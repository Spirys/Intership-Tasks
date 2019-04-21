namespace Task1
{
    partial class MainForm
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
            this.versionTextBox = new System.Windows.Forms.TextBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // versionTextBox
            // 
            this.versionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.versionTextBox.Location = new System.Drawing.Point(179, 59);
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.ReadOnly = true;
            this.versionTextBox.Size = new System.Drawing.Size(100, 23);
            this.versionTextBox.TabIndex = 0;
            this.versionTextBox.Text = "1.0";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.versionLabel.Location = new System.Drawing.Point(66, 62);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(111, 17);
            this.versionLabel.TabIndex = 1;
            this.versionLabel.Text = "Current Version:";
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(69, 123);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(100, 36);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(179, 123);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(100, 36);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 253);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.versionTextBox);
            this.Name = "MainForm";
            this.Text = "Self-updating App";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox versionTextBox;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

