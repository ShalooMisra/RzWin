using NewMethod;
using Tools.Database;

namespace Rz5
{
    partial class view_orddet
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
                    //CurrentDetail.xSys.UnRegisterNotifyClass(this);
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
            this.ts = new System.Windows.Forms.TabControl();
            this.pageInfo = new System.Windows.Forms.TabPage();
            this.ctl_leadtime = new NewMethod.nEdit_List();
            this.ctl_rohs = new NewMethod.nEdit_Boolean();
            this.ctl_shipvia = new NewMethod.nEdit_List();
            this.cmdMultiSearchAlternate = new System.Windows.Forms.Button();
            this.cmdQQ = new System.Windows.Forms.Button();
            this.ctl_is_service = new NewMethod.nEdit_Boolean();
            this.ctl_is_accepted = new NewMethod.nEdit_Boolean();
            this.ctl_has_cofc = new NewMethod.nEdit_Boolean();
            this.ctl_line_paid = new NewMethod.nEdit_Boolean();
            this.ctl_internalcomment = new NewMethod.nEdit_String();
            this.cmdMarkUp = new System.Windows.Forms.Button();
            this.ctl_unitprice = new Rz5.Win.Controls.EditMoney();
            this.ctl_quantityfilled = new NewMethod.nEdit_Number();
            this.ctl_quantityordered = new NewMethod.nEdit_Number();
            this.ctl_isverified = new NewMethod.nEdit_Boolean();
            this.ctl_hasbeenpicked = new NewMethod.nEdit_Boolean();
            this.optMultiSearch = new System.Windows.Forms.RadioButton();
            this.optPartSearch = new System.Windows.Forms.RadioButton();
            this.cmdPartSearch = new System.Windows.Forms.Button();
            this.ctl_mfg_certifications = new NewMethod.nEdit_Boolean();
            this.ctl_unit_of_measure = new NewMethod.nEdit_String();
            this.gb = new System.Windows.Forms.GroupBox();
            this.lblOriginalVendor = new System.Windows.Forms.Label();
            this.lblChooseVendorContact = new System.Windows.Forms.LinkLabel();
            this.ctl_vendorcontactname = new NewMethod.nEdit_String();
            this.lblChooseVendor = new System.Windows.Forms.LinkLabel();
            this.lblStock = new System.Windows.Forms.Label();
            this.cmdQuotes = new System.Windows.Forms.Button();
            this.ctl_unitcost = new Rz5.Win.Controls.EditMoney();
            this.buyer = new NewMethod.nEdit_User();
            this.cStub = new Rz5.CompanyStub();
            this.ctl_packaging = new NewMethod.nEdit_List();
            this.ctl_category = new NewMethod.nEdit_List();
            this.ctl_lotnumber = new NewMethod.nEdit_String();
            this.ctl_country = new NewMethod.nEdit_String();
            this.ctl_partsetup = new NewMethod.nEdit_List();
            this.ctl_partsperpack = new NewMethod.nEdit_Number();
            this.ctl_shipdate = new NewMethod.nEdit_Date();
            this.ctl_requireddate = new NewMethod.nEdit_Date();
            this.ctl_alternatepart = new NewMethod.nEdit_String();
            this.ctl_location = new NewMethod.nEdit_String();
            this.ctl_quantitypurchased = new NewMethod.nEdit_Number();
            this.ctl_alternatepart_02 = new NewMethod.nEdit_String();
            this.ctl_quantitybacked = new NewMethod.nEdit_Number();
            this.ctl_quantitycancelled = new NewMethod.nEdit_Number();
            this.ctl_description = new NewMethod.nEdit_String();
            this.ctl_internalpartnumber = new NewMethod.nEdit_String();
            this.ctl_condition = new NewMethod.nEdit_List();
            this.ctl_minimumquantity = new NewMethod.nEdit_Number();
            this.ctl_datecode = new NewMethod.nEdit_String();
            this.ctl_manufacturer = new NewMethod.nEdit_String();
            this.ctl_isselected = new NewMethod.nEdit_Boolean();
            this.ctl_fullpartnumber = new NewMethod.nEdit_String();
            this.pageOther = new System.Windows.Forms.TabPage();
            this.ctl_invoice_date = new NewMethod.nEdit_Date();
            this.lvQualityControl = new NewMethod.nList();
            this.ctl_buytype = new NewMethod.nEdit_String();
            this.ctl_freightcost = new Rz5.Win.Controls.EditMoney();
            this.ctl_servicecost = new Rz5.Win.Controls.EditMoney();
            this.ctl_alternatepart_04 = new NewMethod.nEdit_String();
            this.ctl_alternatepart_03 = new NewMethod.nEdit_String();
            this.ctl_alternatepart_01 = new NewMethod.nEdit_String();
            this.agent = new NewMethod.nEdit_User();
            this.pagePictures = new System.Windows.Forms.TabPage();
            this.PPV = new Rz5.PartPictureViewer();
            this.tabBids = new System.Windows.Forms.TabPage();
            this.lvBids = new NewMethod.nList();
            this.tabProcurement = new System.Windows.Forms.TabPage();
            this.lvProcurement = new NewMethod.nList();
            this.ts.SuspendLayout();
            this.pageInfo.SuspendLayout();
            this.gb.SuspendLayout();
            this.pageOther.SuspendLayout();
            this.pagePictures.SuspendLayout();
            this.tabBids.SuspendLayout();
            this.tabProcurement.SuspendLayout();
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(899, 0);
            this.xActions.Size = new System.Drawing.Size(192, 798);

