namespace SCPSL_ModPatch
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            applyButton = new Button();
            openIL2CPPDumperDialog = new OpenFileDialog();
            GamePathGroupBox = new GroupBox();
            gamePathTextBox = new TextBox();
            resetButton = new Button();
            UnlicenseGroupBox = new GroupBox();
            unlicenseTextBox = new TextBox();
            autoUpdatePatchInfoCheckBox = new CheckBox();
            GamePathGroupBox.SuspendLayout();
            UnlicenseGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // applyButton
            // 
            applyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            applyButton.Location = new Point(12, 153);
            applyButton.Margin = new Padding(3, 2, 3, 2);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(450, 40);
            applyButton.TabIndex = 0;
            applyButton.Text = "Apply settings";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += applyButton_Click;
            // 
            // openIL2CPPDumperDialog
            // 
            openIL2CPPDumperDialog.Filter = "Executable file|*.exe";
            // 
            // GamePathGroupBox
            // 
            GamePathGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GamePathGroupBox.Controls.Add(gamePathTextBox);
            GamePathGroupBox.Location = new Point(12, 11);
            GamePathGroupBox.Margin = new Padding(3, 2, 3, 2);
            GamePathGroupBox.Name = "GamePathGroupBox";
            GamePathGroupBox.Padding = new Padding(3, 2, 3, 2);
            GamePathGroupBox.Size = new Size(450, 46);
            GamePathGroupBox.TabIndex = 2;
            GamePathGroupBox.TabStop = false;
            GamePathGroupBox.Text = "Game Path";
            // 
            // gamePathTextBox
            // 
            gamePathTextBox.Dock = DockStyle.Top;
            gamePathTextBox.Location = new Point(3, 18);
            gamePathTextBox.Margin = new Padding(3, 2, 3, 2);
            gamePathTextBox.Name = "gamePathTextBox";
            gamePathTextBox.Size = new Size(444, 23);
            gamePathTextBox.TabIndex = 0;
            // 
            // resetButton
            // 
            resetButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resetButton.Location = new Point(12, 197);
            resetButton.Margin = new Padding(3, 2, 3, 2);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(450, 40);
            resetButton.TabIndex = 3;
            resetButton.Text = "Reset Settings";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // UnlicenseGroupBox
            // 
            UnlicenseGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            UnlicenseGroupBox.Controls.Add(unlicenseTextBox);
            UnlicenseGroupBox.Location = new Point(12, 61);
            UnlicenseGroupBox.Margin = new Padding(3, 2, 3, 2);
            UnlicenseGroupBox.Name = "UnlicenseGroupBox";
            UnlicenseGroupBox.Padding = new Padding(3, 2, 3, 2);
            UnlicenseGroupBox.Size = new Size(450, 46);
            UnlicenseGroupBox.TabIndex = 4;
            UnlicenseGroupBox.TabStop = false;
            UnlicenseGroupBox.Text = "Unlicense Path (Themida unpacker)";
            // 
            // unlicenseTextBox
            // 
            unlicenseTextBox.Dock = DockStyle.Top;
            unlicenseTextBox.Location = new Point(3, 18);
            unlicenseTextBox.Margin = new Padding(3, 2, 3, 2);
            unlicenseTextBox.Name = "unlicenseTextBox";
            unlicenseTextBox.Size = new Size(444, 23);
            unlicenseTextBox.TabIndex = 0;
            // 
            // autoUpdatePatchInfoCheckBox
            // 
            autoUpdatePatchInfoCheckBox.AutoSize = true;
            autoUpdatePatchInfoCheckBox.Location = new Point(12, 112);
            autoUpdatePatchInfoCheckBox.Name = "autoUpdatePatchInfoCheckBox";
            autoUpdatePatchInfoCheckBox.Size = new Size(197, 19);
            autoUpdatePatchInfoCheckBox.TabIndex = 5;
            autoUpdatePatchInfoCheckBox.Text = "Automatically update patch info";
            autoUpdatePatchInfoCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(474, 248);
            Controls.Add(autoUpdatePatchInfoCheckBox);
            Controls.Add(UnlicenseGroupBox);
            Controls.Add(resetButton);
            Controls.Add(applyButton);
            Controls.Add(GamePathGroupBox);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(268, 287);
            Name = "SettingsForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            GamePathGroupBox.ResumeLayout(false);
            GamePathGroupBox.PerformLayout();
            UnlicenseGroupBox.ResumeLayout(false);
            UnlicenseGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button applyButton;
        private OpenFileDialog openIL2CPPDumperDialog;
        private GroupBox GamePathGroupBox;
        private TextBox gamePathTextBox;
        private Button resetButton;
        private GroupBox UnlicenseGroupBox;
        private TextBox unlicenseTextBox;
        private CheckBox autoUpdatePatchInfoCheckBox;
    }
}