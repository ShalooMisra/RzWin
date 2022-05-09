namespace NewMethod.Original.Controls
{
    partial class nTables
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
            this.cmdCheckZeroRows = new System.Windows.Forms.Button();
            this.lblDeleteChecked = new System.Windows.Forms.LinkLabel();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.cmdCheckWith = new System.Windows.Forms.Button();
            this.throb = new NewMethod.nThrobber();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.cmdCheckZeroRows);
            this.gb.Controls.Add(this.lblDeleteChecked);
            this.gb.Controls.Add(this.lblCount);
            this.gb.Controls.Add(this.txtStart);
            this.gb.Controls.Add(this.cmdCheckWith);
            this.gb.Controls.Add(this.throb);
            this.gb.Controls.Add(this.cmdRefresh);
            this.gb.Location = new System.Drawing.Point(5, 4);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(158, 505);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            // 
            // cmdCheckZeroRows
            // 
            this.cmdCheckZeroRows.Location = new System.Drawing.Point(6, 172);
            this.cmdCheckZeroRows.Name = "cmdCheckZeroRows";
            this.cmdCheckZeroRows.Size = new System.Drawing.Size(142, 29);
            this.cmdCheckZeroRows.TabIndex = 6;
            this.cmdCheckZeroRows.Text = "Check Zero Rows";
            this.cmdCheckZeroRows.UseVisualStyleBackColor = true;
            this.cmdCheckZeroRows.Click += new System.EventHandler(this.cmdCheckZeroRows_Click);
            // 
            // lblDeleteChecked
            // 
            this.lblDeleteChecked.AutoSize = true;
            this.lblDeleteChecked.Location = new System.Drawing.Point(18, 259);
            this.lblDeleteChecked.Name = "lblDeleteChecked";
            this.lblDeleteChecked.Size = new System.Drawing.Size(36, 13);
            this.lblDeleteChecked.TabIndex = 5;
            this.lblDeleteChecked.TabStop = true;
            this.lblDeleteChecked.Text = "delete";
            this.lblDeleteChecked.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDeleteChecked_LinkClicked);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(18, 246);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(46, 13);
            this.lblCount.TabIndex = 4;
            this.lblCount.Text = "<count>";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(6, 146);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(142, 20);
            this.txtStart.TabIndex = 3;
            this.txtStart.Text = "temp_";
            // 
            // cmdCheckWith
            // 
            this.cmdCheckWith.Location = new System.Drawing.Point(6, 111);
            this.cmdCheckWith.Name = "cmdCheckWith";
            this.cmdCheckWith.Size = new System.Drawing.Size(142, 29);
            this.cmdCheckWith.TabIndex = 2;
            this.cmdCheckWith.Text = "Check Starting With";
            this.cmdCheckWith.UseVisualStyleBackColor = true;
            this.cmdCheckWith.Click += new System.EventHandler(this.cmdCheckWith_Click);
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.White;
            this.throb.Location = new System.Drawing.Point(60, 74);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(39, 31);
            this.throb.TabIndex = 1;
            this.throb.UseParentBackColor = false;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(6, 19);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(142, 36);
            this.cmdRefresh.TabIndex = 0;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // lv
            // 
            this.lv.CheckBoxes = true;
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lv.FullRowSelect = true;
            this.lv.Location = new System.Drawing.Point(178, 13);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(770, 582);
            this.lv.TabIndex = 1;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 253;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Created";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 116;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Data Size";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 131;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Index Size";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 110;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Rows";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 99;
            // 
            // nTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lv);
            this.Controls.Add(this.gb);
            this.Name = "nTables";
            this.Size = new System.Drawing.Size(1065, 657);
            this.Resize += new System.EventHandler(this.nTables_Resize);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Button cmdRefresh;
        private nThrobber throb;
        private System.ComponentModel.BackgroundWorker bg;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Button cmdCheckWith;
        private System.Windows.Forms.LinkLabel lblDeleteChecked;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button cmdCheckZeroRows;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
