namespace NewMethod
{
    partial class nSearchCriteria
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
            this.optLike = new System.Windows.Forms.RadioButton();
            this.optEquals = new System.Windows.Forms.RadioButton();
            this.optLessThan = new System.Windows.Forms.RadioButton();
            this.optMoreThan = new System.Windows.Forms.RadioButton();
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pbBottom = new System.Windows.Forms.PictureBox();
            this.pbTop = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // optLike
            // 
            this.optLike.AutoSize = true;
            this.optLike.Checked = true;
            this.optLike.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.optLike.Location = new System.Drawing.Point(45, 9);
            this.optLike.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.optLike.Name = "optLike";
            this.optLike.Size = new System.Drawing.Size(55, 21);
            this.optLike.TabIndex = 0;
            this.optLike.TabStop = true;
            this.optLike.Text = "Like";
            this.tTip1.SetToolTip(this.optLike, "Like");
            this.optLike.UseVisualStyleBackColor = true;
            // 
            // optEquals
            // 
            this.optEquals.AutoSize = true;
            this.optEquals.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.optEquals.Location = new System.Drawing.Point(7, 9);
            this.optEquals.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.optEquals.Name = "optEquals";
            this.optEquals.Size = new System.Drawing.Size(37, 21);
            this.optEquals.TabIndex = 1;
            this.optEquals.Text = "=";
            this.tTip1.SetToolTip(this.optEquals, "Equal To");
            this.optEquals.UseVisualStyleBackColor = true;
            // 
            // optLessThan
            // 
            this.optLessThan.AutoSize = true;
            this.optLessThan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.optLessThan.Location = new System.Drawing.Point(7, 36);
            this.optLessThan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.optLessThan.Name = "optLessThan";
            this.optLessThan.Size = new System.Drawing.Size(37, 21);
            this.optLessThan.TabIndex = 2;
            this.optLessThan.Text = "<";
            this.tTip1.SetToolTip(this.optLessThan, "Less Than");
            this.optLessThan.UseVisualStyleBackColor = true;
            // 
            // optMoreThan
            // 
            this.optMoreThan.AutoSize = true;
            this.optMoreThan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.optMoreThan.Location = new System.Drawing.Point(45, 36);
            this.optMoreThan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.optMoreThan.Name = "optMoreThan";
            this.optMoreThan.Size = new System.Drawing.Size(37, 21);
            this.optMoreThan.TabIndex = 3;
            this.optMoreThan.Text = ">";
            this.tTip1.SetToolTip(this.optMoreThan, "Greater Than");
            this.optMoreThan.UseVisualStyleBackColor = true;
            // 
            // pbLeft
            // 
            this.pbLeft.BackColor = System.Drawing.Color.Black;
            this.pbLeft.Location = new System.Drawing.Point(201, 177);
            this.pbLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(16, 15);
            this.pbLeft.TabIndex = 32;
            this.pbLeft.TabStop = false;
            // 
            // pbRight
            // 
            this.pbRight.BackColor = System.Drawing.Color.Black;
            this.pbRight.Location = new System.Drawing.Point(201, 155);
            this.pbRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(16, 15);
            this.pbRight.TabIndex = 31;
            this.pbRight.TabStop = false;
            // 
            // pbBottom
            // 
            this.pbBottom.BackColor = System.Drawing.Color.Black;
            this.pbBottom.Location = new System.Drawing.Point(225, 155);
            this.pbBottom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbBottom.Name = "pbBottom";
            this.pbBottom.Size = new System.Drawing.Size(16, 15);
            this.pbBottom.TabIndex = 30;
            this.pbBottom.TabStop = false;
            // 
            // pbTop
            // 
            this.pbTop.BackColor = System.Drawing.Color.Black;
            this.pbTop.Location = new System.Drawing.Point(225, 177);
            this.pbTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbTop.Name = "pbTop";
            this.pbTop.Size = new System.Drawing.Size(16, 15);
            this.pbTop.TabIndex = 29;
            this.pbTop.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(103, -18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(3, 159);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // nSearchCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.optMoreThan);
            this.Controls.Add(this.optLessThan);
            this.Controls.Add(this.optLike);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.pbBottom);
            this.Controls.Add(this.pbTop);
            this.Controls.Add(this.optEquals);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "nSearchCriteria";
            this.Size = new System.Drawing.Size(819, 432);
            this.Resize += new System.EventHandler(this.nSearchCriteria_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton optLike;
        private System.Windows.Forms.RadioButton optEquals;
        private System.Windows.Forms.RadioButton optLessThan;
        private System.Windows.Forms.RadioButton optMoreThan;
        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.PictureBox pbBottom;
        private System.Windows.Forms.PictureBox pbTop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip tTip1;
    }
}
