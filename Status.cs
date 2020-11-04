using SyncTrayApp.Properties;
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
    public partial class Status : Form
    {
        readonly string appPath = Environment.CurrentDirectory;
        readonly HelperContext _hlp = new HelperContext();
        string conflictPath = @"C:\\Conflicts\";
        readonly string flLastSyncSts = @"\last_sync_status.txt";
        readonly string flGitStsCheck = @"\git-status-check.bat";
        readonly string flGitSts = @"\git_status.txt";

        public Status()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Status_Load(object sender, EventArgs e)
        {
            try
            {
                string conflictSts = "You had changed the below files but someone else also made the changes and synchronized with server before you. We have moved all your below files to C:\\Conflicts ";

                Process p = new Process();
                p.StartInfo.FileName = appPath + flGitStsCheck;
                p.Start();
                p.WaitForExit();
                string gitStatus = File.ReadAllText(appPath + flGitSts);
                lblAllSyncStatus.Text = _hlp.SyncStatus();

                //Case: Current Status
                if (gitStatus.Contains("branch is up to date") && gitStatus.Contains("nothing to commit"))
                {
                    picMainStatus.Image = Resources.green;
                    lblCurrentSyncStatus.Text = "Up to date with server.";
                }
                else if (gitStatus.Contains("branch is up to date") && (gitStatus.Contains("modified:") || gitStatus.Contains("deleted:")))
                {
                    picMainStatus.Image = Resources.yellow;
                    lblCurrentSyncStatus.Text = "Up to date with server. But, there are changes in your system.";
                }
                else if (gitStatus.Contains("branch is ahead"))
                {
                    picMainStatus.Image = Resources.yellow;
                    lblCurrentSyncStatus.Text = "There are changes in your system but not sync'd with server yet.";
                }
                else if (gitStatus.Contains("branch is behind") && (gitStatus.Contains("modified:") || gitStatus.Contains("deleted:")))
                {
                    picMainStatus.Image = Resources.yellow;
                    lblCurrentSyncStatus.Text = "There are changes in server and there are changes in your system too.";
                }
                else if (gitStatus.Contains("branch is behind"))
                {
                    picMainStatus.Image = Resources.yellow;
                    lblCurrentSyncStatus.Text = "There are changes in server.";
                }

                //Case2: Conflict state for Last Sync status
                if (File.Exists(appPath + flLastSyncSts))
                {
                    gitStatus = File.ReadAllText(appPath + flLastSyncSts);
                    if (gitStatus.ToUpper().Contains("CONFLICT"))
                    {
                        lnkConflicts.Text = conflictPath;
                        picMainStatus.Image = Resources.red;
                        lblMainStatus.Text = "Conflicts found.";
                        lblLastSyncNeedsAttn.Text = "Needs your attention.";
                        lblLastSyncConflict.Text = conflictSts + Environment.NewLine + gitStatus.Replace("CONFLICT FOUND |", ""); ;
                    }
                    else
                    {
                        picMainStatus.Image = Resources.green;
                        lblLastSyncSts.Text = "Everything went fine.";
                    }
                }
            }
            catch (Exception ex)
            {
                _hlp.Logging(ex.Message, "Status_Load");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(conflictPath);
        }

        private void btnConflictsResolved_Click(object sender, EventArgs e)
        {
            if (File.Exists(appPath + flLastSyncSts))
            {
                File.WriteAllText(appPath + flLastSyncSts, string.Empty);
            }
        }
    }
}
