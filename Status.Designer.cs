namespace SyncTrayApp
{
    partial class Status
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Status));
            this.lblCurrentSyncStatus = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblLastSyncSts = new System.Windows.Forms.Label();
            this.grpLastSyncStatus = new System.Windows.Forms.GroupBox();
            this.lnkConflicts = new System.Windows.Forms.LinkLabel();
            this.lblLastSyncConflict = new System.Windows.Forms.Label();
            this.lblLastSyncNeedsAttn = new System.Windows.Forms.Label();
            this.grpCrntSts = new System.Windows.Forms.GroupBox();
            this.lblAllSyncStatus = new System.Windows.Forms.Label();
            this.lblMainStatus = new System.Windows.Forms.Label();
            this.picMainStatus = new System.Windows.Forms.PictureBox();
            this.btnConflictsResolved = new System.Windows.Forms.Button();
            this.grpLastSyncStatus.SuspendLayout();
            this.grpCrntSts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMainStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCurrentSyncStatus
            // 
            this.lblCurrentSyncStatus.AutoSize = true;
            this.lblCurrentSyncStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentSyncStatus.ForeColor = System.Drawing.Color.Green;
            this.lblCurrentSyncStatus.Location = new System.Drawing.Point(53, 31);
            this.lblCurrentSyncStatus.Name = "lblCurrentSyncStatus";
            this.lblCurrentSyncStatus.Size = new System.Drawing.Size(127, 15);
            this.lblCurrentSyncStatus.TabIndex = 1;
            this.lblCurrentSyncStatus.Text = "Up to date with server.";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(541, 482);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblLastSyncSts
            // 
            this.lblLastSyncSts.AutoSize = true;
            this.lblLastSyncSts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastSyncSts.ForeColor = System.Drawing.Color.Green;
            this.lblLastSyncSts.Location = new System.Drawing.Point(50, 29);
            this.lblLastSyncSts.Name = "lblLastSyncSts";
            this.lblLastSyncSts.Size = new System.Drawing.Size(0, 15);
            this.lblLastSyncSts.TabIndex = 7;
            // 
            // grpLastSyncStatus
            // 
            this.grpLastSyncStatus.AutoSize = true;
            this.grpLastSyncStatus.Controls.Add(this.btnConflictsResolved);
            this.grpLastSyncStatus.Controls.Add(this.lnkConflicts);
            this.grpLastSyncStatus.Controls.Add(this.lblLastSyncConflict);
            this.grpLastSyncStatus.Controls.Add(this.lblLastSyncNeedsAttn);
            this.grpLastSyncStatus.Controls.Add(this.lblLastSyncSts);
            this.grpLastSyncStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLastSyncStatus.Location = new System.Drawing.Point(32, 181);
            this.grpLastSyncStatus.Name = "grpLastSyncStatus";
            this.grpLastSyncStatus.Size = new System.Drawing.Size(584, 296);
            this.grpLastSyncStatus.TabIndex = 9;
            this.grpLastSyncStatus.TabStop = false;
            this.grpLastSyncStatus.Text = "Last Sync Status:";
            // 
            // lnkConflicts
            // 
            this.lnkConflicts.AutoSize = true;
            this.lnkConflicts.Location = new System.Drawing.Point(52, 251);
            this.lnkConflicts.Name = "lnkConflicts";
            this.lnkConflicts.Size = new System.Drawing.Size(0, 17);
            this.lnkConflicts.TabIndex = 13;
            this.lnkConflicts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblLastSyncConflict
            // 
            this.lblLastSyncConflict.AutoSize = true;
            this.lblLastSyncConflict.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastSyncConflict.Location = new System.Drawing.Point(74, 59);
            this.lblLastSyncConflict.MaximumSize = new System.Drawing.Size(480, 250);
            this.lblLastSyncConflict.Name = "lblLastSyncConflict";
            this.lblLastSyncConflict.Size = new System.Drawing.Size(0, 15);
            this.lblLastSyncConflict.TabIndex = 9;
            // 
            // lblLastSyncNeedsAttn
            // 
            this.lblLastSyncNeedsAttn.AutoSize = true;
            this.lblLastSyncNeedsAttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastSyncNeedsAttn.ForeColor = System.Drawing.Color.Red;
            this.lblLastSyncNeedsAttn.Location = new System.Drawing.Point(53, 29);
            this.lblLastSyncNeedsAttn.Name = "lblLastSyncNeedsAttn";
            this.lblLastSyncNeedsAttn.Size = new System.Drawing.Size(0, 15);
            this.lblLastSyncNeedsAttn.TabIndex = 8;
            // 
            // grpCrntSts
            // 
            this.grpCrntSts.AutoSize = true;
            this.grpCrntSts.Controls.Add(this.lblAllSyncStatus);
            this.grpCrntSts.Controls.Add(this.lblCurrentSyncStatus);
            this.grpCrntSts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCrntSts.Location = new System.Drawing.Point(32, 52);
            this.grpCrntSts.Name = "grpCrntSts";
            this.grpCrntSts.Size = new System.Drawing.Size(584, 104);
            this.grpCrntSts.TabIndex = 11;
            this.grpCrntSts.TabStop = false;
            this.grpCrntSts.Text = "Current Status:";
            // 
            // lblAllSyncStatus
            // 
            this.lblAllSyncStatus.AutoSize = true;
            this.lblAllSyncStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllSyncStatus.Location = new System.Drawing.Point(358, 59);
            this.lblAllSyncStatus.Name = "lblAllSyncStatus";
            this.lblAllSyncStatus.Size = new System.Drawing.Size(0, 17);
            this.lblAllSyncStatus.TabIndex = 13;
            // 
            // lblMainStatus
            // 
            this.lblMainStatus.AutoSize = true;
            this.lblMainStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainStatus.Location = new System.Drawing.Point(70, 20);
            this.lblMainStatus.Name = "lblMainStatus";
            this.lblMainStatus.Size = new System.Drawing.Size(150, 17);
            this.lblMainStatus.TabIndex = 8;
            this.lblMainStatus.Text = "All files are up-to date.";
            // 
            // picMainStatus
            // 
            this.picMainStatus.BackgroundImage = global::SyncTrayApp.Properties.Resources.green;
            this.picMainStatus.InitialImage = null;
            this.picMainStatus.Location = new System.Drawing.Point(39, 16);
            this.picMainStatus.Name = "picMainStatus";
            this.picMainStatus.Size = new System.Drawing.Size(29, 28);
            this.picMainStatus.TabIndex = 12;
            this.picMainStatus.TabStop = false;
            // 
            // btnConflictsResolved
            // 
            this.btnConflictsResolved.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConflictsResolved.Location = new System.Drawing.Point(409, 251);
            this.btnConflictsResolved.Name = "btnConflictsResolved";
            this.btnConflictsResolved.Size = new System.Drawing.Size(162, 23);
            this.btnConflictsResolved.TabIndex = 14;
            this.btnConflictsResolved.Text = "My Conflicts Resolved";
            this.btnConflictsResolved.UseVisualStyleBackColor = true;
            this.btnConflictsResolved.Click += new System.EventHandler(this.btnConflictsResolved_Click);
            // 
            // Status
            // 
            this.ClientSize = new System.Drawing.Size(642, 512);
            this.Controls.Add(this.picMainStatus);
            this.Controls.Add(this.lblMainStatus);
            this.Controls.Add(this.grpCrntSts);
            this.Controls.Add(this.grpLastSyncStatus);
            this.Controls.Add(this.button2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Status";
            this.Text = "Sync Status:";
            this.Load += new System.EventHandler(this.Status_Load);
            this.grpLastSyncStatus.ResumeLayout(false);
            this.grpLastSyncStatus.PerformLayout();
            this.grpCrntSts.ResumeLayout(false);
            this.grpCrntSts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMainStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblCurrentSyncStatus;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblLastSyncSts;
        private System.Windows.Forms.GroupBox grpLastSyncStatus;
        private System.Windows.Forms.GroupBox grpCrntSts;
        private System.Windows.Forms.Label lblMainStatus;
        private System.Windows.Forms.PictureBox picMainStatus;
        private System.Windows.Forms.Label lblLastSyncNeedsAttn;
        private System.Windows.Forms.Label lblLastSyncConflict;
        private System.Windows.Forms.Label lblAllSyncStatus;
        private System.Windows.Forms.LinkLabel lnkConflicts;
        private System.Windows.Forms.Button btnConflictsResolved;
    }
}