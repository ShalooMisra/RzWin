namespace Rz5
{
    partial class frmDeduction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeduction));
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.ctl_exclude_from_profit_calc = new NewMethod.nEdit_Boolean();
            this.ctl_description = new NewMethod.nEdit_Memo();
            this.ctl_include_on_po = new NewMethod.nEdit_Boolean();
            this.ctl_name = new NewMethod.nEdit_List();
            this.ctl_amount = new NewMethod.nEdit_Money();
            this.btnDelete = new System.Windows.Forms.Button();
            this.ctl_is_payroll_deduction = new NewMethod.nEdit_Boolean();
            this.ctl_payroll_deduction_date = new NewMethod.nEdit_Date();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Location = new System.Drawing.Point(217, 218);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(349, 32);
            this.cmdSave.TabIndex = 1;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(84, 218);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(127, 32);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // ctl_exclude_from_profit_calc
            // 
            this.ctl_exclude_from_profit_calc.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_exclude_from_profit_calc.Bold = false;
            this.ctl_exclude_from_profit_calc.Caption = "Exclude From Profit";
            this.ctl_exclude_from_profit_calc.Changed = false;
            this.ctl_exclude_from_profit_calc.Location = new System.Drawing.Point(5, 85);
            this.ctl_exclude_from_profit_calc.Name = "ctl_exclude_from_profit_calc";
            this.ctl_exclude_from_profit_calc.Size = new System.Drawing.Size(161, 19);
            this.ctl_exclude_from_profit_calc.TabIndex = 64;
            this.ctl_exclude_from_profit_calc.UseParentBackColor = false;
            this.ctl_exclude_from_profit_calc.zz_CheckValue = false;
            this.ctl_exclude_from_profit_calc.zz_LabelColor = System.Drawing.Color.Black;
            this.ctl_exclude_from_profit_calc.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_exclude_from_profit_calc.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_exclude_from_profit_calc.zz_OriginalDesign = false;
            this.ctl_exclude_from_profit_calc.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_description
            // 
            this.ctl_description.BackColor = System.Drawing.Color.Transparent;
            this.ctl_description.Bold = false;
            this.ctl_description.Caption = "Description";
            this.ctl_description.Changed = false;
            this.ctl_description.DateLines = false;
            this.ctl_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_description.Location = new System.Drawing.Point(5, 113);
            this.ctl_description.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.ctl_description.Name = "ctl_description";
            this.ctl_description.Size = new System.Drawing.Size(561, 96);
            this.ctl_description.TabIndex = 62;
            this.ctl_description.UseParentBackColor = true;
            this.ctl_description.zz_Enabled = true;
            this.ctl_description.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_description.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_description.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_description.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_description.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_description.zz_OriginalDesign = false;
            this.ctl_description.zz_ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ctl_description.zz_ShowNeedsSaveColor = true;
            this.ctl_description.zz_Text = "";
            this.ctl_description.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_description.zz_TextFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_description.zz_UseGlobalColor = false;
            this.ctl_description.zz_UseGlobalFont = false;
            // 
            // ctl_include_on_po
            // 
            this.ctl_include_on_po.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_include_on_po.Bold = false;
            this.ctl_include_on_po.Caption = "Include On PO";
            this.ctl_include_on_po.Changed = false;
            this.ctl_include_on_po.Location = new System.Drawing.Point(5, 58);
            this.ctl_include_on_po.Name = "ctl_include_on_po";
            this.ctl_include_on_po.Size = new System.Drawing.Size(126, 19);
            this.ctl_include_on_po.TabIndex = 3;
            this.ctl_include_on_po.UseParentBackColor = false;
            this.ctl_include_on_po.zz_CheckValue = false;
            this.ctl_include_on_po.zz_LabelColor = System.Drawing.Color.Black;
            this.ctl_include_on_po.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_include_on_po.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_include_on_po.zz_OriginalDesign = false;
            this.ctl_include_on_po.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_name
            // 
            this.ctl_name.AllCaps = false;
            this.ctl_name.AllowEdit = false;
            this.ctl_name.BackColor = System.Drawing.SystemColors.Control;
            this.ctl_name.Bold = false;
            this.ctl_name.Caption = "Description";
            this.ctl_name.Changed = false;
            this.ctl_name.ListName = "deduction_type";
            this.ctl_name.Location = new System.Drawing.Point(4, 4);
            this.ctl_name.Name = "ctl_name";
            this.ctl_name.SimpleList = null;
            this.ctl_name.Size = new System.Drawing.Size(274, 48);
            this.ctl_name.TabIndex = 5;
            this.ctl_name.UseParentBackColor = true;
            this.ctl_name.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctl_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_name.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.ctl_name.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_name.zz_OriginalDesign = false;
            this.ctl_name.zz_ShowNeedsSaveColor = true;
            this.ctl_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_name.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F);
            this.ctl_name.zz_UseGlobalColor = false;
            this.ctl_name.zz_UseGlobalFont = false;
            this.ctl_name.SelectionChanged += new NewMethod.nEdit_List.SelectionChangedHandler(this.ctl_name_SelectionChanged);
            // 
            // ctl_amount
            // 
            this.ctl_amount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_amount.Bold = false;
            this.ctl_amount.Caption = "Amount";
            this.ctl_amount.Changed = false;
            this.ctl_amount.EditCaption = false;
            this.ctl_amount.FullDecimal = false;
            this.ctl_amount.Location = new System.Drawing.Point(295, 5);
            this.ctl_amount.Name = "ctl_amount";
            this.ctl_amount.RoundNearestCent = false;
            this.ctl_amount.Size = new System.Drawing.Size(271, 47);
            this.ctl_amount.TabIndex = 2;
            this.ctl_amount.UseParentBackColor = false;
            this.ctl_amount.zz_Enabled = true;
            this.ctl_amount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_amount.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_amount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_amount.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_amount.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_amount.zz_OriginalDesign = false;
            this.ctl_amount.zz_ShowErrorColor = true;
            this.ctl_amount.zz_ShowNeedsSaveColor = true;
            this.ctl_amount.zz_Text = "";
            this.ctl_amount.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_amount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_amount.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_amount.zz_UseGlobalColor = false;
            this.ctl_amount.zz_UseGlobalFont = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Tomato;
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(12, 218);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 32);
            this.btnDelete.TabIndex = 66;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ctl_is_payroll_deduction
            // 
            this.ctl_is_payroll_deduction.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_is_payroll_deduction.Bold = false;
            this.ctl_is_payroll_deduction.Caption = "Payroll Deduction";
            this.ctl_is_payroll_deduction.Changed = false;
            this.ctl_is_payroll_deduction.Location = new System.Drawing.Point(386, 58);
            this.ctl_is_payroll_deduction.Name = "ctl_is_payroll_deduction";
            this.ctl_is_payroll_deduction.Size = new System.Drawing.Size(147, 19);
            this.ctl_is_payroll_deduction.TabIndex = 67;
            this.ctl_is_payroll_deduction.UseParentBackColor = false;
            this.ctl_is_payroll_deduction.zz_CheckValue = false;
            this.ctl_is_payroll_deduction.zz_LabelColor = System.Drawing.Color.Black;
            this.ctl_is_payroll_deduction.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_is_payroll_deduction.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Left;
            this.ctl_is_payroll_deduction.zz_OriginalDesign = false;
            this.ctl_is_payroll_deduction.zz_ShowNeedsSaveColor = true;
            this.ctl_is_payroll_deduction.CheckChanged += new NewMethod.CheckChangedHandler(this.ctl_is_payroll_deduction_CheckChanged);
            this.ctl_is_payroll_deduction.Load += new System.EventHandler(this.btnDelete_Click);
            // 
            // ctl_payroll_deduction_date
            // 
            this.ctl_payroll_deduction_date.AllowClear = false;
            this.ctl_payroll_deduction_date.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_payroll_deduction_date.Bold = false;
            this.ctl_payroll_deduction_date.Caption = "Payroll Deduction Date";
            this.ctl_payroll_deduction_date.Changed = false;
            this.ctl_payroll_deduction_date.Location = new System.Drawing.Point(409, 74);
            this.ctl_payroll_deduction_date.Name = "ctl_payroll_deduction_date";
            this.ctl_payroll_deduction_date.Size = new System.Drawing.Size(124, 47);
            this.ctl_payroll_deduction_date.SuppressEdit = false;
            this.ctl_payroll_deduction_date.TabIndex = 68;
            this.ctl_payroll_deduction_date.UseParentBackColor = false;
            this.ctl_payroll_deduction_date.Visible = false;
            this.ctl_payroll_deduction_date.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_payroll_deduction_date.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_payroll_deduction_date.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_payroll_deduction_date.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_payroll_deduction_date.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_payroll_deduction_date.zz_OriginalDesign = true;
            this.ctl_payroll_deduction_date.zz_ShowNeedsSaveColor = true;
            this.ctl_payroll_deduction_date.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_payroll_deduction_date.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_payroll_deduction_date.zz_UseGlobalColor = false;
            this.ctl_payroll_deduction_date.zz_UseGlobalFont = false;
            // 
            // frmDeduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 262);
            this.Controls.Add(this.ctl_is_payroll_deduction);
            this.Controls.Add(this.ctl_payroll_deduction_date);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.ctl_exclude_from_profit_calc);
            this.Controls.Add(this.ctl_description);
            this.Controls.Add(this.ctl_include_on_po);
            this.Controls.Add(this.ctl_name);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.ctl_amount);
            this.Controls.Add(this.cmdSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeduction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deduction";
            this.Leave += new System.EventHandler(this.frmDeduction_Leave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdSave;
        private NewMethod.nEdit_Money ctl_amount;
        private NewMethod.nEdit_Boolean ctl_include_on_po;
        private System.Windows.Forms.Button cmdCancel;
        private NewMethod.nEdit_List ctl_name;
        protected NewMethod.nEdit_Memo ctl_description;
        private NewMethod.nEdit_Boolean ctl_exclude_from_profit_calc;
        private System.Windows.Forms.Button btnDelete;
        private NewMethod.nEdit_Boolean ctl_is_payroll_deduction;
        private NewMethod.nEdit_Date ctl_payroll_deduction_date;
    }
}