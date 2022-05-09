namespace Rz5
{
    partial class view_validation_form
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
            this.lblPreValStatusTitle = new System.Windows.Forms.Label();
            this.btnSavePreval = new System.Windows.Forms.Button();
            this.validations = new NewMethod.nList();
            this.gbPrevalidation = new System.Windows.Forms.GroupBox();
            this.ctl_pvDoesShipToMatch = new Rz5.InspectionLine();
            this.ctl_pvDockDateRealistic = new Rz5.InspectionLine();
            this.ctl_pvDoesPnQtyPriceMfgMatch = new Rz5.InspectionLine();
            this.ctl_prevalidation_notes = new NewMethod.nEdit_Memo();
            this.lblPrevalidationStatus = new System.Windows.Forms.Label();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.gbPrevalidation.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPreValStatusTitle
            // 
            this.lblPreValStatusTitle.AutoSize = true;
            this.lblPreValStatusTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreValStatusTitle.Location = new System.Drawing.Point(12, 5);
            this.lblPreValStatusTitle.Name = "lblPreValStatusTitle";
            this.lblPreValStatusTitle.Size = new System.Drawing.Size(107, 17);
            this.lblPreValStatusTitle.TabIndex = 12;
            this.lblPreValStatusTitle.Text = "Current Status: ";
            // 
            // btnSavePreval
            // 
            this.btnSavePreval.Enabled = false;
            this.btnSavePreval.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePreval.Location = new System.Drawing.Point(428, 19);
            this.btnSavePreval.Name = "btnSavePreval";
            this.btnSavePreval.Size = new System.Drawing.Size(77, 27);
            this.btnSavePreval.TabIndex = 18;
            this.btnSavePreval.Text = "Save";
            this.btnSavePreval.UseVisualStyleBackColor = true;
            this.btnSavePreval.Click += new System.EventHandler(this.btnSavePreval_Click);
            // 
            // validations
            // 
            this.validations.AddCaption = "Add New";
            this.validations.AllowActions = true;
            this.validations.AllowAdd = false;
            this.validations.AllowDelete = true;
            this.validations.AllowDeleteAlways = false;
            this.validations.AllowDrop = true;
            this.validations.AllowOnlyOpenDelete = false;
            this.validations.AlternateConnection = null;
            this.validations.BackColor = System.Drawing.Color.White;
            this.validations.Caption = "";
            this.validations.CurrentTemplate = null;
            this.validations.ExtraClassInfo = "";
            this.validations.Location = new System.Drawing.Point(12, 33);
            this.validations.MultiSelect = true;
            this.validations.Name = "validations";
            this.validations.Size = new System.Drawing.Size(517, 308);
            this.validations.SuppressSelectionChanged = false;
            this.validations.TabIndex = 19;
            this.validations.zz_OpenColumnMenu = false;
            this.validations.zz_OrderLineType = "";
            this.validations.zz_ShowAutoRefresh = true;
            this.validations.zz_ShowUnlimited = true;
            // 
            // gbPrevalidation
            // 
            this.gbPrevalidation.Controls.Add(this.lblPrevalidationStatus);
            this.gbPrevalidation.Controls.Add(this.ctl_pvDoesShipToMatch);
            this.gbPrevalidation.Controls.Add(this.ctl_pvDockDateRealistic);
            this.gbPrevalidation.Controls.Add(this.btnSavePreval);
            this.gbPrevalidation.Controls.Add(this.ctl_pvDoesPnQtyPriceMfgMatch);
            this.gbPrevalidation.Controls.Add(this.ctl_prevalidation_notes);
            this.gbPrevalidation.Location = new System.Drawing.Point(12, 365);
            this.gbPrevalidation.Name = "gbPrevalidation";
            this.gbPrevalidation.Size = new System.Drawing.Size(515, 253);
            this.gbPrevalidation.TabIndex = 20;
            this.gbPrevalidation.TabStop = false;
            this.gbPrevalidation.Text = "Pre-Validation";
            // 
            // ctl_pvDoesShipToMatch
            // 
            this.ctl_pvDoesShipToMatch.Caption = "Does the Ship-to match the customer PO?";
            this.ctl_pvDoesShipToMatch.FieldNAText = "NA";
            this.ctl_pvDoesShipToMatch.FieldNotes = "pvDoesShipToMatch_notes";
            this.ctl_pvDoesShipToMatch.FieldNoText = "N";
            this.ctl_pvDoesShipToMatch.FieldYesNo = "pvDoesShipToMatch_condition";
            this.ctl_pvDoesShipToMatch.FieldYesText = "Y";
            this.ctl_pvDoesShipToMatch.IsNA = false;
            this.ctl_pvDoesShipToMatch.IsNo = false;
            this.ctl_pvDoesShipToMatch.IsYes = true;
            this.ctl_pvDoesShipToMatch.Location = new System.Drawing.Point(8, 136);
            this.ctl_pvDoesShipToMatch.Name = "ctl_pvDoesShipToMatch";
            this.ctl_pvDoesShipToMatch.Notes = "";
            this.ctl_pvDoesShipToMatch.ShowNA = true;
            this.ctl_pvDoesShipToMatch.ShowNotes = true;
            this.ctl_pvDoesShipToMatch.Size = new System.Drawing.Size(498, 51);
            this.ctl_pvDoesShipToMatch.TabIndex = 17;
            // 
            // ctl_pvDockDateRealistic
            // 
            this.ctl_pvDockDateRealistic.Caption = "Is Dock Date Realistic? (Add 10 days for ALL external testing)";
            this.ctl_pvDockDateRealistic.FieldNAText = "NA";
            this.ctl_pvDockDateRealistic.FieldNotes = "pvDockDateRealistic_notes";
            this.ctl_pvDockDateRealistic.FieldNoText = "N";
            this.ctl_pvDockDateRealistic.FieldYesNo = "pvDockDateRealistic_condition";
            this.ctl_pvDockDateRealistic.FieldYesText = "Y";
            this.ctl_pvDockDateRealistic.IsNA = false;
            this.ctl_pvDockDateRealistic.IsNo = false;
            this.ctl_pvDockDateRealistic.IsYes = true;
            this.ctl_pvDockDateRealistic.Location = new System.Drawing.Point(7, 190);
            this.ctl_pvDockDateRealistic.Name = "ctl_pvDockDateRealistic";
            this.ctl_pvDockDateRealistic.Notes = "";
            this.ctl_pvDockDateRealistic.ShowNA = true;
            this.ctl_pvDockDateRealistic.ShowNotes = true;
            this.ctl_pvDockDateRealistic.Size = new System.Drawing.Size(498, 51);
            this.ctl_pvDockDateRealistic.TabIndex = 16;
            // 
            // ctl_pvDoesPnQtyPriceMfgMatch
            // 
            this.ctl_pvDoesPnQtyPriceMfgMatch.Caption = "Does Part Number, Price, QTY,  MFG & Description match the customer PO?";
            this.ctl_pvDoesPnQtyPriceMfgMatch.FieldNAText = "NA";
            this.ctl_pvDoesPnQtyPriceMfgMatch.FieldNotes = "pvDoesPnQtyPriceMfgMatch_notes";
            this.ctl_pvDoesPnQtyPriceMfgMatch.FieldNoText = "N";
            this.ctl_pvDoesPnQtyPriceMfgMatch.FieldYesNo = "pvDoesPnQtyPriceMfgMatch_condition";
            this.ctl_pvDoesPnQtyPriceMfgMatch.FieldYesText = "Y";
            this.ctl_pvDoesPnQtyPriceMfgMatch.IsNA = false;
            this.ctl_pvDoesPnQtyPriceMfgMatch.IsNo = false;
            this.ctl_pvDoesPnQtyPriceMfgMatch.IsYes = true;
            this.ctl_pvDoesPnQtyPriceMfgMatch.Location = new System.Drawing.Point(7, 84);
            this.ctl_pvDoesPnQtyPriceMfgMatch.Name = "ctl_pvDoesPnQtyPriceMfgMatch";
            this.ctl_pvDoesPnQtyPriceMfgMatch.Notes = "";
            this.ctl_pvDoesPnQtyPriceMfgMatch.ShowNA = true;
            this.ctl_pvDoesPnQtyPriceMfgMatch.ShowNotes = true;
            this.ctl_pvDoesPnQtyPriceMfgMatch.Size = new System.Drawing.Size(498, 51);
            this.ctl_pvDoesPnQtyPriceMfgMatch.TabIndex = 14;
            // 
            // ctl_prevalidation_notes
            // 
            this.ctl_prevalidation_notes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_prevalidation_notes.Bold = false;
            this.ctl_prevalidation_notes.Caption = "Pre-Validation Notes";
            this.ctl_prevalidation_notes.Changed = false;
            this.ctl_prevalidation_notes.DateLines = false;
            this.ctl_prevalidation_notes.Location = new System.Drawing.Point(7, 247);
            this.ctl_prevalidation_notes.Name = "ctl_prevalidation_notes";
            this.ctl_prevalidation_notes.Size = new System.Drawing.Size(498, 62);
            this.ctl_prevalidation_notes.TabIndex = 13;
            this.ctl_prevalidation_notes.UseParentBackColor = false;
            this.ctl_prevalidation_notes.zz_Enabled = true;
            this.ctl_prevalidation_notes.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_prevalidation_notes.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_prevalidation_notes.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_prevalidation_notes.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_prevalidation_notes.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_prevalidation_notes.zz_OriginalDesign = true;
            this.ctl_prevalidation_notes.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_prevalidation_notes.zz_ShowNeedsSaveColor = true;
            this.ctl_prevalidation_notes.zz_Text = "";
            this.ctl_prevalidation_notes.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_prevalidation_notes.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_prevalidation_notes.zz_UseGlobalColor = false;
            this.ctl_prevalidation_notes.zz_UseGlobalFont = false;
            // 
            // lblPrevalidationStatus
            // 
            this.lblPrevalidationStatus.AutoSize = true;
            this.lblPrevalidationStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrevalidationStatus.Location = new System.Drawing.Point(16, 25);
            this.lblPrevalidationStatus.Name = "lblPrevalidationStatus";
            this.lblPrevalidationStatus.Size = new System.Drawing.Size(172, 17);
            this.lblPrevalidationStatus.TabIndex = 19;
            this.lblPrevalidationStatus.Text = "Pre-Validation Status: ";
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentStatus.Location = new System.Drawing.Point(125, 5);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(123, 17);
            this.lblCurrentStatus.TabIndex = 20;
            this.lblCurrentStatus.Text = "Current Status: ";
            // 
            // view_validation_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 357);
            this.Controls.Add(this.lblCurrentStatus);
            this.Controls.Add(this.gbPrevalidation);
            this.Controls.Add(this.validations);
            this.Controls.Add(this.lblPreValStatusTitle);
            this.Name = "view_validation_form";
            this.gbPrevalidation.ResumeLayout(false);
            this.gbPrevalidation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPreValStatusTitle;
        private System.Windows.Forms.Button btnSavePreval;
        private NewMethod.nList validations;
        private System.Windows.Forms.GroupBox gbPrevalidation;
        protected InspectionLine ctl_pvDoesShipToMatch;
        protected InspectionLine ctl_pvDockDateRealistic;
        protected InspectionLine ctl_pvDoesPnQtyPriceMfgMatch;
        private NewMethod.nEdit_Memo ctl_prevalidation_notes;
        private System.Windows.Forms.Label lblPrevalidationStatus;
        private System.Windows.Forms.Label lblCurrentStatus;
    }
}
