namespace NewMethod
{
    partial class frmDepot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepot));
            this.lv = new System.Windows.Forms.ListView();
            this.col = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuDepot = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCompIdent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdContinue = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.lblData = new System.Windows.Forms.Label();
            this.cmdApply = new System.Windows.Forms.Button();
            this.password = new NewMethod.nEdit_String();
            this.username = new NewMethod.nEdit_String();
            this.description = new NewMethod.nEdit_String();
            this.database = new NewMethod.nEdit_String();
            this.server = new NewMethod.nEdit_String();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.chkAskAgain = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRecall = new System.Windows.Forms.Label();
            this.recall_password = new NewMethod.nEdit_String();
            this.recall_username = new NewMethod.nEdit_String();
            this.recall_database = new NewMethod.nEdit_String();
            this.recall_server = new NewMethod.nEdit_String();
            this.cmdDisable = new System.Windows.Forms.Button();
            this.pIdent = new System.Windows.Forms.Panel();
            this.cmdSetIdent = new System.Windows.Forms.Button();
            this.cmdSetCompIdent = new System.Windows.Forms.Button();
            this.txtCompIdent = new NewMethod.nEdit_String();
            this.mnuDepot.SuspendLayout();
            this.gbConnection.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pIdent.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col});
            this.lv.ContextMenuStrip = this.mnuDepot;
            this.lv.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv.FullRowSelect = true;
            this.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(3, 5);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(672, 317);
            this.lv.TabIndex = 0;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
            // 
            // col
            // 
            this.col.Text = "Connections";
            this.col.Width = 276;
            // 
            // mnuDepot
            // 
            this.mnuDepot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit,
            this.mnuCompIdent,
            this.toolStripSeparator1,
            this.mnuDelete});
            this.mnuDepot.Name = "mnuDepot";
            this.mnuDepot.Size = new System.Drawing.Size(209, 76);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(208, 22);
            this.mnuEdit.Text = "&Edit";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuCompIdent
            // 
            this.mnuCompIdent.Name = "mnuCompIdent";
            this.mnuCompIdent.Size = new System.Drawing.Size(208, 22);
            this.mnuCompIdent.Text = "&Show Company Identifier";
            this.mnuCompIdent.Click += new System.EventHandler(this.mnuCompIdent_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(205, 6);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(208, 22);
            this.mnuDelete.Text = "&Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // cmdContinue
            // 
            this.cmdContinue.Location = new System.Drawing.Point(681, 12);
            this.cmdContinue.Name = "cmdContinue";
            this.cmdContinue.Size = new System.Drawing.Size(132, 106);
            this.cmdContinue.TabIndex = 1;
            this.cmdContinue.Text = "Continue";
            this.cmdContinue.UseVisualStyleBackColor = true;
            this.cmdContinue.Click += new System.EventHandler(this.cmdContinue_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(681, 294);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(132, 28);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // gbConnection
            // 
            this.gbConnection.Controls.Add(this.lblData);
            this.gbConnection.Controls.Add(this.cmdApply);
            this.gbConnection.Controls.Add(this.password);
            this.gbConnection.Controls.Add(this.username);
            this.gbConnection.Controls.Add(this.description);
            this.gbConnection.Controls.Add(this.database);
            this.gbConnection.Controls.Add(this.server);
            this.gbConnection.Location = new System.Drawing.Point(4, 329);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Size = new System.Drawing.Size(397, 214);
            this.gbConnection.TabIndex = 4;
            this.gbConnection.TabStop = false;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(186, 16);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(30, 13);
            this.lblData.TabIndex = 6;
            this.lblData.Text = "Data";
            this.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdApply
            // 
            this.cmdApply.Location = new System.Drawing.Point(8, 178);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(382, 28);
            this.cmdApply.TabIndex = 5;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // password
            // 
            this.password.AllCaps = false;
            this.password.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.password.Bold = false;
            this.password.Caption = "Password:";
            this.password.Changed = false;
            this.password.IsEmail = false;
            this.password.IsURL = false;
            this.password.Location = new System.Drawing.Point(233, 125);
            this.password.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(131, 47);
            this.password.TabIndex = 4;
            this.password.UseParentBackColor = false;
            this.password.zz_Enabled = true;
            this.password.zz_GlobalColor = System.Drawing.Color.Black;
            this.password.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.password.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.password.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.password.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.password.zz_OriginalDesign = true;
            this.password.zz_ShowLinkButton = false;
            this.password.zz_ShowNeedsSaveColor = true;
            this.password.zz_Text = "";
            this.password.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.password.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.password.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.zz_UseGlobalColor = false;
            this.password.zz_UseGlobalFont = false;
            // 
            // username
            // 
            this.username.AllCaps = false;
            this.username.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.username.Bold = false;
            this.username.Caption = "User Name:";
            this.username.Changed = false;
            this.username.IsEmail = false;
            this.username.IsURL = false;
            this.username.Location = new System.Drawing.Point(6, 125);
            this.username.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.username.Name = "username";
            this.username.PasswordChar = '\0';
            this.username.Size = new System.Drawing.Size(184, 47);
            this.username.TabIndex = 3;
            this.username.UseParentBackColor = false;
            this.username.zz_Enabled = true;
            this.username.zz_GlobalColor = System.Drawing.Color.Black;
            this.username.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.username.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.username.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.username.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.username.zz_OriginalDesign = true;
            this.username.zz_ShowLinkButton = false;
            this.username.zz_ShowNeedsSaveColor = true;
            this.username.zz_Text = "";
            this.username.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.username.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.username.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.zz_UseGlobalColor = false;
            this.username.zz_UseGlobalFont = false;
            // 
            // description
            // 
            this.description.AllCaps = false;
            this.description.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.description.Bold = false;
            this.description.Caption = "Description:";
            this.description.Changed = false;
            this.description.IsEmail = false;
            this.description.IsURL = false;
            this.description.Location = new System.Drawing.Point(8, 19);
            this.description.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.description.Name = "description";
            this.description.PasswordChar = '\0';
            this.description.Size = new System.Drawing.Size(382, 47);
            this.description.TabIndex = 2;
            this.description.UseParentBackColor = false;
            this.description.zz_Enabled = true;
            this.description.zz_GlobalColor = System.Drawing.Color.Black;
            this.description.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.description.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.description.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.description.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.description.zz_OriginalDesign = true;
            this.description.zz_ShowLinkButton = false;
            this.description.zz_ShowNeedsSaveColor = true;
            this.description.zz_Text = "";
            this.description.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.description.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.description.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.zz_UseGlobalColor = false;
            this.description.zz_UseGlobalFont = false;
            // 
            // database
            // 
            this.database.AllCaps = false;
            this.database.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.database.Bold = false;
            this.database.Caption = "Database:";
            this.database.Changed = false;
            this.database.IsEmail = false;
            this.database.IsURL = false;
            this.database.Location = new System.Drawing.Point(233, 72);
            this.database.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.database.Name = "database";
            this.database.PasswordChar = '\0';
            this.database.Size = new System.Drawing.Size(131, 47);
            this.database.TabIndex = 1;
            this.database.UseParentBackColor = false;
            this.database.zz_Enabled = true;
            this.database.zz_GlobalColor = System.Drawing.Color.Black;
            this.database.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.database.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.database.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.database.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.database.zz_OriginalDesign = true;
            this.database.zz_ShowLinkButton = false;
            this.database.zz_ShowNeedsSaveColor = true;
            this.database.zz_Text = "";
            this.database.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.database.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.database.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.database.zz_UseGlobalColor = false;
            this.database.zz_UseGlobalFont = false;
            // 
            // server
            // 
            this.server.AllCaps = false;
            this.server.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.server.Bold = false;
            this.server.Caption = "Server:";
            this.server.Changed = false;
            this.server.IsEmail = false;
            this.server.IsURL = false;
            this.server.Location = new System.Drawing.Point(6, 72);
            this.server.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.server.Name = "server";
            this.server.PasswordChar = '\0';
            this.server.Size = new System.Drawing.Size(184, 47);
            this.server.TabIndex = 0;
            this.server.UseParentBackColor = false;
            this.server.zz_Enabled = true;
            this.server.zz_GlobalColor = System.Drawing.Color.Black;
            this.server.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.server.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.server.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.server.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.server.zz_OriginalDesign = true;
            this.server.zz_ShowLinkButton = false;
            this.server.zz_ShowNeedsSaveColor = true;
            this.server.zz_Text = "";
            this.server.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.server.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.server.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server.zz_UseGlobalColor = false;
            this.server.zz_UseGlobalFont = false;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(681, 124);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(132, 28);
            this.cmdAdd.TabIndex = 5;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // chkAskAgain
            // 
            this.chkAskAgain.AutoSize = true;
            this.chkAskAgain.Checked = true;
            this.chkAskAgain.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAskAgain.Location = new System.Drawing.Point(685, 271);
            this.chkAskAgain.Name = "chkAskAgain";
            this.chkAskAgain.Size = new System.Drawing.Size(125, 17);
            this.chkAskAgain.TabIndex = 6;
            this.chkAskAgain.Text = "Ask Again Next Time";
            this.chkAskAgain.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRecall);
            this.groupBox1.Controls.Add(this.recall_password);
            this.groupBox1.Controls.Add(this.recall_username);
            this.groupBox1.Controls.Add(this.recall_database);
            this.groupBox1.Controls.Add(this.recall_server);
            this.groupBox1.Location = new System.Drawing.Point(416, 329);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 214);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // lblRecall
            // 
            this.lblRecall.AutoSize = true;
            this.lblRecall.Location = new System.Drawing.Point(186, 16);
            this.lblRecall.Name = "lblRecall";
            this.lblRecall.Size = new System.Drawing.Size(37, 13);
            this.lblRecall.TabIndex = 6;
            this.lblRecall.Text = "Recall";
            this.lblRecall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // recall_password
            // 
            this.recall_password.AllCaps = false;
            this.recall_password.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.recall_password.Bold = false;
            this.recall_password.Caption = "Password:";
            this.recall_password.Changed = false;
            this.recall_password.IsEmail = false;
            this.recall_password.IsURL = false;
            this.recall_password.Location = new System.Drawing.Point(245, 110);
            this.recall_password.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.recall_password.Name = "recall_password";
            this.recall_password.PasswordChar = '*';
            this.recall_password.Size = new System.Drawing.Size(131, 47);
            this.recall_password.TabIndex = 4;
            this.recall_password.UseParentBackColor = false;
            this.recall_password.zz_Enabled = true;
            this.recall_password.zz_GlobalColor = System.Drawing.Color.Black;
            this.recall_password.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.recall_password.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.recall_password.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.recall_password.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.recall_password.zz_OriginalDesign = true;
            this.recall_password.zz_ShowLinkButton = false;
            this.recall_password.zz_ShowNeedsSaveColor = true;
            this.recall_password.zz_Text = "";
            this.recall_password.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.recall_password.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.recall_password.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recall_password.zz_UseGlobalColor = false;
            this.recall_password.zz_UseGlobalFont = false;
            // 
            // recall_username
            // 
            this.recall_username.AllCaps = false;
            this.recall_username.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.recall_username.Bold = false;
            this.recall_username.Caption = "User Name:";
            this.recall_username.Changed = false;
            this.recall_username.IsEmail = false;
            this.recall_username.IsURL = false;
            this.recall_username.Location = new System.Drawing.Point(18, 110);
            this.recall_username.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.recall_username.Name = "recall_username";
            this.recall_username.PasswordChar = '\0';
            this.recall_username.Size = new System.Drawing.Size(184, 47);
            this.recall_username.TabIndex = 3;
            this.recall_username.UseParentBackColor = false;
            this.recall_username.zz_Enabled = true;
            this.recall_username.zz_GlobalColor = System.Drawing.Color.Black;
            this.recall_username.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.recall_username.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.recall_username.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.recall_username.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.recall_username.zz_OriginalDesign = true;
            this.recall_username.zz_ShowLinkButton = false;
            this.recall_username.zz_ShowNeedsSaveColor = true;
            this.recall_username.zz_Text = "";
            this.recall_username.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.recall_username.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.recall_username.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recall_username.zz_UseGlobalColor = false;
            this.recall_username.zz_UseGlobalFont = false;
            // 
            // recall_database
            // 
            this.recall_database.AllCaps = false;
            this.recall_database.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.recall_database.Bold = false;
            this.recall_database.Caption = "Database:";
            this.recall_database.Changed = false;
            this.recall_database.IsEmail = false;
            this.recall_database.IsURL = false;
            this.recall_database.Location = new System.Drawing.Point(245, 57);
            this.recall_database.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.recall_database.Name = "recall_database";
            this.recall_database.PasswordChar = '\0';
            this.recall_database.Size = new System.Drawing.Size(131, 47);
            this.recall_database.TabIndex = 1;
            this.recall_database.UseParentBackColor = false;
            this.recall_database.zz_Enabled = true;
            this.recall_database.zz_GlobalColor = System.Drawing.Color.Black;
            this.recall_database.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.recall_database.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.recall_database.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.recall_database.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.recall_database.zz_OriginalDesign = true;
            this.recall_database.zz_ShowLinkButton = false;
            this.recall_database.zz_ShowNeedsSaveColor = true;
            this.recall_database.zz_Text = "";
            this.recall_database.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.recall_database.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.recall_database.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recall_database.zz_UseGlobalColor = false;
            this.recall_database.zz_UseGlobalFont = false;
            // 
            // recall_server
            // 
            this.recall_server.AllCaps = false;
            this.recall_server.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.recall_server.Bold = false;
            this.recall_server.Caption = "Server:";
            this.recall_server.Changed = false;
            this.recall_server.IsEmail = false;
            this.recall_server.IsURL = false;
            this.recall_server.Location = new System.Drawing.Point(18, 57);
            this.recall_server.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.recall_server.Name = "recall_server";
            this.recall_server.PasswordChar = '\0';
            this.recall_server.Size = new System.Drawing.Size(184, 47);
            this.recall_server.TabIndex = 0;
            this.recall_server.UseParentBackColor = false;
            this.recall_server.zz_Enabled = true;
            this.recall_server.zz_GlobalColor = System.Drawing.Color.Black;
            this.recall_server.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.recall_server.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.recall_server.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.recall_server.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.recall_server.zz_OriginalDesign = true;
            this.recall_server.zz_ShowLinkButton = false;
            this.recall_server.zz_ShowNeedsSaveColor = true;
            this.recall_server.zz_Text = "";
            this.recall_server.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.recall_server.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.recall_server.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recall_server.zz_UseGlobalColor = false;
            this.recall_server.zz_UseGlobalFont = false;
            // 
            // cmdDisable
            // 
            this.cmdDisable.Location = new System.Drawing.Point(681, 227);
            this.cmdDisable.Name = "cmdDisable";
            this.cmdDisable.Size = new System.Drawing.Size(132, 28);
            this.cmdDisable.TabIndex = 8;
            this.cmdDisable.Text = "Stop System Selection";
            this.cmdDisable.UseVisualStyleBackColor = true;
            this.cmdDisable.Click += new System.EventHandler(this.cmdDisable_Click);
            // 
            // pIdent
            // 
            this.pIdent.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pIdent.Controls.Add(this.cmdSetIdent);
            this.pIdent.Controls.Add(this.cmdSetCompIdent);
            this.pIdent.Controls.Add(this.txtCompIdent);
            this.pIdent.Location = new System.Drawing.Point(679, 158);
            this.pIdent.Name = "pIdent";
            this.pIdent.Size = new System.Drawing.Size(138, 62);
            this.pIdent.TabIndex = 11;
            // 
            // cmdSetIdent
            // 
            this.cmdSetIdent.BackColor = System.Drawing.Color.Transparent;
            this.cmdSetIdent.ForeColor = System.Drawing.Color.Navy;
            this.cmdSetIdent.Location = new System.Drawing.Point(3, 39);
            this.cmdSetIdent.Name = "cmdSetIdent";
            this.cmdSetIdent.Size = new System.Drawing.Size(84, 21);
            this.cmdSetIdent.TabIndex = 13;
            this.cmdSetIdent.Text = "Set Ident";
            this.cmdSetIdent.UseVisualStyleBackColor = false;
            this.cmdSetIdent.Click += new System.EventHandler(this.cmdSetIdent_Click);
            // 
            // cmdSetCompIdent
            // 
            this.cmdSetCompIdent.BackColor = System.Drawing.Color.Transparent;
            this.cmdSetCompIdent.ForeColor = System.Drawing.Color.Navy;
            this.cmdSetCompIdent.Location = new System.Drawing.Point(88, 39);
            this.cmdSetCompIdent.Name = "cmdSetCompIdent";
            this.cmdSetCompIdent.Size = new System.Drawing.Size(48, 21);
            this.cmdSetCompIdent.TabIndex = 12;
            this.cmdSetCompIdent.Text = "Save";
            this.cmdSetCompIdent.UseVisualStyleBackColor = false;
            this.cmdSetCompIdent.Click += new System.EventHandler(this.cmdSetCompIdent_Click);
            // 
            // txtCompIdent
            // 
            this.txtCompIdent.AllCaps = false;
            this.txtCompIdent.BackColor = System.Drawing.Color.Transparent;
            this.txtCompIdent.Bold = false;
            this.txtCompIdent.Caption = "Company Identifier:";
            this.txtCompIdent.Changed = false;
            this.txtCompIdent.IsEmail = false;
            this.txtCompIdent.IsURL = false;
            this.txtCompIdent.Location = new System.Drawing.Point(3, 2);
            this.txtCompIdent.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtCompIdent.Name = "txtCompIdent";
            this.txtCompIdent.PasswordChar = '\0';
            this.txtCompIdent.Size = new System.Drawing.Size(152, 35);
            this.txtCompIdent.TabIndex = 11;
            this.txtCompIdent.UseParentBackColor = false;
            this.txtCompIdent.zz_Enabled = true;
            this.txtCompIdent.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtCompIdent.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtCompIdent.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtCompIdent.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompIdent.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.txtCompIdent.zz_OriginalDesign = false;
            this.txtCompIdent.zz_ShowLinkButton = false;
            this.txtCompIdent.zz_ShowNeedsSaveColor = false;
            this.txtCompIdent.zz_Text = "";
            this.txtCompIdent.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCompIdent.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtCompIdent.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompIdent.zz_UseGlobalColor = false;
            this.txtCompIdent.zz_UseGlobalFont = false;
            // 
            // frmDepot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 554);
            this.Controls.Add(this.pIdent);
            this.Controls.Add(this.cmdDisable);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkAskAgain);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.gbConnection);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdContinue);
            this.Controls.Add(this.lv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDepot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Selection";
            this.mnuDepot.ResumeLayout(false);
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pIdent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.Button cmdContinue;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.GroupBox gbConnection;
        private nEdit_String server;
        private nEdit_String database;
        private System.Windows.Forms.Button cmdApply;
        private nEdit_String password;
        private nEdit_String username;
        private nEdit_String description;
        private System.Windows.Forms.ColumnHeader col;
        private System.Windows.Forms.ContextMenuStrip mnuDepot;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.CheckBox chkAskAgain;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRecall;
        private nEdit_String recall_password;
        private nEdit_String recall_username;
        private nEdit_String recall_database;
        private nEdit_String recall_server;
        private System.Windows.Forms.Button cmdDisable;
        private System.Windows.Forms.Panel pIdent;
        private System.Windows.Forms.Button cmdSetCompIdent;
        private nEdit_String txtCompIdent;
        private System.Windows.Forms.ToolStripMenuItem mnuCompIdent;
        private System.Windows.Forms.Button cmdSetIdent;
    }
}