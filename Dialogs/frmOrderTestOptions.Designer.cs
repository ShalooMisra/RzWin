namespace Rz5
{
    partial class frmOrderTestOptions
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblConfirmDockDates = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.llResetVendorRMA = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.llResetVendorRMA);
            this.groupBox1.Controls.Add(this.lblConfirmDockDates);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 190);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Test Options";
            // 
            // lblConfirmDockDates
            // 
            this.lblConfirmDockDates.AutoSize = true;
            this.lblConfirmDockDates.Location = new System.Drawing.Point(6, 29);
            this.lblConfirmDockDates.Name = "lblConfirmDockDates";
            this.lblConfirmDockDates.Size = new System.Drawing.Size(102, 13);
            this.lblConfirmDockDates.TabIndex = 1;
            this.lblConfirmDockDates.TabStop = true;
            this.lblConfirmDockDates.Text = "Confirm Dock Dates";
            this.lblConfirmDockDates.Click += new System.EventHandler(this.lblConfirmDockDates_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // llResetVendorRMA
            // 
            this.llResetVendorRMA.AutoSize = true;
            this.llResetVendorRMA.Location = new System.Drawing.Point(6, 73);
            this.llResetVendorRMA.Name = "llResetVendorRMA";
            this.llResetVendorRMA.Size = new System.Drawing.Size(144, 13);
            this.llResetVendorRMA.TabIndex = 2;
            this.llResetVendorRMA.TabStop = true;
            this.llResetVendorRMA.Text = "Reset VRMA Shipped Status";
            this.llResetVendorRMA.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llResetVendorRMA_LinkClicked);
            // 
            // frmOrderTestOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmOrderTestOptions";
            this.ShowIcon = false;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel lblConfirmDockDates;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel llResetVendorRMA;
    }
}