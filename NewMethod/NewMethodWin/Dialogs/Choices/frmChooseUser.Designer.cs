namespace NewMethod
{
    partial class frmChooseUser
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cbo = new System.Windows.Forms.ComboBox();
            this.gb = new System.Windows.Forms.GroupBox();
            this.lblNew = new System.Windows.Forms.LinkLabel();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(219, 50);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(90, 23);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(45, 50);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(90, 23);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.Text = "&OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cbo
            // 
            this.cbo.DropDownHeight = 500;
            this.cbo.FormattingEnabled = true;
            this.cbo.IntegralHeight = false;
            this.cbo.Location = new System.Drawing.Point(6, 27);
            this.cbo.Name = "cbo";
            this.cbo.Size = new System.Drawing.Size(337, 21);
            this.cbo.TabIndex = 5;
            this.cbo.SelectedValueChanged += new System.EventHandler(this.cbo_SelectedValueChanged);
            // 
            // gb
            // 
            this.gb.Controls.Add(this.lblNew);
            this.gb.Controls.Add(this.cmdCancel);
            this.gb.Controls.Add(this.cbo);
            this.gb.Controls.Add(this.cmdOK);
            this.gb.Location = new System.Drawing.Point(0, 0);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(349, 76);
            this.gb.TabIndex = 7;
            this.gb.TabStop = false;
            this.gb.Text = "User Name";
            // 
            // lblNew
            // 
            this.lblNew.AutoSize = true;
            this.lblNew.Location = new System.Drawing.Point(316, 11);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(27, 13);
            this.lblNew.TabIndex = 6;
            this.lblNew.TabStop = true;
            this.lblNew.Text = "new";
            this.lblNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNew_LinkClicked);
            // 
            // frmChooseUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(349, 76);
            this.ControlBox = false;
            this.Controls.Add(this.gb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChooseUser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "User Selection";
            this.Activated += new System.EventHandler(this.frmChooseUser_Activated);
            this.Load += new System.EventHandler(this.frmChooseUser_Load);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.ComboBox cbo;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.LinkLabel lblNew;
    }
}