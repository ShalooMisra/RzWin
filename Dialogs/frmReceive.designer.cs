using System.Threading;
using Tools.Database;

namespace Rz5
{
    partial class frmReceive
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
            if (disposing)
            {
                try
                {
                    foreach (Thread t in WatchThreads)
                    {
                        try
                        {
                            t.Abort();
                        }
                        catch { }
                    }
                }
                catch { }
            }

            if (disposing && (components != null))
            {
                CompleteDispose();
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
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.gbPO = new System.Windows.Forms.GroupBox();
            this.lblDetailDetail = new System.Windows.Forms.Label();
            this.lblPODetail = new System.Windows.Forms.Label();
            this.gbSale = new System.Windows.Forms.GroupBox();
            this.lblSaleDetail = new System.Windows.Forms.Label();
            this.gbInventory = new System.Windows.Forms.GroupBox();
            this.lblInventoryDetail = new System.Windows.Forms.Label();
            this.gbReceive = new System.Windows.Forms.GroupBox();
            this.ctlQuantity = new NewMethod.nEdit_Number();
            this.gbPictures = new System.Windows.Forms.GroupBox();
            this.lblLoadPics = new System.Windows.Forms.LinkLabel();
            this.lvPics = new System.Windows.Forms.ListView();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.gbNewPicture = new System.Windows.Forms.GroupBox();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.pbNew = new System.Windows.Forms.PictureBox();
            this.lvNew = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fsw = new System.IO.FileSystemWatcher();
            this.fsw2 = new System.IO.FileSystemWatcher();
            this.pStandard = new System.Windows.Forms.Panel();
            this.pRight = new System.Windows.Forms.Panel();
            this.gbPO.SuspendLayout();
            this.gbSale.SuspendLayout();
            this.gbInventory.SuspendLayout();
            this.gbReceive.SuspendLayout();
            this.gbPictures.SuspendLayout();
            this.gbNewPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsw2)).BeginInit();
            this.pStandard.SuspendLayout();
            this.pRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(92, 418);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(141, 64);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "&OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(0, 418);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(89, 64);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // gbPO
            // 
            this.gbPO.BackColor = System.Drawing.Color.White;
            this.gbPO.Controls.Add(this.lblDetailDetail);
            this.gbPO.Controls.Add(this.lblPODetail);
            this.gbPO.Location = new System.Drawing.Point(5, 6);
            this.gbPO.Name = "gbPO";
            this.gbPO.Size = new System.Drawing.Size(330, 60);
            this.gbPO.TabIndex = 3;
            this.gbPO.TabStop = false;
            this.gbPO.Text = "Purchase Order Information";
            // 
            // lblDetailDetail
            // 
            this.lblDetailDetail.Location = new System.Drawing.Point(171, 14);
            this.lblDetailDetail.Name = "lblDetailDetail";
            this.lblDetailDetail.Size = new System.Drawing.Size(144, 41);
            this.lblDetailDetail.TabIndex = 1;
            this.lblDetailDetail.Text = "<detail detail>";
            // 
            // lblPODetail
            // 
            this.lblPODetail.Location = new System.Drawing.Point(7, 14);
            this.lblPODetail.Name = "lblPODetail";
            this.lblPODetail.Size = new System.Drawing.Size(145, 41);
            this.lblPODetail.TabIndex = 0;
            this.lblPODetail.Text = "<po detail>";
            // 
            // gbSale
            // 
            this.gbSale.BackColor = System.Drawing.Color.White;
            this.gbSale.Controls.Add(this.lblSaleDetail);
            this.gbSale.Location = new System.Drawing.Point(341, 6);
            this.gbSale.Name = "gbSale";
            this.gbSale.Size = new System.Drawing.Size(169, 60);
            this.gbSale.TabIndex = 4;
            this.gbSale.TabStop = false;
            this.gbSale.Text = "Sale Information";
            // 
            // lblSaleDetail
            // 
            this.lblSaleDetail.Location = new System.Drawing.Point(6, 14);
            this.lblSaleDetail.Name = "lblSaleDetail";
            this.lblSaleDetail.Size = new System.Drawing.Size(157, 35);
            this.lblSaleDetail.TabIndex = 2;
            this.lblSaleDetail.Text = "<sale detail>";
            // 
            // gbInventory
            // 
            this.gbInventory.BackColor = System.Drawing.Color.White;
            this.gbInventory.Controls.Add(this.lblInventoryDetail);
            this.gbInventory.Location = new System.Drawing.Point(514, 6);
            this.gbInventory.Name = "gbInventory";
            this.gbInventory.Size = new System.Drawing.Size(169, 60);
            this.gbInventory.TabIndex = 5;
            this.gbInventory.TabStop = false;
            this.gbInventory.Text = "Inventory Information";
            // 
            // lblInventoryDetail
            // 
            this.lblInventoryDetail.Location = new System.Drawing.Point(7, 16);
            this.lblInventoryDetail.Name = "lblInventoryDetail";
            this.lblInventoryDetail.Size = new System.Drawing.Size(144, 42);
            this.lblInventoryDetail.TabIndex = 1;
            this.lblInventoryDetail.Text = "<inventory detail>";
            // 
            // gbReceive
            // 
            this.gbReceive.BackColor = System.Drawing.Color.White;
            this.gbReceive.Controls.Add(this.ctlQuantity);
            this.gbReceive.Location = new System.Drawing.Point(686, 6);
            this.gbReceive.Name = "gbReceive";
            this.gbReceive.Size = new System.Drawing.Size(169, 60);
            this.gbReceive.TabIndex = 6;
            this.gbReceive.TabStop = false;
            this.gbReceive.Text = "This Receive";
            this.gbReceive.Visible = false;
            // 
            // ctlQuantity
            // 
            this.ctlQuantity.BackColor = System.Drawing.Color.White;
            this.ctlQuantity.Bold = true;
            this.ctlQuantity.Caption = "Quantity Received";
            this.ctlQuantity.Changed = false;
            this.ctlQuantity.CurrentType = FieldType.Unknown;
            this.ctlQuantity.Location = new System.Drawing.Point(28, 11);
            this.ctlQuantity.Name = "ctlQuantity";
            this.ctlQuantity.Size = new System.Drawing.Size(127, 42);
            this.ctlQuantity.TabIndex = 0;
            this.ctlQuantity.UseParentBackColor = true;
            this.ctlQuantity.zz_Enabled = true;
            this.ctlQuantity.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlQuantity.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlQuantity.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlQuantity.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctlQuantity.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctlQuantity.zz_OriginalDesign = true;
            this.ctlQuantity.zz_ShowErrorColor = true;
            this.ctlQuantity.zz_ShowNeedsSaveColor = true;
            this.ctlQuantity.zz_Text = "";
            this.ctlQuantity.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctlQuantity.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlQuantity.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlQuantity.zz_UseGlobalColor = false;
            this.ctlQuantity.zz_UseGlobalFont = false;
            this.ctlQuantity.DataChanged += new NewMethod.ChangeHandler(this.ctlQuantity_DataChanged);
            // 
            // gbPictures
            // 
            this.gbPictures.Controls.Add(this.lblLoadPics);
            this.gbPictures.Controls.Add(this.lvPics);
            this.gbPictures.Location = new System.Drawing.Point(3, 3);
            this.gbPictures.Name = "gbPictures";
            this.gbPictures.Size = new System.Drawing.Size(230, 242);
            this.gbPictures.TabIndex = 7;
            this.gbPictures.TabStop = false;
            this.gbPictures.Text = "Pictures";
            // 
            // lblLoadPics
            // 
            this.lblLoadPics.AutoSize = true;
            this.lblLoadPics.Location = new System.Drawing.Point(196, -1);
            this.lblLoadPics.Name = "lblLoadPics";
            this.lblLoadPics.Size = new System.Drawing.Size(27, 13);
            this.lblLoadPics.TabIndex = 1;
            this.lblLoadPics.TabStop = true;
            this.lblLoadPics.Text = "load";
            this.lblLoadPics.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLoadPics_LinkClicked);
            // 
            // lvPics
            // 
            this.lvPics.LargeImageList = this.il;
            this.lvPics.Location = new System.Drawing.Point(9, 14);
            this.lvPics.Name = "lvPics";
            this.lvPics.Size = new System.Drawing.Size(218, 222);
            this.lvPics.TabIndex = 0;
            this.lvPics.UseCompatibleStateImageBehavior = false;
            this.lvPics.DoubleClick += new System.EventHandler(this.lvPics_DoubleClick);
            // 
            // il
            // 
            this.il.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.il.ImageSize = new System.Drawing.Size(32, 32);
            this.il.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // gbNewPicture
            // 
            this.gbNewPicture.Controls.Add(this.cmdBrowse);
            this.gbNewPicture.Controls.Add(this.cmdAdd);
            this.gbNewPicture.Controls.Add(this.pbNew);
            this.gbNewPicture.Controls.Add(this.lvNew);
            this.gbNewPicture.Location = new System.Drawing.Point(0, 251);
            this.gbNewPicture.Name = "gbNewPicture";
            this.gbNewPicture.Size = new System.Drawing.Size(233, 165);
            this.gbNewPicture.TabIndex = 8;
            this.gbNewPicture.TabStop = false;
            this.gbNewPicture.Text = "New File";
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Location = new System.Drawing.Point(171, 135);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(57, 20);
            this.cmdBrowse.TabIndex = 3;
            this.cmdBrowse.Text = "Browse";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(171, 109);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(57, 20);
            this.cmdAdd.TabIndex = 2;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // pbNew
            // 
            this.pbNew.BackColor = System.Drawing.Color.White;
            this.pbNew.Location = new System.Drawing.Point(172, 52);
            this.pbNew.Name = "pbNew";
            this.pbNew.Size = new System.Drawing.Size(56, 54);
            this.pbNew.TabIndex = 1;
            this.pbNew.TabStop = false;
            // 
            // lvNew
            // 
            this.lvNew.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvNew.FullRowSelect = true;
            this.lvNew.Location = new System.Drawing.Point(9, 16);
            this.lvNew.Name = "lvNew";
            this.lvNew.Size = new System.Drawing.Size(157, 143);
            this.lvNew.TabIndex = 0;
            this.lvNew.UseCompatibleStateImageBehavior = false;
            this.lvNew.View = System.Windows.Forms.View.Details;
            this.lvNew.Click += new System.EventHandler(this.lvNew_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File";
            this.columnHeader1.Width = 114;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Path";
            this.columnHeader2.Width = 78;
            // 
            // fsw
            // 
            this.fsw.EnableRaisingEvents = true;
            this.fsw.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this.fsw.SynchronizingObject = this;
            this.fsw.Changed += new System.IO.FileSystemEventHandler(this.fsw_Changed);
            // 
            // fsw2
            // 
            this.fsw2.EnableRaisingEvents = true;
            this.fsw2.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this.fsw2.SynchronizingObject = this;
            this.fsw2.Changed += new System.IO.FileSystemEventHandler(this.fsw2_Changed);
            // 
            // pStandard
            // 
            this.pStandard.Controls.Add(this.pRight);
            this.pStandard.Location = new System.Drawing.Point(5, 67);
            this.pStandard.Name = "pStandard";
            this.pStandard.Size = new System.Drawing.Size(858, 490);
            this.pStandard.TabIndex = 9;
            // 
            // pRight
            // 
            this.pRight.Controls.Add(this.cmdOK);
            this.pRight.Controls.Add(this.cmdCancel);
            this.pRight.Controls.Add(this.gbPictures);
            this.pRight.Controls.Add(this.gbNewPicture);
            this.pRight.Location = new System.Drawing.Point(174, 5);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(238, 482);
            this.pRight.TabIndex = 10;
            // 
            // frmReceive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(871, 560);
            this.Controls.Add(this.gbReceive);
            this.Controls.Add(this.gbInventory);
            this.Controls.Add(this.gbSale);
            this.Controls.Add(this.gbPO);
            this.Controls.Add(this.pStandard);
            this.Name = "frmReceive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receive Inventory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReceive_FormClosing);
            this.Resize += new System.EventHandler(this.frmReceive_Resize);
            this.gbPO.ResumeLayout(false);
            this.gbSale.ResumeLayout(false);
            this.gbInventory.ResumeLayout(false);
            this.gbReceive.ResumeLayout(false);
            this.gbPictures.ResumeLayout(false);
            this.gbPictures.PerformLayout();
            this.gbNewPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsw2)).EndInit();
            this.pStandard.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.GroupBox gbPO;
        private System.Windows.Forms.Label lblDetailDetail;
        private System.Windows.Forms.Label lblPODetail;
        private System.Windows.Forms.GroupBox gbSale;
        private System.Windows.Forms.GroupBox gbInventory;
        private System.Windows.Forms.Label lblInventoryDetail;
        private System.Windows.Forms.GroupBox gbReceive;
        private NewMethod.nEdit_Number ctlQuantity;
        private System.Windows.Forms.Label lblSaleDetail;
        private System.Windows.Forms.GroupBox gbPictures;
        private System.Windows.Forms.GroupBox gbNewPicture;
        private System.Windows.Forms.PictureBox pbNew;
        private System.Windows.Forms.ListView lvNew;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button cmdAdd;
        private System.IO.FileSystemWatcher fsw;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lvPics;
        private System.Windows.Forms.ImageList il;
        private System.IO.FileSystemWatcher fsw2;
        private System.Windows.Forms.LinkLabel lblLoadPics;
        private System.Windows.Forms.Panel pStandard;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Button cmdBrowse;
    }
}