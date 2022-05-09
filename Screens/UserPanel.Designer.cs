namespace Rz5
{
    partial class UserPanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserPanel));
            this.LV = new System.Windows.Forms.ListView();
            this.IMLrg = new System.Windows.Forms.ImageList(this.components);
            this.IM = new System.Windows.Forms.ImageList(this.components);
            this.lvOptions = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblOptionHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LV
            // 
            this.LV.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LV.FullRowSelect = true;
            this.LV.HideSelection = false;
            this.LV.LargeImageList = this.IMLrg;
            this.LV.Location = new System.Drawing.Point(4, 5);
            this.LV.MultiSelect = false;
            this.LV.Name = "LV";
            this.LV.Size = new System.Drawing.Size(330, 319);
            this.LV.SmallImageList = this.IMLrg;
            this.LV.TabIndex = 25;
            this.LV.UseCompatibleStateImageBehavior = false;
            this.LV.View = System.Windows.Forms.View.Tile;
            this.LV.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.LV_ItemSelectionChanged);
            // 
            // IMLrg
            // 
            this.IMLrg.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IMLrg.ImageStream")));
            this.IMLrg.TransparentColor = System.Drawing.Color.Fuchsia;
            this.IMLrg.Images.SetKeyName(0, "Choices.bmp");
            this.IMLrg.Images.SetKeyName(1, "Users.bmp");
            this.IMLrg.Images.SetKeyName(2, "Statistics.bmp");
            this.IMLrg.Images.SetKeyName(3, "Monitors.bmp");
            this.IMLrg.Images.SetKeyName(4, "PrintedForms.bmp");
            this.IMLrg.Images.SetKeyName(5, "SystemManagement.bmp");
            this.IMLrg.Images.SetKeyName(6, "Email.bmp");
            this.IMLrg.Images.SetKeyName(7, "money.bmp");
            // 
            // IM
            // 
            this.IM.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IM.ImageStream")));
            this.IM.TransparentColor = System.Drawing.Color.Fuchsia;
            this.IM.Images.SetKeyName(0, "Users.bmp");
            this.IM.Images.SetKeyName(1, "Summaries.bmp");
            this.IM.Images.SetKeyName(2, "AddressOptions.bmp");
            this.IM.Images.SetKeyName(3, "EmailTemplates.bmp");
            this.IM.Images.SetKeyName(4, "Configure.bmp");
            this.IM.Images.SetKeyName(5, "Screen.bmp");
            this.IM.Images.SetKeyName(6, "AddNewChoiceList.bmp");
            this.IM.Images.SetKeyName(7, "EditList.bmp");
            this.IM.Images.SetKeyName(8, "YourCompanyInformation.bmp");
            this.IM.Images.SetKeyName(9, "EmailBlaster.bmp");
            this.IM.Images.SetKeyName(10, "DatabaseManager.bmp");
            this.IM.Images.SetKeyName(11, "WebUpdate.bmp");
            this.IM.Images.SetKeyName(12, "Design.bmp");
            this.IM.Images.SetKeyName(13, "Import.bmp");
            this.IM.Images.SetKeyName(14, "DutyMonitor.bmp");
            this.IM.Images.SetKeyName(15, "PhoneFaxMonitor.bmp");
            this.IM.Images.SetKeyName(16, "BinSwapper.bmp");
            this.IM.Images.SetKeyName(17, "PictureResizeTool.bmp");
            this.IM.Images.SetKeyName(18, "money.bmp");
            this.IM.Images.SetKeyName(19, "Reports.bmp");
            this.IM.Images.SetKeyName(20, "OrderNumberEditor.bmp");
            this.IM.Images.SetKeyName(21, "CompanyQuestions.bmp");
            // 
            // lvOptions
            // 
            this.lvOptions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvOptions.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvOptions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvOptions.LargeImageList = this.IM;
            this.lvOptions.Location = new System.Drawing.Point(340, 32);
            this.lvOptions.Name = "lvOptions";
            this.lvOptions.Size = new System.Drawing.Size(330, 44);
            this.lvOptions.SmallImageList = this.IM;
            this.lvOptions.TabIndex = 26;
            this.lvOptions.UseCompatibleStateImageBehavior = false;
            this.lvOptions.View = System.Windows.Forms.View.Details;
            this.lvOptions.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvOptions_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 310;
            // 
            // lblOptionHeader
            // 
            this.lblOptionHeader.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptionHeader.Location = new System.Drawing.Point(336, 5);
            this.lblOptionHeader.Name = "lblOptionHeader";
            this.lblOptionHeader.Size = new System.Drawing.Size(330, 24);
            this.lblOptionHeader.TabIndex = 27;
            this.lblOptionHeader.Text = "SELECTED CATEGORY";
            this.lblOptionHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblOptionHeader);
            this.Controls.Add(this.lvOptions);
            this.Controls.Add(this.LV);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserPanel";
            this.Size = new System.Drawing.Size(671, 367);
            this.Resize += new System.EventHandler(this.UserPanel_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LV;
        private System.Windows.Forms.ListView lvOptions;
        private System.Windows.Forms.Label lblOptionHeader;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        protected System.Windows.Forms.ImageList IM;
        protected System.Windows.Forms.ImageList IMLrg;
    }
}
