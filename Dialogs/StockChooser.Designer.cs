namespace Rz5.Win.Dialogs
{
    partial class StockChooser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockChooser));
            this.optPartNumber = new System.Windows.Forms.RadioButton();
            this.chkConsign = new System.Windows.Forms.CheckBox();
            this.chkStock = new System.Windows.Forms.CheckBox();
            this.txtPartNumber = new NewMethod.nEntryBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.ilPics = new System.Windows.Forms.ImageList(this.components);
            this.lvResult = new NewMethod.nList();
            this.chkExcess = new System.Windows.Forms.CheckBox();
            this.pOptions.SuspendLayout();
            this.pContents.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(142, 0);
            this.cmdOK.Size = new System.Drawing.Size(555, 58);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(0, 0);
            // 
            // pOptions
            // 
            this.pOptions.Location = new System.Drawing.Point(0, 371);
            this.pOptions.Size = new System.Drawing.Size(697, 63);
            // 
            // pContents
            // 
            this.pContents.Controls.Add(this.chkExcess);
            this.pContents.Controls.Add(this.lvResult);
            this.pContents.Controls.Add(this.cmdSearch);
            this.pContents.Controls.Add(this.optPartNumber);
            this.pContents.Controls.Add(this.chkConsign);
            this.pContents.Controls.Add(this.chkStock);
            this.pContents.Controls.Add(this.txtPartNumber);
            this.pContents.Location = new System.Drawing.Point(0, 0);
            this.pContents.Size = new System.Drawing.Size(697, 371);
            // 
            // optPartNumber
            // 
            this.optPartNumber.AutoSize = true;
            this.optPartNumber.Checked = true;
            this.optPartNumber.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optPartNumber.Location = new System.Drawing.Point(6, 5);
            this.optPartNumber.Name = "optPartNumber";
            this.optPartNumber.Size = new System.Drawing.Size(57, 19);
            this.optPartNumber.TabIndex = 50;
            this.optPartNumber.TabStop = true;
            this.optPartNumber.Text = "Part #";
            this.optPartNumber.UseVisualStyleBackColor = true;
            // 
            // chkConsign
            // 
            this.chkConsign.AutoSize = true;
            this.chkConsign.Checked = true;
            this.chkConsign.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConsign.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkConsign.Location = new System.Drawing.Point(246, 6);
            this.chkConsign.Name = "chkConsign";
            this.chkConsign.Size = new System.Drawing.Size(70, 19);
            this.chkConsign.TabIndex = 49;
            this.chkConsign.Text = "Consign";
            this.chkConsign.UseVisualStyleBackColor = true;
            // 
            // chkStock
            // 
            this.chkStock.AutoSize = true;
            this.chkStock.Checked = true;
            this.chkStock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStock.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStock.Location = new System.Drawing.Point(173, 6);
            this.chkStock.Name = "chkStock";
            this.chkStock.Size = new System.Drawing.Size(55, 19);
            this.chkStock.TabIndex = 48;
            this.chkStock.Text = "Stock";
            this.chkStock.UseVisualStyleBackColor = true;
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartNumber.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartNumber.Location = new System.Drawing.Point(6, 26);
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.Size = new System.Drawing.Size(400, 31);
            this.txtPartNumber.TabIndex = 47;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSearch.ImageKey = "Search.jpg";
            this.cmdSearch.ImageList = this.ilPics;
            this.cmdSearch.Location = new System.Drawing.Point(412, 6);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(123, 63);
            this.cmdSearch.TabIndex = 51;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // ilPics
            // 
            this.ilPics.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilPics.ImageStream")));
            this.ilPics.TransparentColor = System.Drawing.Color.Transparent;
            this.ilPics.Images.SetKeyName(0, "Search.jpg");
            // 
            // lvResult
            // 
            this.lvResult.AddCaption = "Add New";
            this.lvResult.AllowActions = true;
            this.lvResult.AllowAdd = false;
            this.lvResult.AllowDelete = true;
            this.lvResult.AllowDeleteAlways = false;
            this.lvResult.AllowDrop = true;
            this.lvResult.AllowOnlyOpenDelete = false;
            this.lvResult.AlternateConnection = null;
            this.lvResult.BackColor = System.Drawing.Color.White;
            this.lvResult.Caption = "Stock, Consignments, And Excess";
            this.lvResult.CurrentTemplate = null;
            this.lvResult.ExtraClassInfo = "";
            this.lvResult.Location = new System.Drawing.Point(6, 75);
            this.lvResult.MultiSelect = true;
            this.lvResult.Name = "lvResult";
            this.lvResult.Size = new System.Drawing.Size(653, 290);
            this.lvResult.SuppressSelectionChanged = false;
            this.lvResult.TabIndex = 52;
            this.lvResult.zz_OpenColumnMenu = false;
            this.lvResult.zz_OrderLineType = "";
            this.lvResult.zz_ShowAutoRefresh = true;
            this.lvResult.zz_ShowUnlimited = true;
            this.lvResult.AboutToThrow += new Core.ShowHandler(this.lvResult_AboutToThrow);
            // 
            // chkExcess
            // 
            this.chkExcess.AutoSize = true;
            this.chkExcess.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExcess.ForeColor = System.Drawing.Color.Red;
            this.chkExcess.Location = new System.Drawing.Point(322, 5);
            this.chkExcess.Name = "chkExcess";
            this.chkExcess.Size = new System.Drawing.Size(62, 19);
            this.chkExcess.TabIndex = 53;
            this.chkExcess.Text = "Excess";
            this.chkExcess.UseVisualStyleBackColor = true;
            // 
            // StockChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 434);
            this.Name = "StockChooser";
            this.Text = "Inventory Selection";
            this.pOptions.ResumeLayout(false);
            this.pContents.ResumeLayout(false);
            this.pContents.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.RadioButton optPartNumber;
        protected System.Windows.Forms.CheckBox chkConsign;
        protected System.Windows.Forms.CheckBox chkStock;
        protected NewMethod.nEntryBox txtPartNumber;
        protected System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.ImageList ilPics;
        protected NewMethod.nList lvResult;
        protected System.Windows.Forms.CheckBox chkExcess;
    }
}