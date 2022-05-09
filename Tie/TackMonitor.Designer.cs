namespace Tie
{
    partial class TackMonitor
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
            CloseTack();

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
            this.components = new System.ComponentModel.Container();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.picDisconnected = new System.Windows.Forms.PictureBox();
            this.picConnected = new System.Windows.Forms.PictureBox();
            this.picTie = new System.Windows.Forms.PictureBox();
            this.status = new Tie.nEndlessStatusBox();
            this.lblError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDisconnected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picConnected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTie)).BeginInit();
            this.SuspendLayout();
            // 
            // tmr
            // 
            this.tmr.Interval = 1000;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(374, 34);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "<status>";
            // 
            // picDisconnected
            // 
            this.picDisconnected.Image = global::Tie.Properties.Resources.disconnected;
            this.picDisconnected.Location = new System.Drawing.Point(374, 3);
            this.picDisconnected.Name = "picDisconnected";
            this.picDisconnected.Size = new System.Drawing.Size(30, 28);
            this.picDisconnected.TabIndex = 6;
            this.picDisconnected.TabStop = false;
            this.picDisconnected.Visible = false;
            // 
            // picConnected
            // 
            this.picConnected.Image = global::Tie.Properties.Resources.whitetick;
            this.picConnected.Location = new System.Drawing.Point(374, 3);
            this.picConnected.Name = "picConnected";
            this.picConnected.Size = new System.Drawing.Size(30, 28);
            this.picConnected.TabIndex = 5;
            this.picConnected.TabStop = false;
            this.picConnected.Visible = false;
            // 
            // picTie
            // 
            this.picTie.Image = global::Tie.Properties.Resources.single_tie;
            this.picTie.Location = new System.Drawing.Point(4, 3);
            this.picTie.Name = "picTie";
            this.picTie.Size = new System.Drawing.Size(81, 201);
            this.picTie.TabIndex = 1;
            this.picTie.TabStop = false;
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(81, 3);
            this.status.Name = "status";
            this.status.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.status.Size = new System.Drawing.Size(287, 201);
            this.status.TabIndex = 0;
            this.status.Text = "";
            this.status.WordWrap = false;
            // 
            // lblError
            // 
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(372, 124);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(254, 78);
            this.lblError.TabIndex = 7;
            this.lblError.Text = "<error>";
            this.lblError.Visible = false;
            // 
            // TackMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.status);
            this.Controls.Add(this.picDisconnected);
            this.Controls.Add(this.picConnected);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.picTie);
            this.Name = "TackMonitor";
            this.Size = new System.Drawing.Size(697, 202);
            ((System.ComponentModel.ISupportInitialize)(this.picDisconnected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picConnected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private nEndlessStatusBox status;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.PictureBox picTie;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox picConnected;
        private System.Windows.Forms.PictureBox picDisconnected;
        private System.Windows.Forms.Label lblError;
    }
}
