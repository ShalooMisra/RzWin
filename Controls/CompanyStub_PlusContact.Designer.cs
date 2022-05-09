using NewMethod;

namespace Rz5
{
    partial class CompanyStub_PlusContact
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
            this.components = new System.ComponentModel.Container();
            this.lblContact = new System.Windows.Forms.LinkLabel();
            this.lblViewContact = new System.Windows.Forms.LinkLabel();
            this.lblClearContact = new System.Windows.Forms.LinkLabel();
            this.lblNewContact = new System.Windows.Forms.LinkLabel();
            this.lblSearchContact = new System.Windows.Forms.LinkLabel();
            this.lblLastContact = new System.Windows.Forms.LinkLabel();
            this.tipContact = new System.Windows.Forms.ToolTip(this.components);
            this.lblSummaryContact = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(0, 50);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(80, 20);
            this.lblContact.TabIndex = 2;
            this.lblContact.TabStop = true;
            this.lblContact.Text = "<contact>";
            this.lblContact.UseMnemonic = false;
            this.lblContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblContact_LinkClicked);
            // 
            // lblViewContact
            // 
            this.lblViewContact.AutoSize = true;
            this.lblViewContact.LinkColor = System.Drawing.Color.Purple;
            this.lblViewContact.Location = new System.Drawing.Point(10, 70);
            this.lblViewContact.Name = "lblViewContact";
            this.lblViewContact.Size = new System.Drawing.Size(29, 13);
            this.lblViewContact.TabIndex = 11;
            this.lblViewContact.TabStop = true;
            this.lblViewContact.Text = "view";
            this.lblViewContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblViewContact_LinkClicked);
            // 
            // lblClearContact
            // 
            this.lblClearContact.AutoSize = true;
            this.lblClearContact.LinkColor = System.Drawing.Color.Purple;
            this.lblClearContact.Location = new System.Drawing.Point(45, 70);
            this.lblClearContact.Name = "lblClearContact";
            this.lblClearContact.Size = new System.Drawing.Size(30, 13);
            this.lblClearContact.TabIndex = 12;
            this.lblClearContact.TabStop = true;
            this.lblClearContact.Text = "clear";
            this.lblClearContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblClearContact_LinkClicked);
            // 
            // lblNewContact
            // 
            this.lblNewContact.AutoSize = true;
            this.lblNewContact.LinkColor = System.Drawing.Color.Purple;
            this.lblNewContact.Location = new System.Drawing.Point(135, 70);
            this.lblNewContact.Name = "lblNewContact";
            this.lblNewContact.Size = new System.Drawing.Size(27, 13);
            this.lblNewContact.TabIndex = 14;
            this.lblNewContact.TabStop = true;
            this.lblNewContact.Text = "new";
            this.lblNewContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNewContact_LinkClicked);
            // 
            // lblSearchContact
            // 
            this.lblSearchContact.AutoSize = true;
            this.lblSearchContact.LinkColor = System.Drawing.Color.Purple;
            this.lblSearchContact.Location = new System.Drawing.Point(172, 70);
            this.lblSearchContact.Name = "lblSearchContact";
            this.lblSearchContact.Size = new System.Drawing.Size(39, 13);
            this.lblSearchContact.TabIndex = 0;
            this.lblSearchContact.TabStop = true;
            this.lblSearchContact.Text = "search";
            this.lblSearchContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSearchContact_LinkClicked);
            // 
            // lblLastContact
            // 
            this.lblLastContact.AutoSize = true;
            this.lblLastContact.LinkColor = System.Drawing.Color.Purple;
            this.lblLastContact.Location = new System.Drawing.Point(217, 70);
            this.lblLastContact.Name = "lblLastContact";
            this.lblLastContact.Size = new System.Drawing.Size(23, 13);
            this.lblLastContact.TabIndex = 1;
            this.lblLastContact.TabStop = true;
            this.lblLastContact.Text = "last";
            this.lblLastContact.UseMnemonic = false;
            this.lblLastContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLastContact_LinkClicked);
            this.lblLastContact.MouseLeave += new System.EventHandler(this.lblLastContact_MouseLeave);
            this.lblLastContact.MouseHover += new System.EventHandler(this.lblLastContact_MouseHover);
            // 
            // lblSummaryContact
            // 
            this.lblSummaryContact.AutoSize = true;
            this.lblSummaryContact.LinkColor = System.Drawing.Color.Purple;
            this.lblSummaryContact.Location = new System.Drawing.Point(81, 70);
            this.lblSummaryContact.Name = "lblSummaryContact";
            this.lblSummaryContact.Size = new System.Drawing.Size(48, 13);
            this.lblSummaryContact.TabIndex = 13;
            this.lblSummaryContact.TabStop = true;
            this.lblSummaryContact.Text = "summary";
            this.lblSummaryContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSummaryContact_LinkClicked);
            // 
            // CompanyStub_PlusContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblSummaryContact);
            this.Controls.Add(this.lblLastContact);
            this.Controls.Add(this.lblSearchContact);
            this.Controls.Add(this.lblNewContact);
            this.Controls.Add(this.lblClearContact);
            this.Controls.Add(this.lblViewContact);
            this.Name = "CompanyStub_PlusContact";
            this.Size = new System.Drawing.Size(402, 89);
            this.Controls.SetChildIndex(this.lblViewContact, 0);
            this.Controls.SetChildIndex(this.lblClearContact, 0);
            this.Controls.SetChildIndex(this.lblNewContact, 0);
            this.Controls.SetChildIndex(this.lblSearchContact, 0);
            this.Controls.SetChildIndex(this.lblLastContact, 0);
            this.Controls.SetChildIndex(this.lblSummaryContact, 0);
            this.Controls.SetChildIndex(this.lblContact, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblContact;
        private System.Windows.Forms.LinkLabel lblViewContact;
        private System.Windows.Forms.LinkLabel lblClearContact;
        private System.Windows.Forms.LinkLabel lblNewContact;
        private System.Windows.Forms.LinkLabel lblSearchContact;
        private System.Windows.Forms.LinkLabel lblLastContact;
        private System.Windows.Forms.ToolTip tipContact;
        private System.Windows.Forms.LinkLabel lblSummaryContact;
    }
}
