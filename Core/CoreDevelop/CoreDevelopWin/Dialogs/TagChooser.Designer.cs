namespace CoreDevelopWin.Dialogs
{
    partial class TagChooser
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
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pNew = new System.Windows.Forms.Panel();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdChooseCode = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdChooseSln = new System.Windows.Forms.Button();
            this.txtSln = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdChooseDll = new System.Windows.Forms.Button();
            this.txtDll = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pContents.SuspendLayout();
            this.pNew.SuspendLayout();
            this.SuspendLayout();
            // 
            // pContents
            // 
            this.pContents.Controls.Add(this.pNew);
            this.pContents.Controls.Add(this.lv);
            this.pContents.Location = new System.Drawing.Point(0, 0);
            this.pContents.Size = new System.Drawing.Size(872, 504);
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lv.FullRowSelect = true;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(3, 123);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(866, 375);
            this.lv.TabIndex = 0;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Dll";
            this.columnHeader2.Width = 131;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Sln";
            this.columnHeader3.Width = 210;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Code";
            this.columnHeader4.Width = 214;
            // 
            // pNew
            // 
            this.pNew.Controls.Add(this.cmdAdd);
            this.pNew.Controls.Add(this.cmdChooseCode);
            this.pNew.Controls.Add(this.txtCode);
            this.pNew.Controls.Add(this.label3);
            this.pNew.Controls.Add(this.cmdChooseSln);
            this.pNew.Controls.Add(this.txtSln);
            this.pNew.Controls.Add(this.label2);
            this.pNew.Controls.Add(this.cmdChooseDll);
            this.pNew.Controls.Add(this.txtDll);
            this.pNew.Controls.Add(this.label1);
            this.pNew.Location = new System.Drawing.Point(12, 12);
            this.pNew.Name = "pNew";
            this.pNew.Size = new System.Drawing.Size(848, 105);
            this.pNew.TabIndex = 3;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(688, 6);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(157, 96);
            this.cmdAdd.TabIndex = 9;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdChooseCode
            // 
            this.cmdChooseCode.Location = new System.Drawing.Point(650, 73);
            this.cmdChooseCode.Name = "cmdChooseCode";
            this.cmdChooseCode.Size = new System.Drawing.Size(32, 22);
            this.cmdChooseCode.TabIndex = 8;
            this.cmdChooseCode.Text = "...";
            this.cmdChooseCode.UseVisualStyleBackColor = true;
            this.cmdChooseCode.Click += new System.EventHandler(this.cmdChooseCode_Click);
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(62, 73);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(582, 26);
            this.txtCode.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Code:";
            // 
            // cmdChooseSln
            // 
            this.cmdChooseSln.Location = new System.Drawing.Point(650, 41);
            this.cmdChooseSln.Name = "cmdChooseSln";
            this.cmdChooseSln.Size = new System.Drawing.Size(32, 22);
            this.cmdChooseSln.TabIndex = 5;
            this.cmdChooseSln.Text = "...";
            this.cmdChooseSln.UseVisualStyleBackColor = true;
            this.cmdChooseSln.Click += new System.EventHandler(this.cmdChooseSln_Click);
            // 
            // txtSln
            // 
            this.txtSln.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSln.Location = new System.Drawing.Point(62, 41);
            this.txtSln.Name = "txtSln";
            this.txtSln.Size = new System.Drawing.Size(582, 26);
            this.txtSln.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sln:";
            // 
            // cmdChooseDll
            // 
            this.cmdChooseDll.Location = new System.Drawing.Point(650, 9);
            this.cmdChooseDll.Name = "cmdChooseDll";
            this.cmdChooseDll.Size = new System.Drawing.Size(32, 22);
            this.cmdChooseDll.TabIndex = 2;
            this.cmdChooseDll.Text = "...";
            this.cmdChooseDll.UseVisualStyleBackColor = true;
            this.cmdChooseDll.Click += new System.EventHandler(this.cmdChooseDll_Click);
            // 
            // txtDll
            // 
            this.txtDll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDll.Location = new System.Drawing.Point(62, 9);
            this.txtDll.Name = "txtDll";
            this.txtDll.Size = new System.Drawing.Size(582, 26);
            this.txtDll.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dll:";
            // 
            // TagChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 567);
            this.Name = "TagChooser";
            this.Text = "TagChooser";
            this.pContents.ResumeLayout(false);
            this.pNew.ResumeLayout(false);
            this.pNew.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pNew;
        private System.Windows.Forms.Button cmdChooseSln;
        private System.Windows.Forms.TextBox txtSln;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdChooseDll;
        private System.Windows.Forms.TextBox txtDll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdChooseCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label3;
    }
}