namespace NewMethod
{
    partial class nView_n_choices
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
            this.components = new System.ComponentModel.Container();
            this.cmdSplit = new System.Windows.Forms.Button();
            this.cmdDown = new System.Windows.Forms.Button();
            this.cmdUp = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdAlphabetize = new System.Windows.Forms.Button();
            this.cmdPaste = new System.Windows.Forms.Button();
            this.cmdRemoveAll = new System.Windows.Forms.Button();
            this.lvChoices = new NewMethod.nList();
            this.cmdSave = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdSplit
            // 
            this.cmdSplit.Location = new System.Drawing.Point(6, 147);
            this.cmdSplit.Name = "cmdSplit";
            this.cmdSplit.Size = new System.Drawing.Size(104, 21);
            this.cmdSplit.TabIndex = 10;
            this.cmdSplit.Text = "Split By Commas";
            this.cmdSplit.UseVisualStyleBackColor = true;
            this.cmdSplit.Click += new System.EventHandler(this.cmdSplit_Click);
            // 
            // cmdDown
            // 
            this.cmdDown.Location = new System.Drawing.Point(28, 232);
            this.cmdDown.Name = "cmdDown";
            this.cmdDown.Size = new System.Drawing.Size(58, 25);
            this.cmdDown.TabIndex = 9;
            this.cmdDown.Text = "Down";
            this.cmdDown.UseVisualStyleBackColor = true;
            this.cmdDown.Click += new System.EventHandler(this.cmdDown_Click);
            // 
            // cmdUp
            // 
            this.cmdUp.Location = new System.Drawing.Point(28, 201);
            this.cmdUp.Name = "cmdUp";
            this.cmdUp.Size = new System.Drawing.Size(58, 25);
            this.cmdUp.TabIndex = 8;
            this.cmdUp.Text = "Up";
            this.cmdUp.UseVisualStyleBackColor = true;
            this.cmdUp.Click += new System.EventHandler(this.cmdUp_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(6, 47);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(104, 40);
            this.cmdAdd.TabIndex = 7;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdAlphabetize
            // 
            this.cmdAlphabetize.Location = new System.Drawing.Point(6, 120);
            this.cmdAlphabetize.Name = "cmdAlphabetize";
            this.cmdAlphabetize.Size = new System.Drawing.Size(104, 21);
            this.cmdAlphabetize.TabIndex = 6;
            this.cmdAlphabetize.Text = "Alphabetize";
            this.cmdAlphabetize.UseVisualStyleBackColor = true;
            this.cmdAlphabetize.Click += new System.EventHandler(this.cmdAlphabetize_Click);
            // 
            // cmdPaste
            // 
            this.cmdPaste.Location = new System.Drawing.Point(6, 93);
            this.cmdPaste.Name = "cmdPaste";
            this.cmdPaste.Size = new System.Drawing.Size(104, 21);
            this.cmdPaste.TabIndex = 5;
            this.cmdPaste.Text = "Paste";
            this.cmdPaste.UseVisualStyleBackColor = true;
            this.cmdPaste.Click += new System.EventHandler(this.cmdPaste_Click);
            // 
            // cmdRemoveAll
            // 
            this.cmdRemoveAll.Location = new System.Drawing.Point(6, 174);
            this.cmdRemoveAll.Name = "cmdRemoveAll";
            this.cmdRemoveAll.Size = new System.Drawing.Size(104, 21);
            this.cmdRemoveAll.TabIndex = 4;
            this.cmdRemoveAll.Text = "Remove All";
            this.cmdRemoveAll.UseVisualStyleBackColor = true;
            this.cmdRemoveAll.Click += new System.EventHandler(this.cmdRemoveAll_Click);
            // 
            // lvChoices
            // 
            this.lvChoices.AddCaption = "Add New";
            this.lvChoices.AllowActions = true;
            this.lvChoices.AllowAdd = false;
            this.lvChoices.AllowDelete = true;
            this.lvChoices.AllowDeleteAlways = false;
            this.lvChoices.AllowDrop = true;
            this.lvChoices.AllowOnlyOpenDelete = false;
            this.lvChoices.AlternateConnection = null;
            this.lvChoices.BackColor = System.Drawing.Color.White;
            this.lvChoices.Caption = "";
            this.lvChoices.CurrentTemplate = null;
            this.lvChoices.ExtraClassInfo = "";
            this.lvChoices.Location = new System.Drawing.Point(113, 47);
            this.lvChoices.MultiSelect = true;
            this.lvChoices.Name = "lvChoices";
            this.lvChoices.Size = new System.Drawing.Size(424, 377);
            this.lvChoices.SuppressSelectionChanged = false;
            this.lvChoices.TabIndex = 3;
            this.lvChoices.zz_OpenColumnMenu = false;
            this.lvChoices.zz_OrderLineType = "";
            this.lvChoices.zz_ShowAutoRefresh = true;
            this.lvChoices.zz_ShowUnlimited = true;
            this.lvChoices.AboutToAdd += new NewMethod.AddHandler(this.lvChoices_AboutToAdd);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(254, 12);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(176, 29);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(3, 21);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(245, 20);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "<name>";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // nView_n_choices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmdSplit);
            this.Controls.Add(this.cmdDown);
            this.Controls.Add(this.cmdUp);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdAlphabetize);
            this.Controls.Add(this.cmdPaste);
            this.Controls.Add(this.cmdRemoveAll);
            this.Controls.Add(this.lvChoices);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "nView_n_choices";
            this.Resize += new System.EventHandler(this.nView_n_choices_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblName;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.Button cmdSave;
        public nList lvChoices;
        public System.Windows.Forms.Button cmdRemoveAll;
        public System.Windows.Forms.Button cmdPaste;
        public System.Windows.Forms.Button cmdAlphabetize;
        public System.Windows.Forms.Button cmdAdd;
        public System.Windows.Forms.Button cmdUp;
        public System.Windows.Forms.Button cmdDown;
        public System.Windows.Forms.Button cmdSplit;

    }
}