            // 
            // ts
            // 
            this.ts.Controls.Add(this.pageInfo);
            this.ts.Controls.Add(this.pageOther);
            this.ts.Controls.Add(this.pagePictures);
            this.ts.Controls.Add(this.tabBids);
            this.ts.Controls.Add(this.tabProcurement);
            this.ts.Location = new System.Drawing.Point(181, 40);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(657, 500);
            this.ts.TabIndex = 7;
            this.ts.SelectedIndexChanged += new System.EventHandler(this.ts_SelectedIndexChanged);
            // 
            // pageInfo
            // 
            this.pageInfo.Controls.Add(this.ctl_leadtime);
            this.pageInfo.Controls.Add(this.ctl_rohs);
            this.pageInfo.Controls.Add(this.ctl_shipvia);
            this.pageInfo.Controls.Add(this.cmdMultiSearchAlternate);
            this.pageInfo.Controls.Add(this.cmdQQ);
            this.pageInfo.Controls.Add(this.ctl_is_service);
            this.pageInfo.Controls.Add(this.ctl_is_accepted);
            this.pageInfo.Controls.Add(this.ctl_has_cofc);
            this.pageInfo.Controls.Add(this.ctl_line_paid);
            this.pageInfo.Controls.Add(this.ctl_internalcomment);
            this.pageInfo.Controls.Add(this.cmdMarkUp);
            this.pageInfo.Controls.Add(this.ctl_unitprice);
            this.pageInfo.Controls.Add(this.ctl_quantityfilled);
            this.pageInfo.Controls.Add(this.ctl_quantityordered);
            this.pageInfo.Controls.Add(this.ctl_isverified);
            this.pageInfo.Controls.Add(this.ctl_hasbeenpicked);
            this.pageInfo.Controls.Add(this.optMultiSearch);
            this.pageInfo.Controls.Add(this.optPartSearch);
            this.pageInfo.Controls.Add(this.cmdPartSearch);
            this.pageInfo.Controls.Add(this.ctl_mfg_certifications);
            this.pageInfo.Controls.Add(this.ctl_unit_of_measure);
            this.pageInfo.Controls.Add(this.gb);
            this.pageInfo.Controls.Add(this.ctl_packaging);
            this.pageInfo.Controls.Add(this.ctl_category);
            this.pageInfo.Controls.Add(this.ctl_lotnumber);
            this.pageInfo.Controls.Add(this.ctl_country);
            this.pageInfo.Controls.Add(this.ctl_partsetup);
            this.pageInfo.Controls.Add(this.ctl_partsperpack);
            this.pageInfo.Controls.Add(this.ctl_shipdate);
            this.pageInfo.Controls.Add(this.ctl_requireddate);
            this.pageInfo.Controls.Add(this.ctl_alternatepart);
            this.pageInfo.Controls.Add(this.ctl_location);
            this.pageInfo.Controls.Add(this.ctl_quantitypurchased);
            this.pageInfo.Controls.Add(this.ctl_alternatepart_02);
            this.pageInfo.Controls.Add(this.ctl_quantitybacked);
            this.pageInfo.Controls.Add(this.ctl_quantitycancelled);
            this.pageInfo.Controls.Add(this.ctl_description);
            this.pageInfo.Controls.Add(this.ctl_internalpartnumber);
            this.pageInfo.Controls.Add(this.ctl_condition);
            this.pageInfo.Controls.Add(this.ctl_minimumquantity);
            this.pageInfo.Controls.Add(this.ctl_datecode);
            this.pageInfo.Controls.Add(this.ctl_manufacturer);
            this.pageInfo.Controls.Add(this.ctl_isselected);
            this.pageInfo.Controls.Add(this.ctl_fullpartnumber);
            this.pageInfo.Location = new System.Drawing.Point(4, 22);
            this.pageInfo.Name = "pageInfo";
            this.pageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.pageInfo.Size = new System.Drawing.Size(649, 474);
            this.pageInfo.TabIndex = 0;
            this.pageInfo.Text = "Info";
            this.pageInfo.UseVisualStyleBackColor = true;
            // 
            // ctl_leadtime
            // 
            this.ctl_leadtime.AllCaps = false;
            this.ctl_leadtime.AllowEdit = false;
            this.ctl_leadtime.BackColor = System.Drawing.Color.Transparent;
            this.ctl_leadtime.Bold = false;
            this.ctl_leadtime.Caption = "Lead Time";
            this.ctl_leadtime.Changed = false;
            this.ctl_leadtime.ListName = "";
            this.ctl_leadtime.Location = new System.Drawing.Point(521, 158);
            this.ctl_leadtime.Name = "ctl_leadtime";
            this.ctl_leadtime.SimpleList = "1 Day|2 Days|3 Days|4 Days|5 Days|6 Days|7 Days";
            this.ctl_leadtime.Size = new System.Drawing.Size(123, 42);
            this.ctl_leadtime.TabIndex = 48;
            this.ctl_leadtime.UseParentBackColor = true;
            this.ctl_leadtime.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_leadtime.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_leadtime.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_leadtime.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_leadtime.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_leadtime.zz_OriginalDesign = true;
            this.ctl_leadtime.zz_ShowNeedsSaveColor = true;
            this.ctl_leadtime.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_leadtime.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_leadtime.zz_UseGlobalColor = false;
            this.ctl_leadtime.zz_UseGlobalFont = false;
            // 
            // ctl_rohs
            // 
            this.ctl_rohs.BackColor = System.Drawing.Color.Transparent;
            this.ctl_rohs.Bold = false;
            this.ctl_rohs.Caption = "Rohs";
            this.ctl_rohs.Changed = false;
            this.ctl_rohs.Location = new System.Drawing.Point(394, 25);
            this.ctl_rohs.Name = "ctl_rohs";
            this.ctl_rohs.Size = new System.Drawing.Size(51, 18);
            this.ctl_rohs.TabIndex = 47;
            this.ctl_rohs.UseParentBackColor = true;
            this.ctl_rohs.zz_CheckValue = false;
            this.ctl_rohs.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_rohs.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_rohs.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_rohs.zz_OriginalDesign = false;
            this.ctl_rohs.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_shipvia
            // 
            this.ctl_shipvia.AllCaps = false;
            this.ctl_shipvia.AllowEdit = false;
            this.ctl_shipvia.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shipvia.Bold = false;
            this.ctl_shipvia.Caption = "Ship Via";
            this.ctl_shipvia.Changed = true;
            this.ctl_shipvia.ListName = "shipvia";
            this.ctl_shipvia.Location = new System.Drawing.Point(521, 295);
            this.ctl_shipvia.Name = "ctl_shipvia";
            this.ctl_shipvia.SimpleList = null;
            this.ctl_shipvia.Size = new System.Drawing.Size(122, 42);
            this.ctl_shipvia.TabIndex = 46;
            this.ctl_shipvia.UseParentBackColor = true;
            this.ctl_shipvia.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shipvia.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_shipvia.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shipvia.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_shipvia.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_shipvia.zz_OriginalDesign = true;
            this.ctl_shipvia.zz_ShowNeedsSaveColor = true;
            this.ctl_shipvia.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shipvia.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shipvia.zz_UseGlobalColor = false;
            this.ctl_shipvia.zz_UseGlobalFont = false;
            // 
            // cmdMultiSearchAlternate
            // 
            this.cmdMultiSearchAlternate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cmdMultiSearchAlternate.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMultiSearchAlternate.Location = new System.Drawing.Point(290, 196);
            this.cmdMultiSearchAlternate.Name = "cmdMultiSearchAlternate";
            this.cmdMultiSearchAlternate.Size = new System.Drawing.Size(98, 21);
            this.cmdMultiSearchAlternate.TabIndex = 45;
            this.cmdMultiSearchAlternate.Text = "Multi-Search";
            this.cmdMultiSearchAlternate.UseVisualStyleBackColor = false;
            this.cmdMultiSearchAlternate.Click += new System.EventHandler(this.cmdMultiSearchAltPart_Click);
            // 
            // cmdQQ
            // 
            this.cmdQQ.BackColor = System.Drawing.Color.GreenYellow;
            this.cmdQQ.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdQQ.Location = new System.Drawing.Point(480, 109);
            this.cmdQQ.Name = "cmdQQ";
            this.cmdQQ.Size = new System.Drawing.Size(37, 21);
            this.cmdQQ.TabIndex = 44;
            this.cmdQQ.Text = "QQ";
            this.cmdQQ.UseVisualStyleBackColor = false;
            this.cmdQQ.Visible = false;
            this.cmdQQ.Click += new System.EventHandler(this.cmdQQ_Click);
            // 
            // ctl_is_service
            // 
            this.ctl_is_service.BackColor = System.Drawing.Color.Transparent;
            this.ctl_is_service.Bold = false;
            this.ctl_is_service.Caption = "Service Charge";
            this.ctl_is_service.Changed = false;
            this.ctl_is_service.Location = new System.Drawing.Point(394, 6);
            this.ctl_is_service.Name = "ctl_is_service";
            this.ctl_is_service.Size = new System.Drawing.Size(99, 18);
            this.ctl_is_service.TabIndex = 43;
            this.ctl_is_service.UseParentBackColor = true;
            this.ctl_is_service.zz_CheckValue = false;
            this.ctl_is_service.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_service.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_is_service.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_service.zz_OriginalDesign = false;
            this.ctl_is_service.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_is_accepted
            // 
            this.ctl_is_accepted.BackColor = System.Drawing.Color.Transparent;
            this.ctl_is_accepted.Bold = false;
            this.ctl_is_accepted.Caption = "Is Accepted";
            this.ctl_is_accepted.Changed = false;
            this.ctl_is_accepted.Location = new System.Drawing.Point(5, 6);
            this.ctl_is_accepted.Name = "ctl_is_accepted";
            this.ctl_is_accepted.Size = new System.Drawing.Size(83, 18);
            this.ctl_is_accepted.TabIndex = 42;
            this.ctl_is_accepted.UseParentBackColor = false;
            this.ctl_is_accepted.Visible = false;
            this.ctl_is_accepted.zz_CheckValue = false;
            this.ctl_is_accepted.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_accepted.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_is_accepted.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_accepted.zz_OriginalDesign = false;
            this.ctl_is_accepted.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_has_cofc
            // 
            this.ctl_has_cofc.BackColor = System.Drawing.Color.Transparent;
            this.ctl_has_cofc.Bold = false;
            this.ctl_has_cofc.Caption = "Has C of Cs";
            this.ctl_has_cofc.Changed = false;
            this.ctl_has_cofc.Location = new System.Drawing.Point(305, 25);
            this.ctl_has_cofc.Name = "ctl_has_cofc";
            this.ctl_has_cofc.Size = new System.Drawing.Size(82, 18);
            this.ctl_has_cofc.TabIndex = 41;
            this.ctl_has_cofc.UseParentBackColor = false;
            this.ctl_has_cofc.Visible = false;
            this.ctl_has_cofc.zz_CheckValue = false;
            this.ctl_has_cofc.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_has_cofc.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_has_cofc.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_has_cofc.zz_OriginalDesign = false;
            this.ctl_has_cofc.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_line_paid
            // 
            this.ctl_line_paid.BackColor = System.Drawing.Color.Transparent;
            this.ctl_line_paid.Bold = false;
            this.ctl_line_paid.Caption = "Line Paid";
            this.ctl_line_paid.Changed = false;
            this.ctl_line_paid.Location = new System.Drawing.Point(169, 25);
            this.ctl_line_paid.Name = "ctl_line_paid";
            this.ctl_line_paid.Size = new System.Drawing.Size(70, 18);
            this.ctl_line_paid.TabIndex = 40;
            this.ctl_line_paid.UseParentBackColor = false;
            this.ctl_line_paid.Visible = false;
            this.ctl_line_paid.zz_CheckValue = false;
            this.ctl_line_paid.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_line_paid.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_line_paid.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_line_paid.zz_OriginalDesign = false;
            this.ctl_line_paid.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_internalcomment
            // 
            this.ctl_internalcomment.AllCaps = false;
            this.ctl_internalcomment.BackColor = System.Drawing.Color.Transparent;
            this.ctl_internalcomment.Bold = false;
            this.ctl_internalcomment.Caption = "Internal Comment";
            this.ctl_internalcomment.Changed = false;
            this.ctl_internalcomment.IsEmail = false;
            this.ctl_internalcomment.IsURL = false;
            this.ctl_internalcomment.Location = new System.Drawing.Point(393, 420);
            this.ctl_internalcomment.Name = "ctl_internalcomment";
            this.ctl_internalcomment.PasswordChar = '\0';
            this.ctl_internalcomment.Size = new System.Drawing.Size(250, 41);
            this.ctl_internalcomment.TabIndex = 39;
            this.ctl_internalcomment.UseParentBackColor = true;
            this.ctl_internalcomment.zz_Enabled = true;
            this.ctl_internalcomment.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_internalcomment.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_internalcomment.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_internalcomment.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_internalcomment.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_internalcomment.zz_OriginalDesign = true;
            this.ctl_internalcomment.zz_ShowLinkButton = false;
            this.ctl_internalcomment.zz_ShowNeedsSaveColor = true;
            this.ctl_internalcomment.zz_Text = "";
            this.ctl_internalcomment.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_internalcomment.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_internalcomment.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internalcomment.zz_UseGlobalColor = false;
            this.ctl_internalcomment.zz_UseGlobalFont = false;
            // 
            // cmdMarkUp
            // 
            this.cmdMarkUp.BackColor = System.Drawing.Color.GreenYellow;
            this.cmdMarkUp.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMarkUp.Location = new System.Drawing.Point(322, 107);
            this.cmdMarkUp.Name = "cmdMarkUp";
            this.cmdMarkUp.Size = new System.Drawing.Size(68, 24);
            this.cmdMarkUp.TabIndex = 38;
            this.cmdMarkUp.Text = "MarkUp";
            this.cmdMarkUp.UseVisualStyleBackColor = false;
            this.cmdMarkUp.Visible = false;
            this.cmdMarkUp.Click += new System.EventHandler(this.cmdMarkUp_Click);
            // 
            // ctl_unitprice
            // 
            this.ctl_unitprice.BackColor = System.Drawing.Color.Transparent;
            this.ctl_unitprice.Bold = true;
            this.ctl_unitprice.Caption = "Unit Price";
            this.ctl_unitprice.Changed = false;
            this.ctl_unitprice.EditCaption = false;
            this.ctl_unitprice.FullDecimal = true;
            this.ctl_unitprice.Location = new System.Drawing.Point(262, 112);
            this.ctl_unitprice.Name = "ctl_unitprice";
            this.ctl_unitprice.RoundNearestCent = false;
            this.ctl_unitprice.Size = new System.Drawing.Size(125, 43);
            this.ctl_unitprice.TabIndex = 4;
            this.ctl_unitprice.UseParentBackColor = true;
            this.ctl_unitprice.zz_Enabled = true;
            this.ctl_unitprice.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_unitprice.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_unitprice.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_unitprice.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_unitprice.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_unitprice.zz_OriginalDesign = true;
            this.ctl_unitprice.zz_ShowErrorColor = true;
            this.ctl_unitprice.zz_ShowNeedsSaveColor = true;
            this.ctl_unitprice.zz_Text = "";
            this.ctl_unitprice.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_unitprice.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_unitprice.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_unitprice.zz_UseGlobalColor = false;
            this.ctl_unitprice.zz_UseGlobalFont = false;
            // 
            // ctl_quantityfilled
            // 
            this.ctl_quantityfilled.BackColor = System.Drawing.Color.Transparent;
            this.ctl_quantityfilled.Bold = true;
            this.ctl_quantityfilled.Caption = "Quantity Filled";
            this.ctl_quantityfilled.Changed = false;
            this.ctl_quantityfilled.CurrentType = FieldType.Unknown;
            this.ctl_quantityfilled.Location = new System.Drawing.Point(145, 112);
            this.ctl_quantityfilled.Name = "ctl_quantityfilled";
            this.ctl_quantityfilled.Size = new System.Drawing.Size(111, 45);
            this.ctl_quantityfilled.TabIndex = 3;
            this.ctl_quantityfilled.UseParentBackColor = true;
            this.ctl_quantityfilled.zz_Enabled = true;
            this.ctl_quantityfilled.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_quantityfilled.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_quantityfilled.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_quantityfilled.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_quantityfilled.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_quantityfilled.zz_OriginalDesign = true;
            this.ctl_quantityfilled.zz_ShowErrorColor = true;
            this.ctl_quantityfilled.zz_ShowNeedsSaveColor = true;
            this.ctl_quantityfilled.zz_Text = "";
            this.ctl_quantityfilled.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_quantityfilled.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_quantityfilled.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_quantityfilled.zz_UseGlobalColor = false;
            this.ctl_quantityfilled.zz_UseGlobalFont = false;
            // 
            // ctl_quantityordered
            // 
            this.ctl_quantityordered.BackColor = System.Drawing.Color.Transparent;
            this.ctl_quantityordered.Bold = true;
            this.ctl_quantityordered.Caption = "Quantity Ordered";
            this.ctl_quantityordered.Changed = false;
            this.ctl_quantityordered.CurrentType = FieldType.Unknown;
            this.ctl_quantityordered.Location = new System.Drawing.Point(6, 112);
            this.ctl_quantityordered.Name = "ctl_quantityordered";
            this.ctl_quantityordered.Size = new System.Drawing.Size(125, 45);
            this.ctl_quantityordered.TabIndex = 2;
            this.ctl_quantityordered.UseParentBackColor = true;
            this.ctl_quantityordered.zz_Enabled = true;
            this.ctl_quantityordered.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_quantityordered.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_quantityordered.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_quantityordered.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_quantityordered.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_quantityordered.zz_OriginalDesign = true;
            this.ctl_quantityordered.zz_ShowErrorColor = true;
            this.ctl_quantityordered.zz_ShowNeedsSaveColor = true;
            this.ctl_quantityordered.zz_Text = "";
            this.ctl_quantityordered.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_quantityordered.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_quantityordered.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_quantityordered.zz_UseGlobalColor = false;
            this.ctl_quantityordered.zz_UseGlobalFont = false;
            // 
            // ctl_isverified
            // 
            this.ctl_isverified.BackColor = System.Drawing.Color.Transparent;
            this.ctl_isverified.Bold = false;
            this.ctl_isverified.Caption = "Verified";
            this.ctl_isverified.Changed = false;
            this.ctl_isverified.Location = new System.Drawing.Point(169, 6);
            this.ctl_isverified.Name = "ctl_isverified";
            this.ctl_isverified.Size = new System.Drawing.Size(61, 18);
            this.ctl_isverified.TabIndex = 30;
            this.ctl_isverified.UseParentBackColor = true;
            this.ctl_isverified.zz_CheckValue = false;
            this.ctl_isverified.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_isverified.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_isverified.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_isverified.zz_OriginalDesign = false;
            this.ctl_isverified.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_hasbeenpicked
            // 
            this.ctl_hasbeenpicked.BackColor = System.Drawing.Color.Transparent;
            this.ctl_hasbeenpicked.Bold = false;
            this.ctl_hasbeenpicked.Caption = "Purchased";
            this.ctl_hasbeenpicked.Changed = false;
            this.ctl_hasbeenpicked.Location = new System.Drawing.Point(94, 6);
            this.ctl_hasbeenpicked.Name = "ctl_hasbeenpicked";
            this.ctl_hasbeenpicked.Size = new System.Drawing.Size(77, 18);
            this.ctl_hasbeenpicked.TabIndex = 29;
            this.ctl_hasbeenpicked.UseParentBackColor = true;
            this.ctl_hasbeenpicked.zz_CheckValue = false;
            this.ctl_hasbeenpicked.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_hasbeenpicked.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_hasbeenpicked.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_hasbeenpicked.zz_OriginalDesign = false;
            this.ctl_hasbeenpicked.zz_ShowNeedsSaveColor = true;
            // 
            // optMultiSearch
            // 
            this.optMultiSearch.AutoSize = true;
            this.optMultiSearch.Location = new System.Drawing.Point(497, 17);
            this.optMultiSearch.Name = "optMultiSearch";
            this.optMultiSearch.Size = new System.Drawing.Size(81, 17);
            this.optMultiSearch.TabIndex = 37;
            this.optMultiSearch.Text = "MultiSearch";
            this.optMultiSearch.UseVisualStyleBackColor = true;
            // 
            // optPartSearch
            // 
            this.optPartSearch.AutoSize = true;
            this.optPartSearch.Checked = true;
            this.optPartSearch.Location = new System.Drawing.Point(497, 1);
            this.optPartSearch.Name = "optPartSearch";
            this.optPartSearch.Size = new System.Drawing.Size(78, 17);
            this.optPartSearch.TabIndex = 36;
            this.optPartSearch.TabStop = true;
            this.optPartSearch.Text = "PartSearch";
            this.optPartSearch.UseVisualStyleBackColor = true;
            // 
            // cmdPartSearch
            // 
            this.cmdPartSearch.Image = global::RzInterfaceWin.Properties.Resources.ZoomHS;
            this.cmdPartSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPartSearch.Location = new System.Drawing.Point(579, 3);
            this.cmdPartSearch.Name = "cmdPartSearch";
            this.cmdPartSearch.Size = new System.Drawing.Size(64, 29);
            this.cmdPartSearch.TabIndex = 35;
            this.cmdPartSearch.Text = "Search";
            this.cmdPartSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPartSearch.UseVisualStyleBackColor = true;
            this.cmdPartSearch.Click += new System.EventHandler(this.cmdPartSearch_Click);
            // 
            // ctl_mfg_certifications
            // 
            this.ctl_mfg_certifications.BackColor = System.Drawing.Color.Transparent;
            this.ctl_mfg_certifications.Bold = false;
            this.ctl_mfg_certifications.Caption = "MFG Certs";
            this.ctl_mfg_certifications.Changed = false;
            this.ctl_mfg_certifications.Location = new System.Drawing.Point(303, 6);
            this.ctl_mfg_certifications.Name = "ctl_mfg_certifications";
            this.ctl_mfg_certifications.Size = new System.Drawing.Size(76, 18);
            this.ctl_mfg_certifications.TabIndex = 32;
            this.ctl_mfg_certifications.UseParentBackColor = true;
            this.ctl_mfg_certifications.zz_CheckValue = false;
            this.ctl_mfg_certifications.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_mfg_certifications.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_mfg_certifications.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_mfg_certifications.zz_OriginalDesign = false;
            this.ctl_mfg_certifications.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_unit_of_measure
            // 
            this.ctl_unit_of_measure.AllCaps = false;
            this.ctl_unit_of_measure.BackColor = System.Drawing.Color.Transparent;
            this.ctl_unit_of_measure.Bold = false;
            this.ctl_unit_of_measure.Caption = "UOM";
            this.ctl_unit_of_measure.Changed = false;
            this.ctl_unit_of_measure.IsEmail = false;
            this.ctl_unit_of_measure.IsURL = false;
            this.ctl_unit_of_measure.Location = new System.Drawing.Point(393, 65);
            this.ctl_unit_of_measure.Name = "ctl_unit_of_measure";
            this.ctl_unit_of_measure.PasswordChar = '\0';
            this.ctl_unit_of_measure.Size = new System.Drawing.Size(80, 40);
            this.ctl_unit_of_measure.TabIndex = 6;
            this.ctl_unit_of_measure.UseParentBackColor = true;
            this.ctl_unit_of_measure.zz_Enabled = true;
            this.ctl_unit_of_measure.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_unit_of_measure.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_unit_of_measure.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_unit_of_measure.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_unit_of_measure.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_unit_of_measure.zz_OriginalDesign = true;
            this.ctl_unit_of_measure.zz_ShowLinkButton = false;
            this.ctl_unit_of_measure.zz_ShowNeedsSaveColor = true;
            this.ctl_unit_of_measure.zz_Text = "";
            this.ctl_unit_of_measure.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_unit_of_measure.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_unit_of_measure.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_unit_of_measure.zz_UseGlobalColor = false;
            this.ctl_unit_of_measure.zz_UseGlobalFont = false;
            // 
            // gb
            // 
            this.gb.Controls.Add(this.lblOriginalVendor);
            this.gb.Controls.Add(this.lblChooseVendorContact);
            this.gb.Controls.Add(this.ctl_vendorcontactname);
            this.gb.Controls.Add(this.lblChooseVendor);
            this.gb.Controls.Add(this.lblStock);
            this.gb.Controls.Add(this.cmdQuotes);
            this.gb.Controls.Add(this.ctl_unitcost);
            this.gb.Controls.Add(this.buyer);
            this.gb.Controls.Add(this.cStub);
            this.gb.Location = new System.Drawing.Point(10, 282);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(376, 187);
            this.gb.TabIndex = 31;
            this.gb.TabStop = false;
            // 
            // lblOriginalVendor
            // 
            this.lblOriginalVendor.AutoSize = true;
            this.lblOriginalVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOriginalVendor.ForeColor = System.Drawing.Color.Blue;
            this.lblOriginalVendor.Location = new System.Drawing.Point(150, 35);
            this.lblOriginalVendor.Name = "lblOriginalVendor";
            this.lblOriginalVendor.Size = new System.Drawing.Size(88, 13);
            this.lblOriginalVendor.TabIndex = 35;
            this.lblOriginalVendor.Text = "<original vendor>";
            this.lblOriginalVendor.Visible = false;
            // 
            // lblChooseVendorContact
            // 
            this.lblChooseVendorContact.AutoSize = true;
            this.lblChooseVendorContact.Location = new System.Drawing.Point(146, 63);
            this.lblChooseVendorContact.Name = "lblChooseVendorContact";
            this.lblChooseVendorContact.Size = new System.Drawing.Size(102, 13);
            this.lblChooseVendorContact.TabIndex = 34;
            this.lblChooseVendorContact.TabStop = true;
            this.lblChooseVendorContact.Text = "<choose a contact>";
            this.lblChooseVendorContact.Visible = false;
            this.lblChooseVendorContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChooseVendorContact_LinkClicked);
            // 
            // ctl_vendorcontactname
            // 
            this.ctl_vendorcontactname.AllCaps = false;
            this.ctl_vendorcontactname.BackColor = System.Drawing.Color.Transparent;
            this.ctl_vendorcontactname.Bold = false;
            this.ctl_vendorcontactname.Caption = "Contact";
            this.ctl_vendorcontactname.Changed = false;
            this.ctl_vendorcontactname.Enabled = false;
            this.ctl_vendorcontactname.IsEmail = false;
            this.ctl_vendorcontactname.IsURL = false;
            this.ctl_vendorcontactname.Location = new System.Drawing.Point(14, 60);
            this.ctl_vendorcontactname.Name = "ctl_vendorcontactname";
            this.ctl_vendorcontactname.PasswordChar = '\0';
            this.ctl_vendorcontactname.Size = new System.Drawing.Size(231, 46);
            this.ctl_vendorcontactname.TabIndex = 33;
            this.ctl_vendorcontactname.UseParentBackColor = false;
            this.ctl_vendorcontactname.Visible = false;
            this.ctl_vendorcontactname.zz_Enabled = true;
            this.ctl_vendorcontactname.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_vendorcontactname.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_vendorcontactname.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_vendorcontactname.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_vendorcontactname.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_vendorcontactname.zz_OriginalDesign = true;
            this.ctl_vendorcontactname.zz_ShowLinkButton = false;
            this.ctl_vendorcontactname.zz_ShowNeedsSaveColor = true;
            this.ctl_vendorcontactname.zz_Text = "";
            this.ctl_vendorcontactname.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_vendorcontactname.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_vendorcontactname.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_vendorcontactname.zz_UseGlobalColor = false;
            this.ctl_vendorcontactname.zz_UseGlobalFont = false;
            // 
            // lblChooseVendor
            // 
            this.lblChooseVendor.AutoSize = true;
            this.lblChooseVendor.Location = new System.Drawing.Point(150, 16);
            this.lblChooseVendor.Name = "lblChooseVendor";
            this.lblChooseVendor.Size = new System.Drawing.Size(99, 13);
            this.lblChooseVendor.TabIndex = 32;
            this.lblChooseVendor.TabStop = true;
            this.lblChooseVendor.Text = "<choose a vendor>";
            this.lblChooseVendor.Visible = false;
            this.lblChooseVendor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChooseVendor_LinkClicked);
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Arial Black", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.ForeColor = System.Drawing.Color.Blue;
            this.lblStock.Location = new System.Drawing.Point(6, 9);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(145, 45);
            this.lblStock.TabIndex = 31;
            this.lblStock.Text = "STOCK";
            this.lblStock.Visible = false;
            // 
            // cmdQuotes
            // 
            this.cmdQuotes.Location = new System.Drawing.Point(253, 127);
            this.cmdQuotes.Name = "cmdQuotes";
            this.cmdQuotes.Size = new System.Drawing.Size(117, 21);
            this.cmdQuotes.TabIndex = 30;
            this.cmdQuotes.Text = "Quotes";
            this.cmdQuotes.UseVisualStyleBackColor = true;
            this.cmdQuotes.Click += new System.EventHandler(this.cmdQuotes_Click);
            // 
            // ctl_unitcost
            // 
            this.ctl_unitcost.BackColor = System.Drawing.Color.Transparent;
            this.ctl_unitcost.Bold = true;
            this.ctl_unitcost.Caption = "Cost";
            this.ctl_unitcost.Changed = false;
            this.ctl_unitcost.EditCaption = false;
            this.ctl_unitcost.FullDecimal = true;
            this.ctl_unitcost.Location = new System.Drawing.Point(253, 75);
            this.ctl_unitcost.Name = "ctl_unitcost";
            this.ctl_unitcost.RoundNearestCent = false;
            this.ctl_unitcost.Size = new System.Drawing.Size(117, 46);
            this.ctl_unitcost.TabIndex = 29;
            this.ctl_unitcost.UseParentBackColor = true;
            this.ctl_unitcost.zz_Enabled = true;
            this.ctl_unitcost.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_unitcost.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_unitcost.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_unitcost.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_unitcost.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_unitcost.zz_OriginalDesign = true;
            this.ctl_unitcost.zz_ShowErrorColor = true;
            this.ctl_unitcost.zz_ShowNeedsSaveColor = true;
            this.ctl_unitcost.zz_Text = "";
            this.ctl_unitcost.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_unitcost.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_unitcost.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_unitcost.zz_UseGlobalColor = false;
            this.ctl_unitcost.zz_UseGlobalFont = false;
            // 
            // buyer
            // 
            this.buyer.AllowChange = true;
            this.buyer.AllowClear = false;
            this.buyer.AllowNew = false;
            this.buyer.AllowView = false;
            this.buyer.BackColor = System.Drawing.Color.Transparent;
            this.buyer.Bold = false;
            this.buyer.Caption = "Buyer";
            this.buyer.Changed = false;
            this.buyer.Location = new System.Drawing.Point(6, 103);
            this.buyer.Name = "buyer";
            this.buyer.Size = new System.Drawing.Size(242, 62);
            this.buyer.TabIndex = 28;
            this.buyer.UseParentBackColor = true;
            this.buyer.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.buyer.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            // 
            // cStub
            // 
            this.cStub.Caption = "Vendor";
            this.cStub.Location = new System.Drawing.Point(6, 9);
            this.cStub.Name = "cStub";
            this.cStub.Size = new System.Drawing.Size(364, 56);
            this.cStub.TabIndex = 27;
            this.cStub.ChangeCompany += new Rz5.ContactEventHandler(this.cStub_ChangeCompany);
            this.cStub.ClearCompany += new Rz5.ContactEventHandler(this.cStub_ClearCompany);
            this.cStub.ClearCompanyFinished += new Rz5.ContactEventHandler(this.cStub_ClearCompanyFinished);
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
            this.ctl_packaging.Location = new System.Drawing.Point(506, 378);
            this.ctl_packaging.Name = "ctl_packaging";
            this.ctl_packaging.SimpleList = null;
            this.ctl_packaging.Size = new System.Drawing.Size(137, 42);
            this.ctl_packaging.TabIndex = 26;
            this.ctl_packaging.UseParentBackColor = true;
            this.ctl_packaging.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_packaging.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_packaging.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_packaging.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_packaging.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_packaging.zz_OriginalDesign = true;
            this.ctl_packaging.zz_ShowNeedsSaveColor = true;
            this.ctl_packaging.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_packaging.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_packaging.zz_UseGlobalColor = false;
            this.ctl_packaging.zz_UseGlobalFont = false;
            // 
            // ctl_category
            // 
            this.ctl_category.AllCaps = false;
            this.ctl_category.AllowEdit = false;
            this.ctl_category.BackColor = System.Drawing.Color.Transparent;
            this.ctl_category.Bold = false;
            this.ctl_category.Caption = "Category";
            this.ctl_category.Changed = false;
            this.ctl_category.ListName = "partsetup";
            this.ctl_category.Location = new System.Drawing.Point(393, 382);
            this.ctl_category.Name = "ctl_category";
            this.ctl_category.SimpleList = null;
            this.ctl_category.Size = new System.Drawing.Size(107, 36);
            this.ctl_category.TabIndex = 25;
            this.ctl_category.UseParentBackColor = true;
            this.ctl_category.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_category.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_category.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_category.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_category.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_category.zz_OriginalDesign = false;
            this.ctl_category.zz_ShowNeedsSaveColor = true;
            this.ctl_category.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_category.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_category.zz_UseGlobalColor = false;
            this.ctl_category.zz_UseGlobalFont = false;
            // 
            // ctl_lotnumber
            // 
            this.ctl_lotnumber.AllCaps = false;
            this.ctl_lotnumber.BackColor = System.Drawing.Color.Transparent;
            this.ctl_lotnumber.Bold = false;
            this.ctl_lotnumber.Caption = "Lot #";
            this.ctl_lotnumber.Changed = false;
            this.ctl_lotnumber.IsEmail = false;
            this.ctl_lotnumber.IsURL = false;
            this.ctl_lotnumber.Location = new System.Drawing.Point(592, 247);
            this.ctl_lotnumber.Name = "ctl_lotnumber";
            this.ctl_lotnumber.PasswordChar = '\0';
            this.ctl_lotnumber.Size = new System.Drawing.Size(51, 47);
            this.ctl_lotnumber.TabIndex = 22;
            this.ctl_lotnumber.UseParentBackColor = true;
            this.ctl_lotnumber.zz_Enabled = true;
            this.ctl_lotnumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_lotnumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_lotnumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_lotnumber.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_lotnumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_lotnumber.zz_OriginalDesign = true;
            this.ctl_lotnumber.zz_ShowLinkButton = false;
            this.ctl_lotnumber.zz_ShowNeedsSaveColor = true;
            this.ctl_lotnumber.zz_Text = "";
            this.ctl_lotnumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_lotnumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_lotnumber.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_lotnumber.zz_UseGlobalColor = false;
            this.ctl_lotnumber.zz_UseGlobalFont = false;
            // 
            // ctl_country
            // 
            this.ctl_country.AllCaps = false;
            this.ctl_country.BackColor = System.Drawing.Color.Transparent;
            this.ctl_country.Bold = false;
            this.ctl_country.Caption = "Country";
            this.ctl_country.Changed = false;
            this.ctl_country.IsEmail = false;
            this.ctl_country.IsURL = false;
            this.ctl_country.Location = new System.Drawing.Point(393, 336);
            this.ctl_country.Name = "ctl_country";
            this.ctl_country.PasswordChar = '\0';
            this.ctl_country.Size = new System.Drawing.Size(107, 41);
            this.ctl_country.TabIndex = 23;
            this.ctl_country.UseParentBackColor = true;
            this.ctl_country.zz_Enabled = true;
            this.ctl_country.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_country.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_country.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_country.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_country.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_country.zz_OriginalDesign = true;
            this.ctl_country.zz_ShowLinkButton = false;
            this.ctl_country.zz_ShowNeedsSaveColor = true;
            this.ctl_country.zz_Text = "";
            this.ctl_country.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_country.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_country.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_country.zz_UseGlobalColor = false;
            this.ctl_country.zz_UseGlobalFont = false;
            // 
            // ctl_partsetup
            // 
            this.ctl_partsetup.AllCaps = false;
            this.ctl_partsetup.AllowEdit = false;
            this.ctl_partsetup.BackColor = System.Drawing.Color.Transparent;
            this.ctl_partsetup.Bold = false;
            this.ctl_partsetup.Caption = "Part Setup";
            this.ctl_partsetup.Changed = true;
            this.ctl_partsetup.ListName = "partsetup";
            this.ctl_partsetup.Location = new System.Drawing.Point(504, 336);
            this.ctl_partsetup.Name = "ctl_partsetup";
            this.ctl_partsetup.SimpleList = null;
            this.ctl_partsetup.Size = new System.Drawing.Size(139, 42);
            this.ctl_partsetup.TabIndex = 24;
            this.ctl_partsetup.UseParentBackColor = true;
            this.ctl_partsetup.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_partsetup.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_partsetup.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_partsetup.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_partsetup.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_partsetup.zz_OriginalDesign = true;
            this.ctl_partsetup.zz_ShowNeedsSaveColor = true;
            this.ctl_partsetup.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_partsetup.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_partsetup.zz_UseGlobalColor = false;
            this.ctl_partsetup.zz_UseGlobalFont = false;
            // 
            // ctl_partsperpack
            // 
            this.ctl_partsperpack.BackColor = System.Drawing.Color.Transparent;
            this.ctl_partsperpack.Bold = false;
            this.ctl_partsperpack.Caption = "PPK";
            this.ctl_partsperpack.Changed = false;
            this.ctl_partsperpack.CurrentType = FieldType.Unknown;
            this.ctl_partsperpack.Location = new System.Drawing.Point(521, 247);
            this.ctl_partsperpack.Name = "ctl_partsperpack";
            this.ctl_partsperpack.Size = new System.Drawing.Size(51, 45);
            this.ctl_partsperpack.TabIndex = 20;
            this.ctl_partsperpack.UseParentBackColor = true;
            this.ctl_partsperpack.zz_Enabled = true;
            this.ctl_partsperpack.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_partsperpack.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_partsperpack.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_partsperpack.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_partsperpack.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_partsperpack.zz_OriginalDesign = true;
            this.ctl_partsperpack.zz_ShowErrorColor = true;
            this.ctl_partsperpack.zz_ShowNeedsSaveColor = true;
            this.ctl_partsperpack.zz_Text = "";
            this.ctl_partsperpack.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_partsperpack.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_partsperpack.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_partsperpack.zz_UseGlobalColor = false;
            this.ctl_partsperpack.zz_UseGlobalFont = false;
            // 
            // ctl_shipdate
            // 
            this.ctl_shipdate.AllowClear = false;
            this.ctl_shipdate.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shipdate.Bold = false;
            this.ctl_shipdate.Caption = "Ship Date";
            this.ctl_shipdate.Changed = false;
            this.ctl_shipdate.Location = new System.Drawing.Point(393, 295);
            this.ctl_shipdate.Name = "ctl_shipdate";
            this.ctl_shipdate.Size = new System.Drawing.Size(164, 42);
            this.ctl_shipdate.SuppressEdit = false;
            this.ctl_shipdate.TabIndex = 21;
            this.ctl_shipdate.UseParentBackColor = true;
            this.ctl_shipdate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shipdate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_shipdate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shipdate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_shipdate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_shipdate.zz_OriginalDesign = true;
            this.ctl_shipdate.zz_ShowNeedsSaveColor = true;
            this.ctl_shipdate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shipdate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shipdate.zz_UseGlobalColor = false;
            this.ctl_shipdate.zz_UseGlobalFont = false;
            // 
            // ctl_requireddate
            // 
            this.ctl_requireddate.AllowClear = false;
            this.ctl_requireddate.BackColor = System.Drawing.Color.Transparent;
            this.ctl_requireddate.Bold = false;
            this.ctl_requireddate.Caption = "Required Date";
            this.ctl_requireddate.Changed = false;
            this.ctl_requireddate.Location = new System.Drawing.Point(393, 247);
            this.ctl_requireddate.Name = "ctl_requireddate";
            this.ctl_requireddate.Size = new System.Drawing.Size(164, 42);
            this.ctl_requireddate.SuppressEdit = false;
            this.ctl_requireddate.TabIndex = 19;
            this.ctl_requireddate.UseParentBackColor = true;
            this.ctl_requireddate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_requireddate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_requireddate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_requireddate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_requireddate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_requireddate.zz_OriginalDesign = true;
            this.ctl_requireddate.zz_ShowNeedsSaveColor = true;
            this.ctl_requireddate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_requireddate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_requireddate.zz_UseGlobalColor = false;
            this.ctl_requireddate.zz_UseGlobalFont = false;
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
            this.ctl_alternatepart.Location = new System.Drawing.Point(8, 198);
            this.ctl_alternatepart.Name = "ctl_alternatepart";
            this.ctl_alternatepart.PasswordChar = '\0';
            this.ctl_alternatepart.Size = new System.Drawing.Size(380, 41);
            this.ctl_alternatepart.TabIndex = 16;
            this.ctl_alternatepart.UseParentBackColor = true;
            this.ctl_alternatepart.zz_Enabled = true;
            this.ctl_alternatepart.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_alternatepart.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_alternatepart.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_alternatepart.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_alternatepart.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_alternatepart.zz_OriginalDesign = true;
            this.ctl_alternatepart.zz_ShowLinkButton = false;
            this.ctl_alternatepart.zz_ShowNeedsSaveColor = true;
            this.ctl_alternatepart.zz_Text = "";
            this.ctl_alternatepart.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_alternatepart.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_alternatepart.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_alternatepart.zz_UseGlobalColor = false;
            this.ctl_alternatepart.zz_UseGlobalFont = false;
            // 
            // ctl_location
            // 
            this.ctl_location.AllCaps = false;
            this.ctl_location.BackColor = System.Drawing.Color.Transparent;
            this.ctl_location.Bold = false;
            this.ctl_location.Caption = "Location";
            this.ctl_location.Changed = false;
            this.ctl_location.IsEmail = false;
            this.ctl_location.IsURL = false;
            this.ctl_location.Location = new System.Drawing.Point(393, 158);
            this.ctl_location.Name = "ctl_location";
            this.ctl_location.PasswordChar = '\0';
            this.ctl_location.Size = new System.Drawing.Size(122, 42);
            this.ctl_location.TabIndex = 13;
            this.ctl_location.UseParentBackColor = true;
            this.ctl_location.zz_Enabled = true;
            this.ctl_location.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_location.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_location.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_location.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_location.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_location.zz_OriginalDesign = true;
            this.ctl_location.zz_ShowLinkButton = false;
            this.ctl_location.zz_ShowNeedsSaveColor = true;
            this.ctl_location.zz_Text = "";
            this.ctl_location.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_location.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_location.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_location.zz_UseGlobalColor = false;
            this.ctl_location.zz_UseGlobalFont = false;
            // 
            // ctl_quantitypurchased
            // 
            this.ctl_quantitypurchased.BackColor = System.Drawing.Color.Transparent;
            this.ctl_quantitypurchased.Bold = false;
            this.ctl_quantitypurchased.Caption = "Purchase Ref.";
            this.ctl_quantitypurchased.Changed = false;
            this.ctl_quantitypurchased.CurrentType = FieldType.Unknown;
            this.ctl_quantitypurchased.Location = new System.Drawing.Point(521, 112);
            this.ctl_quantitypurchased.Name = "ctl_quantitypurchased";
            this.ctl_quantitypurchased.Size = new System.Drawing.Size(122, 45);
            this.ctl_quantitypurchased.TabIndex = 10;
            this.ctl_quantitypurchased.UseParentBackColor = true;
            this.ctl_quantitypurchased.zz_Enabled = true;
            this.ctl_quantitypurchased.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_quantitypurchased.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_quantitypurchased.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_quantitypurchased.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_quantitypurchased.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_quantitypurchased.zz_OriginalDesign = true;
            this.ctl_quantitypurchased.zz_ShowErrorColor = true;
            this.ctl_quantitypurchased.zz_ShowNeedsSaveColor = true;
            this.ctl_quantitypurchased.zz_Text = "";
            this.ctl_quantitypurchased.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_quantitypurchased.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_quantitypurchased.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_quantitypurchased.zz_UseGlobalColor = false;
            this.ctl_quantitypurchased.zz_UseGlobalFont = false;
            // 
            // ctl_alternatepart_02
            // 
            this.ctl_alternatepart_02.AllCaps = false;
            this.ctl_alternatepart_02.BackColor = System.Drawing.Color.Transparent;
            this.ctl_alternatepart_02.Bold = false;
            this.ctl_alternatepart_02.Caption = "QB Part #";
            this.ctl_alternatepart_02.Changed = false;
            this.ctl_alternatepart_02.IsEmail = false;
            this.ctl_alternatepart_02.IsURL = false;
            this.ctl_alternatepart_02.Location = new System.Drawing.Point(145, 157);
            this.ctl_alternatepart_02.Name = "ctl_alternatepart_02";
            this.ctl_alternatepart_02.PasswordChar = '\0';
            this.ctl_alternatepart_02.Size = new System.Drawing.Size(242, 50);
            this.ctl_alternatepart_02.TabIndex = 12;
            this.ctl_alternatepart_02.UseParentBackColor = true;
            this.ctl_alternatepart_02.zz_Enabled = true;
            this.ctl_alternatepart_02.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_alternatepart_02.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_alternatepart_02.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_alternatepart_02.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_alternatepart_02.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_alternatepart_02.zz_OriginalDesign = true;
            this.ctl_alternatepart_02.zz_ShowLinkButton = false;
            this.ctl_alternatepart_02.zz_ShowNeedsSaveColor = true;
            this.ctl_alternatepart_02.zz_Text = "";
            this.ctl_alternatepart_02.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_alternatepart_02.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_alternatepart_02.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_alternatepart_02.zz_UseGlobalColor = false;
            this.ctl_alternatepart_02.zz_UseGlobalFont = false;
            // 
            // ctl_quantitybacked
            // 
            this.ctl_quantitybacked.BackColor = System.Drawing.Color.Transparent;
            this.ctl_quantitybacked.Bold = false;
            this.ctl_quantitybacked.Caption = "Backordered";
            this.ctl_quantitybacked.Changed = false;
            this.ctl_quantitybacked.CurrentType = FieldType.Unknown;
            this.ctl_quantitybacked.Location = new System.Drawing.Point(563, 65);
            this.ctl_quantitybacked.Name = "ctl_quantitybacked";
            this.ctl_quantitybacked.Size = new System.Drawing.Size(80, 41);
            this.ctl_quantitybacked.TabIndex = 8;
            this.ctl_quantitybacked.UseParentBackColor = true;
            this.ctl_quantitybacked.zz_Enabled = true;
            this.ctl_quantitybacked.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_quantitybacked.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_quantitybacked.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_quantitybacked.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_quantitybacked.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_quantitybacked.zz_OriginalDesign = true;
            this.ctl_quantitybacked.zz_ShowErrorColor = true;
            this.ctl_quantitybacked.zz_ShowNeedsSaveColor = true;
            this.ctl_quantitybacked.zz_Text = "";
            this.ctl_quantitybacked.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_quantitybacked.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_quantitybacked.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_quantitybacked.zz_UseGlobalColor = false;
            this.ctl_quantitybacked.zz_UseGlobalFont = false;
            // 
            // ctl_quantitycancelled
            // 
            this.ctl_quantitycancelled.BackColor = System.Drawing.Color.Transparent;
            this.ctl_quantitycancelled.Bold = false;
            this.ctl_quantitycancelled.Caption = "Cancelled";
            this.ctl_quantitycancelled.Changed = false;
            this.ctl_quantitycancelled.CurrentType = FieldType.Unknown;
            this.ctl_quantitycancelled.Location = new System.Drawing.Point(479, 65);
            this.ctl_quantitycancelled.Name = "ctl_quantitycancelled";
            this.ctl_quantitycancelled.Size = new System.Drawing.Size(80, 41);
            this.ctl_quantitycancelled.TabIndex = 7;
            this.ctl_quantitycancelled.UseParentBackColor = true;
            this.ctl_quantitycancelled.zz_Enabled = true;
            this.ctl_quantitycancelled.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_quantitycancelled.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_quantitycancelled.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_quantitycancelled.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_quantitycancelled.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_quantitycancelled.zz_OriginalDesign = true;
            this.ctl_quantitycancelled.zz_ShowErrorColor = true;
            this.ctl_quantitycancelled.zz_ShowNeedsSaveColor = true;
            this.ctl_quantitycancelled.zz_Text = "";
            this.ctl_quantitycancelled.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_quantitycancelled.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_quantitycancelled.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_quantitycancelled.zz_UseGlobalColor = false;
            this.ctl_quantitycancelled.zz_UseGlobalFont = false;
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
            this.ctl_description.Location = new System.Drawing.Point(8, 242);
            this.ctl_description.Name = "ctl_description";
            this.ctl_description.PasswordChar = '\0';
            this.ctl_description.Size = new System.Drawing.Size(379, 41);
            this.ctl_description.TabIndex = 18;
            this.ctl_description.UseParentBackColor = true;
            this.ctl_description.zz_Enabled = true;
            this.ctl_description.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_description.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_description.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_description.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
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
            this.ctl_description.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ctl_description_KeyUp);
            // 
            // ctl_internalpartnumber
            // 
            this.ctl_internalpartnumber.AllCaps = false;
            this.ctl_internalpartnumber.BackColor = System.Drawing.Color.Transparent;
            this.ctl_internalpartnumber.Bold = false;
            this.ctl_internalpartnumber.Caption = "Internal Part";
            this.ctl_internalpartnumber.Changed = false;
            this.ctl_internalpartnumber.IsEmail = false;
            this.ctl_internalpartnumber.IsURL = false;
            this.ctl_internalpartnumber.Location = new System.Drawing.Point(393, 198);
            this.ctl_internalpartnumber.Name = "ctl_internalpartnumber";
            this.ctl_internalpartnumber.PasswordChar = '\0';
            this.ctl_internalpartnumber.Size = new System.Drawing.Size(251, 41);
            this.ctl_internalpartnumber.TabIndex = 17;
            this.ctl_internalpartnumber.UseParentBackColor = true;
            this.ctl_internalpartnumber.zz_Enabled = true;
            this.ctl_internalpartnumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_internalpartnumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_internalpartnumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_internalpartnumber.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_internalpartnumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_internalpartnumber.zz_OriginalDesign = true;
            this.ctl_internalpartnumber.zz_ShowLinkButton = false;
            this.ctl_internalpartnumber.zz_ShowNeedsSaveColor = true;
            this.ctl_internalpartnumber.zz_Text = "";
            this.ctl_internalpartnumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_internalpartnumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_internalpartnumber.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internalpartnumber.zz_UseGlobalColor = false;
            this.ctl_internalpartnumber.zz_UseGlobalFont = false;
            // 
            // ctl_condition
            // 
            this.ctl_condition.AllCaps = false;
            this.ctl_condition.AllowEdit = false;
            this.ctl_condition.BackColor = System.Drawing.Color.Transparent;
            this.ctl_condition.Bold = false;
            this.ctl_condition.Caption = "Condition";
            this.ctl_condition.Changed = true;
            this.ctl_condition.ListName = "condition";
            this.ctl_condition.Location = new System.Drawing.Point(393, 112);
            this.ctl_condition.Name = "ctl_condition";
            this.ctl_condition.SimpleList = null;
            this.ctl_condition.Size = new System.Drawing.Size(123, 49);
            this.ctl_condition.TabIndex = 9;
            this.ctl_condition.UseParentBackColor = true;
            this.ctl_condition.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_condition.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_condition.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_condition.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_condition.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_condition.zz_OriginalDesign = true;
            this.ctl_condition.zz_ShowNeedsSaveColor = true;
            this.ctl_condition.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_condition.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_condition.zz_UseGlobalColor = false;
            this.ctl_condition.zz_UseGlobalFont = false;
            // 
            // ctl_minimumquantity
            // 
            this.ctl_minimumquantity.BackColor = System.Drawing.Color.Transparent;
            this.ctl_minimumquantity.Bold = false;
            this.ctl_minimumquantity.Caption = "Min Qty";
            this.ctl_minimumquantity.Changed = false;
            this.ctl_minimumquantity.CurrentType = FieldType.Unknown;
            this.ctl_minimumquantity.Location = new System.Drawing.Point(8, 157);
            this.ctl_minimumquantity.Name = "ctl_minimumquantity";
            this.ctl_minimumquantity.Size = new System.Drawing.Size(123, 41);
            this.ctl_minimumquantity.TabIndex = 11;
            this.ctl_minimumquantity.UseParentBackColor = true;
            this.ctl_minimumquantity.zz_Enabled = true;
            this.ctl_minimumquantity.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_minimumquantity.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_minimumquantity.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_minimumquantity.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_minimumquantity.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_minimumquantity.zz_OriginalDesign = true;
            this.ctl_minimumquantity.zz_ShowErrorColor = true;
            this.ctl_minimumquantity.zz_ShowNeedsSaveColor = true;
            this.ctl_minimumquantity.zz_Text = "";
            this.ctl_minimumquantity.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_minimumquantity.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_minimumquantity.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_minimumquantity.zz_UseGlobalColor = false;
            this.ctl_minimumquantity.zz_UseGlobalFont = false;
            // 
            // ctl_datecode
            // 
            this.ctl_datecode.AllCaps = false;
            this.ctl_datecode.BackColor = System.Drawing.Color.Transparent;
            this.ctl_datecode.Bold = false;
            this.ctl_datecode.Caption = "Date Code";
            this.ctl_datecode.Changed = false;
            this.ctl_datecode.IsEmail = false;
            this.ctl_datecode.IsURL = false;
            this.ctl_datecode.Location = new System.Drawing.Point(262, 65);
            this.ctl_datecode.Name = "ctl_datecode";
            this.ctl_datecode.PasswordChar = '\0';
            this.ctl_datecode.Size = new System.Drawing.Size(125, 40);
            this.ctl_datecode.TabIndex = 5;
            this.ctl_datecode.UseParentBackColor = true;
            this.ctl_datecode.zz_Enabled = true;
            this.ctl_datecode.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_datecode.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_datecode.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_datecode.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_datecode.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_datecode.zz_OriginalDesign = true;
            this.ctl_datecode.zz_ShowLinkButton = false;
            this.ctl_datecode.zz_ShowNeedsSaveColor = true;
            this.ctl_datecode.zz_Text = "";
            this.ctl_datecode.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_datecode.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_datecode.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_datecode.zz_UseGlobalColor = false;
            this.ctl_datecode.zz_UseGlobalFont = false;
            // 
            // ctl_manufacturer
            // 
            this.ctl_manufacturer.AllCaps = false;
            this.ctl_manufacturer.BackColor = System.Drawing.Color.Transparent;
            this.ctl_manufacturer.Bold = false;
            this.ctl_manufacturer.Caption = "Manufacturer";
            this.ctl_manufacturer.Changed = false;
            this.ctl_manufacturer.IsEmail = false;
            this.ctl_manufacturer.IsURL = false;
            this.ctl_manufacturer.Location = new System.Drawing.Point(6, 65);
            this.ctl_manufacturer.Name = "ctl_manufacturer";
            this.ctl_manufacturer.PasswordChar = '\0';
            this.ctl_manufacturer.Size = new System.Drawing.Size(242, 41);
            this.ctl_manufacturer.TabIndex = 1;
            this.ctl_manufacturer.UseParentBackColor = true;
            this.ctl_manufacturer.zz_Enabled = true;
            this.ctl_manufacturer.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_manufacturer.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_manufacturer.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_manufacturer.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_manufacturer.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_manufacturer.zz_OriginalDesign = true;
            this.ctl_manufacturer.zz_ShowLinkButton = false;
            this.ctl_manufacturer.zz_ShowNeedsSaveColor = true;
            this.ctl_manufacturer.zz_Text = "";
            this.ctl_manufacturer.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_manufacturer.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_manufacturer.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_manufacturer.zz_UseGlobalColor = false;
            this.ctl_manufacturer.zz_UseGlobalFont = false;
            this.ctl_manufacturer.Load += new System.EventHandler(this.ctl_manufacturer_Load);
            // 
            // ctl_isselected
            // 
            this.ctl_isselected.BackColor = System.Drawing.Color.Transparent;
            this.ctl_isselected.Bold = false;
            this.ctl_isselected.Caption = "Selected";
            this.ctl_isselected.Changed = false;
            this.ctl_isselected.Location = new System.Drawing.Point(232, 6);
            this.ctl_isselected.Name = "ctl_isselected";
            this.ctl_isselected.Size = new System.Drawing.Size(68, 18);
            this.ctl_isselected.TabIndex = 31;
            this.ctl_isselected.UseParentBackColor = true;
            this.ctl_isselected.zz_CheckValue = false;
            this.ctl_isselected.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_isselected.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_isselected.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_isselected.zz_OriginalDesign = false;
            this.ctl_isselected.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_fullpartnumber
            // 
            this.ctl_fullpartnumber.AllCaps = false;
            this.ctl_fullpartnumber.BackColor = System.Drawing.Color.Transparent;
            this.ctl_fullpartnumber.Bold = true;
            this.ctl_fullpartnumber.Caption = "Part Number";
            this.ctl_fullpartnumber.Changed = false;
            this.ctl_fullpartnumber.IsEmail = false;
            this.ctl_fullpartnumber.IsURL = false;
            this.ctl_fullpartnumber.Location = new System.Drawing.Point(6, 25);
            this.ctl_fullpartnumber.Name = "ctl_fullpartnumber";
            this.ctl_fullpartnumber.PasswordChar = '\0';
            this.ctl_fullpartnumber.Size = new System.Drawing.Size(637, 40);
            this.ctl_fullpartnumber.TabIndex = 0;
            this.ctl_fullpartnumber.UseParentBackColor = true;
            this.ctl_fullpartnumber.zz_Enabled = true;
            this.ctl_fullpartnumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_fullpartnumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_fullpartnumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_fullpartnumber.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_fullpartnumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_fullpartnumber.zz_OriginalDesign = true;
            this.ctl_fullpartnumber.zz_ShowLinkButton = false;
            this.ctl_fullpartnumber.zz_ShowNeedsSaveColor = true;
            this.ctl_fullpartnumber.zz_Text = "";
            this.ctl_fullpartnumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_fullpartnumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_fullpartnumber.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_fullpartnumber.zz_UseGlobalColor = false;
            this.ctl_fullpartnumber.zz_UseGlobalFont = false;
            this.ctl_fullpartnumber.DataChanged += new NewMethod.ChangeHandler(this.ctl_fullpartnumber_DataChanged);
            // 
            // pageOther
            // 
            this.pageOther.Controls.Add(this.ctl_invoice_date);
            this.pageOther.Controls.Add(this.lvQualityControl);
            this.pageOther.Controls.Add(this.ctl_buytype);
            this.pageOther.Controls.Add(this.ctl_freightcost);
            this.pageOther.Controls.Add(this.ctl_servicecost);
            this.pageOther.Controls.Add(this.ctl_alternatepart_04);
            this.pageOther.Controls.Add(this.ctl_alternatepart_03);
            this.pageOther.Controls.Add(this.ctl_alternatepart_01);
            this.pageOther.Controls.Add(this.agent);
            this.pageOther.Location = new System.Drawing.Point(4, 22);
            this.pageOther.Name = "pageOther";
            this.pageOther.Padding = new System.Windows.Forms.Padding(3);
            this.pageOther.Size = new System.Drawing.Size(649, 474);
            this.pageOther.TabIndex = 2;
            this.pageOther.Text = "Other";
            this.pageOther.UseVisualStyleBackColor = true;
            // 
            // ctl_invoice_date
            // 
            this.ctl_invoice_date.AllowClear = false;
            this.ctl_invoice_date.BackColor = System.Drawing.Color.Transparent;
            this.ctl_invoice_date.Bold = false;
            this.ctl_invoice_date.Caption = "Invoice Date";
            this.ctl_invoice_date.Changed = false;
            this.ctl_invoice_date.Location = new System.Drawing.Point(219, 17);
            this.ctl_invoice_date.Name = "ctl_invoice_date";
            this.ctl_invoice_date.Size = new System.Drawing.Size(164, 42);
            this.ctl_invoice_date.SuppressEdit = false;
            this.ctl_invoice_date.TabIndex = 42;
            this.ctl_invoice_date.UseParentBackColor = true;
            this.ctl_invoice_date.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_invoice_date.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_invoice_date.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_invoice_date.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_invoice_date.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_invoice_date.zz_OriginalDesign = true;
            this.ctl_invoice_date.zz_ShowNeedsSaveColor = true;
            this.ctl_invoice_date.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_invoice_date.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_invoice_date.zz_UseGlobalColor = false;
            this.ctl_invoice_date.zz_UseGlobalFont = false;
            // 
            // lvQualityControl
            // 
            this.lvQualityControl.AddCaption = "Add New";
            this.lvQualityControl.AllowActions = true;
            this.lvQualityControl.AllowAdd = false;
            this.lvQualityControl.AllowDelete = true;
            this.lvQualityControl.AllowDeleteAlways = false;
            this.lvQualityControl.AllowDrop = true;
            this.lvQualityControl.AlternateConnection = null;
            this.lvQualityControl.Caption = "";
            this.lvQualityControl.CurrentTemplate = null;
            this.lvQualityControl.ExtraClassInfo = "";
            this.lvQualityControl.Location = new System.Drawing.Point(7, 248);
            this.lvQualityControl.MultiSelect = true;
            this.lvQualityControl.Name = "lvQualityControl";
            this.lvQualityControl.Size = new System.Drawing.Size(636, 220);
            this.lvQualityControl.SuppressSelectionChanged = false;
            this.lvQualityControl.TabIndex = 41;
            this.lvQualityControl.Visible = false;
            this.lvQualityControl.zz_OpenColumnMenu = false;
            this.lvQualityControl.zz_ShowAutoRefresh = false;
            this.lvQualityControl.zz_ShowUnlimited = false;
            this.lvQualityControl.AboutToThrow += new Core.ShowHandler(this.lvQualityControl_AboutToThrow);
            // 
            // ctl_buytype
            // 
            this.ctl_buytype.AllCaps = false;
            this.ctl_buytype.BackColor = System.Drawing.Color.Transparent;
            this.ctl_buytype.Bold = false;
            this.ctl_buytype.Caption = "Buy Type";
            this.ctl_buytype.Changed = false;
            this.ctl_buytype.IsEmail = false;
            this.ctl_buytype.IsURL = false;
            this.ctl_buytype.Location = new System.Drawing.Point(6, 170);
            this.ctl_buytype.Name = "ctl_buytype";
            this.ctl_buytype.PasswordChar = '\0';
            this.ctl_buytype.Size = new System.Drawing.Size(637, 35);
            this.ctl_buytype.TabIndex = 40;
            this.ctl_buytype.UseParentBackColor = true;
            this.ctl_buytype.zz_Enabled = true;
            this.ctl_buytype.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_buytype.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_buytype.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_buytype.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_buytype.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_buytype.zz_OriginalDesign = false;
            this.ctl_buytype.zz_ShowLinkButton = false;
            this.ctl_buytype.zz_ShowNeedsSaveColor = true;
            this.ctl_buytype.zz_Text = "";
            this.ctl_buytype.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_buytype.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_buytype.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_buytype.zz_UseGlobalColor = false;
            this.ctl_buytype.zz_UseGlobalFont = false;
            // 
            // ctl_freightcost
            // 
            this.ctl_freightcost.BackColor = System.Drawing.Color.Transparent;
            this.ctl_freightcost.Bold = false;
            this.ctl_freightcost.Caption = "Freight Cost";
            this.ctl_freightcost.Changed = false;
            this.ctl_freightcost.EditCaption = false;
            this.ctl_freightcost.FullDecimal = true;
            this.ctl_freightcost.Location = new System.Drawing.Point(331, 207);
            this.ctl_freightcost.Name = "ctl_freightcost";
            this.ctl_freightcost.RoundNearestCent = false;
            this.ctl_freightcost.Size = new System.Drawing.Size(312, 35);
            this.ctl_freightcost.TabIndex = 39;
            this.ctl_freightcost.UseParentBackColor = true;
            this.ctl_freightcost.zz_Enabled = true;
            this.ctl_freightcost.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_freightcost.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_freightcost.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_freightcost.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_freightcost.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_freightcost.zz_OriginalDesign = false;
            this.ctl_freightcost.zz_ShowErrorColor = true;
            this.ctl_freightcost.zz_ShowNeedsSaveColor = true;
            this.ctl_freightcost.zz_Text = "";
            this.ctl_freightcost.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_freightcost.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_freightcost.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_freightcost.zz_UseGlobalColor = false;
            this.ctl_freightcost.zz_UseGlobalFont = false;
            // 
            // ctl_servicecost
            // 
            this.ctl_servicecost.BackColor = System.Drawing.Color.Transparent;
            this.ctl_servicecost.Bold = false;
            this.ctl_servicecost.Caption = "Service Cost";
            this.ctl_servicecost.Changed = false;
            this.ctl_servicecost.EditCaption = false;
            this.ctl_servicecost.FullDecimal = true;
            this.ctl_servicecost.Location = new System.Drawing.Point(7, 207);
            this.ctl_servicecost.Name = "ctl_servicecost";
            this.ctl_servicecost.RoundNearestCent = false;
            this.ctl_servicecost.Size = new System.Drawing.Size(312, 35);
            this.ctl_servicecost.TabIndex = 38;
            this.ctl_servicecost.UseParentBackColor = true;
            this.ctl_servicecost.zz_Enabled = true;
            this.ctl_servicecost.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_servicecost.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_servicecost.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_servicecost.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_servicecost.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_servicecost.zz_OriginalDesign = false;
            this.ctl_servicecost.zz_ShowErrorColor = true;
            this.ctl_servicecost.zz_ShowNeedsSaveColor = true;
            this.ctl_servicecost.zz_Text = "";
            this.ctl_servicecost.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_servicecost.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_servicecost.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_servicecost.zz_UseGlobalColor = false;
            this.ctl_servicecost.zz_UseGlobalFont = false;
            // 
            // ctl_alternatepart_04
            // 
            this.ctl_alternatepart_04.AllCaps = false;
            this.ctl_alternatepart_04.BackColor = System.Drawing.Color.Transparent;
            this.ctl_alternatepart_04.Bold = false;
            this.ctl_alternatepart_04.Caption = "Alternate #4";
            this.ctl_alternatepart_04.Changed = false;
            this.ctl_alternatepart_04.IsEmail = false;
            this.ctl_alternatepart_04.IsURL = false;
            this.ctl_alternatepart_04.Location = new System.Drawing.Point(6, 134);
            this.ctl_alternatepart_04.Name = "ctl_alternatepart_04";
            this.ctl_alternatepart_04.PasswordChar = '\0';
            this.ctl_alternatepart_04.Size = new System.Drawing.Size(637, 35);
            this.ctl_alternatepart_04.TabIndex = 37;
            this.ctl_alternatepart_04.UseParentBackColor = true;
            this.ctl_alternatepart_04.zz_Enabled = true;
            this.ctl_alternatepart_04.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_alternatepart_04.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_alternatepart_04.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_alternatepart_04.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_alternatepart_04.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_alternatepart_04.zz_OriginalDesign = false;
            this.ctl_alternatepart_04.zz_ShowLinkButton = false;
            this.ctl_alternatepart_04.zz_ShowNeedsSaveColor = true;
            this.ctl_alternatepart_04.zz_Text = "";
            this.ctl_alternatepart_04.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_alternatepart_04.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_alternatepart_04.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_alternatepart_04.zz_UseGlobalColor = false;
            this.ctl_alternatepart_04.zz_UseGlobalFont = false;
            // 
            // ctl_alternatepart_03
            // 
            this.ctl_alternatepart_03.AllCaps = false;
            this.ctl_alternatepart_03.BackColor = System.Drawing.Color.Transparent;
            this.ctl_alternatepart_03.Bold = false;
            this.ctl_alternatepart_03.Caption = "Alternate #3  (#2 is the QB number on the first tab)";
            this.ctl_alternatepart_03.Changed = false;
            this.ctl_alternatepart_03.IsEmail = false;
            this.ctl_alternatepart_03.IsURL = false;
            this.ctl_alternatepart_03.Location = new System.Drawing.Point(6, 97);
            this.ctl_alternatepart_03.Name = "ctl_alternatepart_03";
            this.ctl_alternatepart_03.PasswordChar = '\0';
            this.ctl_alternatepart_03.Size = new System.Drawing.Size(637, 35);
            this.ctl_alternatepart_03.TabIndex = 36;
            this.ctl_alternatepart_03.UseParentBackColor = true;
            this.ctl_alternatepart_03.zz_Enabled = true;
            this.ctl_alternatepart_03.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_alternatepart_03.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_alternatepart_03.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_alternatepart_03.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_alternatepart_03.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_alternatepart_03.zz_OriginalDesign = false;
            this.ctl_alternatepart_03.zz_ShowLinkButton = false;
            this.ctl_alternatepart_03.zz_ShowNeedsSaveColor = true;
            this.ctl_alternatepart_03.zz_Text = "";
            this.ctl_alternatepart_03.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_alternatepart_03.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_alternatepart_03.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_alternatepart_03.zz_UseGlobalColor = false;
            this.ctl_alternatepart_03.zz_UseGlobalFont = false;
            // 
            // ctl_alternatepart_01
            // 
            this.ctl_alternatepart_01.AllCaps = false;
            this.ctl_alternatepart_01.BackColor = System.Drawing.Color.Transparent;
            this.ctl_alternatepart_01.Bold = false;
            this.ctl_alternatepart_01.Caption = "Alternate #1";
            this.ctl_alternatepart_01.Changed = false;
            this.ctl_alternatepart_01.IsEmail = false;
            this.ctl_alternatepart_01.IsURL = false;
            this.ctl_alternatepart_01.Location = new System.Drawing.Point(6, 60);
            this.ctl_alternatepart_01.Name = "ctl_alternatepart_01";
            this.ctl_alternatepart_01.PasswordChar = '\0';
            this.ctl_alternatepart_01.Size = new System.Drawing.Size(637, 35);
            this.ctl_alternatepart_01.TabIndex = 35;
            this.ctl_alternatepart_01.UseParentBackColor = true;
            this.ctl_alternatepart_01.zz_Enabled = true;
            this.ctl_alternatepart_01.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_alternatepart_01.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_alternatepart_01.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_alternatepart_01.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_alternatepart_01.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_alternatepart_01.zz_OriginalDesign = false;
            this.ctl_alternatepart_01.zz_ShowLinkButton = false;
            this.ctl_alternatepart_01.zz_ShowNeedsSaveColor = true;
            this.ctl_alternatepart_01.zz_Text = "";
            this.ctl_alternatepart_01.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_alternatepart_01.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_alternatepart_01.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_alternatepart_01.zz_UseGlobalColor = false;
            this.ctl_alternatepart_01.zz_UseGlobalFont = false;
            // 
            // agent
            // 
            this.agent.AllowChange = true;
            this.agent.AllowClear = false;
            this.agent.AllowNew = false;
            this.agent.AllowView = false;
            this.agent.BackColor = System.Drawing.Color.Transparent;
            this.agent.Bold = false;
            this.agent.Caption = "Agent";
            this.agent.Changed = false;
            this.agent.Location = new System.Drawing.Point(6, 6);
            this.agent.Name = "agent";
            this.agent.Size = new System.Drawing.Size(276, 53);
            this.agent.TabIndex = 32;
            this.agent.UseParentBackColor = true;
            this.agent.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.agent.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            // 
            // pagePictures
            // 
            this.pagePictures.Controls.Add(this.PPV);
            this.pagePictures.Location = new System.Drawing.Point(4, 22);
            this.pagePictures.Name = "pagePictures";
            this.pagePictures.Size = new System.Drawing.Size(649, 474);
            this.pagePictures.TabIndex = 3;
            this.pagePictures.Text = "Attachments";
            this.pagePictures.UseVisualStyleBackColor = true;
            // 
            // PPV
            // 
            this.PPV.BackColor = System.Drawing.Color.White;
            this.PPV.Caption = "Rz4 PictureViewer";
            this.PPV.DisablePartLink = false;
            this.PPV.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PPV.Location = new System.Drawing.Point(28, 36);
            this.PPV.Name = "PPV";
            this.PPV.ShowFullScreenButton = true;
            this.PPV.ShowPartNumberLink = false;
            this.PPV.ShowPartSearch = false;
            this.PPV.ShowZoomButton = true;
            this.PPV.Size = new System.Drawing.Size(360, 275);
            this.PPV.TabIndex = 0;
            this.PPV.TemplateName = "orddetPartPictureViewer";
            // 
            // tabBids
            // 
            this.tabBids.Controls.Add(this.lvBids);
            this.tabBids.Location = new System.Drawing.Point(4, 22);
            this.tabBids.Name = "tabBids";
            this.tabBids.Size = new System.Drawing.Size(649, 474);
            this.tabBids.TabIndex = 4;
            this.tabBids.Text = "Vendor Bids";
            this.tabBids.UseVisualStyleBackColor = true;
            // 
            // lvBids
            // 
            this.lvBids.AddCaption = "Add New Bid";
            this.lvBids.AllowActions = true;
            this.lvBids.AllowAdd = true;
            this.lvBids.AllowDelete = true;
            this.lvBids.AllowDeleteAlways = false;
            this.lvBids.AllowDrop = true;
            this.lvBids.AlternateConnection = null;
            this.lvBids.Caption = "";
            this.lvBids.CurrentTemplate = null;
            this.lvBids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBids.ExtraClassInfo = "";
            this.lvBids.Location = new System.Drawing.Point(0, 0);
            this.lvBids.MultiSelect = true;
            this.lvBids.Name = "lvBids";
            this.lvBids.Size = new System.Drawing.Size(649, 474);
            this.lvBids.SuppressSelectionChanged = false;
            this.lvBids.TabIndex = 9;
            this.lvBids.zz_OpenColumnMenu = false;
            this.lvBids.zz_ShowAutoRefresh = false;
            this.lvBids.zz_ShowUnlimited = false;
            this.lvBids.AboutToAdd += new NewMethod.AddHandler(this.lvBids_AboutToAdd);
            // 
            // tabProcurement
            // 
            this.tabProcurement.Controls.Add(this.lvProcurement);
            this.tabProcurement.Location = new System.Drawing.Point(4, 22);
            this.tabProcurement.Name = "tabProcurement";
            this.tabProcurement.Size = new System.Drawing.Size(649, 474);
            this.tabProcurement.TabIndex = 6;
            this.tabProcurement.Text = "Procurement History";
            this.tabProcurement.UseVisualStyleBackColor = true;
            // 
            // lvProcurement
            // 
            this.lvProcurement.AddCaption = "Add New";
            this.lvProcurement.AllowActions = true;
            this.lvProcurement.AllowAdd = false;
            this.lvProcurement.AllowDelete = true;
            this.lvProcurement.AllowDeleteAlways = false;
            this.lvProcurement.AllowDrop = true;
            this.lvProcurement.AlternateConnection = null;
            this.lvProcurement.Caption = "";
            this.lvProcurement.CurrentTemplate = null;
            this.lvProcurement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProcurement.ExtraClassInfo = "";
            this.lvProcurement.Location = new System.Drawing.Point(0, 0);
            this.lvProcurement.MultiSelect = true;
            this.lvProcurement.Name = "lvProcurement";
            this.lvProcurement.Size = new System.Drawing.Size(649, 474);
            this.lvProcurement.SuppressSelectionChanged = false;
            this.lvProcurement.TabIndex = 0;
            this.lvProcurement.zz_OpenColumnMenu = false;
            this.lvProcurement.zz_ShowAutoRefresh = false;
            this.lvProcurement.zz_ShowUnlimited = false;
            this.lvProcurement.AboutToThrow += new Core.ShowHandler(this.lvProcurement_AboutToThrow);
            // 
            // view_orddet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ts);
            this.Name = "view_orddet";
            this.Size = new System.Drawing.Size(1091, 798);
            this.Controls.SetChildIndex(this.ts, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.ts.ResumeLayout(false);
            this.pageInfo.ResumeLayout(false);
            this.pageInfo.PerformLayout();
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.pageOther.ResumeLayout(false);
            this.pagePictures.ResumeLayout(false);
            this.tabBids.ResumeLayout(false);
            this.tabProcurement.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage pageOther;
        private nEdit_User agent;
        private Win.Controls.EditMoney ctl_freightcost;
        private Win.Controls.EditMoney ctl_servicecost;
        private nEdit_String ctl_alternatepart_04;
        private nEdit_String ctl_alternatepart_03;
        private nEdit_String ctl_alternatepart_01;
        private System.Windows.Forms.TabPage pagePictures;
        private PartPictureViewer PPV;
        private System.Windows.Forms.Label lblStock;
        private nEdit_String ctl_buytype;
        private System.Windows.Forms.TabPage tabProcurement;
        private nList lvProcurement;
        private nList lvQualityControl;
        //private StockPanel xStockLink;
        public System.Windows.Forms.GroupBox gb;
        public Win.Controls.EditMoney ctl_unitcost;
        public CompanyStub cStub;
        public nEdit_User buyer;
        public System.Windows.Forms.Button cmdQuotes;
        public System.Windows.Forms.LinkLabel lblChooseVendor;
        public nEdit_String ctl_vendorcontactname;
        public System.Windows.Forms.LinkLabel lblChooseVendorContact;
        public System.Windows.Forms.Label lblOriginalVendor;
        private nEdit_Date ctl_invoice_date;
        public System.Windows.Forms.TabPage tabBids;
        public nList lvBids;
        public nEdit_String ctl_fullpartnumber;
        protected System.Windows.Forms.TabPage pageInfo;
        protected System.Windows.Forms.TabControl ts;
        public nEdit_List ctl_category;
        public nEdit_Boolean ctl_hasbeenpicked;
        public nEdit_List ctl_condition;
        public nEdit_Number ctl_minimumquantity;
        public nEdit_String ctl_datecode;
        public nEdit_String ctl_manufacturer;
        public nEdit_Boolean ctl_isselected;
        public nEdit_Boolean ctl_isverified;
        public nEdit_Number ctl_quantityfilled;
        public nEdit_Number ctl_quantityordered;
        public nEdit_String ctl_description;
        public nEdit_String ctl_alternatepart;
        public nEdit_String ctl_location;
        public Win.Controls.EditMoney ctl_unitprice;
        public nEdit_Number ctl_quantitypurchased;
        public nEdit_String ctl_alternatepart_02;
        public nEdit_Number ctl_quantitybacked;
        public nEdit_Number ctl_quantitycancelled;
        public nEdit_Date ctl_shipdate;
        public nEdit_Date ctl_requireddate;
        public nEdit_List ctl_packaging;
        public nEdit_String ctl_lotnumber;
        public nEdit_String ctl_country;
        public nEdit_List ctl_partsetup;
        public nEdit_Number ctl_partsperpack;
        public nEdit_String ctl_unit_of_measure;
        public nEdit_Boolean ctl_mfg_certifications;
        public System.Windows.Forms.Button cmdPartSearch;
        public System.Windows.Forms.RadioButton optMultiSearch;
        public System.Windows.Forms.RadioButton optPartSearch;
        public System.Windows.Forms.Button cmdMarkUp;
        public nEdit_String ctl_internalcomment;
        public nEdit_Boolean ctl_line_paid;
        public nEdit_Boolean ctl_has_cofc;
        public nEdit_Boolean ctl_is_accepted;
        public nEdit_Boolean ctl_is_service;
        public System.Windows.Forms.Button cmdQQ;
        public System.Windows.Forms.Button cmdMultiSearchAlternate;
        public nEdit_List ctl_shipvia;
        public nEdit_String ctl_internalpartnumber;
        public nEdit_Boolean ctl_rohs;
        public nEdit_List ctl_leadtime;
    }
}
