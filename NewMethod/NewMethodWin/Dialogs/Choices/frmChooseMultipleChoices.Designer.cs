namespace NewMethod
{
    partial class frmChooseMultipleChoices
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
            this.lblCaption = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lst = new System.Windows.Forms.CheckedListBox();
            this.lblPaste = new System.Windows.Forms.LinkLabel();
            this.lblScanOrType = new System.Windows.Forms.Label();
            this.txtScan = new System.Windows.Forms.TextBox();
            this.lblCheck = new System.Windows.Forms.LinkLabel();
            this.pScan = new System.Windows.Forms.Panel();
            this.lblCheckAll = new System.Windows.Forms.LinkLabel();
            this.lblCheckNone = new System.Windows.Forms.LinkLabel();
            this.lblChecked = new System.Windows.Forms.Label();
            this.pScan.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(0, 4);
            this.lblCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(99, 25);
            this.lblCaption.TabIndex = 7;
            this.lblCaption.Text = "<caption>";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(316, 549);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(188, 53);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "&OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(16, 549);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(188, 53);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lst
            // 
            this.lst.CheckOnClick = true;
            this.lst.FormattingEnabled = true;
            this.lst.Location = new System.Drawing.Point(5, 63);
            this.lst.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(511, 429);
            this.lst.TabIndex = 8;
            this.lst.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lst_ItemCheck);
            this.lst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lst_KeyDown);
            this.lst.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lst_KeyPress);
            this.lst.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lst_KeyUp);
            this.lst.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lst_MouseUp);
            // 
            // lblPaste
            // 
            this.lblPaste.AutoSize = true;
            this.lblPaste.Location = new System.Drawing.Point(473, 5);
            this.lblPaste.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaste.Name = "lblPaste";
            this.lblPaste.Size = new System.Drawing.Size(43, 17);
            this.lblPaste.TabIndex = 9;
            this.lblPaste.TabStop = true;
            this.lblPaste.Text = "paste";
            this.lblPaste.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPaste_LinkClicked);
            // 
            // lblScanOrType
            // 
            this.lblScanOrType.AutoSize = true;
            this.lblScanOrType.Location = new System.Drawing.Point(15, 9);
            this.lblScanOrType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScanOrType.Name = "lblScanOrType";
            this.lblScanOrType.Size = new System.Drawing.Size(96, 17);
            this.lblScanOrType.TabIndex = 10;
            this.lblScanOrType.Text = "Scan Or Type";
            // 
            // txtScan
            // 
            this.txtScan.Location = new System.Drawing.Point(127, 7);
            this.txtScan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtScan.Name = "txtScan";
            this.txtScan.Size = new System.Drawing.Size(303, 22);
            this.txtScan.TabIndex = 11;
            this.txtScan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtScan_KeyPress);
            // 
            // lblCheck
            // 
            this.lblCheck.AutoSize = true;
            this.lblCheck.Location = new System.Drawing.Point(441, 11);
            this.lblCheck.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(45, 17);
            this.lblCheck.TabIndex = 12;
            this.lblCheck.TabStop = true;
            this.lblCheck.Text = "check";
            this.lblCheck.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCheck_LinkClicked);
            // 
            // pScan
            // 
            this.pScan.Controls.Add(this.txtScan);
            this.pScan.Controls.Add(this.lblCheck);
            this.pScan.Controls.Add(this.lblScanOrType);
            this.pScan.Location = new System.Drawing.Point(4, 502);
            this.pScan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pScan.Name = "pScan";
            this.pScan.Size = new System.Drawing.Size(512, 39);
            this.pScan.TabIndex = 13;
            // 
            // lblCheckAll
            // 
            this.lblCheckAll.AutoSize = true;
            this.lblCheckAll.Location = new System.Drawing.Point(447, 25);
            this.lblCheckAll.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCheckAll.Name = "lblCheckAll";
            this.lblCheckAll.Size = new System.Drawing.Size(63, 17);
            this.lblCheckAll.TabIndex = 14;
            this.lblCheckAll.TabStop = true;
            this.lblCheckAll.Text = "check all";
            this.lblCheckAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCheckAll_LinkClicked);
            // 
            // lblCheckNone
            // 
            this.lblCheckNone.AutoSize = true;
            this.lblCheckNone.Location = new System.Drawing.Point(428, 43);
            this.lblCheckNone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCheckNone.Name = "lblCheckNone";
            this.lblCheckNone.Size = new System.Drawing.Size(81, 17);
            this.lblCheckNone.TabIndex = 15;
            this.lblCheckNone.TabStop = true;
            this.lblCheckNone.Text = "check none";
            this.lblCheckNone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCheckNone_LinkClicked);
            // 
            // lblChecked
            // 
            this.lblChecked.AutoSize = true;
            this.lblChecked.Location = new System.Drawing.Point(1, 36);
            this.lblChecked.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChecked.Name = "lblChecked";
            this.lblChecked.Size = new System.Drawing.Size(77, 17);
            this.lblChecked.TabIndex = 16;
            this.lblChecked.Text = "<checked>";
            // 
            // frmChooseMultipleChoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(521, 607);
            this.Controls.Add(this.lblChecked);
            this.Controls.Add(this.lblCheckNone);
            this.Controls.Add(this.lblCheckAll);
            this.Controls.Add(this.pScan);
            this.Controls.Add(this.lblPaste);
            this.Controls.Add(this.lst);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmChooseMultipleChoices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose";
            this.Click += new System.EventHandler(this.frmChooseOneChoice_Activated);
            this.Resize += new System.EventHandler(this.frmChooseMultipleChoices_Resize);
            this.pScan.ResumeLayout(false);
            this.pScan.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.CheckedListBox lst;
        private System.Windows.Forms.LinkLabel lblPaste;
        private System.Windows.Forms.Label lblScanOrType;
        private System.Windows.Forms.TextBox txtScan;
        private System.Windows.Forms.LinkLabel lblCheck;
        private System.Windows.Forms.Panel pScan;
        private System.Windows.Forms.LinkLabel lblCheckAll;
        private System.Windows.Forms.LinkLabel lblCheckNone;
        private System.Windows.Forms.Label lblChecked;
    }
}