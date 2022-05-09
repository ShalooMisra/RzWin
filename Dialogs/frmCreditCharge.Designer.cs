namespace Rz5
{
    partial class frmCreditCharge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreditCharge));
            this.optCredit = new System.Windows.Forms.RadioButton();
            this.optCharge = new System.Windows.Forms.RadioButton();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cbxDeductProfit = new System.Windows.Forms.CheckBox();
            this.ctl_notes = new NewMethod.nEdit_Memo();
            this.ctl_ordhit_name = new NewMethod.nEdit_List();
            this.ctl_hit_amount = new NewMethod.nEdit_Money();
            this.SuspendLayout();
            // 
            // optCredit
            // 
            this.optCredit.AutoSize = true;
            this.optCredit.Enabled = false;
            this.optCredit.Location = new System.Drawing.Point(221, 12);
            this.optCredit.Name = "optCredit";
            this.optCredit.Size = new System.Drawing.Size(52, 17);
            this.optCredit.TabIndex = 40;
            this.optCredit.Text = "Credit";
            this.optCredit.UseVisualStyleBackColor = true;
            // 
            // optCharge
            // 
            this.optCharge.AutoSize = true;
            this.optCharge.Enabled = false;
            this.optCharge.Location = new System.Drawing.Point(144, 12);
            this.optCharge.Name = "optCharge";
            this.optCharge.Size = new System.Drawing.Size(59, 17);
            this.optCharge.TabIndex = 39;
            this.optCharge.Text = "Charge";
            this.optCharge.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(13, 174);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(180, 23);
            this.cmdCancel.TabIndex = 41;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(227, 174);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(180, 23);
            this.cmdAdd.TabIndex = 51;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cbxDeductProfit
            // 
            this.cbxDeductProfit.AutoSize = true;
            this.cbxDeductProfit.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbxDeductProfit.Location = new System.Drawing.Point(340, 40);
            this.cbxDeductProfit.Name = "cbxDeductProfit";
            this.cbxDeductProfit.Size = new System.Drawing.Size(79, 31);
            this.cbxDeductProfit.TabIndex = 53;
            this.cbxDeductProfit.Text = "Deduct Profit?";
            this.cbxDeductProfit.UseVisualStyleBackColor = true;
            this.cbxDeductProfit.Visible = false;
            // 
            // ctl_notes
            // 
            this.ctl_notes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_notes.Bold = false;
            this.ctl_notes.Caption = "Notes / Details";
            this.ctl_notes.Changed = false;
            this.ctl_notes.DateLines = false;
            this.ctl_notes.Location = new System.Drawing.Point(10, 77);
            this.ctl_notes.Name = "ctl_notes";
            this.ctl_notes.Size = new System.Drawing.Size(397, 91);
            this.ctl_notes.TabIndex = 52;
            this.ctl_notes.UseParentBackColor = false;
            this.ctl_notes.zz_Enabled = true;
            this.ctl_notes.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_notes.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_notes.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_notes.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_notes.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_notes.zz_OriginalDesign = true;
            this.ctl_notes.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_notes.zz_ShowNeedsSaveColor = true;
            this.ctl_notes.zz_Text = "";
            this.ctl_notes.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_notes.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_notes.zz_UseGlobalColor = false;
            this.ctl_notes.zz_UseGlobalFont = false;
            // 
            // ctl_ordhit_name
            // 
            this.ctl_ordhit_name.AllCaps = false;
            this.ctl_ordhit_name.AllowEdit = false;
            this.ctl_ordhit_name.BackColor = System.Drawing.Color.Transparent;
            this.ctl_ordhit_name.Bold = false;
            this.ctl_ordhit_name.Caption = "Category";
            this.ctl_ordhit_name.Changed = false;
            this.ctl_ordhit_name.ListName = "charge_credit_captions";
            this.ctl_ordhit_name.Location = new System.Drawing.Point(10, 33);
            this.ctl_ordhit_name.Margin = new System.Windows.Forms.Padding(4);
            this.ctl_ordhit_name.Name = "ctl_ordhit_name";
            this.ctl_ordhit_name.SimpleList = null;
            this.ctl_ordhit_name.Size = new System.Drawing.Size(186, 38);
            this.ctl_ordhit_name.TabIndex = 50;
            this.ctl_ordhit_name.UseParentBackColor = false;
            this.ctl_ordhit_name.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctl_ordhit_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_ordhit_name.zz_GlobalFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ordhit_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_ordhit_name.zz_LabelFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ordhit_name.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_ordhit_name.zz_OriginalDesign = false;
            this.ctl_ordhit_name.zz_ShowNeedsSaveColor = true;
            this.ctl_ordhit_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_ordhit_name.zz_TextFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ordhit_name.zz_UseGlobalColor = false;
            this.ctl_ordhit_name.zz_UseGlobalFont = false;
            this.ctl_ordhit_name.SelectionChanged += new NewMethod.nEdit_List.SelectionChangedHandler(this.ctl_ordhit_name_SelectionChanged);
            // 
            // ctl_hit_amount
            // 
            this.ctl_hit_amount.BackColor = System.Drawing.Color.Transparent;
            this.ctl_hit_amount.Bold = false;
            this.ctl_hit_amount.Caption = "Amount";
            this.ctl_hit_amount.Changed = false;
            this.ctl_hit_amount.EditCaption = false;
            this.ctl_hit_amount.FullDecimal = false;
            this.ctl_hit_amount.Location = new System.Drawing.Point(221, 36);
            this.ctl_hit_amount.Name = "ctl_hit_amount";
            this.ctl_hit_amount.RoundNearestCent = false;
            this.ctl_hit_amount.Size = new System.Drawing.Size(113, 35);
            this.ctl_hit_amount.TabIndex = 41;
            this.ctl_hit_amount.UseParentBackColor = false;
            this.ctl_hit_amount.zz_Enabled = true;
            this.ctl_hit_amount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_hit_amount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_hit_amount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_hit_amount.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_hit_amount.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_hit_amount.zz_OriginalDesign = false;
            this.ctl_hit_amount.zz_ShowErrorColor = true;
            this.ctl_hit_amount.zz_ShowNeedsSaveColor = true;
            this.ctl_hit_amount.zz_Text = "";
            this.ctl_hit_amount.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_hit_amount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_hit_amount.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_hit_amount.zz_UseGlobalColor = false;
            this.ctl_hit_amount.zz_UseGlobalFont = false;
            // 
            // frmCreditCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 232);
            this.Controls.Add(this.cbxDeductProfit);
            this.Controls.Add(this.ctl_notes);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.ctl_ordhit_name);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.ctl_hit_amount);
            this.Controls.Add(this.optCredit);
            this.Controls.Add(this.optCharge);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCreditCharge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Charges/Credit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NewMethod.nEdit_List ctl_ordhit_name;
        private NewMethod.nEdit_Money ctl_hit_amount;
        private System.Windows.Forms.RadioButton optCredit;
        private System.Windows.Forms.RadioButton optCharge;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdAdd;
        private NewMethod.nEdit_Memo ctl_notes;
        private System.Windows.Forms.CheckBox cbxDeductProfit;
    }
}