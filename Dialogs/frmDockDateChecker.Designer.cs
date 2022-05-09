namespace Rz5
{
    partial class frmDockDateChecker
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
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblLineCode = new System.Windows.Forms.Label();
            this.lblPartNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.gbChange = new System.Windows.Forms.GroupBox();
            this.calDockDate = new System.Windows.Forms.MonthCalendar();
            this.lblCurrentDockTitle = new System.Windows.Forms.Label();
            this.lblCurrentDock = new System.Windows.Forms.Label();
            this.lbUpdateDock = new System.Windows.Forms.LinkLabel();
            this.lblLine = new System.Windows.Forms.Label();
            this.gbChange.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.Enabled = false;
            this.txtAddress.Location = new System.Drawing.Point(12, 97);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(223, 107);
            this.txtAddress.TabIndex = 0;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(12, 68);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(83, 13);
            this.lblCompanyName.TabIndex = 2;
            this.lblCompanyName.Text = "Vendor Name";
            // 
            // lblLineCode
            // 
            this.lblLineCode.AutoSize = true;
            this.lblLineCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineCode.Location = new System.Drawing.Point(51, 10);
            this.lblLineCode.Name = "lblLineCode";
            this.lblLineCode.Size = new System.Drawing.Size(21, 13);
            this.lblLineCode.TabIndex = 3;
            this.lblLineCode.Text = "11";
            // 
            // lblPartNumber
            // 
            this.lblPartNumber.AutoSize = true;
            this.lblPartNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartNumber.Location = new System.Drawing.Point(76, 10);
            this.lblPartNumber.Name = "lblPartNumber";
            this.lblPartNumber.Size = new System.Drawing.Size(77, 13);
            this.lblPartNumber.TabIndex = 4;
            this.lblPartNumber.Text = "Part Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Vendor Address:";
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(148, 260);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(2);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(87, 29);
            this.cmdOK.TabIndex = 9;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(15, 260);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(2);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(87, 29);
            this.cmdCancel.TabIndex = 8;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // gbChange
            // 
            this.gbChange.Controls.Add(this.calDockDate);
            this.gbChange.Location = new System.Drawing.Point(251, 12);
            this.gbChange.Name = "gbChange";
            this.gbChange.Size = new System.Drawing.Size(233, 192);
            this.gbChange.TabIndex = 10;
            this.gbChange.TabStop = false;
            this.gbChange.Text = "Change Dock Date";
            // 
            // calDockDate
            // 
            this.calDockDate.Location = new System.Drawing.Point(6, 25);
            this.calDockDate.MaxSelectionCount = 1;
            this.calDockDate.Name = "calDockDate";
            this.calDockDate.TabIndex = 6;
            this.calDockDate.TitleBackColor = System.Drawing.Color.WhiteSmoke;
            this.calDockDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calDockDate_DateChanged);
            // 
            // lblCurrentDockTitle
            // 
            this.lblCurrentDockTitle.AutoSize = true;
            this.lblCurrentDockTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentDockTitle.Location = new System.Drawing.Point(12, 37);
            this.lblCurrentDockTitle.Name = "lblCurrentDockTitle";
            this.lblCurrentDockTitle.Size = new System.Drawing.Size(73, 13);
            this.lblCurrentDockTitle.TabIndex = 11;
            this.lblCurrentDockTitle.Text = "Current Dock:";
            // 
            // lblCurrentDock
            // 
            this.lblCurrentDock.AutoSize = true;
            this.lblCurrentDock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentDock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCurrentDock.Location = new System.Drawing.Point(91, 37);
            this.lblCurrentDock.Name = "lblCurrentDock";
            this.lblCurrentDock.Size = new System.Drawing.Size(57, 13);
            this.lblCurrentDock.TabIndex = 12;
            this.lblCurrentDock.Text = "1-1-1900";
            // 
            // lbUpdateDock
            // 
            this.lbUpdateDock.AutoSize = true;
            this.lbUpdateDock.Location = new System.Drawing.Point(166, 37);
            this.lbUpdateDock.Name = "lbUpdateDock";
            this.lbUpdateDock.Size = new System.Drawing.Size(56, 13);
            this.lbUpdateDock.TabIndex = 13;
            this.lbUpdateDock.TabStop = true;
            this.lbUpdateDock.Text = "Change ...";
            this.lbUpdateDock.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbUpdateDock_LinkClicked);
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine.Location = new System.Drawing.Point(12, 10);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(39, 13);
            this.lblLine.TabIndex = 14;
            this.lblLine.Text = "Line#";
            // 
            // frmDockDateChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 300);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.lbUpdateDock);
            this.Controls.Add(this.lblCurrentDock);
            this.Controls.Add(this.lblCurrentDockTitle);
            this.Controls.Add(this.gbChange);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPartNumber);
            this.Controls.Add(this.lblLineCode);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.txtAddress);
            this.Name = "frmDockDateChecker";
            this.ShowIcon = false;
            this.Text = "Please confirm the Customer Dock Date";
            this.gbChange.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblLineCode;
        private System.Windows.Forms.Label lblPartNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.GroupBox gbChange;
        private System.Windows.Forms.MonthCalendar calDockDate;
        private System.Windows.Forms.Label lblCurrentDockTitle;
        private System.Windows.Forms.Label lblCurrentDock;
        private System.Windows.Forms.LinkLabel lbUpdateDock;
        private System.Windows.Forms.Label lblLine;
    }
}