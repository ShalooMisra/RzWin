namespace Rz5.Views
{
    partial class view_calendarentry
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
            this.ctl_entrydate = new NewMethod.nEdit_Date();
            this.ctl_entryname = new NewMethod.nEdit_String();
            this.ctl_is_holiday = new NewMethod.nEdit_Boolean();
            this.ctl_entrydescription = new NewMethod.nEdit_Memo();
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(445, 0);
            this.xActions.Size = new System.Drawing.Size(192, 330);
            // 
            // ctl_entrydate
            // 
            this.ctl_entrydate.AllowClear = false;
            this.ctl_entrydate.BackColor = System.Drawing.Color.White;
            this.ctl_entrydate.Bold = false;
            this.ctl_entrydate.Caption = "Date";
            this.ctl_entrydate.Changed = false;
            this.ctl_entrydate.Location = new System.Drawing.Point(3, 3);
            this.ctl_entrydate.Name = "ctl_entrydate";
            this.ctl_entrydate.Size = new System.Drawing.Size(186, 41);
            this.ctl_entrydate.SuppressEdit = false;
            this.ctl_entrydate.TabIndex = 9;
            this.ctl_entrydate.UseParentBackColor = true;
            this.ctl_entrydate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_entrydate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_entrydate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_entrydate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_entrydate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_entrydate.zz_OriginalDesign = false;
            this.ctl_entrydate.zz_ShowNeedsSaveColor = true;
            this.ctl_entrydate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_entrydate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_entrydate.zz_UseGlobalColor = false;
            this.ctl_entrydate.zz_UseGlobalFont = false;
            // 
            // ctl_entryname
            // 
            this.ctl_entryname.AllCaps = false;
            this.ctl_entryname.BackColor = System.Drawing.Color.White;
            this.ctl_entryname.Bold = false;
            this.ctl_entryname.Caption = "Event Name";
            this.ctl_entryname.Changed = false;
            this.ctl_entryname.IsEmail = false;
            this.ctl_entryname.IsURL = false;
            this.ctl_entryname.Location = new System.Drawing.Point(3, 50);
            this.ctl_entryname.Name = "ctl_entryname";
            this.ctl_entryname.PasswordChar = '\0';
            this.ctl_entryname.Size = new System.Drawing.Size(421, 35);
            this.ctl_entryname.TabIndex = 10;
            this.ctl_entryname.UseParentBackColor = true;
            this.ctl_entryname.zz_Enabled = true;
            this.ctl_entryname.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_entryname.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_entryname.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_entryname.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_entryname.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_entryname.zz_OriginalDesign = false;
            this.ctl_entryname.zz_ShowLinkButton = false;
            this.ctl_entryname.zz_ShowNeedsSaveColor = true;
            this.ctl_entryname.zz_Text = "";
            this.ctl_entryname.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_entryname.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_entryname.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_entryname.zz_UseGlobalColor = false;
            this.ctl_entryname.zz_UseGlobalFont = false;
            // 
            // ctl_is_holiday
            // 
            this.ctl_is_holiday.BackColor = System.Drawing.Color.White;
            this.ctl_is_holiday.Bold = false;
            this.ctl_is_holiday.Caption = "Holiday";
            this.ctl_is_holiday.Changed = false;
            this.ctl_is_holiday.Location = new System.Drawing.Point(223, 14);
            this.ctl_is_holiday.Name = "ctl_is_holiday";
            this.ctl_is_holiday.Size = new System.Drawing.Size(61, 18);
            this.ctl_is_holiday.TabIndex = 11;
            this.ctl_is_holiday.UseParentBackColor = true;
            this.ctl_is_holiday.zz_CheckValue = false;
            this.ctl_is_holiday.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_holiday.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_is_holiday.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_holiday.zz_OriginalDesign = false;
            this.ctl_is_holiday.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_entrydescription
            // 
            this.ctl_entrydescription.BackColor = System.Drawing.Color.White;
            this.ctl_entrydescription.Bold = false;
            this.ctl_entrydescription.Caption = "Description";
            this.ctl_entrydescription.Changed = false;
            this.ctl_entrydescription.DateLines = false;
            this.ctl_entrydescription.Location = new System.Drawing.Point(3, 91);
            this.ctl_entrydescription.Name = "ctl_entrydescription";
            this.ctl_entrydescription.Size = new System.Drawing.Size(421, 154);
            this.ctl_entrydescription.TabIndex = 12;
            this.ctl_entrydescription.UseParentBackColor = true;
            this.ctl_entrydescription.zz_Enabled = true;
            this.ctl_entrydescription.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_entrydescription.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_entrydescription.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_entrydescription.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_entrydescription.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_entrydescription.zz_OriginalDesign = false;
            this.ctl_entrydescription.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_entrydescription.zz_ShowNeedsSaveColor = true;
            this.ctl_entrydescription.zz_Text = "";
            this.ctl_entrydescription.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_entrydescription.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_entrydescription.zz_UseGlobalColor = false;
            this.ctl_entrydescription.zz_UseGlobalFont = false;
            // 
            // view_calendarentry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctl_is_holiday);
            this.Controls.Add(this.ctl_entrydescription);
            this.Controls.Add(this.ctl_entryname);
            this.Controls.Add(this.ctl_entrydate);
            this.Name = "view_calendarentry";
            this.Size = new System.Drawing.Size(637, 330);
            this.Controls.SetChildIndex(this.ctl_entrydate, 0);
            this.Controls.SetChildIndex(this.ctl_entryname, 0);
            this.Controls.SetChildIndex(this.ctl_entrydescription, 0);
            this.Controls.SetChildIndex(this.ctl_is_holiday, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nEdit_Date ctl_entrydate;
        private NewMethod.nEdit_String ctl_entryname;
        private NewMethod.nEdit_Boolean ctl_is_holiday;
        private NewMethod.nEdit_Memo ctl_entrydescription;
    }
}
