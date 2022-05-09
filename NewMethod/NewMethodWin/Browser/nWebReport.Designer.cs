namespace NewMethod
{
    partial class nWebReport
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nWebReport));
            this.gb = new System.Windows.Forms.GroupBox();
            this.cmdExport = new System.Windows.Forms.Button();
            this.throb = new NewMethod.nThrobber();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdEmail = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.wb = new ToolsWin.BrowserPlain();
            this.ilReportImages = new System.Windows.Forms.ImageList(this.components);
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.cmdExport);
            this.gb.Controls.Add(this.throb);
            this.gb.Controls.Add(this.pb);
            this.gb.Controls.Add(this.cmdRefresh);
            this.gb.Controls.Add(this.cmdEmail);
            this.gb.Controls.Add(this.cmdSave);
            this.gb.Controls.Add(this.cmdPrint);
            this.gb.Controls.Add(this.lblStatus);
            this.gb.Location = new System.Drawing.Point(3, 344);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(540, 53);
            this.gb.TabIndex = 1;
            this.gb.TabStop = false;
            // 
            // cmdExport
            // 
            this.cmdExport.Location = new System.Drawing.Point(395, 11);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(82, 19);
            this.cmdExport.TabIndex = 7;
            this.cmdExport.Text = "Export";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Visible = false;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.Blue;
            this.throb.Location = new System.Drawing.Point(9, 8);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(28, 24);
            this.throb.TabIndex = 6;
            this.throb.UseParentBackColor = false;
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(6, 34);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(516, 13);
            this.pb.TabIndex = 4;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(43, 11);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(82, 19);
            this.cmdRefresh.TabIndex = 3;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdEmail
            // 
            this.cmdEmail.Location = new System.Drawing.Point(307, 11);
            this.cmdEmail.Name = "cmdEmail";
            this.cmdEmail.Size = new System.Drawing.Size(82, 19);
            this.cmdEmail.TabIndex = 2;
            this.cmdEmail.Text = "Email";
            this.cmdEmail.UseVisualStyleBackColor = true;
            this.cmdEmail.Click += new System.EventHandler(this.cmdEmail_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(219, 11);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(82, 19);
            this.cmdSave.TabIndex = 1;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Location = new System.Drawing.Point(131, 11);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(82, 19);
            this.cmdPrint.TabIndex = 0;
            this.cmdPrint.Text = "Print";
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(109, 16);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(413, 14);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "<status>";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // wb
            // 
            this.wb.BackColor = System.Drawing.Color.White;
            this.wb.Location = new System.Drawing.Point(284, 56);
            this.wb.Name = "wb";
            this.wb.ShowControls = false;
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(130, 100);
            this.wb.TabIndex = 0;
            this.wb.OnNavigate += new ToolsWin.OnNavigateHandler(this.wb_OnNavigate);
            // 
            // ilReportImages
            // 
            this.ilReportImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilReportImages.ImageStream")));
            this.ilReportImages.TransparentColor = System.Drawing.Color.Transparent;
            this.ilReportImages.Images.SetKeyName(0, "orange-question-mark.png");
            // 
            // nWebReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gb);
            this.Controls.Add(this.wb);
            this.Name = "nWebReport";
            this.Size = new System.Drawing.Size(546, 429);
            this.Resize += new System.EventHandler(this.nWebReport_Resize);
            this.gb.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Button cmdEmail;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.Label lblStatus;
        private nThrobber throb;
        public ToolsWin.BrowserPlain wb;
        public System.Windows.Forms.GroupBox gb;
        public System.ComponentModel.BackgroundWorker bg;
        public System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.ImageList ilReportImages;
    }
}
