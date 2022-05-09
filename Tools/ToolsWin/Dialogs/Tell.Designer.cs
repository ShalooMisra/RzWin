namespace ToolsWin.Dialogs
{
    partial class Tell
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
            this.tmrClose = new System.Windows.Forms.Timer(this.components);
            this.cmdWait = new System.Windows.Forms.Button();
            this.lblTicks = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tmrClose
            // 
            this.tmrClose.Interval = 1000;
            this.tmrClose.Tick += new System.EventHandler(this.tmrClose_Tick);
            // 
            // cmdWait
            // 
            this.cmdWait.Location = new System.Drawing.Point(444, 73);
            this.cmdWait.Name = "cmdWait";
            this.cmdWait.Size = new System.Drawing.Size(41, 28);
            this.cmdWait.TabIndex = 1;
            this.cmdWait.Text = "Wait";
            this.cmdWait.UseVisualStyleBackColor = true;
            this.cmdWait.Click += new System.EventHandler(this.cmdWait_Click);
            // 
            // lblTicks
            // 
            this.lblTicks.AutoSize = true;
            this.lblTicks.Font = new System.Drawing.Font("Palatino Linotype", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicks.Location = new System.Drawing.Point(444, 20);
            this.lblTicks.Name = "lblTicks";
            this.lblTicks.Size = new System.Drawing.Size(41, 50);
            this.lblTicks.TabIndex = 4;
            this.lblTicks.Text = "4";
            this.lblTicks.Visible = false;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.White;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Location = new System.Drawing.Point(4, 5);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(436, 97);
            this.txtMessage.TabIndex = 5;
            this.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Tell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(488, 148);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblTicks);
            this.Controls.Add(this.cmdWait);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tell";
            this.Resize += new System.EventHandler(this.Tell_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrClose;
        private System.Windows.Forms.Button cmdWait;
        private System.Windows.Forms.Label lblTicks;
        private System.Windows.Forms.TextBox txtMessage;
    }
}