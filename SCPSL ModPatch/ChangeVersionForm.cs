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

        public ChangeVersionForm(GameVersion version)
        {
            InitializeComponent();
            this.version = version;
            versionTextBox.Text = version.ToString();
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            try
            {
                version = new GameVersion(versionTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Close();
        }


    }
}
