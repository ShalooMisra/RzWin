using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Tools;
using ToolsWin;

using Core;

namespace CoreWin
{
    [ToolboxItem(false)]
    public partial class TabStripCore : UserControl
    {
        Context TheContext;
        
        //events
        public event TabStripCoreEventHandler TabAdded;
        public void FireTabAdded(TabPageCore t)
        {
            if (TabAdded != null)
                TabAdded(t);
        }

        public event TabStripCoreEventHandler TabRemoved;
        public void FireTabRemoved(TabPageCore t)
        {
            if (TabRemoved != null)
                TabRemoved(t);
        }

        public event TabStripCoreEventHandler TabChanged;
        public void FireTabChanged(TabPageCore t)
        {
            if (TabChanged != null)
                TabChanged(t);
        }
        //vars
        private TabPageCore CurrentTabItem;
        private Stack<TabPageCore> TabsInOrder;
        private bool InhibitTabClick = false;

        public TabStripCore()
        {
            InitializeComponent();
        }

        public virtual void Init(Context x)
        {
            TheContext = x;
            TabsInOrder = new Stack<TabPageCore>();
        }

        public virtual void InitUn()
        {
            ExternalFormsInitUn();
        }

        private void TabStripCore_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            try
            {
                cmdCloseTab.Left = this.ClientRectangle.Width - Convert.ToInt32((Convert.ToDouble(cmdCloseTab.Width) * 2.5));
                cmdCloseTab.Top = ts.Top;
                cmdCloseTab.BringToFront();

                ts.Left = 0;
                ts.Top = 0;
                ts.Width = this.ClientRectangle.Width;
                ts.Height = this.ClientRectangle.Height;
            }
            catch { }
        }

        private void cmdCloseTab_Click(object sender, EventArgs e)
        {
            TabTopClose();
        }

        public virtual void TabTopClose()
        {
            TabTopClose(false);
        }

        public virtual void TabTopClose(bool leaveinmemory)
        {
            try
            {
                TabPageCore t = (TabPageCore)ts.SelectedTab;
                try
                {
                    if(t.Locked)
                    {
                        AdjustTabStack();
                        return;
                    }
                }
                catch
                {
                }
                TabRemove(t, leaveinmemory);
            }
            catch (Exception ex)
            {
                TheContext.TheLeader.Tell("There was an error closing the tab: " + ex.Message);
            }

            try
            {
                System.GC.Collect();
            }
            catch
            {
            }
        }

        //public virtual void RemoveTabFromLists(TabPageCore t)
        //{
        //    Stack<TabPageCore> TabsInOrder_New = new Stack<TabPageCore>();
        //    List<TabPageCore> current = new List<TabPageCore>(TabsInOrder);
        //    current.Reverse();

        //    foreach (TabPageCore p in current)
        //    {
        //        if (Object.ReferenceEquals(p, t))
        //        {

        //        }
        //        else
        //        {
        //            TabsInOrder_New.Push(p);
        //        }
        //    }
        //    TabsInOrder = TabsInOrder_New;
        //}

        private void AdjustTabStack()
        {
            try
            {
                if (TabsInOrder.Count <= 0)
                    return;
                if (ts.TabPages.Count <= 1)
                {
                    TabsInOrder = new Stack<TabPageCore>();
                    return;
                }
                TabsInOrder = FilterLockedTabs();
                TabPageCore h = TabsInOrder.Peek();
                if (h == null)
                    return;
                Stack<TabPageCore> st = new Stack<TabPageCore>();
                if (h.Locked)
                {
                    h = TabsInOrder.Pop();
                    TabPageCore th = TabsInOrder.Peek();
                    if (th.IsValid)
                    {
                        TabsInOrder.Push(th);
                        InhibitTabClick = true;
                        ts.SelectedTab = th;
                        InhibitTabClick = false;
                        st = new Stack<TabPageCore>();
                        Boolean foundtab = false;
                        foreach (TabPageCore o in TabsInOrder)
                        {
                            if (o.Equals(h) && !foundtab)
                            {
                                st.Push(o);
                                foundtab = true;
                            }
                            else
                            {
                                st.Push(o);
                            }
                        }
                        if (st.Count > 0)
                        {
                            if (!foundtab)
                                st.Push(h);
                            TabsInOrder = new Stack<TabPageCore>();
                            foreach (TabPageCore o in st)
                            {
                                TabsInOrder.Push(o);
                            }
                        }
                        h = TabsInOrder.Peek();
                        if (h.IsValid)
                        {
                            InhibitTabClick = true;
                            ts.SelectedTab = h;
                            InhibitTabClick = false;
                        }
                        return;
                    }
                }
                else
                {
                    h = TabsInOrder.Pop();
                    st = new Stack<TabPageCore>();
                    foreach (TabPageCore o in TabsInOrder)
                    {
                        if (o.Equals(h))
                            continue;
                        st.Push(o);
                    }
                    TabsInOrder = new Stack<TabPageCore>();
                    foreach (TabPageCore o in st)
                    {
                        TabsInOrder.Push(o);
                    }
                    h = TabsInOrder.Peek();
                    if (h.IsValid)
                    {
                        InhibitTabClick = true;
                        ts.SelectedTab = h;
                        InhibitTabClick = false;
                    }
                }
            }
            catch (Exception)
            {
                ts.SelectedIndex = 0;
            }
        }


