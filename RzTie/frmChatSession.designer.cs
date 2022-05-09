using NewMethod;

namespace Rz5
{
    partial class frmChatSession
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChatSession));
            this.txtSend = new System.Windows.Forms.RichTextBox();
            this.cmdSend = new System.Windows.Forms.Button();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.lvSessions = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdChatWithSomeone = new System.Windows.Forms.Button();
            this.pBrowser = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(270, 422);
            this.txtSend.Name = "txtSend";
            this.txtSend.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txtSend.Size = new System.Drawing.Size(524, 96);
            this.txtSend.TabIndex = 0;
            this.txtSend.Text = "";
            this.txtSend.WordWrap = false;
            this.txtSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSend_KeyPress);
            // 
            // cmdSend
            // 
            this.cmdSend.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdSend.ImageKey = "chat";
            this.cmdSend.ImageList = this.il;
            this.cmdSend.Location = new System.Drawing.Point(800, 422);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(82, 96);
            this.cmdSend.TabIndex = 2;
            this.cmdSend.Text = "Send";
            this.cmdSend.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdSend.UseVisualStyleBackColor = true;
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Magenta;
            this.il.Images.SetKeyName(0, "chat");
            // 
            // lvSessions
            // 
            this.lvSessions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvSessions.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvSessions.FullRowSelect = true;
            this.lvSessions.Location = new System.Drawing.Point(3, 4);
            this.lvSessions.Name = "lvSessions";
            this.lvSessions.Size = new System.Drawing.Size(256, 583);
            this.lvSessions.TabIndex = 4;
            this.lvSessions.UseCompatibleStateImageBehavior = false;
            this.lvSessions.View = System.Windows.Forms.View.Details;
            this.lvSessions.Click += new System.EventHandler(this.lvSessions_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 153;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Machine";
            this.columnHeader2.Width = 94;
            // 
            // cmdChatWithSomeone
            // 
            this.cmdChatWithSomeone.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdChatWithSomeone.Location = new System.Drawing.Point(2, 593);
            this.cmdChatWithSomeone.Name = "cmdChatWithSomeone";
            this.cmdChatWithSomeone.Size = new System.Drawing.Size(257, 29);
            this.cmdChatWithSomeone.TabIndex = 5;
            this.cmdChatWithSomeone.Text = "Chat";
            this.cmdChatWithSomeone.UseVisualStyleBackColor = true;
            this.cmdChatWithSomeone.Click += new System.EventHandler(this.cmdChatWithSomeone_Click);
            // 
            // pBrowser
            // 
            this.pBrowser.Location = new System.Drawing.Point(265, 6);
            this.pBrowser.Name = "pBrowser";
            this.pBrowser.Size = new System.Drawing.Size(616, 402);
            this.pBrowser.TabIndex = 6;
            // 
            // frmChatSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 663);
            this.Controls.Add(this.pBrowser);
            this.Controls.Add(this.cmdChatWithSomeone);
            this.Controls.Add(this.lvSessions);
            this.Controls.Add(this.cmdSend);
            this.Controls.Add(this.txtSend);
            this.Name = "frmChatSession";
            this.Text = "Chat Session";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChatSession_FormClosing);
            this.Resize += new System.EventHandler(this.frmChatSession_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        protected System.Windows.Forms.RichTextBox txtSend;
        protected System.Windows.Forms.Button cmdSend;
        protected System.Windows.Forms.ListView lvSessions;
        protected System.Windows.Forms.Button cmdChatWithSomeone;
        protected System.Windows.Forms.Panel pBrowser;
    }
}