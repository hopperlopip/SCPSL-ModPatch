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
            versionTypeBox = new ComboBox();
            SuspendLayout();
            // 
            // changeButton
            // 
            changeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            changeButton.Location = new Point(11, 68);
            changeButton.Margin = new Padding(2, 2, 2, 2);
            changeButton.Name = "changeButton";
            changeButton.Size = new Size(386, 42);
            changeButton.TabIndex = 0;
            changeButton.Text = "Change version";
            changeButton.UseVisualStyleBackColor = true;
            changeButton.Click += changeButton_Click;
            // 
            // versionTextBox
            // 
            versionTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            versionTextBox.Culture = new System.Globalization.CultureInfo("en-US");
            versionTextBox.Location = new Point(11, 11);
            versionTextBox.Margin = new Padding(2, 2, 2, 2);
            versionTextBox.Name = "versionTextBox";
            versionTextBox.Size = new Size(386, 23);
            versionTextBox.TabIndex = 1;
            // 
            // versionTypeBox
            // 
            versionTypeBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            versionTypeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            versionTypeBox.FormattingEnabled = true;
            versionTypeBox.Location = new Point(11, 38);
            versionTypeBox.Margin = new Padding(2, 2, 2, 2);
            versionTypeBox.MaxDropDownItems = 9;
            versionTypeBox.Name = "versionTypeBox";
            versionTypeBox.Size = new Size(386, 23);
            versionTypeBox.TabIndex = 10;
            versionTypeBox.SelectedIndexChanged += versionTypeBox_SelectedIndexChanged;
            // 
            // ChangeVersionForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(408, 121);
            Controls.Add(versionTypeBox);
            Controls.Add(versionTextBox);
            Controls.Add(changeButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            Name = "ChangeVersionForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Change version";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button changeButton;
        private MaskedTextBox versionTextBox;
        private ComboBox versionTypeBox;
    }
}