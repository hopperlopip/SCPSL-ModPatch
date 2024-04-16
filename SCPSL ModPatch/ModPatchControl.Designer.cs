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
            unity2021RadioButton = new RadioButton();
            afterValidationRadioButton = new RadioButton();
            beforeValidationRadioButton = new RadioButton();
            il2cppButton = new Button();
            versionChangerBox = new GroupBox();
            changeVersionButton = new Button();
            versionTextBox = new TextBox();
            versionGroupBox.SuspendLayout();
            radioPanel.SuspendLayout();
            versionChangerBox.SuspendLayout();
            SuspendLayout();
            // 
            // openSettingsButton
            // 
            openSettingsButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            openSettingsButton.Location = new Point(3, 3);
            openSettingsButton.Name = "openSettingsButton";
            openSettingsButton.Size = new Size(607, 44);
            openSettingsButton.TabIndex = 0;
            openSettingsButton.Text = "Open settings";
            openSettingsButton.UseVisualStyleBackColor = true;
            openSettingsButton.Click += openSettingsButton_Click;
            // 
            // patchButton
            // 
            patchButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            patchButton.Location = new Point(3, 455);
            patchButton.Name = "patchButton";
            patchButton.Size = new Size(607, 53);
            patchButton.TabIndex = 2;
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
            versionGroupBox.Size = new Size(607, 118);
            versionGroupBox.TabIndex = 2;
            versionGroupBox.TabStop = false;
            versionGroupBox.Text = "Game version";
            // 
            // radioPanel
            // 
            radioPanel.Controls.Add(unity2021RadioButton);
            radioPanel.Controls.Add(afterValidationRadioButton);
            radioPanel.Controls.Add(beforeValidationRadioButton);
            radioPanel.Dock = DockStyle.Fill;
            radioPanel.Location = new Point(3, 23);
            radioPanel.Name = "radioPanel";
            radioPanel.Size = new Size(601, 92);
            radioPanel.TabIndex = 3;
            // 
            // unity2021RadioButton
            // 
            unity2021RadioButton.Appearance = Appearance.Button;
            unity2021RadioButton.AutoSize = true;
            unity2021RadioButton.Checked = true;
            unity2021RadioButton.Dock = DockStyle.Top;
            unity2021RadioButton.Location = new Point(0, 60);
            unity2021RadioButton.Name = "unity2021RadioButton";
            unity2021RadioButton.Size = new Size(601, 30);
            unity2021RadioButton.TabIndex = 2;
            unity2021RadioButton.TabStop = true;
            unity2021RadioButton.Text = "13.0.0 – Current";
            unity2021RadioButton.TextAlign = ContentAlignment.MiddleCenter;
            unity2021RadioButton.UseVisualStyleBackColor = true;
            // 
            // afterValidationRadioButton
            // 
            afterValidationRadioButton.Appearance = Appearance.Button;
            afterValidationRadioButton.AutoSize = true;
            afterValidationRadioButton.Dock = DockStyle.Top;
            afterValidationRadioButton.Location = new Point(0, 30);
            afterValidationRadioButton.Name = "afterValidationRadioButton";
            afterValidationRadioButton.Size = new Size(601, 30);
            afterValidationRadioButton.TabIndex = 1;
            afterValidationRadioButton.Text = "11.1.5 – 12.0.2";
            afterValidationRadioButton.TextAlign = ContentAlignment.MiddleCenter;
            afterValidationRadioButton.UseVisualStyleBackColor = true;
            // 
            // beforeValidationRadioButton
            // 
            beforeValidationRadioButton.Appearance = Appearance.Button;
            beforeValidationRadioButton.AutoSize = true;
            beforeValidationRadioButton.Dock = DockStyle.Top;
            beforeValidationRadioButton.Location = new Point(0, 0);
            beforeValidationRadioButton.Name = "beforeValidationRadioButton";
            beforeValidationRadioButton.Size = new Size(601, 30);
            beforeValidationRadioButton.TabIndex = 0;
            beforeValidationRadioButton.Text = "10.1.0 – 11.1.4";
            beforeValidationRadioButton.TextAlign = ContentAlignment.MiddleCenter;
            beforeValidationRadioButton.UseVisualStyleBackColor = true;
            // 
            // il2cppButton
            // 
            il2cppButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            il2cppButton.Location = new Point(3, 396);
            il2cppButton.Name = "il2cppButton";
            il2cppButton.Size = new Size(607, 53);
            il2cppButton.TabIndex = 1;
            il2cppButton.Text = "Load IL2CPP";
            il2cppButton.UseVisualStyleBackColor = true;
            il2cppButton.Click += il2cppButton_Click;
            // 
            // versionChangerBox
            // 
            versionChangerBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            versionChangerBox.Controls.Add(changeVersionButton);
            versionChangerBox.Controls.Add(versionTextBox);
            versionChangerBox.Location = new Point(3, 177);
            versionChangerBox.Name = "versionChangerBox";
            versionChangerBox.Size = new Size(607, 162);
            versionChangerBox.TabIndex = 4;
            versionChangerBox.TabStop = false;
            versionChangerBox.Text = "Version Changer";
            // 
            // changeVersionButton
            // 
            changeVersionButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            changeVersionButton.Location = new Point(6, 100);
            changeVersionButton.Name = "changeVersionButton";
            changeVersionButton.Size = new Size(595, 56);
            changeVersionButton.TabIndex = 3;
            changeVersionButton.Text = "Change version";
            changeVersionButton.UseVisualStyleBackColor = true;
            changeVersionButton.Click += changeVersionButton_Click;
            // 
            // versionTextBox
            // 
            versionTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            versionTextBox.BackColor = SystemColors.Control;
            versionTextBox.BorderStyle = BorderStyle.None;
            versionTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            versionTextBox.Location = new Point(6, 26);
            versionTextBox.Multiline = true;
            versionTextBox.Name = "versionTextBox";
            versionTextBox.ReadOnly = true;
            versionTextBox.Size = new Size(595, 62);
            versionTextBox.TabIndex = 1;
            versionTextBox.Text = "Game version:\r\nN/A";
            versionTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ModPatchControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(versionChangerBox);
            Controls.Add(il2cppButton);
            Controls.Add(versionGroupBox);
            Controls.Add(patchButton);
            Controls.Add(openSettingsButton);
            MinimumSize = new Size(0, 461);
            Name = "ModPatchControl";
            Size = new Size(613, 511);
            versionGroupBox.ResumeLayout(false);
            radioPanel.ResumeLayout(false);
            radioPanel.PerformLayout();
            versionChangerBox.ResumeLayout(false);
            versionChangerBox.PerformLayout();
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
        private RadioButton unity2021RadioButton;
        private RadioButton afterValidationRadioButton;
        private RadioButton beforeValidationRadioButton;
        private Button il2cppButton;
        private GroupBox versionChangerBox;
        private TextBox versionTextBox;
        private Button changeVersionButton;
    }
}
