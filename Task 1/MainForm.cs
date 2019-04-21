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
        public MainForm()
        {
            InitializeComponent();

            // show current version of .exe
            var appPath = Application.ExecutablePath;
            var versionInfo = FileVersionInfo.GetVersionInfo(appPath);
            string version = versionInfo.ProductVersion;
            versionTextBox.Text = version;

            // remove old file
            var oldAppPath = appPath.Replace(".exe", ".bak");
            if (File.Exists(oldAppPath))
            {
                File.Delete(oldAppPath);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            var appPath = Application.ExecutablePath;
            var appName = AppDomain.CurrentDomain.FriendlyName;
            var newAppPath = $"{Environment.CurrentDirectory}\\new\\{appName}";

            // update current .exe
            if (File.Exists(newAppPath))
            {
                File.Move(appPath, appPath.Replace(".exe", ".bak"));
                File.Copy(newAppPath, appPath);


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
                MessageBox.Show("Updating file does not exist", "Updating error", MessageBoxButtons.OK);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
