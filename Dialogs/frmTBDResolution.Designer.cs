namespace RzInterfaceWin.Dialogs
{
    partial class frmTBDResolution
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbTBDResoluton = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ctl_tbd_notes = new NewMethod.nEdit_Memo();
            this.ctl_manufacturer = new NewMethod.nEdit_List();
            this.ctl_lead_time = new NewMethod.nEdit_List();
            this.ctl_Quantity = new NewMethod.nEdit_Number();
            this.ctl_unit_cost = new NewMethod.nEdit_Money();
            this.ctl_DateCode = new NewMethod.nEdit_String();
            this.ctl_partNumber = new NewMethod.nEdit_String();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.optStock = new System.Windows.Forms.RadioButton();
            this.optVendor = new System.Windows.Forms.RadioButton();
            this.optConsign = new System.Windows.Forms.RadioButton();
            this.lblAllocate = new System.Windows.Forms.LinkLabel();
            this.ctlChooseVendor = new Rz5.CompanyStub_PlusContact();
            this.gbTBDResoluton.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTBDResoluton
            // 
            this.gbTBDResoluton.Controls.Add(this.groupBox3);
            this.gbTBDResoluton.Controls.Add(this.groupBox2);
            this.gbTBDResoluton.Controls.Add(this.groupBox1);
            this.gbTBDResoluton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTBDResoluton.Location = new System.Drawing.Point(12, 12);
            this.gbTBDResoluton.Name = "gbTBDResoluton";
            this.gbTBDResoluton.Size = new System.Drawing.Size(519, 553);
            this.gbTBDResoluton.TabIndex = 1;
            this.gbTBDResoluton.TabStop = false;
            this.gbTBDResoluton.Text = "<Customer, SO#, PartNumber>";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(166, 245);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 40);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(263, 245);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 40);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ctl_tbd_notes
            // 
            this.ctl_tbd_notes.BackColor = System.Drawing.Color.Transparent;
            this.ctl_tbd_notes.Bold = false;
            this.ctl_tbd_notes.Caption = "Notes";
            this.ctl_tbd_notes.Changed = false;
            this.ctl_tbd_notes.DateLines = false;
            this.ctl_tbd_notes.Location = new System.Drawing.Point(15, 129);
            this.ctl_tbd_notes.Margin = new System.Windows.Forms.Padding(24, 20, 24, 20);
            this.ctl_tbd_notes.Name = "ctl_tbd_notes";
            this.ctl_tbd_notes.Size = new System.Drawing.Size(483, 110);
            this.ctl_tbd_notes.TabIndex = 17;
            this.ctl_tbd_notes.UseParentBackColor = false;
            this.ctl_tbd_notes.zz_Enabled = true;
            this.ctl_tbd_notes.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_tbd_notes.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_tbd_notes.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_tbd_notes.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_tbd_notes.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_tbd_notes.zz_OriginalDesign = true;
            this.ctl_tbd_notes.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_tbd_notes.zz_ShowNeedsSaveColor = true;
            this.ctl_tbd_notes.zz_Text = "";
            this.ctl_tbd_notes.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_tbd_notes.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_tbd_notes.zz_UseGlobalColor = false;
            this.ctl_tbd_notes.zz_UseGlobalFont = false;
            // 
            // ctl_manufacturer
            // 
            this.ctl_manufacturer.AllCaps = false;
            this.ctl_manufacturer.AllowEdit = false;
            this.ctl_manufacturer.BackColor = System.Drawing.Color.Transparent;
            this.ctl_manufacturer.Bold = false;
            this.ctl_manufacturer.Caption = "Manufacturer";
            this.ctl_manufacturer.Changed = false;
            this.ctl_manufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_manufacturer.ListName = "manufacturer";
            this.ctl_manufacturer.Location = new System.Drawing.Point(15, 85);
            this.ctl_manufacturer.Margin = new System.Windows.Forms.Padding(6);
            this.ctl_manufacturer.Name = "ctl_manufacturer";
            this.ctl_manufacturer.SimpleList = null;
            this.ctl_manufacturer.Size = new System.Drawing.Size(240, 40);
            this.ctl_manufacturer.TabIndex = 14;
            this.ctl_manufacturer.UseParentBackColor = true;
            this.ctl_manufacturer.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctl_manufacturer.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_manufacturer.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_manufacturer.zz_LabelColor = System.Drawing.Color.Black;
            this.ctl_manufacturer.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_manufacturer.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_manufacturer.zz_OriginalDesign = false;
            this.ctl_manufacturer.zz_ShowNeedsSaveColor = true;
            this.ctl_manufacturer.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_manufacturer.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_manufacturer.zz_UseGlobalColor = false;
            this.ctl_manufacturer.zz_UseGlobalFont = false;
            // 
            // ctl_lead_time
            // 
            this.ctl_lead_time.AllCaps = false;
            this.ctl_lead_time.AllowEdit = false;
            this.ctl_lead_time.BackColor = System.Drawing.Color.White;
            this.ctl_lead_time.Bold = false;
            this.ctl_lead_time.Caption = "Lead Time";
            this.ctl_lead_time.Changed = false;
            this.ctl_lead_time.ListName = "delivery";
            this.ctl_lead_time.Location = new System.Drawing.Point(263, 87);
            this.ctl_lead_time.Margin = new System.Windows.Forms.Padding(24, 20, 24, 20);
            this.ctl_lead_time.Name = "ctl_lead_time";
            this.ctl_lead_time.SimpleList = null;
            this.ctl_lead_time.Size = new System.Drawing.Size(117, 38);
            this.ctl_lead_time.TabIndex = 15;
            this.ctl_lead_time.UseParentBackColor = true;
            this.ctl_lead_time.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_lead_time.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_lead_time.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_lead_time.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_lead_time.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_lead_time.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_lead_time.zz_OriginalDesign = false;
            this.ctl_lead_time.zz_ShowNeedsSaveColor = true;
            this.ctl_lead_time.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_lead_time.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_lead_time.zz_UseGlobalColor = false;
            this.ctl_lead_time.zz_UseGlobalFont = false;
            // 
            // ctl_Quantity
            // 
            this.ctl_Quantity.BackColor = System.Drawing.Color.Transparent;
            this.ctl_Quantity.Bold = false;
            this.ctl_Quantity.Caption = "Quantity";
            this.ctl_Quantity.Changed = false;
            this.ctl_Quantity.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_Quantity.Location = new System.Drawing.Point(392, 31);
            this.ctl_Quantity.Margin = new System.Windows.Forms.Padding(6);
            this.ctl_Quantity.Name = "ctl_Quantity";
            this.ctl_Quantity.Size = new System.Drawing.Size(106, 49);
            this.ctl_Quantity.TabIndex = 12;
            this.ctl_Quantity.UseParentBackColor = false;
            this.ctl_Quantity.zz_Enabled = true;
            this.ctl_Quantity.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_Quantity.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_Quantity.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_Quantity.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_Quantity.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_Quantity.zz_OriginalDesign = true;
            this.ctl_Quantity.zz_ShowErrorColor = true;
            this.ctl_Quantity.zz_ShowNeedsSaveColor = true;
            this.ctl_Quantity.zz_Text = "";
            this.ctl_Quantity.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_Quantity.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_Quantity.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_Quantity.zz_UseGlobalColor = false;
            this.ctl_Quantity.zz_UseGlobalFont = false;
            // 
            // ctl_unit_cost
            // 
            this.ctl_unit_cost.BackColor = System.Drawing.Color.Transparent;
            this.ctl_unit_cost.Bold = false;
            this.ctl_unit_cost.Caption = "Unit  Cost";
            this.ctl_unit_cost.Changed = false;
            this.ctl_unit_cost.EditCaption = false;
            this.ctl_unit_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_unit_cost.FullDecimal = false;
            this.ctl_unit_cost.Location = new System.Drawing.Point(263, 38);
            this.ctl_unit_cost.Margin = new System.Windows.Forms.Padding(6);
            this.ctl_unit_cost.Name = "ctl_unit_cost";
            this.ctl_unit_cost.RoundNearestCent = false;
            this.ctl_unit_cost.Size = new System.Drawing.Size(117, 35);
            this.ctl_unit_cost.TabIndex = 13;
            this.ctl_unit_cost.UseParentBackColor = false;
            this.ctl_unit_cost.zz_Enabled = true;
            this.ctl_unit_cost.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_unit_cost.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_unit_cost.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_unit_cost.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_unit_cost.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_unit_cost.zz_OriginalDesign = false;
            this.ctl_unit_cost.zz_ShowErrorColor = true;
            this.ctl_unit_cost.zz_ShowNeedsSaveColor = true;
            this.ctl_unit_cost.zz_Text = "";
            this.ctl_unit_cost.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_unit_cost.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_unit_cost.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_unit_cost.zz_UseGlobalColor = false;
            this.ctl_unit_cost.zz_UseGlobalFont = false;
            // 
            // ctl_DateCode
            // 
            this.ctl_DateCode.AllCaps = false;
            this.ctl_DateCode.BackColor = System.Drawing.Color.Transparent;
            this.ctl_DateCode.Bold = false;
            this.ctl_DateCode.Caption = "DateCode";
            this.ctl_DateCode.Changed = false;
            this.ctl_DateCode.IsEmail = false;
            this.ctl_DateCode.IsURL = false;
            this.ctl_DateCode.Location = new System.Drawing.Point(392, 88);
            this.ctl_DateCode.Margin = new System.Windows.Forms.Padding(48, 37, 48, 37);
            this.ctl_DateCode.Name = "ctl_DateCode";
            this.ctl_DateCode.PasswordChar = '\0';
            this.ctl_DateCode.Size = new System.Drawing.Size(106, 37);
            this.ctl_DateCode.TabIndex = 16;
            this.ctl_DateCode.UseParentBackColor = false;
            this.ctl_DateCode.zz_Enabled = true;
            this.ctl_DateCode.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_DateCode.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_DateCode.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_DateCode.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_DateCode.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_DateCode.zz_OriginalDesign = false;
            this.ctl_DateCode.zz_ShowLinkButton = true;
            this.ctl_DateCode.zz_ShowNeedsSaveColor = true;
            this.ctl_DateCode.zz_Text = "";
            this.ctl_DateCode.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_DateCode.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_DateCode.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_DateCode.zz_UseGlobalColor = false;
            this.ctl_DateCode.zz_UseGlobalFont = false;
            // 
            // ctl_partNumber
            // 
            this.ctl_partNumber.AllCaps = false;
            this.ctl_partNumber.BackColor = System.Drawing.Color.Transparent;
            this.ctl_partNumber.Bold = false;
            this.ctl_partNumber.Caption = "Part Number";
            this.ctl_partNumber.Changed = false;
            this.ctl_partNumber.IsEmail = false;
            this.ctl_partNumber.IsURL = false;
            this.ctl_partNumber.Location = new System.Drawing.Point(15, 36);
            this.ctl_partNumber.Margin = new System.Windows.Forms.Padding(24, 20, 24, 20);
            this.ctl_partNumber.Name = "ctl_partNumber";
            this.ctl_partNumber.PasswordChar = '\0';
            this.ctl_partNumber.Size = new System.Drawing.Size(240, 37);
            this.ctl_partNumber.TabIndex = 11;
            this.ctl_partNumber.UseParentBackColor = false;
            this.ctl_partNumber.zz_Enabled = true;
            this.ctl_partNumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_partNumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_partNumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_partNumber.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_partNumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_partNumber.zz_OriginalDesign = false;
            this.ctl_partNumber.zz_ShowLinkButton = true;
            this.ctl_partNumber.zz_ShowNeedsSaveColor = true;
            this.ctl_partNumber.zz_Text = "";
            this.ctl_partNumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_partNumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_partNumber.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_partNumber.zz_UseGlobalColor = false;
            this.ctl_partNumber.zz_UseGlobalFont = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optStock);
            this.groupBox1.Controls.Add(this.optVendor);
            this.groupBox1.Controls.Add(this.optConsign);
            this.groupBox1.Location = new System.Drawing.Point(6, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parts coming from:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblAllocate);
            this.groupBox2.Controls.Add(this.ctlChooseVendor);
            this.groupBox2.Location = new System.Drawing.Point(6, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(507, 123);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vendor / Allocation";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.ctl_partNumber);
            this.groupBox3.Controls.Add(this.ctl_unit_cost);
            this.groupBox3.Controls.Add(this.ctl_tbd_notes);
            this.groupBox3.Controls.Add(this.ctl_Quantity);
            this.groupBox3.Controls.Add(this.ctl_DateCode);
            this.groupBox3.Controls.Add(this.ctl_lead_time);
            this.groupBox3.Controls.Add(this.ctl_manufacturer);
            this.groupBox3.Location = new System.Drawing.Point(6, 232);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(507, 298);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "New Part Information";
            // 
            // optStock
            // 
            this.optStock.AutoSize = true;
            this.optStock.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optStock.Location = new System.Drawing.Point(201, 29);
            this.optStock.Margin = new System.Windows.Forms.Padding(4);
            this.optStock.Name = "optStock";
            this.optStock.Size = new System.Drawing.Size(77, 30);
            this.optStock.TabIndex = 21;
            this.optStock.TabStop = true;
            this.optStock.Text = "Stock";
            this.optStock.UseVisualStyleBackColor = true;
            this.optStock.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optVendor
            // 
            this.optVendor.AutoSize = true;
            this.optVendor.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optVendor.Location = new System.Drawing.Point(8, 29);
            this.optVendor.Margin = new System.Windows.Forms.Padding(4);
            this.optVendor.Name = "optVendor";
            this.optVendor.Size = new System.Drawing.Size(91, 30);
            this.optVendor.TabIndex = 23;
            this.optVendor.TabStop = true;
            this.optVendor.Text = "Vendor";
            this.optVendor.UseVisualStyleBackColor = true;
            this.optVendor.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optConsign
            // 
            this.optConsign.AutoSize = true;
            this.optConsign.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optConsign.Location = new System.Drawing.Point(356, 29);
            this.optConsign.Margin = new System.Windows.Forms.Padding(4);
            this.optConsign.Name = "optConsign";
            this.optConsign.Size = new System.Drawing.Size(142, 30);
            this.optConsign.TabIndex = 22;
            this.optConsign.TabStop = true;
            this.optConsign.Text = "Consignment";
            this.optConsign.UseVisualStyleBackColor = true;
            this.optConsign.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // lblAllocate
            // 
            this.lblAllocate.AutoSize = true;
            this.lblAllocate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllocate.Location = new System.Drawing.Point(287, 64);
            this.lblAllocate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAllocate.Name = "lblAllocate";
            this.lblAllocate.Size = new System.Drawing.Size(197, 15);
            this.lblAllocate.TabIndex = 27;
            this.lblAllocate.TabStop = true;
            this.lblAllocate.Text = "Allocate From Stock / Consignment";
            this.lblAllocate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAllocate_LinkClicked);
            // 
            // ctlChooseVendor
            // 
            this.ctlChooseVendor.Caption = "Vendor";
            this.ctlChooseVendor.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlChooseVendor.Location = new System.Drawing.Point(8, 31);
            this.ctlChooseVendor.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ctlChooseVendor.Name = "ctlChooseVendor";
            this.ctlChooseVendor.Size = new System.Drawing.Size(270, 83);
            this.ctlChooseVendor.TabIndex = 11;
            // 
            // frmTBDResolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(542, 567);
            this.Controls.Add(this.gbTBDResoluton);
            this.Name = "frmTBDResolution";
            this.Text = "Source TBD Resolution";
            this.gbTBDResoluton.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbTBDResoluton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private NewMethod.nEdit_String ctl_partNumber;
        private NewMethod.nEdit_Money ctl_unit_cost;
        private NewMethod.nEdit_Memo ctl_tbd_notes;
        private NewMethod.nEdit_Number ctl_Quantity;
        private NewMethod.nEdit_String ctl_DateCode;
        public NewMethod.nEdit_List ctl_lead_time;
        public NewMethod.nEdit_List ctl_manufacturer;
        private System.Windows.Forms.GroupBox groupBox2;
        public Rz5.CompanyStub_PlusContact ctlChooseVendor;
        private System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.RadioButton optStock;
        protected System.Windows.Forms.RadioButton optVendor;
        protected System.Windows.Forms.RadioButton optConsign;
        protected System.Windows.Forms.LinkLabel lblAllocate;
    }
}