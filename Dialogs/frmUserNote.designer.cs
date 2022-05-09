using NewMethod;

namespace Rz5
{
    partial class frmUserNote
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
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ctl_notetext = new NewMethod.nEdit_Memo();
            this.ctl_isclosed = new NewMethod.nEdit_Boolean();
            this.ctl_shouldpopup = new NewMethod.nEdit_Boolean();
            this.ctlDate = new NewMethod.nEdit_Date();
            this.user_for = new NewMethod.nEdit_User();
            this.user_by = new NewMethod.nEdit_User();
            this.ctlTime = new NewMethod.nEdit_String();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lv.Location = new System.Drawing.Point(14, 352);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(463, 111);
            this.lv.TabIndex = 6;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
            this.lv.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Linked Information";
            this.columnHeader1.Width = 453;
            // 
            // ctl_notetext
            // 
            this.ctl_notetext.BackColor = System.Drawing.Color.White;
            this.ctl_notetext.Bold = false;
            this.ctl_notetext.Caption = "Note";
            this.ctl_notetext.Changed = false;
            this.ctl_notetext.Location = new System.Drawing.Point(16, 152);
            this.ctl_notetext.Name = "ctl_notetext";
            this.ctl_notetext.Size = new System.Drawing.Size(462, 189);
            this.ctl_notetext.TabIndex = 5;
            this.ctl_notetext.UseParentBackColor = true;
            this.ctl_notetext.zz_Enabled = true;
            this.ctl_notetext.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_notetext.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_notetext.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_notetext.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_notetext.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_notetext.zz_OriginalDesign = true;
            this.ctl_notetext.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ctl_notetext.zz_ShowNeedsSaveColor = true;
            this.ctl_notetext.zz_Text = "";
            this.ctl_notetext.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_notetext.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_notetext.zz_UseGlobalColor = false;
            this.ctl_notetext.zz_UseGlobalFont = false;
            // 
            // ctl_isclosed
            // 
            this.ctl_isclosed.BackColor = System.Drawing.Color.White;
            this.ctl_isclosed.Bold = false;
            this.ctl_isclosed.Caption = "Closed?";
            this.ctl_isclosed.Changed = false;
            this.ctl_isclosed.Location = new System.Drawing.Point(284, 130);
            this.ctl_isclosed.Name = "ctl_isclosed";
            this.ctl_isclosed.Size = new System.Drawing.Size(64, 18);
            this.ctl_isclosed.TabIndex = 4;
            this.ctl_isclosed.UseParentBackColor = true;
            this.ctl_isclosed.zz_CheckValue = false;
            this.ctl_isclosed.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_isclosed.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_isclosed.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_isclosed.zz_OriginalDesign = false;
            this.ctl_isclosed.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_shouldpopup
            // 
            this.ctl_shouldpopup.BackColor = System.Drawing.Color.White;
            this.ctl_shouldpopup.Bold = false;
            this.ctl_shouldpopup.Caption = "Pop Up?";
            this.ctl_shouldpopup.Changed = false;
            this.ctl_shouldpopup.Location = new System.Drawing.Point(284, 99);
            this.ctl_shouldpopup.Name = "ctl_shouldpopup";
            this.ctl_shouldpopup.Size = new System.Drawing.Size(68, 18);
            this.ctl_shouldpopup.TabIndex = 3;
            this.ctl_shouldpopup.UseParentBackColor = true;
            this.ctl_shouldpopup.zz_CheckValue = false;
            this.ctl_shouldpopup.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shouldpopup.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_shouldpopup.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_shouldpopup.zz_OriginalDesign = false;
            this.ctl_shouldpopup.zz_ShowNeedsSaveColor = true;
            // 
            // ctlDate
            // 
            this.ctlDate.AllowClear = false;
            this.ctlDate.BackColor = System.Drawing.Color.White;
            this.ctlDate.Bold = false;
            this.ctlDate.Caption = "Date";
            this.ctlDate.Changed = false;
            this.ctlDate.Location = new System.Drawing.Point(286, 12);
            this.ctlDate.Name = "ctlDate";
            this.ctlDate.Size = new System.Drawing.Size(182, 53);
            this.ctlDate.SuppressEdit = false;
            this.ctlDate.TabIndex = 2;
            this.ctlDate.UseParentBackColor = true;
            this.ctlDate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlDate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlDate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlDate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctlDate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctlDate.zz_OriginalDesign = true;
            this.ctlDate.zz_ShowNeedsSaveColor = true;
            this.ctlDate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlDate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlDate.zz_UseGlobalColor = false;
            this.ctlDate.zz_UseGlobalFont = false;
            // 
            // user_for
            // 
            this.user_for.AllowChange = true;
            this.user_for.AllowClear = false;
            this.user_for.AllowNew = false;
            this.user_for.AllowView = false;
            this.user_for.BackColor = System.Drawing.Color.White;
            this.user_for.Bold = false;
            this.user_for.Caption = "To";
            this.user_for.Changed = false;
            this.user_for.Location = new System.Drawing.Point(10, 79);
            this.user_for.Name = "user_for";
            this.user_for.Size = new System.Drawing.Size(245, 67);
            this.user_for.TabIndex = 1;
            this.user_for.UseParentBackColor = true;
            this.user_for.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.user_for.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            // 
            // user_by
            // 
            this.user_by.AllowChange = true;
            this.user_by.AllowClear = false;
            this.user_by.AllowNew = false;
            this.user_by.AllowView = false;
            this.user_by.BackColor = System.Drawing.Color.White;
            this.user_by.Bold = false;
            this.user_by.Caption = "From";
            this.user_by.Changed = false;
            this.user_by.Enabled = false;
            this.user_by.Location = new System.Drawing.Point(10, 6);
            this.user_by.Name = "user_by";
            this.user_by.Size = new System.Drawing.Size(245, 67);
            this.user_by.TabIndex = 0;
            this.user_by.UseParentBackColor = true;
            this.user_by.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.user_by.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            // 
            // ctlTime
            // 
            this.ctlTime.AllCaps = false;
            this.ctlTime.BackColor = System.Drawing.Color.White;
            this.ctlTime.Bold = false;
            this.ctlTime.Caption = "Time";
            this.ctlTime.Changed = false;
            this.ctlTime.IsEmail = false;
            this.ctlTime.IsURL = false;
            this.ctlTime.Location = new System.Drawing.Point(286, 60);
            this.ctlTime.Name = "ctlTime";
            this.ctlTime.PasswordChar = '\0';
            this.ctlTime.Size = new System.Drawing.Size(119, 41);
            this.ctlTime.TabIndex = 8;
            this.ctlTime.UseParentBackColor = true;
            this.ctlTime.zz_Enabled = true;
            this.ctlTime.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlTime.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlTime.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlTime.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctlTime.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlTime.zz_OriginalDesign = true;
            this.ctlTime.zz_ShowLinkButton = false;
            this.ctlTime.zz_ShowNeedsSaveColor = true;
            this.ctlTime.zz_Text = "";
            this.ctlTime.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlTime.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlTime.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlTime.zz_UseGlobalColor = false;
            this.ctlTime.zz_UseGlobalFont = false;
            // 
            // frmUserNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 480);
            this.Controls.Add(this.ctlTime);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.ctl_notetext);
            this.Controls.Add(this.ctl_isclosed);
            this.Controls.Add(this.ctl_shouldpopup);
            this.Controls.Add(this.ctlDate);
            this.Controls.Add(this.user_for);
            this.Controls.Add(this.user_by);
            this.MaximizeBox = false;
            this.Name = "frmUserNote";
            this.Text = "Note";
            this.ResumeLayout(false);

        }

        #endregion

        private nEdit_User user_by;
        private nEdit_User user_for;
        private nEdit_Date ctlDate;
        private nEdit_Boolean ctl_shouldpopup;
        private nEdit_Boolean ctl_isclosed;
        private nEdit_Memo ctl_notetext;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private nEdit_String ctlTime;
    }
}