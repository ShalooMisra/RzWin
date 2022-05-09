using System.Runtime.InteropServices;

namespace MultiSearch
{
    partial class Search
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
            try
            {
                if (disposing)
                {
                    try
                    {
                        Marshal.Release(this.wb.Handle);
                    }
                    catch { }
                }

                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch { }
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.cmdBack = new System.Windows.Forms.Button();
            this.IMG = new System.Windows.Forms.ImageList(this.components);
            this.pic = new System.Windows.Forms.PictureBox();
            this.sb = new System.Windows.Forms.StatusStrip();
            this.lblProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmdMainPage = new System.Windows.Forms.Button();
            this.cmdText = new System.Windows.Forms.Button();
            this.cmdHTML = new System.Windows.Forms.Button();
            this.cmdForward = new System.Windows.Forms.Button();
            this.cmdLogin = new System.Windows.Forms.Button();
            this.cmdPOstOffers = new System.Windows.Forms.Button();
            this.cmdPostRFQs = new System.Windows.Forms.Button();
            this.cmdCheckBoxes = new System.Windows.Forms.Button();
            this.wb = new System.Windows.Forms.WebBrowser();
            this.tmrIcon = new System.Windows.Forms.Timer(this.components);
            this.tmrStatusIcon = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.sb.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdBack
            // 
            this.cmdBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBack.ImageIndex = 4;
            this.cmdBack.ImageList = this.IMG;
            this.cmdBack.Location = new System.Drawing.Point(3, 0);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(66, 24);
            this.cmdBack.TabIndex = 1;
            this.cmdBack.Text = "  Back";
            this.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdBack.UseVisualStyleBackColor = true;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // IMG
            // 
            this.IMG.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IMG.ImageStream")));
            this.IMG.TransparentColor = System.Drawing.Color.Fuchsia;
            this.IMG.Images.SetKeyName(0, "Autoformat Document.bmp");
            this.IMG.Images.SetKeyName(1, "align center-4.bmp");
            this.IMG.Images.SetKeyName(2, "web_search16.bmp");
            this.IMG.Images.SetKeyName(3, "contact16a.bmp");
            this.IMG.Images.SetKeyName(4, "left_green16.bmp");
            this.IMG.Images.SetKeyName(5, "right_green16.bmp");
            this.IMG.Images.SetKeyName(6, "postreqs");
            this.IMG.Images.SetKeyName(7, "postoffers");
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(575, 3);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(78, 10);
            this.pic.TabIndex = 2;
            this.pic.TabStop = false;
            // 
            // sb
            // 
            this.sb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProgress});
            this.sb.Location = new System.Drawing.Point(0, 460);
            this.sb.Name = "sb";
            this.sb.Size = new System.Drawing.Size(742, 22);
            this.sb.TabIndex = 3;
            this.sb.Text = "statusStrip1";
            // 
            // lblProgress
            // 
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(68, 17);
            this.lblProgress.Text = "<progress>";
            // 
            // cmdMainPage
            // 
            this.cmdMainPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdMainPage.ImageIndex = 0;
            this.cmdMainPage.ImageList = this.IMG;
            this.cmdMainPage.Location = new System.Drawing.Point(135, 0);
            this.cmdMainPage.Name = "cmdMainPage";
            this.cmdMainPage.Size = new System.Drawing.Size(80, 24);
            this.cmdMainPage.TabIndex = 5;
            this.cmdMainPage.Text = "Main Page";
            this.cmdMainPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdMainPage.UseVisualStyleBackColor = true;
            this.cmdMainPage.Click += new System.EventHandler(this.cmdMainPage_Click);
            // 
            // cmdText
            // 
            this.cmdText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdText.ImageKey = "align center-4.bmp";
            this.cmdText.ImageList = this.IMG;
            this.cmdText.Location = new System.Drawing.Point(455, 0);
            this.cmdText.Name = "cmdText";
            this.cmdText.Size = new System.Drawing.Size(51, 24);
            this.cmdText.TabIndex = 6;
            this.cmdText.Text = "Text";
            this.cmdText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdText.UseVisualStyleBackColor = true;
            this.cmdText.Click += new System.EventHandler(this.cmdText_Click);
            // 
            // cmdHTML
            // 
            this.cmdHTML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdHTML.ImageIndex = 2;
            this.cmdHTML.ImageList = this.IMG;
            this.cmdHTML.Location = new System.Drawing.Point(507, 0);
            this.cmdHTML.Name = "cmdHTML";
            this.cmdHTML.Size = new System.Drawing.Size(59, 24);
            this.cmdHTML.TabIndex = 7;
            this.cmdHTML.Text = "HTML";
            this.cmdHTML.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdHTML.UseVisualStyleBackColor = true;
            this.cmdHTML.Click += new System.EventHandler(this.cmdHTML_Click);
            // 
            // cmdForward
            // 
            this.cmdForward.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdForward.ImageIndex = 5;
            this.cmdForward.ImageList = this.IMG;
            this.cmdForward.Location = new System.Drawing.Point(69, 0);
            this.cmdForward.Name = "cmdForward";
            this.cmdForward.Size = new System.Drawing.Size(66, 24);
            this.cmdForward.TabIndex = 8;
            this.cmdForward.Text = "Forward";
            this.cmdForward.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdForward.UseVisualStyleBackColor = true;
            this.cmdForward.Click += new System.EventHandler(this.cmdForward_Click);
            // 
            // cmdLogin
            // 
            this.cmdLogin.Enabled = false;
            this.cmdLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLogin.ImageIndex = 3;
            this.cmdLogin.ImageList = this.IMG;
            this.cmdLogin.Location = new System.Drawing.Point(215, 0);
            this.cmdLogin.Name = "cmdLogin";
            this.cmdLogin.Size = new System.Drawing.Size(80, 24);
            this.cmdLogin.TabIndex = 9;
            this.cmdLogin.Text = "Login";
            this.cmdLogin.UseVisualStyleBackColor = true;
            this.cmdLogin.Visible = false;
            this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
            // 
            // cmdPOstOffers
            // 
            this.cmdPOstOffers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPOstOffers.ImageKey = "postoffers";
            this.cmdPOstOffers.ImageList = this.IMG;
            this.cmdPOstOffers.Location = new System.Drawing.Point(375, 0);
            this.cmdPOstOffers.Name = "cmdPOstOffers";
            this.cmdPOstOffers.Size = new System.Drawing.Size(80, 24);
            this.cmdPOstOffers.TabIndex = 10;
            this.cmdPOstOffers.Text = "Post Offers";
            this.cmdPOstOffers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPOstOffers.UseVisualStyleBackColor = true;
            this.cmdPOstOffers.Visible = false;
            this.cmdPOstOffers.Click += new System.EventHandler(this.cmdPOstOffers_Click);
            // 
            // cmdPostRFQs
            // 
            this.cmdPostRFQs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPostRFQs.ImageKey = "postreqs";
            this.cmdPostRFQs.ImageList = this.IMG;
            this.cmdPostRFQs.Location = new System.Drawing.Point(295, 0);
            this.cmdPostRFQs.Name = "cmdPostRFQs";
            this.cmdPostRFQs.Size = new System.Drawing.Size(80, 24);
            this.cmdPostRFQs.TabIndex = 11;
            this.cmdPostRFQs.Text = "Post Reqs";
            this.cmdPostRFQs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPostRFQs.UseVisualStyleBackColor = true;
            this.cmdPostRFQs.Visible = false;
            this.cmdPostRFQs.Click += new System.EventHandler(this.cmdPostRFQs_Click);
            // 
            // cmdCheckBoxes
            // 
            this.cmdCheckBoxes.ImageList = this.IMG;
            this.cmdCheckBoxes.Location = new System.Drawing.Point(3, 25);
            this.cmdCheckBoxes.Name = "cmdCheckBoxes";
            this.cmdCheckBoxes.Size = new System.Drawing.Size(132, 19);
            this.cmdCheckBoxes.TabIndex = 12;
            this.cmdCheckBoxes.Text = "CheckBoxes";
            this.cmdCheckBoxes.UseVisualStyleBackColor = true;
            this.cmdCheckBoxes.Visible = false;
            this.cmdCheckBoxes.Click += new System.EventHandler(this.cmdCheckBoxes_Click);
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(2, 26);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(585, 325);
            this.wb.TabIndex = 13;
            this.wb.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wb_DocumentCompleted);
            this.wb.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.wb_Navigating);
            this.wb.NewWindow += new System.ComponentModel.CancelEventHandler(this.wb_NewWindow);
            this.wb.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.wb_ProgressChanged);
            this.wb.LocationChanged += new System.EventHandler(this.wb_LocationChanged);
            // 
            // tmrIcon
            // 
            this.tmrIcon.Interval = 3000;
            this.tmrIcon.Tick += new System.EventHandler(this.tmrIcon_Tick);
            // 
            // tmrStatusIcon
            // 
            this.tmrStatusIcon.Interval = 1500;
            this.tmrStatusIcon.Tick += new System.EventHandler(this.tmrStatusIcon_Tick);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wb);
            this.Controls.Add(this.cmdCheckBoxes);
            this.Controls.Add(this.cmdPostRFQs);
            this.Controls.Add(this.cmdPOstOffers);
            this.Controls.Add(this.cmdLogin);
            this.Controls.Add(this.cmdForward);
            this.Controls.Add(this.cmdHTML);
            this.Controls.Add(this.cmdText);
            this.Controls.Add(this.cmdMainPage);
            this.Controls.Add(this.sb);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.cmdBack);
            this.Name = "Search";
            this.Size = new System.Drawing.Size(742, 482);
            this.Click += new System.EventHandler(this.Search_Click);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Search_MouseUp);
            this.Resize += new System.EventHandler(this.Search_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.sb.ResumeLayout(false);
            this.sb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.StatusStrip sb;
        private System.Windows.Forms.ToolStripStatusLabel lblProgress;
        private System.Windows.Forms.Button cmdMainPage;
        private System.Windows.Forms.Button cmdText;
        private System.Windows.Forms.Button cmdHTML;
        private System.Windows.Forms.Button cmdForward;
        private System.Windows.Forms.ImageList IMG;
        protected System.Windows.Forms.Button cmdLogin;
        protected System.Windows.Forms.Button cmdPOstOffers;
        private System.Windows.Forms.Button cmdPostRFQs;
        public System.Windows.Forms.Button cmdCheckBoxes;
        protected System.Windows.Forms.WebBrowser wb;
        private System.Windows.Forms.Timer tmrIcon;
        private System.Windows.Forms.Timer tmrStatusIcon;
    }
}
