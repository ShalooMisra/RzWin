namespace NewMethod
{
    partial class nEdit_Boolean
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
            this.chkValue = new System.Windows.Forms.CheckBox();
            this.pChanged = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(3, 2);
            // 
            // picInfo
            // 
            this.picInfo.Location = new System.Drawing.Point(352, 0);
            // 
            // chkValue
            // 
            this.chkValue.BackColor = System.Drawing.Color.Transparent;
            this.chkValue.Location = new System.Drawing.Point(8, 7);
            this.chkValue.Name = "chkValue";
            this.chkValue.Size = new System.Drawing.Size(13, 13);
            this.chkValue.TabIndex = 3;
            this.chkValue.UseVisualStyleBackColor = false;
            this.chkValue.CheckedChanged += new System.EventHandler(this.chkValue_CheckedChanged);
            // 
            // pChanged
            // 
            this.pChanged.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pChanged.Location = new System.Drawing.Point(77, 7);
            this.pChanged.Name = "pChanged";
            this.pChanged.Size = new System.Drawing.Size(19, 18);
            this.pChanged.TabIndex = 4;
            this.pChanged.Visible = false;
            // 
            // nEdit_Boolean
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.pChanged);
            this.Controls.Add(this.chkValue);
            this.Name = "nEdit_Boolean";
            this.Size = new System.Drawing.Size(368, 27);
            this.Resize += new System.EventHandler(this.nEdit_Boolean_Resize);
            this.Controls.SetChildIndex(this.picInfo, 0);
            this.Controls.SetChildIndex(this.picError, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.chkValue, 0);
            this.Controls.SetChildIndex(this.pChanged, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkValue;
        private System.Windows.Forms.Panel pChanged;

    }
}
