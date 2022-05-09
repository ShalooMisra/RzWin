using Tools.Database;
namespace Rz5
{
    partial class ReqLine
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
                InitUn();

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
            this.ctl_internalcomment = new NewMethod.nEdit_Memo();
            this.ctl_target_price = new Rz5.Win.Controls.EditMoney();
            this.ctl_target_quantity = new NewMethod.nEdit_Number();
            this.ctl_datecode = new NewMethod.nEdit_String();
            this.ctl_fullpartnumber = new NewMethod.nEdit_String();
            this.ctl_unitprice = new Rz5.Win.Controls.EditMoney();
            this.ctl_quantityordered = new NewMethod.nEdit_Number();
            this.ctl_target_datecode = new NewMethod.nEdit_String();
            this.ctl_internalpartnumber = new NewMethod.nEdit_String();
            this.ctl_alternatepart = new NewMethod.nEdit_String();
            this.lblAdd = new System.Windows.Forms.LinkLabel();
            this.ctl_target_condition = new NewMethod.nEdit_List();
            this.ctl_target_delivery = new NewMethod.nEdit_List();
            this.ctl_delivery = new NewMethod.nEdit_List();
            this.ctl_condition = new NewMethod.nEdit_List();
            this.ctl_unitcost = new Rz5.Win.Controls.EditMoney();
            this.lblProfit = new System.Windows.Forms.Label();
            this.lblReceiveBid = new System.Windows.Forms.LinkLabel();
            this.ctl_alternatepart_04 = new NewMethod.nEdit_Memo();
            this.cmdPartSearch = new System.Windows.Forms.Button();
            this.cmdMultiSearch = new System.Windows.Forms.Button();
            this.ctl_is_priority = new NewMethod.nEdit_Boolean();
            this.ctl_source = new NewMethod.nEdit_List();
            this.ctl_rohs_info = new NewMethod.nEdit_List();
            this.ctl_dockdate = new NewMethod.nEdit_Date();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ts = new System.Windows.Forms.TabControl();
            this.tabDescription = new System.Windows.Forms.TabPage();
            this.tabReqNotes = new System.Windows.Forms.TabPage();
            this.tabQuoteNotes = new System.Windows.Forms.TabPage();
            this.tabStatus = new System.Windows.Forms.TabPage();
            this.ctl_status_notes = new NewMethod.nEdit_Memo();
            this.ctl_isselected = new NewMethod.nEdit_Boolean();
            this.ctl_ProductType = new NewMethod.nEdit_List();
            this.cmdEnterQty = new System.Windows.Forms.Button();
            this.ctl_is_strategic = new NewMethod.nEdit_Boolean();
            this.btnReqWizard = new System.Windows.Forms.Button();
            this.ctl_description = new NewMethod.nEdit_Memo();
            this.sc1 = new Rz5.SplitCommission();
            this.ctl_target_manufacturer = new NewMethod.nEdit_List();
            this.ctl_manufacturer = new NewMethod.nEdit_List();
            this.ctl_affiliate_id = new NewMethod.nEdit_String();
            this.panel2.SuspendLayout();
            this.ts.SuspendLayout();
            this.tabReqNotes.SuspendLayout();
            this.tabQuoteNotes.SuspendLayout();
            this.tabStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pCommands
            // 
            this.pCommands.Location = new System.Drawing.Point(1150, 67);
            // 
            // ctl_internalcomment
            // 
            this.ctl_internalcomment.BackColor = System.Drawing.Color.White;
            this.ctl_internalcomment.Bold = false;
            this.ctl_internalcomment.Caption = "";
            this.ctl_internalcomment.Changed = true;
            this.ctl_internalcomment.DateLines = false;
            this.ctl_internalcomment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctl_internalcomment.Location = new System.Drawing.Point(3, 3);
            this.ctl_internalcomment.Name = "ctl_internalcomment";
            this.ctl_internalcomment.Size = new System.Drawing.Size(290, 41);
            this.ctl_internalcomment.TabIndex = 38;
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
            // ctl_target_price
            // 
            this.ctl_target_price.BackColor = System.Drawing.Color.White;
            this.ctl_target_price.Bold = false;
            this.ctl_target_price.Caption = "Target Price";
            this.ctl_target_price.Changed = false;
            this.ctl_target_price.EditCaption = false;
            this.ctl_target_price.FullDecimal = false;
            this.ctl_target_price.Location = new System.Drawing.Point(31, 83);
            this.ctl_target_price.Name = "ctl_target_price";
            this.ctl_target_price.RoundNearestCent = false;
            this.ctl_target_price.Size = new System.Drawing.Size(110, 35);
            this.ctl_target_price.TabIndex = 3;
            this.ctl_target_price.UseParentBackColor = true;
            this.ctl_target_price.zz_Enabled = true;
            this.ctl_target_price.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_target_price.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_target_price.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_target_price.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_target_price.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_target_price.zz_OriginalDesign = false;
            this.ctl_target_price.zz_ShowErrorColor = true;
            this.ctl_target_price.zz_ShowNeedsSaveColor = true;
            this.ctl_target_price.zz_Text = "";
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
            this.ctl_target_quantity.Changed = false;
            this.ctl_target_quantity.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_target_quantity.Location = new System.Drawing.Point(31, 46);
            this.ctl_target_quantity.Name = "ctl_target_quantity";
            this.ctl_target_quantity.Size = new System.Drawing.Size(110, 35);
            this.ctl_target_quantity.TabIndex = 2;
            this.ctl_target_quantity.UseParentBackColor = true;
            this.ctl_target_quantity.zz_Enabled = true;
            this.ctl_target_quantity.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_target_quantity.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_target_quantity.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_target_quantity.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_target_quantity.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_target_quantity.zz_OriginalDesign = false;
            this.ctl_target_quantity.zz_ShowErrorColor = true;
            this.ctl_target_quantity.zz_ShowNeedsSaveColor = true;
            this.ctl_target_quantity.zz_Text = "";
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
            this.ctl_datecode.Caption = "Quote Date Code";
            this.ctl_datecode.Changed = false;
            this.ctl_datecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_datecode.IsEmail = false;
            this.ctl_datecode.IsURL = false;
            this.ctl_datecode.Location = new System.Drawing.Point(143, 160);
            this.ctl_datecode.Name = "ctl_datecode";
            this.ctl_datecode.PasswordChar = '\0';
            this.ctl_datecode.Size = new System.Drawing.Size(111, 35);
            this.ctl_datecode.TabIndex = 12;
            this.ctl_datecode.UseParentBackColor = true;
            this.ctl_datecode.zz_Enabled = true;
            this.ctl_datecode.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_datecode.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_datecode.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_datecode.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
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
            this.ctl_fullpartnumber.Location = new System.Drawing.Point(31, 10);
            this.ctl_fullpartnumber.Name = "ctl_fullpartnumber";
            this.ctl_fullpartnumber.PasswordChar = '\0';
            this.ctl_fullpartnumber.Size = new System.Drawing.Size(222, 35);
            this.ctl_fullpartnumber.TabIndex = 0;
            this.ctl_fullpartnumber.UseParentBackColor = true;
            this.ctl_fullpartnumber.zz_Enabled = true;
            this.ctl_fullpartnumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_fullpartnumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_fullpartnumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_fullpartnumber.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_fullpartnumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_fullpartnumber.zz_OriginalDesign = false;
            this.ctl_fullpartnumber.zz_ShowLinkButton = false;
            this.ctl_fullpartnumber.zz_ShowNeedsSaveColor = true;
            this.ctl_fullpartnumber.zz_Text = "";
            this.ctl_fullpartnumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_fullpartnumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_fullpartnumber.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_fullpartnumber.zz_UseGlobalColor = false;
            this.ctl_fullpartnumber.zz_UseGlobalFont = false;
            // 
            // ctl_unitprice
            // 
            this.ctl_unitprice.BackColor = System.Drawing.Color.White;
            this.ctl_unitprice.Bold = true;
            this.ctl_unitprice.Caption = "Quote Price";
            this.ctl_unitprice.Changed = false;
            this.ctl_unitprice.EditCaption = false;
            this.ctl_unitprice.FullDecimal = false;
            this.ctl_unitprice.Location = new System.Drawing.Point(143, 84);
            this.ctl_unitprice.Name = "ctl_unitprice";
            this.ctl_unitprice.RoundNearestCent = false;
            this.ctl_unitprice.Size = new System.Drawing.Size(110, 35);
            this.ctl_unitprice.TabIndex = 10;
            this.ctl_unitprice.UseParentBackColor = true;
            this.ctl_unitprice.zz_Enabled = true;
            this.ctl_unitprice.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_unitprice.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_unitprice.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_unitprice.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_unitprice.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_unitprice.zz_OriginalDesign = false;
            this.ctl_unitprice.zz_ShowErrorColor = true;
            this.ctl_unitprice.zz_ShowNeedsSaveColor = true;
            this.ctl_unitprice.zz_Text = "";
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
            this.ctl_quantityordered.Caption = "Quote Quantity";
            this.ctl_quantityordered.Changed = false;
            this.ctl_quantityordered.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_quantityordered.Location = new System.Drawing.Point(143, 46);
            this.ctl_quantityordered.Name = "ctl_quantityordered";
            this.ctl_quantityordered.Size = new System.Drawing.Size(110, 35);
            this.ctl_quantityordered.TabIndex = 9;
            this.ctl_quantityordered.UseParentBackColor = true;
            this.ctl_quantityordered.zz_Enabled = true;
            this.ctl_quantityordered.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_quantityordered.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_quantityordered.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_quantityordered.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_quantityordered.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_quantityordered.zz_OriginalDesign = false;
            this.ctl_quantityordered.zz_ShowErrorColor = true;
            this.ctl_quantityordered.zz_ShowNeedsSaveColor = true;
            this.ctl_quantityordered.zz_Text = "";
            this.ctl_quantityordered.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_quantityordered.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_quantityordered.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_quantityordered.zz_UseGlobalColor = false;
            this.ctl_quantityordered.zz_UseGlobalFont = false;
            // 
            // ctl_target_datecode
            // 
            this.ctl_target_datecode.AllCaps = false;
            this.ctl_target_datecode.BackColor = System.Drawing.Color.White;
            this.ctl_target_datecode.Bold = false;
            this.ctl_target_datecode.Caption = "Target Datecode";
            this.ctl_target_datecode.Changed = false;
            this.ctl_target_datecode.IsEmail = false;
            this.ctl_target_datecode.IsURL = false;
            this.ctl_target_datecode.Location = new System.Drawing.Point(31, 160);
            this.ctl_target_datecode.Name = "ctl_target_datecode";
            this.ctl_target_datecode.PasswordChar = '\0';
            this.ctl_target_datecode.Size = new System.Drawing.Size(110, 35);
            this.ctl_target_datecode.TabIndex = 5;
            this.ctl_target_datecode.UseParentBackColor = true;
            this.ctl_target_datecode.zz_Enabled = true;
            this.ctl_target_datecode.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_target_datecode.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_target_datecode.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_target_datecode.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_target_datecode.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_target_datecode.zz_OriginalDesign = false;
            this.ctl_target_datecode.zz_ShowLinkButton = false;
            this.ctl_target_datecode.zz_ShowNeedsSaveColor = true;
            this.ctl_target_datecode.zz_Text = "";
            this.ctl_target_datecode.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_target_datecode.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_target_datecode.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_target_datecode.zz_UseGlobalColor = false;
            this.ctl_target_datecode.zz_UseGlobalFont = false;
            // 
            // ctl_internalpartnumber
            // 
            this.ctl_internalpartnumber.AllCaps = false;
            this.ctl_internalpartnumber.BackColor = System.Drawing.Color.White;
            this.ctl_internalpartnumber.Bold = false;
            this.ctl_internalpartnumber.Caption = "Internal Part";
            this.ctl_internalpartnumber.Changed = false;
            this.ctl_internalpartnumber.IsEmail = false;
            this.ctl_internalpartnumber.IsURL = false;
            this.ctl_internalpartnumber.Location = new System.Drawing.Point(261, 84);
            this.ctl_internalpartnumber.Name = "ctl_internalpartnumber";
            this.ctl_internalpartnumber.PasswordChar = '\0';
            this.ctl_internalpartnumber.Size = new System.Drawing.Size(142, 35);
            this.ctl_internalpartnumber.TabIndex = 16;
            this.ctl_internalpartnumber.UseParentBackColor = true;
            this.ctl_internalpartnumber.zz_Enabled = true;
            this.ctl_internalpartnumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_internalpartnumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_internalpartnumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_internalpartnumber.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_internalpartnumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_internalpartnumber.zz_OriginalDesign = false;
            this.ctl_internalpartnumber.zz_ShowLinkButton = false;
            this.ctl_internalpartnumber.zz_ShowNeedsSaveColor = true;
            this.ctl_internalpartnumber.zz_Text = "";
            this.ctl_internalpartnumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_internalpartnumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_internalpartnumber.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internalpartnumber.zz_UseGlobalColor = false;
            this.ctl_internalpartnumber.zz_UseGlobalFont = false;
            // 
            // ctl_alternatepart
            // 
            this.ctl_alternatepart.AllCaps = false;
            this.ctl_alternatepart.BackColor = System.Drawing.Color.White;
            this.ctl_alternatepart.Bold = false;
            this.ctl_alternatepart.Caption = "Alternate Part";
            this.ctl_alternatepart.Changed = false;
            this.ctl_alternatepart.IsEmail = false;
            this.ctl_alternatepart.IsURL = false;
            this.ctl_alternatepart.Location = new System.Drawing.Point(261, 120);
            this.ctl_alternatepart.Name = "ctl_alternatepart";
            this.ctl_alternatepart.PasswordChar = '\0';
            this.ctl_alternatepart.Size = new System.Drawing.Size(142, 35);
            this.ctl_alternatepart.TabIndex = 17;
            this.ctl_alternatepart.UseParentBackColor = true;
            this.ctl_alternatepart.zz_Enabled = true;
            this.ctl_alternatepart.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_alternatepart.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_alternatepart.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_alternatepart.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_alternatepart.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_alternatepart.zz_OriginalDesign = false;
            this.ctl_alternatepart.zz_ShowLinkButton = false;
            this.ctl_alternatepart.zz_ShowNeedsSaveColor = true;
            this.ctl_alternatepart.zz_Text = "";
            this.ctl_alternatepart.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_alternatepart.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_alternatepart.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_alternatepart.zz_UseGlobalColor = false;
            this.ctl_alternatepart.zz_UseGlobalFont = false;
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Location = new System.Drawing.Point(1147, 194);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(25, 13);
            this.lblAdd.TabIndex = 51;
            this.lblAdd.TabStop = true;
            this.lblAdd.Text = "add";
            this.lblAdd.Visible = false;
            this.lblAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAdd_LinkClicked);
            // 
            // ctl_target_condition
            // 
            this.ctl_target_condition.AllCaps = false;
            this.ctl_target_condition.AllowEdit = false;
            this.ctl_target_condition.BackColor = System.Drawing.Color.White;
            this.ctl_target_condition.Bold = false;
            this.ctl_target_condition.Caption = "Target Condition ";
            this.ctl_target_condition.Changed = false;
            this.ctl_target_condition.ListName = "condition";
            this.ctl_target_condition.Location = new System.Drawing.Point(31, 196);
            this.ctl_target_condition.Name = "ctl_target_condition";
            this.ctl_target_condition.SimpleList = null;
            this.ctl_target_condition.Size = new System.Drawing.Size(110, 36);
            this.ctl_target_condition.TabIndex = 6;
            this.ctl_target_condition.UseParentBackColor = true;
            this.ctl_target_condition.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_target_condition.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_target_condition.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_target_condition.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_target_condition.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_target_condition.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_target_condition.zz_OriginalDesign = false;
            this.ctl_target_condition.zz_ShowNeedsSaveColor = true;
            this.ctl_target_condition.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_target_condition.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_target_condition.zz_UseGlobalColor = false;
            this.ctl_target_condition.zz_UseGlobalFont = false;
            // 
            // ctl_target_delivery
            // 
            this.ctl_target_delivery.AllCaps = false;
            this.ctl_target_delivery.AllowEdit = false;
            this.ctl_target_delivery.BackColor = System.Drawing.Color.White;
            this.ctl_target_delivery.Bold = false;
            this.ctl_target_delivery.Caption = "Target Delivery";
            this.ctl_target_delivery.Changed = false;
            this.ctl_target_delivery.ListName = "delivery";
            this.ctl_target_delivery.Location = new System.Drawing.Point(31, 234);
            this.ctl_target_delivery.Name = "ctl_target_delivery";
            this.ctl_target_delivery.SimpleList = null;
            this.ctl_target_delivery.Size = new System.Drawing.Size(110, 36);
            this.ctl_target_delivery.TabIndex = 7;
            this.ctl_target_delivery.UseParentBackColor = true;
            this.ctl_target_delivery.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_target_delivery.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_target_delivery.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_target_delivery.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_target_delivery.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_target_delivery.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_target_delivery.zz_OriginalDesign = false;
            this.ctl_target_delivery.zz_ShowNeedsSaveColor = true;
            this.ctl_target_delivery.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_target_delivery.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_target_delivery.zz_UseGlobalColor = false;
            this.ctl_target_delivery.zz_UseGlobalFont = false;
            // 
            // ctl_delivery
            // 
            this.ctl_delivery.AllCaps = false;
            this.ctl_delivery.AllowEdit = false;
            this.ctl_delivery.BackColor = System.Drawing.Color.White;
            this.ctl_delivery.Bold = false;
            this.ctl_delivery.Caption = "Quote Delivery";
            this.ctl_delivery.Changed = false;
            this.ctl_delivery.ListName = "delivery";
            this.ctl_delivery.Location = new System.Drawing.Point(143, 234);
            this.ctl_delivery.Name = "ctl_delivery";
            this.ctl_delivery.SimpleList = null;
            this.ctl_delivery.Size = new System.Drawing.Size(111, 36);
            this.ctl_delivery.TabIndex = 14;
            this.ctl_delivery.UseParentBackColor = true;
            this.ctl_delivery.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_delivery.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_delivery.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_delivery.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_delivery.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_delivery.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_delivery.zz_OriginalDesign = false;
            this.ctl_delivery.zz_ShowNeedsSaveColor = true;
            this.ctl_delivery.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_delivery.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_delivery.zz_UseGlobalColor = false;
            this.ctl_delivery.zz_UseGlobalFont = false;
            // 
            // ctl_condition
            // 
            this.ctl_condition.AllCaps = false;
            this.ctl_condition.AllowEdit = false;
            this.ctl_condition.BackColor = System.Drawing.Color.White;
            this.ctl_condition.Bold = false;
            this.ctl_condition.Caption = "Quote Condition";
            this.ctl_condition.Changed = false;
            this.ctl_condition.ListName = "condition";
            this.ctl_condition.Location = new System.Drawing.Point(143, 196);
            this.ctl_condition.Name = "ctl_condition";
            this.ctl_condition.SimpleList = null;
            this.ctl_condition.Size = new System.Drawing.Size(111, 36);
            this.ctl_condition.TabIndex = 13;
            this.ctl_condition.UseParentBackColor = true;
            this.ctl_condition.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_condition.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_condition.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_condition.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_condition.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_condition.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_condition.zz_OriginalDesign = false;
            this.ctl_condition.zz_ShowNeedsSaveColor = true;
            this.ctl_condition.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_condition.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_condition.zz_UseGlobalColor = false;
            this.ctl_condition.zz_UseGlobalFont = false;
            // 
            // ctl_unitcost
            // 
            this.ctl_unitcost.BackColor = System.Drawing.Color.White;
            this.ctl_unitcost.Bold = false;
            this.ctl_unitcost.Caption = "Cost";
            this.ctl_unitcost.Changed = false;
            this.ctl_unitcost.EditCaption = false;
            this.ctl_unitcost.FullDecimal = false;
            this.ctl_unitcost.Location = new System.Drawing.Point(261, 46);
            this.ctl_unitcost.Name = "ctl_unitcost";
            this.ctl_unitcost.RoundNearestCent = false;
            this.ctl_unitcost.Size = new System.Drawing.Size(141, 35);
            this.ctl_unitcost.TabIndex = 15;
            this.ctl_unitcost.UseParentBackColor = true;
            this.ctl_unitcost.zz_Enabled = true;
            this.ctl_unitcost.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_unitcost.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_unitcost.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_unitcost.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_unitcost.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_unitcost.zz_OriginalDesign = false;
            this.ctl_unitcost.zz_ShowErrorColor = true;
            this.ctl_unitcost.zz_ShowNeedsSaveColor = true;
            this.ctl_unitcost.zz_Text = "";
            this.ctl_unitcost.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_unitcost.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_unitcost.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_unitcost.zz_UseGlobalColor = false;
            this.ctl_unitcost.zz_UseGlobalFont = false;
            // 
            // lblProfit
            // 
            this.lblProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfit.ForeColor = System.Drawing.Color.Green;
            this.lblProfit.Location = new System.Drawing.Point(3, 14);
            this.lblProfit.Name = "lblProfit";
            this.lblProfit.Size = new System.Drawing.Size(138, 20);
            this.lblProfit.TabIndex = 62;
            this.lblProfit.Text = "$100,000,000.00";
            this.lblProfit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblReceiveBid
            // 
            this.lblReceiveBid.AutoSize = true;
            this.lblReceiveBid.Location = new System.Drawing.Point(1182, 194);
            this.lblReceiveBid.Name = "lblReceiveBid";
            this.lblReceiveBid.Size = new System.Drawing.Size(65, 13);
            this.lblReceiveBid.TabIndex = 63;
            this.lblReceiveBid.TabStop = true;
            this.lblReceiveBid.Text = "Receive Bid";
            this.lblReceiveBid.Visible = false;
            this.lblReceiveBid.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblReceiveBid_LinkClicked);
            // 
            // ctl_alternatepart_04
            // 
            this.ctl_alternatepart_04.BackColor = System.Drawing.Color.White;
            this.ctl_alternatepart_04.Bold = false;
            this.ctl_alternatepart_04.Caption = "";
            this.ctl_alternatepart_04.Changed = false;
            this.ctl_alternatepart_04.DateLines = false;
            this.ctl_alternatepart_04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctl_alternatepart_04.Location = new System.Drawing.Point(3, 3);
            this.ctl_alternatepart_04.Name = "ctl_alternatepart_04";
            this.ctl_alternatepart_04.Size = new System.Drawing.Size(290, 41);
            this.ctl_alternatepart_04.TabIndex = 71;
            this.ctl_alternatepart_04.UseParentBackColor = true;
            this.ctl_alternatepart_04.zz_Enabled = true;
            this.ctl_alternatepart_04.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_alternatepart_04.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_alternatepart_04.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_alternatepart_04.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_alternatepart_04.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_alternatepart_04.zz_OriginalDesign = false;
            this.ctl_alternatepart_04.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ctl_alternatepart_04.zz_ShowNeedsSaveColor = true;
            this.ctl_alternatepart_04.zz_Text = "";
            this.ctl_alternatepart_04.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_alternatepart_04.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_alternatepart_04.zz_UseGlobalColor = false;
            this.ctl_alternatepart_04.zz_UseGlobalFont = false;
            // 
            // cmdPartSearch
            // 
            this.cmdPartSearch.Location = new System.Drawing.Point(113, 4);
            this.cmdPartSearch.Name = "cmdPartSearch";
            this.cmdPartSearch.Size = new System.Drawing.Size(69, 19);
            this.cmdPartSearch.TabIndex = 1;
            this.cmdPartSearch.Text = "PartSearch";
            this.cmdPartSearch.UseVisualStyleBackColor = true;
            this.cmdPartSearch.Click += new System.EventHandler(this.cmdPartSearch_Click);
            // 
            // cmdMultiSearch
            // 
            this.cmdMultiSearch.Location = new System.Drawing.Point(182, 4);
            this.cmdMultiSearch.Name = "cmdMultiSearch";
            this.cmdMultiSearch.Size = new System.Drawing.Size(72, 19);
            this.cmdMultiSearch.TabIndex = 76;
            this.cmdMultiSearch.Text = "MultiSearch";
            this.cmdMultiSearch.UseVisualStyleBackColor = true;
            this.cmdMultiSearch.Click += new System.EventHandler(this.cmdMultiSearch_Click);
            // 
            // ctl_is_priority
            // 
            this.ctl_is_priority.BackColor = System.Drawing.Color.White;
            this.ctl_is_priority.Bold = false;
            this.ctl_is_priority.Caption = "Priority";
            this.ctl_is_priority.Changed = false;
            this.ctl_is_priority.Location = new System.Drawing.Point(721, 63);
            this.ctl_is_priority.Name = "ctl_is_priority";
            this.ctl_is_priority.Size = new System.Drawing.Size(57, 18);
            this.ctl_is_priority.TabIndex = 88;
            this.ctl_is_priority.UseParentBackColor = true;
            this.ctl_is_priority.Visible = false;
            this.ctl_is_priority.zz_CheckValue = false;
            this.ctl_is_priority.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_priority.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_is_priority.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Left;
            this.ctl_is_priority.zz_OriginalDesign = false;
            this.ctl_is_priority.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_source
            // 
            this.ctl_source.AllCaps = false;
            this.ctl_source.AllowEdit = true;
            this.ctl_source.BackColor = System.Drawing.Color.White;
            this.ctl_source.Bold = false;
            this.ctl_source.Caption = "Source";
            this.ctl_source.Changed = false;
            this.ctl_source.ListName = "source";
            this.ctl_source.Location = new System.Drawing.Point(824, 77);
            this.ctl_source.Name = "ctl_source";
            this.ctl_source.SimpleList = null;
            this.ctl_source.Size = new System.Drawing.Size(142, 36);
            this.ctl_source.TabIndex = 89;
            this.ctl_source.UseParentBackColor = true;
            this.ctl_source.Visible = false;
            this.ctl_source.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_source.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_source.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_source.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_source.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_source.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_source.zz_OriginalDesign = false;
            this.ctl_source.zz_ShowNeedsSaveColor = true;
            this.ctl_source.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_source.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_source.zz_UseGlobalColor = false;
            this.ctl_source.zz_UseGlobalFont = false;
            // 
            // ctl_rohs_info
            // 
            this.ctl_rohs_info.AllCaps = false;
            this.ctl_rohs_info.AllowEdit = false;
            this.ctl_rohs_info.BackColor = System.Drawing.Color.White;
            this.ctl_rohs_info.Bold = false;
            this.ctl_rohs_info.Caption = "RoHS Info";
            this.ctl_rohs_info.Changed = false;
            this.ctl_rohs_info.ListName = "";
            this.ctl_rohs_info.Location = new System.Drawing.Point(261, 159);
            this.ctl_rohs_info.Name = "ctl_rohs_info";
            this.ctl_rohs_info.SimpleList = "Y|N|U";
            this.ctl_rohs_info.Size = new System.Drawing.Size(142, 36);
            this.ctl_rohs_info.TabIndex = 18;
            this.ctl_rohs_info.UseParentBackColor = true;
            this.ctl_rohs_info.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_rohs_info.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_rohs_info.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_rohs_info.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_rohs_info.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_rohs_info.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_rohs_info.zz_OriginalDesign = false;
            this.ctl_rohs_info.zz_ShowNeedsSaveColor = true;
            this.ctl_rohs_info.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_rohs_info.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_rohs_info.zz_UseGlobalColor = false;
            this.ctl_rohs_info.zz_UseGlobalFont = false;
            // 
            // ctl_dockdate
            // 
            this.ctl_dockdate.AllowClear = false;
            this.ctl_dockdate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ctl_dockdate.Bold = false;
            this.ctl_dockdate.Caption = "Customer Dock Date";
            this.ctl_dockdate.Changed = false;
            this.ctl_dockdate.Location = new System.Drawing.Point(850, 138);
            this.ctl_dockdate.Name = "ctl_dockdate";
            this.ctl_dockdate.Size = new System.Drawing.Size(294, 46);
            this.ctl_dockdate.SuppressEdit = false;
            this.ctl_dockdate.TabIndex = 99;
            this.ctl_dockdate.UseParentBackColor = false;
            this.ctl_dockdate.Visible = false;
            this.ctl_dockdate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_dockdate.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_dockdate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_dockdate.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_dockdate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopCenter;
            this.ctl_dockdate.zz_OriginalDesign = false;
            this.ctl_dockdate.zz_ShowNeedsSaveColor = true;
            this.ctl_dockdate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_dockdate.zz_TextFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_dockdate.zz_UseGlobalColor = false;
            this.ctl_dockdate.zz_UseGlobalFont = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 101;
            this.label1.Text = "Profit";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Honeydew;
            this.panel2.Controls.Add(this.lblProfit);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(261, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(142, 35);
            this.panel2.TabIndex = 102;
            // 
            // ts
            // 
            this.ts.Controls.Add(this.tabDescription);
            this.ts.Controls.Add(this.tabReqNotes);
            this.ts.Controls.Add(this.tabQuoteNotes);
            this.ts.Controls.Add(this.tabStatus);
            this.ts.Location = new System.Drawing.Point(409, 8);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(304, 73);
            this.ts.TabIndex = 103;
            this.ts.Visible = false;
            // 
            // tabDescription
            // 
            this.tabDescription.Location = new System.Drawing.Point(4, 22);
            this.tabDescription.Name = "tabDescription";
            this.tabDescription.Padding = new System.Windows.Forms.Padding(3);
            this.tabDescription.Size = new System.Drawing.Size(296, 47);
            this.tabDescription.TabIndex = 2;
            this.tabDescription.Text = "Description";
            this.tabDescription.UseVisualStyleBackColor = true;
            // 
            // tabReqNotes
            // 
            this.tabReqNotes.Controls.Add(this.ctl_alternatepart_04);
            this.tabReqNotes.Location = new System.Drawing.Point(4, 22);
            this.tabReqNotes.Name = "tabReqNotes";
            this.tabReqNotes.Padding = new System.Windows.Forms.Padding(3);
            this.tabReqNotes.Size = new System.Drawing.Size(296, 47);
            this.tabReqNotes.TabIndex = 0;
            this.tabReqNotes.Text = "Req Notes";
            this.tabReqNotes.UseVisualStyleBackColor = true;
            // 
            // tabQuoteNotes
            // 
            this.tabQuoteNotes.Controls.Add(this.ctl_internalcomment);
            this.tabQuoteNotes.Location = new System.Drawing.Point(4, 22);
            this.tabQuoteNotes.Name = "tabQuoteNotes";
            this.tabQuoteNotes.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuoteNotes.Size = new System.Drawing.Size(296, 47);
            this.tabQuoteNotes.TabIndex = 1;
            this.tabQuoteNotes.Text = "Quote Notes";
            this.tabQuoteNotes.UseVisualStyleBackColor = true;
            // 
            // tabStatus
            // 
            this.tabStatus.Controls.Add(this.ctl_status_notes);
            this.tabStatus.Location = new System.Drawing.Point(4, 22);
            this.tabStatus.Name = "tabStatus";
            this.tabStatus.Size = new System.Drawing.Size(296, 47);
            this.tabStatus.TabIndex = 3;
            this.tabStatus.Text = "Status";
            this.tabStatus.UseVisualStyleBackColor = true;
            // 
            // ctl_status_notes
            // 
            this.ctl_status_notes.BackColor = System.Drawing.Color.White;
            this.ctl_status_notes.Bold = false;
            this.ctl_status_notes.Caption = "";
            this.ctl_status_notes.Changed = false;
            this.ctl_status_notes.DateLines = false;
            this.ctl_status_notes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctl_status_notes.Location = new System.Drawing.Point(0, 0);
            this.ctl_status_notes.Name = "ctl_status_notes";
            this.ctl_status_notes.Size = new System.Drawing.Size(296, 47);
            this.ctl_status_notes.TabIndex = 73;
            this.ctl_status_notes.UseParentBackColor = true;
            this.ctl_status_notes.zz_Enabled = true;
            this.ctl_status_notes.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_status_notes.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_status_notes.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_status_notes.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_status_notes.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_status_notes.zz_OriginalDesign = false;
            this.ctl_status_notes.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ctl_status_notes.zz_ShowNeedsSaveColor = true;
            this.ctl_status_notes.zz_Text = "";
            this.ctl_status_notes.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_status_notes.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_status_notes.zz_UseGlobalColor = false;
            this.ctl_status_notes.zz_UseGlobalFont = false;
            // 
            // ctl_isselected
            // 
            this.ctl_isselected.BackColor = System.Drawing.Color.Transparent;
            this.ctl_isselected.Bold = false;
            this.ctl_isselected.Caption = "Is Selected";
            this.ctl_isselected.Changed = false;
            this.ctl_isselected.Location = new System.Drawing.Point(719, 8);
            this.ctl_isselected.Name = "ctl_isselected";
            this.ctl_isselected.Size = new System.Drawing.Size(119, 20);
            this.ctl_isselected.TabIndex = 128;
            this.ctl_isselected.UseParentBackColor = false;
            this.ctl_isselected.Visible = false;
            this.ctl_isselected.zz_CheckValue = false;
            this.ctl_isselected.zz_LabelColor = System.Drawing.Color.Blue;
            this.ctl_isselected.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_isselected.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_isselected.zz_OriginalDesign = false;
            this.ctl_isselected.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_ProductType
            // 
            this.ctl_ProductType.AllCaps = false;
            this.ctl_ProductType.AllowEdit = true;
            this.ctl_ProductType.BackColor = System.Drawing.Color.White;
            this.ctl_ProductType.Bold = false;
            this.ctl_ProductType.Caption = "Product Type";
            this.ctl_ProductType.Changed = false;
            this.ctl_ProductType.ListName = "ProductType";
            this.ctl_ProductType.Location = new System.Drawing.Point(972, 77);
            this.ctl_ProductType.Name = "ctl_ProductType";
            this.ctl_ProductType.SimpleList = null;
            this.ctl_ProductType.Size = new System.Drawing.Size(115, 36);
            this.ctl_ProductType.TabIndex = 130;
            this.ctl_ProductType.UseParentBackColor = true;
            this.ctl_ProductType.Visible = false;
            this.ctl_ProductType.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_ProductType.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_ProductType.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_ProductType.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_ProductType.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ProductType.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_ProductType.zz_OriginalDesign = false;
            this.ctl_ProductType.zz_ShowNeedsSaveColor = true;
            this.ctl_ProductType.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_ProductType.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ProductType.zz_UseGlobalColor = false;
            this.ctl_ProductType.zz_UseGlobalFont = false;
            // 
            // cmdEnterQty
            // 
            this.cmdEnterQty.Location = new System.Drawing.Point(233, 44);
            this.cmdEnterQty.Name = "cmdEnterQty";
            this.cmdEnterQty.Size = new System.Drawing.Size(17, 16);
            this.cmdEnterQty.TabIndex = 131;
            this.cmdEnterQty.UseVisualStyleBackColor = true;
            this.cmdEnterQty.Click += new System.EventHandler(this.cmdEnterQty_Click);
            // 
            // ctl_is_strategic
            // 
            this.ctl_is_strategic.BackColor = System.Drawing.Color.Transparent;
            this.ctl_is_strategic.Bold = false;
            this.ctl_is_strategic.Caption = "Is Strategic";
            this.ctl_is_strategic.Changed = false;
            this.ctl_is_strategic.Location = new System.Drawing.Point(720, 34);
            this.ctl_is_strategic.Name = "ctl_is_strategic";
            this.ctl_is_strategic.Size = new System.Drawing.Size(121, 20);
            this.ctl_is_strategic.TabIndex = 132;
            this.ctl_is_strategic.UseParentBackColor = false;
            this.ctl_is_strategic.Visible = false;
            this.ctl_is_strategic.zz_CheckValue = false;
            this.ctl_is_strategic.zz_LabelColor = System.Drawing.Color.Blue;
            this.ctl_is_strategic.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_is_strategic.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_strategic.zz_OriginalDesign = false;
            this.ctl_is_strategic.zz_ShowNeedsSaveColor = true;
            // 
            // btnReqWizard
            // 
            this.btnReqWizard.Location = new System.Drawing.Point(1153, 22);
            this.btnReqWizard.Name = "btnReqWizard";
            this.btnReqWizard.Size = new System.Drawing.Size(94, 34);
            this.btnReqWizard.TabIndex = 133;
            this.btnReqWizard.Text = "Req Wizard";
            this.btnReqWizard.UseVisualStyleBackColor = true;
            this.btnReqWizard.Click += new System.EventHandler(this.btnReqWizard_Click);
            // 
            // ctl_description
            // 
            this.ctl_description.BackColor = System.Drawing.Color.White;
            this.ctl_description.Bold = false;
            this.ctl_description.Caption = "Description";
            this.ctl_description.Changed = false;
            this.ctl_description.DateLines = false;
            this.ctl_description.Location = new System.Drawing.Point(32, 269);
            this.ctl_description.Name = "ctl_description";
            this.ctl_description.Size = new System.Drawing.Size(222, 39);
            this.ctl_description.TabIndex = 8;
            this.ctl_description.UseParentBackColor = false;
            this.ctl_description.zz_Enabled = true;
            this.ctl_description.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_description.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_description.zz_LabelColor = System.Drawing.Color.Black;
            this.ctl_description.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_description.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_description.zz_OriginalDesign = false;
            this.ctl_description.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_description.zz_ShowNeedsSaveColor = true;
            this.ctl_description.zz_Text = "";
            this.ctl_description.zz_TextColor = System.Drawing.Color.Black;
            this.ctl_description.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_description.zz_UseGlobalColor = false;
            this.ctl_description.zz_UseGlobalFont = false;
            // 
            // sc1
            // 
            this.sc1.BackColor = System.Drawing.Color.White;
            this.sc1.Location = new System.Drawing.Point(409, 83);
            this.sc1.Name = "sc1";
            this.sc1.Size = new System.Drawing.Size(325, 153);
            this.sc1.SplitCommissionAgent = null;
            this.sc1.splitCommissionObject = null;
            this.sc1.TabIndex = 19;
            this.sc1.Visible = false;
            // 
            // ctl_target_manufacturer
            // 
            this.ctl_target_manufacturer.AllCaps = false;
            this.ctl_target_manufacturer.AllowEdit = false;
            this.ctl_target_manufacturer.BackColor = System.Drawing.Color.Transparent;
            this.ctl_target_manufacturer.Bold = false;
            this.ctl_target_manufacturer.Caption = "Target MFG";
            this.ctl_target_manufacturer.Changed = false;
            this.ctl_target_manufacturer.ListName = "manufacturer";
            this.ctl_target_manufacturer.Location = new System.Drawing.Point(31, 120);
            this.ctl_target_manufacturer.Name = "ctl_target_manufacturer";
            this.ctl_target_manufacturer.SimpleList = null;
            this.ctl_target_manufacturer.Size = new System.Drawing.Size(110, 40);
            this.ctl_target_manufacturer.TabIndex = 4;
            this.ctl_target_manufacturer.UseParentBackColor = true;
            this.ctl_target_manufacturer.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctl_target_manufacturer.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_target_manufacturer.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_target_manufacturer.zz_LabelColor = System.Drawing.Color.Black;
            this.ctl_target_manufacturer.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_target_manufacturer.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_target_manufacturer.zz_OriginalDesign = false;
            this.ctl_target_manufacturer.zz_ShowNeedsSaveColor = true;
            this.ctl_target_manufacturer.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_target_manufacturer.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_target_manufacturer.zz_UseGlobalColor = false;
            this.ctl_target_manufacturer.zz_UseGlobalFont = false;
            // 
            // ctl_manufacturer
            // 
            this.ctl_manufacturer.AllCaps = false;
            this.ctl_manufacturer.AllowEdit = false;
            this.ctl_manufacturer.BackColor = System.Drawing.Color.Transparent;
            this.ctl_manufacturer.Bold = false;
            this.ctl_manufacturer.Caption = "Quote MFG";
            this.ctl_manufacturer.Changed = false;
            this.ctl_manufacturer.ListName = "manufacturer";
            this.ctl_manufacturer.Location = new System.Drawing.Point(143, 120);
            this.ctl_manufacturer.Name = "ctl_manufacturer";
            this.ctl_manufacturer.SimpleList = null;
            this.ctl_manufacturer.Size = new System.Drawing.Size(110, 40);
            this.ctl_manufacturer.TabIndex = 11;
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
            // ctl_affiliate_id
            // 
            this.ctl_affiliate_id.AllCaps = false;
            this.ctl_affiliate_id.BackColor = System.Drawing.Color.White;
            this.ctl_affiliate_id.Bold = false;
            this.ctl_affiliate_id.Caption = "Affiliate ID";
            this.ctl_affiliate_id.Changed = false;
            this.ctl_affiliate_id.IsEmail = false;
            this.ctl_affiliate_id.IsURL = false;
            this.ctl_affiliate_id.Location = new System.Drawing.Point(260, 201);
            this.ctl_affiliate_id.Name = "ctl_affiliate_id";
            this.ctl_affiliate_id.PasswordChar = '\0';
            this.ctl_affiliate_id.Size = new System.Drawing.Size(142, 35);
            this.ctl_affiliate_id.TabIndex = 135;
            this.ctl_affiliate_id.UseParentBackColor = true;
            this.ctl_affiliate_id.zz_Enabled = true;
            this.ctl_affiliate_id.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_affiliate_id.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_affiliate_id.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_affiliate_id.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_affiliate_id.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_affiliate_id.zz_OriginalDesign = false;
            this.ctl_affiliate_id.zz_ShowLinkButton = false;
            this.ctl_affiliate_id.zz_ShowNeedsSaveColor = true;
            this.ctl_affiliate_id.zz_Text = "";
            this.ctl_affiliate_id.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_affiliate_id.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_affiliate_id.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_affiliate_id.zz_UseGlobalColor = false;
            this.ctl_affiliate_id.zz_UseGlobalFont = false;
            // 
            // ReqLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctl_affiliate_id);
            this.Controls.Add(this.ctl_manufacturer);
            this.Controls.Add(this.ctl_target_manufacturer);
            this.Controls.Add(this.sc1);
            this.Controls.Add(this.ctl_description);
            this.Controls.Add(this.btnReqWizard);
            this.Controls.Add(this.ctl_is_strategic);
            this.Controls.Add(this.cmdEnterQty);
            this.Controls.Add(this.ctl_ProductType);
            this.Controls.Add(this.ctl_isselected);
            this.Controls.Add(this.ts);
            this.Controls.Add(this.ctl_internalpartnumber);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ctl_rohs_info);
            this.Controls.Add(this.ctl_dockdate);
            this.Controls.Add(this.lblReceiveBid);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.ctl_source);
            this.Controls.Add(this.ctl_is_priority);
            this.Controls.Add(this.cmdMultiSearch);
            this.Controls.Add(this.cmdPartSearch);
            this.Controls.Add(this.ctl_unitcost);
            this.Controls.Add(this.ctl_delivery);
            this.Controls.Add(this.ctl_condition);
            this.Controls.Add(this.ctl_target_delivery);
            this.Controls.Add(this.ctl_target_condition);
            this.Controls.Add(this.ctl_target_datecode);
            this.Controls.Add(this.ctl_datecode);
            this.Controls.Add(this.ctl_fullpartnumber);
            this.Controls.Add(this.ctl_quantityordered);
            this.Controls.Add(this.ctl_target_quantity);
            this.Controls.Add(this.ctl_unitprice);
            this.Controls.Add(this.ctl_target_price);
            this.Controls.Add(this.ctl_alternatepart);
            this.Name = "ReqLine";
            this.Size = new System.Drawing.Size(1255, 311);
            this.Controls.SetChildIndex(this.ctl_alternatepart, 0);
            this.Controls.SetChildIndex(this.ctl_target_price, 0);
            this.Controls.SetChildIndex(this.ctl_unitprice, 0);
            this.Controls.SetChildIndex(this.ctl_target_quantity, 0);
            this.Controls.SetChildIndex(this.ctl_quantityordered, 0);
            this.Controls.SetChildIndex(this.ctl_fullpartnumber, 0);
            this.Controls.SetChildIndex(this.ctl_datecode, 0);
            this.Controls.SetChildIndex(this.ctl_target_datecode, 0);
            this.Controls.SetChildIndex(this.ctl_target_condition, 0);
            this.Controls.SetChildIndex(this.ctl_target_delivery, 0);
            this.Controls.SetChildIndex(this.ctl_condition, 0);
            this.Controls.SetChildIndex(this.ctl_delivery, 0);
            this.Controls.SetChildIndex(this.ctl_unitcost, 0);
            this.Controls.SetChildIndex(this.cmdPartSearch, 0);
            this.Controls.SetChildIndex(this.cmdMultiSearch, 0);
            this.Controls.SetChildIndex(this.ctl_is_priority, 0);
            this.Controls.SetChildIndex(this.ctl_source, 0);
            this.Controls.SetChildIndex(this.lblAdd, 0);
            this.Controls.SetChildIndex(this.lblReceiveBid, 0);
            this.Controls.SetChildIndex(this.ctl_dockdate, 0);
            this.Controls.SetChildIndex(this.ctl_rohs_info, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.ctl_internalpartnumber, 0);
            this.Controls.SetChildIndex(this.ts, 0);
            this.Controls.SetChildIndex(this.ctl_isselected, 0);
            this.Controls.SetChildIndex(this.ctl_ProductType, 0);
            this.Controls.SetChildIndex(this.cmdEnterQty, 0);
            this.Controls.SetChildIndex(this.ctl_is_strategic, 0);
            this.Controls.SetChildIndex(this.btnReqWizard, 0);
            this.Controls.SetChildIndex(this.ctl_description, 0);
            this.Controls.SetChildIndex(this.sc1, 0);
            this.Controls.SetChildIndex(this.pCommands, 0);
            this.Controls.SetChildIndex(this.ctl_target_manufacturer, 0);
            this.Controls.SetChildIndex(this.ctl_manufacturer, 0);
            this.Controls.SetChildIndex(this.ctl_affiliate_id, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ts.ResumeLayout(false);
            this.tabReqNotes.ResumeLayout(false);
            this.tabQuoteNotes.ResumeLayout(false);
            this.tabStatus.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblReceiveBid;
        public NewMethod.nEdit_Memo ctl_internalcomment;
        public Win.Controls.EditMoney ctl_target_price;
        public NewMethod.nEdit_Number ctl_target_quantity;
        public NewMethod.nEdit_String ctl_datecode;
        public NewMethod.nEdit_String ctl_fullpartnumber;
        public Win.Controls.EditMoney ctl_unitprice;
        public NewMethod.nEdit_Number ctl_quantityordered;
        public NewMethod.nEdit_String ctl_target_datecode;
        public NewMethod.nEdit_String ctl_internalpartnumber;
        public NewMethod.nEdit_String ctl_alternatepart;
        public System.Windows.Forms.LinkLabel lblAdd;
        public NewMethod.nEdit_List ctl_target_condition;
        public NewMethod.nEdit_List ctl_target_delivery;
        public NewMethod.nEdit_List ctl_delivery;
        public NewMethod.nEdit_List ctl_condition;
        public Win.Controls.EditMoney ctl_unitcost;
        public System.Windows.Forms.Label lblProfit;
        public NewMethod.nEdit_Memo ctl_alternatepart_04;
        public System.Windows.Forms.Button cmdPartSearch;
        public System.Windows.Forms.Button cmdMultiSearch;
        public NewMethod.nEdit_Boolean ctl_is_priority;
        public NewMethod.nEdit_List ctl_source;
        public NewMethod.nEdit_List ctl_rohs_info;
        private NewMethod.nEdit_Date ctl_dockdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl ts;
        private System.Windows.Forms.TabPage tabReqNotes;
        private System.Windows.Forms.TabPage tabQuoteNotes;
        protected NewMethod.nEdit_Boolean ctl_isselected;
        public NewMethod.nEdit_List ctl_ProductType;
        private System.Windows.Forms.Button cmdEnterQty;
        protected NewMethod.nEdit_Boolean ctl_is_strategic;
        private System.Windows.Forms.TabPage tabDescription;
        private System.Windows.Forms.TabPage tabStatus;
        public NewMethod.nEdit_Memo ctl_status_notes;
        private System.Windows.Forms.Button btnReqWizard;
        private NewMethod.nEdit_Memo ctl_description;
        private SplitCommission sc1;
        public NewMethod.nEdit_List ctl_target_manufacturer;
        public NewMethod.nEdit_List ctl_manufacturer;
        public NewMethod.nEdit_String ctl_affiliate_id;
    }
}
