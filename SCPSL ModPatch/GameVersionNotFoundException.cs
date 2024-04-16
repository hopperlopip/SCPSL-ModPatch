using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPSL_ModPatch
{
    public class GameVersionNotFoundException : Exception
    {
        public GameVersionNotFoundException() { }
        public GameVersionNotFoundException(string message) : base(message) { }
    }
}
