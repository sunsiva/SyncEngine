using System;
using System.Diagnostics;
using System.Windows.Forms;
using SyncTrayApp.Properties;
using System.Drawing;
using System.Configuration;
using System.IO;

namespace SyncTrayApp
{
	/// <summary>
	/// 
	/// </summary>
	class ContextMenus
	{
		/// <summary>
		/// Is the About box displayed?
		/// </summary>
		bool isAboutLoaded = false;
		bool isSettingsLoaded = false;
	    bool isStatusLoaded =false;
		readonly string appPath = ConfigurationManager.AppSettings["Environment"]=="local"? ConfigurationManager.AppSettings["AppPath"] : Environment.CurrentDirectory;
		HelperContext _hlp = new HelperContext();
		Process p = new Process();
		readonly string flLastSyncSts = @"\\last_sync_status.txt";
		readonly string flUserProfile = @"\\userprofile.txt";

		/// <summary>
		/// Creates this instance.
		/// </summary>
		/// <returns>ContextMenuStrip</returns>
		public ContextMenuStrip Create()
		{
			// Add the default menu options.
			ContextMenuStrip menu = new ContextMenuStrip();
			ToolStripMenuItem item;
			ToolStripSeparator sep;

			// About.
			item = new ToolStripMenuItem();
			item.Text = "About";
			item.Click += new EventHandler(About_Click);
			item.Image = Resources.About;
			menu.Items.Add(item);

			// Windows Explorer.
			item = new ToolStripMenuItem();
			item.Text = "Settings";
			item.Click += new EventHandler(Explorer_Click);
			item.Image = Resources.Explorer;
			menu.Items.Add(item);

			// Separator.
			sep = new ToolStripSeparator();
			menu.Items.Add(sep);

			// Status.
			item = new ToolStripMenuItem();
			item.Text = "Status";
			item.Click += new EventHandler(Status_Click);
			item.Image = Resources.status;
			menu.Items.Add(item);

			// Sync.
			item = new ToolStripMenuItem();
			item.Text = "Sync";
			item.Click += new EventHandler(Sync_Click);
			item.Image = Resources.sync;
			menu.Items.Add(item);

			// Separator.
			sep = new ToolStripSeparator();
			menu.Items.Add(sep);

			//if(ConfigurationManager.AppSettings["IsExitEnable"].ToString().ToLower()=="yes")
				{ 
				// Exit.
				item = new ToolStripMenuItem();
				item.Text = "Exit";
				item.Click += new System.EventHandler(Exit_Click);
				item.Image = Resources.Exit;
				menu.Items.Add(item);
			}

			return menu;
		}

		/// <summary>
		/// Handles the Click event of the Explorer control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		void Explorer_Click(object sender, EventArgs e)
		{
			if (!isSettingsLoaded)
			{
				isSettingsLoaded = true;
				new Settings().ShowDialog();
				isSettingsLoaded = false;
			}
			//Process.Start("explorer", null);
		}

		/// <summary>
		/// Handles the Click event of the About control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		void About_Click(object sender, EventArgs e)
		{
			if (!isAboutLoaded)
			{
				isAboutLoaded = true;
				new AboutBox().ShowDialog();
				isAboutLoaded = false;
			}
		}

		/// <summary>
		/// Handles the Click event of the About control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		void Sync_Click(object sender, EventArgs e)
		{
			try
			{
				if (File.Exists(appPath + flUserProfile) && !string.IsNullOrEmpty(File.ReadAllText(appPath + flUserProfile)))
				{
					p = new Process();
					p.StartInfo.FileName = appPath + "\\" + ConfigurationManager.AppSettings["BatchFile"];
					p.StartInfo.Verb = "runas";
					p.Start();
					p.WaitForExit();

					_hlp.Logging("ManualSync", "Sync_Click");

					System.Threading.Thread.Sleep(10000);
					string gitStatus = File.ReadAllText(appPath + flLastSyncSts);
					if (gitStatus.ToUpper().Contains("CONFLICT")) //TODO: need check the datetime and then call the conflict
					{
						new Notification().ShowDialog();
					}
					MessageBox.Show("Sync completed.");
				}
				else
				{ 
					new Settings().ShowDialog();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Sync Failed.");
				_hlp.Logging(ex.Message, "Sync_Click");
				_hlp.SaveUserSettings(DateTime.Now + "_Failure", false);
			}
		}

		void Status_Click(object sender, EventArgs e)
		{
			try
			{
				if (!isStatusLoaded)
				{
					isStatusLoaded = true;
					new Status().ShowDialog();
					isStatusLoaded = false;
				}
			}
			catch (Exception ex)
			{
				_hlp.Logging(ex.Message, "Status_Click");
			}
		}

		/// <summary>
		/// Processes a menu item.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		void Exit_Click(object sender, EventArgs e)
		{
			//p = new Process();
			//p.StartInfo.FileName = appPath + "\\task-disable.bat";
			//p.StartInfo.Verb = "runas";
			//p.Start();
			//p.WaitForExit();

			// Quit without further ado.
			Application.Exit();
		}
	}
}