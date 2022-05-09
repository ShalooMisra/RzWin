namespace NewMethod
{
    partial class SystemDerivationGuide
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmdDerive = new System.Windows.Forms.Button();
            this.cmdOpenSystem = new System.Windows.Forms.Button();
            this.targets = new NewMethod.DataTargetManager();
            this.ctlName = new NewMethod.nEdit_String();
            this.sl = new NewMethod.SysLine();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Structure Database Connection:";
            // 
            // cmdDerive
            // 
            this.cmdDerive.Enabled = false;
            this.cmdDerive.Location = new System.Drawing.Point(393, 194);
            this.cmdDerive.Name = "cmdDerive";
            this.cmdDerive.Size = new System.Drawing.Size(171, 39);
            this.cmdDerive.TabIndex = 4;
            this.cmdDerive.Text = "Derive";
            this.cmdDerive.UseVisualStyleBackColor = true;
            this.cmdDerive.Click += new System.EventHandler(this.cmdDerive_Click);
            // 
            // cmdOpenSystem
            // 
            this.cmdOpenSystem.Location = new System.Drawing.Point(575, 196);
            this.cmdOpenSystem.Name = "cmdOpenSystem";
            this.cmdOpenSystem.Size = new System.Drawing.Size(172, 36);
            this.cmdOpenSystem.TabIndex = 5;
            this.cmdOpenSystem.Text = "Open";
            this.cmdOpenSystem.UseVisualStyleBackColor = true;
            this.cmdOpenSystem.Visible = false;
            this.cmdOpenSystem.Click += new System.EventHandler(this.cmdOpenSystem_Click);
            // 
            // targets
            // 
            this.targets.BackColor = System.Drawing.Color.White;
            this.targets.Location = new System.Drawing.Point(11, 249);
            this.targets.Name = "targets";
            this.targets.Size = new System.Drawing.Size(755, 542);
            this.targets.TabIndex = 2;
            // 
            // ctlName
            // 
            this.ctlName.AllCaps = false;
            this.ctlName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlName.Bold = false;
            this.ctlName.Caption = "New System Name";
            this.ctlName.Changed = false;
            this.ctlName.IsEmail = false;
            this.ctlName.IsURL = false;
            this.ctlName.Location = new System.Drawing.Point(5, 181);
            this.ctlName.Name = "ctlName";
            this.ctlName.PasswordChar = '\0';
            this.ctlName.Size = new System.Drawing.Size(382, 43);
            this.ctlName.TabIndex = 1;
            this.ctlName.UseParentBackColor = false;
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
            this.ctlName.DataChanged += new NewMethod.ChangeHandler(this.ctlName_DataChanged);
            // 
            // sl
            // 
            this.sl.BackColor = System.Drawing.Color.White;
            this.sl.Location = new System.Drawing.Point(4, 5);
            this.sl.Name = "sl";
            this.sl.PassiveMode = true;
            this.sl.Size = new System.Drawing.Size(425, 155);
            this.sl.TabIndex = 0;
            // 
            // SystemDerivationGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdOpenSystem);
            this.Controls.Add(this.cmdDerive);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.targets);
            this.Controls.Add(this.ctlName);
            this.Controls.Add(this.sl);
            this.Name = "SystemDerivationGuide";
            this.Size = new System.Drawing.Size(940, 794);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SysLine sl;
        private nEdit_String ctlName;
        private DataTargetManager targets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdDerive;
        private System.Windows.Forms.Button cmdOpenSystem;
    }
}
