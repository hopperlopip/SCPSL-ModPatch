using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPSL_ModPatch
{
    internal class Unpacker
    {
        string _unpackerPath;
        string _gameAssemblyPath;

        public Unpacker(string unpackerPath, string gameAssemblyPath)
        {
            _unpackerPath = unpackerPath;
            _gameAssemblyPath = gameAssemblyPath;
        }

        public void UnpackGameAssembly()
        {
            DialogResult userChoice = MessageBox.Show("Looks like GameAssembly.dll is virtualized by protector (most likely Themida).\r\n" +
                "Do you want to try to unpack GameAssembly.dll by unpacker?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (userChoice == DialogResult.No)
                return;
            if (!File.Exists(_unpackerPath))
            {
                MessageBox.Show("Path is invalid. Please type valid path and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            StartThemidaUnpackerProcess();

            string unpackerFolder = MainForm.GetParentFolderFromFilePath(_unpackerPath);
            string unpackedGameAssemblyPath = @$"{unpackerFolder}\unpacked_GameAssembly.dll";
            if (!File.Exists(unpackedGameAssemblyPath))
            {
                MessageBox.Show("Unpacked file doesn't exist. Try to unpack GameAssembly.dll again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            File.Delete(_gameAssemblyPath);
            File.Move(unpackedGameAssemblyPath, _gameAssemblyPath);

            MessageBox.Show("Please start IL2CPP load again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void StartThemidaUnpackerProcess()
        {
            Process unpacker = new Process();
            unpacker.StartInfo.FileName = _unpackerPath;
            unpacker.StartInfo.Arguments = $"\"{_gameAssemblyPath}\"";
            unpacker.Start();
            unpacker.WaitForExit();
            unpacker.Close();
        }
    }
}
