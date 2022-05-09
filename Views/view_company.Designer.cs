using NewMethod;
using Tools.Database;

namespace Rz5
{
    partial class view_company
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
            this.components = new System.ComponentModel.Container();
            this.ts = new System.Windows.Forms.TabControl();
            this.tabCompany = new System.Windows.Forms.TabPage();
            this.lblVendorCredits = new System.Windows.Forms.Label();
            this.lblProblemVendor = new System.Windows.Forms.Label();
            this.lblOutstandingInvoiceAmnt = new System.Windows.Forms.Label();
            this.lblProblemCustomer = new System.Windows.Forms.Label();
            this.ctl_primarywebaddress = new NewMethod.nEdit_String();
            this.ctl_isverified = new NewMethod.nEdit_Boolean();
            this.ctl_is_prospect = new NewMethod.nEdit_Boolean();
            this.ctl_primaryfax = new NewMethod.nEdit_String();
            this.ctl_primaryphoneextension = new NewMethod.nEdit_String();
            this.ctl_donotemail = new NewMethod.nEdit_Boolean();
            this.ctl_star_rating = new NewMethod.nEdit_Number();
            this.ctl_isdistributor = new NewMethod.nEdit_Boolean();
            this.ctl_iscem = new NewMethod.nEdit_Boolean();
            this.ctl_isoem = new NewMethod.nEdit_Boolean();
            this.lblScroll = new System.Windows.Forms.Label();
            this.cmdForward = new System.Windows.Forms.Button();
            this.cmdBack = new System.Windows.Forms.Button();
            this.cmdChangeCompany = new System.Windows.Forms.Button();
            this.ctl_isactive = new NewMethod.nEdit_Boolean();
            this.ctl_primaryemailaddress = new NewMethod.nEdit_String();
            this.ctl_primaryphone = new NewMethod.nEdit_String();
            this.ctl_companytype = new NewMethod.nEdit_List();
            this.ctl_primarycontact = new NewMethod.nEdit_String();
            this.user = new NewMethod.nEdit_User();
            this.ctl_wherefoundcompany = new NewMethod.nEdit_List();
            this.ctl_companyname = new NewMethod.nEdit_String();
            this.ctl_c_of_c = new NewMethod.nEdit_Boolean();
            this.ctl_needs_contact = new NewMethod.nEdit_Boolean();
            this.cType = new Rz5.CompanyTypeStub();
            this.tabCommission = new System.Windows.Forms.TabPage();
            this.sc1 = new Rz5.SplitCommission();
            this.tabMore = new System.Windows.Forms.TabPage();
            this.ctl_GCAT_required = new NewMethod.nEdit_Boolean();
            this.ctl_timezone = new NewMethod.nEdit_List();
            this.optViewVend = new System.Windows.Forms.RadioButton();
            this.optViewCust = new System.Windows.Forms.RadioButton();
            this.ctl_internetpassword = new NewMethod.nEdit_String();
            this.ctl_internetusername = new NewMethod.nEdit_String();
            this.ctl_vendoraccountnumber = new NewMethod.nEdit_String();
            this.ctl_internalcompanyname = new NewMethod.nEdit_String();
            this.ctl_lastcontactdate = new NewMethod.nEdit_String();
            this.ctl_rfqemail = new NewMethod.nEdit_String();
            this.ctl_zipcode = new NewMethod.nEdit_String();
            this.ctl_statename = new NewMethod.nEdit_String();
            this.ctl_contactfrequency = new NewMethod.nEdit_Number();
            this.ctl_instockonly = new NewMethod.nEdit_Boolean();
            this.ctl_companycode = new NewMethod.nEdit_String();
            this.ctl_companynumber = new NewMethod.nEdit_Number();
            this.ctl_taxid = new NewMethod.nEdit_String();
            this.ctl_companyrating = new NewMethod.nEdit_Number();
            this.ctl_pricelevel = new NewMethod.nEdit_Number();
            this.ctl_donotrfq = new NewMethod.nEdit_Boolean();
            this.ctl_isinternational = new NewMethod.nEdit_Boolean();
            this.ctl_country = new NewMethod.nEdit_String();
            this.ctl_alias1 = new NewMethod.nEdit_String();
            this.tabTerms = new System.Windows.Forms.TabPage();
            this.gbVendor = new System.Windows.Forms.GroupBox();
            this.ctl_islocked_purchase = new NewMethod.nEdit_Boolean();
            this.ctl_problem_vendor = new NewMethod.nEdit_Boolean();
            this.ctl_vendorTermsMemo = new NewMethod.nEdit_Memo();
            this.ctl_cc_warning = new NewMethod.nEdit_Memo();
            this.ctl_shipviavendor = new NewMethod.nEdit_List();
            this.ctl_termsasvendor = new NewMethod.nEdit_List();
            this.ctl_pastduelimitasvendor = new NewMethod.nEdit_Number();
            this.ctl_creditasvendor = new NewMethod.nEdit_Money();
            this.ctl_handling_charge = new NewMethod.nEdit_Money();
            this.ctl_cc_charge = new NewMethod.nEdit_Money();
            this.gbCustomer = new System.Windows.Forms.GroupBox();
            this.btnCheckCreditLimit = new System.Windows.Forms.Button();
            this.ctl_is_locked = new NewMethod.nEdit_Boolean();
            this.ctl_is_problem = new NewMethod.nEdit_Boolean();
            this.ctl_customerTermsMemo = new NewMethod.nEdit_Memo();
            this.ctl_shipviacustomer = new NewMethod.nEdit_List();
            this.ctl_termsascustomer = new NewMethod.nEdit_List();
            this.ctl_pastduelimitascustomer = new NewMethod.nEdit_Number();
            this.ctl_creditascustomer = new NewMethod.nEdit_Money();
            this.tabDescription = new System.Windows.Forms.TabPage();
            this.gbCompanyTermsConditions = new System.Windows.Forms.GroupBox();
            this.ctl_testing_restriction_detail = new System.Windows.Forms.TextBox();
            this.ctl_packaging_requirements_detail = new System.Windows.Forms.TextBox();
            this.ctl_date_code_restriction_detail = new System.Windows.Forms.TextBox();
            this.ctl_requires_traceability = new System.Windows.Forms.CheckBox();
            this.ctl_testing_restriction = new System.Windows.Forms.CheckBox();
            this.ctl_coo_restriction = new System.Windows.Forms.CheckBox();
            this.ctl_broker_restriction = new System.Windows.Forms.CheckBox();
            this.ctl_rohs_restriction = new System.Windows.Forms.CheckBox();
            this.ctl_packaging_requirements = new System.Windows.Forms.CheckBox();
            this.ctl_date_code_restriction = new System.Windows.Forms.CheckBox();
            this.ctl_SOA_services = new NewMethod.nEdit_Boolean();
            this.ctl_SOA_components = new NewMethod.nEdit_Boolean();
            this.label6 = new System.Windows.Forms.Label();
            this.ctl_description = new NewMethod.nEdit_Memo();
            this.tabAttachments = new System.Windows.Forms.TabPage();
            this.PPV = new Rz5.PartPictureViewer();
            this.tabQB = new System.Windows.Forms.TabPage();
            this.ctl_qb_shipping = new NewMethod.nEdit_Memo();
            this.ctl_qb_billing = new NewMethod.nEdit_Memo();
            this.ctl_qb_terms_v = new NewMethod.nEdit_String();
            this.ctl_qb_terms = new NewMethod.nEdit_String();
            this.ctl_qb_name = new NewMethod.nEdit_String();
            this.tabArchive = new System.Windows.Forms.TabPage();
            this.gbAutoArchive = new System.Windows.Forms.GroupBox();
            this.gbArchiveDeleteSettings = new System.Windows.Forms.GroupBox();
            this.ctl_delete_archives = new NewMethod.nEdit_Boolean();
            this.label4 = new System.Windows.Forms.Label();
            this.udDeleteArchivePeriod = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.optArchive = new System.Windows.Forms.RadioButton();
            this.optNoArchive = new System.Windows.Forms.RadioButton();
            this.gbArchiveSettings = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.optToDelete = new System.Windows.Forms.RadioButton();
            this.optToArchive = new System.Windows.Forms.RadioButton();
            this.cboTimespan = new System.Windows.Forms.ComboBox();
            this.udArchivePeriod = new System.Windows.Forms.NumericUpDown();
            this.lblCleanOut = new System.Windows.Forms.Label();
            this.picBroomClock = new System.Windows.Forms.PictureBox();
            this.tabECommerce = new System.Windows.Forms.TabPage();
            this.ctl_websitegreeting = new NewMethod.nEdit_Memo();
            this.ctl_websiteresponse = new NewMethod.nEdit_Memo();
            this.ctl_websitemoniker = new NewMethod.nEdit_String();
            this.ctl_logopath = new NewMethod.nEdit_String();
            this.tabCallSchedule = new System.Windows.Forms.TabPage();
            this.chkCallSunday = new System.Windows.Forms.CheckBox();
            this.chkCallSaturday = new System.Windows.Forms.CheckBox();
            this.chkCallFriday = new System.Windows.Forms.CheckBox();
            this.chkCallThursday = new System.Windows.Forms.CheckBox();
            this.chkCallWednesday = new System.Windows.Forms.CheckBox();
            this.chkCallTuesday = new System.Windows.Forms.CheckBox();
            this.chkCallMonday = new System.Windows.Forms.CheckBox();
            this.tabCreditCard = new System.Windows.Forms.TabPage();
            this.ctl_bank_wire_info = new NewMethod.nEdit_Memo();
            this.ctl_securitycode = new NewMethod.nEdit_String();
            this.cmdSendCreditCardifoToQBs = new System.Windows.Forms.Button();
            this.ctl_nameoncard = new NewMethod.nEdit_String();
            this.ctl_cardbillingzip = new NewMethod.nEdit_String();
            this.ctl_cardbillingaddr = new NewMethod.nEdit_String();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctl_expiration_year = new NewMethod.nEdit_Number();
            this.ctl_expiration_month = new NewMethod.nEdit_Number();
            this.ctl_creditcardtype = new NewMethod.nEdit_List();
            this.ctl_creditcardnumber = new NewMethod.nEdit_String();
            this.pagePOInfo = new System.Windows.Forms.TabPage();
            this.lblNotifyList = new System.Windows.Forms.Label();
            this.lblClear = new System.Windows.Forms.LinkLabel();
            this.lblRemove = new System.Windows.Forms.LinkLabel();
            this.lblNotifyAdd = new System.Windows.Forms.LinkLabel();
            this.lblNotify = new System.Windows.Forms.Label();
            this.ctl_po_min = new NewMethod.nEdit_Number();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.ctl_Products_Components = new NewMethod.nEdit_Boolean();
            this.ctl_Products_PowerSupply = new NewMethod.nEdit_Boolean();
            this.ctl_Products_OpticalTransceiver = new NewMethod.nEdit_Boolean();
            this.lbl_Products = new System.Windows.Forms.Label();
            this.ctl_Products_SSD = new NewMethod.nEdit_Boolean();
            this.ctl_Products_Cabling = new NewMethod.nEdit_Boolean();
            this.ctl_Products_Interconnect = new NewMethod.nEdit_Boolean();
            this.ctl_Products_CrystalOsc = new NewMethod.nEdit_Boolean();
            this.ctl_Products_Relay = new NewMethod.nEdit_Boolean();
            this.ctl_Products_Display = new NewMethod.nEdit_Boolean();
            this.tsl = new System.Windows.Forms.TabControl();
            this.pageContacts = new System.Windows.Forms.TabPage();
            this.result_contacts = new NewMethod.nList();
            this.pageAddresses = new System.Windows.Forms.TabPage();
            this.result_addresses = new NewMethod.nList();
            this.tabAccounts = new System.Windows.Forms.TabPage();
            this.result_accounts = new NewMethod.nList();
            this.pageReqs = new System.Windows.Forms.TabPage();
            this.result_reqs = new NewMethod.nList();
            this.pageBatches = new System.Windows.Forms.TabPage();
            this.result_reqbatches = new NewMethod.nList();
            this.tabQuotes = new System.Windows.Forms.TabPage();
            this.panelAtometronQuote = new System.Windows.Forms.Panel();
            this.gbQuoteOptions = new System.Windows.Forms.GroupBox();
            this.optFormalQuotes = new System.Windows.Forms.RadioButton();
            this.optQuickQuotes = new System.Windows.Forms.RadioButton();
            this.lvQuotes = new NewMethod.nList();
            this.result_qquotes = new NewMethod.nList();
            this.result_fquotes = new NewMethod.nList();
            this.pageBids = new System.Windows.Forms.TabPage();
            this.gbBid = new System.Windows.Forms.GroupBox();
            this.optRelatedBids = new System.Windows.Forms.RadioButton();
            this.optActualBids = new System.Windows.Forms.RadioButton();
            this.result_bids = new NewMethod.nList();
            this.tabOrders = new System.Windows.Forms.TabPage();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.optLineItems = new System.Windows.Forms.RadioButton();
            this.optOrders = new System.Windows.Forms.RadioButton();
            this.result_orders = new NewMethod.nList();
            this.gbOrderOptions = new System.Windows.Forms.GroupBox();
            this.optService = new System.Windows.Forms.RadioButton();
            this.optVRMA = new System.Windows.Forms.RadioButton();
            this.optRMAs = new System.Windows.Forms.RadioButton();
            this.optInvoices = new System.Windows.Forms.RadioButton();
            this.optPurchase = new System.Windows.Forms.RadioButton();
            this.optSales = new System.Windows.Forms.RadioButton();
            this.optQuote = new System.Windows.Forms.RadioButton();
            this.optAll = new System.Windows.Forms.RadioButton();
            this.pageNotes = new System.Windows.Forms.TabPage();
            this.optUserNotes = new System.Windows.Forms.RadioButton();
            this.optStandard = new System.Windows.Forms.RadioButton();
            this.lvNotes = new NewMethod.nList();
            this.tabPortalSearches = new System.Windows.Forms.TabPage();
            this.lvPortalSearches = new NewMethod.nList();
            this.tabCalls = new System.Windows.Forms.TabPage();
            this.lvCalls = new NewMethod.nList();
            this.tabExcess = new System.Windows.Forms.TabPage();
            this.gbExcessOptions = new System.Windows.Forms.GroupBox();
            this.optOffers = new System.Windows.Forms.RadioButton();
            this.optArchivedExcess = new System.Windows.Forms.RadioButton();
            this.optExcess = new System.Windows.Forms.RadioButton();
            this.lvExcess = new NewMethod.nList();
            this.tabFeedback = new System.Windows.Forms.TabPage();
            this.lvFeedback = new NewMethod.nList();
            this.tabCompanyCredits = new System.Windows.Forms.TabPage();
            this.nListVendorCredits = new NewMethod.nList();
            this.tabGenie = new System.Windows.Forms.TabPage();
            this.wb_Genie = new ToolsWin.BrowserPlain();
            this.tabConsignCodes = new System.Windows.Forms.TabPage();
            this.consignmentCodes = new RzSensible.ConsignmentCodes();
            this.gbVet = new System.Windows.Forms.GroupBox();
            this.lblVetDate = new System.Windows.Forms.Label();
            this.lblVettedBy = new System.Windows.Forms.Label();
            this.cbx_is_vetted = new NewMethod.nEdit_Boolean();
            this.ctl_industry_segment = new NewMethod.nEdit_List();
            this.ctl_has_financials = new NewMethod.nEdit_Boolean();
            this.FeedbackControl = new Rz5.Feedback();
            this.ts.SuspendLayout();
            this.tabCompany.SuspendLayout();
            this.tabCommission.SuspendLayout();
            this.tabMore.SuspendLayout();
            this.tabTerms.SuspendLayout();
            this.gbVendor.SuspendLayout();
            this.gbCustomer.SuspendLayout();
            this.tabDescription.SuspendLayout();
            this.gbCompanyTermsConditions.SuspendLayout();
            this.tabAttachments.SuspendLayout();
            this.tabQB.SuspendLayout();
            this.tabArchive.SuspendLayout();
            this.gbAutoArchive.SuspendLayout();
            this.gbArchiveDeleteSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDeleteArchivePeriod)).BeginInit();
            this.gbArchiveSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udArchivePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBroomClock)).BeginInit();
            this.tabECommerce.SuspendLayout();
            this.tabCallSchedule.SuspendLayout();
            this.tabCreditCard.SuspendLayout();
            this.pagePOInfo.SuspendLayout();
            this.tabProducts.SuspendLayout();
            this.tsl.SuspendLayout();
            this.pageContacts.SuspendLayout();
            this.pageAddresses.SuspendLayout();
            this.tabAccounts.SuspendLayout();
            this.pageReqs.SuspendLayout();
            this.pageBatches.SuspendLayout();
            this.tabQuotes.SuspendLayout();
            this.panelAtometronQuote.SuspendLayout();
            this.gbQuoteOptions.SuspendLayout();
            this.pageBids.SuspendLayout();
            this.gbBid.SuspendLayout();
            this.tabOrders.SuspendLayout();
            this.gbSource.SuspendLayout();
            this.gbOrderOptions.SuspendLayout();
            this.pageNotes.SuspendLayout();
            this.tabPortalSearches.SuspendLayout();
            this.tabCalls.SuspendLayout();
            this.tabExcess.SuspendLayout();
            this.gbExcessOptions.SuspendLayout();
            this.tabFeedback.SuspendLayout();
            this.tabCompanyCredits.SuspendLayout();
            this.tabGenie.SuspendLayout();
            this.tabConsignCodes.SuspendLayout();
            this.gbVet.SuspendLayout();
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(744, 0);
            this.xActions.Size = new System.Drawing.Size(148, 615);
            // 
            // ts
            // 
            this.ts.Controls.Add(this.tabCompany);
            this.ts.Controls.Add(this.tabCommission);
            this.ts.Controls.Add(this.tabMore);
            this.ts.Controls.Add(this.tabTerms);
            this.ts.Controls.Add(this.tabDescription);
            this.ts.Controls.Add(this.tabAttachments);
            this.ts.Controls.Add(this.tabQB);
            this.ts.Controls.Add(this.tabArchive);
            this.ts.Controls.Add(this.tabECommerce);
            this.ts.Controls.Add(this.tabCallSchedule);
            this.ts.Controls.Add(this.tabCreditCard);
            this.ts.Controls.Add(this.pagePOInfo);
            this.ts.Controls.Add(this.tabProducts);
            this.ts.Location = new System.Drawing.Point(4, 2);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(630, 294);
            this.ts.TabIndex = 6;
            // 
            // tabCompany
            // 
            this.tabCompany.Controls.Add(this.lblVendorCredits);
            this.tabCompany.Controls.Add(this.lblProblemVendor);
            this.tabCompany.Controls.Add(this.lblOutstandingInvoiceAmnt);
            this.tabCompany.Controls.Add(this.lblProblemCustomer);
            this.tabCompany.Controls.Add(this.ctl_primarywebaddress);
            this.tabCompany.Controls.Add(this.ctl_isverified);
            this.tabCompany.Controls.Add(this.ctl_is_prospect);
            this.tabCompany.Controls.Add(this.ctl_primaryfax);
            this.tabCompany.Controls.Add(this.ctl_primaryphoneextension);
            this.tabCompany.Controls.Add(this.ctl_donotemail);
            this.tabCompany.Controls.Add(this.ctl_star_rating);
            this.tabCompany.Controls.Add(this.ctl_isdistributor);
            this.tabCompany.Controls.Add(this.ctl_iscem);
            this.tabCompany.Controls.Add(this.ctl_isoem);
            this.tabCompany.Controls.Add(this.lblScroll);
            this.tabCompany.Controls.Add(this.cmdForward);
            this.tabCompany.Controls.Add(this.cmdBack);
            this.tabCompany.Controls.Add(this.cmdChangeCompany);
            this.tabCompany.Controls.Add(this.ctl_isactive);
            this.tabCompany.Controls.Add(this.ctl_primaryemailaddress);
            this.tabCompany.Controls.Add(this.ctl_primaryphone);
            this.tabCompany.Controls.Add(this.ctl_companytype);
            this.tabCompany.Controls.Add(this.ctl_primarycontact);
            this.tabCompany.Controls.Add(this.user);
            this.tabCompany.Controls.Add(this.ctl_wherefoundcompany);
            this.tabCompany.Controls.Add(this.ctl_companyname);
            this.tabCompany.Controls.Add(this.ctl_c_of_c);
            this.tabCompany.Controls.Add(this.ctl_needs_contact);
            this.tabCompany.Controls.Add(this.cType);
            this.tabCompany.Location = new System.Drawing.Point(4, 22);
            this.tabCompany.Name = "tabCompany";
            this.tabCompany.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompany.Size = new System.Drawing.Size(622, 268);
            this.tabCompany.TabIndex = 0;
            this.tabCompany.Text = "Company";
            this.tabCompany.UseVisualStyleBackColor = true;
            // 
            // lblVendorCredits
            // 
            this.lblVendorCredits.AutoSize = true;
            this.lblVendorCredits.BackColor = System.Drawing.Color.Yellow;
            this.lblVendorCredits.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendorCredits.ForeColor = System.Drawing.Color.Red;
            this.lblVendorCredits.Location = new System.Drawing.Point(207, 92);
            this.lblVendorCredits.Name = "lblVendorCredits";
            this.lblVendorCredits.Size = new System.Drawing.Size(127, 17);
            this.lblVendorCredits.TabIndex = 59;
            this.lblVendorCredits.Text = "<vendorCredits>";
            // 
            // lblProblemVendor
            // 
            this.lblProblemVendor.AutoSize = true;
            this.lblProblemVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProblemVendor.ForeColor = System.Drawing.Color.Red;
            this.lblProblemVendor.Location = new System.Drawing.Point(356, 47);
            this.lblProblemVendor.Name = "lblProblemVendor";
            this.lblProblemVendor.Size = new System.Drawing.Size(124, 17);
            this.lblProblemVendor.TabIndex = 58;
            this.lblProblemVendor.Text = "Problem Vendor";
            this.lblProblemVendor.Visible = false;
            // 
            // lblOutstandingInvoiceAmnt
            // 
            this.lblOutstandingInvoiceAmnt.AutoSize = true;
            this.lblOutstandingInvoiceAmnt.BackColor = System.Drawing.Color.Yellow;
            this.lblOutstandingInvoiceAmnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutstandingInvoiceAmnt.ForeColor = System.Drawing.Color.Red;
            this.lblOutstandingInvoiceAmnt.Location = new System.Drawing.Point(207, 73);
            this.lblOutstandingInvoiceAmnt.Name = "lblOutstandingInvoiceAmnt";
            this.lblOutstandingInvoiceAmnt.Size = new System.Drawing.Size(162, 17);
            this.lblOutstandingInvoiceAmnt.TabIndex = 57;
            this.lblOutstandingInvoiceAmnt.Text = "<outstandingInvoice>";
            // 
            // lblProblemCustomer
            // 
            this.lblProblemCustomer.AutoSize = true;
            this.lblProblemCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProblemCustomer.ForeColor = System.Drawing.Color.Red;
            this.lblProblemCustomer.Location = new System.Drawing.Point(207, 47);
            this.lblProblemCustomer.Name = "lblProblemCustomer";
            this.lblProblemCustomer.Size = new System.Drawing.Size(140, 17);
            this.lblProblemCustomer.TabIndex = 55;
            this.lblProblemCustomer.Text = "Problem Customer";
            this.lblProblemCustomer.Visible = false;
            // 
            // ctl_primarywebaddress
            // 
            this.ctl_primarywebaddress.AllCaps = false;
            this.ctl_primarywebaddress.BackColor = System.Drawing.Color.Transparent;
            this.ctl_primarywebaddress.Bold = false;
            this.ctl_primarywebaddress.Caption = "Web Address";
            this.ctl_primarywebaddress.Changed = false;
            this.ctl_primarywebaddress.IsEmail = false;
            this.ctl_primarywebaddress.IsURL = true;
            this.ctl_primarywebaddress.Location = new System.Drawing.Point(463, 115);
            this.ctl_primarywebaddress.Name = "ctl_primarywebaddress";
            this.ctl_primarywebaddress.PasswordChar = '\0';
            this.ctl_primarywebaddress.Size = new System.Drawing.Size(148, 35);
            this.ctl_primarywebaddress.TabIndex = 38;
            this.ctl_primarywebaddress.UseParentBackColor = true;
            this.ctl_primarywebaddress.zz_Enabled = true;
            this.ctl_primarywebaddress.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_primarywebaddress.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_primarywebaddress.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_primarywebaddress.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_primarywebaddress.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_primarywebaddress.zz_OriginalDesign = false;
            this.ctl_primarywebaddress.zz_ShowLinkButton = true;
            this.ctl_primarywebaddress.zz_ShowNeedsSaveColor = true;
            this.ctl_primarywebaddress.zz_Text = "";
            this.ctl_primarywebaddress.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_primarywebaddress.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_primarywebaddress.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_primarywebaddress.zz_UseGlobalColor = false;
            this.ctl_primarywebaddress.zz_UseGlobalFont = false;
            // 
            // ctl_isverified
            // 
            this.ctl_isverified.BackColor = System.Drawing.Color.Transparent;
            this.ctl_isverified.Bold = false;
            this.ctl_isverified.Caption = "Verified";
            this.ctl_isverified.Changed = false;
            this.ctl_isverified.Location = new System.Drawing.Point(499, 54);
            this.ctl_isverified.Name = "ctl_isverified";
            this.ctl_isverified.Size = new System.Drawing.Size(61, 18);
            this.ctl_isverified.TabIndex = 37;
            this.ctl_isverified.UseParentBackColor = true;
            this.ctl_isverified.zz_CheckValue = false;
            this.ctl_isverified.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_isverified.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_isverified.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_isverified.zz_OriginalDesign = false;
            this.ctl_isverified.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_is_prospect
            // 
            this.ctl_is_prospect.BackColor = System.Drawing.Color.Transparent;
            this.ctl_is_prospect.Bold = false;
            this.ctl_is_prospect.Caption = "Prospect Account";
            this.ctl_is_prospect.Changed = false;
            this.ctl_is_prospect.Location = new System.Drawing.Point(34, 150);
            this.ctl_is_prospect.Name = "ctl_is_prospect";
            this.ctl_is_prospect.Size = new System.Drawing.Size(111, 18);
            this.ctl_is_prospect.TabIndex = 36;
            this.ctl_is_prospect.UseParentBackColor = true;
            this.ctl_is_prospect.Visible = false;
            this.ctl_is_prospect.zz_CheckValue = false;
            this.ctl_is_prospect.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_prospect.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_is_prospect.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_prospect.zz_OriginalDesign = false;
            this.ctl_is_prospect.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_primaryfax
            // 
            this.ctl_primaryfax.AllCaps = false;
            this.ctl_primaryfax.BackColor = System.Drawing.Color.Transparent;
            this.ctl_primaryfax.Bold = false;
            this.ctl_primaryfax.Caption = "Fax";
            this.ctl_primaryfax.Changed = false;
            this.ctl_primaryfax.IsEmail = false;
            this.ctl_primaryfax.IsURL = false;
            this.ctl_primaryfax.Location = new System.Drawing.Point(181, 106);
            this.ctl_primaryfax.Name = "ctl_primaryfax";
            this.ctl_primaryfax.PasswordChar = '\0';
            this.ctl_primaryfax.Size = new System.Drawing.Size(119, 44);
            this.ctl_primaryfax.TabIndex = 8;
            this.ctl_primaryfax.UseParentBackColor = true;
            this.ctl_primaryfax.zz_Enabled = true;
            this.ctl_primaryfax.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_primaryfax.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_primaryfax.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_primaryfax.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_primaryfax.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_primaryfax.zz_OriginalDesign = true;
            this.ctl_primaryfax.zz_ShowLinkButton = false;
            this.ctl_primaryfax.zz_ShowNeedsSaveColor = true;
            this.ctl_primaryfax.zz_Text = "";
            this.ctl_primaryfax.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_primaryfax.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_primaryfax.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_primaryfax.zz_UseGlobalColor = false;
            this.ctl_primaryfax.zz_UseGlobalFont = false;
            // 
            // ctl_primaryphoneextension
            // 
            this.ctl_primaryphoneextension.AllCaps = false;
            this.ctl_primaryphoneextension.BackColor = System.Drawing.Color.Transparent;
            this.ctl_primaryphoneextension.Bold = false;
            this.ctl_primaryphoneextension.Caption = "Ext";
            this.ctl_primaryphoneextension.Changed = false;
            this.ctl_primaryphoneextension.IsEmail = false;
            this.ctl_primaryphoneextension.IsURL = false;
            this.ctl_primaryphoneextension.Location = new System.Drawing.Point(128, 106);
            this.ctl_primaryphoneextension.Name = "ctl_primaryphoneextension";
            this.ctl_primaryphoneextension.PasswordChar = '\0';
            this.ctl_primaryphoneextension.Size = new System.Drawing.Size(47, 44);
            this.ctl_primaryphoneextension.TabIndex = 35;
            this.ctl_primaryphoneextension.UseParentBackColor = true;
            this.ctl_primaryphoneextension.zz_Enabled = true;
            this.ctl_primaryphoneextension.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_primaryphoneextension.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_primaryphoneextension.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_primaryphoneextension.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_primaryphoneextension.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_primaryphoneextension.zz_OriginalDesign = true;
            this.ctl_primaryphoneextension.zz_ShowLinkButton = false;
            this.ctl_primaryphoneextension.zz_ShowNeedsSaveColor = true;
            this.ctl_primaryphoneextension.zz_Text = "";
            this.ctl_primaryphoneextension.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_primaryphoneextension.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_primaryphoneextension.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_primaryphoneextension.zz_UseGlobalColor = false;
            this.ctl_primaryphoneextension.zz_UseGlobalFont = false;
            // 
            // ctl_donotemail
            // 
            this.ctl_donotemail.BackColor = System.Drawing.Color.Transparent;
            this.ctl_donotemail.Bold = false;
            this.ctl_donotemail.Caption = "Do Not Email";
            this.ctl_donotemail.Changed = false;
            this.ctl_donotemail.ForeColor = System.Drawing.Color.Red;
            this.ctl_donotemail.Location = new System.Drawing.Point(499, 72);
            this.ctl_donotemail.Name = "ctl_donotemail";
            this.ctl_donotemail.Size = new System.Drawing.Size(88, 18);
            this.ctl_donotemail.TabIndex = 34;
            this.ctl_donotemail.UseParentBackColor = false;
            this.ctl_donotemail.zz_CheckValue = false;
            this.ctl_donotemail.zz_LabelColor = System.Drawing.Color.Red;
            this.ctl_donotemail.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_donotemail.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_donotemail.zz_OriginalDesign = false;
            this.ctl_donotemail.zz_ShowNeedsSaveColor = true;
            this.ctl_donotemail.CheckChanged += new NewMethod.CheckChangedHandler(this.ctl_donotemail_CheckChanged);
            // 
            // ctl_star_rating
            // 
            this.ctl_star_rating.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ctl_star_rating.Bold = false;
            this.ctl_star_rating.Caption = "Star Rating";
            this.ctl_star_rating.Changed = false;
            this.ctl_star_rating.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_star_rating.Location = new System.Drawing.Point(541, 210);
            this.ctl_star_rating.Name = "ctl_star_rating";
            this.ctl_star_rating.Size = new System.Drawing.Size(75, 37);
            this.ctl_star_rating.TabIndex = 32;
            this.ctl_star_rating.UseParentBackColor = false;
            this.ctl_star_rating.Visible = false;
            this.ctl_star_rating.zz_Enabled = true;
            this.ctl_star_rating.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_star_rating.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_star_rating.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_star_rating.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_star_rating.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_star_rating.zz_OriginalDesign = true;
            this.ctl_star_rating.zz_ShowErrorColor = true;
            this.ctl_star_rating.zz_ShowNeedsSaveColor = true;
            this.ctl_star_rating.zz_Text = "";
            this.ctl_star_rating.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_star_rating.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_star_rating.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_star_rating.zz_UseGlobalColor = false;
            this.ctl_star_rating.zz_UseGlobalFont = false;
            // 
            // ctl_isdistributor
            // 
            this.ctl_isdistributor.BackColor = System.Drawing.Color.Transparent;
            this.ctl_isdistributor.Bold = false;
            this.ctl_isdistributor.Caption = "Distributor";
            this.ctl_isdistributor.Changed = false;
            this.ctl_isdistributor.Location = new System.Drawing.Point(288, 172);
            this.ctl_isdistributor.Name = "ctl_isdistributor";
            this.ctl_isdistributor.Size = new System.Drawing.Size(73, 18);
            this.ctl_isdistributor.TabIndex = 16;
            this.ctl_isdistributor.UseParentBackColor = true;
            this.ctl_isdistributor.zz_CheckValue = false;
            this.ctl_isdistributor.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_isdistributor.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_isdistributor.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_isdistributor.zz_OriginalDesign = false;
            this.ctl_isdistributor.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_iscem
            // 
            this.ctl_iscem.BackColor = System.Drawing.Color.Transparent;
            this.ctl_iscem.Bold = false;
            this.ctl_iscem.Caption = "CEM";
            this.ctl_iscem.Changed = false;
            this.ctl_iscem.Location = new System.Drawing.Point(423, 172);
            this.ctl_iscem.Name = "ctl_iscem";
            this.ctl_iscem.Size = new System.Drawing.Size(49, 18);
            this.ctl_iscem.TabIndex = 28;
            this.ctl_iscem.UseParentBackColor = true;
            this.ctl_iscem.zz_CheckValue = false;
            this.ctl_iscem.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_iscem.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_iscem.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_iscem.zz_OriginalDesign = false;
            this.ctl_iscem.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_isoem
            // 
            this.ctl_isoem.BackColor = System.Drawing.Color.Transparent;
            this.ctl_isoem.Bold = false;
            this.ctl_isoem.Caption = "OEM";
            this.ctl_isoem.Changed = false;
            this.ctl_isoem.Location = new System.Drawing.Point(367, 172);
            this.ctl_isoem.Name = "ctl_isoem";
            this.ctl_isoem.Size = new System.Drawing.Size(50, 18);
            this.ctl_isoem.TabIndex = 26;
            this.ctl_isoem.UseParentBackColor = true;
            this.ctl_isoem.zz_CheckValue = false;
            this.ctl_isoem.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_isoem.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_isoem.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_isoem.zz_OriginalDesign = false;
            this.ctl_isoem.zz_ShowNeedsSaveColor = true;
            // 
            // lblScroll
            // 
            this.lblScroll.Location = new System.Drawing.Point(131, 3);
            this.lblScroll.Name = "lblScroll";
            this.lblScroll.Size = new System.Drawing.Size(157, 20);
            this.lblScroll.TabIndex = 20;
            this.lblScroll.Text = "<scroll>";
            this.lblScroll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblScroll.Visible = false;
            // 
            // cmdForward
            // 
            this.cmdForward.Location = new System.Drawing.Point(334, 0);
            this.cmdForward.Name = "cmdForward";
            this.cmdForward.Size = new System.Drawing.Size(40, 21);
            this.cmdForward.TabIndex = 19;
            this.cmdForward.Text = ">";
            this.cmdForward.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdForward.UseVisualStyleBackColor = true;
            this.cmdForward.Visible = false;
            // 
            // cmdBack
            // 
            this.cmdBack.Location = new System.Drawing.Point(288, 0);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(40, 21);
            this.cmdBack.TabIndex = 18;
            this.cmdBack.Text = "<";
            this.cmdBack.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdBack.UseVisualStyleBackColor = true;
            this.cmdBack.Visible = false;
            // 
            // cmdChangeCompany
            // 
            this.cmdChangeCompany.Location = new System.Drawing.Point(334, 23);
            this.cmdChangeCompany.Name = "cmdChangeCompany";
            this.cmdChangeCompany.Size = new System.Drawing.Size(40, 21);
            this.cmdChangeCompany.TabIndex = 1;
            this.cmdChangeCompany.Text = "...";
            this.cmdChangeCompany.UseVisualStyleBackColor = true;
            this.cmdChangeCompany.Click += new System.EventHandler(this.cmdChangeCompany_Click_2);
            // 
            // ctl_isactive
            // 
            this.ctl_isactive.BackColor = System.Drawing.Color.Transparent;
            this.ctl_isactive.Bold = false;
            this.ctl_isactive.Caption = "Active";
            this.ctl_isactive.Changed = false;
            this.ctl_isactive.Location = new System.Drawing.Point(499, 0);
            this.ctl_isactive.Name = "ctl_isactive";
            this.ctl_isactive.Size = new System.Drawing.Size(56, 18);
            this.ctl_isactive.TabIndex = 3;
            this.ctl_isactive.UseParentBackColor = true;
            this.ctl_isactive.zz_CheckValue = false;
            this.ctl_isactive.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_isactive.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_isactive.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_isactive.zz_OriginalDesign = false;
            this.ctl_isactive.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_primaryemailaddress
            // 
            this.ctl_primaryemailaddress.AllCaps = false;
            this.ctl_primaryemailaddress.BackColor = System.Drawing.Color.Transparent;
            this.ctl_primaryemailaddress.Bold = false;
            this.ctl_primaryemailaddress.Caption = "Email";
            this.ctl_primaryemailaddress.Changed = false;
            this.ctl_primaryemailaddress.IsEmail = true;
            this.ctl_primaryemailaddress.IsURL = false;
            this.ctl_primaryemailaddress.Location = new System.Drawing.Point(309, 106);
            this.ctl_primaryemailaddress.Name = "ctl_primaryemailaddress";
            this.ctl_primaryemailaddress.PasswordChar = '\0';
            this.ctl_primaryemailaddress.Size = new System.Drawing.Size(148, 44);
            this.ctl_primaryemailaddress.TabIndex = 9;
            this.ctl_primaryemailaddress.UseParentBackColor = true;
            this.ctl_primaryemailaddress.zz_Enabled = true;
            this.ctl_primaryemailaddress.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_primaryemailaddress.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_primaryemailaddress.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_primaryemailaddress.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_primaryemailaddress.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_primaryemailaddress.zz_OriginalDesign = true;
            this.ctl_primaryemailaddress.zz_ShowLinkButton = false;
            this.ctl_primaryemailaddress.zz_ShowNeedsSaveColor = true;
            this.ctl_primaryemailaddress.zz_Text = "";
            this.ctl_primaryemailaddress.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_primaryemailaddress.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_primaryemailaddress.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_primaryemailaddress.zz_UseGlobalColor = false;
            this.ctl_primaryemailaddress.zz_UseGlobalFont = false;
            // 
            // ctl_primaryphone
            // 
            this.ctl_primaryphone.AllCaps = false;
            this.ctl_primaryphone.BackColor = System.Drawing.Color.Transparent;
            this.ctl_primaryphone.Bold = false;
            this.ctl_primaryphone.Caption = "Phone";
            this.ctl_primaryphone.Changed = false;
            this.ctl_primaryphone.IsEmail = false;
            this.ctl_primaryphone.IsURL = false;
            this.ctl_primaryphone.Location = new System.Drawing.Point(3, 106);
            this.ctl_primaryphone.Name = "ctl_primaryphone";
            this.ctl_primaryphone.PasswordChar = '\0';
            this.ctl_primaryphone.Size = new System.Drawing.Size(119, 44);
            this.ctl_primaryphone.TabIndex = 5;
            this.ctl_primaryphone.UseParentBackColor = true;
            this.ctl_primaryphone.zz_Enabled = true;
            this.ctl_primaryphone.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_primaryphone.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_primaryphone.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_primaryphone.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_primaryphone.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_primaryphone.zz_OriginalDesign = true;
            this.ctl_primaryphone.zz_ShowLinkButton = false;
            this.ctl_primaryphone.zz_ShowNeedsSaveColor = true;
            this.ctl_primaryphone.zz_Text = "";
            this.ctl_primaryphone.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_primaryphone.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_primaryphone.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_primaryphone.zz_UseGlobalColor = false;
            this.ctl_primaryphone.zz_UseGlobalFont = false;
            // 
            // ctl_companytype
            // 
            this.ctl_companytype.AllCaps = false;
            this.ctl_companytype.AllowEdit = false;
            this.ctl_companytype.BackColor = System.Drawing.Color.Transparent;
            this.ctl_companytype.Bold = false;
            this.ctl_companytype.Caption = "Type";
            this.ctl_companytype.Changed = false;
            this.ctl_companytype.ListName = "companytype";
            this.ctl_companytype.Location = new System.Drawing.Point(3, 156);
            this.ctl_companytype.Name = "ctl_companytype";
            this.ctl_companytype.SimpleList = null;
            this.ctl_companytype.Size = new System.Drawing.Size(266, 36);
            this.ctl_companytype.TabIndex = 6;
            this.ctl_companytype.UseParentBackColor = true;
            this.ctl_companytype.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_companytype.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_companytype.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_companytype.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_companytype.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_companytype.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_companytype.zz_OriginalDesign = false;
            this.ctl_companytype.zz_ShowNeedsSaveColor = true;
            this.ctl_companytype.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_companytype.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_companytype.zz_UseGlobalColor = false;
            this.ctl_companytype.zz_UseGlobalFont = false;
            // 
            // ctl_primarycontact
            // 
            this.ctl_primarycontact.AllCaps = false;
            this.ctl_primarycontact.BackColor = System.Drawing.Color.Transparent;
            this.ctl_primarycontact.Bold = false;
            this.ctl_primarycontact.Caption = "Contact";
            this.ctl_primarycontact.Changed = false;
            this.ctl_primarycontact.IsEmail = false;
            this.ctl_primarycontact.IsURL = false;
            this.ctl_primarycontact.Location = new System.Drawing.Point(3, 203);
            this.ctl_primarycontact.Name = "ctl_primarycontact";
            this.ctl_primarycontact.PasswordChar = '\0';
            this.ctl_primarycontact.Size = new System.Drawing.Size(266, 44);
            this.ctl_primarycontact.TabIndex = 7;
            this.ctl_primarycontact.UseParentBackColor = true;
            this.ctl_primarycontact.zz_Enabled = true;
            this.ctl_primarycontact.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_primarycontact.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_primarycontact.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_primarycontact.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_primarycontact.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_primarycontact.zz_OriginalDesign = true;
            this.ctl_primarycontact.zz_ShowLinkButton = false;
            this.ctl_primarycontact.zz_ShowNeedsSaveColor = true;
            this.ctl_primarycontact.zz_Text = "";
            this.ctl_primarycontact.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_primarycontact.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_primarycontact.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_primarycontact.zz_UseGlobalColor = false;
            this.ctl_primarycontact.zz_UseGlobalFont = false;
            // 
            // user
            // 
            this.user.AllowChange = true;
            this.user.AllowClear = false;
            this.user.AllowNew = false;
            this.user.AllowView = false;
            this.user.BackColor = System.Drawing.Color.Transparent;
            this.user.Bold = false;
            this.user.Caption = "Agent";
            this.user.Changed = false;
            this.user.Location = new System.Drawing.Point(3, 50);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(200, 59);
            this.user.TabIndex = 2;
            this.user.UseParentBackColor = true;
            this.user.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.user.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            // 
            // ctl_wherefoundcompany
            // 
            this.ctl_wherefoundcompany.AllCaps = false;
            this.ctl_wherefoundcompany.AllowEdit = false;
            this.ctl_wherefoundcompany.BackColor = System.Drawing.Color.Transparent;
            this.ctl_wherefoundcompany.Bold = false;
            this.ctl_wherefoundcompany.Caption = "Source";
            this.ctl_wherefoundcompany.Changed = false;
            this.ctl_wherefoundcompany.ListName = "source";
            this.ctl_wherefoundcompany.Location = new System.Drawing.Point(379, 6);
            this.ctl_wherefoundcompany.Name = "ctl_wherefoundcompany";
            this.ctl_wherefoundcompany.SimpleList = null;
            this.ctl_wherefoundcompany.Size = new System.Drawing.Size(109, 36);
            this.ctl_wherefoundcompany.TabIndex = 2;
            this.ctl_wherefoundcompany.UseParentBackColor = true;
            this.ctl_wherefoundcompany.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctl_wherefoundcompany.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_wherefoundcompany.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_wherefoundcompany.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_wherefoundcompany.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_wherefoundcompany.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_wherefoundcompany.zz_OriginalDesign = false;
            this.ctl_wherefoundcompany.zz_ShowNeedsSaveColor = true;
            this.ctl_wherefoundcompany.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_wherefoundcompany.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_wherefoundcompany.zz_UseGlobalColor = false;
            this.ctl_wherefoundcompany.zz_UseGlobalFont = false;
            // 
            // ctl_companyname
            // 
            this.ctl_companyname.AllCaps = false;
            this.ctl_companyname.BackColor = System.Drawing.Color.Transparent;
            this.ctl_companyname.Bold = true;
            this.ctl_companyname.Caption = "Company Name";
            this.ctl_companyname.Changed = false;
            this.ctl_companyname.Enabled = false;
            this.ctl_companyname.IsEmail = false;
            this.ctl_companyname.IsURL = false;
            this.ctl_companyname.Location = new System.Drawing.Point(6, 3);
            this.ctl_companyname.Name = "ctl_companyname";
            this.ctl_companyname.PasswordChar = '\0';
            this.ctl_companyname.Size = new System.Drawing.Size(322, 44);
            this.ctl_companyname.TabIndex = 0;
            this.ctl_companyname.UseParentBackColor = true;
            this.ctl_companyname.zz_Enabled = true;
            this.ctl_companyname.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_companyname.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_companyname.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_companyname.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
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
            // ctl_c_of_c
            // 
            this.ctl_c_of_c.BackColor = System.Drawing.Color.Transparent;
            this.ctl_c_of_c.Bold = false;
            this.ctl_c_of_c.Caption = "C of C";
            this.ctl_c_of_c.Changed = false;
            this.ctl_c_of_c.Location = new System.Drawing.Point(499, 18);
            this.ctl_c_of_c.Name = "ctl_c_of_c";
            this.ctl_c_of_c.Size = new System.Drawing.Size(55, 18);
            this.ctl_c_of_c.TabIndex = 21;
            this.ctl_c_of_c.UseParentBackColor = true;
            this.ctl_c_of_c.zz_CheckValue = false;
            this.ctl_c_of_c.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_c_of_c.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_c_of_c.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_c_of_c.zz_OriginalDesign = false;
            this.ctl_c_of_c.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_needs_contact
            // 
            this.ctl_needs_contact.BackColor = System.Drawing.Color.Transparent;
            this.ctl_needs_contact.Bold = false;
            this.ctl_needs_contact.Caption = "Needs Contact";
            this.ctl_needs_contact.Changed = false;
            this.ctl_needs_contact.Location = new System.Drawing.Point(499, 36);
            this.ctl_needs_contact.Name = "ctl_needs_contact";
            this.ctl_needs_contact.Size = new System.Drawing.Size(97, 18);
            this.ctl_needs_contact.TabIndex = 22;
            this.ctl_needs_contact.UseParentBackColor = true;
            this.ctl_needs_contact.zz_CheckValue = false;
            this.ctl_needs_contact.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_needs_contact.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_needs_contact.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_needs_contact.zz_OriginalDesign = false;
            this.ctl_needs_contact.zz_ShowNeedsSaveColor = true;
            // 
            // cType
            // 
            this.cType.BackColor = System.Drawing.SystemColors.ControlText;
            this.cType.Location = new System.Drawing.Point(421, 221);
            this.cType.Name = "cType";
            this.cType.Size = new System.Drawing.Size(112, 22);
            this.cType.TabIndex = 4;
            // 
            // tabCommission
            // 
            this.tabCommission.Controls.Add(this.sc1);
            this.tabCommission.Location = new System.Drawing.Point(4, 22);
            this.tabCommission.Name = "tabCommission";
            this.tabCommission.Size = new System.Drawing.Size(192, 74);
            this.tabCommission.TabIndex = 12;
            this.tabCommission.Text = "Commisison";
            this.tabCommission.UseVisualStyleBackColor = true;
            // 
            // sc1
            // 
            this.sc1.BackColor = System.Drawing.Color.White;
            this.sc1.CurrentAgent = null;
            this.sc1.ListAcquisitionAgent = null;
            this.sc1.Location = new System.Drawing.Point(3, 3);
            this.sc1.Name = "sc1";
            this.sc1.Size = new System.Drawing.Size(421, 262);
            this.sc1.SplitCommissionAgent = null;
            this.sc1.splitCommissionObject = null;
            this.sc1.TabIndex = 0;
            // 
            // tabMore
            // 
            this.tabMore.Controls.Add(this.ctl_GCAT_required);
            this.tabMore.Controls.Add(this.ctl_timezone);
            this.tabMore.Controls.Add(this.optViewVend);
            this.tabMore.Controls.Add(this.optViewCust);
            this.tabMore.Controls.Add(this.ctl_internetpassword);
            this.tabMore.Controls.Add(this.ctl_internetusername);
            this.tabMore.Controls.Add(this.ctl_vendoraccountnumber);
            this.tabMore.Controls.Add(this.ctl_internalcompanyname);
            this.tabMore.Controls.Add(this.ctl_lastcontactdate);
            this.tabMore.Controls.Add(this.ctl_rfqemail);
            this.tabMore.Controls.Add(this.ctl_zipcode);
            this.tabMore.Controls.Add(this.ctl_statename);
            this.tabMore.Controls.Add(this.ctl_contactfrequency);
            this.tabMore.Controls.Add(this.ctl_instockonly);
            this.tabMore.Controls.Add(this.ctl_companycode);
            this.tabMore.Controls.Add(this.ctl_companynumber);
            this.tabMore.Controls.Add(this.ctl_taxid);
            this.tabMore.Controls.Add(this.ctl_companyrating);
            this.tabMore.Controls.Add(this.ctl_pricelevel);
            this.tabMore.Controls.Add(this.ctl_donotrfq);
            this.tabMore.Controls.Add(this.ctl_isinternational);
            this.tabMore.Controls.Add(this.ctl_country);
            this.tabMore.Controls.Add(this.ctl_alias1);
            this.tabMore.Location = new System.Drawing.Point(4, 22);
            this.tabMore.Name = "tabMore";
            this.tabMore.Padding = new System.Windows.Forms.Padding(3);
            this.tabMore.Size = new System.Drawing.Size(192, 74);
            this.tabMore.TabIndex = 1;
            this.tabMore.Text = "More Info";
            this.tabMore.UseVisualStyleBackColor = true;
            // 
            // ctl_GCAT_required
            // 
            this.ctl_GCAT_required.BackColor = System.Drawing.Color.Transparent;
            this.ctl_GCAT_required.Bold = false;
            this.ctl_GCAT_required.Caption = "GCAT Required (All Orders)";
            this.ctl_GCAT_required.Changed = false;
            this.ctl_GCAT_required.Location = new System.Drawing.Point(8, 145);
            this.ctl_GCAT_required.Name = "ctl_GCAT_required";
            this.ctl_GCAT_required.Size = new System.Drawing.Size(155, 18);
            this.ctl_GCAT_required.TabIndex = 40;
            this.ctl_GCAT_required.UseParentBackColor = true;
            this.ctl_GCAT_required.zz_CheckValue = false;
            this.ctl_GCAT_required.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_GCAT_required.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_GCAT_required.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_GCAT_required.zz_OriginalDesign = false;
            this.ctl_GCAT_required.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_timezone
            // 
            this.ctl_timezone.AllCaps = false;
            this.ctl_timezone.AllowEdit = false;
            this.ctl_timezone.BackColor = System.Drawing.Color.Transparent;
            this.ctl_timezone.Bold = false;
            this.ctl_timezone.Caption = "Time Zone";
            this.ctl_timezone.Changed = false;
            this.ctl_timezone.ListName = "timezone";
            this.ctl_timezone.Location = new System.Drawing.Point(162, 63);
            this.ctl_timezone.Name = "ctl_timezone";
            this.ctl_timezone.SimpleList = null;
            this.ctl_timezone.Size = new System.Drawing.Size(150, 36);
            this.ctl_timezone.TabIndex = 39;
            this.ctl_timezone.UseParentBackColor = true;
            this.ctl_timezone.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_timezone.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_timezone.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_timezone.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_timezone.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_timezone.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_timezone.zz_OriginalDesign = false;
            this.ctl_timezone.zz_ShowNeedsSaveColor = true;
            this.ctl_timezone.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_timezone.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_timezone.zz_UseGlobalColor = false;
            this.ctl_timezone.zz_UseGlobalFont = false;
            // 
            // optViewVend
            // 
            this.optViewVend.AutoSize = true;
            this.optViewVend.Location = new System.Drawing.Point(315, 74);
            this.optViewVend.Name = "optViewVend";
            this.optViewVend.Size = new System.Drawing.Size(85, 17);
            this.optViewVend.TabIndex = 33;
            this.optViewVend.Text = "View Vendor";
            this.optViewVend.UseVisualStyleBackColor = true;
            this.optViewVend.Visible = false;
            // 
            // optViewCust
            // 
            this.optViewCust.AutoSize = true;
            this.optViewCust.Location = new System.Drawing.Point(315, 57);
            this.optViewCust.Name = "optViewCust";
            this.optViewCust.Size = new System.Drawing.Size(95, 17);
            this.optViewCust.TabIndex = 32;
            this.optViewCust.Text = "View Customer";
            this.optViewCust.UseVisualStyleBackColor = true;
            this.optViewCust.Visible = false;
            // 
            // ctl_internetpassword
            // 
            this.ctl_internetpassword.AllCaps = false;
            this.ctl_internetpassword.BackColor = System.Drawing.Color.Transparent;
            this.ctl_internetpassword.Bold = false;
            this.ctl_internetpassword.Caption = "Internet Password";
            this.ctl_internetpassword.Changed = false;
            this.ctl_internetpassword.IsEmail = false;
            this.ctl_internetpassword.IsURL = false;
            this.ctl_internetpassword.Location = new System.Drawing.Point(468, 208);
            this.ctl_internetpassword.Name = "ctl_internetpassword";
            this.ctl_internetpassword.PasswordChar = '\0';
            this.ctl_internetpassword.Size = new System.Drawing.Size(149, 35);
            this.ctl_internetpassword.TabIndex = 31;
            this.ctl_internetpassword.UseParentBackColor = false;
            this.ctl_internetpassword.zz_Enabled = true;
            this.ctl_internetpassword.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_internetpassword.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_internetpassword.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_internetpassword.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_internetpassword.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_internetpassword.zz_OriginalDesign = false;
            this.ctl_internetpassword.zz_ShowLinkButton = false;
            this.ctl_internetpassword.zz_ShowNeedsSaveColor = true;
            this.ctl_internetpassword.zz_Text = "";
            this.ctl_internetpassword.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_internetpassword.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_internetpassword.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internetpassword.zz_UseGlobalColor = false;
            this.ctl_internetpassword.zz_UseGlobalFont = false;
            // 
            // ctl_internetusername
            // 
            this.ctl_internetusername.AllCaps = false;
            this.ctl_internetusername.BackColor = System.Drawing.Color.Transparent;
            this.ctl_internetusername.Bold = false;
            this.ctl_internetusername.Caption = "Internet Username";
            this.ctl_internetusername.Changed = false;
            this.ctl_internetusername.IsEmail = false;
            this.ctl_internetusername.IsURL = false;
            this.ctl_internetusername.Location = new System.Drawing.Point(315, 208);
            this.ctl_internetusername.Name = "ctl_internetusername";
            this.ctl_internetusername.PasswordChar = '\0';
            this.ctl_internetusername.Size = new System.Drawing.Size(149, 35);
            this.ctl_internetusername.TabIndex = 30;
            this.ctl_internetusername.UseParentBackColor = false;
            this.ctl_internetusername.zz_Enabled = true;
            this.ctl_internetusername.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_internetusername.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_internetusername.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_internetusername.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_internetusername.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_internetusername.zz_OriginalDesign = false;
            this.ctl_internetusername.zz_ShowLinkButton = false;
            this.ctl_internetusername.zz_ShowNeedsSaveColor = true;
            this.ctl_internetusername.zz_Text = "";
            this.ctl_internetusername.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_internetusername.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_internetusername.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internetusername.zz_UseGlobalColor = false;
            this.ctl_internetusername.zz_UseGlobalFont = false;
            // 
            // ctl_vendoraccountnumber
            // 
            this.ctl_vendoraccountnumber.AllCaps = false;
            this.ctl_vendoraccountnumber.BackColor = System.Drawing.Color.Transparent;
            this.ctl_vendoraccountnumber.Bold = false;
            this.ctl_vendoraccountnumber.Caption = "Vendor Account Number";
            this.ctl_vendoraccountnumber.Changed = false;
            this.ctl_vendoraccountnumber.IsEmail = false;
            this.ctl_vendoraccountnumber.IsURL = false;
            this.ctl_vendoraccountnumber.Location = new System.Drawing.Point(315, 6);
            this.ctl_vendoraccountnumber.Name = "ctl_vendoraccountnumber";
            this.ctl_vendoraccountnumber.PasswordChar = '\0';
            this.ctl_vendoraccountnumber.Size = new System.Drawing.Size(149, 45);
            this.ctl_vendoraccountnumber.TabIndex = 21;
            this.ctl_vendoraccountnumber.UseParentBackColor = true;
            this.ctl_vendoraccountnumber.zz_Enabled = true;
            this.ctl_vendoraccountnumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_vendoraccountnumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_vendoraccountnumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_vendoraccountnumber.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_vendoraccountnumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_vendoraccountnumber.zz_OriginalDesign = true;
            this.ctl_vendoraccountnumber.zz_ShowLinkButton = false;
            this.ctl_vendoraccountnumber.zz_ShowNeedsSaveColor = true;
            this.ctl_vendoraccountnumber.zz_Text = "";
            this.ctl_vendoraccountnumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_vendoraccountnumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_vendoraccountnumber.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_vendoraccountnumber.zz_UseGlobalColor = false;
            this.ctl_vendoraccountnumber.zz_UseGlobalFont = false;
            // 
            // ctl_internalcompanyname
            // 
            this.ctl_internalcompanyname.AllCaps = false;
            this.ctl_internalcompanyname.BackColor = System.Drawing.Color.Transparent;
            this.ctl_internalcompanyname.Bold = false;
            this.ctl_internalcompanyname.Caption = "Internal Name";
            this.ctl_internalcompanyname.Changed = false;
            this.ctl_internalcompanyname.IsEmail = false;
            this.ctl_internalcompanyname.IsURL = false;
            this.ctl_internalcompanyname.Location = new System.Drawing.Point(468, 108);
            this.ctl_internalcompanyname.Name = "ctl_internalcompanyname";
            this.ctl_internalcompanyname.PasswordChar = '\0';
            this.ctl_internalcompanyname.Size = new System.Drawing.Size(149, 45);
            this.ctl_internalcompanyname.TabIndex = 28;
            this.ctl_internalcompanyname.UseParentBackColor = true;
            this.ctl_internalcompanyname.zz_Enabled = true;
            this.ctl_internalcompanyname.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_internalcompanyname.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_internalcompanyname.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_internalcompanyname.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_internalcompanyname.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_internalcompanyname.zz_OriginalDesign = true;
            this.ctl_internalcompanyname.zz_ShowLinkButton = false;
            this.ctl_internalcompanyname.zz_ShowNeedsSaveColor = true;
            this.ctl_internalcompanyname.zz_Text = "";
            this.ctl_internalcompanyname.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_internalcompanyname.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_internalcompanyname.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internalcompanyname.zz_UseGlobalColor = false;
            this.ctl_internalcompanyname.zz_UseGlobalFont = false;
            // 
            // ctl_lastcontactdate
            // 
            this.ctl_lastcontactdate.AllCaps = false;
            this.ctl_lastcontactdate.BackColor = System.Drawing.Color.Transparent;
            this.ctl_lastcontactdate.Bold = false;
            this.ctl_lastcontactdate.Caption = "Last Contact Date";
            this.ctl_lastcontactdate.Changed = false;
            this.ctl_lastcontactdate.IsEmail = false;
            this.ctl_lastcontactdate.IsURL = false;
            this.ctl_lastcontactdate.Location = new System.Drawing.Point(468, 57);
            this.ctl_lastcontactdate.Name = "ctl_lastcontactdate";
            this.ctl_lastcontactdate.PasswordChar = '\0';
            this.ctl_lastcontactdate.Size = new System.Drawing.Size(149, 45);
            this.ctl_lastcontactdate.TabIndex = 27;
            this.ctl_lastcontactdate.UseParentBackColor = true;
            this.ctl_lastcontactdate.zz_Enabled = true;
            this.ctl_lastcontactdate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_lastcontactdate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_lastcontactdate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_lastcontactdate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_lastcontactdate.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_lastcontactdate.zz_OriginalDesign = true;
            this.ctl_lastcontactdate.zz_ShowLinkButton = false;
            this.ctl_lastcontactdate.zz_ShowNeedsSaveColor = true;
            this.ctl_lastcontactdate.zz_Text = "";
            this.ctl_lastcontactdate.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_lastcontactdate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_lastcontactdate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_lastcontactdate.zz_UseGlobalColor = false;
            this.ctl_lastcontactdate.zz_UseGlobalFont = false;
            // 
            // ctl_rfqemail
            // 
            this.ctl_rfqemail.AllCaps = false;
            this.ctl_rfqemail.BackColor = System.Drawing.Color.Transparent;
            this.ctl_rfqemail.Bold = false;
            this.ctl_rfqemail.Caption = "RFQ Email";
            this.ctl_rfqemail.Changed = false;
            this.ctl_rfqemail.IsEmail = false;
            this.ctl_rfqemail.IsURL = false;
            this.ctl_rfqemail.Location = new System.Drawing.Point(468, 6);
            this.ctl_rfqemail.Name = "ctl_rfqemail";
            this.ctl_rfqemail.PasswordChar = '\0';
            this.ctl_rfqemail.Size = new System.Drawing.Size(149, 45);
            this.ctl_rfqemail.TabIndex = 26;
            this.ctl_rfqemail.UseParentBackColor = true;
            this.ctl_rfqemail.zz_Enabled = true;
            this.ctl_rfqemail.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_rfqemail.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_rfqemail.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_rfqemail.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_rfqemail.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_rfqemail.zz_OriginalDesign = true;
            this.ctl_rfqemail.zz_ShowLinkButton = false;
            this.ctl_rfqemail.zz_ShowNeedsSaveColor = true;
            this.ctl_rfqemail.zz_Text = "";
            this.ctl_rfqemail.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_rfqemail.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_rfqemail.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_rfqemail.zz_UseGlobalColor = false;
            this.ctl_rfqemail.zz_UseGlobalFont = false;
            // 
            // ctl_zipcode
            // 
            this.ctl_zipcode.AllCaps = false;
            this.ctl_zipcode.BackColor = System.Drawing.Color.Transparent;
            this.ctl_zipcode.Bold = false;
            this.ctl_zipcode.Caption = "Zip Code";
            this.ctl_zipcode.Changed = false;
            this.ctl_zipcode.IsEmail = false;
            this.ctl_zipcode.IsURL = false;
            this.ctl_zipcode.Location = new System.Drawing.Point(161, 205);
            this.ctl_zipcode.Name = "ctl_zipcode";
            this.ctl_zipcode.PasswordChar = '\0';
            this.ctl_zipcode.Size = new System.Drawing.Size(128, 45);
            this.ctl_zipcode.TabIndex = 20;
            this.ctl_zipcode.UseParentBackColor = true;
            this.ctl_zipcode.zz_Enabled = true;
            this.ctl_zipcode.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_zipcode.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_zipcode.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_zipcode.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_zipcode.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_zipcode.zz_OriginalDesign = true;
            this.ctl_zipcode.zz_ShowLinkButton = false;
            this.ctl_zipcode.zz_ShowNeedsSaveColor = true;
            this.ctl_zipcode.zz_Text = "";
            this.ctl_zipcode.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_zipcode.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_zipcode.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_zipcode.zz_UseGlobalColor = false;
            this.ctl_zipcode.zz_UseGlobalFont = false;
            // 
            // ctl_statename
            // 
            this.ctl_statename.AllCaps = false;
            this.ctl_statename.BackColor = System.Drawing.Color.Transparent;
            this.ctl_statename.Bold = false;
            this.ctl_statename.Caption = "State";
            this.ctl_statename.Changed = false;
            this.ctl_statename.IsEmail = false;
            this.ctl_statename.IsURL = false;
            this.ctl_statename.Location = new System.Drawing.Point(315, 150);
            this.ctl_statename.Name = "ctl_statename";
            this.ctl_statename.PasswordChar = '\0';
            this.ctl_statename.Size = new System.Drawing.Size(149, 45);
            this.ctl_statename.TabIndex = 24;
            this.ctl_statename.UseParentBackColor = true;
            this.ctl_statename.zz_Enabled = true;
            this.ctl_statename.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_statename.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_statename.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_statename.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_statename.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_statename.zz_OriginalDesign = true;
            this.ctl_statename.zz_ShowLinkButton = false;
            this.ctl_statename.zz_ShowNeedsSaveColor = true;
            this.ctl_statename.zz_Text = "";
            this.ctl_statename.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_statename.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_statename.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_statename.zz_UseGlobalColor = false;
            this.ctl_statename.zz_UseGlobalFont = false;
            // 
            // ctl_contactfrequency
            // 
            this.ctl_contactfrequency.BackColor = System.Drawing.Color.Transparent;
            this.ctl_contactfrequency.Bold = false;
            this.ctl_contactfrequency.Caption = "Contact Frequency";
            this.ctl_contactfrequency.Changed = false;
            this.ctl_contactfrequency.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_contactfrequency.Location = new System.Drawing.Point(162, 159);
            this.ctl_contactfrequency.Name = "ctl_contactfrequency";
            this.ctl_contactfrequency.Size = new System.Drawing.Size(128, 47);
            this.ctl_contactfrequency.TabIndex = 19;
            this.ctl_contactfrequency.UseParentBackColor = true;
            this.ctl_contactfrequency.zz_Enabled = true;
            this.ctl_contactfrequency.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_contactfrequency.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_contactfrequency.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_contactfrequency.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_contactfrequency.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_contactfrequency.zz_OriginalDesign = true;
            this.ctl_contactfrequency.zz_ShowErrorColor = true;
            this.ctl_contactfrequency.zz_ShowNeedsSaveColor = true;
            this.ctl_contactfrequency.zz_Text = "";
            this.ctl_contactfrequency.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_contactfrequency.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_contactfrequency.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_contactfrequency.zz_UseGlobalColor = false;
            this.ctl_contactfrequency.zz_UseGlobalFont = false;
            // 
            // ctl_instockonly
            // 
            this.ctl_instockonly.BackColor = System.Drawing.Color.Transparent;
            this.ctl_instockonly.Bold = false;
            this.ctl_instockonly.Caption = "In Stock Only";
            this.ctl_instockonly.Changed = false;
            this.ctl_instockonly.Location = new System.Drawing.Point(161, 105);
            this.ctl_instockonly.Name = "ctl_instockonly";
            this.ctl_instockonly.Size = new System.Drawing.Size(90, 18);
            this.ctl_instockonly.TabIndex = 18;
            this.ctl_instockonly.UseParentBackColor = true;
            this.ctl_instockonly.zz_CheckValue = false;
            this.ctl_instockonly.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_instockonly.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_instockonly.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_instockonly.zz_OriginalDesign = false;
            this.ctl_instockonly.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_companycode
            // 
            this.ctl_companycode.AllCaps = false;
            this.ctl_companycode.BackColor = System.Drawing.Color.Transparent;
            this.ctl_companycode.Bold = false;
            this.ctl_companycode.Caption = "Company Code";
            this.ctl_companycode.Changed = false;
            this.ctl_companycode.IsEmail = false;
            this.ctl_companycode.IsURL = false;
            this.ctl_companycode.Location = new System.Drawing.Point(537, 150);
            this.ctl_companycode.Name = "ctl_companycode";
            this.ctl_companycode.PasswordChar = '\0';
            this.ctl_companycode.Size = new System.Drawing.Size(80, 45);
            this.ctl_companycode.TabIndex = 17;
            this.ctl_companycode.UseParentBackColor = true;
            this.ctl_companycode.zz_Enabled = true;
            this.ctl_companycode.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_companycode.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_companycode.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_companycode.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_companycode.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_companycode.zz_OriginalDesign = true;
            this.ctl_companycode.zz_ShowLinkButton = false;
            this.ctl_companycode.zz_ShowNeedsSaveColor = true;
            this.ctl_companycode.zz_Text = "";
            this.ctl_companycode.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_companycode.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_companycode.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_companycode.zz_UseGlobalColor = false;
            this.ctl_companycode.zz_UseGlobalFont = false;
            // 
            // ctl_companynumber
            // 
            this.ctl_companynumber.BackColor = System.Drawing.Color.Transparent;
            this.ctl_companynumber.Bold = false;
            this.ctl_companynumber.Caption = "Company Number";
            this.ctl_companynumber.Changed = false;
            this.ctl_companynumber.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_companynumber.Location = new System.Drawing.Point(160, 12);
            this.ctl_companynumber.Name = "ctl_companynumber";
            this.ctl_companynumber.Size = new System.Drawing.Size(149, 35);
            this.ctl_companynumber.TabIndex = 16;
            this.ctl_companynumber.UseParentBackColor = true;
            this.ctl_companynumber.zz_Enabled = true;
            this.ctl_companynumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_companynumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_companynumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_companynumber.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_companynumber.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_companynumber.zz_OriginalDesign = false;
            this.ctl_companynumber.zz_ShowErrorColor = true;
            this.ctl_companynumber.zz_ShowNeedsSaveColor = true;
            this.ctl_companynumber.zz_Text = "";
            this.ctl_companynumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_companynumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_companynumber.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_companynumber.zz_UseGlobalColor = false;
            this.ctl_companynumber.zz_UseGlobalFont = false;
            // 
            // ctl_taxid
            // 
            this.ctl_taxid.AllCaps = false;
            this.ctl_taxid.BackColor = System.Drawing.Color.Transparent;
            this.ctl_taxid.Bold = false;
            this.ctl_taxid.Caption = "Tax ID";
            this.ctl_taxid.Changed = false;
            this.ctl_taxid.IsEmail = false;
            this.ctl_taxid.IsURL = false;
            this.ctl_taxid.Location = new System.Drawing.Point(315, 108);
            this.ctl_taxid.Name = "ctl_taxid";
            this.ctl_taxid.PasswordChar = '\0';
            this.ctl_taxid.Size = new System.Drawing.Size(149, 45);
            this.ctl_taxid.TabIndex = 23;
            this.ctl_taxid.UseParentBackColor = true;
            this.ctl_taxid.zz_Enabled = true;
            this.ctl_taxid.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_taxid.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_taxid.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_taxid.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_taxid.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_taxid.zz_OriginalDesign = true;
            this.ctl_taxid.zz_ShowLinkButton = false;
            this.ctl_taxid.zz_ShowNeedsSaveColor = true;
            this.ctl_taxid.zz_Text = "";
            this.ctl_taxid.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_taxid.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_taxid.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_taxid.zz_UseGlobalColor = false;
            this.ctl_taxid.zz_UseGlobalFont = false;
            // 
            // ctl_companyrating
            // 
            this.ctl_companyrating.BackColor = System.Drawing.Color.Transparent;
            this.ctl_companyrating.Bold = false;
            this.ctl_companyrating.Caption = "Rating";
            this.ctl_companyrating.Changed = false;
            this.ctl_companyrating.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_companyrating.Location = new System.Drawing.Point(6, 203);
            this.ctl_companyrating.Name = "ctl_companyrating";
            this.ctl_companyrating.Size = new System.Drawing.Size(150, 47);
            this.ctl_companyrating.TabIndex = 15;
            this.ctl_companyrating.UseParentBackColor = true;
            this.ctl_companyrating.zz_Enabled = true;
            this.ctl_companyrating.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_companyrating.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_companyrating.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_companyrating.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_companyrating.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_companyrating.zz_OriginalDesign = true;
            this.ctl_companyrating.zz_ShowErrorColor = true;
            this.ctl_companyrating.zz_ShowNeedsSaveColor = true;
            this.ctl_companyrating.zz_Text = "";
            this.ctl_companyrating.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_companyrating.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_companyrating.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_companyrating.zz_UseGlobalColor = false;
            this.ctl_companyrating.zz_UseGlobalFont = false;
            // 
            // ctl_pricelevel
            // 
            this.ctl_pricelevel.BackColor = System.Drawing.Color.Transparent;
            this.ctl_pricelevel.Bold = false;
            this.ctl_pricelevel.Caption = "Price Level";
            this.ctl_pricelevel.Changed = false;
            this.ctl_pricelevel.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_pricelevel.Location = new System.Drawing.Point(468, 149);
            this.ctl_pricelevel.Name = "ctl_pricelevel";
            this.ctl_pricelevel.Size = new System.Drawing.Size(63, 47);
            this.ctl_pricelevel.TabIndex = 29;
            this.ctl_pricelevel.UseParentBackColor = true;
            this.ctl_pricelevel.zz_Enabled = true;
            this.ctl_pricelevel.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_pricelevel.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_pricelevel.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_pricelevel.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_pricelevel.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_pricelevel.zz_OriginalDesign = true;
            this.ctl_pricelevel.zz_ShowErrorColor = true;
            this.ctl_pricelevel.zz_ShowNeedsSaveColor = true;
            this.ctl_pricelevel.zz_Text = "";
            this.ctl_pricelevel.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_pricelevel.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_pricelevel.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_pricelevel.zz_UseGlobalColor = false;
            this.ctl_pricelevel.zz_UseGlobalFont = false;
            // 
            // ctl_donotrfq
            // 
            this.ctl_donotrfq.BackColor = System.Drawing.Color.Transparent;
            this.ctl_donotrfq.Bold = false;
            this.ctl_donotrfq.Caption = "Do Not RFQ";
            this.ctl_donotrfq.Changed = false;
            this.ctl_donotrfq.Location = new System.Drawing.Point(8, 121);
            this.ctl_donotrfq.Name = "ctl_donotrfq";
            this.ctl_donotrfq.Size = new System.Drawing.Size(85, 18);
            this.ctl_donotrfq.TabIndex = 13;
            this.ctl_donotrfq.UseParentBackColor = true;
            this.ctl_donotrfq.zz_CheckValue = false;
            this.ctl_donotrfq.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_donotrfq.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_donotrfq.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_donotrfq.zz_OriginalDesign = false;
            this.ctl_donotrfq.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_isinternational
            // 
            this.ctl_isinternational.BackColor = System.Drawing.Color.Transparent;
            this.ctl_isinternational.Bold = false;
            this.ctl_isinternational.Caption = "International";
            this.ctl_isinternational.Changed = false;
            this.ctl_isinternational.Location = new System.Drawing.Point(8, 99);
            this.ctl_isinternational.Name = "ctl_isinternational";
            this.ctl_isinternational.Size = new System.Drawing.Size(84, 18);
            this.ctl_isinternational.TabIndex = 12;
            this.ctl_isinternational.UseParentBackColor = true;
            this.ctl_isinternational.zz_CheckValue = false;
            this.ctl_isinternational.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_isinternational.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_isinternational.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_isinternational.zz_OriginalDesign = false;
            this.ctl_isinternational.zz_ShowNeedsSaveColor = true;
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
            this.ctl_country.Location = new System.Drawing.Point(6, 57);
            this.ctl_country.Name = "ctl_country";
            this.ctl_country.PasswordChar = '\0';
            this.ctl_country.Size = new System.Drawing.Size(150, 45);
            this.ctl_country.TabIndex = 11;
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
            // ctl_alias1
            // 
            this.ctl_alias1.AllCaps = false;
            this.ctl_alias1.BackColor = System.Drawing.Color.Transparent;
            this.ctl_alias1.Bold = false;
            this.ctl_alias1.Caption = "Alias 1";
            this.ctl_alias1.Changed = false;
            this.ctl_alias1.IsEmail = false;
            this.ctl_alias1.IsURL = false;
            this.ctl_alias1.Location = new System.Drawing.Point(8, 6);
            this.ctl_alias1.Name = "ctl_alias1";
            this.ctl_alias1.PasswordChar = '\0';
            this.ctl_alias1.Size = new System.Drawing.Size(149, 45);
            this.ctl_alias1.TabIndex = 10;
            this.ctl_alias1.UseParentBackColor = true;
            this.ctl_alias1.zz_Enabled = true;
            this.ctl_alias1.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_alias1.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_alias1.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_alias1.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_alias1.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_alias1.zz_OriginalDesign = true;
            this.ctl_alias1.zz_ShowLinkButton = false;
            this.ctl_alias1.zz_ShowNeedsSaveColor = true;
            this.ctl_alias1.zz_Text = "";
            this.ctl_alias1.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_alias1.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_alias1.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_alias1.zz_UseGlobalColor = false;
            this.ctl_alias1.zz_UseGlobalFont = false;
            // 
            // tabTerms
            // 
            this.tabTerms.Controls.Add(this.gbVendor);
            this.tabTerms.Controls.Add(this.gbCustomer);
            this.tabTerms.Location = new System.Drawing.Point(4, 22);
            this.tabTerms.Name = "tabTerms";
            this.tabTerms.Padding = new System.Windows.Forms.Padding(3);
            this.tabTerms.Size = new System.Drawing.Size(192, 74);
            this.tabTerms.TabIndex = 2;
            this.tabTerms.Text = "Terms";
            this.tabTerms.UseVisualStyleBackColor = true;
            // 
            // gbVendor
            // 
            this.gbVendor.Controls.Add(this.ctl_islocked_purchase);
            this.gbVendor.Controls.Add(this.ctl_problem_vendor);
            this.gbVendor.Controls.Add(this.ctl_vendorTermsMemo);
            this.gbVendor.Controls.Add(this.ctl_cc_warning);
            this.gbVendor.Controls.Add(this.ctl_shipviavendor);
            this.gbVendor.Controls.Add(this.ctl_termsasvendor);
            this.gbVendor.Controls.Add(this.ctl_pastduelimitasvendor);
            this.gbVendor.Controls.Add(this.ctl_creditasvendor);
            this.gbVendor.Controls.Add(this.ctl_handling_charge);
            this.gbVendor.Controls.Add(this.ctl_cc_charge);
            this.gbVendor.Enabled = false;
            this.gbVendor.Location = new System.Drawing.Point(316, 8);
            this.gbVendor.Name = "gbVendor";
            this.gbVendor.Size = new System.Drawing.Size(303, 232);
            this.gbVendor.TabIndex = 1;
            this.gbVendor.TabStop = false;
            this.gbVendor.Text = "Vendor";
            // 
            // ctl_islocked_purchase
            // 
            this.ctl_islocked_purchase.BackColor = System.Drawing.Color.Transparent;
            this.ctl_islocked_purchase.Bold = false;
            this.ctl_islocked_purchase.Caption = "Locked (purchase)";
            this.ctl_islocked_purchase.Changed = false;
            this.ctl_islocked_purchase.Location = new System.Drawing.Point(3, 208);
            this.ctl_islocked_purchase.Name = "ctl_islocked_purchase";
            this.ctl_islocked_purchase.Size = new System.Drawing.Size(115, 18);
            this.ctl_islocked_purchase.TabIndex = 49;
            this.ctl_islocked_purchase.UseParentBackColor = true;
            this.ctl_islocked_purchase.zz_CheckValue = false;
            this.ctl_islocked_purchase.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_islocked_purchase.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_islocked_purchase.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_islocked_purchase.zz_OriginalDesign = false;
            this.ctl_islocked_purchase.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_problem_vendor
            // 
            this.ctl_problem_vendor.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_problem_vendor.Bold = false;
            this.ctl_problem_vendor.Caption = "Problem Vendor";
            this.ctl_problem_vendor.Changed = false;
            this.ctl_problem_vendor.Location = new System.Drawing.Point(195, 0);
            this.ctl_problem_vendor.Name = "ctl_problem_vendor";
            this.ctl_problem_vendor.Size = new System.Drawing.Size(101, 18);
            this.ctl_problem_vendor.TabIndex = 43;
            this.ctl_problem_vendor.UseParentBackColor = false;
            this.ctl_problem_vendor.zz_CheckValue = false;
            this.ctl_problem_vendor.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_problem_vendor.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_problem_vendor.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_problem_vendor.zz_OriginalDesign = false;
            this.ctl_problem_vendor.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_vendorTermsMemo
            // 
            this.ctl_vendorTermsMemo.BackColor = System.Drawing.Color.Transparent;
            this.ctl_vendorTermsMemo.Bold = false;
            this.ctl_vendorTermsMemo.Caption = "Vendor Terms Memo";
            this.ctl_vendorTermsMemo.Changed = false;
            this.ctl_vendorTermsMemo.DateLines = false;
            this.ctl_vendorTermsMemo.Location = new System.Drawing.Point(3, 114);
            this.ctl_vendorTermsMemo.Name = "ctl_vendorTermsMemo";
            this.ctl_vendorTermsMemo.Size = new System.Drawing.Size(156, 94);
            this.ctl_vendorTermsMemo.TabIndex = 41;
            this.ctl_vendorTermsMemo.UseParentBackColor = true;
            this.ctl_vendorTermsMemo.zz_Enabled = true;
            this.ctl_vendorTermsMemo.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_vendorTermsMemo.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_vendorTermsMemo.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_vendorTermsMemo.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_vendorTermsMemo.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_vendorTermsMemo.zz_OriginalDesign = true;
            this.ctl_vendorTermsMemo.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_vendorTermsMemo.zz_ShowNeedsSaveColor = true;
            this.ctl_vendorTermsMemo.zz_Text = "";
            this.ctl_vendorTermsMemo.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_vendorTermsMemo.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_vendorTermsMemo.zz_UseGlobalColor = false;
            this.ctl_vendorTermsMemo.zz_UseGlobalFont = false;
            // 
            // ctl_cc_warning
            // 
            this.ctl_cc_warning.BackColor = System.Drawing.Color.Transparent;
            this.ctl_cc_warning.Bold = false;
            this.ctl_cc_warning.Caption = "Credit Card Message";
            this.ctl_cc_warning.Changed = false;
            this.ctl_cc_warning.DateLines = false;
            this.ctl_cc_warning.Location = new System.Drawing.Point(165, 149);
            this.ctl_cc_warning.Name = "ctl_cc_warning";
            this.ctl_cc_warning.Size = new System.Drawing.Size(131, 77);
            this.ctl_cc_warning.TabIndex = 40;
            this.ctl_cc_warning.UseParentBackColor = true;
            this.ctl_cc_warning.zz_Enabled = true;
            this.ctl_cc_warning.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_cc_warning.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_cc_warning.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_cc_warning.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_cc_warning.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_cc_warning.zz_OriginalDesign = true;
            this.ctl_cc_warning.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_cc_warning.zz_ShowNeedsSaveColor = true;
            this.ctl_cc_warning.zz_Text = "";
            this.ctl_cc_warning.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_cc_warning.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_cc_warning.zz_UseGlobalColor = false;
            this.ctl_cc_warning.zz_UseGlobalFont = false;
            // 
            // ctl_shipviavendor
            // 
            this.ctl_shipviavendor.AllCaps = false;
            this.ctl_shipviavendor.AllowEdit = false;
            this.ctl_shipviavendor.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shipviavendor.Bold = false;
            this.ctl_shipviavendor.Caption = "Ship Via";
            this.ctl_shipviavendor.Changed = false;
            this.ctl_shipviavendor.ListName = "shipvia";
            this.ctl_shipviavendor.Location = new System.Drawing.Point(180, 107);
            this.ctl_shipviavendor.Name = "ctl_shipviavendor";
            this.ctl_shipviavendor.SimpleList = null;
            this.ctl_shipviavendor.Size = new System.Drawing.Size(117, 42);
            this.ctl_shipviavendor.TabIndex = 37;
            this.ctl_shipviavendor.UseParentBackColor = true;
            this.ctl_shipviavendor.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_shipviavendor.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shipviavendor.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_shipviavendor.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shipviavendor.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_shipviavendor.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_shipviavendor.zz_OriginalDesign = true;
            this.ctl_shipviavendor.zz_ShowNeedsSaveColor = true;
            this.ctl_shipviavendor.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shipviavendor.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shipviavendor.zz_UseGlobalColor = false;
            this.ctl_shipviavendor.zz_UseGlobalFont = false;
            // 
            // ctl_termsasvendor
            // 
            this.ctl_termsasvendor.AllCaps = false;
            this.ctl_termsasvendor.AllowEdit = false;
            this.ctl_termsasvendor.BackColor = System.Drawing.Color.Transparent;
            this.ctl_termsasvendor.Bold = false;
            this.ctl_termsasvendor.Caption = "Terms";
            this.ctl_termsasvendor.Changed = false;
            this.ctl_termsasvendor.ListName = "terms";
            this.ctl_termsasvendor.Location = new System.Drawing.Point(7, 22);
            this.ctl_termsasvendor.Name = "ctl_termsasvendor";
            this.ctl_termsasvendor.SimpleList = null;
            this.ctl_termsasvendor.Size = new System.Drawing.Size(167, 49);
            this.ctl_termsasvendor.TabIndex = 36;
            this.ctl_termsasvendor.UseParentBackColor = true;
            this.ctl_termsasvendor.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctl_termsasvendor.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_termsasvendor.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_termsasvendor.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_termsasvendor.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_termsasvendor.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_termsasvendor.zz_OriginalDesign = true;
            this.ctl_termsasvendor.zz_ShowNeedsSaveColor = true;
            this.ctl_termsasvendor.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_termsasvendor.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_termsasvendor.zz_UseGlobalColor = false;
            this.ctl_termsasvendor.zz_UseGlobalFont = false;
            // 
            // ctl_pastduelimitasvendor
            // 
            this.ctl_pastduelimitasvendor.BackColor = System.Drawing.Color.Transparent;
            this.ctl_pastduelimitasvendor.Bold = false;
            this.ctl_pastduelimitasvendor.Caption = "Past Due Limit";
            this.ctl_pastduelimitasvendor.Changed = false;
            this.ctl_pastduelimitasvendor.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_pastduelimitasvendor.Location = new System.Drawing.Point(180, 66);
            this.ctl_pastduelimitasvendor.Name = "ctl_pastduelimitasvendor";
            this.ctl_pastduelimitasvendor.Size = new System.Drawing.Size(117, 42);
            this.ctl_pastduelimitasvendor.TabIndex = 35;
            this.ctl_pastduelimitasvendor.UseParentBackColor = true;
            this.ctl_pastduelimitasvendor.zz_Enabled = true;
            this.ctl_pastduelimitasvendor.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_pastduelimitasvendor.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_pastduelimitasvendor.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_pastduelimitasvendor.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_pastduelimitasvendor.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_pastduelimitasvendor.zz_OriginalDesign = true;
            this.ctl_pastduelimitasvendor.zz_ShowErrorColor = true;
            this.ctl_pastduelimitasvendor.zz_ShowNeedsSaveColor = true;
            this.ctl_pastduelimitasvendor.zz_Text = "";
            this.ctl_pastduelimitasvendor.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_pastduelimitasvendor.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_pastduelimitasvendor.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_pastduelimitasvendor.zz_UseGlobalColor = false;
            this.ctl_pastduelimitasvendor.zz_UseGlobalFont = false;
            // 
            // ctl_creditasvendor
            // 
            this.ctl_creditasvendor.BackColor = System.Drawing.Color.Transparent;
            this.ctl_creditasvendor.Bold = false;
            this.ctl_creditasvendor.Caption = "Credit Limit";
            this.ctl_creditasvendor.Changed = false;
            this.ctl_creditasvendor.EditCaption = false;
            this.ctl_creditasvendor.FullDecimal = false;
            this.ctl_creditasvendor.Location = new System.Drawing.Point(180, 20);
            this.ctl_creditasvendor.Name = "ctl_creditasvendor";
            this.ctl_creditasvendor.RoundNearestCent = true;
            this.ctl_creditasvendor.Size = new System.Drawing.Size(117, 42);
            this.ctl_creditasvendor.TabIndex = 34;
            this.ctl_creditasvendor.UseParentBackColor = true;
            this.ctl_creditasvendor.zz_Enabled = true;
            this.ctl_creditasvendor.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_creditasvendor.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_creditasvendor.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_creditasvendor.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_creditasvendor.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_creditasvendor.zz_OriginalDesign = true;
            this.ctl_creditasvendor.zz_ShowErrorColor = true;
            this.ctl_creditasvendor.zz_ShowNeedsSaveColor = true;
            this.ctl_creditasvendor.zz_Text = "";
            this.ctl_creditasvendor.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_creditasvendor.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_creditasvendor.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_creditasvendor.zz_UseGlobalColor = false;
            this.ctl_creditasvendor.zz_UseGlobalFont = false;
            // 
            // ctl_handling_charge
            // 
            this.ctl_handling_charge.BackColor = System.Drawing.Color.Transparent;
            this.ctl_handling_charge.Bold = false;
            this.ctl_handling_charge.Caption = "Handling Charge";
            this.ctl_handling_charge.Changed = false;
            this.ctl_handling_charge.EditCaption = false;
            this.ctl_handling_charge.FullDecimal = false;
            this.ctl_handling_charge.Location = new System.Drawing.Point(89, 65);
            this.ctl_handling_charge.Name = "ctl_handling_charge";
            this.ctl_handling_charge.RoundNearestCent = true;
            this.ctl_handling_charge.Size = new System.Drawing.Size(85, 44);
            this.ctl_handling_charge.TabIndex = 39;
            this.ctl_handling_charge.UseParentBackColor = true;
            this.ctl_handling_charge.zz_Enabled = true;
            this.ctl_handling_charge.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_handling_charge.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_handling_charge.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_handling_charge.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_handling_charge.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_handling_charge.zz_OriginalDesign = true;
            this.ctl_handling_charge.zz_ShowErrorColor = true;
            this.ctl_handling_charge.zz_ShowNeedsSaveColor = true;
            this.ctl_handling_charge.zz_Text = "";
            this.ctl_handling_charge.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_handling_charge.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_handling_charge.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_handling_charge.zz_UseGlobalColor = false;
            this.ctl_handling_charge.zz_UseGlobalFont = false;
            // 
            // ctl_cc_charge
            // 
            this.ctl_cc_charge.BackColor = System.Drawing.Color.Transparent;
            this.ctl_cc_charge.Bold = false;
            this.ctl_cc_charge.Caption = "CC Charge";
            this.ctl_cc_charge.Changed = false;
            this.ctl_cc_charge.EditCaption = false;
            this.ctl_cc_charge.FullDecimal = false;
            this.ctl_cc_charge.Location = new System.Drawing.Point(7, 65);
            this.ctl_cc_charge.Name = "ctl_cc_charge";
            this.ctl_cc_charge.RoundNearestCent = true;
            this.ctl_cc_charge.Size = new System.Drawing.Size(77, 44);
            this.ctl_cc_charge.TabIndex = 38;
            this.ctl_cc_charge.UseParentBackColor = true;
            this.ctl_cc_charge.zz_Enabled = true;
            this.ctl_cc_charge.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_cc_charge.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_cc_charge.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_cc_charge.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_cc_charge.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_cc_charge.zz_OriginalDesign = true;
            this.ctl_cc_charge.zz_ShowErrorColor = true;
            this.ctl_cc_charge.zz_ShowNeedsSaveColor = true;
            this.ctl_cc_charge.zz_Text = "";
            this.ctl_cc_charge.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_cc_charge.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_cc_charge.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_cc_charge.zz_UseGlobalColor = false;
            this.ctl_cc_charge.zz_UseGlobalFont = false;
            // 
            // gbCustomer
            // 
            this.gbCustomer.Controls.Add(this.btnCheckCreditLimit);
            this.gbCustomer.Controls.Add(this.ctl_is_locked);
            this.gbCustomer.Controls.Add(this.ctl_is_problem);
            this.gbCustomer.Controls.Add(this.ctl_customerTermsMemo);
            this.gbCustomer.Controls.Add(this.ctl_shipviacustomer);
            this.gbCustomer.Controls.Add(this.ctl_termsascustomer);
            this.gbCustomer.Controls.Add(this.ctl_pastduelimitascustomer);
            this.gbCustomer.Controls.Add(this.ctl_creditascustomer);
            this.gbCustomer.Enabled = false;
            this.gbCustomer.Location = new System.Drawing.Point(4, 8);
            this.gbCustomer.Name = "gbCustomer";
            this.gbCustomer.Size = new System.Drawing.Size(309, 232);
            this.gbCustomer.TabIndex = 0;
            this.gbCustomer.TabStop = false;
            this.gbCustomer.Text = "Customer";
            // 
            // btnCheckCreditLimit
            // 
            this.btnCheckCreditLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCheckCreditLimit.Location = new System.Drawing.Point(68, 8);
            this.btnCheckCreditLimit.Name = "btnCheckCreditLimit";
            this.btnCheckCreditLimit.Size = new System.Drawing.Size(85, 21);
            this.btnCheckCreditLimit.TabIndex = 45;
            this.btnCheckCreditLimit.Text = "Credit Info";
            this.btnCheckCreditLimit.UseVisualStyleBackColor = true;
            this.btnCheckCreditLimit.Click += new System.EventHandler(this.btnCheckCreditLimit_Click);
            // 
            // ctl_is_locked
            // 
            this.ctl_is_locked.BackColor = System.Drawing.Color.Transparent;
            this.ctl_is_locked.Bold = false;
            this.ctl_is_locked.Caption = "Locked (everything)";
            this.ctl_is_locked.Changed = false;
            this.ctl_is_locked.Location = new System.Drawing.Point(6, 208);
            this.ctl_is_locked.Name = "ctl_is_locked";
            this.ctl_is_locked.Size = new System.Drawing.Size(120, 18);
            this.ctl_is_locked.TabIndex = 48;
            this.ctl_is_locked.UseParentBackColor = true;
            this.ctl_is_locked.zz_CheckValue = false;
            this.ctl_is_locked.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_locked.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_is_locked.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_locked.zz_OriginalDesign = false;
            this.ctl_is_locked.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_is_problem
            // 
            this.ctl_is_problem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_is_problem.Bold = false;
            this.ctl_is_problem.Caption = "Problem Customer";
            this.ctl_is_problem.Changed = false;
            this.ctl_is_problem.Location = new System.Drawing.Point(187, 0);
            this.ctl_is_problem.Name = "ctl_is_problem";
            this.ctl_is_problem.Size = new System.Drawing.Size(111, 18);
            this.ctl_is_problem.TabIndex = 42;
            this.ctl_is_problem.UseParentBackColor = false;
            this.ctl_is_problem.zz_CheckValue = false;
            this.ctl_is_problem.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_problem.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_is_problem.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_problem.zz_OriginalDesign = false;
            this.ctl_is_problem.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_customerTermsMemo
            // 
            this.ctl_customerTermsMemo.BackColor = System.Drawing.SystemColors.Control;
            this.ctl_customerTermsMemo.Bold = false;
            this.ctl_customerTermsMemo.Caption = "Customer Terms Memo";
            this.ctl_customerTermsMemo.Changed = false;
            this.ctl_customerTermsMemo.DateLines = false;
            this.ctl_customerTermsMemo.Location = new System.Drawing.Point(6, 145);
            this.ctl_customerTermsMemo.Name = "ctl_customerTermsMemo";
            this.ctl_customerTermsMemo.Size = new System.Drawing.Size(292, 63);
            this.ctl_customerTermsMemo.TabIndex = 41;
            this.ctl_customerTermsMemo.UseParentBackColor = true;
            this.ctl_customerTermsMemo.zz_Enabled = true;
            this.ctl_customerTermsMemo.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_customerTermsMemo.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_customerTermsMemo.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_customerTermsMemo.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_customerTermsMemo.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_customerTermsMemo.zz_OriginalDesign = true;
            this.ctl_customerTermsMemo.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_customerTermsMemo.zz_ShowNeedsSaveColor = true;
            this.ctl_customerTermsMemo.zz_Text = "";
            this.ctl_customerTermsMemo.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_customerTermsMemo.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_customerTermsMemo.zz_UseGlobalColor = false;
            this.ctl_customerTermsMemo.zz_UseGlobalFont = false;
            // 
            // ctl_shipviacustomer
            // 
            this.ctl_shipviacustomer.AllCaps = false;
            this.ctl_shipviacustomer.AllowEdit = false;
            this.ctl_shipviacustomer.BackColor = System.Drawing.SystemColors.Control;
            this.ctl_shipviacustomer.Bold = false;
            this.ctl_shipviacustomer.Caption = "Ship Via";
            this.ctl_shipviacustomer.Changed = false;
            this.ctl_shipviacustomer.ListName = "shipvia";
            this.ctl_shipviacustomer.Location = new System.Drawing.Point(6, 100);
            this.ctl_shipviacustomer.Name = "ctl_shipviacustomer";
            this.ctl_shipviacustomer.SimpleList = null;
            this.ctl_shipviacustomer.Size = new System.Drawing.Size(292, 51);
            this.ctl_shipviacustomer.TabIndex = 33;
            this.ctl_shipviacustomer.UseParentBackColor = true;
            this.ctl_shipviacustomer.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_shipviacustomer.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shipviacustomer.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_shipviacustomer.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shipviacustomer.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_shipviacustomer.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_shipviacustomer.zz_OriginalDesign = true;
            this.ctl_shipviacustomer.zz_ShowNeedsSaveColor = true;
            this.ctl_shipviacustomer.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shipviacustomer.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shipviacustomer.zz_UseGlobalColor = false;
            this.ctl_shipviacustomer.zz_UseGlobalFont = false;
            // 
            // ctl_termsascustomer
            // 
            this.ctl_termsascustomer.AllCaps = false;
            this.ctl_termsascustomer.AllowEdit = false;
            this.ctl_termsascustomer.BackColor = System.Drawing.SystemColors.Control;
            this.ctl_termsascustomer.Bold = false;
            this.ctl_termsascustomer.Caption = "Terms";
            this.ctl_termsascustomer.Changed = false;
            this.ctl_termsascustomer.ListName = "terms";
            this.ctl_termsascustomer.Location = new System.Drawing.Point(6, 57);
            this.ctl_termsascustomer.Name = "ctl_termsascustomer";
            this.ctl_termsascustomer.SimpleList = null;
            this.ctl_termsascustomer.Size = new System.Drawing.Size(292, 51);
            this.ctl_termsascustomer.TabIndex = 32;
            this.ctl_termsascustomer.UseParentBackColor = true;
            this.ctl_termsascustomer.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctl_termsascustomer.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_termsascustomer.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_termsascustomer.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_termsascustomer.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_termsascustomer.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_termsascustomer.zz_OriginalDesign = true;
            this.ctl_termsascustomer.zz_ShowNeedsSaveColor = true;
            this.ctl_termsascustomer.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_termsascustomer.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_termsascustomer.zz_UseGlobalColor = false;
            this.ctl_termsascustomer.zz_UseGlobalFont = false;
            // 
            // ctl_pastduelimitascustomer
            // 
            this.ctl_pastduelimitascustomer.BackColor = System.Drawing.Color.Transparent;
            this.ctl_pastduelimitascustomer.Bold = false;
            this.ctl_pastduelimitascustomer.Caption = "Past Due Limit";
            this.ctl_pastduelimitascustomer.Changed = false;
            this.ctl_pastduelimitascustomer.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_pastduelimitascustomer.Location = new System.Drawing.Point(159, 16);
            this.ctl_pastduelimitascustomer.Name = "ctl_pastduelimitascustomer";
            this.ctl_pastduelimitascustomer.Size = new System.Drawing.Size(140, 35);
            this.ctl_pastduelimitascustomer.TabIndex = 31;
            this.ctl_pastduelimitascustomer.UseParentBackColor = true;
            this.ctl_pastduelimitascustomer.zz_Enabled = true;
            this.ctl_pastduelimitascustomer.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_pastduelimitascustomer.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_pastduelimitascustomer.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_pastduelimitascustomer.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_pastduelimitascustomer.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_pastduelimitascustomer.zz_OriginalDesign = false;
            this.ctl_pastduelimitascustomer.zz_ShowErrorColor = true;
            this.ctl_pastduelimitascustomer.zz_ShowNeedsSaveColor = true;
            this.ctl_pastduelimitascustomer.zz_Text = "";
            this.ctl_pastduelimitascustomer.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_pastduelimitascustomer.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_pastduelimitascustomer.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_pastduelimitascustomer.zz_UseGlobalColor = false;
            this.ctl_pastduelimitascustomer.zz_UseGlobalFont = false;
            // 
            // ctl_creditascustomer
            // 
            this.ctl_creditascustomer.BackColor = System.Drawing.Color.Transparent;
            this.ctl_creditascustomer.Bold = false;
            this.ctl_creditascustomer.Caption = "Credit Limit";
            this.ctl_creditascustomer.Changed = false;
            this.ctl_creditascustomer.EditCaption = false;
            this.ctl_creditascustomer.FullDecimal = false;
            this.ctl_creditascustomer.Location = new System.Drawing.Point(6, 8);
            this.ctl_creditascustomer.Name = "ctl_creditascustomer";
            this.ctl_creditascustomer.RoundNearestCent = true;
            this.ctl_creditascustomer.Size = new System.Drawing.Size(147, 46);
            this.ctl_creditascustomer.TabIndex = 30;
            this.ctl_creditascustomer.UseParentBackColor = true;
            this.ctl_creditascustomer.zz_Enabled = false;
            this.ctl_creditascustomer.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_creditascustomer.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_creditascustomer.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_creditascustomer.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_creditascustomer.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_creditascustomer.zz_OriginalDesign = true;
            this.ctl_creditascustomer.zz_ShowErrorColor = true;
            this.ctl_creditascustomer.zz_ShowNeedsSaveColor = true;
            this.ctl_creditascustomer.zz_Text = "";
            this.ctl_creditascustomer.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_creditascustomer.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_creditascustomer.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_creditascustomer.zz_UseGlobalColor = false;
            this.ctl_creditascustomer.zz_UseGlobalFont = false;
            // 
            // tabDescription
            // 
            this.tabDescription.Controls.Add(this.gbCompanyTermsConditions);
            this.tabDescription.Controls.Add(this.ctl_SOA_services);
            this.tabDescription.Controls.Add(this.ctl_SOA_components);
            this.tabDescription.Controls.Add(this.label6);
            this.tabDescription.Controls.Add(this.ctl_description);
            this.tabDescription.Location = new System.Drawing.Point(4, 22);
            this.tabDescription.Name = "tabDescription";
            this.tabDescription.Padding = new System.Windows.Forms.Padding(3);
            this.tabDescription.Size = new System.Drawing.Size(192, 74);
            this.tabDescription.TabIndex = 3;
            this.tabDescription.Text = "Description / SOA";
            this.tabDescription.UseVisualStyleBackColor = true;
            // 
            // gbCompanyTermsConditions
            // 
            this.gbCompanyTermsConditions.Controls.Add(this.ctl_testing_restriction_detail);
            this.gbCompanyTermsConditions.Controls.Add(this.ctl_packaging_requirements_detail);
            this.gbCompanyTermsConditions.Controls.Add(this.ctl_date_code_restriction_detail);
            this.gbCompanyTermsConditions.Controls.Add(this.ctl_requires_traceability);
            this.gbCompanyTermsConditions.Controls.Add(this.ctl_testing_restriction);
            this.gbCompanyTermsConditions.Controls.Add(this.ctl_coo_restriction);
            this.gbCompanyTermsConditions.Controls.Add(this.ctl_broker_restriction);
            this.gbCompanyTermsConditions.Controls.Add(this.ctl_rohs_restriction);
            this.gbCompanyTermsConditions.Controls.Add(this.ctl_packaging_requirements);
            this.gbCompanyTermsConditions.Controls.Add(this.ctl_date_code_restriction);
            this.gbCompanyTermsConditions.Location = new System.Drawing.Point(6, 13);
            this.gbCompanyTermsConditions.Name = "gbCompanyTermsConditions";
            this.gbCompanyTermsConditions.Size = new System.Drawing.Size(607, 100);
            this.gbCompanyTermsConditions.TabIndex = 43;
            this.gbCompanyTermsConditions.TabStop = false;
            this.gbCompanyTermsConditions.Tag = "";
            this.gbCompanyTermsConditions.Text = "Company Terms, Conditions, Requirements, Restrictions";
            // 
            // ctl_testing_restriction_detail
            // 
            this.ctl_testing_restriction_detail.Enabled = false;
            this.ctl_testing_restriction_detail.Location = new System.Drawing.Point(439, 62);
            this.ctl_testing_restriction_detail.Name = "ctl_testing_restriction_detail";
            this.ctl_testing_restriction_detail.Size = new System.Drawing.Size(100, 20);
            this.ctl_testing_restriction_detail.TabIndex = 9;
            // 
            // ctl_packaging_requirements_detail
            // 
            this.ctl_packaging_requirements_detail.Enabled = false;
            this.ctl_packaging_requirements_detail.Location = new System.Drawing.Point(439, 39);
            this.ctl_packaging_requirements_detail.Name = "ctl_packaging_requirements_detail";
            this.ctl_packaging_requirements_detail.Size = new System.Drawing.Size(100, 20);
            this.ctl_packaging_requirements_detail.TabIndex = 8;
            // 
            // ctl_date_code_restriction_detail
            // 
            this.ctl_date_code_restriction_detail.Enabled = false;
            this.ctl_date_code_restriction_detail.Location = new System.Drawing.Point(439, 17);
            this.ctl_date_code_restriction_detail.Name = "ctl_date_code_restriction_detail";
            this.ctl_date_code_restriction_detail.Size = new System.Drawing.Size(100, 20);
            this.ctl_date_code_restriction_detail.TabIndex = 7;
            // 
            // ctl_requires_traceability
            // 
            this.ctl_requires_traceability.AutoSize = true;
            this.ctl_requires_traceability.Location = new System.Drawing.Point(122, 20);
            this.ctl_requires_traceability.Name = "ctl_requires_traceability";
            this.ctl_requires_traceability.Size = new System.Drawing.Size(125, 17);
            this.ctl_requires_traceability.TabIndex = 6;
            this.ctl_requires_traceability.Text = "Requires Traceability";
            this.ctl_requires_traceability.UseVisualStyleBackColor = true;
            // 
            // ctl_testing_restriction
            // 
            this.ctl_testing_restriction.AutoSize = true;
            this.ctl_testing_restriction.Location = new System.Drawing.Point(295, 65);
            this.ctl_testing_restriction.Name = "ctl_testing_restriction";
            this.ctl_testing_restriction.Size = new System.Drawing.Size(114, 17);
            this.ctl_testing_restriction.TabIndex = 5;
            this.ctl_testing_restriction.Text = "Testing Restriction";
            this.ctl_testing_restriction.UseVisualStyleBackColor = true;
            this.ctl_testing_restriction.CheckedChanged += new System.EventHandler(this.ctl_testing_restriction_CheckedChanged);
            // 
            // ctl_coo_restriction
            // 
            this.ctl_coo_restriction.AutoSize = true;
            this.ctl_coo_restriction.Location = new System.Drawing.Point(7, 43);
            this.ctl_coo_restriction.Name = "ctl_coo_restriction";
            this.ctl_coo_restriction.Size = new System.Drawing.Size(102, 17);
            this.ctl_coo_restriction.TabIndex = 4;
            this.ctl_coo_restriction.Text = "COO Restriction";
            this.ctl_coo_restriction.UseVisualStyleBackColor = true;
            // 
            // ctl_broker_restriction
            // 
            this.ctl_broker_restriction.AutoSize = true;
            this.ctl_broker_restriction.Location = new System.Drawing.Point(6, 20);
            this.ctl_broker_restriction.Name = "ctl_broker_restriction";
            this.ctl_broker_restriction.Size = new System.Drawing.Size(110, 17);
            this.ctl_broker_restriction.TabIndex = 3;
            this.ctl_broker_restriction.Text = "Broker Restriction";
            this.ctl_broker_restriction.UseVisualStyleBackColor = true;
            // 
            // ctl_rohs_restriction
            // 
            this.ctl_rohs_restriction.AutoSize = true;
            this.ctl_rohs_restriction.Location = new System.Drawing.Point(6, 65);
            this.ctl_rohs_restriction.Name = "ctl_rohs_restriction";
            this.ctl_rohs_restriction.Size = new System.Drawing.Size(108, 17);
            this.ctl_rohs_restriction.TabIndex = 2;
            this.ctl_rohs_restriction.Text = "RoHS Restriction";
            this.ctl_rohs_restriction.UseVisualStyleBackColor = true;
            // 
            // ctl_packaging_requirements
            // 
            this.ctl_packaging_requirements.AutoSize = true;
            this.ctl_packaging_requirements.Location = new System.Drawing.Point(295, 42);
            this.ctl_packaging_requirements.Name = "ctl_packaging_requirements";
            this.ctl_packaging_requirements.Size = new System.Drawing.Size(145, 17);
            this.ctl_packaging_requirements.TabIndex = 1;
            this.ctl_packaging_requirements.Text = "Packaging Requirements";
            this.ctl_packaging_requirements.UseVisualStyleBackColor = true;
            this.ctl_packaging_requirements.CheckedChanged += new System.EventHandler(this.ctl_packaging_requirements_CheckedChanged);
            // 
            // ctl_date_code_restriction
            // 
            this.ctl_date_code_restriction.AutoSize = true;
            this.ctl_date_code_restriction.Location = new System.Drawing.Point(295, 19);
            this.ctl_date_code_restriction.Name = "ctl_date_code_restriction";
            this.ctl_date_code_restriction.Size = new System.Drawing.Size(130, 17);
            this.ctl_date_code_restriction.TabIndex = 0;
            this.ctl_date_code_restriction.Text = "Date Code Restriction";
            this.ctl_date_code_restriction.UseVisualStyleBackColor = true;
            this.ctl_date_code_restriction.CheckedChanged += new System.EventHandler(this.ctl_date_code_restriction_CheckedChanged);
            // 
            // ctl_SOA_services
            // 
            this.ctl_SOA_services.BackColor = System.Drawing.Color.Transparent;
            this.ctl_SOA_services.Bold = false;
            this.ctl_SOA_services.Caption = "Component Services";
            this.ctl_SOA_services.Changed = false;
            this.ctl_SOA_services.Location = new System.Drawing.Point(151, 226);
            this.ctl_SOA_services.Name = "ctl_SOA_services";
            this.ctl_SOA_services.Size = new System.Drawing.Size(124, 18);
            this.ctl_SOA_services.TabIndex = 42;
            this.ctl_SOA_services.UseParentBackColor = true;
            this.ctl_SOA_services.zz_CheckValue = false;
            this.ctl_SOA_services.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_SOA_services.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_SOA_services.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_SOA_services.zz_OriginalDesign = false;
            this.ctl_SOA_services.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_SOA_components
            // 
            this.ctl_SOA_components.BackColor = System.Drawing.Color.Transparent;
            this.ctl_SOA_components.Bold = false;
            this.ctl_SOA_components.Caption = "Component Purchases";
            this.ctl_SOA_components.Changed = false;
            this.ctl_SOA_components.Location = new System.Drawing.Point(12, 226);
            this.ctl_SOA_components.Name = "ctl_SOA_components";
            this.ctl_SOA_components.Size = new System.Drawing.Size(133, 18);
            this.ctl_SOA_components.TabIndex = 40;
            this.ctl_SOA_components.UseParentBackColor = true;
            this.ctl_SOA_components.zz_CheckValue = false;
            this.ctl_SOA_components.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_SOA_components.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_SOA_components.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_SOA_components.zz_OriginalDesign = false;
            this.ctl_SOA_components.zz_ShowNeedsSaveColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Scope of Approval (SOA)";
            // 
            // ctl_description
            // 
            this.ctl_description.BackColor = System.Drawing.Color.Transparent;
            this.ctl_description.Bold = false;
            this.ctl_description.Caption = "Description / Other Restrictions";
            this.ctl_description.Changed = false;
            this.ctl_description.DateLines = false;
            this.ctl_description.Location = new System.Drawing.Point(6, 119);
            this.ctl_description.Name = "ctl_description";
            this.ctl_description.Size = new System.Drawing.Size(607, 87);
            this.ctl_description.TabIndex = 38;
            this.ctl_description.UseParentBackColor = true;
            this.ctl_description.zz_Enabled = true;
            this.ctl_description.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_description.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_description.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_description.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_description.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_description.zz_OriginalDesign = true;
            this.ctl_description.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_description.zz_ShowNeedsSaveColor = true;
            this.ctl_description.zz_Text = "";
            this.ctl_description.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_description.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_description.zz_UseGlobalColor = false;
            this.ctl_description.zz_UseGlobalFont = false;
            // 
            // tabAttachments
            // 
            this.tabAttachments.Controls.Add(this.PPV);
            this.tabAttachments.Location = new System.Drawing.Point(4, 22);
            this.tabAttachments.Name = "tabAttachments";
            this.tabAttachments.Size = new System.Drawing.Size(192, 74);
            this.tabAttachments.TabIndex = 10;
            this.tabAttachments.Text = "Attachments";
            this.tabAttachments.UseVisualStyleBackColor = true;
            // 
            // PPV
            // 
            this.PPV.BackColor = System.Drawing.Color.White;
            this.PPV.Caption = "Rz4 PictureViewer";
            this.PPV.DisablePartLink = false;
            this.PPV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PPV.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PPV.Location = new System.Drawing.Point(0, 0);
            this.PPV.Name = "PPV";
            this.PPV.ShowFullScreenButton = true;
            this.PPV.ShowPartNumberLink = false;
            this.PPV.ShowPartSearch = false;
            this.PPV.ShowZoomButton = true;
            this.PPV.Size = new System.Drawing.Size(360, 74);
            this.PPV.TabIndex = 2;
            this.PPV.TemplateName = "orddetPartPictureViewer";
            // 
            // tabQB
            // 
            this.tabQB.Controls.Add(this.ctl_qb_shipping);
            this.tabQB.Controls.Add(this.ctl_qb_billing);
            this.tabQB.Controls.Add(this.ctl_qb_terms_v);
            this.tabQB.Controls.Add(this.ctl_qb_terms);
            this.tabQB.Controls.Add(this.ctl_qb_name);
            this.tabQB.Location = new System.Drawing.Point(4, 22);
            this.tabQB.Name = "tabQB";
            this.tabQB.Padding = new System.Windows.Forms.Padding(3);
            this.tabQB.Size = new System.Drawing.Size(192, 74);
            this.tabQB.TabIndex = 4;
            this.tabQB.Text = "QuickBooks";
            this.tabQB.UseVisualStyleBackColor = true;
            // 
            // ctl_qb_shipping
            // 
            this.ctl_qb_shipping.BackColor = System.Drawing.Color.Transparent;
            this.ctl_qb_shipping.Bold = false;
            this.ctl_qb_shipping.Caption = "QuickBooks Shipping Address";
            this.ctl_qb_shipping.Changed = false;
            this.ctl_qb_shipping.DateLines = false;
            this.ctl_qb_shipping.Location = new System.Drawing.Point(247, 60);
            this.ctl_qb_shipping.Name = "ctl_qb_shipping";
            this.ctl_qb_shipping.Size = new System.Drawing.Size(235, 184);
            this.ctl_qb_shipping.TabIndex = 43;
            this.ctl_qb_shipping.UseParentBackColor = true;
            this.ctl_qb_shipping.zz_Enabled = true;
            this.ctl_qb_shipping.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_qb_shipping.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_qb_shipping.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_qb_shipping.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_qb_shipping.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_qb_shipping.zz_OriginalDesign = true;
            this.ctl_qb_shipping.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_qb_shipping.zz_ShowNeedsSaveColor = true;
            this.ctl_qb_shipping.zz_Text = "";
            this.ctl_qb_shipping.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_qb_shipping.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_qb_shipping.zz_UseGlobalColor = false;
            this.ctl_qb_shipping.zz_UseGlobalFont = false;
            // 
            // ctl_qb_billing
            // 
            this.ctl_qb_billing.BackColor = System.Drawing.Color.Transparent;
            this.ctl_qb_billing.Bold = false;
            this.ctl_qb_billing.Caption = "QuickBooks Billing Address";
            this.ctl_qb_billing.Changed = false;
            this.ctl_qb_billing.DateLines = false;
            this.ctl_qb_billing.Location = new System.Drawing.Point(6, 60);
            this.ctl_qb_billing.Name = "ctl_qb_billing";
            this.ctl_qb_billing.Size = new System.Drawing.Size(235, 184);
            this.ctl_qb_billing.TabIndex = 42;
            this.ctl_qb_billing.UseParentBackColor = true;
            this.ctl_qb_billing.zz_Enabled = true;
            this.ctl_qb_billing.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_qb_billing.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_qb_billing.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_qb_billing.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_qb_billing.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_qb_billing.zz_OriginalDesign = true;
            this.ctl_qb_billing.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_qb_billing.zz_ShowNeedsSaveColor = true;
            this.ctl_qb_billing.zz_Text = "";
            this.ctl_qb_billing.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_qb_billing.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_qb_billing.zz_UseGlobalColor = false;
            this.ctl_qb_billing.zz_UseGlobalFont = false;
            // 
            // ctl_qb_terms_v
            // 
            this.ctl_qb_terms_v.AllCaps = false;
            this.ctl_qb_terms_v.BackColor = System.Drawing.Color.Transparent;
            this.ctl_qb_terms_v.Bold = false;
            this.ctl_qb_terms_v.Caption = "QB Terms (Vendor)";
            this.ctl_qb_terms_v.Changed = false;
            this.ctl_qb_terms_v.IsEmail = false;
            this.ctl_qb_terms_v.IsURL = false;
            this.ctl_qb_terms_v.Location = new System.Drawing.Point(454, 8);
            this.ctl_qb_terms_v.Name = "ctl_qb_terms_v";
            this.ctl_qb_terms_v.PasswordChar = '\0';
            this.ctl_qb_terms_v.Size = new System.Drawing.Size(163, 45);
            this.ctl_qb_terms_v.TabIndex = 41;
            this.ctl_qb_terms_v.UseParentBackColor = true;
            this.ctl_qb_terms_v.zz_Enabled = true;
            this.ctl_qb_terms_v.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_qb_terms_v.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_qb_terms_v.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_qb_terms_v.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_qb_terms_v.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_qb_terms_v.zz_OriginalDesign = true;
            this.ctl_qb_terms_v.zz_ShowLinkButton = false;
            this.ctl_qb_terms_v.zz_ShowNeedsSaveColor = true;
            this.ctl_qb_terms_v.zz_Text = "";
            this.ctl_qb_terms_v.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_qb_terms_v.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_qb_terms_v.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_qb_terms_v.zz_UseGlobalColor = false;
            this.ctl_qb_terms_v.zz_UseGlobalFont = false;
            // 
            // ctl_qb_terms
            // 
            this.ctl_qb_terms.AllCaps = false;
            this.ctl_qb_terms.BackColor = System.Drawing.Color.Transparent;
            this.ctl_qb_terms.Bold = false;
            this.ctl_qb_terms.Caption = "QB Terms (Customer)";
            this.ctl_qb_terms.Changed = false;
            this.ctl_qb_terms.IsEmail = false;
            this.ctl_qb_terms.IsURL = false;
            this.ctl_qb_terms.Location = new System.Drawing.Point(302, 8);
            this.ctl_qb_terms.Name = "ctl_qb_terms";
            this.ctl_qb_terms.PasswordChar = '\0';
            this.ctl_qb_terms.Size = new System.Drawing.Size(146, 45);
            this.ctl_qb_terms.TabIndex = 40;
            this.ctl_qb_terms.UseParentBackColor = true;
            this.ctl_qb_terms.zz_Enabled = true;
            this.ctl_qb_terms.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_qb_terms.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_qb_terms.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_qb_terms.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_qb_terms.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_qb_terms.zz_OriginalDesign = true;
            this.ctl_qb_terms.zz_ShowLinkButton = false;
            this.ctl_qb_terms.zz_ShowNeedsSaveColor = true;
            this.ctl_qb_terms.zz_Text = "";
            this.ctl_qb_terms.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_qb_terms.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_qb_terms.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_qb_terms.zz_UseGlobalColor = false;
            this.ctl_qb_terms.zz_UseGlobalFont = false;
            // 
            // ctl_qb_name
            // 
            this.ctl_qb_name.AllCaps = false;
            this.ctl_qb_name.BackColor = System.Drawing.Color.Transparent;
            this.ctl_qb_name.Bold = false;
            this.ctl_qb_name.Caption = "QuickBooks Name";
            this.ctl_qb_name.Changed = false;
            this.ctl_qb_name.IsEmail = false;
            this.ctl_qb_name.IsURL = false;
            this.ctl_qb_name.Location = new System.Drawing.Point(6, 8);
            this.ctl_qb_name.Name = "ctl_qb_name";
            this.ctl_qb_name.PasswordChar = '\0';
            this.ctl_qb_name.Size = new System.Drawing.Size(289, 45);
            this.ctl_qb_name.TabIndex = 39;
            this.ctl_qb_name.UseParentBackColor = true;
            this.ctl_qb_name.zz_Enabled = true;
            this.ctl_qb_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_qb_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_qb_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_qb_name.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_qb_name.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_qb_name.zz_OriginalDesign = true;
            this.ctl_qb_name.zz_ShowLinkButton = false;
            this.ctl_qb_name.zz_ShowNeedsSaveColor = true;
            this.ctl_qb_name.zz_Text = "";
            this.ctl_qb_name.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_qb_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_qb_name.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_qb_name.zz_UseGlobalColor = false;
            this.ctl_qb_name.zz_UseGlobalFont = false;
            // 
            // tabArchive
            // 
            this.tabArchive.Controls.Add(this.gbAutoArchive);
            this.tabArchive.Location = new System.Drawing.Point(4, 22);
            this.tabArchive.Name = "tabArchive";
            this.tabArchive.Padding = new System.Windows.Forms.Padding(3);
            this.tabArchive.Size = new System.Drawing.Size(192, 74);
            this.tabArchive.TabIndex = 5;
            this.tabArchive.Text = "Archive";
            this.tabArchive.UseVisualStyleBackColor = true;
            // 
            // gbAutoArchive
            // 
            this.gbAutoArchive.Controls.Add(this.gbArchiveDeleteSettings);
            this.gbAutoArchive.Controls.Add(this.optArchive);
            this.gbAutoArchive.Controls.Add(this.optNoArchive);
            this.gbAutoArchive.Controls.Add(this.gbArchiveSettings);
            this.gbAutoArchive.Controls.Add(this.picBroomClock);
            this.gbAutoArchive.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAutoArchive.ForeColor = System.Drawing.Color.Black;
            this.gbAutoArchive.Location = new System.Drawing.Point(3, 4);
            this.gbAutoArchive.Name = "gbAutoArchive";
            this.gbAutoArchive.Size = new System.Drawing.Size(614, 242);
            this.gbAutoArchive.TabIndex = 1;
            this.gbAutoArchive.TabStop = false;
            this.gbAutoArchive.Text = "Auto-Archive Offers";
            // 
            // gbArchiveDeleteSettings
            // 
            this.gbArchiveDeleteSettings.Controls.Add(this.ctl_delete_archives);
            this.gbArchiveDeleteSettings.Controls.Add(this.label4);
            this.gbArchiveDeleteSettings.Controls.Add(this.udDeleteArchivePeriod);
            this.gbArchiveDeleteSettings.Controls.Add(this.label5);
            this.gbArchiveDeleteSettings.Enabled = false;
            this.gbArchiveDeleteSettings.Location = new System.Drawing.Point(378, 92);
            this.gbArchiveDeleteSettings.Name = "gbArchiveDeleteSettings";
            this.gbArchiveDeleteSettings.Size = new System.Drawing.Size(230, 144);
            this.gbArchiveDeleteSettings.TabIndex = 4;
            this.gbArchiveDeleteSettings.TabStop = false;
            this.gbArchiveDeleteSettings.Text = "Auto-Archive Settings";
            this.gbArchiveDeleteSettings.Visible = false;
            // 
            // ctl_delete_archives
            // 
            this.ctl_delete_archives.BackColor = System.Drawing.Color.Transparent;
            this.ctl_delete_archives.Bold = false;
            this.ctl_delete_archives.Caption = "Delete Archived Lists";
            this.ctl_delete_archives.Changed = false;
            this.ctl_delete_archives.Location = new System.Drawing.Point(28, 33);
            this.ctl_delete_archives.Margin = new System.Windows.Forms.Padding(4);
            this.ctl_delete_archives.Name = "ctl_delete_archives";
            this.ctl_delete_archives.Size = new System.Drawing.Size(173, 19);
            this.ctl_delete_archives.TabIndex = 7;
            this.ctl_delete_archives.UseParentBackColor = false;
            this.ctl_delete_archives.zz_CheckValue = false;
            this.ctl_delete_archives.zz_LabelColor = System.Drawing.Color.Black;
            this.ctl_delete_archives.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_delete_archives.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_delete_archives.zz_OriginalDesign = false;
            this.ctl_delete_archives.zz_ShowNeedsSaveColor = true;
            this.ctl_delete_archives.CheckChanged += new NewMethod.CheckChangedHandler(this.ctl_delete_archives_CheckChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(161, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Month(s)";
            // 
            // udDeleteArchivePeriod
            // 
            this.udDeleteArchivePeriod.Enabled = false;
            this.udDeleteArchivePeriod.Location = new System.Drawing.Point(112, 106);
            this.udDeleteArchivePeriod.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.udDeleteArchivePeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udDeleteArchivePeriod.Name = "udDeleteArchivePeriod";
            this.udDeleteArchivePeriod.Size = new System.Drawing.Size(49, 26);
            this.udDeleteArchivePeriod.TabIndex = 1;
            this.udDeleteArchivePeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(3, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 57);
            this.label5.TabIndex = 0;
            this.label5.Text = "Delete all archived lists that are\r\nallowed to be deleted when they\r\nare older th" +
    "an:";
            // 
            // optArchive
            // 
            this.optArchive.AutoSize = true;
            this.optArchive.Location = new System.Drawing.Point(109, 54);
            this.optArchive.Name = "optArchive";
            this.optArchive.Size = new System.Drawing.Size(384, 23);
            this.optArchive.TabIndex = 3;
            this.optArchive.Text = "Archive offers from this company with these settings :";
            this.optArchive.UseVisualStyleBackColor = true;
            this.optArchive.CheckedChanged += new System.EventHandler(this.optArchive_CheckedChanged);
            // 
            // optNoArchive
            // 
            this.optNoArchive.AutoSize = true;
            this.optNoArchive.Checked = true;
            this.optNoArchive.Location = new System.Drawing.Point(109, 25);
            this.optNoArchive.Name = "optNoArchive";
            this.optNoArchive.Size = new System.Drawing.Size(297, 23);
            this.optNoArchive.TabIndex = 2;
            this.optNoArchive.TabStop = true;
            this.optNoArchive.Text = "Do not archive offers from this company.";
            this.optNoArchive.UseVisualStyleBackColor = true;
            this.optNoArchive.CheckedChanged += new System.EventHandler(this.optNoArchive_CheckedChanged);
            // 
            // gbArchiveSettings
            // 
            this.gbArchiveSettings.Controls.Add(this.label1);
            this.gbArchiveSettings.Controls.Add(this.optToDelete);
            this.gbArchiveSettings.Controls.Add(this.optToArchive);
            this.gbArchiveSettings.Controls.Add(this.cboTimespan);
            this.gbArchiveSettings.Controls.Add(this.udArchivePeriod);
            this.gbArchiveSettings.Controls.Add(this.lblCleanOut);
            this.gbArchiveSettings.Enabled = false;
            this.gbArchiveSettings.Location = new System.Drawing.Point(6, 92);
            this.gbArchiveSettings.Name = "gbArchiveSettings";
            this.gbArchiveSettings.Size = new System.Drawing.Size(366, 144);
            this.gbArchiveSettings.TabIndex = 1;
            this.gbArchiveSettings.TabStop = false;
            this.gbArchiveSettings.Text = "Auto-Archive Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Day(s)";
            // 
            // optToDelete
            // 
            this.optToDelete.AutoSize = true;
            this.optToDelete.Location = new System.Drawing.Point(10, 94);
            this.optToDelete.Name = "optToDelete";
            this.optToDelete.Size = new System.Drawing.Size(163, 23);
            this.optToDelete.TabIndex = 5;
            this.optToDelete.Text = "Delete all old offers.";
            this.optToDelete.UseVisualStyleBackColor = true;
            this.optToDelete.CheckedChanged += new System.EventHandler(this.optToDelete_CheckedChanged);
            // 
            // optToArchive
            // 
            this.optToArchive.AutoSize = true;
            this.optToArchive.Checked = true;
            this.optToArchive.Location = new System.Drawing.Point(10, 65);
            this.optToArchive.Name = "optToArchive";
            this.optToArchive.Size = new System.Drawing.Size(296, 23);
            this.optToArchive.TabIndex = 4;
            this.optToArchive.TabStop = true;
            this.optToArchive.Text = "Move all old offers to the Archive Table.";
            this.optToArchive.UseVisualStyleBackColor = true;
            this.optToArchive.CheckedChanged += new System.EventHandler(this.optToArchive_CheckedChanged);
            // 
            // cboTimespan
            // 
            this.cboTimespan.FormattingEnabled = true;
            this.cboTimespan.Items.AddRange(new object[] {
            "Months",
            "Weeks",
            "Day(s)"});
            this.cboTimespan.Location = new System.Drawing.Point(264, 30);
            this.cboTimespan.Name = "cboTimespan";
            this.cboTimespan.Size = new System.Drawing.Size(97, 27);
            this.cboTimespan.TabIndex = 2;
            this.cboTimespan.Text = "Day(s)";
            this.cboTimespan.Visible = false;
            // 
            // udArchivePeriod
            // 
            this.udArchivePeriod.Location = new System.Drawing.Point(199, 30);
            this.udArchivePeriod.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.udArchivePeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udArchivePeriod.Name = "udArchivePeriod";
            this.udArchivePeriod.Size = new System.Drawing.Size(49, 26);
            this.udArchivePeriod.TabIndex = 1;
            this.udArchivePeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCleanOut
            // 
            this.lblCleanOut.AutoSize = true;
            this.lblCleanOut.Location = new System.Drawing.Point(6, 32);
            this.lblCleanOut.Name = "lblCleanOut";
            this.lblCleanOut.Size = new System.Drawing.Size(187, 19);
            this.lblCleanOut.TabIndex = 0;
            this.lblCleanOut.Text = "Clean out offers older than";
            // 
            // picBroomClock
            // 
            this.picBroomClock.Image = global::RzInterfaceWin.Properties.Resources.broom_clock;
            this.picBroomClock.Location = new System.Drawing.Point(6, 25);
            this.picBroomClock.Name = "picBroomClock";
            this.picBroomClock.Size = new System.Drawing.Size(46, 50);
            this.picBroomClock.TabIndex = 0;
            this.picBroomClock.TabStop = false;
            // 
            // tabECommerce
            // 
            this.tabECommerce.Controls.Add(this.ctl_websitegreeting);
            this.tabECommerce.Controls.Add(this.ctl_websiteresponse);
            this.tabECommerce.Controls.Add(this.ctl_websitemoniker);
            this.tabECommerce.Controls.Add(this.ctl_logopath);
            this.tabECommerce.Location = new System.Drawing.Point(4, 22);
            this.tabECommerce.Name = "tabECommerce";
            this.tabECommerce.Size = new System.Drawing.Size(192, 74);
            this.tabECommerce.TabIndex = 6;
            this.tabECommerce.Text = "E-Commerce";
            this.tabECommerce.UseVisualStyleBackColor = true;
            // 
            // ctl_websitegreeting
            // 
            this.ctl_websitegreeting.BackColor = System.Drawing.Color.Transparent;
            this.ctl_websitegreeting.Bold = false;
            this.ctl_websitegreeting.Caption = "Website Greeting";
            this.ctl_websitegreeting.Changed = false;
            this.ctl_websitegreeting.DateLines = false;
            this.ctl_websitegreeting.Location = new System.Drawing.Point(311, 107);
            this.ctl_websitegreeting.Name = "ctl_websitegreeting";
            this.ctl_websitegreeting.Size = new System.Drawing.Size(290, 133);
            this.ctl_websitegreeting.TabIndex = 5;
            this.ctl_websitegreeting.UseParentBackColor = false;
            this.ctl_websitegreeting.zz_Enabled = true;
            this.ctl_websitegreeting.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_websitegreeting.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_websitegreeting.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_websitegreeting.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_websitegreeting.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_websitegreeting.zz_OriginalDesign = true;
            this.ctl_websitegreeting.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_websitegreeting.zz_ShowNeedsSaveColor = true;
            this.ctl_websitegreeting.zz_Text = "";
            this.ctl_websitegreeting.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_websitegreeting.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_websitegreeting.zz_UseGlobalColor = false;
            this.ctl_websitegreeting.zz_UseGlobalFont = false;
            // 
            // ctl_websiteresponse
            // 
            this.ctl_websiteresponse.BackColor = System.Drawing.Color.Transparent;
            this.ctl_websiteresponse.Bold = false;
            this.ctl_websiteresponse.Caption = "Website Response";
            this.ctl_websiteresponse.Changed = false;
            this.ctl_websiteresponse.DateLines = false;
            this.ctl_websiteresponse.Location = new System.Drawing.Point(15, 107);
            this.ctl_websiteresponse.Name = "ctl_websiteresponse";
            this.ctl_websiteresponse.Size = new System.Drawing.Size(290, 133);
            this.ctl_websiteresponse.TabIndex = 4;
            this.ctl_websiteresponse.UseParentBackColor = false;
            this.ctl_websiteresponse.zz_Enabled = true;
            this.ctl_websiteresponse.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_websiteresponse.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_websiteresponse.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_websiteresponse.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_websiteresponse.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_websiteresponse.zz_OriginalDesign = true;
            this.ctl_websiteresponse.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_websiteresponse.zz_ShowNeedsSaveColor = true;
            this.ctl_websiteresponse.zz_Text = "";
            this.ctl_websiteresponse.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_websiteresponse.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_websiteresponse.zz_UseGlobalColor = false;
            this.ctl_websiteresponse.zz_UseGlobalFont = false;
            // 
            // ctl_websitemoniker
            // 
            this.ctl_websitemoniker.AllCaps = false;
            this.ctl_websitemoniker.BackColor = System.Drawing.Color.Transparent;
            this.ctl_websitemoniker.Bold = false;
            this.ctl_websitemoniker.Caption = "Website Moniker";
            this.ctl_websitemoniker.Changed = false;
            this.ctl_websitemoniker.IsEmail = false;
            this.ctl_websitemoniker.IsURL = false;
            this.ctl_websitemoniker.Location = new System.Drawing.Point(311, 55);
            this.ctl_websitemoniker.Name = "ctl_websitemoniker";
            this.ctl_websitemoniker.PasswordChar = '\0';
            this.ctl_websitemoniker.Size = new System.Drawing.Size(290, 46);
            this.ctl_websitemoniker.TabIndex = 3;
            this.ctl_websitemoniker.UseParentBackColor = false;
            this.ctl_websitemoniker.zz_Enabled = true;
            this.ctl_websitemoniker.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_websitemoniker.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_websitemoniker.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_websitemoniker.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_websitemoniker.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_websitemoniker.zz_OriginalDesign = true;
            this.ctl_websitemoniker.zz_ShowLinkButton = false;
            this.ctl_websitemoniker.zz_ShowNeedsSaveColor = true;
            this.ctl_websitemoniker.zz_Text = "";
            this.ctl_websitemoniker.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_websitemoniker.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_websitemoniker.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_websitemoniker.zz_UseGlobalColor = false;
            this.ctl_websitemoniker.zz_UseGlobalFont = false;
            // 
            // ctl_logopath
            // 
            this.ctl_logopath.AllCaps = false;
            this.ctl_logopath.BackColor = System.Drawing.Color.Transparent;
            this.ctl_logopath.Bold = false;
            this.ctl_logopath.Caption = "Logo Path";
            this.ctl_logopath.Changed = false;
            this.ctl_logopath.IsEmail = false;
            this.ctl_logopath.IsURL = false;
            this.ctl_logopath.Location = new System.Drawing.Point(311, 3);
            this.ctl_logopath.Name = "ctl_logopath";
            this.ctl_logopath.PasswordChar = '\0';
            this.ctl_logopath.Size = new System.Drawing.Size(290, 46);
            this.ctl_logopath.TabIndex = 2;
            this.ctl_logopath.UseParentBackColor = false;
            this.ctl_logopath.zz_Enabled = true;
            this.ctl_logopath.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_logopath.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_logopath.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_logopath.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_logopath.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_logopath.zz_OriginalDesign = true;
            this.ctl_logopath.zz_ShowLinkButton = false;
            this.ctl_logopath.zz_ShowNeedsSaveColor = true;
            this.ctl_logopath.zz_Text = "";
            this.ctl_logopath.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_logopath.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_logopath.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_logopath.zz_UseGlobalColor = false;
            this.ctl_logopath.zz_UseGlobalFont = false;
            // 
            // tabCallSchedule
            // 
            this.tabCallSchedule.Controls.Add(this.chkCallSunday);
            this.tabCallSchedule.Controls.Add(this.chkCallSaturday);
            this.tabCallSchedule.Controls.Add(this.chkCallFriday);
            this.tabCallSchedule.Controls.Add(this.chkCallThursday);
            this.tabCallSchedule.Controls.Add(this.chkCallWednesday);
            this.tabCallSchedule.Controls.Add(this.chkCallTuesday);
            this.tabCallSchedule.Controls.Add(this.chkCallMonday);
            this.tabCallSchedule.Location = new System.Drawing.Point(4, 22);
            this.tabCallSchedule.Name = "tabCallSchedule";
            this.tabCallSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.tabCallSchedule.Size = new System.Drawing.Size(192, 74);
            this.tabCallSchedule.TabIndex = 7;
            this.tabCallSchedule.Text = "Call Schedule";
            this.tabCallSchedule.UseVisualStyleBackColor = true;
            // 
            // chkCallSunday
            // 
            this.chkCallSunday.AutoSize = true;
            this.chkCallSunday.Location = new System.Drawing.Point(11, 153);
            this.chkCallSunday.Name = "chkCallSunday";
            this.chkCallSunday.Size = new System.Drawing.Size(62, 17);
            this.chkCallSunday.TabIndex = 6;
            this.chkCallSunday.Text = "Sunday";
            this.chkCallSunday.UseVisualStyleBackColor = true;
            // 
            // chkCallSaturday
            // 
            this.chkCallSaturday.AutoSize = true;
            this.chkCallSaturday.Location = new System.Drawing.Point(11, 130);
            this.chkCallSaturday.Name = "chkCallSaturday";
            this.chkCallSaturday.Size = new System.Drawing.Size(68, 17);
            this.chkCallSaturday.TabIndex = 5;
            this.chkCallSaturday.Text = "Saturday";
            this.chkCallSaturday.UseVisualStyleBackColor = true;
            // 
            // chkCallFriday
            // 
            this.chkCallFriday.AutoSize = true;
            this.chkCallFriday.Location = new System.Drawing.Point(11, 107);
            this.chkCallFriday.Name = "chkCallFriday";
            this.chkCallFriday.Size = new System.Drawing.Size(54, 17);
            this.chkCallFriday.TabIndex = 4;
            this.chkCallFriday.Text = "Friday";
            this.chkCallFriday.UseVisualStyleBackColor = true;
            // 
            // chkCallThursday
            // 
            this.chkCallThursday.AutoSize = true;
            this.chkCallThursday.Location = new System.Drawing.Point(11, 84);
            this.chkCallThursday.Name = "chkCallThursday";
            this.chkCallThursday.Size = new System.Drawing.Size(70, 17);
            this.chkCallThursday.TabIndex = 3;
            this.chkCallThursday.Text = "Thursday";
            this.chkCallThursday.UseVisualStyleBackColor = true;
            // 
            // chkCallWednesday
            // 
            this.chkCallWednesday.AutoSize = true;
            this.chkCallWednesday.Location = new System.Drawing.Point(11, 61);
            this.chkCallWednesday.Name = "chkCallWednesday";
            this.chkCallWednesday.Size = new System.Drawing.Size(83, 17);
            this.chkCallWednesday.TabIndex = 2;
            this.chkCallWednesday.Text = "Wednesday";
            this.chkCallWednesday.UseVisualStyleBackColor = true;
            // 
            // chkCallTuesday
            // 
            this.chkCallTuesday.AutoSize = true;
            this.chkCallTuesday.Location = new System.Drawing.Point(11, 38);
            this.chkCallTuesday.Name = "chkCallTuesday";
            this.chkCallTuesday.Size = new System.Drawing.Size(67, 17);
            this.chkCallTuesday.TabIndex = 1;
            this.chkCallTuesday.Text = "Tuesday";
            this.chkCallTuesday.UseVisualStyleBackColor = true;
            // 
            // chkCallMonday
            // 
            this.chkCallMonday.AutoSize = true;
            this.chkCallMonday.Location = new System.Drawing.Point(11, 15);
            this.chkCallMonday.Name = "chkCallMonday";
            this.chkCallMonday.Size = new System.Drawing.Size(64, 17);
            this.chkCallMonday.TabIndex = 0;
            this.chkCallMonday.Text = "Monday";
            this.chkCallMonday.UseVisualStyleBackColor = true;
            // 
            // tabCreditCard
            // 
            this.tabCreditCard.Controls.Add(this.ctl_bank_wire_info);
            this.tabCreditCard.Controls.Add(this.ctl_securitycode);
            this.tabCreditCard.Controls.Add(this.cmdSendCreditCardifoToQBs);
            this.tabCreditCard.Controls.Add(this.ctl_nameoncard);
            this.tabCreditCard.Controls.Add(this.ctl_cardbillingzip);
            this.tabCreditCard.Controls.Add(this.ctl_cardbillingaddr);
            this.tabCreditCard.Controls.Add(this.label3);
            this.tabCreditCard.Controls.Add(this.label2);
            this.tabCreditCard.Controls.Add(this.ctl_expiration_year);
            this.tabCreditCard.Controls.Add(this.ctl_expiration_month);
            this.tabCreditCard.Controls.Add(this.ctl_creditcardtype);
            this.tabCreditCard.Controls.Add(this.ctl_creditcardnumber);
            this.tabCreditCard.Location = new System.Drawing.Point(4, 22);
            this.tabCreditCard.Name = "tabCreditCard";
            this.tabCreditCard.Size = new System.Drawing.Size(192, 74);
            this.tabCreditCard.TabIndex = 8;
            this.tabCreditCard.Text = "Credit Card Info";
            this.tabCreditCard.UseVisualStyleBackColor = true;
            // 
            // ctl_bank_wire_info
            // 
            this.ctl_bank_wire_info.BackColor = System.Drawing.Color.Transparent;
            this.ctl_bank_wire_info.Bold = false;
            this.ctl_bank_wire_info.Caption = "Bank Information";
            this.ctl_bank_wire_info.Changed = false;
            this.ctl_bank_wire_info.DateLines = false;
            this.ctl_bank_wire_info.Location = new System.Drawing.Point(319, 67);
            this.ctl_bank_wire_info.Name = "ctl_bank_wire_info";
            this.ctl_bank_wire_info.Size = new System.Drawing.Size(295, 179);
            this.ctl_bank_wire_info.TabIndex = 36;
            this.ctl_bank_wire_info.UseParentBackColor = false;
            this.ctl_bank_wire_info.zz_Enabled = true;
            this.ctl_bank_wire_info.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_bank_wire_info.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_bank_wire_info.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_bank_wire_info.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_bank_wire_info.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_bank_wire_info.zz_OriginalDesign = false;
            this.ctl_bank_wire_info.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ctl_bank_wire_info.zz_ShowNeedsSaveColor = true;
            this.ctl_bank_wire_info.zz_Text = "";
            this.ctl_bank_wire_info.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_bank_wire_info.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_bank_wire_info.zz_UseGlobalColor = false;
            this.ctl_bank_wire_info.zz_UseGlobalFont = false;
            // 
            // ctl_securitycode
            // 
            this.ctl_securitycode.AllCaps = false;
            this.ctl_securitycode.BackColor = System.Drawing.Color.Transparent;
            this.ctl_securitycode.Bold = false;
            this.ctl_securitycode.Caption = "Security Code";
            this.ctl_securitycode.Changed = false;
            this.ctl_securitycode.IsEmail = false;
            this.ctl_securitycode.IsURL = false;
            this.ctl_securitycode.Location = new System.Drawing.Point(9, 107);
            this.ctl_securitycode.Name = "ctl_securitycode";
            this.ctl_securitycode.PasswordChar = '\0';
            this.ctl_securitycode.Size = new System.Drawing.Size(132, 47);
            this.ctl_securitycode.TabIndex = 27;
            this.ctl_securitycode.UseParentBackColor = true;
            this.ctl_securitycode.zz_Enabled = true;
            this.ctl_securitycode.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_securitycode.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_securitycode.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_securitycode.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_securitycode.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_securitycode.zz_OriginalDesign = false;
            this.ctl_securitycode.zz_ShowLinkButton = false;
            this.ctl_securitycode.zz_ShowNeedsSaveColor = true;
            this.ctl_securitycode.zz_Text = "";
            this.ctl_securitycode.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_securitycode.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_securitycode.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_securitycode.zz_UseGlobalColor = false;
            this.ctl_securitycode.zz_UseGlobalFont = false;
            // 
            // cmdSendCreditCardifoToQBs
            // 
            this.cmdSendCreditCardifoToQBs.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSendCreditCardifoToQBs.Location = new System.Drawing.Point(456, 6);
            this.cmdSendCreditCardifoToQBs.Name = "cmdSendCreditCardifoToQBs";
            this.cmdSendCreditCardifoToQBs.Size = new System.Drawing.Size(152, 23);
            this.cmdSendCreditCardifoToQBs.TabIndex = 35;
            this.cmdSendCreditCardifoToQBs.Text = "Send CC Info To QBs";
            this.cmdSendCreditCardifoToQBs.UseVisualStyleBackColor = true;
            // 
            // ctl_nameoncard
            // 
            this.ctl_nameoncard.AllCaps = false;
            this.ctl_nameoncard.BackColor = System.Drawing.Color.Transparent;
            this.ctl_nameoncard.Bold = false;
            this.ctl_nameoncard.Caption = "Name On Card";
            this.ctl_nameoncard.Changed = false;
            this.ctl_nameoncard.IsEmail = false;
            this.ctl_nameoncard.IsURL = false;
            this.ctl_nameoncard.Location = new System.Drawing.Point(9, 60);
            this.ctl_nameoncard.Name = "ctl_nameoncard";
            this.ctl_nameoncard.PasswordChar = '\0';
            this.ctl_nameoncard.Size = new System.Drawing.Size(303, 47);
            this.ctl_nameoncard.TabIndex = 30;
            this.ctl_nameoncard.UseParentBackColor = true;
            this.ctl_nameoncard.zz_Enabled = true;
            this.ctl_nameoncard.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_nameoncard.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_nameoncard.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_nameoncard.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_nameoncard.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_nameoncard.zz_OriginalDesign = false;
            this.ctl_nameoncard.zz_ShowLinkButton = false;
            this.ctl_nameoncard.zz_ShowNeedsSaveColor = true;
            this.ctl_nameoncard.zz_Text = "";
            this.ctl_nameoncard.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_nameoncard.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_nameoncard.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_nameoncard.zz_UseGlobalColor = false;
            this.ctl_nameoncard.zz_UseGlobalFont = false;
            // 
            // ctl_cardbillingzip
            // 
            this.ctl_cardbillingzip.AllCaps = false;
            this.ctl_cardbillingzip.BackColor = System.Drawing.Color.Transparent;
            this.ctl_cardbillingzip.Bold = false;
            this.ctl_cardbillingzip.Caption = "Card Billing Zip";
            this.ctl_cardbillingzip.Changed = false;
            this.ctl_cardbillingzip.IsEmail = false;
            this.ctl_cardbillingzip.IsURL = false;
            this.ctl_cardbillingzip.Location = new System.Drawing.Point(9, 199);
            this.ctl_cardbillingzip.Name = "ctl_cardbillingzip";
            this.ctl_cardbillingzip.PasswordChar = '\0';
            this.ctl_cardbillingzip.Size = new System.Drawing.Size(303, 47);
            this.ctl_cardbillingzip.TabIndex = 32;
            this.ctl_cardbillingzip.UseParentBackColor = true;
            this.ctl_cardbillingzip.zz_Enabled = true;
            this.ctl_cardbillingzip.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_cardbillingzip.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_cardbillingzip.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_cardbillingzip.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_cardbillingzip.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_cardbillingzip.zz_OriginalDesign = false;
            this.ctl_cardbillingzip.zz_ShowLinkButton = false;
            this.ctl_cardbillingzip.zz_ShowNeedsSaveColor = true;
            this.ctl_cardbillingzip.zz_Text = "";
            this.ctl_cardbillingzip.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_cardbillingzip.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_cardbillingzip.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_cardbillingzip.zz_UseGlobalColor = false;
            this.ctl_cardbillingzip.zz_UseGlobalFont = false;
            // 
            // ctl_cardbillingaddr
            // 
            this.ctl_cardbillingaddr.AllCaps = false;
            this.ctl_cardbillingaddr.BackColor = System.Drawing.Color.Transparent;
            this.ctl_cardbillingaddr.Bold = false;
            this.ctl_cardbillingaddr.Caption = "Card Billing Address";
            this.ctl_cardbillingaddr.Changed = false;
            this.ctl_cardbillingaddr.IsEmail = false;
            this.ctl_cardbillingaddr.IsURL = false;
            this.ctl_cardbillingaddr.Location = new System.Drawing.Point(9, 153);
            this.ctl_cardbillingaddr.Name = "ctl_cardbillingaddr";
            this.ctl_cardbillingaddr.PasswordChar = '\0';
            this.ctl_cardbillingaddr.Size = new System.Drawing.Size(303, 47);
            this.ctl_cardbillingaddr.TabIndex = 31;
            this.ctl_cardbillingaddr.UseParentBackColor = true;
            this.ctl_cardbillingaddr.zz_Enabled = true;
            this.ctl_cardbillingaddr.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_cardbillingaddr.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_cardbillingaddr.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_cardbillingaddr.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_cardbillingaddr.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_cardbillingaddr.zz_OriginalDesign = false;
            this.ctl_cardbillingaddr.zz_ShowLinkButton = false;
            this.ctl_cardbillingaddr.zz_ShowNeedsSaveColor = true;
            this.ctl_cardbillingaddr.zz_Text = "";
            this.ctl_cardbillingaddr.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_cardbillingaddr.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_cardbillingaddr.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_cardbillingaddr.zz_UseGlobalColor = false;
            this.ctl_cardbillingaddr.zz_UseGlobalFont = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(218, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 26);
            this.label3.TabIndex = 31;
            this.label3.Text = "/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(183, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 30;
            this.label2.Text = "Expiration Date";
            // 
            // ctl_expiration_year
            // 
            this.ctl_expiration_year.BackColor = System.Drawing.Color.Transparent;
            this.ctl_expiration_year.Bold = false;
            this.ctl_expiration_year.Caption = "";
            this.ctl_expiration_year.Changed = true;
            this.ctl_expiration_year.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_expiration_year.Location = new System.Drawing.Point(243, 126);
            this.ctl_expiration_year.Name = "ctl_expiration_year";
            this.ctl_expiration_year.Size = new System.Drawing.Size(69, 28);
            this.ctl_expiration_year.TabIndex = 29;
            this.ctl_expiration_year.UseParentBackColor = false;
            this.ctl_expiration_year.zz_Enabled = true;
            this.ctl_expiration_year.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_expiration_year.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_expiration_year.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_expiration_year.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_expiration_year.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_expiration_year.zz_OriginalDesign = false;
            this.ctl_expiration_year.zz_ShowErrorColor = true;
            this.ctl_expiration_year.zz_ShowNeedsSaveColor = true;
            this.ctl_expiration_year.zz_Text = "";
            this.ctl_expiration_year.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctl_expiration_year.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_expiration_year.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_expiration_year.zz_UseGlobalColor = false;
            this.ctl_expiration_year.zz_UseGlobalFont = false;
            // 
            // ctl_expiration_month
            // 
            this.ctl_expiration_month.BackColor = System.Drawing.Color.Transparent;
            this.ctl_expiration_month.Bold = false;
            this.ctl_expiration_month.Caption = "";
            this.ctl_expiration_month.Changed = true;
            this.ctl_expiration_month.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_expiration_month.Location = new System.Drawing.Point(166, 126);
            this.ctl_expiration_month.Name = "ctl_expiration_month";
            this.ctl_expiration_month.Size = new System.Drawing.Size(43, 28);
            this.ctl_expiration_month.TabIndex = 28;
            this.ctl_expiration_month.UseParentBackColor = false;
            this.ctl_expiration_month.zz_Enabled = true;
            this.ctl_expiration_month.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_expiration_month.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_expiration_month.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_expiration_month.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_expiration_month.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_expiration_month.zz_OriginalDesign = false;
            this.ctl_expiration_month.zz_ShowErrorColor = true;
            this.ctl_expiration_month.zz_ShowNeedsSaveColor = true;
            this.ctl_expiration_month.zz_Text = "";
            this.ctl_expiration_month.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctl_expiration_month.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_expiration_month.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_expiration_month.zz_UseGlobalColor = false;
            this.ctl_expiration_month.zz_UseGlobalFont = false;
            // 
            // ctl_creditcardtype
            // 
            this.ctl_creditcardtype.AllCaps = false;
            this.ctl_creditcardtype.AllowEdit = true;
            this.ctl_creditcardtype.BackColor = System.Drawing.Color.Transparent;
            this.ctl_creditcardtype.Bold = false;
            this.ctl_creditcardtype.Caption = "Credit Card Type";
            this.ctl_creditcardtype.Changed = false;
            this.ctl_creditcardtype.ListName = "creditcardtypes";
            this.ctl_creditcardtype.Location = new System.Drawing.Point(319, 13);
            this.ctl_creditcardtype.Name = "ctl_creditcardtype";
            this.ctl_creditcardtype.SimpleList = null;
            this.ctl_creditcardtype.Size = new System.Drawing.Size(295, 48);
            this.ctl_creditcardtype.TabIndex = 26;
            this.ctl_creditcardtype.UseParentBackColor = false;
            this.ctl_creditcardtype.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_creditcardtype.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_creditcardtype.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_creditcardtype.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_creditcardtype.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_creditcardtype.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_creditcardtype.zz_OriginalDesign = false;
            this.ctl_creditcardtype.zz_ShowNeedsSaveColor = true;
            this.ctl_creditcardtype.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_creditcardtype.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_creditcardtype.zz_UseGlobalColor = false;
            this.ctl_creditcardtype.zz_UseGlobalFont = false;
            // 
            // ctl_creditcardnumber
            // 
            this.ctl_creditcardnumber.AllCaps = false;
            this.ctl_creditcardnumber.BackColor = System.Drawing.Color.Transparent;
            this.ctl_creditcardnumber.Bold = false;
            this.ctl_creditcardnumber.Caption = "Credit Card Number";
            this.ctl_creditcardnumber.Changed = false;
            this.ctl_creditcardnumber.IsEmail = false;
            this.ctl_creditcardnumber.IsURL = false;
            this.ctl_creditcardnumber.Location = new System.Drawing.Point(9, 14);
            this.ctl_creditcardnumber.Name = "ctl_creditcardnumber";
            this.ctl_creditcardnumber.PasswordChar = '\0';
            this.ctl_creditcardnumber.Size = new System.Drawing.Size(303, 47);
            this.ctl_creditcardnumber.TabIndex = 25;
            this.ctl_creditcardnumber.UseParentBackColor = true;
            this.ctl_creditcardnumber.zz_Enabled = true;
            this.ctl_creditcardnumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_creditcardnumber.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_creditcardnumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_creditcardnumber.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_creditcardnumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_creditcardnumber.zz_OriginalDesign = false;
            this.ctl_creditcardnumber.zz_ShowLinkButton = false;
            this.ctl_creditcardnumber.zz_ShowNeedsSaveColor = true;
            this.ctl_creditcardnumber.zz_Text = "";
            this.ctl_creditcardnumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_creditcardnumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_creditcardnumber.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_creditcardnumber.zz_UseGlobalColor = false;
            this.ctl_creditcardnumber.zz_UseGlobalFont = false;
            // 
            // pagePOInfo
            // 
            this.pagePOInfo.Controls.Add(this.lblNotifyList);
            this.pagePOInfo.Controls.Add(this.lblClear);
            this.pagePOInfo.Controls.Add(this.lblRemove);
            this.pagePOInfo.Controls.Add(this.lblNotifyAdd);
            this.pagePOInfo.Controls.Add(this.lblNotify);
            this.pagePOInfo.Controls.Add(this.ctl_po_min);
            this.pagePOInfo.Location = new System.Drawing.Point(4, 22);
            this.pagePOInfo.Name = "pagePOInfo";
            this.pagePOInfo.Padding = new System.Windows.Forms.Padding(3);
            this.pagePOInfo.Size = new System.Drawing.Size(192, 74);
            this.pagePOInfo.TabIndex = 9;
            this.pagePOInfo.Text = "PO Info";
            this.pagePOInfo.UseVisualStyleBackColor = true;
            // 
            // lblNotifyList
            // 
            this.lblNotifyList.AutoSize = true;
            this.lblNotifyList.Location = new System.Drawing.Point(10, 91);
            this.lblNotifyList.Name = "lblNotifyList";
            this.lblNotifyList.Size = new System.Drawing.Size(59, 13);
            this.lblNotifyList.TabIndex = 47;
            this.lblNotifyList.Text = "<notify list>";
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.Location = new System.Drawing.Point(93, 70);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(31, 13);
            this.lblClear.TabIndex = 46;
            this.lblClear.TabStop = true;
            this.lblClear.Text = "Clear";
            this.lblClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblClear_LinkClicked);
            // 
            // lblRemove
            // 
            this.lblRemove.AutoSize = true;
            this.lblRemove.Location = new System.Drawing.Point(40, 70);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(47, 13);
            this.lblRemove.TabIndex = 45;
            this.lblRemove.TabStop = true;
            this.lblRemove.Text = "Remove";
            this.lblRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRemove_LinkClicked);
            // 
            // lblNotifyAdd
            // 
            this.lblNotifyAdd.AutoSize = true;
            this.lblNotifyAdd.Location = new System.Drawing.Point(8, 70);
            this.lblNotifyAdd.Name = "lblNotifyAdd";
            this.lblNotifyAdd.Size = new System.Drawing.Size(26, 13);
            this.lblNotifyAdd.TabIndex = 44;
            this.lblNotifyAdd.TabStop = true;
            this.lblNotifyAdd.Text = "Add";
            this.lblNotifyAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNotifyAdd_LinkClicked);
            // 
            // lblNotify
            // 
            this.lblNotify.AutoSize = true;
            this.lblNotify.Location = new System.Drawing.Point(8, 52);
            this.lblNotify.Name = "lblNotify";
            this.lblNotify.Size = new System.Drawing.Size(206, 13);
            this.lblNotify.TabIndex = 43;
            this.lblNotify.Text = "Notify these people when a PO is created:";
            // 
            // ctl_po_min
            // 
            this.ctl_po_min.BackColor = System.Drawing.Color.Transparent;
            this.ctl_po_min.Bold = false;
            this.ctl_po_min.Caption = "PO Min";
            this.ctl_po_min.Changed = true;
            this.ctl_po_min.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_po_min.Location = new System.Drawing.Point(6, 6);
            this.ctl_po_min.Name = "ctl_po_min";
            this.ctl_po_min.Size = new System.Drawing.Size(74, 35);
            this.ctl_po_min.TabIndex = 42;
            this.ctl_po_min.UseParentBackColor = true;
            this.ctl_po_min.zz_Enabled = true;
            this.ctl_po_min.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_po_min.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_po_min.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_po_min.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_po_min.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_po_min.zz_OriginalDesign = false;
            this.ctl_po_min.zz_ShowErrorColor = true;
            this.ctl_po_min.zz_ShowNeedsSaveColor = true;
            this.ctl_po_min.zz_Text = "0";
            this.ctl_po_min.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_po_min.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_po_min.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_po_min.zz_UseGlobalColor = false;
            this.ctl_po_min.zz_UseGlobalFont = false;
            // 
            // tabProducts
            // 
            this.tabProducts.Controls.Add(this.ctl_Products_Components);
            this.tabProducts.Controls.Add(this.ctl_Products_PowerSupply);
            this.tabProducts.Controls.Add(this.ctl_Products_OpticalTransceiver);
            this.tabProducts.Controls.Add(this.lbl_Products);
            this.tabProducts.Controls.Add(this.ctl_Products_SSD);
            this.tabProducts.Controls.Add(this.ctl_Products_Cabling);
            this.tabProducts.Controls.Add(this.ctl_Products_Interconnect);
            this.tabProducts.Controls.Add(this.ctl_Products_CrystalOsc);
            this.tabProducts.Controls.Add(this.ctl_Products_Relay);
            this.tabProducts.Controls.Add(this.ctl_Products_Display);
            this.tabProducts.Location = new System.Drawing.Point(4, 22);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabProducts.Size = new System.Drawing.Size(192, 74);
            this.tabProducts.TabIndex = 11;
            this.tabProducts.Text = "Products";
            this.tabProducts.UseVisualStyleBackColor = true;
            // 
            // ctl_Products_Components
            // 
            this.ctl_Products_Components.BackColor = System.Drawing.Color.Transparent;
            this.ctl_Products_Components.Bold = false;
            this.ctl_Products_Components.Caption = "Components";
            this.ctl_Products_Components.Changed = false;
            this.ctl_Products_Components.Location = new System.Drawing.Point(164, 39);
            this.ctl_Products_Components.Name = "ctl_Products_Components";
            this.ctl_Products_Components.Size = new System.Drawing.Size(85, 18);
            this.ctl_Products_Components.TabIndex = 48;
            this.ctl_Products_Components.UseParentBackColor = true;
            this.ctl_Products_Components.zz_CheckValue = false;
            this.ctl_Products_Components.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_Products_Components.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_Products_Components.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_Products_Components.zz_OriginalDesign = false;
            this.ctl_Products_Components.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_Products_PowerSupply
            // 
            this.ctl_Products_PowerSupply.BackColor = System.Drawing.Color.Transparent;
            this.ctl_Products_PowerSupply.Bold = false;
            this.ctl_Products_PowerSupply.Caption = "Power Supply";
            this.ctl_Products_PowerSupply.Changed = false;
            this.ctl_Products_PowerSupply.Location = new System.Drawing.Point(18, 207);
            this.ctl_Products_PowerSupply.Name = "ctl_Products_PowerSupply";
            this.ctl_Products_PowerSupply.Size = new System.Drawing.Size(91, 18);
            this.ctl_Products_PowerSupply.TabIndex = 47;
            this.ctl_Products_PowerSupply.UseParentBackColor = true;
            this.ctl_Products_PowerSupply.zz_CheckValue = false;
            this.ctl_Products_PowerSupply.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_Products_PowerSupply.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_Products_PowerSupply.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_Products_PowerSupply.zz_OriginalDesign = false;
            this.ctl_Products_PowerSupply.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_Products_OpticalTransceiver
            // 
            this.ctl_Products_OpticalTransceiver.BackColor = System.Drawing.Color.Transparent;
            this.ctl_Products_OpticalTransceiver.Bold = false;
            this.ctl_Products_OpticalTransceiver.Caption = "Optical Transceiver";
            this.ctl_Products_OpticalTransceiver.Changed = false;
            this.ctl_Products_OpticalTransceiver.Location = new System.Drawing.Point(18, 183);
            this.ctl_Products_OpticalTransceiver.Name = "ctl_Products_OpticalTransceiver";
            this.ctl_Products_OpticalTransceiver.Size = new System.Drawing.Size(118, 18);
            this.ctl_Products_OpticalTransceiver.TabIndex = 46;
            this.ctl_Products_OpticalTransceiver.UseParentBackColor = true;
            this.ctl_Products_OpticalTransceiver.zz_CheckValue = false;
            this.ctl_Products_OpticalTransceiver.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_Products_OpticalTransceiver.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_Products_OpticalTransceiver.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_Products_OpticalTransceiver.zz_OriginalDesign = false;
            this.ctl_Products_OpticalTransceiver.zz_ShowNeedsSaveColor = true;
            // 
            // lbl_Products
            // 
            this.lbl_Products.AutoSize = true;
            this.lbl_Products.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Products.Location = new System.Drawing.Point(15, 23);
            this.lbl_Products.Name = "lbl_Products";
            this.lbl_Products.Size = new System.Drawing.Size(276, 13);
            this.lbl_Products.TabIndex = 45;
            this.lbl_Products.Text = "This company uses the following product types:";
            // 
            // ctl_Products_SSD
            // 
            this.ctl_Products_SSD.BackColor = System.Drawing.Color.Transparent;
            this.ctl_Products_SSD.Bold = false;
            this.ctl_Products_SSD.Caption = "SSDs";
            this.ctl_Products_SSD.Changed = false;
            this.ctl_Products_SSD.Location = new System.Drawing.Point(18, 63);
            this.ctl_Products_SSD.Name = "ctl_Products_SSD";
            this.ctl_Products_SSD.Size = new System.Drawing.Size(53, 18);
            this.ctl_Products_SSD.TabIndex = 44;
            this.ctl_Products_SSD.UseParentBackColor = true;
            this.ctl_Products_SSD.zz_CheckValue = false;
            this.ctl_Products_SSD.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_Products_SSD.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_Products_SSD.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_Products_SSD.zz_OriginalDesign = false;
            this.ctl_Products_SSD.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_Products_Cabling
            // 
            this.ctl_Products_Cabling.BackColor = System.Drawing.Color.Transparent;
            this.ctl_Products_Cabling.Bold = false;
            this.ctl_Products_Cabling.Caption = "Cabling";
            this.ctl_Products_Cabling.Changed = false;
            this.ctl_Products_Cabling.Location = new System.Drawing.Point(18, 87);
            this.ctl_Products_Cabling.Name = "ctl_Products_Cabling";
            this.ctl_Products_Cabling.Size = new System.Drawing.Size(61, 18);
            this.ctl_Products_Cabling.TabIndex = 43;
            this.ctl_Products_Cabling.UseParentBackColor = true;
            this.ctl_Products_Cabling.zz_CheckValue = false;
            this.ctl_Products_Cabling.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_Products_Cabling.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_Products_Cabling.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_Products_Cabling.zz_OriginalDesign = false;
            this.ctl_Products_Cabling.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_Products_Interconnect
            // 
            this.ctl_Products_Interconnect.BackColor = System.Drawing.Color.Transparent;
            this.ctl_Products_Interconnect.Bold = false;
            this.ctl_Products_Interconnect.Caption = "Interconnects";
            this.ctl_Products_Interconnect.Changed = false;
            this.ctl_Products_Interconnect.Location = new System.Drawing.Point(18, 111);
            this.ctl_Products_Interconnect.Name = "ctl_Products_Interconnect";
            this.ctl_Products_Interconnect.Size = new System.Drawing.Size(91, 18);
            this.ctl_Products_Interconnect.TabIndex = 42;
            this.ctl_Products_Interconnect.UseParentBackColor = true;
            this.ctl_Products_Interconnect.zz_CheckValue = false;
            this.ctl_Products_Interconnect.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_Products_Interconnect.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_Products_Interconnect.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_Products_Interconnect.zz_OriginalDesign = false;
            this.ctl_Products_Interconnect.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_Products_CrystalOsc
            // 
            this.ctl_Products_CrystalOsc.BackColor = System.Drawing.Color.Transparent;
            this.ctl_Products_CrystalOsc.Bold = false;
            this.ctl_Products_CrystalOsc.Caption = "Crystal Oscillators";
            this.ctl_Products_CrystalOsc.Changed = false;
            this.ctl_Products_CrystalOsc.Location = new System.Drawing.Point(18, 135);
            this.ctl_Products_CrystalOsc.Name = "ctl_Products_CrystalOsc";
            this.ctl_Products_CrystalOsc.Size = new System.Drawing.Size(108, 18);
            this.ctl_Products_CrystalOsc.TabIndex = 41;
            this.ctl_Products_CrystalOsc.UseParentBackColor = true;
            this.ctl_Products_CrystalOsc.zz_CheckValue = false;
            this.ctl_Products_CrystalOsc.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_Products_CrystalOsc.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_Products_CrystalOsc.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_Products_CrystalOsc.zz_OriginalDesign = false;
            this.ctl_Products_CrystalOsc.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_Products_Relay
            // 
            this.ctl_Products_Relay.BackColor = System.Drawing.Color.Transparent;
            this.ctl_Products_Relay.Bold = false;
            this.ctl_Products_Relay.Caption = "Relays";
            this.ctl_Products_Relay.Changed = false;
            this.ctl_Products_Relay.Location = new System.Drawing.Point(18, 159);
            this.ctl_Products_Relay.Name = "ctl_Products_Relay";
            this.ctl_Products_Relay.Size = new System.Drawing.Size(58, 18);
            this.ctl_Products_Relay.TabIndex = 40;
            this.ctl_Products_Relay.UseParentBackColor = true;
            this.ctl_Products_Relay.zz_CheckValue = false;
            this.ctl_Products_Relay.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_Products_Relay.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_Products_Relay.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_Products_Relay.zz_OriginalDesign = false;
            this.ctl_Products_Relay.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_Products_Display
            // 
            this.ctl_Products_Display.BackColor = System.Drawing.Color.Transparent;
            this.ctl_Products_Display.Bold = false;
            this.ctl_Products_Display.Caption = "Displays";
            this.ctl_Products_Display.Changed = false;
            this.ctl_Products_Display.Location = new System.Drawing.Point(18, 39);
            this.ctl_Products_Display.Name = "ctl_Products_Display";
            this.ctl_Products_Display.Size = new System.Drawing.Size(65, 18);
            this.ctl_Products_Display.TabIndex = 39;
            this.ctl_Products_Display.UseParentBackColor = true;
            this.ctl_Products_Display.zz_CheckValue = false;
            this.ctl_Products_Display.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_Products_Display.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_Products_Display.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_Products_Display.zz_OriginalDesign = false;
            this.ctl_Products_Display.zz_ShowNeedsSaveColor = true;
            // 
            // tsl
            // 
            this.tsl.Controls.Add(this.pageContacts);
            this.tsl.Controls.Add(this.pageAddresses);
            this.tsl.Controls.Add(this.tabAccounts);
            this.tsl.Controls.Add(this.pageReqs);
            this.tsl.Controls.Add(this.pageBatches);
            this.tsl.Controls.Add(this.tabQuotes);
            this.tsl.Controls.Add(this.pageBids);
            this.tsl.Controls.Add(this.tabOrders);
            this.tsl.Controls.Add(this.pageNotes);
            this.tsl.Controls.Add(this.tabPortalSearches);
            this.tsl.Controls.Add(this.tabCalls);
            this.tsl.Controls.Add(this.tabExcess);
            this.tsl.Controls.Add(this.tabFeedback);
            this.tsl.Controls.Add(this.tabCompanyCredits);
            this.tsl.Controls.Add(this.tabGenie);
            this.tsl.Controls.Add(this.tabConsignCodes);
            this.tsl.Location = new System.Drawing.Point(4, 302);
            this.tsl.Name = "tsl";
            this.tsl.SelectedIndex = 0;
            this.tsl.Size = new System.Drawing.Size(756, 288);
            this.tsl.TabIndex = 7;
            this.tsl.SelectedIndexChanged += new System.EventHandler(this.tsl_SelectedIndexChanged);
            // 
            // pageContacts
            // 
            this.pageContacts.Controls.Add(this.result_contacts);
            this.pageContacts.Location = new System.Drawing.Point(4, 22);
            this.pageContacts.Name = "pageContacts";
            this.pageContacts.Padding = new System.Windows.Forms.Padding(3);
            this.pageContacts.Size = new System.Drawing.Size(748, 262);
            this.pageContacts.TabIndex = 0;
            this.pageContacts.Text = "Contacts";
            this.pageContacts.UseVisualStyleBackColor = true;
            // 
            // result_contacts
            // 
            this.result_contacts.AddCaption = "Add A New Contact";
            this.result_contacts.AllowActions = true;
            this.result_contacts.AllowAdd = true;
            this.result_contacts.AllowDelete = true;
            this.result_contacts.AllowDeleteAlways = false;
            this.result_contacts.AllowDrop = true;
            this.result_contacts.AllowOnlyOpenDelete = false;
            this.result_contacts.AlternateConnection = null;
            this.result_contacts.BackColor = System.Drawing.Color.White;
            this.result_contacts.Caption = "";
            this.result_contacts.CurrentTemplate = null;
            this.result_contacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.result_contacts.ExtraClassInfo = "";
            this.result_contacts.Location = new System.Drawing.Point(3, 3);
            this.result_contacts.MultiSelect = true;
            this.result_contacts.Name = "result_contacts";
            this.result_contacts.Size = new System.Drawing.Size(742, 256);
            this.result_contacts.SuppressSelectionChanged = false;
            this.result_contacts.TabIndex = 0;
            this.result_contacts.zz_OpenColumnMenu = false;
            this.result_contacts.zz_OrderLineType = "";
            this.result_contacts.zz_ShowAutoRefresh = true;
            this.result_contacts.zz_ShowUnlimited = true;
            this.result_contacts.AboutToAdd += new NewMethod.AddHandler(this.result_contacts_AboutToAdd);
            // 
            // pageAddresses
            // 
            this.pageAddresses.Controls.Add(this.result_addresses);
            this.pageAddresses.Location = new System.Drawing.Point(4, 22);
            this.pageAddresses.Name = "pageAddresses";
            this.pageAddresses.Padding = new System.Windows.Forms.Padding(3);
            this.pageAddresses.Size = new System.Drawing.Size(748, 262);
            this.pageAddresses.TabIndex = 1;
            this.pageAddresses.Text = "Addresses";
            this.pageAddresses.UseVisualStyleBackColor = true;
            // 
            // result_addresses
            // 
            this.result_addresses.AddCaption = "Add A New Address";
            this.result_addresses.AllowActions = true;
            this.result_addresses.AllowAdd = true;
            this.result_addresses.AllowDelete = true;
            this.result_addresses.AllowDeleteAlways = false;
            this.result_addresses.AllowDrop = true;
            this.result_addresses.AllowOnlyOpenDelete = false;
            this.result_addresses.AlternateConnection = null;
            this.result_addresses.BackColor = System.Drawing.Color.White;
            this.result_addresses.Caption = "";
            this.result_addresses.CurrentTemplate = null;
            this.result_addresses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.result_addresses.ExtraClassInfo = "";
            this.result_addresses.Location = new System.Drawing.Point(3, 3);
            this.result_addresses.MultiSelect = true;
            this.result_addresses.Name = "result_addresses";
            this.result_addresses.Size = new System.Drawing.Size(742, 256);
            this.result_addresses.SuppressSelectionChanged = false;
            this.result_addresses.TabIndex = 1;
            this.result_addresses.zz_OpenColumnMenu = false;
            this.result_addresses.zz_OrderLineType = "";
            this.result_addresses.zz_ShowAutoRefresh = true;
            this.result_addresses.zz_ShowUnlimited = true;
            this.result_addresses.AboutToAdd += new NewMethod.AddHandler(this.result_addresses_AboutToAdd);
            this.result_addresses.Load += new System.EventHandler(this.result_addresses_Load);
            // 
            // tabAccounts
            // 
            this.tabAccounts.Controls.Add(this.result_accounts);
            this.tabAccounts.Location = new System.Drawing.Point(4, 22);
            this.tabAccounts.Name = "tabAccounts";
            this.tabAccounts.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccounts.Size = new System.Drawing.Size(748, 262);
            this.tabAccounts.TabIndex = 2;
            this.tabAccounts.Text = "Shipping Accounts";
            this.tabAccounts.UseVisualStyleBackColor = true;
            // 
            // result_accounts
            // 
            this.result_accounts.AddCaption = "Add A New Shipping Account";
            this.result_accounts.AllowActions = true;
            this.result_accounts.AllowAdd = true;
            this.result_accounts.AllowDelete = true;
            this.result_accounts.AllowDeleteAlways = false;
            this.result_accounts.AllowDrop = true;
            this.result_accounts.AllowOnlyOpenDelete = false;
            this.result_accounts.AlternateConnection = null;
            this.result_accounts.BackColor = System.Drawing.Color.White;
            this.result_accounts.Caption = "";
            this.result_accounts.CurrentTemplate = null;
            this.result_accounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.result_accounts.ExtraClassInfo = "";
            this.result_accounts.Location = new System.Drawing.Point(3, 3);
            this.result_accounts.MultiSelect = true;
            this.result_accounts.Name = "result_accounts";
            this.result_accounts.Size = new System.Drawing.Size(742, 256);
            this.result_accounts.SuppressSelectionChanged = false;
            this.result_accounts.TabIndex = 1;
            this.result_accounts.zz_OpenColumnMenu = false;
            this.result_accounts.zz_OrderLineType = "";
            this.result_accounts.zz_ShowAutoRefresh = true;
            this.result_accounts.zz_ShowUnlimited = true;
            this.result_accounts.AboutToAdd += new NewMethod.AddHandler(this.result_accounts_AboutToAdd);
            // 
            // pageReqs
            // 
            this.pageReqs.Controls.Add(this.result_reqs);
            this.pageReqs.Location = new System.Drawing.Point(4, 22);
            this.pageReqs.Name = "pageReqs";
            this.pageReqs.Padding = new System.Windows.Forms.Padding(3);
            this.pageReqs.Size = new System.Drawing.Size(748, 262);
            this.pageReqs.TabIndex = 3;
            this.pageReqs.Text = "Reqs";
            this.pageReqs.UseVisualStyleBackColor = true;
            // 
            // result_reqs
            // 
            this.result_reqs.AddCaption = "Add A New Requirement";
            this.result_reqs.AllowActions = true;
            this.result_reqs.AllowAdd = true;
            this.result_reqs.AllowDelete = true;
            this.result_reqs.AllowDeleteAlways = false;
            this.result_reqs.AllowDrop = true;
            this.result_reqs.AllowOnlyOpenDelete = false;
            this.result_reqs.AlternateConnection = null;
            this.result_reqs.BackColor = System.Drawing.Color.White;
            this.result_reqs.Caption = "";
            this.result_reqs.CurrentTemplate = null;
            this.result_reqs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.result_reqs.ExtraClassInfo = "";
            this.result_reqs.Location = new System.Drawing.Point(3, 3);
            this.result_reqs.MultiSelect = true;
            this.result_reqs.Name = "result_reqs";
            this.result_reqs.Size = new System.Drawing.Size(742, 256);
            this.result_reqs.SuppressSelectionChanged = false;
            this.result_reqs.TabIndex = 1;
            this.result_reqs.zz_OpenColumnMenu = false;
            this.result_reqs.zz_OrderLineType = "";
            this.result_reqs.zz_ShowAutoRefresh = true;
            this.result_reqs.zz_ShowUnlimited = true;
            this.result_reqs.AboutToAdd += new NewMethod.AddHandler(this.result_reqs_AboutToAdd);
            // 
            // pageBatches
            // 
            this.pageBatches.Controls.Add(this.result_reqbatches);
            this.pageBatches.Location = new System.Drawing.Point(4, 22);
            this.pageBatches.Name = "pageBatches";
            this.pageBatches.Padding = new System.Windows.Forms.Padding(3);
            this.pageBatches.Size = new System.Drawing.Size(748, 262);
            this.pageBatches.TabIndex = 4;
            this.pageBatches.Text = "Order Batches";
            this.pageBatches.UseVisualStyleBackColor = true;
            // 
            // result_reqbatches
            // 
            this.result_reqbatches.AddCaption = "Add A Batch";
            this.result_reqbatches.AllowActions = true;
            this.result_reqbatches.AllowAdd = true;
            this.result_reqbatches.AllowDelete = true;
            this.result_reqbatches.AllowDeleteAlways = false;
            this.result_reqbatches.AllowDrop = true;
            this.result_reqbatches.AllowOnlyOpenDelete = false;
            this.result_reqbatches.AlternateConnection = null;
            this.result_reqbatches.BackColor = System.Drawing.Color.White;
            this.result_reqbatches.Caption = "";
            this.result_reqbatches.CurrentTemplate = null;
            this.result_reqbatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.result_reqbatches.ExtraClassInfo = "";
            this.result_reqbatches.Location = new System.Drawing.Point(3, 3);
            this.result_reqbatches.MultiSelect = true;
            this.result_reqbatches.Name = "result_reqbatches";
            this.result_reqbatches.Size = new System.Drawing.Size(742, 256);
            this.result_reqbatches.SuppressSelectionChanged = false;
            this.result_reqbatches.TabIndex = 1;
            this.result_reqbatches.zz_OpenColumnMenu = false;
            this.result_reqbatches.zz_OrderLineType = "";
            this.result_reqbatches.zz_ShowAutoRefresh = true;
            this.result_reqbatches.zz_ShowUnlimited = true;
            this.result_reqbatches.AboutToAdd += new NewMethod.AddHandler(this.result_reqbatches_AboutToAdd);
            // 
            // tabQuotes
            // 
            this.tabQuotes.Controls.Add(this.panelAtometronQuote);
            this.tabQuotes.Controls.Add(this.result_qquotes);
            this.tabQuotes.Controls.Add(this.result_fquotes);
            this.tabQuotes.Location = new System.Drawing.Point(4, 22);
            this.tabQuotes.Name = "tabQuotes";
            this.tabQuotes.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuotes.Size = new System.Drawing.Size(748, 262);
            this.tabQuotes.TabIndex = 5;
            this.tabQuotes.Text = "Quotes";
            this.tabQuotes.UseVisualStyleBackColor = true;
            // 
            // panelAtometronQuote
            // 
            this.panelAtometronQuote.Controls.Add(this.gbQuoteOptions);
            this.panelAtometronQuote.Controls.Add(this.lvQuotes);
            this.panelAtometronQuote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAtometronQuote.Location = new System.Drawing.Point(3, 3);
            this.panelAtometronQuote.Name = "panelAtometronQuote";
            this.panelAtometronQuote.Size = new System.Drawing.Size(742, 256);
            this.panelAtometronQuote.TabIndex = 6;
            this.panelAtometronQuote.Visible = false;
            // 
            // gbQuoteOptions
            // 
            this.gbQuoteOptions.Controls.Add(this.optFormalQuotes);
            this.gbQuoteOptions.Controls.Add(this.optQuickQuotes);
            this.gbQuoteOptions.Location = new System.Drawing.Point(4, 4);
            this.gbQuoteOptions.Name = "gbQuoteOptions";
            this.gbQuoteOptions.Size = new System.Drawing.Size(727, 27);
            this.gbQuoteOptions.TabIndex = 7;
            this.gbQuoteOptions.TabStop = false;
            this.gbQuoteOptions.Text = "Options";
            // 
            // optFormalQuotes
            // 
            this.optFormalQuotes.AutoSize = true;
            this.optFormalQuotes.Location = new System.Drawing.Point(201, 8);
            this.optFormalQuotes.Name = "optFormalQuotes";
            this.optFormalQuotes.Size = new System.Drawing.Size(119, 17);
            this.optFormalQuotes.TabIndex = 2;
            this.optFormalQuotes.Text = "View Formal Quotes";
            this.optFormalQuotes.UseVisualStyleBackColor = true;
            // 
            // optQuickQuotes
            // 
            this.optQuickQuotes.AutoSize = true;
            this.optQuickQuotes.Checked = true;
            this.optQuickQuotes.Location = new System.Drawing.Point(78, 8);
            this.optQuickQuotes.Name = "optQuickQuotes";
            this.optQuickQuotes.Size = new System.Drawing.Size(116, 17);
            this.optQuickQuotes.TabIndex = 1;
            this.optQuickQuotes.TabStop = true;
            this.optQuickQuotes.Text = "View Quick Quotes";
            this.optQuickQuotes.UseVisualStyleBackColor = true;
            // 
            // lvQuotes
            // 
            this.lvQuotes.AddCaption = "Add A New Bid";
            this.lvQuotes.AllowActions = true;
            this.lvQuotes.AllowAdd = false;
            this.lvQuotes.AllowDelete = true;
            this.lvQuotes.AllowDeleteAlways = false;
            this.lvQuotes.AllowDrop = true;
            this.lvQuotes.AllowOnlyOpenDelete = false;
            this.lvQuotes.AlternateConnection = null;
            this.lvQuotes.BackColor = System.Drawing.Color.White;
            this.lvQuotes.Caption = "";
            this.lvQuotes.CurrentTemplate = null;
            this.lvQuotes.ExtraClassInfo = "";
            this.lvQuotes.Location = new System.Drawing.Point(8, 42);
            this.lvQuotes.MultiSelect = true;
            this.lvQuotes.Name = "lvQuotes";
            this.lvQuotes.Size = new System.Drawing.Size(727, 220);
            this.lvQuotes.SuppressSelectionChanged = false;
            this.lvQuotes.TabIndex = 6;
            this.lvQuotes.zz_OpenColumnMenu = false;
            this.lvQuotes.zz_OrderLineType = "";
            this.lvQuotes.zz_ShowAutoRefresh = true;
            this.lvQuotes.zz_ShowUnlimited = true;
            // 
            // result_qquotes
            // 
            this.result_qquotes.AddCaption = "Add New Quote";
            this.result_qquotes.AllowActions = true;
            this.result_qquotes.AllowAdd = false;
            this.result_qquotes.AllowDelete = true;
            this.result_qquotes.AllowDeleteAlways = false;
            this.result_qquotes.AllowDrop = true;
            this.result_qquotes.AllowOnlyOpenDelete = false;
            this.result_qquotes.AlternateConnection = null;
            this.result_qquotes.BackColor = System.Drawing.Color.White;
            this.result_qquotes.Caption = "";
            this.result_qquotes.CurrentTemplate = null;
            this.result_qquotes.ExtraClassInfo = "";
            this.result_qquotes.Location = new System.Drawing.Point(8, 6);
            this.result_qquotes.MultiSelect = true;
            this.result_qquotes.Name = "result_qquotes";
            this.result_qquotes.Size = new System.Drawing.Size(711, 122);
            this.result_qquotes.SuppressSelectionChanged = false;
            this.result_qquotes.TabIndex = 5;
            this.result_qquotes.zz_OpenColumnMenu = false;
            this.result_qquotes.zz_OrderLineType = "";
            this.result_qquotes.zz_ShowAutoRefresh = false;
            this.result_qquotes.zz_ShowUnlimited = false;
            // 
            // result_fquotes
            // 
            this.result_fquotes.AddCaption = "Add A New Contact";
            this.result_fquotes.AllowActions = true;
            this.result_fquotes.AllowAdd = false;
            this.result_fquotes.AllowDelete = true;
            this.result_fquotes.AllowDeleteAlways = false;
            this.result_fquotes.AllowDrop = true;
            this.result_fquotes.AllowOnlyOpenDelete = false;
            this.result_fquotes.AlternateConnection = null;
            this.result_fquotes.BackColor = System.Drawing.Color.White;
            this.result_fquotes.Caption = "";
            this.result_fquotes.CurrentTemplate = null;
            this.result_fquotes.ExtraClassInfo = "";
            this.result_fquotes.Location = new System.Drawing.Point(6, 143);
            this.result_fquotes.MultiSelect = true;
            this.result_fquotes.Name = "result_fquotes";
            this.result_fquotes.Size = new System.Drawing.Size(714, 112);
            this.result_fquotes.SuppressSelectionChanged = false;
            this.result_fquotes.TabIndex = 4;
            this.result_fquotes.zz_OpenColumnMenu = false;
            this.result_fquotes.zz_OrderLineType = "";
            this.result_fquotes.zz_ShowAutoRefresh = false;
            this.result_fquotes.zz_ShowUnlimited = false;
            // 
            // pageBids
            // 
            this.pageBids.Controls.Add(this.gbBid);
            this.pageBids.Controls.Add(this.result_bids);
            this.pageBids.Location = new System.Drawing.Point(4, 22);
            this.pageBids.Name = "pageBids";
            this.pageBids.Padding = new System.Windows.Forms.Padding(3);
            this.pageBids.Size = new System.Drawing.Size(748, 262);
            this.pageBids.TabIndex = 6;
            this.pageBids.Text = "Bids";
            this.pageBids.UseVisualStyleBackColor = true;
            // 
            // gbBid
            // 
            this.gbBid.Controls.Add(this.optRelatedBids);
            this.gbBid.Controls.Add(this.optActualBids);
            this.gbBid.Location = new System.Drawing.Point(6, 3);
            this.gbBid.Name = "gbBid";
            this.gbBid.Size = new System.Drawing.Size(727, 27);
            this.gbBid.TabIndex = 5;
            this.gbBid.TabStop = false;
            this.gbBid.Text = "Options";
            // 
            // optRelatedBids
            // 
            this.optRelatedBids.AutoSize = true;
            this.optRelatedBids.Location = new System.Drawing.Point(201, 8);
            this.optRelatedBids.Name = "optRelatedBids";
            this.optRelatedBids.Size = new System.Drawing.Size(262, 17);
            this.optRelatedBids.TabIndex = 2;
            this.optRelatedBids.Text = "Bids from other vendors on reqs from this company";
            this.optRelatedBids.UseVisualStyleBackColor = true;
            // 
            // optActualBids
            // 
            this.optActualBids.AutoSize = true;
            this.optActualBids.Checked = true;
            this.optActualBids.Location = new System.Drawing.Point(78, 8);
            this.optActualBids.Name = "optActualBids";
            this.optActualBids.Size = new System.Drawing.Size(95, 17);
            this.optActualBids.TabIndex = 1;
            this.optActualBids.TabStop = true;
            this.optActualBids.Text = "Bids as vendor";
            this.optActualBids.UseVisualStyleBackColor = true;
            // 
            // result_bids
            // 
            this.result_bids.AddCaption = "Add A New Bid";
            this.result_bids.AllowActions = true;
            this.result_bids.AllowAdd = false;
            this.result_bids.AllowDelete = true;
            this.result_bids.AllowDeleteAlways = false;
            this.result_bids.AllowDrop = true;
            this.result_bids.AllowOnlyOpenDelete = false;
            this.result_bids.AlternateConnection = null;
            this.result_bids.BackColor = System.Drawing.Color.White;
            this.result_bids.Caption = "";
            this.result_bids.CurrentTemplate = null;
            this.result_bids.ExtraClassInfo = "";
            this.result_bids.Location = new System.Drawing.Point(6, 36);
            this.result_bids.MultiSelect = true;
            this.result_bids.Name = "result_bids";
            this.result_bids.Size = new System.Drawing.Size(727, 222);
            this.result_bids.SuppressSelectionChanged = false;
            this.result_bids.TabIndex = 2;
            this.result_bids.zz_OpenColumnMenu = false;
            this.result_bids.zz_OrderLineType = "";
            this.result_bids.zz_ShowAutoRefresh = true;
            this.result_bids.zz_ShowUnlimited = true;
            this.result_bids.AboutToAdd += new NewMethod.AddHandler(this.result_bids_AboutToAdd);
            // 
            // tabOrders
            // 
            this.tabOrders.Controls.Add(this.gbSource);
            this.tabOrders.Controls.Add(this.result_orders);
            this.tabOrders.Controls.Add(this.gbOrderOptions);
            this.tabOrders.Location = new System.Drawing.Point(4, 22);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrders.Size = new System.Drawing.Size(748, 262);
            this.tabOrders.TabIndex = 7;
            this.tabOrders.Text = "Orders";
            this.tabOrders.UseVisualStyleBackColor = true;
            // 
            // gbSource
            // 
            this.gbSource.Controls.Add(this.optLineItems);
            this.gbSource.Controls.Add(this.optOrders);
            this.gbSource.Location = new System.Drawing.Point(2, 192);
            this.gbSource.Name = "gbSource";
            this.gbSource.Size = new System.Drawing.Size(118, 56);
            this.gbSource.TabIndex = 5;
            this.gbSource.TabStop = false;
            // 
            // optLineItems
            // 
            this.optLineItems.AutoSize = true;
            this.optLineItems.Location = new System.Drawing.Point(14, 28);
            this.optLineItems.Name = "optLineItems";
            this.optLineItems.Size = new System.Drawing.Size(73, 17);
            this.optLineItems.TabIndex = 3;
            this.optLineItems.Text = "Line Items";
            this.optLineItems.UseVisualStyleBackColor = true;
            this.optLineItems.CheckedChanged += new System.EventHandler(this.optAll_CheckedChanged);
            // 
            // optOrders
            // 
            this.optOrders.AutoSize = true;
            this.optOrders.Checked = true;
            this.optOrders.Location = new System.Drawing.Point(14, 11);
            this.optOrders.Name = "optOrders";
            this.optOrders.Size = new System.Drawing.Size(90, 17);
            this.optOrders.TabIndex = 2;
            this.optOrders.TabStop = true;
            this.optOrders.Text = "Whole Orders";
            this.optOrders.UseVisualStyleBackColor = true;
            this.optOrders.CheckedChanged += new System.EventHandler(this.optAll_CheckedChanged);
            // 
            // result_orders
            // 
            this.result_orders.AddCaption = "";
            this.result_orders.AllowActions = true;
            this.result_orders.AllowAdd = false;
            this.result_orders.AllowDelete = true;
            this.result_orders.AllowDeleteAlways = false;
            this.result_orders.AllowDrop = true;
            this.result_orders.AllowOnlyOpenDelete = false;
            this.result_orders.AlternateConnection = null;
            this.result_orders.BackColor = System.Drawing.Color.White;
            this.result_orders.Caption = "";
            this.result_orders.CurrentTemplate = null;
            this.result_orders.ExtraClassInfo = "";
            this.result_orders.Location = new System.Drawing.Point(127, 9);
            this.result_orders.MultiSelect = true;
            this.result_orders.Name = "result_orders";
            this.result_orders.Size = new System.Drawing.Size(609, 269);
            this.result_orders.SuppressSelectionChanged = false;
            this.result_orders.TabIndex = 3;
            this.result_orders.zz_OpenColumnMenu = false;
            this.result_orders.zz_OrderLineType = "";
            this.result_orders.zz_ShowAutoRefresh = true;
            this.result_orders.zz_ShowUnlimited = true;
            // 
            // gbOrderOptions
            // 
            this.gbOrderOptions.Controls.Add(this.optService);
            this.gbOrderOptions.Controls.Add(this.optVRMA);
            this.gbOrderOptions.Controls.Add(this.optRMAs);
            this.gbOrderOptions.Controls.Add(this.optInvoices);
            this.gbOrderOptions.Controls.Add(this.optPurchase);
            this.gbOrderOptions.Controls.Add(this.optSales);
            this.gbOrderOptions.Controls.Add(this.optQuote);
            this.gbOrderOptions.Controls.Add(this.optAll);
            this.gbOrderOptions.Location = new System.Drawing.Point(3, 3);
            this.gbOrderOptions.Name = "gbOrderOptions";
            this.gbOrderOptions.Size = new System.Drawing.Size(118, 186);
            this.gbOrderOptions.TabIndex = 4;
            this.gbOrderOptions.TabStop = false;
            this.gbOrderOptions.Text = "Options";
            // 
            // optService
            // 
            this.optService.AutoSize = true;
            this.optService.Location = new System.Drawing.Point(13, 157);
            this.optService.Name = "optService";
            this.optService.Size = new System.Drawing.Size(61, 17);
            this.optService.TabIndex = 7;
            this.optService.Text = "Service";
            this.optService.UseVisualStyleBackColor = true;
            this.optService.CheckedChanged += new System.EventHandler(this.optAll_CheckedChanged);
            // 
            // optVRMA
            // 
            this.optVRMA.AutoSize = true;
            this.optVRMA.Location = new System.Drawing.Point(13, 139);
            this.optVRMA.Name = "optVRMA";
            this.optVRMA.Size = new System.Drawing.Size(91, 17);
            this.optVRMA.TabIndex = 6;
            this.optVRMA.Text = "Vendor RMAs";
            this.optVRMA.UseVisualStyleBackColor = true;
            this.optVRMA.CheckedChanged += new System.EventHandler(this.optAll_CheckedChanged);
            // 
            // optRMAs
            // 
            this.optRMAs.AutoSize = true;
            this.optRMAs.Location = new System.Drawing.Point(13, 121);
            this.optRMAs.Name = "optRMAs";
            this.optRMAs.Size = new System.Drawing.Size(54, 17);
            this.optRMAs.TabIndex = 5;
            this.optRMAs.Text = "RMAs";
            this.optRMAs.UseVisualStyleBackColor = true;
            this.optRMAs.CheckedChanged += new System.EventHandler(this.optAll_CheckedChanged);
            // 
            // optInvoices
            // 
            this.optInvoices.AutoSize = true;
            this.optInvoices.Location = new System.Drawing.Point(13, 103);
            this.optInvoices.Name = "optInvoices";
            this.optInvoices.Size = new System.Drawing.Size(65, 17);
            this.optInvoices.TabIndex = 4;
            this.optInvoices.Text = "Invoices";
            this.optInvoices.UseVisualStyleBackColor = true;
            this.optInvoices.CheckedChanged += new System.EventHandler(this.optAll_CheckedChanged);
            // 
            // optPurchase
            // 
            this.optPurchase.AutoSize = true;
            this.optPurchase.Location = new System.Drawing.Point(13, 85);
            this.optPurchase.Name = "optPurchase";
            this.optPurchase.Size = new System.Drawing.Size(104, 17);
            this.optPurchase.TabIndex = 3;
            this.optPurchase.Text = "Purchase Orders";
            this.optPurchase.UseVisualStyleBackColor = true;
            this.optPurchase.CheckedChanged += new System.EventHandler(this.optAll_CheckedChanged);
            // 
            // optSales
            // 
            this.optSales.AutoSize = true;
            this.optSales.Location = new System.Drawing.Point(13, 67);
            this.optSales.Name = "optSales";
            this.optSales.Size = new System.Drawing.Size(85, 17);
            this.optSales.TabIndex = 2;
            this.optSales.Text = "Sales Orders";
            this.optSales.UseVisualStyleBackColor = true;
            this.optSales.CheckedChanged += new System.EventHandler(this.optAll_CheckedChanged);
            // 
            // optQuote
            // 
            this.optQuote.AutoSize = true;
            this.optQuote.Location = new System.Drawing.Point(13, 49);
            this.optQuote.Name = "optQuote";
            this.optQuote.Size = new System.Drawing.Size(93, 17);
            this.optQuote.TabIndex = 1;
            this.optQuote.Text = "Formal Quotes";
            this.optQuote.UseVisualStyleBackColor = true;
            this.optQuote.CheckedChanged += new System.EventHandler(this.optAll_CheckedChanged);
            // 
            // optAll
            // 
            this.optAll.AutoSize = true;
            this.optAll.Checked = true;
            this.optAll.Location = new System.Drawing.Point(13, 21);
            this.optAll.Name = "optAll";
            this.optAll.Size = new System.Drawing.Size(68, 17);
            this.optAll.TabIndex = 0;
            this.optAll.TabStop = true;
            this.optAll.Text = "All Types";
            this.optAll.UseVisualStyleBackColor = true;
            this.optAll.CheckedChanged += new System.EventHandler(this.optAll_CheckedChanged);
            // 
            // pageNotes
            // 
            this.pageNotes.Controls.Add(this.optUserNotes);
            this.pageNotes.Controls.Add(this.optStandard);
            this.pageNotes.Controls.Add(this.lvNotes);
            this.pageNotes.Location = new System.Drawing.Point(4, 22);
            this.pageNotes.Name = "pageNotes";
            this.pageNotes.Padding = new System.Windows.Forms.Padding(3);
            this.pageNotes.Size = new System.Drawing.Size(748, 262);
            this.pageNotes.TabIndex = 8;
            this.pageNotes.Text = "Notes";
            this.pageNotes.UseVisualStyleBackColor = true;
            // 
            // optUserNotes
            // 
            this.optUserNotes.AutoSize = true;
            this.optUserNotes.Location = new System.Drawing.Point(127, 3);
            this.optUserNotes.Name = "optUserNotes";
            this.optUserNotes.Size = new System.Drawing.Size(253, 17);
            this.optUserNotes.TabIndex = 2;
            this.optUserNotes.Text = "User Notes / Reminders [linked to this company]";
            this.optUserNotes.UseVisualStyleBackColor = true;
            this.optUserNotes.CheckedChanged += new System.EventHandler(this.optUserNotes_CheckedChanged);
            // 
            // optStandard
            // 
            this.optStandard.AutoSize = true;
            this.optStandard.Checked = true;
            this.optStandard.Location = new System.Drawing.Point(5, 3);
            this.optStandard.Name = "optStandard";
            this.optStandard.Size = new System.Drawing.Size(100, 17);
            this.optStandard.TabIndex = 1;
            this.optStandard.TabStop = true;
            this.optStandard.Text = "Company Notes";
            this.optStandard.UseVisualStyleBackColor = true;
            this.optStandard.CheckedChanged += new System.EventHandler(this.optUserNotes_CheckedChanged);
            // 
            // lvNotes
            // 
            this.lvNotes.AddCaption = "Add New Note";
            this.lvNotes.AllowActions = true;
            this.lvNotes.AllowAdd = true;
            this.lvNotes.AllowDelete = true;
            this.lvNotes.AllowDeleteAlways = false;
            this.lvNotes.AllowDrop = true;
            this.lvNotes.AllowOnlyOpenDelete = false;
            this.lvNotes.AlternateConnection = null;
            this.lvNotes.BackColor = System.Drawing.Color.White;
            this.lvNotes.Caption = "";
            this.lvNotes.CurrentTemplate = null;
            this.lvNotes.ExtraClassInfo = "";
            this.lvNotes.Location = new System.Drawing.Point(3, 25);
            this.lvNotes.MultiSelect = true;
            this.lvNotes.Name = "lvNotes";
            this.lvNotes.Size = new System.Drawing.Size(742, 250);
            this.lvNotes.SuppressSelectionChanged = false;
            this.lvNotes.TabIndex = 0;
            this.lvNotes.zz_OpenColumnMenu = false;
            this.lvNotes.zz_OrderLineType = "";
            this.lvNotes.zz_ShowAutoRefresh = true;
            this.lvNotes.zz_ShowUnlimited = true;
            this.lvNotes.AboutToAdd += new NewMethod.AddHandler(this.lvNotes_AboutToAdd);
            // 
            // tabPortalSearches
            // 
            this.tabPortalSearches.Controls.Add(this.lvPortalSearches);
            this.tabPortalSearches.Location = new System.Drawing.Point(4, 22);
            this.tabPortalSearches.Name = "tabPortalSearches";
            this.tabPortalSearches.Size = new System.Drawing.Size(748, 262);
            this.tabPortalSearches.TabIndex = 15;
            this.tabPortalSearches.Text = "Portal Searches";
            this.tabPortalSearches.UseVisualStyleBackColor = true;
            // 
            // lvPortalSearches
            // 
            this.lvPortalSearches.AddCaption = "Add New";
            this.lvPortalSearches.AllowActions = true;
            this.lvPortalSearches.AllowAdd = false;
            this.lvPortalSearches.AllowDelete = true;
            this.lvPortalSearches.AllowDeleteAlways = false;
            this.lvPortalSearches.AllowDrop = true;
            this.lvPortalSearches.AllowOnlyOpenDelete = false;
            this.lvPortalSearches.AlternateConnection = null;
            this.lvPortalSearches.BackColor = System.Drawing.Color.White;
            this.lvPortalSearches.Caption = "";
            this.lvPortalSearches.CurrentTemplate = null;
            this.lvPortalSearches.ExtraClassInfo = "";
            this.lvPortalSearches.Location = new System.Drawing.Point(307, 14);
            this.lvPortalSearches.MultiSelect = true;
            this.lvPortalSearches.Name = "lvPortalSearches";
            this.lvPortalSearches.Size = new System.Drawing.Size(423, 245);
            this.lvPortalSearches.SuppressSelectionChanged = false;
            this.lvPortalSearches.TabIndex = 2;
            this.lvPortalSearches.zz_OpenColumnMenu = false;
            this.lvPortalSearches.zz_OrderLineType = "";
            this.lvPortalSearches.zz_ShowAutoRefresh = true;
            this.lvPortalSearches.zz_ShowUnlimited = true;
            // 
            // tabCalls
            // 
            this.tabCalls.Controls.Add(this.lvCalls);
            this.tabCalls.Location = new System.Drawing.Point(4, 22);
            this.tabCalls.Name = "tabCalls";
            this.tabCalls.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalls.Size = new System.Drawing.Size(748, 262);
            this.tabCalls.TabIndex = 9;
            this.tabCalls.Text = "Calls";
            this.tabCalls.UseVisualStyleBackColor = true;
            // 
            // lvCalls
            // 
            this.lvCalls.AddCaption = "Add New Call";
            this.lvCalls.AllowActions = true;
            this.lvCalls.AllowAdd = true;
            this.lvCalls.AllowDelete = true;
            this.lvCalls.AllowDeleteAlways = false;
            this.lvCalls.AllowDrop = true;
            this.lvCalls.AllowOnlyOpenDelete = false;
            this.lvCalls.AlternateConnection = null;
            this.lvCalls.BackColor = System.Drawing.Color.White;
            this.lvCalls.Caption = "";
            this.lvCalls.CurrentTemplate = null;
            this.lvCalls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCalls.ExtraClassInfo = "";
            this.lvCalls.Location = new System.Drawing.Point(3, 3);
            this.lvCalls.MultiSelect = true;
            this.lvCalls.Name = "lvCalls";
            this.lvCalls.Size = new System.Drawing.Size(742, 256);
            this.lvCalls.SuppressSelectionChanged = false;
            this.lvCalls.TabIndex = 1;
            this.lvCalls.zz_OpenColumnMenu = false;
            this.lvCalls.zz_OrderLineType = "";
            this.lvCalls.zz_ShowAutoRefresh = true;
            this.lvCalls.zz_ShowUnlimited = true;
            this.lvCalls.AboutToAdd += new NewMethod.AddHandler(this.lvCalls_AboutToAdd);
            // 
            // tabExcess
            // 
            this.tabExcess.Controls.Add(this.gbExcessOptions);
            this.tabExcess.Controls.Add(this.lvExcess);
            this.tabExcess.Location = new System.Drawing.Point(4, 22);
            this.tabExcess.Name = "tabExcess";
            this.tabExcess.Size = new System.Drawing.Size(748, 262);
            this.tabExcess.TabIndex = 10;
            this.tabExcess.Text = "Excess";
            this.tabExcess.UseVisualStyleBackColor = true;
            // 
            // gbExcessOptions
            // 
            this.gbExcessOptions.Controls.Add(this.optOffers);
            this.gbExcessOptions.Controls.Add(this.optArchivedExcess);
            this.gbExcessOptions.Controls.Add(this.optExcess);
            this.gbExcessOptions.Location = new System.Drawing.Point(7, 6);
            this.gbExcessOptions.Name = "gbExcessOptions";
            this.gbExcessOptions.Size = new System.Drawing.Size(727, 27);
            this.gbExcessOptions.TabIndex = 7;
            this.gbExcessOptions.TabStop = false;
            this.gbExcessOptions.Text = "Options";
            // 
            // optOffers
            // 
            this.optOffers.AutoSize = true;
            this.optOffers.Location = new System.Drawing.Point(197, 10);
            this.optOffers.Name = "optOffers";
            this.optOffers.Size = new System.Drawing.Size(53, 17);
            this.optOffers.TabIndex = 3;
            this.optOffers.Text = "Offers";
            this.optOffers.UseVisualStyleBackColor = true;
            this.optOffers.Visible = false;
            // 
            // optArchivedExcess
            // 
            this.optArchivedExcess.AutoSize = true;
            this.optArchivedExcess.Location = new System.Drawing.Point(87, 10);
            this.optArchivedExcess.Name = "optArchivedExcess";
            this.optArchivedExcess.Size = new System.Drawing.Size(104, 17);
            this.optArchivedExcess.TabIndex = 2;
            this.optArchivedExcess.Text = "Archived Excess";
            this.optArchivedExcess.UseVisualStyleBackColor = true;
            // 
            // optExcess
            // 
            this.optExcess.AutoSize = true;
            this.optExcess.Checked = true;
            this.optExcess.Location = new System.Drawing.Point(22, 10);
            this.optExcess.Name = "optExcess";
            this.optExcess.Size = new System.Drawing.Size(59, 17);
            this.optExcess.TabIndex = 1;
            this.optExcess.TabStop = true;
            this.optExcess.Text = "Excess";
            this.optExcess.UseVisualStyleBackColor = true;
            // 
            // lvExcess
            // 
            this.lvExcess.AddCaption = "Add A New Bid";
            this.lvExcess.AllowActions = true;
            this.lvExcess.AllowAdd = false;
            this.lvExcess.AllowDelete = true;
            this.lvExcess.AllowDeleteAlways = false;
            this.lvExcess.AllowDrop = true;
            this.lvExcess.AllowOnlyOpenDelete = false;
            this.lvExcess.AlternateConnection = null;
            this.lvExcess.BackColor = System.Drawing.Color.White;
            this.lvExcess.Caption = "";
            this.lvExcess.CurrentTemplate = null;
            this.lvExcess.ExtraClassInfo = "";
            this.lvExcess.Location = new System.Drawing.Point(7, 39);
            this.lvExcess.MultiSelect = true;
            this.lvExcess.Name = "lvExcess";
            this.lvExcess.Size = new System.Drawing.Size(727, 222);
            this.lvExcess.SuppressSelectionChanged = false;
            this.lvExcess.TabIndex = 6;
            this.lvExcess.zz_OpenColumnMenu = false;
            this.lvExcess.zz_OrderLineType = "";
            this.lvExcess.zz_ShowAutoRefresh = true;
            this.lvExcess.zz_ShowUnlimited = true;
            // 
            // tabFeedback
            // 
            this.tabFeedback.Controls.Add(this.lvFeedback);
            this.tabFeedback.Location = new System.Drawing.Point(4, 22);
            this.tabFeedback.Name = "tabFeedback";
            this.tabFeedback.Size = new System.Drawing.Size(748, 262);
            this.tabFeedback.TabIndex = 11;
            this.tabFeedback.Text = "Feedback";
            this.tabFeedback.UseVisualStyleBackColor = true;
            // 
            // lvFeedback
            // 
            this.lvFeedback.AddCaption = "Add New Feedback";
            this.lvFeedback.AllowActions = true;
            this.lvFeedback.AllowAdd = true;
            this.lvFeedback.AllowDelete = true;
            this.lvFeedback.AllowDeleteAlways = false;
            this.lvFeedback.AllowDrop = true;
            this.lvFeedback.AllowOnlyOpenDelete = false;
            this.lvFeedback.AlternateConnection = null;
            this.lvFeedback.BackColor = System.Drawing.Color.White;
            this.lvFeedback.Caption = "";
            this.lvFeedback.CurrentTemplate = null;
            this.lvFeedback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFeedback.ExtraClassInfo = "";
            this.lvFeedback.Location = new System.Drawing.Point(0, 0);
            this.lvFeedback.MultiSelect = true;
            this.lvFeedback.Name = "lvFeedback";
            this.lvFeedback.Size = new System.Drawing.Size(748, 262);
            this.lvFeedback.SuppressSelectionChanged = false;
            this.lvFeedback.TabIndex = 0;
            this.lvFeedback.zz_OpenColumnMenu = false;
            this.lvFeedback.zz_OrderLineType = "";
            this.lvFeedback.zz_ShowAutoRefresh = true;
            this.lvFeedback.zz_ShowUnlimited = true;
            this.lvFeedback.AboutToThrow += new Core.ShowHandler(this.lvFeedback_AboutToThrow);
            this.lvFeedback.AboutToAdd += new NewMethod.AddHandler(this.lvFeedback_AboutToAdd);
            // 
            // tabCompanyCredits
            // 
            this.tabCompanyCredits.Controls.Add(this.nListVendorCredits);
            this.tabCompanyCredits.Location = new System.Drawing.Point(4, 22);
            this.tabCompanyCredits.Name = "tabCompanyCredits";
            this.tabCompanyCredits.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompanyCredits.Size = new System.Drawing.Size(748, 262);
            this.tabCompanyCredits.TabIndex = 13;
            this.tabCompanyCredits.Text = "Company Credits";
            this.tabCompanyCredits.UseVisualStyleBackColor = true;
            // 
            // nListVendorCredits
            // 
            this.nListVendorCredits.AddCaption = "Add New";
            this.nListVendorCredits.AllowActions = true;
            this.nListVendorCredits.AllowAdd = false;
            this.nListVendorCredits.AllowDelete = true;
            this.nListVendorCredits.AllowDeleteAlways = false;
            this.nListVendorCredits.AllowDrop = true;
            this.nListVendorCredits.AllowOnlyOpenDelete = false;
            this.nListVendorCredits.AlternateConnection = null;
            this.nListVendorCredits.BackColor = System.Drawing.Color.White;
            this.nListVendorCredits.Caption = "";
            this.nListVendorCredits.CurrentTemplate = null;
            this.nListVendorCredits.ExtraClassInfo = "";
            this.nListVendorCredits.Location = new System.Drawing.Point(3, 0);
            this.nListVendorCredits.MultiSelect = true;
            this.nListVendorCredits.Name = "nListVendorCredits";
            this.nListVendorCredits.Size = new System.Drawing.Size(727, 249);
            this.nListVendorCredits.SuppressSelectionChanged = false;
            this.nListVendorCredits.TabIndex = 1;
            this.nListVendorCredits.zz_OpenColumnMenu = false;
            this.nListVendorCredits.zz_OrderLineType = "";
            this.nListVendorCredits.zz_ShowAutoRefresh = true;
            this.nListVendorCredits.zz_ShowUnlimited = true;
            // 
            // tabGenie
            // 
            this.tabGenie.Controls.Add(this.wb_Genie);
            this.tabGenie.Location = new System.Drawing.Point(4, 22);
            this.tabGenie.Name = "tabGenie";
            this.tabGenie.Size = new System.Drawing.Size(748, 262);
            this.tabGenie.TabIndex = 12;
            this.tabGenie.Text = "Sales Genie";
            this.tabGenie.UseVisualStyleBackColor = true;
            // 
            // wb_Genie
            // 
            this.wb_Genie.BackColor = System.Drawing.Color.White;
            this.wb_Genie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb_Genie.Location = new System.Drawing.Point(0, 0);
            this.wb_Genie.Name = "wb_Genie";
            this.wb_Genie.ShowControls = false;
            this.wb_Genie.Silent = false;
            this.wb_Genie.Size = new System.Drawing.Size(748, 262);
            this.wb_Genie.TabIndex = 1;
            // 
            // tabConsignCodes
            // 
            this.tabConsignCodes.Controls.Add(this.consignmentCodes);
            this.tabConsignCodes.Location = new System.Drawing.Point(4, 22);
            this.tabConsignCodes.Name = "tabConsignCodes";
            this.tabConsignCodes.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsignCodes.Size = new System.Drawing.Size(748, 262);
            this.tabConsignCodes.TabIndex = 14;
            this.tabConsignCodes.Text = "Consignment Codes";
            this.tabConsignCodes.UseVisualStyleBackColor = true;
            // 
            // consignmentCodes
            // 
            this.consignmentCodes.BackColor = System.Drawing.Color.White;
            this.consignmentCodes.Location = new System.Drawing.Point(0, 0);
            this.consignmentCodes.Name = "consignmentCodes";
            this.consignmentCodes.Size = new System.Drawing.Size(730, 278);
            this.consignmentCodes.TabIndex = 0;
            // 
            // gbVet
            // 
            this.gbVet.Controls.Add(this.lblVetDate);
            this.gbVet.Controls.Add(this.lblVettedBy);
            this.gbVet.Controls.Add(this.cbx_is_vetted);
            this.gbVet.Location = new System.Drawing.Point(636, 185);
            this.gbVet.Name = "gbVet";
            this.gbVet.Size = new System.Drawing.Size(200, 67);
            this.gbVet.TabIndex = 42;
            this.gbVet.TabStop = false;
            this.gbVet.Text = "Supplier Vetting";
            // 
            // lblVetDate
            // 
            this.lblVetDate.AutoSize = true;
            this.lblVetDate.Location = new System.Drawing.Point(6, 48);
            this.lblVetDate.Name = "lblVetDate";
            this.lblVetDate.Size = new System.Drawing.Size(52, 13);
            this.lblVetDate.TabIndex = 43;
            this.lblVetDate.Text = "Vet Date:";
            // 
            // lblVettedBy
            // 
            this.lblVettedBy.AutoSize = true;
            this.lblVettedBy.Location = new System.Drawing.Point(6, 32);
            this.lblVettedBy.Name = "lblVettedBy";
            this.lblVettedBy.Size = new System.Drawing.Size(56, 13);
            this.lblVettedBy.TabIndex = 42;
            this.lblVettedBy.Text = "Vetted By:";
            // 
            // cbx_is_vetted
            // 
            this.cbx_is_vetted.BackColor = System.Drawing.Color.Transparent;
            this.cbx_is_vetted.Bold = false;
            this.cbx_is_vetted.Caption = "Is Vetted";
            this.cbx_is_vetted.Changed = false;
            this.cbx_is_vetted.Location = new System.Drawing.Point(4, 11);
            this.cbx_is_vetted.Name = "cbx_is_vetted";
            this.cbx_is_vetted.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbx_is_vetted.Size = new System.Drawing.Size(77, 18);
            this.cbx_is_vetted.TabIndex = 41;
            this.cbx_is_vetted.UseParentBackColor = false;
            this.cbx_is_vetted.zz_CheckValue = false;
            this.cbx_is_vetted.zz_LabelColor = System.Drawing.Color.Black;
            this.cbx_is_vetted.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_is_vetted.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.cbx_is_vetted.zz_OriginalDesign = false;
            this.cbx_is_vetted.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_industry_segment
            // 
            this.ctl_industry_segment.AllCaps = false;
            this.ctl_industry_segment.AllowEdit = true;
            this.ctl_industry_segment.BackColor = System.Drawing.Color.Transparent;
            this.ctl_industry_segment.Bold = false;
            this.ctl_industry_segment.Caption = "Industry Segment";
            this.ctl_industry_segment.Changed = false;
            this.ctl_industry_segment.ListName = "industry_segment";
            this.ctl_industry_segment.Location = new System.Drawing.Point(636, 130);
            this.ctl_industry_segment.Name = "ctl_industry_segment";
            this.ctl_industry_segment.SimpleList = null;
            this.ctl_industry_segment.Size = new System.Drawing.Size(234, 50);
            this.ctl_industry_segment.TabIndex = 43;
            this.ctl_industry_segment.UseParentBackColor = true;
            this.ctl_industry_segment.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctl_industry_segment.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_industry_segment.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_industry_segment.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_industry_segment.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_industry_segment.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_industry_segment.zz_OriginalDesign = false;
            this.ctl_industry_segment.zz_ShowNeedsSaveColor = true;
            this.ctl_industry_segment.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_industry_segment.zz_TextFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_industry_segment.zz_UseGlobalColor = false;
            this.ctl_industry_segment.zz_UseGlobalFont = false;
            // 
            // ctl_has_financials
            // 
            this.ctl_has_financials.BackColor = System.Drawing.Color.Transparent;
            this.ctl_has_financials.Bold = false;
            this.ctl_has_financials.Caption = "Has Financials Verified";
            this.ctl_has_financials.Changed = false;
            this.ctl_has_financials.Location = new System.Drawing.Point(636, 258);
            this.ctl_has_financials.Name = "ctl_has_financials";
            this.ctl_has_financials.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ctl_has_financials.Size = new System.Drawing.Size(188, 18);
            this.ctl_has_financials.TabIndex = 44;
            this.ctl_has_financials.UseParentBackColor = false;
            this.ctl_has_financials.zz_CheckValue = false;
            this.ctl_has_financials.zz_LabelColor = System.Drawing.Color.Black;
            this.ctl_has_financials.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_has_financials.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_has_financials.zz_OriginalDesign = false;
            this.ctl_has_financials.zz_ShowNeedsSaveColor = true;
            // 
            // FeedbackControl
            // 
            this.FeedbackControl.BackColor = System.Drawing.Color.White;
            this.FeedbackControl.Location = new System.Drawing.Point(636, 3);
            this.FeedbackControl.Name = "FeedbackControl";
            this.FeedbackControl.Size = new System.Drawing.Size(180, 130);
            this.FeedbackControl.TabIndex = 33;
            // 
            // view_company
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctl_has_financials);
            this.Controls.Add(this.ctl_industry_segment);
            this.Controls.Add(this.gbVet);
            this.Controls.Add(this.FeedbackControl);
            this.Controls.Add(this.ts);
            this.Controls.Add(this.tsl);
            this.Name = "view_company";
            this.Size = new System.Drawing.Size(892, 615);
            this.Controls.SetChildIndex(this.tsl, 0);
            this.Controls.SetChildIndex(this.ts, 0);
            this.Controls.SetChildIndex(this.FeedbackControl, 0);
            this.Controls.SetChildIndex(this.gbVet, 0);
            this.Controls.SetChildIndex(this.ctl_industry_segment, 0);
            this.Controls.SetChildIndex(this.ctl_has_financials, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.ts.ResumeLayout(false);
            this.tabCompany.ResumeLayout(false);
            this.tabCompany.PerformLayout();
            this.tabCommission.ResumeLayout(false);
            this.tabMore.ResumeLayout(false);
            this.tabMore.PerformLayout();
            this.tabTerms.ResumeLayout(false);
            this.gbVendor.ResumeLayout(false);
            this.gbCustomer.ResumeLayout(false);
            this.tabDescription.ResumeLayout(false);
            this.tabDescription.PerformLayout();
            this.gbCompanyTermsConditions.ResumeLayout(false);
            this.gbCompanyTermsConditions.PerformLayout();
            this.tabAttachments.ResumeLayout(false);
            this.tabQB.ResumeLayout(false);
            this.tabArchive.ResumeLayout(false);
            this.gbAutoArchive.ResumeLayout(false);
            this.gbAutoArchive.PerformLayout();
            this.gbArchiveDeleteSettings.ResumeLayout(false);
            this.gbArchiveDeleteSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDeleteArchivePeriod)).EndInit();
            this.gbArchiveSettings.ResumeLayout(false);
            this.gbArchiveSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udArchivePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBroomClock)).EndInit();
            this.tabECommerce.ResumeLayout(false);
            this.tabCallSchedule.ResumeLayout(false);
            this.tabCallSchedule.PerformLayout();
            this.tabCreditCard.ResumeLayout(false);
            this.tabCreditCard.PerformLayout();
            this.pagePOInfo.ResumeLayout(false);
            this.pagePOInfo.PerformLayout();
            this.tabProducts.ResumeLayout(false);
            this.tabProducts.PerformLayout();
            this.tsl.ResumeLayout(false);
            this.pageContacts.ResumeLayout(false);
            this.pageAddresses.ResumeLayout(false);
            this.tabAccounts.ResumeLayout(false);
            this.pageReqs.ResumeLayout(false);
            this.pageBatches.ResumeLayout(false);
            this.tabQuotes.ResumeLayout(false);
            this.panelAtometronQuote.ResumeLayout(false);
            this.gbQuoteOptions.ResumeLayout(false);
            this.gbQuoteOptions.PerformLayout();
            this.pageBids.ResumeLayout(false);
            this.gbBid.ResumeLayout(false);
            this.gbBid.PerformLayout();
            this.tabOrders.ResumeLayout(false);
            this.gbSource.ResumeLayout(false);
            this.gbSource.PerformLayout();
            this.gbOrderOptions.ResumeLayout(false);
            this.gbOrderOptions.PerformLayout();
            this.pageNotes.ResumeLayout(false);
            this.pageNotes.PerformLayout();
            this.tabPortalSearches.ResumeLayout(false);
            this.tabCalls.ResumeLayout(false);
            this.tabExcess.ResumeLayout(false);
            this.gbExcessOptions.ResumeLayout(false);
            this.gbExcessOptions.PerformLayout();
            this.tabFeedback.ResumeLayout(false);
            this.tabCompanyCredits.ResumeLayout(false);
            this.tabGenie.ResumeLayout(false);
            this.tabConsignCodes.ResumeLayout(false);
            this.gbVet.ResumeLayout(false);
            this.gbVet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private nEdit_String ctl_companyname;
        private nEdit_User user;
        private nEdit_List ctl_wherefoundcompany;
        private nEdit_List ctl_companytype;
        private nEdit_String ctl_primaryemailaddress;
        private nEdit_String ctl_primaryfax;
        private nEdit_String ctl_primaryphone;
        private CompanyTypeStub cType;
        private System.Windows.Forms.Button cmdChangeCompany;
        private nEdit_String ctl_creditcardnumber;
        private nEdit_Memo ctl_qb_shipping;
        private nEdit_Memo ctl_qb_billing;
        private nEdit_String ctl_qb_terms_v;
        private nEdit_String ctl_qb_terms;
        private nEdit_String ctl_qb_name;
        private System.Windows.Forms.TabPage pageContacts;
        private nList result_contacts;
        private System.Windows.Forms.TabPage pageAddresses;
        private System.Windows.Forms.TabPage tabAccounts;
        private System.Windows.Forms.TabPage pageReqs;
        private System.Windows.Forms.TabPage pageBatches;
        private System.Windows.Forms.TabPage tabQuotes;
        private System.Windows.Forms.TabPage pageBids;
        private nList result_addresses;
        private nList result_accounts;
        private nList result_reqs;
        private nList result_reqbatches;
        private nList result_bids;
        private System.Windows.Forms.TabPage tabOrders;
        private System.Windows.Forms.GroupBox gbOrderOptions;
        private System.Windows.Forms.RadioButton optVRMA;
        private System.Windows.Forms.RadioButton optRMAs;
        private System.Windows.Forms.RadioButton optInvoices;
        private System.Windows.Forms.RadioButton optPurchase;
        private System.Windows.Forms.RadioButton optSales;
        private System.Windows.Forms.RadioButton optQuote;
        private System.Windows.Forms.RadioButton optAll;
        private nList result_orders;
        private nList result_fquotes;
        private nList result_qquotes;
        protected System.Windows.Forms.Button cmdForward;
        protected System.Windows.Forms.Button cmdBack;
        protected System.Windows.Forms.Label lblScroll;
        private System.Windows.Forms.GroupBox gbAutoArchive;
        private System.Windows.Forms.RadioButton optArchive;
        private System.Windows.Forms.RadioButton optNoArchive;
        private System.Windows.Forms.GroupBox gbArchiveSettings;
        private System.Windows.Forms.RadioButton optToDelete;
        private System.Windows.Forms.RadioButton optToArchive;
        private System.Windows.Forms.ComboBox cboTimespan;
        private System.Windows.Forms.NumericUpDown udArchivePeriod;
        private System.Windows.Forms.Label lblCleanOut;
        private System.Windows.Forms.PictureBox picBroomClock;
        private System.Windows.Forms.TabPage pageNotes;
        private nList lvNotes;
        private System.Windows.Forms.GroupBox gbBid;
        private System.Windows.Forms.RadioButton optRelatedBids;
        private System.Windows.Forms.RadioButton optActualBids;
        protected nEdit_Boolean ctl_needs_contact;
        private System.Windows.Forms.TabPage tabCalls;
        private nList lvCalls;
        //private ReqBidStatus custvendStatus;
        private System.Windows.Forms.Label label1;
        private nEdit_Number ctl_star_rating;
        private System.Windows.Forms.TabPage tabExcess;
        private System.Windows.Forms.GroupBox gbExcessOptions;
        private System.Windows.Forms.RadioButton optArchivedExcess;
        private System.Windows.Forms.RadioButton optExcess;
        private nList lvExcess;
        private System.Windows.Forms.TabPage tabFeedback;
        private nList lvFeedback;
        private nEdit_String ctl_websitemoniker;
        private nEdit_String ctl_logopath;
        private nEdit_Memo ctl_websitegreeting;
        private nEdit_Memo ctl_websiteresponse;
        private System.Windows.Forms.RadioButton optUserNotes;
        private System.Windows.Forms.RadioButton optStandard;
        private System.Windows.Forms.Panel panelAtometronQuote;
        private System.Windows.Forms.GroupBox gbQuoteOptions;
        private System.Windows.Forms.RadioButton optFormalQuotes;
        private System.Windows.Forms.RadioButton optQuickQuotes;
        private nList lvQuotes;
        private System.Windows.Forms.CheckBox chkCallSaturday;
        private System.Windows.Forms.CheckBox chkCallFriday;
        private System.Windows.Forms.CheckBox chkCallThursday;
        private System.Windows.Forms.CheckBox chkCallWednesday;
        private System.Windows.Forms.CheckBox chkCallTuesday;
        private System.Windows.Forms.CheckBox chkCallMonday;
        private System.Windows.Forms.CheckBox chkCallSunday;
        private nEdit_Boolean ctl_donotemail;
        private System.Windows.Forms.TabPage tabGenie;
        private System.Windows.Forms.RadioButton optOffers;
        private nEdit_String ctl_nameoncard;
        private nEdit_List ctl_creditcardtype;
        private nEdit_Number ctl_expiration_year;
        private nEdit_Number ctl_expiration_month;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private nEdit_String ctl_cardbillingzip;
        private nEdit_String ctl_cardbillingaddr;
        private System.Windows.Forms.Button cmdSendCreditCardifoToQBs;
        private nEdit_String ctl_securitycode;
        private System.Windows.Forms.GroupBox gbArchiveDeleteSettings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown udDeleteArchivePeriod;
        private System.Windows.Forms.Label label5;
        private nEdit_Boolean ctl_delete_archives;
        private nEdit_String ctl_primaryphoneextension;
        private nEdit_Boolean ctl_is_prospect;
        public System.Windows.Forms.TabControl tsl;
        public Feedback FeedbackControl;
        public System.Windows.Forms.TabPage tabCompany;
        public System.Windows.Forms.TabPage tabMore;
        public System.Windows.Forms.TabPage tabDescription;
        public System.Windows.Forms.TabPage tabQB;
        public System.Windows.Forms.TabPage tabArchive;
        public System.Windows.Forms.TabPage tabECommerce;
        public System.Windows.Forms.TabPage tabCallSchedule;
        public System.Windows.Forms.TabPage tabCreditCard;
        private nEdit_Memo ctl_bank_wire_info;
        protected nEdit_Boolean ctl_isdistributor;
        protected nEdit_Boolean ctl_iscem;
        protected nEdit_Boolean ctl_isoem;
        protected System.Windows.Forms.TabControl ts;
        protected System.Windows.Forms.TabPage tabTerms;
        protected System.Windows.Forms.GroupBox gbVendor;
        private System.Windows.Forms.TabPage pagePOInfo;
        private System.Windows.Forms.LinkLabel lblClear;
        private System.Windows.Forms.LinkLabel lblRemove;
        private System.Windows.Forms.LinkLabel lblNotifyAdd;
        private System.Windows.Forms.Label lblNotify;
        private nEdit_Number ctl_po_min;
        private System.Windows.Forms.Label lblNotifyList;
        protected nEdit_Boolean ctl_isactive;
        protected nEdit_Boolean ctl_c_of_c;
        private System.Windows.Forms.RadioButton optService;
        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.RadioButton optLineItems;
        private System.Windows.Forms.RadioButton optOrders;
        protected nEdit_String ctl_primarycontact;
        //private CurrencySelector ctl_default_currency;
        private ToolsWin.BrowserPlain wb_Genie;
        private System.Windows.Forms.TabPage tabAttachments;
        private PartPictureViewer PPV;
        protected nEdit_Boolean ctl_isverified;
        protected nEdit_Boolean ctl_donotrfq;
        protected nEdit_Boolean ctl_isinternational;
        protected nEdit_String ctl_country;
        protected nEdit_String ctl_alias1;
        protected nEdit_Number ctl_pricelevel;
        protected nEdit_String ctl_taxid;
        protected nEdit_Number ctl_companyrating;
        protected nEdit_Number ctl_companynumber;
        protected nEdit_String ctl_vendoraccountnumber;
        protected nEdit_String ctl_internalcompanyname;
        protected nEdit_String ctl_lastcontactdate;
        protected nEdit_String ctl_rfqemail;
        protected nEdit_String ctl_zipcode;
        protected nEdit_String ctl_statename;
        protected nEdit_Number ctl_contactfrequency;
        protected nEdit_Boolean ctl_instockonly;
        protected nEdit_String ctl_companycode;
        protected nEdit_String ctl_internetpassword;
        protected nEdit_String ctl_internetusername;
        protected nEdit_Memo ctl_description;
        private System.Windows.Forms.TabPage tabProducts;
        protected nEdit_Boolean ctl_Products_Display;
        protected nEdit_String ctl_primarywebaddress;
        protected nEdit_Boolean ctl_Products_SSD;
        protected nEdit_Boolean ctl_Products_Cabling;
        protected nEdit_Boolean ctl_Products_Interconnect;
        protected nEdit_Boolean ctl_Products_CrystalOsc;
        protected nEdit_Boolean ctl_Products_Relay;
        private System.Windows.Forms.RadioButton optViewVend;
        private System.Windows.Forms.RadioButton optViewCust;
        private System.Windows.Forms.Label lbl_Products;
        protected nEdit_Boolean ctl_Products_OpticalTransceiver;
        protected nEdit_Boolean ctl_Products_PowerSupply;
        protected nEdit_Boolean ctl_Products_Components;
        protected nEdit_Boolean ctl_SOA_services;
        protected nEdit_Boolean ctl_SOA_components;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabCompanyCredits;
        private nList nListVendorCredits;
        private System.Windows.Forms.GroupBox gbVet;
        private System.Windows.Forms.Label lblVetDate;
        private System.Windows.Forms.Label lblVettedBy;
        private nEdit_Boolean cbx_is_vetted;
        private nEdit_List ctl_industry_segment;
        private nEdit_Boolean ctl_has_financials;
        private nEdit_List ctl_timezone;
        private System.Windows.Forms.TabPage tabConsignCodes;
        private RzSensible.ConsignmentCodes consignmentCodes;
        protected nEdit_Boolean ctl_GCAT_required;
        private System.Windows.Forms.Label lblProblemCustomer;
        private nEdit_Memo ctl_vendorTermsMemo;
        private nEdit_Memo ctl_cc_warning;
        private nEdit_List ctl_shipviavendor;
        private nEdit_List ctl_termsasvendor;
        private nEdit_Number ctl_pastduelimitasvendor;
        private nEdit_Money ctl_creditasvendor;
        private nEdit_Money ctl_handling_charge;
        private nEdit_Money ctl_cc_charge;
        protected System.Windows.Forms.GroupBox gbCustomer;
        private nEdit_Memo ctl_customerTermsMemo;
        private nEdit_List ctl_shipviacustomer;
        private nEdit_List ctl_termsascustomer;
        private nEdit_Number ctl_pastduelimitascustomer;
        private nEdit_Money ctl_creditascustomer;
        private nEdit_Boolean ctl_is_problem;
        private nEdit_Boolean ctl_problem_vendor;
        private System.Windows.Forms.Label lblOutstandingInvoiceAmnt;
        private System.Windows.Forms.TabPage tabPortalSearches;
        private nList lvPortalSearches;
        private System.Windows.Forms.GroupBox gbCompanyTermsConditions;
        private System.Windows.Forms.CheckBox ctl_testing_restriction;
        private System.Windows.Forms.CheckBox ctl_coo_restriction;
        private System.Windows.Forms.CheckBox ctl_broker_restriction;
        private System.Windows.Forms.CheckBox ctl_rohs_restriction;
        private System.Windows.Forms.CheckBox ctl_packaging_requirements;
        private System.Windows.Forms.CheckBox ctl_date_code_restriction;
        private System.Windows.Forms.TextBox ctl_testing_restriction_detail;
        private System.Windows.Forms.TextBox ctl_packaging_requirements_detail;
        private System.Windows.Forms.TextBox ctl_date_code_restriction_detail;
        private System.Windows.Forms.CheckBox ctl_requires_traceability;
        private System.Windows.Forms.Label lblVendorCredits;
        private System.Windows.Forms.Label lblProblemVendor;
        private System.Windows.Forms.Button btnCheckCreditLimit;
        private System.Windows.Forms.TabPage tabCommission;
        private SplitCommission sc1;
        private nEdit_Boolean ctl_islocked_purchase;
        private nEdit_Boolean ctl_is_locked;
    }
}
