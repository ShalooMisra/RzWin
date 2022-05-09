namespace RzInterfaceWin
{
    partial class PostOrders
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
            this.pCommands = new System.Windows.Forms.Panel();
            this.throb = new NewMethod.nThrobber();
            this.cmdUnCheck = new System.Windows.Forms.Button();
            this.cmdCheck = new System.Windows.Forms.Button();
            this.cmdPost = new System.Windows.Forms.Button();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.chkService = new System.Windows.Forms.CheckBox();
            this.chkVRMA = new System.Windows.Forms.CheckBox();
            this.chkRMA = new System.Windows.Forms.CheckBox();
            this.chkPurchase = new System.Windows.Forms.CheckBox();
            this.chkInvoice = new System.Windows.Forms.CheckBox();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bgwSearch = new System.ComponentModel.BackgroundWorker();
            this.bgwPost = new System.ComponentModel.BackgroundWorker();
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.pCommands.SuspendLayout();
            this.gbOptions.SuspendLayout();
            this.mnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pCommands
            // 
            this.pCommands.Controls.Add(this.throb);
            this.pCommands.Controls.Add(this.cmdUnCheck);
            this.pCommands.Controls.Add(this.cmdCheck);
            this.pCommands.Controls.Add(this.cmdPost);
            this.pCommands.Location = new System.Drawing.Point(171, 16);
            this.pCommands.Name = "pCommands";
            this.pCommands.Size = new System.Drawing.Size(686, 60);
            this.pCommands.TabIndex = 0;
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.White;
            this.throb.Location = new System.Drawing.Point(133, 4);
            this.throb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(40, 33);
            this.throb.TabIndex = 3;
            this.throb.UseParentBackColor = false;
            // 
            // cmdUnCheck
            // 
            this.cmdUnCheck.Location = new System.Drawing.Point(289, 22);
            this.cmdUnCheck.Name = "cmdUnCheck";
            this.cmdUnCheck.Size = new System.Drawing.Size(103, 32);
            this.cmdUnCheck.TabIndex = 2;
            this.cmdUnCheck.Text = "UnCheck All";
            this.cmdUnCheck.UseVisualStyleBackColor = true;
            this.cmdUnCheck.Click += new System.EventHandler(this.cmdUnCheck_Click);
            // 
            // cmdCheck
            // 
            this.cmdCheck.Location = new System.Drawing.Point(180, 22);
            this.cmdCheck.Name = "cmdCheck";
            this.cmdCheck.Size = new System.Drawing.Size(103, 32);
            this.cmdCheck.TabIndex = 1;
            this.cmdCheck.Text = "Check All";
            this.cmdCheck.UseVisualStyleBackColor = true;
            this.cmdCheck.Click += new System.EventHandler(this.cmdCheck_Click);
            // 
            // cmdPost
            // 
            this.cmdPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPost.Location = new System.Drawing.Point(3, 4);
            this.cmdPost.Name = "cmdPost";
            this.cmdPost.Size = new System.Drawing.Size(123, 53);
            this.cmdPost.TabIndex = 0;
            this.cmdPost.Text = "Post";
            this.cmdPost.UseVisualStyleBackColor = true;
            this.cmdPost.Click += new System.EventHandler(this.cmdPost_Click);
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.cmdSearch);
            this.gbOptions.Controls.Add(this.chkService);
            this.gbOptions.Controls.Add(this.chkVRMA);
            this.gbOptions.Controls.Add(this.chkRMA);
            this.gbOptions.Controls.Add(this.chkPurchase);
            this.gbOptions.Controls.Add(this.chkInvoice);
            this.gbOptions.Location = new System.Drawing.Point(13, 16);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(151, 194);
            this.gbOptions.TabIndex = 1;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Post Options";
            // 
            // cmdSearch
            // 
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearch.Location = new System.Drawing.Point(6, 156);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(138, 32);
            this.cmdSearch.TabIndex = 4;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // chkService
            // 
            this.chkService.AutoSize = true;
            this.chkService.Checked = true;
            this.chkService.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkService.Location = new System.Drawing.Point(6, 129);
            this.chkService.Name = "chkService";
            this.chkService.Size = new System.Drawing.Size(125, 21);
            this.chkService.TabIndex = 4;
            this.chkService.Text = "Service Orders";
            this.chkService.UseVisualStyleBackColor = true;
            // 
            // chkVRMA
            // 
            this.chkVRMA.AutoSize = true;
            this.chkVRMA.Checked = true;
            this.chkVRMA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVRMA.Location = new System.Drawing.Point(6, 102);
            this.chkVRMA.Name = "chkVRMA";
            this.chkVRMA.Size = new System.Drawing.Size(117, 21);
            this.chkVRMA.TabIndex = 3;
            this.chkVRMA.Text = "Vendor RMAs";
            this.chkVRMA.UseVisualStyleBackColor = true;
            // 
            // chkRMA
            // 
            this.chkRMA.AutoSize = true;
            this.chkRMA.Checked = true;
            this.chkRMA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRMA.Location = new System.Drawing.Point(6, 75);
            this.chkRMA.Name = "chkRMA";
            this.chkRMA.Size = new System.Drawing.Size(67, 21);
            this.chkRMA.TabIndex = 2;
            this.chkRMA.Text = "RMAs";
            this.chkRMA.UseVisualStyleBackColor = true;
            // 
            // chkPurchase
            // 
            this.chkPurchase.AutoSize = true;
            this.chkPurchase.Checked = true;
            this.chkPurchase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPurchase.Location = new System.Drawing.Point(6, 48);
            this.chkPurchase.Name = "chkPurchase";
            this.chkPurchase.Size = new System.Drawing.Size(138, 21);
            this.chkPurchase.TabIndex = 1;
            this.chkPurchase.Text = "Purchase Orders";
            this.chkPurchase.UseVisualStyleBackColor = true;
            // 
            // chkInvoice
            // 
            this.chkInvoice.AutoSize = true;
            this.chkInvoice.Checked = true;
            this.chkInvoice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInvoice.Location = new System.Drawing.Point(6, 21);
            this.chkInvoice.Name = "chkInvoice";
            this.chkInvoice.Size = new System.Drawing.Size(81, 21);
            this.chkInvoice.TabIndex = 0;
            this.chkInvoice.Text = "Invoices";
            this.chkInvoice.UseVisualStyleBackColor = true;
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
            this.lv.ContextMenuStrip = this.mnu;
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(171, 82);
            this.lv.MultiSelect = false;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(686, 128);
            this.lv.TabIndex = 2;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Type";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Number";
            this.columnHeader2.Width = 108;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Company";
            this.columnHeader3.Width = 219;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Total";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 99;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Status";
            this.columnHeader5.Width = 103;
            // 
            // bgwSearch
            // 
            this.bgwSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSearch_DoWork);
            this.bgwSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSearch_RunWorkerCompleted);
            // 
            // bgwPost
            // 
            this.bgwPost.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwPost_DoWork);
            this.bgwPost.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwPost_RunWorkerCompleted);
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOpen});
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(115, 28);
            // 
            // toolOpen
            // 
            this.toolOpen.Name = "toolOpen";
            this.toolOpen.Size = new System.Drawing.Size(114, 24);
            this.toolOpen.Text = "Open";
            this.toolOpen.Click += new System.EventHandler(this.toolOpen_Click);
            // 
            // PostOrders
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lv);
            this.Controls.Add(this.gbOptions);
            this.Controls.Add(this.pCommands);
            this.Name = "PostOrders";
            this.Size = new System.Drawing.Size(867, 221);
            this.Resize += new System.EventHandler(this.PostOrders_Resize);
            this.pCommands.ResumeLayout(false);
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.mnu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pCommands;
        private NewMethod.nThrobber throb;
        private System.Windows.Forms.Button cmdUnCheck;
        private System.Windows.Forms.Button cmdCheck;
        private System.Windows.Forms.Button cmdPost;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.CheckBox chkService;
        private System.Windows.Forms.CheckBox chkVRMA;
        private System.Windows.Forms.CheckBox chkRMA;
        private System.Windows.Forms.CheckBox chkPurchase;
        private System.Windows.Forms.CheckBox chkInvoice;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.ComponentModel.BackgroundWorker bgwSearch;
        private System.ComponentModel.BackgroundWorker bgwPost;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.ContextMenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem toolOpen;
    }
}
