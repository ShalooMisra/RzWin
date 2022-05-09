namespace Rz5.Win.Controls
{
    partial class PathStep
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
            this.components = new System.ComponentModel.Container();
            this.pic = new System.Windows.Forms.PictureBox();
            this.lblCaption = new System.Windows.Forms.Label();
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.picRight = new System.Windows.Forms.PictureBox();
            this.picLeft = new System.Windows.Forms.PictureBox();
            this.lblAction = new System.Windows.Forms.LinkLabel();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.Blue;
            this.pic.Location = new System.Drawing.Point(15, 4);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(153, 83);
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblCaption.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(18, 8);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(147, 76);
            this.lblCaption.TabIndex = 2;
            this.lblCaption.Text = "<caption>";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCaption.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblCaption_MouseDown);
            // 
            // mnu
            // 
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(61, 4);
            this.mnu.Opening += new System.ComponentModel.CancelEventHandler(this.mnu_Opening);
            // 
            // picRight
            // 
            this.picRight.BackColor = System.Drawing.Color.Blue;
            this.picRight.Location = new System.Drawing.Point(151, 29);
            this.picRight.Name = "picRight";
            this.picRight.Size = new System.Drawing.Size(34, 10);
            this.picRight.TabIndex = 3;
            this.picRight.TabStop = false;
            // 
            // picLeft
            // 
            this.picLeft.BackColor = System.Drawing.Color.Blue;
            this.picLeft.Location = new System.Drawing.Point(0, 29);
            this.picLeft.Name = "picLeft";
            this.picLeft.Size = new System.Drawing.Size(34, 10);
            this.picLeft.TabIndex = 4;
            this.picLeft.TabStop = false;
            // 
            // lblAction
            // 
            this.lblAction.Location = new System.Drawing.Point(19, 29);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(143, 12);
            this.lblAction.TabIndex = 5;
            this.lblAction.TabStop = true;
            this.lblAction.Text = "action";
            this.lblAction.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAction.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAction_LinkClicked);
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(21, 43);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(140, 36);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = "info";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PathStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ContextMenuStrip = this.mnu;
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.picRight);
            this.Controls.Add(this.picLeft);
            this.Name = "PathStep";
            this.Size = new System.Drawing.Size(185, 90);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.PictureBox picRight;
        private System.Windows.Forms.PictureBox picLeft;
        private System.Windows.Forms.ContextMenuStrip mnu;
        private System.Windows.Forms.LinkLabel lblAction;
        private System.Windows.Forms.Label lblInfo;
    }
}
