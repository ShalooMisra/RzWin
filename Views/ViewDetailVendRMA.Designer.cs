using Tools.Database;
namespace Rz5
{
    partial class ViewDetailVendRMA
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
            this.ctl_tracking_vendrma = new NewMethod.nEdit_Memo();
            this.ctl_shippingaccount_vendrma = new NewMethod.nEdit_List();
            this.ctl_shipvia_vendrma = new NewMethod.nEdit_List();
            this.ctl_charge2_fee_vendrma = new NewMethod.nEdit_Number();
            this.ctl_charge1_fee_vendrma = new NewMethod.nEdit_Number();
            this.ctl_shipping_fee_vendrma = new NewMethod.nEdit_Number();
            this.ctl_unit_price_vendrma = new NewMethod.nEdit_Number();
            this.ctl_notes_vendrma = new NewMethod.nEdit_Memo();
            this.lblPacked = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPacking = new System.Windows.Forms.TabPage();
            this.ctl_ship_date_vendrma_actual = new NewMethod.nEdit_Date();
            this.ctl_ship_date_vendrma_due = new NewMethod.nEdit_Date();
            this.ctl_internal_vendor = new NewMethod.nEdit_String();
            this.tabDeductions = new System.Windows.Forms.TabPage();
            this.deductions = new Rz5.Win.Controls.LineProfit();
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
            this.ts.Size = new System.Drawing.Size(792, 571);
            this.ts.Controls.SetChildIndex(this.tabDeductions, 0);
            this.ts.Controls.SetChildIndex(this.tabPacking, 0);
            this.ts.Controls.SetChildIndex(this.tabAttachments, 0);
            this.ts.Controls.SetChildIndex(this.tabInfo, 0);
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.ctl_internal_vendor);
            this.tabInfo.Controls.Add(this.ctl_ship_date_vendrma_actual);
            this.tabInfo.Controls.Add(this.ctl_ship_date_vendrma_due);
            this.tabInfo.Controls.Add(this.lblPacked);
            this.tabInfo.Controls.Add(this.label1);
            this.tabInfo.Controls.Add(this.ctl_unit_price_vendrma);
            this.tabInfo.Controls.Add(this.ctl_tracking_vendrma);
            this.tabInfo.Controls.Add(this.ctl_shippingaccount_vendrma);
            this.tabInfo.Controls.Add(this.ctl_shipvia_vendrma);
            this.tabInfo.Margin = new System.Windows.Forms.Padding(4);
            this.tabInfo.Padding = new System.Windows.Forms.Padding(4);
            this.tabInfo.Size = new System.Drawing.Size(784, 545);
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
            this.tabInfo.Controls.SetChildIndex(this.ctl_shipvia_vendrma, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_shippingaccount_vendrma, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_tracking_vendrma, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_unit_price_vendrma, 0);
            this.tabInfo.Controls.SetChildIndex(this.label1, 0);
            this.tabInfo.Controls.SetChildIndex(this.lblPacked, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_ship_date_vendrma_due, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_ship_date_vendrma_actual, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_internal_vendor, 0);
            // 
            // tabAttachments
            // 
            this.tabAttachments.Margin = new System.Windows.Forms.Padding(4);
            this.tabAttachments.Padding = new System.Windows.Forms.Padding(4);
            this.tabAttachments.Size = new System.Drawing.Size(784, 545);
            // 
            // gbAction1
            // 
            this.gbAction1.Location = new System.Drawing.Point(799, 3);
            this.gbAction1.Size = new System.Drawing.Size(152, 143);
            // 
            // ctl_fullpartnumber
            // 
            this.ctl_fullpartnumber.zz_Enabled = true;
            // 
            // ctl_manufacturer
            // 
            this.ctl_manufacturer.Location = new System.Drawing.Point(3, 58);
            this.ctl_manufacturer.TabIndex = 3;
            this.ctl_manufacturer.Enabled = true;
            // 
            // ctl_datecode
            // 
            this.ctl_datecode.Location = new System.Drawing.Point(177, 58);
            this.ctl_datecode.TabIndex = 4;
            this.ctl_datecode.zz_Enabled = true;
            // 
            // ctl_category
            // 
            this.ctl_category.Location = new System.Drawing.Point(3, 113);
            this.ctl_category.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_category.TabIndex = 7;
            // 
            // ctl_packaging
            // 
            this.ctl_packaging.Location = new System.Drawing.Point(430, 58);
            this.ctl_packaging.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_packaging.TabIndex = 6;
            // 
            // picview
            // 
            this.picview.Location = new System.Drawing.Point(4, 4);
            this.picview.Size = new System.Drawing.Size(776, 537);
            // 
            // ctl_internalcomment
            // 
            this.ctl_internalcomment.Location = new System.Drawing.Point(9, 361);
            this.ctl_internalcomment.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_internalcomment.Size = new System.Drawing.Size(763, 116);
            this.ctl_internalcomment.TabIndex = 18;
            // 
            // ctl_description
            // 
            this.ctl_description.Location = new System.Drawing.Point(177, 113);
            this.ctl_description.Size = new System.Drawing.Size(414, 44);
            this.ctl_description.TabIndex = 8;
            // 
            // ctl_alternatepart
            // 
            this.ctl_alternatepart.Location = new System.Drawing.Point(3, 178);
            this.ctl_alternatepart.TabIndex = 10;
            // 
            // ctl_rohs_info
            // 
            this.ctl_rohs_info.Location = new System.Drawing.Point(415, 173);
            this.ctl_rohs_info.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_rohs_info.TabIndex = 12;
            // 
            // ctl_condition
            // 
            this.ctl_condition.Location = new System.Drawing.Point(268, 58);
            this.ctl_condition.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_condition.TabIndex = 5;
            // 
            // ctl_country_of_origin
            // 
            this.ctl_country_of_origin.TabIndex = 9;
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(1375, 0);
            this.xActions.Margin = new System.Windows.Forms.Padding(5);
            this.xActions.Size = new System.Drawing.Size(148, 700);
            // 
            // ctl_tracking_vendrma
            // 
            this.ctl_tracking_vendrma.BackColor = System.Drawing.Color.Transparent;
            this.ctl_tracking_vendrma.Bold = false;
            this.ctl_tracking_vendrma.Caption = "Tracking Numbers";
            this.ctl_tracking_vendrma.Changed = false;
            this.ctl_tracking_vendrma.DateLines = false;
            this.ctl_tracking_vendrma.Location = new System.Drawing.Point(455, 239);
            this.ctl_tracking_vendrma.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_tracking_vendrma.Name = "ctl_tracking_vendrma";
            this.ctl_tracking_vendrma.Size = new System.Drawing.Size(319, 116);
            this.ctl_tracking_vendrma.TabIndex = 17;
            this.ctl_tracking_vendrma.UseParentBackColor = false;
            this.ctl_tracking_vendrma.zz_Enabled = true;
            this.ctl_tracking_vendrma.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_tracking_vendrma.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_tracking_vendrma.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_tracking_vendrma.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_tracking_vendrma.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_tracking_vendrma.zz_OriginalDesign = false;
            this.ctl_tracking_vendrma.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_tracking_vendrma.zz_ShowNeedsSaveColor = true;
            this.ctl_tracking_vendrma.zz_Text = "";
            this.ctl_tracking_vendrma.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_tracking_vendrma.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_tracking_vendrma.zz_UseGlobalColor = false;
            this.ctl_tracking_vendrma.zz_UseGlobalFont = false;
            // 
            // ctl_shippingaccount_vendrma
            // 
            this.ctl_shippingaccount_vendrma.AllCaps = false;
            this.ctl_shippingaccount_vendrma.AllowEdit = false;
            this.ctl_shippingaccount_vendrma.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shippingaccount_vendrma.Bold = false;
            this.ctl_shippingaccount_vendrma.Caption = "Shipping Account";
            this.ctl_shippingaccount_vendrma.Changed = false;
            this.ctl_shippingaccount_vendrma.ListName = "";
            this.ctl_shippingaccount_vendrma.Location = new System.Drawing.Point(236, 239);
            this.ctl_shippingaccount_vendrma.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_shippingaccount_vendrma.Name = "ctl_shippingaccount_vendrma";
            this.ctl_shippingaccount_vendrma.SimpleList = null;
            this.ctl_shippingaccount_vendrma.Size = new System.Drawing.Size(215, 44);
            this.ctl_shippingaccount_vendrma.TabIndex = 14;
            this.ctl_shippingaccount_vendrma.UseParentBackColor = false;
            this.ctl_shippingaccount_vendrma.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_shippingaccount_vendrma.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shippingaccount_vendrma.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shippingaccount_vendrma.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shippingaccount_vendrma.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shippingaccount_vendrma.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_shippingaccount_vendrma.zz_OriginalDesign = false;
            this.ctl_shippingaccount_vendrma.zz_ShowNeedsSaveColor = true;
            this.ctl_shippingaccount_vendrma.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shippingaccount_vendrma.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shippingaccount_vendrma.zz_UseGlobalColor = false;
            this.ctl_shippingaccount_vendrma.zz_UseGlobalFont = false;
            // 
            // ctl_shipvia_vendrma
            // 
            this.ctl_shipvia_vendrma.AllCaps = false;
            this.ctl_shipvia_vendrma.AllowEdit = false;
            this.ctl_shipvia_vendrma.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shipvia_vendrma.Bold = false;
            this.ctl_shipvia_vendrma.Caption = "Ship Via";
            this.ctl_shipvia_vendrma.Changed = false;
            this.ctl_shipvia_vendrma.ListName = "shipvia";
            this.ctl_shipvia_vendrma.Location = new System.Drawing.Point(4, 239);
            this.ctl_shipvia_vendrma.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_shipvia_vendrma.Name = "ctl_shipvia_vendrma";
            this.ctl_shipvia_vendrma.SimpleList = null;
            this.ctl_shipvia_vendrma.Size = new System.Drawing.Size(224, 44);
            this.ctl_shipvia_vendrma.TabIndex = 13;
            this.ctl_shipvia_vendrma.UseParentBackColor = false;
            this.ctl_shipvia_vendrma.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_shipvia_vendrma.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shipvia_vendrma.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shipvia_vendrma.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shipvia_vendrma.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shipvia_vendrma.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_shipvia_vendrma.zz_OriginalDesign = false;
            this.ctl_shipvia_vendrma.zz_ShowNeedsSaveColor = true;
            this.ctl_shipvia_vendrma.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shipvia_vendrma.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shipvia_vendrma.zz_UseGlobalColor = false;
            this.ctl_shipvia_vendrma.zz_UseGlobalFont = false;
            // 
            // ctl_charge2_fee_vendrma
            // 
            this.ctl_charge2_fee_vendrma.BackColor = System.Drawing.Color.Transparent;
            this.ctl_charge2_fee_vendrma.Bold = false;
            this.ctl_charge2_fee_vendrma.Caption = "Charge 2";
            this.ctl_charge2_fee_vendrma.Changed = false;
            this.ctl_charge2_fee_vendrma.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_charge2_fee_vendrma.Location = new System.Drawing.Point(8, 110);
            this.ctl_charge2_fee_vendrma.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_charge2_fee_vendrma.Name = "ctl_charge2_fee_vendrma";
            this.ctl_charge2_fee_vendrma.Size = new System.Drawing.Size(191, 44);
            this.ctl_charge2_fee_vendrma.TabIndex = 14;
            this.ctl_charge2_fee_vendrma.UseParentBackColor = true;
            this.ctl_charge2_fee_vendrma.zz_Enabled = true;
            this.ctl_charge2_fee_vendrma.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_charge2_fee_vendrma.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_charge2_fee_vendrma.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_charge2_fee_vendrma.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_charge2_fee_vendrma.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_charge2_fee_vendrma.zz_OriginalDesign = false;
            this.ctl_charge2_fee_vendrma.zz_ShowErrorColor = true;
            this.ctl_charge2_fee_vendrma.zz_ShowNeedsSaveColor = true;
            this.ctl_charge2_fee_vendrma.zz_Text = "";
            this.ctl_charge2_fee_vendrma.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_charge2_fee_vendrma.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_charge2_fee_vendrma.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_charge2_fee_vendrma.zz_UseGlobalColor = false;
            this.ctl_charge2_fee_vendrma.zz_UseGlobalFont = false;
            // 
            // ctl_charge1_fee_vendrma
            // 
            this.ctl_charge1_fee_vendrma.BackColor = System.Drawing.Color.Transparent;
            this.ctl_charge1_fee_vendrma.Bold = false;
            this.ctl_charge1_fee_vendrma.Caption = "Charge 1";
            this.ctl_charge1_fee_vendrma.Changed = false;
            this.ctl_charge1_fee_vendrma.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_charge1_fee_vendrma.Location = new System.Drawing.Point(8, 60);
            this.ctl_charge1_fee_vendrma.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_charge1_fee_vendrma.Name = "ctl_charge1_fee_vendrma";
            this.ctl_charge1_fee_vendrma.Size = new System.Drawing.Size(191, 44);
            this.ctl_charge1_fee_vendrma.TabIndex = 13;
            this.ctl_charge1_fee_vendrma.UseParentBackColor = true;
            this.ctl_charge1_fee_vendrma.zz_Enabled = true;
            this.ctl_charge1_fee_vendrma.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_charge1_fee_vendrma.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_charge1_fee_vendrma.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_charge1_fee_vendrma.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_charge1_fee_vendrma.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_charge1_fee_vendrma.zz_OriginalDesign = false;
            this.ctl_charge1_fee_vendrma.zz_ShowErrorColor = true;
            this.ctl_charge1_fee_vendrma.zz_ShowNeedsSaveColor = true;
            this.ctl_charge1_fee_vendrma.zz_Text = "";
            this.ctl_charge1_fee_vendrma.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_charge1_fee_vendrma.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_charge1_fee_vendrma.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_charge1_fee_vendrma.zz_UseGlobalColor = false;
            this.ctl_charge1_fee_vendrma.zz_UseGlobalFont = false;
            // 
            // ctl_shipping_fee_vendrma
            // 
            this.ctl_shipping_fee_vendrma.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shipping_fee_vendrma.Bold = false;
            this.ctl_shipping_fee_vendrma.Caption = "Shipping";
            this.ctl_shipping_fee_vendrma.Changed = false;
            this.ctl_shipping_fee_vendrma.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_shipping_fee_vendrma.Location = new System.Drawing.Point(8, 10);
            this.ctl_shipping_fee_vendrma.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_shipping_fee_vendrma.Name = "ctl_shipping_fee_vendrma";
            this.ctl_shipping_fee_vendrma.Size = new System.Drawing.Size(191, 44);
            this.ctl_shipping_fee_vendrma.TabIndex = 12;
            this.ctl_shipping_fee_vendrma.UseParentBackColor = true;
            this.ctl_shipping_fee_vendrma.zz_Enabled = true;
            this.ctl_shipping_fee_vendrma.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shipping_fee_vendrma.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shipping_fee_vendrma.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shipping_fee_vendrma.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shipping_fee_vendrma.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_shipping_fee_vendrma.zz_OriginalDesign = false;
            this.ctl_shipping_fee_vendrma.zz_ShowErrorColor = true;
            this.ctl_shipping_fee_vendrma.zz_ShowNeedsSaveColor = true;
            this.ctl_shipping_fee_vendrma.zz_Text = "";
            this.ctl_shipping_fee_vendrma.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_shipping_fee_vendrma.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shipping_fee_vendrma.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shipping_fee_vendrma.zz_UseGlobalColor = false;
            this.ctl_shipping_fee_vendrma.zz_UseGlobalFont = false;
            // 
            // ctl_unit_price_vendrma
            // 
            this.ctl_unit_price_vendrma.BackColor = System.Drawing.Color.Transparent;
            this.ctl_unit_price_vendrma.Bold = false;
            this.ctl_unit_price_vendrma.Caption = "Price";
            this.ctl_unit_price_vendrma.Changed = false;
            this.ctl_unit_price_vendrma.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_unit_price_vendrma.Location = new System.Drawing.Point(663, 4);
            this.ctl_unit_price_vendrma.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_unit_price_vendrma.Name = "ctl_unit_price_vendrma";
            this.ctl_unit_price_vendrma.Size = new System.Drawing.Size(111, 44);
            this.ctl_unit_price_vendrma.TabIndex = 2;
            this.ctl_unit_price_vendrma.UseParentBackColor = true;
            this.ctl_unit_price_vendrma.zz_Enabled = true;
            this.ctl_unit_price_vendrma.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_unit_price_vendrma.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_unit_price_vendrma.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_unit_price_vendrma.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_unit_price_vendrma.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_unit_price_vendrma.zz_OriginalDesign = false;
            this.ctl_unit_price_vendrma.zz_ShowErrorColor = true;
            this.ctl_unit_price_vendrma.zz_ShowNeedsSaveColor = true;
            this.ctl_unit_price_vendrma.zz_Text = "";
            this.ctl_unit_price_vendrma.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_unit_price_vendrma.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_unit_price_vendrma.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_unit_price_vendrma.zz_UseGlobalColor = false;
            this.ctl_unit_price_vendrma.zz_UseGlobalFont = false;
            // 
            // ctl_notes_vendrma
            // 
            this.ctl_notes_vendrma.BackColor = System.Drawing.Color.Transparent;
            this.ctl_notes_vendrma.Bold = false;
            this.ctl_notes_vendrma.Caption = "Notes";
            this.ctl_notes_vendrma.Changed = false;
            this.ctl_notes_vendrma.DateLines = false;
            this.ctl_notes_vendrma.Location = new System.Drawing.Point(6, 51);
            this.ctl_notes_vendrma.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_notes_vendrma.Name = "ctl_notes_vendrma";
            this.ctl_notes_vendrma.Size = new System.Drawing.Size(572, 94);
            this.ctl_notes_vendrma.TabIndex = 52;
            this.ctl_notes_vendrma.UseParentBackColor = false;
            this.ctl_notes_vendrma.zz_Enabled = true;
            this.ctl_notes_vendrma.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_notes_vendrma.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_notes_vendrma.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_notes_vendrma.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_notes_vendrma.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_notes_vendrma.zz_OriginalDesign = false;
            this.ctl_notes_vendrma.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_notes_vendrma.zz_ShowNeedsSaveColor = true;
            this.ctl_notes_vendrma.zz_Text = "";
            this.ctl_notes_vendrma.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_notes_vendrma.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_notes_vendrma.zz_UseGlobalColor = false;
            this.ctl_notes_vendrma.zz_UseGlobalFont = false;
            // 
            // lblPacked
            // 
            this.lblPacked.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacked.Location = new System.Drawing.Point(527, 26);
            this.lblPacked.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPacked.Name = "lblPacked";
            this.lblPacked.Size = new System.Drawing.Size(129, 23);
            this.lblPacked.TabIndex = 62;
            this.lblPacked.Text = "1,000,000";
            this.lblPacked.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(543, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 61;
            this.label1.Text = "Packed";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            // ctl_ship_date_vendrma_actual
            // 
            this.ctl_ship_date_vendrma_actual.AllowClear = false;
            this.ctl_ship_date_vendrma_actual.BackColor = System.Drawing.Color.Transparent;
            this.ctl_ship_date_vendrma_actual.Bold = false;
            this.ctl_ship_date_vendrma_actual.Caption = "VRMA Actual Ship Date";
            this.ctl_ship_date_vendrma_actual.Changed = false;
            this.ctl_ship_date_vendrma_actual.Location = new System.Drawing.Point(236, 300);
            this.ctl_ship_date_vendrma_actual.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_ship_date_vendrma_actual.Name = "ctl_ship_date_vendrma_actual";
            this.ctl_ship_date_vendrma_actual.Size = new System.Drawing.Size(215, 50);
            this.ctl_ship_date_vendrma_actual.SuppressEdit = false;
            this.ctl_ship_date_vendrma_actual.TabIndex = 16;
            this.ctl_ship_date_vendrma_actual.UseParentBackColor = false;
            this.ctl_ship_date_vendrma_actual.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_ship_date_vendrma_actual.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_ship_date_vendrma_actual.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_ship_date_vendrma_actual.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ship_date_vendrma_actual.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_ship_date_vendrma_actual.zz_OriginalDesign = false;
            this.ctl_ship_date_vendrma_actual.zz_ShowNeedsSaveColor = true;
            this.ctl_ship_date_vendrma_actual.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_ship_date_vendrma_actual.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_ship_date_vendrma_actual.zz_UseGlobalColor = false;
            this.ctl_ship_date_vendrma_actual.zz_UseGlobalFont = false;
            // 
            // ctl_ship_date_vendrma_due
            // 
            this.ctl_ship_date_vendrma_due.AllowClear = false;
            this.ctl_ship_date_vendrma_due.BackColor = System.Drawing.Color.Transparent;
            this.ctl_ship_date_vendrma_due.Bold = false;
            this.ctl_ship_date_vendrma_due.Caption = "VRMA Ship Due Date";
            this.ctl_ship_date_vendrma_due.Changed = false;
            this.ctl_ship_date_vendrma_due.Location = new System.Drawing.Point(4, 300);
            this.ctl_ship_date_vendrma_due.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_ship_date_vendrma_due.Name = "ctl_ship_date_vendrma_due";
            this.ctl_ship_date_vendrma_due.Size = new System.Drawing.Size(224, 50);
            this.ctl_ship_date_vendrma_due.SuppressEdit = false;
            this.ctl_ship_date_vendrma_due.TabIndex = 15;
            this.ctl_ship_date_vendrma_due.UseParentBackColor = false;
            this.ctl_ship_date_vendrma_due.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_ship_date_vendrma_due.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_ship_date_vendrma_due.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_ship_date_vendrma_due.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ship_date_vendrma_due.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_ship_date_vendrma_due.zz_OriginalDesign = false;
            this.ctl_ship_date_vendrma_due.zz_ShowNeedsSaveColor = true;
            this.ctl_ship_date_vendrma_due.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_ship_date_vendrma_due.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_ship_date_vendrma_due.zz_UseGlobalColor = false;
            this.ctl_ship_date_vendrma_due.zz_UseGlobalFont = false;
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
            this.ctl_internal_vendor.Location = new System.Drawing.Point(177, 179);
            this.ctl_internal_vendor.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_internal_vendor.Name = "ctl_internal_vendor";
            this.ctl_internal_vendor.PasswordChar = '\0';
            this.ctl_internal_vendor.Size = new System.Drawing.Size(224, 40);
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
            // tabDeductions
            // 
            this.tabDeductions.Controls.Add(this.deductions);
            this.tabDeductions.Location = new System.Drawing.Point(4, 22);
            this.tabDeductions.Name = "tabDeductions";
            this.tabDeductions.Size = new System.Drawing.Size(804, 294);
            this.tabDeductions.TabIndex = 4;
            this.tabDeductions.Text = "Deductions";
            this.tabDeductions.UseVisualStyleBackColor = true;
            // 
            // deductions
            // 
            this.deductions.BackColor = System.Drawing.Color.White;
            this.deductions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deductions.Location = new System.Drawing.Point(0, 0);
            this.deductions.Margin = new System.Windows.Forms.Padding(5);
            this.deductions.Name = "deductions";
            this.deductions.Size = new System.Drawing.Size(804, 294);
            this.deductions.TabIndex = 1;
            // 
            // ViewDetailVendRMA
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.Name = "ViewDetailVendRMA";
            this.Size = new System.Drawing.Size(1523, 700);
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

        private NewMethod.nEdit_Memo ctl_tracking_vendrma;
        private NewMethod.nEdit_List ctl_shippingaccount_vendrma;
        private NewMethod.nEdit_List ctl_shipvia_vendrma;
        public NewMethod.nEdit_Number ctl_charge2_fee_vendrma;
        public NewMethod.nEdit_Number ctl_charge1_fee_vendrma;
        public NewMethod.nEdit_Number ctl_shipping_fee_vendrma;
        public NewMethod.nEdit_Number ctl_unit_price_vendrma;
        private NewMethod.nEdit_Memo ctl_notes_vendrma;
        private System.Windows.Forms.TabPage tabPacking;
        private System.Windows.Forms.Label lblPacked;
        private System.Windows.Forms.Label label1;
        private NewMethod.nEdit_Date ctl_ship_date_vendrma_actual;
        private NewMethod.nEdit_Date ctl_ship_date_vendrma_due;
        protected NewMethod.nEdit_String ctl_internal_vendor;
        private System.Windows.Forms.TabPage tabDeductions;
        private Win.Controls.LineProfit deductions;
    }
}
