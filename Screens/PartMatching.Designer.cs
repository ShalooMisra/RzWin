namespace Rz5
{
    partial class PartMatching
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
            this.gb = new System.Windows.Forms.GroupBox();
            this.cmdNotify = new System.Windows.Forms.Button();
            this.cmdMatch = new System.Windows.Forms.Button();
            this.optPurchase = new System.Windows.Forms.RadioButton();
            this.optSales = new System.Windows.Forms.RadioButton();
            this.optBids = new System.Windows.Forms.RadioButton();
            this.optQuickQuotes = new System.Windows.Forms.RadioButton();
            this.optReqs = new System.Windows.Forms.RadioButton();
            this.optInventory = new System.Windows.Forms.RadioButton();
            this.chkConsignments = new System.Windows.Forms.CheckBox();
            this.chkExcess = new System.Windows.Forms.CheckBox();
            this.chkStock = new System.Windows.Forms.CheckBox();
            this.gbMatch = new System.Windows.Forms.GroupBox();
            this.optExactBase = new System.Windows.Forms.RadioButton();
            this.optBaseStripped = new System.Windows.Forms.RadioButton();
            this.optExactPart = new System.Windows.Forms.RadioButton();
            this.optPartStripped = new System.Windows.Forms.RadioButton();
            this.gbQuantity = new System.Windows.Forms.GroupBox();
            this.dtEnd = new NewMethod.nEdit_Date();
            this.dtStart = new NewMethod.nEdit_Date();
            this.chkQuantity = new System.Windows.Forms.CheckBox();
            this.lv = new NewMethod.nList();
            this.ts = new System.Windows.Forms.TabControl();
            this.pageInternal = new System.Windows.Forms.TabPage();
            this.optOffers = new System.Windows.Forms.RadioButton();
            this.lvImports = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.optImports = new System.Windows.Forms.RadioButton();
            this.pageExternal = new System.Windows.Forms.TabPage();
            this.dv = new NewMethod.nDataView();
            this.gb.SuspendLayout();
            this.gbMatch.SuspendLayout();
            this.gbQuantity.SuspendLayout();
            this.ts.SuspendLayout();
            this.pageInternal.SuspendLayout();
            this.pageExternal.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.BackColor = System.Drawing.Color.White;
            this.gb.Controls.Add(this.cmdNotify);
            this.gb.Controls.Add(this.cmdMatch);
            this.gb.Controls.Add(this.optPurchase);
            this.gb.Controls.Add(this.optSales);
            this.gb.Controls.Add(this.optBids);
            this.gb.Controls.Add(this.optQuickQuotes);
            this.gb.Controls.Add(this.optReqs);
            this.gb.Controls.Add(this.optInventory);
            this.gb.Controls.Add(this.chkConsignments);
            this.gb.Controls.Add(this.chkExcess);
            this.gb.Controls.Add(this.chkStock);
            this.gb.Location = new System.Drawing.Point(12, 3);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(182, 216);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            this.gb.Text = "Match With";
            // 
            // cmdNotify
            // 
            this.cmdNotify.Location = new System.Drawing.Point(89, 183);
            this.cmdNotify.Name = "cmdNotify";
            this.cmdNotify.Size = new System.Drawing.Size(87, 28);
            this.cmdNotify.TabIndex = 11;
            this.cmdNotify.Text = "&Notify";
            this.cmdNotify.UseVisualStyleBackColor = true;
            this.cmdNotify.Click += new System.EventHandler(this.cmdNotify_Click);
            // 
            // cmdMatch
            // 
            this.cmdMatch.Location = new System.Drawing.Point(2, 183);
            this.cmdMatch.Name = "cmdMatch";
            this.cmdMatch.Size = new System.Drawing.Size(87, 28);
            this.cmdMatch.TabIndex = 10;
            this.cmdMatch.Text = "&Match";
            this.cmdMatch.UseVisualStyleBackColor = true;
            this.cmdMatch.Click += new System.EventHandler(this.cmdMatch_Click);
            // 
            // optPurchase
            // 
            this.optPurchase.AutoSize = true;
            this.optPurchase.Location = new System.Drawing.Point(13, 160);
            this.optPurchase.Name = "optPurchase";
            this.optPurchase.Size = new System.Drawing.Size(99, 17);
            this.optPurchase.TabIndex = 9;
            this.optPurchase.Text = "Past Purchases";
            this.optPurchase.UseVisualStyleBackColor = true;
            this.optPurchase.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optSales
            // 
            this.optSales.AutoSize = true;
            this.optSales.Location = new System.Drawing.Point(13, 142);
            this.optSales.Name = "optSales";
            this.optSales.Size = new System.Drawing.Size(75, 17);
            this.optSales.TabIndex = 8;
            this.optSales.Text = "Past Sales";
            this.optSales.UseVisualStyleBackColor = true;
            this.optSales.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optBids
            // 
            this.optBids.AutoSize = true;
            this.optBids.Location = new System.Drawing.Point(13, 124);
            this.optBids.Name = "optBids";
            this.optBids.Size = new System.Drawing.Size(45, 17);
            this.optBids.TabIndex = 7;
            this.optBids.Text = "Bids";
            this.optBids.UseVisualStyleBackColor = true;
            this.optBids.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optQuickQuotes
            // 
            this.optQuickQuotes.AutoSize = true;
            this.optQuickQuotes.Location = new System.Drawing.Point(13, 106);
            this.optQuickQuotes.Name = "optQuickQuotes";
            this.optQuickQuotes.Size = new System.Drawing.Size(96, 17);
            this.optQuickQuotes.TabIndex = 6;
            this.optQuickQuotes.Text = "Quotes [Quick]";
            this.optQuickQuotes.UseVisualStyleBackColor = true;
            this.optQuickQuotes.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optReqs
            // 
            this.optReqs.AutoSize = true;
            this.optReqs.Location = new System.Drawing.Point(13, 88);
            this.optReqs.Name = "optReqs";
            this.optReqs.Size = new System.Drawing.Size(90, 17);
            this.optReqs.TabIndex = 5;
            this.optReqs.Text = "Requirements";
            this.optReqs.UseVisualStyleBackColor = true;
            this.optReqs.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optInventory
            // 
            this.optInventory.AutoSize = true;
            this.optInventory.Checked = true;
            this.optInventory.Location = new System.Drawing.Point(14, 14);
            this.optInventory.Name = "optInventory";
            this.optInventory.Size = new System.Drawing.Size(69, 17);
            this.optInventory.TabIndex = 4;
            this.optInventory.TabStop = true;
            this.optInventory.Text = "Inventory";
            this.optInventory.UseVisualStyleBackColor = true;
            this.optInventory.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // chkConsignments
            // 
            this.chkConsignments.AutoSize = true;
            this.chkConsignments.Checked = true;
            this.chkConsignments.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConsignments.Location = new System.Drawing.Point(29, 51);
            this.chkConsignments.Name = "chkConsignments";
            this.chkConsignments.Size = new System.Drawing.Size(92, 17);
            this.chkConsignments.TabIndex = 3;
            this.chkConsignments.Text = "Consignments";
            this.chkConsignments.UseVisualStyleBackColor = true;
            // 
            // chkExcess
            // 
            this.chkExcess.AutoSize = true;
            this.chkExcess.Checked = true;
            this.chkExcess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcess.Location = new System.Drawing.Point(29, 70);
            this.chkExcess.Name = "chkExcess";
            this.chkExcess.Size = new System.Drawing.Size(60, 17);
            this.chkExcess.TabIndex = 2;
            this.chkExcess.Text = "Excess";
            this.chkExcess.UseVisualStyleBackColor = true;
            // 
            // chkStock
            // 
            this.chkStock.AutoSize = true;
            this.chkStock.Checked = true;
            this.chkStock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStock.Location = new System.Drawing.Point(29, 34);
            this.chkStock.Name = "chkStock";
            this.chkStock.Size = new System.Drawing.Size(54, 17);
            this.chkStock.TabIndex = 1;
            this.chkStock.Text = "Stock";
            this.chkStock.UseVisualStyleBackColor = true;
            // 
            // gbMatch
            // 
            this.gbMatch.BackColor = System.Drawing.Color.White;
            this.gbMatch.Controls.Add(this.optExactBase);
            this.gbMatch.Controls.Add(this.optBaseStripped);
            this.gbMatch.Controls.Add(this.optExactPart);
            this.gbMatch.Controls.Add(this.optPartStripped);
            this.gbMatch.Location = new System.Drawing.Point(12, 225);
            this.gbMatch.Name = "gbMatch";
            this.gbMatch.Size = new System.Drawing.Size(182, 95);
            this.gbMatch.TabIndex = 3;
            this.gbMatch.TabStop = false;
            this.gbMatch.Text = "Part # Matching Options";
            // 
            // optExactBase
            // 
            this.optExactBase.AutoSize = true;
            this.optExactBase.Location = new System.Drawing.Point(13, 70);
            this.optExactBase.Name = "optExactBase";
            this.optExactBase.Size = new System.Drawing.Size(119, 17);
            this.optExactBase.TabIndex = 3;
            this.optExactBase.Text = "Exact Base Number";
            this.optExactBase.UseVisualStyleBackColor = true;
            this.optExactBase.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optBaseStripped
            // 
            this.optBaseStripped.AutoSize = true;
            this.optBaseStripped.Location = new System.Drawing.Point(13, 53);
            this.optBaseStripped.Name = "optBaseStripped";
            this.optBaseStripped.Size = new System.Drawing.Size(168, 17);
            this.optBaseStripped.TabIndex = 2;
            this.optBaseStripped.Text = "Base Number Without Dashes";
            this.optBaseStripped.UseVisualStyleBackColor = true;
            this.optBaseStripped.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optExactPart
            // 
            this.optExactPart.AutoSize = true;
            this.optExactPart.Location = new System.Drawing.Point(13, 36);
            this.optExactPart.Name = "optExactPart";
            this.optExactPart.Size = new System.Drawing.Size(114, 17);
            this.optExactPart.TabIndex = 1;
            this.optExactPart.Text = "Exact Part Number";
            this.optExactPart.UseVisualStyleBackColor = true;
            this.optExactPart.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optPartStripped
            // 
            this.optPartStripped.AutoSize = true;
            this.optPartStripped.Checked = true;
            this.optPartStripped.Location = new System.Drawing.Point(13, 19);
            this.optPartStripped.Name = "optPartStripped";
            this.optPartStripped.Size = new System.Drawing.Size(163, 17);
            this.optPartStripped.TabIndex = 0;
            this.optPartStripped.TabStop = true;
            this.optPartStripped.Text = "Part Number Without Dashes";
            this.optPartStripped.UseVisualStyleBackColor = true;
            this.optPartStripped.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // gbQuantity
            // 
            this.gbQuantity.BackColor = System.Drawing.Color.White;
            this.gbQuantity.Controls.Add(this.dtEnd);
            this.gbQuantity.Controls.Add(this.dtStart);
            this.gbQuantity.Controls.Add(this.chkQuantity);
            this.gbQuantity.Location = new System.Drawing.Point(13, 326);
            this.gbQuantity.Name = "gbQuantity";
            this.gbQuantity.Size = new System.Drawing.Size(180, 167);
            this.gbQuantity.TabIndex = 4;
            this.gbQuantity.TabStop = false;
            this.gbQuantity.Text = "Additional Options";
            // 
            // dtEnd
            // 
            this.dtEnd.AllowClear = true;
            this.dtEnd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dtEnd.Bold = false;
            this.dtEnd.Caption = "End Date";
            this.dtEnd.Changed = false;
            this.dtEnd.Location = new System.Drawing.Point(13, 100);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(144, 60);
            this.dtEnd.SuppressEdit = false;
            this.dtEnd.TabIndex = 7;
            this.dtEnd.UseParentBackColor = false;
            this.dtEnd.zz_GlobalColor = System.Drawing.Color.Black;
            this.dtEnd.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dtEnd.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.dtEnd.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtEnd.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.dtEnd.zz_OriginalDesign = true;
            this.dtEnd.zz_ShowNeedsSaveColor = true;
            this.dtEnd.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.dtEnd.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.zz_UseGlobalColor = false;
            this.dtEnd.zz_UseGlobalFont = false;
            // 
            // dtStart
            // 
            this.dtStart.AllowClear = true;
            this.dtStart.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dtStart.Bold = false;
            this.dtStart.Caption = "Start Date";
            this.dtStart.Changed = false;
            this.dtStart.Location = new System.Drawing.Point(13, 35);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(144, 60);
            this.dtStart.SuppressEdit = false;
            this.dtStart.TabIndex = 6;
            this.dtStart.UseParentBackColor = false;
            this.dtStart.zz_GlobalColor = System.Drawing.Color.Black;
            this.dtStart.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dtStart.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.dtStart.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtStart.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.dtStart.zz_OriginalDesign = true;
            this.dtStart.zz_ShowNeedsSaveColor = true;
            this.dtStart.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.dtStart.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.zz_UseGlobalColor = false;
            this.dtStart.zz_UseGlobalFont = false;
            // 
            // chkQuantity
            // 
            this.chkQuantity.AutoSize = true;
            this.chkQuantity.Location = new System.Drawing.Point(12, 15);
            this.chkQuantity.Name = "chkQuantity";
            this.chkQuantity.Size = new System.Drawing.Size(145, 17);
            this.chkQuantity.TabIndex = 5;
            this.chkQuantity.Text = "Greater or Equal Quantity";
            this.chkQuantity.UseVisualStyleBackColor = true;
            this.chkQuantity.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // lv
            // 
            this.lv.AddCaption = "Add New";
            this.lv.AllowActions = true;
            this.lv.AllowAdd = false;
            this.lv.AllowDelete = true;
            this.lv.AllowDrop = true;
            this.lv.Caption = "";
            this.lv.CurrentTemplate = null;
            this.lv.ExtraClassInfo = "";
            this.lv.Location = new System.Drawing.Point(14, 499);
            this.lv.MultiSelect = true;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(709, 85);
            this.lv.SuppressSelectionChanged = false;
            this.lv.TabIndex = 2;
            this.lv.zz_OpenColumnMenu = false;
            this.lv.zz_ShowAutoRefresh = true;
            this.lv.zz_ShowUnlimited = true;
            // 
            // ts
            // 
            this.ts.Controls.Add(this.pageInternal);
            this.ts.Controls.Add(this.pageExternal);
            this.ts.Location = new System.Drawing.Point(200, 3);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(527, 490);
            this.ts.TabIndex = 5;
            // 
            // pageInternal
            // 
            this.pageInternal.Controls.Add(this.optOffers);
            this.pageInternal.Controls.Add(this.lvImports);
            this.pageInternal.Controls.Add(this.optImports);
            this.pageInternal.Location = new System.Drawing.Point(4, 22);
            this.pageInternal.Name = "pageInternal";
            this.pageInternal.Padding = new System.Windows.Forms.Padding(3);
            this.pageInternal.Size = new System.Drawing.Size(519, 464);
            this.pageInternal.TabIndex = 0;
            this.pageInternal.Text = "Data Within Rz3";
            this.pageInternal.UseVisualStyleBackColor = true;
            // 
            // optOffers
            // 
            this.optOffers.AutoSize = true;
            this.optOffers.Location = new System.Drawing.Point(231, 8);
            this.optOffers.Name = "optOffers";
            this.optOffers.Size = new System.Drawing.Size(53, 17);
            this.optOffers.TabIndex = 2;
            this.optOffers.Text = "Offers";
            this.optOffers.UseVisualStyleBackColor = true;
            this.optOffers.Visible = false;
            this.optOffers.CheckedChanged += new System.EventHandler(this.optOffers_CheckedChanged);
            // 
            // lvImports
            // 
            this.lvImports.CheckBoxes = true;
            this.lvImports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvImports.Location = new System.Drawing.Point(10, 31);
            this.lvImports.Name = "lvImports";
            this.lvImports.Size = new System.Drawing.Size(488, 417);
            this.lvImports.TabIndex = 1;
            this.lvImports.UseCompatibleStateImageBehavior = false;
            this.lvImports.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Import Name";
            this.columnHeader1.Width = 296;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Line Count";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 121;
            // 
            // optImports
            // 
            this.optImports.AutoSize = true;
            this.optImports.Checked = true;
            this.optImports.Location = new System.Drawing.Point(7, 8);
            this.optImports.Name = "optImports";
            this.optImports.Size = new System.Drawing.Size(218, 17);
            this.optImports.TabIndex = 0;
            this.optImports.TabStop = true;
            this.optImports.Text = "Stock, Excess, and Consignment Imports";
            this.optImports.UseVisualStyleBackColor = true;
            this.optImports.CheckedChanged += new System.EventHandler(this.optImports_CheckedChanged);
            // 
            // pageExternal
            // 
            this.pageExternal.Controls.Add(this.dv);
            this.pageExternal.Location = new System.Drawing.Point(4, 22);
            this.pageExternal.Name = "pageExternal";
            this.pageExternal.Padding = new System.Windows.Forms.Padding(3);
            this.pageExternal.Size = new System.Drawing.Size(519, 454);
            this.pageExternal.TabIndex = 1;
            this.pageExternal.Text = "External Data";
            this.pageExternal.UseVisualStyleBackColor = true;
            // 
            // dv
            // 
            this.dv.AlwaysDisableAccept = false;
            this.dv.BackColor = System.Drawing.Color.White;
            this.dv.DisableAutoMatching = false;
            this.dv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dv.HideOptions = false;
            this.dv.Location = new System.Drawing.Point(3, 3);
            this.dv.Name = "dv";
            this.dv.Size = new System.Drawing.Size(513, 448);
            this.dv.TabIndex = 3;
            this.dv.Accept += new NewMethod.nDataViewAcceptHandler(this.dv_Accept);
            // 
            // PartMatching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ts);
            this.Controls.Add(this.gbQuantity);
            this.Controls.Add(this.gbMatch);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.gb);
            this.Name = "PartMatching";
            this.Size = new System.Drawing.Size(785, 672);
            this.Resize += new System.EventHandler(this.PartMatching_Resize);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.gbMatch.ResumeLayout(false);
            this.gbMatch.PerformLayout();
            this.gbQuantity.ResumeLayout(false);
            this.gbQuantity.PerformLayout();
            this.ts.ResumeLayout(false);
            this.pageInternal.ResumeLayout(false);
            this.pageInternal.PerformLayout();
            this.pageExternal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.CheckBox chkConsignments;
        private System.Windows.Forms.CheckBox chkExcess;
        private System.Windows.Forms.CheckBox chkStock;
        private NewMethod.nList lv;
        private System.Windows.Forms.RadioButton optPurchase;
        private System.Windows.Forms.RadioButton optSales;
        private System.Windows.Forms.RadioButton optBids;
        private System.Windows.Forms.RadioButton optQuickQuotes;
        private System.Windows.Forms.RadioButton optReqs;
        private System.Windows.Forms.RadioButton optInventory;
        private System.Windows.Forms.GroupBox gbMatch;
        private System.Windows.Forms.RadioButton optExactBase;
        private System.Windows.Forms.RadioButton optBaseStripped;
        private System.Windows.Forms.RadioButton optExactPart;
        private System.Windows.Forms.RadioButton optPartStripped;
        private System.Windows.Forms.GroupBox gbQuantity;
        private System.Windows.Forms.CheckBox chkQuantity;
        private NewMethod.nEdit_Date dtStart;
        private System.Windows.Forms.TabControl ts;
        private System.Windows.Forms.TabPage pageInternal;
        private System.Windows.Forms.ListView lvImports;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.RadioButton optImports;
        private System.Windows.Forms.TabPage pageExternal;
        private NewMethod.nDataView dv;
        private System.Windows.Forms.Button cmdNotify;
        private System.Windows.Forms.Button cmdMatch;
        private System.Windows.Forms.RadioButton optOffers;
        private NewMethod.nEdit_Date dtEnd;
    }
}
