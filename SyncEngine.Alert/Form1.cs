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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncEngine.Alert
{
    public partial class Form1 : Form
    {
        int counter = 30;
        private readonly string _appPath = ConfigurationManager.AppSettings["AppPath"];
        readonly string flLastSyncSts = @"\last_sync_status.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //notifyIcon1.Icon = new Icon(@"C:\Users\sundarsi\me\xtra\Cache Technologies\Gokare LPO\ref\alert.ico");
            //notifyIcon1.Text = "My applicaiton";
            //notifyIcon1.Visible = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            // Activate the form.
            this.Activate();
            
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();
            lblCountDown.Text = counter.ToString();

            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            { 
                timer1.Stop();
                this.Hide();

                CallGitCommit(true);

                System.Threading.Thread.Sleep(10000);
                string gitStatus = File.ReadAllText(_appPath + flLastSyncSts);
                if (gitStatus.Contains("CONFLICT")) //TODO: need check the datetime and then call the conflict
                {
                    ConflictAlert();
                }
            }
            lblCountDown.Text = counter.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CallGitCommit(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CallGitCommit(false);
            this.Close();
        }

        private void CallGitCommit(bool isGitCommit)
        {
            if (isGitCommit)
            {
                Process p = new Process();
                p = new Process();
                p.StartInfo.FileName = _appPath + "\\" + ConfigurationManager.AppSettings["BatchFile"];
                p.StartInfo.Verb = "runas";
                p.Start();
                p.WaitForExit();
            }
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
