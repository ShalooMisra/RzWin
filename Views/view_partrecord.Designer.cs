using NewMethod;
using Tools.Database;

namespace Rz5
{
    partial class view_partrecord : ViewPlusMenu
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
            this.gbStockType = new System.Windows.Forms.GroupBox();
            this.ctl_stocktype = new System.Windows.Forms.Label();
            this.ctl_fullpartnumber = new NewMethod.nEdit_String();
            this.ts = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.ctl_internalpartnumber = new NewMethod.nEdit_String();
            this.ctl_userdata_01 = new NewMethod.nEdit_String();
            this.ctl_rohs_info2 = new NewMethod.nEdit_List();
            this.label1 = new System.Windows.Forms.Label();
            this.ctl_internalcomment = new NewMethod.nEdit_Memo();
            this.gbOtherInfo = new System.Windows.Forms.GroupBox();
            this.ctl_QC_Status = new NewMethod.nEdit_List();
            this.ctl_boxnum = new NewMethod.nEdit_List();
            this.ctl_lotnumber = new NewMethod.nEdit_List();
            this.ctl_delivery = new NewMethod.nEdit_List();
            this.ctl_boxcode = new NewMethod.nEdit_List();
            this.cmdChangeLocation = new System.Windows.Forms.Button();
            this.ctl_location = new NewMethod.nEdit_List();
            this.gbPriceInfo = new System.Windows.Forms.GroupBox();
            this.lblSMVDate = new System.Windows.Forms.Label();
            this.ctl_smv = new NewMethod.nEdit_Money();
            this.label2 = new System.Windows.Forms.Label();
            this.ctl_averagecost = new NewMethod.nEdit_Money();
            this.buyer = new NewMethod.nEdit_User();
            this.ctl_cost = new NewMethod.nEdit_Money();
            this.ctl_price = new NewMethod.nEdit_Money();
            this.ctl_highcost = new NewMethod.nEdit_Money();
            this.ctl_lowprice = new NewMethod.nEdit_Money();
            this.ctl_midprice = new NewMethod.nEdit_Money();
            this.ctl_actual_cost = new NewMethod.nEdit_Money();
            this.ctl_highprice = new NewMethod.nEdit_Money();
            this.ctl_lowcost = new NewMethod.nEdit_Money();
            this.gbQtyInfo = new System.Windows.Forms.GroupBox();
            this.ctl_unit_of_measure = new NewMethod.nEdit_List();
            this.ctl_manufacturer = new NewMethod.nEdit_List();
            this.ctl_quantity = new NewMethod.nEdit_Number();
            this.ctl_quantityallocated = new NewMethod.nEdit_Number();
            this.ctl_expected_quantity = new NewMethod.nEdit_Number();
            this.ctl_datecode = new NewMethod.nEdit_String();
            this.ctl_partsperpack = new NewMethod.nEdit_Number();
            this.ctl_condition = new NewMethod.nEdit_List();
            this.ctl_packaging = new NewMethod.nEdit_List();
            this.ctl_user_defined = new NewMethod.nEdit_String();
            this.ctl_mfg_certifications = new NewMethod.nEdit_Boolean();
            this.ctl_no_complete_report = new NewMethod.nEdit_Boolean();
            this.ctl_do_not_export = new NewMethod.nEdit_Boolean();
            this.cStub = new Rz5.CompanyStub_PlusContact();
            this.ctl_alternatepart = new NewMethod.nEdit_String();
            this.tpMaster = new System.Windows.Forms.TabPage();
            this.ctl_ProductType = new NewMethod.nEdit_List();
            this.gb_SSD = new System.Windows.Forms.GroupBox();
            this.ctl_maxtemp = new NewMethod.nEdit_String();
            this.ctl_ssd_interface = new NewMethod.nEdit_String();
            this.ctl_formfactor = new NewMethod.nEdit_String();
            this.ctl_capacity = new NewMethod.nEdit_String();
            this.tpExtra = new System.Windows.Forms.TabPage();
            this.nEdit_User1 = new NewMethod.nEdit_User();
            this.ctl_category = new NewMethod.nEdit_List();
            this.ctl_rohs_info = new NewMethod.nEdit_List();
            this.ctl_description = new NewMethod.nEdit_Memo();
            this.ctl_leadtime = new NewMethod.nEdit_String();
            this.ctl_printcomment = new NewMethod.nEdit_Memo();
            this.ctl_islocked = new NewMethod.nEdit_Boolean();
            this.ctl_importid = new NewMethod.nEdit_String();
            this.ctl_userdata_02 = new NewMethod.nEdit_String();
            this.ctl_datemodified = new NewMethod.nEdit_Date();
            this.ctl_datecreated = new NewMethod.nEdit_Date();
            this.ctl_buytype = new NewMethod.nEdit_String();
            this.ctl_country = new NewMethod.nEdit_String();
            this.ctl_alternatequantity = new NewMethod.nEdit_Number();
            this.ctl_partsetup = new NewMethod.nEdit_List();
            this.ctl_dateconfirmed = new NewMethod.nEdit_Date();
            this.pagePictures = new System.Windows.Forms.TabPage();
            this.PPV = new Rz5.PartPictureViewer();
            this.tabInspection = new System.Windows.Forms.TabPage();
            this.tabCofC = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvCofC = new NewMethod.nList();
            this.tabCrosses = new System.Windows.Forms.TabPage();
            this.gbCrossFrom = new System.Windows.Forms.GroupBox();
            this.nList1 = new NewMethod.nList();
            this.gbCrossTo = new System.Windows.Forms.GroupBox();
            this.lv = new NewMethod.nList();
            this.tabImport = new System.Windows.Forms.TabPage();
            this.gbImport = new System.Windows.Forms.GroupBox();
            this.llChangeImportID = new System.Windows.Forms.LinkLabel();
            this.lblImportName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbConsign = new System.Windows.Forms.GroupBox();
            this.lblConsignPerc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ctl_consigncodes = new NewMethod.nEdit_List();
            this.label3 = new System.Windows.Forms.Label();
            this.lblConsignCode = new System.Windows.Forms.Label();
            this.ctl_part_status = new NewMethod.nEdit_List();
            this.cmdSaveAndNew = new System.Windows.Forms.Button();
            this.gbStockType.SuspendLayout();
            this.ts.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.gbOtherInfo.SuspendLayout();
            this.gbPriceInfo.SuspendLayout();
            this.gbQtyInfo.SuspendLayout();
            this.tpMaster.SuspendLayout();
            this.gb_SSD.SuspendLayout();
            this.tpExtra.SuspendLayout();
            this.pagePictures.SuspendLayout();
            this.tabCofC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabCrosses.SuspendLayout();
            this.gbCrossFrom.SuspendLayout();
            this.gbCrossTo.SuspendLayout();
            this.tabImport.SuspendLayout();
            this.gbImport.SuspendLayout();
            this.gbConsign.SuspendLayout();
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(777, 0);
            this.xActions.Size = new System.Drawing.Size(148, 701);
            // 
            // gbStockType
            // 
            this.gbStockType.Controls.Add(this.ctl_stocktype);
            this.gbStockType.Location = new System.Drawing.Point(8, 23);
            this.gbStockType.Name = "gbStockType";
            this.gbStockType.Size = new System.Drawing.Size(100, 43);
            this.gbStockType.TabIndex = 0;
            this.gbStockType.TabStop = false;
            this.gbStockType.Text = "Stock Type";
            // 
            // ctl_stocktype
            // 
            this.ctl_stocktype.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_stocktype.Location = new System.Drawing.Point(6, 15);
            this.ctl_stocktype.Name = "ctl_stocktype";
            this.ctl_stocktype.Size = new System.Drawing.Size(88, 25);
            this.ctl_stocktype.TabIndex = 0;
            this.ctl_stocktype.Text = "STOCK";
            this.ctl_stocktype.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ctl_stocktype.DoubleClick += new System.EventHandler(this.ctl_stocktype_DoubleClick);
            // 
            // ctl_fullpartnumber
            // 
            this.ctl_fullpartnumber.AllCaps = true;
            this.ctl_fullpartnumber.BackColor = System.Drawing.Color.White;
            this.ctl_fullpartnumber.Bold = false;
            this.ctl_fullpartnumber.Caption = "Part Number";
            this.ctl_fullpartnumber.Changed = false;
            this.ctl_fullpartnumber.IsEmail = false;
            this.ctl_fullpartnumber.IsURL = false;
            this.ctl_fullpartnumber.Location = new System.Drawing.Point(112, 30);
            this.ctl_fullpartnumber.Name = "ctl_fullpartnumber";
            this.ctl_fullpartnumber.PasswordChar = '\0';
            this.ctl_fullpartnumber.Size = new System.Drawing.Size(536, 39);
            this.ctl_fullpartnumber.TabIndex = 1;
            this.ctl_fullpartnumber.UseParentBackColor = false;
            this.ctl_fullpartnumber.zz_Enabled = true;
            this.ctl_fullpartnumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_fullpartnumber.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_fullpartnumber.zz_LabelColor = System.Drawing.Color.DarkBlue;
            this.ctl_fullpartnumber.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_fullpartnumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_fullpartnumber.zz_OriginalDesign = false;
            this.ctl_fullpartnumber.zz_ShowLinkButton = false;
            this.ctl_fullpartnumber.zz_ShowNeedsSaveColor = true;
            this.ctl_fullpartnumber.zz_Text = "";
            this.ctl_fullpartnumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_fullpartnumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_fullpartnumber.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_fullpartnumber.zz_UseGlobalColor = false;
            this.ctl_fullpartnumber.zz_UseGlobalFont = false;
            // 
            // ts
            // 
            this.ts.Controls.Add(this.tpGeneral);
            this.ts.Controls.Add(this.tpMaster);
            this.ts.Controls.Add(this.tpExtra);
            this.ts.Controls.Add(this.pagePictures);
            this.ts.Controls.Add(this.tabInspection);
            this.ts.Controls.Add(this.tabCofC);
            this.ts.Controls.Add(this.tabCrosses);
            this.ts.Controls.Add(this.tabImport);
            this.ts.Location = new System.Drawing.Point(7, 72);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(643, 461);
            this.ts.TabIndex = 2;
            this.ts.SelectedIndexChanged += new System.EventHandler(this.ts_SelectedIndexChanged);
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.ctl_internalpartnumber);
            this.tpGeneral.Controls.Add(this.ctl_userdata_01);
            this.tpGeneral.Controls.Add(this.ctl_rohs_info2);
            this.tpGeneral.Controls.Add(this.label1);
            this.tpGeneral.Controls.Add(this.ctl_internalcomment);
            this.tpGeneral.Controls.Add(this.gbOtherInfo);
            this.tpGeneral.Controls.Add(this.gbPriceInfo);
            this.tpGeneral.Controls.Add(this.gbQtyInfo);
            this.tpGeneral.Controls.Add(this.ctl_mfg_certifications);
            this.tpGeneral.Controls.Add(this.ctl_no_complete_report);
            this.tpGeneral.Controls.Add(this.ctl_do_not_export);
            this.tpGeneral.Controls.Add(this.cStub);
            this.tpGeneral.Controls.Add(this.ctl_alternatepart);
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(635, 435);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // ctl_internalpartnumber
            // 
            this.ctl_internalpartnumber.AllCaps = false;
            this.ctl_internalpartnumber.BackColor = System.Drawing.Color.Transparent;
            this.ctl_internalpartnumber.Bold = false;
            this.ctl_internalpartnumber.Caption = "Internal Part Number";
            this.ctl_internalpartnumber.Changed = false;
            this.ctl_internalpartnumber.IsEmail = false;
            this.ctl_internalpartnumber.IsURL = false;
            this.ctl_internalpartnumber.Location = new System.Drawing.Point(3, 43);
            this.ctl_internalpartnumber.Name = "ctl_internalpartnumber";
            this.ctl_internalpartnumber.PasswordChar = '\0';
            this.ctl_internalpartnumber.Size = new System.Drawing.Size(300, 39);
            this.ctl_internalpartnumber.TabIndex = 34;
            this.ctl_internalpartnumber.UseParentBackColor = true;
            this.ctl_internalpartnumber.zz_Enabled = true;
            this.ctl_internalpartnumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_internalpartnumber.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internalpartnumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_internalpartnumber.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internalpartnumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_internalpartnumber.zz_OriginalDesign = false;
            this.ctl_internalpartnumber.zz_ShowLinkButton = false;
            this.ctl_internalpartnumber.zz_ShowNeedsSaveColor = true;
            this.ctl_internalpartnumber.zz_Text = "";
            this.ctl_internalpartnumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_internalpartnumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_internalpartnumber.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internalpartnumber.zz_UseGlobalColor = false;
            this.ctl_internalpartnumber.zz_UseGlobalFont = false;
            // 
            // ctl_userdata_01
            // 
            this.ctl_userdata_01.AllCaps = false;
            this.ctl_userdata_01.BackColor = System.Drawing.Color.Transparent;
            this.ctl_userdata_01.Bold = false;
            this.ctl_userdata_01.Caption = "Alternate Part 2 (userdata_01)";
            this.ctl_userdata_01.Changed = false;
            this.ctl_userdata_01.IsEmail = false;
            this.ctl_userdata_01.IsURL = false;
            this.ctl_userdata_01.Location = new System.Drawing.Point(3, 88);
            this.ctl_userdata_01.Name = "ctl_userdata_01";
            this.ctl_userdata_01.PasswordChar = '\0';
            this.ctl_userdata_01.Size = new System.Drawing.Size(300, 39);
            this.ctl_userdata_01.TabIndex = 33;
            this.ctl_userdata_01.UseParentBackColor = true;
            this.ctl_userdata_01.zz_Enabled = true;
            this.ctl_userdata_01.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_userdata_01.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_userdata_01.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_userdata_01.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_userdata_01.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_userdata_01.zz_OriginalDesign = false;
            this.ctl_userdata_01.zz_ShowLinkButton = false;
            this.ctl_userdata_01.zz_ShowNeedsSaveColor = true;
            this.ctl_userdata_01.zz_Text = "";
            this.ctl_userdata_01.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_userdata_01.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_userdata_01.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_userdata_01.zz_UseGlobalColor = false;
            this.ctl_userdata_01.zz_UseGlobalFont = false;
            // 
            // ctl_rohs_info2
            // 
            this.ctl_rohs_info2.AllCaps = false;
            this.ctl_rohs_info2.AllowEdit = true;
            this.ctl_rohs_info2.BackColor = System.Drawing.Color.Transparent;
            this.ctl_rohs_info2.Bold = false;
            this.ctl_rohs_info2.Caption = "RoHS";
            this.ctl_rohs_info2.Changed = false;
            this.ctl_rohs_info2.ListName = "rohs_info";
            this.ctl_rohs_info2.Location = new System.Drawing.Point(322, 19);
            this.ctl_rohs_info2.Name = "ctl_rohs_info2";
            this.ctl_rohs_info2.SimpleList = null;
            this.ctl_rohs_info2.Size = new System.Drawing.Size(200, 25);
            this.ctl_rohs_info2.TabIndex = 32;
            this.ctl_rohs_info2.UseParentBackColor = false;
            this.ctl_rohs_info2.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_rohs_info2.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_rohs_info2.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_rohs_info2.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_rohs_info2.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_rohs_info2.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.Left;
            this.ctl_rohs_info2.zz_OriginalDesign = false;
            this.ctl_rohs_info2.zz_ShowNeedsSaveColor = true;
            this.ctl_rohs_info2.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_rohs_info2.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_rohs_info2.zz_UseGlobalColor = false;
            this.ctl_rohs_info2.zz_UseGlobalFont = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(321, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 22);
            this.label1.TabIndex = 30;
            this.label1.Text = "Vendor Information";
            // 
            // ctl_internalcomment
            // 
            this.ctl_internalcomment.BackColor = System.Drawing.Color.Transparent;
            this.ctl_internalcomment.Bold = false;
            this.ctl_internalcomment.Caption = "Internal Comment";
            this.ctl_internalcomment.Changed = false;
            this.ctl_internalcomment.DateLines = false;
            this.ctl_internalcomment.Location = new System.Drawing.Point(317, 377);
            this.ctl_internalcomment.Name = "ctl_internalcomment";
            this.ctl_internalcomment.Size = new System.Drawing.Size(312, 78);
            this.ctl_internalcomment.TabIndex = 7;
            this.ctl_internalcomment.UseParentBackColor = false;
            this.ctl_internalcomment.zz_Enabled = true;
            this.ctl_internalcomment.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_internalcomment.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internalcomment.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_internalcomment.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internalcomment.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_internalcomment.zz_OriginalDesign = false;
            this.ctl_internalcomment.zz_ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ctl_internalcomment.zz_ShowNeedsSaveColor = true;
            this.ctl_internalcomment.zz_Text = "";
            this.ctl_internalcomment.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_internalcomment.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internalcomment.zz_UseGlobalColor = false;
            this.ctl_internalcomment.zz_UseGlobalFont = false;
            // 
            // gbOtherInfo
            // 
            this.gbOtherInfo.Controls.Add(this.ctl_QC_Status);
            this.gbOtherInfo.Controls.Add(this.ctl_boxnum);
            this.gbOtherInfo.Controls.Add(this.ctl_lotnumber);
            this.gbOtherInfo.Controls.Add(this.ctl_delivery);
            this.gbOtherInfo.Controls.Add(this.ctl_boxcode);
            this.gbOtherInfo.Controls.Add(this.cmdChangeLocation);
            this.gbOtherInfo.Controls.Add(this.ctl_location);
            this.gbOtherInfo.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOtherInfo.Location = new System.Drawing.Point(3, 360);
            this.gbOtherInfo.Name = "gbOtherInfo";
            this.gbOtherInfo.Size = new System.Drawing.Size(313, 173);
            this.gbOtherInfo.TabIndex = 5;
            this.gbOtherInfo.TabStop = false;
            this.gbOtherInfo.Text = "Lot/Warehouse Information";
            // 
            // ctl_QC_Status
            // 
            this.ctl_QC_Status.AllCaps = false;
            this.ctl_QC_Status.AllowEdit = false;
            this.ctl_QC_Status.BackColor = System.Drawing.Color.Transparent;
            this.ctl_QC_Status.Bold = false;
            this.ctl_QC_Status.Caption = "QC Status";
            this.ctl_QC_Status.Changed = false;
            this.ctl_QC_Status.ListName = "QC_Status";
            this.ctl_QC_Status.Location = new System.Drawing.Point(7, 21);
            this.ctl_QC_Status.Name = "ctl_QC_Status";
            this.ctl_QC_Status.SimpleList = null;
            this.ctl_QC_Status.Size = new System.Drawing.Size(147, 40);
            this.ctl_QC_Status.TabIndex = 45;
            this.ctl_QC_Status.UseParentBackColor = true;
            this.ctl_QC_Status.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_QC_Status.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_QC_Status.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_QC_Status.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_QC_Status.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_QC_Status.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_QC_Status.zz_OriginalDesign = false;
            this.ctl_QC_Status.zz_ShowNeedsSaveColor = true;
            this.ctl_QC_Status.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_QC_Status.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_QC_Status.zz_UseGlobalColor = false;
            this.ctl_QC_Status.zz_UseGlobalFont = false;
            // 
            // ctl_boxnum
            // 
            this.ctl_boxnum.AllCaps = false;
            this.ctl_boxnum.AllowEdit = true;
            this.ctl_boxnum.BackColor = System.Drawing.Color.Transparent;
            this.ctl_boxnum.Bold = false;
            this.ctl_boxnum.Caption = "Box Number";
            this.ctl_boxnum.Changed = true;
            this.ctl_boxnum.ListName = "boxnum";
            this.ctl_boxnum.Location = new System.Drawing.Point(162, 99);
            this.ctl_boxnum.Name = "ctl_boxnum";
            this.ctl_boxnum.SimpleList = "";
            this.ctl_boxnum.Size = new System.Drawing.Size(144, 40);
            this.ctl_boxnum.TabIndex = 11;
            this.ctl_boxnum.UseParentBackColor = true;
            this.ctl_boxnum.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_boxnum.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_boxnum.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_boxnum.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_boxnum.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_boxnum.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_boxnum.zz_OriginalDesign = false;
            this.ctl_boxnum.zz_ShowNeedsSaveColor = true;
            this.ctl_boxnum.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_boxnum.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_boxnum.zz_UseGlobalColor = false;
            this.ctl_boxnum.zz_UseGlobalFont = false;
            // 
            // ctl_lotnumber
            // 
            this.ctl_lotnumber.AllCaps = false;
            this.ctl_lotnumber.AllowEdit = true;
            this.ctl_lotnumber.BackColor = System.Drawing.Color.Transparent;
            this.ctl_lotnumber.Bold = false;
            this.ctl_lotnumber.Caption = "Lot Number";
            this.ctl_lotnumber.Changed = true;
            this.ctl_lotnumber.ListName = "lotnumber";
            this.ctl_lotnumber.Location = new System.Drawing.Point(161, 57);
            this.ctl_lotnumber.Name = "ctl_lotnumber";
            this.ctl_lotnumber.SimpleList = "";
            this.ctl_lotnumber.Size = new System.Drawing.Size(145, 40);
            this.ctl_lotnumber.TabIndex = 9;
            this.ctl_lotnumber.UseParentBackColor = true;
            this.ctl_lotnumber.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_lotnumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_lotnumber.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_lotnumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_lotnumber.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_lotnumber.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_lotnumber.zz_OriginalDesign = false;
            this.ctl_lotnumber.zz_ShowNeedsSaveColor = true;
            this.ctl_lotnumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_lotnumber.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_lotnumber.zz_UseGlobalColor = false;
            this.ctl_lotnumber.zz_UseGlobalFont = false;
            // 
            // ctl_delivery
            // 
            this.ctl_delivery.AllCaps = false;
            this.ctl_delivery.AllowEdit = false;
            this.ctl_delivery.BackColor = System.Drawing.Color.Transparent;
            this.ctl_delivery.Bold = false;
            this.ctl_delivery.Caption = "Delivery";
            this.ctl_delivery.Changed = false;
            this.ctl_delivery.ListName = "category";
            this.ctl_delivery.Location = new System.Drawing.Point(6, 99);
            this.ctl_delivery.Name = "ctl_delivery";
            this.ctl_delivery.SimpleList = null;
            this.ctl_delivery.Size = new System.Drawing.Size(148, 40);
            this.ctl_delivery.TabIndex = 10;
            this.ctl_delivery.UseParentBackColor = true;
            this.ctl_delivery.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_delivery.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_delivery.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_delivery.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_delivery.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_delivery.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_delivery.zz_OriginalDesign = false;
            this.ctl_delivery.zz_ShowNeedsSaveColor = true;
            this.ctl_delivery.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_delivery.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_delivery.zz_UseGlobalColor = false;
            this.ctl_delivery.zz_UseGlobalFont = false;
            // 
            // ctl_boxcode
            // 
            this.ctl_boxcode.AllCaps = false;
            this.ctl_boxcode.AllowEdit = false;
            this.ctl_boxcode.BackColor = System.Drawing.Color.Transparent;
            this.ctl_boxcode.Bold = false;
            this.ctl_boxcode.Caption = "Box Code";
            this.ctl_boxcode.Changed = false;
            this.ctl_boxcode.ListName = "category";
            this.ctl_boxcode.Location = new System.Drawing.Point(6, 57);
            this.ctl_boxcode.Name = "ctl_boxcode";
            this.ctl_boxcode.SimpleList = null;
            this.ctl_boxcode.Size = new System.Drawing.Size(149, 40);
            this.ctl_boxcode.TabIndex = 8;
            this.ctl_boxcode.UseParentBackColor = true;
            this.ctl_boxcode.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_boxcode.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_boxcode.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_boxcode.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_boxcode.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_boxcode.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_boxcode.zz_OriginalDesign = false;
            this.ctl_boxcode.zz_ShowNeedsSaveColor = true;
            this.ctl_boxcode.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_boxcode.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_boxcode.zz_UseGlobalColor = false;
            this.ctl_boxcode.zz_UseGlobalFont = false;
            // 
            // cmdChangeLocation
            // 
            this.cmdChangeLocation.Location = new System.Drawing.Point(162, 144);
            this.cmdChangeLocation.Name = "cmdChangeLocation";
            this.cmdChangeLocation.Size = new System.Drawing.Size(143, 28);
            this.cmdChangeLocation.TabIndex = 19;
            this.cmdChangeLocation.TabStop = false;
            this.cmdChangeLocation.Text = "Change Location";
            this.cmdChangeLocation.UseVisualStyleBackColor = true;
            this.cmdChangeLocation.Click += new System.EventHandler(this.cmdChangeLocation_Click);
            // 
            // ctl_location
            // 
            this.ctl_location.AllCaps = false;
            this.ctl_location.AllowEdit = true;
            this.ctl_location.BackColor = System.Drawing.Color.Transparent;
            this.ctl_location.Bold = false;
            this.ctl_location.Caption = "Location";
            this.ctl_location.Changed = true;
            this.ctl_location.ListName = "location";
            this.ctl_location.Location = new System.Drawing.Point(162, 15);
            this.ctl_location.Name = "ctl_location";
            this.ctl_location.SimpleList = "";
            this.ctl_location.Size = new System.Drawing.Size(145, 40);
            this.ctl_location.TabIndex = 7;
            this.ctl_location.UseParentBackColor = true;
            this.ctl_location.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_location.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_location.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_location.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_location.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_location.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_location.zz_OriginalDesign = false;
            this.ctl_location.zz_ShowNeedsSaveColor = true;
            this.ctl_location.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_location.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_location.zz_UseGlobalColor = false;
            this.ctl_location.zz_UseGlobalFont = false;
            // 
            // gbPriceInfo
            // 
            this.gbPriceInfo.Controls.Add(this.lblSMVDate);
            this.gbPriceInfo.Controls.Add(this.ctl_smv);
            this.gbPriceInfo.Controls.Add(this.label2);
            this.gbPriceInfo.Controls.Add(this.ctl_averagecost);
            this.gbPriceInfo.Controls.Add(this.buyer);
            this.gbPriceInfo.Controls.Add(this.ctl_cost);
            this.gbPriceInfo.Controls.Add(this.ctl_price);
            this.gbPriceInfo.Controls.Add(this.ctl_highcost);
            this.gbPriceInfo.Controls.Add(this.ctl_lowprice);
            this.gbPriceInfo.Controls.Add(this.ctl_midprice);
            this.gbPriceInfo.Controls.Add(this.ctl_actual_cost);
            this.gbPriceInfo.Controls.Add(this.ctl_highprice);
            this.gbPriceInfo.Controls.Add(this.ctl_lowcost);
            this.gbPriceInfo.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPriceInfo.Location = new System.Drawing.Point(320, 43);
            this.gbPriceInfo.Name = "gbPriceInfo";
            this.gbPriceInfo.Size = new System.Drawing.Size(312, 224);
            this.gbPriceInfo.TabIndex = 6;
            this.gbPriceInfo.TabStop = false;
            this.gbPriceInfo.Text = "Price/Cost Information";
            // 
            // lblSMVDate
            // 
            this.lblSMVDate.AutoSize = true;
            this.lblSMVDate.Location = new System.Drawing.Point(161, 139);
            this.lblSMVDate.Name = "lblSMVDate";
            this.lblSMVDate.Size = new System.Drawing.Size(59, 15);
            this.lblSMVDate.TabIndex = 40;
            this.lblSMVDate.Text = "SMVDate";
            // 
            // ctl_smv
            // 
            this.ctl_smv.BackColor = System.Drawing.Color.Transparent;
            this.ctl_smv.Bold = false;
            this.ctl_smv.Caption = "SMV";
            this.ctl_smv.Changed = false;
            this.ctl_smv.EditCaption = false;
            this.ctl_smv.FullDecimal = true;
            this.ctl_smv.Location = new System.Drawing.Point(7, 136);
            this.ctl_smv.Name = "ctl_smv";
            this.ctl_smv.RoundNearestCent = false;
            this.ctl_smv.Size = new System.Drawing.Size(148, 23);
            this.ctl_smv.TabIndex = 39;
            this.ctl_smv.UseParentBackColor = true;
            this.ctl_smv.zz_Enabled = true;
            this.ctl_smv.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_smv.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_smv.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_smv.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_smv.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.Left;
            this.ctl_smv.zz_OriginalDesign = false;
            this.ctl_smv.zz_ShowErrorColor = true;
            this.ctl_smv.zz_ShowNeedsSaveColor = true;
            this.ctl_smv.zz_Text = "";
            this.ctl_smv.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_smv.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_smv.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_smv.zz_UseGlobalColor = false;
            this.ctl_smv.zz_UseGlobalFont = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 38;
            this.label2.Text = "Buyer";
            // 
            // ctl_averagecost
            // 
            this.ctl_averagecost.BackColor = System.Drawing.Color.Transparent;
            this.ctl_averagecost.Bold = false;
            this.ctl_averagecost.Caption = "Average Cost";
            this.ctl_averagecost.Changed = false;
            this.ctl_averagecost.EditCaption = false;
            this.ctl_averagecost.Enabled = false;
            this.ctl_averagecost.FullDecimal = true;
            this.ctl_averagecost.Location = new System.Drawing.Point(189, 181);
            this.ctl_averagecost.Name = "ctl_averagecost";
            this.ctl_averagecost.RoundNearestCent = false;
            this.ctl_averagecost.Size = new System.Drawing.Size(117, 23);
            this.ctl_averagecost.TabIndex = 9;
            this.ctl_averagecost.UseParentBackColor = true;
            this.ctl_averagecost.zz_Enabled = true;
            this.ctl_averagecost.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_averagecost.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_averagecost.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_averagecost.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_averagecost.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.Left;
            this.ctl_averagecost.zz_OriginalDesign = false;
            this.ctl_averagecost.zz_ShowErrorColor = true;
            this.ctl_averagecost.zz_ShowNeedsSaveColor = true;
            this.ctl_averagecost.zz_Text = "";
            this.ctl_averagecost.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_averagecost.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_averagecost.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_averagecost.zz_UseGlobalColor = false;
            this.ctl_averagecost.zz_UseGlobalFont = false;
            // 
            // buyer
            // 
            this.buyer.AllowChange = true;
            this.buyer.AllowClear = false;
            this.buyer.AllowNew = false;
            this.buyer.AllowView = false;
            this.buyer.BackColor = System.Drawing.Color.Transparent;
            this.buyer.Bold = false;
            this.buyer.Caption = "Buyer";
            this.buyer.Changed = false;
            this.buyer.Location = new System.Drawing.Point(1, 157);
            this.buyer.Name = "buyer";
            this.buyer.Size = new System.Drawing.Size(306, 59);
            this.buyer.TabIndex = 10;
            this.buyer.UseParentBackColor = true;
            this.buyer.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.buyer.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            // 
            // ctl_cost
            // 
            this.ctl_cost.BackColor = System.Drawing.Color.Transparent;
            this.ctl_cost.Bold = false;
            this.ctl_cost.Caption = "Cost";
            this.ctl_cost.Changed = false;
            this.ctl_cost.EditCaption = false;
            this.ctl_cost.FullDecimal = true;
            this.ctl_cost.Location = new System.Drawing.Point(159, 17);
            this.ctl_cost.Name = "ctl_cost";
            this.ctl_cost.RoundNearestCent = false;
            this.ctl_cost.Size = new System.Drawing.Size(148, 39);
            this.ctl_cost.TabIndex = 2;
            this.ctl_cost.UseParentBackColor = true;
            this.ctl_cost.zz_Enabled = true;
            this.ctl_cost.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_cost.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_cost.zz_LabelColor = System.Drawing.Color.Green;
            this.ctl_cost.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_cost.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_cost.zz_OriginalDesign = false;
            this.ctl_cost.zz_ShowErrorColor = true;
            this.ctl_cost.zz_ShowNeedsSaveColor = true;
            this.ctl_cost.zz_Text = "";
            this.ctl_cost.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_cost.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_cost.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_cost.zz_UseGlobalColor = false;
            this.ctl_cost.zz_UseGlobalFont = false;
            // 
            // ctl_price
            // 
            this.ctl_price.BackColor = System.Drawing.Color.Transparent;
            this.ctl_price.Bold = false;
            this.ctl_price.Caption = "Price";
            this.ctl_price.Changed = false;
            this.ctl_price.EditCaption = false;
            this.ctl_price.FullDecimal = true;
            this.ctl_price.Location = new System.Drawing.Point(7, 17);
            this.ctl_price.Name = "ctl_price";
            this.ctl_price.RoundNearestCent = false;
            this.ctl_price.Size = new System.Drawing.Size(148, 39);
            this.ctl_price.TabIndex = 1;
            this.ctl_price.UseParentBackColor = true;
            this.ctl_price.zz_Enabled = true;
            this.ctl_price.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_price.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_price.zz_LabelColor = System.Drawing.Color.Green;
            this.ctl_price.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_price.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_price.zz_OriginalDesign = false;
            this.ctl_price.zz_ShowErrorColor = true;
            this.ctl_price.zz_ShowNeedsSaveColor = true;
            this.ctl_price.zz_Text = "";
            this.ctl_price.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_price.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_price.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_price.zz_UseGlobalColor = false;
            this.ctl_price.zz_UseGlobalFont = false;
            // 
            // ctl_highcost
            // 
            this.ctl_highcost.BackColor = System.Drawing.Color.Transparent;
            this.ctl_highcost.Bold = false;
            this.ctl_highcost.Caption = "H. Cost ";
            this.ctl_highcost.Changed = false;
            this.ctl_highcost.EditCaption = false;
            this.ctl_highcost.FullDecimal = true;
            this.ctl_highcost.Location = new System.Drawing.Point(167, 110);
            this.ctl_highcost.Name = "ctl_highcost";
            this.ctl_highcost.RoundNearestCent = false;
            this.ctl_highcost.Size = new System.Drawing.Size(140, 23);
            this.ctl_highcost.TabIndex = 27;
            this.ctl_highcost.UseParentBackColor = true;
            this.ctl_highcost.zz_Enabled = true;
            this.ctl_highcost.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_highcost.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_highcost.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_highcost.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_highcost.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.Left;
            this.ctl_highcost.zz_OriginalDesign = false;
            this.ctl_highcost.zz_ShowErrorColor = true;
            this.ctl_highcost.zz_ShowNeedsSaveColor = true;
            this.ctl_highcost.zz_Text = "";
            this.ctl_highcost.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_highcost.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_highcost.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_highcost.zz_UseGlobalColor = false;
            this.ctl_highcost.zz_UseGlobalFont = false;
            // 
            // ctl_lowprice
            // 
            this.ctl_lowprice.BackColor = System.Drawing.Color.Transparent;
            this.ctl_lowprice.Bold = false;
            this.ctl_lowprice.Caption = "L. Price ";
            this.ctl_lowprice.Changed = true;
            this.ctl_lowprice.EditCaption = false;
            this.ctl_lowprice.FullDecimal = true;
            this.ctl_lowprice.Location = new System.Drawing.Point(6, 58);
            this.ctl_lowprice.Name = "ctl_lowprice";
            this.ctl_lowprice.RoundNearestCent = false;
            this.ctl_lowprice.Size = new System.Drawing.Size(149, 23);
            this.ctl_lowprice.TabIndex = 4;
            this.ctl_lowprice.UseParentBackColor = true;
            this.ctl_lowprice.zz_Enabled = true;
            this.ctl_lowprice.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_lowprice.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_lowprice.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_lowprice.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_lowprice.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.Left;
            this.ctl_lowprice.zz_OriginalDesign = false;
            this.ctl_lowprice.zz_ShowErrorColor = true;
            this.ctl_lowprice.zz_ShowNeedsSaveColor = true;
            this.ctl_lowprice.zz_Text = "";
            this.ctl_lowprice.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_lowprice.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_lowprice.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_lowprice.zz_UseGlobalColor = false;
            this.ctl_lowprice.zz_UseGlobalFont = false;
            // 
            // ctl_midprice
            // 
            this.ctl_midprice.BackColor = System.Drawing.Color.Transparent;
            this.ctl_midprice.Bold = false;
            this.ctl_midprice.Caption = "M. Price";
            this.ctl_midprice.Changed = false;
            this.ctl_midprice.EditCaption = false;
            this.ctl_midprice.FullDecimal = true;
            this.ctl_midprice.Location = new System.Drawing.Point(6, 84);
            this.ctl_midprice.Name = "ctl_midprice";
            this.ctl_midprice.RoundNearestCent = false;
            this.ctl_midprice.Size = new System.Drawing.Size(149, 23);
            this.ctl_midprice.TabIndex = 6;
            this.ctl_midprice.UseParentBackColor = true;
            this.ctl_midprice.zz_Enabled = true;
            this.ctl_midprice.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_midprice.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_midprice.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_midprice.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_midprice.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.Left;
            this.ctl_midprice.zz_OriginalDesign = false;
            this.ctl_midprice.zz_ShowErrorColor = true;
            this.ctl_midprice.zz_ShowNeedsSaveColor = true;
            this.ctl_midprice.zz_Text = "";
            this.ctl_midprice.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_midprice.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_midprice.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_midprice.zz_UseGlobalColor = false;
            this.ctl_midprice.zz_UseGlobalFont = false;
            // 
            // ctl_actual_cost
            // 
            this.ctl_actual_cost.BackColor = System.Drawing.Color.Transparent;
            this.ctl_actual_cost.Bold = false;
            this.ctl_actual_cost.Caption = "M. Cost";
            this.ctl_actual_cost.Changed = false;
            this.ctl_actual_cost.EditCaption = false;
            this.ctl_actual_cost.FullDecimal = true;
            this.ctl_actual_cost.Location = new System.Drawing.Point(167, 84);
            this.ctl_actual_cost.Name = "ctl_actual_cost";
            this.ctl_actual_cost.RoundNearestCent = false;
            this.ctl_actual_cost.Size = new System.Drawing.Size(140, 23);
            this.ctl_actual_cost.TabIndex = 7;
            this.ctl_actual_cost.UseParentBackColor = true;
            this.ctl_actual_cost.zz_Enabled = true;
            this.ctl_actual_cost.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_actual_cost.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_actual_cost.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_actual_cost.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_actual_cost.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.Left;
            this.ctl_actual_cost.zz_OriginalDesign = false;
            this.ctl_actual_cost.zz_ShowErrorColor = true;
            this.ctl_actual_cost.zz_ShowNeedsSaveColor = true;
            this.ctl_actual_cost.zz_Text = "";
            this.ctl_actual_cost.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_actual_cost.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_actual_cost.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_actual_cost.zz_UseGlobalColor = false;
            this.ctl_actual_cost.zz_UseGlobalFont = false;
            // 
            // ctl_highprice
            // 
            this.ctl_highprice.BackColor = System.Drawing.Color.Transparent;
            this.ctl_highprice.Bold = false;
            this.ctl_highprice.Caption = "H. Price ";
            this.ctl_highprice.Changed = false;
            this.ctl_highprice.EditCaption = false;
            this.ctl_highprice.FullDecimal = true;
            this.ctl_highprice.Location = new System.Drawing.Point(6, 110);
            this.ctl_highprice.Name = "ctl_highprice";
            this.ctl_highprice.RoundNearestCent = false;
            this.ctl_highprice.Size = new System.Drawing.Size(149, 23);
            this.ctl_highprice.TabIndex = 8;
            this.ctl_highprice.UseParentBackColor = true;
            this.ctl_highprice.zz_Enabled = true;
            this.ctl_highprice.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_highprice.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_highprice.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_highprice.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_highprice.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.Left;
            this.ctl_highprice.zz_OriginalDesign = false;
            this.ctl_highprice.zz_ShowErrorColor = true;
            this.ctl_highprice.zz_ShowNeedsSaveColor = true;
            this.ctl_highprice.zz_Text = "";
            this.ctl_highprice.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_highprice.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_highprice.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_highprice.zz_UseGlobalColor = false;
            this.ctl_highprice.zz_UseGlobalFont = false;
            // 
            // ctl_lowcost
            // 
            this.ctl_lowcost.BackColor = System.Drawing.Color.Transparent;
            this.ctl_lowcost.Bold = false;
            this.ctl_lowcost.Caption = "L. Cost ";
            this.ctl_lowcost.Changed = false;
            this.ctl_lowcost.EditCaption = false;
            this.ctl_lowcost.FullDecimal = true;
            this.ctl_lowcost.Location = new System.Drawing.Point(167, 58);
            this.ctl_lowcost.Name = "ctl_lowcost";
            this.ctl_lowcost.RoundNearestCent = false;
            this.ctl_lowcost.Size = new System.Drawing.Size(140, 23);
            this.ctl_lowcost.TabIndex = 5;
            this.ctl_lowcost.UseParentBackColor = true;
            this.ctl_lowcost.zz_Enabled = true;
            this.ctl_lowcost.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_lowcost.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_lowcost.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_lowcost.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_lowcost.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.Left;
            this.ctl_lowcost.zz_OriginalDesign = false;
            this.ctl_lowcost.zz_ShowErrorColor = true;
            this.ctl_lowcost.zz_ShowNeedsSaveColor = true;
            this.ctl_lowcost.zz_Text = "";
            this.ctl_lowcost.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_lowcost.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_lowcost.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_lowcost.zz_UseGlobalColor = false;
            this.ctl_lowcost.zz_UseGlobalFont = false;
            // 
            // gbQtyInfo
            // 
            this.gbQtyInfo.Controls.Add(this.ctl_unit_of_measure);
            this.gbQtyInfo.Controls.Add(this.ctl_manufacturer);
            this.gbQtyInfo.Controls.Add(this.ctl_quantity);
            this.gbQtyInfo.Controls.Add(this.ctl_quantityallocated);
            this.gbQtyInfo.Controls.Add(this.ctl_expected_quantity);
            this.gbQtyInfo.Controls.Add(this.ctl_datecode);
            this.gbQtyInfo.Controls.Add(this.ctl_partsperpack);
            this.gbQtyInfo.Controls.Add(this.ctl_condition);
            this.gbQtyInfo.Controls.Add(this.ctl_packaging);
            this.gbQtyInfo.Controls.Add(this.ctl_user_defined);
            this.gbQtyInfo.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbQtyInfo.Location = new System.Drawing.Point(3, 132);
            this.gbQtyInfo.Name = "gbQtyInfo";
            this.gbQtyInfo.Size = new System.Drawing.Size(313, 225);
            this.gbQtyInfo.TabIndex = 4;
            this.gbQtyInfo.TabStop = false;
            this.gbQtyInfo.Text = "Item Information";
            // 
            // ctl_unit_of_measure
            // 
            this.ctl_unit_of_measure.AllCaps = false;
            this.ctl_unit_of_measure.AllowEdit = false;
            this.ctl_unit_of_measure.BackColor = System.Drawing.Color.Transparent;
            this.ctl_unit_of_measure.Bold = false;
            this.ctl_unit_of_measure.Caption = "UOM";
            this.ctl_unit_of_measure.Changed = false;
            this.ctl_unit_of_measure.ListName = "packaging";
            this.ctl_unit_of_measure.Location = new System.Drawing.Point(188, 21);
            this.ctl_unit_of_measure.Name = "ctl_unit_of_measure";
            this.ctl_unit_of_measure.SimpleList = null;
            this.ctl_unit_of_measure.Size = new System.Drawing.Size(169, 40);
            this.ctl_unit_of_measure.TabIndex = 3;
            this.ctl_unit_of_measure.UseParentBackColor = true;
            this.ctl_unit_of_measure.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_unit_of_measure.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_unit_of_measure.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_unit_of_measure.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_unit_of_measure.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_unit_of_measure.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_unit_of_measure.zz_OriginalDesign = false;
            this.ctl_unit_of_measure.zz_ShowNeedsSaveColor = true;
            this.ctl_unit_of_measure.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_unit_of_measure.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_unit_of_measure.zz_UseGlobalColor = false;
            this.ctl_unit_of_measure.zz_UseGlobalFont = false;
            // 
            // ctl_manufacturer
            // 
            this.ctl_manufacturer.AllCaps = false;
            this.ctl_manufacturer.AllowEdit = false;
            this.ctl_manufacturer.BackColor = System.Drawing.Color.Transparent;
            this.ctl_manufacturer.Bold = false;
            this.ctl_manufacturer.Caption = "Manufacturer";
            this.ctl_manufacturer.Changed = false;
            this.ctl_manufacturer.ListName = "manufacturer";
            this.ctl_manufacturer.Location = new System.Drawing.Point(162, 102);
            this.ctl_manufacturer.Name = "ctl_manufacturer";
            this.ctl_manufacturer.SimpleList = null;
            this.ctl_manufacturer.Size = new System.Drawing.Size(143, 40);
            this.ctl_manufacturer.TabIndex = 7;
            this.ctl_manufacturer.UseParentBackColor = true;
            this.ctl_manufacturer.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_manufacturer.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_manufacturer.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_manufacturer.zz_LabelColor = System.Drawing.Color.Blue;
            this.ctl_manufacturer.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_manufacturer.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_manufacturer.zz_OriginalDesign = false;
            this.ctl_manufacturer.zz_ShowNeedsSaveColor = true;
            this.ctl_manufacturer.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_manufacturer.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_manufacturer.zz_UseGlobalColor = false;
            this.ctl_manufacturer.zz_UseGlobalFont = false;
            // 
            // ctl_quantity
            // 
            this.ctl_quantity.BackColor = System.Drawing.Color.Transparent;
            this.ctl_quantity.Bold = false;
            this.ctl_quantity.Caption = "Quantity";
            this.ctl_quantity.Changed = false;
            this.ctl_quantity.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_quantity.Location = new System.Drawing.Point(8, 20);
            this.ctl_quantity.Name = "ctl_quantity";
            this.ctl_quantity.Size = new System.Drawing.Size(173, 39);
            this.ctl_quantity.TabIndex = 2;
            this.ctl_quantity.UseParentBackColor = true;
            this.ctl_quantity.zz_Enabled = true;
            this.ctl_quantity.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_quantity.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_quantity.zz_LabelColor = System.Drawing.Color.Blue;
            this.ctl_quantity.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_quantity.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_quantity.zz_OriginalDesign = false;
            this.ctl_quantity.zz_ShowErrorColor = true;
            this.ctl_quantity.zz_ShowNeedsSaveColor = true;
            this.ctl_quantity.zz_Text = "";
            this.ctl_quantity.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_quantity.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_quantity.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_quantity.zz_UseGlobalColor = false;
            this.ctl_quantity.zz_UseGlobalFont = false;
            // 
            // ctl_quantityallocated
            // 
            this.ctl_quantityallocated.BackColor = System.Drawing.Color.Transparent;
            this.ctl_quantityallocated.Bold = false;
            this.ctl_quantityallocated.Caption = "Qty Allocated";
            this.ctl_quantityallocated.Changed = false;
            this.ctl_quantityallocated.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_quantityallocated.Location = new System.Drawing.Point(7, 58);
            this.ctl_quantityallocated.Name = "ctl_quantityallocated";
            this.ctl_quantityallocated.Size = new System.Drawing.Size(148, 39);
            this.ctl_quantityallocated.TabIndex = 4;
            this.ctl_quantityallocated.UseParentBackColor = true;
            this.ctl_quantityallocated.zz_Enabled = true;
            this.ctl_quantityallocated.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_quantityallocated.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_quantityallocated.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_quantityallocated.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_quantityallocated.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_quantityallocated.zz_OriginalDesign = false;
            this.ctl_quantityallocated.zz_ShowErrorColor = true;
            this.ctl_quantityallocated.zz_ShowNeedsSaveColor = true;
            this.ctl_quantityallocated.zz_Text = "";
            this.ctl_quantityallocated.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_quantityallocated.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_quantityallocated.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_quantityallocated.zz_UseGlobalColor = false;
            this.ctl_quantityallocated.zz_UseGlobalFont = false;
            this.ctl_quantityallocated.Load += new System.EventHandler(this.ctl_quantityallocated_Load);
            // 
            // ctl_expected_quantity
            // 
            this.ctl_expected_quantity.BackColor = System.Drawing.Color.Transparent;
            this.ctl_expected_quantity.Bold = false;
            this.ctl_expected_quantity.Caption = "Qty Expected";
            this.ctl_expected_quantity.Changed = false;
            this.ctl_expected_quantity.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_expected_quantity.Location = new System.Drawing.Point(161, 58);
            this.ctl_expected_quantity.Name = "ctl_expected_quantity";
            this.ctl_expected_quantity.Size = new System.Drawing.Size(145, 39);
            this.ctl_expected_quantity.TabIndex = 5;
            this.ctl_expected_quantity.UseParentBackColor = true;
            this.ctl_expected_quantity.zz_Enabled = true;
            this.ctl_expected_quantity.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_expected_quantity.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_expected_quantity.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_expected_quantity.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_expected_quantity.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_expected_quantity.zz_OriginalDesign = false;
            this.ctl_expected_quantity.zz_ShowErrorColor = true;
            this.ctl_expected_quantity.zz_ShowNeedsSaveColor = true;
            this.ctl_expected_quantity.zz_Text = "";
            this.ctl_expected_quantity.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_expected_quantity.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_expected_quantity.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_expected_quantity.zz_UseGlobalColor = false;
            this.ctl_expected_quantity.zz_UseGlobalFont = false;
            // 
            // ctl_datecode
            // 
            this.ctl_datecode.AllCaps = false;
            this.ctl_datecode.BackColor = System.Drawing.Color.Transparent;
            this.ctl_datecode.Bold = false;
            this.ctl_datecode.Caption = "Date Code";
            this.ctl_datecode.Changed = false;
            this.ctl_datecode.IsEmail = false;
            this.ctl_datecode.IsURL = false;
            this.ctl_datecode.Location = new System.Drawing.Point(7, 100);
            this.ctl_datecode.Name = "ctl_datecode";
            this.ctl_datecode.PasswordChar = '\0';
            this.ctl_datecode.Size = new System.Drawing.Size(148, 39);
            this.ctl_datecode.TabIndex = 6;
            this.ctl_datecode.UseParentBackColor = true;
            this.ctl_datecode.zz_Enabled = true;
            this.ctl_datecode.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_datecode.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_datecode.zz_LabelColor = System.Drawing.Color.Blue;
            this.ctl_datecode.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_datecode.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_datecode.zz_OriginalDesign = false;
            this.ctl_datecode.zz_ShowLinkButton = false;
            this.ctl_datecode.zz_ShowNeedsSaveColor = true;
            this.ctl_datecode.zz_Text = "";
            this.ctl_datecode.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_datecode.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_datecode.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_datecode.zz_UseGlobalColor = false;
            this.ctl_datecode.zz_UseGlobalFont = false;
            // 
            // ctl_partsperpack
            // 
            this.ctl_partsperpack.BackColor = System.Drawing.Color.Transparent;
            this.ctl_partsperpack.Bold = false;
            this.ctl_partsperpack.Caption = "Parts Per Pack";
            this.ctl_partsperpack.Changed = false;
            this.ctl_partsperpack.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_partsperpack.Location = new System.Drawing.Point(7, 140);
            this.ctl_partsperpack.Name = "ctl_partsperpack";
            this.ctl_partsperpack.Size = new System.Drawing.Size(148, 39);
            this.ctl_partsperpack.TabIndex = 8;
            this.ctl_partsperpack.UseParentBackColor = true;
            this.ctl_partsperpack.zz_Enabled = true;
            this.ctl_partsperpack.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_partsperpack.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_partsperpack.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_partsperpack.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_partsperpack.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_partsperpack.zz_OriginalDesign = false;
            this.ctl_partsperpack.zz_ShowErrorColor = true;
            this.ctl_partsperpack.zz_ShowNeedsSaveColor = true;
            this.ctl_partsperpack.zz_Text = "";
            this.ctl_partsperpack.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_partsperpack.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_partsperpack.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_partsperpack.zz_UseGlobalColor = false;
            this.ctl_partsperpack.zz_UseGlobalFont = false;
            // 
            // ctl_condition
            // 
            this.ctl_condition.AllCaps = false;
            this.ctl_condition.AllowEdit = false;
            this.ctl_condition.BackColor = System.Drawing.Color.Transparent;
            this.ctl_condition.Bold = false;
            this.ctl_condition.Caption = "Condition";
            this.ctl_condition.Changed = false;
            this.ctl_condition.ListName = "condition";
            this.ctl_condition.Location = new System.Drawing.Point(7, 181);
            this.ctl_condition.Name = "ctl_condition";
            this.ctl_condition.SimpleList = null;
            this.ctl_condition.Size = new System.Drawing.Size(148, 40);
            this.ctl_condition.TabIndex = 10;
            this.ctl_condition.UseParentBackColor = true;
            this.ctl_condition.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_condition.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_condition.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_condition.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_condition.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_condition.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_condition.zz_OriginalDesign = false;
            this.ctl_condition.zz_ShowNeedsSaveColor = true;
            this.ctl_condition.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_condition.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_condition.zz_UseGlobalColor = false;
            this.ctl_condition.zz_UseGlobalFont = false;
            // 
            // ctl_packaging
            // 
            this.ctl_packaging.AllCaps = false;
            this.ctl_packaging.AllowEdit = false;
            this.ctl_packaging.BackColor = System.Drawing.Color.Transparent;
            this.ctl_packaging.Bold = false;
            this.ctl_packaging.Caption = "Packaging";
            this.ctl_packaging.Changed = false;
            this.ctl_packaging.ListName = "packaging";
            this.ctl_packaging.Location = new System.Drawing.Point(161, 181);
            this.ctl_packaging.Name = "ctl_packaging";
            this.ctl_packaging.SimpleList = null;
            this.ctl_packaging.Size = new System.Drawing.Size(145, 40);
            this.ctl_packaging.TabIndex = 11;
            this.ctl_packaging.UseParentBackColor = true;
            this.ctl_packaging.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_packaging.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_packaging.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_packaging.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_packaging.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_packaging.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_packaging.zz_OriginalDesign = false;
            this.ctl_packaging.zz_ShowNeedsSaveColor = true;
            this.ctl_packaging.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_packaging.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_packaging.zz_UseGlobalColor = false;
            this.ctl_packaging.zz_UseGlobalFont = false;
            // 
            // ctl_user_defined
            // 
            this.ctl_user_defined.AllCaps = false;
            this.ctl_user_defined.BackColor = System.Drawing.Color.Transparent;
            this.ctl_user_defined.Bold = false;
            this.ctl_user_defined.Caption = "Cage Code";
            this.ctl_user_defined.Changed = false;
            this.ctl_user_defined.IsEmail = false;
            this.ctl_user_defined.IsURL = false;
            this.ctl_user_defined.Location = new System.Drawing.Point(161, 140);
            this.ctl_user_defined.Name = "ctl_user_defined";
            this.ctl_user_defined.PasswordChar = '\0';
            this.ctl_user_defined.Size = new System.Drawing.Size(145, 39);
            this.ctl_user_defined.TabIndex = 9;
            this.ctl_user_defined.UseParentBackColor = true;
            this.ctl_user_defined.zz_Enabled = true;
            this.ctl_user_defined.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_user_defined.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_user_defined.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_user_defined.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_user_defined.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_user_defined.zz_OriginalDesign = false;
            this.ctl_user_defined.zz_ShowLinkButton = false;
            this.ctl_user_defined.zz_ShowNeedsSaveColor = true;
            this.ctl_user_defined.zz_Text = "";
            this.ctl_user_defined.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_user_defined.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_user_defined.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_user_defined.zz_UseGlobalColor = false;
            this.ctl_user_defined.zz_UseGlobalFont = false;
            // 
            // ctl_mfg_certifications
            // 
            this.ctl_mfg_certifications.BackColor = System.Drawing.Color.Transparent;
            this.ctl_mfg_certifications.Bold = false;
            this.ctl_mfg_certifications.Caption = "MFG Certifications";
            this.ctl_mfg_certifications.Changed = false;
            this.ctl_mfg_certifications.Location = new System.Drawing.Point(101, 3);
            this.ctl_mfg_certifications.Name = "ctl_mfg_certifications";
            this.ctl_mfg_certifications.Size = new System.Drawing.Size(132, 18);
            this.ctl_mfg_certifications.TabIndex = 22;
            this.ctl_mfg_certifications.UseParentBackColor = true;
            this.ctl_mfg_certifications.zz_CheckValue = false;
            this.ctl_mfg_certifications.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_mfg_certifications.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_mfg_certifications.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_mfg_certifications.zz_OriginalDesign = false;
            this.ctl_mfg_certifications.zz_ShowNeedsSaveColor = true;
            this.ctl_mfg_certifications.CheckChanged += new NewMethod.CheckChangedHandler(this.ctl_mfg_certifications_CheckChanged);
            // 
            // ctl_no_complete_report
            // 
            this.ctl_no_complete_report.BackColor = System.Drawing.Color.Transparent;
            this.ctl_no_complete_report.Bold = false;
            this.ctl_no_complete_report.Caption = "No Complete Report";
            this.ctl_no_complete_report.Changed = false;
            this.ctl_no_complete_report.Location = new System.Drawing.Point(239, 3);
            this.ctl_no_complete_report.Name = "ctl_no_complete_report";
            this.ctl_no_complete_report.Size = new System.Drawing.Size(135, 18);
            this.ctl_no_complete_report.TabIndex = 23;
            this.ctl_no_complete_report.UseParentBackColor = true;
            this.ctl_no_complete_report.zz_CheckValue = false;
            this.ctl_no_complete_report.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_no_complete_report.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_no_complete_report.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_no_complete_report.zz_OriginalDesign = false;
            this.ctl_no_complete_report.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_do_not_export
            // 
            this.ctl_do_not_export.BackColor = System.Drawing.Color.Transparent;
            this.ctl_do_not_export.Bold = false;
            this.ctl_do_not_export.Caption = "Do Not Export";
            this.ctl_do_not_export.Changed = false;
            this.ctl_do_not_export.Location = new System.Drawing.Point(528, 2);
            this.ctl_do_not_export.Name = "ctl_do_not_export";
            this.ctl_do_not_export.Size = new System.Drawing.Size(101, 18);
            this.ctl_do_not_export.TabIndex = 26;
            this.ctl_do_not_export.UseParentBackColor = true;
            this.ctl_do_not_export.zz_CheckValue = false;
            this.ctl_do_not_export.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_do_not_export.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_do_not_export.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_do_not_export.zz_OriginalDesign = false;
            this.ctl_do_not_export.zz_ShowNeedsSaveColor = true;
            // 
            // cStub
            // 
            this.cStub.Caption = "Vendor";
            this.cStub.Location = new System.Drawing.Point(321, 279);
            this.cStub.Name = "cStub";
            this.cStub.Size = new System.Drawing.Size(306, 95);
            this.cStub.TabIndex = 21;
            this.cStub.TabStop = false;
            // 
            // ctl_alternatepart
            // 
            this.ctl_alternatepart.AllCaps = false;
            this.ctl_alternatepart.BackColor = System.Drawing.Color.Transparent;
            this.ctl_alternatepart.Bold = false;
            this.ctl_alternatepart.Caption = "Alternate Part";
            this.ctl_alternatepart.Changed = false;
            this.ctl_alternatepart.IsEmail = false;
            this.ctl_alternatepart.IsURL = false;
            this.ctl_alternatepart.Location = new System.Drawing.Point(3, 5);
            this.ctl_alternatepart.Name = "ctl_alternatepart";
            this.ctl_alternatepart.PasswordChar = '\0';
            this.ctl_alternatepart.Size = new System.Drawing.Size(300, 39);
            this.ctl_alternatepart.TabIndex = 3;
            this.ctl_alternatepart.UseParentBackColor = true;
            this.ctl_alternatepart.zz_Enabled = true;
            this.ctl_alternatepart.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_alternatepart.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_alternatepart.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_alternatepart.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_alternatepart.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_alternatepart.zz_OriginalDesign = false;
            this.ctl_alternatepart.zz_ShowLinkButton = false;
            this.ctl_alternatepart.zz_ShowNeedsSaveColor = true;
            this.ctl_alternatepart.zz_Text = "";
            this.ctl_alternatepart.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_alternatepart.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_alternatepart.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_alternatepart.zz_UseGlobalColor = false;
            this.ctl_alternatepart.zz_UseGlobalFont = false;
            // 
            // tpMaster
            // 
            this.tpMaster.Controls.Add(this.ctl_ProductType);
            this.tpMaster.Controls.Add(this.gb_SSD);
            this.tpMaster.Location = new System.Drawing.Point(4, 22);
            this.tpMaster.Name = "tpMaster";
            this.tpMaster.Size = new System.Drawing.Size(635, 435);
            this.tpMaster.TabIndex = 9;
            this.tpMaster.Text = "Master Detail";
            this.tpMaster.UseVisualStyleBackColor = true;
            // 
            // ctl_ProductType
            // 
            this.ctl_ProductType.AllCaps = false;
            this.ctl_ProductType.AllowEdit = true;
            this.ctl_ProductType.BackColor = System.Drawing.Color.Transparent;
            this.ctl_ProductType.Bold = false;
            this.ctl_ProductType.Caption = "Product Type";
            this.ctl_ProductType.Changed = false;
            this.ctl_ProductType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ProductType.ListName = "ProductType";
            this.ctl_ProductType.Location = new System.Drawing.Point(320, 4);
            this.ctl_ProductType.Name = "ctl_ProductType";
            this.ctl_ProductType.SimpleList = null;
            this.ctl_ProductType.Size = new System.Drawing.Size(161, 53);
            this.ctl_ProductType.TabIndex = 131;
            this.ctl_ProductType.UseParentBackColor = true;
            this.ctl_ProductType.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_ProductType.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_ProductType.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_ProductType.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_ProductType.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.ctl_ProductType.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_ProductType.zz_OriginalDesign = true;
            this.ctl_ProductType.zz_ShowNeedsSaveColor = true;
            this.ctl_ProductType.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_ProductType.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ProductType.zz_UseGlobalColor = false;
            this.ctl_ProductType.zz_UseGlobalFont = false;
            this.ctl_ProductType.SelectionChanged += new NewMethod.nEdit_List.SelectionChangedHandler(this.ctl_ProductType_SelectionChanged);
            // 
            // gb_SSD
            // 
            this.gb_SSD.Controls.Add(this.ctl_maxtemp);
            this.gb_SSD.Controls.Add(this.ctl_ssd_interface);
            this.gb_SSD.Controls.Add(this.ctl_formfactor);
            this.gb_SSD.Controls.Add(this.ctl_capacity);
            this.gb_SSD.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_SSD.Location = new System.Drawing.Point(3, 4);
            this.gb_SSD.Name = "gb_SSD";
            this.gb_SSD.Size = new System.Drawing.Size(313, 265);
            this.gb_SSD.TabIndex = 32;
            this.gb_SSD.TabStop = false;
            this.gb_SSD.Text = "Item Information";
            this.gb_SSD.Visible = false;
            // 
            // ctl_maxtemp
            // 
            this.ctl_maxtemp.AllCaps = false;
            this.ctl_maxtemp.BackColor = System.Drawing.Color.Transparent;
            this.ctl_maxtemp.Bold = false;
            this.ctl_maxtemp.Caption = "Max. Temp (C)";
            this.ctl_maxtemp.Changed = false;
            this.ctl_maxtemp.IsEmail = false;
            this.ctl_maxtemp.IsURL = false;
            this.ctl_maxtemp.Location = new System.Drawing.Point(4, 66);
            this.ctl_maxtemp.Name = "ctl_maxtemp";
            this.ctl_maxtemp.PasswordChar = '\0';
            this.ctl_maxtemp.Size = new System.Drawing.Size(90, 39);
            this.ctl_maxtemp.TabIndex = 17;
            this.ctl_maxtemp.UseParentBackColor = true;
            this.ctl_maxtemp.zz_Enabled = true;
            this.ctl_maxtemp.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_maxtemp.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_maxtemp.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_maxtemp.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_maxtemp.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_maxtemp.zz_OriginalDesign = false;
            this.ctl_maxtemp.zz_ShowLinkButton = false;
            this.ctl_maxtemp.zz_ShowNeedsSaveColor = true;
            this.ctl_maxtemp.zz_Text = "";
            this.ctl_maxtemp.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_maxtemp.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_maxtemp.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_maxtemp.zz_UseGlobalColor = false;
            this.ctl_maxtemp.zz_UseGlobalFont = false;
            // 
            // ctl_ssd_interface
            // 
            this.ctl_ssd_interface.AllCaps = false;
            this.ctl_ssd_interface.BackColor = System.Drawing.Color.Transparent;
            this.ctl_ssd_interface.Bold = false;
            this.ctl_ssd_interface.Caption = "Interface";
            this.ctl_ssd_interface.Changed = false;
            this.ctl_ssd_interface.IsEmail = false;
            this.ctl_ssd_interface.IsURL = false;
            this.ctl_ssd_interface.Location = new System.Drawing.Point(100, 21);
            this.ctl_ssd_interface.Name = "ctl_ssd_interface";
            this.ctl_ssd_interface.PasswordChar = '\0';
            this.ctl_ssd_interface.Size = new System.Drawing.Size(79, 39);
            this.ctl_ssd_interface.TabIndex = 16;
            this.ctl_ssd_interface.UseParentBackColor = true;
            this.ctl_ssd_interface.zz_Enabled = true;
            this.ctl_ssd_interface.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_ssd_interface.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ssd_interface.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_ssd_interface.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ssd_interface.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_ssd_interface.zz_OriginalDesign = false;
            this.ctl_ssd_interface.zz_ShowLinkButton = false;
            this.ctl_ssd_interface.zz_ShowNeedsSaveColor = true;
            this.ctl_ssd_interface.zz_Text = "";
            this.ctl_ssd_interface.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_ssd_interface.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_ssd_interface.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ssd_interface.zz_UseGlobalColor = false;
            this.ctl_ssd_interface.zz_UseGlobalFont = false;
            // 
            // ctl_formfactor
            // 
            this.ctl_formfactor.AllCaps = false;
            this.ctl_formfactor.BackColor = System.Drawing.Color.Transparent;
            this.ctl_formfactor.Bold = false;
            this.ctl_formfactor.Caption = "Form Factor";
            this.ctl_formfactor.Changed = false;
            this.ctl_formfactor.IsEmail = false;
            this.ctl_formfactor.IsURL = false;
            this.ctl_formfactor.Location = new System.Drawing.Point(185, 21);
            this.ctl_formfactor.Name = "ctl_formfactor";
            this.ctl_formfactor.PasswordChar = '\0';
            this.ctl_formfactor.Size = new System.Drawing.Size(88, 39);
            this.ctl_formfactor.TabIndex = 15;
            this.ctl_formfactor.UseParentBackColor = true;
            this.ctl_formfactor.zz_Enabled = true;
            this.ctl_formfactor.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_formfactor.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_formfactor.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_formfactor.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_formfactor.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_formfactor.zz_OriginalDesign = false;
            this.ctl_formfactor.zz_ShowLinkButton = false;
            this.ctl_formfactor.zz_ShowNeedsSaveColor = true;
            this.ctl_formfactor.zz_Text = "";
            this.ctl_formfactor.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_formfactor.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_formfactor.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_formfactor.zz_UseGlobalColor = false;
            this.ctl_formfactor.zz_UseGlobalFont = false;
            // 
            // ctl_capacity
            // 
            this.ctl_capacity.AllCaps = false;
            this.ctl_capacity.BackColor = System.Drawing.Color.Transparent;
            this.ctl_capacity.Bold = false;
            this.ctl_capacity.Caption = "Capacity";
            this.ctl_capacity.Changed = false;
            this.ctl_capacity.IsEmail = false;
            this.ctl_capacity.IsURL = false;
            this.ctl_capacity.Location = new System.Drawing.Point(6, 21);
            this.ctl_capacity.Name = "ctl_capacity";
            this.ctl_capacity.PasswordChar = '\0';
            this.ctl_capacity.Size = new System.Drawing.Size(88, 39);
            this.ctl_capacity.TabIndex = 14;
            this.ctl_capacity.UseParentBackColor = true;
            this.ctl_capacity.zz_Enabled = true;
            this.ctl_capacity.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_capacity.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_capacity.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_capacity.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_capacity.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_capacity.zz_OriginalDesign = false;
            this.ctl_capacity.zz_ShowLinkButton = false;
            this.ctl_capacity.zz_ShowNeedsSaveColor = true;
            this.ctl_capacity.zz_Text = "";
            this.ctl_capacity.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_capacity.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_capacity.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_capacity.zz_UseGlobalColor = false;
            this.ctl_capacity.zz_UseGlobalFont = false;
            // 
            // tpExtra
            // 
            this.tpExtra.Controls.Add(this.nEdit_User1);
            this.tpExtra.Controls.Add(this.ctl_category);
            this.tpExtra.Controls.Add(this.ctl_rohs_info);
            this.tpExtra.Controls.Add(this.ctl_description);
            this.tpExtra.Controls.Add(this.ctl_leadtime);
            this.tpExtra.Controls.Add(this.ctl_printcomment);
            this.tpExtra.Controls.Add(this.ctl_islocked);
            this.tpExtra.Controls.Add(this.ctl_importid);
            this.tpExtra.Controls.Add(this.ctl_userdata_02);
            this.tpExtra.Controls.Add(this.ctl_datemodified);
            this.tpExtra.Controls.Add(this.ctl_datecreated);
            this.tpExtra.Controls.Add(this.ctl_buytype);
            this.tpExtra.Controls.Add(this.ctl_country);
            this.tpExtra.Controls.Add(this.ctl_alternatequantity);
            this.tpExtra.Controls.Add(this.ctl_partsetup);
            this.tpExtra.Controls.Add(this.ctl_dateconfirmed);
            this.tpExtra.Location = new System.Drawing.Point(4, 22);
            this.tpExtra.Name = "tpExtra";
            this.tpExtra.Padding = new System.Windows.Forms.Padding(3);
            this.tpExtra.Size = new System.Drawing.Size(635, 435);
            this.tpExtra.TabIndex = 2;
            this.tpExtra.Text = "Extra";
            this.tpExtra.UseVisualStyleBackColor = true;
            // 
            // nEdit_User1
            // 
            this.nEdit_User1.AllowChange = true;
            this.nEdit_User1.AllowClear = false;
            this.nEdit_User1.AllowNew = false;
            this.nEdit_User1.AllowView = false;
            this.nEdit_User1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nEdit_User1.Bold = false;
            this.nEdit_User1.Caption = "<caption>";
            this.nEdit_User1.Changed = false;
            this.nEdit_User1.Location = new System.Drawing.Point(24, 11);
            this.nEdit_User1.Name = "nEdit_User1";
            this.nEdit_User1.Size = new System.Drawing.Size(351, 39);
            this.nEdit_User1.TabIndex = 45;
            this.nEdit_User1.UseParentBackColor = false;
            this.nEdit_User1.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.nEdit_User1.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // ctl_category
            // 
            this.ctl_category.AllCaps = false;
            this.ctl_category.AllowEdit = false;
            this.ctl_category.BackColor = System.Drawing.Color.Transparent;
            this.ctl_category.Bold = false;
            this.ctl_category.Caption = "Category";
            this.ctl_category.Changed = false;
            this.ctl_category.ListName = "category";
            this.ctl_category.Location = new System.Drawing.Point(188, 189);
            this.ctl_category.Name = "ctl_category";
            this.ctl_category.SimpleList = null;
            this.ctl_category.Size = new System.Drawing.Size(148, 40);
            this.ctl_category.TabIndex = 44;
            this.ctl_category.UseParentBackColor = true;
            this.ctl_category.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_category.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_category.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_category.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_category.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_category.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_category.zz_OriginalDesign = false;
            this.ctl_category.zz_ShowNeedsSaveColor = true;
            this.ctl_category.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_category.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_category.zz_UseGlobalColor = false;
            this.ctl_category.zz_UseGlobalFont = false;
            // 
            // ctl_rohs_info
            // 
            this.ctl_rohs_info.AllCaps = false;
            this.ctl_rohs_info.AllowEdit = true;
            this.ctl_rohs_info.BackColor = System.Drawing.Color.Transparent;
            this.ctl_rohs_info.Bold = false;
            this.ctl_rohs_info.Caption = "ROHS Info";
            this.ctl_rohs_info.Changed = false;
            this.ctl_rohs_info.ListName = "partsetup";
            this.ctl_rohs_info.Location = new System.Drawing.Point(6, 185);
            this.ctl_rohs_info.Name = "ctl_rohs_info";
            this.ctl_rohs_info.SimpleList = null;
            this.ctl_rohs_info.Size = new System.Drawing.Size(170, 40);
            this.ctl_rohs_info.TabIndex = 43;
            this.ctl_rohs_info.UseParentBackColor = true;
            this.ctl_rohs_info.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_rohs_info.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_rohs_info.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_rohs_info.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_rohs_info.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_rohs_info.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_rohs_info.zz_OriginalDesign = false;
            this.ctl_rohs_info.zz_ShowNeedsSaveColor = true;
            this.ctl_rohs_info.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_rohs_info.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_rohs_info.zz_UseGlobalColor = false;
            this.ctl_rohs_info.zz_UseGlobalFont = false;
            // 
            // ctl_description
            // 
            this.ctl_description.BackColor = System.Drawing.Color.Transparent;
            this.ctl_description.Bold = false;
            this.ctl_description.Caption = "Description";
            this.ctl_description.Changed = false;
            this.ctl_description.DateLines = false;
            this.ctl_description.Location = new System.Drawing.Point(3, 235);
            this.ctl_description.Name = "ctl_description";
            this.ctl_description.Size = new System.Drawing.Size(623, 102);
            this.ctl_description.TabIndex = 41;
            this.ctl_description.UseParentBackColor = true;
            this.ctl_description.zz_Enabled = true;
            this.ctl_description.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_description.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_description.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_description.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_description.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_description.zz_OriginalDesign = false;
            this.ctl_description.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ctl_description.zz_ShowNeedsSaveColor = true;
            this.ctl_description.zz_Text = "";
            this.ctl_description.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_description.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_description.zz_UseGlobalColor = false;
            this.ctl_description.zz_UseGlobalFont = false;
            // 
            // ctl_leadtime
            // 
            this.ctl_leadtime.AllCaps = false;
            this.ctl_leadtime.BackColor = System.Drawing.Color.Transparent;
            this.ctl_leadtime.Bold = false;
            this.ctl_leadtime.Caption = "Lead Time";
            this.ctl_leadtime.Changed = false;
            this.ctl_leadtime.IsEmail = false;
            this.ctl_leadtime.IsURL = false;
            this.ctl_leadtime.Location = new System.Drawing.Point(6, 140);
            this.ctl_leadtime.Name = "ctl_leadtime";
            this.ctl_leadtime.PasswordChar = '\0';
            this.ctl_leadtime.Size = new System.Drawing.Size(170, 39);
            this.ctl_leadtime.TabIndex = 37;
            this.ctl_leadtime.UseParentBackColor = true;
            this.ctl_leadtime.zz_Enabled = true;
            this.ctl_leadtime.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_leadtime.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_leadtime.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_leadtime.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_leadtime.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_leadtime.zz_OriginalDesign = false;
            this.ctl_leadtime.zz_ShowLinkButton = false;
            this.ctl_leadtime.zz_ShowNeedsSaveColor = true;
            this.ctl_leadtime.zz_Text = "";
            this.ctl_leadtime.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_leadtime.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_leadtime.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_leadtime.zz_UseGlobalColor = false;
            this.ctl_leadtime.zz_UseGlobalFont = false;
            // 
            // ctl_printcomment
            // 
            this.ctl_printcomment.BackColor = System.Drawing.Color.Transparent;
            this.ctl_printcomment.Bold = false;
            this.ctl_printcomment.Caption = "Comment";
            this.ctl_printcomment.Changed = false;
            this.ctl_printcomment.DateLines = false;
            this.ctl_printcomment.Location = new System.Drawing.Point(3, 343);
            this.ctl_printcomment.Name = "ctl_printcomment";
            this.ctl_printcomment.Size = new System.Drawing.Size(623, 112);
            this.ctl_printcomment.TabIndex = 42;
            this.ctl_printcomment.UseParentBackColor = true;
            this.ctl_printcomment.zz_Enabled = true;
            this.ctl_printcomment.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_printcomment.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_printcomment.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_printcomment.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_printcomment.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_printcomment.zz_OriginalDesign = false;
            this.ctl_printcomment.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ctl_printcomment.zz_ShowNeedsSaveColor = true;
            this.ctl_printcomment.zz_Text = "";
            this.ctl_printcomment.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_printcomment.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_printcomment.zz_UseGlobalColor = false;
            this.ctl_printcomment.zz_UseGlobalFont = false;
            // 
            // ctl_islocked
            // 
            this.ctl_islocked.BackColor = System.Drawing.Color.Transparent;
            this.ctl_islocked.Bold = false;
            this.ctl_islocked.Caption = "Locked";
            this.ctl_islocked.Changed = false;
            this.ctl_islocked.Location = new System.Drawing.Point(563, 4);
            this.ctl_islocked.Name = "ctl_islocked";
            this.ctl_islocked.Size = new System.Drawing.Size(66, 18);
            this.ctl_islocked.TabIndex = 30;
            this.ctl_islocked.UseParentBackColor = true;
            this.ctl_islocked.zz_CheckValue = false;
            this.ctl_islocked.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_islocked.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_islocked.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_islocked.zz_OriginalDesign = false;
            this.ctl_islocked.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_importid
            // 
            this.ctl_importid.AllCaps = false;
            this.ctl_importid.BackColor = System.Drawing.Color.Transparent;
            this.ctl_importid.Bold = false;
            this.ctl_importid.Caption = "Import ID";
            this.ctl_importid.Changed = false;
            this.ctl_importid.IsEmail = false;
            this.ctl_importid.IsURL = false;
            this.ctl_importid.Location = new System.Drawing.Point(438, 11);
            this.ctl_importid.Name = "ctl_importid";
            this.ctl_importid.PasswordChar = '\0';
            this.ctl_importid.Size = new System.Drawing.Size(191, 39);
            this.ctl_importid.TabIndex = 31;
            this.ctl_importid.UseParentBackColor = true;
            this.ctl_importid.zz_Enabled = true;
            this.ctl_importid.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_importid.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_importid.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_importid.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_importid.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_importid.zz_OriginalDesign = false;
            this.ctl_importid.zz_ShowLinkButton = false;
            this.ctl_importid.zz_ShowNeedsSaveColor = true;
            this.ctl_importid.zz_Text = "";
            this.ctl_importid.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_importid.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_importid.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_importid.zz_UseGlobalColor = false;
            this.ctl_importid.zz_UseGlobalFont = false;
            // 
            // ctl_userdata_02
            // 
            this.ctl_userdata_02.AllCaps = false;
            this.ctl_userdata_02.BackColor = System.Drawing.Color.Transparent;
            this.ctl_userdata_02.Bold = false;
            this.ctl_userdata_02.Caption = "UserData 02 / QB Number";
            this.ctl_userdata_02.Changed = false;
            this.ctl_userdata_02.IsEmail = false;
            this.ctl_userdata_02.IsURL = false;
            this.ctl_userdata_02.Location = new System.Drawing.Point(324, 95);
            this.ctl_userdata_02.Name = "ctl_userdata_02";
            this.ctl_userdata_02.PasswordChar = '\0';
            this.ctl_userdata_02.Size = new System.Drawing.Size(305, 39);
            this.ctl_userdata_02.TabIndex = 36;
            this.ctl_userdata_02.UseParentBackColor = true;
            this.ctl_userdata_02.zz_Enabled = true;
            this.ctl_userdata_02.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_userdata_02.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_userdata_02.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_userdata_02.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_userdata_02.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_userdata_02.zz_OriginalDesign = false;
            this.ctl_userdata_02.zz_ShowLinkButton = false;
            this.ctl_userdata_02.zz_ShowNeedsSaveColor = true;
            this.ctl_userdata_02.zz_Text = "";
            this.ctl_userdata_02.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_userdata_02.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_userdata_02.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_userdata_02.zz_UseGlobalColor = false;
            this.ctl_userdata_02.zz_UseGlobalFont = false;
            // 
            // ctl_datemodified
            // 
            this.ctl_datemodified.AllowClear = false;
            this.ctl_datemodified.BackColor = System.Drawing.Color.Transparent;
            this.ctl_datemodified.Bold = false;
            this.ctl_datemodified.Caption = "Date Modified";
            this.ctl_datemodified.Changed = false;
            this.ctl_datemodified.Location = new System.Drawing.Point(478, 137);
            this.ctl_datemodified.Name = "ctl_datemodified";
            this.ctl_datemodified.Size = new System.Drawing.Size(151, 45);
            this.ctl_datemodified.SuppressEdit = false;
            this.ctl_datemodified.TabIndex = 40;
            this.ctl_datemodified.UseParentBackColor = true;
            this.ctl_datemodified.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_datemodified.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_datemodified.zz_LabelColor = System.Drawing.Color.Green;
            this.ctl_datemodified.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_datemodified.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopCenter;
            this.ctl_datemodified.zz_OriginalDesign = false;
            this.ctl_datemodified.zz_ShowNeedsSaveColor = true;
            this.ctl_datemodified.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_datemodified.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_datemodified.zz_UseGlobalColor = false;
            this.ctl_datemodified.zz_UseGlobalFont = false;
            // 
            // ctl_datecreated
            // 
            this.ctl_datecreated.AllowClear = false;
            this.ctl_datecreated.BackColor = System.Drawing.Color.Transparent;
            this.ctl_datecreated.Bold = false;
            this.ctl_datecreated.Caption = "Date Created";
            this.ctl_datecreated.Changed = false;
            this.ctl_datecreated.Location = new System.Drawing.Point(328, 137);
            this.ctl_datecreated.Name = "ctl_datecreated";
            this.ctl_datecreated.Size = new System.Drawing.Size(151, 45);
            this.ctl_datecreated.SuppressEdit = false;
            this.ctl_datecreated.TabIndex = 39;
            this.ctl_datecreated.UseParentBackColor = true;
            this.ctl_datecreated.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_datecreated.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_datecreated.zz_LabelColor = System.Drawing.Color.Green;
            this.ctl_datecreated.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_datecreated.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopCenter;
            this.ctl_datecreated.zz_OriginalDesign = false;
            this.ctl_datecreated.zz_ShowNeedsSaveColor = true;
            this.ctl_datecreated.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_datecreated.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_datecreated.zz_UseGlobalColor = false;
            this.ctl_datecreated.zz_UseGlobalFont = false;
            // 
            // ctl_buytype
            // 
            this.ctl_buytype.AllCaps = false;
            this.ctl_buytype.BackColor = System.Drawing.Color.Transparent;
            this.ctl_buytype.Bold = false;
            this.ctl_buytype.Caption = "Buy Type";
            this.ctl_buytype.Changed = false;
            this.ctl_buytype.IsEmail = false;
            this.ctl_buytype.IsURL = false;
            this.ctl_buytype.Location = new System.Drawing.Point(6, 95);
            this.ctl_buytype.Name = "ctl_buytype";
            this.ctl_buytype.PasswordChar = '\0';
            this.ctl_buytype.Size = new System.Drawing.Size(305, 39);
            this.ctl_buytype.TabIndex = 35;
            this.ctl_buytype.UseParentBackColor = true;
            this.ctl_buytype.zz_Enabled = true;
            this.ctl_buytype.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_buytype.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_buytype.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_buytype.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_buytype.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_buytype.zz_OriginalDesign = false;
            this.ctl_buytype.zz_ShowLinkButton = false;
            this.ctl_buytype.zz_ShowNeedsSaveColor = true;
            this.ctl_buytype.zz_Text = "";
            this.ctl_buytype.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_buytype.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_buytype.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_buytype.zz_UseGlobalColor = false;
            this.ctl_buytype.zz_UseGlobalFont = false;
            // 
            // ctl_country
            // 
            this.ctl_country.AllCaps = false;
            this.ctl_country.BackColor = System.Drawing.Color.Transparent;
            this.ctl_country.Bold = false;
            this.ctl_country.Caption = "Country";
            this.ctl_country.Changed = false;
            this.ctl_country.IsEmail = false;
            this.ctl_country.IsURL = false;
            this.ctl_country.Location = new System.Drawing.Point(216, 53);
            this.ctl_country.Name = "ctl_country";
            this.ctl_country.PasswordChar = '\0';
            this.ctl_country.Size = new System.Drawing.Size(216, 39);
            this.ctl_country.TabIndex = 33;
            this.ctl_country.UseParentBackColor = true;
            this.ctl_country.zz_Enabled = true;
            this.ctl_country.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_country.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_country.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_country.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_country.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_country.zz_OriginalDesign = false;
            this.ctl_country.zz_ShowLinkButton = false;
            this.ctl_country.zz_ShowNeedsSaveColor = true;
            this.ctl_country.zz_Text = "";
            this.ctl_country.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_country.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_country.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_country.zz_UseGlobalColor = false;
            this.ctl_country.zz_UseGlobalFont = false;
            this.ctl_country.Load += new System.EventHandler(this.ctl_country_Load);
            // 
            // ctl_alternatequantity
            // 
            this.ctl_alternatequantity.BackColor = System.Drawing.Color.Transparent;
            this.ctl_alternatequantity.Bold = false;
            this.ctl_alternatequantity.Caption = "Alt. Quantity";
            this.ctl_alternatequantity.Changed = false;
            this.ctl_alternatequantity.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_alternatequantity.Location = new System.Drawing.Point(6, 54);
            this.ctl_alternatequantity.Name = "ctl_alternatequantity";
            this.ctl_alternatequantity.Size = new System.Drawing.Size(204, 39);
            this.ctl_alternatequantity.TabIndex = 32;
            this.ctl_alternatequantity.UseParentBackColor = true;
            this.ctl_alternatequantity.zz_Enabled = true;
            this.ctl_alternatequantity.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_alternatequantity.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_alternatequantity.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_alternatequantity.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_alternatequantity.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_alternatequantity.zz_OriginalDesign = false;
            this.ctl_alternatequantity.zz_ShowErrorColor = true;
            this.ctl_alternatequantity.zz_ShowNeedsSaveColor = true;
            this.ctl_alternatequantity.zz_Text = "";
            this.ctl_alternatequantity.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_alternatequantity.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_alternatequantity.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_alternatequantity.zz_UseGlobalColor = false;
            this.ctl_alternatequantity.zz_UseGlobalFont = false;
            // 
            // ctl_partsetup
            // 
            this.ctl_partsetup.AllCaps = false;
            this.ctl_partsetup.AllowEdit = false;
            this.ctl_partsetup.BackColor = System.Drawing.Color.Transparent;
            this.ctl_partsetup.Bold = false;
            this.ctl_partsetup.Caption = "Part Setup";
            this.ctl_partsetup.Changed = false;
            this.ctl_partsetup.ListName = "partsetup";
            this.ctl_partsetup.Location = new System.Drawing.Point(438, 48);
            this.ctl_partsetup.Name = "ctl_partsetup";
            this.ctl_partsetup.SimpleList = null;
            this.ctl_partsetup.Size = new System.Drawing.Size(191, 45);
            this.ctl_partsetup.TabIndex = 34;
            this.ctl_partsetup.UseParentBackColor = true;
            this.ctl_partsetup.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_partsetup.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_partsetup.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_partsetup.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_partsetup.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_partsetup.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_partsetup.zz_OriginalDesign = true;
            this.ctl_partsetup.zz_ShowNeedsSaveColor = true;
            this.ctl_partsetup.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_partsetup.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_partsetup.zz_UseGlobalColor = false;
            this.ctl_partsetup.zz_UseGlobalFont = false;
            // 
            // ctl_dateconfirmed
            // 
            this.ctl_dateconfirmed.AllowClear = false;
            this.ctl_dateconfirmed.BackColor = System.Drawing.Color.Transparent;
            this.ctl_dateconfirmed.Bold = false;
            this.ctl_dateconfirmed.Caption = "Date Confirmed";
            this.ctl_dateconfirmed.Changed = false;
            this.ctl_dateconfirmed.Location = new System.Drawing.Point(178, 137);
            this.ctl_dateconfirmed.Name = "ctl_dateconfirmed";
            this.ctl_dateconfirmed.Size = new System.Drawing.Size(151, 45);
            this.ctl_dateconfirmed.SuppressEdit = false;
            this.ctl_dateconfirmed.TabIndex = 38;
            this.ctl_dateconfirmed.UseParentBackColor = true;
            this.ctl_dateconfirmed.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_dateconfirmed.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_dateconfirmed.zz_LabelColor = System.Drawing.Color.Green;
            this.ctl_dateconfirmed.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_dateconfirmed.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopCenter;
            this.ctl_dateconfirmed.zz_OriginalDesign = false;
            this.ctl_dateconfirmed.zz_ShowNeedsSaveColor = true;
            this.ctl_dateconfirmed.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_dateconfirmed.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_dateconfirmed.zz_UseGlobalColor = false;
            this.ctl_dateconfirmed.zz_UseGlobalFont = false;
            // 
            // pagePictures
            // 
            this.pagePictures.Controls.Add(this.PPV);
            this.pagePictures.Location = new System.Drawing.Point(4, 22);
            this.pagePictures.Name = "pagePictures";
            this.pagePictures.Padding = new System.Windows.Forms.Padding(3);
            this.pagePictures.Size = new System.Drawing.Size(635, 435);
            this.pagePictures.TabIndex = 6;
            this.pagePictures.Text = "Attachments";
            this.pagePictures.UseVisualStyleBackColor = true;
            // 
            // PPV
            // 
            this.PPV.BackColor = System.Drawing.Color.White;
            this.PPV.Caption = "Rz4 PictureViewer";
            this.PPV.DisablePartLink = false;
            this.PPV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PPV.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PPV.Location = new System.Drawing.Point(3, 3);
            this.PPV.Name = "PPV";
            this.PPV.ShowFullScreenButton = true;
            this.PPV.ShowPartNumberLink = false;
            this.PPV.ShowPartSearch = false;
            this.PPV.ShowZoomButton = true;
            this.PPV.Size = new System.Drawing.Size(629, 429);
            this.PPV.TabIndex = 1;
            this.PPV.TemplateName = "orddetPartPictureViewer";
            // 
            // tabInspection
            // 
            this.tabInspection.Location = new System.Drawing.Point(4, 22);
            this.tabInspection.Name = "tabInspection";
            this.tabInspection.Padding = new System.Windows.Forms.Padding(3);
            this.tabInspection.Size = new System.Drawing.Size(635, 435);
            this.tabInspection.TabIndex = 7;
            this.tabInspection.Text = "Inspection";
            this.tabInspection.UseVisualStyleBackColor = true;
            // 
            // tabCofC
            // 
            this.tabCofC.Controls.Add(this.splitContainer1);
            this.tabCofC.Location = new System.Drawing.Point(4, 22);
            this.tabCofC.Name = "tabCofC";
            this.tabCofC.Size = new System.Drawing.Size(635, 435);
            this.tabCofC.TabIndex = 8;
            this.tabCofC.Text = "C of Cs";
            this.tabCofC.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvCofC);
            this.splitContainer1.Size = new System.Drawing.Size(635, 435);
            this.splitContainer1.SplitterDistance = 231;
            this.splitContainer1.TabIndex = 0;
            // 
            // lvCofC
            // 
            this.lvCofC.AddCaption = "Add New";
            this.lvCofC.AllowActions = false;
            this.lvCofC.AllowAdd = false;
            this.lvCofC.AllowDelete = true;
            this.lvCofC.AllowDeleteAlways = false;
            this.lvCofC.AllowDrop = true;
            this.lvCofC.AllowOnlyOpenDelete = false;
            this.lvCofC.AlternateConnection = null;
            this.lvCofC.BackColor = System.Drawing.SystemColors.Control;
            this.lvCofC.Caption = "";
            this.lvCofC.CurrentTemplate = null;
            this.lvCofC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCofC.ExtraClassInfo = "";
            this.lvCofC.Location = new System.Drawing.Point(0, 0);
            this.lvCofC.MultiSelect = true;
            this.lvCofC.Name = "lvCofC";
            this.lvCofC.Size = new System.Drawing.Size(231, 435);
            this.lvCofC.SuppressSelectionChanged = false;
            this.lvCofC.TabIndex = 0;
            this.lvCofC.zz_OpenColumnMenu = false;
            this.lvCofC.zz_OrderLineType = "";
            this.lvCofC.zz_ShowAutoRefresh = true;
            this.lvCofC.zz_ShowUnlimited = true;
            this.lvCofC.AboutToThrow += new Core.ShowHandler(this.lvCofC_AboutToThrow);
            this.lvCofC.ObjectClicked += new NewMethod.ObjectClickHandler(this.lvCofC_ObjectClicked);
            // 
            // tabCrosses
            // 
            this.tabCrosses.Controls.Add(this.gbCrossFrom);
            this.tabCrosses.Controls.Add(this.gbCrossTo);
            this.tabCrosses.Location = new System.Drawing.Point(4, 22);
            this.tabCrosses.Name = "tabCrosses";
            this.tabCrosses.Size = new System.Drawing.Size(635, 435);
            this.tabCrosses.TabIndex = 10;
            this.tabCrosses.Text = "Crosses";
            this.tabCrosses.UseVisualStyleBackColor = true;
            // 
            // gbCrossFrom
            // 
            this.gbCrossFrom.Controls.Add(this.nList1);
            this.gbCrossFrom.Location = new System.Drawing.Point(319, 0);
            this.gbCrossFrom.Name = "gbCrossFrom";
            this.gbCrossFrom.Size = new System.Drawing.Size(318, 458);
            this.gbCrossFrom.TabIndex = 8;
            this.gbCrossFrom.TabStop = false;
            this.gbCrossFrom.Text = "Crosses From:";
            // 
            // nList1
            // 
            this.nList1.AddCaption = "Add New";
            this.nList1.AllowActions = true;
            this.nList1.AllowAdd = false;
            this.nList1.AllowDelete = true;
            this.nList1.AllowDeleteAlways = false;
            this.nList1.AllowDrop = true;
            this.nList1.AllowOnlyOpenDelete = false;
            this.nList1.AlternateConnection = null;
            this.nList1.BackColor = System.Drawing.Color.White;
            this.nList1.Caption = "";
            this.nList1.CurrentTemplate = null;
            this.nList1.ExtraClassInfo = "";
            this.nList1.Location = new System.Drawing.Point(5, 121);
            this.nList1.MultiSelect = true;
            this.nList1.Name = "nList1";
            this.nList1.Size = new System.Drawing.Size(300, 337);
            this.nList1.SuppressSelectionChanged = false;
            this.nList1.TabIndex = 7;
            this.nList1.zz_OpenColumnMenu = false;
            this.nList1.zz_OrderLineType = "";
            this.nList1.zz_ShowAutoRefresh = true;
            this.nList1.zz_ShowUnlimited = true;
            // 
            // gbCrossTo
            // 
            this.gbCrossTo.Controls.Add(this.lv);
            this.gbCrossTo.Location = new System.Drawing.Point(0, 0);
            this.gbCrossTo.Name = "gbCrossTo";
            this.gbCrossTo.Size = new System.Drawing.Size(318, 458);
            this.gbCrossTo.TabIndex = 7;
            this.gbCrossTo.TabStop = false;
            this.gbCrossTo.Text = "Crosses To:";
            // 
            // lv
            // 
            this.lv.AddCaption = "Add New";
            this.lv.AllowActions = true;
            this.lv.AllowAdd = false;
            this.lv.AllowDelete = true;
            this.lv.AllowDeleteAlways = false;
            this.lv.AllowDrop = true;
            this.lv.AllowOnlyOpenDelete = false;
            this.lv.AlternateConnection = null;
            this.lv.BackColor = System.Drawing.Color.White;
            this.lv.Caption = "";
            this.lv.CurrentTemplate = null;
            this.lv.ExtraClassInfo = "";
            this.lv.Location = new System.Drawing.Point(7, 121);
            this.lv.MultiSelect = true;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(300, 337);
            this.lv.SuppressSelectionChanged = false;
            this.lv.TabIndex = 6;
            this.lv.zz_OpenColumnMenu = false;
            this.lv.zz_OrderLineType = "";
            this.lv.zz_ShowAutoRefresh = true;
            this.lv.zz_ShowUnlimited = true;
            // 
            // tabImport
            // 
            this.tabImport.Controls.Add(this.gbImport);
            this.tabImport.Controls.Add(this.gbConsign);
            this.tabImport.Location = new System.Drawing.Point(4, 22);
            this.tabImport.Name = "tabImport";
            this.tabImport.Size = new System.Drawing.Size(635, 435);
            this.tabImport.TabIndex = 11;
            this.tabImport.Text = "Import Data";
            this.tabImport.UseVisualStyleBackColor = true;
            // 
            // gbImport
            // 
            this.gbImport.Controls.Add(this.llChangeImportID);
            this.gbImport.Controls.Add(this.lblImportName);
            this.gbImport.Controls.Add(this.label5);
            this.gbImport.Location = new System.Drawing.Point(7, 14);
            this.gbImport.Name = "gbImport";
            this.gbImport.Size = new System.Drawing.Size(625, 100);
            this.gbImport.TabIndex = 15;
            this.gbImport.TabStop = false;
            this.gbImport.Text = "Import Data";
            // 
            // llChangeImportID
            // 
            this.llChangeImportID.AutoSize = true;
            this.llChangeImportID.Location = new System.Drawing.Point(129, 30);
            this.llChangeImportID.Name = "llChangeImportID";
            this.llChangeImportID.Size = new System.Drawing.Size(107, 13);
            this.llChangeImportID.TabIndex = 16;
            this.llChangeImportID.TabStop = true;
            this.llChangeImportID.Text = "Change Import Name";
            // 
            // lblImportName
            // 
            this.lblImportName.AutoSize = true;
            this.lblImportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportName.ForeColor = System.Drawing.Color.Navy;
            this.lblImportName.Location = new System.Drawing.Point(6, 55);
            this.lblImportName.Name = "lblImportName";
            this.lblImportName.Size = new System.Drawing.Size(120, 17);
            this.lblImportName.TabIndex = 15;
            this.lblImportName.Text = "[IMPORTNAME]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Import Name:";
            // 
            // gbConsign
            // 
            this.gbConsign.Controls.Add(this.lblConsignPerc);
            this.gbConsign.Controls.Add(this.label4);
            this.gbConsign.Controls.Add(this.ctl_consigncodes);
            this.gbConsign.Controls.Add(this.label3);
            this.gbConsign.Controls.Add(this.lblConsignCode);
            this.gbConsign.Enabled = false;
            this.gbConsign.Location = new System.Drawing.Point(7, 134);
            this.gbConsign.Name = "gbConsign";
            this.gbConsign.Size = new System.Drawing.Size(625, 139);
            this.gbConsign.TabIndex = 14;
            this.gbConsign.TabStop = false;
            this.gbConsign.Text = "Consignment:";
            // 
            // lblConsignPerc
            // 
            this.lblConsignPerc.AutoSize = true;
            this.lblConsignPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsignPerc.ForeColor = System.Drawing.Color.Navy;
            this.lblConsignPerc.Location = new System.Drawing.Point(202, 106);
            this.lblConsignPerc.Name = "lblConsignPerc";
            this.lblConsignPerc.Size = new System.Drawing.Size(90, 17);
            this.lblConsignPerc.TabIndex = 15;
            this.lblConsignPerc.Text = "[PERCENT]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Consignment Percent:";
            // 
            // ctl_consigncodes
            // 
            this.ctl_consigncodes.AllCaps = false;
            this.ctl_consigncodes.AllowEdit = false;
            this.ctl_consigncodes.BackColor = System.Drawing.Color.White;
            this.ctl_consigncodes.Bold = false;
            this.ctl_consigncodes.Caption = "Choose Consignment Code";
            this.ctl_consigncodes.Changed = false;
            this.ctl_consigncodes.ListName = null;
            this.ctl_consigncodes.Location = new System.Drawing.Point(22, 27);
            this.ctl_consigncodes.Name = "ctl_consigncodes";
            this.ctl_consigncodes.SimpleList = null;
            this.ctl_consigncodes.Size = new System.Drawing.Size(478, 46);
            this.ctl_consigncodes.TabIndex = 13;
            this.ctl_consigncodes.UseParentBackColor = false;
            this.ctl_consigncodes.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_consigncodes.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_consigncodes.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_consigncodes.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_consigncodes.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_consigncodes.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_consigncodes.zz_OriginalDesign = true;
            this.ctl_consigncodes.zz_ShowNeedsSaveColor = true;
            this.ctl_consigncodes.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_consigncodes.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_consigncodes.zz_UseGlobalColor = false;
            this.ctl_consigncodes.zz_UseGlobalFont = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Consignment Code:";
            // 
            // lblConsignCode
            // 
            this.lblConsignCode.AutoSize = true;
            this.lblConsignCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsignCode.ForeColor = System.Drawing.Color.Navy;
            this.lblConsignCode.Location = new System.Drawing.Point(190, 89);
            this.lblConsignCode.Name = "lblConsignCode";
            this.lblConsignCode.Size = new System.Drawing.Size(61, 17);
            this.lblConsignCode.TabIndex = 9;
            this.lblConsignCode.Text = "[CODE]";
            // 
            // ctl_part_status
            // 
            this.ctl_part_status.AllCaps = false;
            this.ctl_part_status.AllowEdit = true;
            this.ctl_part_status.BackColor = System.Drawing.Color.Transparent;
            this.ctl_part_status.Bold = false;
            this.ctl_part_status.Caption = "Part Status";
            this.ctl_part_status.Changed = false;
            this.ctl_part_status.ListName = "part_status";
            this.ctl_part_status.Location = new System.Drawing.Point(199, 0);
            this.ctl_part_status.Name = "ctl_part_status";
            this.ctl_part_status.SimpleList = null;
            this.ctl_part_status.Size = new System.Drawing.Size(449, 40);
            this.ctl_part_status.TabIndex = 45;
            this.ctl_part_status.UseParentBackColor = true;
            this.ctl_part_status.Visible = false;
            this.ctl_part_status.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_part_status.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_part_status.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_part_status.zz_LabelColor = System.Drawing.Color.Green;
            this.ctl_part_status.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_part_status.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_part_status.zz_OriginalDesign = false;
            this.ctl_part_status.zz_ShowNeedsSaveColor = true;
            this.ctl_part_status.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_part_status.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_part_status.zz_UseGlobalColor = false;
            this.ctl_part_status.zz_UseGlobalFont = false;
            // 
            // cmdSaveAndNew
            // 
            this.cmdSaveAndNew.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSaveAndNew.Image = global::RzInterfaceWin.Properties.Resources.saveHS;
            this.cmdSaveAndNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSaveAndNew.Location = new System.Drawing.Point(557, 68);
            this.cmdSaveAndNew.Name = "cmdSaveAndNew";
            this.cmdSaveAndNew.Size = new System.Drawing.Size(93, 22);
            this.cmdSaveAndNew.TabIndex = 44;
            this.cmdSaveAndNew.Text = "Save + New";
            this.cmdSaveAndNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSaveAndNew.UseVisualStyleBackColor = true;
            // 
            // view_partrecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctl_part_status);
            this.Controls.Add(this.cmdSaveAndNew);
            this.Controls.Add(this.gbStockType);
            this.Controls.Add(this.ctl_fullpartnumber);
            this.Controls.Add(this.ts);
            this.Name = "view_partrecord";
            this.Size = new System.Drawing.Size(925, 701);
            this.Controls.SetChildIndex(this.ts, 0);
            this.Controls.SetChildIndex(this.ctl_fullpartnumber, 0);
            this.Controls.SetChildIndex(this.gbStockType, 0);
            this.Controls.SetChildIndex(this.cmdSaveAndNew, 0);
            this.Controls.SetChildIndex(this.ctl_part_status, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.gbStockType.ResumeLayout(false);
            this.ts.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tpGeneral.PerformLayout();
            this.gbOtherInfo.ResumeLayout(false);
            this.gbPriceInfo.ResumeLayout(false);
            this.gbPriceInfo.PerformLayout();
            this.gbQtyInfo.ResumeLayout(false);
            this.tpMaster.ResumeLayout(false);
            this.gb_SSD.ResumeLayout(false);
            this.tpExtra.ResumeLayout(false);
            this.pagePictures.ResumeLayout(false);
            this.tabCofC.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabCrosses.ResumeLayout(false);
            this.gbCrossFrom.ResumeLayout(false);
            this.gbCrossTo.ResumeLayout(false);
            this.tabImport.ResumeLayout(false);
            this.gbImport.ResumeLayout(false);
            this.gbImport.PerformLayout();
            this.gbConsign.ResumeLayout(false);
            this.gbConsign.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ctl_stocktype;
        protected nEdit_String ctl_fullpartnumber;
        private nEdit_Memo ctl_internalcomment;
        private CompanyStub_PlusContact cStub;
        private nEdit_Number ctl_quantityallocated;
        private nEdit_Money ctl_cost;
        private nEdit_Money ctl_price;
        protected nEdit_String ctl_alternatepart;
        private nEdit_Number ctl_alternatequantity;
        private nEdit_List ctl_partsetup;
        private nEdit_Date ctl_dateconfirmed;
        private nEdit_String ctl_importid;
        private nEdit_Boolean ctl_islocked;
        private PartPictureViewer PPV;
        protected nEdit_Boolean ctl_mfg_certifications;
        private nEdit_Boolean ctl_no_complete_report;
        private nEdit_String ctl_buytype;
        private nEdit_Number ctl_expected_quantity;
        private nEdit_Boolean ctl_do_not_export;
        protected nEdit_User buyer;
        private nEdit_Money ctl_averagecost;
        private nEdit_Money ctl_highcost;
        private nEdit_Money ctl_actual_cost;
        private nEdit_Money ctl_lowcost;
        private nEdit_Money ctl_highprice;
        private nEdit_Money ctl_midprice;
        private nEdit_Money ctl_lowprice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private nEdit_String ctl_userdata_02;
        private nEdit_Date ctl_datemodified;
        private nEdit_Date ctl_datecreated;
        private nEdit_Memo ctl_description;
        private nEdit_Memo ctl_printcomment;
        private nEdit_String ctl_leadtime;
        public System.Windows.Forms.TabPage tpExtra;
        public System.Windows.Forms.TabPage pagePictures;
        public System.Windows.Forms.TabPage tabInspection;
        private System.Windows.Forms.TabPage tabCofC;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private nList lvCofC;
        protected System.Windows.Forms.TabControl ts;
        protected System.Windows.Forms.TabPage tpGeneral;
        protected nEdit_String ctl_country;
        public nEdit_List ctl_manufacturer;
        public nEdit_List ctl_condition;
        public nEdit_List ctl_packaging;
        public nEdit_String ctl_datecode;
        public nEdit_Number ctl_partsperpack;
        public nEdit_String ctl_user_defined;
        protected System.Windows.Forms.GroupBox gbStockType;
        protected System.Windows.Forms.Button cmdSaveAndNew;
        protected System.Windows.Forms.GroupBox gbOtherInfo;
        protected nEdit_List ctl_part_status;
        protected System.Windows.Forms.Button cmdChangeLocation;
        protected nEdit_List ctl_delivery;
        protected nEdit_List ctl_boxcode;
        protected nEdit_List ctl_location;
        protected nEdit_List ctl_boxnum;
        protected nEdit_List ctl_lotnumber;
        public nEdit_List ctl_rohs_info;
        protected System.Windows.Forms.GroupBox gbPriceInfo;
        protected System.Windows.Forms.GroupBox gbQtyInfo;
        private System.Windows.Forms.TabPage tpMaster;
        protected System.Windows.Forms.GroupBox gb_SSD;
        public nEdit_List ctl_unit_of_measure;
        protected nEdit_Number ctl_quantity;
        public nEdit_List ctl_ProductType;
        private System.Windows.Forms.TabPage tabCrosses;
        private System.Windows.Forms.GroupBox gbCrossFrom;
        private nList nList1;
        private System.Windows.Forms.GroupBox gbCrossTo;
        private nList lv;
        private nEdit_List ctl_rohs_info2;
        protected nEdit_List ctl_QC_Status;
        protected nEdit_List ctl_category;
        protected nEdit_String ctl_capacity;
        protected nEdit_String ctl_ssd_interface;
        protected nEdit_String ctl_formfactor;
        protected nEdit_String ctl_maxtemp;
        private System.Windows.Forms.Label lblSMVDate;
        private nEdit_Money ctl_smv;
        private nEdit_User nEdit_User1;
        protected nEdit_String ctl_internalpartnumber;
        protected nEdit_String ctl_userdata_01;
        private System.Windows.Forms.TabPage tabImport;
        private System.Windows.Forms.GroupBox gbImport;
        private System.Windows.Forms.LinkLabel llChangeImportID;
        private System.Windows.Forms.Label lblImportName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbConsign;
        private System.Windows.Forms.Label lblConsignPerc;
        private System.Windows.Forms.Label label4;
        private nEdit_List ctl_consigncodes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblConsignCode;
    }
}
