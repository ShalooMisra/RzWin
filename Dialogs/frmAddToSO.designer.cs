namespace Rz5
{
    partial class frmAddToSO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddToSO));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdNewSalesOrder = new System.Windows.Forms.Button();
            this.cmdFill = new System.Windows.Forms.Button();
            this.cmdAddTo = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cboOrders = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Use this option to create a new sales order for this item.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select an existing sales order for this item.";
            // 
            // cmdNewSalesOrder
            // 
            this.cmdNewSalesOrder.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewSalesOrder.Location = new System.Drawing.Point(185, 9);
            this.cmdNewSalesOrder.Name = "cmdNewSalesOrder";
            this.cmdNewSalesOrder.Size = new System.Drawing.Size(196, 30);
            this.cmdNewSalesOrder.TabIndex = 2;
            this.cmdNewSalesOrder.Text = "New Sales Order    >>>";
            this.cmdNewSalesOrder.UseVisualStyleBackColor = true;
            this.cmdNewSalesOrder.Click += new System.EventHandler(this.cmdNewSalesOrder_Click);
            // 
            // cmdFill
            // 
            this.cmdFill.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFill.Location = new System.Drawing.Point(219, 59);
            this.cmdFill.Name = "cmdFill";
            this.cmdFill.Size = new System.Drawing.Size(162, 20);
            this.cmdFill.TabIndex = 3;
            this.cmdFill.Text = "Fill This List";
            this.cmdFill.UseVisualStyleBackColor = true;
            this.cmdFill.Click += new System.EventHandler(this.cmdFill_Click);
            // 
            // cmdAddTo
            // 
            this.cmdAddTo.Enabled = false;
            this.cmdAddTo.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddTo.Location = new System.Drawing.Point(15, 115);
            this.cmdAddTo.Name = "cmdAddTo";
            this.cmdAddTo.Size = new System.Drawing.Size(366, 30);
            this.cmdAddTo.TabIndex = 4;
            this.cmdAddTo.Text = "(Select An Order First)";
            this.cmdAddTo.UseVisualStyleBackColor = true;
            this.cmdAddTo.Click += new System.EventHandler(this.cmdAddTo_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(15, 160);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(366, 30);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cboOrders
            // 
            this.cboOrders.Enabled = false;
            this.cboOrders.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOrders.FormattingEnabled = true;
            this.cboOrders.Location = new System.Drawing.Point(15, 87);
            this.cboOrders.Name = "cboOrders";
            this.cboOrders.Size = new System.Drawing.Size(366, 22);
            this.cboOrders.TabIndex = 6;
            this.cboOrders.SelectionChangeCommitted += new System.EventHandler(this.cboOrders_SelectionChangeCommitted);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(15, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(366, 3);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(15, 151);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(366, 3);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // frmAddToSO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(394, 200);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cboOrders);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAddTo);
            this.Controls.Add(this.cmdFill);
            this.Controls.Add(this.cmdNewSalesOrder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddToSO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Order";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdNewSalesOrder;
        private System.Windows.Forms.Button cmdFill;
        private System.Windows.Forms.Button cmdAddTo;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.ComboBox cboOrders;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}