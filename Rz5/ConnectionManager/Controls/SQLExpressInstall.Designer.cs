namespace ConnectionManager
{
    partial class SQLExpressInstall
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
            if (disposing)
                InitUn();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            //base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pb = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.bgIsInstalled = new System.ComponentModel.BackgroundWorker();
            this.bgRemoteConnection = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerDB = new System.ComponentModel.BackgroundWorker();
            this.lblCustomDBInstalled = new System.Windows.Forms.Label();
            this.lblConfigured = new System.Windows.Forms.Label();
            this.lblServerInstalled = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(3, 100);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(276, 23);
            this.pb.TabIndex = 42;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(3, 84);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 41;
            this.lblStatus.Text = "<status>";
            // 
            // lblCustomDBInstalled
            // 
            this.lblCustomDBInstalled.AutoSize = true;
            this.lblCustomDBInstalled.ForeColor = System.Drawing.Color.Gray;
            this.lblCustomDBInstalled.Location = new System.Drawing.Point(28, 40);
            this.lblCustomDBInstalled.Name = "lblCustomDBInstalled";
            this.lblCustomDBInstalled.Size = new System.Drawing.Size(111, 13);
            this.lblCustomDBInstalled.TabIndex = 43;
            this.lblCustomDBInstalled.Text = "Rz Database Installed";
            // 
            // lblConfigured
            // 
            this.lblConfigured.AutoSize = true;
            this.lblConfigured.ForeColor = System.Drawing.Color.Gray;
            this.lblConfigured.Location = new System.Drawing.Point(28, 60);
            this.lblConfigured.Name = "lblConfigured";
            this.lblConfigured.Size = new System.Drawing.Size(123, 13);
            this.lblConfigured.TabIndex = 44;
            this.lblConfigured.Text = "Rz Database Configured";
            // 
            // lblServerInstalled
            // 
            this.lblServerInstalled.AutoSize = true;
            this.lblServerInstalled.ForeColor = System.Drawing.Color.Gray;
            this.lblServerInstalled.Location = new System.Drawing.Point(28, 20);
            this.lblServerInstalled.Name = "lblServerInstalled";
            this.lblServerInstalled.Size = new System.Drawing.Size(109, 13);
            this.lblServerInstalled.TabIndex = 45;
            this.lblServerInstalled.Text = "Local Server Installed";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(6, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 47;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(6, 60);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.TabIndex = 48;
            this.pictureBox3.TabStop = false;
            // 
            // SQLExpressInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblServerInstalled);
            this.Controls.Add(this.lblConfigured);
            this.Controls.Add(this.lblCustomDBInstalled);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.lblStatus);
            this.Name = "SQLExpressInstall";
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.Controls.SetChildIndex(this.pb, 0);
            this.Controls.SetChildIndex(this.lblCustomDBInstalled, 0);
            this.Controls.SetChildIndex(this.lblConfigured, 0);
            this.Controls.SetChildIndex(this.lblServerInstalled, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.pictureBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.Label lblStatus;
        private System.ComponentModel.BackgroundWorker bgIsInstalled;
        private System.ComponentModel.BackgroundWorker bgRemoteConnection;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDB;
        private System.Windows.Forms.Label lblCustomDBInstalled;
        private System.Windows.Forms.Label lblConfigured;
        private System.Windows.Forms.Label lblServerInstalled;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}
