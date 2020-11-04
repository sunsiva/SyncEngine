using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace SyncTrayApp
{
    public class HelperContext
    {
		readonly string appPath = ConfigurationManager.AppSettings["Environment"] == "local" ? ConfigurationManager.AppSettings["AppPath"] : Environment.CurrentDirectory;
		readonly string flSyncLog = @"\sync_log.log";
		readonly string flSyncSts = @"\sync_status.txt";
		readonly string flUserProfile = @"\\userprofile.txt";
		readonly string flSettings = @"\settings.txt";

		public void Logging(string msg, string action)
        {
			// Save File to .txt  
			FileStream fParameter = new FileStream(appPath + flSyncLog, FileMode.Append, FileAccess.Write);
			StreamWriter m_WriterParameter = new StreamWriter(fParameter);
			m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
			m_WriterParameter.Write(Environment.NewLine + DateTime.Now + ":" + action + "::");
			m_WriterParameter.Write(msg);
			m_WriterParameter.Flush();
			m_WriterParameter.Close();
		}

		public string getTextBetween(string strSource, string strStart, string strEnd)
		{
			if (strSource.Contains(strStart) && strSource.Contains(strEnd))
			{
				int Start, End;
				Start = strSource.IndexOf(strStart, 0) + strStart.Length;
				End = strSource.IndexOf(strEnd, Start);
				return strSource.Substring(Start, End - Start);
			}

			return "";
		}

		// Save File to .txt  
		public void SaveUserSettings(string uName,bool isUser)
		{
			string syncfle;
			
			if (!isUser)
				syncfle = appPath + flSyncSts;
			else
				syncfle = appPath + flUserProfile;

			FileStream fParameter = new FileStream(syncfle, FileMode.Create, FileAccess.Write);
			StreamWriter m_WriterParameter = new StreamWriter(fParameter);
			m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
			m_WriterParameter.Write(uName);
			m_WriterParameter.Flush();
			m_WriterParameter.Close();
		}

		public string SyncStatus()
		{
			// Read the file as one string.
			//int runDuration = Convert.ToInt32(ConfigurationManager.AppSettings["RunDurationInMins"]);
			string cfgRepoName = ConfigurationManager.AppSettings["RepoName"];
			string userProf = File.ReadAllText(appPath + flUserProfile);
			string gitRepo = userProf.Split('|')[1];
			int runDuration = Convert.ToInt32(File.ReadAllText(gitRepo +@"\"+ cfgRepoName + flSettings));

			string sts = string.Empty;

			if (File.Exists(appPath + flSyncSts))
			{
				string runDateStatus = File.ReadAllText(appPath + flSyncSts);
				if(!string.IsNullOrEmpty(runDateStatus))
					{ 
					DateTime runDate = Convert.ToDateTime(runDateStatus.Split('_')[0]);
					string runStatus = runDateStatus.Split('_')[1];
					sts = "LastSync: " + runDate.ToString("MM/dd/yyyy HH:mm") + "_" + runStatus+Environment.NewLine
					+ "NextSync: " + runDate.AddMinutes(runDuration).ToString("MM/dd/yyyy HH:mm");
				}
			}

			return sts;
		}
	}
}
