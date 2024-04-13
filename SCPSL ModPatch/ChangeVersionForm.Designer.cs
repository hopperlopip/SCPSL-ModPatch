namespace SCPSL_ModPatch
{
    partial class ChangeVersionForm
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
            changeButton = new Button();
            versionTextBox = new MaskedTextBox();
            SuspendLayout();
            // 
            // changeButton
            // 
            changeButton.Location = new Point(12, 45);
            changeButton.Name = "changeButton";
            changeButton.Size = new Size(519, 52);
            changeButton.TabIndex = 0;
            changeButton.Text = "Change version";
            changeButton.UseVisualStyleBackColor = true;
            changeButton.Click += changeButton_Click;
            // 
            // versionTextBox
            // 
            versionTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            versionTextBox.Culture = new System.Globalization.CultureInfo("en-US");
            versionTextBox.Location = new Point(12, 12);
            versionTextBox.Name = "versionTextBox";
            versionTextBox.Size = new Size(519, 27);
            versionTextBox.TabIndex = 1;
            // 
            // ChangeVersionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(543, 110);
            Controls.Add(versionTextBox);
            Controls.Add(changeButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ChangeVersionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Change version";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button changeButton;
        private MaskedTextBox versionTextBox;
    }
}