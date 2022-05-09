namespace Rz5.Win.Controls
{
    partial class OrderLinePanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.pRight = new System.Windows.Forms.PictureBox();
            this.pLeft = new System.Windows.Forms.PictureBox();
            this.pBottom = new System.Windows.Forms.PictureBox();
            this.pTop = new System.Windows.Forms.PictureBox();
            this.lblType = new System.Windows.Forms.Label();
            this.optNone = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.optOrder = new System.Windows.Forms.RadioButton();
            this.pOrder = new System.Windows.Forms.Panel();
            this.lblPreview = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.bg = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTop)).BeginInit();
            this.pOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type:";
            // 
            // pRight
            // 
            this.pRight.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pRight.Location = new System.Drawing.Point(234, 3);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(3, 144);
            this.pRight.TabIndex = 41;
            this.pRight.TabStop = false;
            // 
            // pLeft
            // 
            this.pLeft.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft.Location = new System.Drawing.Point(0, 3);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(3, 144);
            this.pLeft.TabIndex = 40;
            this.pLeft.TabStop = false;
            // 
            // pBottom
            // 
            this.pBottom.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBottom.Location = new System.Drawing.Point(0, 147);
            this.pBottom.Name = "pBottom";
            this.pBottom.Size = new System.Drawing.Size(237, 3);
            this.pBottom.TabIndex = 39;
            this.pBottom.TabStop = false;
            // 
            // pTop
            // 
            this.pTop.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTop.Location = new System.Drawing.Point(0, 0);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(237, 3);
            this.pTop.TabIndex = 38;
            this.pTop.TabStop = false;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(46, 6);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(46, 23);
            this.lblType.TabIndex = 42;
            this.lblType.Text = "Type";
            // 
            // optNone
            // 
            this.optNone.AutoSize = true;
            this.optNone.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optNone.Location = new System.Drawing.Point(47, 34);
            this.optNone.Name = "optNone";
            this.optNone.Size = new System.Drawing.Size(69, 27);
            this.optNone.TabIndex = 43;
            this.optNone.TabStop = true;
            this.optNone.Text = "None";
            this.optNone.UseVisualStyleBackColor = true;
            this.optNone.Click += new System.EventHandler(this.optNone_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 44;
            this.label2.Text = "Link:";
            // 
            // optOrder
            // 
            this.optOrder.AutoSize = true;
            this.optOrder.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optOrder.Location = new System.Drawing.Point(122, 34);
            this.optOrder.Name = "optOrder";
            this.optOrder.Size = new System.Drawing.Size(72, 27);
            this.optOrder.TabIndex = 45;
            this.optOrder.TabStop = true;
            this.optOrder.Text = "Sale #";
            this.optOrder.UseVisualStyleBackColor = true;
            // 
            // pOrder
            // 
            this.pOrder.Controls.Add(this.lblPreview);
            this.pOrder.Controls.Add(this.txtOrder);
            this.pOrder.Location = new System.Drawing.Point(9, 60);
            this.pOrder.Name = "pOrder";
            this.pOrder.Size = new System.Drawing.Size(185, 81);
            this.pOrder.TabIndex = 46;
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreview.Location = new System.Drawing.Point(3, 41);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(62, 15);
            this.lblPreview.TabIndex = 47;
            this.lblPreview.Text = "<preview>";
            // 
            // txtOrder
            // 
            this.txtOrder.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrder.Location = new System.Drawing.Point(3, 7);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(126, 31);
            this.txtOrder.TabIndex = 0;
            this.txtOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrder_KeyPress);
            // 
            // tmr
            // 
            this.tmr.Interval = 700;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // OrderLinePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pOrder);
            this.Controls.Add(this.optOrder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.optNone);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.pRight);
            this.Controls.Add(this.pLeft);
            this.Controls.Add(this.pBottom);
            this.Controls.Add(this.pTop);
            this.Controls.Add(this.label1);
            this.Name = "OrderLinePanel";
            this.Size = new System.Drawing.Size(237, 150);
            ((System.ComponentModel.ISupportInitialize)(this.pRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTop)).EndInit();
            this.pOrder.ResumeLayout(false);
            this.pOrder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pRight;
        private System.Windows.Forms.PictureBox pLeft;
        private System.Windows.Forms.PictureBox pBottom;
        private System.Windows.Forms.PictureBox pTop;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.RadioButton optNone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton optOrder;
        private System.Windows.Forms.Panel pOrder;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.Timer tmr;
        private System.ComponentModel.BackgroundWorker bg;
    }
}
