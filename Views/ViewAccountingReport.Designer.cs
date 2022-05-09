namespace RzInterfaceWin
{
    partial class ViewAccountingReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewAccountingReport));
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pbBottom = new System.Windows.Forms.PictureBox();
            this.pbTop = new System.Windows.Forms.PictureBox();
            this.wb = new ToolsWin.BrowserPlain();
            this.pHeader = new System.Windows.Forms.Panel();
            this.reportDate = new Rz5.Win.Controls.ReportCriteriaControlDateRange();
            this.picSide = new System.Windows.Forms.PictureBox();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.throb = new NewMethod.nThrobber();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.il = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).BeginInit();
            this.pHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSide)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLeft
            // 
            this.pbLeft.BackColor = System.Drawing.Color.Black;
            this.pbLeft.Location = new System.Drawing.Point(319, 126);
            this.pbLeft.Margin = new System.Windows.Forms.Padding(4);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(16, 15);
            this.pbLeft.TabIndex = 36;
            this.pbLeft.TabStop = false;
            // 
            // pbRight
            // 
            this.pbRight.BackColor = System.Drawing.Color.Black;
            this.pbRight.Location = new System.Drawing.Point(319, 104);
            this.pbRight.Margin = new System.Windows.Forms.Padding(4);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(16, 15);
            this.pbRight.TabIndex = 35;
            this.pbRight.TabStop = false;
            // 
            // pbBottom
            // 
            this.pbBottom.BackColor = System.Drawing.Color.Black;
            this.pbBottom.Location = new System.Drawing.Point(343, 104);
            this.pbBottom.Margin = new System.Windows.Forms.Padding(4);
            this.pbBottom.Name = "pbBottom";
            this.pbBottom.Size = new System.Drawing.Size(16, 15);
            this.pbBottom.TabIndex = 34;
            this.pbBottom.TabStop = false;
            // 
            // pbTop
            // 
            this.pbTop.BackColor = System.Drawing.Color.Black;
            this.pbTop.Location = new System.Drawing.Point(343, 126);
            this.pbTop.Margin = new System.Windows.Forms.Padding(4);
            this.pbTop.Name = "pbTop";
            this.pbTop.Size = new System.Drawing.Size(16, 15);
            this.pbTop.TabIndex = 33;
            this.pbTop.TabStop = false;
            // 
            // wb
            // 
            this.wb.BackColor = System.Drawing.Color.White;
            this.wb.Location = new System.Drawing.Point(319, 10);
            this.wb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.wb.Name = "wb";
            this.wb.ShowControls = false;
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(115, 86);
            this.wb.TabIndex = 37;
            this.wb.OnNavigate2 += new ToolsWin.OnNavigate2HandlerPlain(this.wb_OnNavigate2);
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.reportDate);
            this.pHeader.Controls.Add(this.picSide);
            this.pHeader.Controls.Add(this.cmdPrint);
            this.pHeader.Controls.Add(this.throb);
            this.pHeader.Controls.Add(this.cmdRefresh);
            this.pHeader.Controls.Add(this.lblTitle);
            this.pHeader.Location = new System.Drawing.Point(9, 10);
            this.pHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(302, 268);
            this.pHeader.TabIndex = 38;
            // 
            // reportDate
            // 
            this.reportDate.BackColor = System.Drawing.Color.White;
            this.reportDate.Location = new System.Drawing.Point(5, 155);
            this.reportDate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.reportDate.Name = "reportDate";
            this.reportDate.Size = new System.Drawing.Size(253, 112);
            this.reportDate.TabIndex = 39;
            // 
            // picSide
            // 
            this.picSide.BackColor = System.Drawing.Color.White;
            this.picSide.BackgroundImage = global::RzInterfaceWin.Properties.Resources.GrayShard2;
            this.picSide.Location = new System.Drawing.Point(267, 0);
            this.picSide.Margin = new System.Windows.Forms.Padding(4);
            this.picSide.Name = "picSide";
            this.picSide.Size = new System.Drawing.Size(35, 267);
            this.picSide.TabIndex = 8;
            this.picSide.TabStop = false;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrint.Image = global::RzInterfaceWin.Properties.Resources.Print;
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdPrint.Location = new System.Drawing.Point(13, 72);
            this.cmdPrint.Margin = new System.Windows.Forms.Padding(4);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(93, 76);
            this.cmdPrint.TabIndex = 5;
            this.cmdPrint.Text = "Print";
            this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.Red;
            this.throb.Location = new System.Drawing.Point(120, 99);
            this.throb.Margin = new System.Windows.Forms.Padding(5);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(28, 25);
            this.throb.TabIndex = 2;
            this.throb.UseParentBackColor = false;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdRefresh.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRefresh.Image = global::RzInterfaceWin.Properties.Resources.RefreshBlue3;
            this.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdRefresh.Location = new System.Drawing.Point(159, 72);
            this.cmdRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(93, 76);
            this.cmdRefresh.TabIndex = 1;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(8, 6);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(244, 62);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Statement Of Owner\'s Equity";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bw
            // 
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Transparent;
            this.il.Images.SetKeyName(0, "Print.png");
            // 
            // ViewAccountingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pHeader);
            this.Controls.Add(this.wb);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.pbBottom);
            this.Controls.Add(this.pbTop);
            this.Name = "ViewAccountingReport";
            this.Size = new System.Drawing.Size(470, 289);
            this.Resize += new System.EventHandler(this.ViewAccountingReport_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).EndInit();
            this.pHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.PictureBox pbBottom;
        private System.Windows.Forms.PictureBox pbTop;
        private ToolsWin.BrowserPlain wb;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Button cmdPrint;
        private NewMethod.nThrobber throb;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Label lblTitle;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.PictureBox picSide;
        private Rz5.Win.Controls.ReportCriteriaControlDateRange reportDate;
    }
}
