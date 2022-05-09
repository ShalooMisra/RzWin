using Tools.Database;
namespace Rz5
{
    partial class DutyMonitor
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
            if (disposing)
                InitUn();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DutyMonitor));
            this.tv = new System.Windows.Forms.TreeView();
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRun = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEnable = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.gb = new System.Windows.Forms.GroupBox();
            this.lblCheckNone = new System.Windows.Forms.LinkLabel();
            this.lblCheckAll = new System.Windows.Forms.LinkLabel();
            this.picActive = new System.Windows.Forms.PictureBox();
            this.cmdNewDuty = new System.Windows.Forms.Button();
            this.IM = new System.Windows.Forms.ImageList(this.components);
            this.cmdStartStop = new System.Windows.Forms.Button();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.gbDuty = new System.Windows.Forms.GroupBox();
            this.ctl_ideal_weekday = new NewMethod.nEdit_String();
            this.ctl_monthstodelete = new NewMethod.nEdit_List();
            this.opt4Hours = new System.Windows.Forms.RadioButton();
            this.cmdShowOptions = new System.Windows.Forms.Button();
            this.ctl_ideal_minute = new NewMethod.nEdit_Number();
            this.optWeek = new System.Windows.Forms.RadioButton();
            this.ctl_ideal_hour = new NewMethod.nEdit_Number();
            this.cmdClose = new System.Windows.Forms.Button();
            this.lblNext = new System.Windows.Forms.Label();
            this.optDay = new System.Windows.Forms.RadioButton();
            this.opt2Hours = new System.Windows.Forms.RadioButton();
            this.optHour = new System.Windows.Forms.RadioButton();
            this.opt30Minutes = new System.Windows.Forms.RadioButton();
            this.opt10Minutes = new System.Windows.Forms.RadioButton();
            this.opt5Minutes = new System.Windows.Forms.RadioButton();
            this.lblInterval = new System.Windows.Forms.Label();
            this.ctl_duty_function = new NewMethod.nEdit_List();
            this.cmdApply = new System.Windows.Forms.Button();
            this.tmrRunning = new System.Windows.Forms.Timer(this.components);
            this.wbSingle = new ToolsWin.BrowserPlain();
            this.ctl_duty_targets = new NewMethod.nEdit_List();
            this.mnu.SuspendLayout();
            this.gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picActive)).BeginInit();
            this.gbDuty.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv
            // 
            this.tv.CheckBoxes = true;
            this.tv.ContextMenuStrip = this.mnu;
            this.tv.Location = new System.Drawing.Point(127, 8);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(395, 490);
            this.tv.TabIndex = 0;
            this.tv.Click += new System.EventHandler(this.tv_Click);
            this.tv.DoubleClick += new System.EventHandler(this.tv_DoubleClick);
            this.tv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tv_MouseDown);
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRun,
            this.mnuEnable,
            this.mnuSearch,
            this.toolStripSeparator1,
            this.mnuDelete});
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(110, 98);
            this.mnu.Opening += new System.ComponentModel.CancelEventHandler(this.mnu_Opening);
            // 
            // mnuRun
            // 
            this.mnuRun.Name = "mnuRun";
            this.mnuRun.Size = new System.Drawing.Size(109, 22);
            this.mnuRun.Text = "&Run";
            this.mnuRun.Click += new System.EventHandler(this.mnuRun_Click);
            // 
            // mnuEnable
            // 
            this.mnuEnable.Name = "mnuEnable";
            this.mnuEnable.Size = new System.Drawing.Size(109, 22);
            this.mnuEnable.Text = "&Enable";
            this.mnuEnable.Click += new System.EventHandler(this.mnuEnable_Click);
            // 
            // mnuSearch
            // 
            this.mnuSearch.Name = "mnuSearch";
            this.mnuSearch.Size = new System.Drawing.Size(109, 22);
            this.mnuSearch.Text = "Search";
            this.mnuSearch.Click += new System.EventHandler(this.mnuSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(106, 6);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(109, 22);
            this.mnuDelete.Text = "&Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // gb
            // 
            this.gb.Controls.Add(this.lblCheckNone);
            this.gb.Controls.Add(this.lblCheckAll);
            this.gb.Controls.Add(this.picActive);
            this.gb.Controls.Add(this.cmdNewDuty);
            this.gb.Controls.Add(this.cmdStartStop);
            this.gb.Location = new System.Drawing.Point(3, 6);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(118, 492);
            this.gb.TabIndex = 1;
            this.gb.TabStop = false;
            // 
            // lblCheckNone
            // 
            this.lblCheckNone.AutoSize = true;
            this.lblCheckNone.Location = new System.Drawing.Point(46, 159);
            this.lblCheckNone.Name = "lblCheckNone";
            this.lblCheckNone.Size = new System.Drawing.Size(64, 13);
            this.lblCheckNone.TabIndex = 31;
            this.lblCheckNone.TabStop = true;
            this.lblCheckNone.Text = "check none";
            this.lblCheckNone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCheckNone_LinkClicked);
            // 
            // lblCheckAll
            // 
            this.lblCheckAll.AutoSize = true;
            this.lblCheckAll.Location = new System.Drawing.Point(59, 141);
            this.lblCheckAll.Name = "lblCheckAll";
            this.lblCheckAll.Size = new System.Drawing.Size(50, 13);
            this.lblCheckAll.TabIndex = 30;
            this.lblCheckAll.TabStop = true;
            this.lblCheckAll.Text = "check all";
            this.lblCheckAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCheckAll_LinkClicked);
            // 
            // picActive
            // 
            this.picActive.BackColor = System.Drawing.Color.Transparent;
            this.picActive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picActive.Location = new System.Drawing.Point(45, 19);
            this.picActive.Name = "picActive";
            this.picActive.Size = new System.Drawing.Size(25, 25);
            this.picActive.TabIndex = 29;
            this.picActive.TabStop = false;
            // 
            // cmdNewDuty
            // 
            this.cmdNewDuty.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewDuty.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNewDuty.ImageKey = "Clock.bmp";
            this.cmdNewDuty.ImageList = this.IM;
            this.cmdNewDuty.Location = new System.Drawing.Point(6, 97);
            this.cmdNewDuty.Name = "cmdNewDuty";
            this.cmdNewDuty.Size = new System.Drawing.Size(106, 35);
            this.cmdNewDuty.TabIndex = 1;
            this.cmdNewDuty.Text = " New Duty";
            this.cmdNewDuty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdNewDuty.UseVisualStyleBackColor = true;
            this.cmdNewDuty.Click += new System.EventHandler(this.cmdNewDuty_Click);
            // 
            // IM
            // 
            this.IM.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IM.ImageStream")));
            this.IM.TransparentColor = System.Drawing.Color.Fuchsia;
            this.IM.Images.SetKeyName(0, "Clock.bmp");
            this.IM.Images.SetKeyName(1, "Start.bmp");
            this.IM.Images.SetKeyName(2, "Stop.bmp");
            this.IM.Images.SetKeyName(3, "LED-Green.bmp");
            this.IM.Images.SetKeyName(4, "LED-Red.bmp");
            // 
            // cmdStartStop
            // 
            this.cmdStartStop.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdStartStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdStartStop.ImageKey = "Start.bmp";
            this.cmdStartStop.ImageList = this.IM;
            this.cmdStartStop.Location = new System.Drawing.Point(6, 56);
            this.cmdStartStop.Name = "cmdStartStop";
            this.cmdStartStop.Size = new System.Drawing.Size(106, 35);
            this.cmdStartStop.TabIndex = 0;
            this.cmdStartStop.Text = "Start";
            this.cmdStartStop.UseVisualStyleBackColor = true;
            this.cmdStartStop.Click += new System.EventHandler(this.cmdStartStop_Click);
            // 
            // tmr
            // 
            this.tmr.Interval = 30000;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(528, 8);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(352, 326);
            this.txtStatus.TabIndex = 2;
            this.txtStatus.WordWrap = false;
            // 
            // gbDuty
            // 
            this.gbDuty.BackColor = System.Drawing.Color.White;
            this.gbDuty.Controls.Add(this.ctl_duty_targets);
            this.gbDuty.Controls.Add(this.ctl_ideal_weekday);
            this.gbDuty.Controls.Add(this.ctl_monthstodelete);
            this.gbDuty.Controls.Add(this.opt4Hours);
            this.gbDuty.Controls.Add(this.cmdShowOptions);
            this.gbDuty.Controls.Add(this.ctl_ideal_minute);
            this.gbDuty.Controls.Add(this.optWeek);
            this.gbDuty.Controls.Add(this.ctl_ideal_hour);
            this.gbDuty.Controls.Add(this.cmdClose);
            this.gbDuty.Controls.Add(this.lblNext);
            this.gbDuty.Controls.Add(this.optDay);
            this.gbDuty.Controls.Add(this.opt2Hours);
            this.gbDuty.Controls.Add(this.optHour);
            this.gbDuty.Controls.Add(this.opt30Minutes);
            this.gbDuty.Controls.Add(this.opt10Minutes);
            this.gbDuty.Controls.Add(this.opt5Minutes);
            this.gbDuty.Controls.Add(this.lblInterval);
            this.gbDuty.Controls.Add(this.ctl_duty_function);
            this.gbDuty.Controls.Add(this.cmdApply);
            this.gbDuty.Location = new System.Drawing.Point(6, 506);
            this.gbDuty.Name = "gbDuty";
            this.gbDuty.Size = new System.Drawing.Size(516, 188);
            this.gbDuty.TabIndex = 3;
            this.gbDuty.TabStop = false;
            // 
            // ctl_ideal_weekday
            // 
            this.ctl_ideal_weekday.AllCaps = false;
            this.ctl_ideal_weekday.BackColor = System.Drawing.Color.White;
            this.ctl_ideal_weekday.Bold = false;
            this.ctl_ideal_weekday.Caption = "Ideal Day";
            this.ctl_ideal_weekday.Changed = false;
            this.ctl_ideal_weekday.IsEmail = false;
            this.ctl_ideal_weekday.IsURL = false;
            this.ctl_ideal_weekday.Location = new System.Drawing.Point(384, 34);
            this.ctl_ideal_weekday.Name = "ctl_ideal_weekday";
            this.ctl_ideal_weekday.PasswordChar = '\0';
            this.ctl_ideal_weekday.Size = new System.Drawing.Size(125, 35);
            this.ctl_ideal_weekday.TabIndex = 18;
            this.ctl_ideal_weekday.UseParentBackColor = true;
            this.ctl_ideal_weekday.zz_Enabled = true;
            this.ctl_ideal_weekday.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_ideal_weekday.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_ideal_weekday.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_ideal_weekday.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ideal_weekday.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_ideal_weekday.zz_OriginalDesign = false;
            this.ctl_ideal_weekday.zz_ShowLinkButton = false;
            this.ctl_ideal_weekday.zz_ShowNeedsSaveColor = true;
            this.ctl_ideal_weekday.zz_Text = "";
            this.ctl_ideal_weekday.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_ideal_weekday.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_ideal_weekday.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ideal_weekday.zz_UseGlobalColor = false;
            this.ctl_ideal_weekday.zz_UseGlobalFont = false;
            // 
            // ctl_monthstodelete
            // 
            this.ctl_monthstodelete.AllCaps = false;
            this.ctl_monthstodelete.AllowEdit = false;
            this.ctl_monthstodelete.BackColor = System.Drawing.Color.White;
            this.ctl_monthstodelete.Bold = false;
            this.ctl_monthstodelete.Caption = "Delete Months Old";
            this.ctl_monthstodelete.Changed = false;
            this.ctl_monthstodelete.ListName = null;
            this.ctl_monthstodelete.Location = new System.Drawing.Point(9, 117);
            this.ctl_monthstodelete.Name = "ctl_monthstodelete";
            this.ctl_monthstodelete.SimpleList = "6|3|1";
            this.ctl_monthstodelete.Size = new System.Drawing.Size(236, 22);
            this.ctl_monthstodelete.TabIndex = 17;
            this.ctl_monthstodelete.UseParentBackColor = true;
            this.ctl_monthstodelete.Visible = false;
            this.ctl_monthstodelete.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_monthstodelete.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_monthstodelete.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_monthstodelete.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_monthstodelete.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.Left;
            this.ctl_monthstodelete.zz_OriginalDesign = false;
            this.ctl_monthstodelete.zz_ShowNeedsSaveColor = false;
            this.ctl_monthstodelete.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_monthstodelete.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_monthstodelete.zz_UseGlobalColor = false;
            this.ctl_monthstodelete.zz_UseGlobalFont = false;
            // 
            // opt4Hours
            // 
            this.opt4Hours.AutoSize = true;
            this.opt4Hours.Location = new System.Drawing.Point(262, 102);
            this.opt4Hours.Name = "opt4Hours";
            this.opt4Hours.Size = new System.Drawing.Size(92, 17);
            this.opt4Hours.TabIndex = 16;
            this.opt4Hours.Text = "Every 4 Hours";
            this.opt4Hours.UseVisualStyleBackColor = true;
            // 
            // cmdShowOptions
            // 
            this.cmdShowOptions.Location = new System.Drawing.Point(9, 114);
            this.cmdShowOptions.Name = "cmdShowOptions";
            this.cmdShowOptions.Size = new System.Drawing.Size(234, 25);
            this.cmdShowOptions.TabIndex = 15;
            this.cmdShowOptions.Text = "Show Other Options";
            this.cmdShowOptions.UseVisualStyleBackColor = true;
            this.cmdShowOptions.Visible = false;
            this.cmdShowOptions.Click += new System.EventHandler(this.cmdShowOptions_Click);
            // 
            // ctl_ideal_minute
            // 
            this.ctl_ideal_minute.BackColor = System.Drawing.Color.White;
            this.ctl_ideal_minute.Bold = false;
            this.ctl_ideal_minute.Caption = "Ideal Minute";
            this.ctl_ideal_minute.Changed = false;
            this.ctl_ideal_minute.CurrentType = FieldType.Unknown;
            this.ctl_ideal_minute.Location = new System.Drawing.Point(381, 102);
            this.ctl_ideal_minute.Name = "ctl_ideal_minute";
            this.ctl_ideal_minute.Size = new System.Drawing.Size(128, 21);
            this.ctl_ideal_minute.TabIndex = 14;
            this.ctl_ideal_minute.UseParentBackColor = true;
            this.ctl_ideal_minute.zz_Enabled = true;
            this.ctl_ideal_minute.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_ideal_minute.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_ideal_minute.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_ideal_minute.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_ideal_minute.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.Left;
            this.ctl_ideal_minute.zz_OriginalDesign = false;
            this.ctl_ideal_minute.zz_ShowErrorColor = true;
            this.ctl_ideal_minute.zz_ShowNeedsSaveColor = true;
            this.ctl_ideal_minute.zz_Text = "";
            this.ctl_ideal_minute.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_ideal_minute.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_ideal_minute.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ideal_minute.zz_UseGlobalColor = false;
            this.ctl_ideal_minute.zz_UseGlobalFont = false;
            // 
            // optWeek
            // 
            this.optWeek.AutoSize = true;
            this.optWeek.Location = new System.Drawing.Point(262, 132);
            this.optWeek.Name = "optWeek";
            this.optWeek.Size = new System.Drawing.Size(84, 17);
            this.optWeek.TabIndex = 13;
            this.optWeek.Text = "Every Week";
            this.optWeek.UseVisualStyleBackColor = true;
            // 
            // ctl_ideal_hour
            // 
            this.ctl_ideal_hour.BackColor = System.Drawing.Color.White;
            this.ctl_ideal_hour.Bold = false;
            this.ctl_ideal_hour.Caption = "Ideal Hour";
            this.ctl_ideal_hour.Changed = false;
            this.ctl_ideal_hour.CurrentType = FieldType.Unknown;
            this.ctl_ideal_hour.Location = new System.Drawing.Point(386, 74);
            this.ctl_ideal_hour.Name = "ctl_ideal_hour";
            this.ctl_ideal_hour.Size = new System.Drawing.Size(124, 21);
            this.ctl_ideal_hour.TabIndex = 12;
            this.ctl_ideal_hour.UseParentBackColor = true;
            this.ctl_ideal_hour.zz_Enabled = true;
            this.ctl_ideal_hour.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_ideal_hour.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_ideal_hour.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_ideal_hour.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_ideal_hour.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.Left;
            this.ctl_ideal_hour.zz_OriginalDesign = false;
            this.ctl_ideal_hour.zz_ShowErrorColor = true;
            this.ctl_ideal_hour.zz_ShowNeedsSaveColor = true;
            this.ctl_ideal_hour.zz_Text = "";
            this.ctl_ideal_hour.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_ideal_hour.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_ideal_hour.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ideal_hour.zz_UseGlobalColor = false;
            this.ctl_ideal_hour.zz_UseGlobalFont = false;
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(482, 11);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(28, 23);
            this.cmdClose.TabIndex = 11;
            this.cmdClose.Text = "x";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lblNext
            // 
            this.lblNext.AutoSize = true;
            this.lblNext.Location = new System.Drawing.Point(396, 138);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(39, 13);
            this.lblNext.TabIndex = 10;
            this.lblNext.Text = "<next>";
            // 
            // optDay
            // 
            this.optDay.AutoSize = true;
            this.optDay.Location = new System.Drawing.Point(262, 117);
            this.optDay.Name = "optDay";
            this.optDay.Size = new System.Drawing.Size(74, 17);
            this.optDay.TabIndex = 9;
            this.optDay.Text = "Every Day";
            this.optDay.UseVisualStyleBackColor = true;
            // 
            // opt2Hours
            // 
            this.opt2Hours.AutoSize = true;
            this.opt2Hours.Location = new System.Drawing.Point(262, 87);
            this.opt2Hours.Name = "opt2Hours";
            this.opt2Hours.Size = new System.Drawing.Size(92, 17);
            this.opt2Hours.TabIndex = 8;
            this.opt2Hours.Text = "Every 2 Hours";
            this.opt2Hours.UseVisualStyleBackColor = true;
            // 
            // optHour
            // 
            this.optHour.AutoSize = true;
            this.optHour.Location = new System.Drawing.Point(262, 72);
            this.optHour.Name = "optHour";
            this.optHour.Size = new System.Drawing.Size(78, 17);
            this.optHour.TabIndex = 7;
            this.optHour.Text = "Every Hour";
            this.optHour.UseVisualStyleBackColor = true;
            // 
            // opt30Minutes
            // 
            this.opt30Minutes.AutoSize = true;
            this.opt30Minutes.Location = new System.Drawing.Point(262, 57);
            this.opt30Minutes.Name = "opt30Minutes";
            this.opt30Minutes.Size = new System.Drawing.Size(107, 17);
            this.opt30Minutes.TabIndex = 6;
            this.opt30Minutes.Text = "Every 30 Minutes";
            this.opt30Minutes.UseVisualStyleBackColor = true;
            // 
            // opt10Minutes
            // 
            this.opt10Minutes.AutoSize = true;
            this.opt10Minutes.Location = new System.Drawing.Point(262, 42);
            this.opt10Minutes.Name = "opt10Minutes";
            this.opt10Minutes.Size = new System.Drawing.Size(107, 17);
            this.opt10Minutes.TabIndex = 5;
            this.opt10Minutes.Text = "Every 10 Minutes";
            this.opt10Minutes.UseVisualStyleBackColor = true;
            // 
            // opt5Minutes
            // 
            this.opt5Minutes.AutoSize = true;
            this.opt5Minutes.Checked = true;
            this.opt5Minutes.Location = new System.Drawing.Point(262, 27);
            this.opt5Minutes.Name = "opt5Minutes";
            this.opt5Minutes.Size = new System.Drawing.Size(101, 17);
            this.opt5Minutes.TabIndex = 4;
            this.opt5Minutes.TabStop = true;
            this.opt5Minutes.Text = "Every 5 Minutes";
            this.opt5Minutes.UseVisualStyleBackColor = true;
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(263, 12);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(42, 13);
            this.lblInterval.TabIndex = 3;
            this.lblInterval.Text = "Interval";
            // 
            // ctl_duty_function
            // 
            this.ctl_duty_function.AllCaps = false;
            this.ctl_duty_function.AllowEdit = false;
            this.ctl_duty_function.BackColor = System.Drawing.Color.White;
            this.ctl_duty_function.Bold = false;
            this.ctl_duty_function.Caption = "Function";
            this.ctl_duty_function.Changed = false;
            this.ctl_duty_function.ListName = null;
            this.ctl_duty_function.Location = new System.Drawing.Point(9, 17);
            this.ctl_duty_function.Name = "ctl_duty_function";
            this.ctl_duty_function.SimpleList = "";
            this.ctl_duty_function.Size = new System.Drawing.Size(234, 42);
            this.ctl_duty_function.TabIndex = 2;
            this.ctl_duty_function.UseParentBackColor = true;
            this.ctl_duty_function.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_duty_function.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_duty_function.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_duty_function.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_duty_function.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_duty_function.zz_OriginalDesign = true;
            this.ctl_duty_function.zz_ShowNeedsSaveColor = true;
            this.ctl_duty_function.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_duty_function.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_duty_function.zz_UseGlobalColor = false;
            this.ctl_duty_function.zz_UseGlobalFont = false;
            this.ctl_duty_function.SelectionChanged += new NewMethod.nEdit_List.SelectionChangedHandler(this.ctl_duty_function_SelectionChanged);
            // 
            // cmdApply
            // 
            this.cmdApply.Location = new System.Drawing.Point(399, 154);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(111, 25);
            this.cmdApply.TabIndex = 1;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // tmrRunning
            // 
            this.tmrRunning.Enabled = true;
            this.tmrRunning.Interval = 1000;
            this.tmrRunning.Tick += new System.EventHandler(this.tmrRunning_Tick);
            // 
            // wbSingle
            // 
            this.wbSingle.Location = new System.Drawing.Point(528, 340);
            this.wbSingle.Name = "wbSingle";
            this.wbSingle.ShowControls = false;
            this.wbSingle.Silent = false;
            this.wbSingle.Size = new System.Drawing.Size(352, 191);
            this.wbSingle.TabIndex = 4;
            // 
            // ctl_duty_targets
            // 
            this.ctl_duty_targets.AllCaps = false;
            this.ctl_duty_targets.AllowEdit = false;
            this.ctl_duty_targets.BackColor = System.Drawing.Color.White;
            this.ctl_duty_targets.Bold = false;
            this.ctl_duty_targets.Caption = "Database";
            this.ctl_duty_targets.Changed = false;
            this.ctl_duty_targets.ListName = null;
            this.ctl_duty_targets.Location = new System.Drawing.Point(9, 65);
            this.ctl_duty_targets.Name = "ctl_duty_targets";
            this.ctl_duty_targets.SimpleList = "";
            this.ctl_duty_targets.Size = new System.Drawing.Size(234, 42);
            this.ctl_duty_targets.TabIndex = 19;
            this.ctl_duty_targets.UseParentBackColor = true;
            this.ctl_duty_targets.Visible = false;
            this.ctl_duty_targets.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_duty_targets.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_duty_targets.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_duty_targets.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_duty_targets.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_duty_targets.zz_OriginalDesign = true;
            this.ctl_duty_targets.zz_ShowNeedsSaveColor = true;
            this.ctl_duty_targets.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_duty_targets.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_duty_targets.zz_UseGlobalColor = false;
            this.ctl_duty_targets.zz_UseGlobalFont = false;
            // 
            // DutyMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.wbSingle);
            this.Controls.Add(this.gbDuty);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.gb);
            this.Controls.Add(this.tv);
            this.Name = "DutyMonitor";
            this.Size = new System.Drawing.Size(900, 754);
            this.Resize += new System.EventHandler(this.DutyMonitor_Resize);
            this.mnu.ResumeLayout(false);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picActive)).EndInit();
            this.gbDuty.ResumeLayout(false);
            this.gbDuty.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Button cmdStartStop;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.ContextMenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem mnuRun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.GroupBox gbDuty;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.Button cmdNewDuty;
        private NewMethod.nEdit_List ctl_duty_function;
        private System.Windows.Forms.RadioButton optHour;
        private System.Windows.Forms.RadioButton opt30Minutes;
        private System.Windows.Forms.RadioButton opt10Minutes;
        private System.Windows.Forms.RadioButton opt5Minutes;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.RadioButton optDay;
        private System.Windows.Forms.RadioButton opt2Hours;
        private System.Windows.Forms.ToolStripMenuItem mnuEnable;
        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.Button cmdClose;
        private NewMethod.nEdit_Number ctl_ideal_hour;
        private System.Windows.Forms.PictureBox picActive;
        private System.Windows.Forms.ImageList IM;
        private System.Windows.Forms.Timer tmrRunning;
        private System.Windows.Forms.RadioButton optWeek;
        private NewMethod.nEdit_Number ctl_ideal_minute;
        private System.Windows.Forms.Button cmdShowOptions;
        private System.Windows.Forms.RadioButton opt4Hours;
        private NewMethod.nEdit_List ctl_monthstodelete;
        private System.Windows.Forms.ToolStripMenuItem mnuSearch;
        private NewMethod.nEdit_String ctl_ideal_weekday;
        private System.Windows.Forms.LinkLabel lblCheckNone;
        private System.Windows.Forms.LinkLabel lblCheckAll;
        private ToolsWin.BrowserPlain wbSingle;
        private NewMethod.nEdit_List ctl_duty_targets;
    }
}
