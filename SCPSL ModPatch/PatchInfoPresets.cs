using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPSL_ModPatch
{
    public class PatchInfoPresets
    {
        const byte NOP = 144;
        const byte RET = 195;
        public PatchInfo beforeValidationPatchInfo = new PatchInfo();
        public PatchInfo afterValidationPatchInfo = new PatchInfo();
        public PatchInfo unity2021PatchInfo = new PatchInfo();

        public PatchInfoPresets()
        {
            ////////// 1
            beforeValidationPatchInfo.methods.Add(new MethodInfo("LauncherCommunicator$$GetNativeDelegate<object>", 145, NOP, 3));

            beforeValidationPatchInfo.methods.Add(new MethodInfo("LauncherCommunicator.SendDelegate$$Invoke", 179, NOP, 2));

            beforeValidationPatchInfo.gameVersionMethod.name = "GameCore.Version$$.cctor";
            beforeValidationPatchInfo.gameVersionMethod.majorOffset = 52;
            beforeValidationPatchInfo.gameVersionMethod.minorOffset = 70;
            beforeValidationPatchInfo.gameVersionMethod.patchOffset = 88;
            beforeValidationPatchInfo.gameVersionMethod.typeOffset = 106;

            ////////// 2
            afterValidationPatchInfo.methods.Add(new MethodInfo("LauncherCommunicator$$GetNativeDelegate<object>", 145, NOP, 3));
            afterValidationPatchInfo.methods.Add(new MethodInfo("SimpleMenu.<StartLoad>d__10$$MoveNext", 226, NOP, 3));
            afterValidationPatchInfo.methods.Add(new MethodInfo("LauncherAssetScanProgressBar$$Update", 0, RET, 2));

            afterValidationPatchInfo.methods.Add(new MethodInfo("LauncherCommunicator.SendDelegate$$Invoke", 179, NOP, 2));

            afterValidationPatchInfo.gameVersionMethod.name = "GameCore.Version$$.cctor";
            afterValidationPatchInfo.gameVersionMethod.majorOffset = 52;
            afterValidationPatchInfo.gameVersionMethod.minorOffset = 70;
            afterValidationPatchInfo.gameVersionMethod.patchOffset = 88;
            afterValidationPatchInfo.gameVersionMethod.typeOffset = 106;

            ////////// 3
            unity2021PatchInfo.methods.Add(new MethodInfo("LauncherCommunicator$$GetNativeDelegate<object>", 140, NOP, 3));
            unity2021PatchInfo.methods.Add(new MethodInfo("SimpleMenu.<StartLoad>d__10$$MoveNext", 243, NOP, 3));
            unity2021PatchInfo.methods.Add(new MethodInfo("LauncherAssetScanProgressBar$$Update", 0, RET, 2));

            unity2021PatchInfo.methods.Add(new MethodInfo("LauncherCommunicator$$Send", 120, NOP, 4));

            unity2021PatchInfo.gameVersionMethod.name = "GameCore.Version$$.cctor";
            unity2021PatchInfo.gameVersionMethod.majorOffset = 125;
            unity2021PatchInfo.gameVersionMethod.minorOffset = 143;
            unity2021PatchInfo.gameVersionMethod.patchOffset = 161;
            unity2021PatchInfo.gameVersionMethod.typeOffset = 197;
        }
    }
}
