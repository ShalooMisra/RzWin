namespace Rz5
{
    partial class ViewDetailSales
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctl_tracking_invoice = new NewMethod.nEdit_Memo();
            this.ctl_shippingaccount_invoice = new NewMethod.nEdit_List();
            this.ctl_shipvia_invoice = new NewMethod.nEdit_List();
            this.ctl_notes_sales = new NewMethod.nEdit_Memo();
            this.ctl_unit_cost = new NewMethod.nEdit_Money();
            this.ctl_unit_price = new NewMethod.nEdit_Money();
            this.tabDeductions = new System.Windows.Forms.TabPage();
            this.deductions = new Rz5.Win.Controls.LineProfit();
            this.ctl_internal_customer = new NewMethod.nEdit_String();
            this.tabDates = new System.Windows.Forms.TabPage();
            this.ctl_projected_dock_date = new NewMethod.nEdit_Date();
            this.ctl_orderdate_sales = new NewMethod.nEdit_Date();
            this.ctl_customer_dock_date = new NewMethod.nEdit_Date();
            this.ctl_receive_date_actual = new NewMethod.nEdit_Date();
            this.ctl_receive_date_due = new NewMethod.nEdit_Date();
            this.ctl_ship_date_actual = new NewMethod.nEdit_Date();
            this.ctl_ship_date_due = new NewMethod.nEdit_Date();
            this.pAllocation = new System.Windows.Forms.Panel();
            this.lblAllocated = new System.Windows.Forms.Label();
            this.lblAllocate = new System.Windows.Forms.LinkLabel();
            this.lblViewAllocate = new System.Windows.Forms.LinkLabel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblChooseVendor = new System.Windows.Forms.LinkLabel();
            this.pVendor = new System.Windows.Forms.Panel();
            this.ctl_tracking_purchase = new NewMethod.nEdit_Memo();
            this.lblVendorCompany = new System.Windows.Forms.Label();
            this.lblVendorContact = new System.Windows.Forms.Label();
            this.optConsign = new System.Windows.Forms.RadioButton();
            this.ctl_ConsignmentCode = new NewMethod.nEdit_List();
            this.ctl_LotStock = new NewMethod.nEdit_List();
            this.optVendor = new System.Windows.Forms.RadioButton();
            this.optStock = new System.Windows.Forms.RadioButton();
            this.ctl_affiliate_id = new NewMethod.nEdit_String();
            this.ts.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.tabAttachments.SuspendLayout();
            this.gbAction1.SuspendLayout();
            this.gbTop.SuspendLayout();
            this.tabDeductions.SuspendLayout();
            this.tabDates.SuspendLayout();
            this.pAllocation.SuspendLayout();
            this.pVendor.SuspendLayout();
            this.SuspendLayout();
            // 
            // ts
            // 
            this.ts.Controls.Add(this.tabDates);
            this.ts.Controls.Add(this.tabDeductions);
            this.ts.Margin = new System.Windows.Forms.Padding(5);
            this.ts.Size = new System.Drawing.Size(792, 714);
            this.ts.Controls.SetChildIndex(this.tabDeductions, 0);
            this.ts.Controls.SetChildIndex(this.tabDates, 0);
            this.ts.Controls.SetChildIndex(this.tabAttachments, 0);
            this.ts.Controls.SetChildIndex(this.tabInfo, 0);
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.ctl_affiliate_id);
            this.tabInfo.Controls.Add(this.optStock);
            this.tabInfo.Controls.Add(this.optVendor);
            this.tabInfo.Controls.Add(this.ctl_LotStock);
            this.tabInfo.Controls.Add(this.ctl_ConsignmentCode);
            this.tabInfo.Controls.Add(this.pAllocation);
            this.tabInfo.Controls.Add(this.lblFrom);
            this.tabInfo.Controls.Add(this.lblChooseVendor);
            this.tabInfo.Controls.Add(this.pVendor);
            this.tabInfo.Controls.Add(this.optConsign);
            this.tabInfo.Controls.Add(this.ctl_internal_customer);
            this.tabInfo.Controls.Add(this.ctl_unit_price);
            this.tabInfo.Controls.Add(this.ctl_tracking_invoice);
            this.tabInfo.Controls.Add(this.ctl_shippingaccount_invoice);
            this.tabInfo.Controls.Add(this.ctl_shipvia_invoice);
            this.tabInfo.Controls.Add(this.ctl_unit_cost);
            this.tabInfo.Margin = new System.Windows.Forms.Padding(5);
            this.tabInfo.Padding = new System.Windows.Forms.Padding(5);
            this.tabInfo.Size = new System.Drawing.Size(784, 688);
            this.tabInfo.Controls.SetChildIndex(this.ctl_country_of_origin_vendor, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_harmonized_tarriff_schedule, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_unit_cost, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_shipvia_invoice, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_shippingaccount_invoice, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_tracking_invoice, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_unit_price, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_internal_customer, 0);
            this.tabInfo.Controls.SetChildIndex(this.optConsign, 0);
            this.tabInfo.Controls.SetChildIndex(this.pVendor, 0);
            this.tabInfo.Controls.SetChildIndex(this.lblChooseVendor, 0);
            this.tabInfo.Controls.SetChildIndex(this.lblFrom, 0);
            this.tabInfo.Controls.SetChildIndex(this.pAllocation, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_ConsignmentCode, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_country_of_origin, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_rohs_info, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_alternatepart, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_description, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_internalcomment, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_fullpartnumber, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_datecode, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_manufacturer, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_condition, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_packaging, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_category, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_quantity, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_LotStock, 0);
            this.tabInfo.Controls.SetChildIndex(this.optVendor, 0);
            this.tabInfo.Controls.SetChildIndex(this.optStock, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_affiliate_id, 0);
            // 
            // tabAttachments
            // 
            this.tabAttachments.Margin = new System.Windows.Forms.Padding(5);
            this.tabAttachments.Padding = new System.Windows.Forms.Padding(5);
            this.tabAttachments.Size = new System.Drawing.Size(784, 688);
            // 
            // gbAction1
            // 
            this.gbAction1.Location = new System.Drawing.Point(800, 3);
            this.gbAction1.Size = new System.Drawing.Size(152, 143);
            // 
            // ctl_quantity
            // 
            this.ctl_quantity.Location = new System.Drawing.Point(427, 4);
            this.ctl_quantity.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            // 
            // ctl_fullpartnumber
            // 
            this.ctl_fullpartnumber.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.ctl_fullpartnumber.Size = new System.Drawing.Size(415, 44);
            this.ctl_fullpartnumber.zz_Enabled = true;
            // 
            // ctl_datecode
            // 
            this.ctl_datecode.Location = new System.Drawing.Point(153, 53);
            this.ctl_datecode.TabIndex = 5;
            this.ctl_datecode.zz_Enabled = true;
            // 
            // ctl_category
            // 
            this.ctl_category.Location = new System.Drawing.Point(3, 112);
            this.ctl_category.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.ctl_category.TabIndex = 8;
            // 
            // ctl_packaging
            // 
            this.ctl_packaging.Location = new System.Drawing.Point(417, 53);
            this.ctl_packaging.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.ctl_packaging.Size = new System.Drawing.Size(144, 44);
            this.ctl_packaging.TabIndex = 7;
            // 
            // picview
            // 
            this.picview.Location = new System.Drawing.Point(5, 5);
            this.picview.Margin = new System.Windows.Forms.Padding(5);
            this.picview.Size = new System.Drawing.Size(774, 678);
            // 
            // ctl_internalcomment
            // 
            this.ctl_internalcomment.Location = new System.Drawing.Point(5, 554);
            this.ctl_internalcomment.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.ctl_internalcomment.Size = new System.Drawing.Size(771, 127);
            // 
            // ctl_description
            // 
            this.ctl_description.Location = new System.Drawing.Point(177, 112);
            this.ctl_description.TabIndex = 9;
            // 
            // ctl_alternatepart
            // 
            this.ctl_alternatepart.Location = new System.Drawing.Point(3, 175);
            this.ctl_alternatepart.TabIndex = 11;
            // 
            // ctl_rohs_info
            // 
            this.ctl_rohs_info.Location = new System.Drawing.Point(407, 170);
            this.ctl_rohs_info.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.ctl_rohs_info.TabIndex = 13;
            // 
            // ctl_condition
            // 
            this.ctl_condition.Location = new System.Drawing.Point(252, 53);
            this.ctl_condition.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.ctl_condition.TabIndex = 6;
            // 
            // ctl_country_of_origin
            // 
            this.ctl_country_of_origin.Location = new System.Drawing.Point(590, 112);
            this.ctl_country_of_origin.Size = new System.Drawing.Size(157, 44);
            this.ctl_country_of_origin.TabIndex = 10;
            // 
            // ctl_harmonized_tarriff_schedule
            // 
            this.ctl_harmonized_tarriff_schedule.Location = new System.Drawing.Point(590, 57);
            // 
            // ctl_manufacturer
            // 
            this.ctl_manufacturer.Location = new System.Drawing.Point(3, 57);
            this.ctl_manufacturer.TabIndex = 4;
            // 
            // ctl_country_of_origin_vendor
            // 
            this.ctl_country_of_origin_vendor.Location = new System.Drawing.Point(590, 165);
            this.ctl_country_of_origin_vendor.zz_Enabled = true;
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(1375, 0);
            this.xActions.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.xActions.Size = new System.Drawing.Size(148, 801);
            // 
            // ctl_tracking_invoice
            // 
            this.ctl_tracking_invoice.BackColor = System.Drawing.Color.Transparent;
            this.ctl_tracking_invoice.Bold = false;
            this.ctl_tracking_invoice.Caption = "Customer Tracking Numbers";
            this.ctl_tracking_invoice.Changed = false;
            this.ctl_tracking_invoice.DateLines = false;
            this.ctl_tracking_invoice.Location = new System.Drawing.Point(498, 220);
            this.ctl_tracking_invoice.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_tracking_invoice.Name = "ctl_tracking_invoice";
            this.ctl_tracking_invoice.Size = new System.Drawing.Size(278, 66);
            this.ctl_tracking_invoice.TabIndex = 16;
            this.ctl_tracking_invoice.UseParentBackColor = false;
            this.ctl_tracking_invoice.zz_Enabled = true;
            this.ctl_tracking_invoice.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_tracking_invoice.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_tracking_invoice.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_tracking_invoice.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_tracking_invoice.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_tracking_invoice.zz_OriginalDesign = false;
            this.ctl_tracking_invoice.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_tracking_invoice.zz_ShowNeedsSaveColor = true;
            this.ctl_tracking_invoice.zz_Text = "";
            this.ctl_tracking_invoice.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_tracking_invoice.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_tracking_invoice.zz_UseGlobalColor = false;
            this.ctl_tracking_invoice.zz_UseGlobalFont = false;
            // 
            // ctl_shippingaccount_invoice
            // 
            this.ctl_shippingaccount_invoice.AllCaps = false;
            this.ctl_shippingaccount_invoice.AllowEdit = false;
            this.ctl_shippingaccount_invoice.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shippingaccount_invoice.Bold = false;
            this.ctl_shippingaccount_invoice.Caption = "Shipping Account";
            this.ctl_shippingaccount_invoice.Changed = false;
            this.ctl_shippingaccount_invoice.ListName = "";
            this.ctl_shippingaccount_invoice.Location = new System.Drawing.Point(153, 236);
            this.ctl_shippingaccount_invoice.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_shippingaccount_invoice.Name = "ctl_shippingaccount_invoice";
            this.ctl_shippingaccount_invoice.SimpleList = null;
            this.ctl_shippingaccount_invoice.Size = new System.Drawing.Size(137, 44);
            this.ctl_shippingaccount_invoice.TabIndex = 15;
            this.ctl_shippingaccount_invoice.UseParentBackColor = false;
            this.ctl_shippingaccount_invoice.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_shippingaccount_invoice.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shippingaccount_invoice.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shippingaccount_invoice.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shippingaccount_invoice.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shippingaccount_invoice.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_shippingaccount_invoice.zz_OriginalDesign = false;
            this.ctl_shippingaccount_invoice.zz_ShowNeedsSaveColor = true;
            this.ctl_shippingaccount_invoice.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shippingaccount_invoice.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shippingaccount_invoice.zz_UseGlobalColor = false;
            this.ctl_shippingaccount_invoice.zz_UseGlobalFont = false;
            // 
            // ctl_shipvia_invoice
            // 
            this.ctl_shipvia_invoice.AllCaps = false;
            this.ctl_shipvia_invoice.AllowEdit = false;
            this.ctl_shipvia_invoice.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shipvia_invoice.Bold = false;
            this.ctl_shipvia_invoice.Caption = "Ship Via";
            this.ctl_shipvia_invoice.Changed = false;
            this.ctl_shipvia_invoice.ListName = "shipvia";
            this.ctl_shipvia_invoice.Location = new System.Drawing.Point(4, 236);
            this.ctl_shipvia_invoice.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_shipvia_invoice.Name = "ctl_shipvia_invoice";
            this.ctl_shipvia_invoice.SimpleList = null;
            this.ctl_shipvia_invoice.Size = new System.Drawing.Size(143, 44);
            this.ctl_shipvia_invoice.TabIndex = 14;
            this.ctl_shipvia_invoice.UseParentBackColor = false;
            this.ctl_shipvia_invoice.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_shipvia_invoice.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shipvia_invoice.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shipvia_invoice.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shipvia_invoice.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shipvia_invoice.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_shipvia_invoice.zz_OriginalDesign = false;
            this.ctl_shipvia_invoice.zz_ShowNeedsSaveColor = true;
            this.ctl_shipvia_invoice.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shipvia_invoice.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shipvia_invoice.zz_UseGlobalColor = false;
            this.ctl_shipvia_invoice.zz_UseGlobalFont = false;
            // 
            // ctl_notes_sales
            // 
            this.ctl_notes_sales.BackColor = System.Drawing.Color.Transparent;
            this.ctl_notes_sales.Bold = false;
            this.ctl_notes_sales.Caption = "Notes";
            this.ctl_notes_sales.Changed = false;
            this.ctl_notes_sales.DateLines = false;
            this.ctl_notes_sales.Location = new System.Drawing.Point(6, 51);
            this.ctl_notes_sales.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_notes_sales.Name = "ctl_notes_sales";
            this.ctl_notes_sales.Size = new System.Drawing.Size(572, 105);
            this.ctl_notes_sales.TabIndex = 53;
            this.ctl_notes_sales.UseParentBackColor = false;
            this.ctl_notes_sales.zz_Enabled = true;
            this.ctl_notes_sales.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_notes_sales.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_notes_sales.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_notes_sales.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_notes_sales.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_notes_sales.zz_OriginalDesign = false;
            this.ctl_notes_sales.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_notes_sales.zz_ShowNeedsSaveColor = true;
            this.ctl_notes_sales.zz_Text = "";
            this.ctl_notes_sales.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_notes_sales.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_notes_sales.zz_UseGlobalColor = false;
            this.ctl_notes_sales.zz_UseGlobalFont = false;
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
            this.ctl_unit_cost.TabIndex = 3;
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
            // ctl_unit_price
            // 
            this.ctl_unit_price.BackColor = System.Drawing.Color.Transparent;
            this.ctl_unit_price.Bold = false;
            this.ctl_unit_price.Caption = "Unit Price";
            this.ctl_unit_price.Changed = false;
            this.ctl_unit_price.EditCaption = false;
            this.ctl_unit_price.FullDecimal = false;
            this.ctl_unit_price.Location = new System.Drawing.Point(552, 4);
            this.ctl_unit_price.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_unit_price.Name = "ctl_unit_price";
            this.ctl_unit_price.RoundNearestCent = false;
            this.ctl_unit_price.Size = new System.Drawing.Size(107, 44);
            this.ctl_unit_price.TabIndex = 2;
            this.ctl_unit_price.UseParentBackColor = true;
            this.ctl_unit_price.zz_Enabled = true;
            this.ctl_unit_price.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_unit_price.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_unit_price.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_unit_price.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_unit_price.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_unit_price.zz_OriginalDesign = false;
            this.ctl_unit_price.zz_ShowErrorColor = true;
            this.ctl_unit_price.zz_ShowNeedsSaveColor = true;
            this.ctl_unit_price.zz_Text = "";
            this.ctl_unit_price.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_unit_price.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_unit_price.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_unit_price.zz_UseGlobalColor = false;
            this.ctl_unit_price.zz_UseGlobalFont = false;
            // 
            // tabDeductions
            // 
            this.tabDeductions.Controls.Add(this.deductions);
            this.tabDeductions.Location = new System.Drawing.Point(4, 22);
            this.tabDeductions.Margin = new System.Windows.Forms.Padding(4);
            this.tabDeductions.Name = "tabDeductions";
            this.tabDeductions.Padding = new System.Windows.Forms.Padding(4);
            this.tabDeductions.Size = new System.Drawing.Size(804, 294);
            this.tabDeductions.TabIndex = 3;
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
            // ctl_internal_customer
            // 
            this.ctl_internal_customer.AllCaps = false;
            this.ctl_internal_customer.BackColor = System.Drawing.Color.Transparent;
            this.ctl_internal_customer.Bold = false;
            this.ctl_internal_customer.Caption = "Internal Part";
            this.ctl_internal_customer.Changed = false;
            this.ctl_internal_customer.IsEmail = false;
            this.ctl_internal_customer.IsURL = false;
            this.ctl_internal_customer.Location = new System.Drawing.Point(177, 174);
            this.ctl_internal_customer.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_internal_customer.Name = "ctl_internal_customer";
            this.ctl_internal_customer.PasswordChar = '\0';
            this.ctl_internal_customer.Size = new System.Drawing.Size(224, 40);
            this.ctl_internal_customer.TabIndex = 12;
            this.ctl_internal_customer.UseParentBackColor = false;
            this.ctl_internal_customer.zz_Enabled = true;
            this.ctl_internal_customer.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_internal_customer.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_internal_customer.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_internal_customer.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_internal_customer.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_internal_customer.zz_OriginalDesign = false;
            this.ctl_internal_customer.zz_ShowLinkButton = false;
            this.ctl_internal_customer.zz_ShowNeedsSaveColor = true;
            this.ctl_internal_customer.zz_Text = "";
            this.ctl_internal_customer.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_internal_customer.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_internal_customer.zz_TextFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_internal_customer.zz_UseGlobalColor = false;
            this.ctl_internal_customer.zz_UseGlobalFont = false;
            // 
            // tabDates
            // 
            this.tabDates.Controls.Add(this.ctl_projected_dock_date);
            this.tabDates.Controls.Add(this.ctl_orderdate_sales);
            this.tabDates.Controls.Add(this.ctl_customer_dock_date);
            this.tabDates.Controls.Add(this.ctl_receive_date_actual);
            this.tabDates.Controls.Add(this.ctl_receive_date_due);
            this.tabDates.Controls.Add(this.ctl_ship_date_actual);
            this.tabDates.Controls.Add(this.ctl_ship_date_due);
            this.tabDates.Location = new System.Drawing.Point(4, 22);
            this.tabDates.Margin = new System.Windows.Forms.Padding(4);
            this.tabDates.Name = "tabDates";
            this.tabDates.Size = new System.Drawing.Size(804, 294);
            this.tabDates.TabIndex = 4;
            this.tabDates.Text = "Dates";
            this.tabDates.UseVisualStyleBackColor = true;
            // 
            // ctl_projected_dock_date
            // 
            this.ctl_projected_dock_date.AllowClear = false;
            this.ctl_projected_dock_date.BackColor = System.Drawing.Color.Transparent;
            this.ctl_projected_dock_date.Bold = false;
            this.ctl_projected_dock_date.Caption = "SM Projected Dock Date";
            this.ctl_projected_dock_date.Changed = false;
            this.ctl_projected_dock_date.Location = new System.Drawing.Point(8, 143);
            this.ctl_projected_dock_date.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_projected_dock_date.Name = "ctl_projected_dock_date";
            this.ctl_projected_dock_date.Size = new System.Drawing.Size(224, 50);
            this.ctl_projected_dock_date.SuppressEdit = false;
            this.ctl_projected_dock_date.TabIndex = 52;
            this.ctl_projected_dock_date.UseParentBackColor = false;
            this.ctl_projected_dock_date.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_projected_dock_date.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_projected_dock_date.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_projected_dock_date.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_projected_dock_date.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_projected_dock_date.zz_OriginalDesign = false;
            this.ctl_projected_dock_date.zz_ShowNeedsSaveColor = true;
            this.ctl_projected_dock_date.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_projected_dock_date.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_projected_dock_date.zz_UseGlobalColor = false;
            this.ctl_projected_dock_date.zz_UseGlobalFont = false;
            // 
            // ctl_orderdate_sales
            // 
            this.ctl_orderdate_sales.AllowClear = false;
            this.ctl_orderdate_sales.BackColor = System.Drawing.Color.Transparent;
            this.ctl_orderdate_sales.Bold = false;
            this.ctl_orderdate_sales.Caption = "Update Sale Date (For use with Daily WhiteBoard)";
            this.ctl_orderdate_sales.Changed = false;
            this.ctl_orderdate_sales.Enabled = false;
            this.ctl_orderdate_sales.Location = new System.Drawing.Point(8, 279);
            this.ctl_orderdate_sales.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_orderdate_sales.Name = "ctl_orderdate_sales";
            this.ctl_orderdate_sales.Size = new System.Drawing.Size(283, 50);
            this.ctl_orderdate_sales.SuppressEdit = false;
            this.ctl_orderdate_sales.TabIndex = 51;
            this.ctl_orderdate_sales.UseParentBackColor = false;
            this.ctl_orderdate_sales.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_orderdate_sales.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_orderdate_sales.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_orderdate_sales.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_orderdate_sales.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_orderdate_sales.zz_OriginalDesign = false;
            this.ctl_orderdate_sales.zz_ShowNeedsSaveColor = true;
            this.ctl_orderdate_sales.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_orderdate_sales.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_orderdate_sales.zz_UseGlobalColor = false;
            this.ctl_orderdate_sales.zz_UseGlobalFont = false;
            // 
            // ctl_customer_dock_date
            // 
            this.ctl_customer_dock_date.AllowClear = false;
            this.ctl_customer_dock_date.BackColor = System.Drawing.Color.Transparent;
            this.ctl_customer_dock_date.Bold = false;
            this.ctl_customer_dock_date.Caption = "Customer Dock Date";
            this.ctl_customer_dock_date.Changed = false;
            this.ctl_customer_dock_date.Location = new System.Drawing.Point(463, 10);
            this.ctl_customer_dock_date.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_customer_dock_date.Name = "ctl_customer_dock_date";
            this.ctl_customer_dock_date.Size = new System.Drawing.Size(215, 50);
            this.ctl_customer_dock_date.SuppressEdit = false;
            this.ctl_customer_dock_date.TabIndex = 48;
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
            // ctl_receive_date_actual
            // 
            this.ctl_receive_date_actual.AllowClear = false;
            this.ctl_receive_date_actual.BackColor = System.Drawing.Color.Transparent;
            this.ctl_receive_date_actual.Bold = false;
            this.ctl_receive_date_actual.Caption = "Actual Receive Date";
            this.ctl_receive_date_actual.Changed = false;
            this.ctl_receive_date_actual.Enabled = false;
            this.ctl_receive_date_actual.Location = new System.Drawing.Point(240, 79);
            this.ctl_receive_date_actual.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_receive_date_actual.Name = "ctl_receive_date_actual";
            this.ctl_receive_date_actual.Size = new System.Drawing.Size(215, 50);
            this.ctl_receive_date_actual.SuppressEdit = false;
            this.ctl_receive_date_actual.TabIndex = 50;
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
            this.ctl_receive_date_due.Location = new System.Drawing.Point(8, 79);
            this.ctl_receive_date_due.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_receive_date_due.Name = "ctl_receive_date_due";
            this.ctl_receive_date_due.Size = new System.Drawing.Size(224, 50);
            this.ctl_receive_date_due.SuppressEdit = false;
            this.ctl_receive_date_due.TabIndex = 49;
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
            // ctl_ship_date_actual
            // 
            this.ctl_ship_date_actual.AllowClear = false;
            this.ctl_ship_date_actual.BackColor = System.Drawing.Color.Transparent;
            this.ctl_ship_date_actual.Bold = false;
            this.ctl_ship_date_actual.Caption = "Actual Ship Date";
            this.ctl_ship_date_actual.Changed = false;
            this.ctl_ship_date_actual.Enabled = false;
            this.ctl_ship_date_actual.Location = new System.Drawing.Point(240, 10);
            this.ctl_ship_date_actual.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_ship_date_actual.Name = "ctl_ship_date_actual";
            this.ctl_ship_date_actual.Size = new System.Drawing.Size(215, 50);
            this.ctl_ship_date_actual.SuppressEdit = false;
            this.ctl_ship_date_actual.TabIndex = 47;
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
            this.ctl_ship_date_due.Location = new System.Drawing.Point(8, 10);
            this.ctl_ship_date_due.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_ship_date_due.Name = "ctl_ship_date_due";
            this.ctl_ship_date_due.Size = new System.Drawing.Size(224, 50);
            this.ctl_ship_date_due.SuppressEdit = false;
            this.ctl_ship_date_due.TabIndex = 46;
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
            // pAllocation
            // 
            this.pAllocation.BackColor = System.Drawing.Color.Gainsboro;
            this.pAllocation.Controls.Add(this.lblAllocated);
            this.pAllocation.Controls.Add(this.lblAllocate);
            this.pAllocation.Controls.Add(this.lblViewAllocate);
            this.pAllocation.Location = new System.Drawing.Point(14, 401);
            this.pAllocation.Margin = new System.Windows.Forms.Padding(4);
            this.pAllocation.Name = "pAllocation";
            this.pAllocation.Size = new System.Drawing.Size(509, 44);
            this.pAllocation.TabIndex = 89;
            this.pAllocation.Visible = false;
            // 
            // lblAllocated
            // 
            this.lblAllocated.AutoSize = true;
            this.lblAllocated.Location = new System.Drawing.Point(4, 4);
            this.lblAllocated.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAllocated.Name = "lblAllocated";
            this.lblAllocated.Size = new System.Drawing.Size(0, 13);
            this.lblAllocated.TabIndex = 48;
            // 
            // lblAllocate
            // 
            this.lblAllocate.AutoSize = true;
            this.lblAllocate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllocate.Location = new System.Drawing.Point(4, 20);
            this.lblAllocate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAllocate.Name = "lblAllocate";
            this.lblAllocate.Size = new System.Drawing.Size(52, 15);
            this.lblAllocate.TabIndex = 26;
            this.lblAllocate.TabStop = true;
            this.lblAllocate.Text = "Allocate";
            this.lblAllocate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAllocate_LinkClicked);
            // 
            // lblViewAllocate
            // 
            this.lblViewAllocate.AutoSize = true;
            this.lblViewAllocate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViewAllocate.Location = new System.Drawing.Point(91, 20);
            this.lblViewAllocate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblViewAllocate.Name = "lblViewAllocate";
            this.lblViewAllocate.Size = new System.Drawing.Size(33, 15);
            this.lblViewAllocate.TabIndex = 27;
            this.lblViewAllocate.TabStop = true;
            this.lblViewAllocate.Text = "View";
            this.lblViewAllocate.Visible = false;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(9, 285);
            this.lblFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(190, 19);
            this.lblFrom.TabIndex = 17;
            this.lblFrom.Text = "The product is coming from:";
            // 
            // lblChooseVendor
            // 
            this.lblChooseVendor.AutoSize = true;
            this.lblChooseVendor.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseVendor.Location = new System.Drawing.Point(649, 313);
            this.lblChooseVendor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChooseVendor.Name = "lblChooseVendor";
            this.lblChooseVendor.Size = new System.Drawing.Size(98, 15);
            this.lblChooseVendor.TabIndex = 22;
            this.lblChooseVendor.TabStop = true;
            this.lblChooseVendor.Text = "Choose a vendor";
            this.lblChooseVendor.Click += new System.EventHandler(this.lblChooseVendor_LinkClicked);
            // 
            // pVendor
            // 
            this.pVendor.Controls.Add(this.ctl_tracking_purchase);
            this.pVendor.Controls.Add(this.lblVendorCompany);
            this.pVendor.Controls.Add(this.lblVendorContact);
            this.pVendor.Location = new System.Drawing.Point(531, 332);
            this.pVendor.Margin = new System.Windows.Forms.Padding(4);
            this.pVendor.Name = "pVendor";
            this.pVendor.Size = new System.Drawing.Size(244, 145);
            this.pVendor.TabIndex = 26;
            this.pVendor.TabStop = true;
            // 
            // ctl_tracking_purchase
            // 
            this.ctl_tracking_purchase.BackColor = System.Drawing.Color.Transparent;
            this.ctl_tracking_purchase.Bold = false;
            this.ctl_tracking_purchase.Caption = "Vendor Tracking Numbers";
            this.ctl_tracking_purchase.Changed = false;
            this.ctl_tracking_purchase.DateLines = false;
            this.ctl_tracking_purchase.Location = new System.Drawing.Point(9, 54);
            this.ctl_tracking_purchase.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_tracking_purchase.Name = "ctl_tracking_purchase";
            this.ctl_tracking_purchase.Size = new System.Drawing.Size(228, 84);
            this.ctl_tracking_purchase.TabIndex = 1;
            this.ctl_tracking_purchase.TabStop = false;
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
            // lblVendorCompany
            // 
            this.lblVendorCompany.AutoSize = true;
            this.lblVendorCompany.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendorCompany.Location = new System.Drawing.Point(4, 4);
            this.lblVendorCompany.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVendorCompany.Name = "lblVendorCompany";
            this.lblVendorCompany.Size = new System.Drawing.Size(131, 19);
            this.lblVendorCompany.TabIndex = 39;
            this.lblVendorCompany.Text = "<vendor company>";
            // 
            // lblVendorContact
            // 
            this.lblVendorContact.AutoSize = true;
            this.lblVendorContact.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendorContact.Location = new System.Drawing.Point(4, 27);
            this.lblVendorContact.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVendorContact.Name = "lblVendorContact";
            this.lblVendorContact.Size = new System.Drawing.Size(121, 19);
            this.lblVendorContact.TabIndex = 40;
            this.lblVendorContact.Text = "<vendor contact>";
            // 
            // optConsign
            // 
            this.optConsign.AutoSize = true;
            this.optConsign.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optConsign.Location = new System.Drawing.Point(275, 303);
            this.optConsign.Margin = new System.Windows.Forms.Padding(4);
            this.optConsign.Name = "optConsign";
            this.optConsign.Size = new System.Drawing.Size(142, 30);
            this.optConsign.TabIndex = 19;
            this.optConsign.TabStop = true;
            this.optConsign.Text = "Consignment";
            this.optConsign.UseVisualStyleBackColor = true;
            this.optConsign.Click += new System.EventHandler(this.optConsign_Click);
            // 
            // ctl_ConsignmentCode
            // 
            this.ctl_ConsignmentCode.AllCaps = false;
            this.ctl_ConsignmentCode.AllowEdit = false;
            this.ctl_ConsignmentCode.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_ConsignmentCode.Bold = false;
            this.ctl_ConsignmentCode.Caption = "Consignment Code";
            this.ctl_ConsignmentCode.Changed = false;
            this.ctl_ConsignmentCode.Enabled = false;
            this.ctl_ConsignmentCode.ListName = null;
            this.ctl_ConsignmentCode.Location = new System.Drawing.Point(275, 339);
            this.ctl_ConsignmentCode.Name = "ctl_ConsignmentCode";
            this.ctl_ConsignmentCode.SimpleList = null;
            this.ctl_ConsignmentCode.Size = new System.Drawing.Size(236, 46);
            this.ctl_ConsignmentCode.TabIndex = 24;
            this.ctl_ConsignmentCode.TabStop = false;
            this.ctl_ConsignmentCode.UseParentBackColor = false;
            this.ctl_ConsignmentCode.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_ConsignmentCode.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_ConsignmentCode.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_ConsignmentCode.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_ConsignmentCode.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ConsignmentCode.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_ConsignmentCode.zz_OriginalDesign = true;
            this.ctl_ConsignmentCode.zz_ShowNeedsSaveColor = true;
            this.ctl_ConsignmentCode.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_ConsignmentCode.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ConsignmentCode.zz_UseGlobalColor = false;
            this.ctl_ConsignmentCode.zz_UseGlobalFont = false;
            // 
            // ctl_LotStock
            // 
            this.ctl_LotStock.AllCaps = false;
            this.ctl_LotStock.AllowEdit = false;
            this.ctl_LotStock.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_LotStock.Bold = false;
            this.ctl_LotStock.Caption = "Lot#";
            this.ctl_LotStock.Changed = false;
            this.ctl_LotStock.ListName = null;
            this.ctl_LotStock.Location = new System.Drawing.Point(15, 339);
            this.ctl_LotStock.Name = "ctl_LotStock";
            this.ctl_LotStock.SimpleList = null;
            this.ctl_LotStock.Size = new System.Drawing.Size(236, 46);
            this.ctl_LotStock.TabIndex = 23;
            this.ctl_LotStock.TabStop = false;
            this.ctl_LotStock.UseParentBackColor = false;
            this.ctl_LotStock.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_LotStock.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_LotStock.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_LotStock.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_LotStock.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_LotStock.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_LotStock.zz_OriginalDesign = true;
            this.ctl_LotStock.zz_ShowNeedsSaveColor = true;
            this.ctl_LotStock.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_LotStock.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_LotStock.zz_UseGlobalColor = false;
            this.ctl_LotStock.zz_UseGlobalFont = false;
            // 
            // optVendor
            // 
            this.optVendor.AutoSize = true;
            this.optVendor.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optVendor.Location = new System.Drawing.Point(498, 303);
            this.optVendor.Margin = new System.Windows.Forms.Padding(4);
            this.optVendor.Name = "optVendor";
            this.optVendor.Size = new System.Drawing.Size(91, 30);
            this.optVendor.TabIndex = 20;
            this.optVendor.TabStop = true;
            this.optVendor.Text = "Vendor";
            this.optVendor.UseVisualStyleBackColor = true;
            this.optVendor.Click += new System.EventHandler(this.optVendor_Click);
            // 
            // optStock
            // 
            this.optStock.AutoSize = true;
            this.optStock.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optStock.Location = new System.Drawing.Point(13, 303);
            this.optStock.Margin = new System.Windows.Forms.Padding(4);
            this.optStock.Name = "optStock";
            this.optStock.Size = new System.Drawing.Size(77, 30);
            this.optStock.TabIndex = 18;
            this.optStock.TabStop = true;
            this.optStock.Text = "Stock";
            this.optStock.UseVisualStyleBackColor = true;
            this.optStock.Click += new System.EventHandler(this.optStock_Click);
            // 
            // ctl_affiliate_id
            // 
            this.ctl_affiliate_id.AllCaps = false;
            this.ctl_affiliate_id.BackColor = System.Drawing.Color.Transparent;
            this.ctl_affiliate_id.Bold = false;
            this.ctl_affiliate_id.Caption = "Affiliate ID";
            this.ctl_affiliate_id.Changed = false;
            this.ctl_affiliate_id.IsEmail = false;
            this.ctl_affiliate_id.IsURL = false;
            this.ctl_affiliate_id.Location = new System.Drawing.Point(299, 240);
            this.ctl_affiliate_id.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_affiliate_id.Name = "ctl_affiliate_id";
            this.ctl_affiliate_id.PasswordChar = '\0';
            this.ctl_affiliate_id.Size = new System.Drawing.Size(190, 40);
            this.ctl_affiliate_id.TabIndex = 90;
            this.ctl_affiliate_id.UseParentBackColor = false;
            this.ctl_affiliate_id.zz_Enabled = true;
            this.ctl_affiliate_id.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_affiliate_id.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_affiliate_id.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_affiliate_id.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_affiliate_id.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_affiliate_id.zz_OriginalDesign = false;
            this.ctl_affiliate_id.zz_ShowLinkButton = false;
            this.ctl_affiliate_id.zz_ShowNeedsSaveColor = true;
            this.ctl_affiliate_id.zz_Text = "";
            this.ctl_affiliate_id.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_affiliate_id.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_affiliate_id.zz_TextFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_affiliate_id.zz_UseGlobalColor = false;
            this.ctl_affiliate_id.zz_UseGlobalFont = false;
            // 
            // ViewDetailSales
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Margin = new System.Windows.Forms.Padding(16, 11, 16, 11);
            this.Name = "ViewDetailSales";
            this.Size = new System.Drawing.Size(1523, 801);
            this.ts.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.tabInfo.PerformLayout();
            this.tabAttachments.ResumeLayout(false);
            this.gbAction1.ResumeLayout(false);
            this.gbAction1.PerformLayout();
            this.gbTop.ResumeLayout(false);
            this.gbTop.PerformLayout();
            this.tabDeductions.ResumeLayout(false);
            this.tabDates.ResumeLayout(false);
            this.pAllocation.ResumeLayout(false);
            this.pAllocation.PerformLayout();
            this.pVendor.ResumeLayout(false);
            this.pVendor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nEdit_Memo ctl_tracking_invoice;
        private NewMethod.nEdit_List ctl_shippingaccount_invoice;
        private NewMethod.nEdit_List ctl_shipvia_invoice;
        private NewMethod.nEdit_Memo ctl_notes_sales;
        private System.Windows.Forms.TabPage tabDeductions;
        private Win.Controls.LineProfit deductions;
        private System.Windows.Forms.TabPage tabDates;
        private NewMethod.nEdit_Date ctl_receive_date_actual;
        private NewMethod.nEdit_Date ctl_receive_date_due;
        private NewMethod.nEdit_Date ctl_ship_date_actual;
        private NewMethod.nEdit_Date ctl_ship_date_due;
        private NewMethod.nEdit_Date ctl_customer_dock_date;
        protected NewMethod.nEdit_String ctl_internal_customer;
        protected NewMethod.nEdit_Money ctl_unit_cost;
        protected NewMethod.nEdit_Money ctl_unit_price;
        private NewMethod.nEdit_Date ctl_orderdate_sales;
        protected System.Windows.Forms.Panel pAllocation;
        protected System.Windows.Forms.Label lblAllocated;
        protected System.Windows.Forms.LinkLabel lblAllocate;
        protected System.Windows.Forms.LinkLabel lblViewAllocate;
        protected System.Windows.Forms.Label lblFrom;
        protected System.Windows.Forms.LinkLabel lblChooseVendor;
        protected System.Windows.Forms.Panel pVendor;
        private NewMethod.nEdit_Memo ctl_tracking_purchase;
        protected System.Windows.Forms.Label lblVendorCompany;
        protected System.Windows.Forms.Label lblVendorContact;
        protected System.Windows.Forms.RadioButton optConsign;
        private NewMethod.nEdit_List ctl_LotStock;
        private NewMethod.nEdit_List ctl_ConsignmentCode;
        protected System.Windows.Forms.RadioButton optStock;
        protected System.Windows.Forms.RadioButton optVendor;
        private NewMethod.nEdit_Date ctl_projected_dock_date;
        protected NewMethod.nEdit_String ctl_affiliate_id;
    }
}
