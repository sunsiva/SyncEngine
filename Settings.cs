using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SyncTrayApp
{
    public partial class Settings : Form
    {
        HelperContext _hlp = new HelperContext();
        readonly string appPath = ConfigurationManager.AppSettings["Environment"] == "local" ? ConfigurationManager.AppSettings["AppPath"] : Environment.CurrentDirectory;
        bool isFirstClone = false;
        Process p = new Process();
        string conflictPath = @"C:\\Conflicts\";
        readonly string flGitClone = @"\\git-clone.bat";
        readonly string flTaskSchedular = @"\\task-schedular.bat";
        readonly string flUserProfile = @"\\userprofile.txt";

        public Settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = folderDlg.SelectedPath;
                _ = folderDlg.RootFolder;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            //Create Conflict folder if not already,
            if (!Directory.Exists(conflictPath))
                Directory.CreateDirectory(conflictPath);

            if (txtUserName.Text==string.Empty)
            {
                lblStatusMsg.Text = "Please provide value";
                txtUserName.Focus();
                return;
            }
            if (textBox1.Text == string.Empty)
            {
                lblStatusMsg.Text = "Please provide value";
                textBox1.Focus();
                return;
            }
            if (txtUserToken.Text == string.Empty)
            {
                lblStatusMsg.Text = "Please provide value";
                txtUserToken.Focus();
                return;
            }
           
            string cfgRepoUrl = ConfigurationManager.AppSettings["RepoUrl"];
            string cfgRepoName = ConfigurationManager.AppSettings["RepoName"];
            string[] getCfgUrl = cfgRepoUrl.Split('@');
            cfgRepoUrl = cfgRepoUrl.Replace(getCfgUrl[0], "https://" + txtUserToken.Text);
            _hlp.SaveUserSettings(txtUserName.Text + "|" + textBox1.Text + "|" + txtUserToken.Text+"|"+ cfgRepoUrl+"|"+ cfgRepoName, true);

            //Git-clone
            bool isCloneEnable = Convert.ToBoolean(ConfigurationManager.AppSettings["IsCloneEnable"]);
            if (isFirstClone && isCloneEnable)
            {
                p = new Process();
                p.StartInfo.FileName = appPath + flGitClone;
                p.StartInfo.Verb = "runas";
                p.Start();
                p.WaitForExit();
            }
            else
            {
                p = new Process();
                p.StartInfo.FileName = appPath + flTaskSchedular;
                p.StartInfo.Verb = "runas";
                p.Start();
                p.WaitForExit();
            }

            //p = new Process();
            //p.StartInfo.FileName = appPath + "\\task-enable.bat";
            //p.StartInfo.Verb = "runas";
            //p.Start();
            //p.WaitForExit();

            lblStatusMsg.Text = "Save successful.";
            System.Threading.Thread.Sleep(2000);
            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            lblStatusMsg.Text = string.Empty;
            txtUserName.Focus();
            string appLogPath = appPath + flUserProfile;

            //User Settings
            if (File.Exists(appLogPath))
            {
                string runDateStatus = File.ReadAllText(appLogPath);
                if (!string.IsNullOrEmpty(runDateStatus))
                {
                    txtUserName.Text = runDateStatus.Split('|')[0];
                    textBox1.Text = runDateStatus.Split('|')[1];
                    txtUserToken.Text = runDateStatus.Split('|')[2];
                }
            }
            else
                isFirstClone = true;
        }
    }
}
