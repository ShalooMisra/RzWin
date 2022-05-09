namespace Rz5
{
    partial class QuotesViewSimple
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
            this.Result_Quotes = new NewMethod.nList();
            this.SuspendLayout();
            // 
            // Result_Quotes
            // 
            this.Result_Quotes.AddCaption = "Add New";
            this.Result_Quotes.AllowActions = true;
            this.Result_Quotes.AllowAdd = false;
            this.Result_Quotes.AllowDelete = true;
            this.Result_Quotes.AllowDeleteAlways = false;
            this.Result_Quotes.AllowDrop = true;
            this.Result_Quotes.AlternateConnection = null;
            this.Result_Quotes.Caption = "";
            this.Result_Quotes.CurrentTemplate = null;
            this.Result_Quotes.ExtraClassInfo = "";
            this.Result_Quotes.Location = new System.Drawing.Point(25, 59);
            this.Result_Quotes.MultiSelect = true;
            this.Result_Quotes.Name = "Result_Quotes";
            this.Result_Quotes.Size = new System.Drawing.Size(493, 151);
            this.Result_Quotes.SuppressSelectionChanged = false;
            this.Result_Quotes.TabIndex = 9;
            this.Result_Quotes.zz_OpenColumnMenu = false;
            this.Result_Quotes.zz_ShowAutoRefresh = true;
            this.Result_Quotes.zz_ShowUnlimited = true;
            this.Result_Quotes.AboutToThrow += new Core.ShowHandler(this.Result_Quotes_AboutToThrow);
            // 
            // QuotesViewSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Result_Quotes);
            this.Name = "QuotesViewSimple";
            this.Controls.SetChildIndex(this.gbQuotes, 0);
            this.Controls.SetChildIndex(this.Result_Quotes, 0);
            this.ResumeLayout(false);

        }

        #endregion

        protected NewMethod.nList Result_Quotes;
    }
}
