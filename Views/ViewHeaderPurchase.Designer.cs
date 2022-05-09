namespace Rz5
{
    partial class ViewHeaderPurchase
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
            this.ctl_terms = new NewMethod.nEdit_List();
            this.ctl_soreference = new NewMethod.nEdit_String();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCharges = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lnkTracking = new System.Windows.Forms.LinkLabel();
            this.tabCanceled = new System.Windows.Forms.TabPage();
            this.lvCanceled = new NewMethod.nList();
            this.lblCreditAmount = new System.Windows.Forms.Label();
            this.lblAppliedCredits = new System.Windows.Forms.Label();
            this.lvCharges = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdAddCharge = new System.Windows.Forms.Button();
            this.lblPaid = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctl_post_to_portal = new NewMethod.nEdit_Boolean();
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
            this.tabCanceled.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboBillingAddress
            // 
            this.cboBillingAddress.Size = new System.Drawing.Size(290, 22);
            this.cboBillingAddress.TabIndex = 9;
            // 
            // cboShippingAddress
            // 
            this.cboShippingAddress.TabIndex = 10;
            // 
            // tabCompany
            // 
            this.tabCompany.Controls.Add(this.ctl_post_to_portal);
            this.tabCompany.Controls.Add(this.ctl_soreference);
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
            this.tabCompany.Controls.SetChildIndex(this.ctl_soreference, 0);
            this.tabCompany.Controls.SetChildIndex(this.ctl_post_to_portal, 0);
            // 
            // tabAddress
            // 
            this.tabAddress.Size = new System.Drawing.Size(628, 256);
            // 
            // ctl_internalcomment
            // 
            this.ctl_internalcomment.TabIndex = 28;
            // 
            // ctl_printcomment
            // 
            this.ctl_printcomment.TabIndex = 29;
            // 
            // ctl_shippingname
            // 
            this.ctl_shippingname.TabIndex = 8;
            // 
            // ctl_billingname
            // 
            this.ctl_billingname.TabIndex = 7;
            // 
            // ctl_shippingaddress
            // 
            this.ctl_shippingaddress.TabIndex = 18;
            // 
            // ctl_billingaddress
            // 
            this.ctl_billingaddress.TabIndex = 14;
            // 
            // cmdShipBill
            // 
            this.cmdShipBill.TabIndex = 16;
            // 
            // cmdBillShip
            // 
            this.cmdBillShip.TabIndex = 15;
            // 
            // lblAddNewShiping
            // 
            this.lblAddNewShiping.TabIndex = 13;
            // 
            // lblAddNewBilling
            // 
            this.lblAddNewBilling.TabIndex = 11;
            // 
            // cmdSwitchAddress
            // 
            this.cmdSwitchAddress.TabIndex = 17;
            // 
            // cmdPasteBill
            // 
            this.cmdPasteBill.TabIndex = 12;
            // 
            // ctl_primaryemailaddress
            // 
            this.ctl_primaryemailaddress.TabIndex = 5;
            // 
            // agent
            // 
            this.agent.Caption = "Buying Agent";
            // 
            // gbTotals
            // 
            this.gbTotals.Controls.Add(this.lblPaid);
            this.gbTotals.Controls.Add(this.label2);
            this.gbTotals.Controls.Add(this.lblCreditAmount);
            this.gbTotals.Controls.Add(this.lblAppliedCredits);
            this.gbTotals.Controls.Add(this.pictureBox2);
            this.gbTotals.Controls.Add(this.lblTotal);
            this.gbTotals.Controls.Add(this.label5);
            this.gbTotals.Controls.Add(this.lblCharges);
            this.gbTotals.Controls.Add(this.label6);
            this.gbTotals.Controls.Add(this.lblSubTotal);
            this.gbTotals.Controls.Add(this.label3);
            this.gbTotals.Location = new System.Drawing.Point(647, 214);
            this.gbTotals.Size = new System.Drawing.Size(258, 132);
            // 
            // picHeader
            // 
            this.picHeader.BackgroundImage = global::RzInterfaceWin.Properties.Resources.BlueBar;
            // 
            // ctl_shipvia
            // 
            this.ctl_shipvia.Size = new System.Drawing.Size(249, 40);
            this.ctl_shipvia.TabIndex = 19;
            // 
            // lvAccount
            // 
            this.lvAccount.TabIndex = 24;
            // 
            // lvShipVia
            // 
            this.lvShipVia.TabIndex = 23;
            // 
            // ctl_trackingnumber
            // 
            this.ctl_trackingnumber.TabIndex = 25;
            // 
            // ctl_shippingaccount
            // 
            this.ctl_shippingaccount.Size = new System.Drawing.Size(249, 40);
            this.ctl_shippingaccount.TabIndex = 21;
            // 
            // cmdSetShipAccounts
            // 
            this.cmdSetShipAccounts.TabIndex = 22;
            // 
            // cmdSetShipVia
            // 
            this.cmdSetShipVia.TabIndex = 20;
            // 
            // ctl_senttoqb
            // 
            this.ctl_senttoqb.TabIndex = 26;
            // 
            // ctl_is_confirmed
            // 
            this.ctl_is_confirmed.TabIndex = 27;
            // 
            // tabShipping
            // 
            this.tabShipping.Controls.Add(this.lnkTracking);
            this.tabShipping.Controls.SetChildIndex(this.ctl_trackingnumber, 0);
            this.tabShipping.Controls.SetChildIndex(this.lnkTracking, 0);
            this.tabShipping.Controls.SetChildIndex(this.ctl_shipvia, 0);
            this.tabShipping.Controls.SetChildIndex(this.ctl_shippingaccount, 0);
            this.tabShipping.Controls.SetChildIndex(this.lvShipVia, 0);
            this.tabShipping.Controls.SetChildIndex(this.lvAccount, 0);
            this.tabShipping.Controls.SetChildIndex(this.cmdSetShipVia, 0);
            this.tabShipping.Controls.SetChildIndex(this.cmdSetShipAccounts, 0);
            // 
            // details
            // 
            this.details.zz_OrderLineType = "purchase";
            // 
            // tsDetails
            // 
            this.tsDetails.Controls.Add(this.tabCanceled);
            this.tsDetails.Controls.SetChildIndex(this.tabAttachments, 0);
            this.tsDetails.Controls.SetChildIndex(this.tabLines, 0);
            this.tsDetails.Controls.SetChildIndex(this.tabCanceled, 0);
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
            // ctl_soreference
            // 
            this.ctl_soreference.AllCaps = false;
            this.ctl_soreference.BackColor = System.Drawing.Color.Transparent;
            this.ctl_soreference.Bold = false;
            this.ctl_soreference.Caption = "SO#   ";
            this.ctl_soreference.Changed = false;
            this.ctl_soreference.IsEmail = false;
            this.ctl_soreference.IsURL = false;
            this.ctl_soreference.Location = new System.Drawing.Point(351, 169);
            this.ctl_soreference.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_soreference.Name = "ctl_soreference";
            this.ctl_soreference.PasswordChar = '\0';
            this.ctl_soreference.Size = new System.Drawing.Size(198, 28);
            this.ctl_soreference.TabIndex = 4;
            this.ctl_soreference.UseParentBackColor = true;
            this.ctl_soreference.zz_Enabled = true;
            this.ctl_soreference.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_soreference.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_soreference.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_soreference.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_soreference.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctl_soreference.zz_OriginalDesign = false;
            this.ctl_soreference.zz_ShowLinkButton = false;
            this.ctl_soreference.zz_ShowNeedsSaveColor = true;
            this.ctl_soreference.zz_Text = "";
            this.ctl_soreference.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_soreference.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_soreference.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_soreference.zz_UseGlobalColor = false;
            this.ctl_soreference.zz_UseGlobalFont = false;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(76, 86);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(123, 21);
            this.lblTotal.TabIndex = 25;
            this.lblTotal.Text = "$ 1,123,456.67";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(6, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "Total:";
            // 
            // lblCharges
            // 
            this.lblCharges.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharges.Location = new System.Drawing.Point(76, 40);
            this.lblCharges.Name = "lblCharges";
            this.lblCharges.Size = new System.Drawing.Size(123, 21);
            this.lblCharges.TabIndex = 23;
            this.lblCharges.Text = "$ 1,123,456.67";
            this.lblCharges.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(6, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 15);
            this.label6.TabIndex = 22;
            this.label6.Text = "Deductions:";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(76, 21);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(123, 21);
            this.lblSubTotal.TabIndex = 21;
            this.lblSubTotal.Text = "$ 1,123,456.67";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Subtotal:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Silver;
            this.pictureBox2.Location = new System.Drawing.Point(73, 85);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(119, 1);
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // lnkTracking
            // 
            this.lnkTracking.AutoSize = true;
            this.lnkTracking.Location = new System.Drawing.Point(386, 131);
            this.lnkTracking.Name = "lnkTracking";
            this.lnkTracking.Size = new System.Drawing.Size(71, 13);
            this.lnkTracking.TabIndex = 26;
            this.lnkTracking.TabStop = true;
            this.lnkTracking.Text = "Add Tracking";
            this.lnkTracking.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTracking_LinkClicked);
            // 
            // tabCanceled
            // 
            this.tabCanceled.Controls.Add(this.lvCanceled);
            this.tabCanceled.Location = new System.Drawing.Point(4, 22);
            this.tabCanceled.Name = "tabCanceled";
            this.tabCanceled.Size = new System.Drawing.Size(1336, 565);
            this.tabCanceled.TabIndex = 2;
            this.tabCanceled.Text = "Canceled";
            this.tabCanceled.UseVisualStyleBackColor = true;
            // 
            // lvCanceled
            // 
            this.lvCanceled.AddCaption = "Add New";
            this.lvCanceled.AllowActions = true;
            this.lvCanceled.AllowAdd = false;
            this.lvCanceled.AllowDelete = true;
            this.lvCanceled.AllowDeleteAlways = false;
            this.lvCanceled.AllowDrop = true;
            this.lvCanceled.AllowOnlyOpenDelete = true;
            this.lvCanceled.AlternateConnection = null;
            this.lvCanceled.BackColor = System.Drawing.Color.White;
            this.lvCanceled.Caption = "";
            this.lvCanceled.CurrentTemplate = null;
            this.lvCanceled.ExtraClassInfo = "";
            this.lvCanceled.Location = new System.Drawing.Point(4, 4);
            this.lvCanceled.Margin = new System.Windows.Forms.Padding(4);
            this.lvCanceled.MultiSelect = true;
            this.lvCanceled.Name = "lvCanceled";
            this.lvCanceled.Size = new System.Drawing.Size(961, 557);
            this.lvCanceled.SuppressSelectionChanged = false;
            this.lvCanceled.TabIndex = 39;
            this.lvCanceled.zz_OpenColumnMenu = false;
            this.lvCanceled.zz_OrderLineType = "";
            this.lvCanceled.zz_ShowAutoRefresh = true;
            this.lvCanceled.zz_ShowUnlimited = true;
            this.lvCanceled.AboutToThrow += new Core.ShowHandler(this.lvCanceled_AboutToThrow);
            // 
            // lblCreditAmount
            // 
            this.lblCreditAmount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblCreditAmount.Location = new System.Drawing.Point(76, 60);
            this.lblCreditAmount.Name = "lblCreditAmount";
            this.lblCreditAmount.Size = new System.Drawing.Size(123, 21);
            this.lblCreditAmount.TabIndex = 28;
            this.lblCreditAmount.Text = "$ 1,123,456.67";
            this.lblCreditAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAppliedCredits
            // 
            this.lblAppliedCredits.AutoSize = true;
            this.lblAppliedCredits.BackColor = System.Drawing.Color.White;
            this.lblAppliedCredits.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppliedCredits.ForeColor = System.Drawing.Color.Silver;
            this.lblAppliedCredits.Location = new System.Drawing.Point(6, 61);
            this.lblAppliedCredits.Name = "lblAppliedCredits";
            this.lblAppliedCredits.Size = new System.Drawing.Size(49, 15);
            this.lblAppliedCredits.TabIndex = 27;
            this.lblAppliedCredits.Text = "Credits:";
            // 
            // lvCharges
            // 
            this.lvCharges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvCharges.FullRowSelect = true;
            this.lvCharges.GridLines = true;
            this.lvCharges.HideSelection = false;
            this.lvCharges.Location = new System.Drawing.Point(936, 221);
            this.lvCharges.MultiSelect = false;
            this.lvCharges.Name = "lvCharges";
            this.lvCharges.Size = new System.Drawing.Size(193, 104);
            this.lvCharges.TabIndex = 53;
            this.lvCharges.UseCompatibleStateImageBehavior = false;
            this.lvCharges.View = System.Windows.Forms.View.Details;
            this.lvCharges.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Description";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Amount";
            this.columnHeader2.Width = 70;
            // 
            // cmdAddCharge
            // 
            this.cmdAddCharge.Location = new System.Drawing.Point(936, 326);
            this.cmdAddCharge.Name = "cmdAddCharge";
            this.cmdAddCharge.Size = new System.Drawing.Size(193, 24);
            this.cmdAddCharge.TabIndex = 52;
            this.cmdAddCharge.Text = "Add";
            this.cmdAddCharge.UseVisualStyleBackColor = true;
            this.cmdAddCharge.Visible = false;
            this.cmdAddCharge.Click += new System.EventHandler(this.cmdAddCharge_Click);
            // 
            // lblPaid
            // 
            this.lblPaid.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblPaid.Location = new System.Drawing.Point(76, 105);
            this.lblPaid.Name = "lblPaid";
            this.lblPaid.Size = new System.Drawing.Size(123, 21);
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
            this.label2.Location = new System.Drawing.Point(6, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 29;
            this.label2.Text = "Paid Amnt:";
            // 
            // ctl_post_to_portal
            // 
            this.ctl_post_to_portal.BackColor = System.Drawing.Color.White;
            this.ctl_post_to_portal.Bold = false;
            this.ctl_post_to_portal.Caption = "Post to consignment portal";
            this.ctl_post_to_portal.Changed = false;
            this.ctl_post_to_portal.Location = new System.Drawing.Point(351, 128);
            this.ctl_post_to_portal.Name = "ctl_post_to_portal";
            this.ctl_post_to_portal.Size = new System.Drawing.Size(151, 18);
            this.ctl_post_to_portal.TabIndex = 54;
            this.ctl_post_to_portal.Tag = "";
            this.ctl_post_to_portal.UseParentBackColor = false;
            this.ctl_post_to_portal.zz_CheckValue = false;
            this.ctl_post_to_portal.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_post_to_portal.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_post_to_portal.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_post_to_portal.zz_OriginalDesign = false;
            this.ctl_post_to_portal.zz_ShowNeedsSaveColor = true;
            // 
            // ViewHeaderPurchase
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lvCharges);
            this.Controls.Add(this.cmdAddCharge);
            this.Name = "ViewHeaderPurchase";
            this.Controls.SetChildIndex(this.picHeader, 0);
            this.Controls.SetChildIndex(this.ts, 0);
            this.Controls.SetChildIndex(this.gbAction1, 0);
            this.Controls.SetChildIndex(this.gbTotals, 0);
            this.Controls.SetChildIndex(this.tsDetails, 0);
            this.Controls.SetChildIndex(this.gbAction2, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.Controls.SetChildIndex(this.cmdAddCharge, 0);
            this.Controls.SetChildIndex(this.lvCharges, 0);
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
            this.tabShipping.PerformLayout();
            this.tabOther.ResumeLayout(false);
            this.tabLines.ResumeLayout(false);
            this.tabLines.PerformLayout();
            this.tsDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabCanceled.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public NewMethod.nEdit_List ctl_terms;
        public NewMethod.nEdit_String ctl_soreference;
        private System.Windows.Forms.PictureBox pictureBox2;
        protected System.Windows.Forms.Label lblTotal;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label lblCharges;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.Label lblSubTotal;
        protected System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lnkTracking;
        private System.Windows.Forms.TabPage tabCanceled;
        private NewMethod.nList lvCanceled;
        protected System.Windows.Forms.Label lblCreditAmount;
        protected System.Windows.Forms.Label lblAppliedCredits;
        private System.Windows.Forms.ListView lvCharges;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button cmdAddCharge;
        protected System.Windows.Forms.Label lblPaid;
        protected System.Windows.Forms.Label label2;
        private NewMethod.nEdit_Boolean ctl_post_to_portal;
    }
}
