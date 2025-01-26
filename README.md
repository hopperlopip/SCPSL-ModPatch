# SCPSL-ModPatch
A program that lets you disable external game anti-cheat and modify the game freely. Note that servers with enabled `online_mode` in the config will not work.

## How to use it:
All you need is to download the program, open it, type the root game path in the settings, load IL2CPP and then press the "Patch" button.

## What archive should I download?
There are a couple archives in the assets section.
- `SCPSL.ModPatch.dotnet6.0.zip` - is a program that depends on .Net Core 6 framework.
- `SCPSL.ModPatch.Standalone.x86.zip` - is a standalone x86 program that doesn't need anything to run itself.
- `SCPSL.ModPatch.Standalone.x64.zip` - is a standalone x86_64 program that doesn't need anything to run itself.
- `SCPSL.ModPatch.Standalone.zip` - the same as `SCPSL.ModPatch.Standalone.x86.zip`, was often used for versions before 2.0.0.

## Creating your own mod-patches:
In order to create and use your own mod-patches you need to use `patchinfo.json` files.
What is it? It it special json that contains all patch data that ModPatch needs.<br/>
The "clean" version of the `patchinfo.json`, named `patchinfo_template.json`, is located [here](Shared_Files/patchinfo_template/patchinfo_template.json) or in the root folder of the ModPatch program.

Here is an example of patching versions from 10.1.0 to 11.1.4:
```json
{
  "versionRanges": [
    {
      "versionRange": "10.1.0 – 11.1.4",
      "versionFrom": "10.1.0",
      "versionTo": "11.1.4",
      "cleanLauncherPath": "./clean_launchers/2019.4.16f1/SCPSL.exe",
      "cleanLauncherUrl": "https://raw.githubusercontent.com/hopperlopip/SCPSL-ModPatch/refs/heads/master/Shared_Files/clean_launchers/2019.4.16f1/SCPSL.exe",
      "metadataVersion": 24,
      "methods": {
        "patchMethods": [
          {
            "name": "CentralAuthManager$$Authentication",
            "patchOffset": 0,
            "patchData": "[RET]",
            "patchSize": 2
          }
        ],
        "gameVersionMethod": {
          "name": "GameCore.Version$$.cctor",
          "autoFindOffsets": false,
          "majorOffset": 52,
          "minorOffset": 70,
          "revisionOffset": 88,
          "typeOffset": 106
        }
      }
    }
  ]
}
```
- `versionRange` is a "name" of your version range. It will be used in combo box. It is optional field. Default value is `empty string`.
- `versionFrom` is a first game version where your patch works. It is optional field if `versionRange` is not empty, but it is recommended to fill out this field. Default value is `empty string`.
- `versionTo` is a last game version where your patch works. It is optional field, but it is recommended to fill out this field. Default value is `empty string`.
- `cleanLauncherPath` is the path where "clean" version of launcher (SCPSL.exe) is located. Default value is `empty string`.
- `cleanLauncherUrl` is the URL where "clean" version of launcher is located, it is used if user doesn't have the "clean" launcher at `cleanLauncherPath`. It is optional field. Default value is `null`.
- `metadataVersion` is the new metadata version of the `global-metadata.dat`. Default value is `0`.
- `methods` contains patch methods and gameVersion method.
  - `patchMethods` is an array of your patches.
    - `name` is a name of method, you can get proper name from `script.json` in `ScriptMethod` array after using dump feature in [Il2CppDumper](https://github.com/Perfare/Il2CppDumper). Default value is `empty string`.
    - `patchOffset` is a relative offset from the method which name you typed above. Default value is `0`.
    - `patchData` is a hexadecimal representation of the replacing data. It has its own [keywords](#patchdata-keywords) in order to simplify the work. Default value is `empty string`.
    - `patchSize` is a size of patch area which will be replaced by the `patchData`, if the size is bigger than `patchData` size, the next bytes will be replaced by `NOP` assember instruction. It is optional field. If this field is `null` then the patchSize will be taken from lenght of `patchData`. Default value is `null`.
  - `gameVersionMethod` is an object for information of the Game Version. It is optional field. Default value is `null`.
    - `name` is a name of the GameVersion method. Default value is `"GameCore.Version$$.cctor"`.
    - `autoFindOffsets` is a bool field that enabled auto search for GameVersion. If this field is `true` then all offset fields are ignored. Default value is `false`.
    - `majorOffset` is an offset for major (the first one) number of the game version (<ins>14</ins>.0.0).
    - `minorOffset` is an offset for minor (the second one) number of the game version (14.<ins>0</ins>.0).
    - `revisionOffset` is an offset for revision (the third one) number of the game version (14.0.<ins>0</ins>).
    - `typeOffset` is an offset for the version type such as `Release`, `Public Beta`, `Private Beta` etc.

### PatchData keywords:
The `patchData` has some keyword you can use in order to simplify your work:
- `[NOP]` is a binary equivalent of assmebler `nop` instruction.
- `[RET]` is a binary equivalent of assmebler `ret` instruction.
- `[FASM:{asm code here}]` is a special keyword that can assemble instruction, that is placed instead of `{asm code here}`, to its binary equivalent. [EXPERIMENTAL] May not work as expected.

Also you can use ` `(space) and `-` separators but it is not recommended.

## Used libraries/programs:
1) [Il2CppDumper](https://github.com/Perfare/Il2CppDumper) for getting IL2CPP info.
2) [unlicense](https://github.com/ergrelet/unlicense) for unpacking Themida.
3) [Fasm.NET](https://github.com/JamesMenetrey/Fasm.NET) in the FASM binaries.
