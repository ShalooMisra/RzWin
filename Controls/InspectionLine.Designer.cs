namespace Rz5
{
    partial class InspectionLine
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
            this.gb = new System.Windows.Forms.GroupBox();
            this.optNA = new System.Windows.Forms.RadioButton();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.optNo = new System.Windows.Forms.RadioButton();
            this.optYes = new System.Windows.Forms.RadioButton();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.optNA);
            this.gb.Controls.Add(this.txtNotes);
            this.gb.Controls.Add(this.optNo);
            this.gb.Controls.Add(this.optYes);
            this.gb.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb.Location = new System.Drawing.Point(3, 0);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(451, 50);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            this.gb.Text = "<caption>AXSDFSFGEF";
            // 
            // optNA
            // 
            this.optNA.AutoSize = true;
            this.optNA.Location = new System.Drawing.Point(404, 20);
            this.optNA.Name = "optNA";
            this.optNA.Size = new System.Drawing.Size(45, 22);
            this.optNA.TabIndex = 4;
            this.optNA.TabStop = true;
            this.optNA.Text = "NA";
            this.optNA.UseVisualStyleBackColor = true;
            this.optNA.CheckedChanged += new System.EventHandler(this.optNA_CheckedChanged);
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(79, 19);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(319, 26);
            this.txtNotes.TabIndex = 3;
            // 
            // optNo
            // 
            this.optNo.AutoSize = true;
            this.optNo.Location = new System.Drawing.Point(43, 20);
            this.optNo.Name = "optNo";
            this.optNo.Size = new System.Drawing.Size(36, 22);
            this.optNo.TabIndex = 1;
            this.optNo.TabStop = true;
            this.optNo.Text = "N";
            this.optNo.UseVisualStyleBackColor = true;
            this.optNo.CheckedChanged += new System.EventHandler(this.optNo_CheckedChanged);
            // 
            // optYes
            // 
            this.optYes.AutoSize = true;
            this.optYes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.optYes.Location = new System.Drawing.Point(5, 20);
            this.optYes.Name = "optYes";
            this.optYes.Size = new System.Drawing.Size(33, 22);
            this.optYes.TabIndex = 0;
            this.optYes.TabStop = true;
            this.optYes.Text = "Y";
            this.optYes.UseVisualStyleBackColor = true;
            this.optYes.CheckedChanged += new System.EventHandler(this.optYes_CheckedChanged);
            // 
            // InspectionLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb);
            this.Name = "InspectionLine";
            this.Size = new System.Drawing.Size(456, 53);
            this.Resize += new System.EventHandler(this.InspectionLine_Resize);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.RadioButton optNo;
        private System.Windows.Forms.RadioButton optYes;
        private System.Windows.Forms.RadioButton optNA;
    }
}
