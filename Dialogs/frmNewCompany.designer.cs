using NewMethod;

namespace Rz5
{
    partial class frmNewCompany
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblUnique = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lst = new NewMethod.nList();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.throb = new NewMethod.nThrobber();
            this.uniqueInstructions = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.lblUnique);
            this.groupBox1.Controls.Add(this.txtCompany);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 71);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Company Name";
            // 
            // lblUnique
            // 
            this.lblUnique.Location = new System.Drawing.Point(6, 16);
            this.lblUnique.Name = "lblUnique";
            this.lblUnique.Size = new System.Drawing.Size(474, 20);
            this.lblUnique.TabIndex = 4;
            this.lblUnique.Text = "<unique>";
            this.lblUnique.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCompany
            // 
            this.txtCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompany.Location = new System.Drawing.Point(6, 39);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(476, 26);
            this.txtCompany.TabIndex = 2;
            this.txtCompany.TextChanged += new System.EventHandler(this.txtCompany_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lst);
            this.groupBox3.Location = new System.Drawing.Point(4, 152);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(502, 353);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Similar Companies";
            // 
            // lst
            // 
            this.lst.AddCaption = "Add New";
            this.lst.AllowActions = true;
            this.lst.AllowAdd = false;
            this.lst.AllowDelete = true;
            this.lst.AllowDeleteAlways = false;
            this.lst.AllowDrop = true;
            this.lst.AllowOnlyOpenDelete = false;
            this.lst.AlternateConnection = null;
            this.lst.BackColor = System.Drawing.Color.White;
            this.lst.Caption = "";
            this.lst.CurrentTemplate = null;
            this.lst.ExtraClassInfo = "";
            this.lst.Location = new System.Drawing.Point(6, 19);
            this.lst.MultiSelect = true;
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(490, 326);
            this.lst.SuppressSelectionChanged = false;
            this.lst.TabIndex = 9;
            this.lst.zz_OpenColumnMenu = false;
            this.lst.zz_OrderLineType = "";
            this.lst.zz_ShowAutoRefresh = true;
            this.lst.zz_ShowUnlimited = true;
            this.lst.FinishedFill += new NewMethod.FillHandler(this.lst_FinishedFill);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(80, 106);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(118, 40);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "&OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(293, 106);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(118, 40);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // tmr
            // 
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.White;
            this.throb.Location = new System.Drawing.Point(232, 109);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(34, 27);
            this.throb.TabIndex = 8;
            this.throb.UseParentBackColor = false;
            // 
            // uniqueInstructions
            // 
            this.uniqueInstructions.ForeColor = System.Drawing.Color.Red;
            this.uniqueInstructions.Location = new System.Drawing.Point(16, 86);
            this.uniqueInstructions.Name = "uniqueInstructions";
            this.uniqueInstructions.Size = new System.Drawing.Size(474, 20);
            this.uniqueInstructions.TabIndex = 5;
            this.uniqueInstructions.Text = "To make a company name unique, add the email domain in [square brackets] after th" +
    "e name.";
            this.uniqueInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uniqueInstructions.Visible = false;
            // 
            // frmNewCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(508, 509);
            this.ControlBox = false;
            this.Controls.Add(this.uniqueInstructions);
            this.Controls.Add(this.throb);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmNewCompany";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Company";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private nList lst;
        private System.Windows.Forms.Label lblUnique;
        private System.Windows.Forms.Timer tmr;
        private nThrobber throb;
        private System.Windows.Forms.Label uniqueInstructions;
    }
}