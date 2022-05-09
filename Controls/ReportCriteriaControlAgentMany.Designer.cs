namespace RzInterfaceWin
{
    partial class ReportCriteriaControlAgentMany
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
            this.lblClearAgents = new System.Windows.Forms.LinkLabel();
            this.lblChooseAgents = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(40, 10);
            // 
            // pic
            // 
            this.pic.BackgroundImage = global::RzInterfaceWin.Properties.Resources.PeopleSmall;
            // 
            // lblClearAgents
            // 
            this.lblClearAgents.AutoSize = true;
            this.lblClearAgents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearAgents.Location = new System.Drawing.Point(40, 54);
            this.lblClearAgents.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClearAgents.Name = "lblClearAgents";
            this.lblClearAgents.Size = new System.Drawing.Size(46, 20);
            this.lblClearAgents.TabIndex = 28;
            this.lblClearAgents.TabStop = true;
            this.lblClearAgents.Text = "clear";
            this.lblClearAgents.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblClearAgents_LinkClicked);
            // 
            // lblChooseAgents
            // 
            this.lblChooseAgents.AutoSize = true;
            this.lblChooseAgents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseAgents.Location = new System.Drawing.Point(39, 34);
            this.lblChooseAgents.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChooseAgents.Name = "lblChooseAgents";
            this.lblChooseAgents.Size = new System.Drawing.Size(141, 20);
            this.lblChooseAgents.TabIndex = 27;
            this.lblChooseAgents.TabStop = true;
            this.lblChooseAgents.Text = "<click to choose>";
            this.lblChooseAgents.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChooseAgents_LinkClicked);
            // 
            // ReportCriteriaControlAgentMany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblClearAgents);
            this.Controls.Add(this.lblChooseAgents);
            this.Name = "ReportCriteriaControlAgentMany";
            this.Size = new System.Drawing.Size(271, 76);
            this.Controls.SetChildIndex(this.pic, 0);
            this.Controls.SetChildIndex(this.lblChooseAgents, 0);
            this.Controls.SetChildIndex(this.lblClearAgents, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.LinkLabel lblClearAgents;
        public System.Windows.Forms.LinkLabel lblChooseAgents;
    }
}
