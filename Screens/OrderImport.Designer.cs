namespace Rz5
{
    partial class OrderImport
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
            this.gb = new System.Windows.Forms.GroupBox();
            this.cboKeyDetail = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboKeyHeader = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.optTwoLists = new System.Windows.Forms.RadioButton();
            this.optSingleList = new System.Windows.Forms.RadioButton();
            this.cmdImport = new System.Windows.Forms.Button();
            this.bgImport = new System.ComponentModel.BackgroundWorker();
            this.dv2 = new NewMethod.nDataView();
            this.dv = new NewMethod.nDataView();
            this.cboOrderType = new NewMethod.nEdit_List();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.BackColor = System.Drawing.Color.White;
            this.gb.Controls.Add(this.cboKeyDetail);
            this.gb.Controls.Add(this.label2);
            this.gb.Controls.Add(this.cboKeyHeader);
            this.gb.Controls.Add(this.label1);
            this.gb.Controls.Add(this.optTwoLists);
            this.gb.Controls.Add(this.optSingleList);
            this.gb.Controls.Add(this.cboOrderType);
            this.gb.Controls.Add(this.cmdImport);
            this.gb.Location = new System.Drawing.Point(4, 2);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(135, 262);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            // 
            // cboKeyDetail
            // 
            this.cboKeyDetail.FormattingEnabled = true;
            this.cboKeyDetail.Location = new System.Drawing.Point(9, 235);
            this.cboKeyDetail.Name = "cboKeyDetail";
            this.cboKeyDetail.Size = new System.Drawing.Size(120, 21);
            this.cboKeyDetail.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Detail Key";
            // 
            // cboKeyHeader
            // 
            this.cboKeyHeader.FormattingEnabled = true;
            this.cboKeyHeader.Location = new System.Drawing.Point(9, 187);
            this.cboKeyHeader.Name = "cboKeyHeader";
            this.cboKeyHeader.Size = new System.Drawing.Size(120, 21);
            this.cboKeyHeader.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Header Key";
            // 
            // optTwoLists
            // 
            this.optTwoLists.AutoSize = true;
            this.optTwoLists.Location = new System.Drawing.Point(11, 94);
            this.optTwoLists.Name = "optTwoLists";
            this.optTwoLists.Size = new System.Drawing.Size(70, 17);
            this.optTwoLists.TabIndex = 3;
            this.optTwoLists.Text = "Two Lists";
            this.optTwoLists.UseVisualStyleBackColor = true;
            this.optTwoLists.CheckedChanged += new System.EventHandler(this.optList_CheckedChanged);
            // 
            // optSingleList
            // 
            this.optSingleList.AutoSize = true;
            this.optSingleList.Checked = true;
            this.optSingleList.Location = new System.Drawing.Point(11, 71);
            this.optSingleList.Name = "optSingleList";
            this.optSingleList.Size = new System.Drawing.Size(73, 17);
            this.optSingleList.TabIndex = 2;
            this.optSingleList.TabStop = true;
            this.optSingleList.Text = "Single List";
            this.optSingleList.UseVisualStyleBackColor = true;
            this.optSingleList.CheckedChanged += new System.EventHandler(this.optList_CheckedChanged);
            // 
            // cmdImport
            // 
            this.cmdImport.Location = new System.Drawing.Point(5, 117);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(124, 42);
            this.cmdImport.TabIndex = 0;
            this.cmdImport.Text = "Import";
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // bgImport
            // 
            this.bgImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgImport_DoWork);
            this.bgImport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgImport_RunWorkerCompleted);
            // 
            // dv2
            // 
            this.dv2.AlwaysDisableAccept = false;
            this.dv2.BackColor = System.Drawing.Color.White;
            this.dv2.DisableAutoMatching = false;
            this.dv2.HideOptions = false;
            this.dv2.Location = new System.Drawing.Point(146, 281);
            this.dv2.Name = "dv2";
            this.dv2.Size = new System.Drawing.Size(387, 264);
            this.dv2.TabIndex = 2;
            this.dv2.AfterImport += new NewMethod.nDataViewImportHandler(this.dv2_AfterImport);
            // 
            // dv
            // 
            this.dv.AlwaysDisableAccept = false;
            this.dv.BackColor = System.Drawing.Color.White;
            this.dv.DisableAutoMatching = false;
            this.dv.HideOptions = false;
            this.dv.Location = new System.Drawing.Point(146, 11);
            this.dv.Name = "dv";
            this.dv.Size = new System.Drawing.Size(387, 264);
            this.dv.TabIndex = 1;
            this.dv.AfterImport += new NewMethod.nDataViewImportHandler(this.dv_AfterImport);
            this.dv.Accept += new NewMethod.nDataViewAcceptHandler(this.dv_Accept);
            // 
            // cboOrderType
            // 
            this.cboOrderType.AllCaps = false;
            this.cboOrderType.AllowEdit = false;
            this.cboOrderType.BackColor = System.Drawing.Color.White;
            this.cboOrderType.Bold = false;
            this.cboOrderType.Caption = "Order Type";
            this.cboOrderType.Changed = false;
            this.cboOrderType.ListName = null;
            this.cboOrderType.Location = new System.Drawing.Point(9, 19);
            this.cboOrderType.Name = "cboOrderType";
            this.cboOrderType.SimpleList = "Quote|Sales|Invoice|Purchase|RMA|VendRMA";
            this.cboOrderType.Size = new System.Drawing.Size(120, 46);
            this.cboOrderType.TabIndex = 1;
            this.cboOrderType.UseParentBackColor = true;
            this.cboOrderType.zz_GlobalColor = System.Drawing.Color.Black;
            this.cboOrderType.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboOrderType.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cboOrderType.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboOrderType.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.cboOrderType.zz_OriginalDesign = true;
            this.cboOrderType.zz_ShowNeedsSaveColor = true;
            this.cboOrderType.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.cboOrderType.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOrderType.zz_UseGlobalColor = false;
            this.cboOrderType.zz_UseGlobalFont = false;
            // 
            // OrderImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dv2);
            this.Controls.Add(this.dv);
            this.Controls.Add(this.gb);
            this.Name = "OrderImport";
            this.Size = new System.Drawing.Size(675, 570);
            this.Resize += new System.EventHandler(this.OrderImport_Resize);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private NewMethod.nEdit_List cboOrderType;
        private System.Windows.Forms.Button cmdImport;
        private NewMethod.nDataView dv;
        private System.ComponentModel.BackgroundWorker bgImport;
        private System.Windows.Forms.RadioButton optTwoLists;
        private System.Windows.Forms.RadioButton optSingleList;
        private NewMethod.nDataView dv2;
        private System.Windows.Forms.ComboBox cboKeyDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboKeyHeader;
        private System.Windows.Forms.Label label1;
    }
}
