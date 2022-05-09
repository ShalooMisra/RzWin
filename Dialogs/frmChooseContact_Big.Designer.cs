using NewMethod;

namespace Rz5
{
    partial class frmChooseContact_Big
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
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lblContact = new System.Windows.Forms.Label();
            this.tv = new System.Windows.Forms.TreeView();
            this.txtEnter = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.gb = new System.Windows.Forms.GroupBox();
            this.lblContactSummary = new System.Windows.Forms.Label();
            this.tmrPreview = new System.Windows.Forms.Timer(this.components);
            this.lst = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(288, 5);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(40, 20);
            this.cmdAdd.TabIndex = 18;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(9, 53);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(75, 18);
            this.lblContact.TabIndex = 17;
            this.lblContact.Text = "<contact>";
            // 
            // tv
            // 
            this.tv.Location = new System.Drawing.Point(334, 5);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(342, 410);
            this.tv.TabIndex = 16;
            this.tv.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_NodeMouseClick);
            this.tv.DoubleClick += new System.EventHandler(this.tv_DoubleClick);
            // 
            // txtEnter
            // 
            this.txtEnter.Location = new System.Drawing.Point(5, 30);
            this.txtEnter.Name = "txtEnter";
            this.txtEnter.Size = new System.Drawing.Size(323, 20);
            this.txtEnter.TabIndex = 12;
            this.txtEnter.TextChanged += new System.EventHandler(this.txtEnter_TextChanged);
            this.txtEnter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEnter_KeyPress);
            this.txtEnter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtEnter_KeyUp);
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(334, 473);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(342, 45);
            this.cmdOK.TabIndex = 15;
            this.cmdOK.Text = "&OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(99, 480);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(141, 33);
            this.cmdCancel.TabIndex = 14;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(13, 6);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(51, 15);
            this.lbl.TabIndex = 19;
            this.lbl.Text = "Contact:";
            // 
            // gb
            // 
            this.gb.Controls.Add(this.lblContactSummary);
            this.gb.Location = new System.Drawing.Point(5, 424);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(668, 43);
            this.gb.TabIndex = 20;
            this.gb.TabStop = false;
            // 
            // lblContactSummary
            // 
            this.lblContactSummary.Location = new System.Drawing.Point(7, 17);
            this.lblContactSummary.Name = "lblContactSummary";
            this.lblContactSummary.Size = new System.Drawing.Size(655, 17);
            this.lblContactSummary.TabIndex = 2;
            this.lblContactSummary.Text = "<contact>";
            this.lblContactSummary.UseMnemonic = false;
            // 
            // tmrPreview
            // 
            this.tmrPreview.Interval = 1000;
            this.tmrPreview.Tick += new System.EventHandler(this.tmrPreview_Tick);
            // 
            // lst
            // 
            this.lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lst.FullRowSelect = true;
            this.lst.GridLines = true;
            this.lst.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lst.HideSelection = false;
            this.lst.Location = new System.Drawing.Point(5, 73);
            this.lst.MultiSelect = false;
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(322, 341);
            this.lst.TabIndex = 21;
            this.lst.UseCompatibleStateImageBehavior = false;
            this.lst.View = System.Windows.Forms.View.Details;
            this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
            this.lst.DoubleClick += new System.EventHandler(this.lst_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 311;
            // 
            // frmChooseContact_Big
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 524);
            this.ControlBox = false;
            this.Controls.Add(this.lst);
            this.Controls.Add(this.gb);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.tv);
            this.Controls.Add(this.txtEnter);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Name = "frmChooseContact_Big";
            this.Text = "Contact Selection";
            this.Activated += new System.EventHandler(this.frmChooseContact_Big_Activated);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmChooseContact_Big_KeyPress);
            this.gb.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.TextBox txtEnter;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Label lblContactSummary;
        private System.Windows.Forms.Timer tmrPreview;
        private System.Windows.Forms.ListView lst;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}