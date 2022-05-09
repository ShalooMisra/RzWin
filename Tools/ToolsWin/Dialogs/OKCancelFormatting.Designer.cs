namespace ToolsWin.Dialogs
{
    partial class OkCancelFormatting
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
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.pOptions = new System.Windows.Forms.Panel();
            this.rtTitle = new System.Windows.Forms.RichTextBox();
            this.rtBody = new System.Windows.Forms.RichTextBox();
            this.pOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdOK.ImageKey = "ok";
            this.cmdOK.Location = new System.Drawing.Point(195, 3);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(391, 58);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "&Yes";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdCancel.ImageKey = "cancel";
            this.cmdCancel.Location = new System.Drawing.Point(3, 3);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(186, 58);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "&No";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // pOptions
            // 
            this.pOptions.BackColor = System.Drawing.Color.White;
            this.pOptions.Controls.Add(this.cmdCancel);
            this.pOptions.Controls.Add(this.cmdOK);
            this.pOptions.Location = new System.Drawing.Point(61, 229);
            this.pOptions.Name = "pOptions";
            this.pOptions.Size = new System.Drawing.Size(592, 63);
            this.pOptions.TabIndex = 2;
            // 
            // rtTitle
            // 
            this.rtTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtTitle.Location = new System.Drawing.Point(12, 2);
            this.rtTitle.Name = "rtTitle";
            this.rtTitle.Size = new System.Drawing.Size(683, 54);
            this.rtTitle.TabIndex = 6;
            this.rtTitle.Text = "";
            // 
            // rtBody
            // 
            this.rtBody.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtBody.Location = new System.Drawing.Point(26, 62);
            this.rtBody.Name = "rtBody";
            this.rtBody.Size = new System.Drawing.Size(654, 161);
            this.rtBody.TabIndex = 7;
            this.rtBody.Text = "";
            // 
            // OkCancelFormatting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(707, 306);
            this.Controls.Add(this.rtBody);
            this.Controls.Add(this.rtTitle);
            this.Controls.Add(this.pOptions);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OkCancelFormatting";
            this.Text = "OKCancel";
            this.Activated += new System.EventHandler(this.OKCancel_Activated);
            this.Resize += new System.EventHandler(this.OKCancel_Resize);
            this.pOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button cmdOK;
        protected System.Windows.Forms.Button cmdCancel;
        protected System.Windows.Forms.Panel pOptions;
        private System.Windows.Forms.RichTextBox rtTitle;
        private System.Windows.Forms.RichTextBox rtBody;
    }
}