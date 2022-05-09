using NewMethod;

namespace Rz5
{
    partial class PrintPreview
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
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch (System.Exception)
            { }
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintPreview));
            this.cmdEdit = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lv = new NewMethod.nList();
            this.wb = new ToolsWin.BrowserPlain();
            this.lblPrinterInfo = new System.Windows.Forms.LinkLabel();
            this.chkDisablePreview = new System.Windows.Forms.CheckBox();
            this.tsPreview = new System.Windows.Forms.TabControl();
            this.page1 = new System.Windows.Forms.TabPage();
            this.FirstPage = new Rz5.PrintPreviewPage();
            this.gbSize = new System.Windows.Forms.GroupBox();
            this.cmdApply = new System.Windows.Forms.Button();
            this.cmdPreview = new System.Windows.Forms.Button();
            this.numx = new System.Windows.Forms.NumericUpDown();
            this.pButtons = new System.Windows.Forms.Panel();
            this.chkIncludePDF = new System.Windows.Forms.CheckBox();
            this.cmdGo = new System.Windows.Forms.Button();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.picPrint = new System.Windows.Forms.PictureBox();
            this.pCopies = new System.Windows.Forms.Panel();
            this.txtCopies = new System.Windows.Forms.TextBox();
            this.lblCopies = new System.Windows.Forms.Label();
            this.picPDF = new System.Windows.Forms.PictureBox();
            this.optPDF = new System.Windows.Forms.RadioButton();
            this.picEmail = new System.Windows.Forms.PictureBox();
            this.optEmail = new System.Windows.Forms.RadioButton();
            this.picFax = new System.Windows.Forms.PictureBox();
            this.optFax = new System.Windows.Forms.RadioButton();
            this.optPrint = new System.Windows.Forms.RadioButton();
            this.cmdClose = new System.Windows.Forms.Button();
            this.RT = new System.Windows.Forms.RichTextBox();
            this.chkConsolidateLines = new System.Windows.Forms.CheckBox();
            this.ctl_cc_agent = new System.Windows.Forms.CheckBox();
            this.tsPreview.SuspendLayout();
            this.page1.SuspendLayout();
            this.gbSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numx)).BeginInit();
            this.pButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            this.pCopies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFax)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdEdit
            // 
            this.cmdEdit.Location = new System.Drawing.Point(3, 415);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(306, 24);
            this.cmdEdit.TabIndex = 5;
            this.cmdEdit.Text = "<edit>";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoEllipsis = true;
            this.lblStatus.Location = new System.Drawing.Point(0, 462);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(72, 19);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "<status>";
            // 
            // lv
            // 
            this.lv.AddCaption = "Add New";
            this.lv.AllowActions = true;
            this.lv.AllowAdd = false;
            this.lv.AllowDelete = true;
            this.lv.AllowDeleteAlways = false;
            this.lv.AllowDrop = true;
            this.lv.AllowOnlyOpenDelete = false;
            this.lv.AlternateConnection = null;
            this.lv.BackColor = System.Drawing.Color.White;
            this.lv.Caption = "";
            this.lv.CurrentTemplate = null;
            this.lv.ExtraClassInfo = "";
            this.lv.Location = new System.Drawing.Point(0, 92);
            this.lv.MultiSelect = true;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(306, 321);
            this.lv.SuppressSelectionChanged = false;
            this.lv.TabIndex = 3;
            this.lv.zz_OpenColumnMenu = false;
            this.lv.zz_OrderLineType = "";
            this.lv.zz_ShowAutoRefresh = true;
            this.lv.zz_ShowUnlimited = true;
            this.lv.AboutToThrow += new Core.ShowHandler(this.lv_AboutToThrow);
            this.lv.ObjectClicked += new NewMethod.ObjectClickHandler(this.lv_ObjectClicked);
            // 
            // wb
            // 
            this.wb.BackColor = System.Drawing.Color.White;
            this.wb.Location = new System.Drawing.Point(483, 3);
            this.wb.Name = "wb";
            this.wb.ShowControls = false;
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(415, 519);
            this.wb.TabIndex = 4;
            // 
            // lblPrinterInfo
            // 
            this.lblPrinterInfo.Location = new System.Drawing.Point(0, 480);
            this.lblPrinterInfo.Name = "lblPrinterInfo";
            this.lblPrinterInfo.Size = new System.Drawing.Size(80, 19);
            this.lblPrinterInfo.TabIndex = 10;
            this.lblPrinterInfo.TabStop = true;
            this.lblPrinterInfo.Text = "<printer info>";
            this.lblPrinterInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPrinterInfo_LinkClicked);
            // 
            // chkDisablePreview
            // 
            this.chkDisablePreview.AutoSize = true;
            this.chkDisablePreview.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDisablePreview.Location = new System.Drawing.Point(3, 556);
            this.chkDisablePreview.Name = "chkDisablePreview";
            this.chkDisablePreview.Size = new System.Drawing.Size(116, 17);
            this.chkDisablePreview.TabIndex = 11;
            this.chkDisablePreview.Text = "Disable Previewing";
            this.chkDisablePreview.UseVisualStyleBackColor = true;
            this.chkDisablePreview.CheckedChanged += new System.EventHandler(this.chkDisablePreview_CheckedChanged);
            // 
            // tsPreview
            // 
            this.tsPreview.Controls.Add(this.page1);
            this.tsPreview.Location = new System.Drawing.Point(322, 3);
            this.tsPreview.Name = "tsPreview";
            this.tsPreview.SelectedIndex = 0;
            this.tsPreview.Size = new System.Drawing.Size(446, 567);
            this.tsPreview.TabIndex = 12;
            // 
            // page1
            // 
            this.page1.Controls.Add(this.FirstPage);
            this.page1.Location = new System.Drawing.Point(4, 22);
            this.page1.Name = "page1";
            this.page1.Padding = new System.Windows.Forms.Padding(3);
            this.page1.Size = new System.Drawing.Size(438, 541);
            this.page1.TabIndex = 0;
            this.page1.Text = "Page 1";
            this.page1.UseVisualStyleBackColor = true;
            // 
            // FirstPage
            // 
            this.FirstPage.AlternateResize = false;
            this.FirstPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FirstPage.Location = new System.Drawing.Point(3, 3);
            this.FirstPage.Name = "FirstPage";
            this.FirstPage.Size = new System.Drawing.Size(432, 535);
            this.FirstPage.TabIndex = 0;
            // 
            // gbSize
            // 
            this.gbSize.Controls.Add(this.cmdApply);
            this.gbSize.Controls.Add(this.cmdPreview);
            this.gbSize.Controls.Add(this.numx);
            this.gbSize.Location = new System.Drawing.Point(129, 480);
            this.gbSize.Name = "gbSize";
            this.gbSize.Size = new System.Drawing.Size(186, 39);
            this.gbSize.TabIndex = 13;
            this.gbSize.TabStop = false;
            this.gbSize.Text = "Scale";
            this.gbSize.Visible = false;
            // 
            // cmdApply
            // 
            this.cmdApply.Location = new System.Drawing.Point(95, 13);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(56, 20);
            this.cmdApply.TabIndex = 15;
            this.cmdApply.Text = "&Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // cmdPreview
            // 
            this.cmdPreview.Location = new System.Drawing.Point(157, 13);
            this.cmdPreview.Name = "cmdPreview";
            this.cmdPreview.Size = new System.Drawing.Size(23, 20);
            this.cmdPreview.TabIndex = 14;
            this.cmdPreview.Text = "&P";
            this.cmdPreview.UseVisualStyleBackColor = true;
            this.cmdPreview.Click += new System.EventHandler(this.cmdPreview_Click);
            // 
            // numx
            // 
            this.numx.DecimalPlaces = 4;
            this.numx.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numx.Location = new System.Drawing.Point(6, 15);
            this.numx.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numx.Name = "numx";
            this.numx.Size = new System.Drawing.Size(83, 20);
            this.numx.TabIndex = 0;
            this.numx.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // pButtons
            // 
            this.pButtons.Controls.Add(this.chkIncludePDF);
            this.pButtons.Controls.Add(this.cmdGo);
            this.pButtons.Controls.Add(this.picPrint);
            this.pButtons.Controls.Add(this.pCopies);
            this.pButtons.Controls.Add(this.picPDF);
            this.pButtons.Controls.Add(this.optPDF);
            this.pButtons.Controls.Add(this.picEmail);
            this.pButtons.Controls.Add(this.optEmail);
            this.pButtons.Controls.Add(this.picFax);
            this.pButtons.Controls.Add(this.optFax);
            this.pButtons.Controls.Add(this.optPrint);
            this.pButtons.Location = new System.Drawing.Point(3, 0);
            this.pButtons.Name = "pButtons";
            this.pButtons.Size = new System.Drawing.Size(306, 90);
            this.pButtons.TabIndex = 14;
            // 
            // chkIncludePDF
            // 
            this.chkIncludePDF.AutoSize = true;
            this.chkIncludePDF.Checked = true;
            this.chkIncludePDF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludePDF.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIncludePDF.Location = new System.Drawing.Point(13, 52);
            this.chkIncludePDF.Name = "chkIncludePDF";
            this.chkIncludePDF.Size = new System.Drawing.Size(108, 23);
            this.chkIncludePDF.TabIndex = 19;
            this.chkIncludePDF.Text = "Include PDF";
            this.chkIncludePDF.UseVisualStyleBackColor = true;
            this.chkIncludePDF.Visible = false;
            // 
            // cmdGo
            // 
            this.cmdGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGo.ImageKey = "Print";
            this.cmdGo.ImageList = this.il;
            this.cmdGo.Location = new System.Drawing.Point(160, 50);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(140, 32);
            this.cmdGo.TabIndex = 9;
            this.cmdGo.Text = "Print";
            this.cmdGo.UseVisualStyleBackColor = true;
            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Magenta;
            this.il.Images.SetKeyName(0, "Fax");
            this.il.Images.SetKeyName(1, "Print");
            this.il.Images.SetKeyName(2, "Email");
            this.il.Images.SetKeyName(3, "PDF");
            // 
            // picPrint
            // 
            this.picPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPrint.Location = new System.Drawing.Point(26, 6);
            this.picPrint.Name = "picPrint";
            this.picPrint.Size = new System.Drawing.Size(24, 24);
            this.picPrint.TabIndex = 1;
            this.picPrint.TabStop = false;
            // 
            // pCopies
            // 
            this.pCopies.Controls.Add(this.txtCopies);
            this.pCopies.Controls.Add(this.lblCopies);
            this.pCopies.Location = new System.Drawing.Point(12, 58);
            this.pCopies.Name = "pCopies";
            this.pCopies.Size = new System.Drawing.Size(100, 24);
            this.pCopies.TabIndex = 8;
            // 
            // txtCopies
            // 
            this.txtCopies.Location = new System.Drawing.Point(52, 3);
            this.txtCopies.Name = "txtCopies";
            this.txtCopies.Size = new System.Drawing.Size(43, 20);
            this.txtCopies.TabIndex = 1;
            this.txtCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCopies
            // 
            this.lblCopies.AutoSize = true;
            this.lblCopies.Location = new System.Drawing.Point(4, 4);
            this.lblCopies.Name = "lblCopies";
            this.lblCopies.Size = new System.Drawing.Size(42, 13);
            this.lblCopies.TabIndex = 0;
            this.lblCopies.Text = "Copies:";
            // 
            // picPDF
            // 
            this.picPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPDF.Location = new System.Drawing.Point(260, 6);
            this.picPDF.Name = "picPDF";
            this.picPDF.Size = new System.Drawing.Size(24, 24);
            this.picPDF.TabIndex = 7;
            this.picPDF.TabStop = false;
            // 
            // optPDF
            // 
            this.optPDF.AutoSize = true;
            this.optPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optPDF.Location = new System.Drawing.Point(243, 28);
            this.optPDF.Name = "optPDF";
            this.optPDF.Size = new System.Drawing.Size(59, 24);
            this.optPDF.TabIndex = 6;
            this.optPDF.TabStop = true;
            this.optPDF.Text = "PDF";
            this.optPDF.UseVisualStyleBackColor = true;
            this.optPDF.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // picEmail
            // 
            this.picEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picEmail.Location = new System.Drawing.Point(182, 6);
            this.picEmail.Name = "picEmail";
            this.picEmail.Size = new System.Drawing.Size(24, 24);
            this.picEmail.TabIndex = 5;
            this.picEmail.TabStop = false;
            // 
            // optEmail
            // 
            this.optEmail.AutoSize = true;
            this.optEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optEmail.Location = new System.Drawing.Point(160, 28);
            this.optEmail.Name = "optEmail";
            this.optEmail.Size = new System.Drawing.Size(66, 24);
            this.optEmail.TabIndex = 4;
            this.optEmail.TabStop = true;
            this.optEmail.Text = "Email";
            this.optEmail.UseVisualStyleBackColor = true;
            this.optEmail.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // picFax
            // 
            this.picFax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picFax.Location = new System.Drawing.Point(104, 6);
            this.picFax.Name = "picFax";
            this.picFax.Size = new System.Drawing.Size(24, 24);
            this.picFax.TabIndex = 3;
            this.picFax.TabStop = false;
            // 
            // optFax
            // 
            this.optFax.AutoSize = true;
            this.optFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optFax.Location = new System.Drawing.Point(89, 28);
            this.optFax.Name = "optFax";
            this.optFax.Size = new System.Drawing.Size(53, 24);
            this.optFax.TabIndex = 2;
            this.optFax.TabStop = true;
            this.optFax.Text = "Fax";
            this.optFax.UseVisualStyleBackColor = true;
            this.optFax.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optPrint
            // 
            this.optPrint.AutoSize = true;
            this.optPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optPrint.Location = new System.Drawing.Point(10, 28);
            this.optPrint.Name = "optPrint";
            this.optPrint.Size = new System.Drawing.Size(59, 24);
            this.optPrint.TabIndex = 0;
            this.optPrint.TabStop = true;
            this.optPrint.Text = "Print";
            this.optPrint.UseVisualStyleBackColor = true;
            this.optPrint.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(4, 526);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(310, 24);
            this.cmdClose.TabIndex = 15;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // RT
            // 
            this.RT.Location = new System.Drawing.Point(870, 257);
            this.RT.Name = "RT";
            this.RT.Size = new System.Drawing.Size(100, 96);
            this.RT.TabIndex = 16;
            this.RT.Text = "";
            this.RT.Visible = false;
            // 
            // chkConsolidateLines
            // 
            this.chkConsolidateLines.AutoSize = true;
            this.chkConsolidateLines.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkConsolidateLines.Location = new System.Drawing.Point(3, 442);
            this.chkConsolidateLines.Name = "chkConsolidateLines";
            this.chkConsolidateLines.Size = new System.Drawing.Size(109, 17);
            this.chkConsolidateLines.TabIndex = 17;
            this.chkConsolidateLines.Text = "Consolidate Lines";
            this.chkConsolidateLines.UseVisualStyleBackColor = true;
            // 
            // ctl_cc_agent
            // 
            this.ctl_cc_agent.AutoSize = true;
            this.ctl_cc_agent.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ctl_cc_agent.Location = new System.Drawing.Point(129, 442);
            this.ctl_cc_agent.Name = "ctl_cc_agent";
            this.ctl_cc_agent.Size = new System.Drawing.Size(71, 17);
            this.ctl_cc_agent.TabIndex = 19;
            this.ctl_cc_agent.Text = "CC Agent";
            this.ctl_cc_agent.UseVisualStyleBackColor = true;
            // 
            // PrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctl_cc_agent);
            this.Controls.Add(this.chkConsolidateLines);
            this.Controls.Add(this.RT);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.pButtons);
            this.Controls.Add(this.gbSize);
            this.Controls.Add(this.tsPreview);
            this.Controls.Add(this.chkDisablePreview);
            this.Controls.Add(this.lblPrinterInfo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.wb);
            this.Name = "PrintPreview";
            this.Size = new System.Drawing.Size(1010, 651);
            this.Resize += new System.EventHandler(this.PrintPreview_Resize);
            this.tsPreview.ResumeLayout(false);
            this.page1.ResumeLayout(false);
            this.gbSize.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numx)).EndInit();
            this.pButtons.ResumeLayout(false);
            this.pButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).EndInit();
            this.pCopies.ResumeLayout(false);
            this.pCopies.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolsWin.BrowserPlain wb;
        private System.Windows.Forms.TabPage page1;
        private System.Windows.Forms.ImageList il;
        protected System.Windows.Forms.Panel pButtons;
        protected System.Windows.Forms.PictureBox picPrint;
        protected System.Windows.Forms.RadioButton optPrint;
        protected System.Windows.Forms.PictureBox picPDF;
        protected System.Windows.Forms.RadioButton optPDF;
        protected System.Windows.Forms.PictureBox picEmail;
        protected System.Windows.Forms.RadioButton optEmail;
        protected System.Windows.Forms.PictureBox picFax;
        protected System.Windows.Forms.RadioButton optFax;
        protected System.Windows.Forms.TextBox txtCopies;
        protected System.Windows.Forms.Label lblCopies;
        protected System.Windows.Forms.Button cmdGo;
        protected nList lv;
        protected System.Windows.Forms.Button cmdEdit;
        protected System.Windows.Forms.Label lblStatus;
        protected System.Windows.Forms.LinkLabel lblPrinterInfo;
        protected System.Windows.Forms.CheckBox chkDisablePreview;
        protected System.Windows.Forms.Button cmdClose;
        protected System.Windows.Forms.CheckBox chkConsolidateLines;
        protected System.Windows.Forms.TabControl tsPreview;
        protected PrintPreviewPage FirstPage;
        protected System.Windows.Forms.GroupBox gbSize;
        protected System.Windows.Forms.NumericUpDown numx;
        protected System.Windows.Forms.Button cmdPreview;
        protected System.Windows.Forms.Button cmdApply;
        protected System.Windows.Forms.Panel pCopies;
        protected System.Windows.Forms.RichTextBox RT;
        protected System.Windows.Forms.CheckBox chkIncludePDF;
        protected System.Windows.Forms.CheckBox ctl_cc_agent;
    }
}
