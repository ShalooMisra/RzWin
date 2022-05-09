namespace Rz5
{
    partial class QBPost
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
            this.gb = new System.Windows.Forms.GroupBox();
            this.cmdDate = new System.Windows.Forms.Button();
            this.throb = new NewMethod.nThrobber();
            this.cmdVendorRMAs = new System.Windows.Forms.Button();
            this.cmdRMAs = new System.Windows.Forms.Button();
            this.cmdPurchases = new System.Windows.Forms.Button();
            this.cmdInvoices = new System.Windows.Forms.Button();
            this.lblChecked = new System.Windows.Forms.Label();
            this.cmdFax = new System.Windows.Forms.Button();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.cmdPost = new System.Windows.Forms.Button();
            this.chkNotifyCustomer = new System.Windows.Forms.CheckBox();
            this.chkNotifyAgent = new System.Windows.Forms.CheckBox();
            this.chkPreview = new System.Windows.Forms.CheckBox();
            this.cmdCheckNone = new System.Windows.Forms.Button();
            this.cmdCheckAll = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.dtCutoff = new NewMethod.nEdit_Date();
            this.chkUnsent = new System.Windows.Forms.CheckBox();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopies = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEnterCopies = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSend = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSendOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSendCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSendCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.gb.SuspendLayout();
            this.mnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.BackColor = System.Drawing.Color.White;
            this.gb.Controls.Add(this.cmdDate);
            this.gb.Controls.Add(this.throb);
            this.gb.Controls.Add(this.cmdVendorRMAs);
            this.gb.Controls.Add(this.cmdRMAs);
            this.gb.Controls.Add(this.cmdPurchases);
            this.gb.Controls.Add(this.cmdInvoices);
            this.gb.Controls.Add(this.lblChecked);
            this.gb.Controls.Add(this.cmdFax);
            this.gb.Controls.Add(this.cmdPrint);
            this.gb.Controls.Add(this.cmdPost);
            this.gb.Controls.Add(this.chkNotifyCustomer);
            this.gb.Controls.Add(this.chkNotifyAgent);
            this.gb.Controls.Add(this.chkPreview);
            this.gb.Controls.Add(this.cmdCheckNone);
            this.gb.Controls.Add(this.cmdCheckAll);
            this.gb.Controls.Add(this.lblCount);
            this.gb.Controls.Add(this.cmdRefresh);
            this.gb.Controls.Add(this.dtCutoff);
            this.gb.Controls.Add(this.chkUnsent);
            this.gb.Location = new System.Drawing.Point(4, 5);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(172, 621);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            // 
            // cmdDate
            // 
            this.cmdDate.Location = new System.Drawing.Point(137, 61);
            this.cmdDate.Name = "cmdDate";
            this.cmdDate.Size = new System.Drawing.Size(28, 20);
            this.cmdDate.TabIndex = 19;
            this.cmdDate.Text = "...";
            this.cmdDate.UseVisualStyleBackColor = true;
            this.cmdDate.Click += new System.EventHandler(this.cmdDate_Click);
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.White;
            this.throb.Location = new System.Drawing.Point(134, 16);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(33, 30);
            this.throb.TabIndex = 18;
            this.throb.UseParentBackColor = false;
            // 
            // cmdVendorRMAs
            // 
            this.cmdVendorRMAs.Location = new System.Drawing.Point(11, 593);
            this.cmdVendorRMAs.Name = "cmdVendorRMAs";
            this.cmdVendorRMAs.Size = new System.Drawing.Size(148, 22);
            this.cmdVendorRMAs.TabIndex = 17;
            this.cmdVendorRMAs.Text = "Vendor RMAs";
            this.cmdVendorRMAs.UseVisualStyleBackColor = true;
            this.cmdVendorRMAs.Click += new System.EventHandler(this.cmdVendorRMAs_Click);
            // 
            // cmdRMAs
            // 
            this.cmdRMAs.Location = new System.Drawing.Point(11, 567);
            this.cmdRMAs.Name = "cmdRMAs";
            this.cmdRMAs.Size = new System.Drawing.Size(148, 22);
            this.cmdRMAs.TabIndex = 16;
            this.cmdRMAs.Text = "RMAs";
            this.cmdRMAs.UseVisualStyleBackColor = true;
            this.cmdRMAs.Click += new System.EventHandler(this.cmdRMAs_Click);
            // 
            // cmdPurchases
            // 
            this.cmdPurchases.Location = new System.Drawing.Point(11, 539);
            this.cmdPurchases.Name = "cmdPurchases";
            this.cmdPurchases.Size = new System.Drawing.Size(148, 22);
            this.cmdPurchases.TabIndex = 15;
            this.cmdPurchases.Text = "Purchases";
            this.cmdPurchases.UseVisualStyleBackColor = true;
            this.cmdPurchases.Click += new System.EventHandler(this.cmdPurchases_Click);
            // 
            // cmdInvoices
            // 
            this.cmdInvoices.Location = new System.Drawing.Point(11, 511);
            this.cmdInvoices.Name = "cmdInvoices";
            this.cmdInvoices.Size = new System.Drawing.Size(148, 22);
            this.cmdInvoices.TabIndex = 14;
            this.cmdInvoices.Text = "Invoices";
            this.cmdInvoices.UseVisualStyleBackColor = true;
            this.cmdInvoices.Click += new System.EventHandler(this.cmdInvoices_Click);
            // 
            // lblChecked
            // 
            this.lblChecked.Location = new System.Drawing.Point(9, 148);
            this.lblChecked.Name = "lblChecked";
            this.lblChecked.Size = new System.Drawing.Size(151, 17);
            this.lblChecked.TabIndex = 13;
            this.lblChecked.Text = "1,24 Selected";
            this.lblChecked.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmdFax
            // 
            this.cmdFax.Location = new System.Drawing.Point(7, 336);
            this.cmdFax.Name = "cmdFax";
            this.cmdFax.Size = new System.Drawing.Size(161, 33);
            this.cmdFax.TabIndex = 12;
            this.cmdFax.Text = "Fax Selected Orders";
            this.cmdFax.UseVisualStyleBackColor = true;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Location = new System.Drawing.Point(7, 297);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(161, 33);
            this.cmdPrint.TabIndex = 11;
            this.cmdPrint.Text = "Print Selected Orders";
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdPost
            // 
            this.cmdPost.Location = new System.Drawing.Point(6, 396);
            this.cmdPost.Name = "cmdPost";
            this.cmdPost.Size = new System.Drawing.Size(161, 64);
            this.cmdPost.TabIndex = 10;
            this.cmdPost.Text = "Post To Quickbooks >";
            this.cmdPost.UseVisualStyleBackColor = true;
            this.cmdPost.Click += new System.EventHandler(this.cmdPost_Click);
            // 
            // chkNotifyCustomer
            // 
            this.chkNotifyCustomer.AutoSize = true;
            this.chkNotifyCustomer.Location = new System.Drawing.Point(12, 274);
            this.chkNotifyCustomer.Name = "chkNotifyCustomer";
            this.chkNotifyCustomer.Size = new System.Drawing.Size(100, 17);
            this.chkNotifyCustomer.TabIndex = 9;
            this.chkNotifyCustomer.Text = "Notify Customer";
            this.chkNotifyCustomer.UseVisualStyleBackColor = true;
            // 
            // chkNotifyAgent
            // 
            this.chkNotifyAgent.AutoSize = true;
            this.chkNotifyAgent.Location = new System.Drawing.Point(12, 251);
            this.chkNotifyAgent.Name = "chkNotifyAgent";
            this.chkNotifyAgent.Size = new System.Drawing.Size(84, 17);
            this.chkNotifyAgent.TabIndex = 8;
            this.chkNotifyAgent.Text = "Notify Agent";
            this.chkNotifyAgent.UseVisualStyleBackColor = true;
            // 
            // chkPreview
            // 
            this.chkPreview.AutoSize = true;
            this.chkPreview.Checked = true;
            this.chkPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreview.Location = new System.Drawing.Point(12, 228);
            this.chkPreview.Name = "chkPreview";
            this.chkPreview.Size = new System.Drawing.Size(64, 17);
            this.chkPreview.TabIndex = 7;
            this.chkPreview.Text = "Preview";
            this.chkPreview.UseVisualStyleBackColor = true;
            // 
            // cmdCheckNone
            // 
            this.cmdCheckNone.Location = new System.Drawing.Point(87, 171);
            this.cmdCheckNone.Name = "cmdCheckNone";
            this.cmdCheckNone.Size = new System.Drawing.Size(80, 24);
            this.cmdCheckNone.TabIndex = 6;
            this.cmdCheckNone.Text = "Check None";
            this.cmdCheckNone.UseVisualStyleBackColor = true;
            this.cmdCheckNone.Click += new System.EventHandler(this.cmdCheckNone_Click);
            // 
            // cmdCheckAll
            // 
            this.cmdCheckAll.Location = new System.Drawing.Point(6, 171);
            this.cmdCheckAll.Name = "cmdCheckAll";
            this.cmdCheckAll.Size = new System.Drawing.Size(80, 24);
            this.cmdCheckAll.TabIndex = 5;
            this.cmdCheckAll.Text = "Check All";
            this.cmdCheckAll.UseVisualStyleBackColor = true;
            this.cmdCheckAll.Click += new System.EventHandler(this.cmdCheckAll_Click);
            // 
            // lblCount
            // 
            this.lblCount.Location = new System.Drawing.Point(9, 131);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(151, 17);
            this.lblCount.TabIndex = 4;
            this.lblCount.Text = "1,234 Documents";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(6, 95);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(161, 33);
            this.cmdRefresh.TabIndex = 3;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // dtCutoff
            // 
            this.dtCutoff.AllowClear = false;
            this.dtCutoff.BackColor = System.Drawing.Color.White;
            this.dtCutoff.Bold = false;
            this.dtCutoff.Caption = "Cutoff Date";
            this.dtCutoff.Changed = false;
            this.dtCutoff.Location = new System.Drawing.Point(7, 45);
            this.dtCutoff.Name = "dtCutoff";
            this.dtCutoff.Size = new System.Drawing.Size(155, 44);
            this.dtCutoff.SuppressEdit = false;
            this.dtCutoff.TabIndex = 2;
            this.dtCutoff.UseParentBackColor = true;
            this.dtCutoff.zz_GlobalColor = System.Drawing.Color.Black;
            this.dtCutoff.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dtCutoff.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.dtCutoff.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtCutoff.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.dtCutoff.zz_OriginalDesign = true;
            this.dtCutoff.zz_ShowNeedsSaveColor = true;
            this.dtCutoff.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.dtCutoff.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtCutoff.zz_UseGlobalColor = false;
            this.dtCutoff.zz_UseGlobalFont = false;
            // 
            // chkUnsent
            // 
            this.chkUnsent.AutoSize = true;
            this.chkUnsent.Checked = true;
            this.chkUnsent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUnsent.Location = new System.Drawing.Point(6, 19);
            this.chkUnsent.Name = "chkUnsent";
            this.chkUnsent.Size = new System.Drawing.Size(84, 17);
            this.chkUnsent.TabIndex = 1;
            this.chkUnsent.Text = "Unsent Only";
            this.chkUnsent.UseVisualStyleBackColor = true;
            // 
            // lv
            // 
            this.lv.CheckBoxes = true;
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lv.ContextMenuStrip = this.mnu;
            this.lv.FullRowSelect = true;
            this.lv.Location = new System.Drawing.Point(186, 10);
            this.lv.MultiSelect = false;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(440, 408);
            this.lv.TabIndex = 1;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
            this.lv.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_ItemChecked);
            this.lv.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
            this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Order #";
            this.columnHeader1.Width = 73;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Date";
            this.columnHeader2.Width = 76;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Company";
            this.columnHeader3.Width = 110;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Terms";
            this.columnHeader4.Width = 88;
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopies,
            this.viewToolStripMenuItem,
            this.mnuSend});
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(118, 70);
            this.mnu.Opening += new System.ComponentModel.CancelEventHandler(this.mnu_Opening);
            // 
            // mnuCopies
            // 
            this.mnuCopies.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.mnuEnterCopies});
            this.mnuCopies.Name = "mnuCopies";
            this.mnuCopies.Size = new System.Drawing.Size(117, 22);
            this.mnuCopies.Text = "&Copies";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(101, 22);
            this.toolStripMenuItem2.Text = "1";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(101, 22);
            this.toolStripMenuItem3.Text = "2";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(101, 22);
            this.toolStripMenuItem4.Text = "3";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(101, 22);
            this.toolStripMenuItem5.Text = "4";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(101, 22);
            this.toolStripMenuItem6.Text = "5";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // mnuEnterCopies
            // 
            this.mnuEnterCopies.Name = "mnuEnterCopies";
            this.mnuEnterCopies.Size = new System.Drawing.Size(101, 22);
            this.mnuEnterCopies.Text = "&Enter";
            this.mnuEnterCopies.Click += new System.EventHandler(this.mnuEnterCopies_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderToolStripMenuItem,
            this.companyToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // orderToolStripMenuItem
            // 
            this.orderToolStripMenuItem.Name = "orderToolStripMenuItem";
            this.orderToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.orderToolStripMenuItem.Text = "&Order";
            this.orderToolStripMenuItem.Click += new System.EventHandler(this.orderToolStripMenuItem_Click);
            // 
            // companyToolStripMenuItem
            // 
            this.companyToolStripMenuItem.Name = "companyToolStripMenuItem";
            this.companyToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.companyToolStripMenuItem.Text = "&Company";
            this.companyToolStripMenuItem.Click += new System.EventHandler(this.companyToolStripMenuItem_Click);
            // 
            // mnuSend
            // 
            this.mnuSend.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSendOrder,
            this.mnuSendCompany,
            this.mnuSendCustomer});
            this.mnuSend.Name = "mnuSend";
            this.mnuSend.Size = new System.Drawing.Size(117, 22);
            this.mnuSend.Text = "&Send";
            // 
            // mnuSendOrder
            // 
            this.mnuSendOrder.Name = "mnuSendOrder";
            this.mnuSendOrder.Size = new System.Drawing.Size(126, 22);
            this.mnuSendOrder.Text = "&Order";
            this.mnuSendOrder.Click += new System.EventHandler(this.mnuSendOrder_Click);
            // 
            // mnuSendCompany
            // 
            this.mnuSendCompany.Name = "mnuSendCompany";
            this.mnuSendCompany.Size = new System.Drawing.Size(126, 22);
            this.mnuSendCompany.Text = "&Company";
            this.mnuSendCompany.Click += new System.EventHandler(this.mnuSendCompany_Click);
            // 
            // mnuSendCustomer
            // 
            this.mnuSendCustomer.Name = "mnuSendCustomer";
            this.mnuSendCustomer.Size = new System.Drawing.Size(126, 22);
            this.mnuSendCustomer.Text = "C&ustomer";
            this.mnuSendCustomer.Click += new System.EventHandler(this.cmdSendCustomer_Click);
            // 
            // bg
            // 
            this.bg.WorkerReportsProgress = true;
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bg_ProgressChanged);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // QBPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lv);
            this.Controls.Add(this.gb);
            this.Name = "QBPost";
            this.Size = new System.Drawing.Size(653, 648);
            this.Resize += new System.EventHandler(this.QBPost_Resize);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.mnu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem mnuCopies;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem mnuEnterCopies;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSend;
        private System.Windows.Forms.ToolStripMenuItem mnuSendOrder;
        private System.Windows.Forms.ToolStripMenuItem mnuSendCompany;
        private System.Windows.Forms.ToolStripMenuItem mnuSendCustomer;
        private System.ComponentModel.BackgroundWorker bg;
        protected System.Windows.Forms.GroupBox gb;
        protected System.Windows.Forms.CheckBox chkUnsent;
        protected NewMethod.nEdit_Date dtCutoff;
        protected System.Windows.Forms.Button cmdRefresh;
        protected System.Windows.Forms.Label lblCount;
        protected System.Windows.Forms.Button cmdCheckNone;
        protected System.Windows.Forms.Button cmdCheckAll;
        protected System.Windows.Forms.Button cmdPost;
        protected System.Windows.Forms.CheckBox chkNotifyCustomer;
        protected System.Windows.Forms.CheckBox chkNotifyAgent;
        protected System.Windows.Forms.CheckBox chkPreview;
        protected System.Windows.Forms.Label lblChecked;
        protected System.Windows.Forms.Button cmdFax;
        protected System.Windows.Forms.Button cmdPrint;
        protected System.Windows.Forms.Button cmdVendorRMAs;
        protected System.Windows.Forms.Button cmdRMAs;
        protected System.Windows.Forms.Button cmdPurchases;
        protected System.Windows.Forms.Button cmdInvoices;
        protected NewMethod.nThrobber throb;
        protected System.Windows.Forms.Button cmdDate;
    }
}
