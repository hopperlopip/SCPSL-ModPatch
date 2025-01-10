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
            gamePathTextBox.Text = _config.GameFolder_Path;
            unlicenseTextBox.Text = _config.Unlicense_Path;
            autoUpdatePatchInfoCheckBox.Checked = _config.AutoUpdatePatchInfo;
        }

        private void ApplySettings()
        {
            _config.GameFolder_Path = gamePathTextBox.Text;
            _config.Unlicense_Path = unlicenseTextBox.Text;
            _config.AutoUpdatePatchInfo = autoUpdatePatchInfoCheckBox.Checked;

            SaveConfiguration();
        }

        private void ResetSettings()
        {
            _config = new Configuration();
            UpdateSettings();
            SaveConfiguration();
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
    }
}
