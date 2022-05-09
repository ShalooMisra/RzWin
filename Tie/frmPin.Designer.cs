namespace TiePin
{
    partial class frmPin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPin));
            this.hv = new Tie.HookView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDutyLogFile = new System.Windows.Forms.Label();
            this.tabTie = new System.Windows.Forms.TabControl();
            this.pageStatus = new System.Windows.Forms.TabPage();
            this.pageDuties = new System.Windows.Forms.TabPage();
            this.cmdTestBackUpPatch = new System.Windows.Forms.Button();
            this.tabTie.SuspendLayout();
            this.pageStatus.SuspendLayout();
            this.pageDuties.SuspendLayout();
            this.SuspendLayout();
            // 
            // hv
            // 
            this.hv.Location = new System.Drawing.Point(3, 3);
            this.hv.Name = "hv";
            this.hv.Size = new System.Drawing.Size(654, 448);
            this.hv.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Log File:";
            // 
            // lblDutyLogFile
            // 
            this.lblDutyLogFile.AutoSize = true;
            this.lblDutyLogFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDutyLogFile.Location = new System.Drawing.Point(6, 26);
            this.lblDutyLogFile.Name = "lblDutyLogFile";
            this.lblDutyLogFile.Size = new System.Drawing.Size(116, 20);
            this.lblDutyLogFile.TabIndex = 2;
            this.lblDutyLogFile.Text = "<log file name>";
            // 
            // tabTie
            // 
            this.tabTie.Controls.Add(this.pageStatus);
            this.tabTie.Controls.Add(this.pageDuties);
            this.tabTie.Location = new System.Drawing.Point(2, 4);
            this.tabTie.Name = "tabTie";
            this.tabTie.SelectedIndex = 0;
            this.tabTie.Size = new System.Drawing.Size(673, 488);
            this.tabTie.TabIndex = 3;
            // 
            // pageStatus
            // 
            this.pageStatus.Controls.Add(this.hv);
            this.pageStatus.Location = new System.Drawing.Point(4, 22);
            this.pageStatus.Name = "pageStatus";
            this.pageStatus.Padding = new System.Windows.Forms.Padding(3);
            this.pageStatus.Size = new System.Drawing.Size(665, 462);
            this.pageStatus.TabIndex = 0;
            this.pageStatus.Text = "Status";
            this.pageStatus.UseVisualStyleBackColor = true;
            // 
            // pageDuties
            // 
            this.pageDuties.Controls.Add(this.cmdTestBackUpPatch);
            this.pageDuties.Controls.Add(this.label1);
            this.pageDuties.Controls.Add(this.lblDutyLogFile);
            this.pageDuties.Location = new System.Drawing.Point(4, 22);
            this.pageDuties.Name = "pageDuties";
            this.pageDuties.Padding = new System.Windows.Forms.Padding(3);
            this.pageDuties.Size = new System.Drawing.Size(665, 462);
            this.pageDuties.TabIndex = 1;
            this.pageDuties.Text = "Duties";
            this.pageDuties.UseVisualStyleBackColor = true;
            // 
            // cmdTestBackUpPatch
            // 
            this.cmdTestBackUpPatch.Location = new System.Drawing.Point(10, 89);
            this.cmdTestBackUpPatch.Name = "cmdTestBackUpPatch";
            this.cmdTestBackUpPatch.Size = new System.Drawing.Size(229, 23);
            this.cmdTestBackUpPatch.TabIndex = 3;
            this.cmdTestBackUpPatch.Text = "Test BackUp Patch";
            this.cmdTestBackUpPatch.UseVisualStyleBackColor = true;
            this.cmdTestBackUpPatch.Click += new System.EventHandler(this.cmdTestBackUpPatch_Click);
            // 
            // frmPin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 496);
            this.Controls.Add(this.tabTie);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPin";
            this.Text = "Pin View";
            this.tabTie.ResumeLayout(false);
            this.pageStatus.ResumeLayout(false);
            this.pageDuties.ResumeLayout(false);
            this.pageDuties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Tie.HookView hv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDutyLogFile;
        private System.Windows.Forms.TabControl tabTie;
        private System.Windows.Forms.TabPage pageStatus;
        private System.Windows.Forms.TabPage pageDuties;
        private System.Windows.Forms.Button cmdTestBackUpPatch;
    }
}