
namespace decryptor
{
    partial class decryptor
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectFile = new System.Windows.Forms.Button();
            this.decryptAlphabet = new System.Windows.Forms.GroupBox();
            this.alphabetEn = new System.Windows.Forms.RadioButton();
            this.alphabetRu = new System.Windows.Forms.RadioButton();
            this.decryptType = new System.Windows.Forms.CheckedListBox();
            this.decrypt = new System.Windows.Forms.Button();
            this.outText = new System.Windows.Forms.RichTextBox();
            this.clearOutText = new System.Windows.Forms.Button();
            this.alphabetBinary = new System.Windows.Forms.RadioButton();
            this.decryptAlphabet.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectFile
            // 
            this.selectFile.Location = new System.Drawing.Point(12, 12);
            this.selectFile.Name = "selectFile";
            this.selectFile.Size = new System.Drawing.Size(200, 23);
            this.selectFile.TabIndex = 0;
            this.selectFile.Text = "Выбрать файл";
            this.selectFile.UseVisualStyleBackColor = true;
            this.selectFile.Click += new System.EventHandler(this.selectFile_Click);
            // 
            // decryptAlphabet
            // 
            this.decryptAlphabet.Controls.Add(this.alphabetBinary);
            this.decryptAlphabet.Controls.Add(this.alphabetEn);
            this.decryptAlphabet.Controls.Add(this.alphabetRu);
            this.decryptAlphabet.Location = new System.Drawing.Point(12, 41);
            this.decryptAlphabet.Name = "decryptAlphabet";
            this.decryptAlphabet.Size = new System.Drawing.Size(200, 92);
            this.decryptAlphabet.TabIndex = 3;
            this.decryptAlphabet.TabStop = false;
            this.decryptAlphabet.Text = "Алфавит";
            // 
            // alphabetEn
            // 
            this.alphabetEn.AutoSize = true;
            this.alphabetEn.Location = new System.Drawing.Point(6, 42);
            this.alphabetEn.Name = "alphabetEn";
            this.alphabetEn.Size = new System.Drawing.Size(129, 17);
            this.alphabetEn.TabIndex = 1;
            this.alphabetEn.Text = "Английский, 26 букв";
            this.alphabetEn.UseVisualStyleBackColor = true;
            // 
            // alphabetRu
            // 
            this.alphabetRu.AutoSize = true;
            this.alphabetRu.Checked = true;
            this.alphabetRu.Location = new System.Drawing.Point(6, 19);
            this.alphabetRu.Name = "alphabetRu";
            this.alphabetRu.Size = new System.Drawing.Size(119, 17);
            this.alphabetRu.TabIndex = 0;
            this.alphabetRu.TabStop = true;
            this.alphabetRu.Text = "Русский, 32 буквы";
            this.alphabetRu.UseVisualStyleBackColor = true;
            // 
            // decryptType
            // 
            this.decryptType.CheckOnClick = true;
            this.decryptType.FormattingEnabled = true;
            this.decryptType.Items.AddRange(new object[] {
            "Частотный анализ",
            "Линейный шифр",
            "Потоковый шифр"});
            this.decryptType.Location = new System.Drawing.Point(12, 139);
            this.decryptType.Name = "decryptType";
            this.decryptType.Size = new System.Drawing.Size(200, 49);
            this.decryptType.TabIndex = 5;
            // 
            // decrypt
            // 
            this.decrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.decrypt.Enabled = false;
            this.decrypt.Location = new System.Drawing.Point(12, 415);
            this.decrypt.Name = "decrypt";
            this.decrypt.Size = new System.Drawing.Size(200, 23);
            this.decrypt.TabIndex = 6;
            this.decrypt.Text = "Дешифровать";
            this.decrypt.UseVisualStyleBackColor = true;
            this.decrypt.Click += new System.EventHandler(this.decrypt_Click);
            // 
            // outText
            // 
            this.outText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.outText.Location = new System.Drawing.Point(218, 12);
            this.outText.Name = "outText";
            this.outText.ReadOnly = true;
            this.outText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.outText.Size = new System.Drawing.Size(570, 426);
            this.outText.TabIndex = 8;
            this.outText.Text = "";
            // 
            // clearOutText
            // 
            this.clearOutText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearOutText.Location = new System.Drawing.Point(12, 386);
            this.clearOutText.Name = "clearOutText";
            this.clearOutText.Size = new System.Drawing.Size(200, 23);
            this.clearOutText.TabIndex = 9;
            this.clearOutText.Text = "Очистить";
            this.clearOutText.UseVisualStyleBackColor = true;
            this.clearOutText.Click += new System.EventHandler(this.clearOutText_Click);
            // 
            // alphabetBinary
            // 
            this.alphabetBinary.AutoSize = true;
            this.alphabetBinary.Location = new System.Drawing.Point(6, 65);
            this.alphabetBinary.Name = "alphabetBinary";
            this.alphabetBinary.Size = new System.Drawing.Size(76, 17);
            this.alphabetBinary.TabIndex = 2;
            this.alphabetBinary.Text = "Бинарный";
            this.alphabetBinary.UseVisualStyleBackColor = true;
            // 
            // decryptor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clearOutText);
            this.Controls.Add(this.outText);
            this.Controls.Add(this.decrypt);
            this.Controls.Add(this.decryptType);
            this.Controls.Add(this.decryptAlphabet);
            this.Controls.Add(this.selectFile);
            this.Name = "decryptor";
            this.Text = "Мой маленький дешифратор";
            this.decryptAlphabet.ResumeLayout(false);
            this.decryptAlphabet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button selectFile;
        private System.Windows.Forms.GroupBox decryptAlphabet;
        private System.Windows.Forms.RadioButton alphabetEn;
        private System.Windows.Forms.RadioButton alphabetRu;
        private System.Windows.Forms.CheckedListBox decryptType;
        private System.Windows.Forms.Button decrypt;
        private System.Windows.Forms.RichTextBox outText;
        private System.Windows.Forms.Button clearOutText;
        private System.Windows.Forms.RadioButton alphabetBinary;
    }
}

