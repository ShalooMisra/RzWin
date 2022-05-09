using NewMethod;

namespace Rz5
{
    partial class CompanyStub
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
            this.lblCaption = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.LinkLabel();
            this.lblViewCompany = new System.Windows.Forms.LinkLabel();
            this.lblSearchCompany = new System.Windows.Forms.LinkLabel();
            this.lblNewCompany = new System.Windows.Forms.LinkLabel();
            this.lblClearCompany = new System.Windows.Forms.LinkLabel();
            this.lblLast = new System.Windows.Forms.LinkLabel();
            this.lblSummary = new System.Windows.Forms.LinkLabel();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyCompanyNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(0, -1);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(113, 13);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "<caption>";
            // 
            // lblCompany
            // 
            this.lblCompany.ContextMenuStrip = this.mnu;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.Location = new System.Drawing.Point(0, 12);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(332, 27);
            this.lblCompany.TabIndex = 1;
            this.lblCompany.TabStop = true;
            this.lblCompany.Text = "<company>";
            this.lblCompany.UseMnemonic = false;
            this.lblCompany.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCompany_LinkClicked);
            // 
            // lblViewCompany
            // 
            this.lblViewCompany.AutoSize = true;
            this.lblViewCompany.LinkColor = System.Drawing.Color.Purple;
            this.lblViewCompany.Location = new System.Drawing.Point(10, 34);
            this.lblViewCompany.Name = "lblViewCompany";
            this.lblViewCompany.Size = new System.Drawing.Size(29, 13);
            this.lblViewCompany.TabIndex = 2;
            this.lblViewCompany.TabStop = true;
            this.lblViewCompany.Text = "view";
            this.lblViewCompany.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblViewCompany_LinkClicked);
            // 
            // lblSearchCompany
            // 
            this.lblSearchCompany.LinkColor = System.Drawing.Color.Purple;
            this.lblSearchCompany.Location = new System.Drawing.Point(172, 34);
            this.lblSearchCompany.Name = "lblSearchCompany";
            this.lblSearchCompany.Size = new System.Drawing.Size(39, 19);
            this.lblSearchCompany.TabIndex = 9;
            this.lblSearchCompany.TabStop = true;
            this.lblSearchCompany.Text = "search";
            this.lblSearchCompany.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSearchCompany_LinkClicked);
            // 
            // lblNewCompany
            // 
            this.lblNewCompany.AutoSize = true;
            this.lblNewCompany.LinkColor = System.Drawing.Color.Purple;
            this.lblNewCompany.Location = new System.Drawing.Point(135, 34);
            this.lblNewCompany.Name = "lblNewCompany";
            this.lblNewCompany.Size = new System.Drawing.Size(27, 13);
            this.lblNewCompany.TabIndex = 8;
            this.lblNewCompany.TabStop = true;
            this.lblNewCompany.Text = "new";
            this.lblNewCompany.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNewCompany_LinkClicked);
            // 
            // lblClearCompany
            // 
            this.lblClearCompany.AutoSize = true;
            this.lblClearCompany.LinkColor = System.Drawing.Color.Purple;
            this.lblClearCompany.Location = new System.Drawing.Point(45, 34);
            this.lblClearCompany.Name = "lblClearCompany";
            this.lblClearCompany.Size = new System.Drawing.Size(30, 13);
            this.lblClearCompany.TabIndex = 7;
            this.lblClearCompany.TabStop = true;
            this.lblClearCompany.Text = "clear";
            this.lblClearCompany.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblClearCompany_LinkClicked);
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.LinkColor = System.Drawing.Color.Purple;
            this.lblLast.Location = new System.Drawing.Point(217, 34);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(23, 13);
            this.lblLast.TabIndex = 10;
            this.lblLast.TabStop = true;
            this.lblLast.Text = "last";
            this.lblLast.UseMnemonic = false;
            this.lblLast.MouseLeave += new System.EventHandler(this.lblLast_MouseLeave);
            this.lblLast.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLast_LinkClicked);
            this.lblLast.MouseHover += new System.EventHandler(this.lblLast_MouseHover);
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.LinkColor = System.Drawing.Color.Purple;
            this.lblSummary.Location = new System.Drawing.Point(81, 34);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(48, 13);
            this.lblSummary.TabIndex = 11;
            this.lblSummary.TabStop = true;
            this.lblSummary.Text = "summary";
            this.lblSummary.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSummary_LinkClicked);
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyCompanyNameToolStripMenuItem});
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(178, 26);
            // 
            // copyCompanyNameToolStripMenuItem
            // 
            this.copyCompanyNameToolStripMenuItem.Name = "copyCompanyNameToolStripMenuItem";
            this.copyCompanyNameToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.copyCompanyNameToolStripMenuItem.Text = "Copy Company Name";
            this.copyCompanyNameToolStripMenuItem.Click += new System.EventHandler(this.copyCompanyNameToolStripMenuItem_Click);
            // 
            // CompanyStub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.lblLast);
            this.Controls.Add(this.lblSearchCompany);
            this.Controls.Add(this.lblNewCompany);
            this.Controls.Add(this.lblClearCompany);
            this.Controls.Add(this.lblViewCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblCaption);
            this.Name = "CompanyStub";
            this.Size = new System.Drawing.Size(344, 51);
            this.mnu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.LinkLabel lblCompany;
        private System.Windows.Forms.LinkLabel lblViewCompany;
        private System.Windows.Forms.LinkLabel lblSearchCompany;
        private System.Windows.Forms.LinkLabel lblNewCompany;
        private System.Windows.Forms.LinkLabel lblClearCompany;
        private System.Windows.Forms.LinkLabel lblLast;
        private System.Windows.Forms.LinkLabel lblSummary;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.ContextMenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem copyCompanyNameToolStripMenuItem;
    }
}
