using Tools.Database;
namespace Rz5
{
    partial class frmRzTieServer
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
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.cmdApply = new System.Windows.Forms.Button();
            this.ctlPort = new NewMethod.nEdit_Number();
            this.ctlServerName = new NewMethod.nEdit_String();
            this.xEye = new Tie.EyeView();
            this.ctlUseHook = new NewMethod.nEdit_Boolean();
            this.ctlPassword = new NewMethod.nEdit_String();
            this.gbSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.ctlPassword);
            this.gbSettings.Controls.Add(this.ctlUseHook);
            this.gbSettings.Controls.Add(this.cmdApply);
            this.gbSettings.Controls.Add(this.ctlPort);
            this.gbSettings.Controls.Add(this.ctlServerName);
            this.gbSettings.Location = new System.Drawing.Point(6, 5);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(186, 420);
            this.gbSettings.TabIndex = 0;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // cmdApply
            // 
            this.cmdApply.Location = new System.Drawing.Point(121, 71);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(54, 37);
            this.cmdApply.TabIndex = 2;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // ctlPort
            // 
            this.ctlPort.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlPort.Bold = false;
            this.ctlPort.Caption = "Port";
            this.ctlPort.Changed = false;
            this.ctlPort.CurrentType = FieldType.Unknown;
            this.ctlPort.Location = new System.Drawing.Point(8, 64);
            this.ctlPort.Name = "ctlPort";
            this.ctlPort.Size = new System.Drawing.Size(107, 44);
            this.ctlPort.TabIndex = 1;
            this.ctlPort.UseParentBackColor = false;
            this.ctlPort.zz_Enabled = true;
            this.ctlPort.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlPort.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlPort.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlPort.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPort.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctlPort.zz_OriginalDesign = true;
            this.ctlPort.zz_ShowErrorColor = true;
            this.ctlPort.zz_ShowNeedsSaveColor = true;
            this.ctlPort.zz_Text = "";
            this.ctlPort.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctlPort.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlPort.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPort.zz_UseGlobalColor = false;
            this.ctlPort.zz_UseGlobalFont = false;
            // 
            // ctlServerName
            // 
            this.ctlServerName.AllCaps = false;
            this.ctlServerName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlServerName.Bold = false;
            this.ctlServerName.Caption = "Server Name";
            this.ctlServerName.Changed = false;
            this.ctlServerName.IsEmail = false;
            this.ctlServerName.IsURL = false;
            this.ctlServerName.Location = new System.Drawing.Point(8, 22);
            this.ctlServerName.Name = "ctlServerName";
            this.ctlServerName.PasswordChar = '\0';
            this.ctlServerName.Size = new System.Drawing.Size(167, 43);
            this.ctlServerName.TabIndex = 0;
            this.ctlServerName.UseParentBackColor = false;
            this.ctlServerName.zz_Enabled = true;
            this.ctlServerName.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlServerName.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlServerName.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlServerName.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServerName.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlServerName.zz_OriginalDesign = true;
            this.ctlServerName.zz_ShowLinkButton = false;
            this.ctlServerName.zz_ShowNeedsSaveColor = true;
            this.ctlServerName.zz_Text = "";
            this.ctlServerName.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlServerName.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlServerName.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServerName.zz_UseGlobalColor = false;
            this.ctlServerName.zz_UseGlobalFont = false;
            // 
            // xEye
            // 
            this.xEye.Location = new System.Drawing.Point(198, 12);
            this.xEye.Name = "xEye";
            this.xEye.Size = new System.Drawing.Size(474, 413);
            this.xEye.TabIndex = 1;
            // 
            // ctlUseHook
            // 
            this.ctlUseHook.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlUseHook.Bold = false;
            this.ctlUseHook.Caption = "Enable";
            this.ctlUseHook.Changed = false;
            this.ctlUseHook.Location = new System.Drawing.Point(116, 22);
            this.ctlUseHook.Name = "ctlUseHook";
            this.ctlUseHook.Size = new System.Drawing.Size(59, 18);
            this.ctlUseHook.TabIndex = 3;
            this.ctlUseHook.UseParentBackColor = false;
            this.ctlUseHook.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlUseHook.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlUseHook.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Left;
            this.ctlUseHook.zz_OriginalDesign = false;
            this.ctlUseHook.zz_ShowNeedsSaveColor = true;
            // 
            // ctlPassword
            // 
            this.ctlPassword.AllCaps = false;
            this.ctlPassword.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlPassword.Bold = false;
            this.ctlPassword.Caption = "Password";
            this.ctlPassword.Changed = false;
            this.ctlPassword.IsEmail = false;
            this.ctlPassword.IsURL = false;
            this.ctlPassword.Location = new System.Drawing.Point(8, 114);
            this.ctlPassword.Name = "ctlPassword";
            this.ctlPassword.PasswordChar = '*';
            this.ctlPassword.Size = new System.Drawing.Size(167, 43);
            this.ctlPassword.TabIndex = 4;
            this.ctlPassword.UseParentBackColor = false;
            this.ctlPassword.zz_Enabled = true;
            this.ctlPassword.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlPassword.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlPassword.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlPassword.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPassword.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlPassword.zz_OriginalDesign = true;
            this.ctlPassword.zz_ShowLinkButton = false;
            this.ctlPassword.zz_ShowNeedsSaveColor = true;
            this.ctlPassword.zz_Text = "";
            this.ctlPassword.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlPassword.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlPassword.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPassword.zz_UseGlobalColor = false;
            this.ctlPassword.zz_UseGlobalFont = false;
            // 
            // frmRzTieServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 437);
            this.Controls.Add(this.xEye);
            this.Controls.Add(this.gbSettings);
            this.Name = "frmRzTieServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rz3 Tie Server";
            this.gbSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSettings;
        private NewMethod.nEdit_String ctlServerName;
        private System.Windows.Forms.Button cmdApply;
        private NewMethod.nEdit_Number ctlPort;
        private Tie.EyeView xEye;
        private NewMethod.nEdit_Boolean ctlUseHook;
        private NewMethod.nEdit_String ctlPassword;
    }
}