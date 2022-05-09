namespace NewMethod
{
    partial class nQuery
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
            this.split = new System.Windows.Forms.SplitContainer();
            this.txtSQL = new System.Windows.Forms.RichTextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lv = new ManagedControls.ManagedListView();
            this.cmdExportToCsv = new System.Windows.Forms.Button();
            this.cmdExportToExcel = new System.Windows.Forms.Button();
            this.cmdRun = new System.Windows.Forms.Button();
            this.gb = new System.Windows.Forms.GroupBox();
            this.sendToMeButton = new System.Windows.Forms.Button();
            this.cmdExportToHTML = new System.Windows.Forms.Button();
            this.optCompareTables = new System.Windows.Forms.RadioButton();
            this.optSQL = new System.Windows.Forms.RadioButton();
            this.throb = new NewMethod.nThrobber();
            this.cmdClear = new System.Windows.Forms.Button();
            this.chkSkipShow = new System.Windows.Forms.CheckBox();
            this.cmdDataSource = new System.Windows.Forms.Button();
            this.sb = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblResult = new System.Windows.Forms.ToolStripStatusLabel();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.mnuData = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuColumn = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopyColumnValues = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdSaveToTable = new System.Windows.Forms.Button();
            this.mnuRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolCopy = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.gb.SuspendLayout();
            this.sb.SuspendLayout();
            this.mnuColumn.SuspendLayout();
            this.mnuRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // split
            // 
            this.split.Location = new System.Drawing.Point(0, 0);
            this.split.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.split.Name = "split";
            this.split.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.txtSQL);
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.txtResult);
            this.split.Panel2.Controls.Add(this.lv);
            this.split.Size = new System.Drawing.Size(1005, 583);
            this.split.SplitterDistance = 327;
            this.split.SplitterWidth = 5;
            this.split.TabIndex = 1;
            this.split.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.split_SplitterMoved);
            // 
            // txtSQL
            // 
            this.txtSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSQL.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSQL.Location = new System.Drawing.Point(0, 0);
            this.txtSQL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txtSQL.Size = new System.Drawing.Size(1005, 327);
            this.txtSQL.TabIndex = 0;
            this.txtSQL.Text = "";
            this.txtSQL.WordWrap = false;
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(0, 0);
            this.txtResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(1005, 251);
            this.txtResult.TabIndex = 1;
            this.txtResult.WordWrap = false;
            // 
            // lv
            // 
            this.lv.ContextMenuStrip = this.mnuRightClick;
            this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv.FullRowSelect = true;
            this.lv.Location = new System.Drawing.Point(0, 0);
            this.lv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(1005, 251);
            this.lv.TabIndex = 0;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
            // 
            // cmdExportToCsv
            // 
            this.cmdExportToCsv.Location = new System.Drawing.Point(8, 233);
            this.cmdExportToCsv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdExportToCsv.Name = "cmdExportToCsv";
            this.cmdExportToCsv.Size = new System.Drawing.Size(185, 27);
            this.cmdExportToCsv.TabIndex = 5;
            this.cmdExportToCsv.Text = "Export To .csv";
            this.cmdExportToCsv.UseVisualStyleBackColor = true;
            this.cmdExportToCsv.Visible = false;
            this.cmdExportToCsv.Click += new System.EventHandler(this.cmdExportToCsv_Click);
            // 
            // cmdExportToExcel
            // 
            this.cmdExportToExcel.Location = new System.Drawing.Point(8, 198);
            this.cmdExportToExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdExportToExcel.Name = "cmdExportToExcel";
            this.cmdExportToExcel.Size = new System.Drawing.Size(185, 27);
            this.cmdExportToExcel.TabIndex = 4;
            this.cmdExportToExcel.Text = "Export To Excel";
            this.cmdExportToExcel.UseVisualStyleBackColor = true;
            this.cmdExportToExcel.Visible = false;
            this.cmdExportToExcel.Click += new System.EventHandler(this.cmdExportToExcel_Click);
            // 
            // cmdRun
            // 
            this.cmdRun.Location = new System.Drawing.Point(8, 12);
            this.cmdRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(185, 27);
            this.cmdRun.TabIndex = 3;
            this.cmdRun.Text = "Run";
            this.cmdRun.UseVisualStyleBackColor = true;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // gb
            // 
            this.gb.Controls.Add(this.cmdSaveToTable);
            this.gb.Controls.Add(this.sendToMeButton);
            this.gb.Controls.Add(this.cmdExportToHTML);
            this.gb.Controls.Add(this.optCompareTables);
            this.gb.Controls.Add(this.optSQL);
            this.gb.Controls.Add(this.throb);
            this.gb.Controls.Add(this.cmdClear);
            this.gb.Controls.Add(this.chkSkipShow);
            this.gb.Controls.Add(this.cmdDataSource);
            this.gb.Controls.Add(this.cmdExportToCsv);
            this.gb.Controls.Add(this.cmdExportToExcel);
            this.gb.Controls.Add(this.cmdRun);
            this.gb.Location = new System.Drawing.Point(1013, 4);
            this.gb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb.Name = "gb";
            this.gb.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb.Size = new System.Drawing.Size(203, 565);
            this.gb.TabIndex = 6;
            this.gb.TabStop = false;
            // 
            // sendToMeButton
            // 
            this.sendToMeButton.Location = new System.Drawing.Point(8, 329);
            this.sendToMeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendToMeButton.Name = "sendToMeButton";
            this.sendToMeButton.Size = new System.Drawing.Size(185, 50);
            this.sendToMeButton.TabIndex = 13;
            this.sendToMeButton.Text = "Query, Export, and Send";
            this.sendToMeButton.UseVisualStyleBackColor = true;
            this.sendToMeButton.Click += new System.EventHandler(this.sendToMeButton_Click);
            // 
            // cmdExportToHTML
            // 
            this.cmdExportToHTML.Location = new System.Drawing.Point(8, 267);
            this.cmdExportToHTML.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdExportToHTML.Name = "cmdExportToHTML";
            this.cmdExportToHTML.Size = new System.Drawing.Size(185, 27);
            this.cmdExportToHTML.TabIndex = 12;
            this.cmdExportToHTML.Text = "Export To HTML";
            this.cmdExportToHTML.UseVisualStyleBackColor = true;
            this.cmdExportToHTML.Visible = false;
            this.cmdExportToHTML.Click += new System.EventHandler(this.cmdExportToHTML_Click);
            // 
            // optCompareTables
            // 
            this.optCompareTables.AutoSize = true;
            this.optCompareTables.Location = new System.Drawing.Point(11, 427);
            this.optCompareTables.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.optCompareTables.Name = "optCompareTables";
            this.optCompareTables.Size = new System.Drawing.Size(133, 21);
            this.optCompareTables.TabIndex = 11;
            this.optCompareTables.Text = "Compare Tables";
            this.optCompareTables.UseVisualStyleBackColor = true;
            // 
            // optSQL
            // 
            this.optSQL.AutoSize = true;
            this.optSQL.Checked = true;
            this.optSQL.Location = new System.Drawing.Point(11, 401);
            this.optSQL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.optSQL.Name = "optSQL";
            this.optSQL.Size = new System.Drawing.Size(57, 21);
            this.optSQL.TabIndex = 10;
            this.optSQL.TabStop = true;
            this.optSQL.Text = "SQL";
            this.optSQL.UseVisualStyleBackColor = true;
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.Maroon;
            this.throb.Location = new System.Drawing.Point(63, 116);
            this.throb.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(47, 36);
            this.throb.TabIndex = 9;
            this.throb.UseParentBackColor = false;
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(11, 81);
            this.cmdClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(185, 27);
            this.cmdClear.TabIndex = 8;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // chkSkipShow
            // 
            this.chkSkipShow.AutoSize = true;
            this.chkSkipShow.Location = new System.Drawing.Point(31, 299);
            this.chkSkipShow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSkipShow.Name = "chkSkipShow";
            this.chkSkipShow.Size = new System.Drawing.Size(107, 21);
            this.chkSkipShow.TabIndex = 7;
            this.chkSkipShow.Text = "Skip Display";
            this.chkSkipShow.UseVisualStyleBackColor = true;
            this.chkSkipShow.CheckedChanged += new System.EventHandler(this.chkSkipShow_CheckedChanged);
            // 
            // cmdDataSource
            // 
            this.cmdDataSource.Location = new System.Drawing.Point(8, 47);
            this.cmdDataSource.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdDataSource.Name = "cmdDataSource";
            this.cmdDataSource.Size = new System.Drawing.Size(185, 27);
            this.cmdDataSource.TabIndex = 6;
            this.cmdDataSource.Text = "Switch Data Source";
            this.cmdDataSource.UseVisualStyleBackColor = true;
            this.cmdDataSource.Click += new System.EventHandler(this.cmdDataSource_Click);
            // 
            // sb
            // 
            this.sb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblResult});
            this.sb.Location = new System.Drawing.Point(0, 737);
            this.sb.Name = "sb";
            this.sb.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.sb.Size = new System.Drawing.Size(1235, 25);
            this.sb.TabIndex = 7;
            this.sb.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(67, 20);
            this.lblStatus.Text = "<status>";
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.SystemColors.Control;
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(65, 20);
            this.lblResult.Text = "<result>";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // mnuData
            // 
            this.mnuData.Name = "mnuData";
            this.mnuData.Size = new System.Drawing.Size(61, 4);
            // 
            // mnuColumn
            // 
            this.mnuColumn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopyColumnValues});
            this.mnuColumn.Name = "mnuColumn";
            this.mnuColumn.Size = new System.Drawing.Size(215, 28);
            // 
            // mnuCopyColumnValues
            // 
            this.mnuCopyColumnValues.Name = "mnuCopyColumnValues";
            this.mnuCopyColumnValues.Size = new System.Drawing.Size(214, 24);
            this.mnuCopyColumnValues.Text = "&Copy Column Values";
            this.mnuCopyColumnValues.Click += new System.EventHandler(this.mnuCopyColumnValues_Click);
            // 
            // cmdSaveToTable
            // 
            this.cmdSaveToTable.Location = new System.Drawing.Point(8, 163);
            this.cmdSaveToTable.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSaveToTable.Name = "cmdSaveToTable";
            this.cmdSaveToTable.Size = new System.Drawing.Size(185, 27);
            this.cmdSaveToTable.TabIndex = 14;
            this.cmdSaveToTable.Text = "Save To Table";
            this.cmdSaveToTable.UseVisualStyleBackColor = true;
            this.cmdSaveToTable.Visible = false;
            this.cmdSaveToTable.Click += new System.EventHandler(this.cmdSaveToTable_Click);
            // 
            // mnuRightClick
            // 
            this.mnuRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolCopy});
            this.mnuRightClick.Name = "mnuColumn";
            this.mnuRightClick.Size = new System.Drawing.Size(113, 28);
            // 
            // toolCopy
            // 
            this.toolCopy.Name = "toolCopy";
            this.toolCopy.Size = new System.Drawing.Size(152, 24);
            this.toolCopy.Text = "Copy";
            this.toolCopy.Click += new System.EventHandler(this.toolCopy_Click);
            // 
            // nQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.sb);
            this.Controls.Add(this.gb);
            this.Controls.Add(this.split);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "nQuery";
            this.Size = new System.Drawing.Size(1235, 762);
            this.Resize += new System.EventHandler(this.nQuery_Resize);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            this.split.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.sb.ResumeLayout(false);
            this.sb.PerformLayout();
            this.mnuColumn.ResumeLayout(false);
            this.mnuRightClick.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.TextBox txtResult;
        private ManagedControls.ManagedListView lv;
        private System.Windows.Forms.Button cmdRun;
        private System.Windows.Forms.Button cmdExportToExcel;
        private System.Windows.Forms.Button cmdExportToCsv;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Button cmdDataSource;
        private System.Windows.Forms.StatusStrip sb;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.CheckBox chkSkipShow;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.ToolStripStatusLabel lblResult;
        private nThrobber throb;
        private System.ComponentModel.BackgroundWorker bg;
        private System.Windows.Forms.RichTextBox txtSQL;
        private System.Windows.Forms.RadioButton optCompareTables;
        private System.Windows.Forms.RadioButton optSQL;
        private System.Windows.Forms.ContextMenuStrip mnuData;
        private System.Windows.Forms.ContextMenuStrip mnuColumn;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyColumnValues;
        private System.Windows.Forms.Button cmdExportToHTML;
        private System.Windows.Forms.Button sendToMeButton;
        private System.Windows.Forms.Button cmdSaveToTable;
        private System.Windows.Forms.ContextMenuStrip mnuRightClick;
        private System.Windows.Forms.ToolStripMenuItem toolCopy;
    }
}
