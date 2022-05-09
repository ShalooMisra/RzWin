using NewMethod;

namespace Rz5
{
    partial class view_emailtemplate
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
            this.components = new System.ComponentModel.Container();
            this.ctl_emailbody = new NewMethod.nEdit_Memo();
            this.ctl_emailfooter = new NewMethod.nEdit_Memo();
            this.lv = new NewMethod.nList();
            this.ctl_templatename = new NewMethod.nEdit_String();
            this.ctl_class_name = new NewMethod.nEdit_String();
            this.ctl_ordertype = new NewMethod.nEdit_List();
            this.ctl_subjectstring = new NewMethod.nEdit_String();
            this.ts = new System.Windows.Forms.TabControl();
            this.pageTemplate = new System.Windows.Forms.TabPage();
            this.ctl_exclude_details = new NewMethod.nEdit_Boolean();
            this.pagePreview = new System.Windows.Forms.TabPage();
            this.wbPreview = new ToolsWin.Browser();
            this.ctl_is_text = new NewMethod.nEdit_Boolean();
            this.ts.SuspendLayout();
            this.pageTemplate.SuspendLayout();
            this.pagePreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(835, 0);
            this.xActions.Size = new System.Drawing.Size(192, 748);
            // 
            // ctl_emailbody
            // 
            this.ctl_emailbody.BackColor = System.Drawing.Color.White;
            this.ctl_emailbody.Bold = false;
            this.ctl_emailbody.Caption = "Header";
            this.ctl_emailbody.Changed = false;
            this.ctl_emailbody.DateLines = false;
            this.ctl_emailbody.Location = new System.Drawing.Point(6, 122);
            this.ctl_emailbody.Name = "ctl_emailbody";
            this.ctl_emailbody.Size = new System.Drawing.Size(353, 103);
            this.ctl_emailbody.TabIndex = 8;
            this.ctl_emailbody.UseParentBackColor = true;
            this.ctl_emailbody.zz_Enabled = true;
            this.ctl_emailbody.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_emailbody.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_emailbody.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_emailbody.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_emailbody.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_emailbody.zz_OriginalDesign = false;
            this.ctl_emailbody.zz_ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ctl_emailbody.zz_ShowNeedsSaveColor = true;
            this.ctl_emailbody.zz_Text = "";
            this.ctl_emailbody.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_emailbody.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_emailbody.zz_UseGlobalColor = false;
            this.ctl_emailbody.zz_UseGlobalFont = false;
            // 
            // ctl_emailfooter
            // 
            this.ctl_emailfooter.BackColor = System.Drawing.Color.White;
            this.ctl_emailfooter.Bold = false;
            this.ctl_emailfooter.Caption = "Footer";
            this.ctl_emailfooter.Changed = false;
            this.ctl_emailfooter.DateLines = false;
            this.ctl_emailfooter.Location = new System.Drawing.Point(6, 323);
            this.ctl_emailfooter.Name = "ctl_emailfooter";
            this.ctl_emailfooter.Size = new System.Drawing.Size(353, 84);
            this.ctl_emailfooter.TabIndex = 9;
            this.ctl_emailfooter.UseParentBackColor = true;
            this.ctl_emailfooter.zz_Enabled = true;
            this.ctl_emailfooter.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_emailfooter.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_emailfooter.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_emailfooter.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_emailfooter.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_emailfooter.zz_OriginalDesign = false;
            this.ctl_emailfooter.zz_ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ctl_emailfooter.zz_ShowNeedsSaveColor = true;
            this.ctl_emailfooter.zz_Text = "";
            this.ctl_emailfooter.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_emailfooter.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_emailfooter.zz_UseGlobalColor = false;
            this.ctl_emailfooter.zz_UseGlobalFont = false;
            // 
            // lv
            // 
            this.lv.AddCaption = "Add New";
            this.lv.AllowActions = true;
            this.lv.AllowAdd = false;
            this.lv.AllowDelete = true;
            this.lv.AllowDrop = true;
            this.lv.Caption = "";
            this.lv.CurrentTemplate = null;
            this.lv.ExtraClassInfo = "";
            this.lv.Location = new System.Drawing.Point(6, 227);
            this.lv.MultiSelect = true;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(353, 92);
            this.lv.SuppressSelectionChanged = false;
            this.lv.TabIndex = 10;
            this.lv.zz_OpenColumnMenu = false;
            this.lv.zz_ShowAutoRefresh = true;
            this.lv.zz_ShowUnlimited = true;
            // 
            // ctl_templatename
            // 
            this.ctl_templatename.AllCaps = false;
            this.ctl_templatename.BackColor = System.Drawing.Color.White;
            this.ctl_templatename.Bold = false;
            this.ctl_templatename.Caption = "Template Name";
            this.ctl_templatename.Changed = false;
            this.ctl_templatename.IsEmail = false;
            this.ctl_templatename.IsURL = false;
            this.ctl_templatename.Location = new System.Drawing.Point(6, 6);
            this.ctl_templatename.Name = "ctl_templatename";
            this.ctl_templatename.PasswordChar = '\0';
            this.ctl_templatename.Size = new System.Drawing.Size(353, 39);
            this.ctl_templatename.TabIndex = 11;
            this.ctl_templatename.UseParentBackColor = true;
            this.ctl_templatename.zz_Enabled = true;
            this.ctl_templatename.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_templatename.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_templatename.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_templatename.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_templatename.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_templatename.zz_OriginalDesign = false;
            this.ctl_templatename.zz_ShowLinkButton = false;
            this.ctl_templatename.zz_ShowNeedsSaveColor = true;
            this.ctl_templatename.zz_Text = "";
            this.ctl_templatename.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_templatename.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_templatename.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_templatename.zz_UseGlobalColor = false;
            this.ctl_templatename.zz_UseGlobalFont = false;
            // 
            // ctl_class_name
            // 
            this.ctl_class_name.AllCaps = false;
            this.ctl_class_name.BackColor = System.Drawing.Color.White;
            this.ctl_class_name.Bold = false;
            this.ctl_class_name.Caption = "Class";
            this.ctl_class_name.Changed = false;
            this.ctl_class_name.IsEmail = false;
            this.ctl_class_name.IsURL = false;
            this.ctl_class_name.Location = new System.Drawing.Point(6, 44);
            this.ctl_class_name.Name = "ctl_class_name";
            this.ctl_class_name.PasswordChar = '\0';
            this.ctl_class_name.Size = new System.Drawing.Size(173, 39);
            this.ctl_class_name.TabIndex = 12;
            this.ctl_class_name.UseParentBackColor = true;
            this.ctl_class_name.zz_Enabled = true;
            this.ctl_class_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_class_name.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_class_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_class_name.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_class_name.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_class_name.zz_OriginalDesign = false;
            this.ctl_class_name.zz_ShowLinkButton = false;
            this.ctl_class_name.zz_ShowNeedsSaveColor = true;
            this.ctl_class_name.zz_Text = "";
            this.ctl_class_name.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_class_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_class_name.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_class_name.zz_UseGlobalColor = false;
            this.ctl_class_name.zz_UseGlobalFont = false;
            // 
            // ctl_ordertype
            // 
            this.ctl_ordertype.AllCaps = false;
            this.ctl_ordertype.AllowEdit = false;
            this.ctl_ordertype.BackColor = System.Drawing.Color.White;
            this.ctl_ordertype.Bold = false;
            this.ctl_ordertype.Caption = "Order Type";
            this.ctl_ordertype.Changed = false;
            this.ctl_ordertype.ListName = null;
            this.ctl_ordertype.Location = new System.Drawing.Point(185, 44);
            this.ctl_ordertype.Name = "ctl_ordertype";
            this.ctl_ordertype.SimpleList = "Quote|Sales|Purchase|Invoice|RMA|VendRMA";
            this.ctl_ordertype.Size = new System.Drawing.Size(174, 40);
            this.ctl_ordertype.TabIndex = 13;
            this.ctl_ordertype.UseParentBackColor = true;
            this.ctl_ordertype.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_ordertype.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ordertype.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_ordertype.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ordertype.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_ordertype.zz_OriginalDesign = false;
            this.ctl_ordertype.zz_ShowNeedsSaveColor = true;
            this.ctl_ordertype.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_ordertype.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ordertype.zz_UseGlobalColor = false;
            this.ctl_ordertype.zz_UseGlobalFont = false;
            // 
            // ctl_subjectstring
            // 
            this.ctl_subjectstring.AllCaps = false;
            this.ctl_subjectstring.BackColor = System.Drawing.Color.White;
            this.ctl_subjectstring.Bold = false;
            this.ctl_subjectstring.Caption = "Subject";
            this.ctl_subjectstring.Changed = false;
            this.ctl_subjectstring.IsEmail = false;
            this.ctl_subjectstring.IsURL = false;
            this.ctl_subjectstring.Location = new System.Drawing.Point(6, 83);
            this.ctl_subjectstring.Name = "ctl_subjectstring";
            this.ctl_subjectstring.PasswordChar = '\0';
            this.ctl_subjectstring.Size = new System.Drawing.Size(353, 39);
            this.ctl_subjectstring.TabIndex = 15;
            this.ctl_subjectstring.UseParentBackColor = true;
            this.ctl_subjectstring.zz_Enabled = true;
            this.ctl_subjectstring.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_subjectstring.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_subjectstring.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_subjectstring.zz_LabelFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_subjectstring.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_subjectstring.zz_OriginalDesign = false;
            this.ctl_subjectstring.zz_ShowLinkButton = false;
            this.ctl_subjectstring.zz_ShowNeedsSaveColor = true;
            this.ctl_subjectstring.zz_Text = "";
            this.ctl_subjectstring.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_subjectstring.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_subjectstring.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_subjectstring.zz_UseGlobalColor = false;
            this.ctl_subjectstring.zz_UseGlobalFont = false;
            // 
            // ts
            // 
            this.ts.Controls.Add(this.pageTemplate);
            this.ts.Controls.Add(this.pagePreview);
            this.ts.Location = new System.Drawing.Point(8, 8);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(812, 732);
            this.ts.TabIndex = 37;
            this.ts.SelectedIndexChanged += new System.EventHandler(this.ts_SelectedIndexChanged);
            // 
            // pageTemplate
            // 
            this.pageTemplate.Controls.Add(this.ctl_is_text);
            this.pageTemplate.Controls.Add(this.ctl_exclude_details);
            this.pageTemplate.Controls.Add(this.ctl_templatename);
            this.pageTemplate.Controls.Add(this.lv);
            this.pageTemplate.Controls.Add(this.ctl_emailfooter);
            this.pageTemplate.Controls.Add(this.ctl_emailbody);
            this.pageTemplate.Controls.Add(this.ctl_class_name);
            this.pageTemplate.Controls.Add(this.ctl_ordertype);
            this.pageTemplate.Controls.Add(this.ctl_subjectstring);
            this.pageTemplate.Location = new System.Drawing.Point(4, 22);
            this.pageTemplate.Name = "pageTemplate";
            this.pageTemplate.Padding = new System.Windows.Forms.Padding(3);
            this.pageTemplate.Size = new System.Drawing.Size(804, 706);
            this.pageTemplate.TabIndex = 0;
            this.pageTemplate.Text = "Template";
            this.pageTemplate.UseVisualStyleBackColor = true;
            // 
            // ctl_exclude_details
            // 
            this.ctl_exclude_details.BackColor = System.Drawing.Color.Transparent;
            this.ctl_exclude_details.Bold = false;
            this.ctl_exclude_details.Caption = "Exclude Details";
            this.ctl_exclude_details.Changed = false;
            this.ctl_exclude_details.Location = new System.Drawing.Point(231, 3);
            this.ctl_exclude_details.Name = "ctl_exclude_details";
            this.ctl_exclude_details.Size = new System.Drawing.Size(99, 18);
            this.ctl_exclude_details.TabIndex = 16;
            this.ctl_exclude_details.UseParentBackColor = true;
            this.ctl_exclude_details.zz_CheckValue = false;
            this.ctl_exclude_details.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_exclude_details.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_exclude_details.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_exclude_details.zz_OriginalDesign = false;
            this.ctl_exclude_details.zz_ShowNeedsSaveColor = true;
            // 
            // pagePreview
            // 
            this.pagePreview.Controls.Add(this.wbPreview);
            this.pagePreview.Location = new System.Drawing.Point(4, 22);
            this.pagePreview.Name = "pagePreview";
            this.pagePreview.Padding = new System.Windows.Forms.Padding(3);
            this.pagePreview.Size = new System.Drawing.Size(804, 706);
            this.pagePreview.TabIndex = 1;
            this.pagePreview.Text = "Preview";
            this.pagePreview.UseVisualStyleBackColor = true;
            // 
            // wbPreview
            // 
            this.wbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbPreview.Location = new System.Drawing.Point(3, 3);
            this.wbPreview.Name = "wbPreview";
            this.wbPreview.ShowControls = false;
            this.wbPreview.Silent = false;
            this.wbPreview.Size = new System.Drawing.Size(798, 700);
            this.wbPreview.TabIndex = 0;
            // 
            // ctl_is_text
            // 
            this.ctl_is_text.BackColor = System.Drawing.Color.Transparent;
            this.ctl_is_text.Bold = false;
            this.ctl_is_text.Caption = "Is Text";
            this.ctl_is_text.Changed = false;
            this.ctl_is_text.Location = new System.Drawing.Point(167, 3);
            this.ctl_is_text.Name = "ctl_is_text";
            this.ctl_is_text.Size = new System.Drawing.Size(58, 18);
            this.ctl_is_text.TabIndex = 17;
            this.ctl_is_text.UseParentBackColor = true;
            this.ctl_is_text.zz_CheckValue = false;
            this.ctl_is_text.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_text.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_is_text.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_text.zz_OriginalDesign = false;
            this.ctl_is_text.zz_ShowNeedsSaveColor = true;
            // 
            // view_emailtemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ts);
            this.Name = "view_emailtemplate";
            this.Size = new System.Drawing.Size(1027, 748);
            this.Controls.SetChildIndex(this.ts, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.ts.ResumeLayout(false);
            this.pageTemplate.ResumeLayout(false);
            this.pagePreview.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nEdit_Memo ctl_emailbody;
        private NewMethod.nEdit_Memo ctl_emailfooter;
        private NewMethod.nList lv;
        private nEdit_String ctl_templatename;
        private nEdit_String ctl_class_name;
        private nEdit_List ctl_ordertype;
        private nEdit_String ctl_subjectstring;
        private System.Windows.Forms.TabControl ts;
        private System.Windows.Forms.TabPage pageTemplate;
        private System.Windows.Forms.TabPage pagePreview;
        private ToolsWin.Browser wbPreview;
        private nEdit_Boolean ctl_exclude_details;
        private nEdit_Boolean ctl_is_text;
    }
}
