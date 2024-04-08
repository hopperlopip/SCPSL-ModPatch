using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SCPSL_ModPatch
{
    [Serializable]
    public class IL2CPPDumperNotFoundException : Exception
    {
        public IL2CPPDumperNotFoundException(string message) : base(message) { }
        public IL2CPPDumperNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
