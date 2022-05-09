namespace TieManager
{
    partial class frmTieManager
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
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.cmdUpdateTie = new System.Windows.Forms.Button();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.txt = new Tie.nEndlessStatusBox();
            this.gb = new System.Windows.Forms.GroupBox();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.lblLiveVersion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentSite = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lv.FullRowSelect = true;
            this.lv.Location = new System.Drawing.Point(4, 73);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(389, 215);
            this.lv.TabIndex = 0;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File";
            this.columnHeader1.Width = 142;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 82;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Version";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 53;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Folder";
            this.columnHeader4.Width = 258;
            // 
            // cmdUpdateTie
            // 
            this.cmdUpdateTie.Location = new System.Drawing.Point(2, 286);
            this.cmdUpdateTie.Name = "cmdUpdateTie";
            this.cmdUpdateTie.Size = new System.Drawing.Size(391, 61);
            this.cmdUpdateTie.TabIndex = 1;
            this.cmdUpdateTie.Text = "Update www.newmethodsoftware.com/tie.*";
            this.cmdUpdateTie.UseVisualStyleBackColor = true;
            this.cmdUpdateTie.Click += new System.EventHandler(this.cmdUpdateTie_Click);
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(399, 319);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(381, 26);
            this.pb.TabIndex = 3;
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(399, 73);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(381, 245);
            this.txt.TabIndex = 2;
            this.txt.Text = "";
            // 
            // gb
            // 
            this.gb.Controls.Add(this.cmdRefresh);
            this.gb.Controls.Add(this.lblLiveVersion);
            this.gb.Controls.Add(this.label3);
            this.gb.Controls.Add(this.lblCurrentSite);
            this.gb.Controls.Add(this.label1);
            this.gb.Location = new System.Drawing.Point(4, 2);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(768, 65);
            this.gb.TabIndex = 4;
            this.gb.TabStop = false;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(609, 10);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(153, 49);
            this.cmdRefresh.TabIndex = 4;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // lblLiveVersion
            // 
            this.lblLiveVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLiveVersion.Location = new System.Drawing.Point(8, 29);
            this.lblLiveVersion.Name = "lblLiveVersion";
            this.lblLiveVersion.Size = new System.Drawing.Size(100, 33);
            this.lblLiveVersion.TabIndex = 3;
            this.lblLiveVersion.Text = "1112";
            this.lblLiveVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Live Version:";
            // 
            // lblCurrentSite
            // 
            this.lblCurrentSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentSite.Location = new System.Drawing.Point(132, 29);
            this.lblCurrentSite.Name = "lblCurrentSite";
            this.lblCurrentSite.Size = new System.Drawing.Size(100, 33);
            this.lblCurrentSite.TabIndex = 1;
            this.lblCurrentSite.Text = "1111";
            this.lblCurrentSite.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Site Version:";
            // 
            // frmTieManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 351);
            this.Controls.Add(this.gb);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.cmdUpdateTie);
            this.Controls.Add(this.lv);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTieManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tie Manager";
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button cmdUpdateTie;
        private Tie.nEndlessStatusBox txt;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Label lblLiveVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCurrentSite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdRefresh;
    }
}

