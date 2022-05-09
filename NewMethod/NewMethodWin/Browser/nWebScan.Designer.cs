namespace NewMethod
{
    partial class nWebScan
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
            this.gb = new System.Windows.Forms.GroupBox();
            this.cmdView = new System.Windows.Forms.Button();
            this.cmdStop = new System.Windows.Forms.Button();
            this.throb = new NewMethod.nThrobber();
            this.cmdParse = new System.Windows.Forms.Button();
            this.cmdGo = new System.Windows.Forms.Button();
            this.gbBottom = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.sc = new System.Windows.Forms.SplitContainer();
            this.wb = new ToolsWin.Browser();
            this.wbExtra = new ToolsWin.Browser();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.gb.SuspendLayout();
            this.gbBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc)).BeginInit();
            this.sc.Panel1.SuspendLayout();
            this.sc.Panel2.SuspendLayout();
            this.sc.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.cmdView);
            this.gb.Controls.Add(this.cmdStop);
            this.gb.Controls.Add(this.throb);
            this.gb.Controls.Add(this.cmdParse);
            this.gb.Controls.Add(this.cmdGo);
            this.gb.Location = new System.Drawing.Point(0, 0);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(97, 533);
            this.gb.TabIndex = 1;
            this.gb.TabStop = false;
            // 
            // cmdView
            // 
            this.cmdView.Location = new System.Drawing.Point(8, 440);
            this.cmdView.Name = "cmdView";
            this.cmdView.Size = new System.Drawing.Size(78, 20);
            this.cmdView.TabIndex = 4;
            this.cmdView.Text = "View";
            this.cmdView.UseVisualStyleBackColor = true;
            this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
            // 
            // cmdStop
            // 
            this.cmdStop.Location = new System.Drawing.Point(6, 76);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(84, 31);
            this.cmdStop.TabIndex = 3;
            this.cmdStop.Text = "Stop";
            this.cmdStop.UseVisualStyleBackColor = true;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.Blue;
            this.throb.Location = new System.Drawing.Point(33, 46);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(24, 24);
            this.throb.TabIndex = 2;
            this.throb.UseParentBackColor = false;
            // 
            // cmdParse
            // 
            this.cmdParse.Location = new System.Drawing.Point(6, 405);
            this.cmdParse.Name = "cmdParse";
            this.cmdParse.Size = new System.Drawing.Size(84, 31);
            this.cmdParse.TabIndex = 1;
            this.cmdParse.Text = "Parse";
            this.cmdParse.UseVisualStyleBackColor = true;
            this.cmdParse.Click += new System.EventHandler(this.cmdParse_Click);
            // 
            // cmdGo
            // 
            this.cmdGo.Location = new System.Drawing.Point(6, 9);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(84, 31);
            this.cmdGo.TabIndex = 0;
            this.cmdGo.Text = "Go";
            this.cmdGo.UseVisualStyleBackColor = true;
            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // gbBottom
            // 
            this.gbBottom.Controls.Add(this.progressBar1);
            this.gbBottom.Controls.Add(this.txtStatus);
            this.gbBottom.Location = new System.Drawing.Point(110, 335);
            this.gbBottom.Name = "gbBottom";
            this.gbBottom.Size = new System.Drawing.Size(719, 218);
            this.gbBottom.TabIndex = 2;
            this.gbBottom.TabStop = false;
            this.gbBottom.Text = "Status";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 174);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(703, 20);
            this.progressBar1.TabIndex = 1;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(10, 17);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(703, 151);
            this.txtStatus.TabIndex = 0;
            this.txtStatus.WordWrap = false;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(110, 9);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(480, 20);
            this.txtURL.TabIndex = 3;
            // 
            // sc
            // 
            this.sc.Location = new System.Drawing.Point(110, 35);
            this.sc.Name = "sc";
            // 
            // sc.Panel1
            // 
            this.sc.Panel1.Controls.Add(this.wb);
            // 
            // sc.Panel2
            // 
            this.sc.Panel2.Controls.Add(this.wbExtra);
            this.sc.Size = new System.Drawing.Size(594, 294);
            this.sc.SplitterDistance = 373;
            this.sc.TabIndex = 5;
            // 
            // wb
            // 
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(0, 0);
            this.wb.Name = "wb";
            this.wb.ShowBackButton = false;
            this.wb.ShowControls = false;
            this.wb.Silent = true;
            this.wb.Size = new System.Drawing.Size(373, 294);
            this.wb.TabIndex = 1;
            // 
            // wbExtra
            // 
            this.wbExtra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbExtra.Location = new System.Drawing.Point(0, 0);
            this.wbExtra.Name = "wbExtra";
            this.wbExtra.ShowBackButton = false;
            this.wbExtra.ShowControls = false;
            this.wbExtra.Silent = true;
            this.wbExtra.Size = new System.Drawing.Size(217, 294);
            this.wbExtra.TabIndex = 5;
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // nWebScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sc);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.gbBottom);
            this.Controls.Add(this.gb);
            this.Name = "nWebScan";
            this.Size = new System.Drawing.Size(889, 606);
            this.Resize += new System.EventHandler(this.nWebScan_Resize);
            this.gb.ResumeLayout(false);
            this.gbBottom.ResumeLayout(false);
            this.gbBottom.PerformLayout();
            this.sc.Panel1.ResumeLayout(false);
            this.sc.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc)).EndInit();
            this.sc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdGo;
        private System.Windows.Forms.GroupBox gbBottom;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtURL;
        protected System.Windows.Forms.Button cmdParse;
        private System.Windows.Forms.SplitContainer sc;
        protected ToolsWin.Browser wb;
        protected ToolsWin.Browser wbExtra;
        protected nThrobber throb;
        protected System.ComponentModel.BackgroundWorker bg;
        private System.Windows.Forms.Button cmdStop;
        public System.Windows.Forms.GroupBox gb;
        protected System.Windows.Forms.Button cmdView;
    }
}
