using Il2CppDumper;
using Newtonsoft.Json;
using SCPSL_ModPatch.IL2Cpp;
using SCPSL_ModPatch.PatchUtils;
using System.Diagnostics;
using static SCPSL_ModPatch.GameVersion;

namespace SCPSL_ModPatch
{
    public partial class MainForm : Form
    {
        const string PATCHINFO_FILENAME = @".\patchinfo.json";
        const string PATCHINFO_TEMPLATE_FILENAME = @".\patchinfo_template.json";

        const string IL2CPP_IS_NOT_LOADED_MESSAGE = "IL2CPP is not loaded. Please load IL2CPP first.";
        const string IL2CPP_IS_LOADING_MESSAGE = "IL2CPP is loading. Please wait and try again.";
        const string GAME_PATH_IS_EMPTY_MESSAGE = "Game path is empty. Please type valid game path in the settings.";
        const string GAME_PATH_IS_INVALID_MESSAGE = "Game path is invalid. Please type valid game path in the settings.";
        const string IL2CPP_LOADED_FOR_DIFFERENT_VERSIONS_MESSAGE = "IL2CPP is loaded for different versions. Please load IL2CPP again to continue.";
        const string GAME_VERSION_METHOD_IS_NOT_FOUND_MESSAGE = "Game version is not found in \"GameAssembly.dll\".\r\n" +
                    "Try to find game version data in \"global-metadata.dat\".";
        const string VERSION_RANGE_SELECTION_IS_EMPTY_MESSAGE = "Please select game version in the drop-down list.";

        Configuration _config;
        PatchInfo _patchInfo;

        byte[] _gameAssemblyData = Array.Empty<byte>();
        string GamePath { get => _config.GameFolder_Path; }
        string GameAssemblyPath { get => @$"{GamePath}\GameAssembly.dll"; }
        string MetadataPath { get => @$"{GamePath}\SCPSL_Data\il2cpp_data\Metadata\global-metadata.dat"; }

        Il2cppManager _il2CppManager = new();
        GameVersion _gameVersion;
        readonly string _defaultGameVersionString;
        bool _isIl2cppLoading = false;

