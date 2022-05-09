using NewMethod;

namespace Rz5
{
    partial class view_shippingaccount
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
            this.ctl_description = new NewMethod.nEdit_String();
            this.ctl_accountnumber = new NewMethod.nEdit_String();
            this.SuspendLayout();
            // 
            // ctl_description
            // 
            this.ctl_description.BackColor = System.Drawing.Color.White;
            this.ctl_description.Bold = false;
            this.ctl_description.Caption = "Description";
            this.ctl_description.Changed = false;
            this.ctl_description.IsEmail = false;
            this.ctl_description.IsURL = false;
            this.ctl_description.Location = new System.Drawing.Point(3, 50);
            this.ctl_description.Name = "ctl_description";
            this.ctl_description.Size = new System.Drawing.Size(426, 49);
            this.ctl_description.TabIndex = 8;
            this.ctl_description.UseParentBackColor = true;
            // 
            // ctl_accountnumber
            // 
            this.ctl_accountnumber.BackColor = System.Drawing.Color.White;
            this.ctl_accountnumber.Bold = false;
            this.ctl_accountnumber.Caption = "Number";
            this.ctl_accountnumber.Changed = false;
            this.ctl_accountnumber.IsEmail = false;
            this.ctl_accountnumber.IsURL = false;
            this.ctl_accountnumber.Location = new System.Drawing.Point(3, 105);
            this.ctl_accountnumber.Name = "ctl_accountnumber";
            this.ctl_accountnumber.Size = new System.Drawing.Size(426, 49);
            this.ctl_accountnumber.TabIndex = 9;
            this.ctl_accountnumber.UseParentBackColor = true;
            // 
            // view_shippingaccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctl_accountnumber);
            this.Controls.Add(this.ctl_description);
            this.Name = "view_shippingaccount";
            this.Controls.SetChildIndex(this.ctl_description, 0);
            this.Controls.SetChildIndex(this.ctl_accountnumber, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nEdit_String ctl_description;
        private NewMethod.nEdit_String ctl_accountnumber;
    }
}
