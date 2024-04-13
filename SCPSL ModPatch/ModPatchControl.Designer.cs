namespace SCPSL_ModPatch
{
    partial class ModPatchControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            openSettingsButton = new Button();
            patchButton = new Button();
            versionGroupBox = new GroupBox();
            radioPanel = new Panel();
            v13radioButton = new RadioButton();
            v12radioButton = new RadioButton();
            v11radioButton = new RadioButton();
            il2cppButton = new Button();
            versionGroupBox.SuspendLayout();
            radioPanel.SuspendLayout();
            SuspendLayout();
            // 
            // openSettingsButton
            // 
            openSettingsButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            openSettingsButton.Location = new Point(3, 3);
            openSettingsButton.Name = "openSettingsButton";
            openSettingsButton.Size = new Size(490, 44);
            openSettingsButton.TabIndex = 0;
            openSettingsButton.Text = "Open settings";
            openSettingsButton.UseVisualStyleBackColor = true;
            openSettingsButton.Click += openSettingsButton_Click;
            // 
            // patchButton
            // 
            patchButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            patchButton.Location = new Point(3, 312);
            patchButton.Name = "patchButton";
            patchButton.Size = new Size(490, 53);
            patchButton.TabIndex = 1;
            patchButton.Text = "Patch!";
            patchButton.UseVisualStyleBackColor = true;
            patchButton.Click += patchButton_Click;
            // 
            // versionGroupBox
            // 
            versionGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            versionGroupBox.Controls.Add(radioPanel);
            versionGroupBox.Location = new Point(3, 53);
            versionGroupBox.Name = "versionGroupBox";
            versionGroupBox.Size = new Size(490, 118);
            versionGroupBox.TabIndex = 2;
            versionGroupBox.TabStop = false;
            versionGroupBox.Text = "Game version";
            // 
            // radioPanel
            // 
            radioPanel.Controls.Add(v13radioButton);
            radioPanel.Controls.Add(v12radioButton);
            radioPanel.Controls.Add(v11radioButton);
            radioPanel.Dock = DockStyle.Fill;
            radioPanel.Location = new Point(3, 23);
            radioPanel.Name = "radioPanel";
            radioPanel.Size = new Size(484, 92);
            radioPanel.TabIndex = 3;
            // 
            // v13radioButton
            // 
            v13radioButton.Appearance = Appearance.Button;
            v13radioButton.AutoSize = true;
            v13radioButton.Checked = true;
            v13radioButton.Dock = DockStyle.Top;
            v13radioButton.Location = new Point(0, 60);
            v13radioButton.Name = "v13radioButton";
            v13radioButton.Size = new Size(484, 30);
            v13radioButton.TabIndex = 2;
            v13radioButton.TabStop = true;
            v13radioButton.Text = "13.0.0 – Current";
            v13radioButton.TextAlign = ContentAlignment.MiddleCenter;
            v13radioButton.UseVisualStyleBackColor = true;
            // 
            // v12radioButton
            // 
            v12radioButton.Appearance = Appearance.Button;
            v12radioButton.AutoSize = true;
            v12radioButton.Dock = DockStyle.Top;
            v12radioButton.Location = new Point(0, 30);
            v12radioButton.Name = "v12radioButton";
            v12radioButton.Size = new Size(484, 30);
            v12radioButton.TabIndex = 1;
            v12radioButton.Text = "12.0.2 – 13.0.0";
            v12radioButton.TextAlign = ContentAlignment.MiddleCenter;
            v12radioButton.UseVisualStyleBackColor = true;
            // 
            // v11radioButton
            // 
            v11radioButton.Appearance = Appearance.Button;
            v11radioButton.AutoSize = true;
            v11radioButton.Dock = DockStyle.Top;
            v11radioButton.Location = new Point(0, 0);
            v11radioButton.Name = "v11radioButton";
            v11radioButton.Size = new Size(484, 30);
            v11radioButton.TabIndex = 0;
            v11radioButton.Text = "11.0 – 12.0.2";
            v11radioButton.TextAlign = ContentAlignment.MiddleCenter;
            v11radioButton.UseVisualStyleBackColor = true;
            // 
            // il2cppButton
            // 
            il2cppButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            il2cppButton.Location = new Point(3, 253);
            il2cppButton.Name = "il2cppButton";
            il2cppButton.Size = new Size(490, 53);
            il2cppButton.TabIndex = 3;
            il2cppButton.Text = "IL2CPP Dumper";
            il2cppButton.UseVisualStyleBackColor = true;
            il2cppButton.Click += il2cppButton_Click;
            // 
            // ModPatchControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(il2cppButton);
            Controls.Add(versionGroupBox);
            Controls.Add(patchButton);
            Controls.Add(openSettingsButton);
            MinimumSize = new Size(0, 289);
            Name = "ModPatchControl";
            Size = new Size(496, 368);
            versionGroupBox.ResumeLayout(false);
            radioPanel.ResumeLayout(false);
            radioPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button openSettingsButton;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button patchButton;
        private GroupBox versionGroupBox;
        private Panel radioPanel;
        private SplitContainer splitContainer1;
        private RichTextBox noticeTextBox;
        private RadioButton v13radioButton;
        private RadioButton v12radioButton;
        private RadioButton v11radioButton;
        private Button il2cppButton;
    }
}
