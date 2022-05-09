using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using OfficeOpenXml;

using Tools.Database;
using Core;
using CoreWin;

namespace NewMethod
{
    public partial class nList : UserControl, IEnableable, InList  //, IChangeSubscriber
    {
        public SysNewMethod xSys
        {
            get
            {
                return NMWin.ContextDefault.xSys;
            }
        }

        //Private Delegates
        private delegate void SearchCompleteHandler(DataTable rst, int seconds);
        private delegate void ShowResultsHandler(DataTable rst);
        //Public Vars
        public static bool AllowConfiguration = false;
        public n_template m_CurrentTemplate;
        public n_template CurrentTemplate
        {
            get
            {
                return m_CurrentTemplate;
            }

            set
            {
                m_CurrentTemplate = value;
            }
        }

        public int SelectedColumnIndex;
        public string CurrentSQL;
        public string LastClass;
        public string LastWhere;
        public string LastOrder;
        public long LastLimit;
        public bool IsExpandedRight;
        public bool IsExpandedLeft;
        public bool IsExpandedTop;
        public bool IsExpandedBottom;
        public bool UseShadedLines = true;
        public bool AllowDrag = false;
        //public MenuSetup menu;
        public bool UnlimitedResults = false;
        public Boolean CollectionMode = false;
        public IVarRefMany CurrentVar;
        public IItems CurrentItems;
        public nObject LastClicked;
        public nObjectHandle LastHandleClicked;
        public bool AsyncMode = true;
        public String CurrentID = "";
        protected DataConnection m_AlternateConnection = null;
       
        public DataConnection AlternateConnection
        {
            get
            {
                return m_AlternateConnection;
            }

            set
            {
                m_AlternateConnection = value;
            }
        }
        public String AlternateTableName = "";
        //public ArrayList CustomMenuOptions = null;

        private string m_OrderLineType = "";
        public string zz_OrderLineType
        {
            get
            {
                return m_OrderLineType;
            }
            set
            {
                m_OrderLineType = value;
            }
        }


        //Private Vars
        private bool dragdown = false;
        private bool dragcatch = false;
        private bool bInhibitLayout = false;
        private int sortColumn = -1;
        private System.Drawing.Color bColor = System.Drawing.Color.LightGray;
        private long LastSearchTicks = 0;
        public DataTable CurrentRst;
        private DateTime AsyncStart;
        private bool AsyncSearchMenu = false;
        private BackgroundWorker AsyncThread;
        //private ExcelApplication xExcel;

        bool m_NotifyInhibited = false;
        private bool NotifyInhibited
        {
            get
            {
                return m_NotifyInhibited;
            }

            set
            {
                m_NotifyInhibited = value;
            }
        }


        private bool AlternateIcons = false;



        private ImageList AlternateIconList;
        private bool HasSearched = false;
        private int ColorLimit = 0;
        private int ColorStep = 0;
        private System.Drawing.Color SingleColor = Color.White;
        private bool UseColor = false;
        private Color[] BackColors = null;
        private AsyncWait aw;
        public int SkipRows = 0;
        //Stylizer TheStyle = null;
        public ListArgs TheArgs;
        //Public Events
        public event ShowHandler AboutToThrow;
        public event AddHandler AboutToAdd;
        public event ObjectClickHandler ObjectClicked;
        public event FillHandler FinishedFill;
        public event IconRequest RequestIcon;
        public event FillHandler NotifyRefresh;
        //public event FillHandlerTable FinishedFillTable;
        public event ActionHandler AboutToAction;
        public event ActionHandler AboutToDelete;
        public event ActionHandler FinishedAction;
        //public event ObjectsDeletedHandler ObjectsDeleted;
        public event nListItemDragHandler ItemDrag;
        public event nListItemDragDropHandler DragDrop;
        public event nListItemDragDropHandler DragEnter;
        public event nListItemDragDropHandler DragOver;
        public event ItemStyleHandler AskForStyle;
        public event SelectedObjectGetHandler SelectedObjectGet;
        //Properties
        private bool m_OpenColumnMenu = false;
        public Boolean zz_OpenColumnMenu
        {
            get
            {
                return m_OpenColumnMenu;
            }
            set
            {
                m_OpenColumnMenu = value;
            }
        }
        private bool m_ShowAutoRefresh = true;
        private bool m_ShowUnlimited = true;
        public Boolean zz_ShowAutoRefresh
        {
            get
            {
                return m_ShowAutoRefresh;
            }
            set
            {
                chkRefresh.Visible = value;
                chkRefresh.Checked = value;
                m_ShowAutoRefresh = value;
            }
        }
        public Boolean zz_ShowUnlimited
        {
            get
            {
                return m_ShowUnlimited;
            }
            set
            {
                chkUnlimited.Visible = value;
                m_ShowUnlimited = value;
            }
        }
        private String m_ExtraClassInfo = "";
        public String ExtraClassInfo
        {
            get
            {
                return m_ExtraClassInfo;
            }
            set
            {
                m_ExtraClassInfo = value;
            }
        }
        private bool m_AllowAdd = false;
        public bool AllowAdd
        {
            get
            {
                return m_AllowAdd;
            }
            set
            {
                m_AllowAdd = value;
                DoResize();
            }
        }
        private bool m_AllowActions = true;
        public bool AllowActions
        {
            get
            {
                return m_AllowActions;
            }
            set
            {
                m_AllowActions = value;
                DoResize();
            }
        }
        private bool m_AllowDelete = true;
        public bool AllowDelete
        {
            get
            {
                return m_AllowDelete;
            }
            set
            {
                m_AllowDelete = value;
                //mnuDelete.Visible = m_AllowDelete;
            }
        }

        private bool m_AllowOnlyOpenDelete = false;
        public bool AllowOnlyOpenDelete
        {
            get
            {
                return m_AllowOnlyOpenDelete;
            }
            set
            {
                m_AllowOnlyOpenDelete = value;
            }
        }


        private bool m_AllowDeleteAlways = false;
        public bool AllowDeleteAlways
        {
            get
            {
                return m_AllowDeleteAlways;
            }
            set
            {
                m_AllowDeleteAlways = value;
            }
        }

