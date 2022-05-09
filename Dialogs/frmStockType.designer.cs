using NewMethod;

namespace Rz5
{
    partial class frmStockType
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
            this.cmdStock = new System.Windows.Forms.Button();
            this.lblCaption = new System.Windows.Forms.Label();
            this.cmdBuy = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lblStock = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdStock
            // 
            this.cmdStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdStock.Location = new System.Drawing.Point(12, 38);
            this.cmdStock.Name = "cmdStock";
            this.cmdStock.Size = new System.Drawing.Size(199, 39);
            this.cmdStock.TabIndex = 0;
            this.cmdStock.Text = "Stock";
            this.cmdStock.UseVisualStyleBackColor = true;
            this.cmdStock.Click += new System.EventHandler(this.cmdStock_Click);
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(12, 5);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(79, 20);
            this.lblCaption.TabIndex = 1;
            this.lblCaption.Text = "<caption>";
            // 
            // cmdBuy
            // 
            this.cmdBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBuy.Location = new System.Drawing.Point(12, 83);
            this.cmdBuy.Name = "cmdBuy";
            this.cmdBuy.Size = new System.Drawing.Size(199, 39);
            this.cmdBuy.TabIndex = 2;
            this.cmdBuy.Text = "Buy";
            this.cmdBuy.UseVisualStyleBackColor = true;
            this.cmdBuy.Click += new System.EventHandler(this.cmdBuy_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(59, 128);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(98, 21);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.ForeColor = System.Drawing.Color.Blue;
            this.lblStock.Location = new System.Drawing.Point(221, 46);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(326, 13);
            this.lblStock.TabIndex = 4;
            this.lblStock.Text = "( These parts will be advertized and be available for sale by anyone)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(221, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "( These parts will not be advertized )";
            // 
            // frmStockType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(566, 155);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdBuy);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.cmdStock);
            this.Name = "frmStockType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Type Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdStock;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Button cmdBuy;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label label1;
    }
}