        private Stack<TabPageCore> FilterLockedTabs()
        {
            try
            {
                if (TabsInOrder.Count <= 0)
                    return TabsInOrder;
                Stack<TabPageCore> locked = new Stack<TabPageCore>();
                Stack<TabPageCore> st = new Stack<TabPageCore>();
                foreach (TabPageCore o in TabsInOrder)
                {
                    if (o.Locked)
                        locked.Push(o);
                }
                if (locked.Count <= 0)
                    return TabsInOrder;
                st = TabsInOrder;
                foreach (TabPageCore o in locked)
                {
                    st = FilterLockedTab(o, st);
                }
                return st;
            }
            catch (Exception)
            {
                return new Stack<TabPageCore>();
            }
        }
        private Stack<TabPageCore> FilterLockedTab(TabPageCore th, Stack<TabPageCore> st)
        {
            try
            {
                if (st == null)
                    return new Stack<TabPageCore>();
                if (th == null)
                    return st;
                Stack<TabPageCore> build = new Stack<TabPageCore>();
                Boolean bFound = false;
                foreach (TabPageCore o in st)
                {
                    if (o.Equals(th))
                    {
                        if (!bFound)
                        {
                            bFound = true;
                            build.Push(o);
                        }
                    }
                    else
                    {
                        build.Push(o);
                    }
                }
                st = new Stack<TabPageCore>();
                foreach (TabPageCore o in build)
                {
                    st.Push(o);
                }
                return st;
            }
            catch (Exception)
            {
                return new Stack<TabPageCore>();
            }
        }
        private void RemoveTabFromStack(TabPageCore t)
        {
            try
            {
                ArrayList a = new ArrayList();
                foreach (TabPageCore o in TabsInOrder)
                {
                    if (o.TheControl != null)
                    {
                        //if (ho.control != h.control)
                        //{
                            if (o.IsValid)
                                a.Add(o);
                        //}
                    }
                }
                TabsInOrder.Clear();
                TabsInOrder = new Stack<TabPageCore>();
                for (int i = a.Count - 1; i >= 0; i--)
                {
                    TabsInOrder.Push((TabPageCore)a[i]);
                }
            }
            catch
            {
            }
        }

        public void LockUnLockTab()
        {
            if (CurrentTabItem == null)
                LockUnLockTab((TabPageCore)ts.SelectedTab);
            else
                LockUnLockTab(CurrentTabItem);
        }

        public void LockUnLockTab(TabPageCore t)
        {
            try
            {
                if (t == null)
                    return;

                if (t.Locked)
                {
                    t.UnLock();
                }
                else
                {
                    t.Lock();
                }
            }
            catch
            {
            }
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            if (CurrentTabItem != null)
            {
                //if (CurrentTabItem == tp)
                //{
                //    if (!context.TheLeader.AskYesNo("You are about to close the main start page. This page cannot be reloaded until you restart Rz3.\r\nAre you sure you want to close this tab?"))
                //        return;
                //}
                try
                {
                    try
                    {
                        if (CurrentTabItem.Locked)
                        {
                            TheContext.TheLeader.Tell("This tab has been locked. Please unlock this tab before trying to close it.");
                            return;
                        }
                    }
                    catch
                    {
                    }
                    TabClose(CurrentTabItem);
                }
                catch
                {
                }
            }
        }

