namespace NewMethod.Grids
{
    partial class GridView
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
            this.lblCaption = new System.Windows.Forms.Label();
            this.pOptions = new System.Windows.Forms.Panel();
            this.cmdExportXls = new System.Windows.Forms.Button();
            this.pDate = new System.Windows.Forms.Panel();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdCSV = new System.Windows.Forms.Button();
            this.bgLoad = new System.ComponentModel.BackgroundWorker();
            this.cmdChart = new System.Windows.Forms.Button();
            this.wb = new ToolsWin.Browser();
            this.dtEnd = new NewMethod.nEdit_Date();
            this.dtStart = new NewMethod.nEdit_Date();
            this.throb = new NewMethod.nThrobber();
            this.lblChartBy = new System.Windows.Forms.LinkLabel();
            this.optYear = new System.Windows.Forms.RadioButton();
            this.optMonth = new System.Windows.Forms.RadioButton();
            this.pOptions.SuspendLayout();
            this.pDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(2, 2);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(74, 24);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Caption";
            // 
            // pOptions
            // 
            this.pOptions.Controls.Add(this.cmdChart);
            this.pOptions.Controls.Add(this.cmdExportXls);
            this.pOptions.Controls.Add(this.pDate);
            this.pOptions.Controls.Add(this.cmdPrint);
            this.pOptions.Controls.Add(this.throb);
            this.pOptions.Controls.Add(this.cmdSave);
            this.pOptions.Controls.Add(this.cmdRefresh);
            this.pOptions.Controls.Add(this.cmdCSV);
            this.pOptions.Location = new System.Drawing.Point(6, 29);
            this.pOptions.Name = "pOptions";
            this.pOptions.Size = new System.Drawing.Size(133, 575);
            this.pOptions.TabIndex = 1;
            // 
            // cmdExportXls
            // 
            this.cmdExportXls.Location = new System.Drawing.Point(3, 207);
            this.cmdExportXls.Name = "cmdExportXls";
            this.cmdExportXls.Size = new System.Drawing.Size(121, 37);
            this.cmdExportXls.TabIndex = 5;
            this.cmdExportXls.Text = "Export .xls";
            this.cmdExportXls.UseVisualStyleBackColor = true;
            this.cmdExportXls.Click += new System.EventHandler(this.cmdExportXls_Click);
            // 
            // pDate
            // 
            this.pDate.BackColor = System.Drawing.Color.White;
            this.pDate.Controls.Add(this.optMonth);
            this.pDate.Controls.Add(this.optYear);
            this.pDate.Controls.Add(this.lblChartBy);
            this.pDate.Controls.Add(this.dtEnd);
            this.pDate.Controls.Add(this.dtStart);
            this.pDate.Location = new System.Drawing.Point(4, 318);
            this.pDate.Name = "pDate";
            this.pDate.Size = new System.Drawing.Size(124, 205);
            this.pDate.TabIndex = 4;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Location = new System.Drawing.Point(3, 121);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(121, 37);
            this.cmdPrint.TabIndex = 3;
            this.cmdPrint.Text = "Print";
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(3, 78);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(121, 37);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(3, 35);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(121, 37);
            this.cmdRefresh.TabIndex = 1;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdCSV
            // 
            this.cmdCSV.Location = new System.Drawing.Point(3, 164);
            this.cmdCSV.Name = "cmdCSV";
            this.cmdCSV.Size = new System.Drawing.Size(121, 37);
            this.cmdCSV.TabIndex = 0;
            this.cmdCSV.Text = "Export .csv";
            this.cmdCSV.UseVisualStyleBackColor = true;
            this.cmdCSV.Click += new System.EventHandler(this.cmdCSV_Click);
            // 
            // bgLoad
            // 
            this.bgLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgLoad_DoWork);
            this.bgLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgLoad_RunWorkerCompleted);
            // 
            // cmdChart
            // 
            this.cmdChart.Location = new System.Drawing.Point(3, 250);
            this.cmdChart.Name = "cmdChart";
            this.cmdChart.Size = new System.Drawing.Size(121, 37);
            this.cmdChart.TabIndex = 6;
            this.cmdChart.Text = "Chart";
            this.cmdChart.UseVisualStyleBackColor = true;
            this.cmdChart.Click += new System.EventHandler(this.cmdChart_Click);
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(174, 29);
            this.wb.Name = "wb";
            this.wb.ShowControls = false;
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(429, 474);
            this.wb.TabIndex = 2;
            // 
            // dtEnd
            // 
            this.dtEnd.AllowClear = false;
            this.dtEnd.BackColor = System.Drawing.Color.White;
            this.dtEnd.Bold = false;
            this.dtEnd.Caption = "End";
            this.dtEnd.Changed = false;
            this.dtEnd.Location = new System.Drawing.Point(8, 62);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(105, 41);
            this.dtEnd.SuppressEdit = false;
            this.dtEnd.TabIndex = 1;
            this.dtEnd.UseParentBackColor = true;
            this.dtEnd.zz_GlobalColor = System.Drawing.Color.Black;
            this.dtEnd.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dtEnd.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.dtEnd.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.dtEnd.zz_OriginalDesign = false;
            this.dtEnd.zz_ShowNeedsSaveColor = true;
            this.dtEnd.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.dtEnd.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.zz_UseGlobalColor = false;
            this.dtEnd.zz_UseGlobalFont = false;
            // 
            // dtStart
            // 
            this.dtStart.AllowClear = false;
            this.dtStart.BackColor = System.Drawing.Color.White;
            this.dtStart.Bold = false;
            this.dtStart.Caption = "Start";
            this.dtStart.Changed = false;
            this.dtStart.Location = new System.Drawing.Point(8, 15);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(105, 41);
            this.dtStart.SuppressEdit = false;
            this.dtStart.TabIndex = 0;
            this.dtStart.UseParentBackColor = true;
            this.dtStart.zz_GlobalColor = System.Drawing.Color.Black;
            this.dtStart.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dtStart.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.dtStart.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.dtStart.zz_OriginalDesign = false;
            this.dtStart.zz_ShowNeedsSaveColor = true;
            this.dtStart.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.dtStart.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.zz_UseGlobalColor = false;
            this.dtStart.zz_UseGlobalFont = false;
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.Maroon;
            this.throb.Location = new System.Drawing.Point(6, 4);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(28, 25);
            this.throb.TabIndex = 3;
            this.throb.UseParentBackColor = false;
            // 
            // lblChartBy
            // 
            this.lblChartBy.AutoSize = true;
            this.lblChartBy.Location = new System.Drawing.Point(14, 113);
            this.lblChartBy.Name = "lblChartBy";
            this.lblChartBy.Size = new System.Drawing.Size(47, 13);
            this.lblChartBy.TabIndex = 2;
            this.lblChartBy.TabStop = true;
            this.lblChartBy.Text = "Chart By";
            this.lblChartBy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChartBy_LinkClicked);
            // 
            // optYear
            // 
            this.optYear.AutoSize = true;
            this.optYear.Location = new System.Drawing.Point(67, 130);
            this.optYear.Name = "optYear";
            this.optYear.Size = new System.Drawing.Size(47, 17);
            this.optYear.TabIndex = 3;
            this.optYear.Text = "Year";
            this.optYear.UseVisualStyleBackColor = true;
            // 
            // optMonth
            // 
            this.optMonth.AutoSize = true;
            this.optMonth.Checked = true;
            this.optMonth.Location = new System.Drawing.Point(66, 113);
            this.optMonth.Name = "optMonth";
            this.optMonth.Size = new System.Drawing.Size(55, 17);
            this.optMonth.TabIndex = 4;
            this.optMonth.TabStop = true;
            this.optMonth.Text = "Month";
            this.optMonth.UseVisualStyleBackColor = true;
            // 
            // GridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.wb);
            this.Controls.Add(this.pOptions);
            this.Controls.Add(this.lblCaption);
            this.Name = "GridView";
            this.Size = new System.Drawing.Size(774, 651);
            this.Resize += new System.EventHandler(this.GridView_Resize);
            this.pOptions.ResumeLayout(false);
            this.pDate.ResumeLayout(false);
            this.pDate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Panel pOptions;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Button cmdCSV;
        private ToolsWin.Browser wb;
        private System.ComponentModel.BackgroundWorker bgLoad;
        private nThrobber throb;
        private System.Windows.Forms.Panel pDate;
        private nEdit_Date dtStart;
        private nEdit_Date dtEnd;
        private System.Windows.Forms.Button cmdExportXls;
        private System.Windows.Forms.Button cmdChart;
        private System.Windows.Forms.RadioButton optMonth;
        private System.Windows.Forms.RadioButton optYear;
        private System.Windows.Forms.LinkLabel lblChartBy;
    }
}
