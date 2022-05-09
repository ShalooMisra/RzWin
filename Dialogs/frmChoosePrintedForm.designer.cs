namespace Rz5
{
    partial class frmChoosePrintedForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChoosePrintedForm));
            this.lv = new NewMethod.nList();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.AddCaption = "Add New";
            this.lv.AllowActions = true;
            this.lv.AllowAdd = false;
            this.lv.AllowDelete = true;
            this.lv.AllowDeleteAlways = false;
            this.lv.AllowDrop = true;
            this.lv.AlternateConnection = null;
            this.lv.Caption = "";
            this.lv.CurrentTemplate = null;
            this.lv.ExtraClassInfo = "";
            this.lv.Location = new System.Drawing.Point(12, 34);
            this.lv.MultiSelect = true;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(295, 197);
            this.lv.SuppressSelectionChanged = false;
            this.lv.TabIndex = 20;
            this.lv.zz_OpenColumnMenu = false;
            this.lv.zz_OrderLineType = "";
            this.lv.zz_ShowAutoRefresh = true;
            this.lv.zz_ShowUnlimited = true;
            // 
            // cmdAccept
            // 
            this.cmdAccept.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAccept.Location = new System.Drawing.Point(163, 237);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(144, 28);
            this.cmdAccept.TabIndex = 21;
            this.cmdAccept.Text = "Accept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(295, 23);
            this.label2.TabIndex = 22;
            this.label2.Text = "Choose A Form To Attach As PDF";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(12, 237);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(144, 28);
            this.cmdCancel.TabIndex = 23;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmChoosePrintedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 271);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.lv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmChoosePrintedForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose Printed Form";
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nList lv;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdCancel;
    }
}