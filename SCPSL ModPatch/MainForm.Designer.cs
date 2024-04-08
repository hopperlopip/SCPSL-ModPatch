namespace SCPSL_ModPatch
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            ModPatchPage = new TabPage();
            modPatchControl1 = new ModPatchControl();
            VersionChangerPage = new TabPage();
            versionChangerControl1 = new VersionChangerControl();
            tabControl1.SuspendLayout();
            ModPatchPage.SuspendLayout();
            VersionChangerPage.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(ModPatchPage);
            tabControl1.Controls.Add(VersionChangerPage);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(544, 402);
            tabControl1.TabIndex = 0;
            // 
            // ModPatchPage
            // 
            ModPatchPage.Controls.Add(modPatchControl1);
            ModPatchPage.Location = new Point(4, 29);
            ModPatchPage.Name = "ModPatchPage";
            ModPatchPage.Padding = new Padding(3);
            ModPatchPage.Size = new Size(536, 369);
            ModPatchPage.TabIndex = 0;
            ModPatchPage.Text = "Mod Patch";
            ModPatchPage.UseVisualStyleBackColor = true;
            // 
            // modPatchControl1
            // 
            modPatchControl1.Dock = DockStyle.Fill;
            modPatchControl1.Location = new Point(3, 3);
            modPatchControl1.Name = "modPatchControl1";
            modPatchControl1.Size = new Size(530, 363);
            modPatchControl1.TabIndex = 0;
            // 
            // VersionChangerPage
            // 
            VersionChangerPage.Controls.Add(versionChangerControl1);
            VersionChangerPage.Location = new Point(4, 29);
            VersionChangerPage.Name = "VersionChangerPage";
            VersionChangerPage.Padding = new Padding(3);
            VersionChangerPage.Size = new Size(536, 369);
            VersionChangerPage.TabIndex = 1;
            VersionChangerPage.Text = "Version Changer";
            VersionChangerPage.UseVisualStyleBackColor = true;
            // 
            // versionChangerControl1
            // 
            versionChangerControl1.Dock = DockStyle.Fill;
            versionChangerControl1.Location = new Point(3, 3);
            versionChangerControl1.Name = "versionChangerControl1";
            versionChangerControl1.Size = new Size(530, 363);
            versionChangerControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 402);
            Controls.Add(tabControl1);
            Name = "MainForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SCPSL ModPatch";
            tabControl1.ResumeLayout(false);
            ModPatchPage.ResumeLayout(false);
            VersionChangerPage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage ModPatchPage;
        private TabPage VersionChangerPage;
        private ModPatchControl modPatchControl1;
        private VersionChangerControl versionChangerControl1;
    }
}