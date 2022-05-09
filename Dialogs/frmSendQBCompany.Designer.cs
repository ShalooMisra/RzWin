namespace Rz5
{
    partial class frmSendQBCompany
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
                try
                {
                    //NewMethod.//nStatus.UnRegisterStatusView(this);
                }
                catch (System.Exception)
                { }

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
            this.lblExplain = new System.Windows.Forms.Label();
            this.cmdSend = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.cmdCheckIt = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.billingdata = new Rz5.view_companyaddress_data();
            this.shippingdata = new Rz5.view_companyaddress_data();
            this.lblExists = new System.Windows.Forms.Label();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.lblType = new System.Windows.Forms.Label();
            this.lblAddresses = new System.Windows.Forms.LinkLabel();
            this.cmdUpdateCompany = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbVendor = new System.Windows.Forms.RadioButton();
            this.rbCustomer = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblExplain
            // 
            this.lblExplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExplain.Location = new System.Drawing.Point(4, 0);
            this.lblExplain.Name = "lblExplain";
            this.lblExplain.Size = new System.Drawing.Size(706, 27);
            this.lblExplain.TabIndex = 0;
            this.lblExplain.Text = "The company --- needs to be sent to QuickBooks.";
            this.lblExplain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdSend
            // 
            this.cmdSend.Location = new System.Drawing.Point(12, 126);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(150, 54);
            this.cmdSend.TabIndex = 1;
            this.cmdSend.Text = "Send This Company";
            this.cmdSend.UseVisualStyleBackColor = true;
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(327, 126);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(150, 54);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "Close And Continue";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(8, 100);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(469, 20);
            this.txtCompanyName.TabIndex = 3;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(5, 77);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(94, 13);
            this.lblCompanyName.TabIndex = 4;
            this.lblCompanyName.Text = "Company Name";
            // 
            // cmdCheckIt
            // 
            this.cmdCheckIt.Location = new System.Drawing.Point(483, 127);
            this.cmdCheckIt.Name = "cmdCheckIt";
            this.cmdCheckIt.Size = new System.Drawing.Size(229, 31);
            this.cmdCheckIt.TabIndex = 5;
            this.cmdCheckIt.Text = "Check Quickbooks";
            this.cmdCheckIt.UseVisualStyleBackColor = true;
            this.cmdCheckIt.Click += new System.EventHandler(this.cmdCheckIt_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(8, 480);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(702, 84);
            this.txtStatus.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 464);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Status";
            // 
            // billingdata
            // 
            this.billingdata.Location = new System.Drawing.Point(8, 186);
            this.billingdata.Name = "billingdata";
            this.billingdata.Size = new System.Drawing.Size(348, 275);
            this.billingdata.TabIndex = 9;
            // 
            // shippingdata
            // 
            this.shippingdata.Location = new System.Drawing.Point(362, 186);
            this.shippingdata.Name = "shippingdata";
            this.shippingdata.Size = new System.Drawing.Size(348, 275);
            this.shippingdata.TabIndex = 10;
            // 
            // lblExists
            // 
            this.lblExists.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExists.ForeColor = System.Drawing.Color.Red;
            this.lblExists.Location = new System.Drawing.Point(483, 167);
            this.lblExists.Name = "lblExists";
            this.lblExists.Size = new System.Drawing.Size(229, 20);
            this.lblExists.TabIndex = 11;
            this.lblExists.Text = "<Not In QuickBooks>";
            this.lblExists.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // lblType
            // 
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(244, 27);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(218, 22);
            this.lblType.TabIndex = 12;
            this.lblType.Text = "As A Vendor";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblType.Visible = false;
            // 
            // lblAddresses
            // 
            this.lblAddresses.AutoSize = true;
            this.lblAddresses.Location = new System.Drawing.Point(14, 182);
            this.lblAddresses.Name = "lblAddresses";
            this.lblAddresses.Size = new System.Drawing.Size(67, 13);
            this.lblAddresses.TabIndex = 13;
            this.lblAddresses.TabStop = true;
            this.lblAddresses.Text = "<addresses>";
            this.lblAddresses.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddresses_LinkClicked);
            // 
            // cmdUpdateCompany
            // 
            this.cmdUpdateCompany.Location = new System.Drawing.Point(168, 126);
            this.cmdUpdateCompany.Name = "cmdUpdateCompany";
            this.cmdUpdateCompany.Size = new System.Drawing.Size(150, 54);
            this.cmdUpdateCompany.TabIndex = 14;
            this.cmdUpdateCompany.Text = "Update This Company";
            this.cmdUpdateCompany.UseVisualStyleBackColor = true;
            this.cmdUpdateCompany.Click += new System.EventHandler(this.cmdUpdateCompany_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbVendor);
            this.groupBox1.Controls.Add(this.rbCustomer);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(483, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 44);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Company Type (Required)";
            // 
            // rbVendor
            // 
            this.rbVendor.AutoSize = true;
            this.rbVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbVendor.Location = new System.Drawing.Point(84, 21);
            this.rbVendor.Name = "rbVendor";
            this.rbVendor.Size = new System.Drawing.Size(59, 17);
            this.rbVendor.TabIndex = 1;
            this.rbVendor.TabStop = true;
            this.rbVendor.Text = "Vendor";
            this.rbVendor.UseVisualStyleBackColor = true;
            // 
            // rbCustomer
            // 
            this.rbCustomer.AutoSize = true;
            this.rbCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCustomer.Location = new System.Drawing.Point(9, 21);
            this.rbCustomer.Name = "rbCustomer";
            this.rbCustomer.Size = new System.Drawing.Size(69, 17);
            this.rbCustomer.TabIndex = 0;
            this.rbCustomer.TabStop = true;
            this.rbCustomer.Text = "Customer";
            this.rbCustomer.UseVisualStyleBackColor = true;
            // 
            // frmSendQBCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 576);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdUpdateCompany);
            this.Controls.Add(this.lblAddresses);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblExists);
            this.Controls.Add(this.shippingdata);
            this.Controls.Add(this.billingdata);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.cmdCheckIt);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSend);
            this.Controls.Add(this.lblExplain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSendQBCompany";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QB Company Checker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSendQBCompany_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExplain;
        private System.Windows.Forms.Button cmdSend;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Button cmdCheckIt;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label1;
        private view_companyaddress_data billingdata;
        private view_companyaddress_data shippingdata;
        private System.Windows.Forms.Label lblExists;
        private System.ComponentModel.BackgroundWorker bg;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.LinkLabel lblAddresses;
        private System.Windows.Forms.Button cmdUpdateCompany;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbVendor;
        private System.Windows.Forms.RadioButton rbCustomer;
    }
}