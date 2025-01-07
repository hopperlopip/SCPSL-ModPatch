using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPSL_ModPatch.IL2Cpp
{
    [Serializable]
    public class NotRightMetadataVersionException : Exception
    {
        public NotRightMetadataVersionException() { }

        public NotRightMetadataVersionException(string message) : base(message) { }
    }
}
