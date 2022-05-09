namespace MultiSearch
{
    partial class MultiSearchScreen
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
            try
            {
                CancelSearches();
                KillSearchThread();

                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch { }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiSearchScreen));
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.cmdSearch = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.tmrStatus = new System.Windows.Forms.Timer(this.components);
            this.cmdP = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.tmrStock = new System.Windows.Forms.Timer(this.components);
            this.cmdStock = new System.Windows.Forms.Button();
            this.tmrEEM = new System.Windows.Forms.Timer(this.components);
            this.lblLast = new System.Windows.Forms.Label();
            this.tmrBrokerForum = new System.Windows.Forms.Timer(this.components);
            this.cmdSettings = new System.Windows.Forms.Button();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.chkCheckAll = new NewMethod.nEdit_Boolean();
            this.cmdReload = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.gbSite = new System.Windows.Forms.GroupBox();
            this.ctl_auto_search = new NewMethod.nEdit_Boolean();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdSaveLogin = new System.Windows.Forms.Button();
            this.ctl_username = new NewMethod.nEdit_String();
            this.ctl_password = new NewMethod.nEdit_String();
            this.ctl_extradata = new NewMethod.nEdit_String();
            this.optUser = new System.Windows.Forms.RadioButton();
            this.optCompany = new System.Windows.Forms.RadioButton();
            this.cmdMoveDown = new System.Windows.Forms.Button();
            this.cmdMoveUp = new System.Windows.Forms.Button();
            this.lvSiteOrder = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pic = new System.Windows.Forms.PictureBox();
            this.txtPartNumber = new System.Windows.Forms.ComboBox();
            this.ts = new DraggableTabControl.DraggableTabControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkSearchAll = new NewMethod.nEdit_Boolean();
            this.gbSettings.SuspendLayout();
            this.gbSite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Fuchsia;
            this.il.Images.SetKeyName(0, "ready");
            this.il.Images.SetKeyName(1, "auto");
            this.il.Images.SetKeyName(2, "busy");
            this.il.Images.SetKeyName(3, "error");
            this.il.Images.SetKeyName(4, "noresults");
            this.il.Images.SetKeyName(5, "results");
            // 
            // cmdSearch
            // 
            this.cmdSearch.Image = global::RzInterfaceWin.Properties.Resources.ZoomHS;
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSearch.Location = new System.Drawing.Point(594, 3);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(73, 25);
            this.cmdSearch.TabIndex = 5;
            this.cmdSearch.Text = "&Search";
            this.cmdSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(3, 3);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(40, 16);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "Part #:";
            // 
            // tmrStatus
            // 
            this.tmrStatus.Interval = 500;
            this.tmrStatus.Tick += new System.EventHandler(this.tmrStatus_Tick);
            // 
            // cmdP
            // 
            this.cmdP.Location = new System.Drawing.Point(828, 3);
            this.cmdP.Name = "cmdP";
            this.cmdP.Size = new System.Drawing.Size(33, 21);
            this.cmdP.TabIndex = 6;
            this.cmdP.UseVisualStyleBackColor = true;
            this.cmdP.Visible = false;
            this.cmdP.Click += new System.EventHandler(this.cmdP_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(867, 6);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(49, 13);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "00:00:00";
            this.lblTime.Visible = false;
            // 
            // tmrStock
            // 
            this.tmrStock.Interval = 600000;
            this.tmrStock.Tick += new System.EventHandler(this.tmrStock_Tick);
            // 
            // cmdStock
            // 
            this.cmdStock.Location = new System.Drawing.Point(936, 3);
            this.cmdStock.Name = "cmdStock";
            this.cmdStock.Size = new System.Drawing.Size(63, 20);
            this.cmdStock.TabIndex = 9;
            this.cmdStock.Text = "Stock";
            this.cmdStock.UseVisualStyleBackColor = true;
            this.cmdStock.Visible = false;
            this.cmdStock.Click += new System.EventHandler(this.cmdStock_Click);
            // 
            // tmrEEM
            // 
            this.tmrEEM.Interval = 60000;
            this.tmrEEM.Tick += new System.EventHandler(this.tmrEEM_Tick);
            // 
            // lblLast
            // 
            this.lblLast.Location = new System.Drawing.Point(1009, 6);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(72, 16);
            this.lblLast.TabIndex = 10;
            this.lblLast.Text = "<last>";
            this.lblLast.Visible = false;
            // 
            // tmrBrokerForum
            // 
            this.tmrBrokerForum.Interval = 120500;
            this.tmrBrokerForum.Tick += new System.EventHandler(this.tmrBrokerForum_Tick);
            // 
            // cmdSettings
            // 
            this.cmdSettings.Image = global::RzInterfaceWin.Properties.Resources.NewCardHS;
            this.cmdSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSettings.Location = new System.Drawing.Point(747, 4);
            this.cmdSettings.Name = "cmdSettings";
            this.cmdSettings.Size = new System.Drawing.Size(71, 24);
            this.cmdSettings.TabIndex = 11;
            this.cmdSettings.Text = "Settings";
            this.cmdSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSettings.UseVisualStyleBackColor = true;
            this.cmdSettings.Click += new System.EventHandler(this.cmdSettings_Click);
            // 
            // gbSettings
            // 
            this.gbSettings.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gbSettings.Controls.Add(this.chkCheckAll);
            this.gbSettings.Controls.Add(this.cmdReload);
            this.gbSettings.Controls.Add(this.cmdClose);
            this.gbSettings.Controls.Add(this.gbSite);
            this.gbSettings.Controls.Add(this.optUser);
            this.gbSettings.Controls.Add(this.optCompany);
            this.gbSettings.Controls.Add(this.cmdMoveDown);
            this.gbSettings.Controls.Add(this.cmdMoveUp);
            this.gbSettings.Controls.Add(this.lvSiteOrder);
            this.gbSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSettings.ForeColor = System.Drawing.Color.Black;
            this.gbSettings.Location = new System.Drawing.Point(3, 29);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(662, 322);
            this.gbSettings.TabIndex = 12;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Site Settings";
            this.gbSettings.Visible = false;
            // 
            // chkCheckAll
            // 
            this.chkCheckAll.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.chkCheckAll.Bold = false;
            this.chkCheckAll.Caption = "Check/UnCheck All";
            this.chkCheckAll.Changed = false;
            this.chkCheckAll.Location = new System.Drawing.Point(208, 14);
            this.chkCheckAll.Name = "chkCheckAll";
            this.chkCheckAll.Size = new System.Drawing.Size(115, 13);
            this.chkCheckAll.TabIndex = 8;
            this.chkCheckAll.UseParentBackColor = false;
            this.chkCheckAll.zz_CheckValue = false;
            this.chkCheckAll.zz_LabelColor = System.Drawing.Color.Black;
            this.chkCheckAll.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCheckAll.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Left;
            this.chkCheckAll.zz_OriginalDesign = false;
            this.chkCheckAll.zz_ShowNeedsSaveColor = false;
            this.chkCheckAll.CheckChanged += new NewMethod.CheckChangedHandler(this.chkCheckAll_CheckChanged);
            // 
            // cmdReload
            // 
            this.cmdReload.ForeColor = System.Drawing.Color.Black;
            this.cmdReload.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdReload.ImageKey = "favs.bmp";
            this.cmdReload.ImageList = this.il;
            this.cmdReload.Location = new System.Drawing.Point(556, 263);
            this.cmdReload.Name = "cmdReload";
            this.cmdReload.Size = new System.Drawing.Size(85, 37);
            this.cmdReload.TabIndex = 7;
            this.cmdReload.Text = "ReLoad Sites";
            this.cmdReload.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdReload.UseVisualStyleBackColor = true;
            this.cmdReload.Click += new System.EventHandler(this.cmdReload_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.ForeColor = System.Drawing.Color.Black;
            this.cmdClose.Image = global::RzInterfaceWin.Properties.Resources.OK1221;
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdClose.Location = new System.Drawing.Point(379, 263);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(171, 37);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "Close";
            this.cmdClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // gbSite
            // 
            this.gbSite.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gbSite.Controls.Add(this.ctl_auto_search);
            this.gbSite.Controls.Add(this.cmdDelete);
            this.gbSite.Controls.Add(this.cmdSaveLogin);
            this.gbSite.Controls.Add(this.ctl_username);
            this.gbSite.Controls.Add(this.ctl_password);
            this.gbSite.Controls.Add(this.ctl_extradata);
            this.gbSite.ForeColor = System.Drawing.Color.Black;
            this.gbSite.Location = new System.Drawing.Point(379, 64);
            this.gbSite.Name = "gbSite";
            this.gbSite.Size = new System.Drawing.Size(262, 187);
            this.gbSite.TabIndex = 3;
            this.gbSite.TabStop = false;
            this.gbSite.Text = "Selected WebSite";
            // 
            // ctl_auto_search
            // 
            this.ctl_auto_search.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_auto_search.Bold = false;
            this.ctl_auto_search.Caption = "Auto Search";
            this.ctl_auto_search.Changed = false;
            this.ctl_auto_search.Location = new System.Drawing.Point(159, 12);
            this.ctl_auto_search.Name = "ctl_auto_search";
            this.ctl_auto_search.Size = new System.Drawing.Size(85, 18);
            this.ctl_auto_search.TabIndex = 7;
            this.ctl_auto_search.UseParentBackColor = false;
            this.ctl_auto_search.zz_CheckValue = false;
            this.ctl_auto_search.zz_LabelColor = System.Drawing.Color.Black;
            this.ctl_auto_search.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_auto_search.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_auto_search.zz_OriginalDesign = false;
            this.ctl_auto_search.zz_ShowNeedsSaveColor = true;
            // 
            // cmdDelete
            // 
            this.cmdDelete.ForeColor = System.Drawing.Color.Black;
            this.cmdDelete.Image = global::RzInterfaceWin.Properties.Resources.eventlogError;
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdDelete.Location = new System.Drawing.Point(7, 143);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(123, 37);
            this.cmdDelete.TabIndex = 6;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdSaveLogin
            // 
            this.cmdSaveLogin.ForeColor = System.Drawing.Color.Black;
            this.cmdSaveLogin.Image = global::RzInterfaceWin.Properties.Resources.saveHS;
            this.cmdSaveLogin.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdSaveLogin.Location = new System.Drawing.Point(133, 143);
            this.cmdSaveLogin.Name = "cmdSaveLogin";
            this.cmdSaveLogin.Size = new System.Drawing.Size(123, 37);
            this.cmdSaveLogin.TabIndex = 5;
            this.cmdSaveLogin.Text = "Save";
            this.cmdSaveLogin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdSaveLogin.UseVisualStyleBackColor = true;
            this.cmdSaveLogin.Click += new System.EventHandler(this.cmdSaveLogin_Click);
            // 
            // ctl_username
            // 
            this.ctl_username.AllCaps = false;
            this.ctl_username.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_username.Bold = false;
            this.ctl_username.Caption = "User Name";
            this.ctl_username.Changed = false;
            this.ctl_username.ForeColor = System.Drawing.Color.Black;
            this.ctl_username.IsEmail = false;
            this.ctl_username.IsURL = false;
            this.ctl_username.Location = new System.Drawing.Point(7, 14);
            this.ctl_username.Name = "ctl_username";
            this.ctl_username.PasswordChar = '\0';
            this.ctl_username.Size = new System.Drawing.Size(249, 40);
            this.ctl_username.TabIndex = 0;
            this.ctl_username.UseParentBackColor = true;
            this.ctl_username.zz_Enabled = true;
            this.ctl_username.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_username.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_username.zz_LabelColor = System.Drawing.Color.Black;
            this.ctl_username.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_username.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_username.zz_OriginalDesign = true;
            this.ctl_username.zz_ShowLinkButton = false;
            this.ctl_username.zz_ShowNeedsSaveColor = true;
            this.ctl_username.zz_Text = "";
            this.ctl_username.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_username.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_username.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_username.zz_UseGlobalColor = false;
            this.ctl_username.zz_UseGlobalFont = false;
            // 
            // ctl_password
            // 
            this.ctl_password.AllCaps = false;
            this.ctl_password.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_password.Bold = false;
            this.ctl_password.Caption = "Password";
            this.ctl_password.Changed = false;
            this.ctl_password.ForeColor = System.Drawing.Color.Black;
            this.ctl_password.IsEmail = false;
            this.ctl_password.IsURL = false;
            this.ctl_password.Location = new System.Drawing.Point(7, 57);
            this.ctl_password.Name = "ctl_password";
            this.ctl_password.PasswordChar = '*';
            this.ctl_password.Size = new System.Drawing.Size(249, 40);
            this.ctl_password.TabIndex = 1;
            this.ctl_password.UseParentBackColor = true;
            this.ctl_password.zz_Enabled = true;
            this.ctl_password.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_password.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_password.zz_LabelColor = System.Drawing.Color.Black;
            this.ctl_password.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_password.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_password.zz_OriginalDesign = true;
            this.ctl_password.zz_ShowLinkButton = false;
            this.ctl_password.zz_ShowNeedsSaveColor = true;
            this.ctl_password.zz_Text = "";
            this.ctl_password.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_password.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_password.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_password.zz_UseGlobalColor = false;
            this.ctl_password.zz_UseGlobalFont = false;
            // 
            // ctl_extradata
            // 
            this.ctl_extradata.AllCaps = false;
            this.ctl_extradata.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_extradata.Bold = false;
            this.ctl_extradata.Caption = "Extra Data";
            this.ctl_extradata.Changed = false;
            this.ctl_extradata.ForeColor = System.Drawing.Color.Black;
            this.ctl_extradata.IsEmail = false;
            this.ctl_extradata.IsURL = false;
            this.ctl_extradata.Location = new System.Drawing.Point(7, 100);
            this.ctl_extradata.Name = "ctl_extradata";
            this.ctl_extradata.PasswordChar = '\0';
            this.ctl_extradata.Size = new System.Drawing.Size(249, 40);
            this.ctl_extradata.TabIndex = 2;
            this.ctl_extradata.UseParentBackColor = true;
            this.ctl_extradata.zz_Enabled = true;
            this.ctl_extradata.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_extradata.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_extradata.zz_LabelColor = System.Drawing.Color.Black;
            this.ctl_extradata.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_extradata.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_extradata.zz_OriginalDesign = true;
            this.ctl_extradata.zz_ShowLinkButton = false;
            this.ctl_extradata.zz_ShowNeedsSaveColor = true;
            this.ctl_extradata.zz_Text = "";
            this.ctl_extradata.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_extradata.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_extradata.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_extradata.zz_UseGlobalColor = false;
            this.ctl_extradata.zz_UseGlobalFont = false;
            // 
            // optUser
            // 
            this.optUser.AutoSize = true;
            this.optUser.Location = new System.Drawing.Point(482, 32);
            this.optUser.Name = "optUser";
            this.optUser.Size = new System.Drawing.Size(68, 17);
            this.optUser.TabIndex = 4;
            this.optUser.Text = "User Info";
            this.optUser.UseVisualStyleBackColor = true;
            this.optUser.CheckedChanged += new System.EventHandler(this.optUser_CheckedChanged);
            // 
            // optCompany
            // 
            this.optCompany.AutoSize = true;
            this.optCompany.Checked = true;
            this.optCompany.Location = new System.Drawing.Point(386, 32);
            this.optCompany.Name = "optCompany";
            this.optCompany.Size = new System.Drawing.Size(90, 17);
            this.optCompany.TabIndex = 3;
            this.optCompany.TabStop = true;
            this.optCompany.Text = "Company Info";
            this.optCompany.UseVisualStyleBackColor = true;
            // 
            // cmdMoveDown
            // 
            this.cmdMoveDown.BackgroundImage = global::RzInterfaceWin.Properties.Resources.DownArrowHS;
            this.cmdMoveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdMoveDown.Location = new System.Drawing.Point(338, 173);
            this.cmdMoveDown.Name = "cmdMoveDown";
            this.cmdMoveDown.Size = new System.Drawing.Size(24, 60);
            this.cmdMoveDown.TabIndex = 2;
            this.cmdMoveDown.UseVisualStyleBackColor = true;
            this.cmdMoveDown.Click += new System.EventHandler(this.cmdMoveDown_Click);
            // 
            // cmdMoveUp
            // 
            this.cmdMoveUp.BackgroundImage = global::RzInterfaceWin.Properties.Resources.UpArrowHS;
            this.cmdMoveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdMoveUp.Location = new System.Drawing.Point(338, 107);
            this.cmdMoveUp.Name = "cmdMoveUp";
            this.cmdMoveUp.Size = new System.Drawing.Size(24, 60);
            this.cmdMoveUp.TabIndex = 1;
            this.cmdMoveUp.UseVisualStyleBackColor = true;
            this.cmdMoveUp.Click += new System.EventHandler(this.cmdMoveUp_Click);
            // 
            // lvSiteOrder
            // 
            this.lvSiteOrder.CheckBoxes = true;
            this.lvSiteOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvSiteOrder.FullRowSelect = true;
            this.lvSiteOrder.GridLines = true;
            this.lvSiteOrder.HideSelection = false;
            this.lvSiteOrder.Location = new System.Drawing.Point(6, 32);
            this.lvSiteOrder.MultiSelect = false;
            this.lvSiteOrder.Name = "lvSiteOrder";
            this.lvSiteOrder.Size = new System.Drawing.Size(317, 284);
            this.lvSiteOrder.TabIndex = 0;
            this.lvSiteOrder.UseCompatibleStateImageBehavior = false;
            this.lvSiteOrder.View = System.Windows.Forms.View.Details;
            this.lvSiteOrder.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvSiteOrder_ItemChecked);
            this.lvSiteOrder.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvSiteOrder_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Load Order";
            this.columnHeader1.Width = 97;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Website";
            this.columnHeader2.Width = 186;
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.Blue;
            this.pic.Location = new System.Drawing.Point(750, 123);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(100, 73);
            this.pic.TabIndex = 7;
            this.pic.TabStop = false;
            this.pic.Visible = false;
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.FormattingEnabled = true;
            this.txtPartNumber.Location = new System.Drawing.Point(40, 3);
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.Size = new System.Drawing.Size(548, 21);
            this.txtPartNumber.TabIndex = 13;
            // 
            // ts
            // 
            this.ts.AllowDrop = true;
            this.ts.ImageList = this.il;
            this.ts.Location = new System.Drawing.Point(6, 29);
            this.ts.Multiline = true;
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(738, 301);
            this.ts.TabIndex = 0;
            this.ts.zz_TabMoved += new DraggableTabControl.TabMoveHandler(this.ts_zz_TabMoved);
            this.ts.SelectedIndexChanged += new System.EventHandler(this.ts_SelectedIndexChanged);
            this.ts.Click += new System.EventHandler(this.ts_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 600000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkSearchAll
            // 
            this.chkSearchAll.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.chkSearchAll.Bold = false;
            this.chkSearchAll.Caption = "Search All";
            this.chkSearchAll.Changed = false;
            this.chkSearchAll.Location = new System.Drawing.Point(671, 6);
            this.chkSearchAll.Name = "chkSearchAll";
            this.chkSearchAll.Size = new System.Drawing.Size(74, 18);
            this.chkSearchAll.TabIndex = 14;
            this.chkSearchAll.UseParentBackColor = false;
            this.chkSearchAll.zz_CheckValue = false;
            this.chkSearchAll.zz_LabelColor = System.Drawing.Color.Black;
            this.chkSearchAll.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSearchAll.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.chkSearchAll.zz_OriginalDesign = false;
            this.chkSearchAll.zz_ShowNeedsSaveColor = true;
            // 
            // MultiSearchScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkSearchAll);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.ts);
            this.Controls.Add(this.txtPartNumber);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.cmdSettings);
            this.Controls.Add(this.lblLast);
            this.Controls.Add(this.cmdStock);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.cmdP);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.lblSearch);
            this.Name = "MultiSearchScreen";
            this.Size = new System.Drawing.Size(1189, 513);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmMultiSearch_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMultiSearch_MouseMove);
            this.Resize += new System.EventHandler(this.frmMultiSearch_Resize);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.gbSite.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Timer tmrStatus;
        private System.Windows.Forms.Button cmdP;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer tmrStock;
        private System.Windows.Forms.Button cmdStock;
        private System.Windows.Forms.Timer tmrEEM;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.Timer tmrBrokerForum;
        private System.Windows.Forms.Button cmdSettings;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.ListView lvSiteOrder;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button cmdMoveUp;
        private System.Windows.Forms.Button cmdMoveDown;
        private System.Windows.Forms.GroupBox gbSite;
        private NewMethod.nEdit_String ctl_password;
        private NewMethod.nEdit_String ctl_username;
        private NewMethod.nEdit_String ctl_extradata;
        private System.Windows.Forms.Button cmdSaveLogin;
        private System.Windows.Forms.RadioButton optUser;
        private System.Windows.Forms.RadioButton optCompany;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Button cmdReload;
        private DraggableTabControl.DraggableTabControl ts;
        private System.Windows.Forms.Timer timer1;
        private NewMethod.nEdit_Boolean ctl_auto_search;
        private NewMethod.nEdit_Boolean chkSearchAll;
        private NewMethod.nEdit_Boolean chkCheckAll;
        protected System.Windows.Forms.Button cmdSearch;
        protected System.Windows.Forms.ComboBox txtPartNumber;
    }
}

