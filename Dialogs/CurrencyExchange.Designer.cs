namespace RzInterfaceWin.Dialogs
{
    partial class CurrencyExchange
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.currencyChoice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.baseValue = new System.Windows.Forms.TextBox();
            this.foreignValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rateLabel = new System.Windows.Forms.Label();
            this.picBase = new System.Windows.Forms.PictureBox();
            this.picForeign = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picForeign)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(67, 253);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(97, 33);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(5, 253);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(57, 33);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // currencyChoice
            // 
            this.currencyChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currencyChoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencyChoice.FormattingEnabled = true;
            this.currencyChoice.Location = new System.Drawing.Point(26, 31);
            this.currencyChoice.Name = "currencyChoice";
            this.currencyChoice.Size = new System.Drawing.Size(117, 28);
            this.currencyChoice.TabIndex = 2;
            this.currencyChoice.SelectedIndexChanged += new System.EventHandler(this.currencyChoice_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Currency:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Base currency amount:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Foreign currency amount:";
            // 
            // baseValue
            // 
            this.baseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseValue.Location = new System.Drawing.Point(20, 153);
            this.baseValue.Name = "baseValue";
            this.baseValue.Size = new System.Drawing.Size(106, 26);
            this.baseValue.TabIndex = 6;
            this.baseValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.baseValue.TextChanged += new System.EventHandler(this.baseValue_TextChanged);
            // 
            // foreignValue
            // 
            this.foreignValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreignValue.Location = new System.Drawing.Point(20, 211);
            this.foreignValue.Name = "foreignValue";
            this.foreignValue.Size = new System.Drawing.Size(106, 26);
            this.foreignValue.TabIndex = 7;
            this.foreignValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.foreignValue.TextChanged += new System.EventHandler(this.foreignValue_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Exchange Rate:";
            // 
            // rateLabel
            // 
            this.rateLabel.AutoSize = true;
            this.rateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rateLabel.Location = new System.Drawing.Point(60, 97);
            this.rateLabel.Name = "rateLabel";
            this.rateLabel.Size = new System.Drawing.Size(46, 16);
            this.rateLabel.TabIndex = 9;
            this.rateLabel.Text = "0.7734";
            // 
            // picBase
            // 
            this.picBase.BackColor = System.Drawing.Color.Red;
            this.picBase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBase.Location = new System.Drawing.Point(132, 153);
            this.picBase.Name = "picBase";
            this.picBase.Size = new System.Drawing.Size(24, 24);
            this.picBase.TabIndex = 10;
            this.picBase.TabStop = false;
            // 
            // picForeign
            // 
            this.picForeign.BackColor = System.Drawing.Color.Red;
            this.picForeign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picForeign.Location = new System.Drawing.Point(132, 211);
            this.picForeign.Name = "picForeign";
            this.picForeign.Size = new System.Drawing.Size(24, 24);
            this.picForeign.TabIndex = 11;
            this.picForeign.TabStop = false;
            // 
            // CurrencyExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(168, 291);
            this.Controls.Add(this.picForeign);
            this.Controls.Add(this.picBase);
            this.Controls.Add(this.rateLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.foreignValue);
            this.Controls.Add(this.baseValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currencyChoice);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CurrencyExchange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Currency Selection";
            ((System.ComponentModel.ISupportInitialize)(this.picBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picForeign)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox currencyChoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox baseValue;
        private System.Windows.Forms.TextBox foreignValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label rateLabel;
        private System.Windows.Forms.PictureBox picBase;
        private System.Windows.Forms.PictureBox picForeign;
    }
}