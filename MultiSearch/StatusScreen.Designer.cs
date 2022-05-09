namespace MultiSearch
{
    partial class StatusScreen
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
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.cmdStockCheck = new System.Windows.Forms.Button();
            this.cmdRunEEM = new System.Windows.Forms.Button();
            this.chkIgnoreActivity = new System.Windows.Forms.CheckBox();
            this.cmdBrokerforum = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(104, 3);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(394, 418);
            this.txtStatus.TabIndex = 0;
            this.txtStatus.WordWrap = false;
            // 
            // cmdStockCheck
            // 
            this.cmdStockCheck.Location = new System.Drawing.Point(7, 3);
            this.cmdStockCheck.Name = "cmdStockCheck";
            this.cmdStockCheck.Size = new System.Drawing.Size(91, 26);
            this.cmdStockCheck.TabIndex = 1;
            this.cmdStockCheck.Text = "Stock Check";
            this.cmdStockCheck.UseVisualStyleBackColor = true;
            this.cmdStockCheck.Click += new System.EventHandler(this.cmdStockCheck_Click);
            // 
            // cmdRunEEM
            // 
            this.cmdRunEEM.Location = new System.Drawing.Point(7, 35);
            this.cmdRunEEM.Name = "cmdRunEEM";
            this.cmdRunEEM.Size = new System.Drawing.Size(91, 26);
            this.cmdRunEEM.TabIndex = 2;
            this.cmdRunEEM.Text = "EEM";
            this.cmdRunEEM.UseVisualStyleBackColor = true;
            this.cmdRunEEM.Click += new System.EventHandler(this.cmdRunEEM_Click);
            // 
            // chkIgnoreActivity
            // 
            this.chkIgnoreActivity.AutoSize = true;
            this.chkIgnoreActivity.Location = new System.Drawing.Point(5, 99);
            this.chkIgnoreActivity.Name = "chkIgnoreActivity";
            this.chkIgnoreActivity.Size = new System.Drawing.Size(93, 17);
            this.chkIgnoreActivity.TabIndex = 3;
            this.chkIgnoreActivity.Text = "Ignore Activity";
            this.chkIgnoreActivity.UseVisualStyleBackColor = true;
            this.chkIgnoreActivity.CheckedChanged += new System.EventHandler(this.chkIgnoreActivity_CheckedChanged);
            // 
            // cmdBrokerforum
            // 
            this.cmdBrokerforum.Location = new System.Drawing.Point(7, 67);
            this.cmdBrokerforum.Name = "cmdBrokerforum";
            this.cmdBrokerforum.Size = new System.Drawing.Size(91, 26);
            this.cmdBrokerforum.TabIndex = 4;
            this.cmdBrokerforum.Text = "BrokerForum";
            this.cmdBrokerforum.UseVisualStyleBackColor = true;
            this.cmdBrokerforum.Click += new System.EventHandler(this.cmdBrokerforum_Click);
            // 
            // StatusScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdBrokerforum);
            this.Controls.Add(this.chkIgnoreActivity);
            this.Controls.Add(this.cmdRunEEM);
            this.Controls.Add(this.cmdStockCheck);
            this.Controls.Add(this.txtStatus);
            this.Name = "StatusScreen";
            this.Size = new System.Drawing.Size(504, 424);
            this.Resize += new System.EventHandler(this.StatusScreen_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button cmdStockCheck;
        private System.Windows.Forms.Button cmdRunEEM;
        private System.Windows.Forms.CheckBox chkIgnoreActivity;
        private System.Windows.Forms.Button cmdBrokerforum;
    }
}
