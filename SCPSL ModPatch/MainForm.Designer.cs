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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            il2cppButton = new Button();
            openSettingsButton = new Button();
            versionGroupBox = new GroupBox();
            versionComboBox = new ComboBox();
            patchButton = new Button();
            changeVersionButton = new Button();
            versionTextBox = new TextBox();
            versionChangerBox = new GroupBox();
            versionGroupBox.SuspendLayout();
            versionChangerBox.SuspendLayout();
            SuspendLayout();
            // 
            // il2cppButton
            // 
            il2cppButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            il2cppButton.Location = new Point(10, 257);
            il2cppButton.Margin = new Padding(3, 2, 3, 2);
            il2cppButton.Name = "il2cppButton";
            il2cppButton.Size = new Size(511, 40);
            il2cppButton.TabIndex = 3;
            il2cppButton.Text = "Load IL2CPP";
            il2cppButton.UseVisualStyleBackColor = true;
            il2cppButton.Click += il2cppButton_Click;
            // 
            // openSettingsButton
            // 
            openSettingsButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            openSettingsButton.Location = new Point(10, 11);
            openSettingsButton.Margin = new Padding(3, 2, 3, 2);
            openSettingsButton.Name = "openSettingsButton";
            openSettingsButton.Size = new Size(511, 40);
            openSettingsButton.TabIndex = 2;
            openSettingsButton.Text = "Open settings";
            openSettingsButton.UseVisualStyleBackColor = true;
            openSettingsButton.Click += openSettingsButton_Click;
            // 
            // versionGroupBox
            // 
            versionGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            versionGroupBox.Controls.Add(versionComboBox);
            versionGroupBox.Location = new Point(10, 55);
            versionGroupBox.Margin = new Padding(3, 2, 3, 2);
            versionGroupBox.Name = "versionGroupBox";
            versionGroupBox.Padding = new Padding(3, 2, 3, 2);
            versionGroupBox.Size = new Size(511, 47);
            versionGroupBox.TabIndex = 5;
            versionGroupBox.TabStop = false;
            versionGroupBox.Text = "Game version";
            // 
            // versionComboBox
            // 
            versionComboBox.Dock = DockStyle.Top;
            versionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            versionComboBox.FormattingEnabled = true;
            versionComboBox.Location = new Point(3, 18);
            versionComboBox.Name = "versionComboBox";
            versionComboBox.Size = new Size(505, 23);
            versionComboBox.TabIndex = 0;
            // 
            // patchButton
            // 
            patchButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            patchButton.Location = new Point(10, 301);
            patchButton.Margin = new Padding(2);
            patchButton.Name = "patchButton";
            patchButton.Size = new Size(511, 40);
            patchButton.TabIndex = 6;
            patchButton.Text = "Patch!";
            patchButton.UseVisualStyleBackColor = true;
            patchButton.Click += patchButton_Click;
            // 
            // changeVersionButton
            // 
            changeVersionButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            changeVersionButton.Location = new Point(5, 90);
            changeVersionButton.Margin = new Padding(2);
            changeVersionButton.Name = "changeVersionButton";
            changeVersionButton.Size = new Size(502, 45);
            changeVersionButton.TabIndex = 8;
            changeVersionButton.Text = "Change version";
            changeVersionButton.UseVisualStyleBackColor = true;
            changeVersionButton.Click += changeVersionButton_Click;
            // 
            // versionTextBox
            // 
            versionTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            versionTextBox.BackColor = SystemColors.Control;
            versionTextBox.BorderStyle = BorderStyle.None;
            versionTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            versionTextBox.Location = new Point(5, 21);
            versionTextBox.Margin = new Padding(2);
            versionTextBox.Multiline = true;
            versionTextBox.Name = "versionTextBox";
            versionTextBox.ReadOnly = true;
            versionTextBox.Size = new Size(502, 62);
            versionTextBox.TabIndex = 7;
            versionTextBox.Text = "Game version:\r\nN/A";
            versionTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // versionChangerBox
            // 
            versionChangerBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            versionChangerBox.Controls.Add(versionTextBox);
            versionChangerBox.Controls.Add(changeVersionButton);
            versionChangerBox.Location = new Point(10, 106);
            versionChangerBox.Margin = new Padding(2);
            versionChangerBox.Name = "versionChangerBox";
            versionChangerBox.Padding = new Padding(2);
            versionChangerBox.Size = new Size(511, 140);
            versionChangerBox.TabIndex = 9;
            versionChangerBox.TabStop = false;
            versionChangerBox.Text = "Version Changer";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(530, 352);
            Controls.Add(versionChangerBox);
            Controls.Add(patchButton);
            Controls.Add(versionGroupBox);
            Controls.Add(il2cppButton);
            Controls.Add(openSettingsButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(202, 391);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SCPSL ModPatch";
            versionGroupBox.ResumeLayout(false);
            versionChangerBox.ResumeLayout(false);
            versionChangerBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button il2cppButton;
        private Button openSettingsButton;
        private GroupBox versionGroupBox;
        private Button patchButton;
        private Button changeVersionButton;
        private TextBox versionTextBox;
        private GroupBox versionChangerBox;
        private ComboBox versionComboBox;
    }
}