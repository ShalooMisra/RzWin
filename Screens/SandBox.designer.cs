using NewMethod;

namespace Rz5
{
    partial class SandBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SandBox));
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.oFile = new System.Windows.Forms.OpenFileDialog();
            this.bgImport = new System.ComponentModel.BackgroundWorker();
            this.bgAtom = new System.ComponentModel.BackgroundWorker();
            this.bgImportPhoenix = new System.ComponentModel.BackgroundWorker();
            this.bgAtomExport = new System.ComponentModel.BackgroundWorker();
            this.lblNotesImport = new System.Windows.Forms.LinkLabel();
            this.lblOrdersImport = new System.Windows.Forms.LinkLabel();
            this.lblVersion = new System.Windows.Forms.LinkLabel();
            this.lblRemoveArch = new System.Windows.Forms.LinkLabel();
            this.lblIdRemove = new System.Windows.Forms.LinkLabel();
            this.IMLrg = new System.Windows.Forms.ImageList(this.components);
            this.IM = new System.Windows.Forms.ImageList(this.components);
            this.lblArRestore = new System.Windows.Forms.LinkLabel();
            this.lblShrink = new System.Windows.Forms.LinkLabel();
            this.lblSaveClassInstances = new System.Windows.Forms.LinkLabel();
            this.lnkReSaveStock = new System.Windows.Forms.LinkLabel();
            this.lblImportCharges = new System.Windows.Forms.LinkLabel();
            this.lblZebraTest = new System.Windows.Forms.LinkLabel();
            this.lblWBPDFTest = new System.Windows.Forms.LinkLabel();
            this.lnkSetSetting = new System.Windows.Forms.LinkLabel();
            this.lnkProcessCSV = new System.Windows.Forms.LinkLabel();
            this.lblImportQBs = new System.Windows.Forms.LinkLabel();
            this.lblRzLink = new System.Windows.Forms.LinkLabel();
            this.lnkOldCommReport = new System.Windows.Forms.LinkLabel();
            this.lblTwit = new System.Windows.Forms.LinkLabel();
            this.lblBFImport = new System.Windows.Forms.LinkLabel();
            this.lblNafta = new System.Windows.Forms.LinkLabel();
            this.lbl7525 = new System.Windows.Forms.LinkLabel();
            this.lblTestPDF = new System.Windows.Forms.LinkLabel();
            this.lblRyan1Import = new System.Windows.Forms.LinkLabel();
            this.lblRyan2Import = new System.Windows.Forms.LinkLabel();
            this.bgRyan1 = new System.ComponentModel.BackgroundWorker();
            this.bgRyan2 = new System.ComponentModel.BackgroundWorker();
            this.lblFirstNames = new System.Windows.Forms.LinkLabel();
            this.lnkEmailGMail = new System.Windows.Forms.LinkLabel();
            this.lnkCommonSettings = new System.Windows.Forms.LinkLabel();
            this.lnkTest = new System.Windows.Forms.LinkLabel();
            this.lblFieldMain = new System.Windows.Forms.LinkLabel();
            this.lblUpdateData = new System.Windows.Forms.LinkLabel();
            this.bgwSaveInstance = new System.ComponentModel.BackgroundWorker();
            this.bgPics = new System.ComponentModel.BackgroundWorker();
            this.lnkPicDetails = new System.Windows.Forms.LinkLabel();
            this.lnkCheckClosed = new System.Windows.Forms.LinkLabel();
            this.bgwClosedOrdersAlfa = new System.ComponentModel.BackgroundWorker();
            this.lnkUpdateAlfaCompTypes = new System.Windows.Forms.LinkLabel();
            this.lnkUpdateAlfaCompNumbs = new System.Windows.Forms.LinkLabel();
            this.lnkCreateOrderViews = new System.Windows.Forms.LinkLabel();
            this.lnkAccountingTest = new System.Windows.Forms.LinkLabel();
            this.lnkAddExampleAccounts = new System.Windows.Forms.LinkLabel();
            this.clearAccountBalances = new System.Windows.Forms.LinkLabel();
            this.removeNonRzAccounts = new System.Windows.Forms.LinkLabel();
            this.productionAccounts = new System.Windows.Forms.LinkLabel();
            this.lnkImportQBsAccounts = new System.Windows.Forms.LinkLabel();
            this.lnkCloseBooks = new System.Windows.Forms.LinkLabel();
            this.bgwQBsAccounts = new System.ComponentModel.BackgroundWorker();
            this.lnkStartingAccounts = new System.Windows.Forms.LinkLabel();
            this.lnkTransferCount = new System.Windows.Forms.LinkLabel();
            this.lnkAddRz3_Ext = new System.Windows.Forms.LinkLabel();
            this.lnkEmailNotification = new System.Windows.Forms.LinkLabel();
            this.lnkImportGLPro = new System.Windows.Forms.LinkLabel();
            this.lnkShowSalesProps = new System.Windows.Forms.LinkLabel();
            this.lnkFixPhoneTable = new System.Windows.Forms.LinkLabel();
            this.gbHubspot = new System.Windows.Forms.GroupBox();
            this.llUpdateHsDeals = new System.Windows.Forms.LinkLabel();
            this.lnklblCreateTestHubspotDeal = new System.Windows.Forms.LinkLabel();
            this.wb = new ToolsWin.Browser();
            this.gbQuickbooks = new System.Windows.Forms.GroupBox();
            this.llShowQuickBench = new System.Windows.Forms.LinkLabel();
            this.lnkCreateQbSaleFromRzLine = new System.Windows.Forms.LinkLabel();
            this.llFixOtherMfg = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbSensible = new System.Windows.Forms.GroupBox();
            this.llCreateListAcquisitionSplitObjects = new System.Windows.Forms.LinkLabel();
            this.llCreateSplitCommissionObjects = new System.Windows.Forms.LinkLabel();
            this.llTestSerilogLogging = new System.Windows.Forms.LinkLabel();
            this.llManuallyShipStock = new System.Windows.Forms.LinkLabel();
            this.lblCloseSalesOrders = new System.Windows.Forms.LinkLabel();
            this.linkUpdateQuoteOppStages = new System.Windows.Forms.LinkLabel();
            this.lnkUpdateInvoiceBalances = new System.Windows.Forms.LinkLabel();
            this.llChooseManufactuer = new System.Windows.Forms.LinkLabel();
            this.llOpenRecentTabs = new System.Windows.Forms.LinkLabel();
            this.lnkSetRecentTabs = new System.Windows.Forms.LinkLabel();
            this.llTestEmail = new System.Windows.Forms.LinkLabel();
            this.gbHubspot.SuspendLayout();
            this.gbQuickbooks.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbSensible.SuspendLayout();
            this.SuspendLayout();
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // bgImport
            // 
            this.bgImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgImport_DoWork);
            this.bgImport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgImport_RunWorkerCompleted);
            // 
            // bgImportPhoenix
            // 
            this.bgImportPhoenix.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgImportPhoenix_DoWork);
            this.bgImportPhoenix.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgImportPhoenix_RunWorkerCompleted);
            // 
            // bgAtomExport
            // 
            this.bgAtomExport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgAtomExport_DoWork);
            this.bgAtomExport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgAtomExport_RunWorkerCompleted);
            // 
            // lblNotesImport
            // 
            this.lblNotesImport.AutoSize = true;
            this.lblNotesImport.Location = new System.Drawing.Point(10, 103);
            this.lblNotesImport.Name = "lblNotesImport";
            this.lblNotesImport.Size = new System.Drawing.Size(64, 13);
            this.lblNotesImport.TabIndex = 115;
            this.lblNotesImport.TabStop = true;
            this.lblNotesImport.Text = "notes import";
            this.lblNotesImport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNotesImport_LinkClicked);
            // 
            // lblOrdersImport
            // 
            this.lblOrdersImport.AutoSize = true;
            this.lblOrdersImport.Location = new System.Drawing.Point(10, 9);
            this.lblOrdersImport.Name = "lblOrdersImport";
            this.lblOrdersImport.Size = new System.Drawing.Size(67, 13);
            this.lblOrdersImport.TabIndex = 116;
            this.lblOrdersImport.TabStop = true;
            this.lblOrdersImport.Text = "orders import";
            this.lblOrdersImport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblOrdersImport_LinkClicked);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(10, 31);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(79, 13);
            this.lblVersion.TabIndex = 117;
            this.lblVersion.TabStop = true;
            this.lblVersion.Text = "version number";
            this.lblVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblVersion_LinkClicked);
            // 
            // lblRemoveArch
            // 
            this.lblRemoveArch.AutoSize = true;
            this.lblRemoveArch.Location = new System.Drawing.Point(10, 126);
            this.lblRemoveArch.Name = "lblRemoveArch";
            this.lblRemoveArch.Size = new System.Drawing.Size(170, 13);
            this.lblRemoveArch.TabIndex = 118;
            this.lblRemoveArch.TabStop = true;
            this.lblRemoveArch.Text = "Remove Arch Tables And Triggers";
            this.lblRemoveArch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRemoveArch_LinkClicked);
            // 
            // lblIdRemove
            // 
            this.lblIdRemove.AutoSize = true;
            this.lblIdRemove.Location = new System.Drawing.Point(10, 54);
            this.lblIdRemove.Name = "lblIdRemove";
            this.lblIdRemove.Size = new System.Drawing.Size(93, 13);
            this.lblIdRemove.TabIndex = 119;
            this.lblIdRemove.TabStop = true;
            this.lblIdRemove.Text = "remove the id field";
            this.lblIdRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblIdRemove_LinkClicked);
            // 
            // IMLrg
            // 
            this.IMLrg.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IMLrg.ImageStream")));
            this.IMLrg.TransparentColor = System.Drawing.Color.Fuchsia;
            this.IMLrg.Images.SetKeyName(0, "Choices.bmp");
            this.IMLrg.Images.SetKeyName(1, "Users.bmp");
            this.IMLrg.Images.SetKeyName(2, "Statistics.bmp");
            this.IMLrg.Images.SetKeyName(3, "Monitors.bmp");
            this.IMLrg.Images.SetKeyName(4, "PrintedForms.bmp");
            this.IMLrg.Images.SetKeyName(5, "SystemManagement.bmp");
            this.IMLrg.Images.SetKeyName(6, "Email.bmp");
            // 
            // IM
            // 
            this.IM.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IM.ImageStream")));
            this.IM.TransparentColor = System.Drawing.Color.Fuchsia;
            this.IM.Images.SetKeyName(0, "Users.bmp");
            this.IM.Images.SetKeyName(1, "Summaries.bmp");
            this.IM.Images.SetKeyName(2, "AddressOptions.bmp");
            this.IM.Images.SetKeyName(3, "EmailTemplates.bmp");
            this.IM.Images.SetKeyName(4, "Configure.bmp");
            this.IM.Images.SetKeyName(5, "Screen.bmp");
            this.IM.Images.SetKeyName(6, "AddNewChoiceList.bmp");
            this.IM.Images.SetKeyName(7, "EditList.bmp");
            this.IM.Images.SetKeyName(8, "YourCompanyInformation.bmp");
            this.IM.Images.SetKeyName(9, "EmailBlaster.bmp");
            this.IM.Images.SetKeyName(10, "DatabaseManager.bmp");
            this.IM.Images.SetKeyName(11, "WebUpdate.bmp");
            this.IM.Images.SetKeyName(12, "Design.bmp");
            this.IM.Images.SetKeyName(13, "Import.bmp");
            this.IM.Images.SetKeyName(14, "DutyMonitor.bmp");
            this.IM.Images.SetKeyName(15, "PhoneFaxMonitor.bmp");
            this.IM.Images.SetKeyName(16, "BinSwapper.bmp");
            this.IM.Images.SetKeyName(17, "PictureResizeTool.bmp");
            // 
            // lblArRestore
            // 
            this.lblArRestore.AutoSize = true;
            this.lblArRestore.Location = new System.Drawing.Point(10, 78);
            this.lblArRestore.Name = "lblArRestore";
            this.lblArRestore.Size = new System.Drawing.Size(51, 13);
            this.lblArRestore.TabIndex = 120;
            this.lblArRestore.TabStop = true;
            this.lblArRestore.Text = "ar restore";
            this.lblArRestore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblArRestore_LinkClicked);
            // 
            // lblShrink
            // 
            this.lblShrink.AutoSize = true;
            this.lblShrink.Location = new System.Drawing.Point(10, 151);
            this.lblShrink.Name = "lblShrink";
            this.lblShrink.Size = new System.Drawing.Size(95, 13);
            this.lblShrink.TabIndex = 121;
            this.lblShrink.TabStop = true;
            this.lblShrink.Text = "Shrink the pictures";
            this.lblShrink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblShrink_LinkClicked);
            // 
            // lblSaveClassInstances
            // 
            this.lblSaveClassInstances.AutoSize = true;
            this.lblSaveClassInstances.Location = new System.Drawing.Point(10, 176);
            this.lblSaveClassInstances.Name = "lblSaveClassInstances";
            this.lblSaveClassInstances.Size = new System.Drawing.Size(167, 13);
            this.lblSaveClassInstances.TabIndex = 122;
            this.lblSaveClassInstances.TabStop = true;
            this.lblSaveClassInstances.Text = "Re-save every instance of a class";
            this.lblSaveClassInstances.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSaveClassInstances_LinkClicked);
            // 
            // lnkReSaveStock
            // 
            this.lnkReSaveStock.AutoSize = true;
            this.lnkReSaveStock.Location = new System.Drawing.Point(10, 200);
            this.lnkReSaveStock.Name = "lnkReSaveStock";
            this.lnkReSaveStock.Size = new System.Drawing.Size(80, 13);
            this.lnkReSaveStock.TabIndex = 124;
            this.lnkReSaveStock.TabStop = true;
            this.lnkReSaveStock.Text = "Re-Save Stock";
            this.lnkReSaveStock.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReSaveStock_LinkClicked);
            // 
            // lblImportCharges
            // 
            this.lblImportCharges.AutoSize = true;
            this.lblImportCharges.Location = new System.Drawing.Point(10, 226);
            this.lblImportCharges.Name = "lblImportCharges";
            this.lblImportCharges.Size = new System.Drawing.Size(78, 13);
            this.lblImportCharges.TabIndex = 125;
            this.lblImportCharges.TabStop = true;
            this.lblImportCharges.Text = "Import Charges";
            this.lblImportCharges.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblImportCharges_LinkClicked);
            // 
            // lblZebraTest
            // 
            this.lblZebraTest.AutoSize = true;
            this.lblZebraTest.Location = new System.Drawing.Point(12, 251);
            this.lblZebraTest.Name = "lblZebraTest";
            this.lblZebraTest.Size = new System.Drawing.Size(59, 13);
            this.lblZebraTest.TabIndex = 126;
            this.lblZebraTest.TabStop = true;
            this.lblZebraTest.Text = "Zebra Test";
            this.lblZebraTest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblZebraTest_LinkClicked);
            // 
            // lblWBPDFTest
            // 
            this.lblWBPDFTest.AutoSize = true;
            this.lblWBPDFTest.Location = new System.Drawing.Point(163, 9);
            this.lblWBPDFTest.Name = "lblWBPDFTest";
            this.lblWBPDFTest.Size = new System.Drawing.Size(49, 13);
            this.lblWBPDFTest.TabIndex = 127;
            this.lblWBPDFTest.TabStop = true;
            this.lblWBPDFTest.Text = "Test WB";
            this.lblWBPDFTest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblWBPDFTest_LinkClicked);
            // 
            // lnkSetSetting
            // 
            this.lnkSetSetting.AutoSize = true;
            this.lnkSetSetting.Location = new System.Drawing.Point(12, 272);
            this.lnkSetSetting.Name = "lnkSetSetting";
            this.lnkSetSetting.Size = new System.Drawing.Size(59, 13);
            this.lnkSetSetting.TabIndex = 129;
            this.lnkSetSetting.TabStop = true;
            this.lnkSetSetting.Text = "Set Setting";
            this.lnkSetSetting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSetSetting_LinkClicked);
            // 
            // lnkProcessCSV
            // 
            this.lnkProcessCSV.AutoSize = true;
            this.lnkProcessCSV.Location = new System.Drawing.Point(12, 311);
            this.lnkProcessCSV.Name = "lnkProcessCSV";
            this.lnkProcessCSV.Size = new System.Drawing.Size(69, 13);
            this.lnkProcessCSV.TabIndex = 130;
            this.lnkProcessCSV.TabStop = true;
            this.lnkProcessCSV.Text = "Process CSV";
            this.lnkProcessCSV.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProcessCSV_LinkClicked);
            // 
            // lblImportQBs
            // 
            this.lblImportQBs.AutoSize = true;
            this.lblImportQBs.Location = new System.Drawing.Point(12, 338);
            this.lblImportQBs.Name = "lblImportQBs";
            this.lblImportQBs.Size = new System.Drawing.Size(122, 13);
            this.lblImportQBs.TabIndex = 131;
            this.lblImportQBs.TabStop = true;
            this.lblImportQBs.Text = "Import From Quickbooks";
            this.lblImportQBs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblImportQBs_LinkClicked);
            // 
            // lblRzLink
            // 
            this.lblRzLink.AutoSize = true;
            this.lblRzLink.Location = new System.Drawing.Point(12, 361);
            this.lblRzLink.Name = "lblRzLink";
            this.lblRzLink.Size = new System.Drawing.Size(40, 13);
            this.lblRzLink.TabIndex = 132;
            this.lblRzLink.TabStop = true;
            this.lblRzLink.Text = "RzLink";
            this.lblRzLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRzLink_LinkClicked);
            // 
            // lnkOldCommReport
            // 
            this.lnkOldCommReport.AutoSize = true;
            this.lnkOldCommReport.Location = new System.Drawing.Point(226, 9);
            this.lnkOldCommReport.Name = "lnkOldCommReport";
            this.lnkOldCommReport.Size = new System.Drawing.Size(90, 13);
            this.lnkOldCommReport.TabIndex = 133;
            this.lnkOldCommReport.TabStop = true;
            this.lnkOldCommReport.Text = "Old Comm Report";
            this.lnkOldCommReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOldCommReport_LinkClicked);
            // 
            // lblTwit
            // 
            this.lblTwit.AutoSize = true;
            this.lblTwit.Location = new System.Drawing.Point(12, 383);
            this.lblTwit.Name = "lblTwit";
            this.lblTwit.Size = new System.Drawing.Size(63, 13);
            this.lblTwit.TabIndex = 134;
            this.lblTwit.TabStop = true;
            this.lblTwit.Text = "Twitter Test";
            this.lblTwit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblTwit_LinkClicked);
            // 
            // lblBFImport
            // 
            this.lblBFImport.AutoSize = true;
            this.lblBFImport.Location = new System.Drawing.Point(14, 409);
            this.lblBFImport.Name = "lblBFImport";
            this.lblBFImport.Size = new System.Drawing.Size(127, 13);
            this.lblBFImport.TabIndex = 135;
            this.lblBFImport.TabStop = true;
            this.lblBFImport.Text = "BrokerForum Email Import";
            this.lblBFImport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblBFImport_LinkClicked);
            // 
            // lblNafta
            // 
            this.lblNafta.AutoSize = true;
            this.lblNafta.Location = new System.Drawing.Point(14, 437);
            this.lblNafta.Name = "lblNafta";
            this.lblNafta.Size = new System.Drawing.Size(97, 13);
            this.lblNafta.TabIndex = 136;
            this.lblNafta.TabStop = true;
            this.lblNafta.Text = "TJR NAFTA Import";
            this.lblNafta.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNafta_LinkClicked);
            // 
            // lbl7525
            // 
            this.lbl7525.AutoSize = true;
            this.lbl7525.Location = new System.Drawing.Point(14, 462);
            this.lbl7525.Name = "lbl7525";
            this.lbl7525.Size = new System.Drawing.Size(86, 13);
            this.lbl7525.TabIndex = 137;
            this.lbl7525.TabStop = true;
            this.lbl7525.Text = "TJR 7525 Import";
            this.lbl7525.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl7525_LinkClicked);
            // 
            // lblTestPDF
            // 
            this.lblTestPDF.AutoSize = true;
            this.lblTestPDF.Location = new System.Drawing.Point(14, 490);
            this.lblTestPDF.Name = "lblTestPDF";
            this.lblTestPDF.Size = new System.Drawing.Size(52, 13);
            this.lblTestPDF.TabIndex = 138;
            this.lblTestPDF.TabStop = true;
            this.lblTestPDF.Text = "PDF Test";
            this.lblTestPDF.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblTestPDF_LinkClicked);
            // 
            // lblRyan1Import
            // 
            this.lblRyan1Import.AutoSize = true;
            this.lblRyan1Import.Location = new System.Drawing.Point(230, 437);
            this.lblRyan1Import.Name = "lblRyan1Import";
            this.lblRyan1Import.Size = new System.Drawing.Size(101, 13);
            this.lblRyan1Import.TabIndex = 139;
            this.lblRyan1Import.TabStop = true;
            this.lblRyan1Import.Text = "Braun Ryan1 Import";
            this.lblRyan1Import.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRyan1Import_LinkClicked);
            // 
            // lblRyan2Import
            // 
            this.lblRyan2Import.AutoSize = true;
            this.lblRyan2Import.Location = new System.Drawing.Point(230, 462);
            this.lblRyan2Import.Name = "lblRyan2Import";
            this.lblRyan2Import.Size = new System.Drawing.Size(101, 13);
            this.lblRyan2Import.TabIndex = 140;
            this.lblRyan2Import.TabStop = true;
            this.lblRyan2Import.Text = "Braun Ryan2 Import";
            this.lblRyan2Import.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRyan2Import_LinkClicked);
            // 
            // bgRyan1
            // 
            this.bgRyan1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgRyan1_DoWork);
            this.bgRyan1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgRyan1_RunWorkerCompleted);
            // 
            // bgRyan2
            // 
            this.bgRyan2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgRyan2_DoWork);
            this.bgRyan2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgRyan2_RunWorkerCompleted);
            // 
            // lblFirstNames
            // 
            this.lblFirstNames.AutoSize = true;
            this.lblFirstNames.Location = new System.Drawing.Point(14, 519);
            this.lblFirstNames.Name = "lblFirstNames";
            this.lblFirstNames.Size = new System.Drawing.Size(132, 13);
            this.lblFirstNames.TabIndex = 141;
            this.lblFirstNames.TabStop = true;
            this.lblFirstNames.Text = "Parse Contact First Names";
            this.lblFirstNames.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblFirstNames_LinkClicked);
            // 
            // lnkEmailGMail
            // 
            this.lnkEmailGMail.AutoSize = true;
            this.lnkEmailGMail.Location = new System.Drawing.Point(230, 490);
            this.lnkEmailGMail.Name = "lnkEmailGMail";
            this.lnkEmailGMail.Size = new System.Drawing.Size(86, 13);
            this.lnkEmailGMail.TabIndex = 142;
            this.lnkEmailGMail.TabStop = true;
            this.lnkEmailGMail.Text = "GMail Email Test";
            this.lnkEmailGMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEmailGMail_LinkClicked);
            // 
            // lnkCommonSettings
            // 
            this.lnkCommonSettings.AutoSize = true;
            this.lnkCommonSettings.Location = new System.Drawing.Point(14, 292);
            this.lnkCommonSettings.Name = "lnkCommonSettings";
            this.lnkCommonSettings.Size = new System.Drawing.Size(89, 13);
            this.lnkCommonSettings.TabIndex = 143;
            this.lnkCommonSettings.TabStop = true;
            this.lnkCommonSettings.Text = "Common Settings";
            this.lnkCommonSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCommonSettings_LinkClicked);
            // 
            // lnkTest
            // 
            this.lnkTest.AutoSize = true;
            this.lnkTest.Location = new System.Drawing.Point(163, 31);
            this.lnkTest.Name = "lnkTest";
            this.lnkTest.Size = new System.Drawing.Size(28, 13);
            this.lnkTest.TabIndex = 144;
            this.lnkTest.TabStop = true;
            this.lnkTest.Text = "Test";
            this.lnkTest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTest_LinkClicked);
            // 
            // lblFieldMain
            // 
            this.lblFieldMain.AutoSize = true;
            this.lblFieldMain.Location = new System.Drawing.Point(349, 9);
            this.lblFieldMain.Name = "lblFieldMain";
            this.lblFieldMain.Size = new System.Drawing.Size(94, 13);
            this.lblFieldMain.TabIndex = 145;
            this.lblFieldMain.TabStop = true;
            this.lblFieldMain.Text = "Field Maintenance";
            this.lblFieldMain.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblFieldMain_LinkClicked);
            // 
            // lblUpdateData
            // 
            this.lblUpdateData.AutoSize = true;
            this.lblUpdateData.Location = new System.Drawing.Point(349, 31);
            this.lblUpdateData.Name = "lblUpdateData";
            this.lblUpdateData.Size = new System.Drawing.Size(114, 13);
            this.lblUpdateData.TabIndex = 146;
            this.lblUpdateData.TabStop = true;
            this.lblUpdateData.Text = "Update Data Structure";
            this.lblUpdateData.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblUpdateData_LinkClicked);
            // 
            // bgwSaveInstance
            // 
            this.bgwSaveInstance.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSaveInstance_DoWork);
            this.bgwSaveInstance.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSaveInstance_RunWorkerCompleted);
            // 
            // bgPics
            // 
            this.bgPics.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgPics_DoWork);
            this.bgPics.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgPics_RunWorkerCompleted);
            // 
            // lnkPicDetails
            // 
            this.lnkPicDetails.AutoSize = true;
            this.lnkPicDetails.Location = new System.Drawing.Point(503, 9);
            this.lnkPicDetails.Name = "lnkPicDetails";
            this.lnkPicDetails.Size = new System.Drawing.Size(112, 13);
            this.lnkPicDetails.TabIndex = 147;
            this.lnkPicDetails.TabStop = true;
            this.lnkPicDetails.Text = "Adjust Orddet Line QC";
            this.lnkPicDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPicDetails_LinkClicked);
            // 
            // lnkCheckClosed
            // 
            this.lnkCheckClosed.AutoSize = true;
            this.lnkCheckClosed.Location = new System.Drawing.Point(503, 31);
            this.lnkCheckClosed.Name = "lnkCheckClosed";
            this.lnkCheckClosed.Size = new System.Drawing.Size(146, 13);
            this.lnkCheckClosed.TabIndex = 148;
            this.lnkCheckClosed.TabStop = true;
            this.lnkCheckClosed.Text = "Check For Closed Orders Alfa";
            this.lnkCheckClosed.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCheckClosed_LinkClicked);
            // 
            // bgwClosedOrdersAlfa
            // 
            this.bgwClosedOrdersAlfa.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwClosedOrdersAlfa_DoWork);
            this.bgwClosedOrdersAlfa.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwClosedOrdersAlfa_RunWorkerCompleted);
            // 
            // lnkUpdateAlfaCompTypes
            // 
            this.lnkUpdateAlfaCompTypes.AutoSize = true;
            this.lnkUpdateAlfaCompTypes.Location = new System.Drawing.Point(667, 9);
            this.lnkUpdateAlfaCompTypes.Name = "lnkUpdateAlfaCompTypes";
            this.lnkUpdateAlfaCompTypes.Size = new System.Drawing.Size(142, 13);
            this.lnkUpdateAlfaCompTypes.TabIndex = 149;
            this.lnkUpdateAlfaCompTypes.TabStop = true;
            this.lnkUpdateAlfaCompTypes.Text = "Update Alfa Company Types";
            this.lnkUpdateAlfaCompTypes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpdateAlfaCompTypes_LinkClicked);
            // 
            // lnkUpdateAlfaCompNumbs
            // 
            this.lnkUpdateAlfaCompNumbs.AutoSize = true;
            this.lnkUpdateAlfaCompNumbs.Location = new System.Drawing.Point(667, 31);
            this.lnkUpdateAlfaCompNumbs.Name = "lnkUpdateAlfaCompNumbs";
            this.lnkUpdateAlfaCompNumbs.Size = new System.Drawing.Size(155, 13);
            this.lnkUpdateAlfaCompNumbs.TabIndex = 150;
            this.lnkUpdateAlfaCompNumbs.TabStop = true;
            this.lnkUpdateAlfaCompNumbs.Text = "Update Alfa Company Numbers";
            this.lnkUpdateAlfaCompNumbs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpdateAlfaCompNumbs_LinkClicked);
            // 
            // lnkCreateOrderViews
            // 
            this.lnkCreateOrderViews.AutoSize = true;
            this.lnkCreateOrderViews.Location = new System.Drawing.Point(231, 519);
            this.lnkCreateOrderViews.Name = "lnkCreateOrderViews";
            this.lnkCreateOrderViews.Size = new System.Drawing.Size(98, 13);
            this.lnkCreateOrderViews.TabIndex = 151;
            this.lnkCreateOrderViews.TabStop = true;
            this.lnkCreateOrderViews.Text = "Create Order Views";
            this.lnkCreateOrderViews.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCreateOrderViews_LinkClicked);
            // 
            // lnkAccountingTest
            // 
            this.lnkAccountingTest.AutoSize = true;
            this.lnkAccountingTest.Location = new System.Drawing.Point(14, 548);
            this.lnkAccountingTest.Name = "lnkAccountingTest";
            this.lnkAccountingTest.Size = new System.Drawing.Size(85, 13);
            this.lnkAccountingTest.TabIndex = 152;
            this.lnkAccountingTest.TabStop = true;
            this.lnkAccountingTest.Text = "Accounting Test";
            this.lnkAccountingTest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAccountingTest_LinkClicked);
            // 
            // lnkAddExampleAccounts
            // 
            this.lnkAddExampleAccounts.AutoSize = true;
            this.lnkAddExampleAccounts.Location = new System.Drawing.Point(38, 566);
            this.lnkAddExampleAccounts.Name = "lnkAddExampleAccounts";
            this.lnkAddExampleAccounts.Size = new System.Drawing.Size(117, 13);
            this.lnkAddExampleAccounts.TabIndex = 153;
            this.lnkAddExampleAccounts.TabStop = true;
            this.lnkAddExampleAccounts.Text = "[AddExampleAccounts]";
            this.lnkAddExampleAccounts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddExampleAccounts_LinkClicked);
            // 
            // clearAccountBalances
            // 
            this.clearAccountBalances.AutoSize = true;
            this.clearAccountBalances.Location = new System.Drawing.Point(38, 585);
            this.clearAccountBalances.Name = "clearAccountBalances";
            this.clearAccountBalances.Size = new System.Drawing.Size(173, 13);
            this.clearAccountBalances.TabIndex = 154;
            this.clearAccountBalances.TabStop = true;
            this.clearAccountBalances.Text = "[Clear Balances - Truncate Journal]";
            this.clearAccountBalances.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.clearAccountBalances_LinkClicked);
            // 
            // removeNonRzAccounts
            // 
            this.removeNonRzAccounts.AutoSize = true;
            this.removeNonRzAccounts.Location = new System.Drawing.Point(37, 604);
            this.removeNonRzAccounts.Name = "removeNonRzAccounts";
            this.removeNonRzAccounts.Size = new System.Drawing.Size(140, 13);
            this.removeNonRzAccounts.TabIndex = 155;
            this.removeNonRzAccounts.TabStop = true;
            this.removeNonRzAccounts.Text = "[Remove Non-Rz Examples]";
            this.removeNonRzAccounts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.removeNonRzAccounts_LinkClicked);
            // 
            // productionAccounts
            // 
            this.productionAccounts.AutoSize = true;
            this.productionAccounts.Location = new System.Drawing.Point(226, 566);
            this.productionAccounts.Name = "productionAccounts";
            this.productionAccounts.Size = new System.Drawing.Size(128, 13);
            this.productionAccounts.TabIndex = 156;
            this.productionAccounts.TabStop = true;
            this.productionAccounts.Text = "[AddProductionAccounts]";
            this.productionAccounts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.productionAccounts_LinkClicked);
            // 
            // lnkImportQBsAccounts
            // 
            this.lnkImportQBsAccounts.AutoSize = true;
            this.lnkImportQBsAccounts.Location = new System.Drawing.Point(356, 519);
            this.lnkImportQBsAccounts.Name = "lnkImportQBsAccounts";
            this.lnkImportQBsAccounts.Size = new System.Drawing.Size(107, 13);
            this.lnkImportQBsAccounts.TabIndex = 157;
            this.lnkImportQBsAccounts.TabStop = true;
            this.lnkImportQBsAccounts.Text = "Import QBs Accounts";
            this.lnkImportQBsAccounts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkImportQBsAccounts_LinkClicked);
            // 
            // lnkCloseBooks
            // 
            this.lnkCloseBooks.AutoSize = true;
            this.lnkCloseBooks.Location = new System.Drawing.Point(226, 585);
            this.lnkCloseBooks.Name = "lnkCloseBooks";
            this.lnkCloseBooks.Size = new System.Drawing.Size(88, 13);
            this.lnkCloseBooks.TabIndex = 158;
            this.lnkCloseBooks.TabStop = true;
            this.lnkCloseBooks.Text = "Close The Books";
            this.lnkCloseBooks.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCloseBooks_LinkClicked);
            // 
            // bgwQBsAccounts
            // 
            this.bgwQBsAccounts.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwQBsAccounts_DoWork);
            this.bgwQBsAccounts.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwQBsAccounts_RunWorkerCompleted);
            // 
            // lnkStartingAccounts
            // 
            this.lnkStartingAccounts.AutoSize = true;
            this.lnkStartingAccounts.Location = new System.Drawing.Point(356, 490);
            this.lnkStartingAccounts.Name = "lnkStartingAccounts";
            this.lnkStartingAccounts.Size = new System.Drawing.Size(113, 13);
            this.lnkStartingAccounts.TabIndex = 159;
            this.lnkStartingAccounts.TabStop = true;
            this.lnkStartingAccounts.Text = "Add Starting Accounts";
            this.lnkStartingAccounts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkStartingAccounts_LinkClicked);
            // 
            // lnkTransferCount
            // 
            this.lnkTransferCount.AutoSize = true;
            this.lnkTransferCount.Location = new System.Drawing.Point(356, 548);
            this.lnkTransferCount.Name = "lnkTransferCount";
            this.lnkTransferCount.Size = new System.Drawing.Size(120, 13);
            this.lnkTransferCount.TabIndex = 160;
            this.lnkTransferCount.TabStop = true;
            this.lnkTransferCount.Text = "Get QBs Transfer Count";
            this.lnkTransferCount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTransferCount_LinkClicked);
            // 
            // lnkAddRz3_Ext
            // 
            this.lnkAddRz3_Ext.AutoSize = true;
            this.lnkAddRz3_Ext.Location = new System.Drawing.Point(163, 54);
            this.lnkAddRz3_Ext.Name = "lnkAddRz3_Ext";
            this.lnkAddRz3_Ext.Size = new System.Drawing.Size(69, 13);
            this.lnkAddRz3_Ext.TabIndex = 161;
            this.lnkAddRz3_Ext.TabStop = true;
            this.lnkAddRz3_Ext.Text = "Add Rz3_Ext";
            this.lnkAddRz3_Ext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddRz3_Ext_LinkClicked);
            // 
            // lnkEmailNotification
            // 
            this.lnkEmailNotification.AutoSize = true;
            this.lnkEmailNotification.Location = new System.Drawing.Point(231, 417);
            this.lnkEmailNotification.Name = "lnkEmailNotification";
            this.lnkEmailNotification.Size = new System.Drawing.Size(88, 13);
            this.lnkEmailNotification.TabIndex = 162;
            this.lnkEmailNotification.TabStop = true;
            this.lnkEmailNotification.Text = "Email Notification";
            this.lnkEmailNotification.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEmailNotification_LinkClicked);
            // 
            // lnkImportGLPro
            // 
            this.lnkImportGLPro.AutoSize = true;
            this.lnkImportGLPro.Location = new System.Drawing.Point(356, 417);
            this.lnkImportGLPro.Name = "lnkImportGLPro";
            this.lnkImportGLPro.Size = new System.Drawing.Size(117, 13);
            this.lnkImportGLPro.TabIndex = 163;
            this.lnkImportGLPro.TabStop = true;
            this.lnkImportGLPro.Text = "Import GLPro Accounts";
            this.lnkImportGLPro.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkImportGLPro_LinkClicked);
            // 
            // lnkShowSalesProps
            // 
            this.lnkShowSalesProps.AutoSize = true;
            this.lnkShowSalesProps.Location = new System.Drawing.Point(356, 437);
            this.lnkShowSalesProps.Name = "lnkShowSalesProps";
            this.lnkShowSalesProps.Size = new System.Drawing.Size(93, 13);
            this.lnkShowSalesProps.TabIndex = 166;
            this.lnkShowSalesProps.TabStop = true;
            this.lnkShowSalesProps.Text = "Show Sales Props";
            // 
            // lnkFixPhoneTable
            // 
            this.lnkFixPhoneTable.AutoSize = true;
            this.lnkFixPhoneTable.Location = new System.Drawing.Point(356, 462);
            this.lnkFixPhoneTable.Name = "lnkFixPhoneTable";
            this.lnkFixPhoneTable.Size = new System.Drawing.Size(84, 13);
            this.lnkFixPhoneTable.TabIndex = 165;
            this.lnkFixPhoneTable.TabStop = true;
            this.lnkFixPhoneTable.Text = "Fix Phone Table";
            // 
            // gbHubspot
            // 
            this.gbHubspot.Controls.Add(this.llUpdateHsDeals);
            this.gbHubspot.Controls.Add(this.lnklblCreateTestHubspotDeal);
            this.gbHubspot.Location = new System.Drawing.Point(711, 245);
            this.gbHubspot.Name = "gbHubspot";
            this.gbHubspot.Size = new System.Drawing.Size(176, 129);
            this.gbHubspot.TabIndex = 168;
            this.gbHubspot.TabStop = false;
            this.gbHubspot.Text = "Hubspot";
            // 
            // llUpdateHsDeals
            // 
            this.llUpdateHsDeals.AutoSize = true;
            this.llUpdateHsDeals.Location = new System.Drawing.Point(6, 66);
            this.llUpdateHsDeals.Name = "llUpdateHsDeals";
            this.llUpdateHsDeals.Size = new System.Drawing.Size(137, 13);
            this.llUpdateHsDeals.TabIndex = 161;
            this.llUpdateHsDeals.TabStop = true;
            this.llUpdateHsDeals.Text = "Create Missing Batch Deals";
            this.llUpdateHsDeals.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llUpdateHsDeals_LinkClicked);
            // 
            // lnklblCreateTestHubspotDeal
            // 
            this.lnklblCreateTestHubspotDeal.AutoSize = true;
            this.lnklblCreateTestHubspotDeal.Location = new System.Drawing.Point(6, 31);
            this.lnklblCreateTestHubspotDeal.Name = "lnklblCreateTestHubspotDeal";
            this.lnklblCreateTestHubspotDeal.Size = new System.Drawing.Size(130, 13);
            this.lnklblCreateTestHubspotDeal.TabIndex = 160;
            this.lnklblCreateTestHubspotDeal.TabStop = true;
            this.lnklblCreateTestHubspotDeal.Text = "Create Test Hubspot Deal";
            this.lnklblCreateTestHubspotDeal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblCreateTestHubspotDeal_LinkClicked);
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(233, 54);
            this.wb.Margin = new System.Windows.Forms.Padding(4);
            this.wb.Name = "wb";
            this.wb.ShowBackButton = false;
            this.wb.ShowControls = false;
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(240, 359);
            this.wb.TabIndex = 128;
            // 
            // gbQuickbooks
            // 
            this.gbQuickbooks.Controls.Add(this.llShowQuickBench);
            this.gbQuickbooks.Controls.Add(this.lnkCreateQbSaleFromRzLine);
            this.gbQuickbooks.Location = new System.Drawing.Point(711, 390);
            this.gbQuickbooks.Name = "gbQuickbooks";
            this.gbQuickbooks.Size = new System.Drawing.Size(176, 85);
            this.gbQuickbooks.TabIndex = 172;
            this.gbQuickbooks.TabStop = false;
            this.gbQuickbooks.Text = "Quickbooks";
            // 
            // llShowQuickBench
            // 
            this.llShowQuickBench.AutoSize = true;
            this.llShowQuickBench.Location = new System.Drawing.Point(6, 53);
            this.llShowQuickBench.Name = "llShowQuickBench";
            this.llShowQuickBench.Size = new System.Drawing.Size(66, 13);
            this.llShowQuickBench.TabIndex = 161;
            this.llShowQuickBench.TabStop = true;
            this.llShowQuickBench.Text = "QuickBench";
            this.llShowQuickBench.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowQuickBench_LinkClicked);
            // 
            // lnkCreateQbSaleFromRzLine
            // 
            this.lnkCreateQbSaleFromRzLine.AutoSize = true;
            this.lnkCreateQbSaleFromRzLine.Location = new System.Drawing.Point(6, 31);
            this.lnkCreateQbSaleFromRzLine.Name = "lnkCreateQbSaleFromRzLine";
            this.lnkCreateQbSaleFromRzLine.Size = new System.Drawing.Size(153, 13);
            this.lnkCreateQbSaleFromRzLine.TabIndex = 160;
            this.lnkCreateQbSaleFromRzLine.TabStop = true;
            this.lnkCreateQbSaleFromRzLine.Text = "Create Sale in QB from Rz Line";
            this.lnkCreateQbSaleFromRzLine.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCreateQbSaleFromRzLine_LinkClicked);
            // 
            // llFixOtherMfg
            // 
            this.llFixOtherMfg.AutoSize = true;
            this.llFixOtherMfg.Location = new System.Drawing.Point(6, 23);
            this.llFixOtherMfg.Name = "llFixOtherMfg";
            this.llFixOtherMfg.Size = new System.Drawing.Size(121, 13);
            this.llFixOtherMfg.TabIndex = 174;
            this.llFixOtherMfg.TabStop = true;
            this.llFixOtherMfg.Text = "Fix Missing Quote MFGs\r\n";
            this.llFixOtherMfg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llFixOtherMfg_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.llFixOtherMfg);
            this.groupBox1.Location = new System.Drawing.Point(526, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 175;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "gbSiliconExpert";
            // 
            // gbSensible
            // 
            this.gbSensible.Controls.Add(this.llTestEmail);
            this.gbSensible.Controls.Add(this.llCreateListAcquisitionSplitObjects);
            this.gbSensible.Controls.Add(this.llCreateSplitCommissionObjects);
            this.gbSensible.Controls.Add(this.llTestSerilogLogging);
            this.gbSensible.Controls.Add(this.llManuallyShipStock);
            this.gbSensible.Controls.Add(this.lblCloseSalesOrders);
            this.gbSensible.Controls.Add(this.linkUpdateQuoteOppStages);
            this.gbSensible.Controls.Add(this.lnkUpdateInvoiceBalances);
            this.gbSensible.Controls.Add(this.llChooseManufactuer);
            this.gbSensible.Controls.Add(this.llOpenRecentTabs);
            this.gbSensible.Controls.Add(this.lnkSetRecentTabs);
            this.gbSensible.Location = new System.Drawing.Point(506, 245);
            this.gbSensible.Name = "gbSensible";
            this.gbSensible.Size = new System.Drawing.Size(199, 316);
            this.gbSensible.TabIndex = 177;
            this.gbSensible.TabStop = false;
            this.gbSensible.Text = "Sensible Stuff";
            // 
            // llCreateListAcquisitionSplitObjects
            // 
            this.llCreateListAcquisitionSplitObjects.AutoSize = true;
            this.llCreateListAcquisitionSplitObjects.BackColor = System.Drawing.SystemColors.Control;
            this.llCreateListAcquisitionSplitObjects.Location = new System.Drawing.Point(6, 198);
            this.llCreateListAcquisitionSplitObjects.Name = "llCreateListAcquisitionSplitObjects";
            this.llCreateListAcquisitionSplitObjects.Size = new System.Drawing.Size(171, 13);
            this.llCreateListAcquisitionSplitObjects.TabIndex = 186;
            this.llCreateListAcquisitionSplitObjects.TabStop = true;
            this.llCreateListAcquisitionSplitObjects.Text = "Create List Acqisistion split objects.";
            this.llCreateListAcquisitionSplitObjects.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCreateListAcquisitionSplitObjects_LinkClicked);
            // 
            // llCreateSplitCommissionObjects
            // 
            this.llCreateSplitCommissionObjects.AutoSize = true;
            this.llCreateSplitCommissionObjects.BackColor = System.Drawing.SystemColors.Control;
            this.llCreateSplitCommissionObjects.Location = new System.Drawing.Point(6, 181);
            this.llCreateSplitCommissionObjects.Name = "llCreateSplitCommissionObjects";
            this.llCreateSplitCommissionObjects.Size = new System.Drawing.Size(158, 13);
            this.llCreateSplitCommissionObjects.TabIndex = 185;
            this.llCreateSplitCommissionObjects.TabStop = true;
            this.llCreateSplitCommissionObjects.Text = "Create Split Commission Objects";
            this.llCreateSplitCommissionObjects.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCreateSplitCommissionObjects_LinkClicked);
            // 
            // llTestSerilogLogging
            // 
            this.llTestSerilogLogging.AutoSize = true;
            this.llTestSerilogLogging.BackColor = System.Drawing.SystemColors.Control;
            this.llTestSerilogLogging.Location = new System.Drawing.Point(6, 164);
            this.llTestSerilogLogging.Name = "llTestSerilogLogging";
            this.llTestSerilogLogging.Size = new System.Drawing.Size(63, 13);
            this.llTestSerilogLogging.TabIndex = 184;
            this.llTestSerilogLogging.TabStop = true;
            this.llTestSerilogLogging.Text = "Test Serilog";
            this.llTestSerilogLogging.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llTestSerilogLogging_LinkClicked);
            // 
            // llManuallyShipStock
            // 
            this.llManuallyShipStock.AutoSize = true;
            this.llManuallyShipStock.Location = new System.Drawing.Point(6, 145);
            this.llManuallyShipStock.Name = "llManuallyShipStock";
            this.llManuallyShipStock.Size = new System.Drawing.Size(104, 13);
            this.llManuallyShipStock.TabIndex = 183;
            this.llManuallyShipStock.TabStop = true;
            this.llManuallyShipStock.Text = "Manually Ship Stock";
            // 
            // lblCloseSalesOrders
            // 
            this.lblCloseSalesOrders.AutoSize = true;
            this.lblCloseSalesOrders.Location = new System.Drawing.Point(6, 123);
            this.lblCloseSalesOrders.Name = "lblCloseSalesOrders";
            this.lblCloseSalesOrders.Size = new System.Drawing.Size(96, 13);
            this.lblCloseSalesOrders.TabIndex = 182;
            this.lblCloseSalesOrders.TabStop = true;
            this.lblCloseSalesOrders.Text = "Close Sales Orders";
            // 
            // linkUpdateQuoteOppStages
            // 
            this.linkUpdateQuoteOppStages.AutoSize = true;
            this.linkUpdateQuoteOppStages.Location = new System.Drawing.Point(6, 103);
            this.linkUpdateQuoteOppStages.Name = "linkUpdateQuoteOppStages";
            this.linkUpdateQuoteOppStages.Size = new System.Drawing.Size(135, 13);
            this.linkUpdateQuoteOppStages.TabIndex = 181;
            this.linkUpdateQuoteOppStages.TabStop = true;
            this.linkUpdateQuoteOppStages.Text = "Update Opportunity Stages";
            // 
            // lnkUpdateInvoiceBalances
            // 
            this.lnkUpdateInvoiceBalances.AutoSize = true;
            this.lnkUpdateInvoiceBalances.Location = new System.Drawing.Point(6, 78);
            this.lnkUpdateInvoiceBalances.Name = "lnkUpdateInvoiceBalances";
            this.lnkUpdateInvoiceBalances.Size = new System.Drawing.Size(141, 13);
            this.lnkUpdateInvoiceBalances.TabIndex = 180;
            this.lnkUpdateInvoiceBalances.TabStop = true;
            this.lnkUpdateInvoiceBalances.Text = "Update All Invoice Balances";
            // 
            // llChooseManufactuer
            // 
            this.llChooseManufactuer.AutoSize = true;
            this.llChooseManufactuer.Location = new System.Drawing.Point(6, 62);
            this.llChooseManufactuer.Name = "llChooseManufactuer";
            this.llChooseManufactuer.Size = new System.Drawing.Size(109, 13);
            this.llChooseManufactuer.TabIndex = 179;
            this.llChooseManufactuer.TabStop = true;
            this.llChooseManufactuer.Text = "Choose Manufacturer";
            // 
            // llOpenRecentTabs
            // 
            this.llOpenRecentTabs.AutoSize = true;
            this.llOpenRecentTabs.Location = new System.Drawing.Point(6, 42);
            this.llOpenRecentTabs.Name = "llOpenRecentTabs";
            this.llOpenRecentTabs.Size = new System.Drawing.Size(98, 13);
            this.llOpenRecentTabs.TabIndex = 178;
            this.llOpenRecentTabs.TabStop = true;
            this.llOpenRecentTabs.Text = "Open Recent Tabs";
            // 
            // lnkSetRecentTabs
            // 
            this.lnkSetRecentTabs.AutoSize = true;
            this.lnkSetRecentTabs.Location = new System.Drawing.Point(6, 21);
            this.lnkSetRecentTabs.Name = "lnkSetRecentTabs";
            this.lnkSetRecentTabs.Size = new System.Drawing.Size(88, 13);
            this.lnkSetRecentTabs.TabIndex = 177;
            this.lnkSetRecentTabs.TabStop = true;
            this.lnkSetRecentTabs.Text = "Set Recent Tabs";
            // 
            // llTestEmail
            // 
            this.llTestEmail.AutoSize = true;
            this.llTestEmail.Location = new System.Drawing.Point(6, 217);
            this.llTestEmail.Name = "llTestEmail";
            this.llTestEmail.Size = new System.Drawing.Size(118, 13);
            this.llTestEmail.TabIndex = 187;
            this.llTestEmail.TabStop = true;
            this.llTestEmail.Text = "Test Email Functionality";
            this.llTestEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llTestEmail_LinkClicked);
            // 
            // SandBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbSensible);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbQuickbooks);
            this.Controls.Add(this.gbHubspot);
            this.Controls.Add(this.lnkShowSalesProps);
            this.Controls.Add(this.lnkFixPhoneTable);
            this.Controls.Add(this.lnkImportGLPro);
            this.Controls.Add(this.lnkEmailNotification);
            this.Controls.Add(this.lnkAddRz3_Ext);
            this.Controls.Add(this.lnkTransferCount);
            this.Controls.Add(this.lnkStartingAccounts);
            this.Controls.Add(this.lnkCloseBooks);
            this.Controls.Add(this.lnkImportQBsAccounts);
            this.Controls.Add(this.productionAccounts);
            this.Controls.Add(this.removeNonRzAccounts);
            this.Controls.Add(this.clearAccountBalances);
            this.Controls.Add(this.lnkAddExampleAccounts);
            this.Controls.Add(this.lnkAccountingTest);
            this.Controls.Add(this.lnkCreateOrderViews);
            this.Controls.Add(this.lnkUpdateAlfaCompNumbs);
            this.Controls.Add(this.lnkUpdateAlfaCompTypes);
            this.Controls.Add(this.lnkCheckClosed);
            this.Controls.Add(this.lnkPicDetails);
            this.Controls.Add(this.lblUpdateData);
            this.Controls.Add(this.lblFieldMain);
            this.Controls.Add(this.lnkTest);
            this.Controls.Add(this.lnkCommonSettings);
            this.Controls.Add(this.lnkEmailGMail);
            this.Controls.Add(this.lblFirstNames);
            this.Controls.Add(this.lblRyan2Import);
            this.Controls.Add(this.lblRyan1Import);
            this.Controls.Add(this.lblTestPDF);
            this.Controls.Add(this.lbl7525);
            this.Controls.Add(this.lblNafta);
            this.Controls.Add(this.lblBFImport);
            this.Controls.Add(this.lblTwit);
            this.Controls.Add(this.lnkOldCommReport);
            this.Controls.Add(this.lblRzLink);
            this.Controls.Add(this.lblImportQBs);
            this.Controls.Add(this.lnkProcessCSV);
            this.Controls.Add(this.lnkSetSetting);
            this.Controls.Add(this.wb);
            this.Controls.Add(this.lblWBPDFTest);
            this.Controls.Add(this.lblZebraTest);
            this.Controls.Add(this.lblImportCharges);
            this.Controls.Add(this.lnkReSaveStock);
            this.Controls.Add(this.lblSaveClassInstances);
            this.Controls.Add(this.lblShrink);
            this.Controls.Add(this.lblArRestore);
            this.Controls.Add(this.lblIdRemove);
            this.Controls.Add(this.lblRemoveArch);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblOrdersImport);
            this.Controls.Add(this.lblNotesImport);
            this.Name = "SandBox";
            this.Size = new System.Drawing.Size(899, 669);
            this.Tag = "";
            this.gbHubspot.ResumeLayout(false);
            this.gbHubspot.PerformLayout();
            this.gbQuickbooks.ResumeLayout(false);
            this.gbQuickbooks.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbSensible.ResumeLayout(false);
            this.gbSensible.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bg;
        private System.Windows.Forms.OpenFileDialog oFile;
        private System.ComponentModel.BackgroundWorker bgImport;
        private System.ComponentModel.BackgroundWorker bgAtom;
        private System.ComponentModel.BackgroundWorker bgImportPhoenix;
        private System.ComponentModel.BackgroundWorker bgAtomExport;
        private System.Windows.Forms.LinkLabel lblNotesImport;
        private System.Windows.Forms.LinkLabel lblOrdersImport;
        private System.Windows.Forms.LinkLabel lblVersion;
        private System.Windows.Forms.LinkLabel lblRemoveArch;
        private System.Windows.Forms.LinkLabel lblIdRemove;
        private System.Windows.Forms.ImageList IMLrg;
        private System.Windows.Forms.ImageList IM;
        private System.Windows.Forms.LinkLabel lblArRestore;
        private System.Windows.Forms.LinkLabel lblShrink;
        private System.Windows.Forms.LinkLabel lblSaveClassInstances;
        private System.Windows.Forms.LinkLabel lnkReSaveStock;
        private System.Windows.Forms.LinkLabel lblImportCharges;
        private System.Windows.Forms.LinkLabel lblZebraTest;
        private System.Windows.Forms.LinkLabel lblWBPDFTest;
        private System.Windows.Forms.LinkLabel lnkSetSetting;
        private System.Windows.Forms.LinkLabel lnkProcessCSV;
        private System.Windows.Forms.LinkLabel lblImportQBs;
        private System.Windows.Forms.LinkLabel lblRzLink;
        private System.Windows.Forms.LinkLabel lnkOldCommReport;
        private System.Windows.Forms.LinkLabel lblTwit;
        private System.Windows.Forms.LinkLabel lblBFImport;
        private System.Windows.Forms.LinkLabel lblNafta;
        private System.Windows.Forms.LinkLabel lbl7525;
        private System.Windows.Forms.LinkLabel lblTestPDF;
        private System.Windows.Forms.LinkLabel lblRyan1Import;
        private System.Windows.Forms.LinkLabel lblRyan2Import;
        private System.ComponentModel.BackgroundWorker bgRyan1;
        private System.ComponentModel.BackgroundWorker bgRyan2;
        private System.Windows.Forms.LinkLabel lblFirstNames;
        private System.Windows.Forms.LinkLabel lnkEmailGMail;
        private System.Windows.Forms.LinkLabel lnkCommonSettings;
        private System.Windows.Forms.LinkLabel lnkTest;
        private System.Windows.Forms.LinkLabel lblFieldMain;
        private System.Windows.Forms.LinkLabel lblUpdateData;
        private System.ComponentModel.BackgroundWorker bgwSaveInstance;
        private System.ComponentModel.BackgroundWorker bgPics;
        private System.Windows.Forms.LinkLabel lnkPicDetails;
        private System.Windows.Forms.LinkLabel lnkCheckClosed;
        private System.ComponentModel.BackgroundWorker bgwClosedOrdersAlfa;
        private System.Windows.Forms.LinkLabel lnkUpdateAlfaCompTypes;
        private System.Windows.Forms.LinkLabel lnkUpdateAlfaCompNumbs;
        private System.Windows.Forms.LinkLabel lnkCreateOrderViews;
        public ToolsWin.Browser wb;
        private System.Windows.Forms.LinkLabel lnkAccountingTest;
        private System.Windows.Forms.LinkLabel lnkAddExampleAccounts;
        private System.Windows.Forms.LinkLabel clearAccountBalances;
        private System.Windows.Forms.LinkLabel removeNonRzAccounts;
        private System.Windows.Forms.LinkLabel productionAccounts;
        private System.Windows.Forms.LinkLabel lnkImportQBsAccounts;
        private System.Windows.Forms.LinkLabel lnkCloseBooks;
        private System.ComponentModel.BackgroundWorker bgwQBsAccounts;
        private System.Windows.Forms.LinkLabel lnkStartingAccounts;
        private System.Windows.Forms.LinkLabel lnkTransferCount;
        private System.Windows.Forms.LinkLabel lnkAddRz3_Ext;
        private System.Windows.Forms.LinkLabel lnkEmailNotification;
        private System.Windows.Forms.LinkLabel lnkImportGLPro;
        private System.Windows.Forms.LinkLabel lnkShowSalesProps;
        private System.Windows.Forms.LinkLabel lnkFixPhoneTable;
        private System.Windows.Forms.GroupBox gbHubspot;
        private System.Windows.Forms.LinkLabel lnklblCreateTestHubspotDeal;
        private System.Windows.Forms.GroupBox gbQuickbooks;
        private System.Windows.Forms.LinkLabel lnkCreateQbSaleFromRzLine;
        private System.Windows.Forms.LinkLabel llShowQuickBench;
        private System.Windows.Forms.LinkLabel llUpdateHsDeals;
        private System.Windows.Forms.LinkLabel llFixOtherMfg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbSensible;
        private System.Windows.Forms.LinkLabel llTestSerilogLogging;
        private System.Windows.Forms.LinkLabel llManuallyShipStock;
        private System.Windows.Forms.LinkLabel lblCloseSalesOrders;
        private System.Windows.Forms.LinkLabel linkUpdateQuoteOppStages;
        private System.Windows.Forms.LinkLabel lnkUpdateInvoiceBalances;
        private System.Windows.Forms.LinkLabel llChooseManufactuer;
        private System.Windows.Forms.LinkLabel llOpenRecentTabs;
        private System.Windows.Forms.LinkLabel lnkSetRecentTabs;
        private System.Windows.Forms.LinkLabel llCreateSplitCommissionObjects;
        private System.Windows.Forms.LinkLabel llCreateListAcquisitionSplitObjects;
        private System.Windows.Forms.LinkLabel llTestEmail;
    }
}
