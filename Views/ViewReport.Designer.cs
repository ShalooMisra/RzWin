namespace Rz5.Win.Views
{
    partial class ViewReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewReport));
            this.pHeader = new System.Windows.Forms.Panel();
            this.pExport = new System.Windows.Forms.Panel();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.cmdExcel = new System.Windows.Forms.Button();
            this.cmdExport = new System.Windows.Forms.Button();
            this.throb = new NewMethod.nThrobber();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.wb = new ToolsWin.BrowserPlain();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.fp = new System.Windows.Forms.FlowLayoutPanel();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.picSide = new System.Windows.Forms.PictureBox();
            this.pBottom = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.pHeader.SuspendLayout();
            this.pExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSide)).BeginInit();
            this.pBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.pExport);
            this.pHeader.Controls.Add(this.throb);
            this.pHeader.Controls.Add(this.cmdRefresh);
            this.pHeader.Controls.Add(this.lblTitle);
            this.pHeader.Location = new System.Drawing.Point(6, 6);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(214, 186);
            this.pHeader.TabIndex = 0;
            // 
            // pExport
            // 
            this.pExport.Controls.Add(this.cmdPrint);
            this.pExport.Controls.Add(this.cmdExcel);
            this.pExport.Controls.Add(this.cmdExport);
            this.pExport.Location = new System.Drawing.Point(0, 120);
            this.pExport.Name = "pExport";
            this.pExport.Size = new System.Drawing.Size(211, 65);
            this.pExport.TabIndex = 4;
            this.pExport.Visible = false;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrint.Image = global::RzInterfaceWin.Properties.Resources.Print;
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdPrint.Location = new System.Drawing.Point(76, 3);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(59, 60);
            this.cmdPrint.TabIndex = 5;
            this.cmdPrint.Text = "Print";
            this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdExcel
            // 
            this.cmdExcel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExcel.Image = global::RzInterfaceWin.Properties.Resources.ExcelFile3;
            this.cmdExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdExcel.Location = new System.Drawing.Point(141, 3);
            this.cmdExcel.Name = "cmdExcel";
            this.cmdExcel.Size = new System.Drawing.Size(59, 60);
            this.cmdExcel.TabIndex = 4;
            this.cmdExcel.Text = "Excel";
            this.cmdExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdExcel.UseVisualStyleBackColor = true;
            this.cmdExcel.Click += new System.EventHandler(this.cmdExcel_Click);
            // 
            // cmdExport
            // 
            this.cmdExport.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExport.Image = global::RzInterfaceWin.Properties.Resources.CsvFile3;
            this.cmdExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdExport.Location = new System.Drawing.Point(10, 3);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(59, 60);
            this.cmdExport.TabIndex = 3;
            this.cmdExport.Text = ".csv";
            this.cmdExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.Red;
            this.throb.Location = new System.Drawing.Point(89, 67);
            this.throb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(35, 35);
            this.throb.TabIndex = 2;
            this.throb.UseParentBackColor = false;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdRefresh.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRefresh.Image = global::RzInterfaceWin.Properties.Resources.RefreshBlue3;
            this.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdRefresh.Location = new System.Drawing.Point(73, 54);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(65, 62);
            this.cmdRefresh.TabIndex = 1;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(6, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(205, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "<title>";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // wb
            // 
            this.wb.BackColor = System.Drawing.Color.White;
            this.wb.Location = new System.Drawing.Point(255, 3);
            this.wb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.wb.Name = "wb";
            this.wb.ShowControls = false;
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(306, 375);
            this.wb.TabIndex = 1;
            this.wb.OnNavigate += new ToolsWin.OnNavigateHandler(this.wb_OnNavigate);
            // 
            // bw
            // 
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // fp
            // 
            this.fp.AutoScroll = true;
            this.fp.AutoSize = true;
            this.fp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fp.Location = new System.Drawing.Point(6, 196);
            this.fp.Name = "fp";
            this.fp.Size = new System.Drawing.Size(214, 120);
            this.fp.TabIndex = 2;
            this.fp.WrapContents = false;
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Transparent;
            this.il.Images.SetKeyName(0, "Print.png");
            // 
            // picSide
            // 
            this.picSide.BackColor = System.Drawing.Color.White;
            this.picSide.BackgroundImage = global::RzInterfaceWin.Properties.Resources.GrayShard2;
            this.picSide.Location = new System.Drawing.Point(223, 0);
            this.picSide.Name = "picSide";
            this.picSide.Size = new System.Drawing.Size(26, 519);
            this.picSide.TabIndex = 3;
            this.picSide.TabStop = false;
            // 
            // pBottom
            // 
            this.pBottom.Controls.Add(this.lblCount);
            this.pBottom.Controls.Add(this.lblDescription);
            this.pBottom.Location = new System.Drawing.Point(6, 322);
            this.pBottom.Name = "pBottom";
            this.pBottom.Size = new System.Drawing.Size(214, 136);
            this.pBottom.TabIndex = 4;
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(3, 116);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(206, 16);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "count";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCount.Visible = false;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.Gray;
            this.lblDescription.Location = new System.Drawing.Point(4, 3);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(205, 113);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "description text...";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // ViewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.fp);
            this.Controls.Add(this.pBottom);
            this.Controls.Add(this.picSide);
            this.Controls.Add(this.wb);
            this.Controls.Add(this.pHeader);
            this.Name = "ViewReport";
            this.Size = new System.Drawing.Size(811, 585);
            this.Resize += new System.EventHandler(this.ViewReport_Resize);
            this.pHeader.ResumeLayout(false);
            this.pExport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSide)).EndInit();
            this.pBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pHeader;
        private NewMethod.nThrobber throb;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Label lblTitle;
        private ToolsWin.BrowserPlain wb;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.FlowLayoutPanel fp;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.PictureBox picSide;
        private System.Windows.Forms.Panel pExport;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.Button cmdExcel;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.Panel pBottom;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblDescription;
    }
}
