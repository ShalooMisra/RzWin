namespace Rz5
{
    partial class frmLabelLines
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
            this.txtData = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lblInstruct = new System.Windows.Forms.Label();
            this.gb = new System.Windows.Forms.GroupBox();
            this.lblTop = new System.Windows.Forms.Label();
            this.lblCaption = new System.Windows.Forms.Label();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(-1, 129);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtData.Size = new System.Drawing.Size(256, 316);
            this.txtData.TabIndex = 0;
            this.txtData.WordWrap = false;
            this.txtData.TextChanged += new System.EventHandler(this.txtData_TextChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(257, 129);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "<status>";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(348, 393);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(155, 52);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "&OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(260, 393);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(82, 52);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lblInstruct
            // 
            this.lblInstruct.AutoSize = true;
            this.lblInstruct.Location = new System.Drawing.Point(0, 113);
            this.lblInstruct.Name = "lblInstruct";
            this.lblInstruct.Size = new System.Drawing.Size(106, 13);
            this.lblInstruct.TabIndex = 4;
            this.lblInstruct.Text = "Quantity : Date Code";
            // 
            // gb
            // 
            this.gb.Controls.Add(this.lblTop);
            this.gb.Controls.Add(this.lblCaption);
            this.gb.Location = new System.Drawing.Point(3, -2);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(505, 112);
            this.gb.TabIndex = 5;
            this.gb.TabStop = false;
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Location = new System.Drawing.Point(7, 16);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(34, 13);
            this.lblTop.TabIndex = 3;
            this.lblTop.Text = "<top>";
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(6, 81);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(487, 28);
            this.lblCaption.TabIndex = 2;
            this.lblCaption.Text = "Please enter 1 line in the text box below for each label that needs to be printed" +
                ".  Enter the quantity, then optionally add a comma and the date code for each la" +
                "bel.";
            // 
            // frmLabelLines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 445);
            this.Controls.Add(this.gb);
            this.Controls.Add(this.lblInstruct);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtData);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLabelLines";
            this.Text = "Label Lines";
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox txtData;
        protected System.Windows.Forms.Label lblStatus;
        protected System.Windows.Forms.Button cmdOK;
        protected System.Windows.Forms.Button cmdCancel;
        protected System.Windows.Forms.Label lblInstruct;
        protected System.Windows.Forms.GroupBox gb;
        protected System.Windows.Forms.Label lblCaption;
        protected System.Windows.Forms.Label lblTop;
    }
}