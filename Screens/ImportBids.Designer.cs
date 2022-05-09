namespace Rz5
{
    partial class ImportBids
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
            this.dv = new NewMethod.nDataView();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.pbTop = new System.Windows.Forms.PictureBox();
            this.pbBottom = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // dv
            // 
            this.dv.AlwaysDisableAccept = false;
            this.dv.BackColor = System.Drawing.Color.White;
            this.dv.DisableAutoMatching = false;
            this.dv.HideOptions = false;
            this.dv.Location = new System.Drawing.Point(42, 5);
            this.dv.Name = "dv";
            this.dv.Size = new System.Drawing.Size(701, 279);
            this.dv.TabIndex = 1;
            this.dv.Accept += new NewMethod.nDataViewAcceptHandler(this.dv_Accept);
            this.dv.AfterImport += new NewMethod.nDataViewImportHandler(this.dv_AfterImport);
            // 
            // pbRight
            // 
            this.pbRight.BackColor = System.Drawing.Color.Black;
            this.pbRight.Location = new System.Drawing.Point(6, 5);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(12, 12);
            this.pbRight.TabIndex = 42;
            this.pbRight.TabStop = false;
            // 
            // pbLeft
            // 
            this.pbLeft.BackColor = System.Drawing.Color.Black;
            this.pbLeft.Location = new System.Drawing.Point(6, 23);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(12, 12);
            this.pbLeft.TabIndex = 43;
            this.pbLeft.TabStop = false;
            // 
            // pbTop
            // 
            this.pbTop.BackColor = System.Drawing.Color.Black;
            this.pbTop.Location = new System.Drawing.Point(24, 23);
            this.pbTop.Name = "pbTop";
            this.pbTop.Size = new System.Drawing.Size(12, 12);
            this.pbTop.TabIndex = 40;
            this.pbTop.TabStop = false;
            // 
            // pbBottom
            // 
            this.pbBottom.BackColor = System.Drawing.Color.Black;
            this.pbBottom.Location = new System.Drawing.Point(24, 5);
            this.pbBottom.Name = "pbBottom";
            this.pbBottom.Size = new System.Drawing.Size(12, 12);
            this.pbBottom.TabIndex = 41;
            this.pbBottom.TabStop = false;
            // 
            // ImportBids
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.pbTop);
            this.Controls.Add(this.pbBottom);
            this.Controls.Add(this.dv);
            this.Name = "ImportBids";
            this.Size = new System.Drawing.Size(748, 290);
            this.Resize += new System.EventHandler(this.ImportBids_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public NewMethod.nDataView dv;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.PictureBox pbTop;
        private System.Windows.Forms.PictureBox pbBottom;
    }
}
