using NewMethod;

namespace Rz5
{
    partial class frmChooseCompany_Big
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChooseCompany_Big));
            this.lst = new System.Windows.Forms.ListBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.optVendor = new System.Windows.Forms.RadioButton();
            this.optCustomer = new System.Windows.Forms.RadioButton();
            this.optCompany = new System.Windows.Forms.RadioButton();
            this.txtEnter = new System.Windows.Forms.TextBox();
            this.tv = new System.Windows.Forms.TreeView();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.lblCompany = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.gb = new System.Windows.Forms.GroupBox();
            this.lblNewContact = new System.Windows.Forms.LinkLabel();
            this.cboContacts = new System.Windows.Forms.ComboBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblQB = new System.Windows.Forms.Label();
            this.lblContacts = new System.Windows.Forms.Label();
            this.tmrPreview = new System.Windows.Forms.Timer(this.components);
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.FormattingEnabled = true;
            this.lst.Location = new System.Drawing.Point(3, 77);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(323, 329);
            this.lst.TabIndex = 0;
            this.lst.DoubleClick += new System.EventHandler(this.lst_DoubleClick);
            this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(86, 550);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(141, 33);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(332, 543);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(342, 45);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "&OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lbl
            // 
            this.lbl.Location = new System.Drawing.Point(5, 9);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(85, 14);
            this.lbl.TabIndex = 8;
            this.lbl.Text = "Company";
            // 
            // optVendor
            // 
            this.optVendor.AutoSize = true;
            this.optVendor.Location = new System.Drawing.Point(216, 12);
            this.optVendor.Name = "optVendor";
            this.optVendor.Size = new System.Drawing.Size(64, 17);
            this.optVendor.TabIndex = 7;
            this.optVendor.TabStop = true;
            this.optVendor.Text = "Vendors";
            this.optVendor.UseVisualStyleBackColor = true;
            this.optVendor.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optCustomer
            // 
            this.optCustomer.AutoSize = true;
            this.optCustomer.Location = new System.Drawing.Point(139, 12);
            this.optCustomer.Name = "optCustomer";
            this.optCustomer.Size = new System.Drawing.Size(74, 17);
            this.optCustomer.TabIndex = 6;
            this.optCustomer.TabStop = true;
            this.optCustomer.Text = "Customers";
            this.optCustomer.UseVisualStyleBackColor = true;
            this.optCustomer.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optCompany
            // 
            this.optCompany.AutoSize = true;
            this.optCompany.Location = new System.Drawing.Point(97, 12);
            this.optCompany.Name = "optCompany";
            this.optCompany.Size = new System.Drawing.Size(36, 17);
            this.optCompany.TabIndex = 5;
            this.optCompany.TabStop = true;
            this.optCompany.Text = "All";
            this.optCompany.UseVisualStyleBackColor = true;
            this.optCompany.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // txtEnter
            // 
            this.txtEnter.Location = new System.Drawing.Point(8, 33);
            this.txtEnter.Name = "txtEnter";
            this.txtEnter.Size = new System.Drawing.Size(318, 20);
            this.txtEnter.TabIndex = 0;
            this.txtEnter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtEnter_KeyUp);
            this.txtEnter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEnter_KeyPress);
            this.txtEnter.TextChanged += new System.EventHandler(this.txtEnter_TextChanged);
            // 
            // tv
            // 
            this.tv.ImageIndex = 0;
            this.tv.ImageList = this.il;
            this.tv.Location = new System.Drawing.Point(332, 9);
            this.tv.Name = "tv";
            this.tv.SelectedImageIndex = 0;
            this.tv.Size = new System.Drawing.Size(342, 397);
            this.tv.TabIndex = 9;
            this.tv.DoubleClick += new System.EventHandler(this.tv_DoubleClick);
            this.tv.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_NodeMouseClick);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Transparent;
            this.il.Images.SetKeyName(0, "search4files.ico");
            this.il.Images.SetKeyName(1, "folderopen.ico");
            this.il.Images.SetKeyName(2, "document.ico");
            this.il.Images.SetKeyName(3, "security.ico");
            this.il.Images.SetKeyName(4, "globe.ico");
            this.il.Images.SetKeyName(5, "newfolder.ico");
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.Location = new System.Drawing.Point(7, 57);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(78, 16);
            this.lblCompany.TabIndex = 10;
            this.lblCompany.Text = "<company>";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(286, 9);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(40, 20);
            this.cmdAdd.TabIndex = 11;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // gb
            // 
            this.gb.Controls.Add(this.lblNewContact);
            this.gb.Controls.Add(this.cboContacts);
            this.gb.Controls.Add(this.lblContact);
            this.gb.Controls.Add(this.lblQB);
            this.gb.Controls.Add(this.lblContacts);
            this.gb.Location = new System.Drawing.Point(5, 411);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(668, 126);
            this.gb.TabIndex = 12;
            this.gb.TabStop = false;
            // 
            // lblNewContact
            // 
            this.lblNewContact.AutoSize = true;
            this.lblNewContact.Location = new System.Drawing.Point(322, 14);
            this.lblNewContact.Name = "lblNewContact";
            this.lblNewContact.Size = new System.Drawing.Size(66, 13);
            this.lblNewContact.TabIndex = 5;
            this.lblNewContact.TabStop = true;
            this.lblNewContact.Text = "new contact";
            this.lblNewContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNewContact_LinkClicked);
            // 
            // cboContacts
            // 
            this.cboContacts.FormattingEnabled = true;
            this.cboContacts.Location = new System.Drawing.Point(5, 10);
            this.cboContacts.Name = "cboContacts";
            this.cboContacts.Size = new System.Drawing.Size(311, 21);
            this.cboContacts.TabIndex = 4;
            this.cboContacts.Visible = false;
            // 
            // lblContact
            // 
            this.lblContact.Location = new System.Drawing.Point(6, 34);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(415, 14);
            this.lblContact.TabIndex = 2;
            this.lblContact.Text = "<contact>";
            this.lblContact.UseMnemonic = false;
            // 
            // lblQB
            // 
            this.lblQB.Location = new System.Drawing.Point(428, 17);
            this.lblQB.Name = "lblQB";
            this.lblQB.Size = new System.Drawing.Size(232, 16);
            this.lblQB.TabIndex = 1;
            this.lblQB.Text = "<qb name>";
            this.lblQB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblQB.UseMnemonic = false;
            // 
            // lblContacts
            // 
            this.lblContacts.Location = new System.Drawing.Point(6, 48);
            this.lblContacts.Name = "lblContacts";
            this.lblContacts.Size = new System.Drawing.Size(654, 73);
            this.lblContacts.TabIndex = 0;
            this.lblContacts.Text = "<contacts>";
            this.lblContacts.UseMnemonic = false;
            // 
            // tmrPreview
            // 
            this.tmrPreview.Interval = 1000;
            this.tmrPreview.Tick += new System.EventHandler(this.tmrPreview_Tick);
            // 
            // frmChooseCompany_Big
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 591);
            this.ControlBox = false;
            this.Controls.Add(this.gb);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.tv);
            this.Controls.Add(this.txtEnter);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.optVendor);
            this.Controls.Add(this.optCustomer);
            this.Controls.Add(this.optCompany);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.lst);
            this.KeyPreview = true;
            this.Name = "frmChooseCompany_Big";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Selection";
            this.Activated += new System.EventHandler(this.frmChooseCompany_Big_Activated);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmChooseCompany_Big_KeyPress);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.RadioButton optVendor;
        private System.Windows.Forms.RadioButton optCustomer;
        private System.Windows.Forms.RadioButton optCompany;
        private System.Windows.Forms.TextBox txtEnter;
        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Timer tmrPreview;
        private System.Windows.Forms.Label lblContacts;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblQB;
        private System.Windows.Forms.ComboBox cboContacts;
        private System.Windows.Forms.LinkLabel lblNewContact;
    }
}