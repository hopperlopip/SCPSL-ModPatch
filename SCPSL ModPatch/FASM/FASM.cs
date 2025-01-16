using System.Diagnostics;

namespace SCPSL_ModPatch
{
    internal class FASM
    {
        const string FASM_FILENAME = @".\fasm_binaries\FASM.exe";

        public static bool IsFasmExisting()
        {
            return File.Exists(FASM_FILENAME);
        }

        public static string AssembleToHex(string mnemonics)
        {
            if (!File.Exists(FASM_FILENAME))
            {
                throw new FasmAssembleException("FASM Assembler binary was not found.");
            }
            Process fasmProcess = new Process();
            fasmProcess.StartInfo = new ProcessStartInfo()
            {
                FileName = FASM_FILENAME,
                Arguments = mnemonics,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            fasmProcess.Start();

            string errorMessage = fasmProcess.StandardError.ReadToEnd();
            string hexInstructions = fasmProcess.StandardOutput.ReadToEnd();

            fasmProcess.WaitForExit();

            if (!string.IsNullOrEmpty(errorMessage) || string.IsNullOrEmpty(hexInstructions))
            {
                throw new FasmAssembleException("Failed to assemble mnemonics.");
            }

            return hexInstructions;
        }
    }
}
