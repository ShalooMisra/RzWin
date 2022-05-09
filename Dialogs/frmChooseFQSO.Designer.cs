namespace Rz5
{
    partial class frmChooseFQSO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChooseFQSO));
            this.lv = new NewMethod.nList();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.optQuote = new System.Windows.Forms.RadioButton();
            this.optSales = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.AddCaption = "Add New";
            this.lv.AllowActions = false;
            this.lv.AllowAdd = false;
            this.lv.AllowDelete = false;
            this.lv.AllowDeleteAlways = false;
            this.lv.AllowDrop = true;
            this.lv.AllowOnlyOpenDelete = false;
            this.lv.AlternateConnection = null;
            this.lv.BackColor = System.Drawing.Color.White;
            this.lv.Caption = "Formal Quotes";
            this.lv.CurrentTemplate = null;
            this.lv.ExtraClassInfo = "";
            this.lv.Location = new System.Drawing.Point(12, 37);
            this.lv.MultiSelect = true;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(680, 253);
            this.lv.SuppressSelectionChanged = false;
            this.lv.TabIndex = 0;
            this.lv.zz_OpenColumnMenu = false;
            this.lv.zz_OrderLineType = "";
            this.lv.zz_ShowAutoRefresh = true;
            this.lv.zz_ShowUnlimited = true;
            // 
            // cmdAccept
            // 
            this.cmdAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAccept.Location = new System.Drawing.Point(365, 294);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(327, 32);
            this.cmdAccept.TabIndex = 1;
            this.cmdAccept.Text = "Accept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(12, 294);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(327, 32);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // optQuote
            // 
            this.optQuote.AutoSize = true;
            this.optQuote.Checked = true;
            this.optQuote.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optQuote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.optQuote.Location = new System.Drawing.Point(401, 8);
            this.optQuote.Name = "optQuote";
            this.optQuote.Size = new System.Drawing.Size(151, 26);
            this.optQuote.TabIndex = 3;
            this.optQuote.TabStop = true;
            this.optQuote.Text = "Formal Quotes";
            this.optQuote.UseVisualStyleBackColor = true;
            this.optQuote.Visible = false;
            this.optQuote.CheckedChanged += new System.EventHandler(this.optQuote_CheckedChanged);
            // 
            // optSales
            // 
            this.optSales.AutoSize = true;
            this.optSales.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.optSales.Location = new System.Drawing.Point(558, 10);
            this.optSales.Name = "optSales";
            this.optSales.Size = new System.Drawing.Size(134, 26);
            this.optSales.TabIndex = 4;
            this.optSales.Text = "Sales Orders";
            this.optSales.UseVisualStyleBackColor = true;
            this.optSales.Visible = false;
            this.optSales.CheckedChanged += new System.EventHandler(this.optSales_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Double Click an order below to preview it.";
            // 
            // frmChooseFQSO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 332);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.optSales);
            this.Controls.Add(this.optQuote);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.lv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmChooseFQSO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NewMethod.nList lv;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.RadioButton optQuote;
        private System.Windows.Forms.RadioButton optSales;
        private System.Windows.Forms.Label label1;
    }
}