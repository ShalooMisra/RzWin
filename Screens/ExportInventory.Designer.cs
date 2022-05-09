using Tools.Database;
namespace Rz5
{
    partial class ExportInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportInventory));
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pbBottom = new System.Windows.Forms.PictureBox();
            this.pbTop = new System.Windows.Forms.PictureBox();
            this.gbTemplate = new System.Windows.Forms.GroupBox();
            this.ctl_adpercent = new NewMethod.nEdit_Number();
            this.ctl_adqty = new NewMethod.nEdit_Boolean();
            this.ctl_exportname = new NewMethod.nEdit_String();
            this.ctl_exportfile = new NewMethod.nEdit_String();
            this.TS = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.ctl_includeheader = new NewMethod.nEdit_Boolean();
            this.ctl_only_selected_offers = new NewMethod.nEdit_Boolean();
            this.ctl_exportoffers = new NewMethod.nEdit_Boolean();
            this.ts2 = new System.Windows.Forms.TabControl();
            this.tabExcess = new System.Windows.Forms.TabPage();
            this.lvImports = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.tabConsign = new System.Windows.Forms.TabPage();
            this.lvConsign = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.tabOffers = new System.Windows.Forms.TabPage();
            this.lvOffers = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.ctl_only_selected_consign = new NewMethod.nEdit_Boolean();
            this.ctl_only_selected = new NewMethod.nEdit_Boolean();
            this.ctl_withcost = new NewMethod.nEdit_Boolean();
            this.ctl_filter_dupes = new NewMethod.nEdit_Boolean();
            this.ctl_exportconsigned = new NewMethod.nEdit_Boolean();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.IM = new System.Windows.Forms.ImageList(this.components);
            this.cmdNew = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.ctl_exportstock = new NewMethod.nEdit_Boolean();
            this.ctl_exportexcess = new NewMethod.nEdit_Boolean();
            this.ctl_pnlength = new NewMethod.nEdit_Boolean();
            this.ctl_qtyabovezero = new NewMethod.nEdit_Boolean();
            this.tabColumns = new System.Windows.Forms.TabPage();
            this.lvColumns = new NewMethod.nList();
            this.tabSQL = new System.Windows.Forms.TabPage();
            this.cmdEnable = new System.Windows.Forms.Button();
            this.gbSQL = new System.Windows.Forms.GroupBox();
            this.ctl_manualsql = new NewMethod.nEdit_Boolean();
            this.ctl_exportstring = new NewMethod.nEdit_Memo();
            this.cmdExport = new System.Windows.Forms.Button();
            this.bgExport = new System.ComponentModel.BackgroundWorker();
            this.lvTemplates = new NewMethod.nList();
            this.chkAll = new NewMethod.nEdit_Boolean();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).BeginInit();
            this.gbTemplate.SuspendLayout();
            this.TS.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.ts2.SuspendLayout();
            this.tabExcess.SuspendLayout();
            this.tabConsign.SuspendLayout();
            this.tabOffers.SuspendLayout();
            this.tabColumns.SuspendLayout();
            this.tabSQL.SuspendLayout();
            this.gbSQL.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbLeft
            // 
            this.pbLeft.BackColor = System.Drawing.Color.Black;
            this.pbLeft.Location = new System.Drawing.Point(134, 142);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(12, 12);
            this.pbLeft.TabIndex = 28;
            this.pbLeft.TabStop = false;
            // 
            // pbRight
            // 
            this.pbRight.BackColor = System.Drawing.Color.Black;
            this.pbRight.Location = new System.Drawing.Point(134, 124);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(12, 12);
            this.pbRight.TabIndex = 27;
            this.pbRight.TabStop = false;
            // 
            // pbBottom
            // 
            this.pbBottom.BackColor = System.Drawing.Color.Black;
            this.pbBottom.Location = new System.Drawing.Point(152, 124);
            this.pbBottom.Name = "pbBottom";
            this.pbBottom.Size = new System.Drawing.Size(12, 12);
            this.pbBottom.TabIndex = 26;
            this.pbBottom.TabStop = false;
            // 
            // pbTop
            // 
            this.pbTop.BackColor = System.Drawing.Color.Black;
            this.pbTop.Location = new System.Drawing.Point(152, 142);
            this.pbTop.Name = "pbTop";
            this.pbTop.Size = new System.Drawing.Size(12, 12);
            this.pbTop.TabIndex = 25;
            this.pbTop.TabStop = false;
            // 
            // gbTemplate
            // 
            this.gbTemplate.Controls.Add(this.ctl_adpercent);
            this.gbTemplate.Controls.Add(this.ctl_adqty);
            this.gbTemplate.Controls.Add(this.ctl_exportname);
            this.gbTemplate.Controls.Add(this.ctl_exportfile);
            this.gbTemplate.Location = new System.Drawing.Point(250, 3);
            this.gbTemplate.Name = "gbTemplate";
            this.gbTemplate.Size = new System.Drawing.Size(451, 79);
            this.gbTemplate.TabIndex = 30;
            this.gbTemplate.TabStop = false;
            this.gbTemplate.Text = "Export Template";
            // 
            // ctl_adpercent
            // 
            this.ctl_adpercent.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_adpercent.Bold = false;
            this.ctl_adpercent.Caption = "%";
            this.ctl_adpercent.Changed = false;
            this.ctl_adpercent.CurrentType = FieldType.Unknown;
            this.ctl_adpercent.Location = new System.Drawing.Point(245, 9);
            this.ctl_adpercent.Name = "ctl_adpercent";
            this.ctl_adpercent.Size = new System.Drawing.Size(62, 22);
            this.ctl_adpercent.TabIndex = 22;
            this.ctl_adpercent.UseParentBackColor = false;
            this.ctl_adpercent.Visible = false;
            this.ctl_adpercent.zz_Enabled = true;
            this.ctl_adpercent.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_adpercent.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_adpercent.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_adpercent.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_adpercent.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.Right;
            this.ctl_adpercent.zz_OriginalDesign = false;
            this.ctl_adpercent.zz_ShowErrorColor = true;
            this.ctl_adpercent.zz_ShowNeedsSaveColor = true;
            this.ctl_adpercent.zz_Text = "";
            this.ctl_adpercent.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_adpercent.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_adpercent.zz_TextFont = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_adpercent.zz_UseGlobalColor = false;
            this.ctl_adpercent.zz_UseGlobalFont = false;
            // 
            // ctl_adqty
            // 
            this.ctl_adqty.BackColor = System.Drawing.Color.Transparent;
            this.ctl_adqty.Bold = false;
            this.ctl_adqty.Caption = "Advertised Quantity";
            this.ctl_adqty.Changed = false;
            this.ctl_adqty.Location = new System.Drawing.Point(309, 12);
            this.ctl_adqty.Name = "ctl_adqty";
            this.ctl_adqty.Size = new System.Drawing.Size(137, 18);
            this.ctl_adqty.TabIndex = 21;
            this.ctl_adqty.UseParentBackColor = false;
            this.ctl_adqty.Visible = false;
            this.ctl_adqty.zz_CheckValue = false;
            this.ctl_adqty.zz_LabelColor = System.Drawing.Color.Navy;
            this.ctl_adqty.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_adqty.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_adqty.zz_OriginalDesign = false;
            this.ctl_adqty.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_exportname
            // 
            this.ctl_exportname.AllCaps = false;
            this.ctl_exportname.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_exportname.Bold = false;
            this.ctl_exportname.Caption = "Export Template Name";
            this.ctl_exportname.Changed = false;
            this.ctl_exportname.IsEmail = false;
            this.ctl_exportname.IsURL = false;
            this.ctl_exportname.Location = new System.Drawing.Point(6, 31);
            this.ctl_exportname.Name = "ctl_exportname";
            this.ctl_exportname.PasswordChar = '\0';
            this.ctl_exportname.Size = new System.Drawing.Size(439, 21);
            this.ctl_exportname.TabIndex = 0;
            this.ctl_exportname.UseParentBackColor = false;
            this.ctl_exportname.zz_Enabled = true;
            this.ctl_exportname.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_exportname.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_exportname.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_exportname.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_exportname.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctl_exportname.zz_OriginalDesign = false;
            this.ctl_exportname.zz_ShowLinkButton = false;
            this.ctl_exportname.zz_ShowNeedsSaveColor = true;
            this.ctl_exportname.zz_Text = "";
            this.ctl_exportname.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_exportname.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_exportname.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_exportname.zz_UseGlobalColor = false;
            this.ctl_exportname.zz_UseGlobalFont = false;
            // 
            // ctl_exportfile
            // 
            this.ctl_exportfile.AllCaps = false;
            this.ctl_exportfile.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_exportfile.Bold = false;
            this.ctl_exportfile.Caption = "Export File Name";
            this.ctl_exportfile.Changed = false;
            this.ctl_exportfile.IsEmail = false;
            this.ctl_exportfile.IsURL = false;
            this.ctl_exportfile.Location = new System.Drawing.Point(6, 55);
            this.ctl_exportfile.Name = "ctl_exportfile";
            this.ctl_exportfile.PasswordChar = '\0';
            this.ctl_exportfile.Size = new System.Drawing.Size(439, 23);
            this.ctl_exportfile.TabIndex = 1;
            this.ctl_exportfile.UseParentBackColor = false;
            this.ctl_exportfile.zz_Enabled = true;
            this.ctl_exportfile.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_exportfile.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_exportfile.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_exportfile.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_exportfile.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctl_exportfile.zz_OriginalDesign = false;
            this.ctl_exportfile.zz_ShowLinkButton = false;
            this.ctl_exportfile.zz_ShowNeedsSaveColor = true;
            this.ctl_exportfile.zz_Text = "";
            this.ctl_exportfile.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_exportfile.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_exportfile.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_exportfile.zz_UseGlobalColor = false;
            this.ctl_exportfile.zz_UseGlobalFont = false;
            // 
            // TS
            // 
            this.TS.Controls.Add(this.tabGeneral);
            this.TS.Controls.Add(this.tabColumns);
            this.TS.Controls.Add(this.tabSQL);
            this.TS.Location = new System.Drawing.Point(250, 106);
            this.TS.Name = "TS";
            this.TS.SelectedIndex = 0;
            this.TS.Size = new System.Drawing.Size(455, 265);
            this.TS.TabIndex = 31;
            this.TS.SelectedIndexChanged += new System.EventHandler(this.TS_SelectedIndexChanged);
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.ctl_includeheader);
            this.tabGeneral.Controls.Add(this.ctl_only_selected_offers);
            this.tabGeneral.Controls.Add(this.ctl_exportoffers);
            this.tabGeneral.Controls.Add(this.ts2);
            this.tabGeneral.Controls.Add(this.ctl_only_selected_consign);
            this.tabGeneral.Controls.Add(this.ctl_only_selected);
            this.tabGeneral.Controls.Add(this.ctl_withcost);
            this.tabGeneral.Controls.Add(this.ctl_filter_dupes);
            this.tabGeneral.Controls.Add(this.ctl_exportconsigned);
            this.tabGeneral.Controls.Add(this.cmdRefresh);
            this.tabGeneral.Controls.Add(this.cmdNew);
            this.tabGeneral.Controls.Add(this.cmdDelete);
            this.tabGeneral.Controls.Add(this.cmdSave);
            this.tabGeneral.Controls.Add(this.ctl_exportstock);
            this.tabGeneral.Controls.Add(this.ctl_exportexcess);
            this.tabGeneral.Controls.Add(this.ctl_pnlength);
            this.tabGeneral.Controls.Add(this.ctl_qtyabovezero);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(447, 239);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // ctl_includeheader
            // 
            this.ctl_includeheader.BackColor = System.Drawing.Color.Transparent;
            this.ctl_includeheader.Bold = false;
            this.ctl_includeheader.Caption = "Include Headers";
            this.ctl_includeheader.Changed = false;
            this.ctl_includeheader.Location = new System.Drawing.Point(1, 7);
            this.ctl_includeheader.Name = "ctl_includeheader";
            this.ctl_includeheader.Size = new System.Drawing.Size(104, 18);
            this.ctl_includeheader.TabIndex = 0;
            this.ctl_includeheader.UseParentBackColor = false;
            this.ctl_includeheader.zz_CheckValue = false;
            this.ctl_includeheader.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_includeheader.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_includeheader.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_includeheader.zz_OriginalDesign = false;
            this.ctl_includeheader.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_only_selected_offers
            // 
            this.ctl_only_selected_offers.BackColor = System.Drawing.Color.Transparent;
            this.ctl_only_selected_offers.Bold = false;
            this.ctl_only_selected_offers.Caption = "Selected Offers";
            this.ctl_only_selected_offers.Changed = false;
            this.ctl_only_selected_offers.Location = new System.Drawing.Point(223, 174);
            this.ctl_only_selected_offers.Name = "ctl_only_selected_offers";
            this.ctl_only_selected_offers.Size = new System.Drawing.Size(99, 18);
            this.ctl_only_selected_offers.TabIndex = 21;
            this.ctl_only_selected_offers.UseParentBackColor = false;
            this.ctl_only_selected_offers.Visible = false;
            this.ctl_only_selected_offers.zz_CheckValue = false;
            this.ctl_only_selected_offers.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_only_selected_offers.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_only_selected_offers.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_only_selected_offers.zz_OriginalDesign = false;
            this.ctl_only_selected_offers.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_exportoffers
            // 
            this.ctl_exportoffers.BackColor = System.Drawing.Color.Transparent;
            this.ctl_exportoffers.Bold = false;
            this.ctl_exportoffers.Caption = "Export Offers";
            this.ctl_exportoffers.Changed = false;
            this.ctl_exportoffers.Location = new System.Drawing.Point(342, 26);
            this.ctl_exportoffers.Name = "ctl_exportoffers";
            this.ctl_exportoffers.Size = new System.Drawing.Size(100, 18);
            this.ctl_exportoffers.TabIndex = 20;
            this.ctl_exportoffers.UseParentBackColor = false;
            this.ctl_exportoffers.Visible = false;
            this.ctl_exportoffers.zz_CheckValue = false;
            this.ctl_exportoffers.zz_LabelColor = System.Drawing.Color.Navy;
            this.ctl_exportoffers.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_exportoffers.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_exportoffers.zz_OriginalDesign = false;
            this.ctl_exportoffers.zz_ShowNeedsSaveColor = true;
            // 
            // ts2
            // 
            this.ts2.Controls.Add(this.tabExcess);
            this.ts2.Controls.Add(this.tabConsign);
            this.ts2.Controls.Add(this.tabOffers);
            this.ts2.Location = new System.Drawing.Point(2, 45);
            this.ts2.Name = "ts2";
            this.ts2.SelectedIndex = 0;
            this.ts2.Size = new System.Drawing.Size(442, 126);
            this.ts2.TabIndex = 17;
            // 
            // tabExcess
            // 
            this.tabExcess.Controls.Add(this.lvImports);
            this.tabExcess.Location = new System.Drawing.Point(4, 22);
            this.tabExcess.Name = "tabExcess";
            this.tabExcess.Padding = new System.Windows.Forms.Padding(3);
            this.tabExcess.Size = new System.Drawing.Size(434, 100);
            this.tabExcess.TabIndex = 0;
            this.tabExcess.Text = "Excess";
            this.tabExcess.UseVisualStyleBackColor = true;
            // 
            // lvImports
            // 
            this.lvImports.CheckBoxes = true;
            this.lvImports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader7});
            this.lvImports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvImports.FullRowSelect = true;
            this.lvImports.HideSelection = false;
            this.lvImports.Location = new System.Drawing.Point(3, 3);
            this.lvImports.Name = "lvImports";
            this.lvImports.Size = new System.Drawing.Size(428, 94);
            this.lvImports.TabIndex = 4;
            this.lvImports.UseCompatibleStateImageBehavior = false;
            this.lvImports.View = System.Windows.Forms.View.Details;
            this.lvImports.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvImports_ColumnClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Company";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Import Name";
            this.columnHeader1.Width = 175;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Date";
            this.columnHeader7.Width = 80;
            // 
            // tabConsign
            // 
            this.tabConsign.Controls.Add(this.lvConsign);
            this.tabConsign.Location = new System.Drawing.Point(4, 22);
            this.tabConsign.Name = "tabConsign";
            this.tabConsign.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsign.Size = new System.Drawing.Size(434, 100);
            this.tabConsign.TabIndex = 1;
            this.tabConsign.Text = "Consignment";
            this.tabConsign.UseVisualStyleBackColor = true;
            // 
            // lvConsign
            // 
            this.lvConsign.CheckBoxes = true;
            this.lvConsign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader8});
            this.lvConsign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvConsign.FullRowSelect = true;
            this.lvConsign.HideSelection = false;
            this.lvConsign.Location = new System.Drawing.Point(3, 3);
            this.lvConsign.Name = "lvConsign";
            this.lvConsign.Size = new System.Drawing.Size(428, 94);
            this.lvConsign.TabIndex = 5;
            this.lvConsign.UseCompatibleStateImageBehavior = false;
            this.lvConsign.View = System.Windows.Forms.View.Details;
            this.lvConsign.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvConsign_ColumnClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Company";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Import Name";
            this.columnHeader4.Width = 175;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Date";
            this.columnHeader8.Width = 80;
            // 
            // tabOffers
            // 
            this.tabOffers.Controls.Add(this.lvOffers);
            this.tabOffers.Location = new System.Drawing.Point(4, 22);
            this.tabOffers.Name = "tabOffers";
            this.tabOffers.Size = new System.Drawing.Size(434, 100);
            this.tabOffers.TabIndex = 2;
            this.tabOffers.Text = "Offers";
            this.tabOffers.UseVisualStyleBackColor = true;
            // 
            // lvOffers
            // 
            this.lvOffers.CheckBoxes = true;
            this.lvOffers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader9});
            this.lvOffers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOffers.FullRowSelect = true;
            this.lvOffers.HideSelection = false;
            this.lvOffers.Location = new System.Drawing.Point(0, 0);
            this.lvOffers.Name = "lvOffers";
            this.lvOffers.Size = new System.Drawing.Size(434, 100);
            this.lvOffers.TabIndex = 5;
            this.lvOffers.UseCompatibleStateImageBehavior = false;
            this.lvOffers.View = System.Windows.Forms.View.Details;
            this.lvOffers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvOffers_ColumnClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Company";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Import Name";
            this.columnHeader6.Width = 175;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Date";
            this.columnHeader9.Width = 80;
            // 
            // ctl_only_selected_consign
            // 
            this.ctl_only_selected_consign.BackColor = System.Drawing.Color.Transparent;
            this.ctl_only_selected_consign.Bold = false;
            this.ctl_only_selected_consign.Caption = "Selected Consign";
            this.ctl_only_selected_consign.Changed = false;
            this.ctl_only_selected_consign.Location = new System.Drawing.Point(113, 174);
            this.ctl_only_selected_consign.Name = "ctl_only_selected_consign";
            this.ctl_only_selected_consign.Size = new System.Drawing.Size(109, 18);
            this.ctl_only_selected_consign.TabIndex = 19;
            this.ctl_only_selected_consign.UseParentBackColor = false;
            this.ctl_only_selected_consign.zz_CheckValue = false;
            this.ctl_only_selected_consign.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_only_selected_consign.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_only_selected_consign.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_only_selected_consign.zz_OriginalDesign = false;
            this.ctl_only_selected_consign.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_only_selected
            // 
            this.ctl_only_selected.BackColor = System.Drawing.Color.Transparent;
            this.ctl_only_selected.Bold = false;
            this.ctl_only_selected.Caption = "Selected Excess";
            this.ctl_only_selected.Changed = false;
            this.ctl_only_selected.Location = new System.Drawing.Point(5, 174);
            this.ctl_only_selected.Name = "ctl_only_selected";
            this.ctl_only_selected.Size = new System.Drawing.Size(105, 18);
            this.ctl_only_selected.TabIndex = 18;
            this.ctl_only_selected.UseParentBackColor = false;
            this.ctl_only_selected.zz_CheckValue = false;
            this.ctl_only_selected.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_only_selected.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_only_selected.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_only_selected.zz_OriginalDesign = false;
            this.ctl_only_selected.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_withcost
            // 
            this.ctl_withcost.BackColor = System.Drawing.Color.Transparent;
            this.ctl_withcost.Bold = false;
            this.ctl_withcost.Caption = "Excess /w Cost > 0";
            this.ctl_withcost.Changed = false;
            this.ctl_withcost.Location = new System.Drawing.Point(322, 174);
            this.ctl_withcost.Name = "ctl_withcost";
            this.ctl_withcost.Size = new System.Drawing.Size(118, 18);
            this.ctl_withcost.TabIndex = 16;
            this.ctl_withcost.UseParentBackColor = false;
            this.ctl_withcost.zz_CheckValue = false;
            this.ctl_withcost.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_withcost.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_withcost.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_withcost.zz_OriginalDesign = false;
            this.ctl_withcost.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_filter_dupes
            // 
            this.ctl_filter_dupes.BackColor = System.Drawing.Color.Transparent;
            this.ctl_filter_dupes.Bold = false;
            this.ctl_filter_dupes.Caption = "Filter Dupes";
            this.ctl_filter_dupes.Changed = false;
            this.ctl_filter_dupes.Location = new System.Drawing.Point(208, 6);
            this.ctl_filter_dupes.Name = "ctl_filter_dupes";
            this.ctl_filter_dupes.Size = new System.Drawing.Size(82, 18);
            this.ctl_filter_dupes.TabIndex = 15;
            this.ctl_filter_dupes.UseParentBackColor = false;
            this.ctl_filter_dupes.zz_CheckValue = false;
            this.ctl_filter_dupes.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_filter_dupes.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_filter_dupes.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_filter_dupes.zz_OriginalDesign = false;
            this.ctl_filter_dupes.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_exportconsigned
            // 
            this.ctl_exportconsigned.BackColor = System.Drawing.Color.Transparent;
            this.ctl_exportconsigned.Bold = false;
            this.ctl_exportconsigned.Caption = "Export Consigned";
            this.ctl_exportconsigned.Changed = false;
            this.ctl_exportconsigned.Location = new System.Drawing.Point(103, 26);
            this.ctl_exportconsigned.Name = "ctl_exportconsigned";
            this.ctl_exportconsigned.Size = new System.Drawing.Size(125, 18);
            this.ctl_exportconsigned.TabIndex = 4;
            this.ctl_exportconsigned.UseParentBackColor = false;
            this.ctl_exportconsigned.zz_CheckValue = false;
            this.ctl_exportconsigned.zz_LabelColor = System.Drawing.Color.Navy;
            this.ctl_exportconsigned.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_exportconsigned.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_exportconsigned.zz_OriginalDesign = false;
            this.ctl_exportconsigned.zz_ShowNeedsSaveColor = true;
            this.ctl_exportconsigned.CheckChanged += new NewMethod.CheckChangedHandler(this.ctl_exportconsigned_CheckChanged);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdRefresh.ImageIndex = 0;
            this.cmdRefresh.ImageList = this.IM;
            this.cmdRefresh.Location = new System.Drawing.Point(3, 195);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(103, 41);
            this.cmdRefresh.TabIndex = 10;
            this.cmdRefresh.Text = "Refresh List";
            this.cmdRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // IM
            // 
            this.IM.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IM.ImageStream")));
            this.IM.TransparentColor = System.Drawing.Color.Transparent;
            this.IM.Images.SetKeyName(0, "refresh.gif");
            // 
            // cmdNew
            // 
            this.cmdNew.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNew.Image = global::RzInterfaceWin.Properties.Resources.NewCardHS;
            this.cmdNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdNew.Location = new System.Drawing.Point(114, 195);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(103, 41);
            this.cmdNew.TabIndex = 9;
            this.cmdNew.Text = "New Template";
            this.cmdNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.Image = global::RzInterfaceWin.Properties.Resources.eventlogError;
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdDelete.Location = new System.Drawing.Point(227, 195);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(103, 41);
            this.cmdDelete.TabIndex = 8;
            this.cmdDelete.Text = "Delete Template";
            this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Image = global::RzInterfaceWin.Properties.Resources.saveHS;
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdSave.Location = new System.Drawing.Point(338, 195);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(103, 41);
            this.cmdSave.TabIndex = 7;
            this.cmdSave.Text = "Save Template";
            this.cmdSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // ctl_exportstock
            // 
            this.ctl_exportstock.BackColor = System.Drawing.Color.Transparent;
            this.ctl_exportstock.Bold = false;
            this.ctl_exportstock.Caption = "Export Stock";
            this.ctl_exportstock.Changed = false;
            this.ctl_exportstock.Location = new System.Drawing.Point(0, 26);
            this.ctl_exportstock.Name = "ctl_exportstock";
            this.ctl_exportstock.Size = new System.Drawing.Size(99, 18);
            this.ctl_exportstock.TabIndex = 6;
            this.ctl_exportstock.UseParentBackColor = false;
            this.ctl_exportstock.zz_CheckValue = false;
            this.ctl_exportstock.zz_LabelColor = System.Drawing.Color.Navy;
            this.ctl_exportstock.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_exportstock.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_exportstock.zz_OriginalDesign = false;
            this.ctl_exportstock.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_exportexcess
            // 
            this.ctl_exportexcess.BackColor = System.Drawing.Color.Transparent;
            this.ctl_exportexcess.Bold = false;
            this.ctl_exportexcess.Caption = "Export Excess";
            this.ctl_exportexcess.Changed = false;
            this.ctl_exportexcess.Location = new System.Drawing.Point(232, 26);
            this.ctl_exportexcess.Name = "ctl_exportexcess";
            this.ctl_exportexcess.Size = new System.Drawing.Size(106, 18);
            this.ctl_exportexcess.TabIndex = 5;
            this.ctl_exportexcess.UseParentBackColor = false;
            this.ctl_exportexcess.zz_CheckValue = false;
            this.ctl_exportexcess.zz_LabelColor = System.Drawing.Color.Navy;
            this.ctl_exportexcess.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_exportexcess.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_exportexcess.zz_OriginalDesign = false;
            this.ctl_exportexcess.zz_ShowNeedsSaveColor = true;
            this.ctl_exportexcess.CheckChanged += new NewMethod.CheckChangedHandler(this.ctl_exportexcess_CheckChanged);
            // 
            // ctl_pnlength
            // 
            this.ctl_pnlength.BackColor = System.Drawing.Color.Transparent;
            this.ctl_pnlength.Bold = false;
            this.ctl_pnlength.Caption = "PartNumber Length > 2";
            this.ctl_pnlength.Changed = false;
            this.ctl_pnlength.Location = new System.Drawing.Point(302, 5);
            this.ctl_pnlength.Name = "ctl_pnlength";
            this.ctl_pnlength.Size = new System.Drawing.Size(136, 18);
            this.ctl_pnlength.TabIndex = 2;
            this.ctl_pnlength.UseParentBackColor = false;
            this.ctl_pnlength.zz_CheckValue = false;
            this.ctl_pnlength.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_pnlength.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_pnlength.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_pnlength.zz_OriginalDesign = false;
            this.ctl_pnlength.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_qtyabovezero
            // 
            this.ctl_qtyabovezero.BackColor = System.Drawing.Color.Transparent;
            this.ctl_qtyabovezero.Bold = false;
            this.ctl_qtyabovezero.Caption = "Quantity > 0";
            this.ctl_qtyabovezero.Changed = false;
            this.ctl_qtyabovezero.Location = new System.Drawing.Point(110, 5);
            this.ctl_qtyabovezero.Name = "ctl_qtyabovezero";
            this.ctl_qtyabovezero.Size = new System.Drawing.Size(83, 18);
            this.ctl_qtyabovezero.TabIndex = 1;
            this.ctl_qtyabovezero.UseParentBackColor = false;
            this.ctl_qtyabovezero.zz_CheckValue = false;
            this.ctl_qtyabovezero.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_qtyabovezero.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_qtyabovezero.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_qtyabovezero.zz_OriginalDesign = false;
            this.ctl_qtyabovezero.zz_ShowNeedsSaveColor = true;
            // 
            // tabColumns
            // 
            this.tabColumns.Controls.Add(this.lvColumns);
            this.tabColumns.Location = new System.Drawing.Point(4, 22);
            this.tabColumns.Name = "tabColumns";
            this.tabColumns.Padding = new System.Windows.Forms.Padding(3);
            this.tabColumns.Size = new System.Drawing.Size(447, 239);
            this.tabColumns.TabIndex = 1;
            this.tabColumns.Text = "Columns";
            this.tabColumns.UseVisualStyleBackColor = true;
            // 
            // lvColumns
            // 
            this.lvColumns.AddCaption = "Add New";
            this.lvColumns.AllowActions = true;
            this.lvColumns.AllowAdd = false;
            this.lvColumns.AllowDelete = true;
            this.lvColumns.AllowDrop = true;
            this.lvColumns.Caption = "";
            this.lvColumns.CurrentTemplate = null;
            this.lvColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvColumns.ExtraClassInfo = "";
            this.lvColumns.Location = new System.Drawing.Point(3, 3);
            this.lvColumns.MultiSelect = true;
            this.lvColumns.Name = "lvColumns";
            this.lvColumns.Size = new System.Drawing.Size(441, 233);
            this.lvColumns.SuppressSelectionChanged = false;
            this.lvColumns.TabIndex = 30;
            this.lvColumns.zz_OpenColumnMenu = false;
            this.lvColumns.zz_ShowAutoRefresh = true;
            this.lvColumns.zz_ShowUnlimited = true;
            // 
            // tabSQL
            // 
            this.tabSQL.Controls.Add(this.cmdEnable);
            this.tabSQL.Controls.Add(this.gbSQL);
            this.tabSQL.Location = new System.Drawing.Point(4, 22);
            this.tabSQL.Name = "tabSQL";
            this.tabSQL.Size = new System.Drawing.Size(447, 239);
            this.tabSQL.TabIndex = 2;
            this.tabSQL.Text = "SQL";
            this.tabSQL.UseVisualStyleBackColor = true;
            // 
            // cmdEnable
            // 
            this.cmdEnable.Location = new System.Drawing.Point(3, 213);
            this.cmdEnable.Name = "cmdEnable";
            this.cmdEnable.Size = new System.Drawing.Size(441, 23);
            this.cmdEnable.TabIndex = 33;
            this.cmdEnable.Text = "Enable";
            this.cmdEnable.UseVisualStyleBackColor = true;
            this.cmdEnable.Click += new System.EventHandler(this.cmdEnable_Click);
            // 
            // gbSQL
            // 
            this.gbSQL.Controls.Add(this.ctl_manualsql);
            this.gbSQL.Controls.Add(this.ctl_exportstring);
            this.gbSQL.Enabled = false;
            this.gbSQL.Location = new System.Drawing.Point(3, 3);
            this.gbSQL.Name = "gbSQL";
            this.gbSQL.Size = new System.Drawing.Size(441, 204);
            this.gbSQL.TabIndex = 32;
            this.gbSQL.TabStop = false;
            // 
            // ctl_manualsql
            // 
            this.ctl_manualsql.BackColor = System.Drawing.Color.Transparent;
            this.ctl_manualsql.Bold = false;
            this.ctl_manualsql.Caption = "Manual SQL";
            this.ctl_manualsql.Changed = false;
            this.ctl_manualsql.Location = new System.Drawing.Point(2, 9);
            this.ctl_manualsql.Name = "ctl_manualsql";
            this.ctl_manualsql.Size = new System.Drawing.Size(85, 18);
            this.ctl_manualsql.TabIndex = 0;
            this.ctl_manualsql.UseParentBackColor = false;
            this.ctl_manualsql.zz_CheckValue = false;
            this.ctl_manualsql.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_manualsql.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_manualsql.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_manualsql.zz_OriginalDesign = false;
            this.ctl_manualsql.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_exportstring
            // 
            this.ctl_exportstring.BackColor = System.Drawing.Color.Transparent;
            this.ctl_exportstring.Bold = false;
            this.ctl_exportstring.Caption = "";
            this.ctl_exportstring.Changed = false;
            this.ctl_exportstring.DateLines = false;
            this.ctl_exportstring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctl_exportstring.Location = new System.Drawing.Point(3, 16);
            this.ctl_exportstring.Name = "ctl_exportstring";
            this.ctl_exportstring.Size = new System.Drawing.Size(435, 185);
            this.ctl_exportstring.TabIndex = 1;
            this.ctl_exportstring.UseParentBackColor = false;
            this.ctl_exportstring.zz_Enabled = true;
            this.ctl_exportstring.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_exportstring.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_exportstring.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_exportstring.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_exportstring.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_exportstring.zz_OriginalDesign = true;
            this.ctl_exportstring.zz_ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ctl_exportstring.zz_ShowNeedsSaveColor = true;
            this.ctl_exportstring.zz_Text = "";
            this.ctl_exportstring.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_exportstring.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_exportstring.zz_UseGlobalColor = false;
            this.ctl_exportstring.zz_UseGlobalFont = false;
            // 
            // cmdExport
            // 
            this.cmdExport.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExport.Image = global::RzInterfaceWin.Properties.Resources.OK1221;
            this.cmdExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdExport.Location = new System.Drawing.Point(3, 330);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(244, 40);
            this.cmdExport.TabIndex = 32;
            this.cmdExport.Text = "Run Export";
            this.cmdExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // bgExport
            // 
            this.bgExport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgExport_DoWork);
            this.bgExport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgExport_RunWorkerCompleted);
            // 
            // lvTemplates
            // 
            this.lvTemplates.AddCaption = "Add New";
            this.lvTemplates.AllowActions = true;
            this.lvTemplates.AllowAdd = false;
            this.lvTemplates.AllowDelete = true;
            this.lvTemplates.AllowDrop = true;
            this.lvTemplates.Caption = "";
            this.lvTemplates.CurrentTemplate = null;
            this.lvTemplates.ExtraClassInfo = "";
            this.lvTemplates.Location = new System.Drawing.Point(3, 3);
            this.lvTemplates.MultiSelect = true;
            this.lvTemplates.Name = "lvTemplates";
            this.lvTemplates.Size = new System.Drawing.Size(244, 327);
            this.lvTemplates.SuppressSelectionChanged = false;
            this.lvTemplates.TabIndex = 29;
            this.lvTemplates.zz_OpenColumnMenu = false;
            this.lvTemplates.zz_ShowAutoRefresh = true;
            this.lvTemplates.zz_ShowUnlimited = true;
            this.lvTemplates.ObjectClicked += new NewMethod.ObjectClickHandler(this.lvTemplates_ObjectClicked);
            this.lvTemplates.AboutToThrow += new Core.ShowHandler(this.lvTemplates_AboutToThrow);
            this.lvTemplates.FinishedFill += new NewMethod.FillHandler(this.lvTemplates_FinishedFill);
            // 
            // chkAll
            // 
            this.chkAll.BackColor = System.Drawing.Color.Transparent;
            this.chkAll.Bold = false;
            this.chkAll.Caption = "Check/Uncheck All";
            this.chkAll.Changed = false;
            this.chkAll.Location = new System.Drawing.Point(250, 85);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(120, 18);
            this.chkAll.TabIndex = 22;
            this.chkAll.UseParentBackColor = false;
            this.chkAll.zz_CheckValue = false;
            this.chkAll.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.chkAll.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkAll.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.chkAll.zz_OriginalDesign = false;
            this.chkAll.zz_ShowNeedsSaveColor = true;
            this.chkAll.CheckChanged += new NewMethod.CheckChangedHandler(this.chkAll_CheckChanged);
            // 
            // ExportInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.TS);
            this.Controls.Add(this.gbTemplate);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.pbBottom);
            this.Controls.Add(this.pbTop);
            this.Controls.Add(this.lvTemplates);
            this.Name = "ExportInventory";
            this.Size = new System.Drawing.Size(775, 658);
            this.Resize += new System.EventHandler(this.ExportInventory_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).EndInit();
            this.gbTemplate.ResumeLayout(false);
            this.TS.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.ts2.ResumeLayout(false);
            this.tabExcess.ResumeLayout(false);
            this.tabConsign.ResumeLayout(false);
            this.tabOffers.ResumeLayout(false);
            this.tabColumns.ResumeLayout(false);
            this.tabSQL.ResumeLayout(false);
            this.gbSQL.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.PictureBox pbBottom;
        private System.Windows.Forms.PictureBox pbTop;
        private NewMethod.nList lvTemplates;
        private System.Windows.Forms.GroupBox gbTemplate;
        private NewMethod.nEdit_String ctl_exportname;
        private NewMethod.nEdit_String ctl_exportfile;
        private System.Windows.Forms.TabControl TS;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabColumns;
        private System.Windows.Forms.TabPage tabSQL;
        private NewMethod.nEdit_Boolean ctl_manualsql;
        private System.Windows.Forms.GroupBox gbSQL;
        private NewMethod.nEdit_Memo ctl_exportstring;
        private NewMethod.nList lvColumns;
        private System.Windows.Forms.Button cmdEnable;
        private NewMethod.nEdit_Boolean ctl_includeheader;
        private NewMethod.nEdit_Boolean ctl_pnlength;
        private NewMethod.nEdit_Boolean ctl_qtyabovezero;
        private NewMethod.nEdit_Boolean ctl_exportstock;
        private NewMethod.nEdit_Boolean ctl_exportexcess;
        private NewMethod.nEdit_Boolean ctl_exportconsigned;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.ImageList IM;
        private System.ComponentModel.BackgroundWorker bgExport;
        private NewMethod.nEdit_Boolean ctl_filter_dupes;
        private System.Windows.Forms.TabControl ts2;
        private System.Windows.Forms.TabPage tabExcess;
        private System.Windows.Forms.ListView lvImports;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TabPage tabConsign;
        private System.Windows.Forms.ListView lvConsign;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private NewMethod.nEdit_Boolean ctl_only_selected_consign;
        private NewMethod.nEdit_Boolean ctl_only_selected;
        private NewMethod.nEdit_Boolean ctl_withcost;
        private NewMethod.nEdit_Boolean ctl_exportoffers;
        private System.Windows.Forms.TabPage tabOffers;
        private System.Windows.Forms.ListView lvOffers;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private NewMethod.nEdit_Boolean ctl_only_selected_offers;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private NewMethod.nEdit_Boolean ctl_adqty;
        private NewMethod.nEdit_Number ctl_adpercent;
        private NewMethod.nEdit_Boolean chkAll;
    }
}
