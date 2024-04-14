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
        ConfigurationClass config;

        public SettingsForm()
        {
            InitializeComponent();
            if (!File.Exists(CONFIG_FILENAME))
            {
                File.WriteAllText(CONFIG_FILENAME, JsonConvert.SerializeObject(new ConfigurationClass(), Formatting.Indented));
            }
            config = GetConfiguration(CONFIG_FILENAME);
            gamePathTextBox.Text = config.GameFolder_Path;
            unlicenseTextBox.Text = config.Unlicense_Path;
        }

        public static ConfigurationClass GetConfiguration(string configPath)
        {
            if (!File.Exists(configPath))
            {
                return new ConfigurationClass();
            }
            string configJSON = File.ReadAllText(configPath);
            ConfigurationClass? config = JsonConvert.DeserializeObject<ConfigurationClass>(configJSON);
            if (config == null)
            {
                return new ConfigurationClass();
            }
            return config;
        }

        private void SaveConfiguration(string configPath, ConfigurationClass config)
        {
            config.GameFolder_Path = gamePathTextBox.Text;
            config.Unlicense_Path = unlicenseTextBox.Text;
            File.WriteAllText(configPath, JsonConvert.SerializeObject(config, Formatting.Indented));
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            SaveConfiguration(CONFIG_FILENAME, config);
        }

        private void UpdateTextBoxes(ConfigurationClass config)
        {
            gamePathTextBox.Text = config.GameFolder_Path;
            unlicenseTextBox.Text = config.Unlicense_Path;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            config = new ConfigurationClass();
            UpdateTextBoxes(config);
            SaveConfiguration(CONFIG_FILENAME, config);
        }
    }
}
