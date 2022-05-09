namespace Rz5
{
    partial class PickReceiveItem
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
            this.chkReceive = new System.Windows.Forms.CheckBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtMFG = new System.Windows.Forms.TextBox();
            this.lblMFG = new System.Windows.Forms.Label();
            this.txtDC = new System.Windows.Forms.TextBox();
            this.lblDC = new System.Windows.Forms.Label();
            this.cboPkg = new System.Windows.Forms.ComboBox();
            this.lblPkg = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.lblComments = new System.Windows.Forms.Label();
            this.lblCond = new System.Windows.Forms.Label();
            this.cboCond = new System.Windows.Forms.ComboBox();
            this.lblItem = new System.Windows.Forms.LinkLabel();
            this.picDone = new System.Windows.Forms.PictureBox();
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pbBottom = new System.Windows.Forms.PictureBox();
            this.pbTop = new System.Windows.Forms.PictureBox();
            this.picY = new System.Windows.Forms.PictureBox();
            this.picN = new System.Windows.Forms.PictureBox();
            this.chkTotalQty = new System.Windows.Forms.CheckBox();
            this.ctl_initials = new NewMethod.nEdit_String();
            ((System.ComponentModel.ISupportInitialize)(this.picDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picN)).BeginInit();
            this.SuspendLayout();
            // 
            // chkReceive
            // 
            this.chkReceive.AutoSize = true;
            this.chkReceive.Location = new System.Drawing.Point(5, 5);
            this.chkReceive.Name = "chkReceive";
            this.chkReceive.Size = new System.Drawing.Size(15, 14);
            this.chkReceive.TabIndex = 1;
            this.chkReceive.UseVisualStyleBackColor = true;
            this.chkReceive.CheckedChanged += new System.EventHandler(this.chkReceive_CheckedChanged);
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(110, 2);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(100, 20);
            this.txtItem.TabIndex = 2;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(240, 1);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(67, 20);
            this.txtQty.TabIndex = 4;
            // 
            // lblQty
            // 
            this.lblQty.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(212, 4);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(31, 15);
            this.lblQty.TabIndex = 3;
            this.lblQty.Text = "Qty:";
            // 
            // txtMFG
            // 
            this.txtMFG.Location = new System.Drawing.Point(353, 1);
            this.txtMFG.Name = "txtMFG";
            this.txtMFG.Size = new System.Drawing.Size(74, 20);
            this.txtMFG.TabIndex = 6;
            // 
            // lblMFG
            // 
            this.lblMFG.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMFG.Location = new System.Drawing.Point(322, 4);
            this.lblMFG.Name = "lblMFG";
            this.lblMFG.Size = new System.Drawing.Size(33, 15);
            this.lblMFG.TabIndex = 5;
            this.lblMFG.Text = "Mfg:";
            // 
            // txtDC
            // 
            this.txtDC.Location = new System.Drawing.Point(459, 1);
            this.txtDC.Name = "txtDC";
            this.txtDC.Size = new System.Drawing.Size(50, 20);
            this.txtDC.TabIndex = 8;
            this.txtDC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDC
            // 
            this.lblDC.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDC.Location = new System.Drawing.Point(433, 4);
            this.lblDC.Name = "lblDC";
            this.lblDC.Size = new System.Drawing.Size(30, 15);
            this.lblDC.TabIndex = 7;
            this.lblDC.Text = "DC:";
            // 
            // cboPkg
            // 
            this.cboPkg.FormattingEnabled = true;
            this.cboPkg.Items.AddRange(new object[] {
            "Bulk",
            "Cut Tape",
            "T/R",
            "Trays",
            "Tubes"});
            this.cboPkg.Location = new System.Drawing.Point(550, 0);
            this.cboPkg.Name = "cboPkg";
            this.cboPkg.Size = new System.Drawing.Size(71, 22);
            this.cboPkg.TabIndex = 9;
            // 
            // lblPkg
            // 
            this.lblPkg.AutoSize = true;
            this.lblPkg.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPkg.Location = new System.Drawing.Point(515, 3);
            this.lblPkg.Name = "lblPkg";
            this.lblPkg.Size = new System.Drawing.Size(34, 15);
            this.lblPkg.TabIndex = 10;
            this.lblPkg.Text = "Pkg:";
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.Blue;
            this.lblCount.Location = new System.Drawing.Point(2, 30);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(28, 15);
            this.lblCount.TabIndex = 17;
            this.lblCount.Text = "000";
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(260, 53);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(50, 34);
            this.txtComments.TabIndex = 19;
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComments.Location = new System.Drawing.Point(32, 30);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(69, 15);
            this.lblComments.TabIndex = 18;
            this.lblComments.Text = "Comments:";
            // 
            // lblCond
            // 
            this.lblCond.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCond.Location = new System.Drawing.Point(263, 124);
            this.lblCond.Name = "lblCond";
            this.lblCond.Size = new System.Drawing.Size(40, 15);
            this.lblCond.TabIndex = 21;
            this.lblCond.Text = "Cond:";
            // 
            // cboCond
            // 
            this.cboCond.FormattingEnabled = true;
            this.cboCond.Items.AddRange(new object[] {
            "NEW",
            "Refurb",
            "Trims",
            "Pulls",
            "Socket"});
            this.cboCond.Location = new System.Drawing.Point(308, 122);
            this.cboCond.Name = "cboCond";
            this.cboCond.Size = new System.Drawing.Size(71, 22);
            this.cboCond.TabIndex = 20;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(32, 4);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(79, 15);
            this.lblItem.TabIndex = 22;
            this.lblItem.TabStop = true;
            this.lblItem.Text = "PartNumber:";
            this.lblItem.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblItem_LinkClicked);
            // 
            // picDone
            // 
            this.picDone.Image = global::RzInterfaceWin.Properties.Resources.OK1221;
            this.picDone.Location = new System.Drawing.Point(3, 3);
            this.picDone.Name = "picDone";
            this.picDone.Size = new System.Drawing.Size(23, 24);
            this.picDone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDone.TabIndex = 23;
            this.picDone.TabStop = false;
            this.picDone.Visible = false;
            // 
            // pbLeft
            // 
            this.pbLeft.BackColor = System.Drawing.Color.Black;
            this.pbLeft.Location = new System.Drawing.Point(353, 27);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(26, 10);
            this.pbLeft.TabIndex = 16;
            this.pbLeft.TabStop = false;
            // 
            // pbRight
            // 
            this.pbRight.BackColor = System.Drawing.Color.Black;
            this.pbRight.Location = new System.Drawing.Point(170, 41);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(27, 32);
            this.pbRight.TabIndex = 15;
            this.pbRight.TabStop = false;
            // 
            // pbBottom
            // 
            this.pbBottom.BackColor = System.Drawing.Color.Black;
            this.pbBottom.Location = new System.Drawing.Point(215, 28);
            this.pbBottom.Name = "pbBottom";
            this.pbBottom.Size = new System.Drawing.Size(28, 59);
            this.pbBottom.TabIndex = 14;
            this.pbBottom.TabStop = false;
            // 
            // pbTop
            // 
            this.pbTop.BackColor = System.Drawing.Color.Black;
            this.pbTop.Location = new System.Drawing.Point(446, 63);
            this.pbTop.Name = "pbTop";
            this.pbTop.Size = new System.Drawing.Size(154, 24);
            this.pbTop.TabIndex = 13;
            this.pbTop.TabStop = false;
            // 
            // picY
            // 
            this.picY.Image = global::RzInterfaceWin.Properties.Resources.camera_y;
            this.picY.Location = new System.Drawing.Point(615, 12);
            this.picY.Name = "picY";
            this.picY.Size = new System.Drawing.Size(20, 21);
            this.picY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picY.TabIndex = 12;
            this.picY.TabStop = false;
            this.picY.DoubleClick += new System.EventHandler(this.picY_DoubleClick);
            // 
            // picN
            // 
            this.picN.Image = global::RzInterfaceWin.Properties.Resources.ThumbnailLoadingHS;
            this.picN.Location = new System.Drawing.Point(615, 12);
            this.picN.Name = "picN";
            this.picN.Size = new System.Drawing.Size(20, 21);
            this.picN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picN.TabIndex = 11;
            this.picN.TabStop = false;
            this.picN.DoubleClick += new System.EventHandler(this.picN_DoubleClick);
            // 
            // chkTotalQty
            // 
            this.chkTotalQty.AutoSize = true;
            this.chkTotalQty.Location = new System.Drawing.Point(309, 5);
            this.chkTotalQty.Name = "chkTotalQty";
            this.chkTotalQty.Size = new System.Drawing.Size(15, 14);
            this.chkTotalQty.TabIndex = 24;
            this.chkTotalQty.UseVisualStyleBackColor = true;
            // 
            // ctl_initials
            // 
            this.ctl_initials.AllCaps = false;
            this.ctl_initials.BackColor = System.Drawing.Color.Transparent;
            this.ctl_initials.Bold = false;
            this.ctl_initials.Caption = "I";
            this.ctl_initials.Changed = true;
            this.ctl_initials.IsEmail = false;
            this.ctl_initials.IsURL = false;
            this.ctl_initials.Location = new System.Drawing.Point(35, 45);
            this.ctl_initials.Name = "ctl_initials";
            this.ctl_initials.PasswordChar = '\0';
            this.ctl_initials.Size = new System.Drawing.Size(53, 21);
            this.ctl_initials.TabIndex = 26;
            this.ctl_initials.UseParentBackColor = false;
            this.ctl_initials.Visible = false;
            this.ctl_initials.zz_Enabled = true;
            this.ctl_initials.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_initials.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_initials.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_initials.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_initials.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctl_initials.zz_OriginalDesign = false;
            this.ctl_initials.zz_ShowLinkButton = false;
            this.ctl_initials.zz_ShowNeedsSaveColor = true;
            this.ctl_initials.zz_Text = "";
            this.ctl_initials.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctl_initials.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_initials.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_initials.zz_UseGlobalColor = false;
            this.ctl_initials.zz_UseGlobalFont = false;
            // 
            // PickReceiveItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.ctl_initials);
            this.Controls.Add(this.chkTotalQty);
            this.Controls.Add(this.picDone);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.cboCond);
            this.Controls.Add(this.lblCond);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.lblComments);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.pbBottom);
            this.Controls.Add(this.pbTop);
            this.Controls.Add(this.lblPkg);
            this.Controls.Add(this.txtDC);
            this.Controls.Add(this.lblDC);
            this.Controls.Add(this.txtMFG);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.chkReceive);
            this.Controls.Add(this.picY);
            this.Controls.Add(this.cboPkg);
            this.Controls.Add(this.picN);
            this.Controls.Add(this.lblMFG);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PickReceiveItem";
            this.Size = new System.Drawing.Size(647, 180);
            this.Resize += new System.EventHandler(this.PickReceiveItem_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkReceive;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtMFG;
        private System.Windows.Forms.Label lblMFG;
        private System.Windows.Forms.TextBox txtDC;
        private System.Windows.Forms.Label lblDC;
        private System.Windows.Forms.ComboBox cboPkg;
        private System.Windows.Forms.Label lblPkg;
        private System.Windows.Forms.PictureBox picN;
        private System.Windows.Forms.PictureBox picY;
        private System.Windows.Forms.PictureBox pbTop;
        private System.Windows.Forms.PictureBox pbBottom;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.Label lblCond;
        private System.Windows.Forms.ComboBox cboCond;
        private System.Windows.Forms.LinkLabel lblItem;
        private System.Windows.Forms.PictureBox picDone;
        private System.Windows.Forms.CheckBox chkTotalQty;
        private NewMethod.nEdit_String ctl_initials;
    }
}
