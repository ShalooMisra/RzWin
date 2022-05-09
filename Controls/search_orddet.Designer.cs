namespace Rz5
{
    partial class search_orddet
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
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.optLogical = new System.Windows.Forms.RadioButton();
            this.optAlpha = new System.Windows.Forms.RadioButton();
            this.vs = new System.Windows.Forms.VScrollBar();
            this.pbBottom = new System.Windows.Forms.PictureBox();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.pbTop = new System.Windows.Forms.PictureBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.gb = new System.Windows.Forms.GroupBox();
            this.nSearchCriteria4 = new NewMethod.nSearchCriteria();
            this.nSearchCriteria3 = new NewMethod.nSearchCriteria();
            this.nSearchCriteria2 = new NewMethod.nSearchCriteria();
            this.nSearchCriteria1 = new NewMethod.nSearchCriteria();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).BeginInit();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.CheckBoxes = true;
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(12, 12);
            this.lv.MultiSelect = false;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(220, 228);
            this.lv.TabIndex = 10;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Column Name";
            this.columnHeader1.Width = 197;
            // 
            // optLogical
            // 
            this.optLogical.AutoSize = true;
            this.optLogical.Location = new System.Drawing.Point(134, 245);
            this.optLogical.Name = "optLogical";
            this.optLogical.Size = new System.Drawing.Size(59, 17);
            this.optLogical.TabIndex = 19;
            this.optLogical.Text = "Logical";
            this.optLogical.UseVisualStyleBackColor = true;
            this.optLogical.CheckedChanged += new System.EventHandler(this.optLogical_CheckedChanged);
            // 
            // optAlpha
            // 
            this.optAlpha.AutoSize = true;
            this.optAlpha.Checked = true;
            this.optAlpha.Location = new System.Drawing.Point(43, 245);
            this.optAlpha.Name = "optAlpha";
            this.optAlpha.Size = new System.Drawing.Size(83, 17);
            this.optAlpha.TabIndex = 18;
            this.optAlpha.TabStop = true;
            this.optAlpha.Text = "Alphabetical";
            this.optAlpha.UseVisualStyleBackColor = true;
            this.optAlpha.CheckedChanged += new System.EventHandler(this.optAlpha_CheckedChanged);
            // 
            // vs
            // 
            this.vs.LargeChange = 1;
            this.vs.Location = new System.Drawing.Point(571, 12);
            this.vs.Maximum = 0;
            this.vs.Name = "vs";
            this.vs.Size = new System.Drawing.Size(17, 257);
            this.vs.TabIndex = 17;
            // 
            // pbBottom
            // 
            this.pbBottom.BackColor = System.Drawing.Color.Black;
            this.pbBottom.Location = new System.Drawing.Point(472, 346);
            this.pbBottom.Name = "pbBottom";
            this.pbBottom.Size = new System.Drawing.Size(10, 12);
            this.pbBottom.TabIndex = 16;
            this.pbBottom.TabStop = false;
            // 
            // pbRight
            // 
            this.pbRight.BackColor = System.Drawing.Color.Black;
            this.pbRight.Location = new System.Drawing.Point(464, 338);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(10, 12);
            this.pbRight.TabIndex = 15;
            this.pbRight.TabStop = false;
            // 
            // pbLeft
            // 
            this.pbLeft.BackColor = System.Drawing.Color.Black;
            this.pbLeft.Location = new System.Drawing.Point(456, 330);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(10, 12);
            this.pbLeft.TabIndex = 14;
            this.pbLeft.TabStop = false;
            // 
            // pbTop
            // 
            this.pbTop.BackColor = System.Drawing.Color.Black;
            this.pbTop.Location = new System.Drawing.Point(450, 323);
            this.pbTop.Name = "pbTop";
            this.pbTop.Size = new System.Drawing.Size(10, 12);
            this.pbTop.TabIndex = 13;
            this.pbTop.TabStop = false;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearch.Location = new System.Drawing.Point(12, 287);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(556, 29);
            this.cmdSearch.TabIndex = 12;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // gb
            // 
            this.gb.Controls.Add(this.nSearchCriteria4);
            this.gb.Controls.Add(this.nSearchCriteria3);
            this.gb.Controls.Add(this.nSearchCriteria2);
            this.gb.Controls.Add(this.nSearchCriteria1);
            this.gb.Location = new System.Drawing.Point(238, 12);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(330, 257);
            this.gb.TabIndex = 11;
            this.gb.TabStop = false;
            // 
            // nSearchCriteria4
            // 
            this.nSearchCriteria4.Location = new System.Drawing.Point(4, 195);
            this.nSearchCriteria4.Name = "nSearchCriteria4";
            this.nSearchCriteria4.Size = new System.Drawing.Size(320, 55);
            this.nSearchCriteria4.TabIndex = 3;
            // 
            // nSearchCriteria3
            // 
            this.nSearchCriteria3.Location = new System.Drawing.Point(4, 134);
            this.nSearchCriteria3.Name = "nSearchCriteria3";
            this.nSearchCriteria3.Size = new System.Drawing.Size(320, 55);
            this.nSearchCriteria3.TabIndex = 2;
            // 
            // nSearchCriteria2
            // 
            this.nSearchCriteria2.Location = new System.Drawing.Point(4, 73);
            this.nSearchCriteria2.Name = "nSearchCriteria2";
            this.nSearchCriteria2.Size = new System.Drawing.Size(320, 55);
            this.nSearchCriteria2.TabIndex = 1;
            // 
            // nSearchCriteria1
            // 
            this.nSearchCriteria1.Location = new System.Drawing.Point(5, 12);
            this.nSearchCriteria1.Name = "nSearchCriteria1";
            this.nSearchCriteria1.Size = new System.Drawing.Size(320, 55);
            this.nSearchCriteria1.TabIndex = 0;
            // 
            // search_orddet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lv);
            this.Controls.Add(this.optLogical);
            this.Controls.Add(this.optAlpha);
            this.Controls.Add(this.vs);
            this.Controls.Add(this.pbBottom);
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.pbTop);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.gb);
            this.Name = "search_orddet";
            this.Size = new System.Drawing.Size(598, 374);
            this.Resize += new System.EventHandler(this.search_soft_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).EndInit();
            this.gb.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.RadioButton optLogical;
        private System.Windows.Forms.RadioButton optAlpha;
        private System.Windows.Forms.VScrollBar vs;
        private System.Windows.Forms.PictureBox pbBottom;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.PictureBox pbTop;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.GroupBox gb;
        private NewMethod.nSearchCriteria nSearchCriteria4;
        private NewMethod.nSearchCriteria nSearchCriteria3;
        private NewMethod.nSearchCriteria nSearchCriteria2;
        private NewMethod.nSearchCriteria nSearchCriteria1;

    }
}
