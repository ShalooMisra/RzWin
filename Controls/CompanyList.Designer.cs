using NewMethod;

namespace Rz5
{
    partial class CompanyList
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
            this.optCompany = new System.Windows.Forms.RadioButton();
            this.optCustomer = new System.Windows.Forms.RadioButton();
            this.optVendor = new System.Windows.Forms.RadioButton();
            this.cbo = new System.Windows.Forms.ComboBox();
            this.lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // optCompany
            // 
            this.optCompany.AutoSize = true;
            this.optCompany.Location = new System.Drawing.Point(52, 8);
            this.optCompany.Name = "optCompany";
            this.optCompany.Size = new System.Drawing.Size(36, 17);
            this.optCompany.TabIndex = 0;
            this.optCompany.TabStop = true;
            this.optCompany.Text = "All";
            this.optCompany.UseVisualStyleBackColor = true;
            this.optCompany.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optCustomer
            // 
            this.optCustomer.AutoSize = true;
            this.optCustomer.Location = new System.Drawing.Point(88, 8);
            this.optCustomer.Name = "optCustomer";
            this.optCustomer.Size = new System.Drawing.Size(74, 17);
            this.optCustomer.TabIndex = 1;
            this.optCustomer.TabStop = true;
            this.optCustomer.Text = "Customers";
            this.optCustomer.UseVisualStyleBackColor = true;
            this.optCustomer.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optVendor
            // 
            this.optVendor.AutoSize = true;
            this.optVendor.Location = new System.Drawing.Point(160, 8);
            this.optVendor.Name = "optVendor";
            this.optVendor.Size = new System.Drawing.Size(64, 17);
            this.optVendor.TabIndex = 2;
            this.optVendor.TabStop = true;
            this.optVendor.Text = "Vendors";
            this.optVendor.UseVisualStyleBackColor = true;
            this.optVendor.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // cbo
            // 
            this.cbo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo.FormattingEnabled = true;
            this.cbo.Location = new System.Drawing.Point(0, 24);
            this.cbo.Name = "cbo";
            this.cbo.Size = new System.Drawing.Size(216, 28);
            this.cbo.TabIndex = 3;
            this.cbo.SelectedIndexChanged += new System.EventHandler(this.cbo_SelectedIndexChanged);
            this.cbo.SelectedValueChanged += new System.EventHandler(this.cbo_SelectedValueChanged);
            // 
            // lbl
            // 
            this.lbl.Location = new System.Drawing.Point(0, 5);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(57, 16);
            this.lbl.TabIndex = 4;
            this.lbl.Text = "Company";
            // 
            // CompanyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cbo);
            this.Controls.Add(this.optCompany);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.optVendor);
            this.Controls.Add(this.optCustomer);
            this.Name = "CompanyList";
            this.Size = new System.Drawing.Size(221, 55);
            this.Resize += new System.EventHandler(this.CompanyList_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton optCompany;
        private System.Windows.Forms.RadioButton optCustomer;
        private System.Windows.Forms.RadioButton optVendor;
        private System.Windows.Forms.ComboBox cbo;
        private System.Windows.Forms.Label lbl;
    }
}
