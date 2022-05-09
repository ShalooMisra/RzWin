namespace Rz5
{
    partial class CurrencySelector
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
            this.nameList = new System.Windows.Forms.ComboBox();
            this.currencyLabel = new System.Windows.Forms.Label();
            this.rateCaptionLabel = new System.Windows.Forms.Label();
            this.rateLabel = new System.Windows.Forms.Label();
            this.picCurrency = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrency)).BeginInit();
            this.SuspendLayout();
            // 
            // nameList
            // 
            this.nameList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nameList.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameList.FormattingEnabled = true;
            this.nameList.Location = new System.Drawing.Point(0, 14);
            this.nameList.Name = "nameList";
            this.nameList.Size = new System.Drawing.Size(67, 23);
            this.nameList.TabIndex = 0;
            this.nameList.SelectedIndexChanged += new System.EventHandler(this.nameList_SelectedIndexChanged);
            // 
            // currencyLabel
            // 
            this.currencyLabel.AutoSize = true;
            this.currencyLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencyLabel.Location = new System.Drawing.Point(-1, -2);
            this.currencyLabel.Name = "currencyLabel";
            this.currencyLabel.Size = new System.Drawing.Size(56, 15);
            this.currencyLabel.TabIndex = 1;
            this.currencyLabel.Text = "Currency";
            // 
            // rateCaptionLabel
            // 
            this.rateCaptionLabel.AutoSize = true;
            this.rateCaptionLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rateCaptionLabel.Location = new System.Drawing.Point(98, 0);
            this.rateCaptionLabel.Name = "rateCaptionLabel";
            this.rateCaptionLabel.Size = new System.Drawing.Size(31, 15);
            this.rateCaptionLabel.TabIndex = 2;
            this.rateCaptionLabel.Text = "Rate";
            // 
            // rateLabel
            // 
            this.rateLabel.AutoSize = true;
            this.rateLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rateLabel.Location = new System.Drawing.Point(98, 17);
            this.rateLabel.Name = "rateLabel";
            this.rateLabel.Size = new System.Drawing.Size(59, 15);
            this.rateLabel.TabIndex = 3;
            this.rateLabel.Text = "0.123456";
            // 
            // picCurrency
            // 
            this.picCurrency.BackColor = System.Drawing.Color.Red;
            this.picCurrency.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picCurrency.Location = new System.Drawing.Point(70, 13);
            this.picCurrency.Name = "picCurrency";
            this.picCurrency.Size = new System.Drawing.Size(16, 16);
            this.picCurrency.TabIndex = 6;
            this.picCurrency.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(69, 1);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(26, 13);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "USD";
            // 
            // CurrencySelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.picCurrency);
            this.Controls.Add(this.rateLabel);
            this.Controls.Add(this.rateCaptionLabel);
            this.Controls.Add(this.currencyLabel);
            this.Controls.Add(this.nameList);
            this.Name = "CurrencySelector";
            this.Size = new System.Drawing.Size(166, 40);
            ((System.ComponentModel.ISupportInitialize)(this.picCurrency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox nameList;
        private System.Windows.Forms.Label currencyLabel;
        private System.Windows.Forms.Label rateCaptionLabel;
        private System.Windows.Forms.Label rateLabel;
        private System.Windows.Forms.PictureBox picCurrency;
        private System.Windows.Forms.Label nameLabel;
    }
}
