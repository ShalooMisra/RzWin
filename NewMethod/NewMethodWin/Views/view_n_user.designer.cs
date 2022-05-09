namespace NewMethod
{
    partial class view_n_user
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.ctl_AssistantTo = new NewMethod.nEdit_User();
            this.ctl_is_accounting = new NewMethod.nEdit_Boolean();
            this.ctl_internal_phonenumber = new NewMethod.nEdit_String();
            this.btnTestPasswordHash = new System.Windows.Forms.Button();
            this.txtTestPasswordHash = new NewMethod.nEdit_String();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCarrier = new System.Windows.Forms.ComboBox();
            this.ctl_cell_number = new NewMethod.nEdit_String();
            this.ctl_alternate_email = new NewMethod.nEdit_String();
            this.ctl_alternate_initials = new NewMethod.nEdit_String();
            this.ctl_email_signature = new NewMethod.nEdit_Memo();
            this.ctl_fax_number = new NewMethod.nEdit_String();
            this.ctl_job_desc = new NewMethod.nEdit_Memo();
            this.txtPassword = new NewMethod.nEdit_String();
            this.ctl_login_name = new NewMethod.nEdit_String();
            this.ctl_user_initials = new NewMethod.nEdit_String();
            this.ctl_email_address = new NewMethod.nEdit_String();
            this.ctl_phone_ext = new NewMethod.nEdit_String();
            this.ctl_phone = new NewMethod.nEdit_String();
            this.ctl_super_user = new NewMethod.nEdit_Boolean();
            this.ctl_name = new NewMethod.nEdit_String();
            this.ctl_email_client = new NewMethod.nEdit_List();
            this.tabSales = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctl_is_hubspot_enabled = new NewMethod.nEdit_Boolean();
            this.ctl_show_on_sales_screen = new NewMethod.nEdit_Boolean();
            this.ctl_showonprofit_report = new NewMethod.nEdit_Boolean();
            this.gbSalesGoals = new System.Windows.Forms.GroupBox();
            this.ctl_commission_bogey = new NewMethod.nEdit_Number();
            this.ctl_monthly_invoiced_goal = new NewMethod.nEdit_Number();
            this.ctl_commission_percent = new NewMethod.nEdit_Number();
            this.ctl_monthly_booking_goal = new NewMethod.nEdit_Number();
            this.ctl_monthly_np_goal = new NewMethod.nEdit_Number();
            this.ctl_monthly_quote_goal = new NewMethod.nEdit_Number();
            this.tabRzSettings = new System.Windows.Forms.TabPage();
            this.chkViewAllAgentsCrossRef = new System.Windows.Forms.CheckBox();
            this.ctl_allow_list_export = new NewMethod.nEdit_Boolean();
            this.ctl_template_editor = new NewMethod.nEdit_Boolean();
            this.lvSettings = new NewMethod.nList();
            this.gbLeaderBoard = new System.Windows.Forms.GroupBox();
            this.nEdit_Memo1 = new NewMethod.nEdit_Memo();
            this.pbLeaderboardImage = new System.Windows.Forms.PictureBox();
            this.ctl_leaderboard_image_url = new NewMethod.nEdit_String();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabSales.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbSalesGoals.SuspendLayout();
            this.tabRzSettings.SuspendLayout();
            this.gbLeaderBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeaderboardImage)).BeginInit();
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(832, 0);
            this.xActions.Size = new System.Drawing.Size(148, 637);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabSales);
            this.tabControl1.Controls.Add(this.tabRzSettings);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(826, 637);
            this.tabControl1.TabIndex = 44;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.gbLeaderBoard);
            this.tabGeneral.Controls.Add(this.ctl_AssistantTo);
            this.tabGeneral.Controls.Add(this.ctl_is_accounting);
            this.tabGeneral.Controls.Add(this.ctl_internal_phonenumber);
            this.tabGeneral.Controls.Add(this.btnTestPasswordHash);
            this.tabGeneral.Controls.Add(this.txtTestPasswordHash);
            this.tabGeneral.Controls.Add(this.label1);
            this.tabGeneral.Controls.Add(this.cboCarrier);
            this.tabGeneral.Controls.Add(this.ctl_cell_number);
            this.tabGeneral.Controls.Add(this.ctl_alternate_email);
            this.tabGeneral.Controls.Add(this.ctl_alternate_initials);
            this.tabGeneral.Controls.Add(this.ctl_email_signature);
            this.tabGeneral.Controls.Add(this.ctl_fax_number);
            this.tabGeneral.Controls.Add(this.ctl_job_desc);
            this.tabGeneral.Controls.Add(this.txtPassword);
            this.tabGeneral.Controls.Add(this.ctl_login_name);
            this.tabGeneral.Controls.Add(this.ctl_user_initials);
            this.tabGeneral.Controls.Add(this.ctl_email_address);
            this.tabGeneral.Controls.Add(this.ctl_phone_ext);
            this.tabGeneral.Controls.Add(this.ctl_phone);
            this.tabGeneral.Controls.Add(this.ctl_super_user);
            this.tabGeneral.Controls.Add(this.ctl_name);
            this.tabGeneral.Controls.Add(this.ctl_email_client);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(818, 611);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // ctl_AssistantTo
            // 
            this.ctl_AssistantTo.AllowChange = true;
            this.ctl_AssistantTo.AllowClear = true;
            this.ctl_AssistantTo.AllowNew = false;
            this.ctl_AssistantTo.AllowView = false;
            this.ctl_AssistantTo.BackColor = System.Drawing.Color.Transparent;
            this.ctl_AssistantTo.Bold = false;
            this.ctl_AssistantTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctl_AssistantTo.Caption = "Assistant To:";
            this.ctl_AssistantTo.Changed = false;
            this.ctl_AssistantTo.Location = new System.Drawing.Point(503, 53);
            this.ctl_AssistantTo.Name = "ctl_AssistantTo";
            this.ctl_AssistantTo.Size = new System.Drawing.Size(299, 57);
            this.ctl_AssistantTo.TabIndex = 77;
            this.ctl_AssistantTo.UseParentBackColor = false;
            this.ctl_AssistantTo.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_AssistantTo.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // ctl_is_accounting
            // 
            this.ctl_is_accounting.BackColor = System.Drawing.Color.Transparent;
            this.ctl_is_accounting.Bold = false;
            this.ctl_is_accounting.Caption = "Accounting User";
            this.ctl_is_accounting.Changed = false;
            this.ctl_is_accounting.Location = new System.Drawing.Point(697, 23);
            this.ctl_is_accounting.Name = "ctl_is_accounting";
            this.ctl_is_accounting.Size = new System.Drawing.Size(105, 18);
            this.ctl_is_accounting.TabIndex = 40;
            this.ctl_is_accounting.UseParentBackColor = false;
            this.ctl_is_accounting.zz_CheckValue = false;
            this.ctl_is_accounting.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_accounting.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_is_accounting.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_accounting.zz_OriginalDesign = false;
            this.ctl_is_accounting.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_internal_phonenumber
            // 
            this.ctl_internal_phonenumber.AllCaps = false;
            this.ctl_internal_phonenumber.BackColor = System.Drawing.Color.Transparent;
            this.ctl_internal_phonenumber.Bold = false;
            this.ctl_internal_phonenumber.Caption = "Internal Phone Number (DID)";
            this.ctl_internal_phonenumber.Changed = false;
            this.ctl_internal_phonenumber.IsEmail = false;
            this.ctl_internal_phonenumber.IsURL = false;
            this.ctl_internal_phonenumber.Location = new System.Drawing.Point(282, 75);
            this.ctl_internal_phonenumber.Name = "ctl_internal_phonenumber";
            this.ctl_internal_phonenumber.PasswordChar = '\0';
            this.ctl_internal_phonenumber.Size = new System.Drawing.Size(194, 35);
            this.ctl_internal_phonenumber.TabIndex = 74;
            this.ctl_internal_phonenumber.UseParentBackColor = false;
            this.ctl_internal_phonenumber.Visible = false;
            this.ctl_internal_phonenumber.zz_Enabled = true;
            this.ctl_internal_phonenumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_internal_phonenumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_internal_phonenumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_internal_phonenumber.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internal_phonenumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_internal_phonenumber.zz_OriginalDesign = false;
            this.ctl_internal_phonenumber.zz_ShowLinkButton = false;
            this.ctl_internal_phonenumber.zz_ShowNeedsSaveColor = true;
            this.ctl_internal_phonenumber.zz_Text = "";
            this.ctl_internal_phonenumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_internal_phonenumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_internal_phonenumber.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internal_phonenumber.zz_UseGlobalColor = false;
            this.ctl_internal_phonenumber.zz_UseGlobalFont = false;
            // 
            // btnTestPasswordHash
            // 
            this.btnTestPasswordHash.Location = new System.Drawing.Point(585, 229);
            this.btnTestPasswordHash.Name = "btnTestPasswordHash";
            this.btnTestPasswordHash.Size = new System.Drawing.Size(46, 33);
            this.btnTestPasswordHash.TabIndex = 72;
            this.btnTestPasswordHash.Text = "Test";
            this.btnTestPasswordHash.UseVisualStyleBackColor = true;
            // 
            // txtTestPasswordHash
            // 
            this.txtTestPasswordHash.AllCaps = false;
            this.txtTestPasswordHash.BackColor = System.Drawing.Color.White;
            this.txtTestPasswordHash.Bold = false;
            this.txtTestPasswordHash.Caption = "Test Password Hash";
            this.txtTestPasswordHash.Changed = false;
            this.txtTestPasswordHash.IsEmail = false;
            this.txtTestPasswordHash.IsURL = false;
            this.txtTestPasswordHash.Location = new System.Drawing.Point(418, 221);
            this.txtTestPasswordHash.Name = "txtTestPasswordHash";
            this.txtTestPasswordHash.PasswordChar = '*';
            this.txtTestPasswordHash.Size = new System.Drawing.Size(160, 53);
            this.txtTestPasswordHash.TabIndex = 71;
            this.txtTestPasswordHash.UseParentBackColor = true;
            this.txtTestPasswordHash.zz_Enabled = true;
            this.txtTestPasswordHash.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtTestPasswordHash.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtTestPasswordHash.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtTestPasswordHash.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtTestPasswordHash.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.txtTestPasswordHash.zz_OriginalDesign = true;
            this.txtTestPasswordHash.zz_ShowLinkButton = false;
            this.txtTestPasswordHash.zz_ShowNeedsSaveColor = true;
            this.txtTestPasswordHash.zz_Text = "";
            this.txtTestPasswordHash.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTestPasswordHash.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtTestPasswordHash.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestPasswordHash.zz_UseGlobalColor = false;
            this.txtTestPasswordHash.zz_UseGlobalFont = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(591, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "Cell Carrier ( for automated texts )";
            // 
            // cboCarrier
            // 
            this.cboCarrier.FormattingEnabled = true;
            this.cboCarrier.Items.AddRange(new object[] {
            "Verizon",
            "AT&T",
            "Sprint",
            "T-Mobile",
            "Nextel",
            "Cingular",
            "Virgin Mobile",
            "Alltel",
            "Cellularone",
            "Omnipoint",
            "Qwest"});
            this.cboCarrier.Location = new System.Drawing.Point(591, 135);
            this.cboCarrier.Name = "cboCarrier";
            this.cboCarrier.Size = new System.Drawing.Size(164, 21);
            this.cboCarrier.TabIndex = 65;
            // 
            // ctl_cell_number
            // 
            this.ctl_cell_number.AllCaps = false;
            this.ctl_cell_number.BackColor = System.Drawing.Color.White;
            this.ctl_cell_number.Bold = false;
            this.ctl_cell_number.Caption = "Cell # ( just the 10 digits )";
            this.ctl_cell_number.Changed = false;
            this.ctl_cell_number.IsEmail = false;
            this.ctl_cell_number.IsURL = false;
            this.ctl_cell_number.Location = new System.Drawing.Point(418, 117);
            this.ctl_cell_number.Name = "ctl_cell_number";
            this.ctl_cell_number.PasswordChar = '\0';
            this.ctl_cell_number.Size = new System.Drawing.Size(160, 46);
            this.ctl_cell_number.TabIndex = 64;
            this.ctl_cell_number.UseParentBackColor = true;
            this.ctl_cell_number.zz_Enabled = true;
            this.ctl_cell_number.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_cell_number.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_cell_number.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_cell_number.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_cell_number.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_cell_number.zz_OriginalDesign = true;
            this.ctl_cell_number.zz_ShowLinkButton = false;
            this.ctl_cell_number.zz_ShowNeedsSaveColor = true;
            this.ctl_cell_number.zz_Text = "";
            this.ctl_cell_number.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_cell_number.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_cell_number.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_cell_number.zz_UseGlobalColor = false;
            this.ctl_cell_number.zz_UseGlobalFont = false;
            // 
            // ctl_alternate_email
            // 
            this.ctl_alternate_email.AllCaps = false;
            this.ctl_alternate_email.BackColor = System.Drawing.Color.White;
            this.ctl_alternate_email.Bold = false;
            this.ctl_alternate_email.Caption = "Alternate Email";
            this.ctl_alternate_email.Changed = false;
            this.ctl_alternate_email.IsEmail = false;
            this.ctl_alternate_email.IsURL = false;
            this.ctl_alternate_email.Location = new System.Drawing.Point(418, 169);
            this.ctl_alternate_email.Name = "ctl_alternate_email";
            this.ctl_alternate_email.PasswordChar = '\0';
            this.ctl_alternate_email.Size = new System.Drawing.Size(338, 46);
            this.ctl_alternate_email.TabIndex = 62;
            this.ctl_alternate_email.UseParentBackColor = true;
            this.ctl_alternate_email.zz_Enabled = true;
            this.ctl_alternate_email.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_alternate_email.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_alternate_email.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_alternate_email.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_alternate_email.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_alternate_email.zz_OriginalDesign = true;
            this.ctl_alternate_email.zz_ShowLinkButton = false;
            this.ctl_alternate_email.zz_ShowNeedsSaveColor = true;
            this.ctl_alternate_email.zz_Text = "";
            this.ctl_alternate_email.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_alternate_email.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_alternate_email.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_alternate_email.zz_UseGlobalColor = false;
            this.ctl_alternate_email.zz_UseGlobalFont = false;
            // 
            // ctl_alternate_initials
            // 
            this.ctl_alternate_initials.AllCaps = false;
            this.ctl_alternate_initials.BackColor = System.Drawing.Color.White;
            this.ctl_alternate_initials.Bold = false;
            this.ctl_alternate_initials.Caption = "Alt Initials";
            this.ctl_alternate_initials.Changed = false;
            this.ctl_alternate_initials.IsEmail = false;
            this.ctl_alternate_initials.IsURL = false;
            this.ctl_alternate_initials.Location = new System.Drawing.Point(418, 23);
            this.ctl_alternate_initials.Name = "ctl_alternate_initials";
            this.ctl_alternate_initials.PasswordChar = '\0';
            this.ctl_alternate_initials.Size = new System.Drawing.Size(58, 46);
            this.ctl_alternate_initials.TabIndex = 60;
            this.ctl_alternate_initials.UseParentBackColor = true;
            this.ctl_alternate_initials.zz_Enabled = true;
            this.ctl_alternate_initials.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_alternate_initials.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_alternate_initials.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_alternate_initials.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_alternate_initials.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_alternate_initials.zz_OriginalDesign = true;
            this.ctl_alternate_initials.zz_ShowLinkButton = false;
            this.ctl_alternate_initials.zz_ShowNeedsSaveColor = true;
            this.ctl_alternate_initials.zz_Text = "";
            this.ctl_alternate_initials.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_alternate_initials.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_alternate_initials.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_alternate_initials.zz_UseGlobalColor = false;
            this.ctl_alternate_initials.zz_UseGlobalFont = false;
            // 
            // ctl_email_signature
            // 
            this.ctl_email_signature.BackColor = System.Drawing.Color.White;
            this.ctl_email_signature.Bold = false;
            this.ctl_email_signature.Caption = "Email Signature";
            this.ctl_email_signature.Changed = false;
            this.ctl_email_signature.DateLines = false;
            this.ctl_email_signature.Location = new System.Drawing.Point(418, 270);
            this.ctl_email_signature.Name = "ctl_email_signature";
            this.ctl_email_signature.Size = new System.Drawing.Size(385, 55);
            this.ctl_email_signature.TabIndex = 58;
            this.ctl_email_signature.UseParentBackColor = true;
            this.ctl_email_signature.zz_Enabled = true;
            this.ctl_email_signature.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_email_signature.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_email_signature.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_email_signature.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_email_signature.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_email_signature.zz_OriginalDesign = true;
            this.ctl_email_signature.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_email_signature.zz_ShowNeedsSaveColor = true;
            this.ctl_email_signature.zz_Text = "";
            this.ctl_email_signature.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_email_signature.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_email_signature.zz_UseGlobalColor = false;
            this.ctl_email_signature.zz_UseGlobalFont = false;
            // 
            // ctl_fax_number
            // 
            this.ctl_fax_number.AllCaps = false;
            this.ctl_fax_number.BackColor = System.Drawing.Color.White;
            this.ctl_fax_number.Bold = false;
            this.ctl_fax_number.Caption = "Fax Number";
            this.ctl_fax_number.Changed = false;
            this.ctl_fax_number.IsEmail = false;
            this.ctl_fax_number.IsURL = false;
            this.ctl_fax_number.Location = new System.Drawing.Point(19, 117);
            this.ctl_fax_number.Name = "ctl_fax_number";
            this.ctl_fax_number.PasswordChar = '\0';
            this.ctl_fax_number.Size = new System.Drawing.Size(385, 46);
            this.ctl_fax_number.TabIndex = 53;
            this.ctl_fax_number.UseParentBackColor = true;
            this.ctl_fax_number.zz_Enabled = true;
            this.ctl_fax_number.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_fax_number.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_fax_number.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_fax_number.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_fax_number.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_fax_number.zz_OriginalDesign = true;
            this.ctl_fax_number.zz_ShowLinkButton = false;
            this.ctl_fax_number.zz_ShowNeedsSaveColor = true;
            this.ctl_fax_number.zz_Text = "";
            this.ctl_fax_number.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_fax_number.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_fax_number.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_fax_number.zz_UseGlobalColor = false;
            this.ctl_fax_number.zz_UseGlobalFont = false;
            // 
            // ctl_job_desc
            // 
            this.ctl_job_desc.BackColor = System.Drawing.Color.White;
            this.ctl_job_desc.Bold = false;
            this.ctl_job_desc.Caption = "Job Description";
            this.ctl_job_desc.Changed = false;
            this.ctl_job_desc.DateLines = false;
            this.ctl_job_desc.Location = new System.Drawing.Point(19, 270);
            this.ctl_job_desc.Name = "ctl_job_desc";
            this.ctl_job_desc.Size = new System.Drawing.Size(385, 55);
            this.ctl_job_desc.TabIndex = 52;
            this.ctl_job_desc.UseParentBackColor = true;
            this.ctl_job_desc.zz_Enabled = true;
            this.ctl_job_desc.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_job_desc.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_job_desc.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_job_desc.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_job_desc.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_job_desc.zz_OriginalDesign = true;
            this.ctl_job_desc.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_job_desc.zz_ShowNeedsSaveColor = true;
            this.ctl_job_desc.zz_Text = "";
            this.ctl_job_desc.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_job_desc.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_job_desc.zz_UseGlobalColor = false;
            this.ctl_job_desc.zz_UseGlobalFont = false;
            // 
            // txtPassword
            // 
            this.txtPassword.AllCaps = false;
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.Bold = false;
            this.txtPassword.Caption = "Password";
            this.txtPassword.Changed = false;
            this.txtPassword.IsEmail = false;
            this.txtPassword.IsURL = false;
            this.txtPassword.Location = new System.Drawing.Point(218, 221);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(186, 46);
            this.txtPassword.TabIndex = 51;
            this.txtPassword.UseParentBackColor = true;
            this.txtPassword.zz_Enabled = true;
            this.txtPassword.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtPassword.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtPassword.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtPassword.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtPassword.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.txtPassword.zz_OriginalDesign = true;
            this.txtPassword.zz_ShowLinkButton = false;
            this.txtPassword.zz_ShowNeedsSaveColor = true;
            this.txtPassword.zz_Text = "";
            this.txtPassword.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPassword.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtPassword.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.zz_UseGlobalColor = false;
            this.txtPassword.zz_UseGlobalFont = false;
            // 
            // ctl_login_name
            // 
            this.ctl_login_name.AllCaps = false;
            this.ctl_login_name.BackColor = System.Drawing.Color.White;
            this.ctl_login_name.Bold = false;
            this.ctl_login_name.Caption = "Login Name";
            this.ctl_login_name.Changed = false;
            this.ctl_login_name.IsEmail = false;
            this.ctl_login_name.IsURL = false;
            this.ctl_login_name.Location = new System.Drawing.Point(19, 221);
            this.ctl_login_name.Name = "ctl_login_name";
            this.ctl_login_name.PasswordChar = '\0';
            this.ctl_login_name.Size = new System.Drawing.Size(186, 46);
            this.ctl_login_name.TabIndex = 50;
            this.ctl_login_name.UseParentBackColor = true;
            this.ctl_login_name.zz_Enabled = true;
            this.ctl_login_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_login_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_login_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_login_name.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_login_name.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_login_name.zz_OriginalDesign = true;
            this.ctl_login_name.zz_ShowLinkButton = false;
            this.ctl_login_name.zz_ShowNeedsSaveColor = true;
            this.ctl_login_name.zz_Text = "";
            this.ctl_login_name.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_login_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_login_name.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_login_name.zz_UseGlobalColor = false;
            this.ctl_login_name.zz_UseGlobalFont = false;
            // 
            // ctl_user_initials
            // 
            this.ctl_user_initials.AllCaps = false;
            this.ctl_user_initials.BackColor = System.Drawing.Color.White;
            this.ctl_user_initials.Bold = false;
            this.ctl_user_initials.Caption = "Initials";
            this.ctl_user_initials.Changed = false;
            this.ctl_user_initials.IsEmail = false;
            this.ctl_user_initials.IsURL = false;
            this.ctl_user_initials.Location = new System.Drawing.Point(346, 23);
            this.ctl_user_initials.Name = "ctl_user_initials";
            this.ctl_user_initials.PasswordChar = '\0';
            this.ctl_user_initials.Size = new System.Drawing.Size(58, 46);
            this.ctl_user_initials.TabIndex = 49;
            this.ctl_user_initials.UseParentBackColor = true;
            this.ctl_user_initials.zz_Enabled = true;
            this.ctl_user_initials.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_user_initials.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_user_initials.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_user_initials.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_user_initials.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_user_initials.zz_OriginalDesign = true;
            this.ctl_user_initials.zz_ShowLinkButton = false;
            this.ctl_user_initials.zz_ShowNeedsSaveColor = true;
            this.ctl_user_initials.zz_Text = "";
            this.ctl_user_initials.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_user_initials.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_user_initials.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_user_initials.zz_UseGlobalColor = false;
            this.ctl_user_initials.zz_UseGlobalFont = false;
            // 
            // ctl_email_address
            // 
            this.ctl_email_address.AllCaps = false;
            this.ctl_email_address.BackColor = System.Drawing.Color.White;
            this.ctl_email_address.Bold = false;
            this.ctl_email_address.Caption = "Email Address";
            this.ctl_email_address.Changed = false;
            this.ctl_email_address.IsEmail = false;
            this.ctl_email_address.IsURL = false;
            this.ctl_email_address.Location = new System.Drawing.Point(19, 169);
            this.ctl_email_address.Name = "ctl_email_address";
            this.ctl_email_address.PasswordChar = '\0';
            this.ctl_email_address.Size = new System.Drawing.Size(385, 46);
            this.ctl_email_address.TabIndex = 48;
            this.ctl_email_address.UseParentBackColor = true;
            this.ctl_email_address.zz_Enabled = true;
            this.ctl_email_address.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_email_address.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_email_address.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_email_address.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_email_address.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_email_address.zz_OriginalDesign = true;
            this.ctl_email_address.zz_ShowLinkButton = false;
            this.ctl_email_address.zz_ShowNeedsSaveColor = true;
            this.ctl_email_address.zz_Text = "";
            this.ctl_email_address.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_email_address.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_email_address.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_email_address.zz_UseGlobalColor = false;
            this.ctl_email_address.zz_UseGlobalFont = false;
            // 
            // ctl_phone_ext
            // 
            this.ctl_phone_ext.AllCaps = false;
            this.ctl_phone_ext.BackColor = System.Drawing.Color.White;
            this.ctl_phone_ext.Bold = false;
            this.ctl_phone_ext.Caption = "Ext.";
            this.ctl_phone_ext.Changed = false;
            this.ctl_phone_ext.IsEmail = false;
            this.ctl_phone_ext.IsURL = false;
            this.ctl_phone_ext.Location = new System.Drawing.Point(218, 67);
            this.ctl_phone_ext.Name = "ctl_phone_ext";
            this.ctl_phone_ext.PasswordChar = '\0';
            this.ctl_phone_ext.Size = new System.Drawing.Size(58, 46);
            this.ctl_phone_ext.TabIndex = 47;
            this.ctl_phone_ext.UseParentBackColor = true;
            this.ctl_phone_ext.zz_Enabled = true;
            this.ctl_phone_ext.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_phone_ext.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_phone_ext.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_phone_ext.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_phone_ext.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_phone_ext.zz_OriginalDesign = true;
            this.ctl_phone_ext.zz_ShowLinkButton = false;
            this.ctl_phone_ext.zz_ShowNeedsSaveColor = true;
            this.ctl_phone_ext.zz_Text = "";
            this.ctl_phone_ext.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_phone_ext.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_phone_ext.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_phone_ext.zz_UseGlobalColor = false;
            this.ctl_phone_ext.zz_UseGlobalFont = false;
            // 
            // ctl_phone
            // 
            this.ctl_phone.AllCaps = false;
            this.ctl_phone.BackColor = System.Drawing.Color.White;
            this.ctl_phone.Bold = false;
            this.ctl_phone.Caption = "Phone Number";
            this.ctl_phone.Changed = false;
            this.ctl_phone.IsEmail = false;
            this.ctl_phone.IsURL = false;
            this.ctl_phone.Location = new System.Drawing.Point(19, 67);
            this.ctl_phone.Name = "ctl_phone";
            this.ctl_phone.PasswordChar = '\0';
            this.ctl_phone.Size = new System.Drawing.Size(186, 46);
            this.ctl_phone.TabIndex = 46;
            this.ctl_phone.UseParentBackColor = true;
            this.ctl_phone.zz_Enabled = true;
            this.ctl_phone.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_phone.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_phone.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_phone.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_phone.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_phone.zz_OriginalDesign = true;
            this.ctl_phone.zz_ShowLinkButton = false;
            this.ctl_phone.zz_ShowNeedsSaveColor = true;
            this.ctl_phone.zz_Text = "";
            this.ctl_phone.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_phone.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_phone.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_phone.zz_UseGlobalColor = false;
            this.ctl_phone.zz_UseGlobalFont = false;
            // 
            // ctl_super_user
            // 
            this.ctl_super_user.BackColor = System.Drawing.Color.White;
            this.ctl_super_user.Bold = false;
            this.ctl_super_user.Caption = "Super User";
            this.ctl_super_user.Changed = false;
            this.ctl_super_user.Location = new System.Drawing.Point(612, 23);
            this.ctl_super_user.Name = "ctl_super_user";
            this.ctl_super_user.Size = new System.Drawing.Size(79, 18);
            this.ctl_super_user.TabIndex = 45;
            this.ctl_super_user.UseParentBackColor = true;
            this.ctl_super_user.zz_CheckValue = false;
            this.ctl_super_user.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_super_user.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_super_user.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_super_user.zz_OriginalDesign = false;
            this.ctl_super_user.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_name
            // 
            this.ctl_name.AllCaps = false;
            this.ctl_name.BackColor = System.Drawing.Color.White;
            this.ctl_name.Bold = false;
            this.ctl_name.Caption = "Name";
            this.ctl_name.Changed = false;
            this.ctl_name.IsEmail = false;
            this.ctl_name.IsURL = false;
            this.ctl_name.Location = new System.Drawing.Point(19, 23);
            this.ctl_name.Name = "ctl_name";
            this.ctl_name.PasswordChar = '\0';
            this.ctl_name.Size = new System.Drawing.Size(321, 46);
            this.ctl_name.TabIndex = 44;
            this.ctl_name.UseParentBackColor = true;
            this.ctl_name.zz_Enabled = true;
            this.ctl_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_name.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_name.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_name.zz_OriginalDesign = true;
            this.ctl_name.zz_ShowLinkButton = false;
            this.ctl_name.zz_ShowNeedsSaveColor = true;
            this.ctl_name.zz_Text = "";
            this.ctl_name.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_name.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_name.zz_UseGlobalColor = false;
            this.ctl_name.zz_UseGlobalFont = false;
            // 
            // ctl_email_client
            // 
            this.ctl_email_client.AllCaps = false;
            this.ctl_email_client.AllowEdit = false;
            this.ctl_email_client.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_email_client.Bold = false;
            this.ctl_email_client.Caption = "Email Client";
            this.ctl_email_client.Changed = false;
            this.ctl_email_client.ListName = "email_client";
            this.ctl_email_client.Location = new System.Drawing.Point(637, 220);
            this.ctl_email_client.Name = "ctl_email_client";
            this.ctl_email_client.SimpleList = null;
            this.ctl_email_client.Size = new System.Drawing.Size(165, 46);
            this.ctl_email_client.TabIndex = 50;
            this.ctl_email_client.UseParentBackColor = false;
            this.ctl_email_client.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctl_email_client.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_email_client.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_email_client.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_email_client.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_email_client.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_email_client.zz_OriginalDesign = true;
            this.ctl_email_client.zz_ShowNeedsSaveColor = true;
            this.ctl_email_client.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_email_client.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_email_client.zz_UseGlobalColor = false;
            this.ctl_email_client.zz_UseGlobalFont = false;
            // 
            // tabSales
            // 
            this.tabSales.Controls.Add(this.groupBox1);
            this.tabSales.Controls.Add(this.gbSalesGoals);
            this.tabSales.Location = new System.Drawing.Point(4, 22);
            this.tabSales.Name = "tabSales";
            this.tabSales.Padding = new System.Windows.Forms.Padding(3);
            this.tabSales.Size = new System.Drawing.Size(818, 611);
            this.tabSales.TabIndex = 1;
            this.tabSales.Text = "Sales";
            this.tabSales.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctl_is_hubspot_enabled);
            this.groupBox1.Controls.Add(this.ctl_show_on_sales_screen);
            this.groupBox1.Controls.Add(this.ctl_showonprofit_report);
            this.groupBox1.Location = new System.Drawing.Point(6, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 124);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Integrations";
            // 
            // ctl_is_hubspot_enabled
            // 
            this.ctl_is_hubspot_enabled.BackColor = System.Drawing.Color.White;
            this.ctl_is_hubspot_enabled.Bold = false;
            this.ctl_is_hubspot_enabled.Caption = "Hubspot Enabled";
            this.ctl_is_hubspot_enabled.Changed = false;
            this.ctl_is_hubspot_enabled.Location = new System.Drawing.Point(6, 67);
            this.ctl_is_hubspot_enabled.Name = "ctl_is_hubspot_enabled";
            this.ctl_is_hubspot_enabled.Size = new System.Drawing.Size(108, 18);
            this.ctl_is_hubspot_enabled.TabIndex = 60;
            this.ctl_is_hubspot_enabled.UseParentBackColor = true;
            this.ctl_is_hubspot_enabled.zz_CheckValue = false;
            this.ctl_is_hubspot_enabled.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_hubspot_enabled.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_is_hubspot_enabled.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_hubspot_enabled.zz_OriginalDesign = false;
            this.ctl_is_hubspot_enabled.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_show_on_sales_screen
            // 
            this.ctl_show_on_sales_screen.BackColor = System.Drawing.Color.White;
            this.ctl_show_on_sales_screen.Bold = false;
            this.ctl_show_on_sales_screen.Caption = "Show On Sales Screen";
            this.ctl_show_on_sales_screen.Changed = false;
            this.ctl_show_on_sales_screen.Location = new System.Drawing.Point(6, 43);
            this.ctl_show_on_sales_screen.Name = "ctl_show_on_sales_screen";
            this.ctl_show_on_sales_screen.Size = new System.Drawing.Size(136, 18);
            this.ctl_show_on_sales_screen.TabIndex = 59;
            this.ctl_show_on_sales_screen.UseParentBackColor = true;
            this.ctl_show_on_sales_screen.zz_CheckValue = false;
            this.ctl_show_on_sales_screen.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_show_on_sales_screen.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_show_on_sales_screen.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_show_on_sales_screen.zz_OriginalDesign = false;
            this.ctl_show_on_sales_screen.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_showonprofit_report
            // 
            this.ctl_showonprofit_report.BackColor = System.Drawing.Color.White;
            this.ctl_showonprofit_report.Bold = false;
            this.ctl_showonprofit_report.Caption = "Show On Profit Report";
            this.ctl_showonprofit_report.Changed = false;
            this.ctl_showonprofit_report.Location = new System.Drawing.Point(6, 19);
            this.ctl_showonprofit_report.Name = "ctl_showonprofit_report";
            this.ctl_showonprofit_report.Size = new System.Drawing.Size(132, 18);
            this.ctl_showonprofit_report.TabIndex = 58;
            this.ctl_showonprofit_report.UseParentBackColor = true;
            this.ctl_showonprofit_report.zz_CheckValue = false;
            this.ctl_showonprofit_report.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_showonprofit_report.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_showonprofit_report.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_showonprofit_report.zz_OriginalDesign = false;
            this.ctl_showonprofit_report.zz_ShowNeedsSaveColor = true;
            // 
            // gbSalesGoals
            // 
            this.gbSalesGoals.Controls.Add(this.ctl_commission_bogey);
            this.gbSalesGoals.Controls.Add(this.ctl_monthly_invoiced_goal);
            this.gbSalesGoals.Controls.Add(this.ctl_commission_percent);
            this.gbSalesGoals.Controls.Add(this.ctl_monthly_booking_goal);
            this.gbSalesGoals.Controls.Add(this.ctl_monthly_np_goal);
            this.gbSalesGoals.Controls.Add(this.ctl_monthly_quote_goal);
            this.gbSalesGoals.Location = new System.Drawing.Point(6, 6);
            this.gbSalesGoals.Name = "gbSalesGoals";
            this.gbSalesGoals.Size = new System.Drawing.Size(352, 146);
            this.gbSalesGoals.TabIndex = 56;
            this.gbSalesGoals.TabStop = false;
            this.gbSalesGoals.Text = "Sales Goals";
            // 
            // ctl_commission_bogey
            // 
            this.ctl_commission_bogey.BackColor = System.Drawing.Color.Transparent;
            this.ctl_commission_bogey.Bold = false;
            this.ctl_commission_bogey.Caption = "Commission Bogey";
            this.ctl_commission_bogey.Changed = false;
            this.ctl_commission_bogey.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_commission_bogey.Location = new System.Drawing.Point(6, 19);
            this.ctl_commission_bogey.Name = "ctl_commission_bogey";
            this.ctl_commission_bogey.Size = new System.Drawing.Size(165, 35);
            this.ctl_commission_bogey.TabIndex = 51;
            this.ctl_commission_bogey.UseParentBackColor = false;
            this.ctl_commission_bogey.zz_Enabled = true;
            this.ctl_commission_bogey.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_commission_bogey.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_commission_bogey.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_commission_bogey.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_commission_bogey.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_commission_bogey.zz_OriginalDesign = false;
            this.ctl_commission_bogey.zz_ShowErrorColor = true;
            this.ctl_commission_bogey.zz_ShowNeedsSaveColor = true;
            this.ctl_commission_bogey.zz_Text = "";
            this.ctl_commission_bogey.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_commission_bogey.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_commission_bogey.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_commission_bogey.zz_UseGlobalColor = false;
            this.ctl_commission_bogey.zz_UseGlobalFont = false;
            // 
            // ctl_monthly_invoiced_goal
            // 
            this.ctl_monthly_invoiced_goal.BackColor = System.Drawing.Color.Transparent;
            this.ctl_monthly_invoiced_goal.Bold = false;
            this.ctl_monthly_invoiced_goal.Caption = "Monthly Invoiced GP Goal";
            this.ctl_monthly_invoiced_goal.Changed = false;
            this.ctl_monthly_invoiced_goal.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_monthly_invoiced_goal.Location = new System.Drawing.Point(176, 101);
            this.ctl_monthly_invoiced_goal.Name = "ctl_monthly_invoiced_goal";
            this.ctl_monthly_invoiced_goal.Size = new System.Drawing.Size(165, 35);
            this.ctl_monthly_invoiced_goal.TabIndex = 55;
            this.ctl_monthly_invoiced_goal.UseParentBackColor = false;
            this.ctl_monthly_invoiced_goal.zz_Enabled = true;
            this.ctl_monthly_invoiced_goal.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_monthly_invoiced_goal.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_monthly_invoiced_goal.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_monthly_invoiced_goal.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_monthly_invoiced_goal.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_monthly_invoiced_goal.zz_OriginalDesign = false;
            this.ctl_monthly_invoiced_goal.zz_ShowErrorColor = true;
            this.ctl_monthly_invoiced_goal.zz_ShowNeedsSaveColor = true;
            this.ctl_monthly_invoiced_goal.zz_Text = "";
            this.ctl_monthly_invoiced_goal.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_monthly_invoiced_goal.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_monthly_invoiced_goal.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_monthly_invoiced_goal.zz_UseGlobalColor = false;
            this.ctl_monthly_invoiced_goal.zz_UseGlobalFont = false;
            // 
            // ctl_commission_percent
            // 
            this.ctl_commission_percent.BackColor = System.Drawing.Color.Transparent;
            this.ctl_commission_percent.Bold = false;
            this.ctl_commission_percent.Caption = "Commission Percent";
            this.ctl_commission_percent.Changed = false;
            this.ctl_commission_percent.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_commission_percent.Location = new System.Drawing.Point(6, 60);
            this.ctl_commission_percent.Name = "ctl_commission_percent";
            this.ctl_commission_percent.Size = new System.Drawing.Size(165, 35);
            this.ctl_commission_percent.TabIndex = 50;
            this.ctl_commission_percent.UseParentBackColor = false;
            this.ctl_commission_percent.zz_Enabled = true;
            this.ctl_commission_percent.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_commission_percent.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_commission_percent.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_commission_percent.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_commission_percent.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_commission_percent.zz_OriginalDesign = false;
            this.ctl_commission_percent.zz_ShowErrorColor = true;
            this.ctl_commission_percent.zz_ShowNeedsSaveColor = true;
            this.ctl_commission_percent.zz_Text = "";
            this.ctl_commission_percent.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_commission_percent.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_commission_percent.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_commission_percent.zz_UseGlobalColor = false;
            this.ctl_commission_percent.zz_UseGlobalFont = false;
            // 
            // ctl_monthly_booking_goal
            // 
            this.ctl_monthly_booking_goal.BackColor = System.Drawing.Color.Transparent;
            this.ctl_monthly_booking_goal.Bold = false;
            this.ctl_monthly_booking_goal.Caption = "Monthly Booked GP Goal";
            this.ctl_monthly_booking_goal.Changed = false;
            this.ctl_monthly_booking_goal.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_monthly_booking_goal.Location = new System.Drawing.Point(176, 60);
            this.ctl_monthly_booking_goal.Name = "ctl_monthly_booking_goal";
            this.ctl_monthly_booking_goal.Size = new System.Drawing.Size(165, 35);
            this.ctl_monthly_booking_goal.TabIndex = 54;
            this.ctl_monthly_booking_goal.UseParentBackColor = false;
            this.ctl_monthly_booking_goal.zz_Enabled = true;
            this.ctl_monthly_booking_goal.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_monthly_booking_goal.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_monthly_booking_goal.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_monthly_booking_goal.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_monthly_booking_goal.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_monthly_booking_goal.zz_OriginalDesign = false;
            this.ctl_monthly_booking_goal.zz_ShowErrorColor = true;
            this.ctl_monthly_booking_goal.zz_ShowNeedsSaveColor = true;
            this.ctl_monthly_booking_goal.zz_Text = "";
            this.ctl_monthly_booking_goal.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_monthly_booking_goal.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_monthly_booking_goal.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_monthly_booking_goal.zz_UseGlobalColor = false;
            this.ctl_monthly_booking_goal.zz_UseGlobalFont = false;
            // 
            // ctl_monthly_np_goal
            // 
            this.ctl_monthly_np_goal.BackColor = System.Drawing.Color.Transparent;
            this.ctl_monthly_np_goal.Bold = false;
            this.ctl_monthly_np_goal.Caption = "Monthly NP Goal";
            this.ctl_monthly_np_goal.Changed = false;
            this.ctl_monthly_np_goal.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_monthly_np_goal.Location = new System.Drawing.Point(6, 101);
            this.ctl_monthly_np_goal.Name = "ctl_monthly_np_goal";
            this.ctl_monthly_np_goal.Size = new System.Drawing.Size(165, 35);
            this.ctl_monthly_np_goal.TabIndex = 52;
            this.ctl_monthly_np_goal.UseParentBackColor = false;
            this.ctl_monthly_np_goal.zz_Enabled = true;
            this.ctl_monthly_np_goal.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_monthly_np_goal.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_monthly_np_goal.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_monthly_np_goal.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_monthly_np_goal.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_monthly_np_goal.zz_OriginalDesign = false;
            this.ctl_monthly_np_goal.zz_ShowErrorColor = true;
            this.ctl_monthly_np_goal.zz_ShowNeedsSaveColor = true;
            this.ctl_monthly_np_goal.zz_Text = "";
            this.ctl_monthly_np_goal.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_monthly_np_goal.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_monthly_np_goal.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_monthly_np_goal.zz_UseGlobalColor = false;
            this.ctl_monthly_np_goal.zz_UseGlobalFont = false;
            // 
            // ctl_monthly_quote_goal
            // 
            this.ctl_monthly_quote_goal.BackColor = System.Drawing.Color.Transparent;
            this.ctl_monthly_quote_goal.Bold = false;
            this.ctl_monthly_quote_goal.Caption = "Monthly Quote GP Goal";
            this.ctl_monthly_quote_goal.Changed = false;
            this.ctl_monthly_quote_goal.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_monthly_quote_goal.Location = new System.Drawing.Point(176, 19);
            this.ctl_monthly_quote_goal.Name = "ctl_monthly_quote_goal";
            this.ctl_monthly_quote_goal.Size = new System.Drawing.Size(165, 35);
            this.ctl_monthly_quote_goal.TabIndex = 53;
            this.ctl_monthly_quote_goal.UseParentBackColor = false;
            this.ctl_monthly_quote_goal.zz_Enabled = true;
            this.ctl_monthly_quote_goal.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_monthly_quote_goal.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_monthly_quote_goal.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_monthly_quote_goal.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_monthly_quote_goal.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_monthly_quote_goal.zz_OriginalDesign = false;
            this.ctl_monthly_quote_goal.zz_ShowErrorColor = true;
            this.ctl_monthly_quote_goal.zz_ShowNeedsSaveColor = true;
            this.ctl_monthly_quote_goal.zz_Text = "";
            this.ctl_monthly_quote_goal.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_monthly_quote_goal.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_monthly_quote_goal.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_monthly_quote_goal.zz_UseGlobalColor = false;
            this.ctl_monthly_quote_goal.zz_UseGlobalFont = false;
            // 
            // tabRzSettings
            // 
            this.tabRzSettings.Controls.Add(this.chkViewAllAgentsCrossRef);
            this.tabRzSettings.Controls.Add(this.ctl_allow_list_export);
            this.tabRzSettings.Controls.Add(this.ctl_template_editor);
            this.tabRzSettings.Controls.Add(this.lvSettings);
            this.tabRzSettings.Location = new System.Drawing.Point(4, 22);
            this.tabRzSettings.Name = "tabRzSettings";
            this.tabRzSettings.Size = new System.Drawing.Size(818, 611);
            this.tabRzSettings.TabIndex = 2;
            this.tabRzSettings.Text = "RzSettings";
            this.tabRzSettings.UseVisualStyleBackColor = true;
            // 
            // chkViewAllAgentsCrossRef
            // 
            this.chkViewAllAgentsCrossRef.AutoSize = true;
            this.chkViewAllAgentsCrossRef.Location = new System.Drawing.Point(276, 13);
            this.chkViewAllAgentsCrossRef.Name = "chkViewAllAgentsCrossRef";
            this.chkViewAllAgentsCrossRef.Size = new System.Drawing.Size(193, 17);
            this.chkViewAllAgentsCrossRef.TabIndex = 77;
            this.chkViewAllAgentsCrossRef.Text = "View All Agents In Cross Reference";
            this.chkViewAllAgentsCrossRef.UseVisualStyleBackColor = true;
            // 
            // ctl_allow_list_export
            // 
            this.ctl_allow_list_export.BackColor = System.Drawing.Color.White;
            this.ctl_allow_list_export.Bold = false;
            this.ctl_allow_list_export.Caption = "Can Export Lists To Excel";
            this.ctl_allow_list_export.Changed = false;
            this.ctl_allow_list_export.Location = new System.Drawing.Point(6, 13);
            this.ctl_allow_list_export.Name = "ctl_allow_list_export";
            this.ctl_allow_list_export.Size = new System.Drawing.Size(147, 18);
            this.ctl_allow_list_export.TabIndex = 76;
            this.ctl_allow_list_export.UseParentBackColor = true;
            this.ctl_allow_list_export.zz_CheckValue = false;
            this.ctl_allow_list_export.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_allow_list_export.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_allow_list_export.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_allow_list_export.zz_OriginalDesign = false;
            this.ctl_allow_list_export.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_template_editor
            // 
            this.ctl_template_editor.BackColor = System.Drawing.Color.White;
            this.ctl_template_editor.Bold = false;
            this.ctl_template_editor.Caption = "Is Template Editor";
            this.ctl_template_editor.Changed = false;
            this.ctl_template_editor.Location = new System.Drawing.Point(159, 13);
            this.ctl_template_editor.Name = "ctl_template_editor";
            this.ctl_template_editor.Size = new System.Drawing.Size(111, 18);
            this.ctl_template_editor.TabIndex = 75;
            this.ctl_template_editor.UseParentBackColor = true;
            this.ctl_template_editor.zz_CheckValue = false;
            this.ctl_template_editor.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_template_editor.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_template_editor.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_template_editor.zz_OriginalDesign = false;
            this.ctl_template_editor.zz_ShowNeedsSaveColor = true;
            // 
            // lvSettings
            // 
            this.lvSettings.AddCaption = "Add A Settings";
            this.lvSettings.AllowActions = true;
            this.lvSettings.AllowAdd = true;
            this.lvSettings.AllowDelete = true;
            this.lvSettings.AllowDeleteAlways = false;
            this.lvSettings.AllowDrop = true;
            this.lvSettings.AllowOnlyOpenDelete = false;
            this.lvSettings.AlternateConnection = null;
            this.lvSettings.BackColor = System.Drawing.Color.White;
            this.lvSettings.Caption = "";
            this.lvSettings.CurrentTemplate = null;
            this.lvSettings.ExtraClassInfo = "";
            this.lvSettings.Location = new System.Drawing.Point(6, 43);
            this.lvSettings.MultiSelect = true;
            this.lvSettings.Name = "lvSettings";
            this.lvSettings.Size = new System.Drawing.Size(809, 266);
            this.lvSettings.SuppressSelectionChanged = false;
            this.lvSettings.TabIndex = 14;
            this.lvSettings.zz_OpenColumnMenu = false;
            this.lvSettings.zz_OrderLineType = "";
            this.lvSettings.zz_ShowAutoRefresh = true;
            this.lvSettings.zz_ShowUnlimited = true;
            // 
            // gbLeaderBoard
            // 
            this.gbLeaderBoard.Controls.Add(this.nEdit_Memo1);
            this.gbLeaderBoard.Controls.Add(this.pbLeaderboardImage);
            this.gbLeaderBoard.Controls.Add(this.ctl_leaderboard_image_url);
            this.gbLeaderBoard.Location = new System.Drawing.Point(19, 331);
            this.gbLeaderBoard.Name = "gbLeaderBoard";
            this.gbLeaderBoard.Size = new System.Drawing.Size(208, 277);
            this.gbLeaderBoard.TabIndex = 78;
            this.gbLeaderBoard.TabStop = false;
            this.gbLeaderBoard.Text = "LeaderBoard";
            // 
            // nEdit_Memo1
            // 
            this.nEdit_Memo1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nEdit_Memo1.Bold = false;
            this.nEdit_Memo1.Caption = "Leaderboard Text";
            this.nEdit_Memo1.Changed = false;
            this.nEdit_Memo1.DateLines = false;
            this.nEdit_Memo1.Location = new System.Drawing.Point(13, 225);
            this.nEdit_Memo1.Name = "nEdit_Memo1";
            this.nEdit_Memo1.Size = new System.Drawing.Size(179, 50);
            this.nEdit_Memo1.TabIndex = 59;
            this.nEdit_Memo1.UseParentBackColor = false;
            this.nEdit_Memo1.zz_Enabled = true;
            this.nEdit_Memo1.zz_GlobalColor = System.Drawing.Color.Black;
            this.nEdit_Memo1.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nEdit_Memo1.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.nEdit_Memo1.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nEdit_Memo1.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.nEdit_Memo1.zz_OriginalDesign = true;
            this.nEdit_Memo1.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.nEdit_Memo1.zz_ShowNeedsSaveColor = true;
            this.nEdit_Memo1.zz_Text = "";
            this.nEdit_Memo1.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.nEdit_Memo1.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nEdit_Memo1.zz_UseGlobalColor = false;
            this.nEdit_Memo1.zz_UseGlobalFont = false;
            // 
            // pbLeaderboardImage
            // 
            this.pbLeaderboardImage.Location = new System.Drawing.Point(13, 64);
            this.pbLeaderboardImage.Name = "pbLeaderboardImage";
            this.pbLeaderboardImage.Size = new System.Drawing.Size(179, 157);
            this.pbLeaderboardImage.TabIndex = 58;
            this.pbLeaderboardImage.TabStop = false;
            // 
            // ctl_leaderboard_image_url
            // 
            this.ctl_leaderboard_image_url.AllCaps = false;
            this.ctl_leaderboard_image_url.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_leaderboard_image_url.Bold = false;
            this.ctl_leaderboard_image_url.Caption = "Leaderboard Image URL";
            this.ctl_leaderboard_image_url.Changed = false;
            this.ctl_leaderboard_image_url.IsEmail = false;
            this.ctl_leaderboard_image_url.IsURL = true;
            this.ctl_leaderboard_image_url.Location = new System.Drawing.Point(13, 17);
            this.ctl_leaderboard_image_url.Name = "ctl_leaderboard_image_url";
            this.ctl_leaderboard_image_url.PasswordChar = '\0';
            this.ctl_leaderboard_image_url.Size = new System.Drawing.Size(179, 40);
            this.ctl_leaderboard_image_url.TabIndex = 57;
            this.ctl_leaderboard_image_url.UseParentBackColor = false;
            this.ctl_leaderboard_image_url.zz_Enabled = true;
            this.ctl_leaderboard_image_url.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_leaderboard_image_url.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_leaderboard_image_url.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_leaderboard_image_url.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_leaderboard_image_url.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_leaderboard_image_url.zz_OriginalDesign = true;
            this.ctl_leaderboard_image_url.zz_ShowLinkButton = false;
            this.ctl_leaderboard_image_url.zz_ShowNeedsSaveColor = true;
            this.ctl_leaderboard_image_url.zz_Text = "";
            this.ctl_leaderboard_image_url.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_leaderboard_image_url.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_leaderboard_image_url.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_leaderboard_image_url.zz_UseGlobalColor = false;
            this.ctl_leaderboard_image_url.zz_UseGlobalFont = false;
            // 
            // view_n_user
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Name = "view_n_user";
            this.Size = new System.Drawing.Size(980, 637);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabSales.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbSalesGoals.ResumeLayout(false);
            this.tabRzSettings.ResumeLayout(false);
            this.tabRzSettings.PerformLayout();
            this.gbLeaderBoard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLeaderboardImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.Button btnTestPasswordHash;
        protected nEdit_String txtTestPasswordHash;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.ComboBox cboCarrier;
        protected nEdit_String ctl_cell_number;
        protected nEdit_String ctl_alternate_email;
        protected nEdit_String ctl_alternate_initials;
        protected nEdit_Memo ctl_email_signature;
        protected nEdit_String ctl_fax_number;
        protected nEdit_Memo ctl_job_desc;
        protected nEdit_String txtPassword;
        protected nEdit_String ctl_login_name;
        protected nEdit_String ctl_user_initials;
        protected nEdit_String ctl_email_address;
        protected nEdit_String ctl_phone_ext;
        protected nEdit_String ctl_phone;
        protected nEdit_Boolean ctl_super_user;
        protected nEdit_String ctl_name;
        private System.Windows.Forms.TabPage tabSales;
        private System.Windows.Forms.TabPage tabRzSettings;
        protected nList lvSettings;
        protected nEdit_Number ctl_monthly_invoiced_goal;
        protected nEdit_Number ctl_monthly_booking_goal;
        protected nEdit_Number ctl_monthly_quote_goal;
        protected nEdit_Number ctl_monthly_np_goal;
        protected nEdit_Number ctl_commission_bogey;
        protected nEdit_Number ctl_commission_percent;
        private nEdit_List ctl_email_client;
        protected nEdit_Boolean ctl_is_accounting;
        private System.Windows.Forms.CheckBox chkViewAllAgentsCrossRef;
        protected nEdit_Boolean ctl_allow_list_export;
        protected nEdit_Boolean ctl_template_editor;
        private nEdit_String ctl_internal_phonenumber;
        private System.Windows.Forms.GroupBox gbSalesGoals;
        private System.Windows.Forms.GroupBox groupBox1;
        protected nEdit_Boolean ctl_is_hubspot_enabled;
        protected nEdit_Boolean ctl_show_on_sales_screen;
        protected nEdit_Boolean ctl_showonprofit_report;
        private nEdit_User ctl_AssistantTo;
        private System.Windows.Forms.GroupBox gbLeaderBoard;
        private nEdit_Memo nEdit_Memo1;
        private System.Windows.Forms.PictureBox pbLeaderboardImage;
        private nEdit_String ctl_leaderboard_image_url;
    }
}
