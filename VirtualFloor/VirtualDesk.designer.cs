//namespace Rz4.VirtualFloor
//{
//    partial class VirtualDesk
//    {
//        /// <summary> 
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary> 
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Component Designer generated code

//        /// <summary> 
//        /// Required method for Designer support - do not modify 
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VirtualDesk));
//            this.lblActivity = new System.Windows.Forms.Label();
//            this.ilSpin = new System.Windows.Forms.ImageList(this.components);
//            this.tmrSpin = new System.Windows.Forms.Timer(this.components);
//            this.mnuBanner = new System.Windows.Forms.ContextMenuStrip(this.components);
//            this.mnuActivityReport = new System.Windows.Forms.ToolStripMenuItem();
//            this.mnuActivityReportToday = new System.Windows.Forms.ToolStripMenuItem();
//            this.mnuActivityReportYesterday = new System.Windows.Forms.ToolStripMenuItem();
//            this.mnuBannerColor = new System.Windows.Forms.ToolStripMenuItem();
//            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
//            this.mnuRemove = new System.Windows.Forms.ToolStripMenuItem();
//            this.ilBanner = new System.Windows.Forms.ImageList(this.components);
//            this.picBanner = new System.Windows.Forms.PictureBox();
//            this.picSlices = new System.Windows.Forms.PictureBox();
//            this.picSpin = new System.Windows.Forms.PictureBox();
//            this.picDrag = new System.Windows.Forms.PictureBox();
//            this.picDesk = new System.Windows.Forms.PictureBox();
//            this.mnuBanner.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.picSlices)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.picSpin)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.picDrag)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.picDesk)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // lblActivity
//            // 
//            this.lblActivity.AutoSize = true;
//            this.lblActivity.Location = new System.Drawing.Point(24, 45);
//            this.lblActivity.Name = "lblActivity";
//            this.lblActivity.Size = new System.Drawing.Size(52, 13);
//            this.lblActivity.TabIndex = 3;
//            this.lblActivity.Text = "<activity>";
//            // 
//            // ilSpin
//            // 
//            this.ilSpin.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilSpin.ImageStream")));
//            this.ilSpin.TransparentColor = System.Drawing.Color.Transparent;
//            this.ilSpin.Images.SetKeyName(0, "desk_000.jpg");
//            this.ilSpin.Images.SetKeyName(1, "desk_001.jpg");
//            this.ilSpin.Images.SetKeyName(2, "desk_002.jpg");
//            this.ilSpin.Images.SetKeyName(3, "desk_003.jpg");
//            this.ilSpin.Images.SetKeyName(4, "desk_004.jpg");
//            this.ilSpin.Images.SetKeyName(5, "desk_005.jpg");
//            this.ilSpin.Images.SetKeyName(6, "desk_006.jpg");
//            this.ilSpin.Images.SetKeyName(7, "desk_007.jpg");
//            this.ilSpin.Images.SetKeyName(8, "desk_008.jpg");
//            this.ilSpin.Images.SetKeyName(9, "desk_009.jpg");
//            this.ilSpin.Images.SetKeyName(10, "desk_010.jpg");
//            this.ilSpin.Images.SetKeyName(11, "desk_011.jpg");
//            this.ilSpin.Images.SetKeyName(12, "desk_012.jpg");
//            this.ilSpin.Images.SetKeyName(13, "desk_013.jpg");
//            this.ilSpin.Images.SetKeyName(14, "desk_014.jpg");
//            this.ilSpin.Images.SetKeyName(15, "desk_015.jpg");
//            this.ilSpin.Images.SetKeyName(16, "desk_016.jpg");
//            this.ilSpin.Images.SetKeyName(17, "desk_017.jpg");
//            this.ilSpin.Images.SetKeyName(18, "desk_blue.jpg");
//            this.ilSpin.Images.SetKeyName(19, "desk_green.jpg");
//            this.ilSpin.Images.SetKeyName(20, "desk_orange.jpg");
//            this.ilSpin.Images.SetKeyName(21, "desk_purple.jpg");
//            this.ilSpin.Images.SetKeyName(22, "desk_red.jpg");
//            this.ilSpin.Images.SetKeyName(23, "desk_yellow.jpg");
//            this.ilSpin.Images.SetKeyName(24, "desk_inactive.jpg");
//            // 
//            // tmrSpin
//            // 
//            this.tmrSpin.Interval = 300;
//            this.tmrSpin.Tick += new System.EventHandler(this.tmrSpin_Tick);
//            // 
//            // mnuBanner
//            // 
//            this.mnuBanner.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.mnuActivityReport,
//            this.mnuBannerColor,
//            this.toolStripSeparator1,
//            this.mnuRemove});
//            this.mnuBanner.Name = "mnuBanner";
//            this.mnuBanner.Size = new System.Drawing.Size(153, 76);
//            this.mnuBanner.Opening += new System.ComponentModel.CancelEventHandler(this.mnuBanner_Opening);
//            // 
//            // mnuActivityReport
//            // 
//            this.mnuActivityReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.mnuActivityReportToday,
//            this.mnuActivityReportYesterday});
//            this.mnuActivityReport.Name = "mnuActivityReport";
//            this.mnuActivityReport.Size = new System.Drawing.Size(152, 22);
//            this.mnuActivityReport.Text = "&Activity Report";
//            // 
//            // mnuActivityReportToday
//            // 
//            this.mnuActivityReportToday.Name = "mnuActivityReportToday";
//            this.mnuActivityReportToday.Size = new System.Drawing.Size(125, 22);
//            this.mnuActivityReportToday.Text = "&Today";
//            this.mnuActivityReportToday.Click += new System.EventHandler(this.mnuActivityReportToday_Click);
//            // 
//            // mnuActivityReportYesterday
//            // 
//            this.mnuActivityReportYesterday.Name = "mnuActivityReportYesterday";
//            this.mnuActivityReportYesterday.Size = new System.Drawing.Size(125, 22);
//            this.mnuActivityReportYesterday.Text = "&Yesterday";
//            this.mnuActivityReportYesterday.Click += new System.EventHandler(this.mnuActivityReportYesterday_Click);
//            // 
//            // mnuBannerColor
//            // 
//            this.mnuBannerColor.Name = "mnuBannerColor";
//            this.mnuBannerColor.Size = new System.Drawing.Size(152, 22);
//            this.mnuBannerColor.Text = "Color";
//            // 
//            // toolStripSeparator1
//            // 
//            this.toolStripSeparator1.Name = "toolStripSeparator1";
//            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
//            // 
//            // mnuRemove
//            // 
//            this.mnuRemove.Name = "mnuRemove";
//            this.mnuRemove.Size = new System.Drawing.Size(152, 22);
//            this.mnuRemove.Text = "&Remove";
//            this.mnuRemove.Click += new System.EventHandler(this.mnuRemove_Click);
//            // 
//            // ilBanner
//            // 
//            this.ilBanner.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilBanner.ImageStream")));
//            this.ilBanner.TransparentColor = System.Drawing.Color.Transparent;
//            this.ilBanner.Images.SetKeyName(0, "banner_blue.jpg");
//            this.ilBanner.Images.SetKeyName(1, "banner_green.jpg");
//            this.ilBanner.Images.SetKeyName(2, "banner_orange.jpg");
//            this.ilBanner.Images.SetKeyName(3, "banner_purple.jpg");
//            this.ilBanner.Images.SetKeyName(4, "banner_red.jpg");
//            this.ilBanner.Images.SetKeyName(5, "banner_yellow.jpg");
//            // 
//            // picBanner
//            // 
//            this.picBanner.Image = ((System.Drawing.Image)(resources.GetObject("picBanner.Image")));
//            this.picBanner.Location = new System.Drawing.Point(6, 3);
//            this.picBanner.Name = "picBanner";
//            this.picBanner.Size = new System.Drawing.Size(109, 35);
//            this.picBanner.TabIndex = 10;
//            this.picBanner.TabStop = false;
//            this.picBanner.Click += new System.EventHandler(this.picBanner_Click);
//            // 
//            // picSlices
//            // 
//            this.picSlices.Location = new System.Drawing.Point(56, 150);
//            this.picSlices.Name = "picSlices";
//            this.picSlices.Size = new System.Drawing.Size(120, 15);
//            this.picSlices.TabIndex = 9;
//            this.picSlices.TabStop = false;
//            // 
//            // picSpin
//            // 
//            this.picSpin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
//            this.picSpin.Image = ((System.Drawing.Image)(resources.GetObject("picSpin.Image")));
//            this.picSpin.Location = new System.Drawing.Point(184, 72);
//            this.picSpin.Name = "picSpin";
//            this.picSpin.Size = new System.Drawing.Size(52, 49);
//            this.picSpin.TabIndex = 8;
//            this.picSpin.TabStop = false;
//            this.picSpin.Click += new System.EventHandler(this.picSpin_Click);
//            // 
//            // picDrag
//            // 
//            this.picDrag.BackColor = System.Drawing.SystemColors.ButtonFace;
//            this.picDrag.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picDrag.BackgroundImage")));
//            this.picDrag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
//            this.picDrag.Location = new System.Drawing.Point(23, 119);
//            this.picDrag.Name = "picDrag";
//            this.picDrag.Size = new System.Drawing.Size(12, 11);
//            this.picDrag.TabIndex = 2;
//            this.picDrag.TabStop = false;
//            this.picDrag.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDrag_MouseMove);
//            this.picDrag.Click += new System.EventHandler(this.picDrag_Click);
//            this.picDrag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picDrag_MouseDown);
//            // 
//            // picDesk
//            // 
//            this.picDesk.ContextMenuStrip = this.mnuBanner;
//            this.picDesk.Image = ((System.Drawing.Image)(resources.GetObject("picDesk.Image")));
//            this.picDesk.Location = new System.Drawing.Point(0, 0);
//            this.picDesk.Name = "picDesk";
//            this.picDesk.Size = new System.Drawing.Size(242, 182);
//            this.picDesk.TabIndex = 7;
//            this.picDesk.TabStop = false;
//            // 
//            // VirtualDesk
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.Color.White;
//            this.Controls.Add(this.picBanner);
//            this.Controls.Add(this.picSlices);
//            this.Controls.Add(this.picSpin);
//            this.Controls.Add(this.lblActivity);
//            this.Controls.Add(this.picDrag);
//            this.Controls.Add(this.picDesk);
//            this.Name = "VirtualDesk";
//            this.Size = new System.Drawing.Size(246, 186);
//            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VirtualDesk_MouseMove);
//            this.mnuBanner.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.picSlices)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.picSpin)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.picDrag)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.picDesk)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.PictureBox picDrag;
//        private System.Windows.Forms.Label lblActivity;
//        private System.Windows.Forms.PictureBox picDesk;
//        private System.Windows.Forms.PictureBox picSpin;
//        private System.Windows.Forms.ImageList ilSpin;
//        private System.Windows.Forms.Timer tmrSpin;
//        private System.Windows.Forms.PictureBox picSlices;
//        private System.Windows.Forms.PictureBox picBanner;
//        private System.Windows.Forms.ContextMenuStrip mnuBanner;
//        private System.Windows.Forms.ToolStripMenuItem mnuBannerColor;
//        private System.Windows.Forms.ImageList ilBanner;
//        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
//        private System.Windows.Forms.ToolStripMenuItem mnuRemove;
//        private System.Windows.Forms.ToolStripMenuItem mnuActivityReport;
//        private System.Windows.Forms.ToolStripMenuItem mnuActivityReportToday;
//        private System.Windows.Forms.ToolStripMenuItem mnuActivityReportYesterday;
//    }
//}
