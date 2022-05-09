namespace NewMethod
{
    partial class IconStub
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
            this.pic = new System.Windows.Forms.PictureBox();
            this.lblSet = new System.Windows.Forms.LinkLabel();
            this.lblClear = new System.Windows.Forms.LinkLabel();
            this.IM = new System.Windows.Forms.ImageList(this.components);
            this.ctlKey = new NewMethod.nEdit_String();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pic.Location = new System.Drawing.Point(1, 1);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(36, 33);
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            this.pic.DoubleClick += new System.EventHandler(this.pic_DoubleClick);
            // 
            // lblSet
            // 
            this.lblSet.AutoSize = true;
            this.lblSet.BackColor = System.Drawing.Color.Transparent;
            this.lblSet.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSet.Location = new System.Drawing.Point(37, -1);
            this.lblSet.Name = "lblSet";
            this.lblSet.Size = new System.Drawing.Size(33, 14);
            this.lblSet.TabIndex = 2;
            this.lblSet.TabStop = true;
            this.lblSet.Text = "<Set>";
            this.lblSet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSet_LinkClicked);
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClear.Location = new System.Drawing.Point(75, -1);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(43, 14);
            this.lblClear.TabIndex = 3;
            this.lblClear.TabStop = true;
            this.lblClear.Text = "<Clear>";
            this.lblClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblClear_LinkClicked);
            // 
            // IM
            // 
            this.IM.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.IM.ImageSize = new System.Drawing.Size(36, 33);
            this.IM.TransparentColor = System.Drawing.Color.Fuchsia;
            // 
            // ctlKey
            // 
            this.ctlKey.AllCaps = false;
            this.ctlKey.BackColor = System.Drawing.Color.Transparent;
            this.ctlKey.Bold = false;
            this.ctlKey.Caption = "Icon Key";
            this.ctlKey.Changed = false;
            this.ctlKey.IsEmail = false;
            this.ctlKey.IsURL = false;
            this.ctlKey.Location = new System.Drawing.Point(38, -1);
            this.ctlKey.Name = "ctlKey";
            this.ctlKey.PasswordChar = '\0';
            this.ctlKey.Size = new System.Drawing.Size(131, 36);
            this.ctlKey.TabIndex = 1;
            this.ctlKey.UseParentBackColor = false;
            this.ctlKey.zz_Enabled = true;
            this.ctlKey.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlKey.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlKey.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlKey.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlKey.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopRight;
            this.ctlKey.zz_OriginalDesign = false;
            this.ctlKey.zz_ShowLinkButton = false;
            this.ctlKey.zz_ShowNeedsSaveColor = true;
            this.ctlKey.zz_Text = "";
            this.ctlKey.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlKey.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlKey.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlKey.zz_UseGlobalColor = false;
            this.ctlKey.zz_UseGlobalFont = false;
            // 
            // IconStub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblClear);
            this.Controls.Add(this.lblSet);
            this.Controls.Add(this.ctlKey);
            this.Controls.Add(this.pic);
            this.Name = "IconStub";
            this.Size = new System.Drawing.Size(170, 35);
            this.Resize += new System.EventHandler(this.IconStub_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        private nEdit_String ctlKey;
        private System.Windows.Forms.LinkLabel lblSet;
        private System.Windows.Forms.LinkLabel lblClear;
        private System.Windows.Forms.ImageList IM;
    }
}
