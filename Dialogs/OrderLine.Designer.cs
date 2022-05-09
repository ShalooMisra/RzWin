namespace Rz5.Win.Dialogs
{
    partial class OrderLine
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
            this.pSale = new Rz5.Win.Controls.OrderLinePanel();
            this.pService = new Rz5.Win.Controls.OrderLinePanel();
            this.pInvoice = new Rz5.Win.Controls.OrderLinePanel();
            this.pPurchase = new Rz5.Win.Controls.OrderLinePanel();
            this.pRMA = new Rz5.Win.Controls.OrderLinePanel();
            this.pVendRMA = new Rz5.Win.Controls.OrderLinePanel();
            this.pContents.SuspendLayout();
            this.SuspendLayout();
            // 
            // pContents
            // 
            this.pContents.Controls.Add(this.pVendRMA);
            this.pContents.Controls.Add(this.pRMA);
            this.pContents.Controls.Add(this.pPurchase);
            this.pContents.Controls.Add(this.pInvoice);
            this.pContents.Controls.Add(this.pService);
            this.pContents.Controls.Add(this.pSale);
            this.pContents.Location = new System.Drawing.Point(0, 0);
            this.pContents.Size = new System.Drawing.Size(696, 552);
            // 
            // pSale
            // 
            this.pSale.BackColor = System.Drawing.Color.White;
            this.pSale.Location = new System.Drawing.Point(96, 185);
            this.pSale.Name = "pSale";
            this.pSale.Size = new System.Drawing.Size(230, 170);
            this.pSale.TabIndex = 0;
            // 
            // pService
            // 
            this.pService.BackColor = System.Drawing.Color.White;
            this.pService.Location = new System.Drawing.Point(369, 185);
            this.pService.Name = "pService";
            this.pService.Size = new System.Drawing.Size(230, 170);
            this.pService.TabIndex = 1;
            // 
            // pInvoice
            // 
            this.pInvoice.BackColor = System.Drawing.Color.White;
            this.pInvoice.Location = new System.Drawing.Point(96, 361);
            this.pInvoice.Name = "pInvoice";
            this.pInvoice.Size = new System.Drawing.Size(230, 170);
            this.pInvoice.TabIndex = 2;
            // 
            // pPurchase
            // 
            this.pPurchase.BackColor = System.Drawing.Color.White;
            this.pPurchase.Location = new System.Drawing.Point(96, 12);
            this.pPurchase.Name = "pPurchase";
            this.pPurchase.Size = new System.Drawing.Size(230, 170);
            this.pPurchase.TabIndex = 3;
            // 
            // pRMA
            // 
            this.pRMA.BackColor = System.Drawing.Color.White;
            this.pRMA.Location = new System.Drawing.Point(369, 12);
            this.pRMA.Name = "pRMA";
            this.pRMA.Size = new System.Drawing.Size(230, 170);
            this.pRMA.TabIndex = 4;
            // 
            // pVendRMA
            // 
            this.pVendRMA.BackColor = System.Drawing.Color.White;
            this.pVendRMA.Location = new System.Drawing.Point(369, 361);
            this.pVendRMA.Name = "pVendRMA";
            this.pVendRMA.Size = new System.Drawing.Size(230, 170);
            this.pVendRMA.TabIndex = 5;
            // 
            // OrderLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 615);
            this.Name = "OrderLine";
            this.Text = "OrderLine";
            this.pContents.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.OrderLinePanel pVendRMA;
        private Controls.OrderLinePanel pRMA;
        private Controls.OrderLinePanel pPurchase;
        private Controls.OrderLinePanel pInvoice;
        private Controls.OrderLinePanel pService;
        private Controls.OrderLinePanel pSale;
    }
}