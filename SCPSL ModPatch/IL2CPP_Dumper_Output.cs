using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPSL_ModPatch
{
    class IL2CPP_Dumper_Output
    {
        public ScriptMethod[] ScriptMethod = new ScriptMethod[0];
    }

    class ScriptMethod
    {
        public int Address;
        public int Offset
        {
            get { return Address - 4096; }
        }
        public string Name = string.Empty;
    }
}
