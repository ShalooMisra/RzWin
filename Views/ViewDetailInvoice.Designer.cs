using Tools.Database;
namespace Rz5
{
    partial class ViewDetailInvoice
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
            this.ctl_shipvia_invoice = new NewMethod.nEdit_List();
            this.ctl_shippingaccount_invoice = new NewMethod.nEdit_List();
            this.ctl_shipping_fee_invoice = new NewMethod.nEdit_Number();
            this.ctl_charge1_fee_invoice = new NewMethod.nEdit_Number();
            this.ctl_charge2_fee_invoice = new NewMethod.nEdit_Number();
            this.ctl_tracking_invoice = new NewMethod.nEdit_Memo();
            this.ctl_ship_date_due = new NewMethod.nEdit_Date();
            this.ctl_ship_date_actual = new NewMethod.nEdit_Date();
            this.ctl_notes_sales = new NewMethod.nEdit_Memo();
            this.lblPacked = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctl_unit_price = new NewMethod.nEdit_Money();
            this.tabPacking = new System.Windows.Forms.TabPage();
            this.tabDeductions = new System.Windows.Forms.TabPage();
            this.deductions = new Rz5.Win.Controls.LineProfit();
            this.ctl_internal_customer = new NewMethod.nEdit_String();
            this.ts.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.tabAttachments.SuspendLayout();
            this.gbAction1.SuspendLayout();
            this.gbTop.SuspendLayout();
            this.tabDeductions.SuspendLayout();
            this.SuspendLayout();
            // 
            // ts
            // 
            this.ts.Controls.Add(this.tabPacking);
            this.ts.Controls.Add(this.tabDeductions);
            this.ts.Margin = new System.Windows.Forms.Padding(4);
            this.ts.Size = new System.Drawing.Size(792, 538);
            this.ts.Controls.SetChildIndex(this.tabDeductions, 0);
            this.ts.Controls.SetChildIndex(this.tabPacking, 0);
            this.ts.Controls.SetChildIndex(this.tabAttachments, 0);
            this.ts.Controls.SetChildIndex(this.tabInfo, 0);
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.ctl_internal_customer);
            this.tabInfo.Controls.Add(this.lblPacked);
            this.tabInfo.Controls.Add(this.label1);
            this.tabInfo.Controls.Add(this.ctl_unit_price);
            this.tabInfo.Controls.Add(this.ctl_ship_date_actual);
            this.tabInfo.Controls.Add(this.ctl_ship_date_due);
            this.tabInfo.Controls.Add(this.ctl_tracking_invoice);
            this.tabInfo.Controls.Add(this.ctl_shippingaccount_invoice);
            this.tabInfo.Controls.Add(this.ctl_shipvia_invoice);
            this.tabInfo.Margin = new System.Windows.Forms.Padding(4);
            this.tabInfo.Padding = new System.Windows.Forms.Padding(4);
            this.tabInfo.Size = new System.Drawing.Size(784, 512);
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
            this.tabInfo.Controls.SetChildIndex(this.ctl_shipvia_invoice, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_shippingaccount_invoice, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_tracking_invoice, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_ship_date_due, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_ship_date_actual, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_unit_price, 0);
            this.tabInfo.Controls.SetChildIndex(this.label1, 0);
            this.tabInfo.Controls.SetChildIndex(this.lblPacked, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_internal_customer, 0);
            // 
            // tabAttachments
            // 
            this.tabAttachments.Margin = new System.Windows.Forms.Padding(4);
            this.tabAttachments.Padding = new System.Windows.Forms.Padding(4);
            this.tabAttachments.Size = new System.Drawing.Size(784, 512);
            // 
            // gbAction1
            // 
            this.gbAction1.Location = new System.Drawing.Point(803, 3);
            this.gbAction1.Size = new System.Drawing.Size(152, 144);
            // 
            // ctl_fullpartnumber
            // 
            this.ctl_fullpartnumber.zz_Enabled = true;
            // 
            // ctl_manufacturer
            // 
            this.ctl_manufacturer.Location = new System.Drawing.Point(3, 59);
            this.ctl_manufacturer.TabIndex = 3;            
            // 
            // ctl_datecode
            // 
            this.ctl_datecode.Location = new System.Drawing.Point(177, 59);
            this.ctl_datecode.TabIndex = 4;
            this.ctl_datecode.zz_Enabled = true;
            // 
            // ctl_category
            // 
            this.ctl_category.Location = new System.Drawing.Point(3, 114);
            this.ctl_category.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_category.TabIndex = 7;
            // 
            // ctl_packaging
            // 
            this.ctl_packaging.Location = new System.Drawing.Point(419, 59);
            this.ctl_packaging.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_packaging.TabIndex = 6;
            // 
            // picview
            // 
            this.picview.Location = new System.Drawing.Point(4, 4);
            this.picview.Margin = new System.Windows.Forms.Padding(4);
            this.picview.Size = new System.Drawing.Size(776, 504);
            // 
            // ctl_internalcomment
            // 
            this.ctl_internalcomment.Location = new System.Drawing.Point(8, 367);
            this.ctl_internalcomment.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_internalcomment.Size = new System.Drawing.Size(763, 137);
            this.ctl_internalcomment.TabIndex = 18;
            // 
            // ctl_description
            // 
            this.ctl_description.Location = new System.Drawing.Point(177, 114);
            this.ctl_description.TabIndex = 8;
            this.ctl_description.Load += new System.EventHandler(this.ctl_description_Load);
            // 
            // ctl_alternatepart
            // 
            this.ctl_alternatepart.Location = new System.Drawing.Point(3, 173);
            this.ctl_alternatepart.TabIndex = 10;
            // 
            // ctl_rohs_info
            // 
            this.ctl_rohs_info.Location = new System.Drawing.Point(415, 168);
            this.ctl_rohs_info.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_rohs_info.TabIndex = 12;
            // 
            // ctl_condition
            // 
            this.ctl_condition.Location = new System.Drawing.Point(257, 59);
            this.ctl_condition.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_condition.TabIndex = 5;
            // 
            // ctl_country_of_origin
            // 
            this.ctl_country_of_origin.Location = new System.Drawing.Point(590, 114);
            this.ctl_country_of_origin.TabIndex = 9;
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(1300, 0);
            this.xActions.Margin = new System.Windows.Forms.Padding(5);
            this.xActions.Size = new System.Drawing.Size(148, 704);
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
            this.ctl_shipvia_invoice.Location = new System.Drawing.Point(4, 245);
            this.ctl_shipvia_invoice.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_shipvia_invoice.Name = "ctl_shipvia_invoice";
            this.ctl_shipvia_invoice.SimpleList = null;
            this.ctl_shipvia_invoice.Size = new System.Drawing.Size(224, 44);
            this.ctl_shipvia_invoice.TabIndex = 13;
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
            // ctl_shippingaccount_invoice
            // 
            this.ctl_shippingaccount_invoice.AllCaps = false;
            this.ctl_shippingaccount_invoice.AllowEdit = false;
            this.ctl_shippingaccount_invoice.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shippingaccount_invoice.Bold = false;
            this.ctl_shippingaccount_invoice.Caption = "Shipping Account";
            this.ctl_shippingaccount_invoice.Changed = false;
            this.ctl_shippingaccount_invoice.ListName = "";
            this.ctl_shippingaccount_invoice.Location = new System.Drawing.Point(236, 245);
            this.ctl_shippingaccount_invoice.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_shippingaccount_invoice.Name = "ctl_shippingaccount_invoice";
            this.ctl_shippingaccount_invoice.SimpleList = null;
            this.ctl_shippingaccount_invoice.Size = new System.Drawing.Size(215, 44);
            this.ctl_shippingaccount_invoice.TabIndex = 14;
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
            // ctl_shipping_fee_invoice
            // 
            this.ctl_shipping_fee_invoice.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shipping_fee_invoice.Bold = false;
            this.ctl_shipping_fee_invoice.Caption = "Shipping";
            this.ctl_shipping_fee_invoice.Changed = false;
            this.ctl_shipping_fee_invoice.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_shipping_fee_invoice.Location = new System.Drawing.Point(8, 7);
            this.ctl_shipping_fee_invoice.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_shipping_fee_invoice.Name = "ctl_shipping_fee_invoice";
            this.ctl_shipping_fee_invoice.Size = new System.Drawing.Size(191, 44);
            this.ctl_shipping_fee_invoice.TabIndex = 9;
            this.ctl_shipping_fee_invoice.UseParentBackColor = true;
            this.ctl_shipping_fee_invoice.zz_Enabled = true;
            this.ctl_shipping_fee_invoice.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shipping_fee_invoice.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shipping_fee_invoice.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shipping_fee_invoice.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shipping_fee_invoice.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_shipping_fee_invoice.zz_OriginalDesign = false;
            this.ctl_shipping_fee_invoice.zz_ShowErrorColor = true;
            this.ctl_shipping_fee_invoice.zz_ShowNeedsSaveColor = true;
            this.ctl_shipping_fee_invoice.zz_Text = "";
            this.ctl_shipping_fee_invoice.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_shipping_fee_invoice.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shipping_fee_invoice.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shipping_fee_invoice.zz_UseGlobalColor = false;
            this.ctl_shipping_fee_invoice.zz_UseGlobalFont = false;
            // 
            // ctl_charge1_fee_invoice
            // 
            this.ctl_charge1_fee_invoice.BackColor = System.Drawing.Color.Transparent;
            this.ctl_charge1_fee_invoice.Bold = false;
            this.ctl_charge1_fee_invoice.Caption = "Charge 1";
            this.ctl_charge1_fee_invoice.Changed = false;
            this.ctl_charge1_fee_invoice.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_charge1_fee_invoice.Location = new System.Drawing.Point(8, 57);
            this.ctl_charge1_fee_invoice.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_charge1_fee_invoice.Name = "ctl_charge1_fee_invoice";
            this.ctl_charge1_fee_invoice.Size = new System.Drawing.Size(191, 44);
            this.ctl_charge1_fee_invoice.TabIndex = 10;
            this.ctl_charge1_fee_invoice.UseParentBackColor = true;
            this.ctl_charge1_fee_invoice.zz_Enabled = true;
            this.ctl_charge1_fee_invoice.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_charge1_fee_invoice.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_charge1_fee_invoice.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_charge1_fee_invoice.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_charge1_fee_invoice.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_charge1_fee_invoice.zz_OriginalDesign = false;
            this.ctl_charge1_fee_invoice.zz_ShowErrorColor = true;
            this.ctl_charge1_fee_invoice.zz_ShowNeedsSaveColor = true;
            this.ctl_charge1_fee_invoice.zz_Text = "";
            this.ctl_charge1_fee_invoice.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_charge1_fee_invoice.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_charge1_fee_invoice.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_charge1_fee_invoice.zz_UseGlobalColor = false;
            this.ctl_charge1_fee_invoice.zz_UseGlobalFont = false;
            // 
            // ctl_charge2_fee_invoice
            // 
            this.ctl_charge2_fee_invoice.BackColor = System.Drawing.Color.Transparent;
            this.ctl_charge2_fee_invoice.Bold = false;
            this.ctl_charge2_fee_invoice.Caption = "Charge 2";
            this.ctl_charge2_fee_invoice.Changed = false;
            this.ctl_charge2_fee_invoice.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_charge2_fee_invoice.Location = new System.Drawing.Point(8, 107);
            this.ctl_charge2_fee_invoice.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_charge2_fee_invoice.Name = "ctl_charge2_fee_invoice";
            this.ctl_charge2_fee_invoice.Size = new System.Drawing.Size(191, 44);
            this.ctl_charge2_fee_invoice.TabIndex = 11;
            this.ctl_charge2_fee_invoice.UseParentBackColor = true;
            this.ctl_charge2_fee_invoice.zz_Enabled = true;
            this.ctl_charge2_fee_invoice.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_charge2_fee_invoice.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_charge2_fee_invoice.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_charge2_fee_invoice.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_charge2_fee_invoice.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_charge2_fee_invoice.zz_OriginalDesign = false;
            this.ctl_charge2_fee_invoice.zz_ShowErrorColor = true;
            this.ctl_charge2_fee_invoice.zz_ShowNeedsSaveColor = true;
            this.ctl_charge2_fee_invoice.zz_Text = "";
            this.ctl_charge2_fee_invoice.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_charge2_fee_invoice.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_charge2_fee_invoice.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_charge2_fee_invoice.zz_UseGlobalColor = false;
            this.ctl_charge2_fee_invoice.zz_UseGlobalFont = false;
            // 
            // ctl_tracking_invoice
            // 
            this.ctl_tracking_invoice.BackColor = System.Drawing.Color.Transparent;
            this.ctl_tracking_invoice.Bold = false;
            this.ctl_tracking_invoice.Caption = "Tracking Numbers";
            this.ctl_tracking_invoice.Changed = false;
            this.ctl_tracking_invoice.DateLines = false;
            this.ctl_tracking_invoice.Location = new System.Drawing.Point(455, 245);
            this.ctl_tracking_invoice.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_tracking_invoice.Name = "ctl_tracking_invoice";
            this.ctl_tracking_invoice.Size = new System.Drawing.Size(319, 122);
            this.ctl_tracking_invoice.TabIndex = 17;
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
            // ctl_ship_date_due
            // 
            this.ctl_ship_date_due.AllowClear = false;
            this.ctl_ship_date_due.BackColor = System.Drawing.Color.Transparent;
            this.ctl_ship_date_due.Bold = false;
            this.ctl_ship_date_due.Caption = "Shipping Due Date";
            this.ctl_ship_date_due.Changed = false;
            this.ctl_ship_date_due.Location = new System.Drawing.Point(4, 306);
            this.ctl_ship_date_due.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_ship_date_due.Name = "ctl_ship_date_due";
            this.ctl_ship_date_due.Size = new System.Drawing.Size(224, 50);
            this.ctl_ship_date_due.SuppressEdit = false;
            this.ctl_ship_date_due.TabIndex = 15;
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
            // ctl_ship_date_actual
            // 
            this.ctl_ship_date_actual.AllowClear = false;
            this.ctl_ship_date_actual.BackColor = System.Drawing.Color.Transparent;
            this.ctl_ship_date_actual.Bold = false;
            this.ctl_ship_date_actual.Caption = "Actual Ship Date";
            this.ctl_ship_date_actual.Changed = false;
            this.ctl_ship_date_actual.Location = new System.Drawing.Point(236, 306);
            this.ctl_ship_date_actual.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_ship_date_actual.Name = "ctl_ship_date_actual";
            this.ctl_ship_date_actual.Size = new System.Drawing.Size(215, 50);
            this.ctl_ship_date_actual.SuppressEdit = false;
            this.ctl_ship_date_actual.TabIndex = 16;
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
            // ctl_notes_sales
            // 
            this.ctl_notes_sales.BackColor = System.Drawing.Color.Transparent;
            this.ctl_notes_sales.Bold = false;
            this.ctl_notes_sales.Caption = "Notes";
            this.ctl_notes_sales.Changed = false;
            this.ctl_notes_sales.DateLines = false;
            this.ctl_notes_sales.Location = new System.Drawing.Point(6, 52);
            this.ctl_notes_sales.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_notes_sales.Name = "ctl_notes_sales";
            this.ctl_notes_sales.Size = new System.Drawing.Size(572, 81);
            this.ctl_notes_sales.TabIndex = 52;
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
            // lblPacked
            // 
            this.lblPacked.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacked.Location = new System.Drawing.Point(527, 25);
            this.lblPacked.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPacked.Name = "lblPacked";
            this.lblPacked.Size = new System.Drawing.Size(129, 23);
            this.lblPacked.TabIndex = 60;
            this.lblPacked.Text = "1,000,000";
            this.lblPacked.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(547, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 59;
            this.label1.Text = "Packed";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ctl_unit_price
            // 
            this.ctl_unit_price.BackColor = System.Drawing.Color.Transparent;
            this.ctl_unit_price.Bold = false;
            this.ctl_unit_price.Caption = "Unit Price";
            this.ctl_unit_price.Changed = false;
            this.ctl_unit_price.EditCaption = false;
            this.ctl_unit_price.FullDecimal = false;
            this.ctl_unit_price.Location = new System.Drawing.Point(664, 4);
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
            // tabPacking
            // 
            this.tabPacking.Location = new System.Drawing.Point(4, 22);
            this.tabPacking.Margin = new System.Windows.Forms.Padding(4);
            this.tabPacking.Name = "tabPacking";
            this.tabPacking.Padding = new System.Windows.Forms.Padding(4);
            this.tabPacking.Size = new System.Drawing.Size(804, 294);
            this.tabPacking.TabIndex = 3;
            this.tabPacking.Text = "Packing";
            this.tabPacking.UseVisualStyleBackColor = true;
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
            // ctl_internal_customer
            // 
            this.ctl_internal_customer.AllCaps = false;
            this.ctl_internal_customer.BackColor = System.Drawing.Color.Transparent;
            this.ctl_internal_customer.Bold = false;
            this.ctl_internal_customer.Caption = "Internal Part";
            this.ctl_internal_customer.Changed = false;
            this.ctl_internal_customer.IsEmail = false;
            this.ctl_internal_customer.IsURL = false;
            this.ctl_internal_customer.Location = new System.Drawing.Point(177, 173);
            this.ctl_internal_customer.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_internal_customer.Name = "ctl_internal_customer";
            this.ctl_internal_customer.PasswordChar = '\0';
            this.ctl_internal_customer.Size = new System.Drawing.Size(224, 40);
            this.ctl_internal_customer.TabIndex = 11;
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
            // ViewDetailInvoice
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.Name = "ViewDetailInvoice";
            this.Size = new System.Drawing.Size(1448, 704);
            this.ts.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.tabAttachments.ResumeLayout(false);
            this.gbAction1.ResumeLayout(false);
            this.gbAction1.PerformLayout();
            this.gbTop.ResumeLayout(false);
            this.gbTop.PerformLayout();
            this.tabDeductions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nEdit_List ctl_shipvia_invoice;
        private NewMethod.nEdit_List ctl_shippingaccount_invoice;
        public NewMethod.nEdit_Number ctl_shipping_fee_invoice;
        public NewMethod.nEdit_Number ctl_charge2_fee_invoice;
        public NewMethod.nEdit_Number ctl_charge1_fee_invoice;
        private NewMethod.nEdit_Date ctl_ship_date_due;
        private NewMethod.nEdit_Date ctl_ship_date_actual;
        private NewMethod.nEdit_Memo ctl_notes_sales;
        private System.Windows.Forms.Label lblPacked;
        private System.Windows.Forms.Label label1;
        private NewMethod.nEdit_Money ctl_unit_price;
        private System.Windows.Forms.TabPage tabDeductions;
        private Win.Controls.LineProfit deductions;
        public System.Windows.Forms.TabPage tabPacking;
        protected NewMethod.nEdit_String ctl_internal_customer;
        protected NewMethod.nEdit_Memo ctl_tracking_invoice;
    }
}
