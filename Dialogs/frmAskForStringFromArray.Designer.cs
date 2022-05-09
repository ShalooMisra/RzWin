namespace RzInterfaceWin.Dialogs
{
    partial class frmAskForStringFromArray
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAskForStringFromArray));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.ctlList = new NewMethod.nEdit_List();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(353, 71);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(116, 36);
            this.cmdCancel.TabIndex = 0;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(475, 71);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(116, 36);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // ctlList
            // 
            this.ctlList.AllCaps = false;
            this.ctlList.AllowEdit = false;
            this.ctlList.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlList.Bold = false;
            this.ctlList.Caption = "<caption>";
            this.ctlList.Changed = false;
            this.ctlList.ListName = null;
            this.ctlList.Location = new System.Drawing.Point(7, 5);
            this.ctlList.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctlList.Name = "ctlList";
            this.ctlList.SimpleList = null;
            this.ctlList.Size = new System.Drawing.Size(584, 58);
            this.ctlList.TabIndex = 4;
            this.ctlList.UseParentBackColor = false;
            this.ctlList.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctlList.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlList.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlList.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlList.zz_LabelFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlList.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctlList.zz_OriginalDesign = false;
            this.ctlList.zz_ShowNeedsSaveColor = true;
            this.ctlList.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlList.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlList.zz_UseGlobalColor = false;
            this.ctlList.zz_UseGlobalFont = false;
            // 
            // frmAskForStringFromArray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 113);
            this.Controls.Add(this.ctlList);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAskForStringFromArray";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Text";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private NewMethod.nEdit_List ctlList;
    }
}