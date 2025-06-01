using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Il2CppDumper;

namespace SCPSL_ModPatch.IL2Cpp
{
    public class Il2CppDumperWorker
    {
        public static void Init(string il2cppPath, string metadataPath, Config config, out Metadata metadata, out Il2Cpp il2Cpp)
        {
            var metadataBytes = File.ReadAllBytes(metadataPath);
            var il2cppBytes = File.ReadAllBytes(il2cppPath);
            Init(il2cppBytes, metadataBytes, config, out metadata, out il2Cpp);
        }

        public static void Init(byte[] il2cppBytes, string metadataPath, Config config, out Metadata metadata, out Il2Cpp il2Cpp)
        {
            var metadataBytes = File.ReadAllBytes(metadataPath);
            Init(il2cppBytes, metadataBytes, config, out metadata, out il2Cpp);
        }

        public static void Init(byte[] il2cppBytes, byte[] metadataBytes, Config config, out Metadata metadata, out Il2Cpp il2Cpp)
        {
            Console.WriteLine("Initializing metadata...");
            metadata = new Metadata(new MemoryStream(metadataBytes));
            Console.WriteLine($"Metadata Version: {metadata.Version}");

            Console.WriteLine("Initializing il2cpp file...");
            var il2cppMagic = BitConverter.ToUInt32(il2cppBytes, 0);
            var il2CppMemory = new MemoryStream(il2cppBytes);
            switch (il2cppMagic)
            {
                default:
                    throw new NotSupportedException("ERROR: il2cpp file not supported.");
                case 0x6D736100:
                    var web = new WebAssembly(il2CppMemory);
                    il2Cpp = web.CreateMemory();
                    break;
                case 0x304F534E:
                    var nso = new NSO(il2CppMemory);
                    il2Cpp = nso.UnCompress();
                    break;
                case 0x905A4D: //PE
                    il2Cpp = new PE(il2CppMemory);
                    break;
                case 0x464c457f: //ELF
                    if (il2cppBytes[4] == 2) //ELF64
                    {
                        il2Cpp = new Elf64(il2CppMemory);
                    }
                    else
                    {
                        il2Cpp = new Elf(il2CppMemory);
                    }
                    break;
                case 0xCAFEBABE: //FAT Mach-O
                case 0xBEBAFECA:
                    var machofat = new MachoFat(new MemoryStream(il2cppBytes));
                    Console.Write("Select Platform: ");
                    for (var i = 0; i < machofat.fats.Length; i++)
                    {
                        var fat = machofat.fats[i];
                        Console.Write(fat.magic == 0xFEEDFACF ? $"{i + 1}.64bit " : $"{i + 1}.32bit ");
                    }
                    Console.WriteLine();
                    var key = Console.ReadKey(true);
                    var index = int.Parse(key.KeyChar.ToString()) - 1;
                    var magic = machofat.fats[index % 2].magic;
                    il2cppBytes = machofat.GetMacho(index % 2);
                    il2CppMemory = new MemoryStream(il2cppBytes);
                    if (magic == 0xFEEDFACF)
                        goto case 0xFEEDFACF;
                    else
                        goto case 0xFEEDFACE;
                case 0xFEEDFACF: // 64bit Mach-O
                    il2Cpp = new Macho64(il2CppMemory);
                    break;
                case 0xFEEDFACE: // 32bit Mach-O
                    il2Cpp = new Macho(il2CppMemory);
                    break;
            }
            var version = config.ForceIl2CppVersion ? config.ForceVersion : metadata.Version;
            il2Cpp.SetProperties(version, metadata.metadataUsagesCount);
            Console.WriteLine($"Il2Cpp Version: {il2Cpp.Version}");
            if (config.ForceDump || il2Cpp.CheckDump())
            {
                if (il2Cpp is ElfBase elf)
                {
                    Console.WriteLine("Detected this may be a dump file.");
                    Console.WriteLine("Input il2cpp dump address or input 0 to force continue:");
                    var DumpAddr = Convert.ToUInt64(Console.ReadLine(), 16);
                    if (DumpAddr != 0)
                    {
                        il2Cpp.ImageBase = DumpAddr;
                        il2Cpp.IsDumped = true;
                        if (!config.NoRedirectedPointer)
                        {
                            elf.Reload();
                        }
                    }
                }
                else
                {
                    il2Cpp.IsDumped = true;
                }
            }

            Console.WriteLine("Searching...");

            var flag = il2Cpp.PlusSearch(metadata.methodDefs.Count(x => x.methodIndex >= 0), metadata.typeDefs.Length, metadata.imageDefs.Length);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (!flag && il2Cpp is PE)
                {
                    throw new FileIsProtectedException();
                    /*Console.WriteLine("Use custom PE loader");
                    il2Cpp = PELoader.Load(il2cppPath);
                    il2Cpp.SetProperties(version, metadata.metadataUsagesCount);
                    flag = il2Cpp.PlusSearch(metadata.methodDefs.Count(x => x.methodIndex >= 0), metadata.typeDefs.Length, metadata.imageDefs.Length);*/
                }
            }
            if (!flag)
            {
                flag = il2Cpp.Search();
            }
            if (!flag)
            {
                flag = il2Cpp.SymbolSearch();
            }
            if (!flag)
            {
                Console.WriteLine("ERROR: Can't use auto mode to process file, try manual mode.");
                Console.Write("Input CodeRegistration: ");
                var codeRegistration = Convert.ToUInt64(Console.ReadLine(), 16);
                Console.Write("Input MetadataRegistration: ");
                var metadataRegistration = Convert.ToUInt64(Console.ReadLine(), 16);
                il2Cpp.Init(codeRegistration, metadataRegistration);
            }
            if (il2Cpp.Version >= 27 && il2Cpp.IsDumped)
            {
                var typeDef = metadata.typeDefs[0];
                var il2CppType = il2Cpp.types[typeDef.byvalTypeIndex];
                metadata.ImageBase = il2CppType.data.typeHandle - metadata.header.typeDefinitionsOffset;
            }
        }

        public static void Dump(Metadata metadata, Il2Cpp il2Cpp, string outputDir)
        {
            Console.WriteLine("Dumping...");
            var executor = new Il2CppExecutor(metadata, il2Cpp);
            Console.WriteLine("Generate struct...");
            var scriptGenerator = new StructGenerator(executor);
            scriptGenerator.WriteScript(outputDir);
            Console.WriteLine("Done!");
        }

        public static void GenerateDummyDll(Metadata metadata, Il2Cpp il2Cpp, string outputDir, string dirName = "Managed")
        {
            var executor = new Il2CppExecutor(metadata, il2Cpp);
            Console.WriteLine("Generate dummy dll...");
            DummyExport(executor, outputDir, true, dirName);
            Console.WriteLine("Done!");
        }

        private static void DummyExport(Il2CppExecutor il2CppExecutor, string outputDir, bool addToken, string dirName = "Managed")
        {
            string dummyDllDirectory = Path.Combine(outputDir, dirName);
            if (Directory.Exists(dummyDllDirectory))
                Directory.Delete(dummyDllDirectory, true);
            Directory.CreateDirectory(dummyDllDirectory);
            var dummy = new DummyAssemblyGenerator(il2CppExecutor, addToken);
            foreach (var assembly in dummy.Assemblies)
            {
                using var stream = new MemoryStream();
                assembly.Write(stream);
                string dllFilePath = Path.Combine(dummyDllDirectory, assembly.MainModule.Name);
                File.WriteAllBytes(dllFilePath, stream.ToArray());
            }
        }
    }
}
