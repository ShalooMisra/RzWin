namespace Rz5
{
    partial class LoginComplete
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
            this.pLogin = new System.Windows.Forms.Panel();
            this.lblBottom = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.pLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pLogin
            // 
            this.pLogin.BackColor = System.Drawing.Color.White;
            this.pLogin.Controls.Add(this.lblBottom);
            this.pLogin.Controls.Add(this.lblTop);
            this.pLogin.ForeColor = System.Drawing.Color.White;
            this.pLogin.Location = new System.Drawing.Point(0, 0);
            this.pLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pLogin.Name = "pLogin";
            this.pLogin.Size = new System.Drawing.Size(437, 73);
            this.pLogin.TabIndex = 20;
            this.pLogin.Resize += new System.EventHandler(this.pLogin_Resize);
            // 
            // lblBottom
            // 
            this.lblBottom.BackColor = System.Drawing.Color.White;
            this.lblBottom.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBottom.ForeColor = System.Drawing.Color.DarkGray;
            this.lblBottom.Location = new System.Drawing.Point(3, 36);
            this.lblBottom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBottom.Name = "lblBottom";
            this.lblBottom.Size = new System.Drawing.Size(432, 34);
            this.lblBottom.TabIndex = 17;
            this.lblBottom.Text = "Finishing Init";
            this.lblBottom.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTop
            // 
            this.lblTop.BackColor = System.Drawing.Color.White;
            this.lblTop.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTop.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTop.Location = new System.Drawing.Point(3, 2);
            this.lblTop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(432, 33);
            this.lblTop.TabIndex = 16;
            this.lblTop.Text = "Login Pending";
            this.lblTop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LoginComplete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pLogin);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LoginComplete";
            this.Size = new System.Drawing.Size(437, 73);
            this.pLogin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pLogin;
        private System.Windows.Forms.Label lblBottom;
        private System.Windows.Forms.Label lblTop;
    }
}
