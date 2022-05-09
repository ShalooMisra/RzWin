namespace Rz5.Focus
{
    partial class AdvanceShipmentNotification
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
            this.lblCaption = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.LinkLabel();
            this.lblCompany = new System.Windows.Forms.LinkLabel();
            this.lblContact = new System.Windows.Forms.LinkLabel();
            this.cmdASN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(6, 4);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(86, 25);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Caption";
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Location = new System.Drawing.Point(163, 46);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(43, 13);
            this.lblOrder.TabIndex = 1;
            this.lblOrder.TabStop = true;
            this.lblOrder.Text = "<order>";
            this.lblOrder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblOrder_LinkClicked);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(164, 69);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(62, 13);
            this.lblCompany.TabIndex = 2;
            this.lblCompany.TabStop = true;
            this.lblCompany.Text = "<company>";
            this.lblCompany.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCompany_LinkClicked);
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(164, 94);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(55, 13);
            this.lblContact.TabIndex = 3;
            this.lblContact.TabStop = true;
            this.lblContact.Text = "<contact>";
            this.lblContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblContact_LinkClicked);
            // 
            // cmdASN
            // 
            this.cmdASN.Location = new System.Drawing.Point(12, 46);
            this.cmdASN.Name = "cmdASN";
            this.cmdASN.Size = new System.Drawing.Size(145, 63);
            this.cmdASN.TabIndex = 4;
            this.cmdASN.Text = "Create ASN Email";
            this.cmdASN.UseVisualStyleBackColor = true;
            this.cmdASN.Click += new System.EventHandler(this.cmdASN_Click);
            // 
            // AdvanceShipmentNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmdASN);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblOrder);
            this.Controls.Add(this.lblCaption);
            this.Name = "AdvanceShipmentNotification";
            this.Size = new System.Drawing.Size(681, 155);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.LinkLabel lblOrder;
        private System.Windows.Forms.LinkLabel lblCompany;
        private System.Windows.Forms.LinkLabel lblContact;
        private System.Windows.Forms.Button cmdASN;
    }
}
