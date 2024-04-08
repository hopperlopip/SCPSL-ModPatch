using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPSL_ModPatch
{
    internal class GameVersion
    {
        public int major = 0;
        public int minor = 0;
        public int patch = 0;

        public GameVersion(int major, int minor, int patch)
        {
            this.major = major;
            this.minor = minor;
            this.patch = patch;
        }

        public GameVersion(string versionStr, char separator = '.')
        {
            string[] version = versionStr.Split(separator);
            if (version.Length != 3)
            {
                throw new Exception("Invalid version string.");
            }
            if (!int.TryParse(version[0], out major))
            {
                throw new Exception("Invalid major string.");
            }
            if (!int.TryParse(version[1], out minor))
            {
                throw new Exception("Invalid minor string.");
            }
            if (!int.TryParse(version[2], out patch))
            {
                throw new Exception("Invalid patch string.");
            }
        }

        public override string ToString()
        {
            return $"{major}.{minor}.{patch}";
        }
    }
}
