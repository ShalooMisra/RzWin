namespace Rz5.Focus
{
    partial class FocusPanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FocusPanel));
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.lblData = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.pCompany = new System.Windows.Forms.Panel();
            this.lblChat = new System.Windows.Forms.LinkLabel();
            this.lblProfile = new System.Windows.Forms.Label();
            this.pData = new System.Windows.Forms.Panel();
            this.lblViewInbox = new System.Windows.Forms.LinkLabel();
            this.picItems = new System.Windows.Forms.PictureBox();
            this.picInbox = new System.Windows.Forms.PictureBox();
            this.picCompany = new System.Windows.Forms.PictureBox();
            this.picData = new System.Windows.Forms.PictureBox();
            this.picChat = new System.Windows.Forms.PictureBox();
            this.tmrChat = new System.Windows.Forms.Timer(this.components);
            this.picExtra = new System.Windows.Forms.PictureBox();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.lblStamp = new System.Windows.Forms.Label();
            this.pCompany.SuspendLayout();
            this.pData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExtra)).BeginInit();
            this.SuspendLayout();
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Magenta;
            this.il.Images.SetKeyName(0, "connected");
            this.il.Images.SetKeyName(1, "disconnected");
            this.il.Images.SetKeyName(2, "company_connected");
            this.il.Images.SetKeyName(3, "company_disconnected");
            this.il.Images.SetKeyName(4, "help");
            // 
            // lblData
            // 
            this.lblData.Location = new System.Drawing.Point(32, 2);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(206, 32);
            this.lblData.TabIndex = 1;
            this.lblData.Text = "<data status>";
            // 
            // lblCompany
            // 
            this.lblCompany.Location = new System.Drawing.Point(268, 1);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(149, 25);
            this.lblCompany.TabIndex = 3;
            this.lblCompany.Text = "<company status>";
            // 
            // pCompany
            // 
            this.pCompany.Controls.Add(this.lblChat);
            this.pCompany.Location = new System.Drawing.Point(275, 15);
            this.pCompany.Name = "pCompany";
            this.pCompany.Size = new System.Drawing.Size(175, 16);
            this.pCompany.TabIndex = 4;
            // 
            // lblChat
            // 
            this.lblChat.AutoSize = true;
            this.lblChat.Location = new System.Drawing.Point(4, 2);
            this.lblChat.Name = "lblChat";
            this.lblChat.Size = new System.Drawing.Size(28, 13);
            this.lblChat.TabIndex = 0;
            this.lblChat.TabStop = true;
            this.lblChat.Text = "chat";
            this.lblChat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChat_LinkClicked);
            // 
            // lblProfile
            // 
            this.lblProfile.AutoSize = true;
            this.lblProfile.Location = new System.Drawing.Point(3, 2);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(47, 13);
            this.lblProfile.TabIndex = 5;
            this.lblProfile.Text = "<profile>";
            // 
            // pData
            // 
            this.pData.Controls.Add(this.lblProfile);
            this.pData.Location = new System.Drawing.Point(458, 0);
            this.pData.Name = "pData";
            this.pData.Size = new System.Drawing.Size(248, 38);
            this.pData.TabIndex = 7;
            // 
            // lblViewInbox
            // 
            this.lblViewInbox.AutoSize = true;
            this.lblViewInbox.Location = new System.Drawing.Point(919, 6);
            this.lblViewInbox.Name = "lblViewInbox";
            this.lblViewInbox.Size = new System.Drawing.Size(84, 13);
            this.lblViewInbox.TabIndex = 10;
            this.lblViewInbox.TabStop = true;
            this.lblViewInbox.Text = "view inbox items";
            this.lblViewInbox.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblViewInbox_LinkClicked);
            // 
            // picItems
            // 
            this.picItems.BackColor = System.Drawing.Color.Blue;
            this.picItems.Location = new System.Drawing.Point(1035, 4);
            this.picItems.Name = "picItems";
            this.picItems.Size = new System.Drawing.Size(10, 22);
            this.picItems.TabIndex = 11;
            this.picItems.TabStop = false;
            // 
            // picInbox
            // 
            this.picInbox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picInbox.BackgroundImage")));
            this.picInbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picInbox.Location = new System.Drawing.Point(1006, 2);
            this.picInbox.Name = "picInbox";
            this.picInbox.Size = new System.Drawing.Size(74, 32);
            this.picInbox.TabIndex = 8;
            this.picInbox.TabStop = false;
            this.picInbox.Click += new System.EventHandler(this.picInbox_Click);
            // 
            // picCompany
            // 
            this.picCompany.Location = new System.Drawing.Point(244, 5);
            this.picCompany.Name = "picCompany";
            this.picCompany.Size = new System.Drawing.Size(24, 24);
            this.picCompany.TabIndex = 2;
            this.picCompany.TabStop = false;
            // 
            // picData
            // 
            this.picData.Location = new System.Drawing.Point(4, 5);
            this.picData.Name = "picData";
            this.picData.Size = new System.Drawing.Size(24, 24);
            this.picData.TabIndex = 0;
            this.picData.TabStop = false;
            // 
            // picChat
            // 
            this.picChat.BackgroundImage = global::RzInterfaceWin.Properties.Resources.chat1;
            this.picChat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picChat.Location = new System.Drawing.Point(869, 1);
            this.picChat.Name = "picChat";
            this.picChat.Size = new System.Drawing.Size(42, 33);
            this.picChat.TabIndex = 12;
            this.picChat.TabStop = false;
            this.picChat.Visible = false;
            // 
            // tmrChat
            // 
            this.tmrChat.Tick += new System.EventHandler(this.tmrChat_Tick);
            // 
            // picExtra
            // 
            this.picExtra.Location = new System.Drawing.Point(729, 5);
            this.picExtra.Name = "picExtra";
            this.picExtra.Size = new System.Drawing.Size(24, 24);
            this.picExtra.TabIndex = 13;
            this.picExtra.TabStop = false;
            // 
            // lblStamp
            // 
            this.lblStamp.AutoSize = true;
            this.lblStamp.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStamp.Location = new System.Drawing.Point(756, 0);
            this.lblStamp.Name = "lblStamp";
            this.lblStamp.Size = new System.Drawing.Size(110, 33);
            this.lblStamp.TabIndex = 14;
            this.lblStamp.Text = "<stamp>";
            // 
            // FocusPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblStamp);
            this.Controls.Add(this.picExtra);
            this.Controls.Add(this.picChat);
            this.Controls.Add(this.picItems);
            this.Controls.Add(this.lblViewInbox);
            this.Controls.Add(this.picInbox);
            this.Controls.Add(this.pData);
            this.Controls.Add(this.pCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.picCompany);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.picData);
            this.Name = "FocusPanel";
            this.Size = new System.Drawing.Size(1136, 38);
            this.Resize += new System.EventHandler(this.FocusPanel_Resize);
            this.pCompany.ResumeLayout(false);
            this.pCompany.PerformLayout();
            this.pData.ResumeLayout(false);
            this.pData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExtra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.PictureBox picData;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.PictureBox picCompany;
        private System.Windows.Forms.Panel pCompany;
        private System.Windows.Forms.Label lblProfile;
        private System.Windows.Forms.LinkLabel lblChat;
        private System.Windows.Forms.Panel pData;
        private System.Windows.Forms.PictureBox picInbox;
        private System.Windows.Forms.LinkLabel lblViewInbox;
        private System.Windows.Forms.PictureBox picItems;
        private System.Windows.Forms.PictureBox picChat;
        private System.Windows.Forms.Timer tmrChat;
        private System.Windows.Forms.PictureBox picExtra;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.Label lblStamp;
    }
}
