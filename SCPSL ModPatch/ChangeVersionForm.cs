using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCPSL_ModPatch
{
    public partial class ChangeVersionForm : Form
    {
        public GameVersion version;
        public bool versionChanged = false;

        public ChangeVersionForm(GameVersion version)
        {
            InitializeComponent();
            versionTypeBox.Items.AddRange(Enum.GetNames(typeof(GameVersion.VersionType)));
            this.version = version;
            versionTextBox.Text = version.ToString();
            versionTypeBox.SelectedIndex = (byte)version.type;
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            try
            {
                version = new GameVersion(versionTextBox.Text, version.type);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            versionChanged = true;
            Close();
        }

        private void versionTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            version.type = (GameVersion.VersionType)versionTypeBox.SelectedIndex;
        }
    }
}
