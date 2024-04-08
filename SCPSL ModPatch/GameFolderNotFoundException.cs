using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SCPSL_ModPatch
{
    [Serializable]
    public class GameFolderNotFoundException : Exception
    {
        public GameFolderNotFoundException(string message) : base(message) { }
        public GameFolderNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
