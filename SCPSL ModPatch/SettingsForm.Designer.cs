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
            openIL2CPPDumperDialog = new OpenFileDialog();
            GamePathGroupBox = new GroupBox();
            gamePathTextBox = new TextBox();
            resetButton = new Button();
            UnlicenseGroupBox = new GroupBox();
            unlicenseTextBox = new TextBox();
            GamePathGroupBox.SuspendLayout();
            UnlicenseGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // ApplyButton
            // 
            ApplyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ApplyButton.Location = new Point(12, 146);
            ApplyButton.Name = "ApplyButton";
            ApplyButton.Size = new Size(485, 43);
            ApplyButton.TabIndex = 0;
            ApplyButton.Text = "Apply settings";
            ApplyButton.UseVisualStyleBackColor = true;
            ApplyButton.Click += ApplyButton_Click;
            // 
            // openIL2CPPDumperDialog
            // 
            openIL2CPPDumperDialog.Filter = "Executable file|*.exe";
            // 
            // GamePathGroupBox
            // 
            GamePathGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GamePathGroupBox.Controls.Add(gamePathTextBox);
            GamePathGroupBox.Location = new Point(12, 12);
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
            resetButton.Location = new Point(12, 195);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(485, 43);
            resetButton.TabIndex = 3;
            resetButton.Text = "Reset Settings";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // UnlicenseGroupBox
            // 
            UnlicenseGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            UnlicenseGroupBox.Controls.Add(unlicenseTextBox);
            UnlicenseGroupBox.Location = new Point(12, 75);
            UnlicenseGroupBox.Name = "UnlicenseGroupBox";
            UnlicenseGroupBox.Size = new Size(485, 61);
            UnlicenseGroupBox.TabIndex = 4;
            UnlicenseGroupBox.TabStop = false;
            UnlicenseGroupBox.Text = "Unlicense Path (Themida unpacker)";
            // 
            // unlicenseTextBox
            // 
            unlicenseTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            unlicenseTextBox.Location = new Point(6, 26);
            unlicenseTextBox.Name = "unlicenseTextBox";
            unlicenseTextBox.Size = new Size(473, 27);
            unlicenseTextBox.TabIndex = 0;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 250);
            Controls.Add(UnlicenseGroupBox);
            Controls.Add(resetButton);
            Controls.Add(ApplyButton);
            Controls.Add(GamePathGroupBox);
            MinimumSize = new Size(0, 297);
            Name = "SettingsForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            GamePathGroupBox.ResumeLayout(false);
            GamePathGroupBox.PerformLayout();
            UnlicenseGroupBox.ResumeLayout(false);
            UnlicenseGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button ApplyButton;
        private OpenFileDialog openIL2CPPDumperDialog;
        private GroupBox GamePathGroupBox;
        private TextBox gamePathTextBox;
        private Button resetButton;
        private GroupBox UnlicenseGroupBox;
        private TextBox unlicenseTextBox;
    }
}