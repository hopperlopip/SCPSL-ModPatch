﻿using Il2CppDumper;
using SCPSL_ModPatch.IL2Cpp;
using System.Text;
using System.Text.RegularExpressions;

namespace SCPSL_ModPatch.PatchUtils
{
    internal class Patcher
    {
        const byte NOP = 144;
        const byte RET = 195;

        Il2cppManager _il2cppManager;
        string _gameAssemblyPath;
        byte[] _gameAssemblyData;
        VersionRangeInfo _versionRangeInfo;

        public Patcher(string gameAssemblyPath, byte[] gameAssemblyData, Il2cppManager il2CppManager, VersionRangeInfo versionRangeInfo)
        {
            _gameAssemblyPath = gameAssemblyPath;
            _gameAssemblyData = gameAssemblyData;
            _versionRangeInfo = versionRangeInfo;
            _il2cppManager = il2CppManager;
        }

        /// <summary>
        /// Gets data of the GameAssembly.
        /// </summary>
        /// <param name="gameAssemblyPath">Path to the GameAssembly file.</param>
        /// <returns></returns>
        public static byte[] GetGameAssemblyData(string gameAssemblyPath)
        {
            byte[] gameAssemblyData = File.ReadAllBytes(gameAssemblyPath);
            return gameAssemblyData;
        }

        /// <summary>
        /// Asynchronously gets data of the GameAssembly.
        /// </summary>
        /// <param name="gameAssemblyPath">Path to the GameAssembly file.</param>
        /// <returns></returns>
        public static async Task<byte[]> GetGameAssemblyDataAsync(string gameAssemblyPath)
        {
            byte[] gameAssemblyData = await File.ReadAllBytesAsync(gameAssemblyPath);
            return gameAssemblyData;
        }

        /// <summary>
        /// Gets RVA (Relative Virtual Address) offset.
        /// </summary>
        /// <param name="il2Cpp"></param>
        /// <param name="addr">RVA of the function</param>
        /// <returns></returns>
        private static ulong GetRVAOffset(Il2Cpp il2Cpp, ulong addr)
        {
            return il2Cpp.GetRVA(il2Cpp.MapRTVA(addr)) - addr;
        }

        /// <summary>
        /// Gets offset from function name.
        /// </summary>
        /// <param name="il2Cpp"></param>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="scriptJson"></param>
        /// <returns></returns>
        [Obsolete]
        private static int GetOffsetFromFuncName(Il2Cpp il2Cpp, string functionName, ScriptJson scriptJson)
        {
            for (int i = 0; i < scriptJson.ScriptMethod.Count; i++)
            {
                if (scriptJson.ScriptMethod[i].Name == functionName)
                {
                    ScriptMethod method = scriptJson.ScriptMethod[i];
                    ulong address = method.Address;
                    ulong offset = address - GetRVAOffset(il2Cpp, address);
                    return Convert.ToInt32(offset);
                }
            }
            return -1;
        }

        /// <summary>
        /// Gets offset from function name.
        /// </summary>
        /// <param name="il2Cpp"></param>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="methodsDictionary">Dictionary that contains all the methods info.</param>
        /// <returns></returns>
        private static int GetOffsetFromFuncName(Il2Cpp il2Cpp, string functionName, IReadOnlyDictionary<string, ScriptMethod> methodsDictionary)
        {
            if (methodsDictionary.ContainsKey(functionName))
            {
                ScriptMethod method = methodsDictionary[functionName];
                ulong address = method.Address;
                ulong offset = address - GetRVAOffset(il2Cpp, address);
                return Convert.ToInt32(offset);
            }
            return -1;
        }

        /// <summary>
        /// Gets offset from function name.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <returns></returns>
        private int GetOffsetFromFuncName(string functionName)
        {
            return GetOffsetFromFuncName(_il2cppManager.IL2CPP, functionName, _il2cppManager.MethodsDictionary);
        }

        /// <summary>
        /// Replaces native launcher with the clean one.
        /// </summary>
        /// <param name="gamePath">Root game folder.</param>
        /// <param name="cleanLauncherPath">Path to the clean launcher.</param>
        private static void ReplaceLauncher(string gamePath, string cleanLauncherPath)
        {
            string nativeLauncherPath = @$"{gamePath}\SCPSL.exe";

            File.Copy(cleanLauncherPath, nativeLauncherPath, true);
        }

