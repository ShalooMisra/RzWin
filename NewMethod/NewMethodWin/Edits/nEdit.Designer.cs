namespace NewMethod
{
    partial class nEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nEdit));
            this.lblCaption = new System.Windows.Forms.Label();
            this.picInfo = new System.Windows.Forms.PictureBox();
            this.picError = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Location = new System.Drawing.Point(3, 4);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(54, 13);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "<caption>";
            // 
            // picInfo
            // 
            this.picInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picInfo.BackgroundImage")));
            this.picInfo.Location = new System.Drawing.Point(157, 3);
            this.picInfo.Name = "picInfo";
            this.picInfo.Size = new System.Drawing.Size(16, 16);
            this.picInfo.TabIndex = 1;
            this.picInfo.TabStop = false;
            // 
            // picError
            // 
            this.picError.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picError.BackgroundImage")));
            this.picError.Location = new System.Drawing.Point(179, 5);
            this.picError.Name = "picError";
            this.picError.Size = new System.Drawing.Size(16, 16);
            this.picError.TabIndex = 2;
            this.picError.TabStop = false;
            this.picError.Visible = false;
            // 
            // nEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.picError);
            this.Controls.Add(this.picInfo);
            this.Controls.Add(this.lblCaption);
            this.Name = "nEdit";
            this.Size = new System.Drawing.Size(368, 64);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.nEdit_MouseMove);
            this.Resize += new System.EventHandler(this.nEdit_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Label lblCaption;
        public System.Windows.Forms.PictureBox picInfo;
        public System.Windows.Forms.PictureBox picError;
    }
}
