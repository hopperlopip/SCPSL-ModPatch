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
            modPatchControl1 = new ModPatchControl();
            SuspendLayout();
            // 
            // modPatchControl1
            // 
            modPatchControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            modPatchControl1.Location = new Point(12, 11);
            modPatchControl1.Margin = new Padding(3, 2, 3, 2);
            modPatchControl1.Name = "modPatchControl1";
            modPatchControl1.Size = new Size(496, 357);
            modPatchControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(520, 379);
            Controls.Add(modPatchControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(202, 418);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SCPSL ModPatch";
            ResumeLayout(false);
        }

        #endregion
        private ModPatchControl modPatchControl1;
    }
}