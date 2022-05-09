namespace Rz5.Win.Controls
{
    partial class OrderSearchOptions
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
            this.chkConsignment = new NewMethod.nEdit_Boolean();
            this.ddlInvoicePaidStatus = new NewMethod.nEdit_List();
            this.SuspendLayout();
            // 
            // chkConsignment
            // 
            this.chkConsignment.BackColor = System.Drawing.Color.Transparent;
            this.chkConsignment.Bold = false;
            this.chkConsignment.Caption = "Consignment Only";
            this.chkConsignment.Changed = false;
            this.chkConsignment.Location = new System.Drawing.Point(125, 198);
            this.chkConsignment.Name = "chkConsignment";
            this.chkConsignment.Size = new System.Drawing.Size(105, 13);
            this.chkConsignment.TabIndex = 17;
            this.chkConsignment.UseParentBackColor = false;
            this.chkConsignment.zz_CheckValue = false;
            this.chkConsignment.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.chkConsignment.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkConsignment.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.chkConsignment.zz_OriginalDesign = false;
            this.chkConsignment.zz_ShowNeedsSaveColor = false;
            // 
            // ddlInvoicePaidStatus
            // 
            this.ddlInvoicePaidStatus.AllCaps = false;
            this.ddlInvoicePaidStatus.AllowEdit = false;
            this.ddlInvoicePaidStatus.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ddlInvoicePaidStatus.Bold = false;
            this.ddlInvoicePaidStatus.Caption = "<caption>";
            this.ddlInvoicePaidStatus.Changed = false;
            this.ddlInvoicePaidStatus.ListName = null;
            this.ddlInvoicePaidStatus.Location = new System.Drawing.Point(0, 0);
            this.ddlInvoicePaidStatus.Name = "ddlInvoicePaidStatus";
            this.ddlInvoicePaidStatus.SimpleList = null;
            this.ddlInvoicePaidStatus.Size = new System.Drawing.Size(236, 46);
            this.ddlInvoicePaidStatus.TabIndex = 0;
            this.ddlInvoicePaidStatus.UseParentBackColor = false;
            this.ddlInvoicePaidStatus.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ddlInvoicePaidStatus.zz_GlobalColor = System.Drawing.Color.Black;
            this.ddlInvoicePaidStatus.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ddlInvoicePaidStatus.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ddlInvoicePaidStatus.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlInvoicePaidStatus.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ddlInvoicePaidStatus.zz_OriginalDesign = true;
            this.ddlInvoicePaidStatus.zz_ShowNeedsSaveColor = true;
            this.ddlInvoicePaidStatus.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ddlInvoicePaidStatus.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlInvoicePaidStatus.zz_UseGlobalColor = false;
            this.ddlInvoicePaidStatus.zz_UseGlobalFont = false;
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nEdit_Boolean chkConsignment;
        private NewMethod.nEdit_List ddlInvoicePaidStatus;
    }
}
