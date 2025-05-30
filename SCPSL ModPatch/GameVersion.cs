﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPSL_ModPatch
{
    public struct GameVersion
    {
        public byte major = 0;
        public byte minor = 0;
        public byte revision = 0;
        public VersionType type = 0;

        public GameVersion(byte major, byte minor, byte revision, byte type)
        {
            this.major = major;
            this.minor = minor;
            this.revision = revision;
            this.type = (VersionType)type;
        }

        public GameVersion(string versionStr, VersionType type, char separator = '.')
        {
            string[] version = versionStr.Split(separator);
            if (version.Length != 3)
            {
                throw new Exception("Invalid version.");
            }
            if (!byte.TryParse(version[0], out major))
            {
                throw new Exception("Invalid major number. Value must be from 0 to 255.");
            }
            if (!byte.TryParse(version[1], out minor))
            {
                throw new Exception("Invalid minor number. Value must be from 0 to 255.");
            }
            if (!byte.TryParse(version[2], out revision))
            {
                throw new Exception("Invalid revision number. Value must be from 0 to 255.");
            }
            this.type = type;
        }

        public override string ToString()
        {
            return $"{major}.{minor}.{revision}";
        }

        public enum VersionType : byte
        {
            Release,
            PublicRC,
            PublicBeta,
            PrivateRC,
            PrivateRCStreamingForbidden,
            PrivateBeta,
            PrivateBetaStreamingForbidden,
            Development,
            Nightly
        }
    }
}
