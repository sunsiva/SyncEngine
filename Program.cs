using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SyncTrayApp
{
	/// <summary>
	/// 
	/// </summary>
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			string appPath = Environment.CurrentDirectory;

			//User Settings
			if (!File.Exists(appPath + "\\userprofile.txt")	|| (File.Exists(appPath + "\\userprofile.txt") && string.IsNullOrEmpty(File.ReadAllText(appPath + "\\userprofile.txt"))))
				new Settings().ShowDialog();

			////Pre-Installation
			//HelperContext _hlp = new HelperContext();
			//try
			//{
			//	var jobPath = ConfigurationManager.AppSettings["PreInstallationBatchFile"];
			//	//if (jobPath != null)
			//	//	Process.Start(jobPath, null);
			//	//else
			//		Process.Start(@"pre-installer.bat", null);
			//	_hlp.Logging("Pre-Installation", "Main_Program");
			//}
			//catch (Exception ex)
			//{
			//	_hlp.Logging(ex.Message, "Main_Program");
			//}

			// Show the system tray icon.					
			using (ProcessIcon pi = new ProcessIcon())
			{
				pi.Display();

				//Process.Start(appPath + "\\task-enable.bat", null);
				// Make sure the application runs!
				Application.Run();

			}
		}
	}
}