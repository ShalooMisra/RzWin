using Tools.Database;
namespace Rz5
{
    partial class ViewHeaderService
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCharges = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabServices = new System.Windows.Forms.TabPage();
            this.gbService = new System.Windows.Forms.GroupBox();
            this.ctl_harmonized_code = new NewMethod.nEdit_String();
            this.ctl_service_notes = new NewMethod.nEdit_Memo();
            this.ctlServiceName = new NewMethod.nEdit_List();
            this.lblServiceTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctlServiceCost = new NewMethod.nEdit_Money();
            this.ctlServiceQuantity = new NewMethod.nEdit_Number();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lvServices = new NewMethod.nList();
            this.ctl_charge_service_to_customer = new NewMethod.nEdit_Boolean();
            this.gbCharges = new System.Windows.Forms.GroupBox();
            this.ctl_taxamount = new NewMethod.nEdit_Money();
            this.ctl_handlingamount = new NewMethod.nEdit_Money();
            this.ctl_shippingamount = new NewMethod.nEdit_Money();
            this.ctl_terms = new NewMethod.nEdit_List();
            this.lblVendorCreditAmount = new System.Windows.Forms.Label();
            this.lblVendorCreditAlert = new System.Windows.Forms.Label();
            this.lblCreditAmount = new System.Windows.Forms.Label();
            this.lblAppliedCredits = new System.Windows.Forms.Label();
            this.gbTotals.SuspendLayout();
            this.gbAction1.SuspendLayout();
            this.gbAction2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.tabLines.SuspendLayout();
            this.tsDetails.SuspendLayout();
            this.gbReport.SuspendLayout();
            this.tabNotes.SuspendLayout();
            this.tabOther.SuspendLayout();
            this.tabShipping.SuspendLayout();
            this.tabAddress.SuspendLayout();
            this.tabCompany.SuspendLayout();
            this.ts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabServices.SuspendLayout();
            this.gbService.SuspendLayout();
            this.gbCharges.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTotals
            // 
            this.gbTotals.Controls.Add(this.lblCreditAmount);
            this.gbTotals.Controls.Add(this.lblAppliedCredits);
            this.gbTotals.Controls.Add(this.pictureBox2);
            this.gbTotals.Controls.Add(this.lblTotal);
            this.gbTotals.Controls.Add(this.label5);
            this.gbTotals.Controls.Add(this.lblCharges);
            this.gbTotals.Controls.Add(this.label6);
            this.gbTotals.Controls.Add(this.lblSubTotal);
            this.gbTotals.Controls.Add(this.label3);
            this.gbTotals.Location = new System.Drawing.Point(647, 210);
            this.gbTotals.Size = new System.Drawing.Size(255, 139);
            // 
            // picHeader
            // 
            this.picHeader.BackgroundImage = global::RzInterfaceWin.Properties.Resources.SplitBar;
            // 
            // tabAttachments
            // 
            this.tabAttachments.Size = new System.Drawing.Size(1336, 566);
            // 
            // tabLines
            // 
            this.tabLines.Size = new System.Drawing.Size(1336, 566);
            // 
            // details
            // 
            this.details.Size = new System.Drawing.Size(1328, 558);
            this.details.zz_OrderLineType = "service";
            // 
            // tsDetails
            // 
            this.tsDetails.Controls.Add(this.tabServices);
            this.tsDetails.TabIndexChanged += new System.EventHandler(this.tsDetails_TabIndexChanged);
            this.tsDetails.Controls.SetChildIndex(this.tabAttachments, 0);
            this.tsDetails.Controls.SetChildIndex(this.tabLines, 0);
            this.tsDetails.Controls.SetChildIndex(this.tabServices, 0);
            // 
            // tabNotes
            // 
            this.tabNotes.Size = new System.Drawing.Size(628, 256);
            // 
            // tabOther
            // 
            this.tabOther.Controls.Add(this.ctl_charge_service_to_customer);
            this.tabOther.Size = new System.Drawing.Size(628, 256);
            this.tabOther.Controls.SetChildIndex(this.ctl_charge_service_to_customer, 0);
            this.tabOther.Controls.SetChildIndex(this.ctl_senttoqb, 0);
            this.tabOther.Controls.SetChildIndex(this.ctl_is_confirmed, 0);
            // 
            // ctl_is_confirmed
            // 
            this.ctl_is_confirmed.Location = new System.Drawing.Point(196, 9);
            this.ctl_is_confirmed.TabIndex = 25;
            // 
            // ctl_senttoqb
            // 
            this.ctl_senttoqb.TabIndex = 24;
            // 
            // tabShipping
            // 
            this.tabShipping.Size = new System.Drawing.Size(628, 256);
            // 
            // cmdSetShipAccounts
            // 
            this.cmdSetShipAccounts.TabIndex = 20;
            // 
            // cmdSetShipVia
            // 
            this.cmdSetShipVia.TabIndex = 18;
            // 
            // ctl_trackingnumber
            // 
            this.ctl_trackingnumber.TabIndex = 23;
            // 
            // lvAccount
            // 
            this.lvAccount.TabIndex = 22;
            // 
            // lvShipVia
            // 
            this.lvShipVia.TabIndex = 21;
            // 
            // ctl_shippingaccount
            // 
            this.ctl_shippingaccount.Size = new System.Drawing.Size(249, 40);
            this.ctl_shippingaccount.TabIndex = 19;
            // 
            // ctl_shipvia
            // 
            this.ctl_shipvia.Size = new System.Drawing.Size(249, 40);
            this.ctl_shipvia.TabIndex = 17;
            // 
            // cmdPasteBill
            // 
            this.cmdPasteBill.Location = new System.Drawing.Point(234, 66);
            this.cmdPasteBill.TabIndex = 10;
            // 
            // cmdSwitchAddress
            // 
            this.cmdSwitchAddress.Location = new System.Drawing.Point(296, 209);
            this.cmdSwitchAddress.TabIndex = 15;
            // 
            // lblAddNewShiping
            // 
            this.lblAddNewShiping.Location = new System.Drawing.Point(329, 76);
            this.lblAddNewShiping.TabIndex = 11;
            // 
            // lblAddNewBilling
            // 
            this.lblAddNewBilling.TabIndex = 9;
            // 
            // cmdShipBill
            // 
            this.cmdShipBill.Location = new System.Drawing.Point(296, 168);
            this.cmdShipBill.TabIndex = 14;
            // 
            // cmdBillShip
            // 
            this.cmdBillShip.Location = new System.Drawing.Point(296, 127);
            this.cmdBillShip.TabIndex = 13;
            // 
            // ctl_shippingaddress
            // 
            this.ctl_shippingaddress.Location = new System.Drawing.Point(333, 98);
            this.ctl_shippingaddress.Size = new System.Drawing.Size(288, 148);
            this.ctl_shippingaddress.TabIndex = 16;
            // 
            // ctl_billingaddress
            // 
            this.ctl_billingaddress.TabIndex = 12;
            // 
            // cboBillingAddress
            // 
            this.cboBillingAddress.TabIndex = 7;
            // 
            // cboShippingAddress
            // 
            this.cboShippingAddress.Location = new System.Drawing.Point(333, 33);
            this.cboShippingAddress.Size = new System.Drawing.Size(288, 22);
            this.cboShippingAddress.TabIndex = 8;
            // 
            // ctl_shippingname
            // 
            this.ctl_shippingname.Location = new System.Drawing.Point(333, 4);
            this.ctl_shippingname.Size = new System.Drawing.Size(288, 22);
            this.ctl_shippingname.TabIndex = 6;
            // 
            // ctl_billingname
            // 
            this.ctl_billingname.TabIndex = 5;
            // 
            // tabCompany
            // 
            this.tabCompany.Controls.Add(this.lblVendorCreditAmount);
            this.tabCompany.Controls.Add(this.lblVendorCreditAlert);
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
            this.tabCompany.Controls.SetChildIndex(this.lblVendorCreditAlert, 0);
            this.tabCompany.Controls.SetChildIndex(this.lblVendorCreditAmount, 0);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Silver;
            this.pictureBox2.Location = new System.Drawing.Point(69, 94);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(119, 1);
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(66, 101);
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
            this.label5.Location = new System.Drawing.Point(10, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 26;
            this.label5.Text = "Total:";
            // 
            // lblCharges
            // 
            this.lblCharges.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharges.Location = new System.Drawing.Point(68, 46);
            this.lblCharges.Name = "lblCharges";
            this.lblCharges.Size = new System.Drawing.Size(127, 21);
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
            this.label6.Location = new System.Drawing.Point(10, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "Charges:";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(68, 27);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(127, 21);
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
            this.label3.Location = new System.Drawing.Point(10, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Subtotal:";
            // 
            // tabServices
            // 
            this.tabServices.Controls.Add(this.gbService);
            this.tabServices.Controls.Add(this.lvServices);
            this.tabServices.Location = new System.Drawing.Point(4, 22);
            this.tabServices.Name = "tabServices";
            this.tabServices.Size = new System.Drawing.Size(1336, 566);
            this.tabServices.TabIndex = 2;
            this.tabServices.Text = "Services";
            this.tabServices.UseVisualStyleBackColor = true;
            // 
            // gbService
            // 
            this.gbService.BackColor = System.Drawing.Color.White;
            this.gbService.Controls.Add(this.ctl_harmonized_code);
            this.gbService.Controls.Add(this.ctl_service_notes);
            this.gbService.Controls.Add(this.ctlServiceName);
            this.gbService.Controls.Add(this.lblServiceTotal);
            this.gbService.Controls.Add(this.label1);
            this.gbService.Controls.Add(this.ctlServiceCost);
            this.gbService.Controls.Add(this.ctlServiceQuantity);
            this.gbService.Controls.Add(this.cmdSave);
            this.gbService.Location = new System.Drawing.Point(30, 301);
            this.gbService.Name = "gbService";
            this.gbService.Size = new System.Drawing.Size(1132, 172);
            this.gbService.TabIndex = 3;
            this.gbService.TabStop = false;
            // 
            // ctl_harmonized_code
            // 
            this.ctl_harmonized_code.AllCaps = false;
            this.ctl_harmonized_code.BackColor = System.Drawing.Color.Transparent;
            this.ctl_harmonized_code.Bold = false;
            this.ctl_harmonized_code.Caption = "Harmonized Code";
            this.ctl_harmonized_code.Changed = false;
            this.ctl_harmonized_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_harmonized_code.IsEmail = false;
            this.ctl_harmonized_code.IsURL = false;
            this.ctl_harmonized_code.Location = new System.Drawing.Point(958, 31);
            this.ctl_harmonized_code.Name = "ctl_harmonized_code";
            this.ctl_harmonized_code.PasswordChar = '\0';
            this.ctl_harmonized_code.Size = new System.Drawing.Size(127, 41);
            this.ctl_harmonized_code.TabIndex = 43;
            this.ctl_harmonized_code.UseParentBackColor = false;
            this.ctl_harmonized_code.zz_Enabled = true;
            this.ctl_harmonized_code.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_harmonized_code.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_harmonized_code.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_harmonized_code.zz_LabelFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_harmonized_code.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_harmonized_code.zz_OriginalDesign = false;
            this.ctl_harmonized_code.zz_ShowLinkButton = false;
            this.ctl_harmonized_code.zz_ShowNeedsSaveColor = true;
            this.ctl_harmonized_code.zz_Text = "";
            this.ctl_harmonized_code.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_harmonized_code.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_harmonized_code.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_harmonized_code.zz_UseGlobalColor = false;
            this.ctl_harmonized_code.zz_UseGlobalFont = false;
            // 
            // ctl_service_notes
            // 
            this.ctl_service_notes.BackColor = System.Drawing.Color.Transparent;
            this.ctl_service_notes.Bold = false;
            this.ctl_service_notes.Caption = "Service Notes";
            this.ctl_service_notes.Changed = false;
            this.ctl_service_notes.DateLines = false;
            this.ctl_service_notes.Location = new System.Drawing.Point(556, 10);
            this.ctl_service_notes.Name = "ctl_service_notes";
            this.ctl_service_notes.Size = new System.Drawing.Size(389, 153);
            this.ctl_service_notes.TabIndex = 42;
            this.ctl_service_notes.UseParentBackColor = false;
            this.ctl_service_notes.zz_Enabled = true;
            this.ctl_service_notes.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_service_notes.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_service_notes.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_service_notes.zz_LabelFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_service_notes.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_service_notes.zz_OriginalDesign = false;
            this.ctl_service_notes.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_service_notes.zz_ShowNeedsSaveColor = true;
            this.ctl_service_notes.zz_Text = "";
            this.ctl_service_notes.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_service_notes.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_service_notes.zz_UseGlobalColor = false;
            this.ctl_service_notes.zz_UseGlobalFont = false;
            // 
            // ctlServiceName
            // 
            this.ctlServiceName.AllCaps = false;
            this.ctlServiceName.AllowEdit = false;
            this.ctlServiceName.BackColor = System.Drawing.Color.Transparent;
            this.ctlServiceName.Bold = false;
            this.ctlServiceName.Caption = "Service Name";
            this.ctlServiceName.Changed = false;
            this.ctlServiceName.ListName = "service_list";
            this.ctlServiceName.Location = new System.Drawing.Point(7, 10);
            this.ctlServiceName.Margin = new System.Windows.Forms.Padding(5);
            this.ctlServiceName.Name = "ctlServiceName";
            this.ctlServiceName.SimpleList = null;
            this.ctlServiceName.Size = new System.Drawing.Size(522, 48);
            this.ctlServiceName.TabIndex = 41;
            this.ctlServiceName.UseParentBackColor = false;
            this.ctlServiceName.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctlServiceName.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlServiceName.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceName.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlServiceName.zz_LabelFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceName.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctlServiceName.zz_OriginalDesign = false;
            this.ctlServiceName.zz_ShowNeedsSaveColor = true;
            this.ctlServiceName.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlServiceName.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceName.zz_UseGlobalColor = false;
            this.ctlServiceName.zz_UseGlobalFont = false;
            // 
            // lblServiceTotal
            // 
            this.lblServiceTotal.AutoSize = true;
            this.lblServiceTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceTotal.Location = new System.Drawing.Point(397, 85);
            this.lblServiceTotal.Name = "lblServiceTotal";
            this.lblServiceTotal.Size = new System.Drawing.Size(49, 19);
            this.lblServiceTotal.TabIndex = 40;
            this.lblServiceTotal.Text = "(total)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(350, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 19);
            this.label1.TabIndex = 39;
            this.label1.Text = "Total:";
            // 
            // ctlServiceCost
            // 
            this.ctlServiceCost.BackColor = System.Drawing.Color.White;
            this.ctlServiceCost.Bold = false;
            this.ctlServiceCost.Caption = "Service Unit Cost";
            this.ctlServiceCost.Changed = false;
            this.ctlServiceCost.EditCaption = false;
            this.ctlServiceCost.FullDecimal = false;
            this.ctlServiceCost.Location = new System.Drawing.Point(176, 65);
            this.ctlServiceCost.Margin = new System.Windows.Forms.Padding(16, 28, 16, 28);
            this.ctlServiceCost.Name = "ctlServiceCost";
            this.ctlServiceCost.RoundNearestCent = false;
            this.ctlServiceCost.Size = new System.Drawing.Size(155, 48);
            this.ctlServiceCost.TabIndex = 38;
            this.ctlServiceCost.UseParentBackColor = true;
            this.ctlServiceCost.zz_Enabled = true;
            this.ctlServiceCost.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlServiceCost.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlServiceCost.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlServiceCost.zz_LabelFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceCost.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctlServiceCost.zz_OriginalDesign = false;
            this.ctlServiceCost.zz_ShowErrorColor = true;
            this.ctlServiceCost.zz_ShowNeedsSaveColor = true;
            this.ctlServiceCost.zz_Text = "";
            this.ctlServiceCost.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctlServiceCost.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlServiceCost.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceCost.zz_UseGlobalColor = false;
            this.ctlServiceCost.zz_UseGlobalFont = false;
            this.ctlServiceCost.DataChanged += new NewMethod.ChangeHandler(this.ctlServiceCost_DataChanged);
            // 
            // ctlServiceQuantity
            // 
            this.ctlServiceQuantity.BackColor = System.Drawing.Color.White;
            this.ctlServiceQuantity.Bold = false;
            this.ctlServiceQuantity.Caption = "Service Quantity";
            this.ctlServiceQuantity.Changed = false;
            this.ctlServiceQuantity.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctlServiceQuantity.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceQuantity.Location = new System.Drawing.Point(7, 65);
            this.ctlServiceQuantity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctlServiceQuantity.Name = "ctlServiceQuantity";
            this.ctlServiceQuantity.Size = new System.Drawing.Size(149, 48);
            this.ctlServiceQuantity.TabIndex = 27;
            this.ctlServiceQuantity.UseParentBackColor = true;
            this.ctlServiceQuantity.zz_Enabled = true;
            this.ctlServiceQuantity.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlServiceQuantity.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlServiceQuantity.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlServiceQuantity.zz_LabelFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceQuantity.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctlServiceQuantity.zz_OriginalDesign = false;
            this.ctlServiceQuantity.zz_ShowErrorColor = true;
            this.ctlServiceQuantity.zz_ShowNeedsSaveColor = true;
            this.ctlServiceQuantity.zz_Text = "";
            this.ctlServiceQuantity.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctlServiceQuantity.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlServiceQuantity.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceQuantity.zz_UseGlobalColor = false;
            this.ctlServiceQuantity.zz_UseGlobalFont = false;
            this.ctlServiceQuantity.DataChanged += new NewMethod.ChangeHandler(this.ctlServiceQuantity_DataChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(7, 123);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(523, 40);
            this.cmdSave.TabIndex = 1;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lvServices
            // 
            this.lvServices.AddCaption = "Add New";
            this.lvServices.AllowActions = true;
            this.lvServices.AllowAdd = false;
            this.lvServices.AllowDelete = true;
            this.lvServices.AllowDeleteAlways = false;
            this.lvServices.AllowDrop = true;
            this.lvServices.AllowOnlyOpenDelete = false;
            this.lvServices.AlternateConnection = null;
            this.lvServices.BackColor = System.Drawing.Color.White;
            this.lvServices.Caption = "";
            this.lvServices.CurrentTemplate = null;
            this.lvServices.ExtraClassInfo = "";
            this.lvServices.Location = new System.Drawing.Point(215, 21);
            this.lvServices.Margin = new System.Windows.Forms.Padding(4);
            this.lvServices.MultiSelect = true;
            this.lvServices.Name = "lvServices";
            this.lvServices.Size = new System.Drawing.Size(537, 268);
            this.lvServices.SuppressSelectionChanged = false;
            this.lvServices.TabIndex = 2;
            this.lvServices.zz_OpenColumnMenu = false;
            this.lvServices.zz_OrderLineType = "";
            this.lvServices.zz_ShowAutoRefresh = true;
            this.lvServices.zz_ShowUnlimited = true;
            this.lvServices.AboutToThrow += new Core.ShowHandler(this.lvServices_AboutToThrow);
            this.lvServices.AboutToAdd += new NewMethod.AddHandler(this.lvServices_AboutToAdd);
            this.lvServices.AboutToAction += new NewMethod.ActionHandler(this.lvServices_AboutToAction);
            // 
            // ctl_charge_service_to_customer
            // 
            this.ctl_charge_service_to_customer.BackColor = System.Drawing.Color.Transparent;
            this.ctl_charge_service_to_customer.Bold = false;
            this.ctl_charge_service_to_customer.Caption = "Charged Service To Customer";
            this.ctl_charge_service_to_customer.Changed = false;
            this.ctl_charge_service_to_customer.Enabled = false;
            this.ctl_charge_service_to_customer.Location = new System.Drawing.Point(330, 9);
            this.ctl_charge_service_to_customer.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_charge_service_to_customer.Name = "ctl_charge_service_to_customer";
            this.ctl_charge_service_to_customer.Size = new System.Drawing.Size(168, 18);
            this.ctl_charge_service_to_customer.TabIndex = 26;
            this.ctl_charge_service_to_customer.UseParentBackColor = false;
            this.ctl_charge_service_to_customer.zz_CheckValue = false;
            this.ctl_charge_service_to_customer.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_charge_service_to_customer.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_charge_service_to_customer.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_charge_service_to_customer.zz_OriginalDesign = false;
            this.ctl_charge_service_to_customer.zz_ShowNeedsSaveColor = true;
            // 
            // gbCharges
            // 
            this.gbCharges.BackColor = System.Drawing.Color.White;
            this.gbCharges.Controls.Add(this.ctl_taxamount);
            this.gbCharges.Controls.Add(this.ctl_handlingamount);
            this.gbCharges.Controls.Add(this.ctl_shippingamount);
            this.gbCharges.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCharges.Location = new System.Drawing.Point(909, 214);
            this.gbCharges.Name = "gbCharges";
            this.gbCharges.Size = new System.Drawing.Size(183, 135);
            this.gbCharges.TabIndex = 50;
            this.gbCharges.TabStop = false;
            this.gbCharges.Text = "Charges";
            this.gbCharges.Visible = false;
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
            // ctl_terms
            // 
            this.ctl_terms.AllCaps = false;
            this.ctl_terms.AllowEdit = false;
            this.ctl_terms.BackColor = System.Drawing.Color.Transparent;
            this.ctl_terms.Bold = false;
            this.ctl_terms.Caption = "Terms";
            this.ctl_terms.Changed = false;
            this.ctl_terms.ListName = "terms";
            this.ctl_terms.Location = new System.Drawing.Point(399, 211);
            this.ctl_terms.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_terms.Name = "ctl_terms";
            this.ctl_terms.SimpleList = null;
            this.ctl_terms.Size = new System.Drawing.Size(198, 28);
            this.ctl_terms.TabIndex = 24;
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
            // lblVendorCreditAmount
            // 
            this.lblVendorCreditAmount.AutoSize = true;
            this.lblVendorCreditAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendorCreditAmount.ForeColor = System.Drawing.Color.Red;
            this.lblVendorCreditAmount.Location = new System.Drawing.Point(544, 128);
            this.lblVendorCreditAmount.Name = "lblVendorCreditAmount";
            this.lblVendorCreditAmount.Size = new System.Drawing.Size(52, 17);
            this.lblVendorCreditAmount.TabIndex = 53;
            this.lblVendorCreditAmount.Text = "label1";
            this.lblVendorCreditAmount.Visible = false;
            // 
            // lblVendorCreditAlert
            // 
            this.lblVendorCreditAlert.AutoSize = true;
            this.lblVendorCreditAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendorCreditAlert.ForeColor = System.Drawing.Color.Red;
            this.lblVendorCreditAlert.Location = new System.Drawing.Point(349, 128);
            this.lblVendorCreditAlert.Name = "lblVendorCreditAlert";
            this.lblVendorCreditAlert.Size = new System.Drawing.Size(189, 17);
            this.lblVendorCreditAlert.TabIndex = 52;
            this.lblVendorCreditAlert.Text = "Vendor Credit Available: ";
            this.lblVendorCreditAlert.Visible = false;
            // 
            // lblCreditAmount
            // 
            this.lblCreditAmount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblCreditAmount.Location = new System.Drawing.Point(68, 64);
            this.lblCreditAmount.Name = "lblCreditAmount";
            this.lblCreditAmount.Size = new System.Drawing.Size(127, 21);
            this.lblCreditAmount.TabIndex = 30;
            this.lblCreditAmount.Text = "$ 1,123,456.67";
            this.lblCreditAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAppliedCredits
            // 
            this.lblAppliedCredits.AutoSize = true;
            this.lblAppliedCredits.BackColor = System.Drawing.Color.White;
            this.lblAppliedCredits.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppliedCredits.ForeColor = System.Drawing.Color.Silver;
            this.lblAppliedCredits.Location = new System.Drawing.Point(10, 65);
            this.lblAppliedCredits.Name = "lblAppliedCredits";
            this.lblAppliedCredits.Size = new System.Drawing.Size(49, 15);
            this.lblAppliedCredits.TabIndex = 29;
            this.lblAppliedCredits.Text = "Credits:";
            // 
            // ViewHeaderService
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.gbCharges);
            this.Name = "ViewHeaderService";
            this.Load += new System.EventHandler(this.ViewHeaderService_Load_1);
            this.Controls.SetChildIndex(this.gbReport, 0);
            this.Controls.SetChildIndex(this.gbTotals, 0);
            this.Controls.SetChildIndex(this.picHeader, 0);
            this.Controls.SetChildIndex(this.ts, 0);
            this.Controls.SetChildIndex(this.gbAction1, 0);
            this.Controls.SetChildIndex(this.tsDetails, 0);
            this.Controls.SetChildIndex(this.gbAction2, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.Controls.SetChildIndex(this.gbCharges, 0);
            this.gbTotals.ResumeLayout(false);
            this.gbTotals.PerformLayout();
            this.gbAction1.ResumeLayout(false);
            this.gbAction1.PerformLayout();
            this.gbAction2.ResumeLayout(false);
            this.gbAction2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.tabLines.ResumeLayout(false);
            this.tabLines.PerformLayout();
            this.tsDetails.ResumeLayout(false);
            this.gbReport.ResumeLayout(false);
            this.tabNotes.ResumeLayout(false);
            this.tabOther.ResumeLayout(false);
            this.tabShipping.ResumeLayout(false);
            this.tabAddress.ResumeLayout(false);
            this.tabAddress.PerformLayout();
            this.tabCompany.ResumeLayout(false);
            this.tabCompany.PerformLayout();
            this.ts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabServices.ResumeLayout(false);
            this.gbService.ResumeLayout(false);
            this.gbService.PerformLayout();
            this.gbCharges.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCharges;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabServices;
        protected System.Windows.Forms.GroupBox gbService;
        protected System.Windows.Forms.Label lblServiceTotal;
        protected System.Windows.Forms.Label label1;
        protected NewMethod.nEdit_Money ctlServiceCost;
        protected NewMethod.nEdit_Number ctlServiceQuantity;
        protected System.Windows.Forms.Button cmdSave;
        protected NewMethod.nList lvServices;
        private NewMethod.nEdit_Boolean ctl_charge_service_to_customer;
        protected NewMethod.nEdit_List ctlServiceName;
        private System.Windows.Forms.GroupBox gbCharges;
        protected NewMethod.nEdit_Money ctl_taxamount;
        protected NewMethod.nEdit_Money ctl_handlingamount;
        protected NewMethod.nEdit_Money ctl_shippingamount;
        public NewMethod.nEdit_List ctl_terms;
        private System.Windows.Forms.Label lblVendorCreditAmount;
        private System.Windows.Forms.Label lblVendorCreditAlert;
        protected System.Windows.Forms.Label lblCreditAmount;
        protected System.Windows.Forms.Label lblAppliedCredits;
        private NewMethod.nEdit_Memo ctl_service_notes;
        private NewMethod.nEdit_String ctl_harmonized_code;
    }
}
