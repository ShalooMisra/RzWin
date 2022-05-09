namespace NewMethod
{
    partial class GroupManager
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
            this.gb = new System.Windows.Forms.GroupBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.gbg = new System.Windows.Forms.GroupBox();
            this.lblClear = new System.Windows.Forms.LinkLabel();
            this.lblSetUser = new System.Windows.Forms.LinkLabel();
            this.lblSetTeam = new System.Windows.Forms.LinkLabel();
            this.lblPermit = new System.Windows.Forms.Label();
            this.cmdApply = new System.Windows.Forms.Button();
            this.ctlName = new NewMethod.nEdit_String();
            this.lv = new NewMethod.nList();
            this.lblRemove = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.gb.SuspendLayout();
            this.gbg.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.lblClass);
            this.gb.Location = new System.Drawing.Point(2, 4);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(465, 44);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(9, 17);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(72, 13);
            this.lblClass.TabIndex = 0;
            this.lblClass.Text = "<class name>";
            // 
            // gbg
            // 
            this.gbg.BackColor = System.Drawing.Color.White;
            this.gbg.Controls.Add(this.label1);
            this.gbg.Controls.Add(this.lblRemove);
            this.gbg.Controls.Add(this.lblClear);
            this.gbg.Controls.Add(this.lblSetUser);
            this.gbg.Controls.Add(this.lblSetTeam);
            this.gbg.Controls.Add(this.lblPermit);
            this.gbg.Controls.Add(this.cmdApply);
            this.gbg.Controls.Add(this.ctlName);
            this.gbg.Location = new System.Drawing.Point(483, 10);
            this.gbg.Name = "gbg";
            this.gbg.Size = new System.Drawing.Size(349, 392);
            this.gbg.TabIndex = 2;
            this.gbg.TabStop = false;
            this.gbg.Text = "<group>";
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.Location = new System.Drawing.Point(11, 166);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(30, 13);
            this.lblClear.TabIndex = 7;
            this.lblClear.TabStop = true;
            this.lblClear.Text = "clear";
            this.lblClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblClear_LinkClicked);
            // 
            // lblSetUser
            // 
            this.lblSetUser.AutoSize = true;
            this.lblSetUser.Location = new System.Drawing.Point(10, 147);
            this.lblSetUser.Name = "lblSetUser";
            this.lblSetUser.Size = new System.Drawing.Size(44, 13);
            this.lblSetUser.TabIndex = 6;
            this.lblSetUser.TabStop = true;
            this.lblSetUser.Text = "set user";
            this.lblSetUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSetUser_LinkClicked);
            // 
            // lblSetTeam
            // 
            this.lblSetTeam.AutoSize = true;
            this.lblSetTeam.Location = new System.Drawing.Point(10, 130);
            this.lblSetTeam.Name = "lblSetTeam";
            this.lblSetTeam.Size = new System.Drawing.Size(47, 13);
            this.lblSetTeam.TabIndex = 5;
            this.lblSetTeam.TabStop = true;
            this.lblSetTeam.Text = "set team";
            this.lblSetTeam.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSetTeam_LinkClicked);
            // 
            // lblPermit
            // 
            this.lblPermit.AutoSize = true;
            this.lblPermit.Location = new System.Drawing.Point(6, 110);
            this.lblPermit.Name = "lblPermit";
            this.lblPermit.Size = new System.Drawing.Size(47, 13);
            this.lblPermit.TabIndex = 4;
            this.lblPermit.Text = "<permit>";
            // 
            // cmdApply
            // 
            this.cmdApply.Location = new System.Drawing.Point(243, 14);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(100, 24);
            this.cmdApply.TabIndex = 3;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // ctlName
            // 
            this.ctlName.AllCaps = false;
            this.ctlName.BackColor = System.Drawing.Color.White;
            this.ctlName.Bold = false;
            this.ctlName.Caption = "Name";
            this.ctlName.Changed = false;
            this.ctlName.IsEmail = false;
            this.ctlName.IsURL = false;
            this.ctlName.Location = new System.Drawing.Point(9, 21);
            this.ctlName.Name = "ctlName";
            this.ctlName.PasswordChar = '\0';
            this.ctlName.Size = new System.Drawing.Size(334, 45);
            this.ctlName.TabIndex = 0;
            this.ctlName.UseParentBackColor = true;
            this.ctlName.zz_Enabled = true;
            this.ctlName.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlName.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlName.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlName.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlName.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlName.zz_OriginalDesign = true;
            this.ctlName.zz_ShowLinkButton = false;
            this.ctlName.zz_ShowNeedsSaveColor = true;
            this.ctlName.zz_Text = "";
            this.ctlName.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlName.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlName.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlName.zz_UseGlobalColor = false;
            this.ctlName.zz_UseGlobalFont = false;
            // 
            // lv
            // 
            this.lv.AddCaption = "Add New Group";
            this.lv.AllowAdd = true;
            this.lv.AllowDelete = true;
            this.lv.Caption = "";
            this.lv.ExtraClassInfo = "";
            this.lv.Location = new System.Drawing.Point(7, 57);
            this.lv.MultiSelect = true;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(460, 439);
            this.lv.SuppressSelectionChanged = false;
            this.lv.TabIndex = 1;
            this.lv.ObjectClicked += new NewMethod.ObjectClickHandler(this.lv_ObjectClicked);
            this.lv.AboutToAdd += new NewMethod.AddHandler(this.lv_AboutToAdd);
            // 
            // lblRemove
            // 
            this.lblRemove.AutoSize = true;
            this.lblRemove.Location = new System.Drawing.Point(159, 65);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(183, 13);
            this.lblRemove.TabIndex = 8;
            this.lblRemove.TabStop = true;
            this.lblRemove.Text = "completely remove from the database";
            this.lblRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRemove_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Permissions";
            // 
            // GroupManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbg);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.gb);
            this.Name = "GroupManager";
            this.Size = new System.Drawing.Size(946, 544);
            this.Resize += new System.EventHandler(this.GroupManager_Resize);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.gbg.ResumeLayout(false);
            this.gbg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Label lblClass;
        private nList lv;
        private System.Windows.Forms.GroupBox gbg;
        private System.Windows.Forms.Button cmdApply;
        private nEdit_String ctlName;
        private System.Windows.Forms.Label lblPermit;
        private System.Windows.Forms.LinkLabel lblSetUser;
        private System.Windows.Forms.LinkLabel lblSetTeam;
        private System.Windows.Forms.LinkLabel lblClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lblRemove;
    }
}