        private String m_AddCaption = "Add New";
        public String AddCaption
        {
            get
            {
                return m_AddCaption;
            }
            set
            {
                m_AddCaption = value;
                cmdAdd.Text = m_AddCaption;
            }
        }
        private String m_Caption = "";
        public String Caption
        {
            get
            {
                return m_Caption;
            }
            set
            {
                m_Caption = value;
                lblCaption.Text = value;
                DoResize();
            }
        }
        private Boolean bMultiSelect = true;
        public Boolean MultiSelect
        {
            get
            {
                return bMultiSelect;
            }
            set
            {
                bMultiSelect = value;
                lv.MultiSelect = value;
            }
        }
        private bool m_SuppressSelectionChanged = false;
        public bool SuppressSelectionChanged
        {
            get
            {
                return m_SuppressSelectionChanged;
            }
            set
            {
                m_SuppressSelectionChanged = value;
            }
        }
        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return lv.ContextMenuStrip;
            }
            set
            {
                lv.ContextMenuStrip = value;
            }
        }


       
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            
            return base.ProcessCmdKey(ref msg, keyData);
           
            //    //capture up arrow key
            //    if (keyData == Keys.Up)
            //    {
            //        MessageBox.Show("You pressed Up arrow key");
            //        return true;
            //    }
            //    //capture down arrow key
            //    if (keyData == Keys.Down)
            //    {
            //        MessageBox.Show("You pressed Down arrow key");
            //        return true;
            //    }
            //    //capture left arrow key
            //    if (keyData == Keys.Left)
            //    {
            //        MessageBox.Show("You pressed Left arrow key");
            //        return true;
            //    }
            //    //capture right arrow key
            //    if (keyData == Keys.Right)
            //    {
            //        MessageBox.Show("You pressed Right arrow key");
            //        return true;
            //    }
            //    return base.ProcessCmdKey(ref msg, keyData);
            }


            public nList()
        {
            InitializeComponent();

            if (NMWin.ContextDefault != null)
            {
                NMWin.Sys.Changed += new DeltaHandler(Sys_Changed);

                if (!NMWin.ContextDefault.xUser.ExportAllow(NMWin.ContextDefault))
                {
                    cmdExport.Visible = false;
                    cmdCsv.Visible = false;
                }
                cmdColumns.Visible = NMWin.ContextDefault.xUser.TemplateEditor;
                cmdSave.Visible = NMWin.ContextDefault.xUser.TemplateEditor;
            }
        }

        //Public Functions
        public void DoResize()
        {
            if (lv == null)
                return;

            IsExpandedBottom = m_AllowAdd;
            lv.BeginUpdate();
            try
            {
                gbBottom.Visible = IsExpandedBottom;
                //gbLeft.Visible = IsExpandedLeft;
                gbRight.Visible = IsExpandedRight;
                //gbTop.Visible = IsExpandedTop;
                gbBottom.Top = this.ClientRectangle.Height - (gbBottom.Height);
                gbBottom.Left = 0;
                if (IsExpandedRight)
                    gbBottom.Width = this.ClientRectangle.Width - gbRight.Width;
                else
                    gbBottom.Width = this.ClientRectangle.Width;
                //gbTop.Location = new Point(0, 0);
                //gbTop.Width = this.Width - gbRight.Width;
                //gbLeft.Location = new Point(0, gbTop.Height);
                //gbLeft.Height = this.Height - (gbTop.Height + gbBottom.Height);
                gbRight.Location = new Point(this.Width - gbRight.Width, 0);
                gbRight.Height = this.ClientRectangle.Height;
                lblCaption.Visible = false;
                lblCaption.Left = 0;
                lblCaption.Top = 0;
                lblCaption.Width = this.ClientRectangle.Width;
                if (IsExpandedLeft)
                {
                    if (IsExpandedTop)
                    {
                        //lv.Location = new Point(gbLeft.Width, gbTop.Height);
                    }
                    else
                    {
                        //lv.Location = new Point(gbLeft.Width, 0);
                    }
                }
                else
                {
                    if (IsExpandedTop)
                    {
                        //lv.Location = new Point(0, gbTop.Height);
                    }
                    else
                    {
                        if (Tools.Strings.StrExt(Caption))
                        {
                            lblCaption.Visible = true;
                            lv.Location = new Point(0, lblCaption.Height);
                        }
                        else
                        {
                            lv.Location = new Point(0, 0);
                        }
                    }
                }
                if (IsExpandedBottom)
                {
                    gbBottom.Visible = true;
                    lv.Height = (this.Height - lv.Location.Y) - (gbBottom.Height + (lblStatus.Height + 5));
                }
                else
                {
                    gbBottom.Visible = false;
                    lv.Height = (this.Height - (lv.Location.Y + (lblStatus.Height + 5)));
                }
                if (IsExpandedRight)
                {
                    lv.Width = (this.Width - lv.Location.X) - gbRight.Width;
                }
                else
                {
                    lv.Width = (this.Width - lv.Location.X);
                }
                SizeColumns();
                lblStatus.Left = lv.Left;
                //lblStatus.Width = lv.Width;
                lblStatus.Top = (lv.Top + lv.Height) + 2;
                chkRefresh.Top = lblStatus.Top;
                chkRefresh.Left = (lv.Right - chkRefresh.Width) - 20;
                AlignUnlimitedCheckbox();
                cmdSHRight.Top = chkRefresh.Top;
                cmdSHRight.Left = chkRefresh.Left - cmdSHRight.Width;
                chkUnlimited.Visible = !CollectionMode;
            }
            catch (Exception e)
            {
            }
            lv.EndUpdate();
        }

        public nObject GetObjectByCoordinates(int x, int y)
        {
            ListViewHitTestInfo i = lv.HitTest(lv.PointToClient(new Point(x, y)));
            if (i == null)
                return null;
            if (i.Item == null)
                return null;
            return GetObjectFromItem(i.Item);
        }

        public nObject GetObjectFromItem(ListViewItem xLst)
        {
            try
            {
                nObject o = null;
                if (CollectionMode)
                {
                    if (CurrentItems != null)
                        return (nObject)CurrentItems.ByIdGet(NMWin.ContextDefault, (String)xLst.Tag);
                    else
                        return null;
                    //    return (nObject)CurrentSortedCollection[xLst.Tag];
                }
                else
                {
                    string class_name = CurrentTemplate.class_name;
                    if (TheArgs != null)
                        class_name = TheArgs.TheClass;
                    if (AlternateConnection != null)
                        return (nObject)NMWin.ContextDefault.GetById(class_name, (String)xLst.Tag, AlternateTableName, AlternateConnection);
                    else
                        return (nObject)NMWin.ContextDefault.GetById(class_name, (String)xLst.Tag, AlternateTableName);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public String GetSelectedData(String field)
        {
            try
            {
                if (CurrentTemplate == null)
                    return "";

                ListViewItem i = lv.SelectedItems[0];
                if (i == null)
                    return "";

                int ix = 0;
                foreach (DictionaryEntry d in CurrentTemplate.AllColumns)
                {
                    n_column c = (n_column)d.Value;
                    if (Tools.Strings.StrCmp(c.field_name, field))
                    {
                        if (ix == 0)
                            return i.Text;
                        else
                            return i.SubItems[ix].Text;
                    }
                    ix++;
                }

                return "";
            }
            catch
            {
                return "";
            }
        }

        public bool IsShowingTemplate(String strName)
        {
            if (CurrentTemplate == null)
                return false;
            return Tools.Strings.StrCmp(CurrentTemplate.template_name, strName);
        }
        public ListView GetListViewControl()
        {
            return lv;
        }
        public void ReDoSearch()
        {
            ReDoSearch(false);
        }
        public void ReDoSearch(bool skip_if_too_long)
        {
            try
            {
                CurrentID = "";
                if (lv.SelectedItems.Count > 0)
                    CurrentID = (String)lv.SelectedItems[0].Tag;
                if (CollectionMode)
                {
                    RefreshFromCollection();
                }
                else
                {
                    if (skip_if_too_long && LastSearchTicks > 2000)
                        return;
                    if (!Tools.Strings.StrExt(LastClass))
                    {
                        //context.TheLeader.Error("The Last Class var doesn't appear to be set.");
                        return;
                    }
                    long newlimit = LastLimit;
                    if (UnlimitedResults)
                        newlimit = -1;
                    ShowData(LastClass, LastWhere, LastOrder, newlimit, true);
                    //re-implement the original sorting?
                }
            }
            catch (Exception ex)
            {
                NMWin.Leader.Error(ex);
            }
        }
        public void Clear()
        {
            try
            {
                lv.Items.Clear();
                SetStatus("No results.");
            }
            catch (Exception)
            {
            }
        }
        public void ShowArray(ArrayList a)
        {
            CurrentItems = new ItemsInstance();
            foreach (nObject x in a)
            {
                CurrentItems.Add(NMWin.ContextDefault, x);
            }
            RefreshFromCollection();
        }
        public void ShowData(nSQL xs)
        {
            if (Tools.Strings.StrExt(xs.strAlternateTable))
                AlternateTableName = xs.strAlternateTable;

            if (Tools.Strings.StrExt(xs.strTemplate))
                ShowTemplate(xs.strTemplate, xs.strClass);

            ShowData(xs.strClass, xs.strWhere, xs.strOrder, xs.lngLimit);
        }



        public bool ShowData(String strClass, String strWhere, String strOrder)  //, String strTemplate
        {
            return ShowData(strClass, strWhere, strOrder, -1, false);  //, strTemplate
        }

        public bool ShowData(String strClass, String strWhere, String strOrder, long lngLimit)  //, String strTemplate
        {
            return ShowData(strClass, strWhere, strOrder, lngLimit, false);  //, strTemplate
        }
        public bool ShowData(String strClass, String strWhere, String strOrder, long lngLimit, bool KeepCurrentID)  //String strTemplate, 
        {
            LastClass = strClass;
            LastWhere = strWhere;
            LastOrder = strOrder;
            string theSql = GenerateSQL(strClass, strWhere, strOrder, lngLimit);
            return ShowData(theSql, strClass, lngLimit, KeepCurrentID);  //, strTemplate
        }
        public bool ShowData(String strClass, String strSQL)
        {
            return ShowData(strSQL, strClass, -1, false);
        }

        public bool Init(ListArgs args)
        {
            return ShowData(args);
        }

        public bool ShowData(ListArgs args)
        {
            if (lv == null)
                return false;

            TheArgs = null;
            if (args == null)
                return false;
            TheArgs = args;

            if (UnlimitedResults)
                TheArgs.TheLimit = -1;
            else if (TheArgs.TheLimit <= 0)
                TheArgs.TheLimit = SysNewMethod.ListLimitDefault;

            Caption = args.TheCaption;
            AllowAdd = args.AddAllow;
            AddCaption = args.AddCaption;
            ExtraClassInfo = args.ExtraClassInfo;

            if (CurrentTemplate == null)
            {
                ShowTemplate(TheArgs);
            }
            else if (Tools.Strings.StrExt(TheArgs.TheTemplate) && !Tools.Strings.StrCmp(TheArgs.TheTemplate, CurrentTemplate.template_name))
            {
                ShowTemplate(TheArgs);
            }

            //TheStyle = TheArgs.TheStyle;
            if (args.HeaderOnly)
                return true;

            if (AlternateConnection == null)
            {
                if (TheArgs.TheConnection == null)
                    AlternateConnection = NMWin.Data;
                else
                    AlternateConnection = TheArgs.TheConnection;
            }

            AlternateTableName = TheArgs.TheTable;
            TheArgs.PrepareTables();
            bool b = false;

            if (args.LiveItems == null)
                b = ShowData(args.TheClass, args.TheWhere, args.TheOrder, args.TheLimit);
            else
            {
                CurrentItems = args.LiveItems;
                RefreshFromCollection();
                b = true;
            }

            return b;
        }

        public bool ShowData(String strSQL, String strClass, long lngLimit, bool KeepCurrentID)  //, String strTemplate
        {
            //don't let a search overrride a running search
            if (IsAsyncRunning())
                return false;
            if (!KeepCurrentID)
                CurrentID = "";
            if (!UnlimitedResults)
                LastLimit = lngLimit;
            //if( Tools.Strings.StrExt(strTemplate) )
            //    ShowTemplate(strTemplate, strClass);
            if (CurrentTemplate == null)
                return false;
            if (CurrentTemplate.AllColumns.Count <= 0)
                return false;
            CurrentSQL = strSQL;
            Clear();
            lv.Sorting = SortOrder.None;
            SetStatus("Searching...");
            //xSys.SetStatus("Searching...", ActivityType.Searching);
            if (AsyncMode)
            {
                ShowDataAsync();
                return true;
            }
            DateTime t = System.DateTime.Now;
            DataTable rst;
            if (AlternateConnection != null)
                rst = AlternateConnection.Select(CurrentSQL);
            else
                rst = NMWin.ContextDefault.Select(CurrentSQL);
            TimeSpan ts = System.DateTime.Now.Subtract(t);
            LastSearchTicks = ts.Milliseconds;
            int i = 0;
            try
            {
                i = Convert.ToInt32(ts.TotalSeconds);
            }
            catch (Exception)
            {
            }
            ShowSearchTime(i);
            if (rst == null)
            {
                SetStatus("No results.");
                return true;
            }
            ShowResults(rst);
            return true;
        }



        public Dictionary<String, nObject> GetObjectsByColor(Color c)
        {
            try
            {
                Dictionary<String, nObject> d = new Dictionary<string, nObject>();
                foreach (IItem i in CurrentItems.AllGet(NMWin.ContextDefault))
                {
                    nObject o = (nObject)i;
                    if (nTools.GetColorFromInt(o.grid_color).ToArgb() == c.ToArgb())
                    {
                        d.Add(o.unique_id, o);
                    }
                }
                return d;
            }
            catch
            {
                return null;
            }
        }
        public bool IsAsyncRunning()
        {
            try
            {
                if (AsyncThread == null)
                    return false;
                //if (IsAsyncWait)
                //    return true;
                return AsyncThread.IsBusy;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void ShowDataAsync()
        {
            AsyncSearchMenu = false;
            AsyncStart = System.DateTime.Now;
            if (AsyncThread == null)
            {
                AsyncThread = new BackgroundWorker();
                AsyncThread.DoWork += new DoWorkEventHandler(AsyncThread_DoWork);
                AsyncThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(AsyncThread_RunWorkerCompleted);
            }
            AsyncThread.RunWorkerAsync();
            //AsyncThread = new Thread(new ThreadStart(ShowDataAsync_Handler));
            //AsyncThread.SetApartmentState(ApartmentState.STA);
            //AsyncThread.Start();
            AsyncTimer.Interval = 100;
            AsyncTimer.Start();
        }
        public void ShowTemplate(ListArgs args)
        {
            if (args == null)
                return;
            ShowTemplate(args.TheTemplate, args.TheClass, args.TheContext.xUser.TemplateEditor, args.TheTemplateBase);
        }
        public void ShowTemplate(String strName, String strClass)
        {
            bool b = true;
            if (NMWin.ContextDefault.xUser != null)
                b = NMWin.User.TemplateEditor;
            ShowTemplate(strName, strClass, b, "");
        }

        public void ShowTemplate(String strName, String strClass, bool allow_config)
        {
            ShowTemplate(strName, strClass, allow_config, "");
        }

        public void ShowTemplate(String strName, String strClass, bool allow_config, String template_base)
        {
            if (lv == null)
                return;

            AllowConfiguration = allow_config;
            cmdSHRight.Visible = nList.AllowConfiguration;
            if (xSys == null)
            {
                NMWin.Leader.Error("The system isn't set for this nList");
                return;
            }
            if (xSys.icons != null)
                lv.SmallImageList = xSys.icons;
            lv.Items.Clear();
            CoreClassHandle cl = NMWin.ContextDefault.TheSys.CoreClassGet(strClass);
            if (cl == null)
                return;

            CurrentTemplate = n_template.GetByName(NMWin.ContextDefault, strName);

            if (CurrentTemplate == null)
            {
                //there's a problem here where the client is temporarily disconnected so that CurrentTemplate is null, but then the get reconnected and create another template
                //wait a bit
                System.Threading.Thread.Sleep(2000);

                if (NMWin.Data.ConnectPossible())
                {
                    CurrentTemplate = n_template.GetByName(NMWin.ContextDefault, strName);

                    if (CurrentTemplate == null)
                    {
                        CurrentTemplate = n_template.Create(NMWin.ContextDefault, cl.Name, strName);
                        n_template b = null;
                        if (Tools.Strings.StrExt(template_base))
                            b = n_template.GetByName(NMWin.ContextDefault, template_base);
                        if (b != null)
                        {
                            CurrentTemplate.RemoveAllColumns(NMWin.ContextDefault);
                            b.GatherColumns(NMWin.ContextDefault);
                            CurrentTemplate.AbsorbColumns(NMWin.ContextDefault, b);
                        }
                    }
                }
                else
                    return;
            }
            else
            {
                CurrentTemplate.GatherColumns(NMWin.ContextDefault);
            }
            if (!Tools.Strings.StrExt(CurrentTemplate.class_name))
            {
                CurrentTemplate.class_name = strClass;
                NMWin.ContextDefault.Update(CurrentTemplate);
            }
            if (!Tools.Strings.StrCmp(CurrentTemplate.class_name, strClass) && Tools.Strings.StrExt(strClass))
            {
                if (strClass.ToLower().StartsWith("ordhed") || strClass.ToLower().StartsWith("orddet"))
                {
                    CurrentTemplate.class_name = strClass;
                    NMWin.ContextDefault.Update(CurrentTemplate);
                }
            }

            //xSys.UnRegisterNotifyClass(this);
            //xSys.RegisterNotifyClass(this, this.CurrentTemplate.class_name);
            ShowCurrentTemplate();
        }

        void Sys_Changed(Context x, ChangeArgs args)
        {
            if (InvokeRequired)
                Invoke(new DeltaHandler(Sys_ChangedActually), new Object[] { x, args });
            else
                Sys_ChangedActually(x, args);
        }

        void Sys_ChangedActually(Context x, ChangeArgs args)
        {
            if (CurrentTemplate == null)
                return;

            if (CurrentTemplate.template_name.ToLower().Contains("purchase"))
            {
                ;
            }

            if (!Tools.Strings.StrExt(CurrentTemplate.class_name))
                return;

            if (!args.Classes.Contains(CurrentTemplate.class_name.ToLower()))
                return;

            TemplateClassChanged();
        }

        void TemplateClassChanged()
        {
            if (this.ParentForm == null)
                return;

            if (!HasSearched)
                return;

            if (NotifyInhibited)
            {
                changeOnResume = true;
                return;
            }

            if (!chkRefresh.Checked)
                return;

            if (CollectionMode)
                this.RefreshFromCollection();
            else
                this.ReDoSearch();

            if (NotifyRefresh != null)
                NotifyRefresh(this);

            ReClickLast();
        }

        public void SetExtraClassInfo(String strExtra)
        {
            ExtraClassInfo = strExtra;
            RefreshObjectMenu();
        }
        public void HighlightBySelectedTags(ArrayList sTag)
        {
            if (sTag != null)
            {
                lv.SelectedItems.Clear();
                foreach (ListViewItem l in lv.Items)
                {
                    if (sTag.Contains(l.Tag.ToString()))
                        l.Selected = true;
                    else
                        l.Selected = false;
                }
            }
        }
        public void SelectIndex(Int32 index)
        {
            if (lv.Items.Count <= 0)
                return;
            if (index < 0)
                return;
            try
            {
                foreach (ListViewItem i in lv.Items)
                {
                    if (i.Index == index)
                    {
                        i.Selected = true;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public Int32 GetIndexOfKey(String key)
        {
            if (lv.Items.Count <= 0)
                return -1;
            try
            {
                foreach (ListViewItem i in lv.Items)
                {
                    if (Tools.Strings.StrCmp(i.Tag.ToString(), key))
                        return i.Index;
                }
                return -1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int HighlightByFieldValue(String fieldName, List<String> valuesUpperCase, bool fuzzyMode = false)
        {
            int i = CurrentTemplate.GetColumnIndexByProperty(fieldName);
            if (i == -1)
                return 0;

            int sel = 0;
            foreach (ListViewItem il in lv.Items)
            {
                String s = il.SubItems[i].Text;
                if (fuzzyMode)
                {
                    il.Selected = false;
                    foreach (String val in valuesUpperCase)
                    {
                        if (s.ToUpper().Contains(val))
                        {
                            il.Selected = true;
                            sel++;
                            break;
                        }
                    }
                }
                else
                {
                    if (valuesUpperCase.Contains(s.Trim().ToUpper()))
                    {
                        il.Selected = true;
                        sel++;
                    }
                    else
                        il.Selected = false;
                }
            }
            return sel;
        }

        public void ClearAllSelected()
        {
            if (lv.Items.Count <= 0)
                return;
            lv.SelectedItems.Clear();
        }
        public nObject GetFirstObject()
        {
            if (lv.Items.Count <= 0)
                return null;
            lv.Items[0].Selected = true;
            return GetSelectedObject();
        }
        public void ShowCurrentTemplate()
        {
            tColumnHeader c;
            lv.BeginUpdate();

            try
            {
                lv.Items.Clear();
                lv.Columns.Clear();
                n_column xColumn;
                if (CurrentTemplate.AllColumns == null)
                    CurrentTemplate.GatherColumns(NMWin.ContextDefault);
                foreach (DictionaryEntry d in CurrentTemplate.AllColumns)
                {
                    xColumn = (n_column)d.Value;
                    c = new tColumnHeader();
                    c.Text = xColumn.column_caption;
                    c.WidthPercent = xColumn.column_width;
                    c.SetWidth(lv.Width);
                    c.Tag = xColumn;
                    switch (xColumn.column_alignment)
                    {
                        case 2:
                            c.TextAlign = HorizontalAlignment.Center;
                            break;
                        case 1:
                            c.TextAlign = HorizontalAlignment.Right;
                            break;
                        default:
                            c.TextAlign = HorizontalAlignment.Left;
                            break;
                    }
                    lv.Columns.Add(c);
                }
            }
            catch { }

            lv.EndUpdate();
            inhibit_colors = true;
            if (CurrentTemplate.background_repeat <= 0)
                cboColors.Text = "none";
            else
                cboColors.Text = CurrentTemplate.background_repeat.ToString();
            SetColorBoxes();
            SetLines();
            inhibit_colors = false;
        }
        public void SetLines()
        {
            lv.GridLines = CurrentTemplate.use_gridlines;
        }
        public String GenerateSQL(String strClass, String strWhere, String strOrder, long lngLimit)
        {
            if (CurrentTemplate == null)
                return "";
            String strFinalTable = "";
            if (Tools.Strings.StrExt(AlternateTableName))
            {
                strFinalTable = AlternateTableName;
            }
            else
            {
                if (Tools.Strings.StrExt(CurrentTemplate.class_name))
                    strFinalTable = CurrentTemplate.class_name;
                else
                    strFinalTable = strClass;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("select ");
            //KT Top X doesnt' work in MySQL, see Limit below
            if (strClass != "partpicture")
                if (lngLimit > 0)
                    sb.Append("top " + lngLimit.ToString() + " ");
            sb.Append(strFinalTable + ".unique_id, " + strFinalTable + ".grid_color, " + strFinalTable + ".icon_index, ");
            bool relates = false;
            string strPrefix = "";
            string strRelate = "";
            string strColumn = "";
            string strAlias = "";
            string strField = "";
            string strJoin = "";
            string strTable = "";
            string strGroup = "" + strFinalTable + ".unique_id, " + strFinalTable + ".grid_color, " + strFinalTable + ".icon_index";
            string sj = "";
            int j = 0;
            n_column c;
            foreach (DictionaryEntry d in CurrentTemplate.AllColumns)
            {
                c = (n_column)d.Value;
                if (!Tools.Strings.StrCmp(c.field_name, "unique_id") && Tools.Strings.StrExt(c.field_name))
                {
                    if (j > 0)
                        sb.Append(", ");
                    //joined tables
                    if (Tools.Strings.StrExt(c.relate_class))
                    {
                        relates = true;
                        if (Tools.Strings.StrExt(c.function_name))
                        {
                            strAlias = c.relate_name + "_" + c.relate_class;
                            strTable = c.relate_class;
                            strRelate = c.relate_name;
                            sj = " LEFT JOIN " + strTable + " " + strAlias + " on " + strAlias + "." + strRelate + "_" + CurrentTemplate.class_name + "_uid = " + CurrentTemplate.class_name + ".unique_id ";
                            if (!Tools.Strings.HasString(strJoin, " LEFT JOIN " + strPrefix + " " + strAlias + " on"))
                                strJoin = strJoin + sj;
                        }
                        else
                        {
                            strAlias = c.relate_name + "_" + c.relate_class;
                            strTable = c.relate_class;
                            strRelate = c.relate_name;
                            sj = " LEFT JOIN " + strTable + " " + strAlias + " on " + CurrentTemplate.class_name + "." + strRelate + "_" + strTable + "_uid = " + strAlias + ".unique_id ";
                            if (!Tools.Strings.HasString(strJoin, "LEFT JOIN " + strTable + " " + strAlias + " on"))
                                strJoin = strJoin + sj;
                        }
                        if (Tools.Strings.StrExt(strGroup))
                            strGroup = strGroup + ", ";
                        strGroup = strGroup + strAlias + "." + c.field_name;
                    }
                    else
                    {
                        strAlias = strFinalTable;
                        strTable = strFinalTable;
                        if (Tools.Strings.StrExt(strGroup))
                            strGroup = strGroup + ", ";
                        strGroup = strGroup + strAlias + "." + c.field_name;
                    }
                    if (Tools.Strings.StrExt(c.function_name))
                    {
                        strField = c.function_name + "(" + strAlias + "." + c.field_name + ")";
                    }
                    else
                    {
                        strField = strAlias + "." + c.field_name;
                    }
                    sb.Append(strField + " as " + c.GetAsName());
                    j++;
                }
            }
            sb.Append(" from " + strFinalTable);
            if (relates)
            {
                if (Tools.Strings.StrExt(strJoin))
                {
                    sb.Append(strJoin);
                }
            }
            if (Tools.Strings.StrExt(strWhere))
                sb.Append(" where " + strWhere);
            if (relates)
            {
                if (Tools.Strings.StrExt(strGroup))
                {
                    sb.Append(" group by " + strGroup);
                }
            }
            if (Tools.Strings.StrExt(strOrder))
                sb.Append(" order by " + strOrder);
            //ToolsWin.Clipboard.SetClip(sb.ToString());

            //KT use "Limit if MySQL"
            if (strClass == "partpicture")
                if (lngLimit > 0)
                    sb.Append(" LIMIT " + lngLimit.ToString() + " ");
            return sb.ToString();
        }

        public String GetFieldList(String strFinalTable)
        {
            return GetFieldList(strFinalTable, false);
        }

        public String GetFieldList(String strFinalTable, bool no_as)
        {
            String ret = strFinalTable + ".unique_id, " + strFinalTable + ".grid_color, " + strFinalTable + ".icon_index ";
            foreach (DictionaryEntry d in CurrentTemplate.AllColumns)
            {
                n_column c = (n_column)d.Value;
                if (!Tools.Strings.StrCmp(c.field_name, "unique_id") && Tools.Strings.StrExt(c.field_name))
                {
                    ret += ", " + strFinalTable + "." + c.field_name;

                    if (!no_as)
                        ret += " as " + c.GetAsName();
                }
            }
            return ret;
        }
        public String GetGroupList(String strFinalTable)
        {
            String ret = strFinalTable + ".unique_id, " + strFinalTable + ".grid_color, " + strFinalTable + ".icon_index ";
            foreach (DictionaryEntry d in CurrentTemplate.AllColumns)
            {
                n_column c = (n_column)d.Value;
                if (!Tools.Strings.StrCmp(c.field_name, "unique_id") && Tools.Strings.StrExt(c.field_name))
                {
                    ret += ", " + strFinalTable + "." + c.field_name;
                }
            }
            return ret;
        }
        public String GetSimpleFieldSQL()
        {
            if (CurrentTemplate == null)
                return "";
            try
            {
                StringBuilder sb = new StringBuilder();
                int j = 0;
                foreach (DictionaryEntry d in CurrentTemplate.AllColumns)
                {
                    n_column c = (n_column)d.Value;
                    if (!Tools.Strings.StrCmp(c.field_name, "unique_id") && Tools.Strings.StrExt(c.field_name))
                    {
                        String strField = CurrentTemplate.class_name + "." + c.field_name;
                        if (j > 0)
                            sb.Append(", ");
                        sb.Append(strField + " as " + c.GetAsName());
                        j++;
                    }
                }
                return CurrentTemplate.class_name + ".unique_id, " + CurrentTemplate.class_name + ".grid_color, " + CurrentTemplate.class_name + ".icon_index, " + sb.ToString();
            }
            catch (Exception)
            {
            }
            return "";
        }
        public String GetSimpleGroupSQL()
        {
            if (CurrentTemplate == null)
                return "";
            try
            {
                StringBuilder sb = new StringBuilder();
                int j = 0;
                foreach (DictionaryEntry d in CurrentTemplate.AllColumns)
                {
                    n_column c = (n_column)d.Value;
                    if (!Tools.Strings.StrCmp(c.field_name, "unique_id") && Tools.Strings.StrExt(c.field_name))
                    {
                        String strField = CurrentTemplate.class_name + "." + c.field_name;
                        if (j > 0)
                            sb.Append(", ");
                        sb.Append(strField);
                        j++;
                    }
                }
                return CurrentTemplate.class_name + ".unique_id, " + CurrentTemplate.class_name + ".grid_color, " + CurrentTemplate.class_name + ".icon_index, " + sb.ToString();
            }
            catch (Exception)
            {
            }
            return "";
        }
        public Int64 GetCount()
        {
            return lv.Items.Count;
        }
        public void ShowResults(DataTable rst)
        {
            HasSearched = true;
            ListViewItem xLst = new ListViewItem();
            String strValue = "";
            Object val;
            Int32 color;
            int j = 0;
            Int32 ic;
            lv.BeginUpdate();
            lv.Items.Clear();
            try
            {
                SetColors();
                String sid = "";
                int rowindex = 0;
                foreach (DataRow r in rst.Rows)
                {
                    j = 0;
                    if (SkipRows > 0)
                    {
                        if (rowindex <= SkipRows)
                        {
                            rowindex++;
                            continue;
                        }
                    }
                    n_column c;
                    foreach (DictionaryEntry d in CurrentTemplate.AllColumns)
                    {
                        c = (n_column)d.Value;
                        if (Tools.Strings.StrExt(c.field_name))
                        {
                            try
                            {
                                val = r[c.GetAsName()];
                                strValue = Stylizer.RenderVal(val, c, "$");
                            }
                            catch (Exception)
                            {
                                try
                                {
                                    val = r[c.field_name];
                                    strValue = Stylizer.RenderVal(val, c, "$");
                                }
                                catch (Exception)
                                {
                                    strValue = "#";
                                }
                            }

                            if (j == 0)
                            {
                                try
                                {
                                    sid = (string)r["unique_id"];
                                }
                                catch (Exception)
                                {
                                    sid = Tools.Strings.GetNewID();
                                }
                                xLst = lv.Items.Add(sid, strValue, "");
                                xLst.Tag = sid;
                                if (UseColor)
                                {
                                    if (ColorLimit == 1)
                                    {
                                        xLst.BackColor = SingleColor;
                                    }
                                    else
                                    {
                                        xLst.BackColor = (Color)BackColors.GetValue(ColorStep);
                                        ColorStep++;
                                        if (ColorStep > (ColorLimit - 1))
                                            ColorStep = 0;
                                    }
                                }
                                //else if (TheStyle != null)
                                //{
                                //    xLst.BackColor = TheStyle.RowBackColor(r);
                                //}

                                ic = Tools.Data.NullFilterInt(r["grid_color"]);
                                if (ic != 0)
                                {
                                    xLst.ForeColor = nTools.GetColorFromInt(ic);
                                }
                                //else if (TheStyle != null)
                                //{
                                //    xLst.ForeColor = TheStyle.RowForeColor(r);
                                //}

                                if (!AlternateIcons)
                                {
                                    ic = Tools.Data.NullFilterInt(r["icon_index"]);
                                    if (ic > 0)
                                    {
                                        xLst.ImageIndex = (ic - 1);
                                    }
                                }
                                else
                                {
                                    if (RequestIcon != null)
                                    {
                                        IconRequestArgs a = new IconRequestArgs(r);
                                        RequestIcon(a);
                                        if (a.icon > 0)
                                            xLst.ImageIndex = (a.icon - 1);
                                    }
                                }
                            }
                            else
                            {
                                xLst.SubItems.Add(strValue.Replace("\r\n", ","));
                            }
                            j++;
                        }
                        else
                        {
                            int yt = 0;
                        }
                    }
                    if (AskForStyle != null)
                        AskForStyle(xLst, r);
                    rowindex++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            lv.EndUpdate();
            try
            {
                if (rst.Rows.Count == 0)
                    SetStatus("No results.");
                else if (rst.Rows.Count == 1)
                    SetStatus("1 result.");
                else
                    SetStatus(Tools.Number.LongFormat(rst.Rows.Count) + " results.");
                if (Tools.Strings.StrExt(CurrentID))
                    HighlightByID(CurrentID);
                if (FinishedFill != null)
                    FinishedFill(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool ObjectInList(nObject obj)
        {
            if (obj == null)
                return false;
            return ObjectInList(obj.unique_id);
        }
        public bool ObjectInList(String id)
        {
            try
            {
                if (!Tools.Strings.StrExt(id))
                    return false;
                foreach (ListViewItem xLst in lv.Items)
                {
                    if (Tools.Strings.StrCmp(id, xLst.Tag.ToString()))
                        return true;
                }
            }
            catch
            {
            }
            return false;
        }
        public void AddObject(nObject obj)
        {
            try
            {
                if (obj == null)
                    return;
                n_column c = (n_column)CurrentTemplate.AllColumns[0];
                ListViewItem xLst = new ListViewItem();
                xLst.Tag = obj.unique_id;
                bool text = false;
                foreach (DictionaryEntry d in CurrentTemplate.AllColumns)
                {
                    c = (n_column)d.Value;
                    if (!Tools.Strings.StrCmp(c.field_name, "unique_id") && Tools.Strings.StrExt(c.field_name))
                    {
                        if (!text)
                        {
                            text = true;
                            xLst.Text = obj.IGet(c.field_name).ToString();
                        }
                        else
                            xLst.SubItems.Add(obj.IGet(c.field_name).ToString());
                    }
                }
                xLst.ForeColor = nTools.GetColorFromInt((int)obj.IGet("grid_color"));
                lv.Items.Add(xLst);
                if (lv.Items.Count > 0)
                    SetStatus(Tools.Number.LongFormat(lv.Items.Count) + " results.");
                else
                    SetStatus("No Results.");
            }
            catch
            {
            }
        }
        public void RemoveObject(String id)
        {
            try
            {
                if (!Tools.Strings.StrExt(id))
                    return;
                foreach (ListViewItem xLst in lv.Items)
                {
                    if (!Tools.Strings.StrCmp(id, xLst.Tag.ToString()))
                        continue;
                    lv.Items.Remove(xLst);
                    if (lv.Items.Count > 0)
                        SetStatus(Tools.Number.LongFormat(lv.Items.Count) + " results.");
                    else
                        SetStatus("No Results.");
                    return;
                }
            }
            catch
            {
            }
        }
        public void RemoveObject(nObject obj)
        {
            RemoveObject(obj.unique_id);
        }
        public void ReColor()
        {
            SetColors();
            foreach (ListViewItem xLst in lv.Items)
            {
                if (UseColor)
                {
                    if (ColorLimit == 1)
                    {
                        xLst.BackColor = SingleColor;
                    }
                    else
                    {
                        xLst.BackColor = (Color)BackColors.GetValue(ColorStep);
                        ColorStep++;
                        if (ColorStep > (ColorLimit - 1))
                            ColorStep = 0;
                    }
                }
                else
                {
                    xLst.BackColor = Color.White;
                }
            }
        }

        public void FillSelectedObjectSoft(nObject x)
        {
            try
            {
                ListViewItem i = lv.SelectedItems[0];

                int col = 0;
                foreach (DictionaryEntry d in CurrentTemplate.AllColumns)
                {
                    x.ISet_String(NMWin.ContextDefault, ((n_column)d.Value).field_name, i.SubItems[col].Text);
                    col++;
                }
            }
            catch
            {
            }
        }

        public nObject GetSelectedObject()
        {
            if (SelectedObjectGet != null)
            {
                bool cancel = false;
                nObject ret = SelectedObjectGet(ref cancel);

                if (cancel)
                    return null;

                if (ret != null)
                    return ret;
            }

            try
            {
                return GetObjectFromItem(lv.SelectedItems[0]);
            }
            catch
            {
                return null;
            }
        }
        public nObjectHandle GetSelectedHandle()
        {
            try
            {
                return new nObjectHandle(CurrentTemplate.class_name, nTools.CStr(lv.SelectedItems[0].Tag), AlternateTableName);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void SizeColumns()
        {
            foreach (tColumnHeader c in lv.Columns)
            {
                c.SetWidth(lv.Width);
            }
        }
        public string GetSelectedID()
        {
            try
            {
                return (string)lv.SelectedItems[0].Tag;
            }
            catch (Exception e)
            {
                return "";
            }
        }
        public ArrayList GetSelectedIDs()
        {
            ArrayList ret = new ArrayList();
            try
            {
                foreach (ListViewItem i in lv.SelectedItems)
                {
                    ret.Add((String)i.Tag);
                }
            }
            catch
            {
            }
            return ret;
        }
        public bool ThrowSelected()
        {
            if (AsyncMode && !CollectionMode)
            {
                try
                {
                    ShowArgs t = null;
                    nObject sel = GetSelectedObject();

                    if (sel == null)
                        return false;

                    t = new ShowArgs(NMWin.ContextDefault, sel);

                    //t.AsyncMode = true;
                    //t.xHandle = GetSelectedHandle();
                    if (AboutToThrow != null)
                    {
                        AboutToThrow(NMWin.ContextDefault, t);
                    }
                    if (!t.Handled)
                    {
                        NMWin.ContextDefault.Show(t);
                    }
                }
                catch (Exception ex_async)
                {
                    NMWin.Leader.Tell("There was an error displaying this information (async): " + ex_async.Message + "\r\n\r\n" + ex_async.StackTrace.ToString());
                }
                return true;
            }
            else
            {
                try
                {
                    nObject xObject;
                    xObject = GetSelectedObject();
                    if (xObject == null)
                        return false;
                    return ShowObject(xObject);
                }
                catch (Exception ex_sync)
                {
                    NMWin.Leader.Tell("There was an error displaying this information (sync): " + ex_sync.Message + "\r\n\r\n" + ex_sync.StackTrace.ToString());
                    return false;
                }
            }
        }
        public bool ShowObject(nObject xObject)
        {
            ShowArgs t = new ShowArgs(NMWin.ContextDefault, xObject);
            if (AboutToThrow != null)
            {
                AboutToThrow(NMWin.ContextDefault, t);
            }
            if (!t.Handled)
            {
                ShowArgs args = null;
                if (CurrentVar != null)
                    args = CurrentVar.ShowArgsCreate(NMWin.ContextDefault, xObject);

                if (args == null)
                {
                    args = new ShowArgs(NMWin.ContextDefault, xObject);
                }

                NMWin.ContextDefault.Show(args);
            }
            return true;
        }
        public void SaveColumnHeader(tColumnHeader h, n_column c)
        {
            bool b = false;
            int ord = lv.ListView_ColumnHeaderPosition(h.Index);
            if (ord != c.column_order)
            {
                b = true;
                CurrentTemplate.ChangeColumnOrder(NMWin.ContextDefault, c, ord);
            }
            int w = Convert.ToInt32(((Convert.ToDouble(h.Width) / Convert.ToDouble(lv.Width)) * (Double)100));
            if (w != c.column_width)
            {
                h.WidthPercent = w;
                c.column_width = w;
                b = true;
            }
            if (b)
                NMWin.ContextDefault.Update(c);
        }

        public void SaveLayout()
        {
            SaveLayout(false);
        }

        public void SaveLayout(bool skipcheck)
        {
            if (!nList.AllowConfiguration)
                return;

            if (!skipcheck)
            {
                if (NMWin.User != null)
                {
                    if (!NMWin.User.template_editor)
                        return;
                }
            }
            String strKey;
            n_column xColumn;
            foreach (tColumnHeader c in lv.Columns)
            {
                if ((Object)c.Tag != null)
                {
                    xColumn = (n_column)c.Tag;
                    if (xColumn != null)
                        SaveColumnHeader(c, xColumn);
                }
            }
        }
        public ArrayList GetSelectedObjects()
        {
            ArrayList a = new ArrayList();
            nObject o;
            foreach (ListViewItem xLst in lv.SelectedItems)
            {
                if (xLst.Selected)
                {
                    o = GetObjectFromItem(xLst);
                    if (o != null)
                    {
                        a.Add(o);
                    }
                }
            }
            return a;
        }

        public void CheckBoxesInit()
        {
            lv.CheckBoxes = true;
        }

        public ArrayList GetCheckedObjects()
        {
            ArrayList a = new ArrayList();
            nObject o;
            foreach (ListViewItem xLst in lv.CheckedItems)
            {
                //if (xLst.Selected)
                //{
                o = GetObjectFromItem(xLst);
                if (o != null)
                {
                    a.Add(o);
                }
                //}
            }
            return a;
        }

        public long GetSelectedCount()
        {
            long l = 0;
            foreach (ListViewItem xLst in lv.SelectedItems)
            {
                if (xLst.Selected)
                    l++;
            }
            return l;
        }
        public void RemoveSelectedItems()
        {
            ArrayList a = new ArrayList();
            foreach (ListViewItem l in lv.Items)
            {
                if (l.Selected)
                    a.Add(l);
            }
            foreach (ListViewItem l in a)
            {
                lv.Items.Remove(l);
            }
        }
        public void InhibitNotify()
        {
            NotifyInhibited = true;
            changeOnResume = false;
        }
        public void ResumeNotify()
        {
            NotifyInhibited = false;
            if (changeOnResume)
                TemplateClassChanged();
        }

        bool changeOnResume = false;
        private void ResumeNotify(String strClass)
        {
            NotifyInhibited = false;
            if (changeOnResume)
                TemplateClassChanged();
        }

        public void DisableAutoRefresh()
        {
            Invoke(new NothingDelegate(ActuallyDisableAutoRefresh));
        }

        protected void ActuallyDisableAutoRefresh()
        {
            chkRefresh.Checked = false;
        }

        public void EnableAutoRefresh()
        {
            Invoke(new NothingDelegate(ActuallyEnableAutoRefresh));
        }

        protected void ActuallyEnableAutoRefresh()
        {
            chkRefresh.Checked = true;
        }

        public bool AutoRefreshEnabled
        {
            get
            {
                return chkRefresh.Checked;
            }
        }

        public void SetUnlimited()
        {
            chkUnlimited.Checked = true;
            UnlimitedResults = true;
        }
        public void DisableUnlimited()
        {
            chkUnlimited.Enabled = false;
        }

        public void ReClickLast()
        {
            if (LastClicked != null)
            {
                if (!CollectionMode)
                    LastClicked = (nObject)NMWin.ContextDefault.GetById(LastClicked.ClassId, LastClicked.unique_id);
                if (LastClicked != null)
                    ObjectClicked(this, new ObjectClickArgs(LastClicked, true));
            }
        }
        public void ShowCollection(String strClass, String strTemplate)
        {
            HasSearched = true;
            CollectionMode = true;
            ShowTemplate(strTemplate, strClass, true, "");
            RefreshFromCollection();
        }
        public void RefreshFromCollection()
        {
            RefreshFromCollection(false);
        }
        public void RefreshFromCollection(Boolean bUseKeyForTag)
        {
            if (CurrentItems == null)  // && CurrentSortedCollection == null
                return;
            CollectionMode = true;
            HasSearched = true;  //not having this was keeping the updates from showing
            ArrayList a = new ArrayList();
            //if (CurrentItems.Reordered)
            //{
            //    lv.Items.Clear();
            //    CurrentItems.Reordered = false;
            //}
            foreach (ListViewItem lst in lv.Items)
            {
                a.Add(lst);
            }

            IItems items = null;
            if (CurrentVar == null)
                items = CurrentItems;
            else
                items = CurrentVar.RefsGetAsItems(NMWin.ContextDefault);

            if (CurrentTemplate != null)
            {
                if (CurrentTemplate.template_name.ToLower().Contains("purchase"))
                {
                    ;
                }
            }

            lv.SuspendLayout();
            lv.BeginUpdate();
            try
            {
                nObject o;
                ListViewItem l;
                if (CurrentItems != null)
                {
                    foreach (IItem i in items.AllGet(NMWin.ContextDefault))
                    {
                        o = (nObject)i;
                        l = lv.Items[o.unique_id];
                        if (l == null)
                        {
                            String uid = o.unique_id;
                            if (bUseKeyForTag)
                                uid = o.unique_id;
                            l = lv.Items.Add(uid, "", 0);
                            l.Tag = uid;
                            for (int ix = 0; ix < (CurrentTemplate.AllColumns.Count - 1); ix++)
                            {
                                l.SubItems.Add("");
                            }
                        }
                        else
                        {
                            if (o.Invalid)
                            {
                                lv.Items.Remove(l);
                                break;
                            }
                            a.Remove(l);
                        }
                        RefreshItem(l, o);
                    }
                }
                //remove extras
                foreach (ListViewItem lst in a)
                {
                    lv.Items.Remove(lst);
                }
            }
            catch (Exception)
            { }
            lv.EndUpdate();
            lv.ResumeLayout();
            try
            {
                if (lv.Items.Count == 0)
                    SetStatus("No results.");
                else if (lv.Items.Count == 1)
                    SetStatus("1 result.");
                else
                    SetStatus(Tools.Number.LongFormat(lv.Items.Count) + " results.");
            }
            catch (Exception ex)
            {
                string exception = ex.Message;
            }
            if (FinishedFill != null)
                FinishedFill(this);
        }
        public void RefreshItem(ListViewItem xLst, nObject o)
        {
            String strValue;
            Object val;
            Int32 color;
            int j = 0;
            n_column c;
            bool boolColor = false;
            int ic;
            foreach (DictionaryEntry d in CurrentTemplate.AllColumns)
            {
                try
                {
                    c = (n_column)d.Value;
                    val = o.IGet(c.field_name);
                    strValue = Stylizer.RenderVal(val, c, NMWin.ContextDefault.TheSys.CurrencySymbol);
                    if (j == 0)
                    {
                        //xLst = lv.Items.Add(o.unique_id, strValue, 0);
                        //xLst.Tag = o.unique_id;
                        xLst.Text = strValue;
                        //if (UseShadedLines)
                        //{
                        //    if (boolColor)
                        //        xLst.BackColor = bColor;
                        //    boolColor = !boolColor;
                        //}
                        ic = o.grid_color;
                        if (ic != 0)
                        {
                            xLst.ForeColor = nTools.GetColorFromInt(ic);
                        }
                        ic = o.icon_index;
                        if (ic > 0)
                        {
                            xLst.ImageIndex = (ic - 1);
                        }
                        else
                        {
                            xLst.ImageIndex = -1;
                        }
                    }
                    else
                    {
                        while (xLst.SubItems.Count < (j + 1))
                        {
                            xLst.SubItems.Add("");
                        }
                        xLst.SubItems[j].Text = strValue;
                    }
                }
                catch (Exception ex)
                {
                    NMWin.ContextDefault.Leader.Error(ex);
                }
                j++;
            }
        }
        public void SelectObjectByID(String ID)
        {
            try
            {
                foreach (ListViewItem xLst in lv.Items)
                {
                    if (!Tools.Strings.StrCmp(xLst.Tag.ToString(), ID))
                        continue;
                    xLst.Selected = true;
                    xLst.EnsureVisible();
                    return;
                }
            }
            catch (Exception)
            {
            }
        }
        public nObject GetNextObject()
        {
            try
            {
                ListViewItem i = lv.SelectedItems[0];
                if (i == null)
                    return null;
                if (i.Index == lv.Items.Count - 1)
                    return null;
                lv.SelectedIndices.Clear();
                lv.SelectedIndices.Add(i.Index + 1);
                return GetSelectedObject();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public nObject GetPreviousObject()
        {
            try
            {
                ListViewItem i = lv.SelectedItems[0];
                if (i == null)
                    return null;
                if (i.Index == 0)
                    return null;
                lv.SelectedIndices.Clear();
                lv.SelectedIndices.Add(i.Index - 1);
                return GetSelectedObject();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public String GetScrollCaption()
        {
            try
            {
                ListViewItem i = lv.SelectedItems[0];
                if (i == null)
                    return "";
                return Tools.Number.LongFormat(i.Index + 1) + " of " + Tools.Number.LongFormat(lv.Items.Count);
            }
            catch (Exception)
            {
                return "";
            }
        }
        public void SelectFirst()
        {
            SelectFirst(false);
        }
        public void SelectFirst(Boolean bSendObjectClick)
        {
            if (lv.Items.Count <= 0)
                return;
            try
            {
                ListViewItem lvi = lv.Items[0];
                lvi.Selected = true;
                if (bSendObjectClick)
                {
                    nObject o = GetObjectFromItem(lv.Items[0]);
                    if (o == null)
                    {
                        return;
                    }
                    ObjectClicked(this, new ObjectClickArgs(o, true));
                }
            }
            catch (Exception ex)
            {
                string test = ex.Message;

            }

        }
        public void HighlightByID(String strID)
        {
            foreach (ListViewItem l in lv.Items)
            {
                if ((String)l.Tag == strID)
                {
                    l.Selected = true;
                    l.EnsureVisible();
                }
                else
                {
                    l.Selected = false;
                }
            }
        }
        public void SetStatus(String NewStatus)
        {
            lblStatus.Text = NewStatus;
            AlignUnlimitedCheckbox();
        }
        public void SetAlternateIcons(ImageList il)
        {
            AlternateIcons = true;
            AlternateIconList = il;
        }
        public void DoExport(String type)
        {
            try
            {
                NMWin.Leader.StartPopStatus();
                NMWin.Leader.Comment("Starting " + type + " export.");
                NMWin.Leader.Comment("Checking...");
                if (lv.Items.Count > 0)
                {
                    Boolean bSelected = false;
                    if (lv.SelectedItems.Count > 1)
                        bSelected = NMWin.Leader.AskYesNo("It appears as though you have more than one record selected. Do you want to only export the selected items?");
                    if (bSelected)
                        NMWin.Leader.Comment("Found " + lv.SelectedItems.Count + " items.");
                    else
                        NMWin.Leader.Comment("Found " + lv.Items.Count + " items.");
                    NMWin.Leader.Comment("Exporting...");

                    if (Tools.Strings.StrCmp(type, "Excel"))
                    {

                        String folder = ToolsWin.FileSystem.ChooseAFolder(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
                        if (!Directory.Exists(folder))
                            return;

                        String file = NMWin.Leader.AskForString("File name", "Export_" + Tools.Dates.GetNowPathHMS() + ".xlsx", "File Name");
                        if (!Tools.Strings.StrExt(file))
                            return;

                        if (!file.ToLower().EndsWith(".xlsx"))
                            file += ".xlsx";

                        file = Tools.Folder.ConditionFolderName(folder) + file;
                        if (File.Exists(file))
                        {
                            if (!NMWin.Leader.AreYouSure("delete the existing copy of " + Path.GetFileName(file)))
                                return;

                            try
                            {
                                File.Delete(file);
                            }
                            catch (Exception ex)
                            {
                                NMWin.Leader.Error(ex);
                                return;
                            }
                        }

                        ToolsWin.Excel.ListViewToExcel(file, lv, bSelected, CurrentTemplate.ColumnTypes(NMWin.ContextDefault));
                        Tools.FileSystem.Shell(file);

                        //xExcel = ToolsOffice.ExcelOffice.ExportListViewToExcel(lv, true, bSelected);
                        //if (xExcel != null)
                        //    context.TheLeader.Comment("Excel file " + xExcel.GetWorkbookName(1) + " is loading.");
                    }
                    else
                    {
                        String folder = ToolsWin.FileSystem.ChooseAFolder(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
                        if (!Directory.Exists(folder))
                            return;

                        String file = NMWin.Leader.AskForString("File name", "RzExport.csv", false, "File Name");
                        if (!Tools.Strings.StrExt(file))
                            return;
                        ToolsOffice.ExcelOffice.ExportListViewToCsv(NMWin.ContextDefault, lv, true, bSelected, Tools.Folder.ConditionFolderName(folder) + file);
                    }
                }
                else
                    NMWin.Leader.Comment("No items were found.");
                NMWin.Leader.Comment("Done");
                NMWin.Leader.StopPopStatus(true);
            }
            catch (Exception ee)
            {
                NMWin.Leader.Comment("Error! " + ee.Message);
                NMWin.Leader.StopPopStatus(true);
            }
        }
        public ArrayList GetAllIDs()
        {
            ArrayList a = new ArrayList();
            foreach (ListViewItem i in lv.Items)
            {
                a.Add((String)i.Tag);
            }
            return a;
        }
        //Private Functions
        private void ShowSearchTime(int seconds)
        {
            //switch(seconds)
            //{
            //    case 0:
            //        xSys.SetStatus("Search complete.", ActivityType.None);
            //        break;
            //    case 1:
            //        xSys.SetStatus("Search complete in 1 second.", ActivityType.None);
            //        break;
            //    default:
            //        xSys.SetStatus("Search complete in " + Tools.Number.LongFormat(seconds) + " seconds.", ActivityType.None);
            //        break;
            //}
        }
        private void RefreshObjectMenu()
        {
            try
            {
                //String se = ExtraClassInfo;
                //if (!Tools.Strings.StrExt(se))
                //    se = GetExtraClassInfo();
                if (xSys == null || CurrentTemplate == null)
                    return;

                ActSetup actSetup;

                if (TheArgs == null)
                    actSetup = new ActSetup();
                else
                    actSetup = TheArgs.ActSetupCreate();

                actSetup.IsRightClick = true;
                actSetup.TheItems = new ItemsInstance();

                int lim = 0;
                foreach (nObject x in GetSelectedObjects())
                {
                    if (lim >= 10)
                        break;

                    actSetup.TheItems.Add(NMWin.ContextDefault, x);
                    lim++;
                }
                NMWin.ContextDefault.TheSys.ActsListInstance(NMWin.ContextDefault, actSetup);
                LoadMenu(actSetup.Handles);
            }
            catch
            { }
        }
        //private String GetExtraClassInfo()
        //{
        //    String s = "";
        //    foreach(ListViewItem i in lv.SelectedItems)
        //    {
        //        String t = xSys.GetExtraClassInfo(CurrentTemplate.class_name, (String)i.Tag);
        //        if(Tools.Strings.StrExt(s) && !Tools.Strings.StrCmp(s, t))
        //        {
        //            return "";
        //        }
        //        s = t;
        //    }
        //    return s;
        //}
        private void LoadMenu(List<ActHandle> actHandles)
        {
            ClearMenu();
            foreach (ActHandle h in actHandles)
            {
                if (h is ActHandleSeparator)
                {
                    ToolStripSeparator s = new ToolStripSeparator();
                    mnu.Items.Add(s);
                }
                else
                {
                    ToolStripMenuItem t = new ToolStripMenuItem();
                    t.Text = h.Caption;
                    t.Tag = h;
                    t.Click += new EventHandler(ExternalMenuClick);
                    mnu.Items.Add(t);
                }
            }

            //add export
            if (NMWin.ContextDefault.xUser.HasPermit(Permissions.ThePermits.ExportListsToExcel, true))
            {
                if (mnu.Items.Count > 0)
                    mnu.Items.Add(new ToolStripSeparator());

                ToolStripMenuItem t = new ToolStripMenuItem();
                t.Text = "Export";
                t.Click += new EventHandler(ExternalMenuClick);
                mnu.Items.Add(t);
            }

            //add copy
            ToolStripMenuItem copy = new ToolStripMenuItem();
            copy.Text = "Copy";
            copy.Click += new EventHandler(mnuCopy_Click);
            mnu.Items.Add(copy);
        }
        private Form GetSearchForm(nSearch s)
        {
            if (s == null)
                return new Form();
            s.CompleteLoad(NMWin.ContextDefault.TheSys.CoreClassGet(CurrentTemplate.class_name));
            Form xForm = new Form();
            xForm.StartPosition = FormStartPosition.CenterScreen;
            xForm.Text = s.FriendlyName + " Detailed Search";
            xForm.Height = 335;
            xForm.Width = 610;
            xForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            xForm.MaximizeBox = false;
            xForm.Controls.Add(s);
            s.Top = 0;
            s.Left = 0;
            s.Width = xForm.ClientRectangle.Width;
            s.Height = xForm.ClientRectangle.Height;
            s.DoResize();
            return xForm;
        }
        private void ExternalMenuClick(object sender, EventArgs e)
        {
            ActHandle a = null;
            try
            {
                ToolStripMenuItem i = (ToolStripMenuItem)sender;

                if (i.Text == "Export" && i.Tag == null)
                {
                    DoExport("Excel");
                    return;
                }

                a = (ActHandle)i.Tag;
                RunAction(a);
            }
            catch (Exception ex)
            {
                if (a == null)
                    NMWin.Leader.Error("There was an error running this command: " + ex.Message);
                else
                    NMWin.Leader.Error("There was an error running the command '" + a.Name + "': " + ex.Message);
            }
        }
        private void RunAction(ActHandle act)
        {
            try
            {
                if (AboutToAction != null)
                {
                    ActArgs args = ((SysNewMethod)xSys).TheListViewLogic.GetRunActionKeyActArgs(NMWin.ContextDefault, act.Name);
                    AboutToAction(this, args);
                    if (args.Handled)
                        return;
                }

                switch (lv.SelectedItems.Count)
                {
                    case 0:
                        return;
                    default:

                        bool refreshRequired = !NotifyInhibited;
                        switch (act.Name)
                        {
                            case "Open":
                                refreshRequired = false;
                                break;

                        }


                        if (refreshRequired)
                            InhibitNotify();

                        ActArgs args = null;
                        Context xx = NMWin.ContextDefault.Clone();
                        String cid = xx.TheDelta.StartChangeCache();

                        try
                        {
                            //prepare the args
                            args = ((SysNewMethod)xSys).TheListViewLogic.GetRunActionKeyActArgs(NMWin.ContextDefault, act.Name);
                            args.TheItems = new ItemsInstance();
                            foreach (nObject x in GetSelectedObjects())
                            {
                                args.TheItems.Add(NMWin.ContextDefault, (IItem)x);
                            }
                            args.AbsorbHandle(act);

                            //run the action
                            NMWin.ContextDefault.TheSys.ActInstanceBeforeAfter(xx, args);
                       }
                        catch (Exception ex)
                        {
                            NMWin.Leader.Tell("An error occurred while running this command: " + ex.Message);
                        }

                        xx.TheDelta.EndChangeCache(NMWin.ContextDefault, cid);

                        if (refreshRequired)
                        {
                            if (args.Canceled)
                                NotifyInhibited = false;
                            else
                            {
                                if (CurrentTemplate != null)
                                    ResumeNotify(CurrentTemplate.class_name);
                            }
                        }

                        break;
                }
                if (FinishedAction != null)
                {
                    ActArgs args = ((SysNewMethod)xSys).TheListViewLogic.GetRunActionKeyActArgs(NMWin.ContextDefault, act.Name);
                    FinishedAction(this, args);
                }
            }
            catch (Exception ex)
            {
                NMWin.Leader.Tell("An error occurred while running this command: " + ex.Message);
            }
        }
        private void ClearMenu()
        {
            try
            {
                foreach (ToolStripMenuItem i in mnu.Items)
                {
                    i.Click -= new EventHandler(ExternalMenuClick);
                }
            }
            catch { }

            mnu.Items.Clear();
        }
        private void SetColors()
        {
            ColorLimit = CurrentTemplate.background_repeat;
            UseColor = ColorLimit > 0;
            if (ColorLimit > 1)
            {
                BackColors = new Color[ColorLimit];
                for (int k = 1; k <= ColorLimit; k++)
                {
                    try
                    {
                        switch (k)
                        {
                            case 1:
                                if (CurrentTemplate.color_1 == 0)
                                    BackColors.SetValue(Color.White, 0);
                                else
                                    BackColors.SetValue(Color.FromArgb(CurrentTemplate.color_1), 0);
                                break;
                            case 2:
                                if (CurrentTemplate.color_2 == 0)
                                    BackColors.SetValue(Color.White, 1);
                                else
                                    BackColors.SetValue(Color.FromArgb(CurrentTemplate.color_2), 1);
                                break;
                            case 3:
                                if (CurrentTemplate.color_3 == 0)
                                    BackColors.SetValue(Color.White, 2);
                                else
                                    BackColors.SetValue(Color.FromArgb(CurrentTemplate.color_3), 2);
                                break;
                            case 4:
                                if (CurrentTemplate.color_4 == 0)
                                    BackColors.SetValue(Color.White, 3);
                                else
                                    BackColors.SetValue(Color.FromArgb(CurrentTemplate.color_4), 3);
                                break;
                            case 5:
                                if (CurrentTemplate.color_5 == 0)
                                    BackColors.SetValue(Color.White, 4);
                                else
                                    BackColors.SetValue(Color.FromArgb(CurrentTemplate.color_5), 4);
                                break;
                            case 6:
                                if (CurrentTemplate.color_6 == 0)
                                    BackColors.SetValue(Color.White, 5);
                                else
                                    BackColors.SetValue(Color.FromArgb(CurrentTemplate.color_6), 5);
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        BackColors.SetValue(Color.White, k - 1);
                    }
                }
            }
            else if (ColorLimit == 1)
            {
                SingleColor = Color.FromArgb(CurrentTemplate.color_1);
            }
            ColorStep = 0;
        }
        private void AlignUnlimitedCheckbox()
        {
            chkUnlimited.Top = chkRefresh.Top;
            chkUnlimited.Left = lblStatus.Right;
        }
        //private void SetObjectColor(int c)
        //{
        //    nObject o;
        //    foreach(ListViewItem xLst in lv.SelectedItems)
        //    {
        //        o = null;
        //        if( CollectionMode )
        //            o = (nObject)CurrentItems.ByIdGet(NMWin.ContextDefault, (String)xLst.Tag);
        //        else
        //            o = xSys.GetByID(CurrentTemplate.class_name, (String)xLst.Tag);
        //        if(o != null)
        //        {
        //            o.SetGridColor(c);
        //            xLst.ForeColor = nTools.GetColorFromInt(c);
        //        }
        //    }
        //}
        //private void SetObjectIcon(int i)
        //{
        //    nObject o;
        //    foreach(ListViewItem xLst in lv.SelectedItems)
        //    {
        //        o = GetObjectFromItem(xLst);
        //        if(o != null)
        //        {
        //            o.SetIconIndex(i);
        //            xLst.ImageIndex = ( i - 1 );
        //        }
        //    }
        //}

        private int GetBackgroundRepeat()
        {
            int i;
            switch (cboColors.Text.ToLower())
            {
                case "":
                    i = 0;
                    break;
                case "none":
                    i = 0;
                    break;
                default:
                    i = Convert.ToInt32(cboColors.Text);
                    break;
            }
            return i;
        }
        private void SetColorBoxes()
        {
            int i = GetBackgroundRepeat();
            pic1.Visible = false;
            pic2.Visible = false;
            pic3.Visible = false;
            pic4.Visible = false;
            pic5.Visible = false;
            pic6.Visible = false;
            for (int j = 1; j <= i; j++)
            {
                switch (j)
                {
                    case 1:
                        SetColorBox(pic1, CurrentTemplate.color_1);
                        break;
                    case 2:
                        SetColorBox(pic2, CurrentTemplate.color_2);
                        break;
                    case 3:
                        SetColorBox(pic3, CurrentTemplate.color_3);
                        break;
                    case 4:
                        SetColorBox(pic4, CurrentTemplate.color_4);
                        break;
                    case 5:
                        SetColorBox(pic5, CurrentTemplate.color_5);
                        break;
                    case 6:
                        SetColorBox(pic6, CurrentTemplate.color_6);
                        break;
                }
            }
        }
        private void SetColorBox(PictureBox p, int c)
        {
            p.Visible = true;
            if (c == 0)
                p.BackColor = System.Drawing.Color.White;
            else
                p.BackColor = System.Drawing.Color.FromArgb(c);
        }
        private void ShowAsyncWait(int seconds)
        {
            try
            {
                if (aw == null)
                {
                    aw = new AsyncWait();
                    this.Controls.Add(aw);
                }
                aw.CanCancel = true;
                aw.SetCaption("Searching...");
                aw.BringToFront();
                aw.Dock = DockStyle.Fill;
                aw.SetDuration(seconds);
                AsyncSearchMenu = true;
            }
            catch (Exception)
            {
            }
        }
        private void HideAsyncWait()
        {
            if (aw == null)
                return;
            try
            {
                this.Controls.Remove(aw);
                aw.Dispose();
                aw = null;
                AsyncSearchMenu = false;
            }
            catch (Exception)
            {
            }
        }
        //Buttons
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RunExtraSearch();
        }
        public void RunExtraSearch()
        {
            try
            {
                nSearch search = NMWin.Leader.GetSearch(CurrentTemplate.class_name, "");
                if (search == null)
                {
                    NMWin.Leader.Tell("The search feature has not been enabled for the '" + CurrentTemplate.class_name + "' class.");
                    return;
                }
                Form xForm = GetSearchForm(search);
                xForm.ShowDialog();
                String where = search.GetWhere();
                if (Tools.Strings.StrExt(where))
                {
                    LastWhere = where;
                }
                else
                {
                    if (LastWhere == null)
                        return;
                }
                long newlimit = LastLimit;
                if (UnlimitedResults)
                    newlimit = -1;
                if (CurrentTemplate == null)
                    return;
                LastClass = CurrentTemplate.class_name;
                if (LastOrder == null)
                    LastOrder = "";
                ShowData(LastClass, LastWhere, LastOrder, newlimit, true);
            }
            catch (Exception)
            {
            }
        }
        private void DoExpandRight()
        {
            IsExpandedRight = !IsExpandedRight;
            DoResize();
        }
        private void OpenColumnEditor()
        {
            if (CurrentTemplate == null)
            {
                NMWin.Leader.Error("No template is currently set for this display.");
                return;
            }
            frmColumnSelect xForm = new frmColumnSelect();
            xForm.xSys = this.xSys;
            xForm.CurrentList = this;
            xForm.CompleteLoad();
            xForm.ShowDialog();
            //if( xSys.DisconnectedMode )
            //    CurrentTemplate.SaveColumnsDisconnected();
            this.ShowCurrentTemplate();
            this.ReDoSearch();
        }
        private void cmdSHRight_Click(object sender, EventArgs e)
        {
            if (!zz_OpenColumnMenu)
                DoExpandRight();
            else
                OpenColumnEditor();
        }
        private void cmdColumns_Click(object sender, EventArgs e)
        {
            OpenColumnEditor();
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (AboutToAdd != null)
            {
                AddArgs a = new AddArgs();
                AboutToAdd(this, a);
                if (a.Handled)
                    return;
            }
            //String strClass = xSys.GetClassName(CurrentTemplate.the_n_class_uid);

            String strClass = CurrentTemplate.class_name;
            //if( !Tools.Strings.StrExt(strClass) )
            //    strClass = CurrentTemplate.class_name;
            nObject n = (nObject)NMWin.ContextDefault.Item(strClass);
            //n.ICreate(xSys, "");  what's this for?  it was making the system create the object as soft
            if (AlternateConnection == null && !Tools.Strings.StrExt(AlternateTableName))
            {
                NMWin.ContextDefault.Insert(n);
            }
            else
            {
                n.Inserting(NMWin.ContextDefault);
                String strTable = CurrentTemplate.class_name;
                if (Tools.Strings.StrExt(AlternateTableName))
                    strTable = AlternateTableName;
                DataConnection dx = NMWin.Data;
                if (AlternateConnection != null)
                    dx = AlternateConnection;
                String s = NMWin.ContextDefault.TheData.InsertOneSql(NMWin.ContextDefault, n, strTable);
                dx.Execute(s);
            }
            ShowObject(n);
        }
        private void cmdAll_Click(object sender, EventArgs e)
        {
            if (CurrentTemplate == null)
                return;
            if (xSys == null)
                return;
            if (!NMWin.Leader.AreYouSure("permanently change the formatting of every display to match this one"))
                return;
            String strSQL = "update n_template set use_gridlines = " + DataConnectionSqlServer.BoolFilter(CurrentTemplate.use_gridlines) + ", color_1 = " + CurrentTemplate.color_1.ToString() + ", color_2 = " + CurrentTemplate.color_2.ToString() + ", color_3 = " + CurrentTemplate.color_3.ToString() + ", color_4 = " + CurrentTemplate.color_4.ToString() + ", color_5 = " + CurrentTemplate.color_5.ToString() + ", color_6 = " + CurrentTemplate.color_6.ToString() + ", background_repeat = " + CurrentTemplate.background_repeat.ToString() + " ";
            NMWin.Data.Execute(strSQL);
        }
        private void cmdSQL_Click(object sender, EventArgs e)
        {
            NMWin.Leader.ShowSql(CurrentSQL);
        }
        private void cmdClear_Click(object sender, EventArgs e)
        {
            if (!NMWin.Leader.AreYouSure("remove this column layout"))
                return;
            Clear();
            lv.Columns.Clear();
            if (CurrentTemplate == null)
                return;
            String strClass = CurrentTemplate.class_name;
            if (!Tools.Strings.StrExt(strClass))
                strClass = NMWin.Leader.AskForString("Class name for template '" + CurrentTemplate.template_name + "'", "", "Class");
            if (!Tools.Strings.StrExt(strClass))
                return;
            String strName = CurrentTemplate.template_name;
            NMWin.ContextDefault.Delete(CurrentTemplate);
            CurrentTemplate = null;
            //ShowTemplate(strName, strClass);
        }
        private void cmdExport_Click(object sender, EventArgs e)
        {
            DoExport("Excel");
        }
        //Control Events
        private void nList_Load(object sender, EventArgs e)
        {
            lv.AllowColumnReorder = true;
        }
        private void pic_Click(object sender, EventArgs e)
        {
            PictureBox p;
            try
            {
                p = (PictureBox)sender;
            }
            catch (Exception)
            {
                return;
            }
            bool cancel = false;
            int c = NMWin.Leader.ChooseColor(Color.Black, ref cancel).ToArgb();
            if (cancel)
                return;
            CurrentTemplate.ISet("color_" + (String)p.Tag, (object)c);
            NMWin.ContextDefault.Update(CurrentTemplate);
            p.BackColor = System.Drawing.Color.FromArgb(c);
            ReColor();
        }

        private void lv_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                dragdown = true;
                dragcatch = false;
            }
            else
            {
                int j = 0;
            }
        }
        private void lv_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragdown = false;
            }
        }
        private void lv_MouseMove(object sender, MouseEventArgs e)
        {
            if (AllowDrag && dragdown && dragcatch)
            {
                ArrayList a = GetSelectedObjects();
                if (a == null)
                    return;
                if (a.Count <= 0)
                    return;
                dragdown = false;
                lv.DoDragDrop(a, DragDropEffects.Copy | DragDropEffects.Move);
            }
            if (!dragcatch)
                dragcatch = true;
        }
        private void lv_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
        }
        private void lv_DoubleClick(object sender, EventArgs e)
        {

            ThrowSelected();
        }
        private void lv_ColumnReordered(object sender, ColumnReorderedEventArgs e)
        {
            if (bInhibitLayout)
                return;
            xTime.Stop();
            xTime.Interval = 500;
            xTime.Start();
        }
        private void lv_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                lv.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (lv.Sorting == SortOrder.Ascending)
                    lv.Sorting = SortOrder.Descending;
                else
                    lv.Sorting = SortOrder.Ascending;
            }
            int t;
            n_column c = (n_column)(lv.Columns[e.Column].Tag);
            t = c.data_type;
            if (t == 0)
                t = 1;
            this.lv.ListViewItemSorter = new ListViewItemComparer(e.Column, lv.Sorting, t);
            lv.Sort();
            ReColor();
        }
        private void lv_ColumnResize_1(object sender, ManagedControls.ManagedListView.ColumnResizeEventArgs e)
        {
            if (bInhibitLayout)
                return;
            xTime.Stop();
            xTime.Interval = 500;
            xTime.Start();
        }
        private void lv_ColumnResize(object sender, ManagedControls.ManagedListView.ColumnResizeEventArgs e)
        {
            if (bInhibitLayout)
                return;
            xTime.Stop();
            xTime.Interval = 500;
            xTime.Start();
        }
        private void lv_Click(object sender, EventArgs e)
        {
            if (ObjectClicked == null)
                return;
            if (CollectionMode)
            {
                nObject o = GetSelectedObject();
                if (o == null)
                    return;
                LastClicked = o;
                ObjectClicked(this, new ObjectClickArgs(o));
            }
            else
            {
                nObjectHandle h = GetSelectedHandle();
                if (h == null)
                    return;
                LastHandleClicked = h;
                ObjectClicked(this, new ObjectClickArgs(h));
            }
        }
        private void lv_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (SuppressSelectionChanged)
                return;
            try
            {
                lv_Click(this, new EventArgs());
            }
            catch
            {
            }
        }

        bool inhibit_colors = false;
        private void cboColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inhibit_colors)
                return;

            CurrentTemplate.background_repeat = GetBackgroundRepeat();
            NMWin.ContextDefault.Update(CurrentTemplate);
            SetColorBoxes();
            ReColor();
        }
        private void xTime_Tick(object sender, EventArgs e)
        {
            if (bInhibitLayout)
                return;
            if (SysNewMethod.ExplicitLayoutSave)
                return;
            bInhibitLayout = true;
            xTime.Stop();
            SaveLayout();
            bInhibitLayout = false;
        }
        private void nList_Load_1(object sender, EventArgs e)
        {
            lv.AllowColumnReorder = true;
            lv.FullRowSelect = true;
        }
        private void nList_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void chkLines_CheckedChanged(object sender, EventArgs e)
        {
            CurrentTemplate.use_gridlines = chkLines.Checked;
            NMWin.ContextDefault.Update(CurrentTemplate);
            SetLines();
        }
        private void chkUnlimited_CheckedChanged(object sender, EventArgs e)
        {
            UnlimitedResults = ((CheckBox)sender).Checked;
            if (UnlimitedResults)
                chkRefresh.Checked = false;

            if (TheArgs != null)
            {
                Init(TheArgs);
            }

            //ReDoSearch();
        }
        private void chkRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRefresh.Checked)
                ReDoSearch();
        }
        //Background Workers
        void AsyncThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (CurrentRst == null)
                {
                    SetStatus("No results.");
                    try
                    {
                        AsyncTimer.Stop();
                        ShowSearchTime(Convert.ToInt32(LastSearchTicks / 1000));
                    }
                    catch { }
                    try
                    {
                        HideAsyncWait();
                    }
                    catch { }
                }
            }
            catch { }
            try
            {
                if (aw != null)
                    aw.SetCaption("Loading...");
            }
            catch { }
            try
            {
                ShowResults(CurrentRst);
            }
            catch { }
            try
            {
                AsyncTimer.Stop();
                ShowSearchTime(Convert.ToInt32(LastSearchTicks / 1000));
            }
            catch { }
            try
            {
                HideAsyncWait();
            }
            catch { }
            try
            {
                if (TheArgs != null)
                    TheArgs.CleanUpTables();
            }
            catch (Exception ex)
            {
                NMWin.ContextDefault.Leader.Error(ex.Message);
            }
        }
        void AsyncThread_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime t = System.DateTime.Now;
            DataTable rst = null;
            try
            {
                if (AlternateConnection != null)
                    rst = AlternateConnection.Select(CurrentSQL);
                else
                    rst = NMWin.ContextDefault.Select(CurrentSQL);
            }
            catch (Exception ex)
            {
                NMWin.Leader.Error(ex);
            }
            TimeSpan ts = System.DateTime.Now.Subtract(t);
            LastSearchTicks = ts.Milliseconds;
            CurrentRst = rst;
        }
        void AsyncTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts;
            try
            {
                //update the ticker
                ts = System.DateTime.Now.Subtract(AsyncStart);
            }
            catch (Exception)
            {
                ts = new TimeSpan(0);
            }
            if (AsyncSearchMenu && aw != null)
            {
                try
                {
                    //check for cancel
                    if (aw.WasCancelled)
                    {
                        //stop the search thread?
                        AsyncTimer.Stop();
                        HideAsyncWait();
                    }
                    int i = 0;
                    try
                    {
                        i = Convert.ToInt32(ts.TotalSeconds);
                    }
                    catch (Exception)
                    {
                    }
                    aw.SetDuration(i);
                    return;
                }
                catch (Exception)
                {
                }
            }
            int sec = 0;
            try
            {
                sec = Convert.ToInt32(ts.TotalSeconds);
            }
            catch (Exception)
            {
            }
            ShowAsyncWait(sec);
        }
        //Menus
        private void mnu_Opening(object sender, CancelEventArgs e)
        {
            if (e.Cancel)
            {
                e.Cancel = false;
            }

            try
            {
                if (lv.SelectedItems.Count == 0)
                {
                    e.Cancel = true;
                    return;
                }
                if (!AllowActions)
                {
                    e.Cancel = true;
                    return;
                }
                //if (AllowOnlyOpenDelete)
                //{
                //    mnu.Items.Clear();
                //    ToolStripItem i = mnu.Items.Add("Open");
                //    i.Click += new EventHandler(i_Click);
                //    i = mnu.Items.Add("Delete");
                //    i.Click += new EventHandler(i_Click);                  
                //    return;
                //}

                //if(CustomMenuOptions == null)
                //{
                RefreshObjectMenu();
                if (mnu.Items.Count == 0)
                {
                    e.Cancel = true;
                    return;
                }

                //if(menu != null)
                //{
                //    if(menu.BlockAll)
                //    {

                //    }
                //    if (menu.Canceled)
                //    {
                //        if (Tools.Strings.StrExt(menu.CancelMessage))
                //            SysNewMethod.ContextDefault.TheLeader.Tell(menu.CancelMessage);
                //        e.Cancel = true;
                //        return;
                //    }
                //    mnuDelete.Visible = (!menu.BlockDelete) || m_AllowDeleteAlways;
                //    mnuColor.Visible = !menu.BlockColor;
                //    mnuIcon.Visible = !menu.BlockIcon;
                //    mnuExcel.Visible = !menu.BlockExcel;
                //}
                //}
                //else
                //{
                //    mnu.Items.Clear();
                //    foreach(String s in CustomMenuOptions)
                //    {
                //        ToolStripItem i = mnu.Items.Add(s);
                //        i.Click += new EventHandler(i_Click);
                //    }
                //}
            }
            catch
            { }

            if (e.Cancel)
            {
                ;
            }
        }

        //void i_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ToolStripItem i = (ToolStripItem)sender;
        //        RunActionKey(i.Text.Trim().ToLower().Replace(" ", ""));
        //    }
        //    catch
        //    {
        //    }
        //}

        //private void mnuOpen_Click(object sender, EventArgs e)
        //{
        //    ThrowSelected();
        //}
        //private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SetObjectColor(nTools.GetIntFromColor(Color.Blue));
        //}
        //private void orangeToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SetObjectColor(nTools.GetIntFromColor(Color.Orange));
        //}
        //private void cloudToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SetObjectIcon(1);
        //}
        //private void earthToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SetObjectIcon(2);
        //}
        //private void fireToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SetObjectIcon(3);
        //}
        //private void lighteningToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SetObjectIcon(4);
        //}
        //private void redToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SetObjectColor(nTools.GetIntFromColor(Color.Red));
        //}
        //private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SetObjectColor(nTools.GetIntFromColor(Color.Green));
        //}
        //private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SetObjectColor(nTools.GetIntFromColor(Color.Yellow));
        //}
        //private void mnuDelete_Click(object sender, EventArgs e)
        //{
        //    DeleteSelected();
        //}
        //private void DeleteSelected()
        //{
        //    long sel = this.GetSelectedCount();
        //    if( sel <= 0 )
        //        return;
        //    if(sel == 1)
        //    {
        //        if( !context.TheLeader.AreYouSure("delete this item") )
        //            return;
        //    }
        //    else
        //    {
        //        if( !context.TheLeader.AreYouSure("delete " + sel.ToString() + " items") )
        //            return;
        //    }
        //    ArrayList a = this.GetSelectedObjects();

        //    String err = "";
        //    bool delete = true;
        //    foreach (nObject check in a)
        //    {
        //        if (!check.DeletePossible(SysNewMethod.ContextDefault, ref err))
        //        {
        //            context.TheLeader.Tell("Delete is not available: " + err);
        //            delete = false;
        //            break;
        //        }
        //    }

        //    if (!delete)
        //        return;

        //    InhibitNotify();
        //    foreach(nObject o in a)
        //    {
        //        if(AboutToDelete != null)
        //        {
        //            ActArgs args = new ActArgs("delete");
        //            args.TheItems.Add(SysNewMethod.ContextDefault, o);
        //            //args.xObject = o;
        //            AboutToDelete(this, args);
        //            if( !args.Handled )
        //                Delete(o);
        //        }
        //        else
        //        {
        //            Delete(o);
        //        }
        //    }
        //    ResumeNotify();
        //    this.RemoveSelectedItems();
        //    if(CollectionMode)
        //    {
        //        try
        //        {
        //            if(CurrentItems != null)    //sorted lists need to take care of themselves
        //            {
        //                foreach(nObject x in a)
        //                {
        //                    CurrentItems.RemoveById(SysNewMethod.ContextDefault, x.unique_id);
        //                }
        //            }
        //        }
        //        catch
        //        {
        //        }
        //    }
        //    if( ObjectsDeleted != null )
        //        ObjectsDeleted(a);
        //}
        //private void Delete(nObject o)
        //{
        //    if (xSys.Recall)
        //    {
        //        o.NoticeChanges(NMWin.ContextDefault, Enums.RecallType.Delete);
        //    }

        //    if ((AlternateConnection == null || AlternateConnection == xSys.xData ) && (!Tools.Strings.StrExt(AlternateTableName) || Tools.Strings.StrCmp(AlternateTableName, o.ClassName) || Tools.Strings.StrCmp(AlternateTableName, "orddet")))
        //    {
        //        o.IDelete();
        //    }
        //    else
        //    {
        //        nData dx = xSys.xData;
        //        if (AlternateConnection != null)
        //            dx = AlternateConnection;
        //        String strTable = CurrentTemplate.class_name;
        //        if (Tools.Strings.StrExt(AlternateTableName))
        //            strTable = AlternateTableName;
        //        dx.Execute("delete from " + strTable + " where unique_id = '" + o.unique_id + "'");
        //    }
        //}
        //private void mnuNoIcon_Click(object sender, EventArgs e)
        //{
        //    SetObjectIcon(0);
        //}
        private void mnuCopy_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem i = lv.SelectedItems[0];
                String s = "";
                int c = 0;
                foreach (ListViewItem.ListViewSubItem u in i.SubItems)
                {
                    s += lv.Columns[c].Text + ": " + u.Text + "\r\n";
                    c++;
                }
                s = Tools.Strings.KillBlankLines(s);
                try
                {
                    s += "\r\nSystem ID: " + (String)i.Tag;
                }
                catch
                {
                    try
                    {
                        nObjectHandle h = (nObjectHandle)i.Tag;
                        s += "\r\nSystem ID: " + h.unique_id;
                    }
                    catch
                    {
                    }
                }
                Tools.FileSystem.PopText(s);
            }
            catch (Exception)
            {
            }
        }
        //private void mnuBlack_Click(object sender, EventArgs e)
        //{
        //    SetObjectColor(nTools.GetIntFromColor(Color.Black));
        //}
        //private void mnuClip_Click(object sender, EventArgs e)
        //{
        //    nObject x = GetSelectedObject();
        //    if( x != null && xSys.xUser != null )
        //        xSys.xUser.AddClipObject(NMWin.ContextDefault, x, true);
        //}
        public void BackColorByString(System.Drawing.Color color, int i, String s)
        {
            lv.BeginUpdate();
            try
            {
                foreach (ListViewItem li in lv.Items)
                {
                    String x = "";
                    if (i == 0)
                        x = li.Text;
                    else
                        x = li.SubItems[i].Text;
                    if (Tools.Strings.HasString(x, s))
                        li.BackColor = color;
                }
            }
            catch
            {
            }
            lv.EndUpdate();
        }

        public void BackColorById(System.Drawing.Color color, ArrayList ids)
        {
            lv.BeginUpdate();
            try
            {
                foreach (ListViewItem li in lv.Items)
                {
                    String id = (String)li.Tag;
                    if (ids.Contains(id))
                        li.BackColor = color;
                    else
                        li.BackColor = Color.White;
                }
            }
            catch
            {
            }
            lv.EndUpdate();
        }

        public void BackColorClear()
        {
            lv.BeginUpdate();
            try
            {
                foreach (ListViewItem li in lv.Items)
                {
                    li.BackColor = Color.White;
                }
            }
            catch
            {
            }
            lv.EndUpdate();
        }

        public void RemoveByFieldNotMatchingString(String strField, String strMatch)
        {
            int i = CurrentTemplate.GetColumnIndexByProperty(strField);
            if (i == -1)
                return;
            ArrayList remove = new ArrayList();
            lv.BeginUpdate();
            try
            {
                foreach (ListViewItem li in lv.Items)
                {
                    String x = "";
                    if (i == 0)
                        x = li.Text;
                    else
                        x = li.SubItems[i].Text;
                    if (!x.ToLower().StartsWith(strMatch.ToLower()))
                        remove.Add(li);
                }
                foreach (ListViewItem li in remove)
                {
                    lv.Items.Remove(li);
                }
            }
            catch
            {
            }
            lv.EndUpdate();
        }
        public ArrayList GetUniqueValuesByField(String strField)
        {
            ArrayList a = new ArrayList();
            int i = CurrentTemplate.GetColumnIndexByProperty(strField);
            if (i == -1)
                return a;
            foreach (ListViewItem il in lv.Items)
            {
                String s = il.SubItems[i].Text;
                if (!a.Contains(s))
                    a.Add(s);
            }
            a.Sort();
            return a;
        }

        public int CountByFields(String strFields)
        {
            String[] fields = Tools.Strings.Split(strFields, ",");
            int[] indexes = new int[fields.Length];

            int i = 0;
            foreach (String field in fields)
            {
                indexes[i] = CurrentTemplate.GetColumnIndexByProperty(field);
                i++;
            }

            int ret = 0;
            foreach (ListViewItem il in lv.Items)
            {
                foreach (int x in indexes)
                {
                    if (x > -1)
                    {
                        if (Tools.Strings.StrExt(il.SubItems[x].Text))
                        {
                            ret++;
                            break;
                        }
                    }
                }
            }
            return ret;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveLayout(true);
        }
        public void BuildTemplate(String strClass, String strProps)
        {
            Clear();
            CoreClassHandle cl = NMWin.ContextDefault.TheSys.CoreClassGet(strClass);
            if (cl == null)
                return;
            CurrentTemplate = (n_template)NMWin.ContextDefault.Item("n_template");  // new n_template(xSys);
            CurrentTemplate.AllColumns = new SortedList();
            String[] fields = Tools.Strings.Split(strProps, "|");
            int i = 0;
            foreach (String f in fields)
            {
                CoreVarValAttribute p = cl.VarValGet(f);
                if (p != null)
                {
                    n_column c = (n_column)NMWin.ContextDefault.Item("n_column");  // new n_column(xSys);
                    c.column_order = i;
                    c.column_caption = p.Caption;
                    c.field_name = f;
                    c.column_width = 100 / fields.Length;
                    switch (p.TheFieldType)
                    {
                        case FieldType.DateTime:
                        case FieldType.Boolean:
                            c.column_alignment = 2;
                            break;
                        case FieldType.Int32:
                        case FieldType.Int64:
                        case FieldType.Double:
                            c.column_alignment = 1;
                            break;
                    }
                    CurrentTemplate.AllColumns.Add(c.column_order, c);
                    i++;
                }
            }
            ShowCurrentTemplate();
        }

        public void Enable(bool enable)
        {
            if (enable)
            {
                AllowAdd = true;
                AllowActions = true;
            }
            else
            {
                AllowAdd = false;
                AllowActions = false;
            }
        }
        private void lv_DragDrop(object sender, DragEventArgs e)
        {
            if (DragDrop != null)
                DragDrop(sender, e);
        }
        private void lv_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (ItemDrag != null)
                ItemDrag(sender, e);
        }
        private void lv_DragEnter(object sender, DragEventArgs e)
        {
            if (DragEnter != null)
                DragEnter(sender, e);
        }
        private void lv_DragOver(object sender, DragEventArgs e)
        {
            if (DragOver != null)
                DragOver(sender, e);
        }

        private void cmdCsv_Click(object sender, EventArgs e)
        {
            DoExport("Csv");
        }

        public int BottomBarTop
        {
            get
            {
                return lblStatus.Top;
            }
        }

        bool sca = false;
        public void StyleCurrentApply()
        {
            try
            {
                Font f = Tools.Style.StyleCurrent.TheFont;
                lv.Font = f;
                lblCaption.Font = f;
                chkRefresh.Font = f;
                lblStatus.Font = f;
                chkUnlimited.Font = f;
                cmdAdd.Font = f;

                if (!sca && f.Size >= 13)
                {
                    gbBottom.Height = Convert.ToInt32(gbBottom.Height * 1.5);
                    cmdAdd.Height = Convert.ToInt32(cmdAdd.Height * 1.5);
                }
                sca = true;
                DoResize();
            }
            catch { }
        }

        private void lblStatus_DoubleClick(object sender, EventArgs e)
        {
            if (ToolsWin.Keyboard.GetControlKey())
            {
                DoExpandRight();
                OpenColumnEditor();
                cmdSave.Visible = true;
                cmdColumns.Visible = true;
            }
        }

        private void lv_KeyPress(object sender, KeyPressEventArgs e)
        {
            string test = "";
        }
    }
    public class tColumnHeader : System.Windows.Forms.ColumnHeader
    {
        public Object tag;
        public int WidthPercent;
        public void SetWidth(int total)
        {
            if (WidthPercent > 0)
            {
                this.Width = Convert.ToInt32(total * (this.WidthPercent / (Decimal)100.0));
            }
            else
            {
                this.Width = 20;
            }
        }
    }

    public class ObjectClickArgs
    {
        public bool Handled;
        public bool IsVirtual;
        private nObject xObject;
        public nObjectHandle xHandle;
        public ObjectClickArgs(nObject o)
        {
            xObject = o;
            Handled = false;
            IsVirtual = false;
        }
        public ObjectClickArgs(nObject o, bool v)
        {
            xObject = o;
            Handled = false;
            IsVirtual = v;
        }
        public ObjectClickArgs(nObjectHandle h)
        {
            xHandle = h;
        }
        //Private Functions
        public nObject GetObject()
        {
            if (xObject != null)
            {
                return xObject;
            }
            else if (xHandle != null)
            {
                return xHandle.GetObject(NMWin.ContextDefault);
            }
            else
            {
                return null;
            }
        }
    }
    public class ListViewItemComparer : IComparer
    {
        private int col;
        private SortOrder order;
        public int sort_type;
        public ListViewItemComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }
        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }
        public ListViewItemComparer(int column, SortOrder order, Int32 t)
        {
            col = column;
            this.order = order;
            sort_type = t;
        }
        //Public Functions
        public int Compare(object x, object y)
        {
            int returnVal = -1;
            if (sort_type == (int)FieldType.DateTime)
            {
                try
                {
                    System.DateTime firstDate = DateTime.Parse(((ListViewItem)x).SubItems[col].Text);
                    System.DateTime secondDate = DateTime.Parse(((ListViewItem)y).SubItems[col].Text);
                    // Compare the two dates.
                    returnVal = DateTime.Compare(firstDate, secondDate);
                }
                catch (Exception e)
                {
                    try
                    {
                        returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                    }
                    catch (Exception)
                    {
                        returnVal = 0;
                    }
                }
            }
            else if (sort_type == (int)FieldType.Double)
            {
                try
                {
                    System.Double firstDouble = Double.Parse(((ListViewItem)x).SubItems[col].Text.Replace(" KB", "").Replace(" MB", "").Replace(NMWin.ContextDefault.TheSys.CurrencySymbol, ""));
                    System.Double secondDouble = Double.Parse(((ListViewItem)y).SubItems[col].Text.Replace(" KB", "").Replace(" MB", "").Replace(NMWin.ContextDefault.TheSys.CurrencySymbol, ""));
                    if (firstDouble == secondDouble)
                        returnVal = 0;
                    else if (firstDouble < secondDouble)
                        returnVal = -1;
                    else if (firstDouble > secondDouble)
                        returnVal = 1;
                }
                catch (Exception e)
                {
                    try
                    {
                        returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }
            else if (sort_type == (int)FieldType.Int64)
            {
                try
                {
                    System.Int64 firstInt64 = Int64.Parse(((ListViewItem)x).SubItems[col].Text.Replace(",", ""));
                    System.Int64 secondInt64 = Int64.Parse(((ListViewItem)y).SubItems[col].Text.Replace(",", ""));
                    if (firstInt64 == secondInt64)
                        returnVal = 0;
                    else if (firstInt64 < secondInt64)
                        returnVal = -1;
                    else if (firstInt64 > secondInt64)
                        returnVal = 1;
                }
                catch (Exception e)
                {
                    try
                    {
                        returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                    }
                    catch
                    {
                        return -1;
                    }
                }
            }
            else if (sort_type == (int)FieldType.Int32)
            {
                try
                {
                    System.Int32 firstInt32 = Int32.Parse(((ListViewItem)x).SubItems[col].Text.Replace(",", ""));
                    System.Int32 secondInt32 = Int32.Parse(((ListViewItem)y).SubItems[col].Text.Replace(",", ""));
                    if (firstInt32 == secondInt32)
                        returnVal = 0;
                    else if (firstInt32 < secondInt32)
                        returnVal = -1;
                    else if (firstInt32 > secondInt32)
                        returnVal = 1;
                }
                catch (Exception e)
                {
                    try
                    {
                        returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }
            else
            {
                try
                {
                    returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            // Determine whether the sort order is descending.
            if (order == SortOrder.Descending)
                // Invert the value returned by String.Compare.
                returnVal *= -1;
            return returnVal;
        }
    }


    public class IconRequestArgs
    {
        public int icon = 0;
        public DataRow row;
        public IconRequestArgs(DataRow r)
        {
            row = r;
        }
    }

    public delegate void HandleChangeNotification(Context x, ChangeArgs args);
    //public delegate void ShowHandler(Object sender, ShowArgs args);
    public delegate void AddHandler(Object sender, AddArgs args);
    public delegate void ObjectClickHandler(Object sender, ObjectClickArgs args);
    public delegate void FillHandler(Object sender);
    //public delegate void FillHandlerTable(Object sender, DataTable t);
    public delegate void IconRequest(IconRequestArgs args);
    public delegate void ObjectsDeletedHandler(ArrayList objects);
    public delegate void PrismQuoteSendHandler(String id);
    public delegate void nListItemDragHandler(object sender, ItemDragEventArgs e);
    public delegate void nListItemDragDropHandler(object sender, DragEventArgs e);
    public delegate void ItemStyleHandler(ListViewItem i, DataRow r);
    public delegate nObject SelectedObjectGetHandler(ref bool cancel);

    public interface InList
    {
        n_template CurrentTemplate { get; set; }
        void ShowCurrentTemplate();
        void ReDoSearch(bool x);
        void Clear();
    }

    public delegate void ActionHandler(Object sender, ActArgs args);
}