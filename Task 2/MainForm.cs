using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Task_2
{
    public partial class MainForm : Form
    {
        private readonly int status;
        private DataGridViewRow chosenRow;
        private readonly Logger logger;

        public MainForm(int status, Logger logger)
        {
            this.status = status;
            this.logger = logger;
            InitializeComponent();

            this.logger.Info("Initialize MainForm");
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            updateDataGridViewFromDb();

            uploadDataButton.Enabled = true;
            saveAllButton.Enabled = true;

            this.logger.Info("Click connect button");
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = string.Empty; ;
            openFileDialog.ShowDialog();

            this.logger.Info("Choose file");
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var pattern = @"^[а-яА-ЯёЁ]{1,100}_(\d|\d{10}|\d{14,20})_.{1,7}\.xml$";
            var match = Regex.Match(openFileDialog.SafeFileName, pattern);
            if (!match.Success)
            {
                MessageBox.Show("File name does not match pattern", "File name error", MessageBoxButtons.OK);
                openFileDialog.FileName = string.Empty;

                this.logger.Warning("File name does not match regex");

                return;
            }
            else
            {
                chosenFileNameBox.Text = openFileDialog.SafeFileName;
                uploadFileButton.Enabled = true;

                this.logger.Info("File chosen");
            }
        }

        private void uploadFileButton_Click(object sender, EventArgs e)
        {
            var serializer = new XmlSerializer(typeof(File));

            var stream = openFileDialog.OpenFile();
            var file = (File)serializer.Deserialize(stream);
            stream.Close();

            var db = new DataContext(Settings.connectionString);

            db.GetTable<File>().InsertOnSubmit(file);
            db.SubmitChanges();

            openFileDialog.FileName = string.Empty;
            chosenFileNameBox.Text = string.Empty;
            uploadDataButton.Enabled = false;

            this.logger.Info("Data from file uploaded to DB");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            switch (this.status)
            {
                case (int)Settings.TermCodes.Success:
                    this.logger.Info("Main form loaded");
                    break;

                case (int)Settings.TermCodes.ParsingError:
                    MessageBox.Show("Settings file parsing error");
                    this.logger.Error("Settings file parsing error");
                    Application.Exit();
                    break;

                case (int)Settings.TermCodes.SettingsFileDoesNotExist:
                    MessageBox.Show("Settings file does not exist");
                    this.logger.Error("Settings file does not exist");
                    Application.Exit();
                    break;

                case (int)Settings.TermCodes.SettinsFileCreated:
                    MessageBox.Show("Template of settings file has been created");
                    this.logger.Warning("Template of settings file has been created");
                    Application.Exit();
                    break;

                default:
                    MessageBox.Show("Something went wrong");
                    this.logger.Fatal("Something went wrong");
                    Application.Exit();
                    break;
            }
        }

        private void dataGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected)
            {
                return;
            }

            saveChosenButton.Enabled = true;
            chosenRow = e.Row;

            this.logger.Info($"Selected row {e.Row.Index}");
        }

        private void saveChosenButton_Click(object sender, EventArgs e)
        {
            var file = new File
            {
                Id = (int)chosenRow.Cells["columnID"].Value,
                FileVersion = (string)chosenRow.Cells["columnFileVersion"].Value,
                Name = (string)chosenRow.Cells["columnName"].Value,
                DateTime = (DateTime)chosenRow.Cells["columnDateTime"].Value
            };
            var serializer = new XmlSerializer(typeof(File));

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var stream = saveFileDialog.OpenFile();
                serializer.Serialize(stream, file);
                
                stream.Close();

                this.logger.Info("Chosen row saved to file");
            }
            saveFileDialog.FileName = string.Empty;
            chosenRow = null;
            saveChosenButton.Enabled = false;
        }

        private DataContext updateDataGridViewFromDb()
        {
            var db = new DataContext(Settings.connectionString);

            var files = db.GetTable<File>();

            dataGridView.Rows.Clear();
            foreach (var file in files)
            {
                var index = dataGridView.Rows.Add();
                dataGridView.Rows[index].Cells["columnID"].Value = file.Id;
                dataGridView.Rows[index].Cells["columnFileVersion"].Value = file.FileVersion;
                dataGridView.Rows[index].Cells["columnName"].Value = file.Name;
                dataGridView.Rows[index].Cells["columnDateTime"].Value = file.DateTime;
            }

            this.logger.Info("DataGridView updated");

            return db;
        }

        private void saveAllButton_Click(object sender, EventArgs e)
        {
            var db = updateDataGridViewFromDb();

            var files = new FilesCollection { Files = db.GetTable<File>().ToArray() };
            var serializer = new XmlSerializer(typeof(FilesCollection));

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var stream = saveFileDialog.OpenFile();
                serializer.Serialize(stream, files);

                stream.Close();

                this.logger.Info("Table saved to file");
            }

            saveFileDialog.FileName = string.Empty;
        }

        private void uploadDataButton_Click(object sender, EventArgs e)
        {
            var files = new File[dataGridView.Rows.Count - 1];

            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                files[i] = new File
                {
                    Id = (int)(dataGridView.Rows[i].Cells["columnID"].Value ?? 0),
                    FileVersion = (string)(dataGridView.Rows[i].Cells["columnFileVersion"].Value ?? string.Empty),
                    Name = (string)(dataGridView.Rows[i].Cells["columnName"].Value ?? string.Empty),
                    DateTime = (DateTime)(dataGridView.Rows[i].Cells["columnDateTime"].Value ?? DateTime.Now)
                };
            }

            var db = new DataContext(Settings.connectionString);
            var filesTable = db.GetTable<File>();

            foreach (var file in files)
            {
                if (!filesTable.Any(x => x.Id == file.Id))
                {
                    filesTable.InsertOnSubmit(file);

                    this.logger.Info("Add new row to DB");
                }
                else
                {
                    var fileDB = filesTable.Where(x => x.Id == file.Id).First();
                    fileDB.FileVersion = file.FileVersion;
                    fileDB.Name = file.Name;
                    fileDB.DateTime = file.DateTime;
                }
            }

            db.SubmitChanges();

            this.logger.Info("All rows updated");
        }
    }
}
