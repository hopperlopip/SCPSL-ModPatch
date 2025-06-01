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
            GamePathGroupBox = new GroupBox();
            browseGamePathButton = new Button();
            gamePathTextBox = new TextBox();
            resetButton = new Button();
            UnlicenseGroupBox = new GroupBox();
            browseUnlicensePathButton = new Button();
            unlicenseTextBox = new TextBox();
            autoUpdatePatchInfoCheckBox = new CheckBox();
            CustomPatchInfoGroupBox = new GroupBox();
            browseCustomPatchInfoPathButton = new Button();
            customPatchInfoCheckBox = new CheckBox();
            customPatchInfoPathTextBox = new TextBox();
            folderBrowserDialog = new FolderBrowserDialog();
            openJsonFileDialog = new OpenFileDialog();
            openExeFileDialog = new OpenFileDialog();
            createManagedFolderCheckBox = new CheckBox();
            GamePathGroupBox.SuspendLayout();
            UnlicenseGroupBox.SuspendLayout();
            CustomPatchInfoGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // applyButton
            // 
            applyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            applyButton.Location = new Point(12, 252);
            applyButton.Margin = new Padding(3, 2, 3, 2);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(450, 40);
            applyButton.TabIndex = 0;
            applyButton.Text = "Apply settings";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += applyButton_Click;
            // 
            // GamePathGroupBox
            // 
            GamePathGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GamePathGroupBox.Controls.Add(browseGamePathButton);
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
            // browseGamePathButton
            // 
            browseGamePathButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            browseGamePathButton.Location = new Point(369, 18);
            browseGamePathButton.Name = "browseGamePathButton";
            browseGamePathButton.Size = new Size(75, 23);
            browseGamePathButton.TabIndex = 1;
            browseGamePathButton.Text = "Browse";
            browseGamePathButton.UseVisualStyleBackColor = true;
            browseGamePathButton.Click += browseGamePathButton_Click;
            // 
            // gamePathTextBox
            // 
            gamePathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gamePathTextBox.Location = new Point(3, 18);
            gamePathTextBox.Margin = new Padding(3, 2, 3, 2);
            gamePathTextBox.Name = "gamePathTextBox";
            gamePathTextBox.Size = new Size(360, 23);
            gamePathTextBox.TabIndex = 0;
            // 
            // resetButton
            // 
            resetButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resetButton.Location = new Point(12, 296);
            resetButton.Margin = new Padding(3, 2, 3, 2);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(450, 40);
            resetButton.TabIndex = 3;
            resetButton.Text = "Reset settings";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // UnlicenseGroupBox
            // 
            UnlicenseGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            UnlicenseGroupBox.Controls.Add(browseUnlicensePathButton);
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
            // browseUnlicensePathButton
            // 
            browseUnlicensePathButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            browseUnlicensePathButton.Location = new Point(369, 18);
            browseUnlicensePathButton.Name = "browseUnlicensePathButton";
            browseUnlicensePathButton.Size = new Size(75, 23);
            browseUnlicensePathButton.TabIndex = 1;
            browseUnlicensePathButton.Text = "Browse";
            browseUnlicensePathButton.UseVisualStyleBackColor = true;
            browseUnlicensePathButton.Click += browseUnlicensePathButton_Click;
            // 
            // unlicenseTextBox
            // 
            unlicenseTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            unlicenseTextBox.Location = new Point(3, 18);
            unlicenseTextBox.Margin = new Padding(3, 2, 3, 2);
            unlicenseTextBox.Name = "unlicenseTextBox";
            unlicenseTextBox.Size = new Size(360, 23);
            unlicenseTextBox.TabIndex = 0;
            // 
            // autoUpdatePatchInfoCheckBox
            // 
            autoUpdatePatchInfoCheckBox.AutoSize = true;
            autoUpdatePatchInfoCheckBox.Location = new Point(12, 112);
            autoUpdatePatchInfoCheckBox.Name = "autoUpdatePatchInfoCheckBox";
            autoUpdatePatchInfoCheckBox.Size = new Size(271, 19);
            autoUpdatePatchInfoCheckBox.TabIndex = 5;
            autoUpdatePatchInfoCheckBox.Text = "Automatically update patch info from the web";
            autoUpdatePatchInfoCheckBox.UseVisualStyleBackColor = true;
            // 
            // CustomPatchInfoGroupBox
            // 
            CustomPatchInfoGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CustomPatchInfoGroupBox.Controls.Add(browseCustomPatchInfoPathButton);
            CustomPatchInfoGroupBox.Controls.Add(customPatchInfoCheckBox);
            CustomPatchInfoGroupBox.Controls.Add(customPatchInfoPathTextBox);
            CustomPatchInfoGroupBox.Location = new Point(12, 162);
            CustomPatchInfoGroupBox.Name = "CustomPatchInfoGroupBox";
            CustomPatchInfoGroupBox.Size = new Size(450, 75);
            CustomPatchInfoGroupBox.TabIndex = 6;
            CustomPatchInfoGroupBox.TabStop = false;
            CustomPatchInfoGroupBox.Text = "Custom Patch Info";
            // 
            // browseCustomPatchInfoPathButton
            // 
            browseCustomPatchInfoPathButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            browseCustomPatchInfoPathButton.Location = new Point(369, 47);
            browseCustomPatchInfoPathButton.Name = "browseCustomPatchInfoPathButton";
            browseCustomPatchInfoPathButton.Size = new Size(75, 23);
            browseCustomPatchInfoPathButton.TabIndex = 2;
            browseCustomPatchInfoPathButton.Text = "Browse";
            browseCustomPatchInfoPathButton.UseVisualStyleBackColor = true;
            browseCustomPatchInfoPathButton.Click += browseCustomPatchInfoPathButton_Click;
            // 
            // customPatchInfoCheckBox
            // 
            customPatchInfoCheckBox.AutoSize = true;
            customPatchInfoCheckBox.Location = new Point(6, 22);
            customPatchInfoCheckBox.Name = "customPatchInfoCheckBox";
            customPatchInfoCheckBox.Size = new Size(161, 19);
            customPatchInfoCheckBox.TabIndex = 1;
            customPatchInfoCheckBox.Text = "Enable custom patch info";
            customPatchInfoCheckBox.UseVisualStyleBackColor = true;
            // 
            // customPatchInfoPathTextBox
            // 
            customPatchInfoPathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            customPatchInfoPathTextBox.Location = new Point(3, 47);
            customPatchInfoPathTextBox.Name = "customPatchInfoPathTextBox";
            customPatchInfoPathTextBox.Size = new Size(360, 23);
            customPatchInfoPathTextBox.TabIndex = 0;
            // 
            // openJsonFileDialog
            // 
            openJsonFileDialog.Filter = "JSON files|*.json|All files|*.*";
            // 
            // openExeFileDialog
            // 
            openExeFileDialog.Filter = "EXE files|*.exe|All files|*.*";
            // 
            // createManagedFolderCheckBox
            // 
            createManagedFolderCheckBox.AutoSize = true;
            createManagedFolderCheckBox.Location = new Point(12, 137);
            createManagedFolderCheckBox.Name = "createManagedFolderCheckBox";
            createManagedFolderCheckBox.Size = new Size(367, 19);
            createManagedFolderCheckBox.TabIndex = 7;
            createManagedFolderCheckBox.Text = "Create Managed folder with dummy DLLs during IL2CPP loading";
            createManagedFolderCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(474, 347);
            Controls.Add(createManagedFolderCheckBox);
            Controls.Add(CustomPatchInfoGroupBox);
            Controls.Add(autoUpdatePatchInfoCheckBox);
            Controls.Add(UnlicenseGroupBox);
            Controls.Add(resetButton);
            Controls.Add(applyButton);
            Controls.Add(GamePathGroupBox);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(312, 358);
            Name = "SettingsForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            GamePathGroupBox.ResumeLayout(false);
            GamePathGroupBox.PerformLayout();
            UnlicenseGroupBox.ResumeLayout(false);
            UnlicenseGroupBox.PerformLayout();
            CustomPatchInfoGroupBox.ResumeLayout(false);
            CustomPatchInfoGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button applyButton;
        private GroupBox GamePathGroupBox;
        private TextBox gamePathTextBox;
        private Button resetButton;
        private GroupBox UnlicenseGroupBox;
        private TextBox unlicenseTextBox;
        private CheckBox autoUpdatePatchInfoCheckBox;
        private GroupBox CustomPatchInfoGroupBox;
        private CheckBox customPatchInfoCheckBox;
        private TextBox customPatchInfoPathTextBox;
        private Button browseGamePathButton;
        private Button browseCustomPatchInfoPathButton;
        private FolderBrowserDialog folderBrowserDialog;
        private Button browseUnlicensePathButton;
        private OpenFileDialog openJsonFileDialog;
        private OpenFileDialog openExeFileDialog;
        private CheckBox createManagedFolderCheckBox;
    }
}