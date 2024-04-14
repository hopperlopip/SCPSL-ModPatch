using Il2CppDumper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCPSL_ModPatch
{
    public partial class ModPatchControl : UserControl
    {
        const byte NOP = 144;
        const byte RET = 195;

        const string CONFIG_FILENAME = @".\config.json";
        const string IL2CPP_FOLDER = @".\il2cppdumper";
        const string IL2CPP_IS_NULL_MESSAGE = "IL2CPP is not loaded. Please load IL2CPP first.";

        ConfigurationClass config;
        List<byte> GameAssembly;
        VersionType versionType = VersionType.unity2021;

        Il2Cpp? il2Cpp = null;
        Metadata? metadata = null;
        ScriptJson scriptJson;
        PatchInfo patchInfo;

        public ModPatchControl()
        {
            InitializeComponent();
            beforeValidationRadioButton.CheckedChanged += beforeValidationRadioButton_CheckedChanged;
            afterValidationRadioButton.CheckedChanged += afterValidationRadioButton_CheckedChanged;
            unity2021RadioButton.CheckedChanged += unity2021RadioButton_CheckedChanged;
        }

        private void unity2021RadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (unity2021RadioButton.Checked)
            {
                versionType = VersionType.unity2021;
            }
        }

        private void afterValidationRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (afterValidationRadioButton.Checked)
            {
                versionType = VersionType.afterValidation;
            }
        }

        private void beforeValidationRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (beforeValidationRadioButton.Checked)
            {
                versionType = VersionType.beforeValidation;
            }
        }

        enum VersionType
        {
            beforeValidation,
            afterValidation,
            unity2021
        }

        private void openSettingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private List<byte> GetGameAssemblyData(string gameAssemblyPath)
        {
            List<byte> gameAssemblyData;
            gameAssemblyData = File.ReadAllBytes(gameAssemblyPath).ToList();
            return gameAssemblyData;
        }

        private void FixMetadataVersion(byte metadataVersion, string gamePath)
        {
            string metadataPath = @$"{gamePath}\SCPSL_Data\il2cpp_data\Metadata\global-metadata.dat";
            List<byte> metadataData = File.ReadAllBytes(metadataPath).ToList();
            metadataData.RemoveAt(4);
            metadataData.Insert(4, metadataVersion);
            File.WriteAllBytes(metadataPath, metadataData.ToArray());
        }

        private void il2cppButton_Click(object sender, EventArgs e)
        {
            config = SettingsForm.GetConfiguration(CONFIG_FILENAME);
            string gamePath = config.GameFolder_Path;
            string gameAssemblyPath = @$"{gamePath}\GameAssembly.dll";
            string metadataPath = @$"{gamePath}\SCPSL_Data\il2cpp_data\Metadata\global-metadata.dat";
            string scriptPath = @$"{IL2CPP_FOLDER}\script.json";

            il2Cpp = null;
            metadata = null;

            if (string.IsNullOrEmpty(gamePath) || !Directory.Exists(gamePath))
            {
                MessageBox.Show("Game path is invalid. Please type valid game path in the settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(gameAssemblyPath))
            {
                MessageBox.Show($"Couldn't find GameAssembly.dll. Please type correct path to your game." +
                    "\r\nIf you typed game folder correctly and your game doesn't have GameAssembly.dll," +
                    " probably you're using game version that doesn't need the Mod Patch.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!File.Exists(metadataPath))
            {
                MessageBox.Show($"Couldn't find {Path.GetFileName(metadataPath)}. Please type correct path to your game.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PatchInfos patchInfos = new();
            switch (versionType)
            {
                case VersionType.beforeValidation:
                    FixMetadataVersion(24, gamePath);
                    patchInfo = patchInfos.beforeValidationPatchInfo;
                    break;

                case VersionType.afterValidation:
                    FixMetadataVersion(24, gamePath);
                    patchInfo = patchInfos.afterValidationPatchInfo;
                    break;

                case VersionType.unity2021:
                    FixMetadataVersion(29, gamePath);
                    patchInfo = patchInfos.unity2021PatchInfo;
                    break;
            }

            try
            {
                if (!Il2CppDumperWorker.Init(gameAssemblyPath, metadataPath, out metadata, out il2Cpp))
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                if (ex is FileIsProtectedException)
                {
                    DialogResult userChoice = MessageBox.Show("Looks like GameAssembly.dll is virtualized by protector (most likely Themida).\r\n" +
                        "Do you want to try to unpack GameAssembly.dll by unpacker?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (userChoice == DialogResult.No)
                    {
                        return;
                    }
                    string unpackerPath = config.Unlicense_Path;
                    if (!File.Exists(unpackerPath))
                    {
                        MessageBox.Show("Path is invalid. Please type valid path and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    StartThemidaUnpackerProcess(unpackerPath, gameAssemblyPath);
                    MessageBox.Show("Please start IL2CPP loading again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("Make sure you selected right version of the game.", "IL2CppDumper Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            GameAssembly = GetGameAssemblyData(gameAssemblyPath);

            Directory.CreateDirectory(IL2CPP_FOLDER);
            Il2CppDumperWorker.Dump(metadata, il2Cpp, @$"{IL2CPP_FOLDER}\");
            GC.Collect();
            GC.WaitForPendingFinalizers();

            try
            {
                scriptJson = GetScriptJSON(scriptPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (Directory.Exists(IL2CPP_FOLDER))
            {
                Directory.Delete(IL2CPP_FOLDER, true);
            }

            ChangeVersionTextBoxLines(1, GetGameVersion(scriptJson, patchInfo, GameAssembly).ToString());
        }

        private void StartThemidaUnpackerProcess(string unpackerPath, string gameAssemblyPath)
        {
            Process unpacker = new Process();
            unpacker.StartInfo.FileName = unpackerPath;
            unpacker.StartInfo.Arguments = $"\"{gameAssemblyPath}\"";
            unpacker.Start();
            unpacker.WaitForExit();
            unpacker.Close();

            string unpackerFolder = GetParentFolderFromFilePath(unpackerPath);
            string unpackedGameAssemblyPath = @$"{unpackerFolder}\unpacked_GameAssembly.dll";
            File.Delete(gameAssemblyPath);
            File.Move(unpackedGameAssemblyPath, gameAssemblyPath);
        }

        private string GetParentFolderFromFilePath(string filePath)
        {
            return filePath.Replace(@$"\{Path.GetFileName(filePath)}", string.Empty);
        }

        private void ChangeVersionTextBoxLines(int i, string value)
        {
            var textLines = versionTextBox.Lines;
            textLines[i] = value;
            versionTextBox.Lines = textLines;
        }

        private ulong GetRVAOffset(Il2Cpp il2Cpp, ulong addr)
        {
            return il2Cpp.GetRVA(il2Cpp.MapRTVA(addr)) - addr;
        }

        private void patchButton_Click(object sender, EventArgs e)
        {
            config = SettingsForm.GetConfiguration(CONFIG_FILENAME);
            string gamePath = config.GameFolder_Path;
            string gameAssemblyPath = @$"{gamePath}\GameAssembly.dll";

            if (il2Cpp == null)
            {
                MessageBox.Show(IL2CPP_IS_NULL_MESSAGE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(gamePath))
            {
                MessageBox.Show("Game path is empty. Please type valid game path in the settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PatchGameAssembly(scriptJson, patchInfo, GameAssembly, gameAssemblyPath);

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private ScriptJson GetScriptJSON(string scriptPath)
        {
            ScriptJson? scriptJson = JsonConvert.DeserializeObject<ScriptJson>(File.ReadAllText(scriptPath));
            if (scriptJson == null)
            {
                throw new Exception("Couldn't deserialize JSON file.");
            }
            return scriptJson;
        }

        private void PatchGameAssembly(ScriptJson scriptJson, PatchInfo patchInfo, List<byte> gameAssemblyData, string gameAssemblyPath)
        {
            for (int i = 0; i < patchInfo.methods.Count; i++)
            {
                MethodInfo method = patchInfo.methods[i];
                int functionOffset = GetOffsetFromFuncName(method.name, scriptJson);
                gameAssemblyData = PatchFunction(gameAssemblyData, functionOffset, method.instructionOffset, method.newInstruction, method.instructionSize);
            }

            SaveGameAssembly(gameAssemblyPath, gameAssemblyData);
        }

        private void SaveGameAssembly(string gameAssemblyPath, List<byte> gameAssemblyData)
        {
            File.WriteAllBytes(gameAssemblyPath, gameAssemblyData.ToArray());
        }

        private List<byte> PatchFunction(List<byte> gameAssemblyData, int functionOffset, int relativeInstructionOffset, byte newInstruction, int instructionSize)
        {
            int instructionOffset = functionOffset + relativeInstructionOffset;
            gameAssemblyData.RemoveRange(instructionOffset, instructionSize);
            for (int i = 0; i < instructionSize; i++)
            {
                if (i == 0)
                {
                    gameAssemblyData.Insert(instructionOffset + i, newInstruction);
                    continue;
                }
                gameAssemblyData.Insert(instructionOffset + i, NOP);
            }
            return gameAssemblyData;
        }

        private GameVersion GetGameVersion(ScriptJson scriptJson, PatchInfo patchInfo, List<byte> data)
        {
            int gameVersionOffset = GetOffsetFromFuncName(patchInfo.gameVersionMethod.name, scriptJson);
            GameVersion gameVersion = new GameVersion(
                data[gameVersionOffset + patchInfo.gameVersionMethod.majorOffset],
                data[gameVersionOffset + patchInfo.gameVersionMethod.minorOffset],
                data[gameVersionOffset + patchInfo.gameVersionMethod.patchOffset]);
            return gameVersion;
        }

        private List<byte> ChangeGameVersion(ScriptJson scriptJson, PatchInfo patchInfo, List<byte> data, GameVersion version)
        {
            int gameVersionOffset = GetOffsetFromFuncName(patchInfo.gameVersionMethod.name, scriptJson);
            data[gameVersionOffset + patchInfo.gameVersionMethod.majorOffset] = version.major;
            data[gameVersionOffset + patchInfo.gameVersionMethod.minorOffset] = version.minor;
            data[gameVersionOffset + patchInfo.gameVersionMethod.patchOffset] = version.patch;
            return data;
        }

        private int GetOffsetFromFuncName(string functionName, ScriptJson scriptJson)
        {
            for (int i = 0; i < scriptJson.ScriptMethod.Count; i++)
            {
                if (scriptJson.ScriptMethod[i].Name == functionName)
                {
                    ulong address = scriptJson.ScriptMethod[i].Address;
                    ulong offset = address - GetRVAOffset(il2Cpp, address);
                    return Convert.ToInt32(offset);
                }
            }
            return -1;
        }

        private void changeVersionButton_Click(object sender, EventArgs e)
        {
            if (il2Cpp == null)
            {
                MessageBox.Show(IL2CPP_IS_NULL_MESSAGE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            config = SettingsForm.GetConfiguration(CONFIG_FILENAME);
            string gamePath = config.GameFolder_Path;
            string gameAssemblyPath = @$"{gamePath}\GameAssembly.dll";

            ChangeVersionForm changeVersionForm = new ChangeVersionForm(new GameVersion(versionTextBox.Lines[1]));
            changeVersionForm.ShowDialog();

            if (!changeVersionForm.versionChanged)
            {
                return;
            }

            GameAssembly = ChangeGameVersion(scriptJson, patchInfo, GameAssembly, changeVersionForm.version);
            ChangeVersionTextBoxLines(1, changeVersionForm.version.ToString());
            SaveGameAssembly(gameAssemblyPath, GameAssembly);
        }
    }
}