        private void mnuCloseAllButThis_Click(object sender, EventArgs e)
        {
            if (CurrentTabItem == null)
                return;

            CloseAll(CurrentTabItem);
        }

        public void CloseAll()
        {
            CloseAll(null);
        }

        protected void CloseAll(TabPage except)
        {
            ArrayList a = new ArrayList();
            foreach (TabPage p in ts.TabPages)
            {
                if (p != except)
                    a.Add(p);
            }
            if (a.Count == 0)
                return;
            if (!TheContext.TheLeader.AreYouSure("close " + Tools.Strings.PluralizePhrase("tab", a.Count)))
                return;
            foreach (TabPageCore p in a)
            {
                try
                {
                    if (p.Locked)
                        continue;
                }
                catch { }
                ts.TabPages.Remove(p);
            }
        }

        private void mnuLockUnlock_Click(object sender, EventArgs e)
        {
            LockUnLockTab();
        }

        private void mnuSaveAsPicture_Click(object sender, EventArgs e)
        {
            TabPageCore t = GetSelectedTab();
            if (t == null)
                return;

            //let the menu get out of the way
            for (int ix = 0; ix < 100; ix++)
            {
                System.Windows.Forms.Application.DoEvents();
            }


            Image i = Win32API.GetControlShot(t.TheControl);
            if (i == null)
                return;
            try
            {
                String s = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "temp_screen_shot.bmp";
                if (System.IO.File.Exists(s))
                    System.IO.File.Delete(s);
                i.Save(s, System.Drawing.Imaging.ImageFormat.Bmp);
                Tools.FileSystem.Shell(s);
            }
            catch
            {
            }
        }

        private void mnuTab_Opening(object sender, CancelEventArgs e)
        {
            if (CurrentTabItem == null)
            {
                e.Cancel = true;
                return;
            }
            mnuClose.Text = "Close '" + CurrentTabItem.Text + "'";
            mnuCloseAllButThis.Text = "Close All Except '" + CurrentTabItem.Text + "'";
        }

        public void TabCloseByID(String strID)
        {
            TabPageCore t = TabGetByID(strID);
            if (t == null)
                return;
            TabRemove(t);
        }

        public TabPageCore TabGetByID(String strID)
        {
            foreach (TabPageCore t in ts.TabPages)
            {
                if (Tools.Strings.StrCmp(t.TabID, strID))
                {
                    if (t.IsValid)
                        return t;
                }
            }
  
            return null;
        }

        public TabPageCore GetSelectedTab()
        {
            try
            {
                return (TabPageCore)ts.SelectedTab;
            }
            catch
            {
                return null;
            }
        }

        public void TabSelectedSet(TabPageCore p)
        {
            try
            {
                ts.SelectedTab = p;
            }
            catch { }
        }

