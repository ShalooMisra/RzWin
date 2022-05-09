namespace ToolsWin
{
    public partial class TableScanner
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
            this.lvTables = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdList = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.cmdGo = new System.Windows.Forms.Button();
            this.gbNext = new System.Windows.Forms.GroupBox();
            this.txtList = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lblView = new System.Windows.Forms.LinkLabel();
            this.wbTable = new ToolsWin.BrowserPlain();
            this.wb = new ToolsWin.BrowserPlain();
            this.txtCols = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNext = new System.Windows.Forms.TextBox();
            this.cmdCycle = new System.Windows.Forms.Button();
            this.gb.SuspendLayout();
            this.gbNext.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.lvTables);
            this.gb.Controls.Add(this.cmdList);
            this.gb.Location = new System.Drawing.Point(3, 3);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(247, 520);
            this.gb.TabIndex = 1;
            this.gb.TabStop = false;
            // 
            // lvTables
            // 
            this.lvTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvTables.Location = new System.Drawing.Point(7, 55);
            this.lvTables.Name = "lvTables";
            this.lvTables.Size = new System.Drawing.Size(234, 449);
            this.lvTables.TabIndex = 1;
            this.lvTables.UseCompatibleStateImageBehavior = false;
            this.lvTables.View = System.Windows.Forms.View.Details;
            this.lvTables.DoubleClick += new System.EventHandler(this.lvTables_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Text";
            this.columnHeader1.Width = 101;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Columns";
            this.columnHeader2.Width = 63;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Rows";
            this.columnHeader3.Width = 63;
            // 
            // cmdList
            // 
            this.cmdList.Location = new System.Drawing.Point(6, 19);
            this.cmdList.Name = "cmdList";
            this.cmdList.Size = new System.Drawing.Size(227, 26);
            this.cmdList.TabIndex = 0;
            this.cmdList.Text = "List";
            this.cmdList.UseVisualStyleBackColor = true;
            this.cmdList.Click += new System.EventHandler(this.cmdList_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(256, 11);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(403, 20);
            this.txtUrl.TabIndex = 2;
            // 
            // cmdGo
            // 
            this.cmdGo.Location = new System.Drawing.Point(672, 10);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(96, 20);
            this.cmdGo.TabIndex = 3;
            this.cmdGo.Text = "Go";
            this.cmdGo.UseVisualStyleBackColor = true;
            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // gbNext
            // 
            this.gbNext.Controls.Add(this.cmdCycle);
            this.gbNext.Controls.Add(this.label3);
            this.gbNext.Controls.Add(this.txtNext);
            this.gbNext.Controls.Add(this.label2);
            this.gbNext.Controls.Add(this.txtCols);
            this.gbNext.Controls.Add(this.lblView);
            this.gbNext.Controls.Add(this.cmdSave);
            this.gbNext.Controls.Add(this.label1);
            this.gbNext.Controls.Add(this.txtList);
            this.gbNext.Location = new System.Drawing.Point(271, 463);
            this.gbNext.Name = "gbNext";
            this.gbNext.Size = new System.Drawing.Size(918, 69);
            this.gbNext.TabIndex = 5;
            this.gbNext.TabStop = false;
            // 
            // txtList
            // 
            this.txtList.Location = new System.Drawing.Point(39, 19);
            this.txtList.Name = "txtList";
            this.txtList.Size = new System.Drawing.Size(205, 20);
            this.txtList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "List:";
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(263, 11);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(125, 52);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lblView
            // 
            this.lblView.AutoSize = true;
            this.lblView.Location = new System.Drawing.Point(215, 42);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(29, 13);
            this.lblView.TabIndex = 5;
            this.lblView.TabStop = true;
            this.lblView.Text = "view";
            this.lblView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblView_LinkClicked);
            // 
            // wbTable
            // 
            this.wbTable.Location = new System.Drawing.Point(256, 538);
            this.wbTable.Name = "wbTable";
            this.wbTable.ShowControls = false;
            this.wbTable.Silent = false;
            this.wbTable.Size = new System.Drawing.Size(732, 149);
            this.wbTable.TabIndex = 4;
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(256, 46);
            this.wb.Name = "wb";
            this.wb.ShowControls = false;
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(732, 411);
            this.wb.TabIndex = 0;
            // 
            // txtCols
            // 
            this.txtCols.Location = new System.Drawing.Point(487, 13);
            this.txtCols.Name = "txtCols";
            this.txtCols.Size = new System.Drawing.Size(53, 20);
            this.txtCols.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(408, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Cols:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Next Button:";
            // 
            // txtNext
            // 
            this.txtNext.Location = new System.Drawing.Point(487, 39);
            this.txtNext.Name = "txtNext";
            this.txtNext.Size = new System.Drawing.Size(145, 20);
            this.txtNext.TabIndex = 8;
            // 
            // cmdCycle
            // 
            this.cmdCycle.Location = new System.Drawing.Point(654, 11);
            this.cmdCycle.Name = "cmdCycle";
            this.cmdCycle.Size = new System.Drawing.Size(184, 52);
            this.cmdCycle.TabIndex = 10;
            this.cmdCycle.Text = "Cycle";
            this.cmdCycle.UseVisualStyleBackColor = true;
            this.cmdCycle.Click += new System.EventHandler(this.cmdCycle_Click);
            // 
            // TableScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbNext);
            this.Controls.Add(this.wbTable);
            this.Controls.Add(this.cmdGo);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.gb);
            this.Controls.Add(this.wb);
            this.Name = "TableScanner";
            this.Size = new System.Drawing.Size(1192, 652);
            this.gb.ResumeLayout(false);
            this.gbNext.ResumeLayout(false);
            this.gbNext.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolsWin.BrowserPlain wb;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button cmdGo;
        private System.Windows.Forms.ListView lvTables;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button cmdList;
        private BrowserPlain wbTable;
        private System.Windows.Forms.GroupBox gbNext;
        private System.Windows.Forms.LinkLabel lblView;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtList;
        private System.Windows.Forms.TextBox txtCols;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdCycle;
    }
}
