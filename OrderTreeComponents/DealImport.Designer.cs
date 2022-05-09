namespace Rz5
{
    partial class DealImport
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
            this.dv = new NewMethod.nDataView();
            this.gb = new System.Windows.Forms.GroupBox();
            this.lblViewContact = new System.Windows.Forms.LinkLabel();
            this.lblViewCompany = new System.Windows.Forms.LinkLabel();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblContactCap = new System.Windows.Forms.Label();
            this.lblCompanyCap = new System.Windows.Forms.Label();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // dv
            // 
            this.dv.AlwaysDisableAccept = false;
            this.dv.BackColor = System.Drawing.Color.White;
            this.dv.DisableAutoMatching = false;
            this.dv.HideOptions = false;
            this.dv.Location = new System.Drawing.Point(0, 116);
            this.dv.Name = "dv";
            this.dv.Size = new System.Drawing.Size(801, 537);
            this.dv.TabIndex = 0;
            this.dv.Accept += new NewMethod.nDataViewAcceptHandler(this.dv_Accept);
            this.dv.AfterImport += new NewMethod.nDataViewImportHandler(this.dv_AfterImport);
            // 
            // gb
            // 
            this.gb.Controls.Add(this.lblViewContact);
            this.gb.Controls.Add(this.lblViewCompany);
            this.gb.Controls.Add(this.lblContact);
            this.gb.Controls.Add(this.lblCompany);
            this.gb.Controls.Add(this.lblContactCap);
            this.gb.Controls.Add(this.lblCompanyCap);
            this.gb.Location = new System.Drawing.Point(4, 7);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(426, 103);
            this.gb.TabIndex = 1;
            this.gb.TabStop = false;
            // 
            // lblViewContact
            // 
            this.lblViewContact.AutoSize = true;
            this.lblViewContact.Location = new System.Drawing.Point(61, 58);
            this.lblViewContact.Name = "lblViewContact";
            this.lblViewContact.Size = new System.Drawing.Size(29, 13);
            this.lblViewContact.TabIndex = 5;
            this.lblViewContact.TabStop = true;
            this.lblViewContact.Text = "view";
            this.lblViewContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblViewContact_LinkClicked);
            // 
            // lblViewCompany
            // 
            this.lblViewCompany.AutoSize = true;
            this.lblViewCompany.Location = new System.Drawing.Point(61, 16);
            this.lblViewCompany.Name = "lblViewCompany";
            this.lblViewCompany.Size = new System.Drawing.Size(29, 13);
            this.lblViewCompany.TabIndex = 4;
            this.lblViewCompany.TabStop = true;
            this.lblViewCompany.Text = "view";
            this.lblViewCompany.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblViewCompany_LinkClicked);
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(7, 71);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(218, 20);
            this.lblContact.TabIndex = 3;
            this.lblContact.Text = "CONTACT NAME 123123123";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.Location = new System.Drawing.Point(7, 29);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(223, 20);
            this.lblCompany.TabIndex = 2;
            this.lblCompany.Text = "COMPANY NAME 123123123";
            // 
            // lblContactCap
            // 
            this.lblContactCap.AutoSize = true;
            this.lblContactCap.Location = new System.Drawing.Point(8, 58);
            this.lblContactCap.Name = "lblContactCap";
            this.lblContactCap.Size = new System.Drawing.Size(47, 13);
            this.lblContactCap.TabIndex = 1;
            this.lblContactCap.Text = "Contact:";
            // 
            // lblCompanyCap
            // 
            this.lblCompanyCap.AutoSize = true;
            this.lblCompanyCap.Location = new System.Drawing.Point(8, 16);
            this.lblCompanyCap.Name = "lblCompanyCap";
            this.lblCompanyCap.Size = new System.Drawing.Size(54, 13);
            this.lblCompanyCap.TabIndex = 0;
            this.lblCompanyCap.Text = "Company:";
            // 
            // DealImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gb);
            this.Controls.Add(this.dv);
            this.Name = "DealImport";
            this.Size = new System.Drawing.Size(804, 656);
            this.Resize += new System.EventHandler(this.DealImport_Resize);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.LinkLabel lblViewContact;
        private System.Windows.Forms.LinkLabel lblViewCompany;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblContactCap;
        private System.Windows.Forms.Label lblCompanyCap;
        public NewMethod.nDataView dv;
    }
}
