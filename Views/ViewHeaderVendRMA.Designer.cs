namespace Rz5
{
    partial class ViewHeaderVendRMA
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
            this.tabRMA = new System.Windows.Forms.TabPage();
            this.gbGo = new System.Windows.Forms.GroupBox();
            this.optDiscard = new System.Windows.Forms.RadioButton();
            this.optKeep = new System.Windows.Forms.RadioButton();
            this.optReturn = new System.Windows.Forms.RadioButton();
            this.cboWhy = new NewMethod.nEdit_List();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.optNoReturn = new System.Windows.Forms.RadioButton();
            this.optWarehouse = new System.Windows.Forms.RadioButton();
            this.optShip = new System.Windows.Forms.RadioButton();
            this.cboReimburse = new NewMethod.nEdit_List();
            this.gbVendor = new System.Windows.Forms.GroupBox();
            this.optNoVendor = new System.Windows.Forms.RadioButton();
            this.optYesVendor = new System.Windows.Forms.RadioButton();
            this.gbCustomer = new System.Windows.Forms.GroupBox();
            this.optNoCustomer = new System.Windows.Forms.RadioButton();
            this.optYesCustomer = new System.Windows.Forms.RadioButton();
            this.cboVendReimburse = new NewMethod.nEdit_List();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCharges = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbCharges = new System.Windows.Forms.GroupBox();
            this.ctl_taxamount = new NewMethod.nEdit_Money();
            this.ctl_handlingamount = new NewMethod.nEdit_Money();
            this.ctl_shippingamount = new NewMethod.nEdit_Money();
            this.lblPaid = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctl_terms = new NewMethod.nEdit_List();
            this.ts.SuspendLayout();
            this.tabCompany.SuspendLayout();
            this.tabAddress.SuspendLayout();
            this.tabNotes.SuspendLayout();
            this.gbTotals.SuspendLayout();
            this.gbAction1.SuspendLayout();
            this.gbAction2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.tabShipping.SuspendLayout();
            this.tabOther.SuspendLayout();
            this.tabLines.SuspendLayout();
            this.tsDetails.SuspendLayout();
            this.tabRMA.SuspendLayout();
            this.gbGo.SuspendLayout();
            this.gbStatus.SuspendLayout();
            this.gbVendor.SuspendLayout();
            this.gbCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gbCharges.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboBillingAddress
            // 
            this.cboBillingAddress.Size = new System.Drawing.Size(291, 22);
            this.cboBillingAddress.TabIndex = 7;
            // 
            // cboShippingAddress
            // 
            this.cboShippingAddress.Location = new System.Drawing.Point(331, 33);
            this.cboShippingAddress.Size = new System.Drawing.Size(291, 22);
            this.cboShippingAddress.TabIndex = 8;
            // 
            // ts
            // 
            this.ts.Controls.Add(this.tabRMA);
            this.ts.Controls.SetChildIndex(this.tabOther, 0);
            this.ts.Controls.SetChildIndex(this.tabShipping, 0);
            this.ts.Controls.SetChildIndex(this.tabNotes, 0);
            this.ts.Controls.SetChildIndex(this.tabRMA, 0);
            this.ts.Controls.SetChildIndex(this.tabAddress, 0);
            this.ts.Controls.SetChildIndex(this.tabCompany, 0);
            // 
            // tabCompany
            // 
            this.tabCompany.Controls.Add(this.ctl_terms);
            this.tabCompany.Controls.SetChildIndex(this.cStub, 0);
            this.tabCompany.Controls.SetChildIndex(this.agent, 0);
            this.tabCompany.Controls.SetChildIndex(this.ctl_primaryemailaddress, 0);
            this.tabCompany.Controls.SetChildIndex(this.ctl_primaryfax, 0);
            this.tabCompany.Controls.SetChildIndex(this.ctl_primaryphone, 0);
            this.tabCompany.Controls.SetChildIndex(this.nlblorderdate, 0);
            this.tabCompany.Controls.SetChildIndex(this.nlblordertime, 0);
            this.tabCompany.Controls.SetChildIndex(this.lblChangeDate, 0);
            this.tabCompany.Controls.SetChildIndex(this.ctl_terms, 0);
            // 
            // tabAddress
            // 
            this.tabAddress.Size = new System.Drawing.Size(628, 256);
            // 
            // ctl_shippingname
            // 
            this.ctl_shippingname.Location = new System.Drawing.Point(331, 4);
            this.ctl_shippingname.Size = new System.Drawing.Size(291, 22);
            this.ctl_shippingname.TabIndex = 6;
            // 
            // ctl_billingname
            // 
            this.ctl_billingname.TabIndex = 5;
            // 
            // ctl_shippingaddress
            // 
            this.ctl_shippingaddress.TabIndex = 16;
            // 
            // ctl_billingaddress
            // 
            this.ctl_billingaddress.TabIndex = 12;
            // 
            // cmdShipBill
            // 
            this.cmdShipBill.Location = new System.Drawing.Point(295, 143);
            this.cmdShipBill.TabIndex = 14;
            // 
            // cmdBillShip
            // 
            this.cmdBillShip.Location = new System.Drawing.Point(295, 98);
            this.cmdBillShip.TabIndex = 13;
            // 
            // lblAddNewShiping
            // 
            this.lblAddNewShiping.TabIndex = 11;
            // 
            // lblAddNewBilling
            // 
            this.lblAddNewBilling.TabIndex = 9;
            // 
            // cmdSwitchAddress
            // 
            this.cmdSwitchAddress.Location = new System.Drawing.Point(295, 188);
            this.cmdSwitchAddress.TabIndex = 15;
            // 
            // cmdPasteBill
            // 
            this.cmdPasteBill.Location = new System.Drawing.Point(234, 65);
            this.cmdPasteBill.TabIndex = 10;
            // 
            // gbTotals
            // 
            this.gbTotals.Controls.Add(this.lblPaid);
            this.gbTotals.Controls.Add(this.pictureBox2);
            this.gbTotals.Controls.Add(this.label2);
            this.gbTotals.Controls.Add(this.lblTotal);
            this.gbTotals.Controls.Add(this.label5);
            this.gbTotals.Controls.Add(this.lblCharges);
            this.gbTotals.Controls.Add(this.label6);
            this.gbTotals.Controls.Add(this.lblSubTotal);
            this.gbTotals.Controls.Add(this.label3);
            this.gbTotals.Location = new System.Drawing.Point(647, 210);
            this.gbTotals.Size = new System.Drawing.Size(202, 136);
            // 
            // picHeader
            // 
            this.picHeader.BackgroundImage = global::RzInterfaceWin.Properties.Resources.RedGreenBar;
            // 
            // ctl_shipvia
            // 
            this.ctl_shipvia.Size = new System.Drawing.Size(252, 40);
            this.ctl_shipvia.TabIndex = 17;
            // 
            // lvAccount
            // 
            this.lvAccount.TabIndex = 22;
            // 
            // lvShipVia
            // 
            this.lvShipVia.TabIndex = 21;
            // 
            // ctl_trackingnumber
            // 
            this.ctl_trackingnumber.TabIndex = 23;
            // 
            // ctl_shippingaccount
            // 
            this.ctl_shippingaccount.Size = new System.Drawing.Size(252, 40);
            this.ctl_shippingaccount.TabIndex = 19;
            // 
            // cmdSetShipAccounts
            // 
            this.cmdSetShipAccounts.TabIndex = 20;
            // 
            // cmdSetShipVia
            // 
            this.cmdSetShipVia.TabIndex = 18;
            // 
            // ctl_senttoqb
            // 
            this.ctl_senttoqb.TabIndex = 24;
            // 
            // ctl_is_confirmed
            // 
            this.ctl_is_confirmed.TabIndex = 25;
            // 
            // details
            // 
            this.details.zz_OrderLineType = "vendrma";
            // 
            // tabRMA
            // 
            this.tabRMA.Controls.Add(this.gbGo);
            this.tabRMA.Controls.Add(this.cboWhy);
            this.tabRMA.Controls.Add(this.gbStatus);
            this.tabRMA.Controls.Add(this.cboReimburse);
            this.tabRMA.Controls.Add(this.gbVendor);
            this.tabRMA.Controls.Add(this.gbCustomer);
            this.tabRMA.Controls.Add(this.cboVendReimburse);
            this.tabRMA.Location = new System.Drawing.Point(4, 22);
            this.tabRMA.Name = "tabRMA";
            this.tabRMA.Size = new System.Drawing.Size(628, 256);
            this.tabRMA.TabIndex = 5;
            this.tabRMA.Text = "RMA Data";
            this.tabRMA.UseVisualStyleBackColor = true;
            // 
            // gbGo
            // 
            this.gbGo.Controls.Add(this.optDiscard);
            this.gbGo.Controls.Add(this.optKeep);
            this.gbGo.Controls.Add(this.optReturn);
            this.gbGo.Location = new System.Drawing.Point(298, 100);
            this.gbGo.Name = "gbGo";
            this.gbGo.Size = new System.Drawing.Size(308, 80);
            this.gbGo.TabIndex = 103;
            this.gbGo.TabStop = false;
            this.gbGo.Text = "Where will these parts eventually go?";
            // 
            // optDiscard
            // 
            this.optDiscard.AutoSize = true;
            this.optDiscard.Location = new System.Drawing.Point(23, 57);
            this.optDiscard.Name = "optDiscard";
            this.optDiscard.Size = new System.Drawing.Size(151, 17);
            this.optDiscard.TabIndex = 39;
            this.optDiscard.TabStop = true;
            this.optDiscard.Text = "The parts will be discarded";
            this.optDiscard.UseVisualStyleBackColor = true;
            // 
            // optKeep
            // 
            this.optKeep.AutoSize = true;
            this.optKeep.Location = new System.Drawing.Point(23, 38);
            this.optKeep.Name = "optKeep";
            this.optKeep.Size = new System.Drawing.Size(179, 17);
            this.optKeep.TabIndex = 38;
            this.optKeep.TabStop = true;
            this.optKeep.Text = "The parts will remain in our stock";
            this.optKeep.UseVisualStyleBackColor = true;
            // 
            // optReturn
            // 
            this.optReturn.AutoSize = true;
            this.optReturn.Location = new System.Drawing.Point(23, 19);
            this.optReturn.Name = "optReturn";
            this.optReturn.Size = new System.Drawing.Size(191, 17);
            this.optReturn.TabIndex = 37;
            this.optReturn.TabStop = true;
            this.optReturn.Text = "The parts will be sent to the vendor";
            this.optReturn.UseVisualStyleBackColor = true;
            // 
            // cboWhy
            // 
            this.cboWhy.AllCaps = false;
            this.cboWhy.AllowEdit = false;
            this.cboWhy.BackColor = System.Drawing.Color.Transparent;
            this.cboWhy.Bold = false;
            this.cboWhy.Caption = "Why are these parts being returned?";
            this.cboWhy.Changed = false;
            this.cboWhy.ListName = "rma_reason";
            this.cboWhy.Location = new System.Drawing.Point(7, 4);
            this.cboWhy.Margin = new System.Windows.Forms.Padding(5);
            this.cboWhy.Name = "cboWhy";
            this.cboWhy.SimpleList = "";
            this.cboWhy.Size = new System.Drawing.Size(274, 36);
            this.cboWhy.TabIndex = 28;
            this.cboWhy.UseParentBackColor = true;
            this.cboWhy.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboWhy.zz_GlobalColor = System.Drawing.Color.Black;
            this.cboWhy.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboWhy.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cboWhy.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboWhy.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.cboWhy.zz_OriginalDesign = false;
            this.cboWhy.zz_ShowNeedsSaveColor = true;
            this.cboWhy.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.cboWhy.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWhy.zz_UseGlobalColor = false;
            this.cboWhy.zz_UseGlobalFont = false;
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.optNoReturn);
            this.gbStatus.Controls.Add(this.optWarehouse);
            this.gbStatus.Controls.Add(this.optShip);
            this.gbStatus.Location = new System.Drawing.Point(298, 12);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(308, 82);
            this.gbStatus.TabIndex = 102;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "What is the current status of the parts?";
            // 
            // optNoReturn
            // 
            this.optNoReturn.AutoSize = true;
            this.optNoReturn.Location = new System.Drawing.Point(23, 57);
            this.optNoReturn.Name = "optNoReturn";
            this.optNoReturn.Size = new System.Drawing.Size(162, 17);
            this.optNoReturn.TabIndex = 36;
            this.optNoReturn.TabStop = true;
            this.optNoReturn.Text = "The parts will not be returned";
            this.optNoReturn.UseVisualStyleBackColor = true;
            // 
            // optWarehouse
            // 
            this.optWarehouse.AutoSize = true;
            this.optWarehouse.Location = new System.Drawing.Point(23, 38);
            this.optWarehouse.Name = "optWarehouse";
            this.optWarehouse.Size = new System.Drawing.Size(172, 17);
            this.optWarehouse.TabIndex = 35;
            this.optWarehouse.TabStop = true;
            this.optWarehouse.Text = "The parts are in our warehouse";
            this.optWarehouse.UseVisualStyleBackColor = true;
            // 
            // optShip
            // 
            this.optShip.AutoSize = true;
            this.optShip.Location = new System.Drawing.Point(23, 19);
            this.optShip.Name = "optShip";
            this.optShip.Size = new System.Drawing.Size(198, 17);
            this.optShip.TabIndex = 34;
            this.optShip.TabStop = true;
            this.optShip.Text = "The parts will be shipped back to us.";
            this.optShip.UseVisualStyleBackColor = true;
            // 
            // cboReimburse
            // 
            this.cboReimburse.AllCaps = false;
            this.cboReimburse.AllowEdit = false;
            this.cboReimburse.BackColor = System.Drawing.Color.Transparent;
            this.cboReimburse.Bold = false;
            this.cboReimburse.Caption = "How should the customer be reimbursed?";
            this.cboReimburse.Changed = false;
            this.cboReimburse.ListName = "reimburse_method_customer";
            this.cboReimburse.Location = new System.Drawing.Point(7, 47);
            this.cboReimburse.Margin = new System.Windows.Forms.Padding(5);
            this.cboReimburse.Name = "cboReimburse";
            this.cboReimburse.SimpleList = "";
            this.cboReimburse.Size = new System.Drawing.Size(274, 36);
            this.cboReimburse.TabIndex = 29;
            this.cboReimburse.UseParentBackColor = true;
            this.cboReimburse.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboReimburse.zz_GlobalColor = System.Drawing.Color.Black;
            this.cboReimburse.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboReimburse.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cboReimburse.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboReimburse.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.cboReimburse.zz_OriginalDesign = false;
            this.cboReimburse.zz_ShowNeedsSaveColor = true;
            this.cboReimburse.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.cboReimburse.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReimburse.zz_UseGlobalColor = false;
            this.cboReimburse.zz_UseGlobalFont = false;
            // 
            // gbVendor
            // 
            this.gbVendor.Controls.Add(this.optNoVendor);
            this.gbVendor.Controls.Add(this.optYesVendor);
            this.gbVendor.Location = new System.Drawing.Point(7, 196);
            this.gbVendor.Name = "gbVendor";
            this.gbVendor.Size = new System.Drawing.Size(274, 41);
            this.gbVendor.TabIndex = 101;
            this.gbVendor.TabStop = false;
            this.gbVendor.Text = "Does the vendor owe us a refund?";
            // 
            // optNoVendor
            // 
            this.optNoVendor.AutoSize = true;
            this.optNoVendor.Location = new System.Drawing.Point(119, 19);
            this.optNoVendor.Name = "optNoVendor";
            this.optNoVendor.Size = new System.Drawing.Size(39, 17);
            this.optNoVendor.TabIndex = 33;
            this.optNoVendor.TabStop = true;
            this.optNoVendor.Text = "No";
            this.optNoVendor.UseVisualStyleBackColor = true;
            // 
            // optYesVendor
            // 
            this.optYesVendor.AutoSize = true;
            this.optYesVendor.Location = new System.Drawing.Point(39, 18);
            this.optYesVendor.Name = "optYesVendor";
            this.optYesVendor.Size = new System.Drawing.Size(43, 17);
            this.optYesVendor.TabIndex = 32;
            this.optYesVendor.TabStop = true;
            this.optYesVendor.Text = "Yes";
            this.optYesVendor.UseVisualStyleBackColor = true;
            // 
            // gbCustomer
            // 
            this.gbCustomer.Controls.Add(this.optNoCustomer);
            this.gbCustomer.Controls.Add(this.optYesCustomer);
            this.gbCustomer.Location = new System.Drawing.Point(7, 97);
            this.gbCustomer.Name = "gbCustomer";
            this.gbCustomer.Size = new System.Drawing.Size(274, 41);
            this.gbCustomer.TabIndex = 100;
            this.gbCustomer.TabStop = false;
            this.gbCustomer.Text = "Is the customer due a refund?";
            // 
            // optNoCustomer
            // 
            this.optNoCustomer.AutoSize = true;
            this.optNoCustomer.Location = new System.Drawing.Point(119, 19);
            this.optNoCustomer.Name = "optNoCustomer";
            this.optNoCustomer.Size = new System.Drawing.Size(39, 17);
            this.optNoCustomer.TabIndex = 31;
            this.optNoCustomer.TabStop = true;
            this.optNoCustomer.Text = "No";
            this.optNoCustomer.UseVisualStyleBackColor = true;
            // 
            // optYesCustomer
            // 
            this.optYesCustomer.AutoSize = true;
            this.optYesCustomer.Location = new System.Drawing.Point(39, 18);
            this.optYesCustomer.Name = "optYesCustomer";
            this.optYesCustomer.Size = new System.Drawing.Size(43, 17);
            this.optYesCustomer.TabIndex = 30;
            this.optYesCustomer.TabStop = true;
            this.optYesCustomer.Text = "Yes";
            this.optYesCustomer.UseVisualStyleBackColor = true;
            // 
            // cboVendReimburse
            // 
            this.cboVendReimburse.AllCaps = false;
            this.cboVendReimburse.AllowEdit = false;
            this.cboVendReimburse.BackColor = System.Drawing.Color.Transparent;
            this.cboVendReimburse.Bold = false;
            this.cboVendReimburse.Caption = "How will we be reimbursed?";
            this.cboVendReimburse.Changed = false;
            this.cboVendReimburse.ListName = "reimburse_method_vendor";
            this.cboVendReimburse.Location = new System.Drawing.Point(7, 144);
            this.cboVendReimburse.Margin = new System.Windows.Forms.Padding(5);
            this.cboVendReimburse.Name = "cboVendReimburse";
            this.cboVendReimburse.SimpleList = "";
            this.cboVendReimburse.Size = new System.Drawing.Size(274, 36);
            this.cboVendReimburse.TabIndex = 31;
            this.cboVendReimburse.UseParentBackColor = true;
            this.cboVendReimburse.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboVendReimburse.zz_GlobalColor = System.Drawing.Color.Black;
            this.cboVendReimburse.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboVendReimburse.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cboVendReimburse.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboVendReimburse.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.cboVendReimburse.zz_OriginalDesign = false;
            this.cboVendReimburse.zz_ShowNeedsSaveColor = true;
            this.cboVendReimburse.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.cboVendReimburse.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVendReimburse.zz_UseGlobalColor = false;
            this.cboVendReimburse.zz_UseGlobalFont = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Silver;
            this.pictureBox2.Location = new System.Drawing.Point(67, 68);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(119, 1);
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(65, 75);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(128, 21);
            this.lblTotal.TabIndex = 27;
            this.lblTotal.Text = "$ 1,123,456.67";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(8, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 26;
            this.label5.Text = "Total:";
            // 
            // lblCharges
            // 
            this.lblCharges.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharges.Location = new System.Drawing.Point(65, 47);
            this.lblCharges.Name = "lblCharges";
            this.lblCharges.Size = new System.Drawing.Size(128, 21);
            this.lblCharges.TabIndex = 25;
            this.lblCharges.Text = "$ 1,123,456.67";
            this.lblCharges.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(8, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "Charges:";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(70, 23);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(123, 21);
            this.lblSubTotal.TabIndex = 23;
            this.lblSubTotal.Text = "$ 1,123,456.67";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(8, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Subtotal:";
            // 
            // gbCharges
            // 
            this.gbCharges.BackColor = System.Drawing.Color.White;
            this.gbCharges.Controls.Add(this.ctl_taxamount);
            this.gbCharges.Controls.Add(this.ctl_handlingamount);
            this.gbCharges.Controls.Add(this.ctl_shippingamount);
            this.gbCharges.Enabled = false;
            this.gbCharges.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCharges.Location = new System.Drawing.Point(856, 211);
            this.gbCharges.Name = "gbCharges";
            this.gbCharges.Size = new System.Drawing.Size(183, 135);
            this.gbCharges.TabIndex = 50;
            this.gbCharges.TabStop = false;
            this.gbCharges.Text = "Charges";
            // 
            // ctl_taxamount
            // 
            this.ctl_taxamount.BackColor = System.Drawing.Color.White;
            this.ctl_taxamount.Bold = false;
            this.ctl_taxamount.Caption = "Tax          ";
            this.ctl_taxamount.Changed = false;
            this.ctl_taxamount.EditCaption = false;
            this.ctl_taxamount.FullDecimal = false;
            this.ctl_taxamount.Location = new System.Drawing.Point(8, 97);
            this.ctl_taxamount.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.ctl_taxamount.Name = "ctl_taxamount";
            this.ctl_taxamount.RoundNearestCent = false;
            this.ctl_taxamount.Size = new System.Drawing.Size(164, 28);
            this.ctl_taxamount.TabIndex = 32;
            this.ctl_taxamount.UseParentBackColor = true;
            this.ctl_taxamount.zz_Enabled = true;
            this.ctl_taxamount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_taxamount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_taxamount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_taxamount.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_taxamount.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.Left;
            this.ctl_taxamount.zz_OriginalDesign = false;
            this.ctl_taxamount.zz_ShowErrorColor = true;
            this.ctl_taxamount.zz_ShowNeedsSaveColor = true;
            this.ctl_taxamount.zz_Text = "";
            this.ctl_taxamount.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_taxamount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_taxamount.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_taxamount.zz_UseGlobalColor = false;
            this.ctl_taxamount.zz_UseGlobalFont = false;
            // 
            // ctl_handlingamount
            // 
            this.ctl_handlingamount.BackColor = System.Drawing.Color.White;
            this.ctl_handlingamount.Bold = false;
            this.ctl_handlingamount.Caption = "Handling";
            this.ctl_handlingamount.Changed = false;
            this.ctl_handlingamount.EditCaption = false;
            this.ctl_handlingamount.FullDecimal = false;
            this.ctl_handlingamount.Location = new System.Drawing.Point(8, 61);
            this.ctl_handlingamount.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ctl_handlingamount.Name = "ctl_handlingamount";
            this.ctl_handlingamount.RoundNearestCent = false;
            this.ctl_handlingamount.Size = new System.Drawing.Size(164, 28);
            this.ctl_handlingamount.TabIndex = 31;
            this.ctl_handlingamount.UseParentBackColor = true;
            this.ctl_handlingamount.zz_Enabled = true;
            this.ctl_handlingamount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_handlingamount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_handlingamount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_handlingamount.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_handlingamount.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.Left;
            this.ctl_handlingamount.zz_OriginalDesign = false;
            this.ctl_handlingamount.zz_ShowErrorColor = true;
            this.ctl_handlingamount.zz_ShowNeedsSaveColor = true;
            this.ctl_handlingamount.zz_Text = "";
            this.ctl_handlingamount.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_handlingamount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_handlingamount.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_handlingamount.zz_UseGlobalColor = false;
            this.ctl_handlingamount.zz_UseGlobalFont = false;
            // 
            // ctl_shippingamount
            // 
            this.ctl_shippingamount.BackColor = System.Drawing.Color.White;
            this.ctl_shippingamount.Bold = false;
            this.ctl_shippingamount.Caption = "Shipping";
            this.ctl_shippingamount.Changed = false;
            this.ctl_shippingamount.EditCaption = false;
            this.ctl_shippingamount.FullDecimal = false;
            this.ctl_shippingamount.Location = new System.Drawing.Point(8, 25);
            this.ctl_shippingamount.Margin = new System.Windows.Forms.Padding(4);
            this.ctl_shippingamount.Name = "ctl_shippingamount";
            this.ctl_shippingamount.RoundNearestCent = false;
            this.ctl_shippingamount.Size = new System.Drawing.Size(165, 28);
            this.ctl_shippingamount.TabIndex = 30;
            this.ctl_shippingamount.UseParentBackColor = true;
            this.ctl_shippingamount.zz_Enabled = true;
            this.ctl_shippingamount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shippingamount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_shippingamount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shippingamount.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shippingamount.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.Left;
            this.ctl_shippingamount.zz_OriginalDesign = false;
            this.ctl_shippingamount.zz_ShowErrorColor = true;
            this.ctl_shippingamount.zz_ShowNeedsSaveColor = true;
            this.ctl_shippingamount.zz_Text = "";
            this.ctl_shippingamount.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_shippingamount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shippingamount.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shippingamount.zz_UseGlobalColor = false;
            this.ctl_shippingamount.zz_UseGlobalFont = false;
            // 
            // lblPaid
            // 
            this.lblPaid.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblPaid.Location = new System.Drawing.Point(84, 105);
            this.lblPaid.Name = "lblPaid";
            this.lblPaid.Size = new System.Drawing.Size(109, 21);
            this.lblPaid.TabIndex = 30;
            this.lblPaid.Text = "$ 1,123,456.67";
            this.lblPaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(7, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 29;
            this.label2.Text = "Refund Amnt:";
            // 
            // ctl_terms
            // 
            this.ctl_terms.AllCaps = false;
            this.ctl_terms.AllowEdit = false;
            this.ctl_terms.BackColor = System.Drawing.Color.Transparent;
            this.ctl_terms.Bold = false;
            this.ctl_terms.Caption = "Terms";
            this.ctl_terms.Changed = false;
            this.ctl_terms.Enabled = false;
            this.ctl_terms.ListName = "terms";
            this.ctl_terms.Location = new System.Drawing.Point(351, 211);
            this.ctl_terms.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_terms.Name = "ctl_terms";
            this.ctl_terms.SimpleList = null;
            this.ctl_terms.Size = new System.Drawing.Size(198, 28);
            this.ctl_terms.TabIndex = 64;
            this.ctl_terms.UseParentBackColor = false;
            this.ctl_terms.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctl_terms.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_terms.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_terms.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_terms.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_terms.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.Left;
            this.ctl_terms.zz_OriginalDesign = false;
            this.ctl_terms.zz_ShowNeedsSaveColor = true;
            this.ctl_terms.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_terms.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_terms.zz_UseGlobalColor = false;
            this.ctl_terms.zz_UseGlobalFont = false;
            // 
            // ViewHeaderVendRMA
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.gbCharges);
            this.Name = "ViewHeaderVendRMA";
            this.Controls.SetChildIndex(this.gbTotals, 0);
            this.Controls.SetChildIndex(this.picHeader, 0);
            this.Controls.SetChildIndex(this.ts, 0);
            this.Controls.SetChildIndex(this.gbAction1, 0);
            this.Controls.SetChildIndex(this.tsDetails, 0);
            this.Controls.SetChildIndex(this.gbAction2, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.Controls.SetChildIndex(this.gbCharges, 0);
            this.ts.ResumeLayout(false);
            this.tabCompany.ResumeLayout(false);
            this.tabCompany.PerformLayout();
            this.tabAddress.ResumeLayout(false);
            this.tabAddress.PerformLayout();
            this.tabNotes.ResumeLayout(false);
            this.gbTotals.ResumeLayout(false);
            this.gbTotals.PerformLayout();
            this.gbAction1.ResumeLayout(false);
            this.gbAction1.PerformLayout();
            this.gbAction2.ResumeLayout(false);
            this.gbAction2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.tabShipping.ResumeLayout(false);
            this.tabOther.ResumeLayout(false);
            this.tabLines.ResumeLayout(false);
            this.tabLines.PerformLayout();
            this.tsDetails.ResumeLayout(false);
            this.tabRMA.ResumeLayout(false);
            this.gbGo.ResumeLayout(false);
            this.gbGo.PerformLayout();
            this.gbStatus.ResumeLayout(false);
            this.gbStatus.PerformLayout();
            this.gbVendor.ResumeLayout(false);
            this.gbVendor.PerformLayout();
            this.gbCustomer.ResumeLayout(false);
            this.gbCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gbCharges.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabRMA;
        protected System.Windows.Forms.GroupBox gbGo;
        public System.Windows.Forms.RadioButton optDiscard;
        public System.Windows.Forms.RadioButton optKeep;
        public System.Windows.Forms.RadioButton optReturn;
        protected NewMethod.nEdit_List cboWhy;
        protected System.Windows.Forms.GroupBox gbStatus;
        public System.Windows.Forms.RadioButton optNoReturn;
        public System.Windows.Forms.RadioButton optWarehouse;
        public System.Windows.Forms.RadioButton optShip;
        protected NewMethod.nEdit_List cboReimburse;
        protected System.Windows.Forms.GroupBox gbVendor;
        private System.Windows.Forms.RadioButton optNoVendor;
        private System.Windows.Forms.RadioButton optYesVendor;
        protected System.Windows.Forms.GroupBox gbCustomer;
        private System.Windows.Forms.RadioButton optNoCustomer;
        private System.Windows.Forms.RadioButton optYesCustomer;
        protected NewMethod.nEdit_List cboVendReimburse;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCharges;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbCharges;
        protected NewMethod.nEdit_Money ctl_taxamount;
        protected NewMethod.nEdit_Money ctl_handlingamount;
        protected NewMethod.nEdit_Money ctl_shippingamount;
        protected System.Windows.Forms.Label lblPaid;
        protected System.Windows.Forms.Label label2;
        public NewMethod.nEdit_List ctl_terms;
    }
}
