using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPSL_ModPatch.PatchUtils
{
    public class PatchInfo
    {
        public VersionRangeInfo[] versionRanges = Array.Empty<VersionRangeInfo>();
    }

    public class VersionRangeInfo
    {
        public string versionRange = string.Empty;
        public string versionFrom = string.Empty;
        public string versionTo = string.Empty;

        public string cleanLauncherPath = string.Empty;
        public string? cleanLauncherUrl = string.Empty;
        public int metadataVersion;
        public MethodsInfo methods = new();

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(versionRange))
                return versionRange;
            if (string.IsNullOrEmpty(versionFrom) || string.IsNullOrEmpty(versionTo))
                return "Undefined version range";
            return $"{versionFrom} – {versionTo}";
        }
    }

    public class MethodsInfo
    {
        public PatchMethodInfo[] patchMethods = Array.Empty<PatchMethodInfo>();
        public GameVersionMethodInfo gameVersionMethod = new();
    }

    public class PatchMethodInfo
    {
        public string name = string.Empty;
        public int patchOffset; // Relative offset from method start.
        public string patchData = string.Empty; // Hex-coded patch data.
        public int patchSize; // Size of patching area.
    }

    public class GameVersionMethodInfo
    {
        public string name = "GameCore.Version$$.cctor";
        public int majorOffset;
        public int minorOffset;
        public int revisionOffset;
        public int typeOffset;
    }
}
