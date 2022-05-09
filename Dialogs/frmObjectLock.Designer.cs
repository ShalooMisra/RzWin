namespace Rz5
{
    partial class frmObjectLock
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
            this.cmdIgnore = new System.Windows.Forms.Button();
            this.cmdCloseOther = new System.Windows.Forms.Button();
            this.lblCaption = new System.Windows.Forms.Label();
            this.lblExplanation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdIgnore
            // 
            this.cmdIgnore.Location = new System.Drawing.Point(234, 125);
            this.cmdIgnore.Name = "cmdIgnore";
            this.cmdIgnore.Size = new System.Drawing.Size(180, 65);
            this.cmdIgnore.TabIndex = 0;
            this.cmdIgnore.Text = "Ignore This Warning";
            this.cmdIgnore.UseVisualStyleBackColor = true;
            this.cmdIgnore.Click += new System.EventHandler(this.cmdIgnore_Click);
            // 
            // cmdCloseOther
            // 
            this.cmdCloseOther.Location = new System.Drawing.Point(11, 125);
            this.cmdCloseOther.Name = "cmdCloseOther";
            this.cmdCloseOther.Size = new System.Drawing.Size(180, 65);
            this.cmdCloseOther.TabIndex = 1;
            this.cmdCloseOther.Text = "Close this item on the other computer";
            this.cmdCloseOther.UseVisualStyleBackColor = true;
            this.cmdCloseOther.Click += new System.EventHandler(this.cmdCloseOther_Click);
            // 
            // lblCaption
            // 
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(8, 8);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(405, 30);
            this.lblCaption.TabIndex = 2;
            this.lblCaption.Text = "<caption>";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblExplanation
            // 
            this.lblExplanation.Location = new System.Drawing.Point(8, 52);
            this.lblExplanation.Name = "lblExplanation";
            this.lblExplanation.Size = new System.Drawing.Size(405, 70);
            this.lblExplanation.TabIndex = 3;
            this.lblExplanation.Text = "<explanation>";
            // 
            // frmObjectLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(426, 195);
            this.Controls.Add(this.lblExplanation);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.cmdCloseOther);
            this.Controls.Add(this.cmdIgnore);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmObjectLock";
            this.Text = "Item Open Notification";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdIgnore;
        private System.Windows.Forms.Button cmdCloseOther;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Label lblExplanation;
    }
}