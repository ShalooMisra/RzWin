namespace NewMethod
{
    partial class nEmails
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
            this.sp = new System.Windows.Forms.SplitContainer();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.lblLoadFile = new System.Windows.Forms.LinkLabel();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.wb = new ToolsWin.Browser();
            this.sp.Panel1.SuspendLayout();
            this.sp.Panel2.SuspendLayout();
            this.sp.SuspendLayout();
            this.gbOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // sp
            // 
            this.sp.Location = new System.Drawing.Point(8, 11);
            this.sp.Name = "sp";
            // 
            // sp.Panel1
            // 
            this.sp.Panel1.Controls.Add(this.gbOptions);
            this.sp.Panel1.Controls.Add(this.lv);
            // 
            // sp.Panel2
            // 
            this.sp.Panel2.Controls.Add(this.wb);
            this.sp.Size = new System.Drawing.Size(717, 599);
            this.sp.SplitterDistance = 381;
            this.sp.TabIndex = 0;
            this.sp.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.sp_SplitterMoved);
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.lblLoadFile);
            this.gbOptions.Location = new System.Drawing.Point(7, 7);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(225, 34);
            this.gbOptions.TabIndex = 1;
            this.gbOptions.TabStop = false;
            // 
            // lblLoadFile
            // 
            this.lblLoadFile.AutoSize = true;
            this.lblLoadFile.Location = new System.Drawing.Point(5, 12);
            this.lblLoadFile.Name = "lblLoadFile";
            this.lblLoadFile.Size = new System.Drawing.Size(60, 13);
            this.lblLoadFile.TabIndex = 0;
            this.lblLoadFile.TabStop = true;
            this.lblLoadFile.Text = "Load A File";
            this.lblLoadFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLoadFile_LinkClicked);
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lv.FullRowSelect = true;
            this.lv.Location = new System.Drawing.Point(11, 47);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(367, 532);
            this.lv.TabIndex = 0;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
            this.lv.Click += new System.EventHandler(this.lv_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Email";
            this.columnHeader1.Width = 167;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Domain";
            this.columnHeader2.Width = 118;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Suffix";
            this.columnHeader3.Width = 73;
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(19, 23);
            this.wb.Name = "wb";
            this.wb.ShowControls = false;
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(182, 544);
            this.wb.TabIndex = 0;
            // 
            // nEmails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sp);
            this.Name = "nEmails";
            this.Size = new System.Drawing.Size(826, 668);
            this.Resize += new System.EventHandler(this.nEmails_Resize);
            this.sp.Panel1.ResumeLayout(false);
            this.sp.Panel2.ResumeLayout(false);
            this.sp.ResumeLayout(false);
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sp;
        private System.Windows.Forms.ListView lv;
        private ToolsWin.Browser wb;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.LinkLabel lblLoadFile;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}