        VersionRangeInfo SelectedVersionRange { get => (VersionRangeInfo)versionComboBox.SelectedItem; }
        VersionRangeInfo? _il2cppLoadedVersionRange;
        VersionRangeInfo Il2cppLoadedVersionRange
        {
            get
            {
                if (_il2cppLoadedVersionRange == null)
                    throw new NullReferenceException("IL2CPP is not loaded.");
                return _il2cppLoadedVersionRange;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            _config = SettingsForm.GetConfiguration();
            _defaultGameVersionString = versionTextBox.Lines[1];
#if DEBUG
            GeneratePatchInfoTemplate();
#endif
            if (_config.AutoUpdatePatchInfo)
                Updater.UpdatePatchInfo(PATCHINFO_FILENAME);

            _patchInfo = GetPatchInfo();
            UpdateVersionComboBox();
        }

        private PatchInfo GetPatchInfo()
        {
            string patchInfoPath = PATCHINFO_FILENAME;
            if (!File.Exists(patchInfoPath))
            {
                MessageBox.Show($"Patch info (\"{Path.GetFileName(patchInfoPath)}\") file was not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new PatchInfo();
            }
            PatchInfo? patchInfo = JsonConvert.DeserializeObject<PatchInfo>(File.ReadAllText(patchInfoPath));
            if (patchInfo == null)
                throw new Exception("Couldn't deserialize JSON file.");
            return patchInfo;
        }

        private void GeneratePatchInfoTemplate()
        {
            PatchInfo patchInfo = new PatchInfo();
            patchInfo.versionRanges = new VersionRangeInfo[1];
            patchInfo.versionRanges[0] = new VersionRangeInfo();
            patchInfo.versionRanges[0].versionRange = "TEMPLATE_PATCHINFO";
            patchInfo.versionRanges[0].methods.patchMethods = new PatchMethodInfo[1];
            patchInfo.versionRanges[0].methods.patchMethods[0] = new PatchMethodInfo();
            patchInfo.versionRanges[0].methods.patchMethods[0].patchData = Convert.ToHexString(new byte[] { 0 });
            string patchInfoJson = JsonConvert.SerializeObject(patchInfo, Formatting.Indented);
            File.WriteAllText(PATCHINFO_TEMPLATE_FILENAME, patchInfoJson);
        }

        private void UpdateVersionComboBox()
        {
            if (versionComboBox.Items.Count > 0)
                versionComboBox.Items.Clear();
            versionComboBox.Items.AddRange(_patchInfo.versionRanges);
        }

        private void openSettingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
            _config = SettingsForm.GetConfiguration();
        }

        private async void il2cppButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GamePath) || !Directory.Exists(GamePath))
            {
                MessageBox.Show(GAME_PATH_IS_INVALID_MESSAGE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (SelectedVersionRange == null)
            {
                MessageBox.Show(VERSION_RANGE_SELECTION_IS_EMPTY_MESSAGE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _isIl2cppLoading = true;
            il2cppButton.Enabled = false;
            var initButtonText = il2cppButton.Text;
            il2cppButton.Text = "Loading IL2CPP...";

            //Loading IL2CPP
            _il2CppManager = new();
            _il2cppLoadedVersionRange = SelectedVersionRange;
            ChangeVersionTextBoxLines(1, _defaultGameVersionString);
            int metadataVersion = _il2cppLoadedVersionRange.metadataVersion;
            Patcher.FixMetadataVersion(metadataVersion, GamePath);
            bool il2cppManagerLoadSuccess = await LoadIl2cppManager();
            if (!il2cppManagerLoadSuccess)
            {
                goto IL2CPP_LOAD_END;
            }

            // Game version getting and displaying
            _gameAssemblyData = await Patcher.GetGameAssemblyDataAsync(GameAssemblyPath);
            Patcher patcher = new Patcher(GameAssemblyPath, _gameAssemblyData, _il2CppManager, _il2cppLoadedVersionRange);

            GameVersion gameVersion = new();
            try
            {
                gameVersion = patcher.GetGameVersion();
                ChangeVersionTextBoxLines(1, gameVersion.ToString());
                _gameVersion = gameVersion;
            }
            catch (Exception ex) when (ex is GameVersionNotFoundException)
            {
                _il2cppLoadedVersionRange.methods.gameVersionMethod.methodNotFound = true;
                ChangeVersionTextBoxLines(1, "Game version is not found in GameAssembly.dll");
            }

            IL2CPP_LOAD_END:
            il2cppButton.Text = initButtonText;
            il2cppButton.Enabled = true;
            _isIl2cppLoading = false;
        }

        /// <summary>
        /// Loads Il2cppManager properties.
        /// </summary>
        /// <param name="metadataVersion">Version of the metadata.</param>
        /// <returns>Success of the operation.</returns>
        private async Task<bool> LoadIl2cppManager(double? metadataVersion = null)
        {
            try
            {
                await _il2CppManager.LoadIl2cppAsync(GameAssemblyPath, MetadataPath, metadataVersion);
            }
            catch (Exception ex)
            {
                if (ex is FileIsProtectedException)
                {
                    string unpackerPath = _config.Unlicense_Path;
                    Unpacker unpacker = new Unpacker(unpackerPath, GameAssemblyPath);
                    unpacker.UnpackGameAssembly();
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            await _il2CppManager.DumpIl2cppAsync();
            await _il2CppManager.GetScriptJsonAsync();
            _il2CppManager.RemoveDumpFolder();
            return true;
        }

        private void ChangeVersionTextBoxLines(int i, string value)
        {
            var textLines = versionTextBox.Lines;
            textLines[i] = value;
            versionTextBox.Lines = textLines;
        }

        private void patchButton_Click(object sender, EventArgs e)
        {
            if (_isIl2cppLoading)
            {
                MessageBox.Show(IL2CPP_IS_LOADING_MESSAGE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_il2CppManager.IsIl2cppLoaded)
            {
                MessageBox.Show(IL2CPP_IS_NOT_LOADED_MESSAGE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(GamePath))
            {
                MessageBox.Show(GAME_PATH_IS_EMPTY_MESSAGE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsIl2cppLoadedForSelectedVersionRange())
            {
                MessageBox.Show(IL2CPP_LOADED_FOR_DIFFERENT_VERSIONS_MESSAGE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Patcher patcher = new Patcher(GameAssemblyPath, _gameAssemblyData, _il2CppManager, Il2cppLoadedVersionRange);
            patcher.PatchGameAssembly();
            patcher.SaveGameAssembly();
            //patcher.FixMetadataVersion(GamePath); Disabled because we fix metadata during IL2CPP loading.
            patcher.ReplaceLauncher(GamePath);

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void changeVersionButton_Click(object sender, EventArgs e)
        {
            if (_isIl2cppLoading)
            {
                MessageBox.Show(IL2CPP_IS_LOADING_MESSAGE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_il2CppManager.IsIl2cppLoaded)
            {
                MessageBox.Show(IL2CPP_IS_NOT_LOADED_MESSAGE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(GamePath))
            {
                MessageBox.Show(GAME_PATH_IS_EMPTY_MESSAGE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsIl2cppLoadedForSelectedVersionRange())
            {
                MessageBox.Show(IL2CPP_LOADED_FOR_DIFFERENT_VERSIONS_MESSAGE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Il2cppLoadedVersionRange.methods.gameVersionMethod.methodNotFound)
            {
                MessageBox.Show(GAME_VERSION_METHOD_IS_NOT_FOUND_MESSAGE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ChangeVersionForm changeVersionForm;
            try
            {
                changeVersionForm = new ChangeVersionForm(_gameVersion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            changeVersionForm.ShowDialog();
            changeVersionForm.Dispose();

            if (!changeVersionForm.versionChanged)
                return;

            Patcher patcher = new Patcher(GameAssemblyPath, _gameAssemblyData, _il2CppManager, Il2cppLoadedVersionRange);
            patcher.ChangeGameVersion(changeVersionForm.version);
            _gameVersion = changeVersionForm.version;
            ChangeVersionTextBoxLines(1, _gameVersion.ToString());
            patcher.SaveGameAssembly();
        }

        private bool IsIl2cppLoadedForSelectedVersionRange()
        {
            if (Il2cppLoadedVersionRange == SelectedVersionRange)
                return true;
            return false;
        }
    }
}