        /// <summary>
        /// Replaces native launcher with the clean one.
        /// </summary>
        /// <param name="gamePath">Root game folder.</param>
        public void ReplaceLauncher(string gamePath)
        {
            if (!IsPathValid(_versionRangeInfo.cleanLauncherPath))
            {
                MessageBox.Show("Invalid launcher path in the patch info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(_versionRangeInfo.cleanLauncherPath))
            {
                if (string.IsNullOrEmpty(_versionRangeInfo.cleanLauncherUrl))
                    return;

                DialogResult launcherDialogResult = MessageBox.Show("The native Unity launcher doesn't exist. " +
                    "Without it you can't start the game without anti-cheat.\r\n" +
                    "Would you like to download the launcher from the web?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (launcherDialogResult == DialogResult.Yes)
                {
                    string cleanLauncherUrl = _versionRangeInfo.cleanLauncherUrl;
                    string cleanLauncherPath = _versionRangeInfo.cleanLauncherPath;
                    DownloadLauncher(cleanLauncherUrl, cleanLauncherPath);
                    if (!File.Exists(_versionRangeInfo.cleanLauncherPath))
                        return;
                }
                else
                    return;
            }
            ReplaceLauncher(gamePath, _versionRangeInfo.cleanLauncherPath);
        }

        /// <summary>
        /// Downloads the clean launcher from the web.
        /// </summary>
        /// <param name="cleanLauncherUrl"></param>
        /// <param name="cleanLauncherPath"></param>
        private static void DownloadLauncher(string cleanLauncherUrl, string cleanLauncherPath)
        {
            cleanLauncherPath = Path.GetFullPath(cleanLauncherPath);
            DownloadForm downloadForm = new DownloadForm(cleanLauncherUrl, cleanLauncherPath);
            downloadForm.ShowDialog();
        }

        /// <summary>
        /// Checks if the path is valid.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool IsPathValid(string path)
        {
            try
            {
                path = Path.GetFullPath(path);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Fixes version of the metadata.
        /// </summary>
        /// <param name="metadataVersion">New metadata version.</param>
        /// <param name="gamePath">Root game folder.</param>
        public static void FixMetadataVersion(int metadataVersion, string gamePath)
        {
            string metadataPath = @$"{gamePath}\SCPSL_Data\il2cpp_data\Metadata\global-metadata.dat";
            byte[] metadataData = File.ReadAllBytes(metadataPath);
            byte[] metadataVersionBytes = BitConverter.GetBytes(metadataVersion);
            int versionOffset = 4;
            for (int i = 0; i < metadataVersionBytes.Length; i++)
            {
                metadataData[i + versionOffset] = metadataVersionBytes[i];
            }
            File.WriteAllBytes(metadataPath, metadataData);
        }

        /// <summary>
        /// Fixes version of the metadata.
        /// </summary>
        /// <param name="gamePath">Root game folder.</param>
        public void FixMetadataVersion(string gamePath)
        {
            FixMetadataVersion(_versionRangeInfo.metadataVersion, gamePath);
        }

        /// <summary>
        /// Prepares patch data before patching.
        /// </summary>
        /// <param name="patchData">Raw patch data from user.</param>
        /// <returns>Clean patch data that contains only hex.</returns>
        private string PreparePatchData(string patchData)
        {
            StringBuilder patchDataSB = new StringBuilder(patchData);

            patchDataSB.Replace("[NOP]", "90");
            patchDataSB.Replace("[RET]", "C3");

            //FASM
            MatchCollection matches = Regex.Matches(patchDataSB.ToString(), @"\[FASM:(.*?)\]");
            bool isFasmExisting = FASM.IsFasmExisting();
            if (!isFasmExisting && matches.Count > 0)
            {
                MessageBox.Show("FASM Assembler binary was not found.\r\n" +
                    "All assembly blocks will be skipped.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            foreach (Match match in matches)
            {
                string fasmKeyword = match.Groups[0].Value;
                string mnemonics = match.Groups[1].Value;
                string hexInstructions;
                if (!isFasmExisting)
                {
                    patchDataSB.Replace(fasmKeyword, string.Empty);
                    continue;
                }
                try
                {
                    hexInstructions = FASM.AssembleToHex(mnemonics);
                    patchDataSB.Replace(fasmKeyword, hexInstructions);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"The assembly block ({fasmKeyword}) will be skipped.\r\n" +
                        $"Reason: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    patchDataSB.Replace(fasmKeyword, string.Empty);
                }
            }

            // Replacing a possible " " and "-" separators.
            patchDataSB.Replace(" ", string.Empty);
            patchDataSB.Replace("-", string.Empty);

            patchData = patchDataSB.ToString();
            return patchData;
        }

        /// <summary>
        /// Patches function in the GameAssembly.
        /// </summary>
        /// <param name="functionOffset">Offset of the function.</param>
        /// <param name="patchMethod">Method patch information.</param>
        private void PatchFunction(int functionOffset, PatchMethodInfo patchMethod)
        {
            string rawUserPatchData = patchMethod.patchData;
            string hexPatchData = PreparePatchData(rawUserPatchData);

            byte[] patchData;
            try
            {
                patchData = Convert.FromHexString(hexPatchData);
            }
            catch (Exception ex) when (ex is FormatException)
            {
                throw new FormatException($"The hex-coded patch data ({hexPatchData}) of ({patchMethod.name}) method aren't valid.");
            }
            int patchOffset = functionOffset + patchMethod.patchOffset;
            int patchSize = patchMethod.patchSize;

            for (int i = 0; i < patchSize; i++)
            {
                if (i < patchData.Length)
                {
                    _gameAssemblyData[i + patchOffset] = patchData[i];
                }
                else
                {
                    _gameAssemblyData[i + patchOffset] = NOP;
                }
            }
        }

        /// <summary>
        /// Patches GameAssembly.
        /// </summary>
        public void PatchGameAssembly()
        {
            PatchMethodInfo[] patchMethods = _versionRangeInfo.methods.patchMethods;

            for (int i = 0; i < patchMethods.Length; i++)
            {
                PatchMethodInfo patchMethod = patchMethods[i];
                int functionOffset = GetOffsetFromFuncName(patchMethod.name);
                if (functionOffset < 0)
                {
                    MessageBox.Show($"Couldn't patch ({patchMethod.name}) function", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }
                try
                {
                    PatchFunction(functionOffset, patchMethod);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Saves GameAssembly.
        /// </summary>
        public void SaveGameAssembly()
        {
            File.WriteAllBytes(_gameAssemblyPath, _gameAssemblyData);
        }

        // Game version

        /// <summary>
        /// Gets game version of the game.
        /// </summary>
        /// <returns>Game version of the game.</returns>
        /// <exception cref="GameVersionNotFoundException"></exception>
        public GameVersion GetGameVersion()
        {
            GameVersionMethodInfo gameVersionMethod = _versionRangeInfo.methods.gameVersionMethod;
            int gameVersionOffset = GetOffsetFromFuncName(_il2cppManager.IL2CPP, gameVersionMethod.name, _il2cppManager.MethodsDictionary);
            if (gameVersionOffset < 0)
            {
                throw new GameVersionNotFoundException();
            }
            GameVersion gameVersion = new GameVersion(
                _gameAssemblyData[gameVersionOffset + gameVersionMethod.majorOffset],
                _gameAssemblyData[gameVersionOffset + gameVersionMethod.minorOffset],
                _gameAssemblyData[gameVersionOffset + gameVersionMethod.revisionOffset],
                _gameAssemblyData[gameVersionOffset + gameVersionMethod.typeOffset]);
            return gameVersion;
        }

        /// <summary>
        /// Changes game version of the game.
        /// </summary>
        /// <param name="version">New version of the game.</param>
        public void ChangeGameVersion(GameVersion version)
        {
            GameVersionMethodInfo gameVersionMethod = _versionRangeInfo.methods.gameVersionMethod;
            int gameVersionOffset = GetOffsetFromFuncName(_il2cppManager.IL2CPP, gameVersionMethod.name, _il2cppManager.MethodsDictionary);
            _gameAssemblyData[gameVersionOffset + gameVersionMethod.majorOffset] = version.major;
            _gameAssemblyData[gameVersionOffset + gameVersionMethod.minorOffset] = version.minor;
            _gameAssemblyData[gameVersionOffset + gameVersionMethod.revisionOffset] = version.revision;
            _gameAssemblyData[gameVersionOffset + gameVersionMethod.typeOffset] = (byte)version.type;
        }
    }
}
