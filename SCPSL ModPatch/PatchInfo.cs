using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPSL_ModPatch
{
    public class PatchInfo
    {
        public List<MethodInfo> methods = new();
        public GameVersionMethodInfo gameVersionMethod = new();
    }

    public class MethodInfo
    {
        public string name;
        public int instructionOffset;
        public byte newInstruction;
        public int instructionSize;

        public MethodInfo(string name, int instructionOffset, byte newInstruction, int instructionSize)
        {
            this.name = name;
            this.instructionOffset = instructionOffset;
            this.newInstruction = newInstruction;
            this.instructionSize = instructionSize;
        }
    }

    public class GameVersionMethodInfo
    {
        public string name = "GameCore.Version$$.cctor";
        public int majorOffset;
        public int minorOffset;
        public int patchOffset;

        public GameVersionMethodInfo()
        {
            majorOffset = 0;
            minorOffset = 0;
            patchOffset = 0;
        }

        public GameVersionMethodInfo(string name, int majorOffset, int minorOffset, int patchOffset)
        {
            this.name = name;
            this.majorOffset = majorOffset;
            this.minorOffset = minorOffset;
            this.patchOffset = patchOffset;
        }
    }
}
