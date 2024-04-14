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
            modPatchControl1.Dock = DockStyle.Fill;
            modPatchControl1.Location = new Point(0, 0);
            modPatchControl1.MinimumSize = new Size(0, 289);
            modPatchControl1.Name = "modPatchControl1";
            modPatchControl1.Size = new Size(611, 459);
            modPatchControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(611, 459);
            Controls.Add(modPatchControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(0, 506);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SCPSL ModPatch";
            ResumeLayout(false);
        }

        #endregion
        private ModPatchControl modPatchControl1;
    }
}