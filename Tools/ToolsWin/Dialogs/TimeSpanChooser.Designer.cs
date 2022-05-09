namespace ToolsWin.Dialogs
{
    partial class TimeSpanChooser
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
            this.lblDays = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.txtMinutes = new System.Windows.Forms.TextBox();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.pContents.SuspendLayout();
            this.SuspendLayout();
            // 
            // pContents
            // 
            this.pContents.Controls.Add(this.lblConfirm);
            this.pContents.Controls.Add(this.txtMinutes);
            this.pContents.Controls.Add(this.lblMinutes);
            this.pContents.Controls.Add(this.txtHours);
            this.pContents.Controls.Add(this.lblHours);
            this.pContents.Controls.Add(this.txtDays);
            this.pContents.Controls.Add(this.lblDays);
            this.pContents.Location = new System.Drawing.Point(0, 0);
            this.pContents.Size = new System.Drawing.Size(262, 188);
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.Location = new System.Drawing.Point(52, 14);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(53, 26);
            this.lblDays.TabIndex = 0;
            this.lblDays.Text = "Days";
            // 
            // txtDays
            // 
            this.txtDays.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDays.Location = new System.Drawing.Point(111, 11);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(95, 33);
            this.txtDays.TabIndex = 1;
            this.txtDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDays.TextChanged += new System.EventHandler(this.txtDays_TextChanged);
            // 
            // txtHours
            // 
            this.txtHours.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHours.Location = new System.Drawing.Point(111, 50);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(95, 33);
            this.txtHours.TabIndex = 3;
            this.txtHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHours.TextChanged += new System.EventHandler(this.txtDays_TextChanged);
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.Location = new System.Drawing.Point(43, 53);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(62, 26);
            this.lblHours.TabIndex = 2;
            this.lblHours.Text = "Hours";
            // 
            // txtMinutes
            // 
            this.txtMinutes.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinutes.Location = new System.Drawing.Point(111, 89);
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.Size = new System.Drawing.Size(95, 33);
            this.txtMinutes.TabIndex = 5;
            this.txtMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMinutes.TextChanged += new System.EventHandler(this.txtDays_TextChanged);
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.Location = new System.Drawing.Point(23, 92);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(82, 26);
            this.lblMinutes.TabIndex = 4;
            this.lblMinutes.Text = "Minutes";
            // 
            // lblConfirm
            // 
            this.lblConfirm.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirm.Location = new System.Drawing.Point(3, 139);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(256, 34);
            this.lblConfirm.TabIndex = 6;
            this.lblConfirm.Text = "<confirm>";
            this.lblConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeSpanChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 251);
            this.Name = "TimeSpanChooser";
            this.Text = "Time Span";
            this.pContents.ResumeLayout(false);
            this.pContents.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtMinutes;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Label lblDays;
    }
}