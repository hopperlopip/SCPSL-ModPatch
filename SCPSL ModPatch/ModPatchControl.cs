using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCPSL_ModPatch
{
    public partial class ModPatchControl : UserControl
    {
        const byte NOP = 144;
        const byte RET = 195;
        const string CONFIG_FILENAME = @".\config.json";

        ConfigurationClass config;
        List<byte> GameAssembly;
        string il2cpp_output_folder = @$"{Environment.CurrentDirectory}\IL2CPP_Output";
        IL2CPP_Dumper_Output? il2cpp_output = null;
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

            il2cpp_output = null;
            try
            {
                il2cpp_output = IL2CPP_Dumper(config.IL2CPP_Dumper_Path, gameFolder, il2cpp_output_folder);
            }
            catch (Exception ex)
            {
                if (ex is IL2CPPDumperNotFoundException || ex is IL2CPPDumperErrorException)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        /*private void patchButton_Click(object sender, EventArgs e)
        {
            config = SettingsForm.GetConfiguration(CONFIG_FILENAME);
            string gamePath = config.GameFolder_Path;
            GameAssembly = new List<byte>();

            if (il2cpp_output == null)
            {
                MessageBox.Show("You need to run IL2CPP Dumper first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                GameAssembly = GetGameAssemblyData(gamePath);
            }
            catch (Exception ex)
            {
                if (ex is GameFolderNotFoundException || ex is GameAssemblyNotFoundException)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string gameAssemblyPath = @$"{gamePath}\GameAssembly.dll";
            switch (versionType)
            {
                case VersionType.v11:

                    break;

                case VersionType.v12:

                    break;

                case VersionType.v13:
                    PatchGameAssembly_v13(il2cpp_output, GameAssembly, gameAssemblyPath);
                    break;
            }

            //PatchGameAssembly(il2cpp_output, versionType, GameAssembly, @$"{gamePath}\GameAssembly.dll");
        }*/

        private void patchButton_Click(object sender, EventArgs e)
        {
            config = SettingsForm.GetConfiguration(CONFIG_FILENAME);
            string gamePath = config.GameFolder_Path;
            string gameAssemblyPath = @$"{gamePath}\GameAssembly.dll";
            string metadataPath = @$"{gamePath}\SCPSL_Data\il2cpp_data\Metadata\global-metadata.dat";

            if (!File.Exists(gameAssemblyPath) || !File.Exists(metadataPath))
            {
                MessageBox.Show("No files");
                return;
            }
            if (!Il2CppDumperWorker.Init(gameAssemblyPath, metadataPath, out var metadata, out var il2Cpp))
            {
                MessageBox.Show("Il2cppdumper error");
                return;
            }
        }

        private void PatchGameAssembly_v13(IL2CPP_Dumper_Output output, List<byte> gameAssemblyData, string gameAssemblyPath)
        {
            int firstExceptionOffset = GetOffsetFromFuncName("LauncherCommunicator$$GetNativeDelegate<object>", output);
            gameAssemblyData = PatchFunction(gameAssemblyData, firstExceptionOffset, 140, NOP, 3);

            int thirdExceptionOffset = GetOffsetFromFuncName("SimpleMenu.<StartLoad>d__10$$MoveNext", output);
            gameAssemblyData = PatchFunction(gameAssemblyData, thirdExceptionOffset, 243, NOP, 3);

            int validationProgressOffset = GetOffsetFromFuncName("LauncherAssetScanProgressBar$$Update", output);
            gameAssemblyData = PatchFunction(gameAssemblyData, validationProgressOffset, 0, RET, 2);

            int authFunctionOffset = GetOffsetFromFuncName("LauncherCommunicator$$Send", output);
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

        private GameVersion GetGameVersion(IL2CPP_Dumper_Output output, List<byte> data)
        {
            int gameVersionOffset = GetOffsetFromFuncName("GameCore.Version$$.cctor", output);
            GameVersion gameVersion = new GameVersion(data[gameVersionOffset + 125], data[gameVersionOffset + 143], data[gameVersionOffset + 161]);
            return gameVersion;
        }

        private int GetOffsetFromFuncName(string functionName, IL2CPP_Dumper_Output output)
        {
            for (int i = 0; i < output.ScriptMethod.Length; i++)
            {
                if (output.ScriptMethod[i].Name == functionName)
                {
                    return output.ScriptMethod[i].Offset;
                }
            }
            return -1;
        }

        private IL2CPP_Dumper_Output IL2CPP_Dumper(string programPath, string gameFolder, string il2cppOutputFolder)
        {
            if (Directory.Exists(il2cppOutputFolder))
            {
                Directory.Delete(il2cppOutputFolder, true);
            }
            Directory.CreateDirectory(il2cppOutputFolder);

            if (!File.Exists(programPath))
            {
                throw new IL2CPPDumperNotFoundException("IL2CPP Dumper not found. Please type correct path to this program.");
            }

            Process il2cppdumper = new Process();
            //il2cppdumper.StartInfo.CreateNoWindow = true;
            il2cppdumper.StartInfo.FileName = programPath;
            //il2cppdumper.StartInfo.RedirectStandardOutput = true;
            il2cppdumper.StartInfo.RedirectStandardError = true;
            il2cppdumper.StartInfo.RedirectStandardInput = true;
            il2cppdumper.StartInfo.Arguments = @$"""{gameFolder}\GameAssembly.dll"" ""{gameFolder}\SCPSL_Data\il2cpp_data\Metadata\global-metadata.dat"" ""{il2cppOutputFolder}""";
            il2cppdumper.Start();
            //il2cppdumper.BeginOutputReadLine();
            il2cppdumper.StandardInput.WriteLine();
            il2cppdumper.WaitForExit();
            il2cppdumper.Close();

            if (!File.Exists(@$"{il2cppOutputFolder}\script.json"))
            {
                throw new IL2CPPDumperErrorException("IL2CPP Dumper caused an error. Most likely you selected wrong version type.");
            }
            IL2CPP_Dumper_Output? output = JsonConvert.DeserializeObject<IL2CPP_Dumper_Output>(File.ReadAllText(@$"{il2cppOutputFolder}\script.json"));
            if (output == null)
            {
                return new IL2CPP_Dumper_Output();
            }
            return output;
        }
    }
}
