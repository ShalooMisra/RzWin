namespace Rz5.OrderTreeComponents
{
    partial class OrderList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderList));
            this.chkShowOrders = new System.Windows.Forms.CheckBox();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.lv = new NewMethod.nList();
            this.bVendRMA = new OrderButton();
            this.bRMA = new OrderButton();
            this.bInvoice = new OrderButton();
            this.bPurchase = new OrderButton();
            this.bService = new OrderButton();
            this.bSales = new OrderButton();
            this.bRFQ = new OrderButton();
            this.bQuote = new OrderButton();
            this.SuspendLayout();
            // 
            // chkShowOrders
            // 
            this.chkShowOrders.AutoSize = true;
            this.chkShowOrders.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowOrders.Location = new System.Drawing.Point(930, 3);
            this.chkShowOrders.Name = "chkShowOrders";
            this.chkShowOrders.Size = new System.Drawing.Size(120, 17);
            this.chkShowOrders.TabIndex = 0;
            this.chkShowOrders.Text = "Show / Hide Orders";
            this.chkShowOrders.UseVisualStyleBackColor = true;
            this.chkShowOrders.CheckedChanged += new System.EventHandler(this.chkShowOrders_CheckedChanged);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Magenta;
            this.il.Images.SetKeyName(0, "ordhed_vendrma");
            this.il.Images.SetKeyName(1, "ordhed_invoice");
            this.il.Images.SetKeyName(2, "ordhed_purchase");
            this.il.Images.SetKeyName(3, "ordhed_quote");
            this.il.Images.SetKeyName(4, "ordhed_rfq");
            this.il.Images.SetKeyName(5, "ordhed_rma");
            this.il.Images.SetKeyName(6, "ordhed_sales");
            this.il.Images.SetKeyName(7, "ordhed_service");
            // 
            // lv
            // 
            this.lv.AddCaption = "Add New";
            this.lv.AllowAdd = false;
            this.lv.AllowDelete = true;
            this.lv.Caption = "";
            this.lv.ExtraClassInfo = "";
            this.lv.Location = new System.Drawing.Point(3, 88);
            this.lv.MultiSelect = true;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(417, 197);
            this.lv.SuppressSelectionChanged = false;
            this.lv.TabIndex = 9;
            this.lv.AboutToThrow += new Core.ShowHandler(this.lv_AboutToThrow);
            // 
            // bVendRMA
            // 
            this.bVendRMA.BackColor = System.Drawing.Color.White;
            this.bVendRMA.Location = new System.Drawing.Point(477, 43);
            this.bVendRMA.Name = "bVendRMA";
            this.bVendRMA.Size = new System.Drawing.Size(152, 42);
            this.bVendRMA.TabIndex = 8;
            this.bVendRMA.ButtonClicked += new OrderButtonHandler(this.b_ButtonClicked);
            // 
            // bRMA
            // 
            this.bRMA.BackColor = System.Drawing.Color.White;
            this.bRMA.Location = new System.Drawing.Point(477, 0);
            this.bRMA.Name = "bRMA";
            this.bRMA.Size = new System.Drawing.Size(152, 42);
            this.bRMA.TabIndex = 7;
            this.bRMA.ButtonClicked += new OrderButtonHandler(this.b_ButtonClicked);
            // 
            // bInvoice
            // 
            this.bInvoice.BackColor = System.Drawing.Color.White;
            this.bInvoice.Location = new System.Drawing.Point(319, 43);
            this.bInvoice.Name = "bInvoice";
            this.bInvoice.Size = new System.Drawing.Size(152, 42);
            this.bInvoice.TabIndex = 6;
            this.bInvoice.ButtonClicked += new OrderButtonHandler(this.b_ButtonClicked);
            // 
            // bPurchase
            // 
            this.bPurchase.BackColor = System.Drawing.Color.White;
            this.bPurchase.Location = new System.Drawing.Point(319, 0);
            this.bPurchase.Name = "bPurchase";
            this.bPurchase.Size = new System.Drawing.Size(152, 42);
            this.bPurchase.TabIndex = 5;
            this.bPurchase.ButtonClicked += new OrderButtonHandler(this.b_ButtonClicked);
            // 
            // bService
            // 
            this.bService.BackColor = System.Drawing.Color.White;
            this.bService.Location = new System.Drawing.Point(161, 0);
            this.bService.Name = "bService";
            this.bService.Size = new System.Drawing.Size(152, 42);
            this.bService.TabIndex = 4;
            this.bService.ButtonClicked += new OrderButtonHandler(this.b_ButtonClicked);
            // 
            // bSales
            // 
            this.bSales.BackColor = System.Drawing.Color.White;
            this.bSales.Location = new System.Drawing.Point(161, 43);
            this.bSales.Name = "bSales";
            this.bSales.Size = new System.Drawing.Size(152, 42);
            this.bSales.TabIndex = 3;
            this.bSales.ButtonClicked += new OrderButtonHandler(this.b_ButtonClicked);
            // 
            // bRFQ
            // 
            this.bRFQ.BackColor = System.Drawing.Color.White;
            this.bRFQ.Location = new System.Drawing.Point(3, 0);
            this.bRFQ.Name = "bRFQ";
            this.bRFQ.Size = new System.Drawing.Size(152, 42);
            this.bRFQ.TabIndex = 2;
            this.bRFQ.ButtonClicked += new OrderButtonHandler(this.b_ButtonClicked);
            // 
            // bQuote
            // 
            this.bQuote.BackColor = System.Drawing.Color.White;
            this.bQuote.Location = new System.Drawing.Point(3, 43);
            this.bQuote.Name = "bQuote";
            this.bQuote.Size = new System.Drawing.Size(152, 42);
            this.bQuote.TabIndex = 1;
            this.bQuote.ButtonClicked += new OrderButtonHandler(this.b_ButtonClicked);
            // 
            // OrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lv);
            this.Controls.Add(this.bVendRMA);
            this.Controls.Add(this.bRMA);
            this.Controls.Add(this.bInvoice);
            this.Controls.Add(this.bPurchase);
            this.Controls.Add(this.bService);
            this.Controls.Add(this.bSales);
            this.Controls.Add(this.bRFQ);
            this.Controls.Add(this.bQuote);
            this.Controls.Add(this.chkShowOrders);
            this.Name = "OrderList";
            this.Size = new System.Drawing.Size(1053, 347);
            this.Resize += new System.EventHandler(this.OrderList_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkShowOrders;
        private OrderButton bQuote;
        private OrderButton bRFQ;
        private OrderButton bSales;
        private OrderButton bService;
        private OrderButton bPurchase;
        private OrderButton bInvoice;
        private OrderButton bRMA;
        private OrderButton bVendRMA;
        private System.Windows.Forms.ImageList il;
        private NewMethod.nList lv;
    }
}
