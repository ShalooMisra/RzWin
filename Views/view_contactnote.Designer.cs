using NewMethod;

namespace Rz5
{
    partial class view_contactnote
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
            this.ctl_notedate = new NewMethod.nEdit_Date();
            this.ctl_notetext = new NewMethod.nEdit_Memo();
            this.ctlAgent = new NewMethod.nEdit_User();
            this.ctl_companyname = new NewMethod.nEdit_String();
            this.ctl_contactname = new NewMethod.nEdit_List();
            this.ctl_is_remote_visit = new NewMethod.nEdit_Boolean();
            this.ctl_is_site_audit = new NewMethod.nEdit_Boolean();
            this.ctl_site_audit_date = new NewMethod.nEdit_Date();
            this.SuspendLayout();
            // 
            // ctl_notedate
            // 
            this.ctl_notedate.AllowClear = false;
            this.ctl_notedate.BackColor = System.Drawing.Color.White;
            this.ctl_notedate.Bold = false;
            this.ctl_notedate.Caption = "Date";
            this.ctl_notedate.Changed = false;
            this.ctl_notedate.Enabled = false;
            this.ctl_notedate.Location = new System.Drawing.Point(3, 197);
            this.ctl_notedate.Name = "ctl_notedate";
            this.ctl_notedate.Size = new System.Drawing.Size(240, 45);
            this.ctl_notedate.SuppressEdit = false;
            this.ctl_notedate.TabIndex = 10;
            this.ctl_notedate.UseParentBackColor = true;
            this.ctl_notedate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_notedate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_notedate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_notedate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_notedate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_notedate.zz_OriginalDesign = true;
            this.ctl_notedate.zz_ShowNeedsSaveColor = true;
            this.ctl_notedate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_notedate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_notedate.zz_UseGlobalColor = false;
            this.ctl_notedate.zz_UseGlobalFont = false;
            // 
            // ctl_notetext
            // 
            this.ctl_notetext.BackColor = System.Drawing.Color.White;
            this.ctl_notetext.Bold = false;
            this.ctl_notetext.Caption = "Note";
            this.ctl_notetext.Changed = false;
            this.ctl_notetext.DateLines = false;
            this.ctl_notetext.Location = new System.Drawing.Point(5, 251);
            this.ctl_notetext.Name = "ctl_notetext";
            this.ctl_notetext.Size = new System.Drawing.Size(540, 184);
            this.ctl_notetext.TabIndex = 12;
            this.ctl_notetext.UseParentBackColor = true;
            this.ctl_notetext.zz_Enabled = true;
            this.ctl_notetext.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_notetext.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_notetext.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_notetext.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_notetext.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_notetext.zz_OriginalDesign = true;
            this.ctl_notetext.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_notetext.zz_ShowNeedsSaveColor = true;
            this.ctl_notetext.zz_Text = "";
            this.ctl_notetext.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_notetext.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_notetext.zz_UseGlobalColor = false;
            this.ctl_notetext.zz_UseGlobalFont = false;
            // 
            // ctlAgent
            // 
            this.ctlAgent.AllowChange = true;
            this.ctlAgent.AllowClear = false;
            this.ctlAgent.AllowNew = false;
            this.ctlAgent.AllowView = false;
            this.ctlAgent.BackColor = System.Drawing.Color.White;
            this.ctlAgent.Bold = false;
            this.ctlAgent.Caption = "Agent";
            this.ctlAgent.Changed = false;
            this.ctlAgent.Location = new System.Drawing.Point(-1, 34);
            this.ctlAgent.Name = "ctlAgent";
            this.ctlAgent.Size = new System.Drawing.Size(368, 53);
            this.ctlAgent.TabIndex = 13;
            this.ctlAgent.UseParentBackColor = true;
            this.ctlAgent.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlAgent.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            // 
            // ctl_companyname
            // 
            this.ctl_companyname.AllCaps = false;
            this.ctl_companyname.BackColor = System.Drawing.Color.White;
            this.ctl_companyname.Bold = false;
            this.ctl_companyname.Caption = "Company";
            this.ctl_companyname.Changed = false;
            this.ctl_companyname.IsEmail = false;
            this.ctl_companyname.IsURL = false;
            this.ctl_companyname.Location = new System.Drawing.Point(3, 93);
            this.ctl_companyname.Name = "ctl_companyname";
            this.ctl_companyname.PasswordChar = '\0';
            this.ctl_companyname.Size = new System.Drawing.Size(368, 46);
            this.ctl_companyname.TabIndex = 9;
            this.ctl_companyname.UseParentBackColor = true;
            this.ctl_companyname.zz_Enabled = true;
            this.ctl_companyname.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_companyname.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_companyname.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_companyname.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_companyname.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_companyname.zz_OriginalDesign = true;
            this.ctl_companyname.zz_ShowLinkButton = false;
            this.ctl_companyname.zz_ShowNeedsSaveColor = true;
            this.ctl_companyname.zz_Text = "";
            this.ctl_companyname.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_companyname.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_companyname.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_companyname.zz_UseGlobalColor = false;
            this.ctl_companyname.zz_UseGlobalFont = false;
            // 
            // ctl_contactname
            // 
            this.ctl_contactname.AllCaps = false;
            this.ctl_contactname.AllowEdit = false;
            this.ctl_contactname.BackColor = System.Drawing.Color.White;
            this.ctl_contactname.Bold = false;
            this.ctl_contactname.Caption = "Contact";
            this.ctl_contactname.Changed = false;
            this.ctl_contactname.ListName = null;
            this.ctl_contactname.Location = new System.Drawing.Point(3, 145);
            this.ctl_contactname.Name = "ctl_contactname";
            this.ctl_contactname.SimpleList = null;
            this.ctl_contactname.Size = new System.Drawing.Size(368, 46);
            this.ctl_contactname.TabIndex = 14;
            this.ctl_contactname.UseParentBackColor = true;
            this.ctl_contactname.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_contactname.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_contactname.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_contactname.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_contactname.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_contactname.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_contactname.zz_OriginalDesign = true;
            this.ctl_contactname.zz_ShowNeedsSaveColor = true;
            this.ctl_contactname.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_contactname.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_contactname.zz_UseGlobalColor = false;
            this.ctl_contactname.zz_UseGlobalFont = false;
            // 
            // ctl_is_remote_visit
            // 
            this.ctl_is_remote_visit.BackColor = System.Drawing.Color.Transparent;
            this.ctl_is_remote_visit.Bold = false;
            this.ctl_is_remote_visit.Caption = "Remote Visit";
            this.ctl_is_remote_visit.Changed = false;
            this.ctl_is_remote_visit.Enabled = false;
            this.ctl_is_remote_visit.Location = new System.Drawing.Point(142, 197);
            this.ctl_is_remote_visit.Name = "ctl_is_remote_visit";
            this.ctl_is_remote_visit.Size = new System.Drawing.Size(85, 18);
            this.ctl_is_remote_visit.TabIndex = 65;
            this.ctl_is_remote_visit.UseParentBackColor = false;
            this.ctl_is_remote_visit.zz_CheckValue = false;
            this.ctl_is_remote_visit.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_remote_visit.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_is_remote_visit.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_remote_visit.zz_OriginalDesign = false;
            this.ctl_is_remote_visit.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_is_site_audit
            // 
            this.ctl_is_site_audit.BackColor = System.Drawing.Color.Transparent;
            this.ctl_is_site_audit.Bold = false;
            this.ctl_is_site_audit.Caption = "Site Audit";
            this.ctl_is_site_audit.Changed = false;
            this.ctl_is_site_audit.Location = new System.Drawing.Point(249, 197);
            this.ctl_is_site_audit.Name = "ctl_is_site_audit";
            this.ctl_is_site_audit.Size = new System.Drawing.Size(71, 18);
            this.ctl_is_site_audit.TabIndex = 66;
            this.ctl_is_site_audit.UseParentBackColor = false;
            this.ctl_is_site_audit.zz_CheckValue = false;
            this.ctl_is_site_audit.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_site_audit.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_is_site_audit.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_site_audit.zz_OriginalDesign = false;
            this.ctl_is_site_audit.zz_ShowNeedsSaveColor = true;
            this.ctl_is_site_audit.CheckChanged += new NewMethod.CheckChangedHandler(this.ctl_is_site_audit_CheckChanged);
            // 
            // ctl_site_audit_date
            // 
            this.ctl_site_audit_date.AllowClear = false;
            this.ctl_site_audit_date.BackColor = System.Drawing.Color.White;
            this.ctl_site_audit_date.Bold = false;
            this.ctl_site_audit_date.Caption = "Site Audit Date";
            this.ctl_site_audit_date.Changed = false;
            this.ctl_site_audit_date.Enabled = false;
            this.ctl_site_audit_date.Location = new System.Drawing.Point(249, 221);
            this.ctl_site_audit_date.Name = "ctl_site_audit_date";
            this.ctl_site_audit_date.Size = new System.Drawing.Size(231, 45);
            this.ctl_site_audit_date.SuppressEdit = false;
            this.ctl_site_audit_date.TabIndex = 67;
            this.ctl_site_audit_date.UseParentBackColor = true;
            this.ctl_site_audit_date.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_site_audit_date.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_site_audit_date.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_site_audit_date.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_site_audit_date.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_site_audit_date.zz_OriginalDesign = true;
            this.ctl_site_audit_date.zz_ShowNeedsSaveColor = true;
            this.ctl_site_audit_date.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_site_audit_date.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_site_audit_date.zz_UseGlobalColor = false;
            this.ctl_site_audit_date.zz_UseGlobalFont = false;
            // 
            // view_contactnote
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctl_site_audit_date);
            this.Controls.Add(this.ctl_is_site_audit);
            this.Controls.Add(this.ctl_is_remote_visit);
            this.Controls.Add(this.ctlAgent);
            this.Controls.Add(this.ctl_notetext);
            this.Controls.Add(this.ctl_notedate);
            this.Controls.Add(this.ctl_companyname);
            this.Controls.Add(this.ctl_contactname);
            this.Name = "view_contactnote";
            this.Controls.SetChildIndex(this.xActions, 0);
            this.Controls.SetChildIndex(this.ctl_contactname, 0);
            this.Controls.SetChildIndex(this.ctl_companyname, 0);
            this.Controls.SetChildIndex(this.ctl_notedate, 0);
            this.Controls.SetChildIndex(this.ctl_notetext, 0);
            this.Controls.SetChildIndex(this.ctlAgent, 0);
            this.Controls.SetChildIndex(this.ctl_is_remote_visit, 0);
            this.Controls.SetChildIndex(this.ctl_is_site_audit, 0);
            this.Controls.SetChildIndex(this.ctl_site_audit_date, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private nEdit_Date ctl_notedate;
        private nEdit_Memo ctl_notetext;
        private nEdit_User ctlAgent;
        private nEdit_String ctl_companyname;
        private nEdit_List ctl_contactname;
        private nEdit_Boolean ctl_is_remote_visit;
        private nEdit_Boolean ctl_is_site_audit;
        private nEdit_Date ctl_site_audit_date;
    }
}
