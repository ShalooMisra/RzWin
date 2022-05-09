namespace TieServerTest
{
    partial class frmTieTest
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
                try
                {
                    if (CurrentEye != null)
                    {
                        if( CurrentEye.CurrentState == Tie.EyeState.Watching )
                            CurrentEye.StopListening(false);
                    }

                    if (h1.CurrentHook != null)
                        h1.CurrentHook.Close();

                }
                catch { }
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
            this.h1 = new Tie.HookView();
            this.gb = new System.Windows.Forms.GroupBox();
            this.chkManager = new System.Windows.Forms.CheckBox();
            this.cmdCheckKnotUpdate = new System.Windows.Forms.Button();
            this.cmdPersistentKnot = new System.Windows.Forms.Button();
            this.cmdKnot = new System.Windows.Forms.Button();
            this.num = new System.Windows.Forms.NumericUpDown();
            this.cmdAddClients = new System.Windows.Forms.Button();
            this.lblMike = new System.Windows.Forms.LinkLabel();
            this.lblLocal = new System.Windows.Forms.LinkLabel();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.lvClients = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.eye = new Tie.EyeView();
            this.gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num)).BeginInit();
            this.SuspendLayout();
            // 
            // h1
            // 
            this.h1.Location = new System.Drawing.Point(12, 278);
            this.h1.Name = "h1";
            this.h1.Size = new System.Drawing.Size(658, 451);
            this.h1.TabIndex = 1;
            // 
            // gb
            // 
            this.gb.Controls.Add(this.chkManager);
            this.gb.Controls.Add(this.cmdCheckKnotUpdate);
            this.gb.Controls.Add(this.cmdPersistentKnot);
            this.gb.Controls.Add(this.cmdKnot);
            this.gb.Controls.Add(this.num);
            this.gb.Controls.Add(this.cmdAddClients);
            this.gb.Controls.Add(this.lblMike);
            this.gb.Controls.Add(this.lblLocal);
            this.gb.Controls.Add(this.txtServer);
            this.gb.Controls.Add(this.cmdConnect);
            this.gb.Location = new System.Drawing.Point(12, 216);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(807, 56);
            this.gb.TabIndex = 3;
            this.gb.TabStop = false;
            // 
            // chkManager
            // 
            this.chkManager.AutoSize = true;
            this.chkManager.Location = new System.Drawing.Point(332, 26);
            this.chkManager.Name = "chkManager";
            this.chkManager.Size = new System.Drawing.Size(35, 17);
            this.chkManager.TabIndex = 9;
            this.chkManager.Text = "M";
            this.chkManager.UseVisualStyleBackColor = true;
            // 
            // cmdCheckKnotUpdate
            // 
            this.cmdCheckKnotUpdate.Location = new System.Drawing.Point(558, 15);
            this.cmdCheckKnotUpdate.Name = "cmdCheckKnotUpdate";
            this.cmdCheckKnotUpdate.Size = new System.Drawing.Size(77, 35);
            this.cmdCheckKnotUpdate.TabIndex = 8;
            this.cmdCheckKnotUpdate.Text = "Check Update";
            this.cmdCheckKnotUpdate.UseVisualStyleBackColor = true;
            this.cmdCheckKnotUpdate.Click += new System.EventHandler(this.cmdCheckKnotUpdate_Click);
            // 
            // cmdPersistentKnot
            // 
            this.cmdPersistentKnot.Location = new System.Drawing.Point(463, 15);
            this.cmdPersistentKnot.Name = "cmdPersistentKnot";
            this.cmdPersistentKnot.Size = new System.Drawing.Size(89, 35);
            this.cmdPersistentKnot.TabIndex = 7;
            this.cmdPersistentKnot.Text = "Persistent Knot";
            this.cmdPersistentKnot.UseVisualStyleBackColor = true;
            this.cmdPersistentKnot.Click += new System.EventHandler(this.cmdPersistentKnot_Click);
            // 
            // cmdKnot
            // 
            this.cmdKnot.Location = new System.Drawing.Point(368, 15);
            this.cmdKnot.Name = "cmdKnot";
            this.cmdKnot.Size = new System.Drawing.Size(89, 35);
            this.cmdKnot.TabIndex = 6;
            this.cmdKnot.Text = "Run One Knot";
            this.cmdKnot.UseVisualStyleBackColor = true;
            this.cmdKnot.Click += new System.EventHandler(this.cmdKnot_Click);
            // 
            // num
            // 
            this.num.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num.Location = new System.Drawing.Point(754, 21);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(47, 20);
            this.num.TabIndex = 5;
            this.num.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // cmdAddClients
            // 
            this.cmdAddClients.Location = new System.Drawing.Point(646, 18);
            this.cmdAddClients.Name = "cmdAddClients";
            this.cmdAddClients.Size = new System.Drawing.Size(102, 29);
            this.cmdAddClients.TabIndex = 4;
            this.cmdAddClients.Text = "Add Clients";
            this.cmdAddClients.UseVisualStyleBackColor = true;
            this.cmdAddClients.Click += new System.EventHandler(this.cmdAddClients_Click);
            // 
            // lblMike
            // 
            this.lblMike.AutoSize = true;
            this.lblMike.Location = new System.Drawing.Point(43, 40);
            this.lblMike.Name = "lblMike";
            this.lblMike.Size = new System.Drawing.Size(96, 13);
            this.lblMike.TabIndex = 3;
            this.lblMike.TabStop = true;
            this.lblMike.Text = "mike.recognin.com";
            this.lblMike.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblMike_LinkClicked);
            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.Location = new System.Drawing.Point(8, 41);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(29, 13);
            this.lblLocal.TabIndex = 2;
            this.lblLocal.TabStop = true;
            this.lblLocal.Text = "local";
            this.lblLocal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLocal_LinkClicked);
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(8, 19);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(189, 20);
            this.txtServer.TabIndex = 1;
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(203, 15);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(124, 35);
            this.cmdConnect.TabIndex = 0;
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // lvClients
            // 
            this.lvClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvClients.Location = new System.Drawing.Point(825, 10);
            this.lvClients.Name = "lvClients";
            this.lvClients.Size = new System.Drawing.Size(275, 533);
            this.lvClients.TabIndex = 4;
            this.lvClients.UseCompatibleStateImageBehavior = false;
            this.lvClients.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Session";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Application";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Reconnects";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status";
            this.columnHeader4.Width = 78;
            // 
            // tmr
            // 
            this.tmr.Interval = 5000;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // eye
            // 
            this.eye.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.eye.Location = new System.Drawing.Point(12, 12);
            this.eye.Name = "eye";
            this.eye.Size = new System.Drawing.Size(807, 198);
            this.eye.TabIndex = 5;
            this.eye.Load += new System.EventHandler(this.eye_Load);
            // 
            // frmTieTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 762);
            this.Controls.Add(this.eye);
            this.Controls.Add(this.lvClients);
            this.Controls.Add(this.gb);
            this.Controls.Add(this.h1);
            this.Name = "frmTieTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tie Test v2";
            this.Resize += new System.EventHandler(this.frmTieTest_Resize);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Tie.HookView h1;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.LinkLabel lblMike;
        private System.Windows.Forms.LinkLabel lblLocal;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.NumericUpDown num;
        private System.Windows.Forms.Button cmdAddClients;
        private System.Windows.Forms.ListView lvClients;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private Tie.EyeView eye;
        private System.Windows.Forms.Button cmdKnot;
        private System.Windows.Forms.Button cmdPersistentKnot;
        private System.Windows.Forms.Button cmdCheckKnotUpdate;
        private System.Windows.Forms.CheckBox chkManager;
    }
}

