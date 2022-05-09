namespace Rz5
{
    partial class ImportFromQBs
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
            this.cmdImportPayChargeToQBs = new System.Windows.Forms.Button();
            this.cmcQBCompanyImport = new System.Windows.Forms.Button();
            this.cmcQBSalesImport = new System.Windows.Forms.Button();
            this.cmcQBPurchaseImport = new System.Windows.Forms.Button();
            this.cmdQBInvoiceImport = new System.Windows.Forms.Button();
            this.cmdTestQB = new System.Windows.Forms.Button();
            this.ctlQBDate = new NewMethod.nEdit_Date();
            this.bgImport = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdImportAllOrders = new System.Windows.Forms.Button();
            this.chkRemoveOrders = new System.Windows.Forms.CheckBox();
            this.cmdImportBills = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdImportPayChargeToQBs
            // 
            this.cmdImportPayChargeToQBs.BackColor = System.Drawing.SystemColors.Control;
            this.cmdImportPayChargeToQBs.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImportPayChargeToQBs.Location = new System.Drawing.Point(22, 309);
            this.cmdImportPayChargeToQBs.Name = "cmdImportPayChargeToQBs";
            this.cmdImportPayChargeToQBs.Size = new System.Drawing.Size(527, 37);
            this.cmdImportPayChargeToQBs.TabIndex = 90;
            this.cmdImportPayChargeToQBs.Text = "Import Payment And Charge Info To QBs";
            this.cmdImportPayChargeToQBs.UseVisualStyleBackColor = false;
            this.cmdImportPayChargeToQBs.Click += new System.EventHandler(this.cmdImportPayChargeToQBs_Click);
            // 
            // cmcQBCompanyImport
            // 
            this.cmcQBCompanyImport.BackColor = System.Drawing.SystemColors.Control;
            this.cmcQBCompanyImport.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmcQBCompanyImport.Location = new System.Drawing.Point(22, 91);
            this.cmcQBCompanyImport.Name = "cmcQBCompanyImport";
            this.cmcQBCompanyImport.Size = new System.Drawing.Size(527, 37);
            this.cmcQBCompanyImport.TabIndex = 84;
            this.cmcQBCompanyImport.Text = "Import Companies From QBs";
            this.cmcQBCompanyImport.UseVisualStyleBackColor = false;
            this.cmcQBCompanyImport.Click += new System.EventHandler(this.cmcQBCompanyImport_Click);
            // 
            // cmcQBSalesImport
            // 
            this.cmcQBSalesImport.BackColor = System.Drawing.SystemColors.Control;
            this.cmcQBSalesImport.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmcQBSalesImport.Location = new System.Drawing.Point(22, 266);
            this.cmcQBSalesImport.Name = "cmcQBSalesImport";
            this.cmcQBSalesImport.Size = new System.Drawing.Size(527, 37);
            this.cmcQBSalesImport.TabIndex = 85;
            this.cmcQBSalesImport.Text = "Import Sales Orders From QBs";
            this.cmcQBSalesImport.UseVisualStyleBackColor = false;
            this.cmcQBSalesImport.Click += new System.EventHandler(this.cmcQBSalesImport_Click);
            // 
            // cmcQBPurchaseImport
            // 
            this.cmcQBPurchaseImport.BackColor = System.Drawing.SystemColors.Control;
            this.cmcQBPurchaseImport.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmcQBPurchaseImport.Location = new System.Drawing.Point(22, 179);
            this.cmcQBPurchaseImport.Name = "cmcQBPurchaseImport";
            this.cmcQBPurchaseImport.Size = new System.Drawing.Size(527, 36);
            this.cmcQBPurchaseImport.TabIndex = 86;
            this.cmcQBPurchaseImport.Text = "Import POs From QBs";
            this.cmcQBPurchaseImport.UseVisualStyleBackColor = false;
            this.cmcQBPurchaseImport.Click += new System.EventHandler(this.cmcQBPurchaseImport_Click);
            // 
            // cmdQBInvoiceImport
            // 
            this.cmdQBInvoiceImport.BackColor = System.Drawing.SystemColors.Control;
            this.cmdQBInvoiceImport.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdQBInvoiceImport.Location = new System.Drawing.Point(22, 224);
            this.cmdQBInvoiceImport.Name = "cmdQBInvoiceImport";
            this.cmdQBInvoiceImport.Size = new System.Drawing.Size(527, 36);
            this.cmdQBInvoiceImport.TabIndex = 87;
            this.cmdQBInvoiceImport.Text = "Import Invoices From QBs";
            this.cmdQBInvoiceImport.UseVisualStyleBackColor = false;
            this.cmdQBInvoiceImport.Click += new System.EventHandler(this.cmdQBInvoiceImport_Click);
            // 
            // cmdTestQB
            // 
            this.cmdTestQB.BackColor = System.Drawing.SystemColors.Control;
            this.cmdTestQB.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdTestQB.ForeColor = System.Drawing.Color.Maroon;
            this.cmdTestQB.Location = new System.Drawing.Point(22, 395);
            this.cmdTestQB.Name = "cmdTestQB";
            this.cmdTestQB.Size = new System.Drawing.Size(527, 37);
            this.cmdTestQB.TabIndex = 88;
            this.cmdTestQB.Text = "Test QB Connection";
            this.cmdTestQB.UseVisualStyleBackColor = false;
            this.cmdTestQB.Click += new System.EventHandler(this.cmdTestQB_Click);
            // 
            // ctlQBDate
            // 
            this.ctlQBDate.AllowClear = false;
            this.ctlQBDate.BackColor = System.Drawing.Color.White;
            this.ctlQBDate.Bold = false;
            this.ctlQBDate.Caption = "Cutoff Date";
            this.ctlQBDate.Changed = false;
            this.ctlQBDate.Location = new System.Drawing.Point(22, 30);
            this.ctlQBDate.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ctlQBDate.Name = "ctlQBDate";
            this.ctlQBDate.Size = new System.Drawing.Size(527, 53);
            this.ctlQBDate.SuppressEdit = false;
            this.ctlQBDate.TabIndex = 89;
            this.ctlQBDate.UseParentBackColor = false;
            this.ctlQBDate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlQBDate.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlQBDate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlQBDate.zz_LabelFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlQBDate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopCenter;
            this.ctlQBDate.zz_OriginalDesign = false;
            this.ctlQBDate.zz_ShowNeedsSaveColor = false;
            this.ctlQBDate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlQBDate.zz_TextFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlQBDate.zz_UseGlobalColor = false;
            this.ctlQBDate.zz_UseGlobalFont = false;
            // 
            // bgImport
            // 
            this.bgImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgImport_DoWork);
            this.bgImport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgImport_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.cmdImportBills);
            this.groupBox1.Controls.Add(this.cmdImportAllOrders);
            this.groupBox1.Controls.Add(this.chkRemoveOrders);
            this.groupBox1.Controls.Add(this.ctlQBDate);
            this.groupBox1.Controls.Add(this.cmdImportPayChargeToQBs);
            this.groupBox1.Controls.Add(this.cmdTestQB);
            this.groupBox1.Controls.Add(this.cmcQBCompanyImport);
            this.groupBox1.Controls.Add(this.cmdQBInvoiceImport);
            this.groupBox1.Controls.Add(this.cmcQBSalesImport);
            this.groupBox1.Controls.Add(this.cmcQBPurchaseImport);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(22, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 444);
            this.groupBox1.TabIndex = 91;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "QuickBooks Imports";
            // 
            // cmdImportAllOrders
            // 
            this.cmdImportAllOrders.BackColor = System.Drawing.SystemColors.Control;
            this.cmdImportAllOrders.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImportAllOrders.ForeColor = System.Drawing.Color.Blue;
            this.cmdImportAllOrders.Location = new System.Drawing.Point(22, 134);
            this.cmdImportAllOrders.Name = "cmdImportAllOrders";
            this.cmdImportAllOrders.Size = new System.Drawing.Size(527, 37);
            this.cmdImportAllOrders.TabIndex = 92;
            this.cmdImportAllOrders.Text = "Import Sales/Purchases/Invoices";
            this.cmdImportAllOrders.UseVisualStyleBackColor = false;
            this.cmdImportAllOrders.Click += new System.EventHandler(this.cmdImportAllOrders_Click);
            // 
            // chkRemoveOrders
            // 
            this.chkRemoveOrders.AutoSize = true;
            this.chkRemoveOrders.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRemoveOrders.Location = new System.Drawing.Point(391, 16);
            this.chkRemoveOrders.Name = "chkRemoveOrders";
            this.chkRemoveOrders.Size = new System.Drawing.Size(158, 26);
            this.chkRemoveOrders.TabIndex = 91;
            this.chkRemoveOrders.Text = "Remove Orders";
            this.chkRemoveOrders.UseVisualStyleBackColor = true;
            // 
            // cmdImportBills
            // 
            this.cmdImportBills.BackColor = System.Drawing.SystemColors.Control;
            this.cmdImportBills.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImportBills.Location = new System.Drawing.Point(22, 353);
            this.cmdImportBills.Name = "cmdImportBills";
            this.cmdImportBills.Size = new System.Drawing.Size(527, 36);
            this.cmdImportBills.TabIndex = 93;
            this.cmdImportBills.Text = "Import Bills From QBs";
            this.cmdImportBills.UseVisualStyleBackColor = false;
            this.cmdImportBills.Click += new System.EventHandler(this.cmdImportBills_Click);
            // 
            // ImportFromQBs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ImportFromQBs";
            this.Size = new System.Drawing.Size(695, 505);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdImportPayChargeToQBs;
        private System.Windows.Forms.Button cmcQBCompanyImport;
        private System.Windows.Forms.Button cmcQBSalesImport;
        private System.Windows.Forms.Button cmcQBPurchaseImport;
        private System.Windows.Forms.Button cmdQBInvoiceImport;
        private System.Windows.Forms.Button cmdTestQB;
        private NewMethod.nEdit_Date ctlQBDate;
        private System.ComponentModel.BackgroundWorker bgImport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkRemoveOrders;
        private System.Windows.Forms.Button cmdImportAllOrders;
        private System.Windows.Forms.Button cmdImportBills;
    }
}
