namespace Rz5
{
    partial class ViewHeaderInvoice
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
            this.ctl_terms = new NewMethod.nEdit_List();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblPayoutTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCharges = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctl_orderreference = new NewMethod.nEdit_String();
            this.lblCreditsAmnt = new System.Windows.Forms.Label();
            this.lblCredits = new System.Windows.Forms.Label();
            this.lblPaid = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFinancials = new System.Windows.Forms.Label();
            this.lblOutstandingAmnt = new System.Windows.Forms.Label();
            this.lblOutstanding = new System.Windows.Forms.Label();
            this.lblNetProfitAmnt = new System.Windows.Forms.Label();
            this.lblNetProfit = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctl_override_stock_commission = new System.Windows.Forms.CheckBox();
            this.btn_edit_commission_percent = new System.Windows.Forms.Button();
            this.ctl_commission_percent = new NewMethod.nEdit_Number();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCompanyCredits = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblInvoiceTotal = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboBillingAddress
            // 
            this.cboBillingAddress.Size = new System.Drawing.Size(291, 22);
            this.cboBillingAddress.TabIndex = 16;
            // 
            // cboShippingAddress
            // 
            this.cboShippingAddress.Location = new System.Drawing.Point(346, 33);
            this.cboShippingAddress.Size = new System.Drawing.Size(271, 22);
            this.cboShippingAddress.TabIndex = 17;
            // 
            // tabCompany
            // 
            this.tabCompany.Controls.Add(this.groupBox1);
            this.tabCompany.Controls.Add(this.lblFinancials);
            this.tabCompany.Controls.Add(this.ctl_orderreference);
            this.tabCompany.Controls.Add(this.ctl_terms);
            this.tabCompany.Controls.SetChildIndex(this.ctl_terms, 0);
            this.tabCompany.Controls.SetChildIndex(this.ctl_orderreference, 0);
            this.tabCompany.Controls.SetChildIndex(this.lblFinancials, 0);
            this.tabCompany.Controls.SetChildIndex(this.cStub, 0);
            this.tabCompany.Controls.SetChildIndex(this.agent, 0);
            this.tabCompany.Controls.SetChildIndex(this.ctl_primaryemailaddress, 0);
            this.tabCompany.Controls.SetChildIndex(this.ctl_primaryfax, 0);
            this.tabCompany.Controls.SetChildIndex(this.ctl_primaryphone, 0);
            this.tabCompany.Controls.SetChildIndex(this.nlblorderdate, 0);
            this.tabCompany.Controls.SetChildIndex(this.nlblordertime, 0);
            this.tabCompany.Controls.SetChildIndex(this.lblChangeDate, 0);
            this.tabCompany.Controls.SetChildIndex(this.groupBox1, 0);
            // 
            // ctl_internalcomment
            // 
            this.ctl_internalcomment.TabIndex = 35;
            // 
            // ctl_printcomment
            // 
            this.ctl_printcomment.TabIndex = 36;
            // 
            // ctl_shippingname
            // 
            this.ctl_shippingname.Location = new System.Drawing.Point(347, 4);
            this.ctl_shippingname.Size = new System.Drawing.Size(270, 22);
            this.ctl_shippingname.TabIndex = 15;
            // 
            // ctl_shippingaddress
            // 
            this.ctl_shippingaddress.Location = new System.Drawing.Point(346, 98);
            this.ctl_shippingaddress.Size = new System.Drawing.Size(271, 148);
            this.ctl_shippingaddress.TabIndex = 25;
            // 
            // ctl_billingaddress
            // 
            this.ctl_billingaddress.TabIndex = 21;
            // 
            // cmdShipBill
            // 
            this.cmdShipBill.Location = new System.Drawing.Point(299, 150);
            this.cmdShipBill.TabIndex = 23;
            // 
            // cmdBillShip
            // 
            this.cmdBillShip.Location = new System.Drawing.Point(299, 110);
            this.cmdBillShip.TabIndex = 22;
            // 
            // lblAddNewShiping
            // 
            this.lblAddNewShiping.Location = new System.Drawing.Point(342, 71);
            this.lblAddNewShiping.TabIndex = 20;
            // 
            // lblAddNewBilling
            // 
            this.lblAddNewBilling.TabIndex = 18;
            // 
            // cmdSwitchAddress
            // 
            this.cmdSwitchAddress.Location = new System.Drawing.Point(299, 189);
            this.cmdSwitchAddress.TabIndex = 24;
            // 
            // cmdPasteBill
            // 
            this.cmdPasteBill.Location = new System.Drawing.Point(234, 65);
            this.cmdPasteBill.TabIndex = 19;
            // 
            // ctl_primaryemailaddress
            // 
            this.ctl_primaryemailaddress.TabIndex = 5;
            // 
            // gbTotals
            // 
            this.gbTotals.Controls.Add(this.lblSubTotal);
            this.gbTotals.Controls.Add(this.lblInvoiceTotal);
            this.gbTotals.Controls.Add(this.lblCompanyCredits);
            this.gbTotals.Controls.Add(this.label7);
            this.gbTotals.Controls.Add(this.label4);
            this.gbTotals.Controls.Add(this.lblNetProfitAmnt);
            this.gbTotals.Controls.Add(this.lblNetProfit);
            this.gbTotals.Controls.Add(this.lblOutstandingAmnt);
            this.gbTotals.Controls.Add(this.lblOutstanding);
            this.gbTotals.Controls.Add(this.lblPaid);
            this.gbTotals.Controls.Add(this.label2);
            this.gbTotals.Controls.Add(this.lblCreditsAmnt);
            this.gbTotals.Controls.Add(this.lblCredits);
            this.gbTotals.Controls.Add(this.pictureBox2);
            this.gbTotals.Controls.Add(this.lblPayoutTotal);
            this.gbTotals.Controls.Add(this.label5);
            this.gbTotals.Controls.Add(this.lblCharges);
            this.gbTotals.Controls.Add(this.label6);
            this.gbTotals.Controls.Add(this.label3);
            this.gbTotals.Location = new System.Drawing.Point(645, 187);
            this.gbTotals.Size = new System.Drawing.Size(400, 159);
            this.gbTotals.Enter += new System.EventHandler(this.gbTotals_Enter);
            // 
            // gbAction1
            // 
            this.gbAction1.Size = new System.Drawing.Size(260, 173);
            // 
            // gbAction2
            // 
            this.gbAction2.Size = new System.Drawing.Size(260, 172);
            // 
            // picHeader
            // 
            this.picHeader.BackgroundImage = global::RzInterfaceWin.Properties.Resources.GreenBar1;
            // 
            // ctl_shipvia
            // 
            this.ctl_shipvia.Size = new System.Drawing.Size(249, 40);
            this.ctl_shipvia.TabIndex = 26;
            // 
            // lvAccount
            // 
            this.lvAccount.TabIndex = 31;
            // 
            // lvShipVia
            // 
            this.lvShipVia.TabIndex = 30;
            // 
            // ctl_trackingnumber
            // 
            this.ctl_trackingnumber.TabIndex = 32;
            // 
            // ctl_shippingaccount
            // 
            this.ctl_shippingaccount.Size = new System.Drawing.Size(249, 40);
            this.ctl_shippingaccount.TabIndex = 28;
            // 
            // cmdSetShipAccounts
            // 
            this.cmdSetShipAccounts.TabIndex = 29;
            // 
            // cmdSetShipVia
            // 
            this.cmdSetShipVia.TabIndex = 27;
            // 
            // ctl_senttoqb
            // 
            this.ctl_senttoqb.TabIndex = 33;
            // 
            // ctl_is_confirmed
            // 
            this.ctl_is_confirmed.TabIndex = 34;
            // 
            // tabAttachments
            // 
            this.tabAttachments.Size = new System.Drawing.Size(1397, 388);
            // 
            // tabLines
            // 
            this.tabLines.Size = new System.Drawing.Size(1397, 388);
            // 
            // details
            // 
            this.details.Size = new System.Drawing.Size(1389, 380);
            this.details.zz_OrderLineType = "invoice";
            // 
            // tsDetails
            // 
            this.tsDetails.Size = new System.Drawing.Size(1405, 414);
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(1408, 0);
            this.xActions.Size = new System.Drawing.Size(148, 768);
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
            this.ctl_terms.TabIndex = 6;
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
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Silver;
            this.pictureBox2.Location = new System.Drawing.Point(65, 95);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(272, 1);
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // lblPayoutTotal
            // 
            this.lblPayoutTotal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayoutTotal.Location = new System.Drawing.Point(259, 15);
            this.lblPayoutTotal.Name = "lblPayoutTotal";
            this.lblPayoutTotal.Size = new System.Drawing.Size(128, 21);
            this.lblPayoutTotal.TabIndex = 19;
            this.lblPayoutTotal.Text = "$ 1,123,456.67";
            this.lblPayoutTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPayoutTotal.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(196, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Payout:";
            this.label5.Visible = false;
            // 
            // lblCharges
            // 
            this.lblCharges.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharges.Location = new System.Drawing.Point(79, 36);
            this.lblCharges.Name = "lblCharges";
            this.lblCharges.Size = new System.Drawing.Size(128, 21);
            this.lblCharges.TabIndex = 17;
            this.lblCharges.Text = "$ 1,123,456.67";
            this.lblCharges.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCharges.Click += new System.EventHandler(this.lblCharges_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(8, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Charges:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(8, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Inv Total:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ctl_orderreference
            // 
            this.ctl_orderreference.AllCaps = false;
            this.ctl_orderreference.BackColor = System.Drawing.Color.Transparent;
            this.ctl_orderreference.Bold = false;
            this.ctl_orderreference.Caption = "PO#   ";
            this.ctl_orderreference.Changed = false;
            this.ctl_orderreference.IsEmail = false;
            this.ctl_orderreference.IsURL = false;
            this.ctl_orderreference.Location = new System.Drawing.Point(351, 168);
            this.ctl_orderreference.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_orderreference.Name = "ctl_orderreference";
            this.ctl_orderreference.PasswordChar = '\0';
            this.ctl_orderreference.Size = new System.Drawing.Size(198, 28);
            this.ctl_orderreference.TabIndex = 4;
            this.ctl_orderreference.UseParentBackColor = true;
            this.ctl_orderreference.zz_Enabled = true;
            this.ctl_orderreference.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_orderreference.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_orderreference.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_orderreference.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_orderreference.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctl_orderreference.zz_OriginalDesign = false;
            this.ctl_orderreference.zz_ShowLinkButton = false;
            this.ctl_orderreference.zz_ShowNeedsSaveColor = true;
            this.ctl_orderreference.zz_Text = "";
            this.ctl_orderreference.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_orderreference.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_orderreference.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_orderreference.zz_UseGlobalColor = false;
            this.ctl_orderreference.zz_UseGlobalFont = false;
            // 
            // lblCreditsAmnt
            // 
            this.lblCreditsAmnt.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditsAmnt.Location = new System.Drawing.Point(79, 55);
            this.lblCreditsAmnt.Name = "lblCreditsAmnt";
            this.lblCreditsAmnt.Size = new System.Drawing.Size(128, 21);
            this.lblCreditsAmnt.TabIndex = 23;
            this.lblCreditsAmnt.Text = "$ 1,123,456.67";
            this.lblCreditsAmnt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCredits
            // 
            this.lblCredits.AutoSize = true;
            this.lblCredits.BackColor = System.Drawing.Color.White;
            this.lblCredits.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredits.ForeColor = System.Drawing.Color.Silver;
            this.lblCredits.Location = new System.Drawing.Point(9, 58);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(65, 15);
            this.lblCredits.TabIndex = 22;
            this.lblCredits.Text = "Discounts:";
            // 
            // lblPaid
            // 
            this.lblPaid.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblPaid.Location = new System.Drawing.Point(271, 104);
            this.lblPaid.Name = "lblPaid";
            this.lblPaid.Size = new System.Drawing.Size(128, 21);
            this.lblPaid.TabIndex = 32;
            this.lblPaid.Text = "$ 1,123,456.67";
            this.lblPaid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(205, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 31;
            this.label2.Text = "Paid Amnt:";
            // 
            // lblFinancials
            // 
            this.lblFinancials.BackColor = System.Drawing.Color.Red;
            this.lblFinancials.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinancials.ForeColor = System.Drawing.Color.White;
            this.lblFinancials.Location = new System.Drawing.Point(446, 66);
            this.lblFinancials.Name = "lblFinancials";
            this.lblFinancials.Size = new System.Drawing.Size(158, 21);
            this.lblFinancials.TabIndex = 50;
            this.lblFinancials.Text = "Need Financials";
            this.lblFinancials.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblFinancials.Visible = false;
            // 
            // lblOutstandingAmnt
            // 
            this.lblOutstandingAmnt.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutstandingAmnt.Location = new System.Drawing.Point(271, 128);
            this.lblOutstandingAmnt.Name = "lblOutstandingAmnt";
            this.lblOutstandingAmnt.Size = new System.Drawing.Size(128, 21);
            this.lblOutstandingAmnt.TabIndex = 34;
            this.lblOutstandingAmnt.Text = "$ 1,123,456.67";
            this.lblOutstandingAmnt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOutstanding
            // 
            this.lblOutstanding.AutoSize = true;
            this.lblOutstanding.BackColor = System.Drawing.Color.White;
            this.lblOutstanding.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutstanding.ForeColor = System.Drawing.Color.Silver;
            this.lblOutstanding.Location = new System.Drawing.Point(206, 131);
            this.lblOutstanding.Name = "lblOutstanding";
            this.lblOutstanding.Size = new System.Drawing.Size(54, 15);
            this.lblOutstanding.TabIndex = 33;
            this.lblOutstanding.Text = "Balance:";
            // 
            // lblNetProfitAmnt
            // 
            this.lblNetProfitAmnt.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetProfitAmnt.Location = new System.Drawing.Point(79, 128);
            this.lblNetProfitAmnt.Name = "lblNetProfitAmnt";
            this.lblNetProfitAmnt.Size = new System.Drawing.Size(128, 21);
            this.lblNetProfitAmnt.TabIndex = 36;
            this.lblNetProfitAmnt.Text = "$ 1,123,456.67";
            this.lblNetProfitAmnt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNetProfit
            // 
            this.lblNetProfit.AutoSize = true;
            this.lblNetProfit.BackColor = System.Drawing.Color.White;
            this.lblNetProfit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetProfit.ForeColor = System.Drawing.Color.Silver;
            this.lblNetProfit.Location = new System.Drawing.Point(8, 131);
            this.lblNetProfit.Name = "lblNetProfit";
            this.lblNetProfit.Size = new System.Drawing.Size(61, 15);
            this.lblNetProfit.TabIndex = 35;
            this.lblNetProfit.Text = "Net Profit:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(508, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 28);
            this.button1.TabIndex = 55;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctl_override_stock_commission);
            this.groupBox1.Controls.Add(this.btn_edit_commission_percent);
            this.groupBox1.Controls.Add(this.ctl_commission_percent);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(349, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 53);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Commission";
            // 
            // ctl_override_stock_commission
            // 
            this.ctl_override_stock_commission.AutoSize = true;
            this.ctl_override_stock_commission.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctl_override_stock_commission.Enabled = false;
            this.ctl_override_stock_commission.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_override_stock_commission.Location = new System.Drawing.Point(129, 14);
            this.ctl_override_stock_commission.Name = "ctl_override_stock_commission";
            this.ctl_override_stock_commission.Size = new System.Drawing.Size(98, 31);
            this.ctl_override_stock_commission.TabIndex = 66;
            this.ctl_override_stock_commission.Tag = "Select this to override stock lines commission percent with this value.";
            this.ctl_override_stock_commission.Text = "O/R Stock Comm.";
            this.ctl_override_stock_commission.UseVisualStyleBackColor = true;
            this.ctl_override_stock_commission.CheckStateChanged += new System.EventHandler(this.ctl_override_stock_commission_CheckedChanged);
            // 
            // btn_edit_commission_percent
            // 
            this.btn_edit_commission_percent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit_commission_percent.Location = new System.Drawing.Point(82, 20);
            this.btn_edit_commission_percent.Name = "btn_edit_commission_percent";
            this.btn_edit_commission_percent.Size = new System.Drawing.Size(41, 28);
            this.btn_edit_commission_percent.TabIndex = 65;
            this.btn_edit_commission_percent.Text = "Edit";
            this.btn_edit_commission_percent.UseVisualStyleBackColor = true;
            this.btn_edit_commission_percent.Click += new System.EventHandler(this.btn_edit_commission_percent_Click);
            // 
            // ctl_commission_percent
            // 
            this.ctl_commission_percent.BackColor = System.Drawing.Color.Transparent;
            this.ctl_commission_percent.Bold = false;
            this.ctl_commission_percent.Caption = "%";
            this.ctl_commission_percent.Changed = false;
            this.ctl_commission_percent.CurrentType = Tools.Database.FieldType.Double;
            this.ctl_commission_percent.Enabled = false;
            this.ctl_commission_percent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_commission_percent.Location = new System.Drawing.Point(5, 20);
            this.ctl_commission_percent.Name = "ctl_commission_percent";
            this.ctl_commission_percent.Size = new System.Drawing.Size(67, 28);
            this.ctl_commission_percent.TabIndex = 64;
            this.ctl_commission_percent.UseParentBackColor = false;
            this.ctl_commission_percent.zz_Enabled = true;
            this.ctl_commission_percent.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_commission_percent.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_commission_percent.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_commission_percent.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_commission_percent.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.Left;
            this.ctl_commission_percent.zz_OriginalDesign = false;
            this.ctl_commission_percent.zz_ShowErrorColor = false;
            this.ctl_commission_percent.zz_ShowNeedsSaveColor = true;
            this.ctl_commission_percent.zz_Text = "";
            this.ctl_commission_percent.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_commission_percent.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_commission_percent.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_commission_percent.zz_UseGlobalColor = false;
            this.ctl_commission_percent.zz_UseGlobalFont = false;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(71, 104);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(128, 21);
            this.lblTotal.TabIndex = 19;
            this.lblTotal.Text = "$ 1,123,456.67";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(7, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 37;
            this.label4.Text = "Amnt Due:";
            // 
            // lblCompanyCredits
            // 
            this.lblCompanyCredits.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyCredits.Location = new System.Drawing.Point(79, 74);
            this.lblCompanyCredits.Name = "lblCompanyCredits";
            this.lblCompanyCredits.Size = new System.Drawing.Size(128, 21);
            this.lblCompanyCredits.TabIndex = 40;
            this.lblCompanyCredits.Text = "$ 1,123,456.67";
            this.lblCompanyCredits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(10, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 15);
            this.label7.TabIndex = 39;
            this.label7.Text = "Credits:";
            // 
            // lblInvoiceTotal
            // 
            this.lblInvoiceTotal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceTotal.Location = new System.Drawing.Point(80, 17);
            this.lblInvoiceTotal.Name = "lblInvoiceTotal";
            this.lblInvoiceTotal.Size = new System.Drawing.Size(128, 21);
            this.lblInvoiceTotal.TabIndex = 41;
            this.lblInvoiceTotal.Text = "$ 1,123,456.67";
            this.lblInvoiceTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(79, 105);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(128, 21);
            this.lblSubTotal.TabIndex = 42;
            this.lblSubTotal.Text = "$ 1,123,456.67";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ViewHeaderInvoice
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Name = "ViewHeaderInvoice";
            this.Size = new System.Drawing.Size(1556, 768);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public NewMethod.nEdit_List ctl_terms;
        private System.Windows.Forms.PictureBox pictureBox2;
        public NewMethod.nEdit_String ctl_orderreference;
        protected System.Windows.Forms.Label lblPayoutTotal;
        protected System.Windows.Forms.Label lblCharges;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label lblCreditsAmnt;
        protected System.Windows.Forms.Label lblCredits;
        protected System.Windows.Forms.Label lblPaid;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFinancials;
        protected System.Windows.Forms.Label lblOutstandingAmnt;
        protected System.Windows.Forms.Label lblOutstanding;
        protected System.Windows.Forms.Label lblNetProfitAmnt;
        protected System.Windows.Forms.Label lblNetProfit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ctl_override_stock_commission;
        private System.Windows.Forms.Button btn_edit_commission_percent;
        private NewMethod.nEdit_Number ctl_commission_percent;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label lblTotal;
        protected System.Windows.Forms.Label lblCompanyCredits;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.Label lblSubTotal;
        protected System.Windows.Forms.Label lblInvoiceTotal;
    }
}
