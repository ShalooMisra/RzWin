namespace Rz5
{
    partial class frmWorldShipSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWorldShipSettings));
            this.ctlXMLPath = new NewMethod.nEdit_String();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.xFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.cmdSave = new System.Windows.Forms.Button();
            this.ctlUseWorldship = new NewMethod.nEdit_Boolean();
            this.SuspendLayout();
            // 
            // ctlXMLPath
            // 
            this.ctlXMLPath.AllCaps = false;
            this.ctlXMLPath.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlXMLPath.Bold = false;
            this.ctlXMLPath.Caption = "Auto-XML Import Folder";
            this.ctlXMLPath.Changed = false;
            this.ctlXMLPath.IsEmail = false;
            this.ctlXMLPath.IsURL = false;
            this.ctlXMLPath.Location = new System.Drawing.Point(6, 4);
            this.ctlXMLPath.Name = "ctlXMLPath";
            this.ctlXMLPath.PasswordChar = '\0';
            this.ctlXMLPath.Size = new System.Drawing.Size(320, 41);
            this.ctlXMLPath.TabIndex = 0;
            this.ctlXMLPath.UseParentBackColor = false;
            this.ctlXMLPath.zz_Enabled = true;
            this.ctlXMLPath.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlXMLPath.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlXMLPath.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlXMLPath.zz_LabelFont = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlXMLPath.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlXMLPath.zz_OriginalDesign = false;
            this.ctlXMLPath.zz_ShowLinkButton = false;
            this.ctlXMLPath.zz_ShowNeedsSaveColor = false;
            this.ctlXMLPath.zz_Text = "";
            this.ctlXMLPath.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlXMLPath.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlXMLPath.zz_TextFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlXMLPath.zz_UseGlobalColor = false;
            this.ctlXMLPath.zz_UseGlobalFont = false;
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBrowse.Location = new System.Drawing.Point(332, 22);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(34, 23);
            this.cmdBrowse.TabIndex = 1;
            this.cmdBrowse.Text = "...";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Location = new System.Drawing.Point(6, 51);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(360, 26);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "Save And Exit";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // ctlUseWorldship
            // 
            this.ctlUseWorldship.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlUseWorldship.Bold = false;
            this.ctlUseWorldship.Caption = "Use Worldship";
            this.ctlUseWorldship.Changed = false;
            this.ctlUseWorldship.Location = new System.Drawing.Point(241, 1);
            this.ctlUseWorldship.Name = "ctlUseWorldship";
            this.ctlUseWorldship.Size = new System.Drawing.Size(129, 18);
            this.ctlUseWorldship.TabIndex = 3;
            this.ctlUseWorldship.UseParentBackColor = false;
            this.ctlUseWorldship.zz_CheckValue = false;
            this.ctlUseWorldship.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlUseWorldship.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlUseWorldship.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctlUseWorldship.zz_OriginalDesign = false;
            this.ctlUseWorldship.zz_ShowNeedsSaveColor = true;
            // 
            // frmWorldShipSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 83);
            this.Controls.Add(this.ctlUseWorldship);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.ctlXMLPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmWorldShipSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Worldship Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nEdit_String ctlXMLPath;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.FolderBrowserDialog xFolder;
        private System.Windows.Forms.Button cmdSave;
        private NewMethod.nEdit_Boolean ctlUseWorldship;
    }
}