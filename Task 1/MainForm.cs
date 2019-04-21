using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class MainForm : Form
    {
        private bool updated = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // show current version of .exe
            var appPath = Application.ExecutablePath;
            var versionInfo = FileVersionInfo.GetVersionInfo(appPath);
            string version = versionInfo.ProductVersion;
            versionTextBox.Text = version;

            updated = false;

            // remove old file
            var oldAppPath = appPath.Replace(".exe", ".bak");
            if (File.Exists(oldAppPath))
            {
                File.Delete(oldAppPath);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            // check if already updated
            if (updated)
            {
                MessageBox.Show("Application already updated", "Update error", MessageBoxButtons.OK);

                return;
            }

            var appPath = Application.ExecutablePath;
            var appName = AppDomain.CurrentDomain.FriendlyName;
            var newAppPath = $@"{Environment.CurrentDirectory}\new\{appName}";

            // update current .exe
            if (File.Exists(newAppPath))
            {
                File.Move(appPath, appPath.Replace(".exe", ".bak"));
                File.Copy(newAppPath, appPath);

                updated = true;

                var res = MessageBox.Show("Restart application for changes to take effect?\nAll temp files will be deleted after restart.", "Updating successful", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    Application.Restart();
                }
                if (res == DialogResult.No)
                {

                }
            }
            else
            {
                MessageBox.Show("Updating file does not exist", "Update error", MessageBoxButtons.OK);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
