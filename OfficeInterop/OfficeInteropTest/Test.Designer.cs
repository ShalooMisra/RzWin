namespace OfficeInteropTest
{
    partial class Test
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
            this.cmdExcel = new System.Windows.Forms.Button();
            this.cmdWord = new System.Windows.Forms.Button();
            this.cmdOutlook = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdExcel
            // 
            this.cmdExcel.Location = new System.Drawing.Point(5, 4);
            this.cmdExcel.Name = "cmdExcel";
            this.cmdExcel.Size = new System.Drawing.Size(123, 41);
            this.cmdExcel.TabIndex = 0;
            this.cmdExcel.Text = "Excel";
            this.cmdExcel.UseVisualStyleBackColor = true;
            this.cmdExcel.Click += new System.EventHandler(this.cmdExcel_Click);
            // 
            // cmdWord
            // 
            this.cmdWord.Location = new System.Drawing.Point(5, 51);
            this.cmdWord.Name = "cmdWord";
            this.cmdWord.Size = new System.Drawing.Size(123, 41);
            this.cmdWord.TabIndex = 1;
            this.cmdWord.Text = "Word";
            this.cmdWord.UseVisualStyleBackColor = true;
            this.cmdWord.Click += new System.EventHandler(this.cmdWord_Click);
            // 
            // cmdOutlook
            // 
            this.cmdOutlook.Location = new System.Drawing.Point(5, 98);
            this.cmdOutlook.Name = "cmdOutlook";
            this.cmdOutlook.Size = new System.Drawing.Size(123, 41);
            this.cmdOutlook.TabIndex = 2;
            this.cmdOutlook.Text = "Outlook";
            this.cmdOutlook.UseVisualStyleBackColor = true;
            this.cmdOutlook.Click += new System.EventHandler(this.cmdOutlook_Click);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 335);
            this.Controls.Add(this.cmdOutlook);
            this.Controls.Add(this.cmdWord);
            this.Controls.Add(this.cmdExcel);
            this.Name = "Test";
            this.Text = "Test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdExcel;
        private System.Windows.Forms.Button cmdWord;
        private System.Windows.Forms.Button cmdOutlook;
    }
}

