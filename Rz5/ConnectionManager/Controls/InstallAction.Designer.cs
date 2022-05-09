namespace ConnectionManager
{
    partial class InstallAction
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
            this.optServer = new System.Windows.Forms.RadioButton();
            this.optClient = new System.Windows.Forms.RadioButton();
            this.optDemo = new System.Windows.Forms.RadioButton();
            this.lblExplanation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // optServer
            // 
            this.optServer.AutoSize = true;
            this.optServer.Enabled = false;
            this.optServer.Location = new System.Drawing.Point(12, 86);
            this.optServer.Name = "optServer";
            this.optServer.Size = new System.Drawing.Size(86, 17);
            this.optServer.TabIndex = 42;
            this.optServer.Text = "Server Install";
            this.optServer.UseVisualStyleBackColor = true;
            // 
            // optClient
            // 
            this.optClient.AutoSize = true;
            this.optClient.Location = new System.Drawing.Point(12, 54);
            this.optClient.Name = "optClient";
            this.optClient.Size = new System.Drawing.Size(81, 17);
            this.optClient.TabIndex = 41;
            this.optClient.Text = "Client Install";
            this.optClient.UseVisualStyleBackColor = true;
            // 
            // optDemo
            // 
            this.optDemo.AutoSize = true;
            this.optDemo.Location = new System.Drawing.Point(12, 20);
            this.optDemo.Name = "optDemo";
            this.optDemo.Size = new System.Drawing.Size(83, 17);
            this.optDemo.TabIndex = 40;
            this.optDemo.Text = "Demo Install";
            this.optDemo.UseVisualStyleBackColor = true;
            // 
            // lblExplanation
            // 
            this.lblExplanation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExplanation.Location = new System.Drawing.Point(9, 0);
            this.lblExplanation.Name = "lblExplanation";
            this.lblExplanation.Size = new System.Drawing.Size(142, 23);
            this.lblExplanation.TabIndex = 39;
            this.lblExplanation.Text = "Installation options:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(29, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Use this option to evaluate Rz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(27, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Use this option to install a standard Rz workstation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(27, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Use this option for installing an Rz server";
            // 
            // InstallAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.optServer);
            this.Controls.Add(this.optClient);
            this.Controls.Add(this.optDemo);
            this.Controls.Add(this.lblExplanation);
            this.Name = "InstallAction";
            this.Controls.SetChildIndex(this.lblExplanation, 0);
            this.Controls.SetChildIndex(this.optDemo, 0);
            this.Controls.SetChildIndex(this.optClient, 0);
            this.Controls.SetChildIndex(this.optServer, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton optServer;
        private System.Windows.Forms.RadioButton optClient;
        private System.Windows.Forms.RadioButton optDemo;
        private System.Windows.Forms.Label lblExplanation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
