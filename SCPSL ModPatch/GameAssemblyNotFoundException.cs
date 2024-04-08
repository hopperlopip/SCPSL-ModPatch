using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SCPSL_ModPatch
{
    [Serializable]
    public class GameAssemblyNotFoundException : Exception
    {
        public GameAssemblyNotFoundException(string message) :base(message) { }
        public GameAssemblyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
