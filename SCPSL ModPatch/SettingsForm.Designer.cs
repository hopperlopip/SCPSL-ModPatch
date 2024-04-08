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
            ApplyButton = new Button();
            IL2CPPDumperGroupBox = new GroupBox();
            il2cppPathTextBox = new TextBox();
            openIL2CPPDumperDialog = new OpenFileDialog();
            GamePathGroupBox = new GroupBox();
            gamePathTextBox = new TextBox();
            resetButton = new Button();
            IL2CPPDumperGroupBox.SuspendLayout();
            GamePathGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // ApplyButton
            // 
            ApplyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ApplyButton.Location = new Point(12, 141);
            ApplyButton.Name = "ApplyButton";
            ApplyButton.Size = new Size(485, 43);
            ApplyButton.TabIndex = 0;
            ApplyButton.Text = "Apply settings";
            ApplyButton.UseVisualStyleBackColor = true;
            ApplyButton.Click += ApplyButton_Click;
            // 
            // IL2CPPDumperGroupBox
            // 
            IL2CPPDumperGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            IL2CPPDumperGroupBox.Controls.Add(il2cppPathTextBox);
            IL2CPPDumperGroupBox.Location = new Point(12, 12);
            IL2CPPDumperGroupBox.Name = "IL2CPPDumperGroupBox";
            IL2CPPDumperGroupBox.Size = new Size(485, 57);
            IL2CPPDumperGroupBox.TabIndex = 1;
            IL2CPPDumperGroupBox.TabStop = false;
            IL2CPPDumperGroupBox.Text = "IL2CPP Dumper Path";
            // 
            // il2cppPathTextBox
            // 
            il2cppPathTextBox.Dock = DockStyle.Fill;
            il2cppPathTextBox.Location = new Point(3, 23);
            il2cppPathTextBox.Name = "il2cppPathTextBox";
            il2cppPathTextBox.Size = new Size(479, 27);
            il2cppPathTextBox.TabIndex = 2;
            // 
            // openIL2CPPDumperDialog
            // 
            openIL2CPPDumperDialog.Filter = "Executable file|*.exe";
            // 
            // GamePathGroupBox
            // 
            GamePathGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GamePathGroupBox.Controls.Add(gamePathTextBox);
            GamePathGroupBox.Location = new Point(12, 75);
            GamePathGroupBox.Name = "GamePathGroupBox";
            GamePathGroupBox.Size = new Size(485, 57);
            GamePathGroupBox.TabIndex = 2;
            GamePathGroupBox.TabStop = false;
            GamePathGroupBox.Text = "Game Path";
            // 
            // gamePathTextBox
            // 
            gamePathTextBox.Dock = DockStyle.Fill;
            gamePathTextBox.Location = new Point(3, 23);
            gamePathTextBox.Name = "gamePathTextBox";
            gamePathTextBox.Size = new Size(479, 27);
            gamePathTextBox.TabIndex = 0;
            // 
            // resetButton
            // 
            resetButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resetButton.Location = new Point(12, 190);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(485, 43);
            resetButton.TabIndex = 3;
            resetButton.Text = "Reset Settings";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 245);
            Controls.Add(resetButton);
            Controls.Add(ApplyButton);
            Controls.Add(GamePathGroupBox);
            Controls.Add(IL2CPPDumperGroupBox);
            MinimumSize = new Size(0, 292);
            Name = "SettingsForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            IL2CPPDumperGroupBox.ResumeLayout(false);
            IL2CPPDumperGroupBox.PerformLayout();
            GamePathGroupBox.ResumeLayout(false);
            GamePathGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button ApplyButton;
        private GroupBox IL2CPPDumperGroupBox;
        private TextBox il2cppPathTextBox;
        private OpenFileDialog openIL2CPPDumperDialog;
        private GroupBox GamePathGroupBox;
        private TextBox gamePathTextBox;
        private Button resetButton;
    }
}