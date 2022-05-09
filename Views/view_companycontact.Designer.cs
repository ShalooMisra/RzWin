using NewMethod;

namespace Rz5
{
    partial class view_companycontact
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
            if (disposing)
                CompleteDispose();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(view_companycontact));
            this.ctl_contactname = new NewMethod.nEdit_String();
            this.ctl_donotmail = new NewMethod.nEdit_Boolean();
            this.ctl_donotemail = new NewMethod.nEdit_Boolean();
            this.ctl_donotpromote = new NewMethod.nEdit_Boolean();
            this.ctl_iscustomer = new NewMethod.nEdit_Boolean();
            this.ctl_isvendor = new NewMethod.nEdit_Boolean();
            this.ctl_isactive = new NewMethod.nEdit_Boolean();
            this.ctl_spam_graphic = new NewMethod.nEdit_Boolean();
            this.agent = new NewMethod.nEdit_User();
            this.cmdBad = new System.Windows.Forms.Button();
            this.cmdRelease = new System.Windows.Forms.Button();
            this.cmdClaim = new System.Windows.Forms.Button();
            this.ctl_contactnotes = new NewMethod.nEdit_Memo();
            this.cmdAssign = new System.Windows.Forms.Button();
            this.ctl_donotcall = new NewMethod.nEdit_Boolean();
            this.cmdUnClaim = new System.Windows.Forms.Button();
            this.result_notes = new NewMethod.nList();
            this.pNotes = new System.Windows.Forms.Panel();
            this.cmdFollowUp = new System.Windows.Forms.Button();
            this.cmdSentEmail = new System.Windows.Forms.Button();
            this.cmdSE = new System.Windows.Forms.Button();
            this.cmdBadEmail = new System.Windows.Forms.Button();
            this.cmdWrongNumber = new System.Windows.Forms.Button();
            this.cmdVoiceMail = new System.Windows.Forms.Button();
            this.cmdNoAnswer = new System.Windows.Forms.Button();
            this.lblClearDuplicateNotes = new System.Windows.Forms.LinkLabel();
            this.ctl_personality_type = new NewMethod.nEdit_List();
            this.lbl_interaction = new System.Windows.Forms.Label();
            this.lbl_interact = new System.Windows.Forms.Label();
            this.lbl_expect = new System.Windows.Forms.Label();
            this.lbl_expectation = new System.Windows.Forms.Label();
            this.lbl_trait = new System.Windows.Forms.Label();
            this.lbl_traits = new System.Windows.Forms.Label();
            this.tabAffiliate = new System.Windows.Forms.TabPage();
            this.pageCallLogs = new System.Windows.Forms.TabPage();
            this.pagePhoneNumbers = new System.Windows.Forms.TabPage();
            this.gbPhone = new System.Windows.Forms.GroupBox();
            this.cmdViewPhone = new System.Windows.Forms.Button();
            this.cmdChangePhone = new System.Windows.Forms.Button();
            this.lblWebPhone = new System.Windows.Forms.Label();
            this.lvPhone = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdAddPhone = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.pageFeedback = new System.Windows.Forms.TabPage();
            this.wbFeedback = new ToolsWin.BrowserPlain();
            this.pageOrders = new System.Windows.Forms.TabPage();
            this.gbOrderOptions = new System.Windows.Forms.GroupBox();
            this.optAll = new System.Windows.Forms.RadioButton();
            this.optQuote = new System.Windows.Forms.RadioButton();
            this.optSales = new System.Windows.Forms.RadioButton();
            this.optPurchase = new System.Windows.Forms.RadioButton();
            this.optInvoices = new System.Windows.Forms.RadioButton();
            this.optRMAs = new System.Windows.Forms.RadioButton();
            this.optVRMA = new System.Windows.Forms.RadioButton();
            this.pageBids = new System.Windows.Forms.TabPage();
            this.pageQuotes = new System.Windows.Forms.TabPage();
            this.pageReqs = new System.Windows.Forms.TabPage();
            this.pageCalls = new System.Windows.Forms.TabPage();
            this.wbCalls = new ToolsWin.BrowserPlain();
            this.pageMoreInfo = new System.Windows.Forms.TabPage();
            this.ctl_isdefaultpurchaser = new NewMethod.nEdit_Boolean();
            this.ctl_isdefaultsales = new NewMethod.nEdit_Boolean();
            this.ctl_birthdate = new NewMethod.nEdit_Date();
            this.ctl_contactgender = new NewMethod.nEdit_List();
            this.ctl_maritalstatus = new NewMethod.nEdit_List();
            this.ctl_interests = new NewMethod.nEdit_Memo();
            this.ctl_alternateemail = new NewMethod.nEdit_String();
            this.ctl_group_name = new NewMethod.nEdit_String();
            this.ctl_timezone = new NewMethod.nEdit_List();
            this.ctl_send_company_shipping_email_alert = new NewMethod.nEdit_Boolean();
            this.pageInfo = new System.Windows.Forms.TabPage();
            this.ctl_contacttype = new NewMethod.nEdit_List();
            this.ctl_jobtype = new NewMethod.nEdit_String();
            this.ctl_primaryphone = new NewMethod.nEdit_String();
            this.ctl_primaryphoneextension = new NewMethod.nEdit_String();
            this.ctl_alternatephone = new NewMethod.nEdit_String();
            this.ctl_primaryfax = new NewMethod.nEdit_String();
            this.ctl_alternatefax = new NewMethod.nEdit_String();
            this.ctl_primaryemailaddress = new NewMethod.nEdit_String();
            this.ctl_primarywebaddress = new NewMethod.nEdit_String();
            this.ctl_source = new NewMethod.nEdit_List();
            this.gb = new System.Windows.Forms.GroupBox();
            this.ctl_line1 = new NewMethod.nEdit_String();
            this.ctl_line2 = new NewMethod.nEdit_String();
            this.ctl_line3 = new NewMethod.nEdit_String();
            this.ctl_adrcity = new NewMethod.nEdit_String();
            this.ctl_adrzip = new NewMethod.nEdit_String();
            this.cmdPick = new System.Windows.Forms.Button();
            this.ctl_adrstate = new NewMethod.nEdit_List();
            this.ctl_adrcountry = new NewMethod.nEdit_List();
            this.ctl_companyname = new NewMethod.nEdit_String();
            this.ctl_bad_data = new NewMethod.nEdit_Boolean();
            this.ctl_alternate_names = new NewMethod.nEdit_String();
            this.lblCheckPhone = new System.Windows.Forms.LinkLabel();
            this.lblCheckAlternatePhone = new System.Windows.Forms.LinkLabel();
            this.ts = new System.Windows.Forms.TabControl();
            this.lvCalls = new NewMethod.nList();
            this.result_orders = new NewMethod.nList();
            this.result_bids = new NewMethod.nList();
            this.result_reqs = new NewMethod.nList();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctStub = new Rz5.CompanyTypeStub();
            this.ctl_affiliate_id = new NewMethod.nEdit_String();
            this.ctl_affiliate_name = new NewMethod.nEdit_String();
            this.pNotes.SuspendLayout();
            this.tabAffiliate.SuspendLayout();
            this.pageCallLogs.SuspendLayout();
            this.pagePhoneNumbers.SuspendLayout();
            this.gbPhone.SuspendLayout();
            this.pageFeedback.SuspendLayout();
            this.pageOrders.SuspendLayout();
            this.gbOrderOptions.SuspendLayout();
            this.pageBids.SuspendLayout();
            this.pageReqs.SuspendLayout();
            this.pageCalls.SuspendLayout();
            this.pageMoreInfo.SuspendLayout();
            this.pageInfo.SuspendLayout();
            this.gb.SuspendLayout();
            this.ts.SuspendLayout();
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(899, 0);
            this.xActions.Size = new System.Drawing.Size(148, 765);
            // 
            // ctl_contactname
            // 
            this.ctl_contactname.AllCaps = false;
            this.ctl_contactname.BackColor = System.Drawing.Color.White;
            this.ctl_contactname.Bold = true;
            this.ctl_contactname.Caption = "Contact Name";
            this.ctl_contactname.Changed = false;
            this.ctl_contactname.IsEmail = false;
            this.ctl_contactname.IsURL = false;
            this.ctl_contactname.Location = new System.Drawing.Point(12, 49);
            this.ctl_contactname.Name = "ctl_contactname";
            this.ctl_contactname.PasswordChar = '\0';
            this.ctl_contactname.Size = new System.Drawing.Size(411, 42);
            this.ctl_contactname.TabIndex = 1;
            this.ctl_contactname.UseParentBackColor = true;
            this.ctl_contactname.zz_Enabled = true;
            this.ctl_contactname.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_contactname.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_contactname.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_contactname.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_contactname.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_contactname.zz_OriginalDesign = true;
            this.ctl_contactname.zz_ShowLinkButton = false;
            this.ctl_contactname.zz_ShowNeedsSaveColor = true;
            this.ctl_contactname.zz_Text = "";
            this.ctl_contactname.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_contactname.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_contactname.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_contactname.zz_UseGlobalColor = false;
            this.ctl_contactname.zz_UseGlobalFont = false;
            // 
            // ctl_donotmail
            // 
            this.ctl_donotmail.BackColor = System.Drawing.Color.White;
            this.ctl_donotmail.Bold = false;
            this.ctl_donotmail.Caption = "Do Not Contact Via US Mail";
            this.ctl_donotmail.Changed = false;
            this.ctl_donotmail.ForeColor = System.Drawing.Color.Red;
            this.ctl_donotmail.Location = new System.Drawing.Point(12, 6);
            this.ctl_donotmail.Name = "ctl_donotmail";
            this.ctl_donotmail.Size = new System.Drawing.Size(158, 18);
            this.ctl_donotmail.TabIndex = 7;
            this.ctl_donotmail.UseParentBackColor = true;
            this.ctl_donotmail.zz_CheckValue = false;
            this.ctl_donotmail.zz_LabelColor = System.Drawing.Color.Red;
            this.ctl_donotmail.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_donotmail.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_donotmail.zz_OriginalDesign = false;
            this.ctl_donotmail.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_donotemail
            // 
            this.ctl_donotemail.BackColor = System.Drawing.Color.White;
            this.ctl_donotemail.Bold = false;
            this.ctl_donotemail.Caption = "Do Not Email";
            this.ctl_donotemail.Changed = false;
            this.ctl_donotemail.ForeColor = System.Drawing.Color.Red;
            this.ctl_donotemail.Location = new System.Drawing.Point(12, 27);
            this.ctl_donotemail.Name = "ctl_donotemail";
            this.ctl_donotemail.Size = new System.Drawing.Size(88, 18);
            this.ctl_donotemail.TabIndex = 8;
            this.ctl_donotemail.UseParentBackColor = true;
            this.ctl_donotemail.zz_CheckValue = false;
            this.ctl_donotemail.zz_LabelColor = System.Drawing.Color.Red;
            this.ctl_donotemail.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_donotemail.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_donotemail.zz_OriginalDesign = false;
            this.ctl_donotemail.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_donotpromote
            // 
            this.ctl_donotpromote.BackColor = System.Drawing.Color.White;
            this.ctl_donotpromote.Bold = false;
            this.ctl_donotpromote.Caption = "All Bad Contact Data";
            this.ctl_donotpromote.Changed = false;
            this.ctl_donotpromote.ForeColor = System.Drawing.Color.Red;
            this.ctl_donotpromote.Location = new System.Drawing.Point(180, 5);
            this.ctl_donotpromote.Name = "ctl_donotpromote";
            this.ctl_donotpromote.Size = new System.Drawing.Size(125, 18);
            this.ctl_donotpromote.TabIndex = 9;
            this.ctl_donotpromote.UseParentBackColor = true;
            this.ctl_donotpromote.zz_CheckValue = false;
            this.ctl_donotpromote.zz_LabelColor = System.Drawing.Color.Red;
            this.ctl_donotpromote.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_donotpromote.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_donotpromote.zz_OriginalDesign = false;
            this.ctl_donotpromote.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_iscustomer
            // 
            this.ctl_iscustomer.BackColor = System.Drawing.Color.White;
            this.ctl_iscustomer.Bold = false;
            this.ctl_iscustomer.Caption = "Customer";
            this.ctl_iscustomer.Changed = false;
            this.ctl_iscustomer.Location = new System.Drawing.Point(311, 16);
            this.ctl_iscustomer.Name = "ctl_iscustomer";
            this.ctl_iscustomer.Size = new System.Drawing.Size(70, 18);
            this.ctl_iscustomer.TabIndex = 10;
            this.ctl_iscustomer.UseParentBackColor = true;
            this.ctl_iscustomer.zz_CheckValue = false;
            this.ctl_iscustomer.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_iscustomer.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_iscustomer.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_iscustomer.zz_OriginalDesign = false;
            this.ctl_iscustomer.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_isvendor
            // 
            this.ctl_isvendor.BackColor = System.Drawing.Color.White;
            this.ctl_isvendor.Bold = false;
            this.ctl_isvendor.Caption = "Vendor";
            this.ctl_isvendor.Changed = false;
            this.ctl_isvendor.Location = new System.Drawing.Point(311, 40);
            this.ctl_isvendor.Name = "ctl_isvendor";
            this.ctl_isvendor.Size = new System.Drawing.Size(60, 18);
            this.ctl_isvendor.TabIndex = 11;
            this.ctl_isvendor.UseParentBackColor = true;
            this.ctl_isvendor.zz_CheckValue = false;
            this.ctl_isvendor.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_isvendor.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_isvendor.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_isvendor.zz_OriginalDesign = false;
            this.ctl_isvendor.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_isactive
            // 
            this.ctl_isactive.BackColor = System.Drawing.Color.White;
            this.ctl_isactive.Bold = false;
            this.ctl_isactive.Caption = "Active";
            this.ctl_isactive.Changed = false;
            this.ctl_isactive.Location = new System.Drawing.Point(390, 16);
            this.ctl_isactive.Name = "ctl_isactive";
            this.ctl_isactive.Size = new System.Drawing.Size(56, 18);
            this.ctl_isactive.TabIndex = 12;
            this.ctl_isactive.UseParentBackColor = true;
            this.ctl_isactive.zz_CheckValue = false;
            this.ctl_isactive.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_isactive.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_isactive.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_isactive.zz_OriginalDesign = false;
            this.ctl_isactive.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_spam_graphic
            // 
            this.ctl_spam_graphic.BackColor = System.Drawing.Color.White;
            this.ctl_spam_graphic.Bold = false;
            this.ctl_spam_graphic.Caption = "Buyer";
            this.ctl_spam_graphic.Changed = false;
            this.ctl_spam_graphic.Location = new System.Drawing.Point(390, 38);
            this.ctl_spam_graphic.Name = "ctl_spam_graphic";
            this.ctl_spam_graphic.Size = new System.Drawing.Size(53, 18);
            this.ctl_spam_graphic.TabIndex = 14;
            this.ctl_spam_graphic.UseParentBackColor = true;
            this.ctl_spam_graphic.zz_CheckValue = false;
            this.ctl_spam_graphic.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_spam_graphic.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_spam_graphic.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_spam_graphic.zz_OriginalDesign = false;
            this.ctl_spam_graphic.zz_ShowNeedsSaveColor = true;
            // 
            // agent
            // 
            this.agent.AllowChange = true;
            this.agent.AllowClear = false;
            this.agent.AllowNew = false;
            this.agent.AllowView = false;
            this.agent.BackColor = System.Drawing.Color.White;
            this.agent.Bold = false;
            this.agent.Caption = "Agent";
            this.agent.Changed = false;
            this.agent.Location = new System.Drawing.Point(591, 6);
            this.agent.Name = "agent";
            this.agent.Size = new System.Drawing.Size(174, 52);
            this.agent.TabIndex = 17;
            this.agent.UseParentBackColor = true;
            this.agent.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.agent.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            // 
            // cmdBad
            // 
            this.cmdBad.Location = new System.Drawing.Point(573, 62);
            this.cmdBad.Name = "cmdBad";
            this.cmdBad.Size = new System.Drawing.Size(58, 20);
            this.cmdBad.TabIndex = 18;
            this.cmdBad.Text = "Bad";
            this.cmdBad.UseVisualStyleBackColor = true;
            this.cmdBad.Click += new System.EventHandler(this.cmdBad_Click);
            // 
            // cmdRelease
            // 
            this.cmdRelease.Location = new System.Drawing.Point(512, 62);
            this.cmdRelease.Name = "cmdRelease";
            this.cmdRelease.Size = new System.Drawing.Size(58, 20);
            this.cmdRelease.TabIndex = 19;
            this.cmdRelease.Text = "Release";
            this.cmdRelease.UseVisualStyleBackColor = true;
            this.cmdRelease.Click += new System.EventHandler(this.cmdRelease_Click);
            // 
            // cmdClaim
            // 
            this.cmdClaim.Location = new System.Drawing.Point(637, 62);
            this.cmdClaim.Name = "cmdClaim";
            this.cmdClaim.Size = new System.Drawing.Size(58, 20);
            this.cmdClaim.TabIndex = 20;
            this.cmdClaim.Text = "Claim";
            this.cmdClaim.UseVisualStyleBackColor = true;
            this.cmdClaim.Click += new System.EventHandler(this.cmdClaim_Click);
            // 
            // ctl_contactnotes
            // 
            this.ctl_contactnotes.BackColor = System.Drawing.Color.White;
            this.ctl_contactnotes.Bold = false;
            this.ctl_contactnotes.Caption = "Contact Notes";
            this.ctl_contactnotes.Changed = false;
            this.ctl_contactnotes.DateLines = false;
            this.ctl_contactnotes.Location = new System.Drawing.Point(12, 462);
            this.ctl_contactnotes.Name = "ctl_contactnotes";
            this.ctl_contactnotes.Size = new System.Drawing.Size(508, 132);
            this.ctl_contactnotes.TabIndex = 26;
            this.ctl_contactnotes.UseParentBackColor = true;
            this.ctl_contactnotes.zz_Enabled = true;
            this.ctl_contactnotes.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_contactnotes.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_contactnotes.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_contactnotes.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_contactnotes.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_contactnotes.zz_OriginalDesign = true;
            this.ctl_contactnotes.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ctl_contactnotes.zz_ShowNeedsSaveColor = true;
            this.ctl_contactnotes.zz_Text = "";
            this.ctl_contactnotes.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_contactnotes.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_contactnotes.zz_UseGlobalColor = false;
            this.ctl_contactnotes.zz_UseGlobalFont = false;
            // 
            // cmdAssign
            // 
            this.cmdAssign.Location = new System.Drawing.Point(452, 62);
            this.cmdAssign.Name = "cmdAssign";
            this.cmdAssign.Size = new System.Drawing.Size(58, 20);
            this.cmdAssign.TabIndex = 27;
            this.cmdAssign.Text = "Assign";
            this.cmdAssign.UseVisualStyleBackColor = true;
            this.cmdAssign.Click += new System.EventHandler(this.cmdAssign_Click);
            // 
            // ctl_donotcall
            // 
            this.ctl_donotcall.BackColor = System.Drawing.Color.White;
            this.ctl_donotcall.Bold = false;
            this.ctl_donotcall.Caption = "Do Not Call";
            this.ctl_donotcall.Changed = false;
            this.ctl_donotcall.ForeColor = System.Drawing.Color.Red;
            this.ctl_donotcall.Location = new System.Drawing.Point(179, 25);
            this.ctl_donotcall.Name = "ctl_donotcall";
            this.ctl_donotcall.Size = new System.Drawing.Size(80, 18);
            this.ctl_donotcall.TabIndex = 37;
            this.ctl_donotcall.UseParentBackColor = true;
            this.ctl_donotcall.zz_CheckValue = false;
            this.ctl_donotcall.zz_LabelColor = System.Drawing.Color.Red;
            this.ctl_donotcall.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_donotcall.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_donotcall.zz_OriginalDesign = false;
            this.ctl_donotcall.zz_ShowNeedsSaveColor = true;
            // 
            // cmdUnClaim
            // 
            this.cmdUnClaim.Location = new System.Drawing.Point(701, 62);
            this.cmdUnClaim.Name = "cmdUnClaim";
            this.cmdUnClaim.Size = new System.Drawing.Size(58, 20);
            this.cmdUnClaim.TabIndex = 38;
            this.cmdUnClaim.Text = "Unclaim";
            this.cmdUnClaim.UseVisualStyleBackColor = true;
            this.cmdUnClaim.Click += new System.EventHandler(this.cmdUnClaim_Click);
            // 
            // result_notes
            // 
            this.result_notes.AddCaption = "Add New";
            this.result_notes.AllowActions = true;
            this.result_notes.AllowAdd = true;
            this.result_notes.AllowDelete = false;
            this.result_notes.AllowDeleteAlways = false;
            this.result_notes.AllowDrop = true;
            this.result_notes.AllowOnlyOpenDelete = false;
            this.result_notes.AlternateConnection = null;
            this.result_notes.BackColor = System.Drawing.Color.White;
            this.result_notes.Caption = "Notes";
            this.result_notes.CurrentTemplate = null;
            this.result_notes.ExtraClassInfo = "";
            this.result_notes.Location = new System.Drawing.Point(330, 486);
            this.result_notes.MultiSelect = true;
            this.result_notes.Name = "result_notes";
            this.result_notes.Size = new System.Drawing.Size(441, 108);
            this.result_notes.SuppressSelectionChanged = false;
            this.result_notes.TabIndex = 58;
            this.result_notes.zz_OpenColumnMenu = false;
            this.result_notes.zz_OrderLineType = "";
            this.result_notes.zz_ShowAutoRefresh = true;
            this.result_notes.zz_ShowUnlimited = true;
            this.result_notes.AboutToAdd += new NewMethod.AddHandler(this.result_notes_AboutToAdd);
            // 
            // pNotes
            // 
            this.pNotes.Controls.Add(this.cmdFollowUp);
            this.pNotes.Controls.Add(this.cmdSentEmail);
            this.pNotes.Controls.Add(this.cmdSE);
            this.pNotes.Controls.Add(this.cmdBadEmail);
            this.pNotes.Controls.Add(this.cmdWrongNumber);
            this.pNotes.Controls.Add(this.cmdVoiceMail);
            this.pNotes.Controls.Add(this.cmdNoAnswer);
            this.pNotes.Location = new System.Drawing.Point(94, 459);
            this.pNotes.Name = "pNotes";
            this.pNotes.Size = new System.Drawing.Size(677, 23);
            this.pNotes.TabIndex = 59;
            // 
            // cmdFollowUp
            // 
            this.cmdFollowUp.Location = new System.Drawing.Point(442, 1);
            this.cmdFollowUp.Name = "cmdFollowUp";
            this.cmdFollowUp.Size = new System.Drawing.Size(75, 21);
            this.cmdFollowUp.TabIndex = 64;
            this.cmdFollowUp.Text = "Follow Up";
            this.cmdFollowUp.UseVisualStyleBackColor = true;
            this.cmdFollowUp.Click += new System.EventHandler(this.cmdFollowUp_Click);
            // 
            // cmdSentEmail
            // 
            this.cmdSentEmail.Location = new System.Drawing.Point(351, 1);
            this.cmdSentEmail.Name = "cmdSentEmail";
            this.cmdSentEmail.Size = new System.Drawing.Size(75, 21);
            this.cmdSentEmail.TabIndex = 63;
            this.cmdSentEmail.Text = "Sent Email";
            this.cmdSentEmail.UseVisualStyleBackColor = true;
            this.cmdSentEmail.Click += new System.EventHandler(this.cmdSentEmail_Click);
            // 
            // cmdSE
            // 
            this.cmdSE.Location = new System.Drawing.Point(526, 1);
            this.cmdSE.Name = "cmdSE";
            this.cmdSE.Size = new System.Drawing.Size(151, 21);
            this.cmdSE.TabIndex = 62;
            this.cmdSE.Text = "Save & Close";
            this.cmdSE.UseMnemonic = false;
            this.cmdSE.UseVisualStyleBackColor = true;
            this.cmdSE.Click += new System.EventHandler(this.cmdSE_Click);
            // 
            // cmdBadEmail
            // 
            this.cmdBadEmail.Location = new System.Drawing.Point(265, 1);
            this.cmdBadEmail.Name = "cmdBadEmail";
            this.cmdBadEmail.Size = new System.Drawing.Size(75, 21);
            this.cmdBadEmail.TabIndex = 61;
            this.cmdBadEmail.Text = "Bad Email";
            this.cmdBadEmail.UseVisualStyleBackColor = true;
            this.cmdBadEmail.Click += new System.EventHandler(this.cmdBadEmail_Click);
            // 
            // cmdWrongNumber
            // 
            this.cmdWrongNumber.Location = new System.Drawing.Point(176, 1);
            this.cmdWrongNumber.Name = "cmdWrongNumber";
            this.cmdWrongNumber.Size = new System.Drawing.Size(75, 21);
            this.cmdWrongNumber.TabIndex = 60;
            this.cmdWrongNumber.Text = "Wrong #";
            this.cmdWrongNumber.UseVisualStyleBackColor = true;
            this.cmdWrongNumber.Click += new System.EventHandler(this.cmdWrongNumber_Click);
            // 
            // cmdVoiceMail
            // 
            this.cmdVoiceMail.Location = new System.Drawing.Point(90, 1);
            this.cmdVoiceMail.Name = "cmdVoiceMail";
            this.cmdVoiceMail.Size = new System.Drawing.Size(75, 21);
            this.cmdVoiceMail.TabIndex = 59;
            this.cmdVoiceMail.Text = "Voice Mail";
            this.cmdVoiceMail.UseVisualStyleBackColor = true;
            this.cmdVoiceMail.Click += new System.EventHandler(this.cmdVoiceMail_Click);
            // 
            // cmdNoAnswer
            // 
            this.cmdNoAnswer.Location = new System.Drawing.Point(6, 1);
            this.cmdNoAnswer.Name = "cmdNoAnswer";
            this.cmdNoAnswer.Size = new System.Drawing.Size(75, 21);
            this.cmdNoAnswer.TabIndex = 58;
            this.cmdNoAnswer.Text = "No Answer";
            this.cmdNoAnswer.UseVisualStyleBackColor = true;
            this.cmdNoAnswer.Click += new System.EventHandler(this.cmdNoAnswer_Click);
            // 
            // lblClearDuplicateNotes
            // 
            this.lblClearDuplicateNotes.AutoSize = true;
            this.lblClearDuplicateNotes.Location = new System.Drawing.Point(510, 483);
            this.lblClearDuplicateNotes.Name = "lblClearDuplicateNotes";
            this.lblClearDuplicateNotes.Size = new System.Drawing.Size(105, 13);
            this.lblClearDuplicateNotes.TabIndex = 60;
            this.lblClearDuplicateNotes.TabStop = true;
            this.lblClearDuplicateNotes.Text = "clear duplicate notes";
            this.lblClearDuplicateNotes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblClearDuplicateNotes_LinkClicked);
            // 
            // ctl_personality_type
            // 
            this.ctl_personality_type.AllCaps = false;
            this.ctl_personality_type.AllowEdit = true;
            this.ctl_personality_type.BackColor = System.Drawing.Color.Transparent;
            this.ctl_personality_type.Bold = false;
            this.ctl_personality_type.Caption = "Personality Type";
            this.ctl_personality_type.Changed = false;
            this.ctl_personality_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_personality_type.ListName = "personality_type";
            this.ctl_personality_type.Location = new System.Drawing.Point(775, 118);
            this.ctl_personality_type.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctl_personality_type.Name = "ctl_personality_type";
            this.ctl_personality_type.SimpleList = null;
            this.ctl_personality_type.Size = new System.Drawing.Size(89, 36);
            this.ctl_personality_type.TabIndex = 61;
            this.ctl_personality_type.UseParentBackColor = true;
            this.ctl_personality_type.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_personality_type.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_personality_type.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_personality_type.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_personality_type.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_personality_type.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_personality_type.zz_OriginalDesign = false;
            this.ctl_personality_type.zz_ShowNeedsSaveColor = true;
            this.ctl_personality_type.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_personality_type.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_personality_type.zz_UseGlobalColor = false;
            this.ctl_personality_type.zz_UseGlobalFont = false;
            this.ctl_personality_type.SelectionChanged += new NewMethod.nEdit_List.SelectionChangedHandler(this.ctl_personality_type_SelectionChanged);
            // 
            // lbl_interaction
            // 
            this.lbl_interaction.AutoSize = true;
            this.lbl_interaction.Location = new System.Drawing.Point(775, 276);
            this.lbl_interaction.Name = "lbl_interaction";
            this.lbl_interaction.Size = new System.Drawing.Size(63, 13);
            this.lbl_interaction.TabIndex = 62;
            this.lbl_interaction.Text = "[Interaction]";
            // 
            // lbl_interact
            // 
            this.lbl_interact.AutoSize = true;
            this.lbl_interact.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_interact.Location = new System.Drawing.Point(775, 252);
            this.lbl_interact.Name = "lbl_interact";
            this.lbl_interact.Size = new System.Drawing.Size(127, 17);
            this.lbl_interact.TabIndex = 63;
            this.lbl_interact.Text = "How To Interact:";
            this.lbl_interact.Visible = false;
            // 
            // lbl_expect
            // 
            this.lbl_expect.AutoSize = true;
            this.lbl_expect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_expect.Location = new System.Drawing.Point(775, 211);
            this.lbl_expect.Name = "lbl_expect";
            this.lbl_expect.Size = new System.Drawing.Size(122, 17);
            this.lbl_expect.TabIndex = 65;
            this.lbl_expect.Text = "What to Expect:";
            this.lbl_expect.Visible = false;
            // 
            // lbl_expectation
            // 
            this.lbl_expectation.AutoSize = true;
            this.lbl_expectation.Location = new System.Drawing.Point(775, 235);
            this.lbl_expectation.Name = "lbl_expectation";
            this.lbl_expectation.Size = new System.Drawing.Size(69, 13);
            this.lbl_expectation.TabIndex = 64;
            this.lbl_expectation.Text = "[Expectation]";
            // 
            // lbl_trait
            // 
            this.lbl_trait.AutoSize = true;
            this.lbl_trait.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_trait.Location = new System.Drawing.Point(775, 166);
            this.lbl_trait.Name = "lbl_trait";
            this.lbl_trait.Size = new System.Drawing.Size(55, 17);
            this.lbl_trait.TabIndex = 67;
            this.lbl_trait.Text = "Traits:";
            this.lbl_trait.Visible = false;
            // 
            // lbl_traits
            // 
            this.lbl_traits.AutoSize = true;
            this.lbl_traits.Location = new System.Drawing.Point(775, 190);
            this.lbl_traits.Name = "lbl_traits";
            this.lbl_traits.Size = new System.Drawing.Size(39, 13);
            this.lbl_traits.TabIndex = 66;
            this.lbl_traits.Text = "[Traits]";
            // 
            // tabAffiliate
            // 
            this.tabAffiliate.Controls.Add(this.ctl_affiliate_name);
            this.tabAffiliate.Controls.Add(this.ctl_affiliate_id);
            this.tabAffiliate.Location = new System.Drawing.Point(4, 22);
            this.tabAffiliate.Name = "tabAffiliate";
            this.tabAffiliate.Padding = new System.Windows.Forms.Padding(3);
            this.tabAffiliate.Size = new System.Drawing.Size(749, 333);
            this.tabAffiliate.TabIndex = 14;
            this.tabAffiliate.Text = "Affiliate Info";
            this.tabAffiliate.UseVisualStyleBackColor = true;
            // 
            // pageCallLogs
            // 
            this.pageCallLogs.Controls.Add(this.lvCalls);
            this.pageCallLogs.Location = new System.Drawing.Point(4, 22);
            this.pageCallLogs.Name = "pageCallLogs";
            this.pageCallLogs.Size = new System.Drawing.Size(749, 333);
            this.pageCallLogs.TabIndex = 11;
            this.pageCallLogs.Text = "Call Logs";
            this.pageCallLogs.UseVisualStyleBackColor = true;
            // 
            // pagePhoneNumbers
            // 
            this.pagePhoneNumbers.Controls.Add(this.cmdRemove);
            this.pagePhoneNumbers.Controls.Add(this.cmdAddPhone);
            this.pagePhoneNumbers.Controls.Add(this.lvPhone);
            this.pagePhoneNumbers.Controls.Add(this.gbPhone);
            this.pagePhoneNumbers.Location = new System.Drawing.Point(4, 22);
            this.pagePhoneNumbers.Name = "pagePhoneNumbers";
            this.pagePhoneNumbers.Padding = new System.Windows.Forms.Padding(3);
            this.pagePhoneNumbers.Size = new System.Drawing.Size(749, 333);
            this.pagePhoneNumbers.TabIndex = 9;
            this.pagePhoneNumbers.Text = "Phone Numbers";
            this.pagePhoneNumbers.UseVisualStyleBackColor = true;
            // 
            // gbPhone
            // 
            this.gbPhone.Controls.Add(this.lblWebPhone);
            this.gbPhone.Controls.Add(this.cmdChangePhone);
            this.gbPhone.Controls.Add(this.cmdViewPhone);
            this.gbPhone.Location = new System.Drawing.Point(7, 6);
            this.gbPhone.Name = "gbPhone";
            this.gbPhone.Size = new System.Drawing.Size(707, 47);
            this.gbPhone.TabIndex = 0;
            this.gbPhone.TabStop = false;
            this.gbPhone.Text = "Web Phone Number";
            // 
            // cmdViewPhone
            // 
            this.cmdViewPhone.Location = new System.Drawing.Point(12, 19);
            this.cmdViewPhone.Name = "cmdViewPhone";
            this.cmdViewPhone.Size = new System.Drawing.Size(132, 21);
            this.cmdViewPhone.TabIndex = 0;
            this.cmdViewPhone.Text = "View";
            this.cmdViewPhone.UseVisualStyleBackColor = true;
            this.cmdViewPhone.Click += new System.EventHandler(this.cmdViewPhone_Click);
            // 
            // cmdChangePhone
            // 
            this.cmdChangePhone.Location = new System.Drawing.Point(567, 20);
            this.cmdChangePhone.Name = "cmdChangePhone";
            this.cmdChangePhone.Size = new System.Drawing.Size(132, 21);
            this.cmdChangePhone.TabIndex = 1;
            this.cmdChangePhone.Text = "Change";
            this.cmdChangePhone.UseVisualStyleBackColor = true;
            this.cmdChangePhone.Click += new System.EventHandler(this.cmdChangePhone_Click);
            // 
            // lblWebPhone
            // 
            this.lblWebPhone.AutoSize = true;
            this.lblWebPhone.Location = new System.Drawing.Point(149, 20);
            this.lblWebPhone.Name = "lblWebPhone";
            this.lblWebPhone.Size = new System.Drawing.Size(110, 13);
            this.lblWebPhone.TabIndex = 2;
            this.lblWebPhone.Text = "<web phone number>";
            // 
            // lvPhone
            // 
            this.lvPhone.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvPhone.HideSelection = false;
            this.lvPhone.Location = new System.Drawing.Point(88, 59);
            this.lvPhone.Name = "lvPhone";
            this.lvPhone.Size = new System.Drawing.Size(626, 268);
            this.lvPhone.TabIndex = 1;
            this.lvPhone.UseCompatibleStateImageBehavior = false;
            this.lvPhone.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Number";
            this.columnHeader1.Width = 280;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 276;
            // 
            // cmdAddPhone
            // 
            this.cmdAddPhone.Location = new System.Drawing.Point(19, 61);
            this.cmdAddPhone.Name = "cmdAddPhone";
            this.cmdAddPhone.Size = new System.Drawing.Size(63, 21);
            this.cmdAddPhone.TabIndex = 2;
            this.cmdAddPhone.Text = "Add Number";
            this.cmdAddPhone.UseVisualStyleBackColor = true;
            this.cmdAddPhone.Click += new System.EventHandler(this.cmdAddPhone_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Location = new System.Drawing.Point(19, 88);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(63, 21);
            this.cmdRemove.TabIndex = 3;
            this.cmdRemove.Text = "Remove";
            this.cmdRemove.UseVisualStyleBackColor = true;
            // 
            // pageFeedback
            // 
            this.pageFeedback.Controls.Add(this.wbFeedback);
            this.pageFeedback.Location = new System.Drawing.Point(4, 22);
            this.pageFeedback.Name = "pageFeedback";
            this.pageFeedback.Padding = new System.Windows.Forms.Padding(3);
            this.pageFeedback.Size = new System.Drawing.Size(749, 333);
            this.pageFeedback.TabIndex = 7;
            this.pageFeedback.Text = "Feedback";
            this.pageFeedback.UseVisualStyleBackColor = true;
            // 
            // wbFeedback
            // 
            this.wbFeedback.BackColor = System.Drawing.Color.White;
            this.wbFeedback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbFeedback.Location = new System.Drawing.Point(3, 3);
            this.wbFeedback.Name = "wbFeedback";
            this.wbFeedback.ShowControls = false;
            this.wbFeedback.Silent = false;
            this.wbFeedback.Size = new System.Drawing.Size(743, 327);
            this.wbFeedback.TabIndex = 1;
            // 
            // pageOrders
            // 
            this.pageOrders.Controls.Add(this.gbOrderOptions);
            this.pageOrders.Controls.Add(this.result_orders);
            this.pageOrders.Location = new System.Drawing.Point(4, 22);
            this.pageOrders.Name = "pageOrders";
            this.pageOrders.Padding = new System.Windows.Forms.Padding(3);
            this.pageOrders.Size = new System.Drawing.Size(749, 333);
            this.pageOrders.TabIndex = 6;
            this.pageOrders.Text = "Orders";
            this.pageOrders.UseVisualStyleBackColor = true;
            // 
            // gbOrderOptions
            // 
            this.gbOrderOptions.Controls.Add(this.optVRMA);
            this.gbOrderOptions.Controls.Add(this.optRMAs);
            this.gbOrderOptions.Controls.Add(this.optInvoices);
            this.gbOrderOptions.Controls.Add(this.optPurchase);
            this.gbOrderOptions.Controls.Add(this.optSales);
            this.gbOrderOptions.Controls.Add(this.optQuote);
            this.gbOrderOptions.Controls.Add(this.optAll);
            this.gbOrderOptions.Location = new System.Drawing.Point(6, 6);
            this.gbOrderOptions.Name = "gbOrderOptions";
            this.gbOrderOptions.Size = new System.Drawing.Size(118, 272);
            this.gbOrderOptions.TabIndex = 5;
            this.gbOrderOptions.TabStop = false;
            this.gbOrderOptions.Text = "Options";
            // 
            // optAll
            // 
            this.optAll.AutoSize = true;
            this.optAll.Checked = true;
            this.optAll.Location = new System.Drawing.Point(11, 21);
            this.optAll.Name = "optAll";
            this.optAll.Size = new System.Drawing.Size(68, 17);
            this.optAll.TabIndex = 0;
            this.optAll.TabStop = true;
            this.optAll.Text = "All Types";
            this.optAll.UseVisualStyleBackColor = true;
            this.optAll.CheckedChanged += new System.EventHandler(this.optAll_CheckedChanged);
            // 
            // optQuote
            // 
            this.optQuote.AutoSize = true;
            this.optQuote.Location = new System.Drawing.Point(11, 55);
            this.optQuote.Name = "optQuote";
            this.optQuote.Size = new System.Drawing.Size(93, 17);
            this.optQuote.TabIndex = 1;
            this.optQuote.Text = "Formal Quotes";
            this.optQuote.UseVisualStyleBackColor = true;
            this.optQuote.CheckedChanged += new System.EventHandler(this.optAll_CheckedChanged);
            // 
            // optSales
            // 
            this.optSales.AutoSize = true;
            this.optSales.Location = new System.Drawing.Point(11, 78);
            this.optSales.Name = "optSales";
            this.optSales.Size = new System.Drawing.Size(85, 17);
            this.optSales.TabIndex = 2;
            this.optSales.Text = "Sales Orders";
            this.optSales.UseVisualStyleBackColor = true;
            this.optSales.CheckedChanged += new System.EventHandler(this.optAll_CheckedChanged);
            // 
            // optPurchase
            // 
            this.optPurchase.AutoSize = true;
            this.optPurchase.Location = new System.Drawing.Point(11, 101);
            this.optPurchase.Name = "optPurchase";
            this.optPurchase.Size = new System.Drawing.Size(104, 17);
            this.optPurchase.TabIndex = 3;
            this.optPurchase.Text = "Purchase Orders";
            this.optPurchase.UseVisualStyleBackColor = true;
            this.optPurchase.CheckedChanged += new System.EventHandler(this.optAll_CheckedChanged);
            // 
            // optInvoices
            // 
            this.optInvoices.AutoSize = true;
            this.optInvoices.Location = new System.Drawing.Point(11, 125);
            this.optInvoices.Name = "optInvoices";
            this.optInvoices.Size = new System.Drawing.Size(65, 17);
            this.optInvoices.TabIndex = 4;
            this.optInvoices.Text = "Invoices";
            this.optInvoices.UseVisualStyleBackColor = true;
            this.optInvoices.CheckedChanged += new System.EventHandler(this.optAll_CheckedChanged);
            // 
            // optRMAs
            // 
            this.optRMAs.AutoSize = true;
            this.optRMAs.Location = new System.Drawing.Point(11, 148);
            this.optRMAs.Name = "optRMAs";
            this.optRMAs.Size = new System.Drawing.Size(54, 17);
            this.optRMAs.TabIndex = 5;
            this.optRMAs.Text = "RMAs";
            this.optRMAs.UseVisualStyleBackColor = true;
            this.optRMAs.CheckedChanged += new System.EventHandler(this.optAll_CheckedChanged);
            // 
            // optVRMA
            // 
            this.optVRMA.AutoSize = true;
            this.optVRMA.Location = new System.Drawing.Point(11, 171);
            this.optVRMA.Name = "optVRMA";
            this.optVRMA.Size = new System.Drawing.Size(91, 17);
            this.optVRMA.TabIndex = 6;
            this.optVRMA.Text = "Vendor RMAs";
            this.optVRMA.UseVisualStyleBackColor = true;
            this.optVRMA.CheckedChanged += new System.EventHandler(this.optAll_CheckedChanged);
            // 
            // pageBids
            // 
            this.pageBids.Controls.Add(this.result_bids);
            this.pageBids.Location = new System.Drawing.Point(4, 22);
            this.pageBids.Name = "pageBids";
            this.pageBids.Padding = new System.Windows.Forms.Padding(3);
            this.pageBids.Size = new System.Drawing.Size(749, 333);
            this.pageBids.TabIndex = 10;
            this.pageBids.Text = "Bids";
            this.pageBids.UseVisualStyleBackColor = true;
            // 
            // pageQuotes
            // 
            this.pageQuotes.Location = new System.Drawing.Point(4, 22);
            this.pageQuotes.Name = "pageQuotes";
            this.pageQuotes.Padding = new System.Windows.Forms.Padding(3);
            this.pageQuotes.Size = new System.Drawing.Size(749, 333);
            this.pageQuotes.TabIndex = 5;
            this.pageQuotes.Text = "Quotes";
            this.pageQuotes.UseVisualStyleBackColor = true;
            // 
            // pageReqs
            // 
            this.pageReqs.Controls.Add(this.result_reqs);
            this.pageReqs.Location = new System.Drawing.Point(4, 22);
            this.pageReqs.Name = "pageReqs";
            this.pageReqs.Padding = new System.Windows.Forms.Padding(3);
            this.pageReqs.Size = new System.Drawing.Size(749, 333);
            this.pageReqs.TabIndex = 4;
            this.pageReqs.Text = "Reqs";
            this.pageReqs.UseVisualStyleBackColor = true;
            // 
            // pageCalls
            // 
            this.pageCalls.Controls.Add(this.wbCalls);
            this.pageCalls.Location = new System.Drawing.Point(4, 22);
            this.pageCalls.Name = "pageCalls";
            this.pageCalls.Padding = new System.Windows.Forms.Padding(3);
            this.pageCalls.Size = new System.Drawing.Size(749, 333);
            this.pageCalls.TabIndex = 3;
            this.pageCalls.Text = "Calls";
            this.pageCalls.UseVisualStyleBackColor = true;
            // 
            // wbCalls
            // 
            this.wbCalls.BackColor = System.Drawing.Color.White;
            this.wbCalls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbCalls.Location = new System.Drawing.Point(3, 3);
            this.wbCalls.Name = "wbCalls";
            this.wbCalls.ShowControls = false;
            this.wbCalls.Silent = false;
            this.wbCalls.Size = new System.Drawing.Size(743, 327);
            this.wbCalls.TabIndex = 0;
            // 
            // pageMoreInfo
            // 
            this.pageMoreInfo.Controls.Add(this.ctl_send_company_shipping_email_alert);
            this.pageMoreInfo.Controls.Add(this.ctl_isdefaultsales);
            this.pageMoreInfo.Controls.Add(this.ctl_isdefaultpurchaser);
            this.pageMoreInfo.Controls.Add(this.ctl_timezone);
            this.pageMoreInfo.Controls.Add(this.ctl_group_name);
            this.pageMoreInfo.Controls.Add(this.ctl_alternateemail);
            this.pageMoreInfo.Controls.Add(this.ctl_interests);
            this.pageMoreInfo.Controls.Add(this.ctl_maritalstatus);
            this.pageMoreInfo.Controls.Add(this.ctl_contactgender);
            this.pageMoreInfo.Controls.Add(this.ctl_birthdate);
            this.pageMoreInfo.Location = new System.Drawing.Point(4, 22);
            this.pageMoreInfo.Name = "pageMoreInfo";
            this.pageMoreInfo.Padding = new System.Windows.Forms.Padding(3);
            this.pageMoreInfo.Size = new System.Drawing.Size(749, 333);
            this.pageMoreInfo.TabIndex = 1;
            this.pageMoreInfo.Text = "More Info";
            this.pageMoreInfo.UseVisualStyleBackColor = true;
            // 
            // ctl_isdefaultpurchaser
            // 
            this.ctl_isdefaultpurchaser.BackColor = System.Drawing.Color.Transparent;
            this.ctl_isdefaultpurchaser.Bold = false;
            this.ctl_isdefaultpurchaser.Caption = "Default Purchaser";
            this.ctl_isdefaultpurchaser.Changed = false;
            this.ctl_isdefaultpurchaser.Location = new System.Drawing.Point(6, 6);
            this.ctl_isdefaultpurchaser.Name = "ctl_isdefaultpurchaser";
            this.ctl_isdefaultpurchaser.Size = new System.Drawing.Size(111, 18);
            this.ctl_isdefaultpurchaser.TabIndex = 12;
            this.ctl_isdefaultpurchaser.UseParentBackColor = true;
            this.ctl_isdefaultpurchaser.zz_CheckValue = false;
            this.ctl_isdefaultpurchaser.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_isdefaultpurchaser.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_isdefaultpurchaser.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_isdefaultpurchaser.zz_OriginalDesign = false;
            this.ctl_isdefaultpurchaser.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_isdefaultsales
            // 
            this.ctl_isdefaultsales.BackColor = System.Drawing.Color.Transparent;
            this.ctl_isdefaultsales.Bold = false;
            this.ctl_isdefaultsales.Caption = "Default Sales";
            this.ctl_isdefaultsales.Changed = false;
            this.ctl_isdefaultsales.Location = new System.Drawing.Point(141, 6);
            this.ctl_isdefaultsales.Name = "ctl_isdefaultsales";
            this.ctl_isdefaultsales.Size = new System.Drawing.Size(89, 18);
            this.ctl_isdefaultsales.TabIndex = 13;
            this.ctl_isdefaultsales.UseParentBackColor = true;
            this.ctl_isdefaultsales.zz_CheckValue = false;
            this.ctl_isdefaultsales.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_isdefaultsales.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_isdefaultsales.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_isdefaultsales.zz_OriginalDesign = false;
            this.ctl_isdefaultsales.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_birthdate
            // 
            this.ctl_birthdate.AllowClear = false;
            this.ctl_birthdate.BackColor = System.Drawing.Color.Transparent;
            this.ctl_birthdate.Bold = false;
            this.ctl_birthdate.Caption = "Birthday";
            this.ctl_birthdate.Changed = false;
            this.ctl_birthdate.Location = new System.Drawing.Point(5, 28);
            this.ctl_birthdate.Name = "ctl_birthdate";
            this.ctl_birthdate.Size = new System.Drawing.Size(178, 46);
            this.ctl_birthdate.SuppressEdit = false;
            this.ctl_birthdate.TabIndex = 1;
            this.ctl_birthdate.UseParentBackColor = true;
            this.ctl_birthdate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_birthdate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_birthdate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_birthdate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_birthdate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_birthdate.zz_OriginalDesign = true;
            this.ctl_birthdate.zz_ShowNeedsSaveColor = true;
            this.ctl_birthdate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_birthdate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_birthdate.zz_UseGlobalColor = false;
            this.ctl_birthdate.zz_UseGlobalFont = false;
            // 
            // ctl_contactgender
            // 
            this.ctl_contactgender.AllCaps = false;
            this.ctl_contactgender.AllowEdit = false;
            this.ctl_contactgender.BackColor = System.Drawing.Color.Transparent;
            this.ctl_contactgender.Bold = false;
            this.ctl_contactgender.Caption = "Gender";
            this.ctl_contactgender.Changed = false;
            this.ctl_contactgender.ListName = "contactgender";
            this.ctl_contactgender.Location = new System.Drawing.Point(6, 77);
            this.ctl_contactgender.Name = "ctl_contactgender";
            this.ctl_contactgender.SimpleList = null;
            this.ctl_contactgender.Size = new System.Drawing.Size(147, 47);
            this.ctl_contactgender.TabIndex = 5;
            this.ctl_contactgender.UseParentBackColor = true;
            this.ctl_contactgender.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_contactgender.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_contactgender.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_contactgender.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_contactgender.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_contactgender.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_contactgender.zz_OriginalDesign = true;
            this.ctl_contactgender.zz_ShowNeedsSaveColor = true;
            this.ctl_contactgender.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_contactgender.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_contactgender.zz_UseGlobalColor = false;
            this.ctl_contactgender.zz_UseGlobalFont = false;
            // 
            // ctl_maritalstatus
            // 
            this.ctl_maritalstatus.AllCaps = false;
            this.ctl_maritalstatus.AllowEdit = false;
            this.ctl_maritalstatus.BackColor = System.Drawing.Color.Transparent;
            this.ctl_maritalstatus.Bold = false;
            this.ctl_maritalstatus.Caption = "Marital Status";
            this.ctl_maritalstatus.Changed = false;
            this.ctl_maritalstatus.ListName = "maritalstatus";
            this.ctl_maritalstatus.Location = new System.Drawing.Point(159, 77);
            this.ctl_maritalstatus.Name = "ctl_maritalstatus";
            this.ctl_maritalstatus.SimpleList = null;
            this.ctl_maritalstatus.Size = new System.Drawing.Size(158, 47);
            this.ctl_maritalstatus.TabIndex = 16;
            this.ctl_maritalstatus.UseParentBackColor = true;
            this.ctl_maritalstatus.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_maritalstatus.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_maritalstatus.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_maritalstatus.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_maritalstatus.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_maritalstatus.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_maritalstatus.zz_OriginalDesign = true;
            this.ctl_maritalstatus.zz_ShowNeedsSaveColor = true;
            this.ctl_maritalstatus.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_maritalstatus.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_maritalstatus.zz_UseGlobalColor = false;
            this.ctl_maritalstatus.zz_UseGlobalFont = false;
            // 
            // ctl_interests
            // 
            this.ctl_interests.BackColor = System.Drawing.Color.Transparent;
            this.ctl_interests.Bold = false;
            this.ctl_interests.Caption = "Interests";
            this.ctl_interests.Changed = false;
            this.ctl_interests.DateLines = false;
            this.ctl_interests.Location = new System.Drawing.Point(6, 133);
            this.ctl_interests.Name = "ctl_interests";
            this.ctl_interests.Size = new System.Drawing.Size(708, 138);
            this.ctl_interests.TabIndex = 17;
            this.ctl_interests.UseParentBackColor = true;
            this.ctl_interests.zz_Enabled = true;
            this.ctl_interests.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_interests.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_interests.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_interests.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_interests.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_interests.zz_OriginalDesign = true;
            this.ctl_interests.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ctl_interests.zz_ShowNeedsSaveColor = true;
            this.ctl_interests.zz_Text = "";
            this.ctl_interests.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_interests.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_interests.zz_UseGlobalColor = false;
            this.ctl_interests.zz_UseGlobalFont = false;
            // 
            // ctl_alternateemail
            // 
            this.ctl_alternateemail.AllCaps = false;
            this.ctl_alternateemail.BackColor = System.Drawing.Color.Transparent;
            this.ctl_alternateemail.Bold = false;
            this.ctl_alternateemail.Caption = "Alternate Email";
            this.ctl_alternateemail.Changed = false;
            this.ctl_alternateemail.IsEmail = false;
            this.ctl_alternateemail.IsURL = false;
            this.ctl_alternateemail.Location = new System.Drawing.Point(323, 77);
            this.ctl_alternateemail.Name = "ctl_alternateemail";
            this.ctl_alternateemail.PasswordChar = '\0';
            this.ctl_alternateemail.Size = new System.Drawing.Size(391, 48);
            this.ctl_alternateemail.TabIndex = 18;
            this.ctl_alternateemail.UseParentBackColor = true;
            this.ctl_alternateemail.zz_Enabled = true;
            this.ctl_alternateemail.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_alternateemail.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_alternateemail.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_alternateemail.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_alternateemail.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_alternateemail.zz_OriginalDesign = true;
            this.ctl_alternateemail.zz_ShowLinkButton = false;
            this.ctl_alternateemail.zz_ShowNeedsSaveColor = true;
            this.ctl_alternateemail.zz_Text = "";
            this.ctl_alternateemail.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_alternateemail.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_alternateemail.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_alternateemail.zz_UseGlobalColor = false;
            this.ctl_alternateemail.zz_UseGlobalFont = false;
            // 
            // ctl_group_name
            // 
            this.ctl_group_name.AllCaps = false;
            this.ctl_group_name.BackColor = System.Drawing.Color.Transparent;
            this.ctl_group_name.Bold = false;
            this.ctl_group_name.Caption = "Groups";
            this.ctl_group_name.Changed = false;
            this.ctl_group_name.IsEmail = false;
            this.ctl_group_name.IsURL = false;
            this.ctl_group_name.Location = new System.Drawing.Point(6, 277);
            this.ctl_group_name.Name = "ctl_group_name";
            this.ctl_group_name.PasswordChar = '\0';
            this.ctl_group_name.Size = new System.Drawing.Size(708, 50);
            this.ctl_group_name.TabIndex = 19;
            this.ctl_group_name.UseParentBackColor = true;
            this.ctl_group_name.zz_Enabled = true;
            this.ctl_group_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_group_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_group_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_group_name.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_group_name.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_group_name.zz_OriginalDesign = true;
            this.ctl_group_name.zz_ShowLinkButton = false;
            this.ctl_group_name.zz_ShowNeedsSaveColor = true;
            this.ctl_group_name.zz_Text = "";
            this.ctl_group_name.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_group_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_group_name.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_group_name.zz_UseGlobalColor = false;
            this.ctl_group_name.zz_UseGlobalFont = false;
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
            this.ctl_timezone.Location = new System.Drawing.Point(323, 28);
            this.ctl_timezone.Name = "ctl_timezone";
            this.ctl_timezone.SimpleList = null;
            this.ctl_timezone.Size = new System.Drawing.Size(147, 36);
            this.ctl_timezone.TabIndex = 20;
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
            // ctl_send_company_shipping_email_alert
            // 
            this.ctl_send_company_shipping_email_alert.BackColor = System.Drawing.Color.Transparent;
            this.ctl_send_company_shipping_email_alert.Bold = false;
            this.ctl_send_company_shipping_email_alert.Caption = "Send Order Shipped Email Alerts";
            this.ctl_send_company_shipping_email_alert.Changed = false;
            this.ctl_send_company_shipping_email_alert.Location = new System.Drawing.Point(236, 6);
            this.ctl_send_company_shipping_email_alert.Name = "ctl_send_company_shipping_email_alert";
            this.ctl_send_company_shipping_email_alert.Size = new System.Drawing.Size(179, 18);
            this.ctl_send_company_shipping_email_alert.TabIndex = 21;
            this.ctl_send_company_shipping_email_alert.UseParentBackColor = true;
            this.ctl_send_company_shipping_email_alert.zz_CheckValue = false;
            this.ctl_send_company_shipping_email_alert.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_send_company_shipping_email_alert.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_send_company_shipping_email_alert.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_send_company_shipping_email_alert.zz_OriginalDesign = false;
            this.ctl_send_company_shipping_email_alert.zz_ShowNeedsSaveColor = true;
            // 
            // pageInfo
            // 
            this.pageInfo.Controls.Add(this.lblCheckAlternatePhone);
            this.pageInfo.Controls.Add(this.lblCheckPhone);
            this.pageInfo.Controls.Add(this.ctl_alternate_names);
            this.pageInfo.Controls.Add(this.gb);
            this.pageInfo.Controls.Add(this.ctl_source);
            this.pageInfo.Controls.Add(this.ctl_primarywebaddress);
            this.pageInfo.Controls.Add(this.ctl_primaryemailaddress);
            this.pageInfo.Controls.Add(this.ctl_alternatefax);
            this.pageInfo.Controls.Add(this.ctl_primaryfax);
            this.pageInfo.Controls.Add(this.ctl_alternatephone);
            this.pageInfo.Controls.Add(this.ctl_primaryphoneextension);
            this.pageInfo.Controls.Add(this.ctl_primaryphone);
            this.pageInfo.Controls.Add(this.ctl_jobtype);
            this.pageInfo.Controls.Add(this.ctl_contacttype);
            this.pageInfo.Location = new System.Drawing.Point(4, 22);
            this.pageInfo.Name = "pageInfo";
            this.pageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.pageInfo.Size = new System.Drawing.Size(749, 333);
            this.pageInfo.TabIndex = 0;
            this.pageInfo.Text = "Info";
            this.pageInfo.UseVisualStyleBackColor = true;
            // 
            // ctl_contacttype
            // 
            this.ctl_contacttype.AllCaps = false;
            this.ctl_contacttype.AllowEdit = false;
            this.ctl_contacttype.BackColor = System.Drawing.Color.Transparent;
            this.ctl_contacttype.Bold = false;
            this.ctl_contacttype.Caption = "Contact Type";
            this.ctl_contacttype.Changed = false;
            this.ctl_contacttype.ListName = "contacttype";
            this.ctl_contacttype.Location = new System.Drawing.Point(295, 234);
            this.ctl_contacttype.Name = "ctl_contacttype";
            this.ctl_contacttype.SimpleList = null;
            this.ctl_contacttype.Size = new System.Drawing.Size(443, 48);
            this.ctl_contacttype.TabIndex = 2;
            this.ctl_contacttype.UseParentBackColor = true;
            this.ctl_contacttype.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_contacttype.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_contacttype.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_contacttype.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_contacttype.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_contacttype.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_contacttype.zz_OriginalDesign = true;
            this.ctl_contacttype.zz_ShowNeedsSaveColor = true;
            this.ctl_contacttype.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_contacttype.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_contacttype.zz_UseGlobalColor = false;
            this.ctl_contacttype.zz_UseGlobalFont = false;
            // 
            // ctl_jobtype
            // 
            this.ctl_jobtype.AllCaps = false;
            this.ctl_jobtype.BackColor = System.Drawing.Color.Transparent;
            this.ctl_jobtype.Bold = false;
            this.ctl_jobtype.Caption = "Job Type";
            this.ctl_jobtype.Changed = false;
            this.ctl_jobtype.IsEmail = false;
            this.ctl_jobtype.IsURL = false;
            this.ctl_jobtype.Location = new System.Drawing.Point(560, 146);
            this.ctl_jobtype.Name = "ctl_jobtype";
            this.ctl_jobtype.PasswordChar = '\0';
            this.ctl_jobtype.Size = new System.Drawing.Size(178, 47);
            this.ctl_jobtype.TabIndex = 16;
            this.ctl_jobtype.UseParentBackColor = true;
            this.ctl_jobtype.zz_Enabled = true;
            this.ctl_jobtype.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_jobtype.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_jobtype.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_jobtype.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_jobtype.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_jobtype.zz_OriginalDesign = true;
            this.ctl_jobtype.zz_ShowLinkButton = false;
            this.ctl_jobtype.zz_ShowNeedsSaveColor = true;
            this.ctl_jobtype.zz_Text = "";
            this.ctl_jobtype.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_jobtype.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_jobtype.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_jobtype.zz_UseGlobalColor = false;
            this.ctl_jobtype.zz_UseGlobalFont = false;
            // 
            // ctl_primaryphone
            // 
            this.ctl_primaryphone.AllCaps = false;
            this.ctl_primaryphone.BackColor = System.Drawing.Color.Transparent;
            this.ctl_primaryphone.Bold = false;
            this.ctl_primaryphone.Caption = "Phone Number";
            this.ctl_primaryphone.Changed = false;
            this.ctl_primaryphone.IsEmail = false;
            this.ctl_primaryphone.IsURL = false;
            this.ctl_primaryphone.Location = new System.Drawing.Point(295, -1);
            this.ctl_primaryphone.Name = "ctl_primaryphone";
            this.ctl_primaryphone.PasswordChar = '\0';
            this.ctl_primaryphone.Size = new System.Drawing.Size(162, 47);
            this.ctl_primaryphone.TabIndex = 9;
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
            // ctl_primaryphoneextension
            // 
            this.ctl_primaryphoneextension.AllCaps = false;
            this.ctl_primaryphoneextension.BackColor = System.Drawing.Color.Transparent;
            this.ctl_primaryphoneextension.Bold = false;
            this.ctl_primaryphoneextension.Caption = "Ext.";
            this.ctl_primaryphoneextension.Changed = false;
            this.ctl_primaryphoneextension.IsEmail = false;
            this.ctl_primaryphoneextension.IsURL = false;
            this.ctl_primaryphoneextension.Location = new System.Drawing.Point(463, -1);
            this.ctl_primaryphoneextension.Name = "ctl_primaryphoneextension";
            this.ctl_primaryphoneextension.PasswordChar = '\0';
            this.ctl_primaryphoneextension.Size = new System.Drawing.Size(67, 47);
            this.ctl_primaryphoneextension.TabIndex = 10;
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
            // ctl_alternatephone
            // 
            this.ctl_alternatephone.AllCaps = false;
            this.ctl_alternatephone.BackColor = System.Drawing.Color.Transparent;
            this.ctl_alternatephone.Bold = false;
            this.ctl_alternatephone.Caption = "Alternate Phone";
            this.ctl_alternatephone.Changed = false;
            this.ctl_alternatephone.IsEmail = false;
            this.ctl_alternatephone.IsURL = false;
            this.ctl_alternatephone.Location = new System.Drawing.Point(560, -1);
            this.ctl_alternatephone.Name = "ctl_alternatephone";
            this.ctl_alternatephone.PasswordChar = '\0';
            this.ctl_alternatephone.Size = new System.Drawing.Size(181, 47);
            this.ctl_alternatephone.TabIndex = 11;
            this.ctl_alternatephone.UseParentBackColor = true;
            this.ctl_alternatephone.zz_Enabled = true;
            this.ctl_alternatephone.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_alternatephone.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_alternatephone.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_alternatephone.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_alternatephone.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_alternatephone.zz_OriginalDesign = true;
            this.ctl_alternatephone.zz_ShowLinkButton = false;
            this.ctl_alternatephone.zz_ShowNeedsSaveColor = true;
            this.ctl_alternatephone.zz_Text = "";
            this.ctl_alternatephone.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_alternatephone.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_alternatephone.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_alternatephone.zz_UseGlobalColor = false;
            this.ctl_alternatephone.zz_UseGlobalFont = false;
            // 
            // ctl_primaryfax
            // 
            this.ctl_primaryfax.AllCaps = false;
            this.ctl_primaryfax.BackColor = System.Drawing.Color.Transparent;
            this.ctl_primaryfax.Bold = false;
            this.ctl_primaryfax.Caption = "Fax Number";
            this.ctl_primaryfax.Changed = false;
            this.ctl_primaryfax.IsEmail = false;
            this.ctl_primaryfax.IsURL = false;
            this.ctl_primaryfax.Location = new System.Drawing.Point(295, 47);
            this.ctl_primaryfax.Name = "ctl_primaryfax";
            this.ctl_primaryfax.PasswordChar = '\0';
            this.ctl_primaryfax.Size = new System.Drawing.Size(235, 47);
            this.ctl_primaryfax.TabIndex = 12;
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
            // ctl_alternatefax
            // 
            this.ctl_alternatefax.AllCaps = false;
            this.ctl_alternatefax.BackColor = System.Drawing.Color.Transparent;
            this.ctl_alternatefax.Bold = false;
            this.ctl_alternatefax.Caption = "Alternate Fax";
            this.ctl_alternatefax.Changed = false;
            this.ctl_alternatefax.IsEmail = false;
            this.ctl_alternatefax.IsURL = false;
            this.ctl_alternatefax.Location = new System.Drawing.Point(560, 47);
            this.ctl_alternatefax.Name = "ctl_alternatefax";
            this.ctl_alternatefax.PasswordChar = '\0';
            this.ctl_alternatefax.Size = new System.Drawing.Size(181, 47);
            this.ctl_alternatefax.TabIndex = 13;
            this.ctl_alternatefax.UseParentBackColor = true;
            this.ctl_alternatefax.zz_Enabled = true;
            this.ctl_alternatefax.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_alternatefax.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_alternatefax.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_alternatefax.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_alternatefax.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_alternatefax.zz_OriginalDesign = true;
            this.ctl_alternatefax.zz_ShowLinkButton = false;
            this.ctl_alternatefax.zz_ShowNeedsSaveColor = true;
            this.ctl_alternatefax.zz_Text = "";
            this.ctl_alternatefax.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_alternatefax.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_alternatefax.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_alternatefax.zz_UseGlobalColor = false;
            this.ctl_alternatefax.zz_UseGlobalFont = false;
            // 
            // ctl_primaryemailaddress
            // 
            this.ctl_primaryemailaddress.AllCaps = false;
            this.ctl_primaryemailaddress.BackColor = System.Drawing.Color.Transparent;
            this.ctl_primaryemailaddress.Bold = false;
            this.ctl_primaryemailaddress.Caption = "Email Address";
            this.ctl_primaryemailaddress.Changed = false;
            this.ctl_primaryemailaddress.IsEmail = true;
            this.ctl_primaryemailaddress.IsURL = false;
            this.ctl_primaryemailaddress.Location = new System.Drawing.Point(295, 97);
            this.ctl_primaryemailaddress.Name = "ctl_primaryemailaddress";
            this.ctl_primaryemailaddress.PasswordChar = '\0';
            this.ctl_primaryemailaddress.Size = new System.Drawing.Size(443, 47);
            this.ctl_primaryemailaddress.TabIndex = 14;
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
            // ctl_primarywebaddress
            // 
            this.ctl_primarywebaddress.AllCaps = false;
            this.ctl_primarywebaddress.BackColor = System.Drawing.Color.Transparent;
            this.ctl_primarywebaddress.Bold = false;
            this.ctl_primarywebaddress.Caption = "Web Address";
            this.ctl_primarywebaddress.Changed = false;
            this.ctl_primarywebaddress.IsEmail = false;
            this.ctl_primarywebaddress.IsURL = true;
            this.ctl_primarywebaddress.Location = new System.Drawing.Point(295, 145);
            this.ctl_primarywebaddress.Name = "ctl_primarywebaddress";
            this.ctl_primarywebaddress.PasswordChar = '\0';
            this.ctl_primarywebaddress.Size = new System.Drawing.Size(217, 47);
            this.ctl_primarywebaddress.TabIndex = 15;
            this.ctl_primarywebaddress.UseParentBackColor = true;
            this.ctl_primarywebaddress.zz_Enabled = true;
            this.ctl_primarywebaddress.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_primarywebaddress.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_primarywebaddress.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_primarywebaddress.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_primarywebaddress.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_primarywebaddress.zz_OriginalDesign = true;
            this.ctl_primarywebaddress.zz_ShowLinkButton = false;
            this.ctl_primarywebaddress.zz_ShowNeedsSaveColor = true;
            this.ctl_primarywebaddress.zz_Text = "";
            this.ctl_primarywebaddress.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_primarywebaddress.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_primarywebaddress.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_primarywebaddress.zz_UseGlobalColor = false;
            this.ctl_primarywebaddress.zz_UseGlobalFont = false;
            // 
            // ctl_source
            // 
            this.ctl_source.AllCaps = false;
            this.ctl_source.AllowEdit = false;
            this.ctl_source.BackColor = System.Drawing.Color.Transparent;
            this.ctl_source.Bold = false;
            this.ctl_source.Caption = "Source";
            this.ctl_source.Changed = false;
            this.ctl_source.ListName = "wherefoundcompany";
            this.ctl_source.Location = new System.Drawing.Point(295, 189);
            this.ctl_source.Name = "ctl_source";
            this.ctl_source.SimpleList = null;
            this.ctl_source.Size = new System.Drawing.Size(443, 48);
            this.ctl_source.TabIndex = 17;
            this.ctl_source.UseParentBackColor = true;
            this.ctl_source.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_source.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_source.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_source.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_source.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_source.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_source.zz_OriginalDesign = true;
            this.ctl_source.zz_ShowNeedsSaveColor = true;
            this.ctl_source.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_source.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_source.zz_UseGlobalColor = false;
            this.ctl_source.zz_UseGlobalFont = false;
            // 
            // gb
            // 
            this.gb.Controls.Add(this.ctl_bad_data);
            this.gb.Controls.Add(this.ctl_companyname);
            this.gb.Controls.Add(this.ctl_adrcountry);
            this.gb.Controls.Add(this.ctl_adrstate);
            this.gb.Controls.Add(this.cmdPick);
            this.gb.Controls.Add(this.ctl_adrzip);
            this.gb.Controls.Add(this.ctl_adrcity);
            this.gb.Controls.Add(this.ctl_line3);
            this.gb.Controls.Add(this.ctl_line2);
            this.gb.Controls.Add(this.ctl_line1);
            this.gb.Location = new System.Drawing.Point(9, 6);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(280, 321);
            this.gb.TabIndex = 16;
            this.gb.TabStop = false;
            this.gb.Text = "Direct Mailing Address";
            // 
            // ctl_line1
            // 
            this.ctl_line1.AllCaps = false;
            this.ctl_line1.BackColor = System.Drawing.Color.Transparent;
            this.ctl_line1.Bold = false;
            this.ctl_line1.Caption = "Line 1";
            this.ctl_line1.Changed = false;
            this.ctl_line1.IsEmail = false;
            this.ctl_line1.IsURL = false;
            this.ctl_line1.Location = new System.Drawing.Point(6, 56);
            this.ctl_line1.Name = "ctl_line1";
            this.ctl_line1.PasswordChar = '\0';
            this.ctl_line1.Size = new System.Drawing.Size(268, 47);
            this.ctl_line1.TabIndex = 3;
            this.ctl_line1.UseParentBackColor = true;
            this.ctl_line1.zz_Enabled = true;
            this.ctl_line1.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_line1.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_line1.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_line1.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
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
            this.ctl_line2.BackColor = System.Drawing.Color.Transparent;
            this.ctl_line2.Bold = false;
            this.ctl_line2.Caption = "Line 2";
            this.ctl_line2.Changed = false;
            this.ctl_line2.IsEmail = false;
            this.ctl_line2.IsURL = false;
            this.ctl_line2.Location = new System.Drawing.Point(6, 97);
            this.ctl_line2.Name = "ctl_line2";
            this.ctl_line2.PasswordChar = '\0';
            this.ctl_line2.Size = new System.Drawing.Size(268, 47);
            this.ctl_line2.TabIndex = 4;
            this.ctl_line2.UseParentBackColor = true;
            this.ctl_line2.zz_Enabled = true;
            this.ctl_line2.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_line2.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_line2.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_line2.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
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
            this.ctl_line3.BackColor = System.Drawing.Color.Transparent;
            this.ctl_line3.Bold = false;
            this.ctl_line3.Caption = "Line 3";
            this.ctl_line3.Changed = false;
            this.ctl_line3.IsEmail = false;
            this.ctl_line3.IsURL = false;
            this.ctl_line3.Location = new System.Drawing.Point(6, 139);
            this.ctl_line3.Name = "ctl_line3";
            this.ctl_line3.PasswordChar = '\0';
            this.ctl_line3.Size = new System.Drawing.Size(268, 47);
            this.ctl_line3.TabIndex = 5;
            this.ctl_line3.UseParentBackColor = true;
            this.ctl_line3.zz_Enabled = true;
            this.ctl_line3.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_line3.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_line3.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_line3.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
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
            this.ctl_adrcity.BackColor = System.Drawing.Color.Transparent;
            this.ctl_adrcity.Bold = false;
            this.ctl_adrcity.Caption = "City";
            this.ctl_adrcity.Changed = false;
            this.ctl_adrcity.IsEmail = false;
            this.ctl_adrcity.IsURL = false;
            this.ctl_adrcity.Location = new System.Drawing.Point(6, 181);
            this.ctl_adrcity.Name = "ctl_adrcity";
            this.ctl_adrcity.PasswordChar = '\0';
            this.ctl_adrcity.Size = new System.Drawing.Size(268, 47);
            this.ctl_adrcity.TabIndex = 6;
            this.ctl_adrcity.UseParentBackColor = true;
            this.ctl_adrcity.zz_Enabled = true;
            this.ctl_adrcity.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_adrcity.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_adrcity.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_adrcity.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
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
            this.ctl_adrzip.BackColor = System.Drawing.Color.Transparent;
            this.ctl_adrzip.Bold = false;
            this.ctl_adrzip.Caption = "Zip Code";
            this.ctl_adrzip.Changed = false;
            this.ctl_adrzip.IsEmail = false;
            this.ctl_adrzip.IsURL = false;
            this.ctl_adrzip.Location = new System.Drawing.Point(179, 232);
            this.ctl_adrzip.Name = "ctl_adrzip";
            this.ctl_adrzip.PasswordChar = '\0';
            this.ctl_adrzip.Size = new System.Drawing.Size(95, 47);
            this.ctl_adrzip.TabIndex = 8;
            this.ctl_adrzip.UseParentBackColor = true;
            this.ctl_adrzip.zz_Enabled = true;
            this.ctl_adrzip.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_adrzip.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_adrzip.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_adrzip.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
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
            // cmdPick
            // 
            this.cmdPick.Location = new System.Drawing.Point(208, 56);
            this.cmdPick.Name = "cmdPick";
            this.cmdPick.Size = new System.Drawing.Size(63, 19);
            this.cmdPick.TabIndex = 20;
            this.cmdPick.Text = "Pick";
            this.cmdPick.UseVisualStyleBackColor = true;
            this.cmdPick.Click += new System.EventHandler(this.cmdPick_Click);
            // 
            // ctl_adrstate
            // 
            this.ctl_adrstate.AllCaps = false;
            this.ctl_adrstate.AllowEdit = false;
            this.ctl_adrstate.BackColor = System.Drawing.Color.Transparent;
            this.ctl_adrstate.Bold = false;
            this.ctl_adrstate.Caption = "State";
            this.ctl_adrstate.Changed = false;
            this.ctl_adrstate.ListName = null;
            this.ctl_adrstate.Location = new System.Drawing.Point(6, 231);
            this.ctl_adrstate.Name = "ctl_adrstate";
            this.ctl_adrstate.SimpleList = "AL|AK|AS|AZ|AR|CA|CO|CT|DC|DE|FL|FM|GA|GU|HI|IA|ID|IL|IN|KS|KY|LA|MD|MA|ME|MH|MI|" +
    "MN|MP|MS|MO|MT|NC|ND|NE|NH|NJ|NM|NV|NY|OH|OK|OR|PA|PR|RI|SC|SD|TN|TX|UT|VA|VI|VT" +
    "|WA|WI|WV|WY";
            this.ctl_adrstate.Size = new System.Drawing.Size(165, 49);
            this.ctl_adrstate.TabIndex = 7;
            this.ctl_adrstate.UseParentBackColor = true;
            this.ctl_adrstate.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_adrstate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_adrstate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_adrstate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_adrstate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_adrstate.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_adrstate.zz_OriginalDesign = true;
            this.ctl_adrstate.zz_ShowNeedsSaveColor = true;
            this.ctl_adrstate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_adrstate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_adrstate.zz_UseGlobalColor = false;
            this.ctl_adrstate.zz_UseGlobalFont = false;
            // 
            // ctl_adrcountry
            // 
            this.ctl_adrcountry.AllCaps = false;
            this.ctl_adrcountry.AllowEdit = false;
            this.ctl_adrcountry.BackColor = System.Drawing.Color.Transparent;
            this.ctl_adrcountry.Bold = false;
            this.ctl_adrcountry.Caption = "Country";
            this.ctl_adrcountry.Changed = false;
            this.ctl_adrcountry.ListName = null;
            this.ctl_adrcountry.Location = new System.Drawing.Point(6, 275);
            this.ctl_adrcountry.Name = "ctl_adrcountry";
            this.ctl_adrcountry.SimpleList = resources.GetString("ctl_adrcountry.SimpleList");
            this.ctl_adrcountry.Size = new System.Drawing.Size(265, 42);
            this.ctl_adrcountry.TabIndex = 9;
            this.ctl_adrcountry.UseParentBackColor = true;
            this.ctl_adrcountry.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_adrcountry.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_adrcountry.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_adrcountry.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_adrcountry.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_adrcountry.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_adrcountry.zz_OriginalDesign = true;
            this.ctl_adrcountry.zz_ShowNeedsSaveColor = true;
            this.ctl_adrcountry.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_adrcountry.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_adrcountry.zz_UseGlobalColor = false;
            this.ctl_adrcountry.zz_UseGlobalFont = false;
            // 
            // ctl_companyname
            // 
            this.ctl_companyname.AllCaps = false;
            this.ctl_companyname.BackColor = System.Drawing.Color.White;
            this.ctl_companyname.Bold = true;
            this.ctl_companyname.Caption = "Company Display Name ( for marketing only )";
            this.ctl_companyname.Changed = false;
            this.ctl_companyname.IsEmail = false;
            this.ctl_companyname.IsURL = false;
            this.ctl_companyname.Location = new System.Drawing.Point(6, 14);
            this.ctl_companyname.Name = "ctl_companyname";
            this.ctl_companyname.PasswordChar = '\0';
            this.ctl_companyname.Size = new System.Drawing.Size(268, 40);
            this.ctl_companyname.TabIndex = 38;
            this.ctl_companyname.UseParentBackColor = true;
            this.ctl_companyname.zz_Enabled = true;
            this.ctl_companyname.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_companyname.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_companyname.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_companyname.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // ctl_bad_data
            // 
            this.ctl_bad_data.BackColor = System.Drawing.Color.Transparent;
            this.ctl_bad_data.Bold = false;
            this.ctl_bad_data.Caption = "Bad Mailing Address";
            this.ctl_bad_data.Changed = false;
            this.ctl_bad_data.ForeColor = System.Drawing.Color.Red;
            this.ctl_bad_data.Location = new System.Drawing.Point(79, 56);
            this.ctl_bad_data.Name = "ctl_bad_data";
            this.ctl_bad_data.Size = new System.Drawing.Size(122, 18);
            this.ctl_bad_data.TabIndex = 12;
            this.ctl_bad_data.UseParentBackColor = true;
            this.ctl_bad_data.zz_CheckValue = false;
            this.ctl_bad_data.zz_LabelColor = System.Drawing.Color.Red;
            this.ctl_bad_data.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_bad_data.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Left;
            this.ctl_bad_data.zz_OriginalDesign = false;
            this.ctl_bad_data.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_alternate_names
            // 
            this.ctl_alternate_names.AllCaps = false;
            this.ctl_alternate_names.BackColor = System.Drawing.Color.Transparent;
            this.ctl_alternate_names.Bold = false;
            this.ctl_alternate_names.Caption = "Alternate Names";
            this.ctl_alternate_names.Changed = false;
            this.ctl_alternate_names.IsEmail = false;
            this.ctl_alternate_names.IsURL = true;
            this.ctl_alternate_names.Location = new System.Drawing.Point(295, 280);
            this.ctl_alternate_names.Name = "ctl_alternate_names";
            this.ctl_alternate_names.PasswordChar = '\0';
            this.ctl_alternate_names.Size = new System.Drawing.Size(443, 47);
            this.ctl_alternate_names.TabIndex = 18;
            this.ctl_alternate_names.UseParentBackColor = true;
            this.ctl_alternate_names.zz_Enabled = true;
            this.ctl_alternate_names.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_alternate_names.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_alternate_names.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_alternate_names.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_alternate_names.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_alternate_names.zz_OriginalDesign = true;
            this.ctl_alternate_names.zz_ShowLinkButton = false;
            this.ctl_alternate_names.zz_ShowNeedsSaveColor = true;
            this.ctl_alternate_names.zz_Text = "";
            this.ctl_alternate_names.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_alternate_names.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_alternate_names.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_alternate_names.zz_UseGlobalColor = false;
            this.ctl_alternate_names.zz_UseGlobalFont = false;
            // 
            // lblCheckPhone
            // 
            this.lblCheckPhone.AutoSize = true;
            this.lblCheckPhone.Location = new System.Drawing.Point(422, 3);
            this.lblCheckPhone.Name = "lblCheckPhone";
            this.lblCheckPhone.Size = new System.Drawing.Size(37, 13);
            this.lblCheckPhone.TabIndex = 19;
            this.lblCheckPhone.TabStop = true;
            this.lblCheckPhone.Text = "check";
            this.lblCheckPhone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCheckPhone_LinkClicked);
            // 
            // lblCheckAlternatePhone
            // 
            this.lblCheckAlternatePhone.AutoSize = true;
            this.lblCheckAlternatePhone.Location = new System.Drawing.Point(705, 3);
            this.lblCheckAlternatePhone.Name = "lblCheckAlternatePhone";
            this.lblCheckAlternatePhone.Size = new System.Drawing.Size(37, 13);
            this.lblCheckAlternatePhone.TabIndex = 20;
            this.lblCheckAlternatePhone.TabStop = true;
            this.lblCheckAlternatePhone.Text = "check";
            this.lblCheckAlternatePhone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCheckAlternatePhone_LinkClicked);
            // 
            // ts
            // 
            this.ts.Controls.Add(this.pageInfo);
            this.ts.Controls.Add(this.pageMoreInfo);
            this.ts.Controls.Add(this.pageCalls);
            this.ts.Controls.Add(this.pageReqs);
            this.ts.Controls.Add(this.pageQuotes);
            this.ts.Controls.Add(this.pageBids);
            this.ts.Controls.Add(this.pageOrders);
            this.ts.Controls.Add(this.pageFeedback);
            this.ts.Controls.Add(this.pagePhoneNumbers);
            this.ts.Controls.Add(this.pageCallLogs);
            this.ts.Controls.Add(this.tabAffiliate);
            this.ts.Location = new System.Drawing.Point(12, 97);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(757, 359);
            this.ts.TabIndex = 25;
            this.ts.SelectedIndexChanged += new System.EventHandler(this.ts_SelectedIndexChanged);
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
            this.lvCalls.Location = new System.Drawing.Point(0, 0);
            this.lvCalls.MultiSelect = true;
            this.lvCalls.Name = "lvCalls";
            this.lvCalls.Size = new System.Drawing.Size(749, 333);
            this.lvCalls.SuppressSelectionChanged = false;
            this.lvCalls.TabIndex = 2;
            this.lvCalls.zz_OpenColumnMenu = false;
            this.lvCalls.zz_OrderLineType = "";
            this.lvCalls.zz_ShowAutoRefresh = true;
            this.lvCalls.zz_ShowUnlimited = true;
            this.lvCalls.AboutToAdd += new NewMethod.AddHandler(this.lvCalls_AboutToAdd);
            // 
            // result_orders
            // 
            this.result_orders.AddCaption = "Add New";
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
            this.result_orders.Location = new System.Drawing.Point(127, 6);
            this.result_orders.MultiSelect = true;
            this.result_orders.Name = "result_orders";
            this.result_orders.Size = new System.Drawing.Size(527, 184);
            this.result_orders.SuppressSelectionChanged = false;
            this.result_orders.TabIndex = 1;
            this.result_orders.zz_OpenColumnMenu = false;
            this.result_orders.zz_OrderLineType = "";
            this.result_orders.zz_ShowAutoRefresh = true;
            this.result_orders.zz_ShowUnlimited = true;
            // 
            // result_bids
            // 
            this.result_bids.AddCaption = "Add New Bid";
            this.result_bids.AllowActions = true;
            this.result_bids.AllowAdd = true;
            this.result_bids.AllowDelete = true;
            this.result_bids.AllowDeleteAlways = false;
            this.result_bids.AllowDrop = true;
            this.result_bids.AllowOnlyOpenDelete = false;
            this.result_bids.AlternateConnection = null;
            this.result_bids.BackColor = System.Drawing.Color.White;
            this.result_bids.Caption = "";
            this.result_bids.CurrentTemplate = null;
            this.result_bids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.result_bids.ExtraClassInfo = "";
            this.result_bids.Location = new System.Drawing.Point(3, 3);
            this.result_bids.MultiSelect = true;
            this.result_bids.Name = "result_bids";
            this.result_bids.Size = new System.Drawing.Size(743, 327);
            this.result_bids.SuppressSelectionChanged = false;
            this.result_bids.TabIndex = 2;
            this.result_bids.zz_OpenColumnMenu = false;
            this.result_bids.zz_OrderLineType = "";
            this.result_bids.zz_ShowAutoRefresh = true;
            this.result_bids.zz_ShowUnlimited = true;
            this.result_bids.AboutToAdd += new NewMethod.AddHandler(this.result_bids_AboutToAdd);
            // 
            // result_reqs
            // 
            this.result_reqs.AddCaption = "Add New Req";
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
            this.result_reqs.Size = new System.Drawing.Size(743, 327);
            this.result_reqs.SuppressSelectionChanged = false;
            this.result_reqs.TabIndex = 0;
            this.result_reqs.zz_OpenColumnMenu = false;
            this.result_reqs.zz_OrderLineType = "";
            this.result_reqs.zz_ShowAutoRefresh = true;
            this.result_reqs.zz_ShowUnlimited = true;
            this.result_reqs.AboutToAdd += new NewMethod.AddHandler(this.result_reqs_AboutToAdd);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ctStub
            // 
            this.ctStub.BackColor = System.Drawing.SystemColors.ControlText;
            this.ctStub.Location = new System.Drawing.Point(452, 15);
            this.ctStub.Name = "ctStub";
            this.ctStub.Size = new System.Drawing.Size(133, 41);
            this.ctStub.TabIndex = 24;
            // 
            // ctl_affiliate_id
            // 
            this.ctl_affiliate_id.AllCaps = false;
            this.ctl_affiliate_id.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_affiliate_id.Bold = false;
            this.ctl_affiliate_id.Caption = "Affiliate ID (Email)";
            this.ctl_affiliate_id.Changed = false;
            this.ctl_affiliate_id.IsEmail = false;
            this.ctl_affiliate_id.IsURL = false;
            this.ctl_affiliate_id.Location = new System.Drawing.Point(6, 6);
            this.ctl_affiliate_id.Name = "ctl_affiliate_id";
            this.ctl_affiliate_id.PasswordChar = '\0';
            this.ctl_affiliate_id.Size = new System.Drawing.Size(237, 40);
            this.ctl_affiliate_id.TabIndex = 4;
            this.ctl_affiliate_id.UseParentBackColor = false;
            this.ctl_affiliate_id.zz_Enabled = true;
            this.ctl_affiliate_id.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_affiliate_id.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_affiliate_id.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_affiliate_id.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_affiliate_id.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_affiliate_id.zz_OriginalDesign = true;
            this.ctl_affiliate_id.zz_ShowLinkButton = false;
            this.ctl_affiliate_id.zz_ShowNeedsSaveColor = true;
            this.ctl_affiliate_id.zz_Text = "";
            this.ctl_affiliate_id.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_affiliate_id.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_affiliate_id.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_affiliate_id.zz_UseGlobalColor = false;
            this.ctl_affiliate_id.zz_UseGlobalFont = false;
            // 
            // ctl_affiliate_name
            // 
            this.ctl_affiliate_name.AllCaps = false;
            this.ctl_affiliate_name.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_affiliate_name.Bold = false;
            this.ctl_affiliate_name.Caption = "Affiliate Name";
            this.ctl_affiliate_name.Changed = false;
            this.ctl_affiliate_name.IsEmail = false;
            this.ctl_affiliate_name.IsURL = false;
            this.ctl_affiliate_name.Location = new System.Drawing.Point(6, 52);
            this.ctl_affiliate_name.Name = "ctl_affiliate_name";
            this.ctl_affiliate_name.PasswordChar = '\0';
            this.ctl_affiliate_name.Size = new System.Drawing.Size(237, 40);
            this.ctl_affiliate_name.TabIndex = 5;
            this.ctl_affiliate_name.UseParentBackColor = false;
            this.ctl_affiliate_name.zz_Enabled = true;
            this.ctl_affiliate_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_affiliate_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_affiliate_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_affiliate_name.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_affiliate_name.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_affiliate_name.zz_OriginalDesign = true;
            this.ctl_affiliate_name.zz_ShowLinkButton = false;
            this.ctl_affiliate_name.zz_ShowNeedsSaveColor = true;
            this.ctl_affiliate_name.zz_Text = "";
            this.ctl_affiliate_name.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_affiliate_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_affiliate_name.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_affiliate_name.zz_UseGlobalColor = false;
            this.ctl_affiliate_name.zz_UseGlobalFont = false;
            // 
            // view_companycontact
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbl_trait);
            this.Controls.Add(this.lbl_traits);
            this.Controls.Add(this.lbl_expect);
            this.Controls.Add(this.lbl_expectation);
            this.Controls.Add(this.lbl_interact);
            this.Controls.Add(this.lbl_interaction);
            this.Controls.Add(this.ctl_personality_type);
            this.Controls.Add(this.lblClearDuplicateNotes);
            this.Controls.Add(this.pNotes);
            this.Controls.Add(this.result_notes);
            this.Controls.Add(this.ctl_isvendor);
            this.Controls.Add(this.cmdUnClaim);
            this.Controls.Add(this.cmdAssign);
            this.Controls.Add(this.ctl_spam_graphic);
            this.Controls.Add(this.ctl_contactname);
            this.Controls.Add(this.ts);
            this.Controls.Add(this.ctStub);
            this.Controls.Add(this.ctl_donotcall);
            this.Controls.Add(this.cmdClaim);
            this.Controls.Add(this.cmdRelease);
            this.Controls.Add(this.cmdBad);
            this.Controls.Add(this.agent);
            this.Controls.Add(this.ctl_isactive);
            this.Controls.Add(this.ctl_iscustomer);
            this.Controls.Add(this.ctl_donotemail);
            this.Controls.Add(this.ctl_donotmail);
            this.Controls.Add(this.ctl_donotpromote);
            this.Controls.Add(this.ctl_contactnotes);
            this.Name = "view_companycontact";
            this.Size = new System.Drawing.Size(1047, 765);
            this.Resize += new System.EventHandler(this.view_companycontact_Resize);
            this.Controls.SetChildIndex(this.ctl_contactnotes, 0);
            this.Controls.SetChildIndex(this.ctl_donotpromote, 0);
            this.Controls.SetChildIndex(this.ctl_donotmail, 0);
            this.Controls.SetChildIndex(this.ctl_donotemail, 0);
            this.Controls.SetChildIndex(this.ctl_iscustomer, 0);
            this.Controls.SetChildIndex(this.ctl_isactive, 0);
            this.Controls.SetChildIndex(this.agent, 0);
            this.Controls.SetChildIndex(this.cmdBad, 0);
            this.Controls.SetChildIndex(this.cmdRelease, 0);
            this.Controls.SetChildIndex(this.cmdClaim, 0);
            this.Controls.SetChildIndex(this.ctl_donotcall, 0);
            this.Controls.SetChildIndex(this.ctStub, 0);
            this.Controls.SetChildIndex(this.ts, 0);
            this.Controls.SetChildIndex(this.ctl_contactname, 0);
            this.Controls.SetChildIndex(this.ctl_spam_graphic, 0);
            this.Controls.SetChildIndex(this.cmdAssign, 0);
            this.Controls.SetChildIndex(this.cmdUnClaim, 0);
            this.Controls.SetChildIndex(this.ctl_isvendor, 0);
            this.Controls.SetChildIndex(this.result_notes, 0);
            this.Controls.SetChildIndex(this.pNotes, 0);
            this.Controls.SetChildIndex(this.lblClearDuplicateNotes, 0);
            this.Controls.SetChildIndex(this.ctl_personality_type, 0);
            this.Controls.SetChildIndex(this.lbl_interaction, 0);
            this.Controls.SetChildIndex(this.lbl_interact, 0);
            this.Controls.SetChildIndex(this.lbl_expectation, 0);
            this.Controls.SetChildIndex(this.lbl_expect, 0);
            this.Controls.SetChildIndex(this.lbl_traits, 0);
            this.Controls.SetChildIndex(this.lbl_trait, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.pNotes.ResumeLayout(false);
            this.tabAffiliate.ResumeLayout(false);
            this.pageCallLogs.ResumeLayout(false);
            this.pagePhoneNumbers.ResumeLayout(false);
            this.gbPhone.ResumeLayout(false);
            this.gbPhone.PerformLayout();
            this.pageFeedback.ResumeLayout(false);
            this.pageOrders.ResumeLayout(false);
            this.gbOrderOptions.ResumeLayout(false);
            this.gbOrderOptions.PerformLayout();
            this.pageBids.ResumeLayout(false);
            this.pageReqs.ResumeLayout(false);
            this.pageCalls.ResumeLayout(false);
            this.pageMoreInfo.ResumeLayout(false);
            this.pageInfo.ResumeLayout(false);
            this.pageInfo.PerformLayout();
            this.gb.ResumeLayout(false);
            this.ts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private nEdit_String ctl_contactname;
        private nEdit_Boolean ctl_donotmail;
        private nEdit_Boolean ctl_donotemail;
        private nEdit_Boolean ctl_donotpromote;
        private nEdit_Boolean ctl_donotcall;
        protected nEdit_Memo ctl_contactnotes;
        public nEdit_Boolean ctl_iscustomer;
        public nEdit_Boolean ctl_isvendor;
        public nEdit_Boolean ctl_isactive;
        public nEdit_Boolean ctl_spam_graphic;
        public nEdit_User agent;
        public System.Windows.Forms.Button cmdBad;
        public System.Windows.Forms.Button cmdRelease;
        public System.Windows.Forms.Button cmdClaim;
        public CompanyTypeStub ctStub;
        public System.Windows.Forms.Button cmdAssign;
        public System.Windows.Forms.Button cmdUnClaim;
        private System.Windows.Forms.Button cmdSE;
        private System.Windows.Forms.Button cmdBadEmail;
        private System.Windows.Forms.Button cmdWrongNumber;
        private System.Windows.Forms.Button cmdVoiceMail;
        private System.Windows.Forms.Button cmdNoAnswer;
        private System.Windows.Forms.Button cmdSentEmail;
        private System.Windows.Forms.Button cmdFollowUp;
        protected nList result_notes;
        protected System.Windows.Forms.LinkLabel lblClearDuplicateNotes;
        protected System.Windows.Forms.Panel pNotes;
        private nEdit_List ctl_personality_type;
        private System.Windows.Forms.Label lbl_interaction;
        private System.Windows.Forms.Label lbl_interact;
        private System.Windows.Forms.Label lbl_expect;
        private System.Windows.Forms.Label lbl_expectation;
        private System.Windows.Forms.Label lbl_trait;
        private System.Windows.Forms.Label lbl_traits;
        private System.Windows.Forms.TabPage tabAffiliate;
        private System.Windows.Forms.TabPage pageCallLogs;
        private nList lvCalls;
        private System.Windows.Forms.TabPage pagePhoneNumbers;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Button cmdAddPhone;
        private System.Windows.Forms.ListView lvPhone;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox gbPhone;
        protected System.Windows.Forms.Label lblWebPhone;
        private System.Windows.Forms.Button cmdChangePhone;
        private System.Windows.Forms.Button cmdViewPhone;
        private System.Windows.Forms.TabPage pageFeedback;
        private ToolsWin.BrowserPlain wbFeedback;
        private System.Windows.Forms.TabPage pageOrders;
        private System.Windows.Forms.GroupBox gbOrderOptions;
        private System.Windows.Forms.RadioButton optVRMA;
        private System.Windows.Forms.RadioButton optRMAs;
        private System.Windows.Forms.RadioButton optInvoices;
        private System.Windows.Forms.RadioButton optPurchase;
        private System.Windows.Forms.RadioButton optSales;
        private System.Windows.Forms.RadioButton optQuote;
        private System.Windows.Forms.RadioButton optAll;
        private nList result_orders;
        private System.Windows.Forms.TabPage pageBids;
        private nList result_bids;
        private System.Windows.Forms.TabPage pageQuotes;
        private System.Windows.Forms.TabPage pageReqs;
        private nList result_reqs;
        private System.Windows.Forms.TabPage pageCalls;
        private ToolsWin.BrowserPlain wbCalls;
        private System.Windows.Forms.TabPage pageMoreInfo;
        private nEdit_Boolean ctl_send_company_shipping_email_alert;
        private nEdit_Boolean ctl_isdefaultsales;
        private nEdit_Boolean ctl_isdefaultpurchaser;
        private nEdit_List ctl_timezone;
        private nEdit_String ctl_group_name;
        private nEdit_String ctl_alternateemail;
        private nEdit_Memo ctl_interests;
        private nEdit_List ctl_maritalstatus;
        private nEdit_List ctl_contactgender;
        private nEdit_Date ctl_birthdate;
        public System.Windows.Forms.TabPage pageInfo;
        private System.Windows.Forms.LinkLabel lblCheckAlternatePhone;
        private System.Windows.Forms.LinkLabel lblCheckPhone;
        private nEdit_String ctl_alternate_names;
        private System.Windows.Forms.GroupBox gb;
        private nEdit_Boolean ctl_bad_data;
        private nEdit_String ctl_companyname;
        private nEdit_List ctl_adrcountry;
        private nEdit_List ctl_adrstate;
        private System.Windows.Forms.Button cmdPick;
        private nEdit_String ctl_adrzip;
        private nEdit_String ctl_adrcity;
        private nEdit_String ctl_line3;
        private nEdit_String ctl_line2;
        private nEdit_String ctl_line1;
        private nEdit_List ctl_source;
        private nEdit_String ctl_primarywebaddress;
        protected nEdit_String ctl_primaryemailaddress;
        private nEdit_String ctl_alternatefax;
        private nEdit_String ctl_primaryfax;
        private nEdit_String ctl_alternatephone;
        private nEdit_String ctl_primaryphoneextension;
        private nEdit_String ctl_primaryphone;
        private nEdit_String ctl_jobtype;
        private nEdit_List ctl_contacttype;
        public System.Windows.Forms.TabControl ts;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private nEdit_String ctl_affiliate_name;
        private nEdit_String ctl_affiliate_id;
    }
}
