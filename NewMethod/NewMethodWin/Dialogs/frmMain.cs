using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tools;
using ToolsWin;
using Core;
using Core.Display;
using CoreWin;
using Tools.Database;

namespace NewMethod
{
    public partial class frmMain : MainForm
    {
        public ContextNM TheContextNM
        {
            get
            {
                return NMWin.ContextDefault;
            }
        }

        public SysNewMethod xSys
        {
            get
            {
                return TheContextNM.xSys;
            }
        }

        public frmMain()
        {
            InitializeComponent();
            //nStatus.RegisterStatusView(this);
        }

        public override void Init(Context x)
        {
            base.Init(x);
            x.TheLeader.Comment("Loading main form...");

            try
            {
                ts.AllowTabPictures = TheContextNM.xUser.SuperUser;
                TabsInitialSet();
                SysNewMethod.version_string = Tools.Misc.GetVersionString(ToolsNM.AssemblyNM);  //for recall
                Text = xSys.Name + " " + SysNewMethod.version_string;
                if (TheContextNM.xUser != null)
                    Text += " [" + TheContextNM.xUser.name + "]";
                SetActive();
                UserApply();
                DoResize();
                SetActivityType(ActivityType.None);
            }
            catch (Exception ex)
            {
                x.TheLeader.Comment("Form load error: " + ex.Message);
            }
            x.TheLeader.Comment("Ready.");
        }

        //public override void LoadToolBar()
        //{
        //    base.LoadToolBar();
        //    if (xSys.xUser.IsDeveloper())
        //    {
        //        //Data Workbench
        //        ToolStripButton b = AddToolBarButton("Wrkbnch", il24.Images["Tools"]);
        //        b.Click += new EventHandler(b_Click);
        //        //SQL Query
        //        b = AddToolBarButton("SQL", il24.Images["SQL"]);
        //        b.Click += new EventHandler(sql_Click);
        //        //Data Table
        //        b = AddToolBarButton("Tblz", il24.Images["Table"]);
        //        b.Click += new EventHandler(table_Click);
        //        //Data Targets
        //        b = AddToolBarButton("Trgtz", il24.Images["Target"]);
        //        b.Click += new EventHandler(targets_Click);
        //        //Import Workbench
        //        b = AddToolBarButton("Import", il24.Images["Import"]);
        //        b.Click += new EventHandler(import_Click);

        //        //mnuAllSettings.Visible = true;
        //    }
        //    else
        //    {
        //        //mnuAllSettings.Visible = false;
        //    }
        //}

        protected override Image ToolBarImageGet(string s)
        {
            try
            {
                return il24.Images[s];
            }
            catch
            {
                return null;
            }
        }

        public override void CompleteClose()
        {
            if (ConfirmClose)
            {
                if (!NMWin.Leader.AreYouSure("close " + NMWin.ContextDefault.ProgramCaption))
                    return;
            }

            base.CompleteClose();
        }

        //private nView GetObjectView(String strClass, String strExtra, bool ShowDefault)
        //{
        //    nView vi = null;
        //    if (!ShowDefault)
        //    {
        //        vi = (nView)SysNewMethod.ContextDefault.TheLeader.ViewCreate(SysNewMethod.ContextDefault, new ShowArgs(strClass));
        //    }
        //    if (vi == null)
        //    {
        //        return null;
        //        //nView_nObject viewer = new nView_nObject();
        //        //vi = (nView)viewer;
        //    }
        //    //vi.AboutToThrow += new ShowHandler(ShowHandler);
        //    return vi;
        //}

        public void ShowObjectChanges(nObject xObject)
        {
            nChanges c = new nChanges();
            c.CompleteLoad(xObject);
            ts.TabShow(c, xObject.ToString(), "changes for " + xObject.unique_id);
        }

