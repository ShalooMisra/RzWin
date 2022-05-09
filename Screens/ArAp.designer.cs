namespace Rz5
{
    partial class ArAp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArAp));
            this.gb = new System.Windows.Forms.GroupBox();
            this.pOrderOptions = new System.Windows.Forms.Panel();
            this.optLines = new System.Windows.Forms.RadioButton();
            this.optOrders = new System.Windows.Forms.RadioButton();
            this.compStub = new CompanyStub();
            this.optBoth = new System.Windows.Forms.RadioButton();
            this.optPayable = new System.Windows.Forms.RadioButton();
            this.optReceivable = new System.Windows.Forms.RadioButton();
            this.throb = new NewMethod.nThrobber();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.lv = new System.Windows.Forms.ListView();
            this.mnuCompany = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuViewOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMarkPastDue = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMarkProblemAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.gbTotals = new System.Windows.Forms.GroupBox();
            this.lblBalanceCap = new System.Windows.Forms.Label();
            this.lblAPCap = new System.Windows.Forms.Label();
            this.lblARCap = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblAP = new System.Windows.Forms.Label();
            this.lblAR = new System.Windows.Forms.Label();
            this.cmdExport = new System.Windows.Forms.Button();
            this.IMList = new System.Windows.Forms.ImageList(this.components);
            this.lvOrders = new NewMethod.nList();
            this.cmdExport2 = new System.Windows.Forms.Button();
            this.gb.SuspendLayout();
            this.pOrderOptions.SuspendLayout();
            this.mnuCompany.SuspendLayout();
            this.gbTotals.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.BackColor = System.Drawing.Color.White;
            this.gb.Controls.Add(this.pOrderOptions);
            this.gb.Controls.Add(this.compStub);
            this.gb.Controls.Add(this.optBoth);
            this.gb.Controls.Add(this.optPayable);
            this.gb.Controls.Add(this.optReceivable);
            this.gb.Controls.Add(this.throb);
            this.gb.Controls.Add(this.cmdRefresh);
            this.gb.Location = new System.Drawing.Point(5, 4);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(842, 70);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            this.gb.Text = "AR / AP";
            // 
            // pOrderOptions
            // 
            this.pOrderOptions.Controls.Add(this.optLines);
            this.pOrderOptions.Controls.Add(this.optOrders);
            this.pOrderOptions.Location = new System.Drawing.Point(294, 14);
            this.pOrderOptions.Name = "pOrderOptions";
            this.pOrderOptions.Size = new System.Drawing.Size(98, 46);
            this.pOrderOptions.TabIndex = 6;
            // 
            // optLines
            // 
            this.optLines.AutoSize = true;
            this.optLines.Location = new System.Drawing.Point(17, 20);
            this.optLines.Name = "optLines";
            this.optLines.Size = new System.Drawing.Size(73, 17);
            this.optLines.TabIndex = 1;
            this.optLines.Text = "Line Items";
            this.optLines.UseVisualStyleBackColor = true;
            // 
            // optOrders
            // 
            this.optOrders.AutoSize = true;
            this.optOrders.Checked = true;
            this.optOrders.Location = new System.Drawing.Point(17, 5);
            this.optOrders.Name = "optOrders";
            this.optOrders.Size = new System.Drawing.Size(56, 17);
            this.optOrders.TabIndex = 0;
            this.optOrders.TabStop = true;
            this.optOrders.Text = "Orders";
            this.optOrders.UseVisualStyleBackColor = true;
            // 
            // compStub
            // 
            this.compStub.Caption = "Select Company Below";
            this.compStub.Location = new System.Drawing.Point(409, 13);
            this.compStub.Name = "compStub";
            this.compStub.Size = new System.Drawing.Size(334, 51);
            this.compStub.TabIndex = 5;
            // 
            // optBoth
            // 
            this.optBoth.AutoSize = true;
            this.optBoth.Location = new System.Drawing.Point(127, 47);
            this.optBoth.Name = "optBoth";
            this.optBoth.Size = new System.Drawing.Size(47, 17);
            this.optBoth.TabIndex = 4;
            this.optBoth.Text = "Both";
            this.optBoth.UseVisualStyleBackColor = true;
            // 
            // optPayable
            // 
            this.optPayable.AutoSize = true;
            this.optPayable.Location = new System.Drawing.Point(127, 29);
            this.optPayable.Name = "optPayable";
            this.optPayable.Size = new System.Drawing.Size(111, 17);
            this.optPayable.TabIndex = 3;
            this.optPayable.Text = "Accounts Payable";
            this.optPayable.UseVisualStyleBackColor = true;
            // 
            // optReceivable
            // 
            this.optReceivable.AutoSize = true;
            this.optReceivable.Checked = true;
            this.optReceivable.Location = new System.Drawing.Point(127, 11);
            this.optReceivable.Name = "optReceivable";
            this.optReceivable.Size = new System.Drawing.Size(127, 17);
            this.optReceivable.TabIndex = 2;
            this.optReceivable.TabStop = true;
            this.optReceivable.Text = "Accounts Receivable";
            this.optReceivable.UseVisualStyleBackColor = true;
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.Blue;
            this.throb.Location = new System.Drawing.Point(86, 29);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(30, 26);
            this.throb.TabIndex = 1;
            this.throb.UseParentBackColor = false;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(9, 17);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(71, 47);
            this.cmdRefresh.TabIndex = 0;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // lv
            // 
            this.lv.ContextMenuStrip = this.mnuCompany;
            this.lv.FullRowSelect = true;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(5, 84);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(409, 295);
            this.lv.TabIndex = 1;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.Click += new System.EventHandler(this.lv_Click);
            this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
            this.lv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lv_MouseDown);
            // 
            // mnuCompany
            // 
            this.mnuCompany.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewOrders,
            this.toolStripSeparator1,
            this.mnuMarkPastDue,
            this.mnuMarkProblemAccount});
            this.mnuCompany.Name = "mnuCompany";
            this.mnuCompany.Size = new System.Drawing.Size(221, 76);
            // 
            // mnuViewOrders
            // 
            this.mnuViewOrders.Name = "mnuViewOrders";
            this.mnuViewOrders.Size = new System.Drawing.Size(220, 22);
            this.mnuViewOrders.Text = "View Orders";
            this.mnuViewOrders.Click += new System.EventHandler(this.mnuViewOrders_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(217, 6);
            // 
            // mnuMarkPastDue
            // 
            this.mnuMarkPastDue.Name = "mnuMarkPastDue";
            this.mnuMarkPastDue.Size = new System.Drawing.Size(220, 22);
            this.mnuMarkPastDue.Text = "&Mark as Past Due";
            // 
            // mnuMarkProblemAccount
            // 
            this.mnuMarkProblemAccount.Name = "mnuMarkProblemAccount";
            this.mnuMarkProblemAccount.Size = new System.Drawing.Size(220, 22);
            this.mnuMarkProblemAccount.Text = "Mark as a Problem Account";
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // gbTotals
            // 
            this.gbTotals.Controls.Add(this.lblBalanceCap);
            this.gbTotals.Controls.Add(this.lblAPCap);
            this.gbTotals.Controls.Add(this.lblARCap);
            this.gbTotals.Controls.Add(this.lblBalance);
            this.gbTotals.Controls.Add(this.lblAP);
            this.gbTotals.Controls.Add(this.lblAR);
            this.gbTotals.Location = new System.Drawing.Point(6, 427);
            this.gbTotals.Name = "gbTotals";
            this.gbTotals.Size = new System.Drawing.Size(668, 111);
            this.gbTotals.TabIndex = 3;
            this.gbTotals.TabStop = false;
            // 
            // lblBalanceCap
            // 
            this.lblBalanceCap.AutoSize = true;
            this.lblBalanceCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceCap.Location = new System.Drawing.Point(15, 78);
            this.lblBalanceCap.Name = "lblBalanceCap";
            this.lblBalanceCap.Size = new System.Drawing.Size(54, 20);
            this.lblBalanceCap.TabIndex = 5;
            this.lblBalanceCap.Text = "Total:";
            // 
            // lblAPCap
            // 
            this.lblAPCap.AutoSize = true;
            this.lblAPCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAPCap.Location = new System.Drawing.Point(15, 45);
            this.lblAPCap.Name = "lblAPCap";
            this.lblAPCap.Size = new System.Drawing.Size(140, 20);
            this.lblAPCap.TabIndex = 4;
            this.lblAPCap.Text = "Accounts Payable:";
            // 
            // lblARCap
            // 
            this.lblARCap.AutoSize = true;
            this.lblARCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblARCap.Location = new System.Drawing.Point(13, 16);
            this.lblARCap.Name = "lblARCap";
            this.lblARCap.Size = new System.Drawing.Size(162, 20);
            this.lblARCap.TabIndex = 3;
            this.lblARCap.Text = "Accounts Receivable:";
            // 
            // lblBalance
            // 
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(184, 78);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(194, 21);
            this.lblBalance.TabIndex = 2;
            this.lblBalance.Text = "<balance>";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAP
            // 
            this.lblAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAP.Location = new System.Drawing.Point(184, 45);
            this.lblAP.Name = "lblAP";
            this.lblAP.Size = new System.Drawing.Size(194, 21);
            this.lblAP.TabIndex = 1;
            this.lblAP.Text = "<ap>";
            this.lblAP.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAR
            // 
            this.lblAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAR.Location = new System.Drawing.Point(184, 16);
            this.lblAR.Name = "lblAR";
            this.lblAR.Size = new System.Drawing.Size(194, 21);
            this.lblAR.TabIndex = 0;
            this.lblAR.Text = "<ar>";
            this.lblAR.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmdExport
            // 
            this.cmdExport.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdExport.ImageKey = "excel";
            this.cmdExport.ImageList = this.IMList;
            this.cmdExport.Location = new System.Drawing.Point(6, 389);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(408, 32);
            this.cmdExport.TabIndex = 6;
            this.cmdExport.Text = "Export Above List To Excel";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // IMList
            // 
            this.IMList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IMList.ImageStream")));
            this.IMList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.IMList.Images.SetKeyName(0, "excel");
            // 
            // lvOrders
            // 
            this.lvOrders.AddCaption = "Add New";
            this.lvOrders.AllowActions = true;
            this.lvOrders.AllowAdd = false;
            this.lvOrders.AllowDelete = true;
            this.lvOrders.AllowDeleteAlways = false;
            this.lvOrders.AllowDrop = true;
            this.lvOrders.AlternateConnection = null;
            this.lvOrders.Caption = "";
            this.lvOrders.CurrentTemplate = null;
            this.lvOrders.ExtraClassInfo = "";
            this.lvOrders.Location = new System.Drawing.Point(420, 80);
            this.lvOrders.MultiSelect = true;
            this.lvOrders.Name = "lvOrders";
            this.lvOrders.Size = new System.Drawing.Size(313, 299);
            this.lvOrders.SuppressSelectionChanged = false;
            this.lvOrders.TabIndex = 4;
            this.lvOrders.zz_OpenColumnMenu = false;
            this.lvOrders.zz_ShowAutoRefresh = true;
            this.lvOrders.zz_ShowUnlimited = true;
            // 
            // cmdExport2
            // 
            this.cmdExport2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExport2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdExport2.ImageKey = "excel";
            this.cmdExport2.ImageList = this.IMList;
            this.cmdExport2.Location = new System.Drawing.Point(420, 389);
            this.cmdExport2.Name = "cmdExport2";
            this.cmdExport2.Size = new System.Drawing.Size(313, 32);
            this.cmdExport2.TabIndex = 7;
            this.cmdExport2.Text = "Export Above List To Excel";
            this.cmdExport2.UseVisualStyleBackColor = true;
            this.cmdExport2.Click += new System.EventHandler(this.cmdExport2_Click);
            // 
            // ArAp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmdExport2);
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.lvOrders);
            this.Controls.Add(this.gbTotals);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.gb);
            this.Name = "ArAp";
            this.Size = new System.Drawing.Size(850, 550);
            this.Resize += new System.EventHandler(this.ArAp_Resize);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.pOrderOptions.ResumeLayout(false);
            this.pOrderOptions.PerformLayout();
            this.mnuCompany.ResumeLayout(false);
            this.gbTotals.ResumeLayout(false);
            this.gbTotals.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem mnuMarkPastDue;
        private System.Windows.Forms.ToolStripMenuItem mnuMarkProblemAccount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuViewOrders;
        public System.Windows.Forms.GroupBox gb;
        public NewMethod.nThrobber throb;
        public System.Windows.Forms.Button cmdRefresh;
        public System.Windows.Forms.ListView lv;
        public System.ComponentModel.BackgroundWorker bg;
        public System.Windows.Forms.ContextMenuStrip mnuCompany;
        public System.Windows.Forms.GroupBox gbTotals;
        public NewMethod.nList lvOrders;
        public System.Windows.Forms.Label lblBalanceCap;
        public System.Windows.Forms.Label lblAPCap;
        public System.Windows.Forms.Label lblARCap;
        public System.Windows.Forms.Label lblBalance;
        public System.Windows.Forms.Label lblAP;
        public System.Windows.Forms.Label lblAR;
        public System.Windows.Forms.Button cmdExport;
        public System.Windows.Forms.RadioButton optBoth;
        public System.Windows.Forms.RadioButton optPayable;
        public System.Windows.Forms.RadioButton optReceivable;
        public System.Windows.Forms.ImageList IMList;
        public System.Windows.Forms.Button cmdExport2;
        public CompanyStub compStub;
        public System.Windows.Forms.Panel pOrderOptions;
        public System.Windows.Forms.RadioButton optOrders;
        public System.Windows.Forms.RadioButton optLines;


    }
}
