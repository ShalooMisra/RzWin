namespace Rz5
{
    partial class frmQuickbooksSalesRepsTests
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
            this.gbSearchRep = new System.Windows.Forms.GroupBox();
            this.btnSearchByUser = new System.Windows.Forms.Button();
            this.btnSearchByInitials = new System.Windows.Forms.Button();
            this.ctlQuery = new NewMethod.nEdit_String();
            this.nEdit_User1 = new NewMethod.nEdit_User();
            this.gbSearchRep.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSearchRep
            // 
            this.gbSearchRep.Controls.Add(this.btnSearchByUser);
            this.gbSearchRep.Controls.Add(this.btnSearchByInitials);
            this.gbSearchRep.Controls.Add(this.ctlQuery);
            this.gbSearchRep.Controls.Add(this.nEdit_User1);
            this.gbSearchRep.Location = new System.Drawing.Point(13, 13);
            this.gbSearchRep.Name = "gbSearchRep";
            this.gbSearchRep.Size = new System.Drawing.Size(730, 147);
            this.gbSearchRep.TabIndex = 0;
            this.gbSearchRep.TabStop = false;
            this.gbSearchRep.Text = "Search for Rep";
            // 
            // btnSearchByUser
            // 
            this.btnSearchByUser.Location = new System.Drawing.Point(211, 87);
            this.btnSearchByUser.Name = "btnSearchByUser";
            this.btnSearchByUser.Size = new System.Drawing.Size(192, 23);
            this.btnSearchByUser.TabIndex = 3;
            this.btnSearchByUser.Text = "Search By User";
            this.btnSearchByUser.UseVisualStyleBackColor = true;
            this.btnSearchByUser.Click += new System.EventHandler(this.btnSearchByUser_Click);
            // 
            // btnSearchByInitials
            // 
            this.btnSearchByInitials.Location = new System.Drawing.Point(7, 87);
            this.btnSearchByInitials.Name = "btnSearchByInitials";
            this.btnSearchByInitials.Size = new System.Drawing.Size(179, 23);
            this.btnSearchByInitials.TabIndex = 2;
            this.btnSearchByInitials.Text = "Search";
            this.btnSearchByInitials.UseVisualStyleBackColor = true;
            this.btnSearchByInitials.Click += new System.EventHandler(this.btnSearchByInitials_Click);
            // 
            // ctlQuery
            // 
            this.ctlQuery.AllCaps = false;
            this.ctlQuery.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlQuery.Bold = false;
            this.ctlQuery.Caption = "Search Query";
            this.ctlQuery.Changed = false;
            this.ctlQuery.IsEmail = false;
            this.ctlQuery.IsURL = false;
            this.ctlQuery.Location = new System.Drawing.Point(7, 41);
            this.ctlQuery.Name = "ctlQuery";
            this.ctlQuery.PasswordChar = '\0';
            this.ctlQuery.Size = new System.Drawing.Size(179, 40);
            this.ctlQuery.TabIndex = 1;
            this.ctlQuery.UseParentBackColor = false;
            this.ctlQuery.zz_Enabled = true;
            this.ctlQuery.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlQuery.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlQuery.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlQuery.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlQuery.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlQuery.zz_OriginalDesign = true;
            this.ctlQuery.zz_ShowLinkButton = false;
            this.ctlQuery.zz_ShowNeedsSaveColor = true;
            this.ctlQuery.zz_Text = "";
            this.ctlQuery.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlQuery.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlQuery.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlQuery.zz_UseGlobalColor = false;
            this.ctlQuery.zz_UseGlobalFont = false;
            // 
            // nEdit_User1
            // 
            this.nEdit_User1.AllowChange = true;
            this.nEdit_User1.AllowClear = false;
            this.nEdit_User1.AllowNew = false;
            this.nEdit_User1.AllowView = false;
            this.nEdit_User1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nEdit_User1.Bold = false;
            this.nEdit_User1.Caption = "Select User";
            this.nEdit_User1.Changed = false;
            this.nEdit_User1.Location = new System.Drawing.Point(211, 24);
            this.nEdit_User1.Name = "nEdit_User1";
            this.nEdit_User1.Size = new System.Drawing.Size(192, 57);
            this.nEdit_User1.TabIndex = 0;
            this.nEdit_User1.UseParentBackColor = false;
            this.nEdit_User1.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.nEdit_User1.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // frmQuickbooksSalesRepsTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbSearchRep);
            this.Name = "frmQuickbooksSalesRepsTests";
            this.Text = "Quickbooks Sales Rep Tests";
            this.gbSearchRep.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSearchRep;
        private NewMethod.nEdit_User nEdit_User1;
        private System.Windows.Forms.Button btnSearchByUser;
        private System.Windows.Forms.Button btnSearchByInitials;
        private NewMethod.nEdit_String ctlQuery;
    }
}