        //public virtual void Show(ShowArgs args)
        public override void Show(ShowArgs args)
        {
            try
            {
                nObject x = (nObject)args.TheItems.FirstGet(NMWin.ContextDefault);

                if (x != null)
                {
                    if (args.ShowChanges)
                    {
                        ShowObjectChanges(x);
                        return;
                    }
                    switch (x.ClassId.ToLower())
                    {
                        default:
                            if (args.ShowModal)
                                ShowObjectModally(x, args.ExtraData);
                            else
                                try
                                {
                                    if (x == null)
                                        return;
                                    //KT After making the below new method (!x.CanBeViewedBy(NMWin.ContextDefault, args, TheContextNM.xUser.unique_id))
                                    //to allow users to view orders owned by others that match their Xrefs, I also inadvertently allowed all users to view all companies.
                                    //So, now checking for "Company", if it's company, use the original method:  (!x.CanBeViewedBy(NMWin.ContextDefault, args))
                                    if(x.ClassId == "company")
                                    {
                                        if (!x.CanBeViewedBy(NMWin.ContextDefault, args))
                                        {
                                            NMWin.Leader.Tell("This user account doesn't have permission to access this information.");
                                            return;
                                        }
                                        
                                    }
                                    if (x.ClassId == "companycontact")
                                    {
                                        if (!x.CanBeViewedBy(NMWin.ContextDefault, args))
                                        {
                                            NMWin.Leader.Tell("This user account doesn't have permission to access this information.");
                                            return;
                                        }

                                    }
                                    //KT Switching this to use my new method to also check CompanyOwnerUID
                                    //if (!x.CanBeViewedBy(NMWin.ContextDefault, args))
                                    else if (!x.CanBeViewedBy(NMWin.ContextDefault, args, TheContextNM.xUser.unique_id))
                                    {
                                        NMWin.Leader.Tell("This user account doesn't have permission to access this information.");
                                        return;
                                    }
                                    //make sure it is not already there
                                    Control c = ts.TabCheckShow(x.unique_id);
                                    if (c != null)
                                    {
                                        if (args.ForceReshow)
                                        {
                                            TabPageCore t = ts.TabGetByID(x.unique_id);
                                            if (t != null)
                                                ts.TabRemove(t);
                                        }
                                        else
                                        {
                                            try
                                            {
                                                args.ViewUsed = (nView)c;
                                                return;
                                            }
                                            catch (Exception)
                                            {
                                                args.ViewUsed = null;
                                                return;
                                            }
                                        }
                                    }
                                    nView vi = (nView)NMWin.Leader.ViewCreate(NMWin.ContextDefault, args);  //GetObjectView(x.ClassName, x.GetExtraClassInfo(), false);
                                    if (vi == null)
                                    {
                                        args.ViewUsed = null;
                                        return;
                                    }

                                    vi.Init(x);
                                    vi.CompleteLoad();

                                    //moved this to after init and completeload 2011_06_29
                                    if (args.DisableEdit || (!SuppressPassiveDisable && !x.CanBeEditedBy(NMWin.ContextDefault, args)))
                                        vi.DisableControls();

                                    TabPageCore tab = ts.TabShow(vi, x.ToString(), x.unique_id);  //.ToString()
                                    if (tab == null)
                                        break;
                                    tab.TheItem = x;
                                    tab.TheView = vi;
                                    //NMWin.ContextDefault.xSys.AfterThrow(x);
                                    args.ViewUsed = vi;
                                }
                                catch (Exception ex)
                                {
                                    NMWin.Leader.Tell("There was an error showing this information(main, show): " + ex.Message + "\r\n\r\n" + ex.StackTrace.ToString());
                                    return;
                                }
                            break;
                    }
                    args.Handled = true;
                }
                //else if (args.xHandle != null && args.AsyncMode)
                //{
                //    //ShowObjectAsync(args.xHandle, args.ShowDefault, args.ShowPassive);
                //    args.ViewUsed = ShowObject(args);
                //    args.Handled = true;
                //}

                //if (args.xList != null)
                //{
                //    nList l = new nList();
                //    ShowList(l);
                //    l.ShowTemplate("some_" + args.xList.strClass, args.xList.strClass);
                //    l.ShowData(args.xList.strClass, args.xList.strWhere, args.xList.strOrder);
                //}
            }
            catch (Exception ex)
            {
                NMWin.Leader.Tell("There was an error showing this information (handler, main): " + ex.Message + "\r\n\r\n" + ex.StackTrace.ToString());
            }
        }

