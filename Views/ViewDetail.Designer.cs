using Tools.Database;
namespace Rz5
{
    partial class ViewDetail
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
            this.ctl_fullpartnumber = new NewMethod.nEdit_String();
            this.ts = new System.Windows.Forms.TabControl();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.ctl_manufacturer = new NewMethod.nEdit_List();
            this.ctl_harmonized_tarriff_schedule = new NewMethod.nEdit_String();
            this.ctl_country_of_origin = new NewMethod.nEdit_String();
            this.ctl_rohs_info = new NewMethod.nEdit_List();
            this.ctl_alternatepart = new NewMethod.nEdit_String();
            this.ctl_internalcomment = new NewMethod.nEdit_Memo();
            this.ctl_description = new NewMethod.nEdit_String();
            this.ctl_quantity = new NewMethod.nEdit_Number();
            this.ctl_category = new NewMethod.nEdit_List();
            this.ctl_packaging = new NewMethod.nEdit_List();
            this.ctl_condition = new NewMethod.nEdit_List();
            this.ctl_datecode = new NewMethod.nEdit_String();
            this.tabAttachments = new System.Windows.Forms.TabPage();
            this.tabCommission = new System.Windows.Forms.TabPage();
            this.gbAffiliate = new System.Windows.Forms.GroupBox();
            this.gbAction1 = new System.Windows.Forms.GroupBox();
            this.throb1 = new NewMethod.nThrobber();
            this.lblLineStatus1 = new System.Windows.Forms.Label();
            this.cmdAction1 = new System.Windows.Forms.Button();
            this.gbTop = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.lblOrderType = new System.Windows.Forms.Label();
            this.ctl_country_of_origin_vendor = new NewMethod.nEdit_String();
            this.picview = new Rz5.PartPictureViewer();
            this.ac1 = new RzInterfaceWin.Controls.AffiliateCommission();
            this.sc1 = new Rz5.SplitCommission();
            this.ts.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.tabAttachments.SuspendLayout();
            this.tabCommission.SuspendLayout();
            this.gbAffiliate.SuspendLayout();
            this.gbAction1.SuspendLayout();
            this.gbTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(1024, 0);
            this.xActions.Size = new System.Drawing.Size(148, 559);
            this.xActions.TabIndex = 1;
            // 
            // ctl_fullpartnumber
            // 
            this.ctl_fullpartnumber.AllCaps = true;
            this.ctl_fullpartnumber.BackColor = System.Drawing.Color.Transparent;
            this.ctl_fullpartnumber.Bold = false;
            this.ctl_fullpartnumber.Caption = "Part Number";
            this.ctl_fullpartnumber.Changed = false;
            this.ctl_fullpartnumber.Enabled = false;
            this.ctl_fullpartnumber.IsEmail = false;
            this.ctl_fullpartnumber.IsURL = false;
            this.ctl_fullpartnumber.Location = new System.Drawing.Point(3, 3);
            this.ctl_fullpartnumber.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_fullpartnumber.Name = "ctl_fullpartnumber";
            this.ctl_fullpartnumber.PasswordChar = '\0';
            this.ctl_fullpartnumber.Size = new System.Drawing.Size(293, 44);
            this.ctl_fullpartnumber.TabIndex = 0;
            this.ctl_fullpartnumber.UseParentBackColor = false;
            this.ctl_fullpartnumber.zz_Enabled = true;
            this.ctl_fullpartnumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_fullpartnumber.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_fullpartnumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_fullpartnumber.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_fullpartnumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_fullpartnumber.zz_OriginalDesign = false;
            this.ctl_fullpartnumber.zz_ShowLinkButton = false;
            this.ctl_fullpartnumber.zz_ShowNeedsSaveColor = true;
            this.ctl_fullpartnumber.zz_Text = "";
            this.ctl_fullpartnumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_fullpartnumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_fullpartnumber.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_fullpartnumber.zz_UseGlobalColor = false;
            this.ctl_fullpartnumber.zz_UseGlobalFont = false;
            // 
            // ts
            // 
            this.ts.Controls.Add(this.tabInfo);
            this.ts.Controls.Add(this.tabAttachments);
            this.ts.Controls.Add(this.tabCommission);
            this.ts.Location = new System.Drawing.Point(4, 51);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(812, 320);
            this.ts.TabIndex = 0;
            this.ts.SelectedIndexChanged += new System.EventHandler(this.ts_SelectedIndexChanged);
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.ctl_country_of_origin_vendor);
            this.tabInfo.Controls.Add(this.ctl_manufacturer);
            this.tabInfo.Controls.Add(this.ctl_harmonized_tarriff_schedule);
            this.tabInfo.Controls.Add(this.ctl_country_of_origin);
            this.tabInfo.Controls.Add(this.ctl_rohs_info);
            this.tabInfo.Controls.Add(this.ctl_alternatepart);
            this.tabInfo.Controls.Add(this.ctl_internalcomment);
            this.tabInfo.Controls.Add(this.ctl_description);
            this.tabInfo.Controls.Add(this.ctl_quantity);
            this.tabInfo.Controls.Add(this.ctl_category);
            this.tabInfo.Controls.Add(this.ctl_packaging);
            this.tabInfo.Controls.Add(this.ctl_condition);
            this.tabInfo.Controls.Add(this.ctl_datecode);
            this.tabInfo.Controls.Add(this.ctl_fullpartnumber);
            this.tabInfo.Location = new System.Drawing.Point(4, 22);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfo.Size = new System.Drawing.Size(804, 294);
            this.tabInfo.TabIndex = 0;
            this.tabInfo.Text = "Info";
            this.tabInfo.UseVisualStyleBackColor = true;
            // 
            // ctl_manufacturer
            // 
            this.ctl_manufacturer.AllCaps = false;
            this.ctl_manufacturer.AllowEdit = false;
            this.ctl_manufacturer.BackColor = System.Drawing.Color.Transparent;
            this.ctl_manufacturer.Bold = false;
            this.ctl_manufacturer.Caption = "Manufacturer";
            this.ctl_manufacturer.Changed = false;
            this.ctl_manufacturer.ListName = "manufacturer";
            this.ctl_manufacturer.Location = new System.Drawing.Point(3, 55);
            this.ctl_manufacturer.Name = "ctl_manufacturer";
            this.ctl_manufacturer.SimpleList = null;
            this.ctl_manufacturer.Size = new System.Drawing.Size(143, 40);
            this.ctl_manufacturer.TabIndex = 42;
            this.ctl_manufacturer.UseParentBackColor = true;
            this.ctl_manufacturer.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_manufacturer.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_manufacturer.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_manufacturer.zz_LabelColor = System.Drawing.Color.Black;
            this.ctl_manufacturer.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_manufacturer.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_manufacturer.zz_OriginalDesign = false;
            this.ctl_manufacturer.zz_ShowNeedsSaveColor = true;
            this.ctl_manufacturer.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_manufacturer.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_manufacturer.zz_UseGlobalColor = false;
            this.ctl_manufacturer.zz_UseGlobalFont = false;
            // 
            // ctl_harmonized_tarriff_schedule
            // 
            this.ctl_harmonized_tarriff_schedule.AllCaps = false;
            this.ctl_harmonized_tarriff_schedule.BackColor = System.Drawing.Color.Transparent;
            this.ctl_harmonized_tarriff_schedule.Bold = false;
            this.ctl_harmonized_tarriff_schedule.Caption = "Harmonized Code (HTS)";
            this.ctl_harmonized_tarriff_schedule.Changed = false;
            this.ctl_harmonized_tarriff_schedule.IsEmail = false;
            this.ctl_harmonized_tarriff_schedule.IsURL = false;
            this.ctl_harmonized_tarriff_schedule.Location = new System.Drawing.Point(606, 50);
            this.ctl_harmonized_tarriff_schedule.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_harmonized_tarriff_schedule.Name = "ctl_harmonized_tarriff_schedule";
            this.ctl_harmonized_tarriff_schedule.PasswordChar = '\0';
            this.ctl_harmonized_tarriff_schedule.Size = new System.Drawing.Size(142, 44);
            this.ctl_harmonized_tarriff_schedule.TabIndex = 41;
            this.ctl_harmonized_tarriff_schedule.UseParentBackColor = false;
            this.ctl_harmonized_tarriff_schedule.zz_Enabled = true;
            this.ctl_harmonized_tarriff_schedule.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_harmonized_tarriff_schedule.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_harmonized_tarriff_schedule.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_harmonized_tarriff_schedule.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_harmonized_tarriff_schedule.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_harmonized_tarriff_schedule.zz_OriginalDesign = false;
            this.ctl_harmonized_tarriff_schedule.zz_ShowLinkButton = false;
            this.ctl_harmonized_tarriff_schedule.zz_ShowNeedsSaveColor = true;
            this.ctl_harmonized_tarriff_schedule.zz_Text = "";
            this.ctl_harmonized_tarriff_schedule.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_harmonized_tarriff_schedule.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_harmonized_tarriff_schedule.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_harmonized_tarriff_schedule.zz_UseGlobalColor = false;
            this.ctl_harmonized_tarriff_schedule.zz_UseGlobalFont = false;
            // 
            // ctl_country_of_origin
            // 
            this.ctl_country_of_origin.AllCaps = false;
            this.ctl_country_of_origin.BackColor = System.Drawing.Color.Transparent;
            this.ctl_country_of_origin.Bold = false;
            this.ctl_country_of_origin.Caption = "Country of Origin (COO)";
            this.ctl_country_of_origin.Changed = false;
            this.ctl_country_of_origin.IsEmail = false;
            this.ctl_country_of_origin.IsURL = false;
            this.ctl_country_of_origin.Location = new System.Drawing.Point(606, 100);
            this.ctl_country_of_origin.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_country_of_origin.Name = "ctl_country_of_origin";
            this.ctl_country_of_origin.PasswordChar = '\0';
            this.ctl_country_of_origin.Size = new System.Drawing.Size(142, 44);
            this.ctl_country_of_origin.TabIndex = 8;
            this.ctl_country_of_origin.UseParentBackColor = false;
            this.ctl_country_of_origin.zz_Enabled = true;
            this.ctl_country_of_origin.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_country_of_origin.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_country_of_origin.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_country_of_origin.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_country_of_origin.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_country_of_origin.zz_OriginalDesign = false;
            this.ctl_country_of_origin.zz_ShowLinkButton = false;
            this.ctl_country_of_origin.zz_ShowNeedsSaveColor = true;
            this.ctl_country_of_origin.zz_Text = "";
            this.ctl_country_of_origin.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_country_of_origin.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_country_of_origin.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_country_of_origin.zz_UseGlobalColor = false;
            this.ctl_country_of_origin.zz_UseGlobalFont = false;
            // 
            // ctl_rohs_info
            // 
            this.ctl_rohs_info.AllCaps = false;
            this.ctl_rohs_info.AllowEdit = false;
            this.ctl_rohs_info.BackColor = System.Drawing.Color.Transparent;
            this.ctl_rohs_info.Bold = false;
            this.ctl_rohs_info.Caption = "RoHS Info";
            this.ctl_rohs_info.Changed = false;
            this.ctl_rohs_info.ListName = "";
            this.ctl_rohs_info.Location = new System.Drawing.Point(351, 146);
            this.ctl_rohs_info.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_rohs_info.Name = "ctl_rohs_info";
            this.ctl_rohs_info.SimpleList = "Y|N|U";
            this.ctl_rohs_info.Size = new System.Drawing.Size(82, 44);
            this.ctl_rohs_info.TabIndex = 10;
            this.ctl_rohs_info.UseParentBackColor = false;
            this.ctl_rohs_info.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_rohs_info.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_rohs_info.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_rohs_info.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_rohs_info.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_rohs_info.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_rohs_info.zz_OriginalDesign = false;
            this.ctl_rohs_info.zz_ShowNeedsSaveColor = true;
            this.ctl_rohs_info.zz_TextColor = System.Drawing.Color.Black;
            this.ctl_rohs_info.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_rohs_info.zz_UseGlobalColor = false;
            this.ctl_rohs_info.zz_UseGlobalFont = false;
            // 
            // ctl_alternatepart
            // 
            this.ctl_alternatepart.AllCaps = false;
            this.ctl_alternatepart.BackColor = System.Drawing.Color.Transparent;
            this.ctl_alternatepart.Bold = false;
            this.ctl_alternatepart.Caption = "Alternate Part";
            this.ctl_alternatepart.Changed = false;
            this.ctl_alternatepart.IsEmail = false;
            this.ctl_alternatepart.IsURL = false;
            this.ctl_alternatepart.Location = new System.Drawing.Point(3, 150);
            this.ctl_alternatepart.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_alternatepart.Name = "ctl_alternatepart";
            this.ctl_alternatepart.PasswordChar = '\0';
            this.ctl_alternatepart.Size = new System.Drawing.Size(168, 40);
            this.ctl_alternatepart.TabIndex = 9;
            this.ctl_alternatepart.UseParentBackColor = false;
            this.ctl_alternatepart.zz_Enabled = true;
            this.ctl_alternatepart.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_alternatepart.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_alternatepart.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_alternatepart.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_alternatepart.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_alternatepart.zz_OriginalDesign = false;
            this.ctl_alternatepart.zz_ShowLinkButton = false;
            this.ctl_alternatepart.zz_ShowNeedsSaveColor = true;
            this.ctl_alternatepart.zz_Text = "";
            this.ctl_alternatepart.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_alternatepart.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_alternatepart.zz_TextFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_alternatepart.zz_UseGlobalColor = false;
            this.ctl_alternatepart.zz_UseGlobalFont = false;
            // 
            // ctl_internalcomment
            // 
            this.ctl_internalcomment.BackColor = System.Drawing.Color.Transparent;
            this.ctl_internalcomment.Bold = false;
            this.ctl_internalcomment.Caption = "Internal Comments";
            this.ctl_internalcomment.Changed = false;
            this.ctl_internalcomment.DateLines = false;
            this.ctl_internalcomment.Location = new System.Drawing.Point(8, 197);
            this.ctl_internalcomment.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_internalcomment.Name = "ctl_internalcomment";
            this.ctl_internalcomment.Size = new System.Drawing.Size(572, 59);
            this.ctl_internalcomment.TabIndex = 40;
            this.ctl_internalcomment.UseParentBackColor = false;
            this.ctl_internalcomment.zz_Enabled = true;
            this.ctl_internalcomment.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_internalcomment.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_internalcomment.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_internalcomment.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internalcomment.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_internalcomment.zz_OriginalDesign = false;
            this.ctl_internalcomment.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_internalcomment.zz_ShowNeedsSaveColor = true;
            this.ctl_internalcomment.zz_Text = "";
            this.ctl_internalcomment.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_internalcomment.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_internalcomment.zz_UseGlobalColor = false;
            this.ctl_internalcomment.zz_UseGlobalFont = false;
            // 
            // ctl_description
            // 
            this.ctl_description.AllCaps = false;
            this.ctl_description.BackColor = System.Drawing.Color.Transparent;
            this.ctl_description.Bold = false;
            this.ctl_description.Caption = "Description";
            this.ctl_description.Changed = false;
            this.ctl_description.IsEmail = false;
            this.ctl_description.IsURL = false;
            this.ctl_description.Location = new System.Drawing.Point(177, 100);
            this.ctl_description.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_description.Name = "ctl_description";
            this.ctl_description.PasswordChar = '\0';
            this.ctl_description.Size = new System.Drawing.Size(403, 44);
            this.ctl_description.TabIndex = 7;
            this.ctl_description.UseParentBackColor = false;
            this.ctl_description.zz_Enabled = true;
            this.ctl_description.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_description.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_description.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_description.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_description.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_description.zz_OriginalDesign = false;
            this.ctl_description.zz_ShowLinkButton = false;
            this.ctl_description.zz_ShowNeedsSaveColor = true;
            this.ctl_description.zz_Text = "";
            this.ctl_description.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_description.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_description.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_description.zz_UseGlobalColor = false;
            this.ctl_description.zz_UseGlobalFont = false;
            // 
            // ctl_quantity
            // 
            this.ctl_quantity.BackColor = System.Drawing.Color.Transparent;
            this.ctl_quantity.Bold = false;
            this.ctl_quantity.Caption = "Quantity";
            this.ctl_quantity.Changed = false;
            this.ctl_quantity.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_quantity.Location = new System.Drawing.Point(302, 3);
            this.ctl_quantity.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_quantity.Name = "ctl_quantity";
            this.ctl_quantity.Size = new System.Drawing.Size(88, 44);
            this.ctl_quantity.TabIndex = 1;
            this.ctl_quantity.UseParentBackColor = true;
            this.ctl_quantity.zz_Enabled = true;
            this.ctl_quantity.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_quantity.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_quantity.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_quantity.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_quantity.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_quantity.zz_OriginalDesign = false;
            this.ctl_quantity.zz_ShowErrorColor = true;
            this.ctl_quantity.zz_ShowNeedsSaveColor = true;
            this.ctl_quantity.zz_Text = "";
            this.ctl_quantity.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_quantity.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_quantity.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_quantity.zz_UseGlobalColor = false;
            this.ctl_quantity.zz_UseGlobalFont = false;
            // 
            // ctl_category
            // 
            this.ctl_category.AllCaps = false;
            this.ctl_category.AllowEdit = false;
            this.ctl_category.BackColor = System.Drawing.Color.Transparent;
            this.ctl_category.Bold = false;
            this.ctl_category.Caption = "Category";
            this.ctl_category.Changed = false;
            this.ctl_category.ListName = "category";
            this.ctl_category.Location = new System.Drawing.Point(3, 100);
            this.ctl_category.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_category.Name = "ctl_category";
            this.ctl_category.SimpleList = null;
            this.ctl_category.Size = new System.Drawing.Size(168, 44);
            this.ctl_category.TabIndex = 6;
            this.ctl_category.UseParentBackColor = false;
            this.ctl_category.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_category.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_category.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_category.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_category.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_category.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_category.zz_OriginalDesign = false;
            this.ctl_category.zz_ShowNeedsSaveColor = true;
            this.ctl_category.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_category.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_category.zz_UseGlobalColor = false;
            this.ctl_category.zz_UseGlobalFont = false;
            // 
            // ctl_packaging
            // 
            this.ctl_packaging.AllCaps = false;
            this.ctl_packaging.AllowEdit = false;
            this.ctl_packaging.BackColor = System.Drawing.Color.Transparent;
            this.ctl_packaging.Bold = false;
            this.ctl_packaging.Caption = "Packaging";
            this.ctl_packaging.Changed = false;
            this.ctl_packaging.ListName = "packaging";
            this.ctl_packaging.Location = new System.Drawing.Point(435, 50);
            this.ctl_packaging.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_packaging.Name = "ctl_packaging";
            this.ctl_packaging.SimpleList = null;
            this.ctl_packaging.Size = new System.Drawing.Size(161, 44);
            this.ctl_packaging.TabIndex = 5;
            this.ctl_packaging.UseParentBackColor = false;
            this.ctl_packaging.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_packaging.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_packaging.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_packaging.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_packaging.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_packaging.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_packaging.zz_OriginalDesign = false;
            this.ctl_packaging.zz_ShowNeedsSaveColor = true;
            this.ctl_packaging.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_packaging.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_packaging.zz_UseGlobalColor = false;
            this.ctl_packaging.zz_UseGlobalFont = false;
            // 
            // ctl_condition
            // 
            this.ctl_condition.AllCaps = false;
            this.ctl_condition.AllowEdit = false;
            this.ctl_condition.BackColor = System.Drawing.Color.Transparent;
            this.ctl_condition.Bold = false;
            this.ctl_condition.Caption = "Condition";
            this.ctl_condition.Changed = false;
            this.ctl_condition.ListName = "condition";
            this.ctl_condition.Location = new System.Drawing.Point(269, 50);
            this.ctl_condition.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_condition.Name = "ctl_condition";
            this.ctl_condition.SimpleList = null;
            this.ctl_condition.Size = new System.Drawing.Size(156, 44);
            this.ctl_condition.TabIndex = 4;
            this.ctl_condition.UseParentBackColor = false;
            this.ctl_condition.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_condition.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_condition.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_condition.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_condition.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_condition.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_condition.zz_OriginalDesign = false;
            this.ctl_condition.zz_ShowNeedsSaveColor = true;
            this.ctl_condition.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_condition.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_condition.zz_UseGlobalColor = false;
            this.ctl_condition.zz_UseGlobalFont = false;
            // 
            // ctl_datecode
            // 
            this.ctl_datecode.AllCaps = false;
            this.ctl_datecode.BackColor = System.Drawing.Color.Transparent;
            this.ctl_datecode.Bold = false;
            this.ctl_datecode.Caption = "Date Code";
            this.ctl_datecode.Changed = true;
            this.ctl_datecode.Enabled = false;
            this.ctl_datecode.IsEmail = false;
            this.ctl_datecode.IsURL = false;
            this.ctl_datecode.Location = new System.Drawing.Point(177, 50);
            this.ctl_datecode.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_datecode.Name = "ctl_datecode";
            this.ctl_datecode.PasswordChar = '\0';
            this.ctl_datecode.Size = new System.Drawing.Size(85, 44);
            this.ctl_datecode.TabIndex = 3;
            this.ctl_datecode.UseParentBackColor = false;
            this.ctl_datecode.zz_Enabled = true;
            this.ctl_datecode.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_datecode.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_datecode.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_datecode.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_datecode.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_datecode.zz_OriginalDesign = false;
            this.ctl_datecode.zz_ShowLinkButton = false;
            this.ctl_datecode.zz_ShowNeedsSaveColor = true;
            this.ctl_datecode.zz_Text = "";
            this.ctl_datecode.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_datecode.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_datecode.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_datecode.zz_UseGlobalColor = false;
            this.ctl_datecode.zz_UseGlobalFont = false;
            // 
            // tabAttachments
            // 
            this.tabAttachments.Controls.Add(this.picview);
            this.tabAttachments.Location = new System.Drawing.Point(4, 22);
            this.tabAttachments.Name = "tabAttachments";
            this.tabAttachments.Padding = new System.Windows.Forms.Padding(3);
            this.tabAttachments.Size = new System.Drawing.Size(804, 294);
            this.tabAttachments.TabIndex = 2;
            this.tabAttachments.Text = "Attachments";
            this.tabAttachments.UseVisualStyleBackColor = true;
            // 
            // tabCommission
            // 
            this.tabCommission.Controls.Add(this.gbAffiliate);
            this.tabCommission.Controls.Add(this.sc1);
            this.tabCommission.Location = new System.Drawing.Point(4, 22);
            this.tabCommission.Name = "tabCommission";
            this.tabCommission.Padding = new System.Windows.Forms.Padding(3);
            this.tabCommission.Size = new System.Drawing.Size(804, 294);
            this.tabCommission.TabIndex = 3;
            this.tabCommission.Text = "Commission";
            this.tabCommission.UseVisualStyleBackColor = true;
            // 
            // gbAffiliate
            // 
            this.gbAffiliate.Controls.Add(this.ac1);
            this.gbAffiliate.Location = new System.Drawing.Point(441, 6);
            this.gbAffiliate.Name = "gbAffiliate";
            this.gbAffiliate.Size = new System.Drawing.Size(310, 116);
            this.gbAffiliate.TabIndex = 1;
            this.gbAffiliate.TabStop = false;
            this.gbAffiliate.Text = "Affiliate";
            // 
            // gbAction1
            // 
            this.gbAction1.Controls.Add(this.throb1);
            this.gbAction1.Controls.Add(this.lblLineStatus1);
            this.gbAction1.Controls.Add(this.cmdAction1);
            this.gbAction1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAction1.Location = new System.Drawing.Point(866, 3);
            this.gbAction1.Name = "gbAction1";
            this.gbAction1.Size = new System.Drawing.Size(152, 134);
            this.gbAction1.TabIndex = 42;
            this.gbAction1.TabStop = false;
            this.gbAction1.Text = "Command";
            this.gbAction1.Visible = false;
            // 
            // throb1
            // 
            this.throb1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.throb1.Location = new System.Drawing.Point(117, 89);
            this.throb1.Margin = new System.Windows.Forms.Padding(4);
            this.throb1.Name = "throb1";
            this.throb1.Size = new System.Drawing.Size(28, 26);
            this.throb1.TabIndex = 24;
            this.throb1.UseParentBackColor = false;
            // 
            // lblLineStatus1
            // 
            this.lblLineStatus1.AutoSize = true;
            this.lblLineStatus1.Location = new System.Drawing.Point(8, 90);
            this.lblLineStatus1.Name = "lblLineStatus1";
            this.lblLineStatus1.Size = new System.Drawing.Size(93, 38);
            this.lblLineStatus1.TabIndex = 23;
            this.lblLineStatus1.Text = "<line status>\r\n<line status>";
            // 
            // cmdAction1
            // 
            this.cmdAction1.BackColor = System.Drawing.Color.Lime;
            this.cmdAction1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAction1.Location = new System.Drawing.Point(6, 19);
            this.cmdAction1.Name = "cmdAction1";
            this.cmdAction1.Size = new System.Drawing.Size(140, 69);
            this.cmdAction1.TabIndex = 22;
            this.cmdAction1.Text = "Ship";
            this.cmdAction1.UseVisualStyleBackColor = false;
            // 
            // gbTop
            // 
            this.gbTop.BackColor = System.Drawing.Color.White;
            this.gbTop.Controls.Add(this.lblStatus);
            this.gbTop.Controls.Add(this.txtOrderNumber);
            this.gbTop.Controls.Add(this.lblOrderType);
            this.gbTop.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTop.Location = new System.Drawing.Point(3, 3);
            this.gbTop.Name = "gbTop";
            this.gbTop.Size = new System.Drawing.Size(591, 47);
            this.gbTop.TabIndex = 40;
            this.gbTop.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(469, 15);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(107, 25);
            this.lblStatus.TabIndex = 21;
            this.lblStatus.Text = "CLOSED";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Visible = false;
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOrderNumber.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderNumber.Location = new System.Drawing.Point(158, 15);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.ReadOnly = true;
            this.txtOrderNumber.Size = new System.Drawing.Size(125, 26);
            this.txtOrderNumber.TabIndex = 8;
            this.txtOrderNumber.TabStop = false;
            this.txtOrderNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblOrderType
            // 
            this.lblOrderType.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderType.Location = new System.Drawing.Point(6, 14);
            this.lblOrderType.Name = "lblOrderType";
            this.lblOrderType.Size = new System.Drawing.Size(146, 31);
            this.lblOrderType.TabIndex = 1;
            this.lblOrderType.Text = "<ORDERTYPE>";
            // 
            // ctl_country_of_origin_vendor
            // 
            this.ctl_country_of_origin_vendor.AllCaps = false;
            this.ctl_country_of_origin_vendor.AutoScroll = true;
            this.ctl_country_of_origin_vendor.BackColor = System.Drawing.Color.Transparent;
            this.ctl_country_of_origin_vendor.Bold = false;
            this.ctl_country_of_origin_vendor.Caption = "Country of Origin (Vendor)";
            this.ctl_country_of_origin_vendor.Changed = false;
            this.ctl_country_of_origin_vendor.Enabled = false;
            this.ctl_country_of_origin_vendor.IsEmail = false;
            this.ctl_country_of_origin_vendor.IsURL = false;
            this.ctl_country_of_origin_vendor.Location = new System.Drawing.Point(606, 146);
            this.ctl_country_of_origin_vendor.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_country_of_origin_vendor.Name = "ctl_country_of_origin_vendor";
            this.ctl_country_of_origin_vendor.PasswordChar = '\0';
            this.ctl_country_of_origin_vendor.Size = new System.Drawing.Size(155, 44);
            this.ctl_country_of_origin_vendor.TabIndex = 43;
            this.ctl_country_of_origin_vendor.UseParentBackColor = false;
            this.ctl_country_of_origin_vendor.zz_Enabled = true;
            this.ctl_country_of_origin_vendor.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_country_of_origin_vendor.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_country_of_origin_vendor.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_country_of_origin_vendor.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_country_of_origin_vendor.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_country_of_origin_vendor.zz_OriginalDesign = false;
            this.ctl_country_of_origin_vendor.zz_ShowLinkButton = false;
            this.ctl_country_of_origin_vendor.zz_ShowNeedsSaveColor = true;
            this.ctl_country_of_origin_vendor.zz_Text = "";
            this.ctl_country_of_origin_vendor.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_country_of_origin_vendor.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_country_of_origin_vendor.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_country_of_origin_vendor.zz_UseGlobalColor = false;
            this.ctl_country_of_origin_vendor.zz_UseGlobalFont = false;
            // 
            // picview
            // 
            this.picview.BackColor = System.Drawing.Color.White;
            this.picview.Caption = "Rz3 PictureViewer";
            this.picview.DisablePartLink = false;
            this.picview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picview.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picview.Location = new System.Drawing.Point(3, 3);
            this.picview.Name = "picview";
            this.picview.ShowFullScreenButton = true;
            this.picview.ShowPartNumberLink = false;
            this.picview.ShowPartSearch = false;
            this.picview.ShowZoomButton = true;
            this.picview.Size = new System.Drawing.Size(798, 288);
            this.picview.TabIndex = 2;
            this.picview.TemplateName = "PartPictureViewer";
            // 
            // ac1
            // 
            this.ac1.BackColor = System.Drawing.Color.White;
            this.ac1.Location = new System.Drawing.Point(7, 13);
            this.ac1.Name = "ac1";
            this.ac1.Size = new System.Drawing.Size(298, 99);
            this.ac1.TabIndex = 0;
            // 
            // sc1
            // 
            this.sc1.BackColor = System.Drawing.Color.White;
            this.sc1.CurrentAgent = null;
            this.sc1.ListAcquisitionAgent = null;
            this.sc1.Location = new System.Drawing.Point(6, 6);
            this.sc1.Name = "sc1";
            this.sc1.Size = new System.Drawing.Size(418, 282);
            this.sc1.SplitCommissionAgent = null;
            this.sc1.splitCommissionObject = null;
            this.sc1.TabIndex = 0;
            // 
            // ViewDetail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.gbAction1);
            this.Controls.Add(this.gbTop);
            this.Controls.Add(this.ts);
            this.Name = "ViewDetail";
            this.Size = new System.Drawing.Size(1172, 559);
            this.Resize += new System.EventHandler(this.ViewDetail_Resize);
            this.Controls.SetChildIndex(this.ts, 0);
            this.Controls.SetChildIndex(this.gbTop, 0);
            this.Controls.SetChildIndex(this.gbAction1, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.ts.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.tabAttachments.ResumeLayout(false);
            this.tabCommission.ResumeLayout(false);
            this.gbAffiliate.ResumeLayout(false);
            this.gbAction1.ResumeLayout(false);
            this.gbAction1.PerformLayout();
            this.gbTop.ResumeLayout(false);
            this.gbTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl ts;
        public System.Windows.Forms.TabPage tabInfo;
        public System.Windows.Forms.TabPage tabAttachments;
        protected System.Windows.Forms.GroupBox gbAction1;
        protected NewMethod.nThrobber throb1;
        protected System.Windows.Forms.Label lblLineStatus1;
        protected System.Windows.Forms.Button cmdAction1;
        public System.Windows.Forms.GroupBox gbTop;
        protected System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label lblOrderType;
        public NewMethod.nEdit_Number ctl_quantity;
        public NewMethod.nEdit_String ctl_fullpartnumber;
        public NewMethod.nEdit_String ctl_datecode;
        public NewMethod.nEdit_List ctl_category;
        public NewMethod.nEdit_List ctl_packaging;
        public PartPictureViewer picview;
        public NewMethod.nEdit_Memo ctl_internalcomment;
        public NewMethod.nEdit_String ctl_description;
        protected NewMethod.nEdit_String ctl_alternatepart;
        public NewMethod.nEdit_List ctl_rohs_info;
        public NewMethod.nEdit_List ctl_condition;
        public NewMethod.nEdit_String ctl_country_of_origin;
        private System.Windows.Forms.TabPage tabCommission;
        private SplitCommission sc1;
        public NewMethod.nEdit_String ctl_harmonized_tarriff_schedule;
        public NewMethod.nEdit_List ctl_manufacturer;
        private System.Windows.Forms.GroupBox gbAffiliate;
        private RzInterfaceWin.Controls.AffiliateCommission ac1;
        public NewMethod.nEdit_String ctl_country_of_origin_vendor;
    }
}
