using NewMethod;

namespace Rz5
{
    partial class frmChooseEmailTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChooseEmailTemplate));
            this.cmdSelect = new System.Windows.Forms.Button();
            this.IM24 = new System.Windows.Forms.ImageList(this.components);
            this.cmdCancel = new System.Windows.Forms.Button();
            this.split = new System.Windows.Forms.SplitContainer();
            this.split2 = new System.Windows.Forms.SplitContainer();
            this.lst = new NewMethod.nList();
            this.lvAttachments = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wb = new ToolsWin.BrowserPlain();
            this.cmdAttachments = new System.Windows.Forms.Button();
            this.cmdBlankEmail = new System.Windows.Forms.Button();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.split2.Panel1.SuspendLayout();
            this.split2.Panel2.SuspendLayout();
            this.split2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSelect
            // 
            this.cmdSelect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSelect.ImageKey = "Tick.bmp";
            this.cmdSelect.ImageList = this.IM24;
            this.cmdSelect.Location = new System.Drawing.Point(12, 516);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(160, 45);
            this.cmdSelect.TabIndex = 1;
            this.cmdSelect.Text = "Select";
            this.cmdSelect.UseVisualStyleBackColor = true;
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // IM24
            // 
            this.IM24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IM24.ImageStream")));
            this.IM24.TransparentColor = System.Drawing.Color.Fuchsia;
            this.IM24.Images.SetKeyName(0, "attachment.bmp");
            this.IM24.Images.SetKeyName(1, "delete.bmp");
            this.IM24.Images.SetKeyName(2, "Tick.bmp");
            this.IM24.Images.SetKeyName(3, "mail.bmp");
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.ImageKey = "delete.bmp";
            this.cmdCancel.ImageList = this.IM24;
            this.cmdCancel.Location = new System.Drawing.Point(615, 515);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(160, 45);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // split
            // 
            this.split.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.split.Location = new System.Drawing.Point(12, 12);
            this.split.Name = "split";
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.split2);
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.wb);
            this.split.Size = new System.Drawing.Size(763, 498);
            this.split.SplitterDistance = 318;
            this.split.TabIndex = 6;
            // 
            // split2
            // 
            this.split2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.split2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split2.Location = new System.Drawing.Point(0, 0);
            this.split2.Name = "split2";
            this.split2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split2.Panel1
            // 
            this.split2.Panel1.Controls.Add(this.lst);
            // 
            // split2.Panel2
            // 
            this.split2.Panel2.Controls.Add(this.lvAttachments);
            this.split2.Size = new System.Drawing.Size(318, 498);
            this.split2.SplitterDistance = 341;
            this.split2.TabIndex = 0;
            // 
            // lst
            // 
            this.lst.AddCaption = "Add New";
            this.lst.AllowActions = true;
            this.lst.AllowAdd = false;
            this.lst.AllowDelete = true;
            this.lst.AllowDeleteAlways = false;
            this.lst.AllowDrop = true;
            this.lst.AlternateConnection = null;
            this.lst.Caption = "";
            this.lst.CurrentTemplate = null;
            this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst.ExtraClassInfo = "";
            this.lst.Location = new System.Drawing.Point(0, 0);
            this.lst.MultiSelect = true;
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(316, 339);
            this.lst.SuppressSelectionChanged = false;
            this.lst.TabIndex = 5;
            this.lst.zz_OpenColumnMenu = false;
            this.lst.zz_ShowAutoRefresh = true;
            this.lst.zz_ShowUnlimited = true;
            this.lst.AboutToThrow += new Core.ShowHandler(this.lst_AboutToThrow);
            this.lst.ObjectClicked += new NewMethod.ObjectClickHandler(this.lst_ObjectClicked);
            // 
            // lvAttachments
            // 
            this.lvAttachments.CheckBoxes = true;
            this.lvAttachments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAttachments.FullRowSelect = true;
            this.lvAttachments.GridLines = true;
            this.lvAttachments.HideSelection = false;
            this.lvAttachments.Location = new System.Drawing.Point(0, 0);
            this.lvAttachments.Name = "lvAttachments";
            this.lvAttachments.Size = new System.Drawing.Size(316, 151);
            this.lvAttachments.TabIndex = 10;
            this.lvAttachments.UseCompatibleStateImageBehavior = false;
            this.lvAttachments.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Attachments";
            this.columnHeader1.Width = 288;
            // 
            // wb
            // 
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(0, 0);
            this.wb.Name = "wb";
            this.wb.ShowControls = false;
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(439, 496);
            this.wb.TabIndex = 6;
            // 
            // cmdAttachments
            // 
            this.cmdAttachments.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAttachments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAttachments.ImageKey = "attachment.bmp";
            this.cmdAttachments.ImageList = this.IM24;
            this.cmdAttachments.Location = new System.Drawing.Point(219, 516);
            this.cmdAttachments.Name = "cmdAttachments";
            this.cmdAttachments.Size = new System.Drawing.Size(160, 45);
            this.cmdAttachments.TabIndex = 7;
            this.cmdAttachments.Text = "    Attachments";
            this.cmdAttachments.UseVisualStyleBackColor = true;
            this.cmdAttachments.Click += new System.EventHandler(this.cmdAttachments_Click);
            // 
            // cmdBlankEmail
            // 
            this.cmdBlankEmail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBlankEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBlankEmail.ImageKey = "mail.bmp";
            this.cmdBlankEmail.ImageList = this.IM24;
            this.cmdBlankEmail.Location = new System.Drawing.Point(418, 515);
            this.cmdBlankEmail.Name = "cmdBlankEmail";
            this.cmdBlankEmail.Size = new System.Drawing.Size(160, 45);
            this.cmdBlankEmail.TabIndex = 8;
            this.cmdBlankEmail.Text = "Blank Email";
            this.cmdBlankEmail.UseVisualStyleBackColor = true;
            this.cmdBlankEmail.Click += new System.EventHandler(this.cmdBlankEmail_Click);
            // 
            // frmChooseEmailTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 566);
            this.Controls.Add(this.cmdBlankEmail);
            this.Controls.Add(this.cmdAttachments);
            this.Controls.Add(this.split);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmChooseEmailTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email Templates";
            this.Resize += new System.EventHandler(this.frmChooseEmailTemplate_Resize);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            this.split.ResumeLayout(false);
            this.split2.Panel1.ResumeLayout(false);
            this.split2.Panel2.ResumeLayout(false);
            this.split2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdSelect;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.SplitContainer split;
        private nList lst;
        private ToolsWin.BrowserPlain wb;
        private System.Windows.Forms.ListView lvAttachments;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.SplitContainer split2;
        private System.Windows.Forms.ImageList IM24;
        private System.Windows.Forms.Button cmdAttachments;
        private System.Windows.Forms.Button cmdBlankEmail;
    }
}