namespace Rz5
{
    partial class view_ordhit
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
            this.ctl_deduct_profit = new NewMethod.nEdit_Boolean();
            this.ctl_original_amount = new NewMethod.nEdit_Money();
            this.ctl_hit_amount = new NewMethod.nEdit_Money();
            this.ctl_description = new NewMethod.nEdit_String();
            this.ctl_ordhit_name = new NewMethod.nEdit_List();
            this.SuspendLayout();
            // 
            // ctl_deduct_profit
            // 
            this.ctl_deduct_profit.BackColor = System.Drawing.Color.White;
            this.ctl_deduct_profit.Bold = false;
            this.ctl_deduct_profit.Caption = "Deduct Profit";
            this.ctl_deduct_profit.Changed = false;
            this.ctl_deduct_profit.Location = new System.Drawing.Point(253, 33);
            this.ctl_deduct_profit.Name = "ctl_deduct_profit";
            this.ctl_deduct_profit.Size = new System.Drawing.Size(118, 24);
            this.ctl_deduct_profit.TabIndex = 9;
            this.ctl_deduct_profit.UseParentBackColor = true;
            // 
            // ctl_original_amount
            // 
            this.ctl_original_amount.BackColor = System.Drawing.Color.White;
            this.ctl_original_amount.Bold = false;
            this.ctl_original_amount.Caption = "Original Amount (Optional)";
            this.ctl_original_amount.Changed = false;
            this.ctl_original_amount.EditCaption = false;
            this.ctl_original_amount.FullDecimal = false;
            this.ctl_original_amount.Location = new System.Drawing.Point(227, 141);
            this.ctl_original_amount.Name = "ctl_original_amount";
            this.ctl_original_amount.RoundNearestCent = false;
            this.ctl_original_amount.Size = new System.Drawing.Size(144, 47);
            this.ctl_original_amount.TabIndex = 10;
            this.ctl_original_amount.UseParentBackColor = true;
            // 
            // ctl_hit_amount
            // 
            this.ctl_hit_amount.BackColor = System.Drawing.Color.White;
            this.ctl_hit_amount.Bold = false;
            this.ctl_hit_amount.Caption = "Final Amount";
            this.ctl_hit_amount.Changed = false;
            this.ctl_hit_amount.EditCaption = false;
            this.ctl_hit_amount.FullDecimal = false;
            this.ctl_hit_amount.Location = new System.Drawing.Point(227, 194);
            this.ctl_hit_amount.Name = "ctl_hit_amount";
            this.ctl_hit_amount.RoundNearestCent = false;
            this.ctl_hit_amount.Size = new System.Drawing.Size(144, 47);
            this.ctl_hit_amount.TabIndex = 11;
            this.ctl_hit_amount.UseParentBackColor = true;
            // 
            // ctl_description
            // 
            this.ctl_description.AllCaps = false;
            this.ctl_description.BackColor = System.Drawing.Color.White;
            this.ctl_description.Bold = false;
            this.ctl_description.Caption = "Extra Description";
            this.ctl_description.Changed = false;
            this.ctl_description.IsEmail = false;
            this.ctl_description.IsURL = false;
            this.ctl_description.Location = new System.Drawing.Point(3, 89);
            this.ctl_description.Name = "ctl_description";
            this.ctl_description.PasswordChar = '\0';
            this.ctl_description.Size = new System.Drawing.Size(368, 46);
            this.ctl_description.TabIndex = 12;
            this.ctl_description.UseParentBackColor = true;
            // 
            // ctl_ordhit_name
            // 
            this.ctl_ordhit_name.AllowEdit = false;
            this.ctl_ordhit_name.BackColor = System.Drawing.Color.White;
            this.ctl_ordhit_name.Bold = false;
            this.ctl_ordhit_name.Caption = "Deduction Description";
            this.ctl_ordhit_name.Changed = false;
            this.ctl_ordhit_name.ListName = null;
            this.ctl_ordhit_name.Location = new System.Drawing.Point(3, 42);
            this.ctl_ordhit_name.Name = "ctl_ordhit_name";
            this.ctl_ordhit_name.SimpleList = "Incoming Shipping|Outgoing Shipping|Below Min. Order Fee|Credit Card Fee|Restocki" +
                "ng Fee";
            this.ctl_ordhit_name.Size = new System.Drawing.Size(368, 42);
            this.ctl_ordhit_name.TabIndex = 13;
            this.ctl_ordhit_name.UseParentBackColor = true;
            // 
            // view_ordhit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctl_deduct_profit);
            this.Controls.Add(this.ctl_ordhit_name);
            this.Controls.Add(this.ctl_description);
            this.Controls.Add(this.ctl_hit_amount);
            this.Controls.Add(this.ctl_original_amount);
            this.Name = "view_ordhit";
            this.Size = new System.Drawing.Size(846, 509);
            this.Controls.SetChildIndex(this.ctl_original_amount, 0);
            this.Controls.SetChildIndex(this.ctl_hit_amount, 0);
            this.Controls.SetChildIndex(this.ctl_description, 0);
            this.Controls.SetChildIndex(this.ctl_ordhit_name, 0);
            this.Controls.SetChildIndex(this.ctl_deduct_profit, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nEdit_Boolean ctl_deduct_profit;
        private NewMethod.nEdit_Money ctl_original_amount;
        private NewMethod.nEdit_Money ctl_hit_amount;
        private NewMethod.nEdit_String ctl_description;
        private NewMethod.nEdit_List ctl_ordhit_name;
    }
}
