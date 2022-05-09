using Tools.Database;
namespace Rz5
{
    partial class ViewDetailPurchase
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
            CompleteDispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctl_tracking_purchase = new NewMethod.nEdit_Memo();
            this.ctl_shippingaccount_purchase = new NewMethod.nEdit_List();
            this.ctl_shipvia_purchase = new NewMethod.nEdit_List();
            this.ctl_charge2_fee_purchase = new NewMethod.nEdit_Number();
            this.ctl_charge1_fee_purchase = new NewMethod.nEdit_Number();
            this.ctl_shipping_fee_purchase = new NewMethod.nEdit_Number();
            this.ctl_notes_purchase = new NewMethod.nEdit_Memo();
            this.ctl_unit_cost = new NewMethod.nEdit_Money();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUnpacked = new System.Windows.Forms.Label();
            this.tabPack = new System.Windows.Forms.TabPage();
            this.tabDeductions = new System.Windows.Forms.TabPage();
            this.deductions = new Rz5.Win.Controls.LineProfit();
            this.ctl_internal_vendor = new NewMethod.nEdit_String();
            this.ctl_rohs_info_vendor = new NewMethod.nEdit_List();
            this.ctl_datecode_purchase = new NewMethod.nEdit_String();
            this.tabDates = new System.Windows.Forms.TabPage();
            this.ctl_receive_date_actual = new NewMethod.nEdit_Date();
            this.ctl_receive_date_due = new NewMethod.nEdit_Date();
            this.ctl_customer_dock_date = new NewMethod.nEdit_Date();
            this.ctl_ship_date_actual = new NewMethod.nEdit_Date();
            this.ctl_ship_date_due = new NewMethod.nEdit_Date();
            this.ctl_inspection_status = new NewMethod.nEdit_List();
            this.ts.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.tabAttachments.SuspendLayout();
            this.gbAction1.SuspendLayout();
            this.gbTop.SuspendLayout();
            this.tabDeductions.SuspendLayout();
            this.tabDates.SuspendLayout();
            this.SuspendLayout();
            // 
            // ts
            // 
            this.ts.Controls.Add(this.tabPack);
            this.ts.Controls.Add(this.tabDeductions);
            this.ts.Controls.Add(this.tabDates);
            this.ts.Margin = new System.Windows.Forms.Padding(5);
            this.ts.Size = new System.Drawing.Size(792, 549);
            this.ts.Controls.SetChildIndex(this.tabDates, 0);
            this.ts.Controls.SetChildIndex(this.tabDeductions, 0);
            this.ts.Controls.SetChildIndex(this.tabPack, 0);
            this.ts.Controls.SetChildIndex(this.tabAttachments, 0);
            this.ts.Controls.SetChildIndex(this.tabInfo, 0);
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.ctl_datecode_purchase);
            this.tabInfo.Controls.Add(this.ctl_inspection_status);
            this.tabInfo.Controls.Add(this.ctl_rohs_info_vendor);
            this.tabInfo.Controls.Add(this.ctl_internal_vendor);
            this.tabInfo.Controls.Add(this.lblUnpacked);
            this.tabInfo.Controls.Add(this.label1);
            this.tabInfo.Controls.Add(this.ctl_unit_cost);
            this.tabInfo.Controls.Add(this.ctl_tracking_purchase);
            this.tabInfo.Controls.Add(this.ctl_shippingaccount_purchase);
            this.tabInfo.Controls.Add(this.ctl_shipvia_purchase);
            this.tabInfo.Margin = new System.Windows.Forms.Padding(5);
            this.tabInfo.Padding = new System.Windows.Forms.Padding(5);
            this.tabInfo.Size = new System.Drawing.Size(784, 523);
            this.tabInfo.Controls.SetChildIndex(this.ctl_country_of_origin_vendor, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_shipvia_purchase, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_shippingaccount_purchase, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_tracking_purchase, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_unit_cost, 0);
            this.tabInfo.Controls.SetChildIndex(this.label1, 0);
            this.tabInfo.Controls.SetChildIndex(this.lblUnpacked, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_internal_vendor, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_rohs_info_vendor, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_inspection_status, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_harmonized_tarriff_schedule, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_country_of_origin, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_rohs_info, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_alternatepart, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_description, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_internalcomment, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_fullpartnumber, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_datecode, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_manufacturer, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_datecode_purchase, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_condition, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_packaging, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_category, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_quantity, 0);
            // 
            // tabAttachments
            // 
            this.tabAttachments.Margin = new System.Windows.Forms.Padding(5);
            this.tabAttachments.Padding = new System.Windows.Forms.Padding(5);
            this.tabAttachments.Size = new System.Drawing.Size(784, 523);
            // 
            // gbAction1
            // 
            this.gbAction1.Location = new System.Drawing.Point(800, 3);
            this.gbAction1.Size = new System.Drawing.Size(152, 141);
            // 
            // ctl_fullpartnumber
            // 
            this.ctl_fullpartnumber.zz_Enabled = true;
            // 
            // ctl_datecode
            // 
            this.ctl_datecode.Location = new System.Drawing.Point(154, 55);
            this.ctl_datecode.TabStop = false;
            this.ctl_datecode.zz_Enabled = true;
            // 
            // ctl_category
            // 
            this.ctl_category.Location = new System.Drawing.Point(3, 115);
            this.ctl_category.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.ctl_category.TabIndex = 7;
            // 
            // ctl_packaging
            // 
            this.ctl_packaging.Location = new System.Drawing.Point(432, 59);
            this.ctl_packaging.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.ctl_packaging.TabIndex = 6;
            // 
            // picview
            // 
            this.picview.Location = new System.Drawing.Point(5, 5);
            this.picview.Size = new System.Drawing.Size(774, 513);
            // 
            // ctl_internalcomment
            // 
            this.ctl_internalcomment.Location = new System.Drawing.Point(5, 316);
            this.ctl_internalcomment.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.ctl_internalcomment.Size = new System.Drawing.Size(763, 145);
            this.ctl_internalcomment.TabIndex = 16;
            // 
            // ctl_description
            // 
            this.ctl_description.Location = new System.Drawing.Point(177, 115);
            this.ctl_description.TabIndex = 8;
            // 
            // ctl_alternatepart
            // 
            this.ctl_alternatepart.Location = new System.Drawing.Point(3, 176);
            this.ctl_alternatepart.TabIndex = 10;
            // 
            // ctl_rohs_info
            // 
            this.ctl_rohs_info.Location = new System.Drawing.Point(455, 171);
            this.ctl_rohs_info.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            // 
            // ctl_condition
            // 
            this.ctl_condition.Location = new System.Drawing.Point(270, 59);
            this.ctl_condition.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.ctl_condition.TabIndex = 5;
            // 
            // ctl_country_of_origin
            // 
            this.ctl_country_of_origin.Location = new System.Drawing.Point(607, 104);
            this.ctl_country_of_origin.TabIndex = 9;
            // 
            // ctl_manufacturer
            // 
            this.ctl_manufacturer.Location = new System.Drawing.Point(3, 59);
            this.ctl_manufacturer.TabIndex = 3;
            // 
            // ctl_country_of_origin_vendor
            // 
            this.ctl_country_of_origin_vendor.Location = new System.Drawing.Point(606, 149);
            this.ctl_country_of_origin_vendor.zz_Enabled = true;
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(1375, 0);
            this.xActions.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.xActions.Size = new System.Drawing.Size(148, 800);
            // 
            // ctl_tracking_purchase
            // 
            this.ctl_tracking_purchase.BackColor = System.Drawing.Color.Transparent;
            this.ctl_tracking_purchase.Bold = false;
            this.ctl_tracking_purchase.Caption = "Vendor Tracking Numbers";
            this.ctl_tracking_purchase.Changed = false;
            this.ctl_tracking_purchase.DateLines = false;
            this.ctl_tracking_purchase.Location = new System.Drawing.Point(455, 251);
            this.ctl_tracking_purchase.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_tracking_purchase.Name = "ctl_tracking_purchase";
            this.ctl_tracking_purchase.Size = new System.Drawing.Size(313, 77);
            this.ctl_tracking_purchase.TabIndex = 15;
            this.ctl_tracking_purchase.UseParentBackColor = false;
            this.ctl_tracking_purchase.zz_Enabled = true;
            this.ctl_tracking_purchase.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_tracking_purchase.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_tracking_purchase.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_tracking_purchase.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_tracking_purchase.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_tracking_purchase.zz_OriginalDesign = false;
            this.ctl_tracking_purchase.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_tracking_purchase.zz_ShowNeedsSaveColor = true;
            this.ctl_tracking_purchase.zz_Text = "";
            this.ctl_tracking_purchase.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_tracking_purchase.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_tracking_purchase.zz_UseGlobalColor = false;
            this.ctl_tracking_purchase.zz_UseGlobalFont = false;
            // 
            // ctl_shippingaccount_purchase
            // 
            this.ctl_shippingaccount_purchase.AllCaps = false;
            this.ctl_shippingaccount_purchase.AllowEdit = false;
            this.ctl_shippingaccount_purchase.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shippingaccount_purchase.Bold = false;
            this.ctl_shippingaccount_purchase.Caption = "Shipping Account";
            this.ctl_shippingaccount_purchase.Changed = false;
            this.ctl_shippingaccount_purchase.ListName = "";
            this.ctl_shippingaccount_purchase.Location = new System.Drawing.Point(236, 251);
            this.ctl_shippingaccount_purchase.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_shippingaccount_purchase.Name = "ctl_shippingaccount_purchase";
            this.ctl_shippingaccount_purchase.SimpleList = null;
            this.ctl_shippingaccount_purchase.Size = new System.Drawing.Size(215, 44);
            this.ctl_shippingaccount_purchase.TabIndex = 14;
            this.ctl_shippingaccount_purchase.UseParentBackColor = false;
            this.ctl_shippingaccount_purchase.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_shippingaccount_purchase.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shippingaccount_purchase.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shippingaccount_purchase.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shippingaccount_purchase.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shippingaccount_purchase.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_shippingaccount_purchase.zz_OriginalDesign = false;
            this.ctl_shippingaccount_purchase.zz_ShowNeedsSaveColor = true;
            this.ctl_shippingaccount_purchase.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shippingaccount_purchase.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shippingaccount_purchase.zz_UseGlobalColor = false;
            this.ctl_shippingaccount_purchase.zz_UseGlobalFont = false;
            // 
            // ctl_shipvia_purchase
            // 
            this.ctl_shipvia_purchase.AllCaps = false;
            this.ctl_shipvia_purchase.AllowEdit = false;
            this.ctl_shipvia_purchase.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shipvia_purchase.Bold = false;
            this.ctl_shipvia_purchase.Caption = "Ship Via";
            this.ctl_shipvia_purchase.Changed = false;
            this.ctl_shipvia_purchase.ListName = "shipvia";
            this.ctl_shipvia_purchase.Location = new System.Drawing.Point(3, 251);
            this.ctl_shipvia_purchase.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_shipvia_purchase.Name = "ctl_shipvia_purchase";
            this.ctl_shipvia_purchase.SimpleList = null;
            this.ctl_shipvia_purchase.Size = new System.Drawing.Size(224, 44);
            this.ctl_shipvia_purchase.TabIndex = 13;
            this.ctl_shipvia_purchase.UseParentBackColor = false;
            this.ctl_shipvia_purchase.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_shipvia_purchase.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shipvia_purchase.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shipvia_purchase.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shipvia_purchase.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shipvia_purchase.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_shipvia_purchase.zz_OriginalDesign = false;
            this.ctl_shipvia_purchase.zz_ShowNeedsSaveColor = true;
            this.ctl_shipvia_purchase.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shipvia_purchase.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shipvia_purchase.zz_UseGlobalColor = false;
            this.ctl_shipvia_purchase.zz_UseGlobalFont = false;
            // 
            // ctl_charge2_fee_purchase
            // 
            this.ctl_charge2_fee_purchase.BackColor = System.Drawing.Color.Transparent;
            this.ctl_charge2_fee_purchase.Bold = false;
            this.ctl_charge2_fee_purchase.Caption = "Charge 2";
            this.ctl_charge2_fee_purchase.Changed = false;
            this.ctl_charge2_fee_purchase.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_charge2_fee_purchase.Location = new System.Drawing.Point(8, 110);
            this.ctl_charge2_fee_purchase.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_charge2_fee_purchase.Name = "ctl_charge2_fee_purchase";
            this.ctl_charge2_fee_purchase.Size = new System.Drawing.Size(191, 44);
            this.ctl_charge2_fee_purchase.TabIndex = 14;
            this.ctl_charge2_fee_purchase.UseParentBackColor = true;
            this.ctl_charge2_fee_purchase.zz_Enabled = true;
            this.ctl_charge2_fee_purchase.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_charge2_fee_purchase.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_charge2_fee_purchase.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_charge2_fee_purchase.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_charge2_fee_purchase.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_charge2_fee_purchase.zz_OriginalDesign = false;
            this.ctl_charge2_fee_purchase.zz_ShowErrorColor = true;
            this.ctl_charge2_fee_purchase.zz_ShowNeedsSaveColor = true;
            this.ctl_charge2_fee_purchase.zz_Text = "";
            this.ctl_charge2_fee_purchase.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_charge2_fee_purchase.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_charge2_fee_purchase.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_charge2_fee_purchase.zz_UseGlobalColor = false;
            this.ctl_charge2_fee_purchase.zz_UseGlobalFont = false;
            // 
            // ctl_charge1_fee_purchase
            // 
            this.ctl_charge1_fee_purchase.BackColor = System.Drawing.Color.Transparent;
            this.ctl_charge1_fee_purchase.Bold = false;
            this.ctl_charge1_fee_purchase.Caption = "Charge 1";
            this.ctl_charge1_fee_purchase.Changed = false;
            this.ctl_charge1_fee_purchase.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_charge1_fee_purchase.Location = new System.Drawing.Point(8, 60);
            this.ctl_charge1_fee_purchase.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_charge1_fee_purchase.Name = "ctl_charge1_fee_purchase";
            this.ctl_charge1_fee_purchase.Size = new System.Drawing.Size(191, 44);
            this.ctl_charge1_fee_purchase.TabIndex = 13;
            this.ctl_charge1_fee_purchase.UseParentBackColor = true;
            this.ctl_charge1_fee_purchase.zz_Enabled = true;
            this.ctl_charge1_fee_purchase.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_charge1_fee_purchase.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_charge1_fee_purchase.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_charge1_fee_purchase.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_charge1_fee_purchase.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_charge1_fee_purchase.zz_OriginalDesign = false;
            this.ctl_charge1_fee_purchase.zz_ShowErrorColor = true;
            this.ctl_charge1_fee_purchase.zz_ShowNeedsSaveColor = true;
            this.ctl_charge1_fee_purchase.zz_Text = "";
            this.ctl_charge1_fee_purchase.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_charge1_fee_purchase.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_charge1_fee_purchase.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_charge1_fee_purchase.zz_UseGlobalColor = false;
            this.ctl_charge1_fee_purchase.zz_UseGlobalFont = false;
            // 
            // ctl_shipping_fee_purchase
            // 
            this.ctl_shipping_fee_purchase.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shipping_fee_purchase.Bold = false;
            this.ctl_shipping_fee_purchase.Caption = "Shipping";
            this.ctl_shipping_fee_purchase.Changed = false;
            this.ctl_shipping_fee_purchase.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_shipping_fee_purchase.Location = new System.Drawing.Point(8, 10);
            this.ctl_shipping_fee_purchase.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_shipping_fee_purchase.Name = "ctl_shipping_fee_purchase";
            this.ctl_shipping_fee_purchase.Size = new System.Drawing.Size(191, 44);
            this.ctl_shipping_fee_purchase.TabIndex = 12;
            this.ctl_shipping_fee_purchase.UseParentBackColor = true;
            this.ctl_shipping_fee_purchase.zz_Enabled = true;
            this.ctl_shipping_fee_purchase.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shipping_fee_purchase.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shipping_fee_purchase.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shipping_fee_purchase.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shipping_fee_purchase.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_shipping_fee_purchase.zz_OriginalDesign = false;
            this.ctl_shipping_fee_purchase.zz_ShowErrorColor = true;
            this.ctl_shipping_fee_purchase.zz_ShowNeedsSaveColor = true;
            this.ctl_shipping_fee_purchase.zz_Text = "";
            this.ctl_shipping_fee_purchase.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_shipping_fee_purchase.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shipping_fee_purchase.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shipping_fee_purchase.zz_UseGlobalColor = false;
            this.ctl_shipping_fee_purchase.zz_UseGlobalFont = false;
            // 
            // ctl_notes_purchase
            // 
            this.ctl_notes_purchase.BackColor = System.Drawing.Color.Transparent;
            this.ctl_notes_purchase.Bold = false;
            this.ctl_notes_purchase.Caption = "Notes";
            this.ctl_notes_purchase.Changed = false;
            this.ctl_notes_purchase.DateLines = false;
            this.ctl_notes_purchase.Location = new System.Drawing.Point(6, 51);
            this.ctl_notes_purchase.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_notes_purchase.Name = "ctl_notes_purchase";
            this.ctl_notes_purchase.Size = new System.Drawing.Size(572, 90);
            this.ctl_notes_purchase.TabIndex = 52;
            this.ctl_notes_purchase.UseParentBackColor = false;
            this.ctl_notes_purchase.zz_Enabled = true;
            this.ctl_notes_purchase.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_notes_purchase.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_notes_purchase.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_notes_purchase.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_notes_purchase.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_notes_purchase.zz_OriginalDesign = false;
            this.ctl_notes_purchase.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_notes_purchase.zz_ShowNeedsSaveColor = true;
            this.ctl_notes_purchase.zz_Text = "";
            this.ctl_notes_purchase.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_notes_purchase.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_notes_purchase.zz_UseGlobalColor = false;
            this.ctl_notes_purchase.zz_UseGlobalFont = false;
            // 
            // ctl_unit_cost
            // 
            this.ctl_unit_cost.BackColor = System.Drawing.Color.Transparent;
            this.ctl_unit_cost.Bold = false;
            this.ctl_unit_cost.Caption = "Unit Cost";
            this.ctl_unit_cost.Changed = false;
            this.ctl_unit_cost.EditCaption = false;
            this.ctl_unit_cost.FullDecimal = false;
            this.ctl_unit_cost.Location = new System.Drawing.Point(667, 4);
            this.ctl_unit_cost.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_unit_cost.Name = "ctl_unit_cost";
            this.ctl_unit_cost.RoundNearestCent = false;
            this.ctl_unit_cost.Size = new System.Drawing.Size(107, 44);
            this.ctl_unit_cost.TabIndex = 2;
            this.ctl_unit_cost.UseParentBackColor = true;
            this.ctl_unit_cost.zz_Enabled = true;
            this.ctl_unit_cost.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_unit_cost.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_unit_cost.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_unit_cost.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_unit_cost.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_unit_cost.zz_OriginalDesign = false;
            this.ctl_unit_cost.zz_ShowErrorColor = true;
            this.ctl_unit_cost.zz_ShowNeedsSaveColor = true;
            this.ctl_unit_cost.zz_Text = "";
            this.ctl_unit_cost.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_unit_cost.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_unit_cost.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_unit_cost.zz_UseGlobalColor = false;
            this.ctl_unit_cost.zz_UseGlobalFont = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(528, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 18);
            this.label1.TabIndex = 56;
            this.label1.Text = "Received";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUnpacked
            // 
            this.lblUnpacked.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnpacked.Location = new System.Drawing.Point(527, 25);
            this.lblUnpacked.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUnpacked.Name = "lblUnpacked";
            this.lblUnpacked.Size = new System.Drawing.Size(132, 23);
            this.lblUnpacked.TabIndex = 57;
            this.lblUnpacked.Text = "1,000,000";
            this.lblUnpacked.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabPack
            // 
            this.tabPack.Location = new System.Drawing.Point(4, 22);
            this.tabPack.Margin = new System.Windows.Forms.Padding(4);
            this.tabPack.Name = "tabPack";
            this.tabPack.Padding = new System.Windows.Forms.Padding(4);
            this.tabPack.Size = new System.Drawing.Size(804, 294);
            this.tabPack.TabIndex = 3;
            this.tabPack.Text = "Receive";
            this.tabPack.UseVisualStyleBackColor = true;
            // 
            // tabDeductions
            // 
            this.tabDeductions.Controls.Add(this.deductions);
            this.tabDeductions.Location = new System.Drawing.Point(4, 22);
            this.tabDeductions.Margin = new System.Windows.Forms.Padding(4);
            this.tabDeductions.Name = "tabDeductions";
            this.tabDeductions.Padding = new System.Windows.Forms.Padding(4);
            this.tabDeductions.Size = new System.Drawing.Size(804, 294);
            this.tabDeductions.TabIndex = 4;
            this.tabDeductions.Text = "Deductions";
            this.tabDeductions.UseVisualStyleBackColor = true;
            // 
            // deductions
            // 
            this.deductions.BackColor = System.Drawing.Color.White;
            this.deductions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deductions.Location = new System.Drawing.Point(4, 4);
            this.deductions.Margin = new System.Windows.Forms.Padding(5);
            this.deductions.Name = "deductions";
            this.deductions.Size = new System.Drawing.Size(796, 286);
            this.deductions.TabIndex = 0;
            // 
            // ctl_internal_vendor
            // 
            this.ctl_internal_vendor.AllCaps = false;
            this.ctl_internal_vendor.BackColor = System.Drawing.Color.Transparent;
            this.ctl_internal_vendor.Bold = false;
            this.ctl_internal_vendor.Caption = "Internal Part";
            this.ctl_internal_vendor.Changed = false;
            this.ctl_internal_vendor.IsEmail = false;
            this.ctl_internal_vendor.IsURL = false;
            this.ctl_internal_vendor.Location = new System.Drawing.Point(177, 176);
            this.ctl_internal_vendor.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_internal_vendor.Name = "ctl_internal_vendor";
            this.ctl_internal_vendor.PasswordChar = '\0';
            this.ctl_internal_vendor.Size = new System.Drawing.Size(262, 40);
            this.ctl_internal_vendor.TabIndex = 11;
            this.ctl_internal_vendor.UseParentBackColor = false;
            this.ctl_internal_vendor.zz_Enabled = true;
            this.ctl_internal_vendor.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_internal_vendor.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_internal_vendor.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_internal_vendor.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_internal_vendor.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_internal_vendor.zz_OriginalDesign = false;
            this.ctl_internal_vendor.zz_ShowLinkButton = false;
            this.ctl_internal_vendor.zz_ShowNeedsSaveColor = true;
            this.ctl_internal_vendor.zz_Text = "";
            this.ctl_internal_vendor.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_internal_vendor.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_internal_vendor.zz_TextFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_internal_vendor.zz_UseGlobalColor = false;
            this.ctl_internal_vendor.zz_UseGlobalFont = false;
            // 
            // ctl_rohs_info_vendor
            // 
            this.ctl_rohs_info_vendor.AllCaps = false;
            this.ctl_rohs_info_vendor.AllowEdit = false;
            this.ctl_rohs_info_vendor.BackColor = System.Drawing.Color.Transparent;
            this.ctl_rohs_info_vendor.Bold = false;
            this.ctl_rohs_info_vendor.Caption = "RoHS (Vendor)";
            this.ctl_rohs_info_vendor.Changed = false;
            this.ctl_rohs_info_vendor.ListName = "";
            this.ctl_rohs_info_vendor.Location = new System.Drawing.Point(455, 172);
            this.ctl_rohs_info_vendor.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_rohs_info_vendor.Name = "ctl_rohs_info_vendor";
            this.ctl_rohs_info_vendor.SimpleList = "Y|N|U";
            this.ctl_rohs_info_vendor.Size = new System.Drawing.Size(87, 44);
            this.ctl_rohs_info_vendor.TabIndex = 12;
            this.ctl_rohs_info_vendor.UseParentBackColor = false;
            this.ctl_rohs_info_vendor.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_rohs_info_vendor.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_rohs_info_vendor.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_rohs_info_vendor.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_rohs_info_vendor.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_rohs_info_vendor.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_rohs_info_vendor.zz_OriginalDesign = false;
            this.ctl_rohs_info_vendor.zz_ShowNeedsSaveColor = true;
            this.ctl_rohs_info_vendor.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_rohs_info_vendor.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_rohs_info_vendor.zz_UseGlobalColor = false;
            this.ctl_rohs_info_vendor.zz_UseGlobalFont = false;
            // 
            // ctl_datecode_purchase
            // 
            this.ctl_datecode_purchase.AllCaps = false;
            this.ctl_datecode_purchase.BackColor = System.Drawing.Color.Transparent;
            this.ctl_datecode_purchase.Bold = false;
            this.ctl_datecode_purchase.Caption = "Date Code (Vendor)";
            this.ctl_datecode_purchase.Changed = false;
            this.ctl_datecode_purchase.IsEmail = false;
            this.ctl_datecode_purchase.IsURL = false;
            this.ctl_datecode_purchase.Location = new System.Drawing.Point(153, 58);
            this.ctl_datecode_purchase.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_datecode_purchase.Name = "ctl_datecode_purchase";
            this.ctl_datecode_purchase.PasswordChar = '\0';
            this.ctl_datecode_purchase.Size = new System.Drawing.Size(115, 40);
            this.ctl_datecode_purchase.TabIndex = 4;
            this.ctl_datecode_purchase.UseParentBackColor = false;
            this.ctl_datecode_purchase.zz_Enabled = true;
            this.ctl_datecode_purchase.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_datecode_purchase.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_datecode_purchase.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_datecode_purchase.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_datecode_purchase.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_datecode_purchase.zz_OriginalDesign = false;
            this.ctl_datecode_purchase.zz_ShowLinkButton = false;
            this.ctl_datecode_purchase.zz_ShowNeedsSaveColor = true;
            this.ctl_datecode_purchase.zz_Text = "";
            this.ctl_datecode_purchase.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_datecode_purchase.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_datecode_purchase.zz_TextFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_datecode_purchase.zz_UseGlobalColor = false;
            this.ctl_datecode_purchase.zz_UseGlobalFont = false;
            // 
            // tabDates
            // 
            this.tabDates.Controls.Add(this.ctl_receive_date_actual);
            this.tabDates.Controls.Add(this.ctl_receive_date_due);
            this.tabDates.Controls.Add(this.ctl_customer_dock_date);
            this.tabDates.Controls.Add(this.ctl_ship_date_actual);
            this.tabDates.Controls.Add(this.ctl_ship_date_due);
            this.tabDates.Location = new System.Drawing.Point(4, 22);
            this.tabDates.Name = "tabDates";
            this.tabDates.Size = new System.Drawing.Size(804, 294);
            this.tabDates.TabIndex = 5;
            this.tabDates.Text = "Due Dates";
            this.tabDates.UseVisualStyleBackColor = true;
            // 
            // ctl_receive_date_actual
            // 
            this.ctl_receive_date_actual.AllowClear = false;
            this.ctl_receive_date_actual.BackColor = System.Drawing.Color.Transparent;
            this.ctl_receive_date_actual.Bold = false;
            this.ctl_receive_date_actual.Caption = "Actual Receive Date";
            this.ctl_receive_date_actual.Changed = false;
            this.ctl_receive_date_actual.Enabled = false;
            this.ctl_receive_date_actual.Location = new System.Drawing.Point(249, 83);
            this.ctl_receive_date_actual.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_receive_date_actual.Name = "ctl_receive_date_actual";
            this.ctl_receive_date_actual.Size = new System.Drawing.Size(215, 50);
            this.ctl_receive_date_actual.SuppressEdit = false;
            this.ctl_receive_date_actual.TabIndex = 57;
            this.ctl_receive_date_actual.UseParentBackColor = false;
            this.ctl_receive_date_actual.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_receive_date_actual.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_receive_date_actual.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_receive_date_actual.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_receive_date_actual.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_receive_date_actual.zz_OriginalDesign = false;
            this.ctl_receive_date_actual.zz_ShowNeedsSaveColor = true;
            this.ctl_receive_date_actual.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_receive_date_actual.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_receive_date_actual.zz_UseGlobalColor = false;
            this.ctl_receive_date_actual.zz_UseGlobalFont = false;
            // 
            // ctl_receive_date_due
            // 
            this.ctl_receive_date_due.AllowClear = false;
            this.ctl_receive_date_due.BackColor = System.Drawing.Color.Transparent;
            this.ctl_receive_date_due.Bold = false;
            this.ctl_receive_date_due.Caption = "Receive Due Date";
            this.ctl_receive_date_due.Changed = false;
            this.ctl_receive_date_due.Location = new System.Drawing.Point(17, 83);
            this.ctl_receive_date_due.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_receive_date_due.Name = "ctl_receive_date_due";
            this.ctl_receive_date_due.Size = new System.Drawing.Size(224, 50);
            this.ctl_receive_date_due.SuppressEdit = false;
            this.ctl_receive_date_due.TabIndex = 56;
            this.ctl_receive_date_due.UseParentBackColor = false;
            this.ctl_receive_date_due.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_receive_date_due.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_receive_date_due.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_receive_date_due.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_receive_date_due.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_receive_date_due.zz_OriginalDesign = false;
            this.ctl_receive_date_due.zz_ShowNeedsSaveColor = true;
            this.ctl_receive_date_due.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_receive_date_due.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_receive_date_due.zz_UseGlobalColor = false;
            this.ctl_receive_date_due.zz_UseGlobalFont = false;
            // 
            // ctl_customer_dock_date
            // 
            this.ctl_customer_dock_date.AllowClear = false;
            this.ctl_customer_dock_date.BackColor = System.Drawing.Color.Transparent;
            this.ctl_customer_dock_date.Bold = false;
            this.ctl_customer_dock_date.Caption = "Customer Dock Date";
            this.ctl_customer_dock_date.Changed = false;
            this.ctl_customer_dock_date.Location = new System.Drawing.Point(472, 21);
            this.ctl_customer_dock_date.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_customer_dock_date.Name = "ctl_customer_dock_date";
            this.ctl_customer_dock_date.Size = new System.Drawing.Size(215, 50);
            this.ctl_customer_dock_date.SuppressEdit = false;
            this.ctl_customer_dock_date.TabIndex = 55;
            this.ctl_customer_dock_date.UseParentBackColor = false;
            this.ctl_customer_dock_date.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_customer_dock_date.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_customer_dock_date.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_customer_dock_date.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_customer_dock_date.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_customer_dock_date.zz_OriginalDesign = false;
            this.ctl_customer_dock_date.zz_ShowNeedsSaveColor = true;
            this.ctl_customer_dock_date.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_customer_dock_date.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_customer_dock_date.zz_UseGlobalColor = false;
            this.ctl_customer_dock_date.zz_UseGlobalFont = false;
            // 
            // ctl_ship_date_actual
            // 
            this.ctl_ship_date_actual.AllowClear = false;
            this.ctl_ship_date_actual.BackColor = System.Drawing.Color.Transparent;
            this.ctl_ship_date_actual.Bold = false;
            this.ctl_ship_date_actual.Caption = "Actual Ship Date";
            this.ctl_ship_date_actual.Changed = false;
            this.ctl_ship_date_actual.Enabled = false;
            this.ctl_ship_date_actual.Location = new System.Drawing.Point(249, 21);
            this.ctl_ship_date_actual.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_ship_date_actual.Name = "ctl_ship_date_actual";
            this.ctl_ship_date_actual.Size = new System.Drawing.Size(215, 50);
            this.ctl_ship_date_actual.SuppressEdit = false;
            this.ctl_ship_date_actual.TabIndex = 52;
            this.ctl_ship_date_actual.UseParentBackColor = false;
            this.ctl_ship_date_actual.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_ship_date_actual.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_ship_date_actual.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_ship_date_actual.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ship_date_actual.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_ship_date_actual.zz_OriginalDesign = false;
            this.ctl_ship_date_actual.zz_ShowNeedsSaveColor = true;
            this.ctl_ship_date_actual.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_ship_date_actual.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_ship_date_actual.zz_UseGlobalColor = false;
            this.ctl_ship_date_actual.zz_UseGlobalFont = false;
            // 
            // ctl_ship_date_due
            // 
            this.ctl_ship_date_due.AllowClear = false;
            this.ctl_ship_date_due.BackColor = System.Drawing.Color.Transparent;
            this.ctl_ship_date_due.Bold = false;
            this.ctl_ship_date_due.Caption = "Shipping Due Date";
            this.ctl_ship_date_due.Changed = false;
            this.ctl_ship_date_due.Location = new System.Drawing.Point(17, 21);
            this.ctl_ship_date_due.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_ship_date_due.Name = "ctl_ship_date_due";
            this.ctl_ship_date_due.Size = new System.Drawing.Size(224, 50);
            this.ctl_ship_date_due.SuppressEdit = false;
            this.ctl_ship_date_due.TabIndex = 51;
            this.ctl_ship_date_due.UseParentBackColor = false;
            this.ctl_ship_date_due.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_ship_date_due.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_ship_date_due.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_ship_date_due.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ship_date_due.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_ship_date_due.zz_OriginalDesign = false;
            this.ctl_ship_date_due.zz_ShowNeedsSaveColor = true;
            this.ctl_ship_date_due.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_ship_date_due.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_ship_date_due.zz_UseGlobalColor = false;
            this.ctl_ship_date_due.zz_UseGlobalFont = false;
            // 
            // ctl_inspection_status
            // 
            this.ctl_inspection_status.AllCaps = false;
            this.ctl_inspection_status.AllowEdit = false;
            this.ctl_inspection_status.BackColor = System.Drawing.Color.Transparent;
            this.ctl_inspection_status.Bold = false;
            this.ctl_inspection_status.Caption = "Inspection Status";
            this.ctl_inspection_status.Changed = false;
            this.ctl_inspection_status.ListName = "inspection_status";
            this.ctl_inspection_status.Location = new System.Drawing.Point(606, 196);
            this.ctl_inspection_status.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_inspection_status.Name = "ctl_inspection_status";
            this.ctl_inspection_status.SimpleList = "Y|N|U";
            this.ctl_inspection_status.Size = new System.Drawing.Size(142, 44);
            this.ctl_inspection_status.TabIndex = 58;
            this.ctl_inspection_status.UseParentBackColor = false;
            this.ctl_inspection_status.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctl_inspection_status.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_inspection_status.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_inspection_status.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_inspection_status.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_inspection_status.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_inspection_status.zz_OriginalDesign = false;
            this.ctl_inspection_status.zz_ShowNeedsSaveColor = true;
            this.ctl_inspection_status.zz_TextColor = System.Drawing.Color.Black;
            this.ctl_inspection_status.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_inspection_status.zz_UseGlobalColor = false;
            this.ctl_inspection_status.zz_UseGlobalFont = false;
            // 
            // ViewDetailPurchase
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Margin = new System.Windows.Forms.Padding(16, 11, 16, 11);
            this.Name = "ViewDetailPurchase";
            this.Size = new System.Drawing.Size(1523, 800);
            this.ts.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.tabAttachments.ResumeLayout(false);
            this.gbAction1.ResumeLayout(false);
            this.gbAction1.PerformLayout();
            this.gbTop.ResumeLayout(false);
            this.gbTop.PerformLayout();
            this.tabDeductions.ResumeLayout(false);
            this.tabDates.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public NewMethod.nEdit_Number ctl_charge2_fee_purchase;
        public NewMethod.nEdit_Number ctl_charge1_fee_purchase;
        public NewMethod.nEdit_Number ctl_shipping_fee_purchase;
        private NewMethod.nEdit_Memo ctl_notes_purchase;
        private System.Windows.Forms.Label lblUnpacked;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPack;
        private System.Windows.Forms.TabPage tabDeductions;
        private Win.Controls.LineProfit deductions;
        private NewMethod.nEdit_String ctl_datecode_purchase;
        protected NewMethod.nEdit_String ctl_internal_vendor;
        protected NewMethod.nEdit_List ctl_rohs_info_vendor;
        protected NewMethod.nEdit_Money ctl_unit_cost;
        public NewMethod.nEdit_Memo ctl_tracking_purchase;
        public NewMethod.nEdit_List ctl_shippingaccount_purchase;
        public NewMethod.nEdit_List ctl_shipvia_purchase;
        private System.Windows.Forms.TabPage tabDates;
        private NewMethod.nEdit_Date ctl_customer_dock_date;
        private NewMethod.nEdit_Date ctl_ship_date_actual;
        private NewMethod.nEdit_Date ctl_ship_date_due;
        public NewMethod.nEdit_Date ctl_receive_date_actual;
        public NewMethod.nEdit_Date ctl_receive_date_due;
        public NewMethod.nEdit_List ctl_inspection_status;
    }
}
