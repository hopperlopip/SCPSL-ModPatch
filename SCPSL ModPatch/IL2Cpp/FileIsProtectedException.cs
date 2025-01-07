using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPSL_ModPatch.IL2Cpp
{
    [Serializable]
    public class FileIsProtectedException : Exception
    {
        public FileIsProtectedException() { }
    }
}
