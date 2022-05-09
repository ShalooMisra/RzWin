namespace Rz5.Win.Controls
{
    partial class LineProfit
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
            if (Disposing)
                InitUn();

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
            this.label1 = new System.Windows.Forms.Label();
            this.lblGP = new System.Windows.Forms.Label();
            this.lblDeductions = new System.Windows.Forms.Label();
            this.lblCaption = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRMA = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNet = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pTotals = new System.Windows.Forms.Panel();
            this.pDeduction = new System.Windows.Forms.Panel();
            this.ctl_exclude_from_profit_calc = new NewMethod.nEdit_Boolean();
            this.ctl_is_payroll_deduction = new NewMethod.nEdit_Boolean();
            this.ctl_include_on_po = new NewMethod.nEdit_Boolean();
            this.ctlDeductionName = new NewMethod.nEdit_List();
            this.ctldescription = new NewMethod.nEdit_Memo();
            this.cmdOk = new System.Windows.Forms.Button();
            this.ctlDeductionAmount = new NewMethod.nEdit_Money();
            this.lvDeductions = new NewMethod.nList();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pTotals.SuspendLayout();
            this.pDeduction.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(148, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gross Profit:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblGP
            // 
            this.lblGP.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGP.Location = new System.Drawing.Point(297, 7);
            this.lblGP.Name = "lblGP";
            this.lblGP.Size = new System.Drawing.Size(175, 26);
            this.lblGP.TabIndex = 2;
            this.lblGP.Text = "$123,456,789.00";
            this.lblGP.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDeductions
            // 
            this.lblDeductions.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeductions.Location = new System.Drawing.Point(297, 33);
            this.lblDeductions.Name = "lblDeductions";
            this.lblDeductions.Size = new System.Drawing.Size(175, 26);
            this.lblDeductions.TabIndex = 4;
            this.lblDeductions.Text = "$123,456,789.00";
            this.lblDeductions.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.Color.Gray;
            this.lblCaption.Location = new System.Drawing.Point(7, -1);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(114, 26);
            this.lblCaption.TabIndex = 3;
            this.lblCaption.Text = "Deductions:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(184, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 26);
            this.label4.TabIndex = 6;
            this.label4.Text = "Deductions:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(153, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 26);
            this.label5.TabIndex = 8;
            this.label5.Text = "RMA:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblRMA
            // 
            this.lblRMA.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMA.Location = new System.Drawing.Point(297, 60);
            this.lblRMA.Name = "lblRMA";
            this.lblRMA.Size = new System.Drawing.Size(175, 26);
            this.lblRMA.TabIndex = 7;
            this.lblRMA.Text = "$123,456,789.00";
            this.lblRMA.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(158, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 26);
            this.label6.TabIndex = 10;
            this.label6.Text = "Net Profit:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblNet
            // 
            this.lblNet.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNet.Location = new System.Drawing.Point(297, 93);
            this.lblNet.Name = "lblNet";
            this.lblNet.Size = new System.Drawing.Size(175, 26);
            this.lblNet.TabIndex = 9;
            this.lblNet.Text = "$123,456,789.00";
            this.lblNet.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox1.Location = new System.Drawing.Point(316, 87);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 3);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pTotals
            // 
            this.pTotals.Controls.Add(this.lblGP);
            this.pTotals.Controls.Add(this.pictureBox1);
            this.pTotals.Controls.Add(this.label1);
            this.pTotals.Controls.Add(this.label6);
            this.pTotals.Controls.Add(this.lblDeductions);
            this.pTotals.Controls.Add(this.lblNet);
            this.pTotals.Controls.Add(this.label4);
            this.pTotals.Controls.Add(this.label5);
            this.pTotals.Controls.Add(this.lblRMA);
            this.pTotals.Location = new System.Drawing.Point(17, 336);
            this.pTotals.Name = "pTotals";
            this.pTotals.Size = new System.Drawing.Size(477, 129);
            this.pTotals.TabIndex = 12;
            // 
            // pDeduction
            // 
            this.pDeduction.BackColor = System.Drawing.Color.Silver;
            this.pDeduction.Controls.Add(this.ctl_exclude_from_profit_calc);
            this.pDeduction.Controls.Add(this.ctl_is_payroll_deduction);
            this.pDeduction.Controls.Add(this.ctl_include_on_po);
            this.pDeduction.Controls.Add(this.ctlDeductionName);
            this.pDeduction.Controls.Add(this.ctldescription);
            this.pDeduction.Controls.Add(this.cmdOk);
            this.pDeduction.Controls.Add(this.ctlDeductionAmount);
            this.pDeduction.Location = new System.Drawing.Point(14, 176);
            this.pDeduction.Name = "pDeduction";
            this.pDeduction.Size = new System.Drawing.Size(511, 157);
            this.pDeduction.TabIndex = 13;
            this.pDeduction.Visible = false;
            // 
            // ctl_exclude_from_profit_calc
            // 
            this.ctl_exclude_from_profit_calc.BackColor = System.Drawing.Color.Transparent;
            this.ctl_exclude_from_profit_calc.Bold = false;
            this.ctl_exclude_from_profit_calc.Caption = "Exclude from profit";
            this.ctl_exclude_from_profit_calc.Changed = false;
            this.ctl_exclude_from_profit_calc.Location = new System.Drawing.Point(108, 46);
            this.ctl_exclude_from_profit_calc.Name = "ctl_exclude_from_profit_calc";
            this.ctl_exclude_from_profit_calc.Size = new System.Drawing.Size(113, 18);
            this.ctl_exclude_from_profit_calc.TabIndex = 65;
            this.ctl_exclude_from_profit_calc.UseParentBackColor = false;
            this.ctl_exclude_from_profit_calc.zz_CheckValue = false;
            this.ctl_exclude_from_profit_calc.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_exclude_from_profit_calc.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_exclude_from_profit_calc.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_exclude_from_profit_calc.zz_OriginalDesign = false;
            this.ctl_exclude_from_profit_calc.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_is_payroll_deduction
            // 
            this.ctl_is_payroll_deduction.BackColor = System.Drawing.Color.Transparent;
            this.ctl_is_payroll_deduction.Bold = false;
            this.ctl_is_payroll_deduction.Caption = "Payroll Deduction";
            this.ctl_is_payroll_deduction.Changed = false;
            this.ctl_is_payroll_deduction.Location = new System.Drawing.Point(394, 46);
            this.ctl_is_payroll_deduction.Name = "ctl_is_payroll_deduction";
            this.ctl_is_payroll_deduction.Size = new System.Drawing.Size(109, 18);
            this.ctl_is_payroll_deduction.TabIndex = 64;
            this.ctl_is_payroll_deduction.UseParentBackColor = false;
            this.ctl_is_payroll_deduction.zz_CheckValue = false;
            this.ctl_is_payroll_deduction.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_payroll_deduction.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_is_payroll_deduction.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_payroll_deduction.zz_OriginalDesign = false;
            this.ctl_is_payroll_deduction.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_include_on_po
            // 
            this.ctl_include_on_po.BackColor = System.Drawing.Color.Transparent;
            this.ctl_include_on_po.Bold = false;
            this.ctl_include_on_po.Caption = "Include on PO";
            this.ctl_include_on_po.Changed = false;
            this.ctl_include_on_po.Location = new System.Drawing.Point(8, 46);
            this.ctl_include_on_po.Name = "ctl_include_on_po";
            this.ctl_include_on_po.Size = new System.Drawing.Size(94, 18);
            this.ctl_include_on_po.TabIndex = 63;
            this.ctl_include_on_po.UseParentBackColor = false;
            this.ctl_include_on_po.Visible = false;
            this.ctl_include_on_po.zz_CheckValue = false;
            this.ctl_include_on_po.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_include_on_po.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_include_on_po.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_include_on_po.zz_OriginalDesign = false;
            this.ctl_include_on_po.zz_ShowNeedsSaveColor = true;
            // 
            // ctlDeductionName
            // 
            this.ctlDeductionName.AllCaps = false;
            this.ctlDeductionName.AllowEdit = false;
            this.ctlDeductionName.BackColor = System.Drawing.Color.Transparent;
            this.ctlDeductionName.Bold = false;
            this.ctlDeductionName.Caption = "Deduction Type:";
            this.ctlDeductionName.Changed = false;
            this.ctlDeductionName.ListName = "deduction_type";
            this.ctlDeductionName.Location = new System.Drawing.Point(8, 3);
            this.ctlDeductionName.Name = "ctlDeductionName";
            this.ctlDeductionName.SimpleList = null;
            this.ctlDeductionName.Size = new System.Drawing.Size(236, 46);
            this.ctlDeductionName.TabIndex = 62;
            this.ctlDeductionName.UseParentBackColor = false;
            this.ctlDeductionName.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctlDeductionName.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlDeductionName.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlDeductionName.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlDeductionName.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlDeductionName.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctlDeductionName.zz_OriginalDesign = true;
            this.ctlDeductionName.zz_ShowNeedsSaveColor = true;
            this.ctlDeductionName.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlDeductionName.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlDeductionName.zz_UseGlobalColor = false;
            this.ctlDeductionName.zz_UseGlobalFont = false;
            // 
            // ctldescription
            // 
            this.ctldescription.BackColor = System.Drawing.Color.Silver;
            this.ctldescription.Bold = false;
            this.ctldescription.Caption = "Description";
            this.ctldescription.Changed = false;
            this.ctldescription.DateLines = false;
            this.ctldescription.Location = new System.Drawing.Point(8, 73);
            this.ctldescription.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctldescription.Name = "ctldescription";
            this.ctldescription.Size = new System.Drawing.Size(495, 78);
            this.ctldescription.TabIndex = 61;
            this.ctldescription.UseParentBackColor = true;
            this.ctldescription.zz_Enabled = true;
            this.ctldescription.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctldescription.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctldescription.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctldescription.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctldescription.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctldescription.zz_OriginalDesign = false;
            this.ctldescription.zz_ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ctldescription.zz_ShowNeedsSaveColor = true;
            this.ctldescription.zz_Text = "";
            this.ctldescription.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctldescription.zz_TextFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctldescription.zz_UseGlobalColor = false;
            this.ctldescription.zz_UseGlobalFont = false;
            // 
            // cmdOk
            // 
            this.cmdOk.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOk.Location = new System.Drawing.Point(447, 10);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(56, 36);
            this.cmdOk.TabIndex = 60;
            this.cmdOk.Text = "OK";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // ctlDeductionAmount
            // 
            this.ctlDeductionAmount.BackColor = System.Drawing.Color.Transparent;
            this.ctlDeductionAmount.Bold = false;
            this.ctlDeductionAmount.Caption = "Deduction Amount";
            this.ctlDeductionAmount.Changed = false;
            this.ctlDeductionAmount.EditCaption = false;
            this.ctlDeductionAmount.FullDecimal = false;
            this.ctlDeductionAmount.Location = new System.Drawing.Point(307, 3);
            this.ctlDeductionAmount.Name = "ctlDeductionAmount";
            this.ctlDeductionAmount.RoundNearestCent = false;
            this.ctlDeductionAmount.Size = new System.Drawing.Size(126, 44);
            this.ctlDeductionAmount.TabIndex = 59;
            this.ctlDeductionAmount.UseParentBackColor = true;
            this.ctlDeductionAmount.zz_Enabled = true;
            this.ctlDeductionAmount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlDeductionAmount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlDeductionAmount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlDeductionAmount.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlDeductionAmount.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctlDeductionAmount.zz_OriginalDesign = false;
            this.ctlDeductionAmount.zz_ShowErrorColor = true;
            this.ctlDeductionAmount.zz_ShowNeedsSaveColor = true;
            this.ctlDeductionAmount.zz_Text = "";
            this.ctlDeductionAmount.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctlDeductionAmount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlDeductionAmount.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlDeductionAmount.zz_UseGlobalColor = false;
            this.ctlDeductionAmount.zz_UseGlobalFont = false;
            // 
            // lvDeductions
            // 
            this.lvDeductions.AddCaption = "Add New";
            this.lvDeductions.AllowActions = true;
            this.lvDeductions.AllowAdd = false;
            this.lvDeductions.AllowDelete = true;
            this.lvDeductions.AllowDeleteAlways = false;
            this.lvDeductions.AllowDrop = true;
            this.lvDeductions.AllowOnlyOpenDelete = false;
            this.lvDeductions.AlternateConnection = null;
            this.lvDeductions.BackColor = System.Drawing.Color.White;
            this.lvDeductions.Caption = "";
            this.lvDeductions.CurrentTemplate = null;
            this.lvDeductions.ExtraClassInfo = "";
            this.lvDeductions.Location = new System.Drawing.Point(14, 30);
            this.lvDeductions.MultiSelect = true;
            this.lvDeductions.Name = "lvDeductions";
            this.lvDeductions.Size = new System.Drawing.Size(511, 131);
            this.lvDeductions.SuppressSelectionChanged = false;
            this.lvDeductions.TabIndex = 5;
            this.lvDeductions.zz_OpenColumnMenu = false;
            this.lvDeductions.zz_OrderLineType = "";
            this.lvDeductions.zz_ShowAutoRefresh = true;
            this.lvDeductions.zz_ShowUnlimited = true;
            this.lvDeductions.AboutToThrow += new Core.ShowHandler(this.lvDeductions_AboutToThrow);
            this.lvDeductions.AboutToAdd += new NewMethod.AddHandler(this.lvDeductions_AboutToAdd);
            this.lvDeductions.AboutToAction += new NewMethod.ActionHandler(this.lvDeductions_AboutToAction);
            this.lvDeductions.AboutToDelete += new NewMethod.ActionHandler(this.lvDeductions_AboutToDelete);
            this.lvDeductions.FinishedAction += new NewMethod.ActionHandler(this.lvDeductions_FinishedAction);
            this.lvDeductions.Leave += new System.EventHandler(this.lvDeductions_Leave);
            // 
            // LineProfit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pDeduction);
            this.Controls.Add(this.pTotals);
            this.Controls.Add(this.lvDeductions);
            this.Controls.Add(this.lblCaption);
            this.Name = "LineProfit";
            this.Size = new System.Drawing.Size(549, 470);
            this.Resize += new System.EventHandler(this.LineProfit_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pTotals.ResumeLayout(false);
            this.pDeduction.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGP;
        private System.Windows.Forms.Label lblDeductions;
        private System.Windows.Forms.Label lblCaption;
        private NewMethod.nList lvDeductions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRMA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNet;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pTotals;
        private System.Windows.Forms.Panel pDeduction;
        private System.Windows.Forms.Button cmdOk;
        private NewMethod.nEdit_Money ctlDeductionAmount;
        protected NewMethod.nEdit_Memo ctldescription;
        private NewMethod.nEdit_List ctlDeductionName;
        private NewMethod.nEdit_Boolean ctl_include_on_po;
        private NewMethod.nEdit_Boolean ctl_is_payroll_deduction;
        private NewMethod.nEdit_Boolean ctl_exclude_from_profit_calc;

    }
}
