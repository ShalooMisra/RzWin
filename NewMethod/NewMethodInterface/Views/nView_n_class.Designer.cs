namespace NewMethod
{
    public partial class nView_n_class : nView
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
                try
                {
                    CurrentClass.xRefresh.Remove(this);
                }
                catch { }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nView_n_class));
            this.mnuProp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeleteProp = new System.Windows.Forms.ToolStripMenuItem();
            this.chkNeedsUpdate = new System.Windows.Forms.CheckBox();
            this.ts = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbProp = new System.Windows.Forms.GroupBox();
            this.ctlPropIcon = new NewMethod.IconStub();
            this.ctl_order_index = new NewMethod.nEdit_Number();
            this.ctl_aspect = new NewMethod.nEdit_String();
            this.ctl_vivid = new NewMethod.nEdit_Number();
            this.ctlproperty_use = new NewMethod.nEdit_List();
            this.cmdString = new System.Windows.Forms.Button();
            this.IM16 = new System.Windows.Forms.ImageList(this.components);
            this.cmdRelates = new System.Windows.Forms.Button();
            this.cmdDate = new System.Windows.Forms.Button();
            this.ctl_is_enum = new NewMethod.nEdit_Boolean();
            this.cmdLong = new System.Windows.Forms.Button();
            this.ctl_enum_datatype = new NewMethod.nEdit_List();
            this.cmdInteger = new System.Windows.Forms.Button();
            this.cmdReOrder = new System.Windows.Forms.Button();
            this.cmdBoolean = new System.Windows.Forms.Button();
            this.cmdChangeOrder = new System.Windows.Forms.Button();
            this.cmdMemo = new System.Windows.Forms.Button();
            this.ctl_property_order = new NewMethod.nEdit_Number();
            this.cmdFloat = new System.Windows.Forms.Button();
            this.ctl_property_length = new NewMethod.nEdit_Number();
            this.cmdURL = new System.Windows.Forms.Button();
            this.cmdEmail = new System.Windows.Forms.Button();
            this.ctlproperty_type = new NewMethod.nEdit_List();
            this.label8 = new System.Windows.Forms.Label();
            this.ctl_property_tag = new NewMethod.nEdit_String();
            this.cboChoiceType = new System.Windows.Forms.ComboBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lblChoice = new System.Windows.Forms.LinkLabel();
            this.ctl_name = new NewMethod.nEdit_String();
            this.lblNewChoice = new System.Windows.Forms.LinkLabel();
            this.lblSelectChoice = new System.Windows.Forms.LinkLabel();
            this.ctl_tag_line = new NewMethod.nEdit_String();
            this.cmdUniqueID = new System.Windows.Forms.Button();
            this.cmdBlob = new System.Windows.Forms.Button();
            this.lv = new NewMethod.nList();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbMethod = new System.Windows.Forms.GroupBox();
            this.p_methtop = new System.Windows.Forms.Panel();
            this.ctl_methname = new NewMethod.nEdit_String();
            this.ctl_is_static = new NewMethod.nEdit_Boolean();
            this.ctl_data_type = new NewMethod.nEdit_String();
            this.label10 = new System.Windows.Forms.Label();
            this.ctlaccess_specifier = new NewMethod.nEdit_List();
            this.lvPars = new NewMethod.nList();
            this.p_methbottom = new System.Windows.Forms.Panel();
            this.ctl_user_prompt = new NewMethod.nEdit_String();
            this.ctl_is_optional = new NewMethod.nEdit_Boolean();
            this.ctl_optional_value = new NewMethod.nEdit_String();
            this.ctl_param_name = new NewMethod.nEdit_String();
            this.ctl_by_ref = new NewMethod.nEdit_Boolean();
            this.ctl_param_data_type = new NewMethod.nEdit_String();
            this.cmdNewPar = new System.Windows.Forms.Button();
            this.cmdApply = new System.Windows.Forms.Button();
            this.lvMeths = new NewMethod.nList();
            this.cmdNewMethod = new System.Windows.Forms.Button();
            this.pageClass = new System.Windows.Forms.TabPage();
            this.ctl_explanation = new NewMethod.nEdit_Memo();
            this.pageActions = new System.Windows.Forms.TabPage();
            this.lvActions = new NewMethod.nList();
            this.pageRelationships = new System.Windows.Forms.TabPage();
            this.lstReferencing = new NewMethod.nList();
            this.lstReferencedBy = new NewMethod.nList();
            this.lvDerivedBy = new NewMethod.nList();
            this.lvInheritFrom = new NewMethod.nList();
            this.lblWriteCode = new System.Windows.Forms.LinkLabel();
            this.ctl_is_abstract = new NewMethod.nEdit_Boolean();
            this.cmdSaveClass = new System.Windows.Forms.Button();
            this.ctl_class_tag_line = new NewMethod.nEdit_String();
            this.xIcon = new NewMethod.IconStub();
            this.ctl_class_tag = new NewMethod.nEdit_String();
            this.mnuClass = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRelates = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddParentRelate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddParentRelate_New = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddParentRelate_Existing = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddChildRelate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddChildRelate_New = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddChildRelate_Existing = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddSelfRelate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDerivedClass = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaseClass = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSubscribe = new System.Windows.Forms.ToolStripMenuItem();
            this.tTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbClass = new System.Windows.Forms.GroupBox();
            this.lblCodeCore = new System.Windows.Forms.LinkLabel();
            this.ctl_plural_line = new NewMethod.nEdit_String();
            this.ctl_plural_tag = new NewMethod.nEdit_String();
            this.ctl_class_aspect = new NewMethod.nEdit_String();
            this.ctl_class_vivid = new NewMethod.nEdit_Number();
            this.lblLiveCore = new System.Windows.Forms.LinkLabel();
            this.mnuProp.SuspendLayout();
            this.ts.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbProp.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbMethod.SuspendLayout();
            this.p_methtop.SuspendLayout();
            this.p_methbottom.SuspendLayout();
            this.pageClass.SuspendLayout();
            this.pageActions.SuspendLayout();
            this.pageRelationships.SuspendLayout();
            this.mnuClass.SuspendLayout();
            this.gbClass.SuspendLayout();
            this.SuspendLayout();
            // 
            // xHandle
            // 
            this.xHandle.Location = new System.Drawing.Point(1058, 0);
            // 
            // mnuProp
            // 
            this.mnuProp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCut,
            this.mnuCopy,
            this.mnuPaste,
            this.toolStripSeparator1,
            this.mnuDeleteProp});
            this.mnuProp.Name = "mnuProp";
            this.mnuProp.Size = new System.Drawing.Size(117, 98);
            // 
            // mnuCut
            // 
            this.mnuCut.Name = "mnuCut";
            this.mnuCut.Size = new System.Drawing.Size(116, 22);
            this.mnuCut.Text = "&Cut";
            this.mnuCut.Click += new System.EventHandler(this.mnuCut_Click);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.Size = new System.Drawing.Size(116, 22);
            this.mnuCopy.Text = "&Copy";
            this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
            // 
            // mnuPaste
            // 
            this.mnuPaste.Name = "mnuPaste";
            this.mnuPaste.Size = new System.Drawing.Size(116, 22);
            this.mnuPaste.Text = "&Paste";
            this.mnuPaste.Click += new System.EventHandler(this.mnuPaste_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // mnuDeleteProp
            // 
            this.mnuDeleteProp.Name = "mnuDeleteProp";
            this.mnuDeleteProp.Size = new System.Drawing.Size(116, 22);
            this.mnuDeleteProp.Text = "&Delete";
            this.mnuDeleteProp.Click += new System.EventHandler(this.mnuDeleteProp_Click);
            // 
            // chkNeedsUpdate
            // 
            this.chkNeedsUpdate.AutoSize = true;
            this.chkNeedsUpdate.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNeedsUpdate.Location = new System.Drawing.Point(531, 20);
            this.chkNeedsUpdate.Name = "chkNeedsUpdate";
            this.chkNeedsUpdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkNeedsUpdate.Size = new System.Drawing.Size(89, 18);
            this.chkNeedsUpdate.TabIndex = 80;
            this.chkNeedsUpdate.Text = "Needs Update";
            this.chkNeedsUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNeedsUpdate.UseVisualStyleBackColor = true;
            // 
            // ts
            // 
            this.ts.Controls.Add(this.tabPage1);
            this.ts.Controls.Add(this.tabPage2);
            this.ts.Controls.Add(this.pageClass);
            this.ts.Controls.Add(this.pageActions);
            this.ts.Controls.Add(this.pageRelationships);
            this.ts.Location = new System.Drawing.Point(3, 169);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(804, 665);
            this.ts.TabIndex = 93;
            this.ts.SelectedIndexChanged += new System.EventHandler(this.ts_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbProp);
            this.tabPage1.Controls.Add(this.lv);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(796, 638);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Properties";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbProp
            // 
            this.gbProp.Controls.Add(this.ctlPropIcon);
            this.gbProp.Controls.Add(this.ctl_order_index);
            this.gbProp.Controls.Add(this.ctl_aspect);
            this.gbProp.Controls.Add(this.ctl_vivid);
            this.gbProp.Controls.Add(this.ctlproperty_use);
            this.gbProp.Controls.Add(this.cmdString);
            this.gbProp.Controls.Add(this.cmdRelates);
            this.gbProp.Controls.Add(this.cmdDate);
            this.gbProp.Controls.Add(this.ctl_is_enum);
            this.gbProp.Controls.Add(this.cmdLong);
            this.gbProp.Controls.Add(this.ctl_enum_datatype);
            this.gbProp.Controls.Add(this.cmdInteger);
            this.gbProp.Controls.Add(this.cmdReOrder);
            this.gbProp.Controls.Add(this.cmdBoolean);
            this.gbProp.Controls.Add(this.cmdChangeOrder);
            this.gbProp.Controls.Add(this.cmdMemo);
            this.gbProp.Controls.Add(this.ctl_property_order);
            this.gbProp.Controls.Add(this.cmdFloat);
            this.gbProp.Controls.Add(this.ctl_property_length);
            this.gbProp.Controls.Add(this.cmdURL);
            this.gbProp.Controls.Add(this.cmdEmail);
            this.gbProp.Controls.Add(this.ctlproperty_type);
            this.gbProp.Controls.Add(this.label8);
            this.gbProp.Controls.Add(this.ctl_property_tag);
            this.gbProp.Controls.Add(this.cboChoiceType);
            this.gbProp.Controls.Add(this.cmdSave);
            this.gbProp.Controls.Add(this.lblChoice);
            this.gbProp.Controls.Add(this.ctl_name);
            this.gbProp.Controls.Add(this.lblNewChoice);
            this.gbProp.Controls.Add(this.lblSelectChoice);
            this.gbProp.Controls.Add(this.ctl_tag_line);
            this.gbProp.Controls.Add(this.cmdUniqueID);
            this.gbProp.Controls.Add(this.cmdBlob);
            this.gbProp.Location = new System.Drawing.Point(6, 6);
            this.gbProp.Name = "gbProp";
            this.gbProp.Size = new System.Drawing.Size(394, 410);
            this.gbProp.TabIndex = 140;
            this.gbProp.TabStop = false;
            this.gbProp.Enter += new System.EventHandler(this.gbProp_Enter);
            // 
            // ctlPropIcon
            // 
            this.ctlPropIcon.BackColor = System.Drawing.Color.Transparent;
            this.ctlPropIcon.Location = new System.Drawing.Point(208, 282);
            this.ctlPropIcon.Name = "ctlPropIcon";
            this.ctlPropIcon.Size = new System.Drawing.Size(179, 35);
            this.ctlPropIcon.TabIndex = 83;
            // 
            // ctl_order_index
            // 
            this.ctl_order_index.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_order_index.Bold = false;
            this.ctl_order_index.Caption = "Sort Index";
            this.ctl_order_index.Changed = false;
            this.ctl_order_index.CurrentType = NewMethod.Enums.DataType.Any;
            this.ctl_order_index.Location = new System.Drawing.Point(315, 197);
            this.ctl_order_index.Name = "ctl_order_index";
            this.ctl_order_index.Size = new System.Drawing.Size(74, 36);
            this.ctl_order_index.TabIndex = 141;
            this.ctl_order_index.UseParentBackColor = false;
            this.ctl_order_index.zz_Enabled = true;
            this.ctl_order_index.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_order_index.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_order_index.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_order_index.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_order_index.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_order_index.zz_OriginalDesign = false;
            this.ctl_order_index.zz_ShowErrorColor = true;
            this.ctl_order_index.zz_ShowNeedsSaveColor = true;
            this.ctl_order_index.zz_Text = "";
            this.ctl_order_index.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_order_index.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_order_index.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_order_index.zz_UseGlobalColor = false;
            this.ctl_order_index.zz_UseGlobalFont = false;
            // 
            // ctl_aspect
            // 
            this.ctl_aspect.AllCaps = false;
            this.ctl_aspect.BackColor = System.Drawing.Color.Transparent;
            this.ctl_aspect.Bold = false;
            this.ctl_aspect.Caption = "Aspect";
            this.ctl_aspect.Changed = false;
            this.ctl_aspect.IsEmail = false;
            this.ctl_aspect.IsURL = false;
            this.ctl_aspect.Location = new System.Drawing.Point(10, 197);
            this.ctl_aspect.Name = "ctl_aspect";
            this.ctl_aspect.PasswordChar = '\0';
            this.ctl_aspect.Size = new System.Drawing.Size(174, 36);
            this.ctl_aspect.TabIndex = 83;
            this.ctl_aspect.UseParentBackColor = true;
            this.ctl_aspect.zz_Enabled = true;
            this.ctl_aspect.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_aspect.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_aspect.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_aspect.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_aspect.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_aspect.zz_OriginalDesign = false;
            this.ctl_aspect.zz_ShowLinkButton = false;
            this.ctl_aspect.zz_ShowNeedsSaveColor = true;
            this.ctl_aspect.zz_Text = "";
            this.ctl_aspect.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_aspect.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_aspect.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_aspect.zz_UseGlobalColor = false;
            this.ctl_aspect.zz_UseGlobalFont = false;
            this.ctl_aspect.Load += new System.EventHandler(this.ctl_prop_aspect_Load);
            // 
            // ctl_vivid
            // 
            this.ctl_vivid.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_vivid.Bold = false;
            this.ctl_vivid.Caption = "Vivid";
            this.ctl_vivid.Changed = false;
            this.ctl_vivid.CurrentType = NewMethod.Enums.DataType.Any;
            this.ctl_vivid.Location = new System.Drawing.Point(201, 197);
            this.ctl_vivid.Name = "ctl_vivid";
            this.ctl_vivid.Size = new System.Drawing.Size(106, 36);
            this.ctl_vivid.TabIndex = 140;
            this.ctl_vivid.UseParentBackColor = false;
            this.ctl_vivid.zz_Enabled = true;
            this.ctl_vivid.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_vivid.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_vivid.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_vivid.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_vivid.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_vivid.zz_OriginalDesign = false;
            this.ctl_vivid.zz_ShowErrorColor = true;
            this.ctl_vivid.zz_ShowNeedsSaveColor = true;
            this.ctl_vivid.zz_Text = "";
            this.ctl_vivid.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_vivid.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_vivid.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_vivid.zz_UseGlobalColor = false;
            this.ctl_vivid.zz_UseGlobalFont = false;
            // 
            // ctlproperty_use
            // 
            this.ctlproperty_use.AllCaps = false;
            this.ctlproperty_use.AllowEdit = false;
            this.ctlproperty_use.BackColor = System.Drawing.Color.Transparent;
            this.ctlproperty_use.Bold = false;
            this.ctlproperty_use.Caption = "Use";
            this.ctlproperty_use.Changed = false;
            this.ctlproperty_use.ListName = null;
            this.ctlproperty_use.Location = new System.Drawing.Point(201, 153);
            this.ctlproperty_use.Name = "ctlproperty_use";
            this.ctlproperty_use.SimpleList = "Any|TableSplit|Email|Phone|Url|List|PersonName|FirstName|LastName|Password|RoundM" +
                "oney|FractionMoney";
            this.ctlproperty_use.Size = new System.Drawing.Size(188, 38);
            this.ctlproperty_use.TabIndex = 132;
            this.ctlproperty_use.UseParentBackColor = false;
            this.ctlproperty_use.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlproperty_use.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlproperty_use.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlproperty_use.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlproperty_use.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctlproperty_use.zz_OriginalDesign = false;
            this.ctlproperty_use.zz_ShowNeedsSaveColor = true;
            this.ctlproperty_use.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlproperty_use.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlproperty_use.zz_UseGlobalColor = false;
            this.ctlproperty_use.zz_UseGlobalFont = false;
            // 
            // cmdString
            // 
            this.cmdString.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdString.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdString.ImageKey = "string";
            this.cmdString.ImageList = this.IM16;
            this.cmdString.Location = new System.Drawing.Point(6, 9);
            this.cmdString.Name = "cmdString";
            this.cmdString.Size = new System.Drawing.Size(91, 24);
            this.cmdString.TabIndex = 98;
            this.cmdString.Text = "String";
            this.cmdString.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdString.UseVisualStyleBackColor = true;
            this.cmdString.Click += new System.EventHandler(this.cmdString_Click);
            // 
            // IM16
            // 
            this.IM16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IM16.ImageStream")));
            this.IM16.TransparentColor = System.Drawing.Color.Fuchsia;
            this.IM16.Images.SetKeyName(0, "boolean");
            this.IM16.Images.SetKeyName(1, "string");
            this.IM16.Images.SetKeyName(2, "datetime");
            this.IM16.Images.SetKeyName(3, "float");
            this.IM16.Images.SetKeyName(4, "blob");
            this.IM16.Images.SetKeyName(5, "url");
            this.IM16.Images.SetKeyName(6, "uniqueid");
            this.IM16.Images.SetKeyName(7, "email");
            this.IM16.Images.SetKeyName(8, "long");
            this.IM16.Images.SetKeyName(9, "integer");
            this.IM16.Images.SetKeyName(10, "save");
            this.IM16.Images.SetKeyName(11, "memo");
            this.IM16.Images.SetKeyName(12, "relates");
            this.IM16.Images.SetKeyName(13, "method");
            this.IM16.Images.SetKeyName(14, "prop");
            this.IM16.Images.SetKeyName(15, "apply");
            // 
            // cmdRelates
            // 
            this.cmdRelates.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRelates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRelates.ImageKey = "relates";
            this.cmdRelates.ImageList = this.IM16;
            this.cmdRelates.Location = new System.Drawing.Point(297, 39);
            this.cmdRelates.Name = "cmdRelates";
            this.cmdRelates.Size = new System.Drawing.Size(91, 24);
            this.cmdRelates.TabIndex = 139;
            this.cmdRelates.Text = "Relates";
            this.tTip1.SetToolTip(this.cmdRelates, "Add Relationship");
            this.cmdRelates.UseVisualStyleBackColor = true;
            this.cmdRelates.Click += new System.EventHandler(this.cmdRelates_Click);
            // 
            // cmdDate
            // 
            this.cmdDate.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDate.ImageKey = "datetime";
            this.cmdDate.ImageList = this.IM16;
            this.cmdDate.Location = new System.Drawing.Point(103, 69);
            this.cmdDate.Name = "cmdDate";
            this.cmdDate.Size = new System.Drawing.Size(91, 24);
            this.cmdDate.TabIndex = 100;
            this.cmdDate.Text = "DateTime";
            this.cmdDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdDate.UseVisualStyleBackColor = true;
            this.cmdDate.Click += new System.EventHandler(this.cmdDate_Click);
            // 
            // ctl_is_enum
            // 
            this.ctl_is_enum.BackColor = System.Drawing.Color.Transparent;
            this.ctl_is_enum.Bold = false;
            this.ctl_is_enum.Caption = "Enum";
            this.ctl_is_enum.Changed = false;
            this.ctl_is_enum.Location = new System.Drawing.Point(135, 149);
            this.ctl_is_enum.Name = "ctl_is_enum";
            this.ctl_is_enum.Size = new System.Drawing.Size(53, 18);
            this.ctl_is_enum.TabIndex = 136;
            this.ctl_is_enum.UseParentBackColor = false;
            this.ctl_is_enum.Visible = false;
            this.ctl_is_enum.zz_CheckValue = false;
            this.ctl_is_enum.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_enum.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_is_enum.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Left;
            this.ctl_is_enum.zz_OriginalDesign = false;
            this.ctl_is_enum.zz_ShowNeedsSaveColor = true;
            this.ctl_is_enum.CheckChanged += new NewMethod.CheckChangedHandler(this.ctl_is_enum_CheckChanged);
            // 
            // cmdLong
            // 
            this.cmdLong.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLong.ImageKey = "integer";
            this.cmdLong.ImageList = this.IM16;
            this.cmdLong.Location = new System.Drawing.Point(103, 39);
            this.cmdLong.Name = "cmdLong";
            this.cmdLong.Size = new System.Drawing.Size(91, 24);
            this.cmdLong.TabIndex = 99;
            this.cmdLong.Text = "Long [64]";
            this.cmdLong.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdLong.UseVisualStyleBackColor = true;
            this.cmdLong.Click += new System.EventHandler(this.cmdLong_Click);
            // 
            // ctl_enum_datatype
            // 
            this.ctl_enum_datatype.AllCaps = false;
            this.ctl_enum_datatype.AllowEdit = true;
            this.ctl_enum_datatype.BackColor = System.Drawing.Color.Transparent;
            this.ctl_enum_datatype.Bold = false;
            this.ctl_enum_datatype.Caption = "Enum DataType";
            this.ctl_enum_datatype.Changed = false;
            this.ctl_enum_datatype.Enabled = false;
            this.ctl_enum_datatype.ListName = "enum_datatypes";
            this.ctl_enum_datatype.Location = new System.Drawing.Point(7, 365);
            this.ctl_enum_datatype.Name = "ctl_enum_datatype";
            this.ctl_enum_datatype.SimpleList = null;
            this.ctl_enum_datatype.Size = new System.Drawing.Size(168, 38);
            this.ctl_enum_datatype.TabIndex = 135;
            this.ctl_enum_datatype.UseParentBackColor = false;
            this.ctl_enum_datatype.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_enum_datatype.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_enum_datatype.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_enum_datatype.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_enum_datatype.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_enum_datatype.zz_OriginalDesign = false;
            this.ctl_enum_datatype.zz_ShowNeedsSaveColor = true;
            this.ctl_enum_datatype.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_enum_datatype.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_enum_datatype.zz_UseGlobalColor = false;
            this.ctl_enum_datatype.zz_UseGlobalFont = false;
            // 
            // cmdInteger
            // 
            this.cmdInteger.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInteger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdInteger.ImageKey = "integer";
            this.cmdInteger.ImageList = this.IM16;
            this.cmdInteger.Location = new System.Drawing.Point(8, 39);
            this.cmdInteger.Name = "cmdInteger";
            this.cmdInteger.Size = new System.Drawing.Size(89, 24);
            this.cmdInteger.TabIndex = 101;
            this.cmdInteger.Text = "Int [32]";
            this.cmdInteger.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdInteger.UseVisualStyleBackColor = true;
            this.cmdInteger.Click += new System.EventHandler(this.cmdInteger_Click);
            // 
            // cmdReOrder
            // 
            this.cmdReOrder.Location = new System.Drawing.Point(171, 277);
            this.cmdReOrder.Name = "cmdReOrder";
            this.cmdReOrder.Size = new System.Drawing.Size(24, 19);
            this.cmdReOrder.TabIndex = 123;
            this.cmdReOrder.Text = "R";
            this.tTip1.SetToolTip(this.cmdReOrder, "Re-Order");
            this.cmdReOrder.UseVisualStyleBackColor = true;
            this.cmdReOrder.Click += new System.EventHandler(this.cmdReOrder_Click);
            // 
            // cmdBoolean
            // 
            this.cmdBoolean.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBoolean.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBoolean.ImageKey = "boolean";
            this.cmdBoolean.ImageList = this.IM16;
            this.cmdBoolean.Location = new System.Drawing.Point(8, 69);
            this.cmdBoolean.Name = "cmdBoolean";
            this.cmdBoolean.Size = new System.Drawing.Size(89, 24);
            this.cmdBoolean.TabIndex = 104;
            this.cmdBoolean.Text = "Bool";
            this.cmdBoolean.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdBoolean.UseVisualStyleBackColor = true;
            this.cmdBoolean.Click += new System.EventHandler(this.cmdBoolean_Click);
            // 
            // cmdChangeOrder
            // 
            this.cmdChangeOrder.Location = new System.Drawing.Point(146, 277);
            this.cmdChangeOrder.Name = "cmdChangeOrder";
            this.cmdChangeOrder.Size = new System.Drawing.Size(24, 19);
            this.cmdChangeOrder.TabIndex = 116;
            this.cmdChangeOrder.Text = "...";
            this.tTip1.SetToolTip(this.cmdChangeOrder, "Change Order");
            this.cmdChangeOrder.UseVisualStyleBackColor = true;
            this.cmdChangeOrder.Click += new System.EventHandler(this.cmdChangeOrder_Click);
            // 
            // cmdMemo
            // 
            this.cmdMemo.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMemo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdMemo.ImageKey = "memo";
            this.cmdMemo.ImageList = this.IM16;
            this.cmdMemo.Location = new System.Drawing.Point(103, 9);
            this.cmdMemo.Name = "cmdMemo";
            this.cmdMemo.Size = new System.Drawing.Size(91, 24);
            this.cmdMemo.TabIndex = 103;
            this.cmdMemo.Text = "Memo";
            this.cmdMemo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdMemo.UseVisualStyleBackColor = true;
            this.cmdMemo.Click += new System.EventHandler(this.cmdMemo_Click);
            // 
            // ctl_property_order
            // 
            this.ctl_property_order.BackColor = System.Drawing.Color.Transparent;
            this.ctl_property_order.Bold = false;
            this.ctl_property_order.Caption = "Order";
            this.ctl_property_order.Changed = false;
            this.ctl_property_order.CurrentType = NewMethod.Enums.DataType.Any;
            this.ctl_property_order.Location = new System.Drawing.Point(92, 281);
            this.ctl_property_order.Name = "ctl_property_order";
            this.ctl_property_order.Size = new System.Drawing.Size(102, 36);
            this.ctl_property_order.TabIndex = 134;
            this.ctl_property_order.UseParentBackColor = false;
            this.ctl_property_order.zz_Enabled = false;
            this.ctl_property_order.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_property_order.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_property_order.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_property_order.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_property_order.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_property_order.zz_OriginalDesign = false;
            this.ctl_property_order.zz_ShowErrorColor = true;
            this.ctl_property_order.zz_ShowNeedsSaveColor = true;
            this.ctl_property_order.zz_Text = "";
            this.ctl_property_order.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_property_order.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_property_order.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_property_order.zz_UseGlobalColor = false;
            this.ctl_property_order.zz_UseGlobalFont = false;
            // 
            // cmdFloat
            // 
            this.cmdFloat.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFloat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdFloat.ImageKey = "float";
            this.cmdFloat.ImageList = this.IM16;
            this.cmdFloat.Location = new System.Drawing.Point(200, 39);
            this.cmdFloat.Name = "cmdFloat";
            this.cmdFloat.Size = new System.Drawing.Size(91, 24);
            this.cmdFloat.TabIndex = 111;
            this.cmdFloat.Text = "Float";
            this.cmdFloat.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdFloat.UseVisualStyleBackColor = true;
            this.cmdFloat.Click += new System.EventHandler(this.cmdFloat_Click);
            // 
            // ctl_property_length
            // 
            this.ctl_property_length.BackColor = System.Drawing.Color.Transparent;
            this.ctl_property_length.Bold = false;
            this.ctl_property_length.Caption = "Length";
            this.ctl_property_length.Changed = false;
            this.ctl_property_length.CurrentType = NewMethod.Enums.DataType.Any;
            this.ctl_property_length.Location = new System.Drawing.Point(8, 281);
            this.ctl_property_length.Name = "ctl_property_length";
            this.ctl_property_length.Size = new System.Drawing.Size(78, 36);
            this.ctl_property_length.TabIndex = 133;
            this.ctl_property_length.UseParentBackColor = false;
            this.ctl_property_length.zz_Enabled = true;
            this.ctl_property_length.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_property_length.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_property_length.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_property_length.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_property_length.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_property_length.zz_OriginalDesign = false;
            this.ctl_property_length.zz_ShowErrorColor = true;
            this.ctl_property_length.zz_ShowNeedsSaveColor = true;
            this.ctl_property_length.zz_Text = "";
            this.ctl_property_length.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_property_length.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_property_length.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_property_length.zz_UseGlobalColor = false;
            this.ctl_property_length.zz_UseGlobalFont = false;
            // 
            // cmdURL
            // 
            this.cmdURL.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdURL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdURL.ImageKey = "url";
            this.cmdURL.ImageList = this.IM16;
            this.cmdURL.Location = new System.Drawing.Point(297, 9);
            this.cmdURL.Name = "cmdURL";
            this.cmdURL.Size = new System.Drawing.Size(91, 24);
            this.cmdURL.TabIndex = 112;
            this.cmdURL.Text = "URL";
            this.cmdURL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdURL.UseVisualStyleBackColor = true;
            this.cmdURL.Click += new System.EventHandler(this.cmdURL_Click);
            // 
            // cmdEmail
            // 
            this.cmdEmail.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEmail.ImageKey = "email";
            this.cmdEmail.ImageList = this.IM16;
            this.cmdEmail.Location = new System.Drawing.Point(200, 9);
            this.cmdEmail.Name = "cmdEmail";
            this.cmdEmail.Size = new System.Drawing.Size(91, 24);
            this.cmdEmail.TabIndex = 113;
            this.cmdEmail.Text = "Email";
            this.cmdEmail.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdEmail.UseVisualStyleBackColor = true;
            this.cmdEmail.Click += new System.EventHandler(this.cmdEmail_Click);
            // 
            // ctlproperty_type
            // 
            this.ctlproperty_type.AllCaps = false;
            this.ctlproperty_type.AllowEdit = false;
            this.ctlproperty_type.BackColor = System.Drawing.Color.Transparent;
            this.ctlproperty_type.Bold = false;
            this.ctlproperty_type.Caption = "PropertyType";
            this.ctlproperty_type.Changed = false;
            this.ctlproperty_type.ListName = null;
            this.ctlproperty_type.Location = new System.Drawing.Point(9, 153);
            this.ctlproperty_type.Name = "ctlproperty_type";
            this.ctlproperty_type.SimpleList = "Unknown|Any|String|Integer|Long|Float|Date|Boolean|Memo|List|Picture|Document|Obj" +
                "ect|Blob";
            this.ctlproperty_type.Size = new System.Drawing.Size(175, 38);
            this.ctlproperty_type.TabIndex = 131;
            this.ctlproperty_type.UseParentBackColor = false;
            this.ctlproperty_type.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlproperty_type.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlproperty_type.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlproperty_type.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlproperty_type.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctlproperty_type.zz_OriginalDesign = false;
            this.ctlproperty_type.zz_ShowNeedsSaveColor = true;
            this.ctlproperty_type.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlproperty_type.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlproperty_type.zz_UseGlobalColor = false;
            this.ctlproperty_type.zz_UseGlobalFont = false;
            this.ctlproperty_type.SelectionChanged += new NewMethod.nEdit_List.SelectionChangedHandler(this.ctlproperty_type_SelectionChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 14);
            this.label8.TabIndex = 118;
            this.label8.Text = "Choice Type";
            // 
            // ctl_property_tag
            // 
            this.ctl_property_tag.AllCaps = false;
            this.ctl_property_tag.BackColor = System.Drawing.Color.Transparent;
            this.ctl_property_tag.Bold = false;
            this.ctl_property_tag.Caption = "PropertyTag";
            this.ctl_property_tag.Changed = false;
            this.ctl_property_tag.IsEmail = false;
            this.ctl_property_tag.IsURL = false;
            this.ctl_property_tag.Location = new System.Drawing.Point(17, 126);
            this.ctl_property_tag.Name = "ctl_property_tag";
            this.ctl_property_tag.PasswordChar = '\0';
            this.ctl_property_tag.Size = new System.Drawing.Size(371, 21);
            this.ctl_property_tag.TabIndex = 130;
            this.ctl_property_tag.UseParentBackColor = false;
            this.ctl_property_tag.zz_Enabled = true;
            this.ctl_property_tag.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_property_tag.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_property_tag.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_property_tag.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_property_tag.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctl_property_tag.zz_OriginalDesign = false;
            this.ctl_property_tag.zz_ShowLinkButton = false;
            this.ctl_property_tag.zz_ShowNeedsSaveColor = true;
            this.ctl_property_tag.zz_Text = "";
            this.ctl_property_tag.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_property_tag.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_property_tag.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_property_tag.zz_UseGlobalColor = false;
            this.ctl_property_tag.zz_UseGlobalFont = false;
            // 
            // cboChoiceType
            // 
            this.cboChoiceType.FormattingEnabled = true;
            this.cboChoiceType.Items.AddRange(new object[] {
            "None",
            "FreeType",
            "SelectOnly",
            "MustSelect"});
            this.cboChoiceType.Location = new System.Drawing.Point(10, 253);
            this.cboChoiceType.Name = "cboChoiceType";
            this.cboChoiceType.Size = new System.Drawing.Size(379, 22);
            this.cboChoiceType.TabIndex = 117;
            this.cboChoiceType.Text = "None";
            this.cboChoiceType.SelectedIndexChanged += new System.EventHandler(this.cboChoiceType_SelectedIndexChanged_1);
            this.cboChoiceType.TextChanged += new System.EventHandler(this.cboChoiceType_TextChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.ImageKey = "save";
            this.cmdSave.ImageList = this.IM16;
            this.cmdSave.Location = new System.Drawing.Point(234, 365);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(127, 38);
            this.cmdSave.TabIndex = 97;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lblChoice
            // 
            this.lblChoice.Location = new System.Drawing.Point(130, 236);
            this.lblChoice.Name = "lblChoice";
            this.lblChoice.Size = new System.Drawing.Size(48, 14);
            this.lblChoice.TabIndex = 119;
            this.lblChoice.TabStop = true;
            this.lblChoice.Text = "<Show>";
            this.lblChoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tTip1.SetToolTip(this.lblChoice, "Show Selected Choices List");
            this.lblChoice.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChoice_LinkClicked);
            // 
            // ctl_name
            // 
            this.ctl_name.AllCaps = false;
            this.ctl_name.BackColor = System.Drawing.Color.Transparent;
            this.ctl_name.Bold = false;
            this.ctl_name.Caption = "PropertyName";
            this.ctl_name.Changed = false;
            this.ctl_name.IsEmail = false;
            this.ctl_name.IsURL = false;
            this.ctl_name.Location = new System.Drawing.Point(8, 99);
            this.ctl_name.Name = "ctl_name";
            this.ctl_name.PasswordChar = '\0';
            this.ctl_name.Size = new System.Drawing.Size(380, 21);
            this.ctl_name.TabIndex = 129;
            this.ctl_name.UseParentBackColor = false;
            this.ctl_name.zz_Enabled = true;
            this.ctl_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_name.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_name.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_name.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctl_name.zz_OriginalDesign = false;
            this.ctl_name.zz_ShowLinkButton = false;
            this.ctl_name.zz_ShowNeedsSaveColor = true;
            this.ctl_name.zz_Text = "";
            this.ctl_name.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_name.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_name.zz_UseGlobalColor = false;
            this.ctl_name.zz_UseGlobalFont = false;
            this.ctl_name.zz_GotKeyUp += new NewMethod.GotKeyUpHandler(this.ctl_name_zz_GotKeyUp);
            // 
            // lblNewChoice
            // 
            this.lblNewChoice.AutoSize = true;
            this.lblNewChoice.Location = new System.Drawing.Point(177, 236);
            this.lblNewChoice.Name = "lblNewChoice";
            this.lblNewChoice.Size = new System.Drawing.Size(39, 14);
            this.lblNewChoice.TabIndex = 120;
            this.lblNewChoice.TabStop = true;
            this.lblNewChoice.Text = "<New>";
            this.lblNewChoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tTip1.SetToolTip(this.lblNewChoice, "Create New Choices List");
            this.lblNewChoice.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNewChoice_LinkClicked);
            // 
            // lblSelectChoice
            // 
            this.lblSelectChoice.AutoSize = true;
            this.lblSelectChoice.Location = new System.Drawing.Point(214, 236);
            this.lblSelectChoice.Name = "lblSelectChoice";
            this.lblSelectChoice.Size = new System.Drawing.Size(46, 14);
            this.lblSelectChoice.TabIndex = 121;
            this.lblSelectChoice.TabStop = true;
            this.lblSelectChoice.Text = "<Select>";
            this.lblSelectChoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tTip1.SetToolTip(this.lblSelectChoice, "Select Existing Choices List");
            this.lblSelectChoice.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSelectChoice_LinkClicked);
            // 
            // ctl_tag_line
            // 
            this.ctl_tag_line.AllCaps = false;
            this.ctl_tag_line.BackColor = System.Drawing.Color.Transparent;
            this.ctl_tag_line.Bold = false;
            this.ctl_tag_line.Caption = "Tag Line";
            this.ctl_tag_line.Changed = false;
            this.ctl_tag_line.IsEmail = false;
            this.ctl_tag_line.IsURL = false;
            this.ctl_tag_line.Location = new System.Drawing.Point(7, 323);
            this.ctl_tag_line.Name = "ctl_tag_line";
            this.ctl_tag_line.PasswordChar = '\0';
            this.ctl_tag_line.Size = new System.Drawing.Size(380, 36);
            this.ctl_tag_line.TabIndex = 126;
            this.ctl_tag_line.UseParentBackColor = true;
            this.ctl_tag_line.zz_Enabled = true;
            this.ctl_tag_line.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_tag_line.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_tag_line.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_tag_line.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_tag_line.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_tag_line.zz_OriginalDesign = false;
            this.ctl_tag_line.zz_ShowLinkButton = false;
            this.ctl_tag_line.zz_ShowNeedsSaveColor = true;
            this.ctl_tag_line.zz_Text = "";
            this.ctl_tag_line.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_tag_line.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_tag_line.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_tag_line.zz_UseGlobalColor = false;
            this.ctl_tag_line.zz_UseGlobalFont = false;
            // 
            // cmdUniqueID
            // 
            this.cmdUniqueID.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUniqueID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUniqueID.ImageKey = "uniqueid";
            this.cmdUniqueID.ImageList = this.IM16;
            this.cmdUniqueID.Location = new System.Drawing.Point(200, 69);
            this.cmdUniqueID.Name = "cmdUniqueID";
            this.cmdUniqueID.Size = new System.Drawing.Size(91, 24);
            this.cmdUniqueID.TabIndex = 124;
            this.cmdUniqueID.Text = "UID";
            this.tTip1.SetToolTip(this.cmdUniqueID, "Add unqiue_id property.");
            this.cmdUniqueID.UseVisualStyleBackColor = true;
            this.cmdUniqueID.Click += new System.EventHandler(this.cmdUniqueID_Click);
            // 
            // cmdBlob
            // 
            this.cmdBlob.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBlob.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBlob.ImageKey = "blob";
            this.cmdBlob.ImageList = this.IM16;
            this.cmdBlob.Location = new System.Drawing.Point(297, 69);
            this.cmdBlob.Name = "cmdBlob";
            this.cmdBlob.Size = new System.Drawing.Size(91, 24);
            this.cmdBlob.TabIndex = 125;
            this.cmdBlob.Text = "Image";
            this.cmdBlob.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdBlob.UseVisualStyleBackColor = true;
            this.cmdBlob.Click += new System.EventHandler(this.cmdBlob_Click);
            // 
            // lv
            // 
            this.lv.AddCaption = "Add New";
            this.lv.AllowActions = true;
            this.lv.AllowAdd = false;
            this.lv.AllowDelete = true;
            this.lv.AllowDeleteAlways = false;
            this.lv.AllowDrop = true;
            this.lv.AlternateConnection = null;
            this.lv.Caption = "Props";
            this.lv.ContextMenuStrip = this.mnuProp;
            this.lv.CurrentTemplate = null;
            this.lv.ExtraClassInfo = "";
            this.lv.Location = new System.Drawing.Point(450, 6);
            this.lv.MultiSelect = true;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(235, 435);
            this.lv.SuppressSelectionChanged = false;
            this.lv.TabIndex = 127;
            this.lv.zz_OpenColumnMenu = false;
            this.lv.zz_ShowAutoRefresh = true;
            this.lv.zz_ShowUnlimited = true;
            this.lv.ObjectClicked += new NewMethod.ObjectClickHandler(this.lv_ObjectClicked);
            this.lv.FinishedFill += new NewMethod.FillHandler(this.lv_FinishedFill);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gbMethod);
            this.tabPage2.Controls.Add(this.lvMeths);
            this.tabPage2.Controls.Add(this.cmdNewMethod);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(796, 638);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Methods";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gbMethod
            // 
            this.gbMethod.Controls.Add(this.p_methtop);
            this.gbMethod.Controls.Add(this.lvPars);
            this.gbMethod.Controls.Add(this.p_methbottom);
            this.gbMethod.Location = new System.Drawing.Point(305, 3);
            this.gbMethod.Name = "gbMethod";
            this.gbMethod.Size = new System.Drawing.Size(390, 573);
            this.gbMethod.TabIndex = 125;
            this.gbMethod.TabStop = false;
            // 
            // p_methtop
            // 
            this.p_methtop.Controls.Add(this.ctl_methname);
            this.p_methtop.Controls.Add(this.ctl_is_static);
            this.p_methtop.Controls.Add(this.ctl_data_type);
            this.p_methtop.Controls.Add(this.label10);
            this.p_methtop.Controls.Add(this.ctlaccess_specifier);
            this.p_methtop.Location = new System.Drawing.Point(2, 9);
            this.p_methtop.Name = "p_methtop";
            this.p_methtop.Size = new System.Drawing.Size(385, 93);
            this.p_methtop.TabIndex = 147;
            // 
            // ctl_methname
            // 
            this.ctl_methname.AllCaps = false;
            this.ctl_methname.BackColor = System.Drawing.Color.Transparent;
            this.ctl_methname.Bold = false;
            this.ctl_methname.Caption = "Method Name";
            this.ctl_methname.Changed = false;
            this.ctl_methname.IsEmail = false;
            this.ctl_methname.IsURL = false;
            this.ctl_methname.Location = new System.Drawing.Point(3, 41);
            this.ctl_methname.Name = "ctl_methname";
            this.ctl_methname.PasswordChar = '\0';
            this.ctl_methname.Size = new System.Drawing.Size(379, 36);
            this.ctl_methname.TabIndex = 155;
            this.ctl_methname.UseParentBackColor = false;
            this.ctl_methname.zz_Enabled = true;
            this.ctl_methname.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_methname.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_methname.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_methname.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_methname.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_methname.zz_OriginalDesign = false;
            this.ctl_methname.zz_ShowLinkButton = false;
            this.ctl_methname.zz_ShowNeedsSaveColor = true;
            this.ctl_methname.zz_Text = "";
            this.ctl_methname.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_methname.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_methname.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_methname.zz_UseGlobalColor = false;
            this.ctl_methname.zz_UseGlobalFont = false;
            // 
            // ctl_is_static
            // 
            this.ctl_is_static.BackColor = System.Drawing.Color.Transparent;
            this.ctl_is_static.Bold = false;
            this.ctl_is_static.Caption = "Static";
            this.ctl_is_static.Changed = false;
            this.ctl_is_static.Location = new System.Drawing.Point(334, 1);
            this.ctl_is_static.Name = "ctl_is_static";
            this.ctl_is_static.Size = new System.Drawing.Size(52, 18);
            this.ctl_is_static.TabIndex = 154;
            this.ctl_is_static.UseParentBackColor = false;
            this.ctl_is_static.zz_CheckValue = false;
            this.ctl_is_static.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_static.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_is_static.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Left;
            this.ctl_is_static.zz_OriginalDesign = false;
            this.ctl_is_static.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_data_type
            // 
            this.ctl_data_type.AllCaps = false;
            this.ctl_data_type.BackColor = System.Drawing.Color.Transparent;
            this.ctl_data_type.Bold = false;
            this.ctl_data_type.Caption = "Return Type";
            this.ctl_data_type.Changed = false;
            this.ctl_data_type.IsEmail = false;
            this.ctl_data_type.IsURL = false;
            this.ctl_data_type.Location = new System.Drawing.Point(137, 5);
            this.ctl_data_type.Name = "ctl_data_type";
            this.ctl_data_type.PasswordChar = '\0';
            this.ctl_data_type.Size = new System.Drawing.Size(245, 36);
            this.ctl_data_type.TabIndex = 153;
            this.ctl_data_type.UseParentBackColor = false;
            this.ctl_data_type.zz_Enabled = true;
            this.ctl_data_type.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_data_type.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_data_type.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_data_type.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_data_type.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_data_type.zz_OriginalDesign = false;
            this.ctl_data_type.zz_ShowLinkButton = false;
            this.ctl_data_type.zz_ShowNeedsSaveColor = true;
            this.ctl_data_type.zz_Text = "";
            this.ctl_data_type.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_data_type.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_data_type.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_data_type.zz_UseGlobalColor = false;
            this.ctl_data_type.zz_UseGlobalFont = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(2, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 14);
            this.label10.TabIndex = 127;
            this.label10.Text = "Parameters:";
            // 
            // ctlaccess_specifier
            // 
            this.ctlaccess_specifier.AllCaps = false;
            this.ctlaccess_specifier.AllowEdit = false;
            this.ctlaccess_specifier.BackColor = System.Drawing.Color.Transparent;
            this.ctlaccess_specifier.Bold = false;
            this.ctlaccess_specifier.Caption = "Access";
            this.ctlaccess_specifier.Changed = false;
            this.ctlaccess_specifier.ListName = null;
            this.ctlaccess_specifier.Location = new System.Drawing.Point(3, 3);
            this.ctlaccess_specifier.Name = "ctlaccess_specifier";
            this.ctlaccess_specifier.SimpleList = "Public|Protected|Private";
            this.ctlaccess_specifier.Size = new System.Drawing.Size(128, 38);
            this.ctlaccess_specifier.TabIndex = 152;
            this.ctlaccess_specifier.UseParentBackColor = false;
            this.ctlaccess_specifier.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlaccess_specifier.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlaccess_specifier.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlaccess_specifier.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlaccess_specifier.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctlaccess_specifier.zz_OriginalDesign = false;
            this.ctlaccess_specifier.zz_ShowNeedsSaveColor = true;
            this.ctlaccess_specifier.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlaccess_specifier.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlaccess_specifier.zz_UseGlobalColor = false;
            this.ctlaccess_specifier.zz_UseGlobalFont = false;
            // 
            // lvPars
            // 
            this.lvPars.AddCaption = "Add New";
            this.lvPars.AllowActions = true;
            this.lvPars.AllowAdd = false;
            this.lvPars.AllowDelete = true;
            this.lvPars.AllowDeleteAlways = false;
            this.lvPars.AllowDrop = true;
            this.lvPars.AlternateConnection = null;
            this.lvPars.Caption = "";
            this.lvPars.CurrentTemplate = null;
            this.lvPars.ExtraClassInfo = "";
            this.lvPars.Location = new System.Drawing.Point(2, 104);
            this.lvPars.MultiSelect = true;
            this.lvPars.Name = "lvPars";
            this.lvPars.Size = new System.Drawing.Size(385, 208);
            this.lvPars.SuppressSelectionChanged = false;
            this.lvPars.TabIndex = 146;
            this.lvPars.zz_OpenColumnMenu = false;
            this.lvPars.zz_ShowAutoRefresh = true;
            this.lvPars.zz_ShowUnlimited = true;
            this.lvPars.ObjectClicked += new NewMethod.ObjectClickHandler(this.lvPars_ObjectClicked);
            // 
            // p_methbottom
            // 
            this.p_methbottom.Controls.Add(this.ctl_user_prompt);
            this.p_methbottom.Controls.Add(this.ctl_is_optional);
            this.p_methbottom.Controls.Add(this.ctl_optional_value);
            this.p_methbottom.Controls.Add(this.ctl_param_name);
            this.p_methbottom.Controls.Add(this.ctl_by_ref);
            this.p_methbottom.Controls.Add(this.ctl_param_data_type);
            this.p_methbottom.Controls.Add(this.cmdNewPar);
            this.p_methbottom.Controls.Add(this.cmdApply);
            this.p_methbottom.Location = new System.Drawing.Point(2, 331);
            this.p_methbottom.Name = "p_methbottom";
            this.p_methbottom.Size = new System.Drawing.Size(385, 227);
            this.p_methbottom.TabIndex = 145;
            // 
            // ctl_user_prompt
            // 
            this.ctl_user_prompt.AllCaps = false;
            this.ctl_user_prompt.BackColor = System.Drawing.Color.Transparent;
            this.ctl_user_prompt.Bold = false;
            this.ctl_user_prompt.Caption = "User Prompt";
            this.ctl_user_prompt.Changed = false;
            this.ctl_user_prompt.IsEmail = false;
            this.ctl_user_prompt.IsURL = false;
            this.ctl_user_prompt.Location = new System.Drawing.Point(3, 159);
            this.ctl_user_prompt.Name = "ctl_user_prompt";
            this.ctl_user_prompt.PasswordChar = '\0';
            this.ctl_user_prompt.Size = new System.Drawing.Size(379, 36);
            this.ctl_user_prompt.TabIndex = 161;
            this.ctl_user_prompt.UseParentBackColor = false;
            this.ctl_user_prompt.zz_Enabled = true;
            this.ctl_user_prompt.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_user_prompt.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_user_prompt.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_user_prompt.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_user_prompt.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_user_prompt.zz_OriginalDesign = false;
            this.ctl_user_prompt.zz_ShowLinkButton = false;
            this.ctl_user_prompt.zz_ShowNeedsSaveColor = true;
            this.ctl_user_prompt.zz_Text = "";
            this.ctl_user_prompt.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_user_prompt.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_user_prompt.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_user_prompt.zz_UseGlobalColor = false;
            this.ctl_user_prompt.zz_UseGlobalFont = false;
            // 
            // ctl_is_optional
            // 
            this.ctl_is_optional.BackColor = System.Drawing.Color.Transparent;
            this.ctl_is_optional.Bold = false;
            this.ctl_is_optional.Caption = "Optional";
            this.ctl_is_optional.Changed = false;
            this.ctl_is_optional.Location = new System.Drawing.Point(319, 116);
            this.ctl_is_optional.Name = "ctl_is_optional";
            this.ctl_is_optional.Size = new System.Drawing.Size(67, 18);
            this.ctl_is_optional.TabIndex = 159;
            this.ctl_is_optional.UseParentBackColor = false;
            this.ctl_is_optional.zz_CheckValue = false;
            this.ctl_is_optional.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_optional.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_is_optional.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Left;
            this.ctl_is_optional.zz_OriginalDesign = false;
            this.ctl_is_optional.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_optional_value
            // 
            this.ctl_optional_value.AllCaps = false;
            this.ctl_optional_value.BackColor = System.Drawing.Color.Transparent;
            this.ctl_optional_value.Bold = false;
            this.ctl_optional_value.Caption = "Optional Value";
            this.ctl_optional_value.Changed = false;
            this.ctl_optional_value.IsEmail = false;
            this.ctl_optional_value.IsURL = false;
            this.ctl_optional_value.Location = new System.Drawing.Point(3, 120);
            this.ctl_optional_value.Name = "ctl_optional_value";
            this.ctl_optional_value.PasswordChar = '\0';
            this.ctl_optional_value.Size = new System.Drawing.Size(379, 36);
            this.ctl_optional_value.TabIndex = 160;
            this.ctl_optional_value.UseParentBackColor = false;
            this.ctl_optional_value.zz_Enabled = true;
            this.ctl_optional_value.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_optional_value.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_optional_value.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_optional_value.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_optional_value.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_optional_value.zz_OriginalDesign = false;
            this.ctl_optional_value.zz_ShowLinkButton = false;
            this.ctl_optional_value.zz_ShowNeedsSaveColor = true;
            this.ctl_optional_value.zz_Text = "";
            this.ctl_optional_value.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_optional_value.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_optional_value.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_optional_value.zz_UseGlobalColor = false;
            this.ctl_optional_value.zz_UseGlobalFont = false;
            // 
            // ctl_param_name
            // 
            this.ctl_param_name.AllCaps = false;
            this.ctl_param_name.BackColor = System.Drawing.Color.Transparent;
            this.ctl_param_name.Bold = false;
            this.ctl_param_name.Caption = "Parameter Name";
            this.ctl_param_name.Changed = false;
            this.ctl_param_name.IsEmail = false;
            this.ctl_param_name.IsURL = false;
            this.ctl_param_name.Location = new System.Drawing.Point(3, 75);
            this.ctl_param_name.Name = "ctl_param_name";
            this.ctl_param_name.PasswordChar = '\0';
            this.ctl_param_name.Size = new System.Drawing.Size(379, 36);
            this.ctl_param_name.TabIndex = 158;
            this.ctl_param_name.UseParentBackColor = false;
            this.ctl_param_name.zz_Enabled = true;
            this.ctl_param_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_param_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_param_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_param_name.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_param_name.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_param_name.zz_OriginalDesign = false;
            this.ctl_param_name.zz_ShowLinkButton = false;
            this.ctl_param_name.zz_ShowNeedsSaveColor = true;
            this.ctl_param_name.zz_Text = "";
            this.ctl_param_name.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_param_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_param_name.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_param_name.zz_UseGlobalColor = false;
            this.ctl_param_name.zz_UseGlobalFont = false;
            // 
            // ctl_by_ref
            // 
            this.ctl_by_ref.BackColor = System.Drawing.Color.Transparent;
            this.ctl_by_ref.Bold = false;
            this.ctl_by_ref.Caption = "ByRef";
            this.ctl_by_ref.Changed = false;
            this.ctl_by_ref.Location = new System.Drawing.Point(332, 33);
            this.ctl_by_ref.Name = "ctl_by_ref";
            this.ctl_by_ref.Size = new System.Drawing.Size(55, 18);
            this.ctl_by_ref.TabIndex = 157;
            this.ctl_by_ref.UseParentBackColor = false;
            this.ctl_by_ref.zz_CheckValue = false;
            this.ctl_by_ref.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_by_ref.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_by_ref.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Left;
            this.ctl_by_ref.zz_OriginalDesign = false;
            this.ctl_by_ref.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_param_data_type
            // 
            this.ctl_param_data_type.AllCaps = false;
            this.ctl_param_data_type.BackColor = System.Drawing.Color.Transparent;
            this.ctl_param_data_type.Bold = false;
            this.ctl_param_data_type.Caption = "Parameter Type";
            this.ctl_param_data_type.Changed = false;
            this.ctl_param_data_type.IsEmail = false;
            this.ctl_param_data_type.IsURL = false;
            this.ctl_param_data_type.Location = new System.Drawing.Point(3, 38);
            this.ctl_param_data_type.Name = "ctl_param_data_type";
            this.ctl_param_data_type.PasswordChar = '\0';
            this.ctl_param_data_type.Size = new System.Drawing.Size(379, 36);
            this.ctl_param_data_type.TabIndex = 156;
            this.ctl_param_data_type.UseParentBackColor = false;
            this.ctl_param_data_type.zz_Enabled = true;
            this.ctl_param_data_type.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_param_data_type.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_param_data_type.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_param_data_type.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_param_data_type.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_param_data_type.zz_OriginalDesign = false;
            this.ctl_param_data_type.zz_ShowLinkButton = false;
            this.ctl_param_data_type.zz_ShowNeedsSaveColor = true;
            this.ctl_param_data_type.zz_Text = "";
            this.ctl_param_data_type.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_param_data_type.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_param_data_type.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_param_data_type.zz_UseGlobalColor = false;
            this.ctl_param_data_type.zz_UseGlobalFont = false;
            // 
            // cmdNewPar
            // 
            this.cmdNewPar.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewPar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNewPar.ImageKey = "prop";
            this.cmdNewPar.ImageList = this.IM16;
            this.cmdNewPar.Location = new System.Drawing.Point(1, 3);
            this.cmdNewPar.Name = "cmdNewPar";
            this.cmdNewPar.Size = new System.Drawing.Size(383, 29);
            this.cmdNewPar.TabIndex = 140;
            this.cmdNewPar.Text = "New Parameter";
            this.cmdNewPar.UseVisualStyleBackColor = true;
            // 
            // cmdApply
            // 
            this.cmdApply.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdApply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdApply.ImageKey = "apply";
            this.cmdApply.ImageList = this.IM16;
            this.cmdApply.Location = new System.Drawing.Point(3, 198);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(381, 28);
            this.cmdApply.TabIndex = 144;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            // 
            // lvMeths
            // 
            this.lvMeths.AddCaption = "Add New";
            this.lvMeths.AllowActions = true;
            this.lvMeths.AllowAdd = false;
            this.lvMeths.AllowDelete = true;
            this.lvMeths.AllowDeleteAlways = false;
            this.lvMeths.AllowDrop = true;
            this.lvMeths.AlternateConnection = null;
            this.lvMeths.Caption = "";
            this.lvMeths.CurrentTemplate = null;
            this.lvMeths.ExtraClassInfo = "";
            this.lvMeths.Location = new System.Drawing.Point(6, 6);
            this.lvMeths.MultiSelect = true;
            this.lvMeths.Name = "lvMeths";
            this.lvMeths.Size = new System.Drawing.Size(297, 452);
            this.lvMeths.SuppressSelectionChanged = false;
            this.lvMeths.TabIndex = 124;
            this.lvMeths.zz_OpenColumnMenu = false;
            this.lvMeths.zz_ShowAutoRefresh = true;
            this.lvMeths.zz_ShowUnlimited = true;
            this.lvMeths.ObjectClicked += new NewMethod.ObjectClickHandler(this.lvMeths_ObjectClicked);
            // 
            // cmdNewMethod
            // 
            this.cmdNewMethod.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewMethod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNewMethod.ImageKey = "method";
            this.cmdNewMethod.ImageList = this.IM16;
            this.cmdNewMethod.Location = new System.Drawing.Point(6, 465);
            this.cmdNewMethod.Name = "cmdNewMethod";
            this.cmdNewMethod.Size = new System.Drawing.Size(297, 28);
            this.cmdNewMethod.TabIndex = 1;
            this.cmdNewMethod.Text = "New Method";
            this.cmdNewMethod.UseVisualStyleBackColor = true;
            this.cmdNewMethod.Click += new System.EventHandler(this.cmdNewMethod_Click);
            // 
            // pageClass
            // 
            this.pageClass.Controls.Add(this.ctl_explanation);
            this.pageClass.Location = new System.Drawing.Point(4, 23);
            this.pageClass.Name = "pageClass";
            this.pageClass.Padding = new System.Windows.Forms.Padding(3);
            this.pageClass.Size = new System.Drawing.Size(796, 638);
            this.pageClass.TabIndex = 2;
            this.pageClass.Text = "Explanation";
            this.pageClass.UseVisualStyleBackColor = true;
            // 
            // ctl_explanation
            // 
            this.ctl_explanation.BackColor = System.Drawing.Color.Transparent;
            this.ctl_explanation.Bold = false;
            this.ctl_explanation.Caption = "Explanation";
            this.ctl_explanation.Changed = false;
            this.ctl_explanation.DateLines = false;
            this.ctl_explanation.Location = new System.Drawing.Point(6, 6);
            this.ctl_explanation.Name = "ctl_explanation";
            this.ctl_explanation.Size = new System.Drawing.Size(714, 458);
            this.ctl_explanation.TabIndex = 13;
            this.ctl_explanation.UseParentBackColor = true;
            this.ctl_explanation.zz_Enabled = true;
            this.ctl_explanation.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_explanation.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_explanation.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_explanation.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_explanation.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_explanation.zz_OriginalDesign = false;
            this.ctl_explanation.zz_ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ctl_explanation.zz_ShowNeedsSaveColor = true;
            this.ctl_explanation.zz_Text = "";
            this.ctl_explanation.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_explanation.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_explanation.zz_UseGlobalColor = false;
            this.ctl_explanation.zz_UseGlobalFont = false;
            // 
            // pageActions
            // 
            this.pageActions.Controls.Add(this.lvActions);
            this.pageActions.Location = new System.Drawing.Point(4, 23);
            this.pageActions.Name = "pageActions";
            this.pageActions.Padding = new System.Windows.Forms.Padding(3);
            this.pageActions.Size = new System.Drawing.Size(796, 638);
            this.pageActions.TabIndex = 3;
            this.pageActions.Text = "Actions";
            this.pageActions.UseVisualStyleBackColor = true;
            // 
            // lvActions
            // 
            this.lvActions.AddCaption = " Add New Action";
            this.lvActions.AllowActions = true;
            this.lvActions.AllowAdd = true;
            this.lvActions.AllowDelete = true;
            this.lvActions.AllowDeleteAlways = false;
            this.lvActions.AllowDrop = true;
            this.lvActions.AlternateConnection = null;
            this.lvActions.Caption = "";
            this.lvActions.CurrentTemplate = null;
            this.lvActions.ExtraClassInfo = "";
            this.lvActions.Location = new System.Drawing.Point(6, 6);
            this.lvActions.MultiSelect = true;
            this.lvActions.Name = "lvActions";
            this.lvActions.Size = new System.Drawing.Size(560, 265);
            this.lvActions.SuppressSelectionChanged = false;
            this.lvActions.TabIndex = 0;
            this.lvActions.zz_OpenColumnMenu = false;
            this.lvActions.zz_ShowAutoRefresh = true;
            this.lvActions.zz_ShowUnlimited = true;
            this.lvActions.AboutToThrow += new NewMethod.ThrowHandler(this.lvActions_AboutToThrow);
            this.lvActions.AboutToAdd += new NewMethod.AddHandler(this.lvActions_AboutToAdd);
            // 
            // pageRelationships
            // 
            this.pageRelationships.Controls.Add(this.lstReferencing);
            this.pageRelationships.Controls.Add(this.lstReferencedBy);
            this.pageRelationships.Controls.Add(this.lvDerivedBy);
            this.pageRelationships.Controls.Add(this.lvInheritFrom);
            this.pageRelationships.Location = new System.Drawing.Point(4, 23);
            this.pageRelationships.Name = "pageRelationships";
            this.pageRelationships.Padding = new System.Windows.Forms.Padding(3);
            this.pageRelationships.Size = new System.Drawing.Size(796, 638);
            this.pageRelationships.TabIndex = 4;
            this.pageRelationships.Text = "Relationships";
            this.pageRelationships.UseVisualStyleBackColor = true;
            // 
            // lstReferencing
            // 
            this.lstReferencing.AddCaption = "Add A Class Reference";
            this.lstReferencing.AllowActions = true;
            this.lstReferencing.AllowAdd = true;
            this.lstReferencing.AllowDelete = true;
            this.lstReferencing.AllowDeleteAlways = false;
            this.lstReferencing.AllowDrop = true;
            this.lstReferencing.AlternateConnection = null;
            this.lstReferencing.Caption = "Referencing";
            this.lstReferencing.CurrentTemplate = null;
            this.lstReferencing.ExtraClassInfo = "";
            this.lstReferencing.Location = new System.Drawing.Point(279, 281);
            this.lstReferencing.MultiSelect = true;
            this.lstReferencing.Name = "lstReferencing";
            this.lstReferencing.Size = new System.Drawing.Size(333, 310);
            this.lstReferencing.SuppressSelectionChanged = false;
            this.lstReferencing.TabIndex = 5;
            this.lstReferencing.zz_OpenColumnMenu = false;
            this.lstReferencing.zz_ShowAutoRefresh = true;
            this.lstReferencing.zz_ShowUnlimited = true;
            this.lstReferencing.AboutToAdd += new NewMethod.AddHandler(this.lstReferencing_AboutToAdd);
            this.lstReferencing.AboutToDelete += new NewMethod.ActionHandler(this.lstReferencing_AboutToDelete);
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
            this.lstReferencedBy.Location = new System.Drawing.Point(279, 17);
            this.lstReferencedBy.MultiSelect = true;
            this.lstReferencedBy.Name = "lstReferencedBy";
            this.lstReferencedBy.Size = new System.Drawing.Size(333, 258);
            this.lstReferencedBy.SuppressSelectionChanged = false;
            this.lstReferencedBy.TabIndex = 4;
            this.lstReferencedBy.zz_OpenColumnMenu = false;
            this.lstReferencedBy.zz_ShowAutoRefresh = true;
            this.lstReferencedBy.zz_ShowUnlimited = true;
            // 
            // lvDerivedBy
            // 
            this.lvDerivedBy.AddCaption = "Derive A Sub-Class";
            this.lvDerivedBy.AllowActions = true;
            this.lvDerivedBy.AllowAdd = true;
            this.lvDerivedBy.AllowDelete = true;
            this.lvDerivedBy.AllowDeleteAlways = false;
            this.lvDerivedBy.AllowDrop = true;
            this.lvDerivedBy.AlternateConnection = null;
            this.lvDerivedBy.Caption = "Derived By";
            this.lvDerivedBy.CurrentTemplate = null;
            this.lvDerivedBy.ExtraClassInfo = "";
            this.lvDerivedBy.Location = new System.Drawing.Point(10, 281);
            this.lvDerivedBy.MultiSelect = true;
            this.lvDerivedBy.Name = "lvDerivedBy";
            this.lvDerivedBy.Size = new System.Drawing.Size(263, 310);
            this.lvDerivedBy.SuppressSelectionChanged = false;
            this.lvDerivedBy.TabIndex = 1;
            this.lvDerivedBy.zz_OpenColumnMenu = false;
            this.lvDerivedBy.zz_ShowAutoRefresh = true;
            this.lvDerivedBy.zz_ShowUnlimited = true;
            // 
            // lvInheritFrom
            // 
            this.lvInheritFrom.AddCaption = "Choose A New Base Class";
            this.lvInheritFrom.AllowActions = true;
            this.lvInheritFrom.AllowAdd = true;
            this.lvInheritFrom.AllowDelete = true;
            this.lvInheritFrom.AllowDeleteAlways = false;
            this.lvInheritFrom.AllowDrop = true;
            this.lvInheritFrom.AlternateConnection = null;
            this.lvInheritFrom.Caption = "Inheriting From";
            this.lvInheritFrom.CurrentTemplate = null;
            this.lvInheritFrom.ExtraClassInfo = "";
            this.lvInheritFrom.Location = new System.Drawing.Point(10, 17);
            this.lvInheritFrom.MultiSelect = true;
            this.lvInheritFrom.Name = "lvInheritFrom";
            this.lvInheritFrom.Size = new System.Drawing.Size(263, 258);
            this.lvInheritFrom.SuppressSelectionChanged = false;
            this.lvInheritFrom.TabIndex = 0;
            this.lvInheritFrom.zz_OpenColumnMenu = false;
            this.lvInheritFrom.zz_ShowAutoRefresh = true;
            this.lvInheritFrom.zz_ShowUnlimited = true;
            this.lvInheritFrom.AboutToAdd += new NewMethod.AddHandler(this.lvInheritFrom_AboutToAdd);
            // 
            // lblWriteCode
            // 
            this.lblWriteCode.AutoSize = true;
            this.lblWriteCode.Location = new System.Drawing.Point(7, 138);
            this.lblWriteCode.Name = "lblWriteCode";
            this.lblWriteCode.Size = new System.Drawing.Size(102, 14);
            this.lblWriteCode.TabIndex = 15;
            this.lblWriteCode.TabStop = true;
            this.lblWriteCode.Text = "Write The Code File";
            this.lblWriteCode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblWriteCode_LinkClicked);
            // 
            // ctl_is_abstract
            // 
            this.ctl_is_abstract.BackColor = System.Drawing.Color.Transparent;
            this.ctl_is_abstract.Bold = false;
            this.ctl_is_abstract.Caption = "Is Abstract";
            this.ctl_is_abstract.Changed = false;
            this.ctl_is_abstract.Location = new System.Drawing.Point(548, 35);
            this.ctl_is_abstract.Name = "ctl_is_abstract";
            this.ctl_is_abstract.Size = new System.Drawing.Size(75, 18);
            this.ctl_is_abstract.TabIndex = 14;
            this.ctl_is_abstract.UseParentBackColor = true;
            this.ctl_is_abstract.zz_CheckValue = false;
            this.ctl_is_abstract.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_abstract.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_is_abstract.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Left;
            this.ctl_is_abstract.zz_OriginalDesign = false;
            this.ctl_is_abstract.zz_ShowNeedsSaveColor = true;
            // 
            // cmdSaveClass
            // 
            this.cmdSaveClass.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSaveClass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSaveClass.ImageKey = "save";
            this.cmdSaveClass.ImageList = this.IM16;
            this.cmdSaveClass.Location = new System.Drawing.Point(527, 56);
            this.cmdSaveClass.Name = "cmdSaveClass";
            this.cmdSaveClass.Size = new System.Drawing.Size(93, 38);
            this.cmdSaveClass.TabIndex = 1;
            this.cmdSaveClass.Text = "Save";
            this.cmdSaveClass.UseVisualStyleBackColor = true;
            this.cmdSaveClass.Click += new System.EventHandler(this.cmdSaveClass_Click);
            // 
            // ctl_class_tag_line
            // 
            this.ctl_class_tag_line.AllCaps = false;
            this.ctl_class_tag_line.BackColor = System.Drawing.Color.Transparent;
            this.ctl_class_tag_line.Bold = false;
            this.ctl_class_tag_line.Caption = "Tag Line";
            this.ctl_class_tag_line.Changed = false;
            this.ctl_class_tag_line.IsEmail = false;
            this.ctl_class_tag_line.IsURL = false;
            this.ctl_class_tag_line.Location = new System.Drawing.Point(6, 56);
            this.ctl_class_tag_line.Name = "ctl_class_tag_line";
            this.ctl_class_tag_line.PasswordChar = '\0';
            this.ctl_class_tag_line.Size = new System.Drawing.Size(248, 36);
            this.ctl_class_tag_line.TabIndex = 12;
            this.ctl_class_tag_line.UseParentBackColor = true;
            this.ctl_class_tag_line.zz_Enabled = true;
            this.ctl_class_tag_line.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_class_tag_line.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_class_tag_line.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_class_tag_line.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_class_tag_line.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_class_tag_line.zz_OriginalDesign = false;
            this.ctl_class_tag_line.zz_ShowLinkButton = false;
            this.ctl_class_tag_line.zz_ShowNeedsSaveColor = true;
            this.ctl_class_tag_line.zz_Text = "";
            this.ctl_class_tag_line.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_class_tag_line.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_class_tag_line.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_class_tag_line.zz_UseGlobalColor = false;
            this.ctl_class_tag_line.zz_UseGlobalFont = false;
            // 
            // xIcon
            // 
            this.xIcon.BackColor = System.Drawing.Color.Transparent;
            this.xIcon.Location = new System.Drawing.Point(326, 19);
            this.xIcon.Name = "xIcon";
            this.xIcon.Size = new System.Drawing.Size(195, 35);
            this.xIcon.TabIndex = 11;
            // 
            // ctl_class_tag
            // 
            this.ctl_class_tag.AllCaps = false;
            this.ctl_class_tag.BackColor = System.Drawing.Color.Transparent;
            this.ctl_class_tag.Bold = false;
            this.ctl_class_tag.Caption = "Class Tag";
            this.ctl_class_tag.Changed = false;
            this.ctl_class_tag.IsEmail = false;
            this.ctl_class_tag.IsURL = false;
            this.ctl_class_tag.Location = new System.Drawing.Point(6, 15);
            this.ctl_class_tag.Name = "ctl_class_tag";
            this.ctl_class_tag.PasswordChar = '\0';
            this.ctl_class_tag.Size = new System.Drawing.Size(152, 36);
            this.ctl_class_tag.TabIndex = 0;
            this.ctl_class_tag.UseParentBackColor = true;
            this.ctl_class_tag.zz_Enabled = true;
            this.ctl_class_tag.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_class_tag.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_class_tag.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_class_tag.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_class_tag.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_class_tag.zz_OriginalDesign = false;
            this.ctl_class_tag.zz_ShowLinkButton = false;
            this.ctl_class_tag.zz_ShowNeedsSaveColor = true;
            this.ctl_class_tag.zz_Text = "";
            this.ctl_class_tag.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_class_tag.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_class_tag.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_class_tag.zz_UseGlobalColor = false;
            this.ctl_class_tag.zz_UseGlobalFont = false;
            // 
            // mnuClass
            // 
            this.mnuClass.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRelates});
            this.mnuClass.Name = "mnuClass";
            this.mnuClass.Size = new System.Drawing.Size(122, 26);
            // 
            // mnuRelates
            // 
            this.mnuRelates.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddParentRelate,
            this.mnuAddChildRelate,
            this.mnuAddSelfRelate,
            this.mnuDerivedClass,
            this.mnuBaseClass,
            this.mnuSubscribe});
            this.mnuRelates.Name = "mnuRelates";
            this.mnuRelates.Size = new System.Drawing.Size(121, 22);
            this.mnuRelates.Text = "Relates";
            // 
            // mnuAddParentRelate
            // 
            this.mnuAddParentRelate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddParentRelate_New,
            this.mnuAddParentRelate_Existing});
            this.mnuAddParentRelate.Name = "mnuAddParentRelate";
            this.mnuAddParentRelate.Size = new System.Drawing.Size(183, 22);
            this.mnuAddParentRelate.Text = "Add Parent Relate";
            // 
            // mnuAddParentRelate_New
            // 
            this.mnuAddParentRelate_New.Name = "mnuAddParentRelate_New";
            this.mnuAddParentRelate_New.Size = new System.Drawing.Size(179, 22);
            this.mnuAddParentRelate_New.Text = "To A New Class";
            this.mnuAddParentRelate_New.Click += new System.EventHandler(this.mnuAddParentRelate_New_Click);
            // 
            // mnuAddParentRelate_Existing
            // 
            this.mnuAddParentRelate_Existing.Name = "mnuAddParentRelate_Existing";
            this.mnuAddParentRelate_Existing.Size = new System.Drawing.Size(179, 22);
            this.mnuAddParentRelate_Existing.Text = "To An Existing Class";
            this.mnuAddParentRelate_Existing.Click += new System.EventHandler(this.mnuAddParentRelate_Existing_Click);
            // 
            // mnuAddChildRelate
            // 
            this.mnuAddChildRelate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddChildRelate_New,
            this.mnuAddChildRelate_Existing});
            this.mnuAddChildRelate.Name = "mnuAddChildRelate";
            this.mnuAddChildRelate.Size = new System.Drawing.Size(183, 22);
            this.mnuAddChildRelate.Text = "Add Child Relate";
            // 
            // mnuAddChildRelate_New
            // 
            this.mnuAddChildRelate_New.Name = "mnuAddChildRelate_New";
            this.mnuAddChildRelate_New.Size = new System.Drawing.Size(179, 22);
            this.mnuAddChildRelate_New.Text = "To A New Class";
            this.mnuAddChildRelate_New.Click += new System.EventHandler(this.mnuAddChildRelate_New_Click);
            // 
            // mnuAddChildRelate_Existing
            // 
            this.mnuAddChildRelate_Existing.Name = "mnuAddChildRelate_Existing";
            this.mnuAddChildRelate_Existing.Size = new System.Drawing.Size(179, 22);
            this.mnuAddChildRelate_Existing.Text = "To An Existing Class";
            this.mnuAddChildRelate_Existing.Click += new System.EventHandler(this.mnuAddChildRelate_Existing_Click);
            // 
            // mnuAddSelfRelate
            // 
            this.mnuAddSelfRelate.Name = "mnuAddSelfRelate";
            this.mnuAddSelfRelate.Size = new System.Drawing.Size(183, 22);
            this.mnuAddSelfRelate.Text = "Add &Self Relate";
            this.mnuAddSelfRelate.Click += new System.EventHandler(this.mnuAddSelfRelate_Click);
            // 
            // mnuDerivedClass
            // 
            this.mnuDerivedClass.Name = "mnuDerivedClass";
            this.mnuDerivedClass.Size = new System.Drawing.Size(183, 22);
            this.mnuDerivedClass.Text = "Add A Derived Class";
            this.mnuDerivedClass.Click += new System.EventHandler(this.mnuDerivedClass_Click);
            // 
            // mnuBaseClass
            // 
            this.mnuBaseClass.Name = "mnuBaseClass";
            this.mnuBaseClass.Size = new System.Drawing.Size(183, 22);
            this.mnuBaseClass.Text = "Choose A Base Class";
            this.mnuBaseClass.Click += new System.EventHandler(this.mnuBaseClass_Click);
            // 
            // mnuSubscribe
            // 
            this.mnuSubscribe.Name = "mnuSubscribe";
            this.mnuSubscribe.Size = new System.Drawing.Size(183, 22);
            this.mnuSubscribe.Text = "&Subscribe To A Class";
            this.mnuSubscribe.Click += new System.EventHandler(this.mnuSubscribe_Click);
            // 
            // gbClass
            // 
            this.gbClass.Controls.Add(this.lblLiveCore);
            this.gbClass.Controls.Add(this.lblCodeCore);
            this.gbClass.Controls.Add(this.ctl_plural_line);
            this.gbClass.Controls.Add(this.ctl_plural_tag);
            this.gbClass.Controls.Add(this.ctl_class_aspect);
            this.gbClass.Controls.Add(this.ctl_class_vivid);
            this.gbClass.Controls.Add(this.cmdSaveClass);
            this.gbClass.Controls.Add(this.lblWriteCode);
            this.gbClass.Controls.Add(this.chkNeedsUpdate);
            this.gbClass.Controls.Add(this.ctl_class_tag_line);
            this.gbClass.Controls.Add(this.ctl_is_abstract);
            this.gbClass.Controls.Add(this.xIcon);
            this.gbClass.Controls.Add(this.ctl_class_tag);
            this.gbClass.Location = new System.Drawing.Point(3, 6);
            this.gbClass.Name = "gbClass";
            this.gbClass.Size = new System.Drawing.Size(957, 157);
            this.gbClass.TabIndex = 94;
            this.gbClass.TabStop = false;
            this.gbClass.Text = "<class>";
            // 
            // lblCodeCore
            // 
            this.lblCodeCore.AutoSize = true;
            this.lblCodeCore.Location = new System.Drawing.Point(118, 138);
            this.lblCodeCore.Name = "lblCodeCore";
            this.lblCodeCore.Size = new System.Drawing.Size(141, 14);
            this.lblCodeCore.TabIndex = 85;
            this.lblCodeCore.TabStop = true;
            this.lblCodeCore.Text = "Write The Code File - CORE";
            this.lblCodeCore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCodeCore_LinkClicked);
            // 
            // ctl_plural_line
            // 
            this.ctl_plural_line.AllCaps = false;
            this.ctl_plural_line.BackColor = System.Drawing.Color.Transparent;
            this.ctl_plural_line.Bold = false;
            this.ctl_plural_line.Caption = "Plural Line";
            this.ctl_plural_line.Changed = false;
            this.ctl_plural_line.IsEmail = false;
            this.ctl_plural_line.IsURL = false;
            this.ctl_plural_line.Location = new System.Drawing.Point(271, 56);
            this.ctl_plural_line.Name = "ctl_plural_line";
            this.ctl_plural_line.PasswordChar = '\0';
            this.ctl_plural_line.Size = new System.Drawing.Size(248, 36);
            this.ctl_plural_line.TabIndex = 84;
            this.ctl_plural_line.UseParentBackColor = true;
            this.ctl_plural_line.zz_Enabled = true;
            this.ctl_plural_line.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_plural_line.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_plural_line.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_plural_line.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_plural_line.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_plural_line.zz_OriginalDesign = false;
            this.ctl_plural_line.zz_ShowLinkButton = false;
            this.ctl_plural_line.zz_ShowNeedsSaveColor = true;
            this.ctl_plural_line.zz_Text = "";
            this.ctl_plural_line.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_plural_line.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_plural_line.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_plural_line.zz_UseGlobalColor = false;
            this.ctl_plural_line.zz_UseGlobalFont = false;
            // 
            // ctl_plural_tag
            // 
            this.ctl_plural_tag.AllCaps = false;
            this.ctl_plural_tag.BackColor = System.Drawing.Color.Transparent;
            this.ctl_plural_tag.Bold = false;
            this.ctl_plural_tag.Caption = "Plural Tag";
            this.ctl_plural_tag.Changed = false;
            this.ctl_plural_tag.IsEmail = false;
            this.ctl_plural_tag.IsURL = false;
            this.ctl_plural_tag.Location = new System.Drawing.Point(164, 14);
            this.ctl_plural_tag.Name = "ctl_plural_tag";
            this.ctl_plural_tag.PasswordChar = '\0';
            this.ctl_plural_tag.Size = new System.Drawing.Size(152, 36);
            this.ctl_plural_tag.TabIndex = 83;
            this.ctl_plural_tag.UseParentBackColor = true;
            this.ctl_plural_tag.zz_Enabled = true;
            this.ctl_plural_tag.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_plural_tag.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_plural_tag.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_plural_tag.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_plural_tag.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_plural_tag.zz_OriginalDesign = false;
            this.ctl_plural_tag.zz_ShowLinkButton = false;
            this.ctl_plural_tag.zz_ShowNeedsSaveColor = true;
            this.ctl_plural_tag.zz_Text = "";
            this.ctl_plural_tag.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_plural_tag.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_plural_tag.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_plural_tag.zz_UseGlobalColor = false;
            this.ctl_plural_tag.zz_UseGlobalFont = false;
            // 
            // ctl_class_aspect
            // 
            this.ctl_class_aspect.AllCaps = false;
            this.ctl_class_aspect.BackColor = System.Drawing.Color.Transparent;
            this.ctl_class_aspect.Bold = false;
            this.ctl_class_aspect.Caption = "Aspect";
            this.ctl_class_aspect.Changed = false;
            this.ctl_class_aspect.IsEmail = false;
            this.ctl_class_aspect.IsURL = false;
            this.ctl_class_aspect.Location = new System.Drawing.Point(88, 96);
            this.ctl_class_aspect.Name = "ctl_class_aspect";
            this.ctl_class_aspect.PasswordChar = '\0';
            this.ctl_class_aspect.Size = new System.Drawing.Size(433, 36);
            this.ctl_class_aspect.TabIndex = 82;
            this.ctl_class_aspect.UseParentBackColor = true;
            this.ctl_class_aspect.zz_Enabled = true;
            this.ctl_class_aspect.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_class_aspect.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_class_aspect.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_class_aspect.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_class_aspect.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_class_aspect.zz_OriginalDesign = false;
            this.ctl_class_aspect.zz_ShowLinkButton = false;
            this.ctl_class_aspect.zz_ShowNeedsSaveColor = true;
            this.ctl_class_aspect.zz_Text = "";
            this.ctl_class_aspect.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_class_aspect.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_class_aspect.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_class_aspect.zz_UseGlobalColor = false;
            this.ctl_class_aspect.zz_UseGlobalFont = false;
            // 
            // ctl_class_vivid
            // 
            this.ctl_class_vivid.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_class_vivid.Bold = false;
            this.ctl_class_vivid.Caption = "Vivid";
            this.ctl_class_vivid.Changed = false;
            this.ctl_class_vivid.CurrentType = NewMethod.Enums.DataType.Any;
            this.ctl_class_vivid.Location = new System.Drawing.Point(7, 96);
            this.ctl_class_vivid.Name = "ctl_class_vivid";
            this.ctl_class_vivid.Size = new System.Drawing.Size(75, 36);
            this.ctl_class_vivid.TabIndex = 81;
            this.ctl_class_vivid.UseParentBackColor = false;
            this.ctl_class_vivid.zz_Enabled = true;
            this.ctl_class_vivid.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_class_vivid.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_class_vivid.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_class_vivid.zz_LabelFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_class_vivid.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_class_vivid.zz_OriginalDesign = false;
            this.ctl_class_vivid.zz_ShowErrorColor = true;
            this.ctl_class_vivid.zz_ShowNeedsSaveColor = true;
            this.ctl_class_vivid.zz_Text = "";
            this.ctl_class_vivid.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_class_vivid.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_class_vivid.zz_TextFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_class_vivid.zz_UseGlobalColor = false;
            this.ctl_class_vivid.zz_UseGlobalFont = false;
            // 
            // lblLiveCore
            // 
            this.lblLiveCore.AutoSize = true;
            this.lblLiveCore.Location = new System.Drawing.Point(268, 138);
            this.lblLiveCore.Name = "lblLiveCore";
            this.lblLiveCore.Size = new System.Drawing.Size(60, 14);
            this.lblLiveCore.TabIndex = 86;
            this.lblLiveCore.TabStop = true;
            this.lblLiveCore.Text = "Live CORE";
            this.lblLiveCore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLiveCore_LinkClicked);
            // 
            // nView_n_class
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.Controls.Add(this.gbClass);
            this.Controls.Add(this.ts);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideSoft = true;
            this.Name = "nView_n_class";
            this.Size = new System.Drawing.Size(1115, 834);
            this.Resize += new System.EventHandler(this.nView_n_class_Resize);
            this.Controls.SetChildIndex(this.xHandle, 0);
            this.Controls.SetChildIndex(this.ts, 0);
            this.Controls.SetChildIndex(this.gbClass, 0);
            this.mnuProp.ResumeLayout(false);
            this.ts.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbProp.ResumeLayout(false);
            this.gbProp.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.gbMethod.ResumeLayout(false);
            this.p_methtop.ResumeLayout(false);
            this.p_methtop.PerformLayout();
            this.p_methbottom.ResumeLayout(false);
            this.pageClass.ResumeLayout(false);
            this.pageActions.ResumeLayout(false);
            this.pageRelationships.ResumeLayout(false);
            this.mnuClass.ResumeLayout(false);
            this.gbClass.ResumeLayout(false);
            this.gbClass.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkNeedsUpdate;
        private System.Windows.Forms.ContextMenuStrip mnuProp;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteProp;
        private System.Windows.Forms.ToolStripMenuItem mnuCut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuPaste;
        private System.Windows.Forms.TabControl ts;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.LinkLabel lblSelectChoice;
        private System.Windows.Forms.LinkLabel lblNewChoice;
        private System.Windows.Forms.LinkLabel lblChoice;
        private System.Windows.Forms.ComboBox cboChoiceType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cmdChangeOrder;
        private System.Windows.Forms.Button cmdEmail;
        private System.Windows.Forms.Button cmdURL;
        private System.Windows.Forms.Button cmdFloat;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdMemo;
        private System.Windows.Forms.Button cmdBoolean;
        private System.Windows.Forms.Button cmdInteger;
        private System.Windows.Forms.Button cmdLong;
        private System.Windows.Forms.Button cmdString;
        private System.Windows.Forms.Button cmdDate;
        private System.Windows.Forms.Button cmdNewMethod;
        private System.Windows.Forms.Button cmdReOrder;
        private System.Windows.Forms.Button cmdUniqueID;
        private System.Windows.Forms.TabPage pageClass;
        private nEdit_String ctl_class_tag;
        private System.Windows.Forms.Button cmdSaveClass;
        private System.Windows.Forms.Button cmdBlob;
        private System.Windows.Forms.TabPage pageActions;
        private nList lvActions;
        private nEdit_Memo ctl_explanation;
        private nEdit_String ctl_class_tag_line;
        private IconStub xIcon;
        private nEdit_String ctl_tag_line;
        private nList lv;
        private nEdit_String ctl_name;
        private nEdit_String ctl_property_tag;
        private nEdit_List ctlproperty_type;
        private nEdit_List ctlproperty_use;
        private nEdit_Number ctl_property_length;
        private nEdit_Number ctl_property_order;
        private System.Windows.Forms.ToolTip tTip1;
        private nEdit_Boolean ctl_is_enum;
        private nEdit_List ctl_enum_datatype;
        private System.Windows.Forms.ImageList IM16;
        private System.Windows.Forms.ContextMenuStrip mnuClass;
        private System.Windows.Forms.ToolStripMenuItem mnuRelates;
        private System.Windows.Forms.ToolStripMenuItem mnuAddParentRelate;
        private System.Windows.Forms.ToolStripMenuItem mnuAddParentRelate_New;
        private System.Windows.Forms.ToolStripMenuItem mnuAddParentRelate_Existing;
        private System.Windows.Forms.ToolStripMenuItem mnuAddChildRelate;
        private System.Windows.Forms.ToolStripMenuItem mnuAddChildRelate_New;
        private System.Windows.Forms.ToolStripMenuItem mnuAddChildRelate_Existing;
        private System.Windows.Forms.ToolStripMenuItem mnuAddSelfRelate;
        private System.Windows.Forms.ToolStripMenuItem mnuDerivedClass;
        private System.Windows.Forms.ToolStripMenuItem mnuBaseClass;
        private System.Windows.Forms.ToolStripMenuItem mnuSubscribe;
        private System.Windows.Forms.Button cmdRelates;
        private nList lvMeths;
        private System.Windows.Forms.GroupBox gbMethod;
        private System.Windows.Forms.Button cmdNewPar;
        private System.Windows.Forms.Label label10;
        private nList lvPars;
        private System.Windows.Forms.Panel p_methbottom;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.Panel p_methtop;
        private nEdit_List ctlaccess_specifier;
        private nEdit_String ctl_data_type;
        private nEdit_Boolean ctl_is_static;
        private nEdit_String ctl_methname;
        private nEdit_String ctl_param_data_type;
        private nEdit_Boolean ctl_by_ref;
        private nEdit_String ctl_param_name;
        private nEdit_Boolean ctl_is_optional;
        private nEdit_String ctl_optional_value;
        private nEdit_String ctl_user_prompt;
        private nEdit_Boolean ctl_is_abstract;
        private System.Windows.Forms.GroupBox gbProp;
        private System.Windows.Forms.TabPage pageRelationships;
        private nList lvDerivedBy;
        private nList lvInheritFrom;
        private nList lstReferencing;
        private nList lstReferencedBy;
        private System.Windows.Forms.LinkLabel lblWriteCode;
        private System.Windows.Forms.GroupBox gbClass;
        private nEdit_String ctl_class_aspect;
        private nEdit_Number ctl_class_vivid;
        private nEdit_Number ctl_vivid;
        private nEdit_Number ctl_order_index;
        private nEdit_String ctl_aspect;
        private IconStub ctlPropIcon;
        private nEdit_String ctl_plural_line;
        private nEdit_String ctl_plural_tag;
        private System.Windows.Forms.LinkLabel lblCodeCore;
        private System.Windows.Forms.LinkLabel lblLiveCore;
    }
}
