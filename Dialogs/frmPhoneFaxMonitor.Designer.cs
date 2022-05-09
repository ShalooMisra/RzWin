namespace Rz5
{
    partial class frmPhoneFaxMonitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhoneFaxMonitor));
            this.gbPhone = new System.Windows.Forms.GroupBox();
            this.pIP = new System.Windows.Forms.Panel();
            this.cmdSaveIP = new System.Windows.Forms.Button();
            this.ctlIP = new NewMethod.nEdit_String();
            this.ctlPort = new NewMethod.nEdit_Number();
            this.chkRecordings = new System.Windows.Forms.CheckBox();
            this.lblCreate = new System.Windows.Forms.LinkLabel();
            this.chkDebug = new System.Windows.Forms.CheckBox();
            this.lblInspect = new System.Windows.Forms.LinkLabel();
            this.txtPhoneData = new System.Windows.Forms.TextBox();
            this.txtPhoneStatus = new System.Windows.Forms.TextBox();
            this.chkEnablePhone = new System.Windows.Forms.CheckBox();
            this.lblTestCall = new System.Windows.Forms.LinkLabel();
            this.sp = new System.IO.Ports.SerialPort(this.components);
            this.gbFax = new System.Windows.Forms.GroupBox();
            this.lblTestFax = new System.Windows.Forms.LinkLabel();
            this.txtFaxStatus = new System.Windows.Forms.TextBox();
            this.chkFax = new System.Windows.Forms.CheckBox();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.ni = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmdHide = new System.Windows.Forms.Button();
            this.lblSingleTest = new System.Windows.Forms.LinkLabel();
            this.fsw = new System.IO.FileSystemWatcher();
            this.gbPhone.SuspendLayout();
            this.pIP.SuspendLayout();
            this.gbFax.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fsw)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPhone
            // 
            this.gbPhone.BackColor = System.Drawing.Color.White;
            this.gbPhone.Controls.Add(this.pIP);
            this.gbPhone.Controls.Add(this.chkRecordings);
            this.gbPhone.Controls.Add(this.lblCreate);
            this.gbPhone.Controls.Add(this.chkDebug);
            this.gbPhone.Controls.Add(this.lblInspect);
            this.gbPhone.Controls.Add(this.txtPhoneData);
            this.gbPhone.Controls.Add(this.txtPhoneStatus);
            this.gbPhone.Controls.Add(this.chkEnablePhone);
            this.gbPhone.Location = new System.Drawing.Point(7, 5);
            this.gbPhone.Name = "gbPhone";
            this.gbPhone.Size = new System.Drawing.Size(818, 327);
            this.gbPhone.TabIndex = 0;
            this.gbPhone.TabStop = false;
            this.gbPhone.Text = "Phone System";
            // 
            // pIP
            // 
            this.pIP.Controls.Add(this.cmdSaveIP);
            this.pIP.Controls.Add(this.ctlIP);
            this.pIP.Controls.Add(this.ctlPort);
            this.pIP.Location = new System.Drawing.Point(391, 9);
            this.pIP.Name = "pIP";
            this.pIP.Size = new System.Drawing.Size(263, 42);
            this.pIP.TabIndex = 10;
            this.pIP.Visible = false;
            // 
            // cmdSaveIP
            // 
            this.cmdSaveIP.Location = new System.Drawing.Point(182, 3);
            this.cmdSaveIP.Name = "cmdSaveIP";
            this.cmdSaveIP.Size = new System.Drawing.Size(75, 35);
            this.cmdSaveIP.TabIndex = 10;
            this.cmdSaveIP.Text = "Save";
            this.cmdSaveIP.UseVisualStyleBackColor = true;
            this.cmdSaveIP.Click += new System.EventHandler(this.cmdSaveIP_Click);
            // 
            // ctlIP
            // 
            this.ctlIP.AllCaps = false;
            this.ctlIP.BackColor = System.Drawing.Color.Transparent;
            this.ctlIP.Bold = false;
            this.ctlIP.Caption = "IP Address";
            this.ctlIP.Changed = true;
            this.ctlIP.IsEmail = false;
            this.ctlIP.IsURL = false;
            this.ctlIP.Location = new System.Drawing.Point(3, 3);
            this.ctlIP.Name = "ctlIP";
            this.ctlIP.PasswordChar = '\0';
            this.ctlIP.Size = new System.Drawing.Size(114, 35);
            this.ctlIP.TabIndex = 9;
            this.ctlIP.UseParentBackColor = false;
            this.ctlIP.zz_Enabled = true;
            this.ctlIP.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlIP.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlIP.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlIP.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlIP.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlIP.zz_OriginalDesign = false;
            this.ctlIP.zz_ShowLinkButton = false;
            this.ctlIP.zz_ShowNeedsSaveColor = false;
            this.ctlIP.zz_Text = "127.0.0.1";
            this.ctlIP.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlIP.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlIP.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlIP.zz_UseGlobalColor = false;
            this.ctlIP.zz_UseGlobalFont = false;
            // 
            // ctlPort
            // 
            this.ctlPort.BackColor = System.Drawing.Color.Transparent;
            this.ctlPort.Bold = false;
            this.ctlPort.Caption = "Port";
            this.ctlPort.Changed = true;
            this.ctlPort.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctlPort.Location = new System.Drawing.Point(123, 3);
            this.ctlPort.Name = "ctlPort";
            this.ctlPort.Size = new System.Drawing.Size(53, 35);
            this.ctlPort.TabIndex = 8;
            this.ctlPort.UseParentBackColor = false;
            this.ctlPort.zz_Enabled = true;
            this.ctlPort.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlPort.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlPort.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlPort.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPort.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctlPort.zz_OriginalDesign = false;
            this.ctlPort.zz_ShowErrorColor = true;
            this.ctlPort.zz_ShowNeedsSaveColor = false;
            this.ctlPort.zz_Text = "6801";
            this.ctlPort.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctlPort.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlPort.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPort.zz_UseGlobalColor = false;
            this.ctlPort.zz_UseGlobalFont = false;
            // 
            // chkRecordings
            // 
            this.chkRecordings.AutoSize = true;
            this.chkRecordings.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRecordings.Location = new System.Drawing.Point(734, 34);
            this.chkRecordings.Name = "chkRecordings";
            this.chkRecordings.Size = new System.Drawing.Size(80, 17);
            this.chkRecordings.TabIndex = 7;
            this.chkRecordings.Text = "Recordings";
            this.chkRecordings.UseVisualStyleBackColor = true;
            this.chkRecordings.CheckedChanged += new System.EventHandler(this.chkRecordings_CheckedChanged);
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.Location = new System.Drawing.Point(204, 18);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(49, 13);
            this.lblCreate.TabIndex = 6;
            this.lblCreate.TabStop = true;
            this.lblCreate.Text = "<create>";
            this.lblCreate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCreate_LinkClicked);
            // 
            // chkDebug
            // 
            this.chkDebug.AutoSize = true;
            this.chkDebug.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDebug.Location = new System.Drawing.Point(726, 52);
            this.chkDebug.Name = "chkDebug";
            this.chkDebug.Size = new System.Drawing.Size(88, 17);
            this.chkDebug.TabIndex = 5;
            this.chkDebug.Text = "Debug Mode";
            this.chkDebug.UseVisualStyleBackColor = true;
            // 
            // lblInspect
            // 
            this.lblInspect.AutoSize = true;
            this.lblInspect.Location = new System.Drawing.Point(145, 18);
            this.lblInspect.Name = "lblInspect";
            this.lblInspect.Size = new System.Drawing.Size(53, 13);
            this.lblInspect.TabIndex = 4;
            this.lblInspect.TabStop = true;
            this.lblInspect.Text = "<inspect>";
            this.lblInspect.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblInspect_LinkClicked);
            // 
            // txtPhoneData
            // 
            this.txtPhoneData.Enabled = false;
            this.txtPhoneData.Location = new System.Drawing.Point(412, 75);
            this.txtPhoneData.Multiline = true;
            this.txtPhoneData.Name = "txtPhoneData";
            this.txtPhoneData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPhoneData.Size = new System.Drawing.Size(402, 246);
            this.txtPhoneData.TabIndex = 3;
            this.txtPhoneData.WordWrap = false;
            // 
            // txtPhoneStatus
            // 
            this.txtPhoneStatus.Enabled = false;
            this.txtPhoneStatus.Location = new System.Drawing.Point(4, 75);
            this.txtPhoneStatus.Multiline = true;
            this.txtPhoneStatus.Name = "txtPhoneStatus";
            this.txtPhoneStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPhoneStatus.Size = new System.Drawing.Size(402, 246);
            this.txtPhoneStatus.TabIndex = 1;
            this.txtPhoneStatus.WordWrap = false;
            // 
            // chkEnablePhone
            // 
            this.chkEnablePhone.AutoSize = true;
            this.chkEnablePhone.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEnablePhone.Location = new System.Drawing.Point(660, 17);
            this.chkEnablePhone.Name = "chkEnablePhone";
            this.chkEnablePhone.Size = new System.Drawing.Size(154, 17);
            this.chkEnablePhone.TabIndex = 0;
            this.chkEnablePhone.Text = "Monitor The Phone System";
            this.chkEnablePhone.UseVisualStyleBackColor = true;
            this.chkEnablePhone.CheckedChanged += new System.EventHandler(this.chkEnablePhone_CheckedChanged);
            // 
            // lblTestCall
            // 
            this.lblTestCall.AutoSize = true;
            this.lblTestCall.Location = new System.Drawing.Point(13, 23);
            this.lblTestCall.Name = "lblTestCall";
            this.lblTestCall.Size = new System.Drawing.Size(60, 13);
            this.lblTestCall.TabIndex = 2;
            this.lblTestCall.TabStop = true;
            this.lblTestCall.Text = "<test calls>";
            this.lblTestCall.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblTestCall_LinkClicked);
            // 
            // sp
            // 
            this.sp.BaudRate = 1200;
            this.sp.DtrEnable = true;
            // 
            // gbFax
            // 
            this.gbFax.BackColor = System.Drawing.Color.White;
            this.gbFax.Controls.Add(this.lblTestFax);
            this.gbFax.Controls.Add(this.txtFaxStatus);
            this.gbFax.Controls.Add(this.chkFax);
            this.gbFax.Location = new System.Drawing.Point(7, 338);
            this.gbFax.Name = "gbFax";
            this.gbFax.Size = new System.Drawing.Size(818, 132);
            this.gbFax.TabIndex = 1;
            this.gbFax.TabStop = false;
            this.gbFax.Text = "Fax Server";
            // 
            // lblTestFax
            // 
            this.lblTestFax.AutoSize = true;
            this.lblTestFax.Location = new System.Drawing.Point(6, 18);
            this.lblTestFax.Name = "lblTestFax";
            this.lblTestFax.Size = new System.Drawing.Size(53, 13);
            this.lblTestFax.TabIndex = 2;
            this.lblTestFax.TabStop = true;
            this.lblTestFax.Text = "<test fax>";
            this.lblTestFax.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblTestFax_LinkClicked);
            // 
            // txtFaxStatus
            // 
            this.txtFaxStatus.Enabled = false;
            this.txtFaxStatus.Location = new System.Drawing.Point(4, 35);
            this.txtFaxStatus.Multiline = true;
            this.txtFaxStatus.Name = "txtFaxStatus";
            this.txtFaxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFaxStatus.Size = new System.Drawing.Size(808, 91);
            this.txtFaxStatus.TabIndex = 1;
            this.txtFaxStatus.WordWrap = false;
            // 
            // chkFax
            // 
            this.chkFax.AutoSize = true;
            this.chkFax.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFax.Location = new System.Drawing.Point(688, 17);
            this.chkFax.Name = "chkFax";
            this.chkFax.Size = new System.Drawing.Size(122, 17);
            this.chkFax.TabIndex = 0;
            this.chkFax.Text = "Run The Fax Server";
            this.chkFax.UseVisualStyleBackColor = true;
            this.chkFax.CheckedChanged += new System.EventHandler(this.chkFax_CheckedChanged);
            // 
            // tmr
            // 
            this.tmr.Interval = 500;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // ni
            // 
            this.ni.Icon = ((System.Drawing.Icon)(resources.GetObject("ni.Icon")));
            this.ni.Text = "Rz3 Phone / Fax Monitor";
            this.ni.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ni_MouseDoubleClick);
            // 
            // cmdHide
            // 
            this.cmdHide.Location = new System.Drawing.Point(702, 476);
            this.cmdHide.Name = "cmdHide";
            this.cmdHide.Size = new System.Drawing.Size(123, 21);
            this.cmdHide.TabIndex = 2;
            this.cmdHide.Text = "&Hide";
            this.cmdHide.UseVisualStyleBackColor = true;
            this.cmdHide.Click += new System.EventHandler(this.cmdHide_Click);
            // 
            // lblSingleTest
            // 
            this.lblSingleTest.AutoSize = true;
            this.lblSingleTest.Location = new System.Drawing.Point(80, 23);
            this.lblSingleTest.Name = "lblSingleTest";
            this.lblSingleTest.Size = new System.Drawing.Size(66, 13);
            this.lblSingleTest.TabIndex = 3;
            this.lblSingleTest.TabStop = true;
            this.lblSingleTest.Text = "<single test>";
            this.lblSingleTest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSingleTest_LinkClicked);
            // 
            // fsw
            // 
            this.fsw.EnableRaisingEvents = true;
            this.fsw.IncludeSubdirectories = true;
            this.fsw.NotifyFilter = ((System.IO.NotifyFilters)((((System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.Size) 
            | System.IO.NotifyFilters.LastWrite) 
            | System.IO.NotifyFilters.CreationTime)));
            this.fsw.SynchronizingObject = this;
            this.fsw.Changed += new System.IO.FileSystemEventHandler(this.fsw_Changed);
            this.fsw.Created += new System.IO.FileSystemEventHandler(this.fsw_Created);
            this.fsw.Renamed += new System.IO.RenamedEventHandler(this.fsw_Renamed);
            // 
            // frmPhoneFaxMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(829, 499);
            this.Controls.Add(this.lblSingleTest);
            this.Controls.Add(this.cmdHide);
            this.Controls.Add(this.lblTestCall);
            this.Controls.Add(this.gbFax);
            this.Controls.Add(this.gbPhone);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPhoneFaxMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phone / Fax Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPhoneFaxMonitor_FormClosing);
            this.gbPhone.ResumeLayout(false);
            this.gbPhone.PerformLayout();
            this.pIP.ResumeLayout(false);
            this.gbFax.ResumeLayout(false);
            this.gbFax.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fsw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPhone;
        protected System.Windows.Forms.LinkLabel lblTestCall;
        protected System.Windows.Forms.TextBox txtPhoneStatus;
        protected System.IO.Ports.SerialPort sp;
        protected System.Windows.Forms.TextBox txtPhoneData;
        private System.Windows.Forms.GroupBox gbFax;
        private System.Windows.Forms.LinkLabel lblTestFax;
        private System.Windows.Forms.CheckBox chkFax;
        private System.Windows.Forms.NotifyIcon ni;
        private System.Windows.Forms.Button cmdHide;
        private System.Windows.Forms.LinkLabel lblSingleTest;
        private System.Windows.Forms.LinkLabel lblInspect;
        protected System.Windows.Forms.CheckBox chkDebug;
        private System.Windows.Forms.LinkLabel lblCreate;
        private System.Windows.Forms.CheckBox chkRecordings;
        private System.IO.FileSystemWatcher fsw;
        public System.Windows.Forms.Timer tmr;
        public System.Windows.Forms.CheckBox chkEnablePhone;
        protected System.Windows.Forms.Panel pIP;
        protected System.Windows.Forms.Button cmdSaveIP;
        protected NewMethod.nEdit_String ctlIP;
        protected NewMethod.nEdit_Number ctlPort;
        protected System.Windows.Forms.TextBox txtFaxStatus;
    }
}