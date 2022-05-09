namespace ToolsWin
{
    partial class WebDispatch
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
            this.wb = new ToolsWin.BrowserPlain();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.wbResult = new ToolsWin.BrowserPlain();
            this.ph = new System.Windows.Forms.PictureBox();
            this.pv = new System.Windows.Forms.PictureBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pv)).BeginInit();
            this.SuspendLayout();
            // 
            // wb
            // 
            this.wb.BackColor = System.Drawing.Color.White;
            this.wb.Location = new System.Drawing.Point(4, 97);
            this.wb.Name = "wb";
            this.wb.ShowControls = false;
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(457, 503);
            this.wb.TabIndex = 0;
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(4, 65);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(463, 22);
            this.pb.TabIndex = 1;
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUpdate.Location = new System.Drawing.Point(3, 0);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(464, 59);
            this.cmdUpdate.TabIndex = 2;
            this.cmdUpdate.Text = "Update";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // bw
            // 
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // wbResult
            // 
            this.wbResult.BackColor = System.Drawing.Color.White;
            this.wbResult.Location = new System.Drawing.Point(475, 123);
            this.wbResult.Name = "wbResult";
            this.wbResult.ShowControls = false;
            this.wbResult.Silent = false;
            this.wbResult.Size = new System.Drawing.Size(437, 465);
            this.wbResult.TabIndex = 3;
            this.wbResult.OnNavigate2 += new ToolsWin.OnNavigate2HandlerPlain(this.wbResult_OnNavigate2);
            // 
            // ph
            // 
            this.ph.BackColor = System.Drawing.Color.Blue;
            this.ph.Location = new System.Drawing.Point(4, 91);
            this.ph.Name = "ph";
            this.ph.Size = new System.Drawing.Size(938, 2);
            this.ph.TabIndex = 4;
            this.ph.TabStop = false;
            // 
            // pv
            // 
            this.pv.BackColor = System.Drawing.Color.Blue;
            this.pv.Location = new System.Drawing.Point(467, 93);
            this.pv.Name = "pv";
            this.pv.Size = new System.Drawing.Size(2, 517);
            this.pv.TabIndex = 5;
            this.pv.TabStop = false;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(474, 97);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(91, 23);
            this.lblLocation.TabIndex = 6;
            this.lblLocation.Text = "Location...";
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarget.Location = new System.Drawing.Point(474, 0);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(73, 23);
            this.lblTarget.TabIndex = 7;
            this.lblTarget.Text = "Target...";
            // 
            // WebDispatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.pv);
            this.Controls.Add(this.ph);
            this.Controls.Add(this.wbResult);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.wb);
            this.Name = "WebDispatch";
            this.Size = new System.Drawing.Size(967, 646);
            this.Resize += new System.EventHandler(this.WebDispatch_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.ph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolsWin.BrowserPlain wb;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.Button cmdUpdate;
        private System.ComponentModel.BackgroundWorker bw;
        private ToolsWin.BrowserPlain wbResult;
        private System.Windows.Forms.PictureBox ph;
        private System.Windows.Forms.PictureBox pv;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblTarget;
    }
}
