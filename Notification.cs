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
    public partial class Notification : Form
    {
        private readonly string _appPath = ConfigurationManager.AppSettings["AppPath"];

        public Notification()
        {
            InitializeComponent();
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            this.Hide();
            ConflictAlert();
            this.Close();
        }
        
        private void ConflictAlert()
        {
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;

            notifyIcon1.BalloonTipText = "Plese check your status page for detailed information."; //TODO: change the text

            notifyIcon1.BalloonTipTitle = "CONFLICT FOUND-Need Your Attention";

            notifyIcon1.ShowBalloonTip(20000);
        }
    }
}
