using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SCPSL_ModPatch
{
    [Serializable]
    public class IL2CPPDumperErrorException : Exception
    {
        public IL2CPPDumperErrorException(string message) : base(message) { }
        public IL2CPPDumperErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
