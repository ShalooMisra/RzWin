namespace Rz5
{
    partial class frmLinkMFG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLinkMFG));
            this.IM24 = new System.Windows.Forms.ImageList(this.components);
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.ctl_MFGList = new NewMethod.nEdit_List();
            this.SuspendLayout();
            // 
            // IM24
            // 
            this.IM24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IM24.ImageStream")));
            this.IM24.TransparentColor = System.Drawing.Color.Fuchsia;
            this.IM24.Images.SetKeyName(0, "cancel");
            this.IM24.Images.SetKeyName(1, "ok");
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.ImageKey = "cancel";
            this.cmdCancel.ImageList = this.IM24;
            this.cmdCancel.Location = new System.Drawing.Point(12, 66);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(126, 43);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "  Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOK.ImageKey = "ok";
            this.cmdOK.ImageList = this.IM24;
            this.cmdOK.Location = new System.Drawing.Point(273, 66);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(126, 43);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // ctl_MFGList
            // 
            this.ctl_MFGList.AllCaps = false;
            this.ctl_MFGList.AllowEdit = true;
            this.ctl_MFGList.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_MFGList.Bold = false;
            this.ctl_MFGList.Caption = ".";
            this.ctl_MFGList.Changed = false;
            this.ctl_MFGList.ListName = "";
            this.ctl_MFGList.Location = new System.Drawing.Point(12, 12);
            this.ctl_MFGList.Name = "ctl_MFGList";
            this.ctl_MFGList.SimpleList = null;
            this.ctl_MFGList.Size = new System.Drawing.Size(387, 48);
            this.ctl_MFGList.TabIndex = 6;
            this.ctl_MFGList.UseParentBackColor = false;
            this.ctl_MFGList.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_MFGList.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_MFGList.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_MFGList.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_MFGList.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_MFGList.zz_OriginalDesign = false;
            this.ctl_MFGList.zz_ShowNeedsSaveColor = false;
            this.ctl_MFGList.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_MFGList.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_MFGList.zz_UseGlobalColor = false;
            this.ctl_MFGList.zz_UseGlobalFont = false;
            // 
            // frmLinkMFG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 118);
            this.Controls.Add(this.ctl_MFGList);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLinkMFG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select A Manufacturer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.ImageList IM24;
        private System.Windows.Forms.Button cmdOK;
        private NewMethod.nEdit_List ctl_MFGList;
    }
}