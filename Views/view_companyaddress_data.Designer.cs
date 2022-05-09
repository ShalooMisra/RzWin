namespace Rz5
{
    partial class view_companyaddress_data
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
            this.gb = new System.Windows.Forms.GroupBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdChoose = new System.Windows.Forms.Button();
            this.ctl_adrcountry = new NewMethod.nEdit_String();
            this.ctl_adrzip = new NewMethod.nEdit_String();
            this.ctl_adrstate = new NewMethod.nEdit_String();
            this.ctl_adrcity = new NewMethod.nEdit_String();
            this.ctl_line3 = new NewMethod.nEdit_String();
            this.ctl_line2 = new NewMethod.nEdit_String();
            this.ctl_line1 = new NewMethod.nEdit_String();
            this.ctl_description = new NewMethod.nEdit_String();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.cmdSave);
            this.gb.Controls.Add(this.cmdChoose);
            this.gb.Controls.Add(this.ctl_adrcountry);
            this.gb.Controls.Add(this.ctl_adrzip);
            this.gb.Controls.Add(this.ctl_adrstate);
            this.gb.Controls.Add(this.ctl_adrcity);
            this.gb.Controls.Add(this.ctl_line3);
            this.gb.Controls.Add(this.ctl_line2);
            this.gb.Controls.Add(this.ctl_line1);
            this.gb.Controls.Add(this.ctl_description);
            this.gb.Location = new System.Drawing.Point(3, 3);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(334, 274);
            this.gb.TabIndex = 1;
            this.gb.TabStop = false;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(250, 15);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(78, 20);
            this.cmdSave.TabIndex = 10;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Visible = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdChoose
            // 
            this.cmdChoose.Location = new System.Drawing.Point(250, 35);
            this.cmdChoose.Name = "cmdChoose";
            this.cmdChoose.Size = new System.Drawing.Size(78, 20);
            this.cmdChoose.TabIndex = 9;
            this.cmdChoose.Text = "Choose";
            this.cmdChoose.UseVisualStyleBackColor = true;
            this.cmdChoose.Visible = false;
            this.cmdChoose.Click += new System.EventHandler(this.cmdChoose_Click);
            // 
            // ctl_adrcountry
            // 
            this.ctl_adrcountry.AllCaps = false;
            this.ctl_adrcountry.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_adrcountry.Bold = false;
            this.ctl_adrcountry.Caption = "Country";
            this.ctl_adrcountry.Changed = false;
            this.ctl_adrcountry.IsEmail = false;
            this.ctl_adrcountry.IsURL = false;
            this.ctl_adrcountry.Location = new System.Drawing.Point(8, 222);
            this.ctl_adrcountry.Name = "ctl_adrcountry";
            this.ctl_adrcountry.PasswordChar = '\0';
            this.ctl_adrcountry.Size = new System.Drawing.Size(324, 46);
            this.ctl_adrcountry.TabIndex = 8;
            this.ctl_adrcountry.UseParentBackColor = false;
            this.ctl_adrcountry.zz_Enabled = true;
            this.ctl_adrcountry.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_adrcountry.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_adrcountry.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_adrcountry.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_adrcountry.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_adrcountry.zz_OriginalDesign = true;
            this.ctl_adrcountry.zz_ShowLinkButton = false;
            this.ctl_adrcountry.zz_ShowNeedsSaveColor = true;
            this.ctl_adrcountry.zz_Text = "";
            this.ctl_adrcountry.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_adrcountry.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_adrcountry.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_adrcountry.zz_UseGlobalColor = false;
            this.ctl_adrcountry.zz_UseGlobalFont = false;
            // 
            // ctl_adrzip
            // 
            this.ctl_adrzip.AllCaps = false;
            this.ctl_adrzip.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_adrzip.Bold = false;
            this.ctl_adrzip.Caption = "Zip";
            this.ctl_adrzip.Changed = false;
            this.ctl_adrzip.IsEmail = false;
            this.ctl_adrzip.IsURL = false;
            this.ctl_adrzip.Location = new System.Drawing.Point(208, 180);
            this.ctl_adrzip.Name = "ctl_adrzip";
            this.ctl_adrzip.PasswordChar = '\0';
            this.ctl_adrzip.Size = new System.Drawing.Size(124, 46);
            this.ctl_adrzip.TabIndex = 7;
            this.ctl_adrzip.UseParentBackColor = false;
            this.ctl_adrzip.zz_Enabled = true;
            this.ctl_adrzip.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_adrzip.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_adrzip.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_adrzip.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_adrzip.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_adrzip.zz_OriginalDesign = true;
            this.ctl_adrzip.zz_ShowLinkButton = false;
            this.ctl_adrzip.zz_ShowNeedsSaveColor = true;
            this.ctl_adrzip.zz_Text = "";
            this.ctl_adrzip.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_adrzip.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_adrzip.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_adrzip.zz_UseGlobalColor = false;
            this.ctl_adrzip.zz_UseGlobalFont = false;
            // 
            // ctl_adrstate
            // 
            this.ctl_adrstate.AllCaps = false;
            this.ctl_adrstate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_adrstate.Bold = false;
            this.ctl_adrstate.Caption = "State";
            this.ctl_adrstate.Changed = false;
            this.ctl_adrstate.IsEmail = false;
            this.ctl_adrstate.IsURL = false;
            this.ctl_adrstate.Location = new System.Drawing.Point(132, 180);
            this.ctl_adrstate.Name = "ctl_adrstate";
            this.ctl_adrstate.PasswordChar = '\0';
            this.ctl_adrstate.Size = new System.Drawing.Size(70, 46);
            this.ctl_adrstate.TabIndex = 6;
            this.ctl_adrstate.UseParentBackColor = false;
            this.ctl_adrstate.zz_Enabled = true;
            this.ctl_adrstate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_adrstate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_adrstate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_adrstate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_adrstate.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_adrstate.zz_OriginalDesign = true;
            this.ctl_adrstate.zz_ShowLinkButton = false;
            this.ctl_adrstate.zz_ShowNeedsSaveColor = true;
            this.ctl_adrstate.zz_Text = "";
            this.ctl_adrstate.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_adrstate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_adrstate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_adrstate.zz_UseGlobalColor = false;
            this.ctl_adrstate.zz_UseGlobalFont = false;
            // 
            // ctl_adrcity
            // 
            this.ctl_adrcity.AllCaps = false;
            this.ctl_adrcity.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_adrcity.Bold = false;
            this.ctl_adrcity.Caption = "City";
            this.ctl_adrcity.Changed = false;
            this.ctl_adrcity.IsEmail = false;
            this.ctl_adrcity.IsURL = false;
            this.ctl_adrcity.Location = new System.Drawing.Point(7, 180);
            this.ctl_adrcity.Name = "ctl_adrcity";
            this.ctl_adrcity.PasswordChar = '\0';
            this.ctl_adrcity.Size = new System.Drawing.Size(119, 46);
            this.ctl_adrcity.TabIndex = 5;
            this.ctl_adrcity.UseParentBackColor = false;
            this.ctl_adrcity.zz_Enabled = true;
            this.ctl_adrcity.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_adrcity.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_adrcity.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_adrcity.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_adrcity.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_adrcity.zz_OriginalDesign = true;
            this.ctl_adrcity.zz_ShowLinkButton = false;
            this.ctl_adrcity.zz_ShowNeedsSaveColor = true;
            this.ctl_adrcity.zz_Text = "";
            this.ctl_adrcity.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_adrcity.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_adrcity.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_adrcity.zz_UseGlobalColor = false;
            this.ctl_adrcity.zz_UseGlobalFont = false;
            // 
            // ctl_line3
            // 
            this.ctl_line3.AllCaps = false;
            this.ctl_line3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_line3.Bold = false;
            this.ctl_line3.Caption = "Line 3";
            this.ctl_line3.Changed = false;
            this.ctl_line3.IsEmail = false;
            this.ctl_line3.IsURL = false;
            this.ctl_line3.Location = new System.Drawing.Point(8, 138);
            this.ctl_line3.Name = "ctl_line3";
            this.ctl_line3.PasswordChar = '\0';
            this.ctl_line3.Size = new System.Drawing.Size(324, 46);
            this.ctl_line3.TabIndex = 4;
            this.ctl_line3.UseParentBackColor = false;
            this.ctl_line3.zz_Enabled = true;
            this.ctl_line3.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_line3.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_line3.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_line3.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_line3.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_line3.zz_OriginalDesign = true;
            this.ctl_line3.zz_ShowLinkButton = false;
            this.ctl_line3.zz_ShowNeedsSaveColor = true;
            this.ctl_line3.zz_Text = "";
            this.ctl_line3.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_line3.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_line3.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_line3.zz_UseGlobalColor = false;
            this.ctl_line3.zz_UseGlobalFont = false;
            // 
            // ctl_line2
            // 
            this.ctl_line2.AllCaps = false;
            this.ctl_line2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_line2.Bold = false;
            this.ctl_line2.Caption = "Line 2";
            this.ctl_line2.Changed = false;
            this.ctl_line2.IsEmail = false;
            this.ctl_line2.IsURL = false;
            this.ctl_line2.Location = new System.Drawing.Point(7, 95);
            this.ctl_line2.Name = "ctl_line2";
            this.ctl_line2.PasswordChar = '\0';
            this.ctl_line2.Size = new System.Drawing.Size(325, 46);
            this.ctl_line2.TabIndex = 3;
            this.ctl_line2.UseParentBackColor = false;
            this.ctl_line2.zz_Enabled = true;
            this.ctl_line2.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_line2.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_line2.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_line2.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_line2.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_line2.zz_OriginalDesign = true;
            this.ctl_line2.zz_ShowLinkButton = false;
            this.ctl_line2.zz_ShowNeedsSaveColor = true;
            this.ctl_line2.zz_Text = "";
            this.ctl_line2.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_line2.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_line2.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_line2.zz_UseGlobalColor = false;
            this.ctl_line2.zz_UseGlobalFont = false;
            // 
            // ctl_line1
            // 
            this.ctl_line1.AllCaps = false;
            this.ctl_line1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_line1.Bold = false;
            this.ctl_line1.Caption = "Line 1";
            this.ctl_line1.Changed = false;
            this.ctl_line1.IsEmail = false;
            this.ctl_line1.IsURL = false;
            this.ctl_line1.Location = new System.Drawing.Point(7, 54);
            this.ctl_line1.Name = "ctl_line1";
            this.ctl_line1.PasswordChar = '\0';
            this.ctl_line1.Size = new System.Drawing.Size(325, 46);
            this.ctl_line1.TabIndex = 2;
            this.ctl_line1.UseParentBackColor = false;
            this.ctl_line1.zz_Enabled = true;
            this.ctl_line1.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_line1.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_line1.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_line1.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_line1.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_line1.zz_OriginalDesign = true;
            this.ctl_line1.zz_ShowLinkButton = false;
            this.ctl_line1.zz_ShowNeedsSaveColor = true;
            this.ctl_line1.zz_Text = "";
            this.ctl_line1.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_line1.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_line1.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_line1.zz_UseGlobalColor = false;
            this.ctl_line1.zz_UseGlobalFont = false;
            // 
            // ctl_description
            // 
            this.ctl_description.AllCaps = false;
            this.ctl_description.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_description.Bold = false;
            this.ctl_description.Caption = "Description";
            this.ctl_description.Changed = false;
            this.ctl_description.IsEmail = false;
            this.ctl_description.IsURL = false;
            this.ctl_description.Location = new System.Drawing.Point(8, 12);
            this.ctl_description.Name = "ctl_description";
            this.ctl_description.PasswordChar = '\0';
            this.ctl_description.Size = new System.Drawing.Size(236, 46);
            this.ctl_description.TabIndex = 1;
            this.ctl_description.UseParentBackColor = false;
            this.ctl_description.zz_Enabled = true;
            this.ctl_description.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_description.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_description.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_description.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_description.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_description.zz_OriginalDesign = true;
            this.ctl_description.zz_ShowLinkButton = false;
            this.ctl_description.zz_ShowNeedsSaveColor = true;
            this.ctl_description.zz_Text = "";
            this.ctl_description.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_description.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_description.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_description.zz_UseGlobalColor = false;
            this.ctl_description.zz_UseGlobalFont = false;
            // 
            // view_companyaddress_data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb);
            this.Name = "view_companyaddress_data";
            this.Size = new System.Drawing.Size(342, 283);
            this.gb.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private NewMethod.nEdit_String ctl_adrcountry;
        private NewMethod.nEdit_String ctl_adrzip;
        private NewMethod.nEdit_String ctl_adrstate;
        private NewMethod.nEdit_String ctl_adrcity;
        private NewMethod.nEdit_String ctl_line3;
        private NewMethod.nEdit_String ctl_line2;
        private NewMethod.nEdit_String ctl_line1;
        private NewMethod.nEdit_String ctl_description;
        private System.Windows.Forms.Button cmdChoose;
        private System.Windows.Forms.Button cmdSave;
    }
}
