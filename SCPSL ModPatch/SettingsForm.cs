using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCPSL_ModPatch
{
    public partial class SettingsForm : Form
    {
        const string CONFIG_FILENAME = @".\config.json";
        Configuration _config;
        bool _requireRestart;

        public SettingsForm()
        {
            InitializeComponent();
            _config = GetConfiguration();
            UpdateSettings();
        }

        public static Configuration GetConfiguration()
        {
            if (!File.Exists(CONFIG_FILENAME))
                return new Configuration();
            return Configuration.GetConfiguration(CONFIG_FILENAME);
        }

        public static void SaveConfiguration(Configuration config)
        {
            config.SaveConfiguration(CONFIG_FILENAME);
        }

        private void SaveConfiguration()
        {
            SaveConfiguration(_config);
        }

        private void UpdateSettings()
        {
            UpdateSettings(_config);
        }

        private void UpdateSettings(Configuration config)
        {
            // GameFolder_Path
            gamePathTextBox.Text = config.GameFolder_Path;

            // Unlicense_Path
            unlicenseTextBox.Text = config.Unlicense_Path;

            // AutoUpdatePatchInfo
            autoUpdatePatchInfoCheckBox.Checked = config.AutoUpdatePatchInfo;

            // CustomPatchInfoEnable
            customPatchInfoCheckBox.Checked = config.CustomPatchInfoEnable;

            // CustomPatchInfoPath
            customPatchInfoPathTextBox.Text = config.CustomPatchInfoPath;
        }

        private void ApplySettings()
        {
            // GameFolder_Path
            _config.GameFolder_Path = gamePathTextBox.Text;

            // Unlicense_Path
            _config.Unlicense_Path = unlicenseTextBox.Text;

            // AutoUpdatePatchInfo
            _config.AutoUpdatePatchInfo = autoUpdatePatchInfoCheckBox.Checked;

            // CustomPatchInfoEnable
            if (_config.CustomPatchInfoEnable != customPatchInfoCheckBox.Checked)
                _requireRestart = true;
            _config.CustomPatchInfoEnable = customPatchInfoCheckBox.Checked;

            // CustomPatchInfoPath
            if (_config.CustomPatchInfoPath != customPatchInfoPathTextBox.Text)
                _requireRestart = true;
            _config.CustomPatchInfoPath = customPatchInfoPathTextBox.Text;

            SaveConfiguration();

            if (_requireRestart)
                ShowRestartWarning();
        }

        private void ResetSettings()
        {
            UpdateSettings(new Configuration());
            ApplySettings();
        }

        private void ShowRestartWarning()
        {
            MessageBox.Show("To apply some changes, you must restart the program.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            ApplySettings();
            Close();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetSettings();
        }

        private void browseGamePathButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.Cancel)
                return;
            gamePathTextBox.Text = folderBrowserDialog.SelectedPath;
        }

        private void browseCustomPatchInfoButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.Cancel)
                return;
            customPatchInfoPathTextBox.Text = folderBrowserDialog.SelectedPath;
        }
    }
}
