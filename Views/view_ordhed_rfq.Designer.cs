namespace Rz5
{
    partial class view_ordhed_rfq
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
            this.details = new NewMethod.nList();
            this.gbTop = new System.Windows.Forms.GroupBox();
            this.ctl_is_government = new NewMethod.nEdit_Boolean();
            this.lblOrderType = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.ts = new System.Windows.Forms.TabControl();
            this.pageCompany = new System.Windows.Forms.TabPage();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.ctl_primaryphone = new NewMethod.nEdit_String();
            this.ctl_primaryfax = new NewMethod.nEdit_String();
            this.ctl_primaryemailaddress = new NewMethod.nEdit_String();
            this.agent = new NewMethod.nEdit_User();
            this.cStub = new CompanyStub_PlusContact();
            this.lblOrderTime = new System.Windows.Forms.Label();
            this.pageNotes = new System.Windows.Forms.TabPage();
            this.ctl_printcomment = new NewMethod.nEdit_Memo();
            this.ctl_internalcomment = new NewMethod.nEdit_Memo();
            this.gbTop.SuspendLayout();
            this.ts.SuspendLayout();
            this.pageCompany.SuspendLayout();
            this.pageNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // details
            // 
            this.details.AddCaption = "Add New Line Item";
            this.details.AllowAdd = true;
            this.details.Caption = "";
            this.details.ExtraClassInfo = "";
            this.details.Location = new System.Drawing.Point(3, 278);
            this.details.MultiSelect = true;
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(690, 180);
            this.details.TabIndex = 12;
            this.details.AboutToAdd += new NewMethod.AddHandler(this.details_AboutToAdd);
            // 
            // gbTop
            // 
            this.gbTop.BackColor = System.Drawing.Color.White;
            this.gbTop.Controls.Add(this.ctl_is_government);
            this.gbTop.Controls.Add(this.lblOrderType);
            this.gbTop.Controls.Add(this.lblOrderNumber);
            this.gbTop.Location = new System.Drawing.Point(-2, -4);
            this.gbTop.Name = "gbTop";
            this.gbTop.Size = new System.Drawing.Size(579, 66);
            this.gbTop.TabIndex = 10;
            this.gbTop.TabStop = false;
            // 
            // ctl_is_government
            // 
            this.ctl_is_government.BackColor = System.Drawing.Color.White;
            this.ctl_is_government.Bold = false;
            this.ctl_is_government.Caption = "Have PO";
            this.ctl_is_government.Changed = false;
            this.ctl_is_government.Location = new System.Drawing.Point(241, 30);
            this.ctl_is_government.Name = "ctl_is_government";
            this.ctl_is_government.Size = new System.Drawing.Size(99, 21);
            this.ctl_is_government.TabIndex = 2;
            this.ctl_is_government.UseParentBackColor = true;
            this.ctl_is_government.CheckChanged += new NewMethod.CheckChangedHandler(this.ctl_is_government_CheckChanged);
            // 
            // lblOrderType
            // 
            this.lblOrderType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderType.Location = new System.Drawing.Point(6, 16);
            this.lblOrderType.Name = "lblOrderType";
            this.lblOrderType.Size = new System.Drawing.Size(234, 22);
            this.lblOrderType.TabIndex = 1;
            this.lblOrderType.Text = "<order type>";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNumber.Location = new System.Drawing.Point(6, 41);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(234, 22);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "<order number>";
            // 
            // ts
            // 
            this.ts.Controls.Add(this.pageCompany);
            this.ts.Controls.Add(this.pageNotes);
            this.ts.Location = new System.Drawing.Point(3, 68);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(578, 204);
            this.ts.TabIndex = 11;
            // 
            // pageCompany
            // 
            this.pageCompany.Controls.Add(this.lblOrderDate);
            this.pageCompany.Controls.Add(this.ctl_primaryphone);
            this.pageCompany.Controls.Add(this.ctl_primaryfax);
            this.pageCompany.Controls.Add(this.ctl_primaryemailaddress);
            this.pageCompany.Controls.Add(this.agent);
            this.pageCompany.Controls.Add(this.cStub);
            this.pageCompany.Controls.Add(this.lblOrderTime);
            this.pageCompany.Location = new System.Drawing.Point(4, 22);
            this.pageCompany.Name = "pageCompany";
            this.pageCompany.Padding = new System.Windows.Forms.Padding(3);
            this.pageCompany.Size = new System.Drawing.Size(570, 178);
            this.pageCompany.TabIndex = 0;
            this.pageCompany.Text = "Company";
            this.pageCompany.UseVisualStyleBackColor = true;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDate.Location = new System.Drawing.Point(356, 83);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(107, 22);
            this.lblOrderDate.TabIndex = 13;
            this.lblOrderDate.Text = "<date>";
            this.lblOrderDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctl_primaryphone
            // 
            this.ctl_primaryphone.BackColor = System.Drawing.Color.Transparent;
            this.ctl_primaryphone.Bold = false;
            this.ctl_primaryphone.Caption = "Phone";
            this.ctl_primaryphone.Changed = false;
            this.ctl_primaryphone.IsEmail = false;
            this.ctl_primaryphone.IsURL = false;
            this.ctl_primaryphone.Location = new System.Drawing.Point(7, 87);
            this.ctl_primaryphone.Name = "ctl_primaryphone";
            this.ctl_primaryphone.PasswordChar = '\0';
            this.ctl_primaryphone.Size = new System.Drawing.Size(219, 42);
            this.ctl_primaryphone.TabIndex = 2;
            this.ctl_primaryphone.UseParentBackColor = true;
            // 
            // ctl_primaryfax
            // 
            this.ctl_primaryfax.BackColor = System.Drawing.Color.Transparent;
            this.ctl_primaryfax.Bold = false;
            this.ctl_primaryfax.Caption = "Fax";
            this.ctl_primaryfax.Changed = false;
            this.ctl_primaryfax.IsEmail = false;
            this.ctl_primaryfax.IsURL = false;
            this.ctl_primaryfax.Location = new System.Drawing.Point(7, 130);
            this.ctl_primaryfax.Name = "ctl_primaryfax";
            this.ctl_primaryfax.PasswordChar = '\0';
            this.ctl_primaryfax.Size = new System.Drawing.Size(219, 41);
            this.ctl_primaryfax.TabIndex = 4;
            this.ctl_primaryfax.UseParentBackColor = true;
            // 
            // ctl_primaryemailaddress
            // 
            this.ctl_primaryemailaddress.BackColor = System.Drawing.Color.Transparent;
            this.ctl_primaryemailaddress.Bold = false;
            this.ctl_primaryemailaddress.Caption = "Email";
            this.ctl_primaryemailaddress.Changed = false;
            this.ctl_primaryemailaddress.IsEmail = false;
            this.ctl_primaryemailaddress.IsURL = false;
            this.ctl_primaryemailaddress.Location = new System.Drawing.Point(244, 130);
            this.ctl_primaryemailaddress.Name = "ctl_primaryemailaddress";
            this.ctl_primaryemailaddress.PasswordChar = '\0';
            this.ctl_primaryemailaddress.Size = new System.Drawing.Size(219, 46);
            this.ctl_primaryemailaddress.TabIndex = 5;
            this.ctl_primaryemailaddress.UseParentBackColor = true;
            // 
            // agent
            // 
            this.agent.AllowChange = true;
            this.agent.AllowClear = false;
            this.agent.AllowView = false;
            this.agent.BackColor = System.Drawing.Color.Transparent;
            this.agent.Bold = false;
            this.agent.Caption = "Agent";
            this.agent.Changed = false;
            this.agent.Location = new System.Drawing.Point(346, 16);
            this.agent.Name = "agent";
            this.agent.Size = new System.Drawing.Size(218, 65);
            this.agent.TabIndex = 13;
            this.agent.UseParentBackColor = true;
            // 
            // cStub
            // 
            this.cStub.Caption = "Company Name";
            this.cStub.Location = new System.Drawing.Point(13, 3);
            this.cStub.Name = "cStub";
            this.cStub.Size = new System.Drawing.Size(337, 102);
            this.cStub.TabIndex = 1;
            this.cStub.ChangeCompany += new ContactEventHandler(this.cStub_ChangeCompany);
            this.cStub.ChangeContact += new ContactEventHandler(this.cStub_ChangeContact);
            // 
            // lblOrderTime
            // 
            this.lblOrderTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderTime.Location = new System.Drawing.Point(356, 105);
            this.lblOrderTime.Name = "lblOrderTime";
            this.lblOrderTime.Size = new System.Drawing.Size(107, 22);
            this.lblOrderTime.TabIndex = 14;
            this.lblOrderTime.Text = "<time>";
            this.lblOrderTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pageNotes
            // 
            this.pageNotes.Controls.Add(this.ctl_printcomment);
            this.pageNotes.Controls.Add(this.ctl_internalcomment);
            this.pageNotes.Location = new System.Drawing.Point(4, 22);
            this.pageNotes.Name = "pageNotes";
            this.pageNotes.Padding = new System.Windows.Forms.Padding(3);
            this.pageNotes.Size = new System.Drawing.Size(570, 178);
            this.pageNotes.TabIndex = 2;
            this.pageNotes.Text = "Notes";
            this.pageNotes.UseVisualStyleBackColor = true;
            // 
            // ctl_printcomment
            // 
            this.ctl_printcomment.BackColor = System.Drawing.Color.Transparent;
            this.ctl_printcomment.Bold = false;
            this.ctl_printcomment.Caption = "Print Comment";
            this.ctl_printcomment.Changed = false;
            this.ctl_printcomment.Location = new System.Drawing.Point(317, 3);
            this.ctl_printcomment.Name = "ctl_printcomment";
            this.ctl_printcomment.Size = new System.Drawing.Size(247, 169);
            this.ctl_printcomment.TabIndex = 27;
            this.ctl_printcomment.UseParentBackColor = true;
            // 
            // ctl_internalcomment
            // 
            this.ctl_internalcomment.BackColor = System.Drawing.Color.Transparent;
            this.ctl_internalcomment.Bold = false;
            this.ctl_internalcomment.Caption = "Internal Comment";
            this.ctl_internalcomment.Changed = false;
            this.ctl_internalcomment.Location = new System.Drawing.Point(3, 3);
            this.ctl_internalcomment.Name = "ctl_internalcomment";
            this.ctl_internalcomment.Size = new System.Drawing.Size(304, 169);
            this.ctl_internalcomment.TabIndex = 26;
            this.ctl_internalcomment.UseParentBackColor = true;
            // 
            // view_ordhed_rfq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.details);
            this.Controls.Add(this.gbTop);
            this.Controls.Add(this.ts);
            this.Name = "view_ordhed_rfq";
            //this.Controls.SetChildIndex(this.xFlashCorner, 0);
            this.Controls.SetChildIndex(this.ts, 0);
            this.Controls.SetChildIndex(this.gbTop, 0);
            this.Controls.SetChildIndex(this.details, 0);
            this.gbTop.ResumeLayout(false);
            this.ts.ResumeLayout(false);
            this.pageCompany.ResumeLayout(false);
            this.pageNotes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nList details;
        private System.Windows.Forms.GroupBox gbTop;
        private NewMethod.nEdit_Boolean ctl_is_government;
        private System.Windows.Forms.Label lblOrderType;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.TabControl ts;
        private System.Windows.Forms.TabPage pageCompany;
        private System.Windows.Forms.Label lblOrderDate;
        private NewMethod.nEdit_String ctl_primaryphone;
        private NewMethod.nEdit_String ctl_primaryfax;
        private NewMethod.nEdit_String ctl_primaryemailaddress;
        private NewMethod.nEdit_User agent;
        private CompanyStub_PlusContact cStub;
        private System.Windows.Forms.Label lblOrderTime;
        private System.Windows.Forms.TabPage pageNotes;
        private NewMethod.nEdit_Memo ctl_printcomment;
        private NewMethod.nEdit_Memo ctl_internalcomment;

    }
}
