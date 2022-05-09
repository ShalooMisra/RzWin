namespace Rz5
{
    partial class view_PartCrossReference
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
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pOptions = new System.Windows.Forms.Panel();
            this.lblLowPurchase = new System.Windows.Forms.Label();
            this.lblAvgPurchase = new System.Windows.Forms.Label();
            this.lblLowSales = new System.Windows.Forms.Label();
            this.lblAvgSales = new System.Windows.Forms.Label();
            this.txtLowestSalesPrice = new System.Windows.Forms.TextBox();
            this.txtAvgSalesPrice = new System.Windows.Forms.TextBox();
            this.txtLowestPurchasePrice = new System.Windows.Forms.TextBox();
            this.txtAvgPurchasePrice = new System.Windows.Forms.TextBox();
            this.chkAvgPurchasePrice = new System.Windows.Forms.CheckBox();
            this.chkLowestPurchasePrice = new System.Windows.Forms.CheckBox();
            this.chkAvgSalesPrice = new System.Windows.Forms.CheckBox();
            this.chkLowestSalesPrice = new System.Windows.Forms.CheckBox();
            this.chkMaster = new System.Windows.Forms.CheckBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.chkService = new System.Windows.Forms.CheckBox();
            this.chkVRMA = new System.Windows.Forms.CheckBox();
            this.chkRMA = new System.Windows.Forms.CheckBox();
            this.chkPurchase = new System.Windows.Forms.CheckBox();
            this.chkInvoice = new System.Windows.Forms.CheckBox();
            this.chkSales = new System.Windows.Forms.CheckBox();
            this.chkQuotes = new System.Windows.Forms.CheckBox();
            this.chkBid = new System.Windows.Forms.CheckBox();
            this.chkReq = new System.Windows.Forms.CheckBox();
            this.chkExcess = new System.Windows.Forms.CheckBox();
            this.chkConsign = new System.Windows.Forms.CheckBox();
            this.chkStock = new System.Windows.Forms.CheckBox();
            this.ts = new System.Windows.Forms.TabControl();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pbBottom = new System.Windows.Forms.PictureBox();
            this.pbTop = new System.Windows.Forms.PictureBox();
            this.pOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).BeginInit();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(14, 17);
            this.lv.MultiSelect = false;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(475, 174);
            this.lv.TabIndex = 41;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Part Number";
            this.columnHeader1.Width = 353;
            // 
            // pOptions
            // 
            this.pOptions.BackColor = System.Drawing.Color.Gainsboro;
            this.pOptions.Controls.Add(this.lblLowPurchase);
            this.pOptions.Controls.Add(this.lblAvgPurchase);
            this.pOptions.Controls.Add(this.lblLowSales);
            this.pOptions.Controls.Add(this.lblAvgSales);
            this.pOptions.Controls.Add(this.txtLowestSalesPrice);
            this.pOptions.Controls.Add(this.txtAvgSalesPrice);
            this.pOptions.Controls.Add(this.txtLowestPurchasePrice);
            this.pOptions.Controls.Add(this.txtAvgPurchasePrice);
            this.pOptions.Controls.Add(this.chkAvgPurchasePrice);
            this.pOptions.Controls.Add(this.chkLowestPurchasePrice);
            this.pOptions.Controls.Add(this.chkAvgSalesPrice);
            this.pOptions.Controls.Add(this.chkLowestSalesPrice);
            this.pOptions.Controls.Add(this.chkMaster);
            this.pOptions.Controls.Add(this.cmdSearch);
            this.pOptions.Controls.Add(this.chkService);
            this.pOptions.Controls.Add(this.chkVRMA);
            this.pOptions.Controls.Add(this.chkRMA);
            this.pOptions.Controls.Add(this.chkPurchase);
            this.pOptions.Controls.Add(this.chkInvoice);
            this.pOptions.Controls.Add(this.chkSales);
            this.pOptions.Controls.Add(this.chkQuotes);
            this.pOptions.Controls.Add(this.chkBid);
            this.pOptions.Controls.Add(this.chkReq);
            this.pOptions.Controls.Add(this.chkExcess);
            this.pOptions.Controls.Add(this.chkConsign);
            this.pOptions.Controls.Add(this.chkStock);
            this.pOptions.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pOptions.Location = new System.Drawing.Point(14, 197);
            this.pOptions.Name = "pOptions";
            this.pOptions.Size = new System.Drawing.Size(475, 232);
            this.pOptions.TabIndex = 42;
            // 
            // lblLowPurchase
            // 
            this.lblLowPurchase.BackColor = System.Drawing.Color.White;
            this.lblLowPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowPurchase.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblLowPurchase.Location = new System.Drawing.Point(433, 139);
            this.lblLowPurchase.Name = "lblLowPurchase";
            this.lblLowPurchase.Size = new System.Drawing.Size(27, 20);
            this.lblLowPurchase.TabIndex = 38;
            this.lblLowPurchase.Text = ">=";
            this.lblLowPurchase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLowPurchase.Visible = false;
            // 
            // lblAvgPurchase
            // 
            this.lblAvgPurchase.BackColor = System.Drawing.Color.White;
            this.lblAvgPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgPurchase.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblAvgPurchase.Location = new System.Drawing.Point(433, 162);
            this.lblAvgPurchase.Name = "lblAvgPurchase";
            this.lblAvgPurchase.Size = new System.Drawing.Size(27, 20);
            this.lblAvgPurchase.TabIndex = 37;
            this.lblAvgPurchase.Text = ">=";
            this.lblAvgPurchase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAvgPurchase.Visible = false;
            // 
            // lblLowSales
            // 
            this.lblLowSales.BackColor = System.Drawing.Color.White;
            this.lblLowSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowSales.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblLowSales.Location = new System.Drawing.Point(434, 93);
            this.lblLowSales.Name = "lblLowSales";
            this.lblLowSales.Size = new System.Drawing.Size(27, 20);
            this.lblLowSales.TabIndex = 36;
            this.lblLowSales.Text = ">=";
            this.lblLowSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLowSales.Visible = false;
            // 
            // lblAvgSales
            // 
            this.lblAvgSales.BackColor = System.Drawing.Color.White;
            this.lblAvgSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgSales.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblAvgSales.Location = new System.Drawing.Point(433, 116);
            this.lblAvgSales.Name = "lblAvgSales";
            this.lblAvgSales.Size = new System.Drawing.Size(27, 20);
            this.lblAvgSales.TabIndex = 35;
            this.lblAvgSales.Text = ">=";
            this.lblAvgSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAvgSales.Visible = false;
            // 
            // txtLowestSalesPrice
            // 
            this.txtLowestSalesPrice.Enabled = false;
            this.txtLowestSalesPrice.Location = new System.Drawing.Point(397, 93);
            this.txtLowestSalesPrice.Name = "txtLowestSalesPrice";
            this.txtLowestSalesPrice.Size = new System.Drawing.Size(31, 20);
            this.txtLowestSalesPrice.TabIndex = 34;
            // 
            // txtAvgSalesPrice
            // 
            this.txtAvgSalesPrice.Enabled = false;
            this.txtAvgSalesPrice.Location = new System.Drawing.Point(396, 116);
            this.txtAvgSalesPrice.Name = "txtAvgSalesPrice";
            this.txtAvgSalesPrice.Size = new System.Drawing.Size(31, 20);
            this.txtAvgSalesPrice.TabIndex = 33;
            // 
            // txtLowestPurchasePrice
            // 
            this.txtLowestPurchasePrice.Enabled = false;
            this.txtLowestPurchasePrice.Location = new System.Drawing.Point(396, 139);
            this.txtLowestPurchasePrice.Name = "txtLowestPurchasePrice";
            this.txtLowestPurchasePrice.Size = new System.Drawing.Size(31, 20);
            this.txtLowestPurchasePrice.TabIndex = 32;
            // 
            // txtAvgPurchasePrice
            // 
            this.txtAvgPurchasePrice.Enabled = false;
            this.txtAvgPurchasePrice.Location = new System.Drawing.Point(396, 162);
            this.txtAvgPurchasePrice.Name = "txtAvgPurchasePrice";
            this.txtAvgPurchasePrice.Size = new System.Drawing.Size(31, 20);
            this.txtAvgPurchasePrice.TabIndex = 31;
            // 
            // chkAvgPurchasePrice
            // 
            this.chkAvgPurchasePrice.AutoSize = true;
            this.chkAvgPurchasePrice.Location = new System.Drawing.Point(16, 165);
            this.chkAvgPurchasePrice.Name = "chkAvgPurchasePrice";
            this.chkAvgPurchasePrice.Size = new System.Drawing.Size(363, 17);
            this.chkAvgPurchasePrice.TabIndex = 30;
            this.chkAvgPurchasePrice.Text = "Items With Prices Lower Than The Average Sales Price By At Least (%)";
            this.chkAvgPurchasePrice.UseVisualStyleBackColor = true;
            // 
            // chkLowestPurchasePrice
            // 
            this.chkLowestPurchasePrice.AutoSize = true;
            this.chkLowestPurchasePrice.Location = new System.Drawing.Point(16, 142);
            this.chkLowestPurchasePrice.Name = "chkLowestPurchasePrice";
            this.chkLowestPurchasePrice.Size = new System.Drawing.Size(376, 17);
            this.chkLowestPurchasePrice.TabIndex = 29;
            this.chkLowestPurchasePrice.Text = "Items With Prices Lower Than The Lowest Purchase Price By At Least (%)";
            this.chkLowestPurchasePrice.UseVisualStyleBackColor = true;
            // 
            // chkAvgSalesPrice
            // 
            this.chkAvgSalesPrice.AutoSize = true;
            this.chkAvgSalesPrice.Location = new System.Drawing.Point(16, 119);
            this.chkAvgSalesPrice.Name = "chkAvgSalesPrice";
            this.chkAvgSalesPrice.Size = new System.Drawing.Size(363, 17);
            this.chkAvgSalesPrice.TabIndex = 28;
            this.chkAvgSalesPrice.Text = "Items With Prices Lower Than The Average Sales Price By At Least (%)";
            this.chkAvgSalesPrice.UseVisualStyleBackColor = true;
            // 
            // chkLowestSalesPrice
            // 
            this.chkLowestSalesPrice.AutoSize = true;
            this.chkLowestSalesPrice.Location = new System.Drawing.Point(16, 96);
            this.chkLowestSalesPrice.Name = "chkLowestSalesPrice";
            this.chkLowestSalesPrice.Size = new System.Drawing.Size(357, 17);
            this.chkLowestSalesPrice.TabIndex = 27;
            this.chkLowestSalesPrice.Text = "Items With Prices Lower Than The Lowest Sales Price By At Least (%)";
            this.chkLowestSalesPrice.UseVisualStyleBackColor = true;
            // 
            // chkMaster
            // 
            this.chkMaster.AutoSize = true;
            this.chkMaster.Location = new System.Drawing.Point(16, 73);
            this.chkMaster.Name = "chkMaster";
            this.chkMaster.Size = new System.Drawing.Size(58, 17);
            this.chkMaster.TabIndex = 14;
            this.chkMaster.Text = "Master";
            this.chkMaster.UseVisualStyleBackColor = true;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearch.Location = new System.Drawing.Point(8, 188);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(351, 27);
            this.cmdSearch.TabIndex = 13;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // chkService
            // 
            this.chkService.AutoSize = true;
            this.chkService.Location = new System.Drawing.Point(298, 51);
            this.chkService.Name = "chkService";
            this.chkService.Size = new System.Drawing.Size(67, 17);
            this.chkService.TabIndex = 12;
            this.chkService.Text = "Services";
            this.chkService.UseVisualStyleBackColor = true;
            // 
            // chkVRMA
            // 
            this.chkVRMA.AutoSize = true;
            this.chkVRMA.Location = new System.Drawing.Point(298, 29);
            this.chkVRMA.Name = "chkVRMA";
            this.chkVRMA.Size = new System.Drawing.Size(61, 17);
            this.chkVRMA.TabIndex = 11;
            this.chkVRMA.Text = "vRMAs";
            this.chkVRMA.UseVisualStyleBackColor = true;
            // 
            // chkRMA
            // 
            this.chkRMA.AutoSize = true;
            this.chkRMA.Location = new System.Drawing.Point(298, 8);
            this.chkRMA.Name = "chkRMA";
            this.chkRMA.Size = new System.Drawing.Size(55, 17);
            this.chkRMA.TabIndex = 10;
            this.chkRMA.Text = "RMAs";
            this.chkRMA.UseVisualStyleBackColor = true;
            // 
            // chkPurchase
            // 
            this.chkPurchase.AutoSize = true;
            this.chkPurchase.Location = new System.Drawing.Point(201, 51);
            this.chkPurchase.Name = "chkPurchase";
            this.chkPurchase.Size = new System.Drawing.Size(76, 17);
            this.chkPurchase.TabIndex = 9;
            this.chkPurchase.Text = "Purchases";
            this.chkPurchase.UseVisualStyleBackColor = true;
            // 
            // chkInvoice
            // 
            this.chkInvoice.AutoSize = true;
            this.chkInvoice.Location = new System.Drawing.Point(201, 29);
            this.chkInvoice.Name = "chkInvoice";
            this.chkInvoice.Size = new System.Drawing.Size(66, 17);
            this.chkInvoice.TabIndex = 8;
            this.chkInvoice.Text = "Invoices";
            this.chkInvoice.UseVisualStyleBackColor = true;
            // 
            // chkSales
            // 
            this.chkSales.AutoSize = true;
            this.chkSales.Location = new System.Drawing.Point(201, 8);
            this.chkSales.Name = "chkSales";
            this.chkSales.Size = new System.Drawing.Size(52, 17);
            this.chkSales.TabIndex = 7;
            this.chkSales.Text = "Sales";
            this.chkSales.UseVisualStyleBackColor = true;
            // 
            // chkQuotes
            // 
            this.chkQuotes.AutoSize = true;
            this.chkQuotes.Location = new System.Drawing.Point(112, 51);
            this.chkQuotes.Name = "chkQuotes";
            this.chkQuotes.Size = new System.Drawing.Size(60, 17);
            this.chkQuotes.TabIndex = 6;
            this.chkQuotes.Text = "Quotes";
            this.chkQuotes.UseVisualStyleBackColor = true;
            // 
            // chkBid
            // 
            this.chkBid.AutoSize = true;
            this.chkBid.Location = new System.Drawing.Point(112, 29);
            this.chkBid.Name = "chkBid";
            this.chkBid.Size = new System.Drawing.Size(46, 17);
            this.chkBid.TabIndex = 5;
            this.chkBid.Text = "Bids";
            this.chkBid.UseVisualStyleBackColor = true;
            // 
            // chkReq
            // 
            this.chkReq.AutoSize = true;
            this.chkReq.Location = new System.Drawing.Point(112, 8);
            this.chkReq.Name = "chkReq";
            this.chkReq.Size = new System.Drawing.Size(51, 17);
            this.chkReq.TabIndex = 4;
            this.chkReq.Text = "Reqs";
            this.chkReq.UseVisualStyleBackColor = true;
            // 
            // chkExcess
            // 
            this.chkExcess.AutoSize = true;
            this.chkExcess.Location = new System.Drawing.Point(16, 51);
            this.chkExcess.Name = "chkExcess";
            this.chkExcess.Size = new System.Drawing.Size(60, 17);
            this.chkExcess.TabIndex = 3;
            this.chkExcess.Text = "Excess";
            this.chkExcess.UseVisualStyleBackColor = true;
            // 
            // chkConsign
            // 
            this.chkConsign.AutoSize = true;
            this.chkConsign.Location = new System.Drawing.Point(16, 29);
            this.chkConsign.Name = "chkConsign";
            this.chkConsign.Size = new System.Drawing.Size(64, 17);
            this.chkConsign.TabIndex = 2;
            this.chkConsign.Text = "Consign";
            this.chkConsign.UseVisualStyleBackColor = true;
            // 
            // chkStock
            // 
            this.chkStock.AutoSize = true;
            this.chkStock.Location = new System.Drawing.Point(16, 8);
            this.chkStock.Name = "chkStock";
            this.chkStock.Size = new System.Drawing.Size(54, 17);
            this.chkStock.TabIndex = 1;
            this.chkStock.Text = "Stock";
            this.chkStock.UseVisualStyleBackColor = true;
            // 
            // ts
            // 
            this.ts.Location = new System.Drawing.Point(495, 17);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(366, 412);
            this.ts.TabIndex = 43;
            // 
            // bgw
            // 
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // pbLeft
            // 
            this.pbLeft.BackColor = System.Drawing.Color.Black;
            this.pbLeft.Location = new System.Drawing.Point(14, 573);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(12, 12);
            this.pbLeft.TabIndex = 40;
            this.pbLeft.TabStop = false;
            // 
            // pbRight
            // 
            this.pbRight.BackColor = System.Drawing.Color.Black;
            this.pbRight.Location = new System.Drawing.Point(14, 555);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(12, 12);
            this.pbRight.TabIndex = 39;
            this.pbRight.TabStop = false;
            // 
            // pbBottom
            // 
            this.pbBottom.BackColor = System.Drawing.Color.Black;
            this.pbBottom.Location = new System.Drawing.Point(32, 555);
            this.pbBottom.Name = "pbBottom";
            this.pbBottom.Size = new System.Drawing.Size(12, 12);
            this.pbBottom.TabIndex = 38;
            this.pbBottom.TabStop = false;
            // 
            // pbTop
            // 
            this.pbTop.BackColor = System.Drawing.Color.Black;
            this.pbTop.Location = new System.Drawing.Point(32, 573);
            this.pbTop.Name = "pbTop";
            this.pbTop.Size = new System.Drawing.Size(12, 12);
            this.pbTop.TabIndex = 37;
            this.pbTop.TabStop = false;
            // 
            // view_PartCrossReference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ts);
            this.Controls.Add(this.pOptions);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.pbBottom);
            this.Controls.Add(this.pbTop);
            this.Name = "view_PartCrossReference";
            this.Size = new System.Drawing.Size(864, 449);
            this.Resize += new System.EventHandler(this.view_PartCrossReference_Resize);
            this.pOptions.ResumeLayout(false);
            this.pOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.PictureBox pbBottom;
        private System.Windows.Forms.PictureBox pbTop;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.ComponentModel.BackgroundWorker bgw;
        private System.Windows.Forms.CheckBox chkService;
        private System.Windows.Forms.CheckBox chkVRMA;
        private System.Windows.Forms.CheckBox chkRMA;
        private System.Windows.Forms.CheckBox chkPurchase;
        private System.Windows.Forms.CheckBox chkInvoice;
        private System.Windows.Forms.CheckBox chkSales;
        private System.Windows.Forms.CheckBox chkQuotes;
        private System.Windows.Forms.CheckBox chkBid;
        private System.Windows.Forms.CheckBox chkReq;
        private System.Windows.Forms.CheckBox chkExcess;
        private System.Windows.Forms.CheckBox chkConsign;
        private System.Windows.Forms.CheckBox chkStock;
        public System.Windows.Forms.ListView lv;
        public System.Windows.Forms.Panel pOptions;
        public System.Windows.Forms.TabControl ts;
        public System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.CheckBox chkMaster;
        private System.Windows.Forms.Label lblLowPurchase;
        private System.Windows.Forms.Label lblAvgPurchase;
        private System.Windows.Forms.Label lblLowSales;
        private System.Windows.Forms.Label lblAvgSales;
        private System.Windows.Forms.TextBox txtLowestSalesPrice;
        private System.Windows.Forms.TextBox txtAvgSalesPrice;
        private System.Windows.Forms.TextBox txtLowestPurchasePrice;
        private System.Windows.Forms.TextBox txtAvgPurchasePrice;
        private System.Windows.Forms.CheckBox chkAvgPurchasePrice;
        private System.Windows.Forms.CheckBox chkLowestPurchasePrice;
        private System.Windows.Forms.CheckBox chkAvgSalesPrice;
        private System.Windows.Forms.CheckBox chkLowestSalesPrice;
    }
}
