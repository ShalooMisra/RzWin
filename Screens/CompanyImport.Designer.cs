namespace Rz5
{
    partial class CompanyImport
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
            this.ctlSource = new NewMethod.nEdit_String();
            this.dv = new NewMethod.nDataView();
            this.bgImport = new System.ComponentModel.BackgroundWorker();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.BackColor = System.Drawing.Color.White;
            this.gb.Controls.Add(this.ctlSource);
            this.gb.Location = new System.Drawing.Point(3, 3);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(161, 431);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            // 
            // ctlSource
            // 
            this.ctlSource.AllCaps = false;
            this.ctlSource.BackColor = System.Drawing.Color.White;
            this.ctlSource.Bold = false;
            this.ctlSource.Caption = "Source";
            this.ctlSource.Changed = false;
            this.ctlSource.IsEmail = false;
            this.ctlSource.IsURL = false;
            this.ctlSource.Location = new System.Drawing.Point(6, 16);
            this.ctlSource.Name = "ctlSource";
            this.ctlSource.PasswordChar = '\0';
            this.ctlSource.Size = new System.Drawing.Size(149, 47);
            this.ctlSource.TabIndex = 0;
            this.ctlSource.UseParentBackColor = true;
            this.ctlSource.zz_Enabled = true;
            this.ctlSource.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlSource.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlSource.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlSource.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctlSource.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlSource.zz_OriginalDesign = true;
            this.ctlSource.zz_ShowLinkButton = false;
            this.ctlSource.zz_ShowNeedsSaveColor = true;
            this.ctlSource.zz_Text = "";
            this.ctlSource.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlSource.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlSource.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlSource.zz_UseGlobalColor = false;
            this.ctlSource.zz_UseGlobalFont = false;
            // 
            // dv
            // 
            this.dv.AlwaysDisableAccept = false;
            this.dv.BackColor = System.Drawing.Color.White;
            this.dv.DisableAutoMatching = false;
            this.dv.HideOptions = false;
            this.dv.Location = new System.Drawing.Point(170, 9);
            this.dv.Name = "dv";
            this.dv.Size = new System.Drawing.Size(239, 387);
            this.dv.TabIndex = 1;
            this.dv.Accept += new NewMethod.nDataViewAcceptHandler(this.dv_Accept);
            // 
            // bgImport
            // 
            this.bgImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgImport_DoWork);
            this.bgImport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgImport_RunWorkerCompleted);
            // 
            // CompanyImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dv);
            this.Controls.Add(this.gb);
            this.Name = "CompanyImport";
            this.Size = new System.Drawing.Size(437, 470);
            this.Resize += new System.EventHandler(this.CompanyImport_Resize);
            this.gb.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private NewMethod.nDataView dv;
        private System.ComponentModel.BackgroundWorker bgImport;
        private NewMethod.nEdit_String ctlSource;
    }
}
