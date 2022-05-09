using Tools.Database;
using Rz5;
namespace Rz5
{
    partial class view_qualitycontrol
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
                CompleteDispose();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctl_internalcomment = new NewMethod.nEdit_Memo();
            this.lblAddLog = new System.Windows.Forms.LinkLabel();
            this.lblViewNotes = new System.Windows.Forms.LinkLabel();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.ctl_has_problem = new NewMethod.nEdit_Boolean();
            this.cmdAlert = new System.Windows.Forms.Button();
            this.ctl_problem_notes = new NewMethod.nEdit_String();
            this.gbROHS = new System.Windows.Forms.GroupBox();
            this.gbLeadFreePassFail = new System.Windows.Forms.GroupBox();
            this.optLeadFreeNA = new System.Windows.Forms.RadioButton();
            this.optLeadFreePass = new System.Windows.Forms.RadioButton();
            this.optLeadFreeFailed = new System.Windows.Forms.RadioButton();
            this.insLeadFree = new Rz5.InspectionLine();
            this.gbTestInfo = new System.Windows.Forms.GroupBox();
            this.ctl_test_company = new NewMethod.nEdit_String();
            this.ctl_test_performed = new NewMethod.nEdit_List();
            this.ctl_has_test_docs = new NewMethod.nEdit_Boolean();
            this.ctl_qty_tested = new NewMethod.nEdit_Number();
            this.ctl_qty_passed = new NewMethod.nEdit_Number();
            this.ctl_qty_failed = new NewMethod.nEdit_Number();
            this.ctl_processor_name = new NewMethod.nEdit_String();
            this.fp = new System.Windows.Forms.FlowLayoutPanel();
            this.insGoodPackage = new Rz5.InspectionLine();
            this.insOrigin = new Rz5.InspectionLine();
            this.insReportPackageDamage = new Rz5.InspectionLine();
            this.insVendorInfo = new Rz5.InspectionLine();
            this.insPart = new Rz5.InspectionLine();
            this.insQuantity = new Rz5.InspectionLine();
            this.insManufacturer = new Rz5.InspectionLine();
            this.insDateCode = new Rz5.InspectionLine();
            this.insPackaging = new Rz5.InspectionLine();
            this.insESD = new Rz5.InspectionLine();
            this.insRefurb = new Rz5.InspectionLine();
            this.insAuthentic = new Rz5.InspectionLine();
            this.insHumidity = new Rz5.InspectionLine();
            this.insScan = new Rz5.InspectionLine();
            this.insPrePhotoWeight = new Rz5.InspectionLine();
            this.insPhotosInBox = new Rz5.InspectionLine();
            this.insPhotosIncludeLeads = new Rz5.InspectionLine();
            this.insLeavingPhotos = new Rz5.InspectionLine();
            this.ins_datasheet_analysis = new Rz5.InspectionLine();
            this.ins_ocm_verification = new Rz5.InspectionLine();
            this.ins_gold_standard = new Rz5.InspectionLine();
            this.ins_calibrations_measured = new Rz5.InspectionLine();
            this.insCertsMatch = new Rz5.InspectionLine();
            this.insCerts = new Rz5.InspectionLine();
            this.cmdTesting = new System.Windows.Forms.Button();
            this.gbStatus.SuspendLayout();
            this.gbROHS.SuspendLayout();
            this.gbLeadFreePassFail.SuspendLayout();
            this.gbTestInfo.SuspendLayout();
            this.fp.SuspendLayout();
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(738, 0);
            this.xActions.Size = new System.Drawing.Size(144, 497);
            // 
            // ctl_internalcomment
            // 
            this.ctl_internalcomment.BackColor = System.Drawing.Color.White;
            this.ctl_internalcomment.Bold = false;
            this.ctl_internalcomment.Caption = "Notes";
            this.ctl_internalcomment.Changed = false;
            this.ctl_internalcomment.DateLines = false;
            this.ctl_internalcomment.Enabled = false;
            this.ctl_internalcomment.Location = new System.Drawing.Point(518, 353);
            this.ctl_internalcomment.Name = "ctl_internalcomment";
            this.ctl_internalcomment.Size = new System.Drawing.Size(215, 79);
            this.ctl_internalcomment.TabIndex = 4;
            this.ctl_internalcomment.UseParentBackColor = true;
            this.ctl_internalcomment.zz_Enabled = true;
            this.ctl_internalcomment.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_internalcomment.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_internalcomment.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_internalcomment.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internalcomment.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_internalcomment.zz_OriginalDesign = true;
            this.ctl_internalcomment.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ctl_internalcomment.zz_ShowNeedsSaveColor = true;
            this.ctl_internalcomment.zz_Text = "";
            this.ctl_internalcomment.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_internalcomment.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internalcomment.zz_UseGlobalColor = false;
            this.ctl_internalcomment.zz_UseGlobalFont = false;
            // 
            // lblAddLog
            // 
            this.lblAddLog.AutoSize = true;
            this.lblAddLog.Location = new System.Drawing.Point(707, 355);
            this.lblAddLog.Name = "lblAddLog";
            this.lblAddLog.Size = new System.Drawing.Size(25, 13);
            this.lblAddLog.TabIndex = 5;
            this.lblAddLog.TabStop = true;
            this.lblAddLog.Text = "add";
            this.lblAddLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddLog_LinkClicked);
            // 
            // lblViewNotes
            // 
            this.lblViewNotes.AutoSize = true;
            this.lblViewNotes.Location = new System.Drawing.Point(659, 355);
            this.lblViewNotes.Name = "lblViewNotes";
            this.lblViewNotes.Size = new System.Drawing.Size(42, 13);
            this.lblViewNotes.TabIndex = 6;
            this.lblViewNotes.TabStop = true;
            this.lblViewNotes.Text = "view all";
            this.lblViewNotes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblViewNotes_LinkClicked);
            // 
            // gbStatus
            // 
            this.gbStatus.BackColor = System.Drawing.Color.White;
            this.gbStatus.Controls.Add(this.ctl_has_problem);
            this.gbStatus.Controls.Add(this.cmdAlert);
            this.gbStatus.Controls.Add(this.ctl_problem_notes);
            this.gbStatus.Location = new System.Drawing.Point(518, -1);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(215, 87);
            this.gbStatus.TabIndex = 7;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Status";
            // 
            // ctl_has_problem
            // 
            this.ctl_has_problem.BackColor = System.Drawing.Color.White;
            this.ctl_has_problem.Bold = false;
            this.ctl_has_problem.Caption = "Problem";
            this.ctl_has_problem.Changed = false;
            this.ctl_has_problem.Location = new System.Drawing.Point(144, 11);
            this.ctl_has_problem.Name = "ctl_has_problem";
            this.ctl_has_problem.Size = new System.Drawing.Size(64, 18);
            this.ctl_has_problem.TabIndex = 0;
            this.ctl_has_problem.UseParentBackColor = true;
            this.ctl_has_problem.zz_CheckValue = false;
            this.ctl_has_problem.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_has_problem.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_has_problem.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_has_problem.zz_OriginalDesign = false;
            this.ctl_has_problem.zz_ShowNeedsSaveColor = true;
            this.ctl_has_problem.DataChanged += new NewMethod.ChangeHandler(this.ctl_has_problem_DataChanged);
            // 
            // cmdAlert
            // 
            this.cmdAlert.Location = new System.Drawing.Point(6, 52);
            this.cmdAlert.Name = "cmdAlert";
            this.cmdAlert.Size = new System.Drawing.Size(203, 29);
            this.cmdAlert.TabIndex = 2;
            this.cmdAlert.Text = "Alert";
            this.cmdAlert.UseVisualStyleBackColor = true;
            this.cmdAlert.Click += new System.EventHandler(this.cmdAlert_Click);
            // 
            // ctl_problem_notes
            // 
            this.ctl_problem_notes.AllCaps = false;
            this.ctl_problem_notes.BackColor = System.Drawing.Color.White;
            this.ctl_problem_notes.Bold = false;
            this.ctl_problem_notes.Caption = "Problem Notes";
            this.ctl_problem_notes.Changed = false;
            this.ctl_problem_notes.IsEmail = false;
            this.ctl_problem_notes.IsURL = false;
            this.ctl_problem_notes.Location = new System.Drawing.Point(6, 15);
            this.ctl_problem_notes.Name = "ctl_problem_notes";
            this.ctl_problem_notes.PasswordChar = '\0';
            this.ctl_problem_notes.Size = new System.Drawing.Size(203, 35);
            this.ctl_problem_notes.TabIndex = 1;
            this.ctl_problem_notes.UseParentBackColor = true;
            this.ctl_problem_notes.zz_Enabled = true;
            this.ctl_problem_notes.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_problem_notes.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_problem_notes.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_problem_notes.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_problem_notes.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_problem_notes.zz_OriginalDesign = false;
            this.ctl_problem_notes.zz_ShowLinkButton = false;
            this.ctl_problem_notes.zz_ShowNeedsSaveColor = true;
            this.ctl_problem_notes.zz_Text = "";
            this.ctl_problem_notes.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_problem_notes.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_problem_notes.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_problem_notes.zz_UseGlobalColor = false;
            this.ctl_problem_notes.zz_UseGlobalFont = false;
            // 
            // gbROHS
            // 
            this.gbROHS.Controls.Add(this.gbLeadFreePassFail);
            this.gbROHS.Controls.Add(this.insLeadFree);
            this.gbROHS.ForeColor = System.Drawing.Color.Blue;
            this.gbROHS.Location = new System.Drawing.Point(518, 110);
            this.gbROHS.Name = "gbROHS";
            this.gbROHS.Size = new System.Drawing.Size(215, 96);
            this.gbROHS.TabIndex = 22;
            this.gbROHS.TabStop = false;
            this.gbROHS.Text = "RoHs/Lead Free";
            // 
            // gbLeadFreePassFail
            // 
            this.gbLeadFreePassFail.Controls.Add(this.optLeadFreeNA);
            this.gbLeadFreePassFail.Controls.Add(this.optLeadFreePass);
            this.gbLeadFreePassFail.Controls.Add(this.optLeadFreeFailed);
            this.gbLeadFreePassFail.Location = new System.Drawing.Point(5, 60);
            this.gbLeadFreePassFail.Name = "gbLeadFreePassFail";
            this.gbLeadFreePassFail.Size = new System.Drawing.Size(205, 34);
            this.gbLeadFreePassFail.TabIndex = 13;
            this.gbLeadFreePassFail.TabStop = false;
            this.gbLeadFreePassFail.Text = "Lead Free Test";
            // 
            // optLeadFreeNA
            // 
            this.optLeadFreeNA.AutoSize = true;
            this.optLeadFreeNA.Location = new System.Drawing.Point(141, 15);
            this.optLeadFreeNA.Name = "optLeadFreeNA";
            this.optLeadFreeNA.Size = new System.Drawing.Size(45, 17);
            this.optLeadFreeNA.TabIndex = 13;
            this.optLeadFreeNA.TabStop = true;
            this.optLeadFreeNA.Text = "N/A";
            this.optLeadFreeNA.UseVisualStyleBackColor = true;
            // 
            // optLeadFreePass
            // 
            this.optLeadFreePass.AutoSize = true;
            this.optLeadFreePass.Location = new System.Drawing.Point(13, 15);
            this.optLeadFreePass.Name = "optLeadFreePass";
            this.optLeadFreePass.Size = new System.Drawing.Size(60, 17);
            this.optLeadFreePass.TabIndex = 11;
            this.optLeadFreePass.TabStop = true;
            this.optLeadFreePass.Text = "Passed";
            this.optLeadFreePass.UseVisualStyleBackColor = true;
            // 
            // optLeadFreeFailed
            // 
            this.optLeadFreeFailed.AutoSize = true;
            this.optLeadFreeFailed.Location = new System.Drawing.Point(79, 15);
            this.optLeadFreeFailed.Name = "optLeadFreeFailed";
            this.optLeadFreeFailed.Size = new System.Drawing.Size(53, 17);
            this.optLeadFreeFailed.TabIndex = 12;
            this.optLeadFreeFailed.TabStop = true;
            this.optLeadFreeFailed.Text = "Failed";
            this.optLeadFreeFailed.UseVisualStyleBackColor = true;
            // 
            // insLeadFree
            // 
            this.insLeadFree.Caption = "Are these parts lead free?";
            this.insLeadFree.FieldNAText = "NA";
            this.insLeadFree.FieldNotes = "";
            this.insLeadFree.FieldNoText = "N";
            this.insLeadFree.FieldYesNo = "lead_free";
            this.insLeadFree.FieldYesText = "Y";
            this.insLeadFree.IsNA = false;
            this.insLeadFree.IsNo = false;
            this.insLeadFree.IsYes = true;
            this.insLeadFree.Location = new System.Drawing.Point(5, 14);
            this.insLeadFree.Name = "insLeadFree";
            this.insLeadFree.Notes = "";
            this.insLeadFree.ShowNA = true;
            this.insLeadFree.ShowNotes = false;
            this.insLeadFree.Size = new System.Drawing.Size(205, 44);
            this.insLeadFree.TabIndex = 10;
            // 
            // gbTestInfo
            // 
            this.gbTestInfo.BackColor = System.Drawing.Color.White;
            this.gbTestInfo.Controls.Add(this.ctl_test_company);
            this.gbTestInfo.Controls.Add(this.ctl_test_performed);
            this.gbTestInfo.Controls.Add(this.ctl_has_test_docs);
            this.gbTestInfo.Controls.Add(this.ctl_qty_tested);
            this.gbTestInfo.Controls.Add(this.ctl_qty_passed);
            this.gbTestInfo.Controls.Add(this.ctl_qty_failed);
            this.gbTestInfo.Location = new System.Drawing.Point(518, 209);
            this.gbTestInfo.Name = "gbTestInfo";
            this.gbTestInfo.Size = new System.Drawing.Size(215, 142);
            this.gbTestInfo.TabIndex = 23;
            this.gbTestInfo.TabStop = false;
            this.gbTestInfo.Text = "Part Testing Information";
            // 
            // ctl_test_company
            // 
            this.ctl_test_company.AllCaps = false;
            this.ctl_test_company.BackColor = System.Drawing.Color.White;
            this.ctl_test_company.Bold = false;
            this.ctl_test_company.Caption = "Test Company  ";
            this.ctl_test_company.Changed = false;
            this.ctl_test_company.IsEmail = false;
            this.ctl_test_company.IsURL = false;
            this.ctl_test_company.Location = new System.Drawing.Point(5, 53);
            this.ctl_test_company.Name = "ctl_test_company";
            this.ctl_test_company.PasswordChar = '\0';
            this.ctl_test_company.Size = new System.Drawing.Size(203, 21);
            this.ctl_test_company.TabIndex = 6;
            this.ctl_test_company.UseParentBackColor = true;
            this.ctl_test_company.zz_Enabled = true;
            this.ctl_test_company.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_test_company.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_test_company.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_test_company.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_test_company.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctl_test_company.zz_OriginalDesign = false;
            this.ctl_test_company.zz_ShowLinkButton = false;
            this.ctl_test_company.zz_ShowNeedsSaveColor = true;
            this.ctl_test_company.zz_Text = "";
            this.ctl_test_company.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_test_company.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_test_company.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_test_company.zz_UseGlobalColor = false;
            this.ctl_test_company.zz_UseGlobalFont = false;
            // 
            // ctl_test_performed
            // 
            this.ctl_test_performed.AllCaps = false;
            this.ctl_test_performed.AllowEdit = true;
            this.ctl_test_performed.BackColor = System.Drawing.Color.Transparent;
            this.ctl_test_performed.Bold = false;
            this.ctl_test_performed.Caption = "Test Performed";
            this.ctl_test_performed.Changed = false;
            this.ctl_test_performed.ListName = "part_tests";
            this.ctl_test_performed.Location = new System.Drawing.Point(5, 30);
            this.ctl_test_performed.Name = "ctl_test_performed";
            this.ctl_test_performed.SimpleList = null;
            this.ctl_test_performed.Size = new System.Drawing.Size(203, 22);
            this.ctl_test_performed.TabIndex = 5;
            this.ctl_test_performed.UseParentBackColor = false;
            this.ctl_test_performed.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_test_performed.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_test_performed.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_test_performed.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_test_performed.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.Left;
            this.ctl_test_performed.zz_OriginalDesign = false;
            this.ctl_test_performed.zz_ShowNeedsSaveColor = true;
            this.ctl_test_performed.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_test_performed.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_test_performed.zz_UseGlobalColor = false;
            this.ctl_test_performed.zz_UseGlobalFont = false;
            // 
            // ctl_has_test_docs
            // 
            this.ctl_has_test_docs.BackColor = System.Drawing.Color.Transparent;
            this.ctl_has_test_docs.Bold = false;
            this.ctl_has_test_docs.Caption = "Has Test Docs";
            this.ctl_has_test_docs.Changed = false;
            this.ctl_has_test_docs.Location = new System.Drawing.Point(7, 13);
            this.ctl_has_test_docs.Name = "ctl_has_test_docs";
            this.ctl_has_test_docs.Size = new System.Drawing.Size(97, 18);
            this.ctl_has_test_docs.TabIndex = 4;
            this.ctl_has_test_docs.UseParentBackColor = false;
            this.ctl_has_test_docs.zz_CheckValue = false;
            this.ctl_has_test_docs.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_has_test_docs.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_has_test_docs.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_has_test_docs.zz_OriginalDesign = false;
            this.ctl_has_test_docs.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_qty_tested
            // 
            this.ctl_qty_tested.BackColor = System.Drawing.Color.Transparent;
            this.ctl_qty_tested.Bold = false;
            this.ctl_qty_tested.Caption = "Qty Tested       ";
            this.ctl_qty_tested.Changed = false;
            this.ctl_qty_tested.CurrentType = FieldType.Unknown;
            this.ctl_qty_tested.Location = new System.Drawing.Point(6, 75);
            this.ctl_qty_tested.Name = "ctl_qty_tested";
            this.ctl_qty_tested.Size = new System.Drawing.Size(202, 21);
            this.ctl_qty_tested.TabIndex = 2;
            this.ctl_qty_tested.UseParentBackColor = false;
            this.ctl_qty_tested.zz_Enabled = true;
            this.ctl_qty_tested.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_qty_tested.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_qty_tested.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_qty_tested.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_qty_tested.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.Left;
            this.ctl_qty_tested.zz_OriginalDesign = false;
            this.ctl_qty_tested.zz_ShowErrorColor = true;
            this.ctl_qty_tested.zz_ShowNeedsSaveColor = true;
            this.ctl_qty_tested.zz_Text = "";
            this.ctl_qty_tested.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_qty_tested.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_qty_tested.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_qty_tested.zz_UseGlobalColor = false;
            this.ctl_qty_tested.zz_UseGlobalFont = false;
            // 
            // ctl_qty_passed
            // 
            this.ctl_qty_passed.BackColor = System.Drawing.Color.Transparent;
            this.ctl_qty_passed.Bold = false;
            this.ctl_qty_passed.Caption = "Qty Passed      ";
            this.ctl_qty_passed.Changed = false;
            this.ctl_qty_passed.CurrentType = FieldType.Unknown;
            this.ctl_qty_passed.Location = new System.Drawing.Point(7, 97);
            this.ctl_qty_passed.Name = "ctl_qty_passed";
            this.ctl_qty_passed.Size = new System.Drawing.Size(200, 21);
            this.ctl_qty_passed.TabIndex = 1;
            this.ctl_qty_passed.UseParentBackColor = false;
            this.ctl_qty_passed.zz_Enabled = true;
            this.ctl_qty_passed.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_qty_passed.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_qty_passed.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_qty_passed.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_qty_passed.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.Left;
            this.ctl_qty_passed.zz_OriginalDesign = false;
            this.ctl_qty_passed.zz_ShowErrorColor = true;
            this.ctl_qty_passed.zz_ShowNeedsSaveColor = true;
            this.ctl_qty_passed.zz_Text = "";
            this.ctl_qty_passed.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_qty_passed.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_qty_passed.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_qty_passed.zz_UseGlobalColor = false;
            this.ctl_qty_passed.zz_UseGlobalFont = false;
            // 
            // ctl_qty_failed
            // 
            this.ctl_qty_failed.BackColor = System.Drawing.Color.Transparent;
            this.ctl_qty_failed.Bold = false;
            this.ctl_qty_failed.Caption = "Qty Failed        ";
            this.ctl_qty_failed.Changed = false;
            this.ctl_qty_failed.CurrentType = FieldType.Unknown;
            this.ctl_qty_failed.Location = new System.Drawing.Point(7, 119);
            this.ctl_qty_failed.Name = "ctl_qty_failed";
            this.ctl_qty_failed.Size = new System.Drawing.Size(200, 21);
            this.ctl_qty_failed.TabIndex = 0;
            this.ctl_qty_failed.UseParentBackColor = false;
            this.ctl_qty_failed.zz_Enabled = true;
            this.ctl_qty_failed.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_qty_failed.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_qty_failed.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_qty_failed.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_qty_failed.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.Left;
            this.ctl_qty_failed.zz_OriginalDesign = false;
            this.ctl_qty_failed.zz_ShowErrorColor = true;
            this.ctl_qty_failed.zz_ShowNeedsSaveColor = true;
            this.ctl_qty_failed.zz_Text = "";
            this.ctl_qty_failed.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_qty_failed.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_qty_failed.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_qty_failed.zz_UseGlobalColor = false;
            this.ctl_qty_failed.zz_UseGlobalFont = false;
            // 
            // ctl_processor_name
            // 
            this.ctl_processor_name.AllCaps = false;
            this.ctl_processor_name.BackColor = System.Drawing.Color.White;
            this.ctl_processor_name.Bold = false;
            this.ctl_processor_name.Caption = "Processor Name";
            this.ctl_processor_name.Changed = false;
            this.ctl_processor_name.IsEmail = false;
            this.ctl_processor_name.IsURL = false;
            this.ctl_processor_name.Location = new System.Drawing.Point(520, 90);
            this.ctl_processor_name.Name = "ctl_processor_name";
            this.ctl_processor_name.PasswordChar = '\0';
            this.ctl_processor_name.Size = new System.Drawing.Size(213, 21);
            this.ctl_processor_name.TabIndex = 3;
            this.ctl_processor_name.UseParentBackColor = true;
            this.ctl_processor_name.zz_Enabled = true;
            this.ctl_processor_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_processor_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_processor_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_processor_name.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_processor_name.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctl_processor_name.zz_OriginalDesign = false;
            this.ctl_processor_name.zz_ShowLinkButton = false;
            this.ctl_processor_name.zz_ShowNeedsSaveColor = true;
            this.ctl_processor_name.zz_Text = "";
            this.ctl_processor_name.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_processor_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_processor_name.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_processor_name.zz_UseGlobalColor = false;
            this.ctl_processor_name.zz_UseGlobalFont = false;
            // 
            // fp
            // 
            this.fp.AutoScroll = true;
            this.fp.Controls.Add(this.insGoodPackage);
            this.fp.Controls.Add(this.insOrigin);
            this.fp.Controls.Add(this.insReportPackageDamage);
            this.fp.Controls.Add(this.insVendorInfo);
            this.fp.Controls.Add(this.insPart);
            this.fp.Controls.Add(this.insQuantity);
            this.fp.Controls.Add(this.insManufacturer);
            this.fp.Controls.Add(this.insDateCode);
            this.fp.Controls.Add(this.insPackaging);
            this.fp.Controls.Add(this.insESD);
            this.fp.Controls.Add(this.insRefurb);
            this.fp.Controls.Add(this.insAuthentic);
            this.fp.Controls.Add(this.insHumidity);
            this.fp.Controls.Add(this.insScan);
            this.fp.Controls.Add(this.insPrePhotoWeight);
            this.fp.Controls.Add(this.insPhotosInBox);
            this.fp.Controls.Add(this.insPhotosIncludeLeads);
            this.fp.Controls.Add(this.insLeavingPhotos);
            this.fp.Controls.Add(this.ins_datasheet_analysis);
            this.fp.Controls.Add(this.ins_ocm_verification);
            this.fp.Controls.Add(this.ins_gold_standard);
            this.fp.Controls.Add(this.ins_calibrations_measured);
            this.fp.Location = new System.Drawing.Point(0, 46);
            this.fp.Name = "fp";
            this.fp.Size = new System.Drawing.Size(512, 446);
            this.fp.TabIndex = 29;
            // 
            // insGoodPackage
            // 
            this.insGoodPackage.Caption = "Package received in good condition?";
            this.insGoodPackage.FieldNAText = "NA";
            this.insGoodPackage.FieldNotes = "good_package_notes";
            this.insGoodPackage.FieldNoText = "N";
            this.insGoodPackage.FieldYesNo = "good_package_condition";
            this.insGoodPackage.FieldYesText = "Y";
            this.insGoodPackage.IsNA = false;
            this.insGoodPackage.IsNo = false;
            this.insGoodPackage.IsYes = true;
            this.insGoodPackage.Location = new System.Drawing.Point(3, 3);
            this.insGoodPackage.Name = "insGoodPackage";
            this.insGoodPackage.Notes = "";
            this.insGoodPackage.ShowNA = true;
            this.insGoodPackage.ShowNotes = true;
            this.insGoodPackage.Size = new System.Drawing.Size(489, 51);
            this.insGoodPackage.TabIndex = 8;
            // 
            // insOrigin
            // 
            this.insOrigin.Caption = "Country of origin?";
            this.insOrigin.FieldNAText = "NA";
            this.insOrigin.FieldNotes = "country_of_origin_notes";
            this.insOrigin.FieldNoText = "N";
            this.insOrigin.FieldYesNo = "good_country_of_origin";
            this.insOrigin.FieldYesText = "Y";
            this.insOrigin.IsNA = false;
            this.insOrigin.IsNo = false;
            this.insOrigin.IsYes = true;
            this.insOrigin.Location = new System.Drawing.Point(3, 60);
            this.insOrigin.Name = "insOrigin";
            this.insOrigin.Notes = "";
            this.insOrigin.ShowNA = true;
            this.insOrigin.ShowNotes = true;
            this.insOrigin.Size = new System.Drawing.Size(489, 51);
            this.insOrigin.TabIndex = 15;
            // 
            // insReportPackageDamage
            // 
            this.insReportPackageDamage.Caption = "Report package damage?";
            this.insReportPackageDamage.FieldNAText = "NA";
            this.insReportPackageDamage.FieldNotes = "package_damage_notes";
            this.insReportPackageDamage.FieldNoText = "N";
            this.insReportPackageDamage.FieldYesNo = "report_package_damage";
            this.insReportPackageDamage.FieldYesText = "Y";
            this.insReportPackageDamage.IsNA = false;
            this.insReportPackageDamage.IsNo = false;
            this.insReportPackageDamage.IsYes = true;
            this.insReportPackageDamage.Location = new System.Drawing.Point(3, 117);
            this.insReportPackageDamage.Name = "insReportPackageDamage";
            this.insReportPackageDamage.Notes = "";
            this.insReportPackageDamage.ShowNA = true;
            this.insReportPackageDamage.ShowNotes = true;
            this.insReportPackageDamage.Size = new System.Drawing.Size(489, 51);
            this.insReportPackageDamage.TabIndex = 9;
            // 
            // insVendorInfo
            // 
            this.insVendorInfo.Caption = "Check vendor info?";
            this.insVendorInfo.FieldNAText = "NA";
            this.insVendorInfo.FieldNotes = "vendor_info_notes";
            this.insVendorInfo.FieldNoText = "N";
            this.insVendorInfo.FieldYesNo = "match_vendor_info";
            this.insVendorInfo.FieldYesText = "Y";
            this.insVendorInfo.IsNA = false;
            this.insVendorInfo.IsNo = false;
            this.insVendorInfo.IsYes = true;
            this.insVendorInfo.Location = new System.Drawing.Point(3, 174);
            this.insVendorInfo.Name = "insVendorInfo";
            this.insVendorInfo.Notes = "";
            this.insVendorInfo.ShowNA = true;
            this.insVendorInfo.ShowNotes = true;
            this.insVendorInfo.Size = new System.Drawing.Size(489, 51);
            this.insVendorInfo.TabIndex = 10;
            // 
            // insPart
            // 
            this.insPart.Caption = "Verify part number?";
            this.insPart.FieldNAText = "NA";
            this.insPart.FieldNotes = "part_number_notes";
            this.insPart.FieldNoText = "N";
            this.insPart.FieldYesNo = "verify_part_number";
            this.insPart.FieldYesText = "Y";
            this.insPart.IsNA = false;
            this.insPart.IsNo = false;
            this.insPart.IsYes = true;
            this.insPart.Location = new System.Drawing.Point(3, 231);
            this.insPart.Name = "insPart";
            this.insPart.Notes = "";
            this.insPart.ShowNA = true;
            this.insPart.ShowNotes = true;
            this.insPart.Size = new System.Drawing.Size(489, 51);
            this.insPart.TabIndex = 11;
            // 
            // insQuantity
            // 
            this.insQuantity.Caption = "Verify quantity?";
            this.insQuantity.FieldNAText = "NA";
            this.insQuantity.FieldNotes = "quantity_notes";
            this.insQuantity.FieldNoText = "N";
            this.insQuantity.FieldYesNo = "verify_quantity";
            this.insQuantity.FieldYesText = "Y";
            this.insQuantity.IsNA = false;
            this.insQuantity.IsNo = false;
            this.insQuantity.IsYes = true;
            this.insQuantity.Location = new System.Drawing.Point(3, 288);
            this.insQuantity.Name = "insQuantity";
            this.insQuantity.Notes = "";
            this.insQuantity.ShowNA = true;
            this.insQuantity.ShowNotes = true;
            this.insQuantity.Size = new System.Drawing.Size(489, 51);
            this.insQuantity.TabIndex = 12;
            // 
            // insManufacturer
            // 
            this.insManufacturer.Caption = "Verify manufacturer?";
            this.insManufacturer.FieldNAText = "NA";
            this.insManufacturer.FieldNotes = "manufacturer_notes";
            this.insManufacturer.FieldNoText = "N";
            this.insManufacturer.FieldYesNo = "manufacturer_match";
            this.insManufacturer.FieldYesText = "Y";
            this.insManufacturer.IsNA = false;
            this.insManufacturer.IsNo = false;
            this.insManufacturer.IsYes = true;
            this.insManufacturer.Location = new System.Drawing.Point(3, 345);
            this.insManufacturer.Name = "insManufacturer";
            this.insManufacturer.Notes = "";
            this.insManufacturer.ShowNA = true;
            this.insManufacturer.ShowNotes = true;
            this.insManufacturer.Size = new System.Drawing.Size(489, 51);
            this.insManufacturer.TabIndex = 13;
            // 
            // insDateCode
            // 
            this.insDateCode.Caption = "Verify date code?";
            this.insDateCode.FieldNAText = "NA";
            this.insDateCode.FieldNotes = "datecode_notes";
            this.insDateCode.FieldNoText = "N";
            this.insDateCode.FieldYesNo = "datecode_match";
            this.insDateCode.FieldYesText = "Y";
            this.insDateCode.IsNA = false;
            this.insDateCode.IsNo = false;
            this.insDateCode.IsYes = true;
            this.insDateCode.Location = new System.Drawing.Point(3, 402);
            this.insDateCode.Name = "insDateCode";
            this.insDateCode.Notes = "";
            this.insDateCode.ShowNA = true;
            this.insDateCode.ShowNotes = true;
            this.insDateCode.Size = new System.Drawing.Size(489, 51);
            this.insDateCode.TabIndex = 14;
            // 
            // insPackaging
            // 
            this.insPackaging.Caption = "Manufacturer packaging?";
            this.insPackaging.FieldNAText = "NA";
            this.insPackaging.FieldNotes = "part_package_notes";
            this.insPackaging.FieldNoText = "N";
            this.insPackaging.FieldYesNo = "good_part_packaging";
            this.insPackaging.FieldYesText = "Y";
            this.insPackaging.IsNA = false;
            this.insPackaging.IsNo = false;
            this.insPackaging.IsYes = true;
            this.insPackaging.Location = new System.Drawing.Point(3, 459);
            this.insPackaging.Name = "insPackaging";
            this.insPackaging.Notes = "";
            this.insPackaging.ShowNA = true;
            this.insPackaging.ShowNotes = true;
            this.insPackaging.Size = new System.Drawing.Size(489, 51);
            this.insPackaging.TabIndex = 16;
            // 
            // insESD
            // 
            this.insESD.Caption = "ESD packaging?";
            this.insESD.FieldNAText = "NA";
            this.insESD.FieldNotes = "esd_packaging_notes";
            this.insESD.FieldNoText = "N";
            this.insESD.FieldYesNo = "good_esd_packaging";
            this.insESD.FieldYesText = "Y";
            this.insESD.IsNA = false;
            this.insESD.IsNo = false;
            this.insESD.IsYes = true;
            this.insESD.Location = new System.Drawing.Point(3, 516);
            this.insESD.Name = "insESD";
            this.insESD.Notes = "";
            this.insESD.ShowNA = true;
            this.insESD.ShowNotes = true;
            this.insESD.Size = new System.Drawing.Size(489, 51);
            this.insESD.TabIndex = 17;
            // 
            // insRefurb
            // 
            this.insRefurb.Caption = "Refurbished or reworked?";
            this.insRefurb.FieldNAText = "NA";
            this.insRefurb.FieldNotes = "refurb_notes";
            this.insRefurb.FieldNoText = "N";
            this.insRefurb.FieldYesNo = "is_refurb";
            this.insRefurb.FieldYesText = "Y";
            this.insRefurb.IsNA = false;
            this.insRefurb.IsNo = false;
            this.insRefurb.IsYes = true;
            this.insRefurb.Location = new System.Drawing.Point(3, 573);
            this.insRefurb.Name = "insRefurb";
            this.insRefurb.Notes = "";
            this.insRefurb.ShowNA = true;
            this.insRefurb.ShowNotes = true;
            this.insRefurb.Size = new System.Drawing.Size(489, 51);
            this.insRefurb.TabIndex = 18;
            // 
            // insAuthentic
            // 
            this.insAuthentic.Caption = "Authentic markings and symbols?";
            this.insAuthentic.FieldNAText = "NA";
            this.insAuthentic.FieldNotes = "authentic_notes";
            this.insAuthentic.FieldNoText = "N";
            this.insAuthentic.FieldYesNo = "is_authentic";
            this.insAuthentic.FieldYesText = "Y";
            this.insAuthentic.IsNA = false;
            this.insAuthentic.IsNo = false;
            this.insAuthentic.IsYes = true;
            this.insAuthentic.Location = new System.Drawing.Point(3, 630);
            this.insAuthentic.Name = "insAuthentic";
            this.insAuthentic.Notes = "";
            this.insAuthentic.ShowNA = true;
            this.insAuthentic.ShowNotes = true;
            this.insAuthentic.Size = new System.Drawing.Size(489, 51);
            this.insAuthentic.TabIndex = 19;
            // 
            // insHumidity
            // 
            this.insHumidity.Caption = "Humidity status indicator?";
            this.insHumidity.FieldNAText = "NA";
            this.insHumidity.FieldNotes = "humidity_controlled_notes";
            this.insHumidity.FieldNoText = "N";
            this.insHumidity.FieldYesNo = "is_humidity_controlled";
            this.insHumidity.FieldYesText = "Y";
            this.insHumidity.IsNA = false;
            this.insHumidity.IsNo = false;
            this.insHumidity.IsYes = true;
            this.insHumidity.Location = new System.Drawing.Point(3, 687);
            this.insHumidity.Name = "insHumidity";
            this.insHumidity.Notes = "";
            this.insHumidity.ShowNA = true;
            this.insHumidity.ShowNotes = true;
            this.insHumidity.Size = new System.Drawing.Size(489, 51);
            this.insHumidity.TabIndex = 20;
            // 
            // insScan
            // 
            this.insScan.Caption = "Scanned everything?";
            this.insScan.FieldNAText = "NA";
            this.insScan.FieldNotes = "photographed_label_notes";
            this.insScan.FieldNoText = "N";
            this.insScan.FieldYesNo = "photographed_labels";
            this.insScan.FieldYesText = "Y";
            this.insScan.IsNA = false;
            this.insScan.IsNo = false;
            this.insScan.IsYes = true;
            this.insScan.Location = new System.Drawing.Point(3, 744);
            this.insScan.Name = "insScan";
            this.insScan.Notes = "";
            this.insScan.ShowNA = true;
            this.insScan.ShowNotes = true;
            this.insScan.Size = new System.Drawing.Size(489, 51);
            this.insScan.TabIndex = 21;
            // 
            // insPrePhotoWeight
            // 
            this.insPrePhotoWeight.Caption = "Photo and weight before opening?";
            this.insPrePhotoWeight.FieldNAText = "NA";
            this.insPrePhotoWeight.FieldNotes = "pre_photo_weight_notes";
            this.insPrePhotoWeight.FieldNoText = "N";
            this.insPrePhotoWeight.FieldYesNo = "pre_photo_weight";
            this.insPrePhotoWeight.FieldYesText = "Y";
            this.insPrePhotoWeight.IsNA = false;
            this.insPrePhotoWeight.IsNo = false;
            this.insPrePhotoWeight.IsYes = true;
            this.insPrePhotoWeight.Location = new System.Drawing.Point(3, 801);
            this.insPrePhotoWeight.Name = "insPrePhotoWeight";
            this.insPrePhotoWeight.Notes = "";
            this.insPrePhotoWeight.ShowNA = true;
            this.insPrePhotoWeight.ShowNotes = true;
            this.insPrePhotoWeight.Size = new System.Drawing.Size(489, 51);
            this.insPrePhotoWeight.TabIndex = 24;
            // 
            // insPhotosInBox
            // 
            this.insPhotosInBox.Caption = "Photos in box?";
            this.insPhotosInBox.FieldNAText = "NA";
            this.insPhotosInBox.FieldNotes = "photos_in_box_notes";
            this.insPhotosInBox.FieldNoText = "N";
            this.insPhotosInBox.FieldYesNo = "photos_in_box";
            this.insPhotosInBox.FieldYesText = "Y";
            this.insPhotosInBox.IsNA = false;
            this.insPhotosInBox.IsNo = false;
            this.insPhotosInBox.IsYes = true;
            this.insPhotosInBox.Location = new System.Drawing.Point(3, 858);
            this.insPhotosInBox.Name = "insPhotosInBox";
            this.insPhotosInBox.Notes = "";
            this.insPhotosInBox.ShowNA = true;
            this.insPhotosInBox.ShowNotes = true;
            this.insPhotosInBox.Size = new System.Drawing.Size(489, 51);
            this.insPhotosInBox.TabIndex = 26;
            // 
            // insPhotosIncludeLeads
            // 
            this.insPhotosIncludeLeads.Caption = "Photos include leads?";
            this.insPhotosIncludeLeads.FieldNAText = "NA";
            this.insPhotosIncludeLeads.FieldNotes = "photos_include_leads_notes";
            this.insPhotosIncludeLeads.FieldNoText = "N";
            this.insPhotosIncludeLeads.FieldYesNo = "photos_include_leads";
            this.insPhotosIncludeLeads.FieldYesText = "Y";
            this.insPhotosIncludeLeads.IsNA = false;
            this.insPhotosIncludeLeads.IsNo = false;
            this.insPhotosIncludeLeads.IsYes = true;
            this.insPhotosIncludeLeads.Location = new System.Drawing.Point(3, 915);
            this.insPhotosIncludeLeads.Name = "insPhotosIncludeLeads";
            this.insPhotosIncludeLeads.Notes = "";
            this.insPhotosIncludeLeads.ShowNA = true;
            this.insPhotosIncludeLeads.ShowNotes = true;
            this.insPhotosIncludeLeads.Size = new System.Drawing.Size(489, 51);
            this.insPhotosIncludeLeads.TabIndex = 27;
            // 
            // insLeavingPhotos
            // 
            this.insLeavingPhotos.Caption = "Photos of parts leaving the building?";
            this.insLeavingPhotos.FieldNAText = "NA";
            this.insLeavingPhotos.FieldNotes = "leaving_photos_notes";
            this.insLeavingPhotos.FieldNoText = "N";
            this.insLeavingPhotos.FieldYesNo = "leaving_photos";
            this.insLeavingPhotos.FieldYesText = "Y";
            this.insLeavingPhotos.IsNA = false;
            this.insLeavingPhotos.IsNo = false;
            this.insLeavingPhotos.IsYes = true;
            this.insLeavingPhotos.Location = new System.Drawing.Point(3, 972);
            this.insLeavingPhotos.Name = "insLeavingPhotos";
            this.insLeavingPhotos.Notes = "";
            this.insLeavingPhotos.ShowNA = true;
            this.insLeavingPhotos.ShowNotes = true;
            this.insLeavingPhotos.Size = new System.Drawing.Size(489, 51);
            this.insLeavingPhotos.TabIndex = 28;
            // 
            // ins_datasheet_analysis
            // 
            this.ins_datasheet_analysis.Caption = "Visual Inspection - Datasheet Analysis";
            this.ins_datasheet_analysis.FieldNAText = "NA";
            this.ins_datasheet_analysis.FieldNotes = "datasheet_analysis_notes";
            this.ins_datasheet_analysis.FieldNoText = "N";
            this.ins_datasheet_analysis.FieldYesNo = "datasheet_analysis";
            this.ins_datasheet_analysis.FieldYesText = "Y";
            this.ins_datasheet_analysis.IsNA = false;
            this.ins_datasheet_analysis.IsNo = false;
            this.ins_datasheet_analysis.IsYes = true;
            this.ins_datasheet_analysis.Location = new System.Drawing.Point(3, 1029);
            this.ins_datasheet_analysis.Name = "ins_datasheet_analysis";
            this.ins_datasheet_analysis.Notes = "";
            this.ins_datasheet_analysis.ShowNA = true;
            this.ins_datasheet_analysis.ShowNotes = true;
            this.ins_datasheet_analysis.Size = new System.Drawing.Size(489, 51);
            this.ins_datasheet_analysis.TabIndex = 29;
            // 
            // ins_ocm_verification
            // 
            this.ins_ocm_verification.Caption = "Visual Inspection - OCM Verification?";
            this.ins_ocm_verification.FieldNAText = "NA";
            this.ins_ocm_verification.FieldNotes = "ocm_verification_notes";
            this.ins_ocm_verification.FieldNoText = "N";
            this.ins_ocm_verification.FieldYesNo = "ocm_verification";
            this.ins_ocm_verification.FieldYesText = "Y";
            this.ins_ocm_verification.IsNA = false;
            this.ins_ocm_verification.IsNo = false;
            this.ins_ocm_verification.IsYes = true;
            this.ins_ocm_verification.Location = new System.Drawing.Point(3, 1086);
            this.ins_ocm_verification.Name = "ins_ocm_verification";
            this.ins_ocm_verification.Notes = "";
            this.ins_ocm_verification.ShowNA = true;
            this.ins_ocm_verification.ShowNotes = true;
            this.ins_ocm_verification.Size = new System.Drawing.Size(489, 51);
            this.ins_ocm_verification.TabIndex = 30;
            // 
            // ins_gold_standard
            // 
            this.ins_gold_standard.Caption = "Visual Inspection - Gold Standard?";
            this.ins_gold_standard.FieldNAText = "NA";
            this.ins_gold_standard.FieldNotes = "gold_standard_notes";
            this.ins_gold_standard.FieldNoText = "N";
            this.ins_gold_standard.FieldYesNo = "gold_standard";
            this.ins_gold_standard.FieldYesText = "Y";
            this.ins_gold_standard.IsNA = false;
            this.ins_gold_standard.IsNo = false;
            this.ins_gold_standard.IsYes = true;
            this.ins_gold_standard.Location = new System.Drawing.Point(3, 1143);
            this.ins_gold_standard.Name = "ins_gold_standard";
            this.ins_gold_standard.Notes = "";
            this.ins_gold_standard.ShowNA = true;
            this.ins_gold_standard.ShowNotes = true;
            this.ins_gold_standard.Size = new System.Drawing.Size(489, 51);
            this.ins_gold_standard.TabIndex = 31;
            // 
            // ins_calibrations_measured
            // 
            this.ins_calibrations_measured.Caption = "Visual Inspection - Calibrations Measured";
            this.ins_calibrations_measured.FieldNAText = "NA";
            this.ins_calibrations_measured.FieldNotes = "calibrations_measured_notes";
            this.ins_calibrations_measured.FieldNoText = "N";
            this.ins_calibrations_measured.FieldYesNo = "calibrations_measured";
            this.ins_calibrations_measured.FieldYesText = "Y";
            this.ins_calibrations_measured.IsNA = false;
            this.ins_calibrations_measured.IsNo = false;
            this.ins_calibrations_measured.IsYes = true;
            this.ins_calibrations_measured.Location = new System.Drawing.Point(3, 1200);
            this.ins_calibrations_measured.Name = "ins_calibrations_measured";
            this.ins_calibrations_measured.Notes = "";
            this.ins_calibrations_measured.ShowNA = true;
            this.ins_calibrations_measured.ShowNotes = true;
            this.ins_calibrations_measured.Size = new System.Drawing.Size(489, 51);
            this.ins_calibrations_measured.TabIndex = 32;
            // 
            // insCertsMatch
            // 
            this.insCertsMatch.Caption = "Certification matches parts received?";
            this.insCertsMatch.FieldNAText = "NA";
            this.insCertsMatch.FieldNotes = "";
            this.insCertsMatch.FieldNoText = "N";
            this.insCertsMatch.FieldYesNo = "certs_match";
            this.insCertsMatch.FieldYesText = "Y";
            this.insCertsMatch.IsNA = false;
            this.insCertsMatch.IsNo = false;
            this.insCertsMatch.IsYes = true;
            this.insCertsMatch.Location = new System.Drawing.Point(259, -5);
            this.insCertsMatch.Name = "insCertsMatch";
            this.insCertsMatch.Notes = "";
            this.insCertsMatch.ShowNA = true;
            this.insCertsMatch.ShowNotes = false;
            this.insCertsMatch.Size = new System.Drawing.Size(253, 45);
            this.insCertsMatch.TabIndex = 3;
            // 
            // insCerts
            // 
            this.insCerts.Caption = "Manufacturers certification included?";
            this.insCerts.FieldNAText = "NA";
            this.insCerts.FieldNotes = "";
            this.insCerts.FieldNoText = "N";
            this.insCerts.FieldYesNo = "certs_included";
            this.insCerts.FieldYesText = "Y";
            this.insCerts.IsNA = false;
            this.insCerts.IsNo = false;
            this.insCerts.IsYes = true;
            this.insCerts.Location = new System.Drawing.Point(0, -5);
            this.insCerts.Name = "insCerts";
            this.insCerts.Notes = "";
            this.insCerts.ShowNA = true;
            this.insCerts.ShowNotes = false;
            this.insCerts.Size = new System.Drawing.Size(253, 45);
            this.insCerts.TabIndex = 2;
            // 
            // cmdTesting
            // 
            this.cmdTesting.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdTesting.ForeColor = System.Drawing.Color.Blue;
            this.cmdTesting.Location = new System.Drawing.Point(518, 460);
            this.cmdTesting.Name = "cmdTesting";
            this.cmdTesting.Size = new System.Drawing.Size(214, 31);
            this.cmdTesting.TabIndex = 32;
            this.cmdTesting.Text = "Test Results";
            this.cmdTesting.UseVisualStyleBackColor = true;
            this.cmdTesting.Visible = false;
            this.cmdTesting.Click += new System.EventHandler(this.cmdTesting_Click);
            // 
            // view_qualitycontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.fp);
            this.Controls.Add(this.cmdTesting);
            this.Controls.Add(this.ctl_processor_name);
            this.Controls.Add(this.gbTestInfo);
            this.Controls.Add(this.gbROHS);
            this.Controls.Add(this.gbStatus);
            this.Controls.Add(this.lblViewNotes);
            this.Controls.Add(this.insCertsMatch);
            this.Controls.Add(this.lblAddLog);
            this.Controls.Add(this.ctl_internalcomment);
            this.Controls.Add(this.insCerts);
            this.Name = "view_qualitycontrol";
            this.Size = new System.Drawing.Size(882, 497);
            this.Resize += new System.EventHandler(this.view_qualitycontrol_Resize);
            this.Controls.SetChildIndex(this.insCerts, 0);
            this.Controls.SetChildIndex(this.ctl_internalcomment, 0);
            this.Controls.SetChildIndex(this.lblAddLog, 0);
            this.Controls.SetChildIndex(this.insCertsMatch, 0);
            this.Controls.SetChildIndex(this.lblViewNotes, 0);
            this.Controls.SetChildIndex(this.gbStatus, 0);
            this.Controls.SetChildIndex(this.gbROHS, 0);
            this.Controls.SetChildIndex(this.gbTestInfo, 0);
            this.Controls.SetChildIndex(this.ctl_processor_name, 0);
            this.Controls.SetChildIndex(this.cmdTesting, 0);
            this.Controls.SetChildIndex(this.fp, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.gbStatus.ResumeLayout(false);
            this.gbROHS.ResumeLayout(false);
            this.gbLeadFreePassFail.ResumeLayout(false);
            this.gbLeadFreePassFail.PerformLayout();
            this.gbTestInfo.ResumeLayout(false);
            this.fp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.RadioButton optLeadFreePass;
        protected System.Windows.Forms.RadioButton optLeadFreeFailed;
        protected System.Windows.Forms.RadioButton optLeadFreeNA;
        protected InspectionLine insGoodPackage;
        protected InspectionLine insReportPackageDamage;
        protected InspectionLine insVendorInfo;
        protected InspectionLine insPart;
        protected InspectionLine insQuantity;
        protected InspectionLine insDateCode;
        protected InspectionLine insManufacturer;
        protected InspectionLine insOrigin;
        protected InspectionLine insPackaging;
        protected InspectionLine insESD;
        protected InspectionLine insRefurb;
        protected InspectionLine insAuthentic;
        protected InspectionLine insHumidity;
        protected InspectionLine insScan;
        protected InspectionLine insPrePhotoWeight;
        protected InspectionLine insPhotosInBox;
        protected InspectionLine insPhotosIncludeLeads;
        protected InspectionLine insLeavingPhotos;
        protected System.Windows.Forms.FlowLayoutPanel fp;
        protected InspectionLine ins_datasheet_analysis;
        protected InspectionLine ins_ocm_verification;
        protected InspectionLine ins_gold_standard;
        protected InspectionLine ins_calibrations_measured;
        protected NewMethod.nEdit_Memo ctl_internalcomment;
        protected System.Windows.Forms.LinkLabel lblAddLog;
        protected System.Windows.Forms.LinkLabel lblViewNotes;
        protected System.Windows.Forms.GroupBox gbROHS;
        protected System.Windows.Forms.GroupBox gbTestInfo;
        protected NewMethod.nEdit_String ctl_processor_name;
        protected InspectionLine insCerts;
        protected InspectionLine insCertsMatch;
        protected System.Windows.Forms.GroupBox gbStatus;
        protected NewMethod.nEdit_String ctl_problem_notes;
        protected NewMethod.nEdit_Boolean ctl_has_problem;
        protected System.Windows.Forms.Button cmdAlert;
        protected System.Windows.Forms.Button cmdTesting;
        protected InspectionLine insLeadFree;
        protected System.Windows.Forms.GroupBox gbLeadFreePassFail;
        protected NewMethod.nEdit_Number ctl_qty_tested;
        protected NewMethod.nEdit_Number ctl_qty_passed;
        protected NewMethod.nEdit_Number ctl_qty_failed;
        protected NewMethod.nEdit_List ctl_test_performed;
        protected NewMethod.nEdit_Boolean ctl_has_test_docs;
        protected NewMethod.nEdit_String ctl_test_company;
    }
}
