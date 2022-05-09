namespace Rz5
{
    partial class frmRecallRestore_Company
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecallRestore_Company));
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdSelect = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.chkCheckUnCheckAll = new System.Windows.Forms.CheckBox();
            this.txtSearch = new NewMethod.nEdit_String();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.CheckBoxes = true;
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lv.GridLines = true;
            this.lv.Location = new System.Drawing.Point(12, 27);
            this.lv.MultiSelect = false;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(386, 304);
            this.lv.TabIndex = 1;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Company Name";
            this.columnHeader1.Width = 359;
            // 
            // cmdSelect
            // 
            this.cmdSelect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelect.Location = new System.Drawing.Point(242, 378);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(156, 33);
            this.cmdSelect.TabIndex = 2;
            this.cmdSelect.Text = "Select";
            this.cmdSelect.UseVisualStyleBackColor = true;
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(12, 378);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(156, 33);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // chkCheckUnCheckAll
            // 
            this.chkCheckUnCheckAll.AutoSize = true;
            this.chkCheckUnCheckAll.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCheckUnCheckAll.Location = new System.Drawing.Point(12, 4);
            this.chkCheckUnCheckAll.Name = "chkCheckUnCheckAll";
            this.chkCheckUnCheckAll.Size = new System.Drawing.Size(159, 23);
            this.chkCheckUnCheckAll.TabIndex = 4;
            this.chkCheckUnCheckAll.Text = "Check UnCheck All";
            this.chkCheckUnCheckAll.UseVisualStyleBackColor = true;
            this.chkCheckUnCheckAll.CheckedChanged += new System.EventHandler(this.chkCheckUnCheckAll_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.AllCaps = false;
            this.txtSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtSearch.Bold = false;
            this.txtSearch.Caption = "Company Name";
            this.txtSearch.Changed = false;
            this.txtSearch.IsEmail = false;
            this.txtSearch.IsURL = false;
            this.txtSearch.Location = new System.Drawing.Point(12, 337);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.Size = new System.Drawing.Size(386, 35);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.UseParentBackColor = false;
            this.txtSearch.zz_Enabled = true;
            this.txtSearch.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtSearch.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtSearch.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtSearch.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.txtSearch.zz_OriginalDesign = false;
            this.txtSearch.zz_ShowLinkButton = false;
            this.txtSearch.zz_ShowNeedsSaveColor = false;
            this.txtSearch.zz_Text = "";
            this.txtSearch.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSearch.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtSearch.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.zz_UseGlobalColor = false;
            this.txtSearch.zz_UseGlobalFont = false;
            this.txtSearch.zz_GotKeyUp += new NewMethod.GotKeyUpHandler(this.txtSearch_zz_GotKeyUp);
            // 
            // frmRecallRestore_Company
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 418);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.chkCheckUnCheckAll);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.lv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRecallRestore_Company";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Restore";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button cmdSelect;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.CheckBox chkCheckUnCheckAll;
        private NewMethod.nEdit_String txtSearch;

    }
}