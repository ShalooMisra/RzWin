namespace Rz5
{
    partial class ContactImport
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
            this.cmdImport = new System.Windows.Forms.Button();
            this.ctlAgent = new NewMethod.nEdit_User();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.dv = new NewMethod.nDataView();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.BackColor = System.Drawing.Color.White;
            this.gb.Controls.Add(this.cmdImport);
            this.gb.Controls.Add(this.ctlAgent);
            this.gb.Location = new System.Drawing.Point(12, 3);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(207, 595);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            // 
            // cmdImport
            // 
            this.cmdImport.Location = new System.Drawing.Point(6, 211);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(195, 49);
            this.cmdImport.TabIndex = 3;
            this.cmdImport.Text = "Import";
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // ctlAgent
            // 
            this.ctlAgent.AllowChange = true;
            this.ctlAgent.AllowClear = false;
            this.ctlAgent.AllowNew = false;
            this.ctlAgent.AllowView = false;
            this.ctlAgent.BackColor = System.Drawing.Color.White;
            this.ctlAgent.Bold = false;
            this.ctlAgent.Caption = "Agent";
            this.ctlAgent.Changed = false;
            this.ctlAgent.Location = new System.Drawing.Point(6, 15);
            this.ctlAgent.Name = "ctlAgent";
            this.ctlAgent.Size = new System.Drawing.Size(134, 35);
            this.ctlAgent.TabIndex = 0;
            this.ctlAgent.UseParentBackColor = true;
            this.ctlAgent.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlAgent.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctlAgent.ChangeUser += new NewMethod.ChangeUserHandler(this.ctlAgent_ChangeUser);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(225, 502);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(536, 96);
            this.txtStatus.TabIndex = 2;
            this.txtStatus.WordWrap = false;
            // 
            // dv
            // 
            this.dv.AlwaysDisableAccept = true;
            this.dv.BackColor = System.Drawing.Color.White;
            this.dv.DisableAutoMatching = false;
            this.dv.HideOptions = false;
            this.dv.Location = new System.Drawing.Point(225, 32);
            this.dv.Name = "dv";
            this.dv.Size = new System.Drawing.Size(536, 459);
            this.dv.TabIndex = 1;
            // 
            // ContactImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.dv);
            this.Controls.Add(this.gb);
            this.Name = "ContactImport";
            this.Size = new System.Drawing.Size(780, 624);
            this.Load += new System.EventHandler(this.ContactImport_Load);
            this.Resize += new System.EventHandler(this.ContactImport_Resize);
            this.gb.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStatus;
        protected System.Windows.Forms.GroupBox gb;
        protected NewMethod.nEdit_User ctlAgent;
        protected System.Windows.Forms.Button cmdImport;
        protected NewMethod.nDataView dv;
    }
}
