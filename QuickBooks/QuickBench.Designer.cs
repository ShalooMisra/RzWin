using NewMethod;

namespace Rz5
{
    partial class QuickBench
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

                try
                {
                    ////nStatus.UnRegisterStatusView(this);
                }
                catch (System.Exception)
                { }

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
            System.Windows.Forms.ListViewItem listViewItem52 = new System.Windows.Forms.ListViewItem("PurchaseOrder");
            System.Windows.Forms.ListViewItem listViewItem53 = new System.Windows.Forms.ListViewItem("IncludeYear2Digits");
            System.Windows.Forms.ListViewItem listViewItem54 = new System.Windows.Forms.ListViewItem("IncludeYear4Digits");
            System.Windows.Forms.ListViewItem listViewItem55 = new System.Windows.Forms.ListViewItem("DropLeadingZeroes");
            System.Windows.Forms.ListViewItem listViewItem56 = new System.Windows.Forms.ListViewItem("UseReferenceNumber");
            System.Windows.Forms.ListViewItem listViewItem57 = new System.Windows.Forms.ListViewItem("UseRMA-Prefix");
            System.Windows.Forms.ListViewItem listViewItem58 = new System.Windows.Forms.ListViewItem("AutoCreateCustomer");
            System.Windows.Forms.ListViewItem listViewItem59 = new System.Windows.Forms.ListViewItem("IncludeYear2Digits");
            System.Windows.Forms.ListViewItem listViewItem60 = new System.Windows.Forms.ListViewItem("IncludeYear4Digits");
            System.Windows.Forms.ListViewItem listViewItem61 = new System.Windows.Forms.ListViewItem("DropLeadingZeroes");
            System.Windows.Forms.ListViewItem listViewItem62 = new System.Windows.Forms.ListViewItem("UseReferenceNumber");
            System.Windows.Forms.ListViewItem listViewItem63 = new System.Windows.Forms.ListViewItem("UseVendorRMA-Prefix");
            System.Windows.Forms.ListViewItem listViewItem64 = new System.Windows.Forms.ListViewItem("SetClassToInitials");
            System.Windows.Forms.ListViewItem listViewItem65 = new System.Windows.Forms.ListViewItem("SingleOverheadCharge");
            System.Windows.Forms.ListViewItem listViewItem66 = new System.Windows.Forms.ListViewItem("SimplyParts");
            System.Windows.Forms.ListViewItem listViewItem67 = new System.Windows.Forms.ListViewItem("Non-Inventory");
            System.Windows.Forms.ListViewItem listViewItem68 = new System.Windows.Forms.ListViewItem("InventoryOnly");
            this.gb = new System.Windows.Forms.GroupBox();
            this.ctlInvoiceTemplateName = new NewMethod.nEdit_String();
            this.lvPO = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.lvInvoice = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.lvGeneral = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblGeneral = new System.Windows.Forms.Label();
            this.ctlItemSuffix = new NewMethod.nEdit_String();
            this.ctlVendorSuffix = new NewMethod.nEdit_String();
            this.ctlHandlingItem = new NewMethod.nEdit_String();
            this.ctlIncomingShippingItem = new NewMethod.nEdit_String();
            this.ctlOutgoingShipping = new NewMethod.nEdit_String();
            this.ctlItemOption = new NewMethod.nEdit_List();
            this.ctl_deposit_number = new NewMethod.nEdit_String();
            this.ctl_deposit = new NewMethod.nEdit_String();
            this.ctl_version_name = new NewMethod.nEdit_String();
            this.ctl_cogs_number = new NewMethod.nEdit_String();
            this.ctl_asset_number = new NewMethod.nEdit_String();
            this.ctl_income_number = new NewMethod.nEdit_String();
            this.ctl_expense_number = new NewMethod.nEdit_String();
            this.numMinor = new System.Windows.Forms.NumericUpDown();
            this.lblMinor = new System.Windows.Forms.Label();
            this.numMajor = new System.Windows.Forms.NumericUpDown();
            this.lblMajor = new System.Windows.Forms.Label();
            this.cmdVersionInfo = new System.Windows.Forms.Button();
            this.cmdCreate = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.ctl_cogs = new NewMethod.nEdit_String();
            this.ctl_asset = new NewMethod.nEdit_String();
            this.ctl_income = new NewMethod.nEdit_String();
            this.ctl_expense = new NewMethod.nEdit_String();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.gbUnitTests = new System.Windows.Forms.GroupBox();
            this.llSalesReps = new System.Windows.Forms.LinkLabel();
            this.gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMajor)).BeginInit();
            this.gbUnitTests.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.BackColor = System.Drawing.Color.White;
            this.gb.Controls.Add(this.gbUnitTests);
            this.gb.Controls.Add(this.ctlInvoiceTemplateName);
            this.gb.Controls.Add(this.lvPO);
            this.gb.Controls.Add(this.label2);
            this.gb.Controls.Add(this.lvInvoice);
            this.gb.Controls.Add(this.label1);
            this.gb.Controls.Add(this.lvGeneral);
            this.gb.Controls.Add(this.lblGeneral);
            this.gb.Controls.Add(this.ctlItemSuffix);
            this.gb.Controls.Add(this.ctlVendorSuffix);
            this.gb.Controls.Add(this.ctlHandlingItem);
            this.gb.Controls.Add(this.ctlIncomingShippingItem);
            this.gb.Controls.Add(this.ctlOutgoingShipping);
            this.gb.Controls.Add(this.ctlItemOption);
            this.gb.Controls.Add(this.ctl_deposit_number);
            this.gb.Controls.Add(this.ctl_deposit);
            this.gb.Controls.Add(this.ctl_version_name);
            this.gb.Controls.Add(this.ctl_cogs_number);
            this.gb.Controls.Add(this.ctl_asset_number);
            this.gb.Controls.Add(this.ctl_income_number);
            this.gb.Controls.Add(this.ctl_expense_number);
            this.gb.Controls.Add(this.numMinor);
            this.gb.Controls.Add(this.lblMinor);
            this.gb.Controls.Add(this.numMajor);
            this.gb.Controls.Add(this.lblMajor);
            this.gb.Controls.Add(this.cmdVersionInfo);
            this.gb.Controls.Add(this.cmdCreate);
            this.gb.Controls.Add(this.cmdSave);
            this.gb.Controls.Add(this.ctl_cogs);
            this.gb.Controls.Add(this.ctl_asset);
            this.gb.Controls.Add(this.ctl_income);
            this.gb.Controls.Add(this.ctl_expense);
            this.gb.Controls.Add(this.cmdConnect);
            this.gb.Location = new System.Drawing.Point(8, 4);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(984, 504);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            // 
            // ctlInvoiceTemplateName
            // 
            this.ctlInvoiceTemplateName.AllCaps = false;
            this.ctlInvoiceTemplateName.BackColor = System.Drawing.Color.White;
            this.ctlInvoiceTemplateName.Bold = false;
            this.ctlInvoiceTemplateName.Caption = "Invoice Template Name";
            this.ctlInvoiceTemplateName.Changed = false;
            this.ctlInvoiceTemplateName.IsEmail = false;
            this.ctlInvoiceTemplateName.IsURL = false;
            this.ctlInvoiceTemplateName.Location = new System.Drawing.Point(699, 53);
            this.ctlInvoiceTemplateName.Name = "ctlInvoiceTemplateName";
            this.ctlInvoiceTemplateName.PasswordChar = '\0';
            this.ctlInvoiceTemplateName.Size = new System.Drawing.Size(177, 45);
            this.ctlInvoiceTemplateName.TabIndex = 34;
            this.ctlInvoiceTemplateName.UseParentBackColor = true;
            this.ctlInvoiceTemplateName.zz_Enabled = true;
            this.ctlInvoiceTemplateName.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlInvoiceTemplateName.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlInvoiceTemplateName.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlInvoiceTemplateName.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctlInvoiceTemplateName.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlInvoiceTemplateName.zz_OriginalDesign = true;
            this.ctlInvoiceTemplateName.zz_ShowLinkButton = false;
            this.ctlInvoiceTemplateName.zz_ShowNeedsSaveColor = true;
            this.ctlInvoiceTemplateName.zz_Text = "";
            this.ctlInvoiceTemplateName.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlInvoiceTemplateName.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlInvoiceTemplateName.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlInvoiceTemplateName.zz_UseGlobalColor = false;
            this.ctlInvoiceTemplateName.zz_UseGlobalFont = false;
            // 
            // lvPO
            // 
            this.lvPO.CheckBoxes = true;
            this.lvPO.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.lvPO.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listViewItem52.StateImageIndex = 0;
            listViewItem53.StateImageIndex = 0;
            listViewItem54.StateImageIndex = 0;
            listViewItem55.StateImageIndex = 0;
            listViewItem56.StateImageIndex = 0;
            listViewItem57.StateImageIndex = 0;
            listViewItem58.StateImageIndex = 0;
            this.lvPO.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem52,
            listViewItem53,
            listViewItem54,
            listViewItem55,
            listViewItem56,
            listViewItem57,
            listViewItem58});
            this.lvPO.Location = new System.Drawing.Point(374, 322);
            this.lvPO.Name = "lvPO";
            this.lvPO.Size = new System.Drawing.Size(177, 176);
            this.lvPO.TabIndex = 33;
            this.lvPO.UseCompatibleStateImageBehavior = false;
            this.lvPO.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 207;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "PO/RMA Options";
            // 
            // lvInvoice
            // 
            this.lvInvoice.CheckBoxes = true;
            this.lvInvoice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvInvoice.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listViewItem59.StateImageIndex = 0;
            listViewItem60.StateImageIndex = 0;
            listViewItem61.StateImageIndex = 0;
            listViewItem62.StateImageIndex = 0;
            listViewItem63.StateImageIndex = 0;
            this.lvInvoice.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem59,
            listViewItem60,
            listViewItem61,
            listViewItem62,
            listViewItem63});
            this.lvInvoice.Location = new System.Drawing.Point(191, 322);
            this.lvInvoice.Name = "lvInvoice";
            this.lvInvoice.Size = new System.Drawing.Size(177, 176);
            this.lvInvoice.TabIndex = 31;
            this.lvInvoice.UseCompatibleStateImageBehavior = false;
            this.lvInvoice.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 207;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Invoice/VRMA Options";
            // 
            // lvGeneral
            // 
            this.lvGeneral.CheckBoxes = true;
            this.lvGeneral.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvGeneral.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listViewItem64.StateImageIndex = 0;
            listViewItem65.StateImageIndex = 0;
            listViewItem66.StateImageIndex = 0;
            listViewItem67.StateImageIndex = 0;
            listViewItem68.StateImageIndex = 0;
            this.lvGeneral.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem64,
            listViewItem65,
            listViewItem66,
            listViewItem67,
            listViewItem68});
            this.lvGeneral.Location = new System.Drawing.Point(8, 322);
            this.lvGeneral.Name = "lvGeneral";
            this.lvGeneral.Size = new System.Drawing.Size(177, 176);
            this.lvGeneral.TabIndex = 29;
            this.lvGeneral.UseCompatibleStateImageBehavior = false;
            this.lvGeneral.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 207;
            // 
            // lblGeneral
            // 
            this.lblGeneral.AutoSize = true;
            this.lblGeneral.Location = new System.Drawing.Point(9, 306);
            this.lblGeneral.Name = "lblGeneral";
            this.lblGeneral.Size = new System.Drawing.Size(83, 13);
            this.lblGeneral.TabIndex = 28;
            this.lblGeneral.Text = "General Options";
            // 
            // ctlItemSuffix
            // 
            this.ctlItemSuffix.AllCaps = false;
            this.ctlItemSuffix.BackColor = System.Drawing.Color.White;
            this.ctlItemSuffix.Bold = false;
            this.ctlItemSuffix.Caption = "Item Suffix";
            this.ctlItemSuffix.Changed = false;
            this.ctlItemSuffix.IsEmail = false;
            this.ctlItemSuffix.IsURL = false;
            this.ctlItemSuffix.Location = new System.Drawing.Point(516, 53);
            this.ctlItemSuffix.Name = "ctlItemSuffix";
            this.ctlItemSuffix.PasswordChar = '\0';
            this.ctlItemSuffix.Size = new System.Drawing.Size(177, 45);
            this.ctlItemSuffix.TabIndex = 27;
            this.ctlItemSuffix.UseParentBackColor = true;
            this.ctlItemSuffix.zz_Enabled = true;
            this.ctlItemSuffix.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlItemSuffix.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlItemSuffix.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlItemSuffix.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctlItemSuffix.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlItemSuffix.zz_OriginalDesign = true;
            this.ctlItemSuffix.zz_ShowLinkButton = false;
            this.ctlItemSuffix.zz_ShowNeedsSaveColor = true;
            this.ctlItemSuffix.zz_Text = "";
            this.ctlItemSuffix.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlItemSuffix.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlItemSuffix.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlItemSuffix.zz_UseGlobalColor = false;
            this.ctlItemSuffix.zz_UseGlobalFont = false;
            // 
            // ctlVendorSuffix
            // 
            this.ctlVendorSuffix.AllCaps = false;
            this.ctlVendorSuffix.BackColor = System.Drawing.Color.White;
            this.ctlVendorSuffix.Bold = false;
            this.ctlVendorSuffix.Caption = "Vendor Suffix";
            this.ctlVendorSuffix.Changed = false;
            this.ctlVendorSuffix.IsEmail = false;
            this.ctlVendorSuffix.IsURL = false;
            this.ctlVendorSuffix.Location = new System.Drawing.Point(334, 257);
            this.ctlVendorSuffix.Name = "ctlVendorSuffix";
            this.ctlVendorSuffix.PasswordChar = '\0';
            this.ctlVendorSuffix.Size = new System.Drawing.Size(177, 45);
            this.ctlVendorSuffix.TabIndex = 26;
            this.ctlVendorSuffix.UseParentBackColor = true;
            this.ctlVendorSuffix.zz_Enabled = true;
            this.ctlVendorSuffix.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlVendorSuffix.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlVendorSuffix.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlVendorSuffix.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctlVendorSuffix.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlVendorSuffix.zz_OriginalDesign = true;
            this.ctlVendorSuffix.zz_ShowLinkButton = false;
            this.ctlVendorSuffix.zz_ShowNeedsSaveColor = true;
            this.ctlVendorSuffix.zz_Text = "";
            this.ctlVendorSuffix.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlVendorSuffix.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlVendorSuffix.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlVendorSuffix.zz_UseGlobalColor = false;
            this.ctlVendorSuffix.zz_UseGlobalFont = false;
            // 
            // ctlHandlingItem
            // 
            this.ctlHandlingItem.AllCaps = false;
            this.ctlHandlingItem.BackColor = System.Drawing.Color.White;
            this.ctlHandlingItem.Bold = false;
            this.ctlHandlingItem.Caption = "Handling Item";
            this.ctlHandlingItem.Changed = false;
            this.ctlHandlingItem.IsEmail = false;
            this.ctlHandlingItem.IsURL = false;
            this.ctlHandlingItem.Location = new System.Drawing.Point(334, 206);
            this.ctlHandlingItem.Name = "ctlHandlingItem";
            this.ctlHandlingItem.PasswordChar = '\0';
            this.ctlHandlingItem.Size = new System.Drawing.Size(177, 45);
            this.ctlHandlingItem.TabIndex = 25;
            this.ctlHandlingItem.UseParentBackColor = true;
            this.ctlHandlingItem.zz_Enabled = true;
            this.ctlHandlingItem.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlHandlingItem.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlHandlingItem.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlHandlingItem.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctlHandlingItem.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlHandlingItem.zz_OriginalDesign = true;
            this.ctlHandlingItem.zz_ShowLinkButton = false;
            this.ctlHandlingItem.zz_ShowNeedsSaveColor = true;
            this.ctlHandlingItem.zz_Text = "";
            this.ctlHandlingItem.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlHandlingItem.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlHandlingItem.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlHandlingItem.zz_UseGlobalColor = false;
            this.ctlHandlingItem.zz_UseGlobalFont = false;
            // 
            // ctlIncomingShippingItem
            // 
            this.ctlIncomingShippingItem.AllCaps = false;
            this.ctlIncomingShippingItem.BackColor = System.Drawing.Color.White;
            this.ctlIncomingShippingItem.Bold = false;
            this.ctlIncomingShippingItem.Caption = "Incoming Shipping Item";
            this.ctlIncomingShippingItem.Changed = false;
            this.ctlIncomingShippingItem.IsEmail = false;
            this.ctlIncomingShippingItem.IsURL = false;
            this.ctlIncomingShippingItem.Location = new System.Drawing.Point(334, 155);
            this.ctlIncomingShippingItem.Name = "ctlIncomingShippingItem";
            this.ctlIncomingShippingItem.PasswordChar = '\0';
            this.ctlIncomingShippingItem.Size = new System.Drawing.Size(177, 45);
            this.ctlIncomingShippingItem.TabIndex = 24;
            this.ctlIncomingShippingItem.UseParentBackColor = true;
            this.ctlIncomingShippingItem.zz_Enabled = true;
            this.ctlIncomingShippingItem.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlIncomingShippingItem.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlIncomingShippingItem.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlIncomingShippingItem.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctlIncomingShippingItem.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlIncomingShippingItem.zz_OriginalDesign = true;
            this.ctlIncomingShippingItem.zz_ShowLinkButton = false;
            this.ctlIncomingShippingItem.zz_ShowNeedsSaveColor = true;
            this.ctlIncomingShippingItem.zz_Text = "";
            this.ctlIncomingShippingItem.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlIncomingShippingItem.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlIncomingShippingItem.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlIncomingShippingItem.zz_UseGlobalColor = false;
            this.ctlIncomingShippingItem.zz_UseGlobalFont = false;
            // 
            // ctlOutgoingShipping
            // 
            this.ctlOutgoingShipping.AllCaps = false;
            this.ctlOutgoingShipping.BackColor = System.Drawing.Color.White;
            this.ctlOutgoingShipping.Bold = false;
            this.ctlOutgoingShipping.Caption = "Outgoing Shipping Item";
            this.ctlOutgoingShipping.Changed = false;
            this.ctlOutgoingShipping.IsEmail = false;
            this.ctlOutgoingShipping.IsURL = false;
            this.ctlOutgoingShipping.Location = new System.Drawing.Point(334, 104);
            this.ctlOutgoingShipping.Name = "ctlOutgoingShipping";
            this.ctlOutgoingShipping.PasswordChar = '\0';
            this.ctlOutgoingShipping.Size = new System.Drawing.Size(177, 45);
            this.ctlOutgoingShipping.TabIndex = 23;
            this.ctlOutgoingShipping.UseParentBackColor = true;
            this.ctlOutgoingShipping.zz_Enabled = true;
            this.ctlOutgoingShipping.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlOutgoingShipping.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlOutgoingShipping.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlOutgoingShipping.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctlOutgoingShipping.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlOutgoingShipping.zz_OriginalDesign = true;
            this.ctlOutgoingShipping.zz_ShowLinkButton = false;
            this.ctlOutgoingShipping.zz_ShowNeedsSaveColor = true;
            this.ctlOutgoingShipping.zz_Text = "";
            this.ctlOutgoingShipping.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlOutgoingShipping.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlOutgoingShipping.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlOutgoingShipping.zz_UseGlobalColor = false;
            this.ctlOutgoingShipping.zz_UseGlobalFont = false;
            // 
            // ctlItemOption
            // 
            this.ctlItemOption.AllCaps = false;
            this.ctlItemOption.AllowEdit = false;
            this.ctlItemOption.BackColor = System.Drawing.Color.White;
            this.ctlItemOption.Bold = false;
            this.ctlItemOption.Caption = "Item Option";
            this.ctlItemOption.Changed = false;
            this.ctlItemOption.ListName = null;
            this.ctlItemOption.Location = new System.Drawing.Point(334, 53);
            this.ctlItemOption.Name = "ctlItemOption";
            this.ctlItemOption.SimpleList = "Inventory|Non-Inventory|Simply Parts";
            this.ctlItemOption.Size = new System.Drawing.Size(176, 45);
            this.ctlItemOption.TabIndex = 21;
            this.ctlItemOption.UseParentBackColor = true;
            this.ctlItemOption.Visible = false;
            this.ctlItemOption.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctlItemOption.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlItemOption.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlItemOption.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlItemOption.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlItemOption.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctlItemOption.zz_OriginalDesign = true;
            this.ctlItemOption.zz_ShowNeedsSaveColor = true;
            this.ctlItemOption.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlItemOption.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlItemOption.zz_UseGlobalColor = false;
            this.ctlItemOption.zz_UseGlobalFont = false;
            // 
            // ctl_deposit_number
            // 
            this.ctl_deposit_number.AllCaps = false;
            this.ctl_deposit_number.BackColor = System.Drawing.Color.White;
            this.ctl_deposit_number.Bold = false;
            this.ctl_deposit_number.Caption = "Deposit Account Number";
            this.ctl_deposit_number.Changed = false;
            this.ctl_deposit_number.IsEmail = false;
            this.ctl_deposit_number.IsURL = false;
            this.ctl_deposit_number.Location = new System.Drawing.Point(191, 257);
            this.ctl_deposit_number.Name = "ctl_deposit_number";
            this.ctl_deposit_number.PasswordChar = '\0';
            this.ctl_deposit_number.Size = new System.Drawing.Size(137, 45);
            this.ctl_deposit_number.TabIndex = 20;
            this.ctl_deposit_number.UseParentBackColor = true;
            this.ctl_deposit_number.zz_Enabled = true;
            this.ctl_deposit_number.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_deposit_number.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_deposit_number.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_deposit_number.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_deposit_number.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_deposit_number.zz_OriginalDesign = true;
            this.ctl_deposit_number.zz_ShowLinkButton = false;
            this.ctl_deposit_number.zz_ShowNeedsSaveColor = true;
            this.ctl_deposit_number.zz_Text = "";
            this.ctl_deposit_number.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_deposit_number.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_deposit_number.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_deposit_number.zz_UseGlobalColor = false;
            this.ctl_deposit_number.zz_UseGlobalFont = false;
            // 
            // ctl_deposit
            // 
            this.ctl_deposit.AllCaps = false;
            this.ctl_deposit.BackColor = System.Drawing.Color.White;
            this.ctl_deposit.Bold = false;
            this.ctl_deposit.Caption = "Deposit Account";
            this.ctl_deposit.Changed = false;
            this.ctl_deposit.IsEmail = false;
            this.ctl_deposit.IsURL = false;
            this.ctl_deposit.Location = new System.Drawing.Point(8, 257);
            this.ctl_deposit.Name = "ctl_deposit";
            this.ctl_deposit.PasswordChar = '\0';
            this.ctl_deposit.Size = new System.Drawing.Size(177, 45);
            this.ctl_deposit.TabIndex = 19;
            this.ctl_deposit.UseParentBackColor = true;
            this.ctl_deposit.zz_Enabled = true;
            this.ctl_deposit.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_deposit.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_deposit.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_deposit.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_deposit.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_deposit.zz_OriginalDesign = true;
            this.ctl_deposit.zz_ShowLinkButton = false;
            this.ctl_deposit.zz_ShowNeedsSaveColor = true;
            this.ctl_deposit.zz_Text = "";
            this.ctl_deposit.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_deposit.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_deposit.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_deposit.zz_UseGlobalColor = false;
            this.ctl_deposit.zz_UseGlobalFont = false;
            // 
            // ctl_version_name
            // 
            this.ctl_version_name.AllCaps = false;
            this.ctl_version_name.BackColor = System.Drawing.Color.White;
            this.ctl_version_name.Bold = false;
            this.ctl_version_name.Caption = "Version Name";
            this.ctl_version_name.Changed = false;
            this.ctl_version_name.IsEmail = false;
            this.ctl_version_name.IsURL = false;
            this.ctl_version_name.Location = new System.Drawing.Point(516, 104);
            this.ctl_version_name.Name = "ctl_version_name";
            this.ctl_version_name.PasswordChar = '\0';
            this.ctl_version_name.Size = new System.Drawing.Size(177, 45);
            this.ctl_version_name.TabIndex = 17;
            this.ctl_version_name.UseParentBackColor = true;
            this.ctl_version_name.zz_Enabled = true;
            this.ctl_version_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_version_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_version_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_version_name.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_version_name.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_version_name.zz_OriginalDesign = true;
            this.ctl_version_name.zz_ShowLinkButton = false;
            this.ctl_version_name.zz_ShowNeedsSaveColor = true;
            this.ctl_version_name.zz_Text = "";
            this.ctl_version_name.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_version_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_version_name.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_version_name.zz_UseGlobalColor = false;
            this.ctl_version_name.zz_UseGlobalFont = false;
            // 
            // ctl_cogs_number
            // 
            this.ctl_cogs_number.AllCaps = false;
            this.ctl_cogs_number.BackColor = System.Drawing.Color.White;
            this.ctl_cogs_number.Bold = false;
            this.ctl_cogs_number.Caption = "COGS Account Number";
            this.ctl_cogs_number.Changed = false;
            this.ctl_cogs_number.IsEmail = false;
            this.ctl_cogs_number.IsURL = false;
            this.ctl_cogs_number.Location = new System.Drawing.Point(191, 206);
            this.ctl_cogs_number.Name = "ctl_cogs_number";
            this.ctl_cogs_number.PasswordChar = '\0';
            this.ctl_cogs_number.Size = new System.Drawing.Size(137, 45);
            this.ctl_cogs_number.TabIndex = 16;
            this.ctl_cogs_number.UseParentBackColor = true;
            this.ctl_cogs_number.zz_Enabled = true;
            this.ctl_cogs_number.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_cogs_number.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_cogs_number.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_cogs_number.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_cogs_number.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_cogs_number.zz_OriginalDesign = true;
            this.ctl_cogs_number.zz_ShowLinkButton = false;
            this.ctl_cogs_number.zz_ShowNeedsSaveColor = true;
            this.ctl_cogs_number.zz_Text = "";
            this.ctl_cogs_number.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_cogs_number.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_cogs_number.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_cogs_number.zz_UseGlobalColor = false;
            this.ctl_cogs_number.zz_UseGlobalFont = false;
            // 
            // ctl_asset_number
            // 
            this.ctl_asset_number.AllCaps = false;
            this.ctl_asset_number.BackColor = System.Drawing.Color.White;
            this.ctl_asset_number.Bold = false;
            this.ctl_asset_number.Caption = "Asset Account Number";
            this.ctl_asset_number.Changed = false;
            this.ctl_asset_number.IsEmail = false;
            this.ctl_asset_number.IsURL = false;
            this.ctl_asset_number.Location = new System.Drawing.Point(191, 155);
            this.ctl_asset_number.Name = "ctl_asset_number";
            this.ctl_asset_number.PasswordChar = '\0';
            this.ctl_asset_number.Size = new System.Drawing.Size(137, 45);
            this.ctl_asset_number.TabIndex = 15;
            this.ctl_asset_number.UseParentBackColor = true;
            this.ctl_asset_number.zz_Enabled = true;
            this.ctl_asset_number.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_asset_number.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_asset_number.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_asset_number.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_asset_number.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_asset_number.zz_OriginalDesign = true;
            this.ctl_asset_number.zz_ShowLinkButton = false;
            this.ctl_asset_number.zz_ShowNeedsSaveColor = true;
            this.ctl_asset_number.zz_Text = "";
            this.ctl_asset_number.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_asset_number.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_asset_number.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_asset_number.zz_UseGlobalColor = false;
            this.ctl_asset_number.zz_UseGlobalFont = false;
            // 
            // ctl_income_number
            // 
            this.ctl_income_number.AllCaps = false;
            this.ctl_income_number.BackColor = System.Drawing.Color.White;
            this.ctl_income_number.Bold = false;
            this.ctl_income_number.Caption = "Income Account Number";
            this.ctl_income_number.Changed = false;
            this.ctl_income_number.IsEmail = false;
            this.ctl_income_number.IsURL = false;
            this.ctl_income_number.Location = new System.Drawing.Point(191, 104);
            this.ctl_income_number.Name = "ctl_income_number";
            this.ctl_income_number.PasswordChar = '\0';
            this.ctl_income_number.Size = new System.Drawing.Size(137, 45);
            this.ctl_income_number.TabIndex = 14;
            this.ctl_income_number.UseParentBackColor = true;
            this.ctl_income_number.zz_Enabled = true;
            this.ctl_income_number.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_income_number.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_income_number.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_income_number.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_income_number.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_income_number.zz_OriginalDesign = true;
            this.ctl_income_number.zz_ShowLinkButton = false;
            this.ctl_income_number.zz_ShowNeedsSaveColor = true;
            this.ctl_income_number.zz_Text = "";
            this.ctl_income_number.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_income_number.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_income_number.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_income_number.zz_UseGlobalColor = false;
            this.ctl_income_number.zz_UseGlobalFont = false;
            // 
            // ctl_expense_number
            // 
            this.ctl_expense_number.AllCaps = false;
            this.ctl_expense_number.BackColor = System.Drawing.Color.White;
            this.ctl_expense_number.Bold = false;
            this.ctl_expense_number.Caption = "Expense Account Number";
            this.ctl_expense_number.Changed = false;
            this.ctl_expense_number.IsEmail = false;
            this.ctl_expense_number.IsURL = false;
            this.ctl_expense_number.Location = new System.Drawing.Point(191, 53);
            this.ctl_expense_number.Name = "ctl_expense_number";
            this.ctl_expense_number.PasswordChar = '\0';
            this.ctl_expense_number.Size = new System.Drawing.Size(137, 45);
            this.ctl_expense_number.TabIndex = 13;
            this.ctl_expense_number.UseParentBackColor = true;
            this.ctl_expense_number.zz_Enabled = true;
            this.ctl_expense_number.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_expense_number.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_expense_number.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_expense_number.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_expense_number.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_expense_number.zz_OriginalDesign = true;
            this.ctl_expense_number.zz_ShowLinkButton = false;
            this.ctl_expense_number.zz_ShowNeedsSaveColor = true;
            this.ctl_expense_number.zz_Text = "";
            this.ctl_expense_number.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_expense_number.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_expense_number.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_expense_number.zz_UseGlobalColor = false;
            this.ctl_expense_number.zz_UseGlobalFont = false;
            // 
            // numMinor
            // 
            this.numMinor.Location = new System.Drawing.Point(655, 155);
            this.numMinor.Name = "numMinor";
            this.numMinor.Size = new System.Drawing.Size(38, 20);
            this.numMinor.TabIndex = 11;
            // 
            // lblMinor
            // 
            this.lblMinor.AutoSize = true;
            this.lblMinor.Location = new System.Drawing.Point(613, 157);
            this.lblMinor.Name = "lblMinor";
            this.lblMinor.Size = new System.Drawing.Size(36, 13);
            this.lblMinor.TabIndex = 10;
            this.lblMinor.Text = "Minor:";
            // 
            // numMajor
            // 
            this.numMajor.Location = new System.Drawing.Point(559, 155);
            this.numMajor.Name = "numMajor";
            this.numMajor.Size = new System.Drawing.Size(38, 20);
            this.numMajor.TabIndex = 9;
            // 
            // lblMajor
            // 
            this.lblMajor.AutoSize = true;
            this.lblMajor.Location = new System.Drawing.Point(517, 157);
            this.lblMajor.Name = "lblMajor";
            this.lblMajor.Size = new System.Drawing.Size(36, 13);
            this.lblMajor.TabIndex = 8;
            this.lblMajor.Text = "Major:";
            // 
            // cmdVersionInfo
            // 
            this.cmdVersionInfo.Location = new System.Drawing.Point(516, 195);
            this.cmdVersionInfo.Name = "cmdVersionInfo";
            this.cmdVersionInfo.Size = new System.Drawing.Size(174, 25);
            this.cmdVersionInfo.TabIndex = 7;
            this.cmdVersionInfo.Text = "Check Version Numbers";
            this.cmdVersionInfo.UseVisualStyleBackColor = true;
            this.cmdVersionInfo.Click += new System.EventHandler(this.cmdVersionInfo_Click);
            // 
            // cmdCreate
            // 
            this.cmdCreate.Location = new System.Drawing.Point(516, 257);
            this.cmdCreate.Name = "cmdCreate";
            this.cmdCreate.Size = new System.Drawing.Size(174, 25);
            this.cmdCreate.TabIndex = 6;
            this.cmdCreate.Text = "Create In QuickBooks";
            this.cmdCreate.UseVisualStyleBackColor = true;
            this.cmdCreate.Click += new System.EventHandler(this.cmdCreate_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(516, 226);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(174, 25);
            this.cmdSave.TabIndex = 5;
            this.cmdSave.Text = "Save In Rz3";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // ctl_cogs
            // 
            this.ctl_cogs.AllCaps = false;
            this.ctl_cogs.BackColor = System.Drawing.Color.White;
            this.ctl_cogs.Bold = false;
            this.ctl_cogs.Caption = "COGS Account";
            this.ctl_cogs.Changed = false;
            this.ctl_cogs.IsEmail = false;
            this.ctl_cogs.IsURL = false;
            this.ctl_cogs.Location = new System.Drawing.Point(8, 206);
            this.ctl_cogs.Name = "ctl_cogs";
            this.ctl_cogs.PasswordChar = '\0';
            this.ctl_cogs.Size = new System.Drawing.Size(177, 45);
            this.ctl_cogs.TabIndex = 4;
            this.ctl_cogs.UseParentBackColor = true;
            this.ctl_cogs.zz_Enabled = true;
            this.ctl_cogs.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_cogs.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_cogs.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_cogs.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_cogs.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_cogs.zz_OriginalDesign = true;
            this.ctl_cogs.zz_ShowLinkButton = false;
            this.ctl_cogs.zz_ShowNeedsSaveColor = true;
            this.ctl_cogs.zz_Text = "";
            this.ctl_cogs.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_cogs.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_cogs.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_cogs.zz_UseGlobalColor = false;
            this.ctl_cogs.zz_UseGlobalFont = false;
            // 
            // ctl_asset
            // 
            this.ctl_asset.AllCaps = false;
            this.ctl_asset.BackColor = System.Drawing.Color.White;
            this.ctl_asset.Bold = false;
            this.ctl_asset.Caption = "Asset Account";
            this.ctl_asset.Changed = false;
            this.ctl_asset.IsEmail = false;
            this.ctl_asset.IsURL = false;
            this.ctl_asset.Location = new System.Drawing.Point(8, 155);
            this.ctl_asset.Name = "ctl_asset";
            this.ctl_asset.PasswordChar = '\0';
            this.ctl_asset.Size = new System.Drawing.Size(177, 45);
            this.ctl_asset.TabIndex = 3;
            this.ctl_asset.UseParentBackColor = true;
            this.ctl_asset.zz_Enabled = true;
            this.ctl_asset.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_asset.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_asset.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_asset.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_asset.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_asset.zz_OriginalDesign = true;
            this.ctl_asset.zz_ShowLinkButton = false;
            this.ctl_asset.zz_ShowNeedsSaveColor = true;
            this.ctl_asset.zz_Text = "";
            this.ctl_asset.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_asset.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_asset.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_asset.zz_UseGlobalColor = false;
            this.ctl_asset.zz_UseGlobalFont = false;
            // 
            // ctl_income
            // 
            this.ctl_income.AllCaps = false;
            this.ctl_income.BackColor = System.Drawing.Color.White;
            this.ctl_income.Bold = false;
            this.ctl_income.Caption = "Income Account";
            this.ctl_income.Changed = false;
            this.ctl_income.IsEmail = false;
            this.ctl_income.IsURL = false;
            this.ctl_income.Location = new System.Drawing.Point(8, 104);
            this.ctl_income.Name = "ctl_income";
            this.ctl_income.PasswordChar = '\0';
            this.ctl_income.Size = new System.Drawing.Size(177, 45);
            this.ctl_income.TabIndex = 2;
            this.ctl_income.UseParentBackColor = true;
            this.ctl_income.zz_Enabled = true;
            this.ctl_income.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_income.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_income.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_income.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_income.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_income.zz_OriginalDesign = true;
            this.ctl_income.zz_ShowLinkButton = false;
            this.ctl_income.zz_ShowNeedsSaveColor = true;
            this.ctl_income.zz_Text = "";
            this.ctl_income.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_income.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_income.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_income.zz_UseGlobalColor = false;
            this.ctl_income.zz_UseGlobalFont = false;
            // 
            // ctl_expense
            // 
            this.ctl_expense.AllCaps = false;
            this.ctl_expense.BackColor = System.Drawing.Color.White;
            this.ctl_expense.Bold = false;
            this.ctl_expense.Caption = "Expense Account";
            this.ctl_expense.Changed = false;
            this.ctl_expense.IsEmail = false;
            this.ctl_expense.IsURL = false;
            this.ctl_expense.Location = new System.Drawing.Point(8, 53);
            this.ctl_expense.Name = "ctl_expense";
            this.ctl_expense.PasswordChar = '\0';
            this.ctl_expense.Size = new System.Drawing.Size(177, 45);
            this.ctl_expense.TabIndex = 1;
            this.ctl_expense.UseParentBackColor = true;
            this.ctl_expense.zz_Enabled = true;
            this.ctl_expense.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_expense.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_expense.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_expense.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_expense.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_expense.zz_OriginalDesign = true;
            this.ctl_expense.zz_ShowLinkButton = false;
            this.ctl_expense.zz_ShowNeedsSaveColor = true;
            this.ctl_expense.zz_Text = "";
            this.ctl_expense.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_expense.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_expense.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_expense.zz_UseGlobalColor = false;
            this.ctl_expense.zz_UseGlobalFont = false;
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(5, 11);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(323, 36);
            this.cmdConnect.TabIndex = 0;
            this.cmdConnect.Text = "Test Connect";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(8, 514);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(330, 140);
            this.txtStatus.TabIndex = 1;
            // 
            // gbUnitTests
            // 
            this.gbUnitTests.Controls.Add(this.llSalesReps);
            this.gbUnitTests.Location = new System.Drawing.Point(592, 345);
            this.gbUnitTests.Name = "gbUnitTests";
            this.gbUnitTests.Size = new System.Drawing.Size(200, 100);
            this.gbUnitTests.TabIndex = 35;
            this.gbUnitTests.TabStop = false;
            this.gbUnitTests.Text = "Unit Tests";
            // 
            // llSalesReps
            // 
            this.llSalesReps.AutoSize = true;
            this.llSalesReps.Location = new System.Drawing.Point(7, 20);
            this.llSalesReps.Name = "llSalesReps";
            this.llSalesReps.Size = new System.Drawing.Size(85, 13);
            this.llSalesReps.TabIndex = 0;
            this.llSalesReps.TabStop = true;
            this.llSalesReps.Text = "Sales Rep Tests";
            this.llSalesReps.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSalesReps_LinkClicked);
            // 
            // QuickBench
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.gb);
            this.Name = "QuickBench";
            this.Size = new System.Drawing.Size(1155, 680);
            this.Load += new System.EventHandler(this.QuickBench_Load);
            this.Resize += new System.EventHandler(this.QuickBench_Resize);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMajor)).EndInit();
            this.gbUnitTests.ResumeLayout(false);
            this.gbUnitTests.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        protected System.Windows.Forms.GroupBox gb;
        protected System.Windows.Forms.Button cmdConnect;
        protected System.Windows.Forms.TextBox txtStatus;
        protected System.Windows.Forms.Button cmdCreate;
        protected System.Windows.Forms.Button cmdSave;
        protected nEdit_String ctl_cogs;
        protected nEdit_String ctl_asset;
        protected nEdit_String ctl_income;
        protected nEdit_String ctl_expense;
        protected System.Windows.Forms.Button cmdVersionInfo;
        protected System.Windows.Forms.NumericUpDown numMinor;
        protected System.Windows.Forms.Label lblMinor;
        protected System.Windows.Forms.NumericUpDown numMajor;
        protected System.Windows.Forms.Label lblMajor;
        protected nEdit_String ctl_cogs_number;
        protected nEdit_String ctl_asset_number;
        protected nEdit_String ctl_income_number;
        protected nEdit_String ctl_expense_number;
        protected nEdit_String ctl_version_name;
        protected nEdit_String ctl_deposit_number;
        protected nEdit_String ctl_deposit;
        protected nEdit_List ctlItemOption;
        protected nEdit_String ctlHandlingItem;
        protected nEdit_String ctlIncomingShippingItem;
        protected nEdit_String ctlOutgoingShipping;
        protected nEdit_String ctlVendorSuffix;
        protected nEdit_String ctlItemSuffix;
        protected System.Windows.Forms.ListView lvPO;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.ListView lvInvoice;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.ListView lvGeneral;
        protected System.Windows.Forms.Label lblGeneral;
        protected nEdit_String ctlInvoiceTemplateName;
        private System.Windows.Forms.GroupBox gbUnitTests;
        private System.Windows.Forms.LinkLabel llSalesReps;
    }
}
