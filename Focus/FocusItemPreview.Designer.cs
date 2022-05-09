namespace Rz5.Focus
{
    partial class FocusItemPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FocusItemPreview));
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.LinkLabel();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.pic = new System.Windows.Forms.PictureBox();
            this.lblDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(34, 18);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(70, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "<description>";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(34, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 13);
            this.lblName.TabIndex = 1;
            this.lblName.TabStop = true;
            this.lblName.Text = "<name>";
            this.lblName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblName_LinkClicked);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Magenta;
            this.il.Images.SetKeyName(0, "phonecall");
            this.il.Images.SetKeyName(1, "soldprofit");
            this.il.Images.SetKeyName(2, "rapidquote");
            this.il.Images.SetKeyName(3, "partsearch");
            this.il.Images.SetKeyName(4, "hits");
            this.il.Images.SetKeyName(5, "shippedprofit");
            this.il.Images.SetKeyName(6, "UserNote");
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(4, 4);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(24, 24);
            this.pic.TabIndex = 2;
            this.pic.TabStop = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Location = new System.Drawing.Point(520, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(40, 13);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "<date>";
            // 
            // FocusItemPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblDescription);
            this.Name = "FocusItemPreview";
            this.Size = new System.Drawing.Size(560, 37);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.LinkLabel lblName;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.Label lblDate;
    }
}
