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
        const string DUMP_FOLDER = @".\";

        ConfigurationClass config;
        List<byte> GameAssembly;
        string il2cpp_output_folder = @$"{Environment.CurrentDirectory}\IL2CPP_Output";
        VersionType versionType = VersionType.v13;

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

        private List<byte> GetGameAssemblyData(string gamePath)
        {
            if (string.IsNullOrEmpty(gamePath))
            {
                throw new GameFolderNotFoundException("Your game path is empty. Please go to the settings and type your game path");
            }
            List<byte> gameAssemblyData;
            string gameAssemblyPath = @$"{gamePath}\GameAssembly.dll";
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
            string gameFolder = config.GameFolder_Path;

            switch (versionType)
            {
                case VersionType.v11:
                    FixMetadataVersion(24, gameFolder);
                    break;

                case VersionType.v12:
                    FixMetadataVersion(24, gameFolder);
                    break;

                case VersionType.v13:
                    FixMetadataVersion(29, gameFolder);
                    break;
            }

            config = SettingsForm.GetConfiguration(CONFIG_FILENAME);
            string gamePath = config.GameFolder_Path;
            string gameAssemblyPath = @$"{gamePath}\GameAssembly.dll";
            string metadataPath = @$"{gamePath}\SCPSL_Data\il2cpp_data\Metadata\global-metadata.dat";

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
            Metadata? metadata;
            Il2Cpp? il2Cpp;
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

            ulong rva = 12811120;
            MessageBox.Show($"{GetRVAOffset(il2Cpp, rva)}");
            MessageBox.Show($"RVA: {rva} Offset: {il2Cpp.MapRTVA(rva) - il2Cpp.ImageBase}");

            Il2CppDumperWorker.Dump(metadata, il2Cpp, DUMP_FOLDER);
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
            string dumpPath = $@"{DUMP_FOLDER}\dump.cs";

            if (!File.Exists(dumpPath))
            {
                MessageBox.Show("The dump file is not found. Please start IL2CPP Dumper first.");
                return;
            }

            PatchGameAssembly_v13(dumpPath, GameAssembly, gameAssemblyPath);
        }

        private void PatchGameAssembly_v13(string dumpPath, List<byte> gameAssemblyData, string gameAssemblyPath)
        {
            var dump = File.ReadAllText(dumpPath);

            MessageBox.Show("ss");
            int firstExceptionOffset = GetOffsetFromFuncName("LauncherCommunicator", "GetNativeDelegate<object>", dump);
            gameAssemblyData = PatchFunction(gameAssemblyData, firstExceptionOffset, 140, NOP, 3);

            int thirdExceptionOffset = GetOffsetFromFuncName("SimpleMenu.<StartLoad>d__10", "MoveNext", dump);
            gameAssemblyData = PatchFunction(gameAssemblyData, thirdExceptionOffset, 243, NOP, 3);

            int validationProgressOffset = GetOffsetFromFuncName("LauncherAssetScanProgressBar", "Update", dump);
            gameAssemblyData = PatchFunction(gameAssemblyData, validationProgressOffset, 0, RET, 2);

            int authFunctionOffset = GetOffsetFromFuncName("LauncherCommunicator", "Send", dump);
            gameAssemblyData = PatchFunction(gameAssemblyData, authFunctionOffset, 120, NOP, 4);

            //test
            MessageBox.Show($"firstExceptionOffset: {firstExceptionOffset}\r\nthirdExceptionOffset {thirdExceptionOffset}\r\n" +
                $"validationProgressOffset: {validationProgressOffset}\r\nauthFunctionOffset: {authFunctionOffset}");

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

        /*private GameVersion GetGameVersion(IL2CPP_Dumper_Output output, List<byte> data)
        {
            int gameVersionOffset = GetOffsetFromFuncName("GameCore.Version$$.cctor", output);
            GameVersion gameVersion = new GameVersion(data[gameVersionOffset + 125], data[gameVersionOffset + 143], data[gameVersionOffset + 161]);
            return gameVersion;
        }*/

        private int GetOffsetFromFuncName(string className, string methodName, string dump)
        {
            MessageBox.Show("ss");
            Regex regex = new Regex(className + @"[\S\s]*RVA: 0x([\dA-F]+) Offset: 0x([\dA-F]+) VA: 0x([\dA-F]+)[\S\s]*" + methodName);
            Match match = regex.Match(dump);
            if (match.Success)
            {
                int offset;
                try
                {
                    offset = Convert.ToInt32(match.Groups[2].Value, 16);
                }
                catch
                {
                    return -1;
                }

                //test
                MessageBox.Show($"Class: {className}\r\nMethod: {methodName}\r\nOffset: {offset}");

                return offset;
            }
            return -1;
        }
    }
}
