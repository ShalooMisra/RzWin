namespace Rz5
{
    partial class view_orddet_rfq
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(view_orddet_rfq));
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(933, 0);
            this.xActions.Size = new System.Drawing.Size(192, 577);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Magenta;
            this.il.Images.SetKeyName(0, "quote");
            this.il.Images.SetKeyName(1, "rfq");
            this.il.Images.SetKeyName(2, "service");
            this.il.Images.SetKeyName(3, "stock");
            this.il.Images.SetKeyName(4, "req");
            // 
            // view_orddet_rfq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Name = "view_orddet_rfq";
            this.Size = new System.Drawing.Size(1125, 577);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList il;

    }
}
