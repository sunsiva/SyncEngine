using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SyncTrayApp
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

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
                saveFile(textBox1.Text);
                _ = folderDlg.RootFolder;

                
            }
        }

        private void saveFile(string msg)
        {
            //once you have the path you get the directory with:
            var directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Save File to .txt  
            FileStream fParameter = new FileStream(directory+"\\log.txt", FileMode.Append, FileAccess.Write);
            StreamWriter m_WriterParameter = new StreamWriter(fParameter);
            m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
            m_WriterParameter.Write(msg);
            m_WriterParameter.Flush();
            m_WriterParameter.Close();
        }

    }
}
