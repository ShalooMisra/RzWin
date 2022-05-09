using NewMethod;

namespace Rz5
{
    partial class view_companyaddress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(view_companyaddress));
            this.ctl_description = new NewMethod.nEdit_String();
            this.ctl_defaultbilling = new NewMethod.nEdit_Boolean();
            this.ctl_defaultshipping = new NewMethod.nEdit_Boolean();
            this.ctl_line1 = new NewMethod.nEdit_String();
            this.ctl_line2 = new NewMethod.nEdit_String();
            this.ctl_line3 = new NewMethod.nEdit_String();
            this.ctl_adrcity = new NewMethod.nEdit_String();
            this.ctl_adrzip = new NewMethod.nEdit_String();
            this.cmdPaste = new System.Windows.Forms.Button();
            this.ctl_adrcountry = new NewMethod.nEdit_List();
            this.ctl_adrstate = new NewMethod.nEdit_List();
            this.cmdCopyAddress = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(634, 0);
            this.xActions.Size = new System.Drawing.Size(148, 556);
            // 
            // ctl_description
            // 
            this.ctl_description.AllCaps = false;
            this.ctl_description.BackColor = System.Drawing.Color.White;
            this.ctl_description.Bold = true;
            this.ctl_description.Caption = "Description";
            this.ctl_description.Changed = false;
            this.ctl_description.IsEmail = false;
            this.ctl_description.IsURL = false;
            this.ctl_description.Location = new System.Drawing.Point(3, 46);
            this.ctl_description.Name = "ctl_description";
            this.ctl_description.PasswordChar = '\0';
            this.ctl_description.Size = new System.Drawing.Size(410, 46);
            this.ctl_description.TabIndex = 0;
            this.ctl_description.UseParentBackColor = true;
            this.ctl_description.zz_Enabled = true;
            this.ctl_description.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_description.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_description.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_description.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_description.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_description.zz_OriginalDesign = true;
            this.ctl_description.zz_ShowLinkButton = false;
            this.ctl_description.zz_ShowNeedsSaveColor = true;
            this.ctl_description.zz_Text = "";
            this.ctl_description.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_description.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_description.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_description.zz_UseGlobalColor = false;
            this.ctl_description.zz_UseGlobalFont = false;
            // 
            // ctl_defaultbilling
            // 
            this.ctl_defaultbilling.BackColor = System.Drawing.Color.White;
            this.ctl_defaultbilling.Bold = true;
            this.ctl_defaultbilling.Caption = "Default Billing";
            this.ctl_defaultbilling.Changed = false;
            this.ctl_defaultbilling.Location = new System.Drawing.Point(182, 37);
            this.ctl_defaultbilling.Name = "ctl_defaultbilling";
            this.ctl_defaultbilling.Size = new System.Drawing.Size(105, 18);
            this.ctl_defaultbilling.TabIndex = 7;
            this.ctl_defaultbilling.UseParentBackColor = true;
            this.ctl_defaultbilling.zz_CheckValue = false;
            this.ctl_defaultbilling.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_defaultbilling.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_defaultbilling.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_defaultbilling.zz_OriginalDesign = false;
            this.ctl_defaultbilling.zz_ShowNeedsSaveColor = true;
            this.ctl_defaultbilling.CheckChanged += new NewMethod.CheckChangedHandler(this.ctl_defaultbilling_CheckChanged);
            // 
            // ctl_defaultshipping
            // 
            this.ctl_defaultshipping.BackColor = System.Drawing.Color.White;
            this.ctl_defaultshipping.Bold = true;
            this.ctl_defaultshipping.Caption = "Default Shipping";
            this.ctl_defaultshipping.Changed = false;
            this.ctl_defaultshipping.Location = new System.Drawing.Point(293, 37);
            this.ctl_defaultshipping.Name = "ctl_defaultshipping";
            this.ctl_defaultshipping.Size = new System.Drawing.Size(120, 18);
            this.ctl_defaultshipping.TabIndex = 8;
            this.ctl_defaultshipping.UseParentBackColor = true;
            this.ctl_defaultshipping.zz_CheckValue = false;
            this.ctl_defaultshipping.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_defaultshipping.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_defaultshipping.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_defaultshipping.zz_OriginalDesign = false;
            this.ctl_defaultshipping.zz_ShowNeedsSaveColor = true;
            this.ctl_defaultshipping.CheckChanged += new NewMethod.CheckChangedHandler(this.ctl_defaultshipping_CheckChanged);
            // 
            // ctl_line1
            // 
            this.ctl_line1.AllCaps = false;
            this.ctl_line1.BackColor = System.Drawing.Color.White;
            this.ctl_line1.Bold = true;
            this.ctl_line1.Caption = "Line 1";
            this.ctl_line1.Changed = false;
            this.ctl_line1.IsEmail = false;
            this.ctl_line1.IsURL = false;
            this.ctl_line1.Location = new System.Drawing.Point(3, 98);
            this.ctl_line1.Name = "ctl_line1";
            this.ctl_line1.PasswordChar = '\0';
            this.ctl_line1.Size = new System.Drawing.Size(410, 46);
            this.ctl_line1.TabIndex = 1;
            this.ctl_line1.UseParentBackColor = true;
            this.ctl_line1.zz_Enabled = true;
            this.ctl_line1.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_line1.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_line1.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_line1.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_line1.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_line1.zz_OriginalDesign = true;
            this.ctl_line1.zz_ShowLinkButton = false;
            this.ctl_line1.zz_ShowNeedsSaveColor = true;
            this.ctl_line1.zz_Text = "";
            this.ctl_line1.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_line1.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_line1.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_line1.zz_UseGlobalColor = false;
            this.ctl_line1.zz_UseGlobalFont = false;
            // 
            // ctl_line2
            // 
            this.ctl_line2.AllCaps = false;
            this.ctl_line2.BackColor = System.Drawing.Color.White;
            this.ctl_line2.Bold = true;
            this.ctl_line2.Caption = "Line 2";
            this.ctl_line2.Changed = false;
            this.ctl_line2.IsEmail = false;
            this.ctl_line2.IsURL = false;
            this.ctl_line2.Location = new System.Drawing.Point(3, 150);
            this.ctl_line2.Name = "ctl_line2";
            this.ctl_line2.PasswordChar = '\0';
            this.ctl_line2.Size = new System.Drawing.Size(410, 46);
            this.ctl_line2.TabIndex = 2;
            this.ctl_line2.UseParentBackColor = true;
            this.ctl_line2.zz_Enabled = true;
            this.ctl_line2.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_line2.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_line2.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_line2.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_line2.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_line2.zz_OriginalDesign = true;
            this.ctl_line2.zz_ShowLinkButton = false;
            this.ctl_line2.zz_ShowNeedsSaveColor = true;
            this.ctl_line2.zz_Text = "";
            this.ctl_line2.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_line2.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_line2.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_line2.zz_UseGlobalColor = false;
            this.ctl_line2.zz_UseGlobalFont = false;
            // 
            // ctl_line3
            // 
            this.ctl_line3.AllCaps = false;
            this.ctl_line3.BackColor = System.Drawing.Color.White;
            this.ctl_line3.Bold = true;
            this.ctl_line3.Caption = "Line 3";
            this.ctl_line3.Changed = false;
            this.ctl_line3.IsEmail = false;
            this.ctl_line3.IsURL = false;
            this.ctl_line3.Location = new System.Drawing.Point(3, 202);
            this.ctl_line3.Name = "ctl_line3";
            this.ctl_line3.PasswordChar = '\0';
            this.ctl_line3.Size = new System.Drawing.Size(410, 46);
            this.ctl_line3.TabIndex = 3;
            this.ctl_line3.UseParentBackColor = true;
            this.ctl_line3.zz_Enabled = true;
            this.ctl_line3.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_line3.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_line3.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_line3.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_line3.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_line3.zz_OriginalDesign = true;
            this.ctl_line3.zz_ShowLinkButton = false;
            this.ctl_line3.zz_ShowNeedsSaveColor = true;
            this.ctl_line3.zz_Text = "";
            this.ctl_line3.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_line3.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_line3.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_line3.zz_UseGlobalColor = false;
            this.ctl_line3.zz_UseGlobalFont = false;
            // 
            // ctl_adrcity
            // 
            this.ctl_adrcity.AllCaps = false;
            this.ctl_adrcity.BackColor = System.Drawing.Color.White;
            this.ctl_adrcity.Bold = true;
            this.ctl_adrcity.Caption = "City";
            this.ctl_adrcity.Changed = false;
            this.ctl_adrcity.IsEmail = false;
            this.ctl_adrcity.IsURL = false;
            this.ctl_adrcity.Location = new System.Drawing.Point(3, 254);
            this.ctl_adrcity.Name = "ctl_adrcity";
            this.ctl_adrcity.PasswordChar = '\0';
            this.ctl_adrcity.Size = new System.Drawing.Size(410, 46);
            this.ctl_adrcity.TabIndex = 4;
            this.ctl_adrcity.UseParentBackColor = true;
            this.ctl_adrcity.zz_Enabled = true;
            this.ctl_adrcity.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_adrcity.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_adrcity.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_adrcity.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_adrcity.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_adrcity.zz_OriginalDesign = true;
            this.ctl_adrcity.zz_ShowLinkButton = false;
            this.ctl_adrcity.zz_ShowNeedsSaveColor = true;
            this.ctl_adrcity.zz_Text = "";
            this.ctl_adrcity.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_adrcity.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_adrcity.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_adrcity.zz_UseGlobalColor = false;
            this.ctl_adrcity.zz_UseGlobalFont = false;
            // 
            // ctl_adrzip
            // 
            this.ctl_adrzip.AllCaps = false;
            this.ctl_adrzip.BackColor = System.Drawing.Color.White;
            this.ctl_adrzip.Bold = true;
            this.ctl_adrzip.Caption = "Zip Code";
            this.ctl_adrzip.Changed = false;
            this.ctl_adrzip.IsEmail = false;
            this.ctl_adrzip.IsURL = false;
            this.ctl_adrzip.Location = new System.Drawing.Point(240, 306);
            this.ctl_adrzip.Name = "ctl_adrzip";
            this.ctl_adrzip.PasswordChar = '\0';
            this.ctl_adrzip.Size = new System.Drawing.Size(173, 46);
            this.ctl_adrzip.TabIndex = 6;
            this.ctl_adrzip.UseParentBackColor = true;
            this.ctl_adrzip.zz_Enabled = true;
            this.ctl_adrzip.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_adrzip.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_adrzip.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_adrzip.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_adrzip.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_adrzip.zz_OriginalDesign = true;
            this.ctl_adrzip.zz_ShowLinkButton = false;
            this.ctl_adrzip.zz_ShowNeedsSaveColor = true;
            this.ctl_adrzip.zz_Text = "";
            this.ctl_adrzip.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_adrzip.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_adrzip.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_adrzip.zz_UseGlobalColor = false;
            this.ctl_adrzip.zz_UseGlobalFont = false;
            // 
            // cmdPaste
            // 
            this.cmdPaste.Location = new System.Drawing.Point(3, 27);
            this.cmdPaste.Name = "cmdPaste";
            this.cmdPaste.Size = new System.Drawing.Size(117, 22);
            this.cmdPaste.TabIndex = 16;
            this.cmdPaste.Text = "Paste Address";
            this.cmdPaste.UseVisualStyleBackColor = true;
            this.cmdPaste.Click += new System.EventHandler(this.cmdPaste_Click);
            // 
            // ctl_adrcountry
            // 
            this.ctl_adrcountry.AllCaps = false;
            this.ctl_adrcountry.AllowEdit = false;
            this.ctl_adrcountry.BackColor = System.Drawing.Color.Transparent;
            this.ctl_adrcountry.Bold = true;
            this.ctl_adrcountry.Caption = "Country";
            this.ctl_adrcountry.Changed = false;
            this.ctl_adrcountry.ListName = null;
            this.ctl_adrcountry.Location = new System.Drawing.Point(3, 349);
            this.ctl_adrcountry.Name = "ctl_adrcountry";
            this.ctl_adrcountry.SimpleList = resources.GetString("ctl_adrcountry.SimpleList");
            this.ctl_adrcountry.Size = new System.Drawing.Size(410, 42);
            this.ctl_adrcountry.TabIndex = 7;
            this.ctl_adrcountry.UseParentBackColor = true;
            this.ctl_adrcountry.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_adrcountry.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_adrcountry.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_adrcountry.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_adrcountry.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_adrcountry.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_adrcountry.zz_OriginalDesign = true;
            this.ctl_adrcountry.zz_ShowNeedsSaveColor = true;
            this.ctl_adrcountry.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_adrcountry.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_adrcountry.zz_UseGlobalColor = false;
            this.ctl_adrcountry.zz_UseGlobalFont = false;
            this.ctl_adrcountry.DataChanged += new NewMethod.ChangeHandler(this.ctl_adrcountry_DataChanged);
            // 
            // ctl_adrstate
            // 
            this.ctl_adrstate.AllCaps = false;
            this.ctl_adrstate.AllowEdit = false;
            this.ctl_adrstate.BackColor = System.Drawing.Color.Transparent;
            this.ctl_adrstate.Bold = true;
            this.ctl_adrstate.Caption = "State";
            this.ctl_adrstate.Changed = false;
            this.ctl_adrstate.ListName = null;
            this.ctl_adrstate.Location = new System.Drawing.Point(3, 306);
            this.ctl_adrstate.Name = "ctl_adrstate";
            this.ctl_adrstate.SimpleList = "AL|AK|AS|AZ|AR|CA|CO|CT|DC|DE|FL|FM|GA|GU|HI|IA|ID|IL|IN|KS|KY|LA|MD|MA|ME|MH|MI|" +
    "MN|MP|MS|MO|MT|NC|ND|NE|NH|NJ|NM|NV|NY|OH|OK|OR|PA|PR|RI|SC|SD|TN|TX|UT|VA|VI|VT" +
    "|WA|WI|WV|WY";
            this.ctl_adrstate.Size = new System.Drawing.Size(231, 49);
            this.ctl_adrstate.TabIndex = 5;
            this.ctl_adrstate.UseParentBackColor = true;
            this.ctl_adrstate.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_adrstate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_adrstate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_adrstate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_adrstate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_adrstate.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_adrstate.zz_OriginalDesign = true;
            this.ctl_adrstate.zz_ShowNeedsSaveColor = true;
            this.ctl_adrstate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_adrstate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_adrstate.zz_UseGlobalColor = false;
            this.ctl_adrstate.zz_UseGlobalFont = false;
            // 
            // cmdCopyAddress
            // 
            this.cmdCopyAddress.Location = new System.Drawing.Point(3, 2);
            this.cmdCopyAddress.Name = "cmdCopyAddress";
            this.cmdCopyAddress.Size = new System.Drawing.Size(117, 22);
            this.cmdCopyAddress.TabIndex = 17;
            this.cmdCopyAddress.Text = "Copy Address";
            this.cmdCopyAddress.UseVisualStyleBackColor = true;
            this.cmdCopyAddress.Click += new System.EventHandler(this.cmdCopyAddress_Click);
            // 
            // view_companyaddress
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmdCopyAddress);
            this.Controls.Add(this.ctl_adrcountry);
            this.Controls.Add(this.ctl_adrstate);
            this.Controls.Add(this.cmdPaste);
            this.Controls.Add(this.ctl_adrzip);
            this.Controls.Add(this.ctl_adrcity);
            this.Controls.Add(this.ctl_line3);
            this.Controls.Add(this.ctl_line2);
            this.Controls.Add(this.ctl_line1);
            this.Controls.Add(this.ctl_defaultshipping);
            this.Controls.Add(this.ctl_defaultbilling);
            this.Controls.Add(this.ctl_description);
            this.Name = "view_companyaddress";
            this.Size = new System.Drawing.Size(782, 556);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.Controls.SetChildIndex(this.ctl_description, 0);
            this.Controls.SetChildIndex(this.ctl_defaultbilling, 0);
            this.Controls.SetChildIndex(this.ctl_defaultshipping, 0);
            this.Controls.SetChildIndex(this.ctl_line1, 0);
            this.Controls.SetChildIndex(this.ctl_line2, 0);
            this.Controls.SetChildIndex(this.ctl_line3, 0);
            this.Controls.SetChildIndex(this.ctl_adrcity, 0);
            this.Controls.SetChildIndex(this.ctl_adrzip, 0);
            this.Controls.SetChildIndex(this.cmdPaste, 0);
            this.Controls.SetChildIndex(this.ctl_adrstate, 0);
            this.Controls.SetChildIndex(this.ctl_adrcountry, 0);
            this.Controls.SetChildIndex(this.cmdCopyAddress, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private nEdit_String ctl_description;
        private nEdit_Boolean ctl_defaultbilling;
        private nEdit_Boolean ctl_defaultshipping;
        private nEdit_String ctl_line1;
        private nEdit_String ctl_line2;
        private nEdit_String ctl_line3;
        private nEdit_String ctl_adrcity;
        private nEdit_String ctl_adrzip;
        private System.Windows.Forms.Button cmdPaste;
        private nEdit_List ctl_adrcountry;
        private nEdit_List ctl_adrstate;
        private System.Windows.Forms.Button cmdCopyAddress;
    }
}
