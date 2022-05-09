namespace Rz5
{
    partial class frmChooseCompanyCredit
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
            this.lvCredits = new NewMethod.nList();
            this.SuspendLayout();
            // 
            // lvCredits
            // 
            this.lvCredits.AddCaption = "Apply Selected Credits";
            this.lvCredits.AllowActions = true;
            this.lvCredits.AllowAdd = true;
            this.lvCredits.AllowDelete = false;
            this.lvCredits.AllowDeleteAlways = false;
            this.lvCredits.AllowDrop = true;
            this.lvCredits.AllowOnlyOpenDelete = false;
            this.lvCredits.AlternateConnection = null;
            this.lvCredits.BackColor = System.Drawing.Color.White;
            this.lvCredits.Caption = "";
            this.lvCredits.CurrentTemplate = null;
            this.lvCredits.ExtraClassInfo = "";
            this.lvCredits.Location = new System.Drawing.Point(13, 13);
            this.lvCredits.MultiSelect = true;
            this.lvCredits.Name = "lvCredits";
            this.lvCredits.Size = new System.Drawing.Size(782, 259);
            this.lvCredits.SuppressSelectionChanged = false;
            this.lvCredits.TabIndex = 0;
            this.lvCredits.zz_OpenColumnMenu = false;
            this.lvCredits.zz_OrderLineType = "";
            this.lvCredits.zz_ShowAutoRefresh = true;
            this.lvCredits.zz_ShowUnlimited = true;
            this.lvCredits.AboutToThrow += new Core.ShowHandler(this.lvCredits_AboutToThrow);
            this.lvCredits.AboutToAdd += new NewMethod.AddHandler(this.lvCredits_AboutToAdd);
            this.lvCredits.ObjectClicked += new NewMethod.ObjectClickHandler(this.lvCredits_ObjectClicked);
            // 
            // frmChooseCompanyCredits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 282);
            this.Controls.Add(this.lvCredits);
            this.Name = "frmChooseCompanyCredits";
            this.Text = "Choose Credits:";
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nList lvCredits;




    }
}