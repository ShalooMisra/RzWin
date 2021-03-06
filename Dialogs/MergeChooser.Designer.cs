namespace Rz5.Win.Dialogs
{
    partial class MergeChooser
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblOrder = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.optSales = new System.Windows.Forms.RadioButton();
            this.optPurchase = new System.Windows.Forms.RadioButton();
            this.optService = new System.Windows.Forms.RadioButton();
            this.optInvoice = new System.Windows.Forms.RadioButton();
            this.optRMA = new System.Windows.Forms.RadioButton();
            this.optVendRMA = new System.Windows.Forms.RadioButton();
            this.oFinder = new Rz5.Win.Controls.OrderFinder();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pContents.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(142, 0);
            this.cmdOK.Size = new System.Drawing.Size(842, 59);
            // 
            // pContents
            // 
            this.pContents.Controls.Add(this.lv);
            this.pContents.Controls.Add(this.oFinder);
            this.pContents.Controls.Add(this.optVendRMA);
            this.pContents.Controls.Add(this.optRMA);
            this.pContents.Controls.Add(this.optInvoice);
            this.pContents.Controls.Add(this.optService);
            this.pContents.Controls.Add(this.optPurchase);
            this.pContents.Controls.Add(this.optSales);
            this.pContents.Controls.Add(this.label1);
            this.pContents.Controls.Add(this.lblOrder);
            this.pContents.Location = new System.Drawing.Point(0, 0);
            this.pContents.Size = new System.Drawing.Size(984, 349);
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder.Location = new System.Drawing.Point(13, 9);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(277, 26);
            this.lblOrder.TabIndex = 0;
            this.lblOrder.Text = "Link To Sales Order 123123123";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "From:";
            // 
            // optSales
            // 
            this.optSales.AutoSize = true;
            this.optSales.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSales.Location = new System.Drawing.Point(81, 38);
            this.optSales.Name = "optSales";
            this.optSales.Size = new System.Drawing.Size(61, 23);
            this.optSales.TabIndex = 2;
            this.optSales.TabStop = true;
            this.optSales.Text = "Sales";
            this.optSales.UseVisualStyleBackColor = true;
            this.optSales.CheckedChanged += new System.EventHandler(this.optSales_CheckedChanged);
            // 
            // optPurchase
            // 
            this.optPurchase.AutoSize = true;
            this.optPurchase.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optPurchase.Location = new System.Drawing.Point(81, 57);
            this.optPurchase.Name = "optPurchase";
            this.optPurchase.Size = new System.Drawing.Size(86, 23);
            this.optPurchase.TabIndex = 3;
            this.optPurchase.TabStop = true;
            this.optPurchase.Text = "Purchase";
            this.optPurchase.UseVisualStyleBackColor = true;
            this.optPurchase.CheckedChanged += new System.EventHandler(this.optPurchase_CheckedChanged);
            // 
            // optService
            // 
            this.optService.AutoSize = true;
            this.optService.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optService.Location = new System.Drawing.Point(81, 77);
            this.optService.Name = "optService";
            this.optService.Size = new System.Drawing.Size(73, 23);
            this.optService.TabIndex = 4;
            this.optService.TabStop = true;
            this.optService.Text = "Service";
            this.optService.UseVisualStyleBackColor = true;
            this.optService.CheckedChanged += new System.EventHandler(this.optService_CheckedChanged);
            // 
            // optInvoice
            // 
            this.optInvoice.AutoSize = true;
            this.optInvoice.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optInvoice.Location = new System.Drawing.Point(81, 97);
            this.optInvoice.Name = "optInvoice";
            this.optInvoice.Size = new System.Drawing.Size(73, 23);
            this.optInvoice.TabIndex = 5;
            this.optInvoice.TabStop = true;
            this.optInvoice.Text = "Invoice";
            this.optInvoice.UseVisualStyleBackColor = true;
            this.optInvoice.CheckedChanged += new System.EventHandler(this.optInvoice_CheckedChanged);
            // 
            // optRMA
            // 
            this.optRMA.AutoSize = true;
            this.optRMA.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optRMA.Location = new System.Drawing.Point(81, 117);
            this.optRMA.Name = "optRMA";
            this.optRMA.Size = new System.Drawing.Size(58, 23);
            this.optRMA.TabIndex = 6;
            this.optRMA.TabStop = true;
            this.optRMA.Text = "RMA";
            this.optRMA.UseVisualStyleBackColor = true;
            this.optRMA.CheckedChanged += new System.EventHandler(this.optRMA_CheckedChanged);
            // 
            // optVendRMA
            // 
            this.optVendRMA.AutoSize = true;
            this.optVendRMA.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optVendRMA.Location = new System.Drawing.Point(81, 137);
            this.optVendRMA.Name = "optVendRMA";
            this.optVendRMA.Size = new System.Drawing.Size(107, 23);
            this.optVendRMA.TabIndex = 7;
            this.optVendRMA.TabStop = true;
            this.optVendRMA.Text = "Vendor RMA";
            this.optVendRMA.UseVisualStyleBackColor = true;
            this.optVendRMA.CheckedChanged += new System.EventHandler(this.optVendRMA_CheckedChanged);
            // 
            // oFinder
            // 
            this.oFinder.BackColor = System.Drawing.Color.White;
            this.oFinder.Location = new System.Drawing.Point(207, 38);
            this.oFinder.Name = "oFinder";
            this.oFinder.Size = new System.Drawing.Size(176, 122);
            this.oFinder.TabIndex = 8;
            this.oFinder.OrderFound += new System.EventHandler(this.oFinder_OrderFound);
            // 
            // lv
            // 
            this.lv.CheckBoxes = true;
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lv.FullRowSelect = true;
            this.lv.Location = new System.Drawing.Point(3, 173);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(978, 170);
            this.lv.TabIndex = 9;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lv_ItemCheck);
            this.lv.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Line";
            this.columnHeader1.Width = 58;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Part #";
            this.columnHeader2.Width = 172;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Quantity";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 83;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status";
            this.columnHeader4.Width = 95;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Sales #";
            this.columnHeader5.Width = 76;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Invoice #";
            this.columnHeader6.Width = 72;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Customer";
            this.columnHeader7.Width = 156;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "PO#";
            this.columnHeader8.Width = 84;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Vendor";
            this.columnHeader9.Width = 175;
            // 
            // MergeChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 412);
            this.Name = "MergeChooser";
            this.Text = "OrderLinkChooser";
            this.pContents.ResumeLayout(false);
            this.pContents.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton optVendRMA;
        private System.Windows.Forms.RadioButton optRMA;
        private System.Windows.Forms.RadioButton optInvoice;
        private System.Windows.Forms.RadioButton optService;
        private System.Windows.Forms.RadioButton optPurchase;
        private System.Windows.Forms.RadioButton optSales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOrder;
        private Controls.OrderFinder oFinder;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}