        public ArrayList GetOpenTabCaptions()
        {
            ArrayList a = new ArrayList();
            foreach (TabPageCore t in ts.TabPages)
            {
                a.Add(t.OriginalCaption);
            }
            return a;
        }
        public String TabCurrentCaptionGet()
        {
            try
            {
                return ((TabPageCore)ts.SelectedTab).OriginalCaption;
            }
            catch
            {
                return "";
            }
        }
        public Control TabCheckShow(String strID)
        {
            try
            {
                TabPageCore t = TabGetByID(strID);
                if (t == null)
                    return null;
                if (!t.IsValid)
                    return null;
                ts.SelectedTab = t;
                return t.TheControl;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void TabAdd(TabPageCore t)
        {
            try
            {
                t.ImageKey = "";
                ts.TabPages.Add(t);
                TabsInOrder.Push(t);
                CheckTabButton();
                CheckTabCaptionLengths();
                FireTabAdded(t);
            }
            catch (Exception ex)
            {
                TheContext.TheLeader.Tell("There was an error adding this tab (add, tab): " + ex.Message + "\r\n\r\n" + ex.StackTrace.ToString());
            }
        }

        public event TabStripCoreEventHandlerArgs TabCloseAboutTo;
        public void TabClose(TabPageCore t)
        {
            if (TabCloseAboutTo != null)
            {
                TabStripCoreEventArgs args = new TabStripCoreEventArgs(t);
                TabCloseAboutTo(args);
                if (args.Handled)
                    return;
            }

            TabRemove(t);
        }

        public void TabRemove(TabPageCore t)
        {
            TabRemove(t, false);
        }

        public void TabRemove(TabPageCore t, bool leaveinmemory)
        {
            if (InvokeRequired)
                Invoke(new TabRemoveHandler(TabRemoveActually), new object[] { t, leaveinmemory });
            else
                TabRemoveActually(t, leaveinmemory);
        }

        delegate void TabRemoveHandler(TabPageCore t, bool leaveinmemory);
        void TabRemoveActually(TabPageCore t, bool leaveinmemory)
        {
            if (t == null)
                return;

            InhibitTabClick = true;
            ts.TabPages.Remove(t);

            t.CloseRequest -= new CloseHandler(v_CloseRequest);
            t.ShowExternal -= new ShowExternalHandler(v_ShowExternal);

            InhibitTabClick = false;

            CheckTabButton();
            CheckTabCaptionLengths();
            AdjustTabStack();
            FireTabRemoved(t);

            if (leaveinmemory)
            {
                t.ReleaseControl();
            }

            //RemoveTabFromLists(t);  //adjusttabstack already does this
            t.Dispose();
            t = null;
        }

        void CheckTabButton()
        {
            try
            {
                cmdCloseTab.Enabled = TabCount > 0;
            }
            catch { }
        }

        public int TabCount
        {
            get
            {
                return ts.TabPages.Count;
            }
        }

        //Needed To Make Private To Prevent External Calls
        private TabPageCore TabShow(Control r)
        {
            return TabShow(r, "");
        }

        public TabPageCore TabShow(Control control, String caption, String id, bool locked)
        {
            try
            {
                if (ts.TabPages.Count >= 30)
                {
                    TheContext.TheLeader.Tell("You have too many tabs opened already. Close some tabs and try again.");
                    return null;
                }
                TabPageCore v = new TabPageCore();
                v.TabID = id;
                v.BackColor = Color.White;
                v.MyTabControl = ts;
                v.Text = caption;
                v.OriginalCaption = caption;

                v.CloseRequest += new CloseHandler(v_CloseRequest);
                v.ShowExternal += new ShowExternalHandler(v_ShowExternal);

                v.SetControl(control);
                TabAdd(v);

                if (Object.ReferenceEquals(control.ContextMenuStrip, this.mnuTab))
                    control.ContextMenuStrip = null;
                ts.SelectedTab = v;

                v.DoResize();

                if (locked)
                    v.Lock();
                return v;
            }
            catch (Exception ex)
            {
                TheContext.TheLeader.Tell("There was an error showing this information (wcaption, tab): " + ex.Message + "\r\n\r\n" + ex.StackTrace.ToString());
                return null;
            }
        }

        private TabPageCore TabShowById(Control r, String id)
        {
            return TabShow(r, "", id);

        }

        //Needed To Make Private To Prevent External Calls
        public TabPageCore TabShow(Control control, String caption)
        {
            return TabShow(control, caption, false);
        }
        public TabPageCore TabShow(Control control, String caption, bool locked)
        {
            String id = caption.ToLower().Replace(" ", "");
            if (!Tools.Strings.StrExt(id))
                id = Tools.Strings.GetNewID();

            return TabShow(control, caption, id, locked);
        }

        public TabPageCore TabShow(Control control, String caption, String id)
        {
            return TabShow(control, caption, id, false);
        }

        public void TabsClearAll()
        {
            ArrayList a = new ArrayList(ts.TabPages);
            foreach (TabPageCore p in a)
            {
                TabRemove(p);
            }
            a.Clear();
            a = null;
        }

        private void ts_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int HoverTab = TestTab(new Point(e.X, e.Y));
            if (HoverTab >= 0)
                CurrentTabItem = (TabPageCore)ts.TabPages[HoverTab];

            if (ts.ContextMenuStrip == null)
                ts.ContextMenuStrip = mnuTab;
        }

        private int TestTab(Point pt)
        {
            int returnIndex = -1;
            for (int index = 0; index <= ts.TabCount - 1; index++)
            {
                if (ts.GetTabRect(index).Contains(pt.X, pt.Y))
                    returnIndex = index;
            }
            return returnIndex;
        }


        private void ts_MouseLeave(object sender, System.EventArgs e)
        {
            ts.ContextMenu = null;
        }

        private void CheckTabCaptionLengths()
        {
            try
            {

                StringBuilder sb = new StringBuilder();
                foreach (TabPageCore t in ts.TabPages)
                {
                    sb.Append("   " + t.OriginalCaption);
                }

                Graphics g = Graphics.FromHwnd(ts.Handle);
                if (g == null)
                    return;

                int len = Convert.ToInt32(g.MeasureString(sb.ToString(), ts.Font).Width);

                g.Dispose();
                g = null;

                if (len > ts.Width)
                {
                    foreach (TabPageCore t in ts.TabPages)
                    {
                        if (t.OriginalCaption.Length > 6)
                            t.Text = Tools.Strings.Left(t.OriginalCaption, 6) + "...";
                    }
                }
                else
                {
                    //restore it
                    foreach (TabPageCore t in ts.TabPages)
                    {
                        if (Tools.Strings.StrExt(t.OriginalCaption))
                            t.Text = t.OriginalCaption;
                    }
                }
            }
            catch { }
        }

        private void v_CloseRequest(object sender, CloseArgs args)
        {
            TabPageCore tp = (TabPageCore)sender;
            if( TheContext != null )
                TheContext.TheLeader.CommentEllipse("Closing " + tp.Text);
            int i = ts.SelectedIndex;
            TabRemove(tp);
            args.Handled = true;
        }

        //public event ExternalFormHandler ExternalFormShown;
        List<FormExternal> ExternalForms = new List<FormExternal>();
        private void v_ShowExternal(object sender)
        {
            TabPageCore n = (TabPageCore)sender;
            String s = n.Text;
            ts.SelectedTab = n;
            Control c = n.TheControl;
            n.Controls.Remove(n.TheControl);
            n.TheControl = null;
            TabTopClose(true);
            if (c == null)
                return;
            FormExternal xForm = new FormExternal();
            xForm.TabID = n.TabID;
            xForm.ShowInTab += new FormExternal.ShowInTabHandler(xForm_ShowInTab);
            xForm.SetControl(c);
            xForm.Text = s;
            xForm.Icon = this.ParentForm.Icon;
            xForm.Show();

            ExternalForms.Add(xForm);
        }


        void ExternalFormsInitUn()
        {
            foreach (FormExternal f in ExternalForms)
            {
                try
                {
                    f.ShowInTab -= new FormExternal.ShowInTabHandler(xForm_ShowInTab);
                    f.Close();
                    f.Dispose();
                }
                catch { }
            }
            ExternalForms.Clear();
        }

        private void xForm_ShowInTab(Control u, String caption, String strID)
        {
            TabPageCore t = TabShow(u, caption, strID);
        }

        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InhibitTabClick)
                return;
            
