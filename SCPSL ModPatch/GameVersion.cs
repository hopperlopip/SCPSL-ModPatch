using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPSL_ModPatch
{
    public class GameVersion
    {
        public byte major = 0;
        public byte minor = 0;
        public byte patch = 0;

        public GameVersion(byte major, byte minor, byte patch)
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
            if (!byte.TryParse(version[0], out major))
            {
                throw new Exception("Invalid major string.");
            }
            if (!byte.TryParse(version[1], out minor))
            {
                throw new Exception("Invalid minor string.");
            }
            if (!byte.TryParse(version[2], out patch))
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
