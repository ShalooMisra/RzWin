namespace Rz5
{
    partial class view_checkpayment
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
            this.ctl_istt = new NewMethod.nEdit_Boolean();
            this.ctl_senttoqb = new NewMethod.nEdit_Boolean();
            this.ctl_description = new NewMethod.nEdit_Memo();
            this.ctl_referencedata = new NewMethod.nEdit_String();
            this.ctl_transdate = new NewMethod.nEdit_Date();
            this.ctl_subtotal = new NewMethod.nEdit_Money();
            this.ctl_feeamount = new NewMethod.nEdit_Money();
            this.Xtransamount = new NewMethod.nEdit_Money();
            this.ctl_payment_type = new NewMethod.nEdit_List();
            this.ctl_is_underpaid = new NewMethod.nEdit_Boolean();
            this.gbOrder = new System.Windows.Forms.GroupBox();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblCaption = new System.Windows.Forms.Label();
            this.ctl_handlingamount = new NewMethod.nEdit_Money();
            this.ctl_taxamount = new NewMethod.nEdit_Money();
            this.details = new NewMethod.nList();
            this.ctl_qb_account = new NewMethod.nEdit_List();
            this.ctl_withhold_from_profit = new NewMethod.nEdit_Boolean();
            this.gbOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(631, 0);
            this.xActions.Size = new System.Drawing.Size(148, 618);
            // 
            // ctl_istt
            // 
            this.ctl_istt.BackColor = System.Drawing.Color.White;
            this.ctl_istt.Bold = false;
            this.ctl_istt.Caption = "Is TT";
            this.ctl_istt.Changed = false;
            this.ctl_istt.Location = new System.Drawing.Point(255, 142);
            this.ctl_istt.Name = "ctl_istt";
            this.ctl_istt.Size = new System.Drawing.Size(51, 18);
            this.ctl_istt.TabIndex = 8;
            this.ctl_istt.UseParentBackColor = true;
            this.ctl_istt.zz_CheckValue = false;
            this.ctl_istt.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_istt.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_istt.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_istt.zz_OriginalDesign = false;
            this.ctl_istt.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_senttoqb
            // 
            this.ctl_senttoqb.BackColor = System.Drawing.Color.White;
            this.ctl_senttoqb.Bold = false;
            this.ctl_senttoqb.Caption = "Sent To QuickBooks";
            this.ctl_senttoqb.Changed = false;
            this.ctl_senttoqb.Location = new System.Drawing.Point(310, 142);
            this.ctl_senttoqb.Name = "ctl_senttoqb";
            this.ctl_senttoqb.Size = new System.Drawing.Size(125, 18);
            this.ctl_senttoqb.TabIndex = 9;
            this.ctl_senttoqb.UseParentBackColor = true;
            this.ctl_senttoqb.zz_CheckValue = false;
            this.ctl_senttoqb.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_senttoqb.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_senttoqb.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_senttoqb.zz_OriginalDesign = false;
            this.ctl_senttoqb.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_description
            // 
            this.ctl_description.BackColor = System.Drawing.Color.White;
            this.ctl_description.Bold = false;
            this.ctl_description.Caption = "Description";
            this.ctl_description.Changed = false;
            this.ctl_description.DateLines = false;
            this.ctl_description.Location = new System.Drawing.Point(9, 140);
            this.ctl_description.Name = "ctl_description";
            this.ctl_description.Size = new System.Drawing.Size(425, 113);
            this.ctl_description.TabIndex = 4;
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
            // ctl_referencedata
            // 
            this.ctl_referencedata.AllCaps = false;
            this.ctl_referencedata.BackColor = System.Drawing.Color.White;
            this.ctl_referencedata.Bold = false;
            this.ctl_referencedata.Caption = "Reference Data";
            this.ctl_referencedata.Changed = false;
            this.ctl_referencedata.IsEmail = false;
            this.ctl_referencedata.IsURL = false;
            this.ctl_referencedata.Location = new System.Drawing.Point(9, 253);
            this.ctl_referencedata.Name = "ctl_referencedata";
            this.ctl_referencedata.PasswordChar = '\0';
            this.ctl_referencedata.Size = new System.Drawing.Size(425, 41);
            this.ctl_referencedata.TabIndex = 1;
            this.ctl_referencedata.UseParentBackColor = true;
            this.ctl_referencedata.zz_Enabled = true;
            this.ctl_referencedata.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_referencedata.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_referencedata.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_referencedata.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_referencedata.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_referencedata.zz_OriginalDesign = true;
            this.ctl_referencedata.zz_ShowLinkButton = false;
            this.ctl_referencedata.zz_ShowNeedsSaveColor = true;
            this.ctl_referencedata.zz_Text = "";
            this.ctl_referencedata.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_referencedata.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_referencedata.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_referencedata.zz_UseGlobalColor = false;
            this.ctl_referencedata.zz_UseGlobalFont = false;
            // 
            // ctl_transdate
            // 
            this.ctl_transdate.AllowClear = false;
            this.ctl_transdate.BackColor = System.Drawing.Color.White;
            this.ctl_transdate.Bold = false;
            this.ctl_transdate.Caption = "Payment Date";
            this.ctl_transdate.Changed = false;
            this.ctl_transdate.Location = new System.Drawing.Point(450, 220);
            this.ctl_transdate.Name = "ctl_transdate";
            this.ctl_transdate.Size = new System.Drawing.Size(135, 41);
            this.ctl_transdate.SuppressEdit = false;
            this.ctl_transdate.TabIndex = 2;
            this.ctl_transdate.UseParentBackColor = true;
            this.ctl_transdate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_transdate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_transdate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_transdate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_transdate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopCenter;
            this.ctl_transdate.zz_OriginalDesign = false;
            this.ctl_transdate.zz_ShowNeedsSaveColor = true;
            this.ctl_transdate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_transdate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_transdate.zz_UseGlobalColor = false;
            this.ctl_transdate.zz_UseGlobalFont = false;
            // 
            // ctl_subtotal
            // 
            this.ctl_subtotal.BackColor = System.Drawing.Color.White;
            this.ctl_subtotal.Bold = false;
            this.ctl_subtotal.Caption = "Total Payment";
            this.ctl_subtotal.Changed = false;
            this.ctl_subtotal.EditCaption = false;
            this.ctl_subtotal.FullDecimal = false;
            this.ctl_subtotal.Location = new System.Drawing.Point(450, 163);
            this.ctl_subtotal.Name = "ctl_subtotal";
            this.ctl_subtotal.RoundNearestCent = false;
            this.ctl_subtotal.Size = new System.Drawing.Size(135, 46);
            this.ctl_subtotal.TabIndex = 0;
            this.ctl_subtotal.UseParentBackColor = true;
            this.ctl_subtotal.zz_Enabled = true;
            this.ctl_subtotal.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_subtotal.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_subtotal.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_subtotal.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_subtotal.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_subtotal.zz_OriginalDesign = true;
            this.ctl_subtotal.zz_ShowErrorColor = true;
            this.ctl_subtotal.zz_ShowNeedsSaveColor = true;
            this.ctl_subtotal.zz_Text = "";
            this.ctl_subtotal.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_subtotal.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_subtotal.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_subtotal.zz_UseGlobalColor = false;
            this.ctl_subtotal.zz_UseGlobalFont = false;
            this.ctl_subtotal.DataChanged += new NewMethod.ChangeHandler(this.ctl_subtotal_DataChanged);
            // 
            // ctl_feeamount
            // 
            this.ctl_feeamount.BackColor = System.Drawing.Color.White;
            this.ctl_feeamount.Bold = false;
            this.ctl_feeamount.Caption = "Fee Amount";
            this.ctl_feeamount.Changed = false;
            this.ctl_feeamount.EditCaption = false;
            this.ctl_feeamount.FullDecimal = false;
            this.ctl_feeamount.Location = new System.Drawing.Point(450, 7);
            this.ctl_feeamount.Name = "ctl_feeamount";
            this.ctl_feeamount.RoundNearestCent = false;
            this.ctl_feeamount.Size = new System.Drawing.Size(135, 46);
            this.ctl_feeamount.TabIndex = 1;
            this.ctl_feeamount.UseParentBackColor = true;
            this.ctl_feeamount.Visible = false;
            this.ctl_feeamount.zz_Enabled = true;
            this.ctl_feeamount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_feeamount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_feeamount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_feeamount.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_feeamount.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_feeamount.zz_OriginalDesign = true;
            this.ctl_feeamount.zz_ShowErrorColor = true;
            this.ctl_feeamount.zz_ShowNeedsSaveColor = true;
            this.ctl_feeamount.zz_Text = "";
            this.ctl_feeamount.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_feeamount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_feeamount.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_feeamount.zz_UseGlobalColor = false;
            this.ctl_feeamount.zz_UseGlobalFont = false;
            this.ctl_feeamount.DataChanged += new NewMethod.ChangeHandler(this.ctl_feeamount_DataChanged);
            // 
            // Xtransamount
            // 
            this.Xtransamount.BackColor = System.Drawing.Color.White;
            this.Xtransamount.Bold = true;
            this.Xtransamount.Caption = "Total";
            this.Xtransamount.Changed = false;
            this.Xtransamount.EditCaption = false;
            this.Xtransamount.Enabled = false;
            this.Xtransamount.FullDecimal = false;
            this.Xtransamount.Location = new System.Drawing.Point(450, 309);
            this.Xtransamount.Name = "Xtransamount";
            this.Xtransamount.RoundNearestCent = false;
            this.Xtransamount.Size = new System.Drawing.Size(135, 46);
            this.Xtransamount.TabIndex = 15;
            this.Xtransamount.UseParentBackColor = true;
            this.Xtransamount.zz_Enabled = true;
            this.Xtransamount.zz_GlobalColor = System.Drawing.Color.Black;
            this.Xtransamount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Xtransamount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.Xtransamount.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Xtransamount.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.Xtransamount.zz_OriginalDesign = true;
            this.Xtransamount.zz_ShowErrorColor = true;
            this.Xtransamount.zz_ShowNeedsSaveColor = true;
            this.Xtransamount.zz_Text = "";
            this.Xtransamount.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Xtransamount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.Xtransamount.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Xtransamount.zz_UseGlobalColor = false;
            this.Xtransamount.zz_UseGlobalFont = false;
            // 
            // ctl_payment_type
            // 
            this.ctl_payment_type.AllCaps = false;
            this.ctl_payment_type.AllowEdit = true;
            this.ctl_payment_type.BackColor = System.Drawing.Color.Transparent;
            this.ctl_payment_type.Bold = false;
            this.ctl_payment_type.Caption = "Payment Type";
            this.ctl_payment_type.Changed = false;
            this.ctl_payment_type.ListName = "payment_types";
            this.ctl_payment_type.Location = new System.Drawing.Point(450, 267);
            this.ctl_payment_type.Name = "ctl_payment_type";
            this.ctl_payment_type.SimpleList = null;
            this.ctl_payment_type.Size = new System.Drawing.Size(135, 36);
            this.ctl_payment_type.TabIndex = 3;
            this.ctl_payment_type.UseParentBackColor = false;
            this.ctl_payment_type.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_payment_type.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_payment_type.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_payment_type.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_payment_type.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_payment_type.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_payment_type.zz_OriginalDesign = false;
            this.ctl_payment_type.zz_ShowNeedsSaveColor = true;
            this.ctl_payment_type.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_payment_type.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_payment_type.zz_UseGlobalColor = false;
            this.ctl_payment_type.zz_UseGlobalFont = false;
            // 
            // ctl_is_underpaid
            // 
            this.ctl_is_underpaid.BackColor = System.Drawing.Color.White;
            this.ctl_is_underpaid.Bold = false;
            this.ctl_is_underpaid.Caption = "Is Underpaid";
            this.ctl_is_underpaid.Changed = false;
            this.ctl_is_underpaid.Location = new System.Drawing.Point(498, 139);
            this.ctl_is_underpaid.Name = "ctl_is_underpaid";
            this.ctl_is_underpaid.Size = new System.Drawing.Size(86, 18);
            this.ctl_is_underpaid.TabIndex = 38;
            this.ctl_is_underpaid.UseParentBackColor = true;
            this.ctl_is_underpaid.Visible = false;
            this.ctl_is_underpaid.zz_CheckValue = false;
            this.ctl_is_underpaid.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_underpaid.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_is_underpaid.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_underpaid.zz_OriginalDesign = false;
            this.ctl_is_underpaid.zz_ShowNeedsSaveColor = true;
            // 
            // gbOrder
            // 
            this.gbOrder.Controls.Add(this.lblDetails);
            this.gbOrder.Controls.Add(this.lblCaption);
            this.gbOrder.Location = new System.Drawing.Point(9, 7);
            this.gbOrder.Name = "gbOrder";
            this.gbOrder.Size = new System.Drawing.Size(425, 129);
            this.gbOrder.TabIndex = 39;
            this.gbOrder.TabStop = false;
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(10, 46);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(49, 13);
            this.lblDetails.TabIndex = 1;
            this.lblDetails.Text = "<details>";
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(6, 16);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(106, 25);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "<caption>";
            // 
            // ctl_handlingamount
            // 
            this.ctl_handlingamount.BackColor = System.Drawing.Color.White;
            this.ctl_handlingamount.Bold = false;
            this.ctl_handlingamount.Caption = "Handling Amount";
            this.ctl_handlingamount.Changed = false;
            this.ctl_handlingamount.EditCaption = false;
            this.ctl_handlingamount.FullDecimal = false;
            this.ctl_handlingamount.Location = new System.Drawing.Point(450, 51);
            this.ctl_handlingamount.Name = "ctl_handlingamount";
            this.ctl_handlingamount.RoundNearestCent = false;
            this.ctl_handlingamount.Size = new System.Drawing.Size(135, 46);
            this.ctl_handlingamount.TabIndex = 2;
            this.ctl_handlingamount.UseParentBackColor = true;
            this.ctl_handlingamount.Visible = false;
            this.ctl_handlingamount.zz_Enabled = true;
            this.ctl_handlingamount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_handlingamount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_handlingamount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_handlingamount.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_handlingamount.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_handlingamount.zz_OriginalDesign = true;
            this.ctl_handlingamount.zz_ShowErrorColor = true;
            this.ctl_handlingamount.zz_ShowNeedsSaveColor = true;
            this.ctl_handlingamount.zz_Text = "";
            this.ctl_handlingamount.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_handlingamount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_handlingamount.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_handlingamount.zz_UseGlobalColor = false;
            this.ctl_handlingamount.zz_UseGlobalFont = false;
            this.ctl_handlingamount.DataChanged += new NewMethod.ChangeHandler(this.ctl_handlingamount_DataChanged);
            // 
            // ctl_taxamount
            // 
            this.ctl_taxamount.BackColor = System.Drawing.Color.White;
            this.ctl_taxamount.Bold = false;
            this.ctl_taxamount.Caption = "Tax Amount";
            this.ctl_taxamount.Changed = false;
            this.ctl_taxamount.EditCaption = false;
            this.ctl_taxamount.FullDecimal = false;
            this.ctl_taxamount.Location = new System.Drawing.Point(450, 95);
            this.ctl_taxamount.Name = "ctl_taxamount";
            this.ctl_taxamount.RoundNearestCent = false;
            this.ctl_taxamount.Size = new System.Drawing.Size(135, 46);
            this.ctl_taxamount.TabIndex = 3;
            this.ctl_taxamount.UseParentBackColor = true;
            this.ctl_taxamount.Visible = false;
            this.ctl_taxamount.zz_Enabled = true;
            this.ctl_taxamount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_taxamount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_taxamount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_taxamount.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_taxamount.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_taxamount.zz_OriginalDesign = true;
            this.ctl_taxamount.zz_ShowErrorColor = true;
            this.ctl_taxamount.zz_ShowNeedsSaveColor = true;
            this.ctl_taxamount.zz_Text = "";
            this.ctl_taxamount.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_taxamount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_taxamount.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_taxamount.zz_UseGlobalColor = false;
            this.ctl_taxamount.zz_UseGlobalFont = false;
            this.ctl_taxamount.DataChanged += new NewMethod.ChangeHandler(this.ctl_taxamount_DataChanged);
            // 
            // details
            // 
            this.details.AddCaption = "Add New";
            this.details.AllowActions = true;
            this.details.AllowAdd = false;
            this.details.AllowDelete = true;
            this.details.AllowDeleteAlways = false;
            this.details.AllowDrop = true;
            this.details.AllowOnlyOpenDelete = false;
            this.details.AlternateConnection = null;
            this.details.BackColor = System.Drawing.Color.White;
            this.details.Caption = "";
            this.details.CurrentTemplate = null;
            this.details.ExtraClassInfo = "";
            this.details.Location = new System.Drawing.Point(9, 393);
            this.details.MultiSelect = true;
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(576, 206);
            this.details.SuppressSelectionChanged = false;
            this.details.TabIndex = 41;
            this.details.Visible = false;
            this.details.zz_OpenColumnMenu = false;
            this.details.zz_OrderLineType = "";
            this.details.zz_ShowAutoRefresh = true;
            this.details.zz_ShowUnlimited = true;
            // 
            // ctl_qb_account
            // 
            this.ctl_qb_account.AllCaps = false;
            this.ctl_qb_account.AllowEdit = true;
            this.ctl_qb_account.BackColor = System.Drawing.Color.Transparent;
            this.ctl_qb_account.Bold = false;
            this.ctl_qb_account.Caption = "QuickBooks Account";
            this.ctl_qb_account.Changed = false;
            this.ctl_qb_account.ListName = "quickbooks_account";
            this.ctl_qb_account.Location = new System.Drawing.Point(9, 300);
            this.ctl_qb_account.Name = "ctl_qb_account";
            this.ctl_qb_account.SimpleList = null;
            this.ctl_qb_account.Size = new System.Drawing.Size(284, 36);
            this.ctl_qb_account.TabIndex = 43;
            this.ctl_qb_account.UseParentBackColor = false;
            this.ctl_qb_account.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctl_qb_account.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_qb_account.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_qb_account.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_qb_account.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_qb_account.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_qb_account.zz_OriginalDesign = false;
            this.ctl_qb_account.zz_ShowNeedsSaveColor = true;
            this.ctl_qb_account.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_qb_account.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_qb_account.zz_UseGlobalColor = false;
            this.ctl_qb_account.zz_UseGlobalFont = false;
            // 
            // ctl_withhold_from_profit
            // 
            this.ctl_withhold_from_profit.BackColor = System.Drawing.Color.White;
            this.ctl_withhold_from_profit.Bold = false;
            this.ctl_withhold_from_profit.Caption = "Withhold from Profit";
            this.ctl_withhold_from_profit.Changed = false;
            this.ctl_withhold_from_profit.Location = new System.Drawing.Point(131, 142);
            this.ctl_withhold_from_profit.Name = "ctl_withhold_from_profit";
            this.ctl_withhold_from_profit.Size = new System.Drawing.Size(118, 18);
            this.ctl_withhold_from_profit.TabIndex = 44;
            this.ctl_withhold_from_profit.UseParentBackColor = true;
            this.ctl_withhold_from_profit.zz_CheckValue = false;
            this.ctl_withhold_from_profit.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_withhold_from_profit.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_withhold_from_profit.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_withhold_from_profit.zz_OriginalDesign = false;
            this.ctl_withhold_from_profit.zz_ShowNeedsSaveColor = true;
            // 
            // view_checkpayment
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctl_withhold_from_profit);
            this.Controls.Add(this.ctl_qb_account);
            this.Controls.Add(this.ctl_subtotal);
            this.Controls.Add(this.details);
            this.Controls.Add(this.ctl_taxamount);
            this.Controls.Add(this.ctl_handlingamount);
            this.Controls.Add(this.gbOrder);
            this.Controls.Add(this.ctl_is_underpaid);
            this.Controls.Add(this.ctl_payment_type);
            this.Controls.Add(this.Xtransamount);
            this.Controls.Add(this.ctl_feeamount);
            this.Controls.Add(this.ctl_transdate);
            this.Controls.Add(this.ctl_referencedata);
            this.Controls.Add(this.ctl_istt);
            this.Controls.Add(this.ctl_senttoqb);
            this.Controls.Add(this.ctl_description);
            this.Name = "view_checkpayment";
            this.Size = new System.Drawing.Size(779, 618);
            this.Leave += new System.EventHandler(this.view_checkpayment_Leave);
            this.Controls.SetChildIndex(this.ctl_description, 0);
            this.Controls.SetChildIndex(this.ctl_senttoqb, 0);
            this.Controls.SetChildIndex(this.ctl_istt, 0);
            this.Controls.SetChildIndex(this.ctl_referencedata, 0);
            this.Controls.SetChildIndex(this.ctl_transdate, 0);
            this.Controls.SetChildIndex(this.ctl_feeamount, 0);
            this.Controls.SetChildIndex(this.Xtransamount, 0);
            this.Controls.SetChildIndex(this.ctl_payment_type, 0);
            this.Controls.SetChildIndex(this.ctl_is_underpaid, 0);
            this.Controls.SetChildIndex(this.gbOrder, 0);
            this.Controls.SetChildIndex(this.ctl_handlingamount, 0);
            this.Controls.SetChildIndex(this.ctl_taxamount, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.Controls.SetChildIndex(this.details, 0);
            this.Controls.SetChildIndex(this.ctl_subtotal, 0);
            this.Controls.SetChildIndex(this.ctl_qb_account, 0);
            this.Controls.SetChildIndex(this.ctl_withhold_from_profit, 0);
            this.gbOrder.ResumeLayout(false);
            this.gbOrder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public NewMethod.nEdit_Boolean ctl_istt;
        public NewMethod.nEdit_Boolean ctl_senttoqb;
        public NewMethod.nEdit_Memo ctl_description;
        public NewMethod.nEdit_String ctl_referencedata;
        public NewMethod.nEdit_Date ctl_transdate;
        public NewMethod.nEdit_Money ctl_subtotal;
        public NewMethod.nEdit_Money ctl_feeamount;
        public NewMethod.nEdit_Money Xtransamount;
        public NewMethod.nEdit_List ctl_payment_type;
        public NewMethod.nEdit_Boolean ctl_is_underpaid;
        public System.Windows.Forms.GroupBox gbOrder;
        public System.Windows.Forms.Label lblDetails;
        public System.Windows.Forms.Label lblCaption;
        public NewMethod.nEdit_Money ctl_handlingamount;
        public NewMethod.nEdit_Money ctl_taxamount;
        private NewMethod.nList details;
        public NewMethod.nEdit_List ctl_qb_account;
        public NewMethod.nEdit_Boolean ctl_withhold_from_profit;

    }
}
