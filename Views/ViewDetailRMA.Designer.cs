using Tools.Database;
namespace Rz5
{
    partial class ViewDetailRMA
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
            this.ctl_tracking_rma = new NewMethod.nEdit_Memo();
            this.ctl_shippingaccount_rma = new NewMethod.nEdit_List();
            this.ctl_shipvia_rma = new NewMethod.nEdit_List();
            this.ctl_charge2_fee_rma = new NewMethod.nEdit_Number();
            this.ctl_charge1_fee_rma = new NewMethod.nEdit_Number();
            this.ctl_shipping_fee_rma = new NewMethod.nEdit_Number();
            this.ctl_unit_price_rma = new NewMethod.nEdit_Number();
            this.ctl_notes_rma = new NewMethod.nEdit_Memo();
            this.tabPacking = new System.Windows.Forms.TabPage();
            this.lblUnpacked = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctl_receive_date_rma_actual = new NewMethod.nEdit_Date();
            this.ctl_receive_date_rma_due = new NewMethod.nEdit_Date();
            this.ctl_internal_customer = new NewMethod.nEdit_String();
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
            this.tabInfo.Controls.Add(this.ctl_internal_customer);
            this.tabInfo.Controls.Add(this.ctl_receive_date_rma_actual);
            this.tabInfo.Controls.Add(this.ctl_receive_date_rma_due);
            this.tabInfo.Controls.Add(this.lblUnpacked);
            this.tabInfo.Controls.Add(this.label1);
            this.tabInfo.Controls.Add(this.ctl_unit_price_rma);
            this.tabInfo.Controls.Add(this.ctl_tracking_rma);
            this.tabInfo.Controls.Add(this.ctl_shippingaccount_rma);
            this.tabInfo.Controls.Add(this.ctl_shipvia_rma);
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
            this.tabInfo.Controls.SetChildIndex(this.ctl_shipvia_rma, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_shippingaccount_rma, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_tracking_rma, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_unit_price_rma, 0);
            this.tabInfo.Controls.SetChildIndex(this.label1, 0);
            this.tabInfo.Controls.SetChildIndex(this.lblUnpacked, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_receive_date_rma_due, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_receive_date_rma_actual, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_internal_customer, 0);
            // 
            // tabAttachments
            // 
            this.tabAttachments.Margin = new System.Windows.Forms.Padding(4);
            this.tabAttachments.Padding = new System.Windows.Forms.Padding(4);
            this.tabAttachments.Size = new System.Drawing.Size(784, 545);
            // 
            // gbAction1
            // 
            this.gbAction1.Location = new System.Drawing.Point(803, 4);
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
            this.ctl_packaging.Location = new System.Drawing.Point(431, 58);
            this.ctl_packaging.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_packaging.TabIndex = 6;
            // 
            // picview
            // 
            this.picview.Location = new System.Drawing.Point(4, 4);
            this.picview.Margin = new System.Windows.Forms.Padding(4);
            this.picview.Size = new System.Drawing.Size(776, 537);
            // 
            // ctl_internalcomment
            // 
            this.ctl_internalcomment.Location = new System.Drawing.Point(8, 370);
            this.ctl_internalcomment.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_internalcomment.Size = new System.Drawing.Size(763, 166);
            this.ctl_internalcomment.TabIndex = 18;
            // 
            // ctl_description
            // 
            this.ctl_description.Location = new System.Drawing.Point(177, 113);
            this.ctl_description.TabIndex = 8;
            // 
            // ctl_alternatepart
            // 
            this.ctl_alternatepart.Location = new System.Drawing.Point(3, 179);
            this.ctl_alternatepart.TabIndex = 10;
            // 
            // ctl_rohs_info
            // 
            this.ctl_rohs_info.Location = new System.Drawing.Point(406, 174);
            this.ctl_rohs_info.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_rohs_info.TabIndex = 12;
            // 
            // ctl_condition
            // 
            this.ctl_condition.Location = new System.Drawing.Point(269, 58);
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
            this.xActions.Size = new System.Drawing.Size(148, 709);
            // 
            // ctl_tracking_rma
            // 
            this.ctl_tracking_rma.BackColor = System.Drawing.Color.Transparent;
            this.ctl_tracking_rma.Bold = false;
            this.ctl_tracking_rma.Caption = "Tracking Numbers";
            this.ctl_tracking_rma.Changed = false;
            this.ctl_tracking_rma.DateLines = false;
            this.ctl_tracking_rma.Location = new System.Drawing.Point(455, 250);
            this.ctl_tracking_rma.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_tracking_rma.Name = "ctl_tracking_rma";
            this.ctl_tracking_rma.Size = new System.Drawing.Size(319, 123);
            this.ctl_tracking_rma.TabIndex = 17;
            this.ctl_tracking_rma.UseParentBackColor = false;
            this.ctl_tracking_rma.zz_Enabled = true;
            this.ctl_tracking_rma.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_tracking_rma.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_tracking_rma.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_tracking_rma.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_tracking_rma.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_tracking_rma.zz_OriginalDesign = false;
            this.ctl_tracking_rma.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_tracking_rma.zz_ShowNeedsSaveColor = true;
            this.ctl_tracking_rma.zz_Text = "";
            this.ctl_tracking_rma.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_tracking_rma.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_tracking_rma.zz_UseGlobalColor = false;
            this.ctl_tracking_rma.zz_UseGlobalFont = false;
            // 
            // ctl_shippingaccount_rma
            // 
            this.ctl_shippingaccount_rma.AllCaps = false;
            this.ctl_shippingaccount_rma.AllowEdit = false;
            this.ctl_shippingaccount_rma.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shippingaccount_rma.Bold = false;
            this.ctl_shippingaccount_rma.Caption = "Shipping Account";
            this.ctl_shippingaccount_rma.Changed = false;
            this.ctl_shippingaccount_rma.ListName = "";
            this.ctl_shippingaccount_rma.Location = new System.Drawing.Point(236, 250);
            this.ctl_shippingaccount_rma.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_shippingaccount_rma.Name = "ctl_shippingaccount_rma";
            this.ctl_shippingaccount_rma.SimpleList = null;
            this.ctl_shippingaccount_rma.Size = new System.Drawing.Size(215, 44);
            this.ctl_shippingaccount_rma.TabIndex = 14;
            this.ctl_shippingaccount_rma.UseParentBackColor = false;
            this.ctl_shippingaccount_rma.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_shippingaccount_rma.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shippingaccount_rma.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shippingaccount_rma.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shippingaccount_rma.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shippingaccount_rma.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_shippingaccount_rma.zz_OriginalDesign = false;
            this.ctl_shippingaccount_rma.zz_ShowNeedsSaveColor = true;
            this.ctl_shippingaccount_rma.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shippingaccount_rma.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shippingaccount_rma.zz_UseGlobalColor = false;
            this.ctl_shippingaccount_rma.zz_UseGlobalFont = false;
            // 
            // ctl_shipvia_rma
            // 
            this.ctl_shipvia_rma.AllCaps = false;
            this.ctl_shipvia_rma.AllowEdit = false;
            this.ctl_shipvia_rma.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shipvia_rma.Bold = false;
            this.ctl_shipvia_rma.Caption = "Ship Via";
            this.ctl_shipvia_rma.Changed = false;
            this.ctl_shipvia_rma.ListName = "shipvia";
            this.ctl_shipvia_rma.Location = new System.Drawing.Point(4, 250);
            this.ctl_shipvia_rma.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_shipvia_rma.Name = "ctl_shipvia_rma";
            this.ctl_shipvia_rma.SimpleList = null;
            this.ctl_shipvia_rma.Size = new System.Drawing.Size(224, 44);
            this.ctl_shipvia_rma.TabIndex = 13;
            this.ctl_shipvia_rma.UseParentBackColor = false;
            this.ctl_shipvia_rma.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_shipvia_rma.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shipvia_rma.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shipvia_rma.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shipvia_rma.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shipvia_rma.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_shipvia_rma.zz_OriginalDesign = false;
            this.ctl_shipvia_rma.zz_ShowNeedsSaveColor = true;
            this.ctl_shipvia_rma.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shipvia_rma.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shipvia_rma.zz_UseGlobalColor = false;
            this.ctl_shipvia_rma.zz_UseGlobalFont = false;
            // 
            // ctl_charge2_fee_rma
            // 
            this.ctl_charge2_fee_rma.BackColor = System.Drawing.Color.Transparent;
            this.ctl_charge2_fee_rma.Bold = false;
            this.ctl_charge2_fee_rma.Caption = "Charge 2";
            this.ctl_charge2_fee_rma.Changed = false;
            this.ctl_charge2_fee_rma.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_charge2_fee_rma.Location = new System.Drawing.Point(8, 110);
            this.ctl_charge2_fee_rma.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_charge2_fee_rma.Name = "ctl_charge2_fee_rma";
            this.ctl_charge2_fee_rma.Size = new System.Drawing.Size(191, 44);
            this.ctl_charge2_fee_rma.TabIndex = 17;
            this.ctl_charge2_fee_rma.UseParentBackColor = true;
            this.ctl_charge2_fee_rma.zz_Enabled = true;
            this.ctl_charge2_fee_rma.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_charge2_fee_rma.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_charge2_fee_rma.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_charge2_fee_rma.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_charge2_fee_rma.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_charge2_fee_rma.zz_OriginalDesign = false;
            this.ctl_charge2_fee_rma.zz_ShowErrorColor = true;
            this.ctl_charge2_fee_rma.zz_ShowNeedsSaveColor = true;
            this.ctl_charge2_fee_rma.zz_Text = "";
            this.ctl_charge2_fee_rma.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_charge2_fee_rma.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_charge2_fee_rma.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_charge2_fee_rma.zz_UseGlobalColor = false;
            this.ctl_charge2_fee_rma.zz_UseGlobalFont = false;
            // 
            // ctl_charge1_fee_rma
            // 
            this.ctl_charge1_fee_rma.BackColor = System.Drawing.Color.Transparent;
            this.ctl_charge1_fee_rma.Bold = false;
            this.ctl_charge1_fee_rma.Caption = "Charge 1";
            this.ctl_charge1_fee_rma.Changed = false;
            this.ctl_charge1_fee_rma.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_charge1_fee_rma.Location = new System.Drawing.Point(8, 60);
            this.ctl_charge1_fee_rma.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_charge1_fee_rma.Name = "ctl_charge1_fee_rma";
            this.ctl_charge1_fee_rma.Size = new System.Drawing.Size(191, 44);
            this.ctl_charge1_fee_rma.TabIndex = 16;
            this.ctl_charge1_fee_rma.UseParentBackColor = true;
            this.ctl_charge1_fee_rma.zz_Enabled = true;
            this.ctl_charge1_fee_rma.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_charge1_fee_rma.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_charge1_fee_rma.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_charge1_fee_rma.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_charge1_fee_rma.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_charge1_fee_rma.zz_OriginalDesign = false;
            this.ctl_charge1_fee_rma.zz_ShowErrorColor = true;
            this.ctl_charge1_fee_rma.zz_ShowNeedsSaveColor = true;
            this.ctl_charge1_fee_rma.zz_Text = "";
            this.ctl_charge1_fee_rma.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_charge1_fee_rma.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_charge1_fee_rma.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_charge1_fee_rma.zz_UseGlobalColor = false;
            this.ctl_charge1_fee_rma.zz_UseGlobalFont = false;
            // 
            // ctl_shipping_fee_rma
            // 
            this.ctl_shipping_fee_rma.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shipping_fee_rma.Bold = false;
            this.ctl_shipping_fee_rma.Caption = "Shipping";
            this.ctl_shipping_fee_rma.Changed = false;
            this.ctl_shipping_fee_rma.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_shipping_fee_rma.Location = new System.Drawing.Point(8, 10);
            this.ctl_shipping_fee_rma.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_shipping_fee_rma.Name = "ctl_shipping_fee_rma";
            this.ctl_shipping_fee_rma.Size = new System.Drawing.Size(191, 44);
            this.ctl_shipping_fee_rma.TabIndex = 15;
            this.ctl_shipping_fee_rma.UseParentBackColor = true;
            this.ctl_shipping_fee_rma.zz_Enabled = true;
            this.ctl_shipping_fee_rma.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shipping_fee_rma.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shipping_fee_rma.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shipping_fee_rma.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shipping_fee_rma.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_shipping_fee_rma.zz_OriginalDesign = false;
            this.ctl_shipping_fee_rma.zz_ShowErrorColor = true;
            this.ctl_shipping_fee_rma.zz_ShowNeedsSaveColor = true;
            this.ctl_shipping_fee_rma.zz_Text = "";
            this.ctl_shipping_fee_rma.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_shipping_fee_rma.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shipping_fee_rma.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_shipping_fee_rma.zz_UseGlobalColor = false;
            this.ctl_shipping_fee_rma.zz_UseGlobalFont = false;
            // 
            // ctl_unit_price_rma
            // 
            this.ctl_unit_price_rma.BackColor = System.Drawing.Color.Transparent;
            this.ctl_unit_price_rma.Bold = false;
            this.ctl_unit_price_rma.Caption = "Price";
            this.ctl_unit_price_rma.Changed = false;
            this.ctl_unit_price_rma.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_unit_price_rma.Location = new System.Drawing.Point(672, 7);
            this.ctl_unit_price_rma.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_unit_price_rma.Name = "ctl_unit_price_rma";
            this.ctl_unit_price_rma.Size = new System.Drawing.Size(101, 44);
            this.ctl_unit_price_rma.TabIndex = 2;
            this.ctl_unit_price_rma.UseParentBackColor = true;
            this.ctl_unit_price_rma.zz_Enabled = true;
            this.ctl_unit_price_rma.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_unit_price_rma.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_unit_price_rma.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_unit_price_rma.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_unit_price_rma.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_unit_price_rma.zz_OriginalDesign = false;
            this.ctl_unit_price_rma.zz_ShowErrorColor = true;
            this.ctl_unit_price_rma.zz_ShowNeedsSaveColor = true;
            this.ctl_unit_price_rma.zz_Text = "";
            this.ctl_unit_price_rma.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_unit_price_rma.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_unit_price_rma.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_unit_price_rma.zz_UseGlobalColor = false;
            this.ctl_unit_price_rma.zz_UseGlobalFont = false;
            // 
            // ctl_notes_rma
            // 
            this.ctl_notes_rma.BackColor = System.Drawing.Color.Transparent;
            this.ctl_notes_rma.Bold = false;
            this.ctl_notes_rma.Caption = "Notes";
            this.ctl_notes_rma.Changed = false;
            this.ctl_notes_rma.DateLines = false;
            this.ctl_notes_rma.Location = new System.Drawing.Point(6, 50);
            this.ctl_notes_rma.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_notes_rma.Name = "ctl_notes_rma";
            this.ctl_notes_rma.Size = new System.Drawing.Size(572, 94);
            this.ctl_notes_rma.TabIndex = 52;
            this.ctl_notes_rma.UseParentBackColor = false;
            this.ctl_notes_rma.zz_Enabled = true;
            this.ctl_notes_rma.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_notes_rma.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_notes_rma.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_notes_rma.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_notes_rma.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_notes_rma.zz_OriginalDesign = false;
            this.ctl_notes_rma.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_notes_rma.zz_ShowNeedsSaveColor = true;
            this.ctl_notes_rma.zz_Text = "";
            this.ctl_notes_rma.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_notes_rma.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_notes_rma.zz_UseGlobalColor = false;
            this.ctl_notes_rma.zz_UseGlobalFont = false;
            // 
            // tabPacking
            // 
            this.tabPacking.Location = new System.Drawing.Point(4, 22);
            this.tabPacking.Margin = new System.Windows.Forms.Padding(4);
            this.tabPacking.Name = "tabPacking";
            this.tabPacking.Padding = new System.Windows.Forms.Padding(4);
            this.tabPacking.Size = new System.Drawing.Size(804, 294);
            this.tabPacking.TabIndex = 3;
            this.tabPacking.Text = "Receive";
            this.tabPacking.UseVisualStyleBackColor = true;
            // 
            // lblUnpacked
            // 
            this.lblUnpacked.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnpacked.Location = new System.Drawing.Point(528, 32);
            this.lblUnpacked.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUnpacked.Name = "lblUnpacked";
            this.lblUnpacked.Size = new System.Drawing.Size(136, 23);
            this.lblUnpacked.TabIndex = 59;
            this.lblUnpacked.Text = "1,000,000";
            this.lblUnpacked.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(529, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 18);
            this.label1.TabIndex = 58;
            this.label1.Text = "Received";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ctl_receive_date_rma_actual
            // 
            this.ctl_receive_date_rma_actual.AllowClear = false;
            this.ctl_receive_date_rma_actual.BackColor = System.Drawing.Color.Transparent;
            this.ctl_receive_date_rma_actual.Bold = false;
            this.ctl_receive_date_rma_actual.Caption = "RMA Actual Receive Date";
            this.ctl_receive_date_rma_actual.Changed = false;
            this.ctl_receive_date_rma_actual.Location = new System.Drawing.Point(236, 312);
            this.ctl_receive_date_rma_actual.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_receive_date_rma_actual.Name = "ctl_receive_date_rma_actual";
            this.ctl_receive_date_rma_actual.Size = new System.Drawing.Size(215, 50);
            this.ctl_receive_date_rma_actual.SuppressEdit = false;
            this.ctl_receive_date_rma_actual.TabIndex = 16;
            this.ctl_receive_date_rma_actual.UseParentBackColor = false;
            this.ctl_receive_date_rma_actual.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_receive_date_rma_actual.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_receive_date_rma_actual.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_receive_date_rma_actual.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_receive_date_rma_actual.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_receive_date_rma_actual.zz_OriginalDesign = false;
            this.ctl_receive_date_rma_actual.zz_ShowNeedsSaveColor = true;
            this.ctl_receive_date_rma_actual.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_receive_date_rma_actual.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_receive_date_rma_actual.zz_UseGlobalColor = false;
            this.ctl_receive_date_rma_actual.zz_UseGlobalFont = false;
            // 
            // ctl_receive_date_rma_due
            // 
            this.ctl_receive_date_rma_due.AllowClear = false;
            this.ctl_receive_date_rma_due.BackColor = System.Drawing.Color.Transparent;
            this.ctl_receive_date_rma_due.Bold = false;
            this.ctl_receive_date_rma_due.Caption = "RMA Receiving Due Date";
            this.ctl_receive_date_rma_due.Changed = false;
            this.ctl_receive_date_rma_due.Location = new System.Drawing.Point(4, 312);
            this.ctl_receive_date_rma_due.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_receive_date_rma_due.Name = "ctl_receive_date_rma_due";
            this.ctl_receive_date_rma_due.Size = new System.Drawing.Size(224, 50);
            this.ctl_receive_date_rma_due.SuppressEdit = false;
            this.ctl_receive_date_rma_due.TabIndex = 15;
            this.ctl_receive_date_rma_due.UseParentBackColor = false;
            this.ctl_receive_date_rma_due.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_receive_date_rma_due.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_receive_date_rma_due.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_receive_date_rma_due.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_receive_date_rma_due.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_receive_date_rma_due.zz_OriginalDesign = false;
            this.ctl_receive_date_rma_due.zz_ShowNeedsSaveColor = true;
            this.ctl_receive_date_rma_due.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_receive_date_rma_due.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_receive_date_rma_due.zz_UseGlobalColor = false;
            this.ctl_receive_date_rma_due.zz_UseGlobalFont = false;
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
            this.ctl_internal_customer.Location = new System.Drawing.Point(177, 179);
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
            this.deductions.TabIndex = 2;
            // 
            // ViewDetailRMA
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.Name = "ViewDetailRMA";
            this.Size = new System.Drawing.Size(1523, 709);
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

        private NewMethod.nEdit_Memo ctl_tracking_rma;
        private NewMethod.nEdit_List ctl_shippingaccount_rma;
        private NewMethod.nEdit_List ctl_shipvia_rma;
        public NewMethod.nEdit_Number ctl_charge2_fee_rma;
        public NewMethod.nEdit_Number ctl_charge1_fee_rma;
        public NewMethod.nEdit_Number ctl_shipping_fee_rma;
        public NewMethod.nEdit_Number ctl_unit_price_rma;
        private NewMethod.nEdit_Memo ctl_notes_rma;
        private System.Windows.Forms.TabPage tabPacking;
        private System.Windows.Forms.Label lblUnpacked;
        private System.Windows.Forms.Label label1;
        private NewMethod.nEdit_Date ctl_receive_date_rma_actual;
        private NewMethod.nEdit_Date ctl_receive_date_rma_due;
        protected NewMethod.nEdit_String ctl_internal_customer;
        private System.Windows.Forms.TabPage tabDeductions;
        private Win.Controls.LineProfit deductions;
    }
}
