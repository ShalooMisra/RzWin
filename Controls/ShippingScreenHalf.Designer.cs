namespace Rz5.Win.Controls
{
    partial class ShippingScreenHalf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShippingScreenHalf));
            this.pic = new System.Windows.Forms.PictureBox();
            this.chkInOut = new System.Windows.Forms.CheckBox();
            this.chkService = new System.Windows.Forms.CheckBox();
            this.chkRMA = new System.Windows.Forms.CheckBox();
            this.lv = new NewMethod.nList();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.pTop = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.pTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(3, 3);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(183, 110);
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            // 
            // chkInOut
            // 
            this.chkInOut.AutoSize = true;
            this.chkInOut.Checked = true;
            this.chkInOut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInOut.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInOut.Location = new System.Drawing.Point(192, 7);
            this.chkInOut.Name = "chkInOut";
            this.chkInOut.Size = new System.Drawing.Size(64, 23);
            this.chkInOut.TabIndex = 1;
            this.chkInOut.Text = "InOut";
            this.chkInOut.UseVisualStyleBackColor = true;
            // 
            // chkService
            // 
            this.chkService.AutoSize = true;
            this.chkService.Checked = true;
            this.chkService.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkService.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkService.Location = new System.Drawing.Point(192, 40);
            this.chkService.Name = "chkService";
            this.chkService.Size = new System.Drawing.Size(74, 23);
            this.chkService.TabIndex = 2;
            this.chkService.Text = "Service";
            this.chkService.UseVisualStyleBackColor = true;
            // 
            // chkRMA
            // 
            this.chkRMA.AutoSize = true;
            this.chkRMA.Checked = true;
            this.chkRMA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRMA.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRMA.Location = new System.Drawing.Point(192, 76);
            this.chkRMA.Name = "chkRMA";
            this.chkRMA.Size = new System.Drawing.Size(59, 23);
            this.chkRMA.TabIndex = 3;
            this.chkRMA.Text = "RMA";
            this.chkRMA.UseVisualStyleBackColor = true;
            // 
            // lv
            // 
            this.lv.AddCaption = "Add New";
            this.lv.AllowActions = true;
            this.lv.AllowAdd = false;
            this.lv.AllowDelete = true;
            this.lv.AllowDeleteAlways = false;
            this.lv.AllowDrop = true;
            this.lv.AlternateConnection = null;
            this.lv.Caption = "";
            this.lv.CurrentTemplate = null;
            this.lv.ExtraClassInfo = "";
            this.lv.Location = new System.Drawing.Point(8, 149);
            this.lv.MultiSelect = true;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(444, 337);
            this.lv.SuppressSelectionChanged = false;
            this.lv.TabIndex = 4;
            this.lv.zz_OpenColumnMenu = false;
            this.lv.zz_ShowAutoRefresh = true;
            this.lv.zz_ShowUnlimited = true;
            this.lv.AboutToThrow += new Core.ShowHandler(this.lv_AboutToThrow);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Transparent;
            this.il.Images.SetKeyName(0, "PutAway");
            this.il.Images.SetKeyName(1, "Ship");
            // 
            // pTop
            // 
            this.pTop.Controls.Add(this.pic);
            this.pTop.Controls.Add(this.chkInOut);
            this.pTop.Controls.Add(this.chkRMA);
            this.pTop.Controls.Add(this.chkService);
            this.pTop.Location = new System.Drawing.Point(8, 12);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(377, 120);
            this.pTop.TabIndex = 5;
            // 
            // ShippingScreenHalf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pTop);
            this.Controls.Add(this.lv);
            this.Name = "ShippingScreenHalf";
            this.Size = new System.Drawing.Size(471, 499);
            this.Resize += new System.EventHandler(this.ShippingScreenHalf_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.pTop.ResumeLayout(false);
            this.pTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.CheckBox chkInOut;
        private System.Windows.Forms.CheckBox chkService;
        private System.Windows.Forms.CheckBox chkRMA;
        private NewMethod.nList lv;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.Panel pTop;
    }
}
