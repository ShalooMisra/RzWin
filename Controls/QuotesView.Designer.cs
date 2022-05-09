namespace Rz5
{
    partial class QuotesView
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
            this.gbQuotes = new System.Windows.Forms.GroupBox();
            this.optReceivingBids = new System.Windows.Forms.RadioButton();
            this.optGivingQuotes = new System.Windows.Forms.RadioButton();
            this.optAllQuotes = new System.Windows.Forms.RadioButton();
            this.gbQuotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbQuotes
            // 
            this.gbQuotes.Controls.Add(this.optReceivingBids);
            this.gbQuotes.Controls.Add(this.optGivingQuotes);
            this.gbQuotes.Controls.Add(this.optAllQuotes);
            this.gbQuotes.Location = new System.Drawing.Point(5, 4);
            this.gbQuotes.Name = "gbQuotes";
            this.gbQuotes.Size = new System.Drawing.Size(451, 31);
            this.gbQuotes.TabIndex = 4;
            this.gbQuotes.TabStop = false;
            this.gbQuotes.Text = "Options";
            // 
            // optReceivingBids
            // 
            this.optReceivingBids.AutoSize = true;
            this.optReceivingBids.Location = new System.Drawing.Point(225, 12);
            this.optReceivingBids.Name = "optReceivingBids";
            this.optReceivingBids.Size = new System.Drawing.Size(106, 17);
            this.optReceivingBids.TabIndex = 2;
            this.optReceivingBids.Text = "Only Vendor Bids";
            this.optReceivingBids.UseVisualStyleBackColor = true;
            // 
            // optGivingQuotes
            // 
            this.optGivingQuotes.AutoSize = true;
            this.optGivingQuotes.Location = new System.Drawing.Point(74, 12);
            this.optGivingQuotes.Name = "optGivingQuotes";
            this.optGivingQuotes.Size = new System.Drawing.Size(130, 17);
            this.optGivingQuotes.TabIndex = 1;
            this.optGivingQuotes.Text = "Only Customer Quotes";
            this.optGivingQuotes.UseVisualStyleBackColor = true;
            // 
            // optAllQuotes
            // 
            this.optAllQuotes.AutoSize = true;
            this.optAllQuotes.Checked = true;
            this.optAllQuotes.Location = new System.Drawing.Point(20, 12);
            this.optAllQuotes.Name = "optAllQuotes";
            this.optAllQuotes.Size = new System.Drawing.Size(36, 17);
            this.optAllQuotes.TabIndex = 0;
            this.optAllQuotes.TabStop = true;
            this.optAllQuotes.Text = "All";
            this.optAllQuotes.UseVisualStyleBackColor = true;
            // 
            // QuotesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbQuotes);
            this.Name = "QuotesView";
            this.Size = new System.Drawing.Size(708, 461);
            this.Resize += new System.EventHandler(this.QuotesView_Resize);
            this.gbQuotes.ResumeLayout(false);
            this.gbQuotes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox gbQuotes;
        private System.Windows.Forms.RadioButton optReceivingBids;
        private System.Windows.Forms.RadioButton optGivingQuotes;
        private System.Windows.Forms.RadioButton optAllQuotes;
    }
}
