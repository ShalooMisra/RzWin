namespace NewMethod
{
    partial class ActivityReport
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
            this.lstUsers = new System.Windows.Forms.CheckedListBox();
            this.lblUsers = new System.Windows.Forms.Label();
            this.lblMachines = new System.Windows.Forms.Label();
            this.txtMachines = new System.Windows.Forms.TextBox();
            this.cmdGo = new System.Windows.Forms.Button();
            this.lstClasses = new System.Windows.Forms.CheckedListBox();
            this.lblClasses = new System.Windows.Forms.Label();
            this.chkRecall = new System.Windows.Forms.CheckBox();
            this.wb = new ToolsWin.Browser();
            this.end = new NewMethod.nEdit_Date();
            this.start = new NewMethod.nEdit_Date();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstUsers
            // 
            this.lstUsers.CheckOnClick = true;
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.Location = new System.Drawing.Point(3, 266);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(206, 184);
            this.lstUsers.TabIndex = 0;
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Location = new System.Drawing.Point(3, 250);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(34, 13);
            this.lblUsers.TabIndex = 1;
            this.lblUsers.Text = "Users";
            // 
            // lblMachines
            // 
            this.lblMachines.AutoSize = true;
            this.lblMachines.Location = new System.Drawing.Point(3, 453);
            this.lblMachines.Name = "lblMachines";
            this.lblMachines.Size = new System.Drawing.Size(53, 13);
            this.lblMachines.TabIndex = 2;
            this.lblMachines.Text = "Machines";
            // 
            // txtMachines
            // 
            this.txtMachines.Location = new System.Drawing.Point(3, 469);
            this.txtMachines.Multiline = true;
            this.txtMachines.Name = "txtMachines";
            this.txtMachines.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMachines.Size = new System.Drawing.Size(206, 192);
            this.txtMachines.TabIndex = 3;
            // 
            // cmdGo
            // 
            this.cmdGo.Location = new System.Drawing.Point(6, 5);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(203, 31);
            this.cmdGo.TabIndex = 6;
            this.cmdGo.Text = "View Activity";
            this.cmdGo.UseVisualStyleBackColor = true;
            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // lstClasses
            // 
            this.lstClasses.CheckOnClick = true;
            this.lstClasses.FormattingEnabled = true;
            this.lstClasses.Location = new System.Drawing.Point(3, 168);
            this.lstClasses.Name = "lstClasses";
            this.lstClasses.Size = new System.Drawing.Size(206, 79);
            this.lstClasses.TabIndex = 8;
            // 
            // lblClasses
            // 
            this.lblClasses.AutoSize = true;
            this.lblClasses.Location = new System.Drawing.Point(0, 146);
            this.lblClasses.Name = "lblClasses";
            this.lblClasses.Size = new System.Drawing.Size(43, 13);
            this.lblClasses.TabIndex = 9;
            this.lblClasses.Text = "Classes";
            // 
            // chkRecall
            // 
            this.chkRecall.AutoSize = true;
            this.chkRecall.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRecall.Location = new System.Drawing.Point(115, 142);
            this.chkRecall.Name = "chkRecall";
            this.chkRecall.Size = new System.Drawing.Size(94, 17);
            this.chkRecall.TabIndex = 10;
            this.chkRecall.Text = "Include Recall";
            this.chkRecall.UseVisualStyleBackColor = true;
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(215, 5);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(601, 656);
            this.wb.TabIndex = 7;
            // 
            // end
            // 
            this.end.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.end.Bold = false;
            this.end.Caption = "End";
            this.end.Changed = false;
            this.end.Location = new System.Drawing.Point(6, 92);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(119, 44);
            this.end.SuppressEdit = false;
            this.end.TabIndex = 5;
            this.end.UseParentBackColor = false;
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.start.Bold = false;
            this.start.Caption = "Start";
            this.start.Changed = false;
            this.start.Location = new System.Drawing.Point(6, 42);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(119, 44);
            this.start.SuppressEdit = false;
            this.start.TabIndex = 4;
            this.start.UseParentBackColor = false;
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(126, 61);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(73, 20);
            this.txtStartTime.TabIndex = 11;
            this.txtStartTime.Text = "12:00 AM";
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(126, 116);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(73, 20);
            this.txtEndTime.TabIndex = 12;
            this.txtEndTime.Text = "12:00:00 AM";
            // 
            // ActivityReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtEndTime);
            this.Controls.Add(this.txtStartTime);
            this.Controls.Add(this.chkRecall);
            this.Controls.Add(this.lblClasses);
            this.Controls.Add(this.lstClasses);
            this.Controls.Add(this.wb);
            this.Controls.Add(this.cmdGo);
            this.Controls.Add(this.end);
            this.Controls.Add(this.start);
            this.Controls.Add(this.txtMachines);
            this.Controls.Add(this.lblMachines);
            this.Controls.Add(this.lblUsers);
            this.Controls.Add(this.lstUsers);
            this.Name = "ActivityReport";
            this.Size = new System.Drawing.Size(819, 666);
            this.Resize += new System.EventHandler(this.ActivityReport_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lstUsers;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.Label lblMachines;
        private System.Windows.Forms.TextBox txtMachines;
        private nEdit_Date start;
        private nEdit_Date end;
        private System.Windows.Forms.Button cmdGo;
        private ToolsWin.Browser wb;
        private System.Windows.Forms.CheckedListBox lstClasses;
        private System.Windows.Forms.Label lblClasses;
        private System.Windows.Forms.CheckBox chkRecall;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.TextBox txtEndTime;
    }
}
