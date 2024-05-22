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
            radioPanel = new Panel();
            unity2021RadioButton = new RadioButton();
            afterValidationRadioButton = new RadioButton();
            beforeValidationRadioButton = new RadioButton();
            patchButton = new Button();
            changeVersionButton = new Button();
            versionTextBox = new TextBox();
            versionChangerBox = new GroupBox();
            versionGroupBox.SuspendLayout();
            radioPanel.SuspendLayout();
            versionChangerBox.SuspendLayout();
            SuspendLayout();
            // 
            // il2cppButton
            // 
            il2cppButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            il2cppButton.Location = new Point(12, 382);
            il2cppButton.Margin = new Padding(4, 2, 4, 2);
            il2cppButton.Name = "il2cppButton";
            il2cppButton.Size = new Size(639, 50);
            il2cppButton.TabIndex = 3;
            il2cppButton.Text = "Load IL2CPP";
            il2cppButton.UseVisualStyleBackColor = true;
            il2cppButton.Click += il2cppButton_Click;
            // 
            // openSettingsButton
            // 
            openSettingsButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            openSettingsButton.Location = new Point(12, 14);
            openSettingsButton.Margin = new Padding(4, 2, 4, 2);
            openSettingsButton.Name = "openSettingsButton";
            openSettingsButton.Size = new Size(639, 41);
            openSettingsButton.TabIndex = 2;
            openSettingsButton.Text = "Open settings";
            openSettingsButton.UseVisualStyleBackColor = true;
            openSettingsButton.Click += openSettingsButton_Click;
            // 
            // versionGroupBox
            // 
            versionGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            versionGroupBox.Controls.Add(radioPanel);
            versionGroupBox.Location = new Point(12, 60);
            versionGroupBox.Margin = new Padding(4, 2, 4, 2);
            versionGroupBox.Name = "versionGroupBox";
            versionGroupBox.Padding = new Padding(4, 2, 4, 2);
            versionGroupBox.Size = new Size(639, 129);
            versionGroupBox.TabIndex = 5;
            versionGroupBox.TabStop = false;
            versionGroupBox.Text = "Game version";
            // 
            // radioPanel
            // 
            radioPanel.Controls.Add(unity2021RadioButton);
            radioPanel.Controls.Add(afterValidationRadioButton);
            radioPanel.Controls.Add(beforeValidationRadioButton);
            radioPanel.Dock = DockStyle.Fill;
            radioPanel.Location = new Point(4, 22);
            radioPanel.Margin = new Padding(4, 2, 4, 2);
            radioPanel.Name = "radioPanel";
            radioPanel.Size = new Size(631, 105);
            radioPanel.TabIndex = 3;
            // 
            // unity2021RadioButton
            // 
            unity2021RadioButton.Appearance = Appearance.Button;
            unity2021RadioButton.AutoSize = true;
            unity2021RadioButton.Checked = true;
            unity2021RadioButton.Dock = DockStyle.Top;
            unity2021RadioButton.Location = new Point(0, 60);
            unity2021RadioButton.Margin = new Padding(4, 2, 4, 2);
            unity2021RadioButton.Name = "unity2021RadioButton";
            unity2021RadioButton.Size = new Size(631, 30);
            unity2021RadioButton.TabIndex = 2;
            unity2021RadioButton.TabStop = true;
            unity2021RadioButton.Text = "13.0.0 – Current";
            unity2021RadioButton.TextAlign = ContentAlignment.MiddleCenter;
            unity2021RadioButton.UseVisualStyleBackColor = true;
            unity2021RadioButton.CheckedChanged += unity2021RadioButton_CheckedChanged;
            // 
            // afterValidationRadioButton
            // 
            afterValidationRadioButton.Appearance = Appearance.Button;
            afterValidationRadioButton.AutoSize = true;
            afterValidationRadioButton.Dock = DockStyle.Top;
            afterValidationRadioButton.Location = new Point(0, 30);
            afterValidationRadioButton.Margin = new Padding(4, 2, 4, 2);
            afterValidationRadioButton.Name = "afterValidationRadioButton";
            afterValidationRadioButton.Size = new Size(631, 30);
            afterValidationRadioButton.TabIndex = 1;
            afterValidationRadioButton.Text = "11.1.5 – 12.0.2";
            afterValidationRadioButton.TextAlign = ContentAlignment.MiddleCenter;
            afterValidationRadioButton.UseVisualStyleBackColor = true;
            afterValidationRadioButton.CheckedChanged += afterValidationRadioButton_CheckedChanged;
            // 
            // beforeValidationRadioButton
            // 
            beforeValidationRadioButton.Appearance = Appearance.Button;
            beforeValidationRadioButton.AutoSize = true;
            beforeValidationRadioButton.Dock = DockStyle.Top;
            beforeValidationRadioButton.Location = new Point(0, 0);
            beforeValidationRadioButton.Margin = new Padding(4, 2, 4, 2);
            beforeValidationRadioButton.Name = "beforeValidationRadioButton";
            beforeValidationRadioButton.Size = new Size(631, 30);
            beforeValidationRadioButton.TabIndex = 0;
            beforeValidationRadioButton.Text = "10.1.0 – 11.1.4";
            beforeValidationRadioButton.TextAlign = ContentAlignment.MiddleCenter;
            beforeValidationRadioButton.UseVisualStyleBackColor = true;
            beforeValidationRadioButton.CheckedChanged += beforeValidationRadioButton_CheckedChanged;
            // 
            // patchButton
            // 
            patchButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            patchButton.Location = new Point(12, 436);
            patchButton.Margin = new Padding(3, 2, 3, 2);
            patchButton.Name = "patchButton";
            patchButton.Size = new Size(639, 46);
            patchButton.TabIndex = 6;
            patchButton.Text = "Patch!";
            patchButton.UseVisualStyleBackColor = true;
            patchButton.Click += patchButton_Click;
            // 
            // changeVersionButton
            // 
            changeVersionButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            changeVersionButton.Location = new Point(6, 113);
            changeVersionButton.Name = "changeVersionButton";
            changeVersionButton.Size = new Size(627, 56);
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
            versionTextBox.Location = new Point(6, 26);
            versionTextBox.Multiline = true;
            versionTextBox.Name = "versionTextBox";
            versionTextBox.ReadOnly = true;
            versionTextBox.Size = new Size(627, 78);
            versionTextBox.TabIndex = 7;
            versionTextBox.Text = "Game version:\r\nN/A";
            versionTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // versionChangerBox
            // 
            versionChangerBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            versionChangerBox.Controls.Add(versionTextBox);
            versionChangerBox.Controls.Add(changeVersionButton);
            versionChangerBox.Location = new Point(12, 194);
            versionChangerBox.Name = "versionChangerBox";
            versionChangerBox.Size = new Size(639, 175);
            versionChangerBox.TabIndex = 9;
            versionChangerBox.TabStop = false;
            versionChangerBox.Text = "Version Changer";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(663, 493);
            Controls.Add(versionChangerBox);
            Controls.Add(patchButton);
            Controls.Add(versionGroupBox);
            Controls.Add(il2cppButton);
            Controls.Add(openSettingsButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 2, 4, 2);
            MinimumSize = new Size(248, 540);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SCPSL ModPatch";
            versionGroupBox.ResumeLayout(false);
            radioPanel.ResumeLayout(false);
            radioPanel.PerformLayout();
            versionChangerBox.ResumeLayout(false);
            versionChangerBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button il2cppButton;
        private Button openSettingsButton;
        private GroupBox versionGroupBox;
        private Panel radioPanel;
        private RadioButton unity2021RadioButton;
        private RadioButton afterValidationRadioButton;
        private RadioButton beforeValidationRadioButton;
        private Button patchButton;
        private Button changeVersionButton;
        private TextBox versionTextBox;
        private GroupBox versionChangerBox;
    }
}