        private void ShowList(nList xList)
        {
            //xList.AboutToThrow += new ShowHandler(ShowHandler);
            TabShow(xList, "List");
        }

        public void ShowList(ListArgs args)
        {
            nList l = new nList();
            TabShow(l, args.TheCaption);
            l.Init(args);
        }

        public void ShowObjectModally(nObject xObject)
        {
            ShowObjectModally(xObject, "");
        }
        public void ShowObjectModally(nObject xObject, String strExtra)
        {
            nView v = (nView)NMWin.Leader.ViewCreate(NMWin.ContextDefault, new ShowArgs(NMWin.ContextDefault, xObject));
            if (v == null)
                return;
            v.Init(xObject);
            v.CompleteLoad();
            if (Tools.Strings.StrExt(strExtra))
                v.SetCustomState(strExtra);
            FormExternal xForm = new FormExternal();
            xForm.SetViewControl(v);
            xForm.Text = xObject.ToString();
            xForm.Icon = this.Icon;
            xForm.ShowDialog(this);
        }

        public TabPageCore ShowGenericTabControl_CompleteLoad(ICompleteLoad control, String caption)
        {
            TabPageCore t = ts.TabShow((UserControl)control, caption);
            control.CompleteLoad();
            return t;
        }

        void b_Click(object sender, EventArgs e)
        {
            nDataWorkBench b = new nDataWorkBench();
            ShowGenericTabControl_CompleteLoad(b, "Data WorkBench");
        }
        //void sql_Click(object sender, EventArgs e)
        //{
        //    nQuery b = new nQuery();
        //    b.CompleteLoad();
        //    ts.TabShow(b, "SQL Query");
        //}
        void table_Click(object sender, EventArgs e)
        {
            nDataView v = new nDataView();
            v.CompleteLoad();
            v.SetNoClass();
            ts.TabShow(v, "Data Table");
        }
        void targets_Click(object sender, EventArgs e)
        {
            DataTargetManager m = new DataTargetManager();
            ts.TabShow(m, "Data Targets");
            m.CompleteLoad();
        }
        //void import_Click(object sender, EventArgs e)
        //{
        //    nImportBench b = new nImportBench();
        //    ts.TabShow(b, "Import Workbench");
        //    b.CompleteLoad();
        //}

        public nQuery ShowQuery(String strSQL)
        {
            return ShowQuery(strSQL, NMWin.Data);
        }
        public nQuery ShowQuery(String strSQL, DataConnection xd)
        {
            nQuery q = new nQuery();
            ShowGenericTabControl_CompleteLoad(q, "SQL Query");
            q.SetSQL(strSQL);
            q.xConnect = xd;
            return q;
        }

        private void mnuViewAllSettings_Click(object sender, EventArgs e)
        {
            nList l = new nList();
            TabShow(l, "System Settings");
            l.ShowTemplate("all_settings", "n_set");
            l.ShowData("n_set", "isnull(setting_key, '') = ''", "name");
        }

        public void SetStatusByIndex(Object sender, StatusArgs args)
        {
            SetStatus(args.status);
        }
        public void SetStatus(String s)
        {
            if (InvokeRequired)
            {
                SetStatusDelegate d = new SetStatusDelegate(ActuallySetStatus);
                Invoke(d, new object[] { s });
            }
            else
                ActuallySetStatus(s);
        }
        public void ActuallySetStatus(String s)
        {
            lblStatus.Text = s;
            sb.Refresh();
        }
        public void SetProgressByIndex(Object sender, ProgressArgs args)
        {
        }
        public void SetActivityByIndex(Object sender, ActivityArgs args)
        {
        }
        public void AddLine()
        {
        }
        public void RemoveLine()
        {
        }

        public DateTime LastActivity = DateTime.Now;
        public ActivityType CurrentActivityType = ActivityType.None;
        public bool InhibitActivity = false;

        public void SetActive()
        {
            if (InhibitActivity)
                return;
            LastActivity = System.DateTime.Now;
        }

        public virtual void SetActivityType(ActivityType t)
        {
            try
            {
                CurrentActivityType = t;
            }
            catch (Exception)
            {
            }
        }

    }

    //delegates
    public delegate void RunUpdateDelegate(bool request);
}
