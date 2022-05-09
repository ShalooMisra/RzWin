namespace NewMethod
{
    partial class SystemView
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
                try
                {
                    xSys.xStructure.xRefresh.Remove(this);
                }
                catch { }

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
            this.lstClasses = new NewMethod.nList();
            this.lstReferencedBy = new NewMethod.nList();
            this.lstReferencing = new NewMethod.nList();
            this.sysline = new NewMethod.SysLine();
            this.lblStructureData = new System.Windows.Forms.LinkLabel();
            this.lblSystemCode = new System.Windows.Forms.LinkLabel();
            this.lblXml = new System.Windows.Forms.LinkLabel();
            this.lblImport = new System.Windows.Forms.LinkLabel();
            this.lblObliterate = new System.Windows.Forms.LinkLabel();
            this.lblImportHere = new System.Windows.Forms.LinkLabel();
            this.lblWriteObjectCode = new System.Windows.Forms.LinkLabel();
            this.lblPasteClasses = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // xHandle
            // 
            this.xHandle.Location = new System.Drawing.Point(925, 0);
            // 
            // lstClasses
            // 
            this.lstClasses.AddCaption = "Add New Class";
            this.lstClasses.AllowActions = true;
            this.lstClasses.AllowAdd = true;
            this.lstClasses.AllowDelete = true;
            this.lstClasses.AllowDeleteAlways = false;
            this.lstClasses.AllowDrop = true;
            this.lstClasses.AlternateConnection = null;
            this.lstClasses.Caption = "Classes";
            this.lstClasses.CurrentTemplate = null;
            this.lstClasses.ExtraClassInfo = "";
            this.lstClasses.Location = new System.Drawing.Point(6, 226);
            this.lstClasses.MultiSelect = true;
            this.lstClasses.Name = "lstClasses";
            this.lstClasses.Size = new System.Drawing.Size(426, 303);
            this.lstClasses.SuppressSelectionChanged = false;
            this.lstClasses.TabIndex = 1;
            this.lstClasses.zz_OpenColumnMenu = false;
            this.lstClasses.zz_ShowAutoRefresh = true;
            this.lstClasses.zz_ShowUnlimited = true;
            this.lstClasses.AboutToThrow += new NewMethod.ThrowHandler(this.lstClasses_AboutToThrow);
            this.lstClasses.AboutToAdd += new NewMethod.AddHandler(this.lstClasses_AboutToAdd);
            this.lstClasses.AboutToDelete += new NewMethod.ActionHandler(this.lstClasses_AboutToDelete);
            // 
            // lstReferencedBy
            // 
            this.lstReferencedBy.AddCaption = "Add New";
            this.lstReferencedBy.AllowActions = true;
            this.lstReferencedBy.AllowAdd = false;
            this.lstReferencedBy.AllowDelete = true;
            this.lstReferencedBy.AllowDeleteAlways = false;
            this.lstReferencedBy.AllowDrop = true;
            this.lstReferencedBy.AlternateConnection = null;
            this.lstReferencedBy.Caption = "Referenced By";
            this.lstReferencedBy.CurrentTemplate = null;
            this.lstReferencedBy.ExtraClassInfo = "";
            this.lstReferencedBy.Location = new System.Drawing.Point(438, 0);
            this.lstReferencedBy.MultiSelect = true;
            this.lstReferencedBy.Name = "lstReferencedBy";
            this.lstReferencedBy.Size = new System.Drawing.Size(523, 228);
            this.lstReferencedBy.SuppressSelectionChanged = false;
            this.lstReferencedBy.TabIndex = 2;
            this.lstReferencedBy.zz_OpenColumnMenu = false;
            this.lstReferencedBy.zz_ShowAutoRefresh = true;
            this.lstReferencedBy.zz_ShowUnlimited = true;
            // 
            // lstReferencing
            // 
            this.lstReferencing.AddCaption = "Add A Reference";
            this.lstReferencing.AllowActions = true;
            this.lstReferencing.AllowAdd = true;
            this.lstReferencing.AllowDelete = true;
            this.lstReferencing.AllowDeleteAlways = false;
            this.lstReferencing.AllowDrop = true;
            this.lstReferencing.AlternateConnection = null;
            this.lstReferencing.Caption = "Referencing";
            this.lstReferencing.CurrentTemplate = null;
            this.lstReferencing.ExtraClassInfo = "";
            this.lstReferencing.Location = new System.Drawing.Point(438, 246);
            this.lstReferencing.MultiSelect = true;
            this.lstReferencing.Name = "lstReferencing";
            this.lstReferencing.Size = new System.Drawing.Size(523, 283);
            this.lstReferencing.SuppressSelectionChanged = false;
            this.lstReferencing.TabIndex = 3;
            this.lstReferencing.zz_OpenColumnMenu = false;
            this.lstReferencing.zz_ShowAutoRefresh = true;
            this.lstReferencing.zz_ShowUnlimited = true;
            // 
            // sysline
            // 
            this.sysline.BackColor = System.Drawing.Color.White;
            this.sysline.Location = new System.Drawing.Point(6, 6);
            this.sysline.Name = "sysline";
            this.sysline.PassiveMode = true;
            this.sysline.Size = new System.Drawing.Size(426, 159);
            this.sysline.TabIndex = 4;
            // 
            // lblStructureData
            // 
            this.lblStructureData.AutoSize = true;
            this.lblStructureData.Location = new System.Drawing.Point(3, 177);
            this.lblStructureData.Name = "lblStructureData";
            this.lblStructureData.Size = new System.Drawing.Size(137, 13);
            this.lblStructureData.TabIndex = 5;
            this.lblStructureData.TabStop = true;
            this.lblStructureData.Text = "Update Structure Database";
            this.lblStructureData.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblStructureData_LinkClicked);
            // 
            // lblSystemCode
            // 
            this.lblSystemCode.AutoSize = true;
            this.lblSystemCode.Location = new System.Drawing.Point(3, 201);
            this.lblSystemCode.Name = "lblSystemCode";
            this.lblSystemCode.Size = new System.Drawing.Size(97, 13);
            this.lblSystemCode.TabIndex = 6;
            this.lblSystemCode.TabStop = true;
            this.lblSystemCode.Text = "Write System Code";
            this.lblSystemCode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSystemCode_LinkClicked);
            // 
            // lblXml
            // 
            this.lblXml.AutoSize = true;
            this.lblXml.Location = new System.Drawing.Point(176, 210);
            this.lblXml.Name = "lblXml";
            this.lblXml.Size = new System.Drawing.Size(52, 13);
            this.lblXml.TabIndex = 7;
            this.lblXml.TabStop = true;
            this.lblXml.Text = "Write Xml";
            this.lblXml.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblXml_LinkClicked);
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.Location = new System.Drawing.Point(261, 188);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(74, 13);
            this.lblImport.TabIndex = 8;
            this.lblImport.TabStop = true;
            this.lblImport.Text = "Import [derive]";
            this.lblImport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblImport_LinkClicked);
            // 
            // lblObliterate
            // 
            this.lblObliterate.AutoSize = true;
            this.lblObliterate.Location = new System.Drawing.Point(350, 177);
            this.lblObliterate.Name = "lblObliterate";
            this.lblObliterate.Size = new System.Drawing.Size(52, 13);
            this.lblObliterate.TabIndex = 9;
            this.lblObliterate.TabStop = true;
            this.lblObliterate.Text = "Obliterate";
            this.lblObliterate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblObliterate_LinkClicked);
            // 
            // lblImportHere
            // 
            this.lblImportHere.AutoSize = true;
            this.lblImportHere.Location = new System.Drawing.Point(261, 210);
            this.lblImportHere.Name = "lblImportHere";
            this.lblImportHere.Size = new System.Drawing.Size(66, 13);
            this.lblImportHere.TabIndex = 10;
            this.lblImportHere.TabStop = true;
            this.lblImportHere.Text = "Import [here]";
            this.lblImportHere.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblImportHere_LinkClicked);
            // 
            // lblWriteObjectCode
            // 
            this.lblWriteObjectCode.AutoSize = true;
            this.lblWriteObjectCode.Location = new System.Drawing.Point(155, 177);
            this.lblWriteObjectCode.Name = "lblWriteObjectCode";
            this.lblWriteObjectCode.Size = new System.Drawing.Size(94, 13);
            this.lblWriteObjectCode.TabIndex = 11;
            this.lblWriteObjectCode.TabStop = true;
            this.lblWriteObjectCode.Text = "Write Object Code";
            this.lblWriteObjectCode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblWriteObjectCode_LinkClicked);
            // 
            // lblPasteClasses
            // 
            this.lblPasteClasses.AutoSize = true;
            this.lblPasteClasses.Location = new System.Drawing.Point(350, 210);
            this.lblPasteClasses.Name = "lblPasteClasses";
            this.lblPasteClasses.Size = new System.Drawing.Size(73, 13);
            this.lblPasteClasses.TabIndex = 12;
            this.lblPasteClasses.TabStop = true;
            this.lblPasteClasses.Text = "Paste Classes";
            this.lblPasteClasses.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPasteClasses_LinkClicked);
            // 
            // SystemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblPasteClasses);
            this.Controls.Add(this.lblWriteObjectCode);
            this.Controls.Add(this.lblImportHere);
            this.Controls.Add(this.lblObliterate);
            this.Controls.Add(this.lblImport);
            this.Controls.Add(this.lblXml);
            this.Controls.Add(this.lblSystemCode);
            this.Controls.Add(this.lblStructureData);
            this.Controls.Add(this.sysline);
            this.Controls.Add(this.lstReferencing);
            this.Controls.Add(this.lstReferencedBy);
            this.Controls.Add(this.lstClasses);
            this.HideSoft = true;
            this.Name = "SystemView";
            this.Size = new System.Drawing.Size(982, 539);
            this.Resize += new System.EventHandler(this.SystemView_Resize);
            this.Controls.SetChildIndex(this.lstClasses, 0);
            this.Controls.SetChildIndex(this.xHandle, 0);
            this.Controls.SetChildIndex(this.lstReferencedBy, 0);
            this.Controls.SetChildIndex(this.lstReferencing, 0);
            this.Controls.SetChildIndex(this.sysline, 0);
            this.Controls.SetChildIndex(this.lblStructureData, 0);
            this.Controls.SetChildIndex(this.lblSystemCode, 0);
            this.Controls.SetChildIndex(this.lblXml, 0);
            this.Controls.SetChildIndex(this.lblImport, 0);
            this.Controls.SetChildIndex(this.lblObliterate, 0);
            this.Controls.SetChildIndex(this.lblImportHere, 0);
            this.Controls.SetChildIndex(this.lblWriteObjectCode, 0);
            this.Controls.SetChildIndex(this.lblPasteClasses, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private nList lstClasses;
        private nList lstReferencedBy;
        private nList lstReferencing;
        private SysLine sysline;
        private System.Windows.Forms.LinkLabel lblStructureData;
        private System.Windows.Forms.LinkLabel lblSystemCode;
        private System.Windows.Forms.LinkLabel lblXml;
        private System.Windows.Forms.LinkLabel lblImport;
        private System.Windows.Forms.LinkLabel lblObliterate;
        private System.Windows.Forms.LinkLabel lblImportHere;
        private System.Windows.Forms.LinkLabel lblWriteObjectCode;
        private System.Windows.Forms.LinkLabel lblPasteClasses;

    }
}
