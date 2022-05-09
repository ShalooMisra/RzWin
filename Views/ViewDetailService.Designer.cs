using Tools.Database;
namespace Rz5
{
    partial class ViewDetailService
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
            this.tabServices = new System.Windows.Forms.TabPage();
            this.gbService = new System.Windows.Forms.GroupBox();
            this.lblServiceTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctlServiceCost = new NewMethod.nEdit_Money();
            this.ctlServiceQuantity = new NewMethod.nEdit_Number();
            this.cmdSave = new System.Windows.Forms.Button();
            this.ctlServiceName = new NewMethod.nEdit_String();
            this.lvServices = new NewMethod.nList();
            this.lblPacked = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUnPacked = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPacking = new System.Windows.Forms.TabPage();
            this.packing = new Rz5.Win.Controls.Packing();
            this.tabUnPacking = new System.Windows.Forms.TabPage();
            this.ctl_ship_date_service_actual = new NewMethod.nEdit_Date();
            this.ctl_ship_date_service_due = new NewMethod.nEdit_Date();
            this.ctl_receive_date_service_actual = new NewMethod.nEdit_Date();
            this.ctl_receive_date_service_due = new NewMethod.nEdit_Date();
            this.ctl_internal_customer = new NewMethod.nEdit_String();
            this.ctl_tracking_service_out = new NewMethod.nEdit_Memo();
            this.ctl_tracking_service_in = new NewMethod.nEdit_Memo();
            this.ts.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.tabAttachments.SuspendLayout();
            this.gbAction1.SuspendLayout();
            this.gbTop.SuspendLayout();
            this.tabServices.SuspendLayout();
            this.gbService.SuspendLayout();
            this.tabPacking.SuspendLayout();
            this.SuspendLayout();
            // 
            // ts
            // 
            this.ts.Controls.Add(this.tabServices);
            this.ts.Controls.Add(this.tabPacking);
            this.ts.Controls.Add(this.tabUnPacking);
            this.ts.Margin = new System.Windows.Forms.Padding(4);
            this.ts.Size = new System.Drawing.Size(792, 585);
            this.ts.Controls.SetChildIndex(this.tabUnPacking, 0);
            this.ts.Controls.SetChildIndex(this.tabPacking, 0);
            this.ts.Controls.SetChildIndex(this.tabServices, 0);
            this.ts.Controls.SetChildIndex(this.tabAttachments, 0);
            this.ts.Controls.SetChildIndex(this.tabInfo, 0);
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.ctl_tracking_service_in);
            this.tabInfo.Controls.Add(this.ctl_tracking_service_out);
            this.tabInfo.Controls.Add(this.ctl_internal_customer);
            this.tabInfo.Controls.Add(this.ctl_receive_date_service_actual);
            this.tabInfo.Controls.Add(this.ctl_receive_date_service_due);
            this.tabInfo.Controls.Add(this.ctl_ship_date_service_actual);
            this.tabInfo.Controls.Add(this.ctl_ship_date_service_due);
            this.tabInfo.Controls.Add(this.lblUnPacked);
            this.tabInfo.Controls.Add(this.label4);
            this.tabInfo.Controls.Add(this.lblPacked);
            this.tabInfo.Controls.Add(this.label2);
            this.tabInfo.Margin = new System.Windows.Forms.Padding(4);
            this.tabInfo.Padding = new System.Windows.Forms.Padding(4);
            this.tabInfo.Size = new System.Drawing.Size(784, 559);
            this.tabInfo.Controls.SetChildIndex(this.ctl_country_of_origin, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_rohs_info, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_alternatepart, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_internalcomment, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_fullpartnumber, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_datecode, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_manufacturer, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_condition, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_packaging, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_category, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_quantity, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_description, 0);
            this.tabInfo.Controls.SetChildIndex(this.label2, 0);
            this.tabInfo.Controls.SetChildIndex(this.lblPacked, 0);
            this.tabInfo.Controls.SetChildIndex(this.label4, 0);
            this.tabInfo.Controls.SetChildIndex(this.lblUnPacked, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_ship_date_service_due, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_ship_date_service_actual, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_receive_date_service_due, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_receive_date_service_actual, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_internal_customer, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_tracking_service_out, 0);
            this.tabInfo.Controls.SetChildIndex(this.ctl_tracking_service_in, 0);
            // 
            // tabAttachments
            // 
            this.tabAttachments.Margin = new System.Windows.Forms.Padding(4);
            this.tabAttachments.Padding = new System.Windows.Forms.Padding(4);
            this.tabAttachments.Size = new System.Drawing.Size(784, 559);
            // 
            // gbAction1
            // 
            this.gbAction1.Location = new System.Drawing.Point(803, 3);
            this.gbAction1.Size = new System.Drawing.Size(152, 144);
            // 
            // ctl_fullpartnumber
            // 
            this.ctl_fullpartnumber.zz_Enabled = true;
            // 
            // ctl_manufacturer
            // 
            this.ctl_manufacturer.Location = new System.Drawing.Point(3, 57);
            this.ctl_manufacturer.Enabled = true;
            // 
            // ctl_datecode
            // 
            this.ctl_datecode.Location = new System.Drawing.Point(177, 57);
            this.ctl_datecode.zz_Enabled = true;
            // 
            // ctl_category
            // 
            this.ctl_category.Location = new System.Drawing.Point(3, 113);
            this.ctl_category.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            // 
            // ctl_packaging
            // 
            this.ctl_packaging.Location = new System.Drawing.Point(430, 57);
            this.ctl_packaging.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            // 
            // picview
            // 
            this.picview.Location = new System.Drawing.Point(4, 4);
            this.picview.Margin = new System.Windows.Forms.Padding(4);
            this.picview.Size = new System.Drawing.Size(776, 551);
            // 
            // ctl_internalcomment
            // 
            this.ctl_internalcomment.Location = new System.Drawing.Point(4, 378);
            this.ctl_internalcomment.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_internalcomment.Size = new System.Drawing.Size(769, 110);
            this.ctl_internalcomment.TabIndex = 18;
            // 
            // ctl_description
            // 
            this.ctl_description.Location = new System.Drawing.Point(177, 113);
            // 
            // ctl_alternatepart
            // 
            this.ctl_alternatepart.Location = new System.Drawing.Point(3, 179);
            // 
            // ctl_rohs_info
            // 
            this.ctl_rohs_info.Location = new System.Drawing.Point(415, 174);
            this.ctl_rohs_info.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_rohs_info.TabIndex = 11;
            // 
            // ctl_condition
            // 
            this.ctl_condition.Location = new System.Drawing.Point(268, 57);
            this.ctl_condition.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(1375, 0);
            this.xActions.Margin = new System.Windows.Forms.Padding(5);
            this.xActions.Size = new System.Drawing.Size(148, 651);
            // 
            // tabServices
            // 
            this.tabServices.Controls.Add(this.gbService);
            this.tabServices.Controls.Add(this.lvServices);
            this.tabServices.Location = new System.Drawing.Point(4, 22);
            this.tabServices.Margin = new System.Windows.Forms.Padding(4);
            this.tabServices.Name = "tabServices";
            this.tabServices.Padding = new System.Windows.Forms.Padding(4);
            this.tabServices.Size = new System.Drawing.Size(804, 294);
            this.tabServices.TabIndex = 5;
            this.tabServices.Text = "Services";
            this.tabServices.UseVisualStyleBackColor = true;
            // 
            // gbService
            // 
            this.gbService.BackColor = System.Drawing.Color.White;
            this.gbService.Controls.Add(this.lblServiceTotal);
            this.gbService.Controls.Add(this.label1);
            this.gbService.Controls.Add(this.ctlServiceCost);
            this.gbService.Controls.Add(this.ctlServiceQuantity);
            this.gbService.Controls.Add(this.cmdSave);
            this.gbService.Controls.Add(this.ctlServiceName);
            this.gbService.Location = new System.Drawing.Point(28, 363);
            this.gbService.Margin = new System.Windows.Forms.Padding(4);
            this.gbService.Name = "gbService";
            this.gbService.Padding = new System.Windows.Forms.Padding(4);
            this.gbService.Size = new System.Drawing.Size(715, 161);
            this.gbService.TabIndex = 1;
            this.gbService.TabStop = false;
            // 
            // lblServiceTotal
            // 
            this.lblServiceTotal.AutoSize = true;
            this.lblServiceTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceTotal.Location = new System.Drawing.Point(373, 102);
            this.lblServiceTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServiceTotal.Name = "lblServiceTotal";
            this.lblServiceTotal.Size = new System.Drawing.Size(49, 19);
            this.lblServiceTotal.TabIndex = 40;
            this.lblServiceTotal.Text = "(total)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(373, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 19);
            this.label1.TabIndex = 39;
            this.label1.Text = "Total";
            // 
            // ctlServiceCost
            // 
            this.ctlServiceCost.BackColor = System.Drawing.Color.White;
            this.ctlServiceCost.Bold = false;
            this.ctlServiceCost.Caption = "Service Unit Cost";
            this.ctlServiceCost.Changed = false;
            this.ctlServiceCost.EditCaption = false;
            this.ctlServiceCost.FullDecimal = false;
            this.ctlServiceCost.Location = new System.Drawing.Point(192, 80);
            this.ctlServiceCost.Margin = new System.Windows.Forms.Padding(21, 34, 21, 34);
            this.ctlServiceCost.Name = "ctlServiceCost";
            this.ctlServiceCost.RoundNearestCent = false;
            this.ctlServiceCost.Size = new System.Drawing.Size(156, 48);
            this.ctlServiceCost.TabIndex = 38;
            this.ctlServiceCost.UseParentBackColor = true;
            this.ctlServiceCost.zz_Enabled = true;
            this.ctlServiceCost.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlServiceCost.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlServiceCost.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlServiceCost.zz_LabelFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceCost.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctlServiceCost.zz_OriginalDesign = false;
            this.ctlServiceCost.zz_ShowErrorColor = true;
            this.ctlServiceCost.zz_ShowNeedsSaveColor = true;
            this.ctlServiceCost.zz_Text = "";
            this.ctlServiceCost.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctlServiceCost.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlServiceCost.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceCost.zz_UseGlobalColor = false;
            this.ctlServiceCost.zz_UseGlobalFont = false;
            // 
            // ctlServiceQuantity
            // 
            this.ctlServiceQuantity.BackColor = System.Drawing.Color.White;
            this.ctlServiceQuantity.Bold = false;
            this.ctlServiceQuantity.Caption = "Service Quantity";
            this.ctlServiceQuantity.Changed = false;
            this.ctlServiceQuantity.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctlServiceQuantity.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceQuantity.Location = new System.Drawing.Point(9, 80);
            this.ctlServiceQuantity.Margin = new System.Windows.Forms.Padding(5);
            this.ctlServiceQuantity.Name = "ctlServiceQuantity";
            this.ctlServiceQuantity.Size = new System.Drawing.Size(167, 48);
            this.ctlServiceQuantity.TabIndex = 27;
            this.ctlServiceQuantity.UseParentBackColor = true;
            this.ctlServiceQuantity.zz_Enabled = true;
            this.ctlServiceQuantity.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlServiceQuantity.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlServiceQuantity.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlServiceQuantity.zz_LabelFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceQuantity.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctlServiceQuantity.zz_OriginalDesign = false;
            this.ctlServiceQuantity.zz_ShowErrorColor = true;
            this.ctlServiceQuantity.zz_ShowNeedsSaveColor = true;
            this.ctlServiceQuantity.zz_Text = "";
            this.ctlServiceQuantity.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctlServiceQuantity.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlServiceQuantity.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceQuantity.zz_UseGlobalColor = false;
            this.ctlServiceQuantity.zz_UseGlobalFont = false;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(569, 73);
            this.cmdSave.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(136, 74);
            this.cmdSave.TabIndex = 1;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // ctlServiceName
            // 
            this.ctlServiceName.AllCaps = false;
            this.ctlServiceName.BackColor = System.Drawing.Color.Transparent;
            this.ctlServiceName.Bold = false;
            this.ctlServiceName.Caption = "Service Name";
            this.ctlServiceName.Changed = false;
            this.ctlServiceName.IsEmail = false;
            this.ctlServiceName.IsURL = false;
            this.ctlServiceName.Location = new System.Drawing.Point(8, 12);
            this.ctlServiceName.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctlServiceName.Name = "ctlServiceName";
            this.ctlServiceName.PasswordChar = '\0';
            this.ctlServiceName.Size = new System.Drawing.Size(699, 48);
            this.ctlServiceName.TabIndex = 0;
            this.ctlServiceName.UseParentBackColor = true;
            this.ctlServiceName.zz_Enabled = true;
            this.ctlServiceName.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlServiceName.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlServiceName.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlServiceName.zz_LabelFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceName.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlServiceName.zz_OriginalDesign = false;
            this.ctlServiceName.zz_ShowLinkButton = false;
            this.ctlServiceName.zz_ShowNeedsSaveColor = true;
            this.ctlServiceName.zz_Text = "";
            this.ctlServiceName.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlServiceName.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlServiceName.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceName.zz_UseGlobalColor = false;
            this.ctlServiceName.zz_UseGlobalFont = false;
            // 
            // lvServices
            // 
            this.lvServices.AddCaption = "Add New";
            this.lvServices.AllowActions = true;
            this.lvServices.AllowAdd = false;
            this.lvServices.AllowDelete = true;
            this.lvServices.AllowDeleteAlways = false;
            this.lvServices.AllowDrop = true;
            this.lvServices.AllowOnlyOpenDelete = false;
            this.lvServices.AlternateConnection = null;
            this.lvServices.BackColor = System.Drawing.Color.White;
            this.lvServices.Caption = "";
            this.lvServices.CurrentTemplate = null;
            this.lvServices.ExtraClassInfo = "";
            this.lvServices.Location = new System.Drawing.Point(28, 18);
            this.lvServices.Margin = new System.Windows.Forms.Padding(5);
            this.lvServices.MultiSelect = true;
            this.lvServices.Name = "lvServices";
            this.lvServices.Size = new System.Drawing.Size(716, 330);
            this.lvServices.SuppressSelectionChanged = false;
            this.lvServices.TabIndex = 0;
            this.lvServices.zz_OpenColumnMenu = false;
            this.lvServices.zz_OrderLineType = "";
            this.lvServices.zz_ShowAutoRefresh = true;
            this.lvServices.zz_ShowUnlimited = true;
            this.lvServices.AboutToThrow += new Core.ShowHandler(this.lvServices_AboutToThrow);
            this.lvServices.AboutToAdd += new NewMethod.AddHandler(this.lvServices_AboutToAdd);
            // 
            // lblPacked
            // 
            this.lblPacked.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacked.Location = new System.Drawing.Point(528, 32);
            this.lblPacked.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPacked.Name = "lblPacked";
            this.lblPacked.Size = new System.Drawing.Size(113, 23);
            this.lblPacked.TabIndex = 59;
            this.lblPacked.Text = "1,000,000";
            this.lblPacked.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(540, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 18);
            this.label2.TabIndex = 58;
            this.label2.Text = "Packed";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUnPacked
            // 
            this.lblUnPacked.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnPacked.Location = new System.Drawing.Point(649, 32);
            this.lblUnPacked.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUnPacked.Name = "lblUnPacked";
            this.lblUnPacked.Size = new System.Drawing.Size(112, 23);
            this.lblUnPacked.TabIndex = 61;
            this.lblUnPacked.Text = "1,000,000";
            this.lblUnPacked.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(655, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 18);
            this.label4.TabIndex = 60;
            this.label4.Text = "Received";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabPacking
            // 
            this.tabPacking.Controls.Add(this.packing);
            this.tabPacking.Location = new System.Drawing.Point(4, 22);
            this.tabPacking.Margin = new System.Windows.Forms.Padding(4);
            this.tabPacking.Name = "tabPacking";
            this.tabPacking.Padding = new System.Windows.Forms.Padding(4);
            this.tabPacking.Size = new System.Drawing.Size(804, 294);
            this.tabPacking.TabIndex = 6;
            this.tabPacking.Text = "Packing";
            this.tabPacking.UseVisualStyleBackColor = true;
            // 
            // packing
            // 
            this.packing.BackColor = System.Drawing.Color.White;
            this.packing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.packing.Location = new System.Drawing.Point(4, 4);
            this.packing.Margin = new System.Windows.Forms.Padding(5);
            this.packing.Name = "packing";
            this.packing.Size = new System.Drawing.Size(796, 286);
            this.packing.TabIndex = 0;
            this.packing.PackRefreshed += new System.EventHandler(this.packing_PackRefreshed);
            // 
            // tabUnPacking
            // 
            this.tabUnPacking.Location = new System.Drawing.Point(4, 22);
            this.tabUnPacking.Margin = new System.Windows.Forms.Padding(4);
            this.tabUnPacking.Name = "tabUnPacking";
            this.tabUnPacking.Padding = new System.Windows.Forms.Padding(4);
            this.tabUnPacking.Size = new System.Drawing.Size(804, 294);
            this.tabUnPacking.TabIndex = 7;
            this.tabUnPacking.Text = "Receive";
            this.tabUnPacking.UseVisualStyleBackColor = true;
            // 
            // ctl_ship_date_service_actual
            // 
            this.ctl_ship_date_service_actual.AllowClear = false;
            this.ctl_ship_date_service_actual.BackColor = System.Drawing.Color.Transparent;
            this.ctl_ship_date_service_actual.Bold = false;
            this.ctl_ship_date_service_actual.Caption = "Service Actual Ship Date";
            this.ctl_ship_date_service_actual.Changed = false;
            this.ctl_ship_date_service_actual.Location = new System.Drawing.Point(7, 316);
            this.ctl_ship_date_service_actual.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_ship_date_service_actual.Name = "ctl_ship_date_service_actual";
            this.ctl_ship_date_service_actual.Size = new System.Drawing.Size(215, 50);
            this.ctl_ship_date_service_actual.SuppressEdit = false;
            this.ctl_ship_date_service_actual.TabIndex = 15;
            this.ctl_ship_date_service_actual.UseParentBackColor = false;
            this.ctl_ship_date_service_actual.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_ship_date_service_actual.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_ship_date_service_actual.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_ship_date_service_actual.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ship_date_service_actual.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_ship_date_service_actual.zz_OriginalDesign = false;
            this.ctl_ship_date_service_actual.zz_ShowNeedsSaveColor = true;
            this.ctl_ship_date_service_actual.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_ship_date_service_actual.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_ship_date_service_actual.zz_UseGlobalColor = false;
            this.ctl_ship_date_service_actual.zz_UseGlobalFont = false;
            // 
            // ctl_ship_date_service_due
            // 
            this.ctl_ship_date_service_due.AllowClear = false;
            this.ctl_ship_date_service_due.BackColor = System.Drawing.Color.Transparent;
            this.ctl_ship_date_service_due.Bold = false;
            this.ctl_ship_date_service_due.Caption = "Service Shipping Due Date";
            this.ctl_ship_date_service_due.Changed = false;
            this.ctl_ship_date_service_due.Location = new System.Drawing.Point(4, 247);
            this.ctl_ship_date_service_due.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_ship_date_service_due.Name = "ctl_ship_date_service_due";
            this.ctl_ship_date_service_due.Size = new System.Drawing.Size(218, 50);
            this.ctl_ship_date_service_due.SuppressEdit = false;
            this.ctl_ship_date_service_due.TabIndex = 12;
            this.ctl_ship_date_service_due.UseParentBackColor = false;
            this.ctl_ship_date_service_due.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_ship_date_service_due.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_ship_date_service_due.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_ship_date_service_due.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ship_date_service_due.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_ship_date_service_due.zz_OriginalDesign = false;
            this.ctl_ship_date_service_due.zz_ShowNeedsSaveColor = true;
            this.ctl_ship_date_service_due.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_ship_date_service_due.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_ship_date_service_due.zz_UseGlobalColor = false;
            this.ctl_ship_date_service_due.zz_UseGlobalFont = false;
            // 
            // ctl_receive_date_service_actual
            // 
            this.ctl_receive_date_service_actual.AllowClear = false;
            this.ctl_receive_date_service_actual.BackColor = System.Drawing.Color.Transparent;
            this.ctl_receive_date_service_actual.Bold = false;
            this.ctl_receive_date_service_actual.Caption = "Service Actual Receive Date";
            this.ctl_receive_date_service_actual.Changed = false;
            this.ctl_receive_date_service_actual.Location = new System.Drawing.Point(225, 316);
            this.ctl_receive_date_service_actual.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_receive_date_service_actual.Name = "ctl_receive_date_service_actual";
            this.ctl_receive_date_service_actual.Size = new System.Drawing.Size(224, 50);
            this.ctl_receive_date_service_actual.SuppressEdit = false;
            this.ctl_receive_date_service_actual.TabIndex = 16;
            this.ctl_receive_date_service_actual.UseParentBackColor = false;
            this.ctl_receive_date_service_actual.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_receive_date_service_actual.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_receive_date_service_actual.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_receive_date_service_actual.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_receive_date_service_actual.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_receive_date_service_actual.zz_OriginalDesign = false;
            this.ctl_receive_date_service_actual.zz_ShowNeedsSaveColor = true;
            this.ctl_receive_date_service_actual.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_receive_date_service_actual.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_receive_date_service_actual.zz_UseGlobalColor = false;
            this.ctl_receive_date_service_actual.zz_UseGlobalFont = false;
            // 
            // ctl_receive_date_service_due
            // 
            this.ctl_receive_date_service_due.AllowClear = false;
            this.ctl_receive_date_service_due.BackColor = System.Drawing.Color.Transparent;
            this.ctl_receive_date_service_due.Bold = false;
            this.ctl_receive_date_service_due.Caption = "Service Receiving Due Date";
            this.ctl_receive_date_service_due.Changed = false;
            this.ctl_receive_date_service_due.Location = new System.Drawing.Point(225, 247);
            this.ctl_receive_date_service_due.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_receive_date_service_due.Name = "ctl_receive_date_service_due";
            this.ctl_receive_date_service_due.Size = new System.Drawing.Size(224, 50);
            this.ctl_receive_date_service_due.SuppressEdit = false;
            this.ctl_receive_date_service_due.TabIndex = 13;
            this.ctl_receive_date_service_due.UseParentBackColor = false;
            this.ctl_receive_date_service_due.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_receive_date_service_due.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_receive_date_service_due.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_receive_date_service_due.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_receive_date_service_due.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_receive_date_service_due.zz_OriginalDesign = false;
            this.ctl_receive_date_service_due.zz_ShowNeedsSaveColor = true;
            this.ctl_receive_date_service_due.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_receive_date_service_due.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_receive_date_service_due.zz_UseGlobalColor = false;
            this.ctl_receive_date_service_due.zz_UseGlobalFont = false;
            // 
            // ctl_internal_customer
            // 
            this.ctl_internal_customer.AllCaps = false;
            this.ctl_internal_customer.BackColor = System.Drawing.Color.Transparent;
            this.ctl_internal_customer.Bold = false;
            this.ctl_internal_customer.Caption = "Internal Part";
            this.ctl_internal_customer.Changed = false;
            this.ctl_internal_customer.IsEmail = false;
            this.ctl_internal_customer.IsURL = false;
            this.ctl_internal_customer.Location = new System.Drawing.Point(177, 179);
            this.ctl_internal_customer.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_internal_customer.Name = "ctl_internal_customer";
            this.ctl_internal_customer.PasswordChar = '\0';
            this.ctl_internal_customer.Size = new System.Drawing.Size(224, 40);
            this.ctl_internal_customer.TabIndex = 10;
            this.ctl_internal_customer.UseParentBackColor = false;
            this.ctl_internal_customer.zz_Enabled = true;
            this.ctl_internal_customer.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_internal_customer.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_internal_customer.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_internal_customer.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_internal_customer.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_internal_customer.zz_OriginalDesign = false;
            this.ctl_internal_customer.zz_ShowLinkButton = false;
            this.ctl_internal_customer.zz_ShowNeedsSaveColor = true;
            this.ctl_internal_customer.zz_Text = "";
            this.ctl_internal_customer.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_internal_customer.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_internal_customer.zz_TextFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_internal_customer.zz_UseGlobalColor = false;
            this.ctl_internal_customer.zz_UseGlobalFont = false;
            // 
            // ctl_tracking_service_out
            // 
            this.ctl_tracking_service_out.BackColor = System.Drawing.Color.Transparent;
            this.ctl_tracking_service_out.Bold = false;
            this.ctl_tracking_service_out.Caption = "Tracking Number Out";
            this.ctl_tracking_service_out.Changed = false;
            this.ctl_tracking_service_out.DateLines = false;
            this.ctl_tracking_service_out.Location = new System.Drawing.Point(456, 247);
            this.ctl_tracking_service_out.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_tracking_service_out.Name = "ctl_tracking_service_out";
            this.ctl_tracking_service_out.Size = new System.Drawing.Size(305, 62);
            this.ctl_tracking_service_out.TabIndex = 14;
            this.ctl_tracking_service_out.UseParentBackColor = false;
            this.ctl_tracking_service_out.zz_Enabled = true;
            this.ctl_tracking_service_out.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_tracking_service_out.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_tracking_service_out.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_tracking_service_out.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_tracking_service_out.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_tracking_service_out.zz_OriginalDesign = false;
            this.ctl_tracking_service_out.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_tracking_service_out.zz_ShowNeedsSaveColor = true;
            this.ctl_tracking_service_out.zz_Text = "";
            this.ctl_tracking_service_out.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_tracking_service_out.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_tracking_service_out.zz_UseGlobalColor = false;
            this.ctl_tracking_service_out.zz_UseGlobalFont = false;
            // 
            // ctl_tracking_service_in
            // 
            this.ctl_tracking_service_in.BackColor = System.Drawing.Color.Transparent;
            this.ctl_tracking_service_in.Bold = false;
            this.ctl_tracking_service_in.Caption = "Tracking Number In";
            this.ctl_tracking_service_in.Changed = false;
            this.ctl_tracking_service_in.DateLines = false;
            this.ctl_tracking_service_in.Location = new System.Drawing.Point(456, 316);
            this.ctl_tracking_service_in.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_tracking_service_in.Name = "ctl_tracking_service_in";
            this.ctl_tracking_service_in.Size = new System.Drawing.Size(305, 62);
            this.ctl_tracking_service_in.TabIndex = 17;
            this.ctl_tracking_service_in.UseParentBackColor = false;
            this.ctl_tracking_service_in.zz_Enabled = true;
            this.ctl_tracking_service_in.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_tracking_service_in.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_tracking_service_in.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_tracking_service_in.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_tracking_service_in.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_tracking_service_in.zz_OriginalDesign = false;
            this.ctl_tracking_service_in.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_tracking_service_in.zz_ShowNeedsSaveColor = true;
            this.ctl_tracking_service_in.zz_Text = "";
            this.ctl_tracking_service_in.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_tracking_service_in.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_tracking_service_in.zz_UseGlobalColor = false;
            this.ctl_tracking_service_in.zz_UseGlobalFont = false;
            // 
            // ViewDetailService
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.Name = "ViewDetailService";
            this.Size = new System.Drawing.Size(1523, 651);
            this.ts.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.tabAttachments.ResumeLayout(false);
            this.gbAction1.ResumeLayout(false);
            this.gbAction1.PerformLayout();
            this.gbTop.ResumeLayout(false);
            this.gbTop.PerformLayout();
            this.tabServices.ResumeLayout(false);
            this.gbService.ResumeLayout(false);
            this.gbService.PerformLayout();
            this.tabPacking.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabServices;
        protected NewMethod.nEdit_Number ctlServiceQuantity;
        private System.Windows.Forms.Label lblPacked;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUnPacked;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPacking;
        private System.Windows.Forms.TabPage tabUnPacking;
        private NewMethod.nEdit_Date ctl_receive_date_service_actual;
        private NewMethod.nEdit_Date ctl_receive_date_service_due;
        private NewMethod.nEdit_Date ctl_ship_date_service_actual;
        private NewMethod.nEdit_Date ctl_ship_date_service_due;
        protected NewMethod.nList lvServices;
        protected System.Windows.Forms.GroupBox gbService;
        protected System.Windows.Forms.Button cmdSave;
        protected NewMethod.nEdit_String ctlServiceName;
        protected NewMethod.nEdit_Money ctlServiceCost;
        protected System.Windows.Forms.Label lblServiceTotal;
        protected System.Windows.Forms.Label label1;
        protected Win.Controls.Packing packing;
        protected NewMethod.nEdit_String ctl_internal_customer;
        public NewMethod.nEdit_Memo ctl_tracking_service_in;
        public NewMethod.nEdit_Memo ctl_tracking_service_out;
    }
}
