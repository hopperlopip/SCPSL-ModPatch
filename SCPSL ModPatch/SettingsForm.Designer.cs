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
            ApplyButton.Location = new Point(10, 118);
            ApplyButton.Margin = new Padding(3, 2, 3, 2);
            ApplyButton.Name = "ApplyButton";
            ApplyButton.Size = new Size(426, 32);
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
            GamePathGroupBox.Location = new Point(10, 9);
            GamePathGroupBox.Margin = new Padding(3, 2, 3, 2);
            GamePathGroupBox.Name = "GamePathGroupBox";
            GamePathGroupBox.Padding = new Padding(3, 2, 3, 2);
            GamePathGroupBox.Size = new Size(426, 48);
            GamePathGroupBox.TabIndex = 2;
            GamePathGroupBox.TabStop = false;
            GamePathGroupBox.Text = "Game Path";
            // 
            // gamePathTextBox
            // 
            gamePathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gamePathTextBox.Location = new Point(3, 18);
            gamePathTextBox.Margin = new Padding(3, 2, 3, 2);
            gamePathTextBox.Name = "gamePathTextBox";
            gamePathTextBox.Size = new Size(420, 23);
            gamePathTextBox.TabIndex = 0;
            // 
            // resetButton
            // 
            resetButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resetButton.Location = new Point(10, 154);
            resetButton.Margin = new Padding(3, 2, 3, 2);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(426, 32);
            resetButton.TabIndex = 3;
            resetButton.Text = "Reset Settings";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // UnlicenseGroupBox
            // 
            UnlicenseGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            UnlicenseGroupBox.Controls.Add(unlicenseTextBox);
            UnlicenseGroupBox.Location = new Point(10, 61);
            UnlicenseGroupBox.Margin = new Padding(3, 2, 3, 2);
            UnlicenseGroupBox.Name = "UnlicenseGroupBox";
            UnlicenseGroupBox.Padding = new Padding(3, 2, 3, 2);
            UnlicenseGroupBox.Size = new Size(426, 50);
            UnlicenseGroupBox.TabIndex = 4;
            UnlicenseGroupBox.TabStop = false;
            UnlicenseGroupBox.Text = "Unlicense Path (Themida unpacker)";
            // 
            // unlicenseTextBox
            // 
            unlicenseTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            unlicenseTextBox.Location = new Point(5, 20);
            unlicenseTextBox.Margin = new Padding(3, 2, 3, 2);
            unlicenseTextBox.Name = "unlicenseTextBox";
            unlicenseTextBox.Size = new Size(416, 23);
            unlicenseTextBox.TabIndex = 0;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(447, 202);
            Controls.Add(UnlicenseGroupBox);
            Controls.Add(resetButton);
            Controls.Add(ApplyButton);
            Controls.Add(GamePathGroupBox);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(247, 241);
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