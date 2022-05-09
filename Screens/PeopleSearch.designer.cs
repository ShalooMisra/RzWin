using NewMethod;
using Tools.Database;

namespace Rz5.Win.Screens
{
    partial class PeopleSearch
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
                CompleteDispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PeopleSearch));
            this.IMList = new System.Windows.Forms.ImageList(this.components);
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.pOptions = new System.Windows.Forms.Panel();
            this.optBoth = new System.Windows.Forms.RadioButton();
            this.cmdClear = new System.Windows.Forms.Button();
            this.optCompany = new System.Windows.Forms.RadioButton();
            this.optContact = new System.Windows.Forms.RadioButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdParts = new System.Windows.Forms.Button();
            this.chkSwitchView = new System.Windows.Forms.CheckBox();
            this.ts = new System.Windows.Forms.TabControl();
            this.pageCompany = new System.Windows.Forms.TabPage();
            this.ctl_industry_segment = new NewMethod.nEdit_String();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.lblClearGroup = new System.Windows.Forms.LinkLabel();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblChoose = new System.Windows.Forms.LinkLabel();
            this.ctlBadMailingAddress = new NewMethod.nEdit_Boolean();
            this.pCTG = new System.Windows.Forms.Panel();
            this.ctlCallCutoff = new NewMethod.nEdit_Date();
            this.cmd3Month = new System.Windows.Forms.Button();
            this.lblPrevious = new System.Windows.Forms.LinkLabel();
            this.lblHot50 = new System.Windows.Forms.LinkLabel();
            this.chkProspectAccount = new System.Windows.Forms.CheckBox();
            this.lblNewSearch = new System.Windows.Forms.LinkLabel();
            this.lblClearAgents = new System.Windows.Forms.LinkLabel();
            this.lblChooseAgents = new System.Windows.Forms.LinkLabel();
            this.lblAgents = new System.Windows.Forms.Label();
            this.chkOrderByEmailDomain = new System.Windows.Forms.CheckBox();
            this.ctl_ReqCount = new NewMethod.nEdit_Number();
            this.lblHighlight = new System.Windows.Forms.LinkLabel();
            this.lblCurrentCallList = new System.Windows.Forms.LinkLabel();
            this.lblNextCallList = new System.Windows.Forms.LinkLabel();
            this.chkUnassigned = new System.Windows.Forms.CheckBox();
            this.ctlCallSchedule = new NewMethod.nEdit_List();
            this.cmdViewAgents = new System.Windows.Forms.Button();
            this.chkSales = new System.Windows.Forms.CheckBox();
            this.chkPurchases = new System.Windows.Forms.CheckBox();
            this.ctl_OrderDate = new NewMethod.nEdit_Date();
            this.ctl_CompanyName = new NewMethod.nEdit_String();
            this.ctl_ContactName = new NewMethod.nEdit_String();
            this.ctl_PhoneFaxEmail = new NewMethod.nEdit_String();
            this.ctl_PartNumber = new NewMethod.nEdit_String();
            this.ctl_Address = new NewMethod.nEdit_String();
            this.ctl_Source = new NewMethod.nEdit_List();
            this.ctl_CompanyType = new NewMethod.nEdit_List();
            this.ctl_OrderNumber = new NewMethod.nEdit_String();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.cmdBulkEmail = new System.Windows.Forms.Button();
            this.cmdExcelExport = new System.Windows.Forms.Button();
            this.lblAlt = new System.Windows.Forms.Label();
            this.lvAlt = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstFilters = new System.Windows.Forms.CheckedListBox();
            this.lblFilters = new System.Windows.Forms.Label();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.pOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ts.SuspendLayout();
            this.pageCompany.SuspendLayout();
            this.pCTG.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // xDisplay2
            // 
            this.xDisplay2.AboutToThrow += new Core.ShowHandler(this.xDisplay2_AboutToThrow);
            this.xDisplay2.AboutToAction += new NewMethod.ActionHandler(this.xDisplay2_AboutToAction);
            this.xDisplay2.FinishedAction += new NewMethod.ActionHandler(this.xDisplay_FinishedAction);
            // 
            // xDisplay
            // 
            this.xDisplay.AboutToThrow += new Core.ShowHandler(this.xDisplay_AboutToThrow);
            this.xDisplay.ObjectClicked += new NewMethod.ObjectClickHandler(this.xDisplay_ObjectClicked);
            this.xDisplay.FinishedFill += new NewMethod.FillHandler(this.xDisplay_FinishedFill);
            this.xDisplay.FinishedAction += new NewMethod.ActionHandler(this.xDisplay_FinishedAction);
            this.xDisplay.Load += new System.EventHandler(this.xDisplay_Load);
            // 
            // IMList
            // 
            this.IMList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IMList.ImageStream")));
            this.IMList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.IMList.Images.SetKeyName(0, "add_sm.bmp");
            this.IMList.Images.SetKeyName(1, "clear_sm.bmp");
            this.IMList.Images.SetKeyName(2, "new_sm.bmp");
            this.IMList.Images.SetKeyName(3, "orders_sm.bmp");
            this.IMList.Images.SetKeyName(4, "partsearch_sm.bmp");
            this.IMList.Images.SetKeyName(5, "people_sm.bmp");
            this.IMList.Images.SetKeyName(6, "search_sm.bmp");
            this.IMList.Images.SetKeyName(7, "options_sm.bmp");
            this.IMList.Images.SetKeyName(8, "criteria_sm.bmp");
            this.IMList.Images.SetKeyName(9, "imp_exp_excel16.bmp");
            this.IMList.Images.SetKeyName(10, "envelope.bmp");
            // 
            // tmr
            // 
            this.tmr.Interval = 2000;
            // 
            // pOptions
            // 
            this.pOptions.Controls.Add(this.optBoth);
            this.pOptions.Controls.Add(this.cmdClear);
            this.pOptions.Controls.Add(this.optCompany);
            this.pOptions.Controls.Add(this.optContact);
            this.pOptions.Controls.Add(this.pictureBox2);
            this.pOptions.Controls.Add(this.pictureBox1);
            this.pOptions.Controls.Add(this.cmdAdd);
            this.pOptions.Controls.Add(this.cmdParts);
            this.pOptions.Controls.Add(this.chkSwitchView);
            this.pOptions.Controls.Add(this.ts);
            this.pOptions.Controls.Add(this.cmdSearch);
            this.pOptions.Location = new System.Drawing.Point(3, 7);
            this.pOptions.Name = "pOptions";
            this.pOptions.Size = new System.Drawing.Size(241, 787);
            this.pOptions.TabIndex = 8;
            // 
            // optBoth
            // 
            this.optBoth.Location = new System.Drawing.Point(18, 62);
            this.optBoth.Name = "optBoth";
            this.optBoth.Size = new System.Drawing.Size(70, 17);
            this.optBoth.TabIndex = 20;
            this.optBoth.Text = "Both";
            this.optBoth.UseVisualStyleBackColor = true;
            this.optBoth.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // cmdClear
            // 
            this.cmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClear.ImageKey = "clear_sm.bmp";
            this.cmdClear.ImageList = this.IMList;
            this.cmdClear.Location = new System.Drawing.Point(3, 3);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(106, 25);
            this.cmdClear.TabIndex = 13;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // optCompany
            // 
            this.optCompany.Checked = true;
            this.optCompany.Location = new System.Drawing.Point(18, 32);
            this.optCompany.Name = "optCompany";
            this.optCompany.Size = new System.Drawing.Size(70, 17);
            this.optCompany.TabIndex = 16;
            this.optCompany.TabStop = true;
            this.optCompany.Text = "Company";
            this.optCompany.UseVisualStyleBackColor = true;
            // 
            // optContact
            // 
            this.optContact.Location = new System.Drawing.Point(18, 47);
            this.optContact.Name = "optContact";
            this.optContact.Size = new System.Drawing.Size(70, 17);
            this.optContact.TabIndex = 19;
            this.optContact.Text = "Contact";
            this.optContact.UseVisualStyleBackColor = true;
            this.optContact.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(4, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(104, 50);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(3, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 52);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // cmdAdd
            // 
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.ImageKey = "add_sm.bmp";
            this.cmdAdd.ImageList = this.IMList;
            this.cmdAdd.Location = new System.Drawing.Point(115, 27);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(125, 25);
            this.cmdAdd.TabIndex = 12;
            this.cmdAdd.Text = "Add Company";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdParts
            // 
            this.cmdParts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdParts.ImageKey = "partsearch_sm.bmp";
            this.cmdParts.ImageList = this.IMList;
            this.cmdParts.Location = new System.Drawing.Point(115, 3);
            this.cmdParts.Name = "cmdParts";
            this.cmdParts.Size = new System.Drawing.Size(125, 25);
            this.cmdParts.TabIndex = 11;
            this.cmdParts.Text = "Part Search";
            this.cmdParts.UseVisualStyleBackColor = true;
            this.cmdParts.Click += new System.EventHandler(this.cmdParts_Click);
            // 
            // chkSwitchView
            // 
            this.chkSwitchView.AutoSize = true;
            this.chkSwitchView.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSwitchView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSwitchView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkSwitchView.Location = new System.Drawing.Point(143, 84);
            this.chkSwitchView.Name = "chkSwitchView";
            this.chkSwitchView.Size = new System.Drawing.Size(95, 17);
            this.chkSwitchView.TabIndex = 14;
            this.chkSwitchView.Text = "Switch View";
            this.chkSwitchView.UseVisualStyleBackColor = true;
            this.chkSwitchView.Visible = false;
            this.chkSwitchView.CheckStateChanged += new System.EventHandler(this.chkSwitchView_CheckStateChanged);
            // 
            // ts
            // 
            this.ts.Controls.Add(this.pageCompany);
            this.ts.Controls.Add(this.tabOptions);
            this.ts.Location = new System.Drawing.Point(3, 82);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(237, 699);
            this.ts.TabIndex = 15;
            this.ts.SelectedIndexChanged += new System.EventHandler(this.ts_SelectedIndexChanged);
            this.ts.Resize += new System.EventHandler(this.ts_Resize);
            // 
            // pageCompany
            // 
            this.pageCompany.BackColor = System.Drawing.Color.White;
            this.pageCompany.Controls.Add(this.ctl_industry_segment);
            this.pageCompany.Controls.Add(this.lblGroupName);
            this.pageCompany.Controls.Add(this.lblClearGroup);
            this.pageCompany.Controls.Add(this.lblGroup);
            this.pageCompany.Controls.Add(this.lblChoose);
            this.pageCompany.Controls.Add(this.ctlBadMailingAddress);
            this.pageCompany.Controls.Add(this.pCTG);
            this.pageCompany.Controls.Add(this.chkProspectAccount);
            this.pageCompany.Controls.Add(this.lblNewSearch);
            this.pageCompany.Controls.Add(this.lblClearAgents);
            this.pageCompany.Controls.Add(this.lblChooseAgents);
            this.pageCompany.Controls.Add(this.lblAgents);
            this.pageCompany.Controls.Add(this.chkOrderByEmailDomain);
            this.pageCompany.Controls.Add(this.ctl_ReqCount);
            this.pageCompany.Controls.Add(this.lblHighlight);
            this.pageCompany.Controls.Add(this.lblCurrentCallList);
            this.pageCompany.Controls.Add(this.lblNextCallList);
            this.pageCompany.Controls.Add(this.chkUnassigned);
            this.pageCompany.Controls.Add(this.ctlCallSchedule);
            this.pageCompany.Controls.Add(this.cmdViewAgents);
            this.pageCompany.Controls.Add(this.chkSales);
            this.pageCompany.Controls.Add(this.chkPurchases);
            this.pageCompany.Controls.Add(this.ctl_OrderDate);
            this.pageCompany.Controls.Add(this.ctl_CompanyName);
            this.pageCompany.Controls.Add(this.ctl_ContactName);
            this.pageCompany.Controls.Add(this.ctl_PhoneFaxEmail);
            this.pageCompany.Controls.Add(this.ctl_PartNumber);
            this.pageCompany.Controls.Add(this.ctl_Address);
            this.pageCompany.Controls.Add(this.ctl_Source);
            this.pageCompany.Controls.Add(this.ctl_CompanyType);
            this.pageCompany.Controls.Add(this.ctl_OrderNumber);
            this.pageCompany.ImageKey = "criteria_sm.bmp";
            this.pageCompany.Location = new System.Drawing.Point(4, 22);
            this.pageCompany.Name = "pageCompany";
            this.pageCompany.Padding = new System.Windows.Forms.Padding(3);
            this.pageCompany.Size = new System.Drawing.Size(229, 673);
            this.pageCompany.TabIndex = 0;
            this.pageCompany.Text = "Criteria";
            // 
            // ctl_industry_segment
            // 
            this.ctl_industry_segment.AllCaps = false;
            this.ctl_industry_segment.BackColor = System.Drawing.Color.Transparent;
            this.ctl_industry_segment.Bold = false;
            this.ctl_industry_segment.Caption = "Industry Segment (fuzzy)";
            this.ctl_industry_segment.Changed = false;
            this.ctl_industry_segment.IsEmail = false;
            this.ctl_industry_segment.IsURL = false;
            this.ctl_industry_segment.Location = new System.Drawing.Point(5, 406);
            this.ctl_industry_segment.Name = "ctl_industry_segment";
            this.ctl_industry_segment.PasswordChar = '\0';
            this.ctl_industry_segment.Size = new System.Drawing.Size(218, 41);
            this.ctl_industry_segment.TabIndex = 37;
            this.ctl_industry_segment.UseParentBackColor = true;
            this.ctl_industry_segment.zz_Enabled = true;
            this.ctl_industry_segment.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_industry_segment.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_industry_segment.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_industry_segment.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_industry_segment.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_industry_segment.zz_OriginalDesign = true;
            this.ctl_industry_segment.zz_ShowLinkButton = false;
            this.ctl_industry_segment.zz_ShowNeedsSaveColor = false;
            this.ctl_industry_segment.zz_Text = "";
            this.ctl_industry_segment.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_industry_segment.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_industry_segment.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_industry_segment.zz_UseGlobalColor = false;
            this.ctl_industry_segment.zz_UseGlobalFont = false;
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(11, 178);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(67, 13);
            this.lblGroupName.TabIndex = 36;
            this.lblGroupName.Text = "Group Name";
            // 
            // lblClearGroup
            // 
            this.lblClearGroup.AutoSize = true;
            this.lblClearGroup.Location = new System.Drawing.Point(97, 160);
            this.lblClearGroup.Name = "lblClearGroup";
            this.lblClearGroup.Size = new System.Drawing.Size(30, 13);
            this.lblClearGroup.TabIndex = 35;
            this.lblClearGroup.TabStop = true;
            this.lblClearGroup.Text = "clear";
            this.lblClearGroup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblClearGroup_LinkClicked);
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(9, 159);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(36, 13);
            this.lblGroup.TabIndex = 34;
            this.lblGroup.Text = "Group";
            // 
            // lblChoose
            // 
            this.lblChoose.AutoSize = true;
            this.lblChoose.Location = new System.Drawing.Point(51, 159);
            this.lblChoose.Name = "lblChoose";
            this.lblChoose.Size = new System.Drawing.Size(42, 13);
            this.lblChoose.TabIndex = 33;
            this.lblChoose.TabStop = true;
            this.lblChoose.Text = "choose";
            this.lblChoose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChoose_LinkClicked);
            // 
            // ctlBadMailingAddress
            // 
            this.ctlBadMailingAddress.BackColor = System.Drawing.Color.Transparent;
            this.ctlBadMailingAddress.Bold = false;
            this.ctlBadMailingAddress.Caption = "Bad Mailing Address";
            this.ctlBadMailingAddress.Changed = false;
            this.ctlBadMailingAddress.Location = new System.Drawing.Point(12, 600);
            this.ctlBadMailingAddress.Name = "ctlBadMailingAddress";
            this.ctlBadMailingAddress.Size = new System.Drawing.Size(122, 18);
            this.ctlBadMailingAddress.TabIndex = 32;
            this.ctlBadMailingAddress.UseParentBackColor = true;
            this.ctlBadMailingAddress.zz_CheckValue = false;
            this.ctlBadMailingAddress.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlBadMailingAddress.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlBadMailingAddress.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctlBadMailingAddress.zz_OriginalDesign = false;
            this.ctlBadMailingAddress.zz_ShowNeedsSaveColor = true;
            // 
            // pCTG
            // 
            this.pCTG.Controls.Add(this.ctlCallCutoff);
            this.pCTG.Controls.Add(this.cmd3Month);
            this.pCTG.Controls.Add(this.lblPrevious);
            this.pCTG.Controls.Add(this.lblHot50);
            this.pCTG.Location = new System.Drawing.Point(10, 522);
            this.pCTG.Name = "pCTG";
            this.pCTG.Size = new System.Drawing.Size(211, 73);
            this.pCTG.TabIndex = 31;
            // 
            // ctlCallCutoff
            // 
            this.ctlCallCutoff.AllowClear = true;
            this.ctlCallCutoff.BackColor = System.Drawing.Color.Transparent;
            this.ctlCallCutoff.Bold = false;
            this.ctlCallCutoff.Caption = "Not Called Since";
            this.ctlCallCutoff.Changed = false;
            this.ctlCallCutoff.Location = new System.Drawing.Point(3, 1);
            this.ctlCallCutoff.Name = "ctlCallCutoff";
            this.ctlCallCutoff.Size = new System.Drawing.Size(117, 53);
            this.ctlCallCutoff.SuppressEdit = false;
            this.ctlCallCutoff.TabIndex = 31;
            this.ctlCallCutoff.UseParentBackColor = true;
            this.ctlCallCutoff.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlCallCutoff.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlCallCutoff.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlCallCutoff.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCallCutoff.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctlCallCutoff.zz_OriginalDesign = true;
            this.ctlCallCutoff.zz_ShowNeedsSaveColor = true;
            this.ctlCallCutoff.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlCallCutoff.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCallCutoff.zz_UseGlobalColor = false;
            this.ctlCallCutoff.zz_UseGlobalFont = false;
            // 
            // cmd3Month
            // 
            this.cmd3Month.Location = new System.Drawing.Point(126, 3);
            this.cmd3Month.Name = "cmd3Month";
            this.cmd3Month.Size = new System.Drawing.Size(79, 28);
            this.cmd3Month.TabIndex = 10;
            this.cmd3Month.Text = "Hot 25 >";
            this.cmd3Month.UseVisualStyleBackColor = true;
            this.cmd3Month.Click += new System.EventHandler(this.cmd3Month_Click);
            // 
            // lblPrevious
            // 
            this.lblPrevious.AutoSize = true;
            this.lblPrevious.Location = new System.Drawing.Point(138, 51);
            this.lblPrevious.Name = "lblPrevious";
            this.lblPrevious.Size = new System.Drawing.Size(57, 13);
            this.lblPrevious.TabIndex = 30;
            this.lblPrevious.TabStop = true;
            this.lblPrevious.Text = "< Previous";
            this.lblPrevious.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPrevious_LinkClicked);
            // 
            // lblHot50
            // 
            this.lblHot50.AutoSize = true;
            this.lblHot50.Location = new System.Drawing.Point(148, 34);
            this.lblHot50.Name = "lblHot50";
            this.lblHot50.Size = new System.Drawing.Size(38, 13);
            this.lblHot50.TabIndex = 29;
            this.lblHot50.TabStop = true;
            this.lblHot50.Text = "Next >";
            this.lblHot50.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblHot50_LinkClicked);
            // 
            // chkProspectAccount
            // 
            this.chkProspectAccount.AutoSize = true;
            this.chkProspectAccount.Location = new System.Drawing.Point(3, 233);
            this.chkProspectAccount.Name = "chkProspectAccount";
            this.chkProspectAccount.Size = new System.Drawing.Size(116, 17);
            this.chkProspectAccount.TabIndex = 28;
            this.chkProspectAccount.Text = "Prospect Accounts";
            this.chkProspectAccount.UseVisualStyleBackColor = true;
            this.chkProspectAccount.Visible = false;
            // 
            // lblNewSearch
            // 
            this.lblNewSearch.AutoSize = true;
            this.lblNewSearch.Location = new System.Drawing.Point(120, 503);
            this.lblNewSearch.Name = "lblNewSearch";
            this.lblNewSearch.Size = new System.Drawing.Size(102, 13);
            this.lblNewSearch.TabIndex = 27;
            this.lblNewSearch.TabStop = true;
            this.lblNewSearch.Text = "New People Search";
            this.lblNewSearch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNewSearch_LinkClicked);
            // 
            // lblClearAgents
            // 
            this.lblClearAgents.AutoSize = true;
            this.lblClearAgents.Location = new System.Drawing.Point(54, 117);
            this.lblClearAgents.Name = "lblClearAgents";
            this.lblClearAgents.Size = new System.Drawing.Size(30, 13);
            this.lblClearAgents.TabIndex = 26;
            this.lblClearAgents.TabStop = true;
            this.lblClearAgents.Text = "clear";
            this.lblClearAgents.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblClearAgents_LinkClicked);
            // 
            // lblChooseAgents
            // 
            this.lblChooseAgents.AutoSize = true;
            this.lblChooseAgents.Location = new System.Drawing.Point(20, 138);
            this.lblChooseAgents.Name = "lblChooseAgents";
            this.lblChooseAgents.Size = new System.Drawing.Size(91, 13);
            this.lblChooseAgents.TabIndex = 25;
            this.lblChooseAgents.TabStop = true;
            this.lblChooseAgents.Text = "<click to choose>";
            this.lblChooseAgents.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChooseAgents_LinkClicked);
            // 
            // lblAgents
            // 
            this.lblAgents.AutoSize = true;
            this.lblAgents.Location = new System.Drawing.Point(8, 117);
            this.lblAgents.Name = "lblAgents";
            this.lblAgents.Size = new System.Drawing.Size(40, 13);
            this.lblAgents.TabIndex = 24;
            this.lblAgents.Text = "Agents";
            // 
            // chkOrderByEmailDomain
            // 
            this.chkOrderByEmailDomain.AutoSize = true;
            this.chkOrderByEmailDomain.Location = new System.Drawing.Point(120, 479);
            this.chkOrderByEmailDomain.Name = "chkOrderByEmailDomain";
            this.chkOrderByEmailDomain.Size = new System.Drawing.Size(106, 17);
            this.chkOrderByEmailDomain.TabIndex = 23;
            this.chkOrderByEmailDomain.Text = "Order By Domain";
            this.chkOrderByEmailDomain.UseVisualStyleBackColor = true;
            // 
            // ctl_ReqCount
            // 
            this.ctl_ReqCount.BackColor = System.Drawing.Color.Transparent;
            this.ctl_ReqCount.Bold = false;
            this.ctl_ReqCount.Caption = "Requirement Count (>)";
            this.ctl_ReqCount.Changed = false;
            this.ctl_ReqCount.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_ReqCount.Location = new System.Drawing.Point(8, 452);
            this.ctl_ReqCount.Name = "ctl_ReqCount";
            this.ctl_ReqCount.Size = new System.Drawing.Size(216, 21);
            this.ctl_ReqCount.TabIndex = 22;
            this.ctl_ReqCount.UseParentBackColor = true;
            this.ctl_ReqCount.zz_Enabled = true;
            this.ctl_ReqCount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_ReqCount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_ReqCount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_ReqCount.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ReqCount.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.Left;
            this.ctl_ReqCount.zz_OriginalDesign = false;
            this.ctl_ReqCount.zz_ShowErrorColor = true;
            this.ctl_ReqCount.zz_ShowNeedsSaveColor = true;
            this.ctl_ReqCount.zz_Text = "";
            this.ctl_ReqCount.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_ReqCount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_ReqCount.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ReqCount.zz_UseGlobalColor = false;
            this.ctl_ReqCount.zz_UseGlobalFont = false;
            // 
            // lblHighlight
            // 
            this.lblHighlight.AutoSize = true;
            this.lblHighlight.Location = new System.Drawing.Point(97, 174);
            this.lblHighlight.Name = "lblHighlight";
            this.lblHighlight.Size = new System.Drawing.Size(46, 13);
            this.lblHighlight.TabIndex = 10;
            this.lblHighlight.TabStop = true;
            this.lblHighlight.Text = "highlight";
            this.lblHighlight.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblHighlight_LinkClicked);
            // 
            // lblCurrentCallList
            // 
            this.lblCurrentCallList.AutoSize = true;
            this.lblCurrentCallList.Location = new System.Drawing.Point(11, 479);
            this.lblCurrentCallList.Name = "lblCurrentCallList";
            this.lblCurrentCallList.Size = new System.Drawing.Size(80, 13);
            this.lblCurrentCallList.TabIndex = 21;
            this.lblCurrentCallList.TabStop = true;
            this.lblCurrentCallList.Text = "Current Call List";
            this.lblCurrentCallList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCurrentCallList_LinkClicked);
            // 
            // lblNextCallList
            // 
            this.lblNextCallList.AutoSize = true;
            this.lblNextCallList.Location = new System.Drawing.Point(13, 503);
            this.lblNextCallList.Name = "lblNextCallList";
            this.lblNextCallList.Size = new System.Drawing.Size(68, 13);
            this.lblNextCallList.TabIndex = 20;
            this.lblNextCallList.TabStop = true;
            this.lblNextCallList.Text = "New Call List";
            this.lblNextCallList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNextCallList_LinkClicked);
            // 
            // chkUnassigned
            // 
            this.chkUnassigned.AutoSize = true;
            this.chkUnassigned.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUnassigned.Location = new System.Drawing.Point(139, 113);
            this.chkUnassigned.Name = "chkUnassigned";
            this.chkUnassigned.Size = new System.Drawing.Size(82, 17);
            this.chkUnassigned.TabIndex = 17;
            this.chkUnassigned.Text = "Unassigned";
            this.chkUnassigned.UseVisualStyleBackColor = true;
            // 
            // ctlCallSchedule
            // 
            this.ctlCallSchedule.AllCaps = false;
            this.ctlCallSchedule.AllowEdit = false;
            this.ctlCallSchedule.BackColor = System.Drawing.Color.Transparent;
            this.ctlCallSchedule.Bold = false;
            this.ctlCallSchedule.Caption = "Call Schedule";
            this.ctlCallSchedule.Changed = false;
            this.ctlCallSchedule.ListName = null;
            this.ctlCallSchedule.Location = new System.Drawing.Point(116, 297);
            this.ctlCallSchedule.Name = "ctlCallSchedule";
            this.ctlCallSchedule.SimpleList = "Monday|Tuesday|Wednesday|Thursday|Friday|Saturday|Sunday";
            this.ctlCallSchedule.Size = new System.Drawing.Size(105, 41);
            this.ctlCallSchedule.TabIndex = 15;
            this.ctlCallSchedule.UseParentBackColor = true;
            this.ctlCallSchedule.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctlCallSchedule.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlCallSchedule.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlCallSchedule.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlCallSchedule.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctlCallSchedule.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctlCallSchedule.zz_OriginalDesign = true;
            this.ctlCallSchedule.zz_ShowNeedsSaveColor = true;
            this.ctlCallSchedule.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlCallSchedule.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCallSchedule.zz_UseGlobalColor = false;
            this.ctlCallSchedule.zz_UseGlobalFont = false;
            // 
            // cmdViewAgents
            // 
            this.cmdViewAgents.Location = new System.Drawing.Point(162, 138);
            this.cmdViewAgents.Name = "cmdViewAgents";
            this.cmdViewAgents.Size = new System.Drawing.Size(62, 22);
            this.cmdViewAgents.TabIndex = 14;
            this.cmdViewAgents.Text = "Agent List";
            this.cmdViewAgents.UseVisualStyleBackColor = true;
            this.cmdViewAgents.Click += new System.EventHandler(this.cmdViewAgents_Click);
            // 
            // chkSales
            // 
            this.chkSales.AutoSize = true;
            this.chkSales.Location = new System.Drawing.Point(3, 218);
            this.chkSales.Name = "chkSales";
            this.chkSales.Size = new System.Drawing.Size(183, 17);
            this.chkSales.TabIndex = 13;
            this.chkSales.Text = "Sales Volume GreaterThan $0.00";
            this.chkSales.UseVisualStyleBackColor = true;
            // 
            // chkPurchases
            // 
            this.chkPurchases.AutoSize = true;
            this.chkPurchases.Location = new System.Drawing.Point(3, 203);
            this.chkPurchases.Name = "chkPurchases";
            this.chkPurchases.Size = new System.Drawing.Size(202, 17);
            this.chkPurchases.TabIndex = 12;
            this.chkPurchases.Text = "Purchase Volume GreaterThan $0.00";
            this.chkPurchases.UseVisualStyleBackColor = true;
            // 
            // ctl_OrderDate
            // 
            this.ctl_OrderDate.AllowClear = true;
            this.ctl_OrderDate.BackColor = System.Drawing.Color.Transparent;
            this.ctl_OrderDate.Bold = false;
            this.ctl_OrderDate.Caption = "Order Date";
            this.ctl_OrderDate.Changed = false;
            this.ctl_OrderDate.Location = new System.Drawing.Point(116, 242);
            this.ctl_OrderDate.Name = "ctl_OrderDate";
            this.ctl_OrderDate.Size = new System.Drawing.Size(107, 52);
            this.ctl_OrderDate.SuppressEdit = false;
            this.ctl_OrderDate.TabIndex = 8;
            this.ctl_OrderDate.UseParentBackColor = true;
            this.ctl_OrderDate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_OrderDate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_OrderDate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_OrderDate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_OrderDate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_OrderDate.zz_OriginalDesign = true;
            this.ctl_OrderDate.zz_ShowNeedsSaveColor = true;
            this.ctl_OrderDate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_OrderDate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_OrderDate.zz_UseGlobalColor = false;
            this.ctl_OrderDate.zz_UseGlobalFont = false;
            // 
            // ctl_CompanyName
            // 
            this.ctl_CompanyName.AllCaps = false;
            this.ctl_CompanyName.BackColor = System.Drawing.Color.Transparent;
            this.ctl_CompanyName.Bold = false;
            this.ctl_CompanyName.Caption = "Company Name";
            this.ctl_CompanyName.Changed = false;
            this.ctl_CompanyName.IsEmail = false;
            this.ctl_CompanyName.IsURL = false;
            this.ctl_CompanyName.Location = new System.Drawing.Point(5, -3);
            this.ctl_CompanyName.Name = "ctl_CompanyName";
            this.ctl_CompanyName.PasswordChar = '\0';
            this.ctl_CompanyName.Size = new System.Drawing.Size(218, 41);
            this.ctl_CompanyName.TabIndex = 0;
            this.ctl_CompanyName.UseParentBackColor = true;
            this.ctl_CompanyName.zz_Enabled = true;
            this.ctl_CompanyName.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_CompanyName.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_CompanyName.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_CompanyName.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_CompanyName.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_CompanyName.zz_OriginalDesign = true;
            this.ctl_CompanyName.zz_ShowLinkButton = false;
            this.ctl_CompanyName.zz_ShowNeedsSaveColor = false;
            this.ctl_CompanyName.zz_Text = "";
            this.ctl_CompanyName.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_CompanyName.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_CompanyName.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_CompanyName.zz_UseGlobalColor = false;
            this.ctl_CompanyName.zz_UseGlobalFont = false;
            this.ctl_CompanyName.GotEnter += new NewMethod.GotEnterHandler(this.ctl_GotEnter);
            // 
            // ctl_ContactName
            // 
            this.ctl_ContactName.AllCaps = false;
            this.ctl_ContactName.BackColor = System.Drawing.Color.Transparent;
            this.ctl_ContactName.Bold = false;
            this.ctl_ContactName.Caption = "Contact Name";
            this.ctl_ContactName.Changed = false;
            this.ctl_ContactName.IsEmail = false;
            this.ctl_ContactName.IsURL = false;
            this.ctl_ContactName.Location = new System.Drawing.Point(5, 34);
            this.ctl_ContactName.Name = "ctl_ContactName";
            this.ctl_ContactName.PasswordChar = '\0';
            this.ctl_ContactName.Size = new System.Drawing.Size(218, 41);
            this.ctl_ContactName.TabIndex = 1;
            this.ctl_ContactName.UseParentBackColor = true;
            this.ctl_ContactName.zz_Enabled = true;
            this.ctl_ContactName.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_ContactName.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_ContactName.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_ContactName.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_ContactName.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_ContactName.zz_OriginalDesign = true;
            this.ctl_ContactName.zz_ShowLinkButton = false;
            this.ctl_ContactName.zz_ShowNeedsSaveColor = false;
            this.ctl_ContactName.zz_Text = "";
            this.ctl_ContactName.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_ContactName.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_ContactName.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ContactName.zz_UseGlobalColor = false;
            this.ctl_ContactName.zz_UseGlobalFont = false;
            this.ctl_ContactName.GotEnter += new NewMethod.GotEnterHandler(this.ctl_GotEnter);
            // 
            // ctl_PhoneFaxEmail
            // 
            this.ctl_PhoneFaxEmail.AllCaps = false;
            this.ctl_PhoneFaxEmail.BackColor = System.Drawing.Color.Transparent;
            this.ctl_PhoneFaxEmail.Bold = false;
            this.ctl_PhoneFaxEmail.Caption = "Phone / Fax / Email";
            this.ctl_PhoneFaxEmail.Changed = false;
            this.ctl_PhoneFaxEmail.IsEmail = false;
            this.ctl_PhoneFaxEmail.IsURL = false;
            this.ctl_PhoneFaxEmail.Location = new System.Drawing.Point(5, 72);
            this.ctl_PhoneFaxEmail.Name = "ctl_PhoneFaxEmail";
            this.ctl_PhoneFaxEmail.PasswordChar = '\0';
            this.ctl_PhoneFaxEmail.Size = new System.Drawing.Size(218, 41);
            this.ctl_PhoneFaxEmail.TabIndex = 2;
            this.ctl_PhoneFaxEmail.UseParentBackColor = true;
            this.ctl_PhoneFaxEmail.zz_Enabled = true;
            this.ctl_PhoneFaxEmail.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_PhoneFaxEmail.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_PhoneFaxEmail.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_PhoneFaxEmail.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_PhoneFaxEmail.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_PhoneFaxEmail.zz_OriginalDesign = true;
            this.ctl_PhoneFaxEmail.zz_ShowLinkButton = false;
            this.ctl_PhoneFaxEmail.zz_ShowNeedsSaveColor = false;
            this.ctl_PhoneFaxEmail.zz_Text = "";
            this.ctl_PhoneFaxEmail.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_PhoneFaxEmail.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_PhoneFaxEmail.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_PhoneFaxEmail.zz_UseGlobalColor = false;
            this.ctl_PhoneFaxEmail.zz_UseGlobalFont = false;
            this.ctl_PhoneFaxEmail.GotEnter += new NewMethod.GotEnterHandler(this.ctl_GotEnter);
            // 
            // ctl_PartNumber
            // 
            this.ctl_PartNumber.AllCaps = false;
            this.ctl_PartNumber.BackColor = System.Drawing.Color.Transparent;
            this.ctl_PartNumber.Bold = false;
            this.ctl_PartNumber.Caption = "Part Number";
            this.ctl_PartNumber.Changed = false;
            this.ctl_PartNumber.IsEmail = false;
            this.ctl_PartNumber.IsURL = false;
            this.ctl_PartNumber.Location = new System.Drawing.Point(5, 340);
            this.ctl_PartNumber.Name = "ctl_PartNumber";
            this.ctl_PartNumber.PasswordChar = '\0';
            this.ctl_PartNumber.Size = new System.Drawing.Size(218, 21);
            this.ctl_PartNumber.TabIndex = 10;
            this.ctl_PartNumber.UseParentBackColor = true;
            this.ctl_PartNumber.zz_Enabled = true;
            this.ctl_PartNumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_PartNumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_PartNumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_PartNumber.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_PartNumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctl_PartNumber.zz_OriginalDesign = false;
            this.ctl_PartNumber.zz_ShowLinkButton = false;
            this.ctl_PartNumber.zz_ShowNeedsSaveColor = false;
            this.ctl_PartNumber.zz_Text = "";
            this.ctl_PartNumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_PartNumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_PartNumber.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_PartNumber.zz_UseGlobalColor = false;
            this.ctl_PartNumber.zz_UseGlobalFont = false;
            this.ctl_PartNumber.GotEnter += new NewMethod.GotEnterHandler(this.ctl_GotEnter);
            // 
            // ctl_Address
            // 
            this.ctl_Address.AllCaps = false;
            this.ctl_Address.BackColor = System.Drawing.Color.Transparent;
            this.ctl_Address.Bold = false;
            this.ctl_Address.Caption = "Address (Searches All Address Sections)";
            this.ctl_Address.Changed = false;
            this.ctl_Address.IsEmail = false;
            this.ctl_Address.IsURL = false;
            this.ctl_Address.Location = new System.Drawing.Point(5, 359);
            this.ctl_Address.Name = "ctl_Address";
            this.ctl_Address.PasswordChar = '\0';
            this.ctl_Address.Size = new System.Drawing.Size(218, 41);
            this.ctl_Address.TabIndex = 11;
            this.ctl_Address.UseParentBackColor = true;
            this.ctl_Address.zz_Enabled = true;
            this.ctl_Address.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_Address.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_Address.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_Address.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_Address.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_Address.zz_OriginalDesign = true;
            this.ctl_Address.zz_ShowLinkButton = false;
            this.ctl_Address.zz_ShowNeedsSaveColor = false;
            this.ctl_Address.zz_Text = "";
            this.ctl_Address.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_Address.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_Address.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_Address.zz_UseGlobalColor = false;
            this.ctl_Address.zz_UseGlobalFont = false;
            this.ctl_Address.GotEnter += new NewMethod.GotEnterHandler(this.ctl_GotEnter);
            // 
            // ctl_Source
            // 
            this.ctl_Source.AllCaps = false;
            this.ctl_Source.AllowEdit = true;
            this.ctl_Source.BackColor = System.Drawing.Color.Transparent;
            this.ctl_Source.Bold = false;
            this.ctl_Source.Caption = "Source";
            this.ctl_Source.Changed = false;
            this.ctl_Source.ListName = "source";
            this.ctl_Source.Location = new System.Drawing.Point(149, 160);
            this.ctl_Source.Name = "ctl_Source";
            this.ctl_Source.SimpleList = null;
            this.ctl_Source.Size = new System.Drawing.Size(72, 36);
            this.ctl_Source.TabIndex = 5;
            this.ctl_Source.UseParentBackColor = true;
            this.ctl_Source.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_Source.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_Source.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_Source.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_Source.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_Source.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_Source.zz_OriginalDesign = false;
            this.ctl_Source.zz_ShowNeedsSaveColor = true;
            this.ctl_Source.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_Source.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_Source.zz_UseGlobalColor = false;
            this.ctl_Source.zz_UseGlobalFont = false;
            // 
            // ctl_CompanyType
            // 
            this.ctl_CompanyType.AllCaps = false;
            this.ctl_CompanyType.AllowEdit = false;
            this.ctl_CompanyType.BackColor = System.Drawing.Color.Transparent;
            this.ctl_CompanyType.Bold = false;
            this.ctl_CompanyType.Caption = "Company Type";
            this.ctl_CompanyType.Changed = false;
            this.ctl_CompanyType.ListName = "companytype";
            this.ctl_CompanyType.Location = new System.Drawing.Point(4, 250);
            this.ctl_CompanyType.Name = "ctl_CompanyType";
            this.ctl_CompanyType.SimpleList = "";
            this.ctl_CompanyType.Size = new System.Drawing.Size(109, 36);
            this.ctl_CompanyType.TabIndex = 6;
            this.ctl_CompanyType.UseParentBackColor = true;
            this.ctl_CompanyType.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_CompanyType.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_CompanyType.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_CompanyType.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_CompanyType.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_CompanyType.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_CompanyType.zz_OriginalDesign = false;
            this.ctl_CompanyType.zz_ShowNeedsSaveColor = true;
            this.ctl_CompanyType.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_CompanyType.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_CompanyType.zz_UseGlobalColor = false;
            this.ctl_CompanyType.zz_UseGlobalFont = false;
            // 
            // ctl_OrderNumber
            // 
            this.ctl_OrderNumber.AllCaps = false;
            this.ctl_OrderNumber.BackColor = System.Drawing.Color.Transparent;
            this.ctl_OrderNumber.Bold = false;
            this.ctl_OrderNumber.Caption = "Order / Ref Num";
            this.ctl_OrderNumber.Changed = false;
            this.ctl_OrderNumber.IsEmail = false;
            this.ctl_OrderNumber.IsURL = false;
            this.ctl_OrderNumber.Location = new System.Drawing.Point(5, 297);
            this.ctl_OrderNumber.Name = "ctl_OrderNumber";
            this.ctl_OrderNumber.PasswordChar = '\0';
            this.ctl_OrderNumber.Size = new System.Drawing.Size(105, 41);
            this.ctl_OrderNumber.TabIndex = 7;
            this.ctl_OrderNumber.UseParentBackColor = true;
            this.ctl_OrderNumber.zz_Enabled = true;
            this.ctl_OrderNumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_OrderNumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_OrderNumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_OrderNumber.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_OrderNumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_OrderNumber.zz_OriginalDesign = true;
            this.ctl_OrderNumber.zz_ShowLinkButton = false;
            this.ctl_OrderNumber.zz_ShowNeedsSaveColor = true;
            this.ctl_OrderNumber.zz_Text = "";
            this.ctl_OrderNumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_OrderNumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_OrderNumber.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_OrderNumber.zz_UseGlobalColor = false;
            this.ctl_OrderNumber.zz_UseGlobalFont = false;
            this.ctl_OrderNumber.GotEnter += new NewMethod.GotEnterHandler(this.ctl_GotEnter);
            // 
            // tabOptions
            // 
            this.tabOptions.BackColor = System.Drawing.Color.White;
            this.tabOptions.Controls.Add(this.cmdBulkEmail);
            this.tabOptions.Controls.Add(this.cmdExcelExport);
            this.tabOptions.Controls.Add(this.lblAlt);
            this.tabOptions.Controls.Add(this.lvAlt);
            this.tabOptions.Controls.Add(this.lstFilters);
            this.tabOptions.Controls.Add(this.lblFilters);
            this.tabOptions.ImageKey = "options_sm.bmp";
            this.tabOptions.Location = new System.Drawing.Point(4, 22);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(229, 673);
            this.tabOptions.TabIndex = 3;
            this.tabOptions.Text = "Options";
            // 
            // cmdBulkEmail
            // 
            this.cmdBulkEmail.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBulkEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBulkEmail.ImageKey = "envelope.bmp";
            this.cmdBulkEmail.Location = new System.Drawing.Point(120, 3);
            this.cmdBulkEmail.Name = "cmdBulkEmail";
            this.cmdBulkEmail.Size = new System.Drawing.Size(103, 25);
            this.cmdBulkEmail.TabIndex = 5;
            this.cmdBulkEmail.Text = "   Bulk Email";
            this.cmdBulkEmail.UseVisualStyleBackColor = true;
            this.cmdBulkEmail.Click += new System.EventHandler(this.cmdBulkEmail_Click);
            // 
            // cmdExcelExport
            // 
            this.cmdExcelExport.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExcelExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdExcelExport.ImageKey = "imp_exp_excel16.bmp";
            this.cmdExcelExport.Location = new System.Drawing.Point(9, 3);
            this.cmdExcelExport.Name = "cmdExcelExport";
            this.cmdExcelExport.Size = new System.Drawing.Size(103, 25);
            this.cmdExcelExport.TabIndex = 4;
            this.cmdExcelExport.Text = "   Export List";
            this.cmdExcelExport.UseVisualStyleBackColor = true;
            this.cmdExcelExport.Click += new System.EventHandler(this.cmdExcelExport_Click);
            // 
            // lblAlt
            // 
            this.lblAlt.AutoSize = true;
            this.lblAlt.Location = new System.Drawing.Point(6, 315);
            this.lblAlt.Name = "lblAlt";
            this.lblAlt.Size = new System.Drawing.Size(196, 13);
            this.lblAlt.TabIndex = 3;
            this.lblAlt.Text = "Alternate Searches (Dbl-Click To View)::";
            // 
            // lvAlt
            // 
            this.lvAlt.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvAlt.FullRowSelect = true;
            this.lvAlt.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvAlt.HideSelection = false;
            this.lvAlt.Location = new System.Drawing.Point(9, 333);
            this.lvAlt.MultiSelect = false;
            this.lvAlt.Name = "lvAlt";
            this.lvAlt.Size = new System.Drawing.Size(214, 140);
            this.lvAlt.TabIndex = 2;
            this.lvAlt.UseCompatibleStateImageBehavior = false;
            this.lvAlt.View = System.Windows.Forms.View.Details;
            this.lvAlt.SelectedIndexChanged += new System.EventHandler(this.lvAlt_SelectedIndexChanged);
            this.lvAlt.DoubleClick += new System.EventHandler(this.lvAlt_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Options";
            this.columnHeader1.Width = 195;
            // 
            // lstFilters
            // 
            this.lstFilters.CheckOnClick = true;
            this.lstFilters.FormattingEnabled = true;
            this.lstFilters.Location = new System.Drawing.Point(9, 51);
            this.lstFilters.Name = "lstFilters";
            this.lstFilters.Size = new System.Drawing.Size(214, 259);
            this.lstFilters.TabIndex = 1;
            // 
            // lblFilters
            // 
            this.lblFilters.AutoSize = true;
            this.lblFilters.Location = new System.Drawing.Point(6, 33);
            this.lblFilters.Name = "lblFilters";
            this.lblFilters.Size = new System.Drawing.Size(210, 13);
            this.lblFilters.TabIndex = 0;
            this.lblFilters.Text = "Filters (Check and click \'Search>\' to view)::";
            // 
            // cmdSearch
            // 
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSearch.ImageKey = "search_sm.bmp";
            this.cmdSearch.ImageList = this.IMList;
            this.cmdSearch.Location = new System.Drawing.Point(115, 51);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(125, 30);
            this.cmdSearch.TabIndex = 10;
            this.cmdSearch.Text = "Search >";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // PeopleSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pOptions);
            this.Name = "PeopleSearch";
            this.Size = new System.Drawing.Size(796, 834);
            this.Controls.SetChildIndex(this.pOptions, 0);
            this.Controls.SetChildIndex(this.xDisplay, 0);
            this.Controls.SetChildIndex(this.xDisplay2, 0);
            this.pOptions.ResumeLayout(false);
            this.pOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ts.ResumeLayout(false);
            this.pageCompany.ResumeLayout(false);
            this.pageCompany.PerformLayout();
            this.pCTG.ResumeLayout(false);
            this.pCTG.PerformLayout();
            this.tabOptions.ResumeLayout(false);
            this.tabOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList IMList;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.Panel pOptions;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdParts;
        public System.Windows.Forms.TabControl ts;
        public System.Windows.Forms.TabPage pageCompany;
        public System.Windows.Forms.Label lblGroupName;
        public System.Windows.Forms.LinkLabel lblClearGroup;
        public System.Windows.Forms.Label lblGroup;
        public System.Windows.Forms.LinkLabel lblChoose;
        public nEdit_Boolean ctlBadMailingAddress;
        public System.Windows.Forms.Panel pCTG;
        private nEdit_Date ctlCallCutoff;
        private System.Windows.Forms.Button cmd3Month;
        private System.Windows.Forms.LinkLabel lblPrevious;
        private System.Windows.Forms.LinkLabel lblHot50;
        public System.Windows.Forms.CheckBox chkProspectAccount;
        public System.Windows.Forms.LinkLabel lblNewSearch;
        public System.Windows.Forms.LinkLabel lblClearAgents;
        public System.Windows.Forms.LinkLabel lblChooseAgents;
        public System.Windows.Forms.Label lblAgents;
        public System.Windows.Forms.CheckBox chkOrderByEmailDomain;
        public nEdit_Number ctl_ReqCount;
        public System.Windows.Forms.LinkLabel lblHighlight;
        public System.Windows.Forms.LinkLabel lblCurrentCallList;
        public System.Windows.Forms.LinkLabel lblNextCallList;
        public System.Windows.Forms.CheckBox chkUnassigned;
        public nEdit_List ctlCallSchedule;
        public System.Windows.Forms.Button cmdViewAgents;
        public System.Windows.Forms.CheckBox chkSales;
        public System.Windows.Forms.CheckBox chkPurchases;
        public nEdit_Date ctl_OrderDate;
        public nEdit_String ctl_CompanyName;
        public nEdit_String ctl_ContactName;
        public nEdit_String ctl_PhoneFaxEmail;
        public nEdit_String ctl_PartNumber;
        public nEdit_String ctl_Address;
        public nEdit_List ctl_Source;
        public nEdit_List ctl_CompanyType;
        public nEdit_String ctl_OrderNumber;
        public System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.Button cmdBulkEmail;
        private System.Windows.Forms.Button cmdExcelExport;
        private System.Windows.Forms.Label lblAlt;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.CheckedListBox lstFilters;
        private System.Windows.Forms.Label lblFilters;
        private System.Windows.Forms.Button cmdSearch;
        protected System.Windows.Forms.ListView lvAlt;
        protected System.Windows.Forms.CheckBox chkSwitchView;
        protected System.Windows.Forms.RadioButton optCompany;
        protected System.Windows.Forms.RadioButton optContact;
        protected System.Windows.Forms.RadioButton optBoth;
        public nEdit_String ctl_industry_segment;

        //  private SideKickView viewSideKick;
    }
}
