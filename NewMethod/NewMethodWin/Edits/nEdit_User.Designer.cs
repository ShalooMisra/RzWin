namespace NewMethod
{
    partial class nEdit_User
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
            this.lbl = new System.Windows.Forms.LinkLabel();
            this.lblClear = new System.Windows.Forms.LinkLabel();
            this.lblNote = new System.Windows.Forms.LinkLabel();
            this.lblView = new System.Windows.Forms.LinkLabel();
            this.lblMe = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.SuspendLayout();
            // 
            // picInfo
            // 
            this.picInfo.Location = new System.Drawing.Point(352, 0);
            // 
            // lbl
            // 
            this.lbl.AutoEllipsis = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(8, 17);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(110, 20);
            this.lbl.TabIndex = 3;
            this.lbl.TabStop = true;
            this.lbl.Text = "< user name >";
            this.lbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_LinkClicked);
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.LinkColor = System.Drawing.Color.Purple;
            this.lblClear.Location = new System.Drawing.Point(12, 37);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(30, 13);
            this.lblClear.TabIndex = 9;
            this.lblClear.TabStop = true;
            this.lblClear.Text = "clear";
            this.lblClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblClear_LinkClicked);
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.LinkColor = System.Drawing.Color.Purple;
            this.lblNote.Location = new System.Drawing.Point(48, 37);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(28, 13);
            this.lblNote.TabIndex = 8;
            this.lblNote.TabStop = true;
            this.lblNote.Text = "note";
            this.lblNote.Visible = false;
            this.lblNote.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNote_LinkClicked);
            // 
            // lblView
            // 
            this.lblView.AutoSize = true;
            this.lblView.LinkColor = System.Drawing.Color.Purple;
            this.lblView.Location = new System.Drawing.Point(109, 37);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(29, 13);
            this.lblView.TabIndex = 10;
            this.lblView.TabStop = true;
            this.lblView.Text = "view";
            this.lblView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblView_LinkClicked);
            // 
            // lblMe
            // 
            this.lblMe.AutoSize = true;
            this.lblMe.Enabled = false;
            this.lblMe.LinkColor = System.Drawing.Color.Purple;
            this.lblMe.Location = new System.Drawing.Point(82, 37);
            this.lblMe.Name = "lblMe";
            this.lblMe.Size = new System.Drawing.Size(21, 13);
            this.lblMe.TabIndex = 11;
            this.lblMe.TabStop = true;
            this.lblMe.Text = "me";
            this.lblMe.Visible = false;
            // 
            // nEdit_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.lblMe);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.lblView);
            this.Controls.Add(this.lblClear);
            this.Controls.Add(this.lblNote);
            this.Name = "nEdit_User";
            this.Size = new System.Drawing.Size(368, 57);
            this.Resize += new System.EventHandler(this.nEdit_User_Resize);
            this.Controls.SetChildIndex(this.picInfo, 0);
            this.Controls.SetChildIndex(this.picError, 0);
            this.Controls.SetChildIndex(this.lblNote, 0);
            this.Controls.SetChildIndex(this.lblClear, 0);
            this.Controls.SetChildIndex(this.lblView, 0);
            this.Controls.SetChildIndex(this.lbl, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.lblMe, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lbl;
        private System.Windows.Forms.LinkLabel lblClear;
        private System.Windows.Forms.LinkLabel lblNote;
        private System.Windows.Forms.LinkLabel lblView;
        private System.Windows.Forms.LinkLabel lblMe;

    }
}
