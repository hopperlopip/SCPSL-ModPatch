﻿using Il2CppDumper;
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
        VersionType versionType = VersionType.v13;

        Il2Cpp? il2Cpp = null;
        Metadata? metadata = null;
        ScriptJson scriptJson;

        public ModPatchControl()
        {
            InitializeComponent();
            v11radioButton.CheckedChanged += V11radioButton_CheckedChanged;
            v12radioButton.CheckedChanged += V12radioButton_CheckedChanged;
            v13radioButton.CheckedChanged += V13radioButton_CheckedChanged;
        }

        private void V13radioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (v13radioButton.Checked)
            {
                versionType = VersionType.v13;
            }
        }

        private void V12radioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (v12radioButton.Checked)
            {
                versionType = VersionType.v12;
            }
        }

        private void V11radioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (v11radioButton.Checked)
            {
                versionType = VersionType.v11;
            }
        }

        enum VersionType
        {
            v11,
            v12,
            v13
        }

        private void openSettingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private List<byte> GetGameAssemblyData(string gameAssemblyPath)
        {
            List<byte> gameAssemblyData;
            if (!File.Exists(gameAssemblyPath))
            {
                throw new GameAssemblyNotFoundException("Couldn't find GameAssembly.dll. Please type correct path to your game." +
                    "\r\nIf you typed game folder correctly and your game doesn't have GameAssembly.dll," +
                    " probably you're using game version that doesn't need the Mod Patch.");
            }
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

            if (string.IsNullOrEmpty(gamePath))
            {
                MessageBox.Show("Game path is empty. Please type valid game path in the settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (versionType)
            {
                case VersionType.v11:
                    FixMetadataVersion(24, gamePath);
                    break;

                case VersionType.v12:
                    FixMetadataVersion(24, gamePath);
                    break;

                case VersionType.v13:
                    FixMetadataVersion(29, gamePath);
                    break;
            }

            if (!File.Exists(gameAssemblyPath))
            {
                MessageBox.Show($"File {Path.GetFileName(gameAssemblyPath)} not found");
                return;
            }
            if (!File.Exists(metadataPath))
            {
                MessageBox.Show($"File {Path.GetFileName(metadataPath)} not found");
                return;
            }

            try
            {
                if (!Il2CppDumperWorker.Init(gameAssemblyPath, metadataPath, out metadata, out il2Cpp))
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("Make sure you selected right version of the game.", "IL2CppDumper Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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

            ChangeVersionTextBoxLines(1, GetGameVersion(scriptJson, GameAssembly).ToString());
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

            PatchGameAssembly_v13(scriptJson, GameAssembly, gameAssemblyPath);

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

        private void PatchGameAssembly_v13(ScriptJson scriptJson, List<byte> gameAssemblyData, string gameAssemblyPath)
        {
            int firstExceptionOffset = GetOffsetFromFuncName("LauncherCommunicator$$GetNativeDelegate<object>", scriptJson);
            gameAssemblyData = PatchFunction(gameAssemblyData, firstExceptionOffset, 140, NOP, 3);

            int thirdExceptionOffset = GetOffsetFromFuncName("SimpleMenu.<StartLoad>d__10$$MoveNext", scriptJson);
            gameAssemblyData = PatchFunction(gameAssemblyData, thirdExceptionOffset, 243, NOP, 3);

            int validationProgressOffset = GetOffsetFromFuncName("LauncherAssetScanProgressBar$$Update", scriptJson);
            gameAssemblyData = PatchFunction(gameAssemblyData, validationProgressOffset, 0, RET, 2);

            int authFunctionOffset = GetOffsetFromFuncName("LauncherCommunicator$$Send", scriptJson);
            gameAssemblyData = PatchFunction(gameAssemblyData, authFunctionOffset, 120, NOP, 4);

            /*MessageBox.Show($"firstExceptionOffset: {firstExceptionOffset}\r\nthirdExceptionOffset {thirdExceptionOffset}\r\n" +
                $"validationProgressOffset: {validationProgressOffset}\r\nauthFunctionOffset: {authFunctionOffset}");*/

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

        private GameVersion GetGameVersion(ScriptJson scriptJson, List<byte> data)
        {
            int gameVersionOffset = GetOffsetFromFuncName("GameCore.Version$$.cctor", scriptJson);
            GameVersion gameVersion = new GameVersion(data[gameVersionOffset + 125], data[gameVersionOffset + 143], data[gameVersionOffset + 161]);
            return gameVersion;
        }

        private List<byte> ChangeGameVersion(ScriptJson scriptJson, List<byte> data, GameVersion version)
        {
            int gameVersionOffset = GetOffsetFromFuncName("GameCore.Version$$.cctor", scriptJson);
            data[gameVersionOffset + 125] = version.major;
            data[gameVersionOffset + 143] = version.minor;
            data[gameVersionOffset + 161] = version.patch;
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
            GameAssembly = ChangeGameVersion(scriptJson, GameAssembly, changeVersionForm.version);
            ChangeVersionTextBoxLines(1, changeVersionForm.version.ToString());

            SaveGameAssembly(gameAssemblyPath, GameAssembly);
        }
    }
}
