using NewMethod;

namespace Rz5
{
    partial class ProfitReportScreen
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
            try
            {
                if (disposing && (components != null))
                {
                    CompleteDispose();
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch (System.Exception)
            { }
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.cmdExcel = new System.Windows.Forms.Button();
            this.cmdLastMonth = new System.Windows.Forms.Button();
            this.cmdThisMonth = new System.Windows.Forms.Button();
            this.throb = new NewMethod.nThrobber();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.cboAgent = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtEnd = new NewMethod.nEdit_Date();
            this.dtStart = new NewMethod.nEdit_Date();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.mnuDomain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contactOEMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactDistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.domainViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.domainAlwaysOEMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.domainAlwaysDistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wb = new ToolsWin.BrowserPlain();
            this.bgExcel = new System.ComponentModel.BackgroundWorker();
            this.pExport = new System.Windows.Forms.Panel();
            this.gbOptions.SuspendLayout();
            this.mnuDomain.SuspendLayout();
            this.pExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOptions
            // 
            this.gbOptions.BackColor = System.Drawing.Color.White;
            this.gbOptions.Controls.Add(this.pExport);
            this.gbOptions.Controls.Add(this.cmdLastMonth);
            this.gbOptions.Controls.Add(this.cmdThisMonth);
            this.gbOptions.Controls.Add(this.throb);
            this.gbOptions.Controls.Add(this.cboAgent);
            this.gbOptions.Controls.Add(this.label2);
            this.gbOptions.Controls.Add(this.cmdView);
            this.gbOptions.Controls.Add(this.label1);
            this.gbOptions.Controls.Add(this.dtEnd);
            this.gbOptions.Controls.Add(this.dtStart);
            this.gbOptions.Location = new System.Drawing.Point(0, 5);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(185, 709);
            this.gbOptions.TabIndex = 0;
            this.gbOptions.TabStop = false;
            // 
            // cmdExcel
            // 
            this.cmdExcel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExcel.Location = new System.Drawing.Point(3, 37);
            this.cmdExcel.Name = "cmdExcel";
            this.cmdExcel.Size = new System.Drawing.Size(170, 29);
            this.cmdExcel.TabIndex = 31;
            this.cmdExcel.Text = "Excel";
            this.cmdExcel.UseVisualStyleBackColor = true;
            this.cmdExcel.Click += new System.EventHandler(this.cmdExcel_Click);
            // 
            // cmdLastMonth
            // 
            this.cmdLastMonth.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLastMonth.Location = new System.Drawing.Point(9, 80);
            this.cmdLastMonth.Name = "cmdLastMonth";
            this.cmdLastMonth.Size = new System.Drawing.Size(170, 30);
            this.cmdLastMonth.TabIndex = 1;
            this.cmdLastMonth.Text = "Last Month";
            this.cmdLastMonth.UseVisualStyleBackColor = true;
            this.cmdLastMonth.Click += new System.EventHandler(this.cmdLastMonth_Click);
            // 
            // cmdThisMonth
            // 
            this.cmdThisMonth.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdThisMonth.Location = new System.Drawing.Point(9, 44);
            this.cmdThisMonth.Name = "cmdThisMonth";
            this.cmdThisMonth.Size = new System.Drawing.Size(170, 30);
            this.cmdThisMonth.TabIndex = 0;
            this.cmdThisMonth.Text = "This Month";
            this.cmdThisMonth.UseVisualStyleBackColor = true;
            this.cmdThisMonth.Click += new System.EventHandler(this.cmdThisMonth_Click);
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.White;
            this.throb.Location = new System.Drawing.Point(151, 13);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(31, 25);
            this.throb.TabIndex = 25;
            this.throb.UseParentBackColor = false;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrint.Location = new System.Drawing.Point(3, 3);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(170, 29);
            this.cmdPrint.TabIndex = 6;
            this.cmdPrint.Text = "Print";
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cboAgent
            // 
            this.cboAgent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgent.FormattingEnabled = true;
            this.cboAgent.Location = new System.Drawing.Point(9, 236);
            this.cboAgent.Name = "cboAgent";
            this.cboAgent.Size = new System.Drawing.Size(170, 21);
            this.cboAgent.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Agent / Team:";
            // 
            // cmdView
            // 
            this.cmdView.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdView.Location = new System.Drawing.Point(7, 263);
            this.cmdView.Name = "cmdView";
            this.cmdView.Size = new System.Drawing.Size(170, 65);
            this.cmdView.TabIndex = 2;
            this.cmdView.Text = "View";
            this.cmdView.UseVisualStyleBackColor = true;
            this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Profit Report";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtEnd
            // 
            this.dtEnd.AllowClear = false;
            this.dtEnd.BackColor = System.Drawing.Color.White;
            this.dtEnd.Bold = false;
            this.dtEnd.Caption = "End Date";
            this.dtEnd.Changed = false;
            this.dtEnd.Location = new System.Drawing.Point(4, 167);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(177, 50);
            this.dtEnd.SuppressEdit = false;
            this.dtEnd.TabIndex = 1;
            this.dtEnd.UseParentBackColor = true;
            this.dtEnd.zz_GlobalColor = System.Drawing.Color.Black;
            this.dtEnd.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.dtEnd.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.dtEnd.zz_OriginalDesign = false;
            this.dtEnd.zz_ShowNeedsSaveColor = true;
            this.dtEnd.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.dtEnd.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.zz_UseGlobalColor = false;
            this.dtEnd.zz_UseGlobalFont = false;
            // 
            // dtStart
            // 
            this.dtStart.AllowClear = false;
            this.dtStart.BackColor = System.Drawing.Color.White;
            this.dtStart.Bold = false;
            this.dtStart.Caption = "Start Date";
            this.dtStart.Changed = false;
            this.dtStart.Location = new System.Drawing.Point(4, 118);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(177, 50);
            this.dtStart.SuppressEdit = false;
            this.dtStart.TabIndex = 0;
            this.dtStart.UseParentBackColor = true;
            this.dtStart.zz_GlobalColor = System.Drawing.Color.Black;
            this.dtStart.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.dtStart.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.dtStart.zz_OriginalDesign = false;
            this.dtStart.zz_ShowNeedsSaveColor = true;
            this.dtStart.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.dtStart.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.zz_UseGlobalColor = false;
            this.dtStart.zz_UseGlobalFont = false;
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(4, 788);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(744, 14);
            this.pb.TabIndex = 1;
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // mnuDomain
            // 
            this.mnuDomain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contactOEMToolStripMenuItem,
            this.contactDistToolStripMenuItem,
            this.toolStripSeparator1,
            this.domainViewToolStripMenuItem,
            this.domainAlwaysOEMToolStripMenuItem,
            this.domainAlwaysDistToolStripMenuItem});
            this.mnuDomain.Name = "mnuDomain";
            this.mnuDomain.Size = new System.Drawing.Size(194, 120);
            // 
            // contactOEMToolStripMenuItem
            // 
            this.contactOEMToolStripMenuItem.Name = "contactOEMToolStripMenuItem";
            this.contactOEMToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.contactOEMToolStripMenuItem.Text = "Contact - OEM";
            this.contactOEMToolStripMenuItem.Click += new System.EventHandler(this.contactOEMToolStripMenuItem_Click);
            // 
            // contactDistToolStripMenuItem
            // 
            this.contactDistToolStripMenuItem.Name = "contactDistToolStripMenuItem";
            this.contactDistToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.contactDistToolStripMenuItem.Text = "Contact - Dist";
            this.contactDistToolStripMenuItem.Click += new System.EventHandler(this.contactDistToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // domainViewToolStripMenuItem
            // 
            this.domainViewToolStripMenuItem.Name = "domainViewToolStripMenuItem";
            this.domainViewToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.domainViewToolStripMenuItem.Text = "Domain - View";
            this.domainViewToolStripMenuItem.Click += new System.EventHandler(this.domainViewToolStripMenuItem_Click);
            // 
            // domainAlwaysOEMToolStripMenuItem
            // 
            this.domainAlwaysOEMToolStripMenuItem.Name = "domainAlwaysOEMToolStripMenuItem";
            this.domainAlwaysOEMToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.domainAlwaysOEMToolStripMenuItem.Text = "Domain - Always OEM";
            this.domainAlwaysOEMToolStripMenuItem.Click += new System.EventHandler(this.domainAlwaysOEMToolStripMenuItem_Click);
            // 
            // domainAlwaysDistToolStripMenuItem
            // 
            this.domainAlwaysDistToolStripMenuItem.Name = "domainAlwaysDistToolStripMenuItem";
            this.domainAlwaysDistToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.domainAlwaysDistToolStripMenuItem.Text = "Domain - Always Dist";
            this.domainAlwaysDistToolStripMenuItem.Click += new System.EventHandler(this.domainAlwaysDistToolStripMenuItem_Click);
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(199, 11);
            this.wb.Name = "wb";
            this.wb.ShowControls = false;
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(548, 638);
            this.wb.TabIndex = 2;
            this.wb.OnNavigate += new ToolsWin.OnNavigateHandler(this.wb_OnNavigate);
            // 
            // bgExcel
            // 
            this.bgExcel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgExcel_DoWork);
            this.bgExcel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgExcel_RunWorkerCompleted);
            // 
            // pExport
            // 
            this.pExport.Controls.Add(this.cmdPrint);
            this.pExport.Controls.Add(this.cmdExcel);
            this.pExport.Location = new System.Drawing.Point(4, 329);
            this.pExport.Name = "pExport";
            this.pExport.Size = new System.Drawing.Size(176, 69);
            this.pExport.TabIndex = 32;
            this.pExport.Visible = false;
            // 
            // ProfitReportScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.wb);
            this.Controls.Add(this.gbOptions);
            this.Controls.Add(this.pb);
            this.Name = "ProfitReportScreen";
            this.Size = new System.Drawing.Size(868, 802);
            this.Resize += new System.EventHandler(this.ProfitReport_Resize);
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.mnuDomain.ResumeLayout(false);
            this.pExport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pb;
        private System.ComponentModel.BackgroundWorker bg;
        private System.Windows.Forms.ContextMenuStrip mnuDomain;
        private System.Windows.Forms.ToolStripMenuItem contactOEMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactDistToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem domainViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem domainAlwaysOEMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem domainAlwaysDistToolStripMenuItem;
        protected System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.Button cmdLastMonth;
        private System.Windows.Forms.Button cmdThisMonth;
        protected nEdit_Date dtEnd;
        protected nEdit_Date dtStart;
        protected System.Windows.Forms.Button cmdPrint;
        protected System.Windows.Forms.ComboBox cboAgent;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Button cmdView;
        protected nThrobber throb;
        protected System.Windows.Forms.Button cmdExcel;
        protected ToolsWin.BrowserPlain wb;
        private System.ComponentModel.BackgroundWorker bgExcel;
        private System.Windows.Forms.Panel pExport;
    }
}
