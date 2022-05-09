using System;
using System.ComponentModel;
using Core;

namespace NewMethod
{
    partial class nList
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
            {
                try
                {
                    ClearMenu();

                    if (AsyncThread != null)
                    {
                        try
                        {
                            AsyncThread.DoWork -= new DoWorkEventHandler(AsyncThread_DoWork);
                            AsyncThread.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(AsyncThread_RunWorkerCompleted);
                            AsyncThread = null;
                        }
                        catch (System.Exception)
                        { }
                    }

                    try
                    {
                        //xSys.UnRegisterNotifyClass(this);
                        NMWin.Sys.Changed -= new DeltaHandler(Sys_Changed);
                        AboutToThrow = null;
                        AboutToAdd = null;
                        ObjectClicked = null;
                        FinishedFill = null;
                        CurrentItems = null;
                        CurrentTemplate = null;
                    }
                    catch (System.Exception)
                    { }

                    try
                    {
                        this.mnu.Opening -= new System.ComponentModel.CancelEventHandler(this.mnu_Opening);
                        this.xTime.Tick -= new System.EventHandler(this.xTime_Tick);
                        this.cmdSave.Click -= new System.EventHandler(this.cmdSave_Click);
                        this.cmdSearch.Click -= new System.EventHandler(this.cmdSearch_Click);
                        this.cmdSQL.Click -= new System.EventHandler(this.cmdSQL_Click);
                        this.cmdExport.Click -= new System.EventHandler(this.cmdExport_Click);
                        this.cmdAll.Click -= new System.EventHandler(this.cmdAll_Click);
                        this.cmdClear.Click -= new System.EventHandler(this.cmdClear_Click);
                        this.chkLines.CheckedChanged -= new System.EventHandler(this.chkLines_CheckedChanged);
                        this.pic6.Click -= new System.EventHandler(this.pic_Click);
                        this.pic5.Click -= new System.EventHandler(this.pic_Click);
                        this.pic4.Click -= new System.EventHandler(this.pic_Click);
                        this.pic3.Click -= new System.EventHandler(this.pic_Click);
                        this.pic2.Click -= new System.EventHandler(this.pic_Click);
                        this.pic1.Click -= new System.EventHandler(this.pic_Click);
                        this.cboColors.SelectedIndexChanged -= new System.EventHandler(this.cboColors_SelectedIndexChanged);
                        this.cmdColumns.Click -= new System.EventHandler(this.cmdColumns_Click);
                        this.cmdAdd.Click -= new System.EventHandler(this.cmdAdd_Click);
                        this.cmdSHRight.Click -= new System.EventHandler(this.cmdSHRight_Click);
                        this.AsyncTimer.Tick -= new System.EventHandler(this.AsyncTimer_Tick);
                        this.chkRefresh.CheckedChanged -= new System.EventHandler(this.chkRefresh_CheckedChanged);
                        this.chkUnlimited.CheckedChanged -= new System.EventHandler(this.chkUnlimited_CheckedChanged);
                        this.lv.DoubleClick -= new System.EventHandler(this.lv_DoubleClick);
                        this.lv.ItemMouseHover -= new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.lv_ItemMouseHover);
                        this.lv.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.lv_MouseUp);
                        this.lv.ColumnClick -= new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
                        this.lv.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.lv_MouseMove);
                        this.lv.ItemSelectionChanged -= new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lv_ItemSelectionChanged);
                        this.lv.ColumnReordered -= new System.Windows.Forms.ColumnReorderedEventHandler(this.lv_ColumnReordered);
                        this.lv.ColumnResize -= new ManagedControls.ManagedListView.ColumnResizeEventHandler(this.lv_ColumnResize);
                        this.lv.MouseDown -= new System.Windows.Forms.MouseEventHandler(this.lv_MouseDown);
                        this.lv.Click -= new System.EventHandler(this.lv_Click);
                        this.Load -= new System.EventHandler(this.nList_Load_1);
                        this.Resize -= new System.EventHandler(this.nList_Resize);

                    }
                    catch (System.Exception)
                    { 
                    }
                }
                catch (System.Exception)
                { }

                try
                {
                    if (lv != null)
                    {
                        Controls.Remove(lv);
                        lv.Dispose();
                        lv = null;
                    }
                }
                catch (System.Exception)
                {

                }


                if( components != null )
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nList));
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xTime = new System.Windows.Forms.Timer(this.components);
            this.gbRight = new System.Windows.Forms.GroupBox();
            this.cmdCsv = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdSQL = new System.Windows.Forms.Button();
            this.cmdExport = new System.Windows.Forms.Button();
            this.cmdAll = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.chkLines = new System.Windows.Forms.CheckBox();
            this.pic6 = new System.Windows.Forms.PictureBox();
            this.pic5 = new System.Windows.Forms.PictureBox();
            this.pic4 = new System.Windows.Forms.PictureBox();
            this.pic3 = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.cboColors = new System.Windows.Forms.ComboBox();
            this.lblColors = new System.Windows.Forms.Label();
            this.cmdColumns = new System.Windows.Forms.Button();
            this.gbBottom = new System.Windows.Forms.GroupBox();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdSHRight = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.AsyncTimer = new System.Windows.Forms.Timer(this.components);
            this.chkRefresh = new System.Windows.Forms.CheckBox();
            this.chkUnlimited = new System.Windows.Forms.CheckBox();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.lv = new ManagedControls.ManagedListView();
            this.lblCaption = new System.Windows.Forms.Label();
            this.gbRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.gbBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnu
            // 
            this.mnu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(61, 4);
            this.mnu.Opening += new System.ComponentModel.CancelEventHandler(this.mnu_Opening);
            // 
            // xTime
            // 
            this.xTime.Tick += new System.EventHandler(this.xTime_Tick);
            // 
            // gbRight
            // 
            this.gbRight.BackColor = System.Drawing.Color.White;
            this.gbRight.Controls.Add(this.cmdCsv);
            this.gbRight.Controls.Add(this.cmdSave);
            this.gbRight.Controls.Add(this.cmdSearch);
            this.gbRight.Controls.Add(this.cmdSQL);
            this.gbRight.Controls.Add(this.cmdExport);
            this.gbRight.Controls.Add(this.cmdAll);
            this.gbRight.Controls.Add(this.cmdClear);
            this.gbRight.Controls.Add(this.chkLines);
            this.gbRight.Controls.Add(this.pic6);
            this.gbRight.Controls.Add(this.pic5);
            this.gbRight.Controls.Add(this.pic4);
            this.gbRight.Controls.Add(this.pic3);
            this.gbRight.Controls.Add(this.pic2);
            this.gbRight.Controls.Add(this.pic1);
            this.gbRight.Controls.Add(this.cboColors);
            this.gbRight.Controls.Add(this.lblColors);
            this.gbRight.Controls.Add(this.cmdColumns);
            this.gbRight.Location = new System.Drawing.Point(467, 12);
            this.gbRight.Margin = new System.Windows.Forms.Padding(4);
            this.gbRight.Name = "gbRight";
            this.gbRight.Padding = new System.Windows.Forms.Padding(4);
            this.gbRight.Size = new System.Drawing.Size(77, 583);
            this.gbRight.TabIndex = 7;
            this.gbRight.TabStop = false;
            // 
            // cmdCsv
            // 
            this.cmdCsv.Location = new System.Drawing.Point(5, 89);
            this.cmdCsv.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCsv.Name = "cmdCsv";
            this.cmdCsv.Size = new System.Drawing.Size(68, 23);
            this.cmdCsv.TabIndex = 17;
            this.cmdCsv.Text = "Csv";
            this.cmdCsv.UseVisualStyleBackColor = true;
            this.cmdCsv.Click += new System.EventHandler(this.cmdCsv_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(5, 36);
            this.cmdSave.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(67, 25);
            this.cmdSave.TabIndex = 16;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(5, 114);
            this.cmdSearch.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(67, 23);
            this.cmdSearch.TabIndex = 15;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdSQL
            // 
            this.cmdSQL.Location = new System.Drawing.Point(5, 166);
            this.cmdSQL.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSQL.Name = "cmdSQL";
            this.cmdSQL.Size = new System.Drawing.Size(67, 25);
            this.cmdSQL.TabIndex = 10;
            this.cmdSQL.Text = "SQL";
            this.cmdSQL.UseVisualStyleBackColor = true;
            this.cmdSQL.Click += new System.EventHandler(this.cmdSQL_Click);
            // 
            // cmdExport
            // 
            this.cmdExport.Location = new System.Drawing.Point(5, 63);
            this.cmdExport.Margin = new System.Windows.Forms.Padding(4);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(68, 23);
            this.cmdExport.TabIndex = 14;
            this.cmdExport.Text = "Excel";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // cmdAll
            // 
            this.cmdAll.Location = new System.Drawing.Point(9, 438);
            this.cmdAll.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAll.Name = "cmdAll";
            this.cmdAll.Size = new System.Drawing.Size(60, 25);
            this.cmdAll.TabIndex = 13;
            this.cmdAll.Text = "All";
            this.cmdAll.UseVisualStyleBackColor = true;
            this.cmdAll.Click += new System.EventHandler(this.cmdAll_Click);
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(5, 140);
            this.cmdClear.Margin = new System.Windows.Forms.Padding(4);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(67, 23);
            this.cmdClear.TabIndex = 12;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // chkLines
            // 
            this.chkLines.AutoSize = true;
            this.chkLines.Location = new System.Drawing.Point(8, 218);
            this.chkLines.Margin = new System.Windows.Forms.Padding(4);
            this.chkLines.Name = "chkLines";
            this.chkLines.Size = new System.Drawing.Size(64, 21);
            this.chkLines.TabIndex = 11;
            this.chkLines.Text = "Lines";
            this.chkLines.UseVisualStyleBackColor = true;
            this.chkLines.CheckedChanged += new System.EventHandler(this.chkLines_CheckedChanged);
            // 
            // pic6
            // 
            this.pic6.Location = new System.Drawing.Point(12, 414);
            this.pic6.Margin = new System.Windows.Forms.Padding(4);
            this.pic6.Name = "pic6";
            this.pic6.Size = new System.Drawing.Size(28, 21);
            this.pic6.TabIndex = 9;
            this.pic6.TabStop = false;
            this.pic6.Tag = "6";
            this.pic6.Click += new System.EventHandler(this.pic_Click);
            // 
            // pic5
            // 
            this.pic5.Location = new System.Drawing.Point(12, 388);
            this.pic5.Margin = new System.Windows.Forms.Padding(4);
            this.pic5.Name = "pic5";
            this.pic5.Size = new System.Drawing.Size(28, 21);
            this.pic5.TabIndex = 8;
            this.pic5.TabStop = false;
            this.pic5.Tag = "5";
            this.pic5.Click += new System.EventHandler(this.pic_Click);
            // 
            // pic4
            // 
            this.pic4.Location = new System.Drawing.Point(12, 362);
            this.pic4.Margin = new System.Windows.Forms.Padding(4);
            this.pic4.Name = "pic4";
            this.pic4.Size = new System.Drawing.Size(28, 21);
            this.pic4.TabIndex = 7;
            this.pic4.TabStop = false;
            this.pic4.Tag = "4";
            this.pic4.Click += new System.EventHandler(this.pic_Click);
            // 
            // pic3
            // 
            this.pic3.Location = new System.Drawing.Point(12, 336);
            this.pic3.Margin = new System.Windows.Forms.Padding(4);
            this.pic3.Name = "pic3";
            this.pic3.Size = new System.Drawing.Size(28, 21);
            this.pic3.TabIndex = 6;
            this.pic3.TabStop = false;
            this.pic3.Tag = "3";
            this.pic3.Click += new System.EventHandler(this.pic_Click);
            // 
            // pic2
            // 
            this.pic2.Location = new System.Drawing.Point(12, 310);
            this.pic2.Margin = new System.Windows.Forms.Padding(4);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(28, 21);
            this.pic2.TabIndex = 5;
            this.pic2.TabStop = false;
            this.pic2.Tag = "2";
            this.pic2.Click += new System.EventHandler(this.pic_Click);
            // 
            // pic1
            // 
            this.pic1.Location = new System.Drawing.Point(12, 284);
            this.pic1.Margin = new System.Windows.Forms.Padding(4);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(28, 21);
            this.pic1.TabIndex = 4;
            this.pic1.TabStop = false;
            this.pic1.Tag = "1";
            this.pic1.Click += new System.EventHandler(this.pic_Click);
            // 
            // cboColors
            // 
            this.cboColors.FormattingEnabled = true;
            this.cboColors.Items.AddRange(new object[] {
            "none",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cboColors.Location = new System.Drawing.Point(8, 255);
            this.cboColors.Margin = new System.Windows.Forms.Padding(4);
            this.cboColors.Name = "cboColors";
            this.cboColors.Size = new System.Drawing.Size(59, 24);
            this.cboColors.TabIndex = 3;
            this.cboColors.SelectedIndexChanged += new System.EventHandler(this.cboColors_SelectedIndexChanged);
            // 
            // lblColors
            // 
            this.lblColors.AutoSize = true;
            this.lblColors.Location = new System.Drawing.Point(8, 236);
            this.lblColors.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColors.Name = "lblColors";
            this.lblColors.Size = new System.Drawing.Size(48, 17);
            this.lblColors.TabIndex = 2;
            this.lblColors.Text = "Colors";
            // 
            // cmdColumns
            // 
            this.cmdColumns.Location = new System.Drawing.Point(5, 10);
            this.cmdColumns.Margin = new System.Windows.Forms.Padding(4);
            this.cmdColumns.Name = "cmdColumns";
            this.cmdColumns.Size = new System.Drawing.Size(67, 25);
            this.cmdColumns.TabIndex = 0;
            this.cmdColumns.Text = "Cols";
            this.cmdColumns.UseVisualStyleBackColor = true;
            this.cmdColumns.Click += new System.EventHandler(this.cmdColumns_Click);
            // 
            // gbBottom
            // 
            this.gbBottom.Controls.Add(this.cmdAdd);
            this.gbBottom.Location = new System.Drawing.Point(20, 596);
            this.gbBottom.Margin = new System.Windows.Forms.Padding(4);
            this.gbBottom.Name = "gbBottom";
            this.gbBottom.Padding = new System.Windows.Forms.Padding(4);
            this.gbBottom.Size = new System.Drawing.Size(524, 54);
            this.gbBottom.TabIndex = 4;
            this.gbBottom.TabStop = false;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdAdd.Location = new System.Drawing.Point(4, 19);
            this.cmdAdd.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(516, 31);
            this.cmdAdd.TabIndex = 2;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdSHRight
            // 
            this.cmdSHRight.Location = new System.Drawing.Point(301, 576);
            this.cmdSHRight.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSHRight.Name = "cmdSHRight";
            this.cmdSHRight.Size = new System.Drawing.Size(19, 17);
            this.cmdSHRight.TabIndex = 8;
            this.cmdSHRight.UseVisualStyleBackColor = true;
            this.cmdSHRight.Click += new System.EventHandler(this.cmdSHRight_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(64, 576);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(81, 17);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "No Results.";
            this.lblStatus.DoubleClick += new System.EventHandler(this.lblStatus_DoubleClick);
            // 
            // AsyncTimer
            // 
            this.AsyncTimer.Tick += new System.EventHandler(this.AsyncTimer_Tick);
            // 
            // chkRefresh
            // 
            this.chkRefresh.AutoSize = true;
            this.chkRefresh.Checked = true;
            this.chkRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRefresh.ForeColor = System.Drawing.Color.Gray;
            this.chkRefresh.Location = new System.Drawing.Point(333, 576);
            this.chkRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.chkRefresh.Name = "chkRefresh";
            this.chkRefresh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkRefresh.Size = new System.Drawing.Size(109, 21);
            this.chkRefresh.TabIndex = 11;
            this.chkRefresh.Text = "AutoRefresh";
            this.chkRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRefresh.UseVisualStyleBackColor = true;
            this.chkRefresh.CheckedChanged += new System.EventHandler(this.chkRefresh_CheckedChanged);
            // 
            // chkUnlimited
            // 
            this.chkUnlimited.AutoSize = true;
            this.chkUnlimited.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUnlimited.ForeColor = System.Drawing.Color.Gray;
            this.chkUnlimited.Location = new System.Drawing.Point(201, 576);
            this.chkUnlimited.Margin = new System.Windows.Forms.Padding(4);
            this.chkUnlimited.Name = "chkUnlimited";
            this.chkUnlimited.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkUnlimited.Size = new System.Drawing.Size(88, 21);
            this.chkUnlimited.TabIndex = 12;
            this.chkUnlimited.Text = "Unlimited";
            this.chkUnlimited.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkUnlimited.UseVisualStyleBackColor = true;
            this.chkUnlimited.CheckedChanged += new System.EventHandler(this.chkUnlimited_CheckedChanged);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Magenta;
            this.il.Images.SetKeyName(0, "cloud.jpg");
            this.il.Images.SetKeyName(1, "earth.jpg");
            this.il.Images.SetKeyName(2, "fire.jpg");
            this.il.Images.SetKeyName(3, "lightning.jpg");
            this.il.Images.SetKeyName(4, "fa_dollar.bmp");
            this.il.Images.SetKeyName(5, "fa_calendar.bmp");
            this.il.Images.SetKeyName(6, "fa_plane.bmp");
            this.il.Images.SetKeyName(7, "accepted");
            // 
            // lv
            // 
            this.lv.AllowDrop = true;
            this.lv.ContextMenuStrip = this.mnu;
            this.lv.HideSelection = false;
            this.lv.LargeImageList = this.il;
            this.lv.Location = new System.Drawing.Point(68, 59);
            this.lv.Margin = new System.Windows.Forms.Padding(4);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(377, 512);
            this.lv.SmallImageList = this.il;
            this.lv.TabIndex = 0;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.ColumnResize += new ManagedControls.ManagedListView.ColumnResizeEventHandler(this.lv_ColumnResize_1);
            this.lv.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
            this.lv.ColumnReordered += new System.Windows.Forms.ColumnReorderedEventHandler(this.lv_ColumnReordered);
            this.lv.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lv_ItemDrag);
            this.lv.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.lv_ItemMouseHover);
            this.lv.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lv_ItemSelectionChanged);
            this.lv.Click += new System.EventHandler(this.lv_Click);
            this.lv.DragDrop += new System.Windows.Forms.DragEventHandler(this.lv_DragDrop);
            this.lv.DragEnter += new System.Windows.Forms.DragEventHandler(this.lv_DragEnter);
            this.lv.DragOver += new System.Windows.Forms.DragEventHandler(this.lv_DragOver);
            this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
            this.lv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lv_MouseDown);
            this.lv.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lv_MouseMove);
            this.lv.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lv_MouseUp);
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Location = new System.Drawing.Point(4, 12);
            this.lblCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(70, 17);
            this.lblCaption.TabIndex = 13;
            this.lblCaption.Text = "<caption>";
            // 
            // nList
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.cmdSHRight);
            this.Controls.Add(this.chkUnlimited);
            this.Controls.Add(this.chkRefresh);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.gbRight);
            this.Controls.Add(this.gbBottom);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "nList";
            this.Size = new System.Drawing.Size(767, 654);
            this.Load += new System.EventHandler(this.nList_Load_1);
            this.Resize += new System.EventHandler(this.nList_Resize);
            this.gbRight.ResumeLayout(false);
            this.gbRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.gbBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ManagedControls.ManagedListView lv;
        private System.Windows.Forms.Timer xTime;
        private System.Windows.Forms.GroupBox gbRight;
        private System.Windows.Forms.GroupBox gbBottom;
        private System.Windows.Forms.Button cmdSHRight;
        private System.Windows.Forms.Button cmdColumns;
        private System.Windows.Forms.ComboBox cboColors;
        private System.Windows.Forms.Label lblColors;
        private System.Windows.Forms.PictureBox pic6;
        private System.Windows.Forms.PictureBox pic5;
        private System.Windows.Forms.PictureBox pic4;
        private System.Windows.Forms.PictureBox pic3;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button cmdSQL;
        private System.Windows.Forms.CheckBox chkLines;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Timer AsyncTimer;
        private System.Windows.Forms.Button cmdAll;
        private System.Windows.Forms.CheckBox chkRefresh;
        private System.Windows.Forms.CheckBox chkUnlimited;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.ImageList il;
        public System.Windows.Forms.ContextMenuStrip mnu;
        private System.Windows.Forms.Button cmdCsv;
        private System.Windows.Forms.Label lblCaption;
    }
}
