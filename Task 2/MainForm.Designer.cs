namespace Task_2
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
            this.connectButton = new System.Windows.Forms.Button();
            this.chooseFileButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.columnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnFileVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chosenFileNameBox = new System.Windows.Forms.TextBox();
            this.uploadDataButton = new System.Windows.Forms.Button();
            this.uploadFileButton = new System.Windows.Forms.Button();
            this.saveChosenButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveAllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(23, 193);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(86, 23);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect to DB";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(337, 222);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(80, 23);
            this.chooseFileButton.TabIndex = 1;
            this.chooseFileButton.Text = "Choose file";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.chooseFileButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnID,
            this.columnFileVersion,
            this.columnName,
            this.columnDateTime});
            this.dataGridView.Location = new System.Drawing.Point(23, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(479, 175);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView_RowStateChanged);
            // 
            // columnID
            // 
            this.columnID.HeaderText = "ID";
            this.columnID.Name = "columnID";
            this.columnID.ReadOnly = true;
            // 
            // columnFileVersion
            // 
            this.columnFileVersion.HeaderText = "FileVersion";
            this.columnFileVersion.Name = "columnFileVersion";
            // 
            // columnName
            // 
            this.columnName.HeaderText = "Name";
            this.columnName.Name = "columnName";
            // 
            // columnDateTime
            // 
            this.columnDateTime.HeaderText = "DateTime";
            this.columnDateTime.Name = "columnDateTime";
            this.columnDateTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // chosenFileNameBox
            // 
            this.chosenFileNameBox.Location = new System.Drawing.Point(337, 196);
            this.chosenFileNameBox.Name = "chosenFileNameBox";
            this.chosenFileNameBox.ReadOnly = true;
            this.chosenFileNameBox.Size = new System.Drawing.Size(165, 20);
            this.chosenFileNameBox.TabIndex = 3;
            // 
            // uploadDataButton
            // 
            this.uploadDataButton.Enabled = false;
            this.uploadDataButton.Location = new System.Drawing.Point(115, 193);
            this.uploadDataButton.Name = "uploadDataButton";
            this.uploadDataButton.Size = new System.Drawing.Size(126, 23);
            this.uploadDataButton.TabIndex = 4;
            this.uploadDataButton.Text = "Upload changes to DB";
            this.uploadDataButton.UseVisualStyleBackColor = true;
            this.uploadDataButton.Click += new System.EventHandler(this.uploadDataButton_Click);
            // 
            // uploadFileButton
            // 
            this.uploadFileButton.Enabled = false;
            this.uploadFileButton.Location = new System.Drawing.Point(422, 222);
            this.uploadFileButton.Name = "uploadFileButton";
            this.uploadFileButton.Size = new System.Drawing.Size(80, 23);
            this.uploadFileButton.TabIndex = 5;
            this.uploadFileButton.Text = "Upload to DB";
            this.uploadFileButton.UseVisualStyleBackColor = true;
            this.uploadFileButton.Click += new System.EventHandler(this.uploadFileButton_Click);
            // 
            // saveChosenButton
            // 
            this.saveChosenButton.Enabled = false;
            this.saveChosenButton.Location = new System.Drawing.Point(23, 243);
            this.saveChosenButton.Name = "saveChosenButton";
            this.saveChosenButton.Size = new System.Drawing.Size(127, 23);
            this.saveChosenButton.TabIndex = 7;
            this.saveChosenButton.Text = "Save chosen row to file";
            this.saveChosenButton.UseVisualStyleBackColor = true;
            this.saveChosenButton.Click += new System.EventHandler(this.saveChosenButton_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            // 
            // saveAllButton
            // 
            this.saveAllButton.Enabled = false;
            this.saveAllButton.Location = new System.Drawing.Point(156, 243);
            this.saveAllButton.Name = "saveAllButton";
            this.saveAllButton.Size = new System.Drawing.Size(85, 23);
            this.saveAllButton.TabIndex = 8;
            this.saveAllButton.Text = "Save all to file";
            this.saveAllButton.UseVisualStyleBackColor = true;
            this.saveAllButton.Click += new System.EventHandler(this.saveAllButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 280);
            this.Controls.Add(this.saveAllButton);
            this.Controls.Add(this.saveChosenButton);
            this.Controls.Add(this.uploadFileButton);
            this.Controls.Add(this.uploadDataButton);
            this.Controls.Add(this.chosenFileNameBox);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.chooseFileButton);
            this.Controls.Add(this.connectButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox chosenFileNameBox;
        private System.Windows.Forms.Button uploadDataButton;
        private System.Windows.Forms.Button uploadFileButton;
        private System.Windows.Forms.Button saveChosenButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button saveAllButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFileVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDateTime;
    }
}

