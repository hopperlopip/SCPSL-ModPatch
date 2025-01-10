namespace SCPSL_ModPatch
{
    partial class DownloadForm
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
            downloadProgressBar = new ProgressBar();
            cancelDownloadingButton = new Button();
            fileNameTextBox = new TextBox();
            SuspendLayout();
            // 
            // downloadProgressBar
            // 
            downloadProgressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            downloadProgressBar.Location = new Point(12, 101);
            downloadProgressBar.Name = "downloadProgressBar";
            downloadProgressBar.Size = new Size(298, 23);
            downloadProgressBar.TabIndex = 1;
            // 
            // cancelDownloadingButton
            // 
            cancelDownloadingButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelDownloadingButton.Location = new Point(316, 101);
            cancelDownloadingButton.Name = "cancelDownloadingButton";
            cancelDownloadingButton.Size = new Size(80, 23);
            cancelDownloadingButton.TabIndex = 2;
            cancelDownloadingButton.Text = "Cancel";
            cancelDownloadingButton.UseVisualStyleBackColor = true;
            cancelDownloadingButton.Click += cancelDownloadingButton_Click;
            // 
            // fileNameTextBox
            // 
            fileNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fileNameTextBox.BorderStyle = BorderStyle.None;
            fileNameTextBox.Location = new Point(12, 12);
            fileNameTextBox.Multiline = true;
            fileNameTextBox.Name = "fileNameTextBox";
            fileNameTextBox.ReadOnly = true;
            fileNameTextBox.ScrollBars = ScrollBars.Both;
            fileNameTextBox.Size = new Size(384, 83);
            fileNameTextBox.TabIndex = 3;
            fileNameTextBox.Text = "File name: \"{0}\" from \"{1}\".";
            // 
            // DownloadForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(408, 136);
            Controls.Add(fileNameTextBox);
            Controls.Add(cancelDownloadingButton);
            Controls.Add(downloadProgressBar);
            Name = "DownloadForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Downloading...";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ProgressBar downloadProgressBar;
        private Button cancelDownloadingButton;
        private TextBox fileNameTextBox;
    }
}