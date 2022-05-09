namespace NewMethod
{
    partial class frmNewForm
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
            this.lblInstruct = new System.Windows.Forms.Label();
            this.cmdGenericList = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdAutoDesign = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdBlankScreen = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInstruct
            // 
            this.lblInstruct.Location = new System.Drawing.Point(5, 3);
            this.lblInstruct.Name = "lblInstruct";
            this.lblInstruct.Size = new System.Drawing.Size(397, 47);
            this.lblInstruct.TabIndex = 0;
            this.lblInstruct.Text = "Currently no visual layout or screen has been designed for this kind of informati" +
                "on.  To create one, choose from the list of options below.";
            // 
            // cmdGenericList
            // 
            this.cmdGenericList.Location = new System.Drawing.Point(22, 197);
            this.cmdGenericList.Name = "cmdGenericList";
            this.cmdGenericList.Size = new System.Drawing.Size(109, 64);
            this.cmdGenericList.TabIndex = 1;
            this.cmdGenericList.Text = "Generic Information List";
            this.cmdGenericList.UseVisualStyleBackColor = true;
            this.cmdGenericList.Click += new System.EventHandler(this.cmdGenericList_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(137, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 47);
            this.label1.TabIndex = 2;
            this.label1.Text = "Use this option to create a top-to-bottom list of information.  This format will " +
                "show all of the available data, but the layout cannot be edited.";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(137, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 64);
            this.label2.TabIndex = 4;
            this.label2.Text = "Use this option and the system will infer a reasonable layout and design for this" +
                " data.  Once it has been created, you can add, remove, or re-arrange the auto-ge" +
                "nerated contents.";
            // 
            // cmdAutoDesign
            // 
            this.cmdAutoDesign.Location = new System.Drawing.Point(22, 43);
            this.cmdAutoDesign.Name = "cmdAutoDesign";
            this.cmdAutoDesign.Size = new System.Drawing.Size(109, 64);
            this.cmdAutoDesign.TabIndex = 3;
            this.cmdAutoDesign.Text = "Automatic Screen Design";
            this.cmdAutoDesign.UseVisualStyleBackColor = true;
            this.cmdAutoDesign.Click += new System.EventHandler(this.cmdAutoDesign_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(137, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 64);
            this.label3.TabIndex = 6;
            this.label3.Text = "Use this option to create a blank layout ready to be designed and customized.";
            // 
            // cmdBlankScreen
            // 
            this.cmdBlankScreen.Location = new System.Drawing.Point(22, 120);
            this.cmdBlankScreen.Name = "cmdBlankScreen";
            this.cmdBlankScreen.Size = new System.Drawing.Size(109, 64);
            this.cmdBlankScreen.TabIndex = 5;
            this.cmdBlankScreen.Text = "New Screen Design";
            this.cmdBlankScreen.UseVisualStyleBackColor = true;
            this.cmdBlankScreen.Click += new System.EventHandler(this.cmdBlankScreen_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(22, 282);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(109, 25);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmNewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 319);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdBlankScreen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdAutoDesign);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdGenericList);
            this.Controls.Add(this.lblInstruct);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Screen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInstruct;
        private System.Windows.Forms.Button cmdGenericList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdAutoDesign;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdBlankScreen;
        private System.Windows.Forms.Button cmdCancel;
    }
}