            TabPageCore h = GetSelectedTab();
            if (h != null)
            {
                if( TabsInOrder.Count == 0 || TabsInOrder.Peek() != h )
                    TabsInOrder.Push(h);
                FireTabChanged(h);
            }
            
        }

        bool m_AllowPictures = false;
        public bool AllowTabPictures
        {
            get
            {
                return m_AllowPictures;
            }

            set
            {
                m_AllowPictures = value;
                mnuSaveAsPicture.Visible = m_AllowPictures;
            }


        }

        public String GetTabStackHTML()
        {
            StringBuilder sb = new StringBuilder();
            int i = 1;
            sb.Append("<table border=\"0\">");
            foreach (TabPageCore p in TabsInOrder)
            {
                sb.AppendLine("<tr><td>" + i.ToString() + "</td><td>" + p.OriginalCaption + "</tr>");
                i++;
            }
            sb.Append("</table>");
            return sb.ToString();
        }

        public List<TabPageCore> TabsList
        {
            get
            {
                List<TabPageCore> ret = new List<TabPageCore>();
                foreach (TabPageCore tab in ts.TabPages)
                {
                    ret.Add(tab);
                }
                return ret;
            }
        }
    }

    public delegate void TabStripCoreEventHandler(TabPageCore t);
    public delegate void TabStripCoreEventHandlerArgs(TabStripCoreEventArgs t);
    //public delegate void ExternalFormHandler(Form ExternalForm);

    public class TabStripCoreEventArgs
    {
        public TabPageCore ThePage;
        public bool Handled = false;

        public TabStripCoreEventArgs(TabPageCore t)
        {
            ThePage = t;
        }
    }
}
