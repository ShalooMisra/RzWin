namespace Rz5
{
    partial class frmLocation
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
            this.gb = new System.Windows.Forms.GroupBox();
            this.ctlBox = new NewMethod.nEdit_String();
            this.ctlLocation = new NewMethod.nEdit_String();
            this.lblPart = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.ctlBox);
            this.gb.Controls.Add(this.ctlLocation);
            this.gb.Controls.Add(this.lblPart);
            this.gb.Location = new System.Drawing.Point(4, 4);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(464, 107);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            this.gb.Text = "Stock Receive: Location and Box";
            // 
            // ctlBox
            // 
            this.ctlBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlBox.Bold = false;
            this.ctlBox.Caption = "Box Number";
            this.ctlBox.Changed = false;
            this.ctlBox.IsEmail = false;
            this.ctlBox.IsURL = false;
            this.ctlBox.Location = new System.Drawing.Point(237, 58);
            this.ctlBox.Name = "ctlBox";
            this.ctlBox.PasswordChar = '\0';
            this.ctlBox.Size = new System.Drawing.Size(221, 44);
            this.ctlBox.TabIndex = 2;
            this.ctlBox.UseParentBackColor = false;
            // 
            // ctlLocation
            // 
            this.ctlLocation.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlLocation.Bold = false;
            this.ctlLocation.Caption = "Location";
            this.ctlLocation.Changed = false;
            this.ctlLocation.IsEmail = false;
            this.ctlLocation.IsURL = false;
            this.ctlLocation.Location = new System.Drawing.Point(237, 13);
            this.ctlLocation.Name = "ctlLocation";
            this.ctlLocation.PasswordChar = '\0';
            this.ctlLocation.Size = new System.Drawing.Size(221, 44);
            this.ctlLocation.TabIndex = 1;
            this.ctlLocation.UseParentBackColor = false;
            // 
            // lblPart
            // 
            this.lblPart.AutoSize = true;
            this.lblPart.Location = new System.Drawing.Point(11, 18);
            this.lblPart.Name = "lblPart";
            this.lblPart.Size = new System.Drawing.Size(37, 13);
            this.lblPart.TabIndex = 0;
            this.lblPart.Text = "<part>";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(4, 117);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(227, 33);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(241, 117);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(227, 33);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "&OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 155);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.gb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Location";
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private NewMethod.nEdit_String ctlBox;
        private NewMethod.nEdit_String ctlLocation;
        private System.Windows.Forms.Label lblPart;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
    }
}