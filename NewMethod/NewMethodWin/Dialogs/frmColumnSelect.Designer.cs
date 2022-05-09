namespace NewMethod
{
    partial class frmColumnSelect
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
            this.lv = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdOK = new System.Windows.Forms.Button();
            this.xTime = new System.Windows.Forms.Timer(this.components);
            this.tv = new System.Windows.Forms.TreeView();
            this.gbColumn = new System.Windows.Forms.GroupBox();
            this.chkEntryField = new NewMethod.nEdit_Boolean();
            this.chkTranslateEnum = new NewMethod.nEdit_Boolean();
            this.cmdDate = new System.Windows.Forms.Button();
            this.cboFormat = new NewMethod.nEdit_List();
            this.cmdApply = new System.Windows.Forms.Button();
            this.txtCaption = new NewMethod.nEdit_String();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.cmdClass = new System.Windows.Forms.Button();
            this.cmdChoose = new System.Windows.Forms.Button();
            this.cmdDefault = new System.Windows.Forms.Button();
            this.cmdPaste = new System.Windows.Forms.Button();
            this.cmdCopy = new System.Windows.Forms.Button();
            this.chkInhibit = new System.Windows.Forms.CheckBox();
            this.cmdClearImprops = new System.Windows.Forms.Button();
            this.cmdClearAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.alignmentSelection = new System.Windows.Forms.ComboBox();
            this.gbColumn.SuspendLayout();
            this.gbOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.CheckBoxes = true;
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colTag,
            this.colType});
            this.lv.FullRowSelect = true;
            this.lv.Location = new System.Drawing.Point(225, 0);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(360, 441);
            this.lv.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lv.TabIndex = 0;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_ItemChecked);
            this.lv.Click += new System.EventHandler(this.lv_Click);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 112;
            // 
            // colTag
            // 
            this.colTag.Text = "Tag";
            this.colTag.Width = 109;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 64;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(12, 447);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(562, 32);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "&OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // xTime
            // 
            this.xTime.Interval = 500;
            this.xTime.Tick += new System.EventHandler(this.xTime_Tick);
            // 
            // tv
            // 
            this.tv.Location = new System.Drawing.Point(-2, 0);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(221, 441);
            this.tv.TabIndex = 2;
            this.tv.Click += new System.EventHandler(this.tv_Click);
            this.tv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tv_MouseDown);
            // 
            // gbColumn
            // 
            this.gbColumn.Controls.Add(this.alignmentSelection);
            this.gbColumn.Controls.Add(this.label1);
            this.gbColumn.Controls.Add(this.chkEntryField);
            this.gbColumn.Controls.Add(this.chkTranslateEnum);
            this.gbColumn.Controls.Add(this.cmdDate);
            this.gbColumn.Controls.Add(this.cboFormat);
            this.gbColumn.Controls.Add(this.cmdApply);
            this.gbColumn.Controls.Add(this.txtCaption);
            this.gbColumn.Location = new System.Drawing.Point(591, 184);
            this.gbColumn.Name = "gbColumn";
            this.gbColumn.Size = new System.Drawing.Size(258, 220);
            this.gbColumn.TabIndex = 5;
            this.gbColumn.TabStop = false;
            // 
            // chkEntryField
            // 
            this.chkEntryField.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.chkEntryField.Bold = false;
            this.chkEntryField.Caption = "Entry Field Only";
            this.chkEntryField.Changed = false;
            this.chkEntryField.Location = new System.Drawing.Point(151, 109);
            this.chkEntryField.Name = "chkEntryField";
            this.chkEntryField.Size = new System.Drawing.Size(104, 18);
            this.chkEntryField.TabIndex = 6;
            this.chkEntryField.UseParentBackColor = false;
            this.chkEntryField.zz_CheckValue = false;
            this.chkEntryField.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.chkEntryField.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEntryField.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Left;
            this.chkEntryField.zz_OriginalDesign = false;
            this.chkEntryField.zz_ShowNeedsSaveColor = true;
            // 
            // chkTranslateEnum
            // 
            this.chkTranslateEnum.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.chkTranslateEnum.Bold = false;
            this.chkTranslateEnum.Caption = "Translate Enum";
            this.chkTranslateEnum.Changed = false;
            this.chkTranslateEnum.Location = new System.Drawing.Point(155, 126);
            this.chkTranslateEnum.Name = "chkTranslateEnum";
            this.chkTranslateEnum.Size = new System.Drawing.Size(100, 18);
            this.chkTranslateEnum.TabIndex = 5;
            this.chkTranslateEnum.UseParentBackColor = false;
            this.chkTranslateEnum.Visible = false;
            this.chkTranslateEnum.zz_CheckValue = false;
            this.chkTranslateEnum.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.chkTranslateEnum.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTranslateEnum.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Left;
            this.chkTranslateEnum.zz_OriginalDesign = false;
            this.chkTranslateEnum.zz_ShowNeedsSaveColor = true;
            // 
            // cmdDate
            // 
            this.cmdDate.Location = new System.Drawing.Point(212, 183);
            this.cmdDate.Name = "cmdDate";
            this.cmdDate.Size = new System.Drawing.Size(40, 24);
            this.cmdDate.TabIndex = 4;
            this.cmdDate.Text = "Date";
            this.cmdDate.UseVisualStyleBackColor = true;
            this.cmdDate.Click += new System.EventHandler(this.cmdDate_Click);
            // 
            // cboFormat
            // 
            this.cboFormat.AllCaps = false;
            this.cboFormat.AllowEdit = false;
            this.cboFormat.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cboFormat.Bold = false;
            this.cboFormat.Caption = "Format";
            this.cboFormat.Changed = false;
            this.cboFormat.ListName = null;
            this.cboFormat.Location = new System.Drawing.Point(6, 65);
            this.cboFormat.Name = "cboFormat";
            this.cboFormat.SimpleList = null;
            this.cboFormat.Size = new System.Drawing.Size(246, 38);
            this.cboFormat.TabIndex = 3;
            this.cboFormat.UseParentBackColor = false;
            this.cboFormat.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboFormat.zz_GlobalColor = System.Drawing.Color.Black;
            this.cboFormat.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFormat.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cboFormat.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFormat.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.cboFormat.zz_OriginalDesign = false;
            this.cboFormat.zz_ShowNeedsSaveColor = true;
            this.cboFormat.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.cboFormat.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFormat.zz_UseGlobalColor = false;
            this.cboFormat.zz_UseGlobalFont = false;
            // 
            // cmdApply
            // 
            this.cmdApply.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdApply.Location = new System.Drawing.Point(6, 151);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(246, 29);
            this.cmdApply.TabIndex = 2;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // txtCaption
            // 
            this.txtCaption.AllCaps = false;
            this.txtCaption.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCaption.Bold = false;
            this.txtCaption.Caption = "Caption";
            this.txtCaption.Changed = false;
            this.txtCaption.IsEmail = false;
            this.txtCaption.IsURL = false;
            this.txtCaption.Location = new System.Drawing.Point(6, 19);
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.PasswordChar = '\0';
            this.txtCaption.Size = new System.Drawing.Size(246, 36);
            this.txtCaption.TabIndex = 0;
            this.txtCaption.UseParentBackColor = false;
            this.txtCaption.zz_Enabled = true;
            this.txtCaption.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtCaption.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaption.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtCaption.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaption.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.txtCaption.zz_OriginalDesign = false;
            this.txtCaption.zz_ShowLinkButton = false;
            this.txtCaption.zz_ShowNeedsSaveColor = true;
            this.txtCaption.zz_Text = "";
            this.txtCaption.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCaption.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtCaption.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaption.zz_UseGlobalColor = false;
            this.txtCaption.zz_UseGlobalFont = false;
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.cmdClass);
            this.gbOptions.Controls.Add(this.cmdChoose);
            this.gbOptions.Controls.Add(this.cmdDefault);
            this.gbOptions.Controls.Add(this.cmdPaste);
            this.gbOptions.Controls.Add(this.cmdCopy);
            this.gbOptions.Controls.Add(this.chkInhibit);
            this.gbOptions.Controls.Add(this.cmdClearImprops);
            this.gbOptions.Controls.Add(this.cmdClearAll);
            this.gbOptions.Location = new System.Drawing.Point(590, 12);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(259, 166);
            this.gbOptions.TabIndex = 6;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Options";
            // 
            // cmdClass
            // 
            this.cmdClass.Location = new System.Drawing.Point(160, 86);
            this.cmdClass.Name = "cmdClass";
            this.cmdClass.Size = new System.Drawing.Size(93, 20);
            this.cmdClass.TabIndex = 12;
            this.cmdClass.Text = "Class";
            this.cmdClass.UseVisualStyleBackColor = true;
            this.cmdClass.Click += new System.EventHandler(this.cmdClass_Click);
            // 
            // cmdChoose
            // 
            this.cmdChoose.Location = new System.Drawing.Point(160, 63);
            this.cmdChoose.Name = "cmdChoose";
            this.cmdChoose.Size = new System.Drawing.Size(93, 20);
            this.cmdChoose.TabIndex = 11;
            this.cmdChoose.Text = "Choose";
            this.cmdChoose.UseVisualStyleBackColor = true;
            this.cmdChoose.Click += new System.EventHandler(this.cmdChoose_Click);
            // 
            // cmdDefault
            // 
            this.cmdDefault.Location = new System.Drawing.Point(160, 112);
            this.cmdDefault.Name = "cmdDefault";
            this.cmdDefault.Size = new System.Drawing.Size(93, 29);
            this.cmdDefault.TabIndex = 10;
            this.cmdDefault.Text = "Default";
            this.cmdDefault.UseVisualStyleBackColor = true;
            this.cmdDefault.Click += new System.EventHandler(this.cmdDefault_Click);
            // 
            // cmdPaste
            // 
            this.cmdPaste.Location = new System.Drawing.Point(160, 41);
            this.cmdPaste.Name = "cmdPaste";
            this.cmdPaste.Size = new System.Drawing.Size(93, 20);
            this.cmdPaste.TabIndex = 9;
            this.cmdPaste.Text = "Paste";
            this.cmdPaste.UseVisualStyleBackColor = true;
            this.cmdPaste.Click += new System.EventHandler(this.cmdPaste_Click);
            // 
            // cmdCopy
            // 
            this.cmdCopy.Location = new System.Drawing.Point(160, 19);
            this.cmdCopy.Name = "cmdCopy";
            this.cmdCopy.Size = new System.Drawing.Size(93, 20);
            this.cmdCopy.TabIndex = 8;
            this.cmdCopy.Text = "Copy";
            this.cmdCopy.UseVisualStyleBackColor = true;
            this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
            // 
            // chkInhibit
            // 
            this.chkInhibit.AutoSize = true;
            this.chkInhibit.Location = new System.Drawing.Point(24, 89);
            this.chkInhibit.Name = "chkInhibit";
            this.chkInhibit.Size = new System.Drawing.Size(97, 17);
            this.chkInhibit.TabIndex = 7;
            this.chkInhibit.Text = "Inhibit Updates";
            this.chkInhibit.UseVisualStyleBackColor = true;
            // 
            // cmdClearImprops
            // 
            this.cmdClearImprops.Location = new System.Drawing.Point(10, 54);
            this.cmdClearImprops.Name = "cmdClearImprops";
            this.cmdClearImprops.Size = new System.Drawing.Size(144, 29);
            this.cmdClearImprops.TabIndex = 6;
            this.cmdClearImprops.Text = "Clear Improps";
            this.cmdClearImprops.UseVisualStyleBackColor = true;
            this.cmdClearImprops.Click += new System.EventHandler(this.cmdClearImprops_Click);
            // 
            // cmdClearAll
            // 
            this.cmdClearAll.Location = new System.Drawing.Point(10, 19);
            this.cmdClearAll.Name = "cmdClearAll";
            this.cmdClearAll.Size = new System.Drawing.Size(144, 29);
            this.cmdClearAll.TabIndex = 5;
            this.cmdClearAll.Text = "Clear All";
            this.cmdClearAll.UseVisualStyleBackColor = true;
            this.cmdClearAll.Click += new System.EventHandler(this.cmdClearAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Alignment";
            // 
            // alignmentSelection
            // 
            this.alignmentSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.alignmentSelection.FormattingEnabled = true;
            this.alignmentSelection.Items.AddRange(new object[] {
            "Left",
            "Center",
            "Right"});
            this.alignmentSelection.Location = new System.Drawing.Point(7, 124);
            this.alignmentSelection.Name = "alignmentSelection";
            this.alignmentSelection.Size = new System.Drawing.Size(112, 21);
            this.alignmentSelection.TabIndex = 8;
            // 
            // frmColumnSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 481);
            this.Controls.Add(this.gbOptions);
            this.Controls.Add(this.gbColumn);
            this.Controls.Add(this.tv);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.lv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmColumnSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Column Selection";
            this.gbColumn.ResumeLayout(false);
            this.gbColumn.PerformLayout();
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colTag;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Timer xTime;
        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.GroupBox gbColumn;
        private nEdit_String txtCaption;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.Button cmdClearImprops;
        private System.Windows.Forms.Button cmdClearAll;
        private System.Windows.Forms.Button cmdApply;
        private nEdit_List cboFormat;
        private System.Windows.Forms.CheckBox chkInhibit;
        private System.Windows.Forms.Button cmdDate;
        private System.Windows.Forms.Button cmdPaste;
        private System.Windows.Forms.Button cmdCopy;
        private System.Windows.Forms.Button cmdDefault;
        private nEdit_Boolean chkTranslateEnum;
        private System.Windows.Forms.Button cmdChoose;
        private nEdit_Boolean chkEntryField;
        private System.Windows.Forms.Button cmdClass;
        private System.Windows.Forms.ComboBox alignmentSelection;
        private System.Windows.Forms.Label label1;
    }
}