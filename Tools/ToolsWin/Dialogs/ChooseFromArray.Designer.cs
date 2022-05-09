namespace ToolsWin.Dialogs
{
    partial class ChooseFromArray
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
            this.gbSelected = new System.Windows.Forms.GroupBox();
            this.txtSel = new System.Windows.Forms.TextBox();
            this.pContents.SuspendLayout();
            this.gbSelected.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(142, 0);
            this.cmdOK.Size = new System.Drawing.Size(196, 59);
            // 
            // pContents
            // 
            this.pContents.Controls.Add(this.lv);
            this.pContents.Controls.Add(this.gbSelected);
            this.pContents.Location = new System.Drawing.Point(0, 0);
            this.pContents.Size = new System.Drawing.Size(338, 486);
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv.Location = new System.Drawing.Point(0, 0);
            this.lv.MultiSelect = false;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(338, 435);
            this.lv.TabIndex = 2;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
            this.lv.Click += new System.EventHandler(this.lv_Click);
            this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 302;
            // 
            // gbSelected
            // 
            this.gbSelected.Controls.Add(this.txtSel);
            this.gbSelected.Location = new System.Drawing.Point(4, 441);
            this.gbSelected.Name = "gbSelected";
            this.gbSelected.Size = new System.Drawing.Size(334, 39);
            this.gbSelected.TabIndex = 3;
            this.gbSelected.TabStop = false;
            this.gbSelected.Text = "Selected Text:";
            // 
            // txtSel
            // 
            this.txtSel.Location = new System.Drawing.Point(4, 15);
            this.txtSel.Name = "txtSel";
            this.txtSel.Size = new System.Drawing.Size(325, 20);
            this.txtSel.TabIndex = 0;
            // 
            // ChooseFromArray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 549);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseFromArray";
            this.Text = "Choose";
            this.pContents.ResumeLayout(false);
            this.gbSelected.ResumeLayout(false);
            this.gbSelected.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox gbSelected;
        private System.Windows.Forms.TextBox txtSel;
    }
}