namespace Rz5
{
    partial class UpdateDownload
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
            this.lbFromPath = new System.Windows.Forms.Label();
            this.lblToPath = new System.Windows.Forms.Label();
            this.cmdGo = new System.Windows.Forms.Button();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.cmdChooseLocal = new System.Windows.Forms.Button();
            this.cmdHere = new System.Windows.Forms.Button();
            this.pControls = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmdImport = new System.Windows.Forms.Button();
            this.throb = new NewMethod.nThrobber();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkBeta = new System.Windows.Forms.CheckBox();
            this.optAlternate = new System.Windows.Forms.RadioButton();
            this.optMain = new System.Windows.Forms.RadioButton();
            this.chkClose = new System.Windows.Forms.CheckBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.RT = new System.Windows.Forms.RichTextBox();
            this.wb = new ToolsWin.BrowserPlain();
            this.bgwNewVersion = new System.ComponentModel.BackgroundWorker();
            this.pControls.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbFromPath
            // 
            this.lbFromPath.AutoSize = true;
            this.lbFromPath.Location = new System.Drawing.Point(166, 23);
            this.lbFromPath.Name = "lbFromPath";
            this.lbFromPath.Size = new System.Drawing.Size(105, 13);
            this.lbFromPath.TabIndex = 0;
            this.lbFromPath.Text = "From: <update path>";
            // 
            // lblToPath
            // 
            this.lblToPath.AutoSize = true;
            this.lblToPath.Location = new System.Drawing.Point(166, 38);
            this.lblToPath.Name = "lblToPath";
            this.lblToPath.Size = new System.Drawing.Size(95, 13);
            this.lblToPath.TabIndex = 1;
            this.lblToPath.Text = "To: <update path>";
            // 
            // cmdGo
            // 
            this.cmdGo.Enabled = false;
            this.cmdGo.Location = new System.Drawing.Point(8, 7);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(118, 80);
            this.cmdGo.TabIndex = 2;
            this.cmdGo.Text = "&Update";
            this.cmdGo.UseVisualStyleBackColor = true;
            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(8, 125);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(450, 13);
            this.pb.TabIndex = 4;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(8, 143);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(450, 231);
            this.txtStatus.TabIndex = 5;
            // 
            // cmdChooseLocal
            // 
            this.cmdChooseLocal.Location = new System.Drawing.Point(132, 19);
            this.cmdChooseLocal.Name = "cmdChooseLocal";
            this.cmdChooseLocal.Size = new System.Drawing.Size(28, 20);
            this.cmdChooseLocal.TabIndex = 6;
            this.cmdChooseLocal.Text = "...";
            this.cmdChooseLocal.UseVisualStyleBackColor = true;
            this.cmdChooseLocal.Click += new System.EventHandler(this.cmdChooseLocal_Click);
            // 
            // cmdHere
            // 
            this.cmdHere.Location = new System.Drawing.Point(132, 38);
            this.cmdHere.Name = "cmdHere";
            this.cmdHere.Size = new System.Drawing.Size(28, 20);
            this.cmdHere.TabIndex = 7;
            this.cmdHere.Text = "v";
            this.cmdHere.UseVisualStyleBackColor = true;
            this.cmdHere.Click += new System.EventHandler(this.cmdHere_Click);
            // 
            // pControls
            // 
            this.pControls.BackColor = System.Drawing.Color.White;
            this.pControls.Controls.Add(this.lblStatus);
            this.pControls.Controls.Add(this.cmdImport);
            this.pControls.Controls.Add(this.throb);
            this.pControls.Controls.Add(this.panel1);
            this.pControls.Controls.Add(this.chkClose);
            this.pControls.Controls.Add(this.lblMethod);
            this.pControls.Controls.Add(this.txtStatus);
            this.pControls.Controls.Add(this.lbFromPath);
            this.pControls.Controls.Add(this.cmdHere);
            this.pControls.Controls.Add(this.lblToPath);
            this.pControls.Controls.Add(this.cmdChooseLocal);
            this.pControls.Controls.Add(this.cmdGo);
            this.pControls.Controls.Add(this.pb);
            this.pControls.Location = new System.Drawing.Point(3, 3);
            this.pControls.Name = "pControls";
            this.pControls.Size = new System.Drawing.Size(532, 382);
            this.pControls.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblStatus.Location = new System.Drawing.Point(5, 90);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 15);
            this.lblStatus.TabIndex = 18;
            // 
            // cmdImport
            // 
            this.cmdImport.Location = new System.Drawing.Point(132, 60);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(28, 20);
            this.cmdImport.TabIndex = 17;
            this.cmdImport.Text = ".";
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.White;
            this.throb.Location = new System.Drawing.Point(397, 60);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(30, 27);
            this.throb.TabIndex = 16;
            this.throb.UseParentBackColor = false;
            this.throb.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.chkBeta);
            this.panel1.Controls.Add(this.optAlternate);
            this.panel1.Controls.Add(this.optMain);
            this.panel1.Location = new System.Drawing.Point(163, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 19);
            this.panel1.TabIndex = 15;
            // 
            // chkBeta
            // 
            this.chkBeta.AutoSize = true;
            this.chkBeta.Location = new System.Drawing.Point(175, 0);
            this.chkBeta.Name = "chkBeta";
            this.chkBeta.Size = new System.Drawing.Size(48, 17);
            this.chkBeta.TabIndex = 15;
            this.chkBeta.Text = "Beta";
            this.chkBeta.UseVisualStyleBackColor = true;
            this.chkBeta.CheckedChanged += new System.EventHandler(this.chkBeta_CheckedChanged);
            // 
            // optAlternate
            // 
            this.optAlternate.AutoSize = true;
            this.optAlternate.Location = new System.Drawing.Point(91, 0);
            this.optAlternate.Name = "optAlternate";
            this.optAlternate.Size = new System.Drawing.Size(67, 17);
            this.optAlternate.TabIndex = 1;
            this.optAlternate.Text = "Alternate";
            this.optAlternate.UseVisualStyleBackColor = true;
            // 
            // optMain
            // 
            this.optMain.AutoSize = true;
            this.optMain.Checked = true;
            this.optMain.Location = new System.Drawing.Point(5, 1);
            this.optMain.Name = "optMain";
            this.optMain.Size = new System.Drawing.Size(69, 17);
            this.optMain.TabIndex = 0;
            this.optMain.TabStop = true;
            this.optMain.Text = "Main Site";
            this.optMain.UseVisualStyleBackColor = true;
            this.optMain.CheckedChanged += new System.EventHandler(this.optMain_CheckedChanged);
            // 
            // chkClose
            // 
            this.chkClose.AutoSize = true;
            this.chkClose.Checked = true;
            this.chkClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClose.Location = new System.Drawing.Point(169, 70);
            this.chkClose.Name = "chkClose";
            this.chkClose.Size = new System.Drawing.Size(186, 17);
            this.chkClose.TabIndex = 14;
            this.chkClose.Text = "Close this version after the update";
            this.chkClose.UseVisualStyleBackColor = true;
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Location = new System.Drawing.Point(166, 54);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(54, 13);
            this.lblMethod.TabIndex = 13;
            this.lblMethod.Text = "<method>";
            // 
            // bgw
            // 
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // RT
            // 
            this.RT.Location = new System.Drawing.Point(10, 419);
            this.RT.Name = "RT";
            this.RT.Size = new System.Drawing.Size(100, 110);
            this.RT.TabIndex = 10;
            this.RT.Text = "";
            // 
            // wb
            // 
            this.wb.BackColor = System.Drawing.Color.White;
            this.wb.Location = new System.Drawing.Point(308, 426);
            this.wb.Name = "wb";
            this.wb.ShowControls = false;
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(50, 41);
            this.wb.TabIndex = 11;
            this.wb.Visible = false;
            // 
            // bgwNewVersion
            // 
            this.bgwNewVersion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwNewVersion_DoWork);
            this.bgwNewVersion.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwNewVersion_RunWorkerCompleted);
            // 
            // UpdateDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.wb);
            this.Controls.Add(this.RT);
            this.Controls.Add(this.pControls);
            this.Name = "UpdateDownload";
            this.Size = new System.Drawing.Size(724, 569);
            this.Resize += new System.EventHandler(this.UpdateDownload_Resize);
            this.pControls.ResumeLayout(false);
            this.pControls.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbFromPath;
        private System.Windows.Forms.Label lblToPath;
        private System.Windows.Forms.Button cmdGo;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button cmdChooseLocal;
        private System.Windows.Forms.Button cmdHere;
        private System.Windows.Forms.Panel pControls;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.CheckBox chkClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton optAlternate;
        private System.Windows.Forms.RadioButton optMain;
        private System.ComponentModel.BackgroundWorker bgw;
        private NewMethod.nThrobber throb;
        private System.Windows.Forms.CheckBox chkBeta;
        private System.Windows.Forms.Button cmdImport;
        private System.Windows.Forms.RichTextBox RT;
        private ToolsWin.BrowserPlain wb;
        private System.ComponentModel.BackgroundWorker bgwNewVersion;
        private System.Windows.Forms.Label lblStatus;
    }
}
