namespace Rz5.Win.Screens
{
    partial class RzLink
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
            this.cmdActivate = new System.Windows.Forms.Button();
            this.lblLink = new System.Windows.Forms.LinkLabel();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.pActive = new System.Windows.Forms.Panel();
            this.lblCopy = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.throb = new NewMethod.nThrobber();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblComp = new System.Windows.Forms.Label();
            this.cmdUpdateComp = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCompUser = new System.Windows.Forms.TextBox();
            this.txtCompPW = new System.Windows.Forms.TextBox();
            this.cmdAddComp = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.rt = new System.Windows.Forms.RichTextBox();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pbBottom = new System.Windows.Forms.PictureBox();
            this.pbTop = new System.Windows.Forms.PictureBox();
            this.pSend = new System.Windows.Forms.Panel();
            this.pActive.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).BeginInit();
            this.pSend.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdActivate
            // 
            this.cmdActivate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdActivate.Location = new System.Drawing.Point(655, 3);
            this.cmdActivate.Name = "cmdActivate";
            this.cmdActivate.Size = new System.Drawing.Size(102, 32);
            this.cmdActivate.TabIndex = 0;
            this.cmdActivate.Text = "Activate";
            this.toolTip1.SetToolTip(this.cmdActivate, "Activate/Update database.");
            this.cmdActivate.UseVisualStyleBackColor = true;
            this.cmdActivate.Click += new System.EventHandler(this.cmdActivate_Click);
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblLink.Location = new System.Drawing.Point(382, 5);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(87, 15);
            this.lblLink.TabIndex = 1;
            this.lblLink.TabStop = true;
            this.lblLink.Text = "Log Into RzLink";
            this.toolTip1.SetToolTip(this.lblLink, "Log in to your RzPortal.");
            this.lblLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLink_LinkClicked);
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(7, 23);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(588, 20);
            this.txtLink.TabIndex = 2;
            // 
            // pActive
            // 
            this.pActive.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pActive.Controls.Add(this.lblCopy);
            this.pActive.Controls.Add(this.label1);
            this.pActive.Controls.Add(this.lblLink);
            this.pActive.Controls.Add(this.txtLink);
            this.pActive.Controls.Add(this.throb);
            this.pActive.Location = new System.Drawing.Point(3, 3);
            this.pActive.Name = "pActive";
            this.pActive.Size = new System.Drawing.Size(646, 48);
            this.pActive.TabIndex = 3;
            // 
            // lblCopy
            // 
            this.lblCopy.AutoSize = true;
            this.lblCopy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopy.Location = new System.Drawing.Point(536, 5);
            this.lblCopy.Name = "lblCopy";
            this.lblCopy.Size = new System.Drawing.Size(59, 15);
            this.lblCopy.TabIndex = 4;
            this.lblCopy.TabStop = true;
            this.lblCopy.Text = "Copy Link";
            this.toolTip1.SetToolTip(this.lblCopy, "Copy url link to clipboard.");
            this.lblCopy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCopy_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Login Link:";
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.throb.Location = new System.Drawing.Point(605, 15);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(28, 24);
            this.throb.TabIndex = 4;
            this.throb.UseParentBackColor = true;
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(16, 189);
            this.lv.MultiSelect = false;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(442, 132);
            this.lv.TabIndex = 10;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lv_ItemSelectionChanged);
            this.lv.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Company";
            this.columnHeader1.Width = 176;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Username";
            this.columnHeader2.Width = 112;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Password";
            this.columnHeader3.Width = 121;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblComp);
            this.groupBox2.Controls.Add(this.cmdUpdateComp);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCompUser);
            this.groupBox2.Controls.Add(this.txtCompPW);
            this.groupBox2.Location = new System.Drawing.Point(16, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(442, 169);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selected Company Login Info";
            // 
            // lblComp
            // 
            this.lblComp.AutoSize = true;
            this.lblComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblComp.Location = new System.Drawing.Point(9, 16);
            this.lblComp.Name = "lblComp";
            this.lblComp.Size = new System.Drawing.Size(0, 20);
            this.lblComp.TabIndex = 10;
            // 
            // cmdUpdateComp
            // 
            this.cmdUpdateComp.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUpdateComp.Location = new System.Drawing.Point(13, 130);
            this.cmdUpdateComp.Name = "cmdUpdateComp";
            this.cmdUpdateComp.Size = new System.Drawing.Size(415, 33);
            this.cmdUpdateComp.TabIndex = 9;
            this.cmdUpdateComp.Text = "Update";
            this.toolTip1.SetToolTip(this.cmdUpdateComp, "Update selected company username/password login information.");
            this.cmdUpdateComp.UseVisualStyleBackColor = true;
            this.cmdUpdateComp.Click += new System.EventHandler(this.cmdUpdateComp_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Password:";
            // 
            // txtCompUser
            // 
            this.txtCompUser.Location = new System.Drawing.Point(11, 59);
            this.txtCompUser.Name = "txtCompUser";
            this.txtCompUser.Size = new System.Drawing.Size(417, 20);
            this.txtCompUser.TabIndex = 5;
            // 
            // txtCompPW
            // 
            this.txtCompPW.Location = new System.Drawing.Point(13, 104);
            this.txtCompPW.Name = "txtCompPW";
            this.txtCompPW.Size = new System.Drawing.Size(415, 20);
            this.txtCompPW.TabIndex = 7;
            // 
            // cmdAddComp
            // 
            this.cmdAddComp.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddComp.Location = new System.Drawing.Point(16, 322);
            this.cmdAddComp.Name = "cmdAddComp";
            this.cmdAddComp.Size = new System.Drawing.Size(442, 29);
            this.cmdAddComp.TabIndex = 11;
            this.cmdAddComp.Text = "Add Company";
            this.toolTip1.SetToolTip(this.cmdAddComp, "Add new company login information.");
            this.cmdAddComp.UseVisualStyleBackColor = true;
            this.cmdAddComp.Click += new System.EventHandler(this.cmdAddComp_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(652, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Approx. 5-10 mins.";
            // 
            // rt
            // 
            this.rt.Location = new System.Drawing.Point(6, 15);
            this.rt.Name = "rt";
            this.rt.Size = new System.Drawing.Size(742, 229);
            this.rt.TabIndex = 12;
            this.rt.Text = "";
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(6, 250);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(742, 23);
            this.pb.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb.TabIndex = 13;
            // 
            // gbStatus
            // 
            this.gbStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbStatus.Controls.Add(this.rt);
            this.gbStatus.Controls.Add(this.pb);
            this.gbStatus.Location = new System.Drawing.Point(461, 72);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(754, 279);
            this.gbStatus.TabIndex = 11;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Status";
            // 
            // pbLeft
            // 
            this.pbLeft.BackColor = System.Drawing.Color.Black;
            this.pbLeft.Location = new System.Drawing.Point(184, 391);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(12, 12);
            this.pbLeft.TabIndex = 36;
            this.pbLeft.TabStop = false;
            // 
            // pbRight
            // 
            this.pbRight.BackColor = System.Drawing.Color.Black;
            this.pbRight.Location = new System.Drawing.Point(184, 373);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(12, 12);
            this.pbRight.TabIndex = 35;
            this.pbRight.TabStop = false;
            // 
            // pbBottom
            // 
            this.pbBottom.BackColor = System.Drawing.Color.Black;
            this.pbBottom.Location = new System.Drawing.Point(202, 373);
            this.pbBottom.Name = "pbBottom";
            this.pbBottom.Size = new System.Drawing.Size(12, 12);
            this.pbBottom.TabIndex = 34;
            this.pbBottom.TabStop = false;
            // 
            // pbTop
            // 
            this.pbTop.BackColor = System.Drawing.Color.Black;
            this.pbTop.Location = new System.Drawing.Point(202, 391);
            this.pbTop.Name = "pbTop";
            this.pbTop.Size = new System.Drawing.Size(12, 12);
            this.pbTop.TabIndex = 33;
            this.pbTop.TabStop = false;
            // 
            // pSend
            // 
            this.pSend.BackColor = System.Drawing.Color.Transparent;
            this.pSend.Controls.Add(this.pActive);
            this.pSend.Controls.Add(this.cmdActivate);
            this.pSend.Controls.Add(this.label6);
            this.pSend.Location = new System.Drawing.Point(461, 16);
            this.pSend.Name = "pSend";
            this.pSend.Size = new System.Drawing.Size(768, 54);
            this.pSend.TabIndex = 37;
            // 
            // RzLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pSend);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.pbBottom);
            this.Controls.Add(this.pbTop);
            this.Controls.Add(this.gbStatus);
            this.Controls.Add(this.cmdAddComp);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lv);
            this.Name = "RzLink";
            this.Size = new System.Drawing.Size(1477, 517);
            this.Resize += new System.EventHandler(this.RzLink_Resize);
            this.pActive.ResumeLayout(false);
            this.pActive.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).EndInit();
            this.pSend.ResumeLayout(false);
            this.pSend.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdActivate;
        private System.Windows.Forms.LinkLabel lblLink;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Panel pActive;
        private NewMethod.nThrobber throb;
        private System.Windows.Forms.LinkLabel lblCopy;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker bg;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblComp;
        private System.Windows.Forms.Button cmdUpdateComp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCompUser;
        private System.Windows.Forms.TextBox txtCompPW;
        private System.Windows.Forms.Button cmdAddComp;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rt;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.PictureBox pbBottom;
        private System.Windows.Forms.PictureBox pbTop;
        private System.Windows.Forms.Panel pSend;
    }
}
