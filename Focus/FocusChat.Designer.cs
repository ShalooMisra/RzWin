namespace Rz5.Focus
{
    partial class FocusChat
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
                ReleaseHook(RzWin.Context);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FocusChat));
            this.ilBig = new System.Windows.Forms.ImageList(this.components);
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.cmdInit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ilBig
            // 
            this.ilBig.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilBig.ImageStream")));
            this.ilBig.TransparentColor = System.Drawing.Color.Magenta;
            this.ilBig.Images.SetKeyName(0, "chat.bmp");
            // 
            // il
            // 
            this.il.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.il.ImageSize = new System.Drawing.Size(16, 16);
            this.il.TransparentColor = System.Drawing.Color.Magenta;
            // 
            // cmdInit
            // 
            this.cmdInit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdInit.ImageIndex = 0;
            this.cmdInit.ImageList = this.ilBig;
            this.cmdInit.Location = new System.Drawing.Point(25, 19);
            this.cmdInit.Name = "cmdInit";
            this.cmdInit.Size = new System.Drawing.Size(292, 51);
            this.cmdInit.TabIndex = 0;
            this.cmdInit.Text = "Chat With <someone>";
            this.cmdInit.UseVisualStyleBackColor = true;
            this.cmdInit.Click += new System.EventHandler(this.cmdInit_Click);
            // 
            // FocusChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdInit);
            this.Name = "FocusChat";
            this.Size = new System.Drawing.Size(343, 94);
            this.Resize += new System.EventHandler(this.FocusChat_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdInit;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.ImageList ilBig;
    }
}
