using Tools.Database;
namespace Rz5
{
    partial class BidLine
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
            this.ctl_unitprice = new Rz5.Win.Controls.EditMoney();
            this.ctl_quantityordered = new NewMethod.nEdit_Number();
            this.ctl_target_price = new Rz5.Win.Controls.EditMoney();
            this.ctl_target_quantity = new NewMethod.nEdit_Number();
            this.ctl_datecode = new NewMethod.nEdit_String();
            this.ctl_fullpartnumber = new NewMethod.nEdit_String();
            this.ctl_quantitystocked = new NewMethod.nEdit_Number();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblContactCap = new System.Windows.Forms.Label();
            this.lblVendor = new System.Windows.Forms.Label();
            this.lblCompanyCap = new System.Windows.Forms.Label();
            this.lblViewContact = new System.Windows.Forms.LinkLabel();
            this.lblViewCompany = new System.Windows.Forms.LinkLabel();
            this.lblChangeCompany = new System.Windows.Forms.LinkLabel();
            this.cmdMultiSearch = new System.Windows.Forms.Button();
            this.cmdPartSearch = new System.Windows.Forms.Button();
            this.ctl_packaging = new NewMethod.nEdit_List();
            this.ctl_condition = new NewMethod.nEdit_List();
            this.ctl_rohs_info = new NewMethod.nEdit_List();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBidNote = new System.Windows.Forms.TabPage();
            this.ctl_quicknote = new NewMethod.nEdit_Memo();
            this.tabDescription = new System.Windows.Forms.TabPage();
            this.ctl_description = new NewMethod.nEdit_Memo();
            this.tabInternalComment = new System.Windows.Forms.TabPage();
            this.ctl_internalcomment = new NewMethod.nEdit_Memo();
            this.btnBidWizard = new System.Windows.Forms.Button();
            this.gbVendorAlerts = new System.Windows.Forms.GroupBox();
            this.lblVendorAlertList = new System.Windows.Forms.Label();
            this.ctl_manufacturer = new NewMethod.nEdit_List();
            this.ctl_country = new NewMethod.nEdit_String();
            this.tabControl1.SuspendLayout();
            this.tabBidNote.SuspendLayout();
            this.tabDescription.SuspendLayout();
            this.tabInternalComment.SuspendLayout();
            this.gbVendorAlerts.SuspendLayout();
            this.SuspendLayout();
            // 
            // pCommands
            // 
            this.pCommands.Location = new System.Drawing.Point(747, 63);
            // 
            // ctl_unitprice
            // 
            this.ctl_unitprice.BackColor = System.Drawing.Color.White;
            this.ctl_unitprice.Bold = true;
            this.ctl_unitprice.Caption = "Bid Price";
            this.ctl_unitprice.Changed = true;
            this.ctl_unitprice.EditCaption = false;
            this.ctl_unitprice.FullDecimal = false;
            this.ctl_unitprice.Location = new System.Drawing.Point(156, 82);
            this.ctl_unitprice.Name = "ctl_unitprice";
            this.ctl_unitprice.RoundNearestCent = false;
            this.ctl_unitprice.Size = new System.Drawing.Size(115, 35);
            this.ctl_unitprice.TabIndex = 4;
            this.ctl_unitprice.UseParentBackColor = true;
            this.ctl_unitprice.zz_Enabled = true;
            this.ctl_unitprice.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_unitprice.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_unitprice.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_unitprice.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_unitprice.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_unitprice.zz_OriginalDesign = false;
            this.ctl_unitprice.zz_ShowErrorColor = true;
            this.ctl_unitprice.zz_ShowNeedsSaveColor = true;
            this.ctl_unitprice.zz_Text = "0.00";
            this.ctl_unitprice.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_unitprice.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_unitprice.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_unitprice.zz_UseGlobalColor = false;
            this.ctl_unitprice.zz_UseGlobalFont = false;
            // 
            // ctl_quantityordered
            // 
            this.ctl_quantityordered.BackColor = System.Drawing.Color.White;
            this.ctl_quantityordered.Bold = true;
            this.ctl_quantityordered.Caption = "Bid Qty";
            this.ctl_quantityordered.Changed = true;
            this.ctl_quantityordered.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_quantityordered.Location = new System.Drawing.Point(156, 47);
            this.ctl_quantityordered.Name = "ctl_quantityordered";
            this.ctl_quantityordered.Size = new System.Drawing.Size(114, 35);
            this.ctl_quantityordered.TabIndex = 3;
            this.ctl_quantityordered.UseParentBackColor = true;
            this.ctl_quantityordered.zz_Enabled = true;
            this.ctl_quantityordered.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_quantityordered.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_quantityordered.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_quantityordered.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_quantityordered.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_quantityordered.zz_OriginalDesign = false;
            this.ctl_quantityordered.zz_ShowErrorColor = true;
            this.ctl_quantityordered.zz_ShowNeedsSaveColor = true;
            this.ctl_quantityordered.zz_Text = "0";
            this.ctl_quantityordered.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_quantityordered.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_quantityordered.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_quantityordered.zz_UseGlobalColor = false;
            this.ctl_quantityordered.zz_UseGlobalFont = false;
            // 
            // ctl_target_price
            // 
            this.ctl_target_price.BackColor = System.Drawing.Color.White;
            this.ctl_target_price.Bold = false;
            this.ctl_target_price.Caption = "Target Price";
            this.ctl_target_price.Changed = true;
            this.ctl_target_price.EditCaption = false;
            this.ctl_target_price.FullDecimal = false;
            this.ctl_target_price.Location = new System.Drawing.Point(33, 82);
            this.ctl_target_price.Name = "ctl_target_price";
            this.ctl_target_price.RoundNearestCent = false;
            this.ctl_target_price.Size = new System.Drawing.Size(119, 35);
            this.ctl_target_price.TabIndex = 2;
            this.ctl_target_price.UseParentBackColor = true;
            this.ctl_target_price.zz_Enabled = true;
            this.ctl_target_price.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_target_price.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_target_price.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_target_price.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_target_price.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_target_price.zz_OriginalDesign = false;
            this.ctl_target_price.zz_ShowErrorColor = true;
            this.ctl_target_price.zz_ShowNeedsSaveColor = false;
            this.ctl_target_price.zz_Text = "0.00";
            this.ctl_target_price.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_target_price.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_target_price.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_target_price.zz_UseGlobalColor = false;
            this.ctl_target_price.zz_UseGlobalFont = false;
            // 
            // ctl_target_quantity
            // 
            this.ctl_target_quantity.BackColor = System.Drawing.Color.White;
            this.ctl_target_quantity.Bold = false;
            this.ctl_target_quantity.Caption = "Target Qty";
            this.ctl_target_quantity.Changed = true;
            this.ctl_target_quantity.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_target_quantity.Location = new System.Drawing.Point(32, 47);
            this.ctl_target_quantity.Name = "ctl_target_quantity";
            this.ctl_target_quantity.Size = new System.Drawing.Size(120, 35);
            this.ctl_target_quantity.TabIndex = 1;
            this.ctl_target_quantity.UseParentBackColor = true;
            this.ctl_target_quantity.zz_Enabled = true;
            this.ctl_target_quantity.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_target_quantity.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_target_quantity.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_target_quantity.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_target_quantity.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_target_quantity.zz_OriginalDesign = false;
            this.ctl_target_quantity.zz_ShowErrorColor = true;
            this.ctl_target_quantity.zz_ShowNeedsSaveColor = false;
            this.ctl_target_quantity.zz_Text = "0";
            this.ctl_target_quantity.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_target_quantity.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_target_quantity.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_target_quantity.zz_UseGlobalColor = false;
            this.ctl_target_quantity.zz_UseGlobalFont = false;
            // 
            // ctl_datecode
            // 
            this.ctl_datecode.AllCaps = false;
            this.ctl_datecode.BackColor = System.Drawing.Color.White;
            this.ctl_datecode.Bold = false;
            this.ctl_datecode.Caption = "Date Code";
            this.ctl_datecode.Changed = false;
            this.ctl_datecode.IsEmail = false;
            this.ctl_datecode.IsURL = false;
            this.ctl_datecode.Location = new System.Drawing.Point(277, 86);
            this.ctl_datecode.Name = "ctl_datecode";
            this.ctl_datecode.PasswordChar = '\0';
            this.ctl_datecode.Size = new System.Drawing.Size(108, 35);
            this.ctl_datecode.TabIndex = 11;
            this.ctl_datecode.UseParentBackColor = true;
            this.ctl_datecode.zz_Enabled = true;
            this.ctl_datecode.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_datecode.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_datecode.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_datecode.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_datecode.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_datecode.zz_OriginalDesign = false;
            this.ctl_datecode.zz_ShowLinkButton = false;
            this.ctl_datecode.zz_ShowNeedsSaveColor = true;
            this.ctl_datecode.zz_Text = "";
            this.ctl_datecode.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_datecode.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_datecode.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_datecode.zz_UseGlobalColor = false;
            this.ctl_datecode.zz_UseGlobalFont = false;
            // 
            // ctl_fullpartnumber
            // 
            this.ctl_fullpartnumber.AllCaps = false;
            this.ctl_fullpartnumber.BackColor = System.Drawing.Color.White;
            this.ctl_fullpartnumber.Bold = true;
            this.ctl_fullpartnumber.Caption = "Part Number";
            this.ctl_fullpartnumber.Changed = false;
            this.ctl_fullpartnumber.IsEmail = false;
            this.ctl_fullpartnumber.IsURL = false;
            this.ctl_fullpartnumber.Location = new System.Drawing.Point(32, 5);
            this.ctl_fullpartnumber.Name = "ctl_fullpartnumber";
            this.ctl_fullpartnumber.PasswordChar = '\0';
            this.ctl_fullpartnumber.Size = new System.Drawing.Size(353, 48);
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
            // 
            // ctl_quantitystocked
            // 
            this.ctl_quantitystocked.BackColor = System.Drawing.Color.White;
            this.ctl_quantitystocked.Bold = false;
            this.ctl_quantitystocked.Caption = "Quantity to Stock";
            this.ctl_quantitystocked.Changed = false;
            this.ctl_quantitystocked.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_quantitystocked.Location = new System.Drawing.Point(747, 186);
            this.ctl_quantitystocked.Name = "ctl_quantitystocked";
            this.ctl_quantitystocked.Size = new System.Drawing.Size(105, 35);
            this.ctl_quantitystocked.TabIndex = 6;
            this.ctl_quantitystocked.UseParentBackColor = true;
            this.ctl_quantitystocked.Visible = false;
            this.ctl_quantitystocked.zz_Enabled = true;
            this.ctl_quantitystocked.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_quantitystocked.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_quantitystocked.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_quantitystocked.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_quantitystocked.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_quantitystocked.zz_OriginalDesign = false;
            this.ctl_quantitystocked.zz_ShowErrorColor = true;
            this.ctl_quantitystocked.zz_ShowNeedsSaveColor = true;
            this.ctl_quantitystocked.zz_Text = "";
            this.ctl_quantitystocked.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_quantitystocked.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_quantitystocked.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_quantitystocked.zz_UseGlobalColor = false;
            this.ctl_quantitystocked.zz_UseGlobalFont = false;
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(391, 56);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(150, 20);
            this.lblContact.TabIndex = 64;
            this.lblContact.Text = "Contact Name Here";
            // 
            // lblContactCap
            // 
            this.lblContactCap.AutoSize = true;
            this.lblContactCap.Location = new System.Drawing.Point(391, 44);
            this.lblContactCap.Name = "lblContactCap";
            this.lblContactCap.Size = new System.Drawing.Size(47, 13);
            this.lblContactCap.TabIndex = 63;
            this.lblContactCap.Text = "Contact:";
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendor.Location = new System.Drawing.Point(391, 19);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(146, 20);
            this.lblVendor.TabIndex = 62;
            this.lblVendor.Text = "Vendor Name Here";
            // 
            // lblCompanyCap
            // 
            this.lblCompanyCap.AutoSize = true;
            this.lblCompanyCap.Location = new System.Drawing.Point(391, 7);
            this.lblCompanyCap.Name = "lblCompanyCap";
            this.lblCompanyCap.Size = new System.Drawing.Size(44, 13);
            this.lblCompanyCap.TabIndex = 61;
            this.lblCompanyCap.Text = "Vendor:";
            // 
            // lblViewContact
            // 
            this.lblViewContact.AutoSize = true;
            this.lblViewContact.Location = new System.Drawing.Point(436, 42);
            this.lblViewContact.Name = "lblViewContact";
            this.lblViewContact.Size = new System.Drawing.Size(29, 13);
            this.lblViewContact.TabIndex = 70;
            this.lblViewContact.TabStop = true;
            this.lblViewContact.Text = "view";
            this.lblViewContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblViewContact_LinkClicked);
            // 
            // lblViewCompany
            // 
            this.lblViewCompany.AutoSize = true;
            this.lblViewCompany.Location = new System.Drawing.Point(434, 5);
            this.lblViewCompany.Name = "lblViewCompany";
            this.lblViewCompany.Size = new System.Drawing.Size(29, 13);
            this.lblViewCompany.TabIndex = 69;
            this.lblViewCompany.TabStop = true;
            this.lblViewCompany.Text = "view";
            this.lblViewCompany.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblViewCompany_LinkClicked);
            // 
            // lblChangeCompany
            // 
            this.lblChangeCompany.AutoSize = true;
            this.lblChangeCompany.Location = new System.Drawing.Point(469, 5);
            this.lblChangeCompany.Name = "lblChangeCompany";
            this.lblChangeCompany.Size = new System.Drawing.Size(43, 13);
            this.lblChangeCompany.TabIndex = 72;
            this.lblChangeCompany.TabStop = true;
            this.lblChangeCompany.Text = "change";
            this.lblChangeCompany.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChangeCompany_LinkClicked);
            // 
            // cmdMultiSearch
            // 
            this.cmdMultiSearch.Location = new System.Drawing.Point(313, 4);
            this.cmdMultiSearch.Name = "cmdMultiSearch";
            this.cmdMultiSearch.Size = new System.Drawing.Size(72, 19);
            this.cmdMultiSearch.TabIndex = 78;
            this.cmdMultiSearch.Text = "MultiSearch";
            this.cmdMultiSearch.UseVisualStyleBackColor = true;
            this.cmdMultiSearch.Click += new System.EventHandler(this.cmdMultiSearch_Click);
            // 
            // cmdPartSearch
            // 
            this.cmdPartSearch.Location = new System.Drawing.Point(244, 4);
            this.cmdPartSearch.Name = "cmdPartSearch";
            this.cmdPartSearch.Size = new System.Drawing.Size(69, 19);
            this.cmdPartSearch.TabIndex = 77;
            this.cmdPartSearch.Text = "PartSearch";
            this.cmdPartSearch.UseVisualStyleBackColor = true;
            this.cmdPartSearch.Click += new System.EventHandler(this.cmdPartSearch_Click);
            // 
            // ctl_packaging
            // 
            this.ctl_packaging.AllCaps = false;
            this.ctl_packaging.AllowEdit = true;
            this.ctl_packaging.BackColor = System.Drawing.Color.White;
            this.ctl_packaging.Bold = false;
            this.ctl_packaging.Caption = "Packaging";
            this.ctl_packaging.Changed = false;
            this.ctl_packaging.ListName = "packaging";
            this.ctl_packaging.Location = new System.Drawing.Point(156, 121);
            this.ctl_packaging.Name = "ctl_packaging";
            this.ctl_packaging.SimpleList = null;
            this.ctl_packaging.Size = new System.Drawing.Size(114, 36);
            this.ctl_packaging.TabIndex = 81;
            this.ctl_packaging.UseParentBackColor = true;
            this.ctl_packaging.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_packaging.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_packaging.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_packaging.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_packaging.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_packaging.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_packaging.zz_OriginalDesign = false;
            this.ctl_packaging.zz_ShowNeedsSaveColor = true;
            this.ctl_packaging.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_packaging.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_packaging.zz_UseGlobalColor = false;
            this.ctl_packaging.zz_UseGlobalFont = false;
            // 
            // ctl_condition
            // 
            this.ctl_condition.AllCaps = false;
            this.ctl_condition.AllowEdit = true;
            this.ctl_condition.BackColor = System.Drawing.Color.White;
            this.ctl_condition.Bold = false;
            this.ctl_condition.Caption = "Condition";
            this.ctl_condition.Changed = false;
            this.ctl_condition.ListName = "condition";
            this.ctl_condition.Location = new System.Drawing.Point(275, 121);
            this.ctl_condition.Name = "ctl_condition";
            this.ctl_condition.SimpleList = null;
            this.ctl_condition.Size = new System.Drawing.Size(110, 36);
            this.ctl_condition.TabIndex = 85;
            this.ctl_condition.UseParentBackColor = true;
            this.ctl_condition.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_condition.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_condition.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_condition.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_condition.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_condition.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_condition.zz_OriginalDesign = false;
            this.ctl_condition.zz_ShowNeedsSaveColor = true;
            this.ctl_condition.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_condition.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_condition.zz_UseGlobalColor = false;
            this.ctl_condition.zz_UseGlobalFont = false;
            // 
            // ctl_rohs_info
            // 
            this.ctl_rohs_info.AllCaps = false;
            this.ctl_rohs_info.AllowEdit = true;
            this.ctl_rohs_info.BackColor = System.Drawing.Color.Transparent;
            this.ctl_rohs_info.Bold = false;
            this.ctl_rohs_info.Caption = "RoHS";
            this.ctl_rohs_info.Changed = false;
            this.ctl_rohs_info.ListName = "rohs_info";
            this.ctl_rohs_info.Location = new System.Drawing.Point(32, 121);
            this.ctl_rohs_info.Name = "ctl_rohs_info";
            this.ctl_rohs_info.SimpleList = "";
            this.ctl_rohs_info.Size = new System.Drawing.Size(120, 36);
            this.ctl_rohs_info.TabIndex = 99;
            this.ctl_rohs_info.UseParentBackColor = false;
            this.ctl_rohs_info.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_rohs_info.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_rohs_info.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_rohs_info.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_rohs_info.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_rohs_info.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_rohs_info.zz_OriginalDesign = false;
            this.ctl_rohs_info.zz_ShowNeedsSaveColor = true;
            this.ctl_rohs_info.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_rohs_info.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_rohs_info.zz_UseGlobalColor = false;
            this.ctl_rohs_info.zz_UseGlobalFont = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBidNote);
            this.tabControl1.Controls.Add(this.tabDescription);
            this.tabControl1.Controls.Add(this.tabInternalComment);
            this.tabControl1.Location = new System.Drawing.Point(395, 158);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(336, 111);
            this.tabControl1.TabIndex = 102;
            // 
            // tabBidNote
            // 
            this.tabBidNote.Controls.Add(this.ctl_quicknote);
            this.tabBidNote.Location = new System.Drawing.Point(4, 22);
            this.tabBidNote.Name = "tabBidNote";
            this.tabBidNote.Padding = new System.Windows.Forms.Padding(3);
            this.tabBidNote.Size = new System.Drawing.Size(328, 85);
            this.tabBidNote.TabIndex = 0;
            this.tabBidNote.Text = "Bid Note";
            this.tabBidNote.UseVisualStyleBackColor = true;
            // 
            // ctl_quicknote
            // 
            this.ctl_quicknote.BackColor = System.Drawing.Color.Transparent;
            this.ctl_quicknote.Bold = false;
            this.ctl_quicknote.Caption = "";
            this.ctl_quicknote.Changed = false;
            this.ctl_quicknote.DateLines = false;
            this.ctl_quicknote.Location = new System.Drawing.Point(0, 1);
            this.ctl_quicknote.Name = "ctl_quicknote";
            this.ctl_quicknote.Size = new System.Drawing.Size(344, 84);
            this.ctl_quicknote.TabIndex = 85;
            this.ctl_quicknote.UseParentBackColor = true;
            this.ctl_quicknote.zz_Enabled = true;
            this.ctl_quicknote.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_quicknote.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_quicknote.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_quicknote.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_quicknote.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_quicknote.zz_OriginalDesign = false;
            this.ctl_quicknote.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ctl_quicknote.zz_ShowNeedsSaveColor = true;
            this.ctl_quicknote.zz_Text = "";
            this.ctl_quicknote.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_quicknote.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_quicknote.zz_UseGlobalColor = false;
            this.ctl_quicknote.zz_UseGlobalFont = false;
            // 
            // tabDescription
            // 
            this.tabDescription.Controls.Add(this.ctl_description);
            this.tabDescription.Location = new System.Drawing.Point(4, 22);
            this.tabDescription.Name = "tabDescription";
            this.tabDescription.Padding = new System.Windows.Forms.Padding(3);
            this.tabDescription.Size = new System.Drawing.Size(344, 85);
            this.tabDescription.TabIndex = 1;
            this.tabDescription.Text = "Description";
            this.tabDescription.UseVisualStyleBackColor = true;
            // 
            // ctl_description
            // 
            this.ctl_description.BackColor = System.Drawing.Color.White;
            this.ctl_description.Bold = false;
            this.ctl_description.Caption = "";
            this.ctl_description.Changed = false;
            this.ctl_description.DateLines = false;
            this.ctl_description.Location = new System.Drawing.Point(0, 0);
            this.ctl_description.Name = "ctl_description";
            this.ctl_description.Size = new System.Drawing.Size(344, 84);
            this.ctl_description.TabIndex = 84;
            this.ctl_description.UseParentBackColor = true;
            this.ctl_description.zz_Enabled = true;
            this.ctl_description.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_description.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_description.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_description.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_description.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_description.zz_OriginalDesign = false;
            this.ctl_description.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ctl_description.zz_ShowNeedsSaveColor = true;
            this.ctl_description.zz_Text = "";
            this.ctl_description.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_description.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_description.zz_UseGlobalColor = false;
            this.ctl_description.zz_UseGlobalFont = false;
            // 
            // tabInternalComment
            // 
            this.tabInternalComment.Controls.Add(this.ctl_internalcomment);
            this.tabInternalComment.Location = new System.Drawing.Point(4, 22);
            this.tabInternalComment.Name = "tabInternalComment";
            this.tabInternalComment.Padding = new System.Windows.Forms.Padding(3);
            this.tabInternalComment.Size = new System.Drawing.Size(344, 85);
            this.tabInternalComment.TabIndex = 2;
            this.tabInternalComment.Text = "Internal Comment";
            this.tabInternalComment.UseVisualStyleBackColor = true;
            // 
            // ctl_internalcomment
            // 
            this.ctl_internalcomment.BackColor = System.Drawing.Color.White;
            this.ctl_internalcomment.Bold = false;
            this.ctl_internalcomment.Caption = "";
            this.ctl_internalcomment.Changed = false;
            this.ctl_internalcomment.DateLines = false;
            this.ctl_internalcomment.Location = new System.Drawing.Point(0, 0);
            this.ctl_internalcomment.Name = "ctl_internalcomment";
            this.ctl_internalcomment.Size = new System.Drawing.Size(344, 84);
            this.ctl_internalcomment.TabIndex = 9;
            this.ctl_internalcomment.UseParentBackColor = true;
            this.ctl_internalcomment.zz_Enabled = true;
            this.ctl_internalcomment.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_internalcomment.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_internalcomment.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_internalcomment.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_internalcomment.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_internalcomment.zz_OriginalDesign = false;
            this.ctl_internalcomment.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ctl_internalcomment.zz_ShowNeedsSaveColor = true;
            this.ctl_internalcomment.zz_Text = "";
            this.ctl_internalcomment.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_internalcomment.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internalcomment.zz_UseGlobalColor = false;
            this.ctl_internalcomment.zz_UseGlobalFont = false;
            // 
            // btnBidWizard
            // 
            this.btnBidWizard.Location = new System.Drawing.Point(750, 19);
            this.btnBidWizard.Name = "btnBidWizard";
            this.btnBidWizard.Size = new System.Drawing.Size(94, 34);
            this.btnBidWizard.TabIndex = 103;
            this.btnBidWizard.Text = "Bid Wizard";
            this.btnBidWizard.UseVisualStyleBackColor = true;
            this.btnBidWizard.Visible = false;
            // 
            // gbVendorAlerts
            // 
            this.gbVendorAlerts.Controls.Add(this.lblVendorAlertList);
            this.gbVendorAlerts.Location = new System.Drawing.Point(395, 80);
            this.gbVendorAlerts.Name = "gbVendorAlerts";
            this.gbVendorAlerts.Size = new System.Drawing.Size(336, 77);
            this.gbVendorAlerts.TabIndex = 104;
            this.gbVendorAlerts.TabStop = false;
            this.gbVendorAlerts.Text = "Vendor Alerts";
            // 
            // lblVendorAlertList
            // 
            this.lblVendorAlertList.AutoSize = true;
            this.lblVendorAlertList.BackColor = System.Drawing.Color.Transparent;
            this.lblVendorAlertList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendorAlertList.ForeColor = System.Drawing.Color.Black;
            this.lblVendorAlertList.Location = new System.Drawing.Point(7, 20);
            this.lblVendorAlertList.Name = "lblVendorAlertList";
            this.lblVendorAlertList.Size = new System.Drawing.Size(41, 13);
            this.lblVendorAlertList.TabIndex = 0;
            this.lblVendorAlertList.Text = "label1";
            // 
            // ctl_manufacturer
            // 
            this.ctl_manufacturer.AllCaps = false;
            this.ctl_manufacturer.AllowEdit = false;
            this.ctl_manufacturer.BackColor = System.Drawing.Color.Transparent;
            this.ctl_manufacturer.Bold = false;
            this.ctl_manufacturer.Caption = "Bid MFG";
            this.ctl_manufacturer.Changed = false;
            this.ctl_manufacturer.ListName = "manufacturer";
            this.ctl_manufacturer.Location = new System.Drawing.Point(275, 45);
            this.ctl_manufacturer.Name = "ctl_manufacturer";
            this.ctl_manufacturer.SimpleList = null;
            this.ctl_manufacturer.Size = new System.Drawing.Size(110, 40);
            this.ctl_manufacturer.TabIndex = 105;
            this.ctl_manufacturer.UseParentBackColor = true;
            this.ctl_manufacturer.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            // ctl_country
            // 
            this.ctl_country.AllCaps = false;
            this.ctl_country.BackColor = System.Drawing.Color.White;
            this.ctl_country.Bold = false;
            this.ctl_country.Caption = "COO";
            this.ctl_country.Changed = false;
            this.ctl_country.IsEmail = false;
            this.ctl_country.IsURL = false;
            this.ctl_country.Location = new System.Drawing.Point(33, 163);
            this.ctl_country.Name = "ctl_country";
            this.ctl_country.PasswordChar = '\0';
            this.ctl_country.Size = new System.Drawing.Size(108, 35);
            this.ctl_country.TabIndex = 106;
            this.ctl_country.UseParentBackColor = true;
            this.ctl_country.zz_Enabled = true;
            this.ctl_country.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_country.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_country.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_country.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_country.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_country.zz_OriginalDesign = false;
            this.ctl_country.zz_ShowLinkButton = false;
            this.ctl_country.zz_ShowNeedsSaveColor = true;
            this.ctl_country.zz_Text = "";
            this.ctl_country.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_country.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_country.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_country.zz_UseGlobalColor = false;
            this.ctl_country.zz_UseGlobalFont = false;
            // 
            // BidLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctl_country);
            this.Controls.Add(this.ctl_manufacturer);
            this.Controls.Add(this.gbVendorAlerts);
            this.Controls.Add(this.btnBidWizard);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ctl_rohs_info);
            this.Controls.Add(this.ctl_condition);
            this.Controls.Add(this.ctl_packaging);
            this.Controls.Add(this.cmdMultiSearch);
            this.Controls.Add(this.cmdPartSearch);
            this.Controls.Add(this.lblChangeCompany);
            this.Controls.Add(this.lblViewContact);
            this.Controls.Add(this.lblViewCompany);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblContactCap);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.lblCompanyCap);
            this.Controls.Add(this.ctl_quantitystocked);
            this.Controls.Add(this.ctl_unitprice);
            this.Controls.Add(this.ctl_quantityordered);
            this.Controls.Add(this.ctl_target_price);
            this.Controls.Add(this.ctl_target_quantity);
            this.Controls.Add(this.ctl_datecode);
            this.Controls.Add(this.ctl_fullpartnumber);
            this.Name = "BidLine";
            this.Size = new System.Drawing.Size(852, 277);
            this.Controls.SetChildIndex(this.ctl_fullpartnumber, 0);
            this.Controls.SetChildIndex(this.ctl_datecode, 0);
            this.Controls.SetChildIndex(this.ctl_target_quantity, 0);
            this.Controls.SetChildIndex(this.ctl_target_price, 0);
            this.Controls.SetChildIndex(this.ctl_quantityordered, 0);
            this.Controls.SetChildIndex(this.ctl_unitprice, 0);
            this.Controls.SetChildIndex(this.ctl_quantitystocked, 0);
            this.Controls.SetChildIndex(this.lblCompanyCap, 0);
            this.Controls.SetChildIndex(this.lblVendor, 0);
            this.Controls.SetChildIndex(this.lblContactCap, 0);
            this.Controls.SetChildIndex(this.lblContact, 0);
            this.Controls.SetChildIndex(this.lblViewCompany, 0);
            this.Controls.SetChildIndex(this.lblViewContact, 0);
            this.Controls.SetChildIndex(this.lblChangeCompany, 0);
            this.Controls.SetChildIndex(this.cmdPartSearch, 0);
            this.Controls.SetChildIndex(this.cmdMultiSearch, 0);
            this.Controls.SetChildIndex(this.ctl_packaging, 0);
            this.Controls.SetChildIndex(this.ctl_condition, 0);
            this.Controls.SetChildIndex(this.ctl_rohs_info, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.btnBidWizard, 0);
            this.Controls.SetChildIndex(this.pCommands, 0);
            this.Controls.SetChildIndex(this.gbVendorAlerts, 0);
            this.Controls.SetChildIndex(this.ctl_manufacturer, 0);
            this.Controls.SetChildIndex(this.ctl_country, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabBidNote.ResumeLayout(false);
            this.tabDescription.ResumeLayout(false);
            this.tabInternalComment.ResumeLayout(false);
            this.gbVendorAlerts.ResumeLayout(false);
            this.gbVendorAlerts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Win.Controls.EditMoney ctl_unitprice;
        protected NewMethod.nEdit_Number ctl_quantityordered;
        protected Win.Controls.EditMoney ctl_target_price;
        protected NewMethod.nEdit_Number ctl_target_quantity;
        protected NewMethod.nEdit_String ctl_datecode;
        protected NewMethod.nEdit_String ctl_fullpartnumber;
        protected NewMethod.nEdit_Number ctl_quantitystocked;
        protected System.Windows.Forms.Label lblContact;
        protected System.Windows.Forms.Label lblContactCap;
        protected System.Windows.Forms.Label lblVendor;
        protected System.Windows.Forms.Label lblCompanyCap;
        protected System.Windows.Forms.LinkLabel lblViewContact;
        protected System.Windows.Forms.LinkLabel lblViewCompany;
        protected System.Windows.Forms.LinkLabel lblChangeCompany;
        protected System.Windows.Forms.Button cmdMultiSearch;
        protected System.Windows.Forms.Button cmdPartSearch;
        protected NewMethod.nEdit_List ctl_packaging;
        protected NewMethod.nEdit_List ctl_condition;
        protected NewMethod.nEdit_List ctl_rohs_info;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBidNote;
        protected NewMethod.nEdit_Memo ctl_quicknote;
        private System.Windows.Forms.TabPage tabDescription;
        protected NewMethod.nEdit_Memo ctl_description;
        private System.Windows.Forms.TabPage tabInternalComment;
        protected NewMethod.nEdit_Memo ctl_internalcomment;
        private System.Windows.Forms.Button btnBidWizard;
        private System.Windows.Forms.GroupBox gbVendorAlerts;
        private System.Windows.Forms.Label lblVendorAlertList;
        public NewMethod.nEdit_List ctl_manufacturer;
        protected NewMethod.nEdit_String ctl_country;
    }
}
