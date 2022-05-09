using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using Tools;
using ToolsWin;
using Core;
using CoreWin.Views;

namespace CoreWin
{
    public partial class MainForm : Form
    {
        public bool SuppressOpenWarnings = false;
        public bool SuppressPassiveDisable = false;
        public MainForm()
        {
            try
            {
                InitializeComponent();
            }
            catch
            {
                //context.TheLeader.Comment("Init error: " + ex.Message);
            }
        }

        public Context TheContext;

        public virtual void Init(Context x)
        {
            TheContext = x;
            CaptionInit();
            ts.Init(TheContext);
            DoResize();
            this.WindowState = FormWindowState.Maximized;
        }

        protected virtual void CaptionInit()
        {
            this.Text = TheContext.TheSys.CaptionGet(TheContext);
        }

        public virtual void LoadUserTabs()
        {

        }

        //public virtual void LoadToolBar()
        //{
        //    cmdBack.Image = GetBackButtonImage();
        //    tools.BackColor = Color.White;
        //}
        public virtual Image GetBackButtonImage()
        {
            try
            {
                return il24.Images["Back"];                
            }
            catch
            {
                return null;
            }
        }
        public virtual Image GetExitButtonImage()
        {
            try
            {
                return il24.Images["Exit"];                
            }
            catch
            {
                return null;
            }
        }
        public virtual void AddExitButton()
        {
            ToolStripButton b = AddToolBarButton("Exit", GetExitButtonImage());
            b.Click += new EventHandler(cmdExit_Click);
        }
        void cmdExit_Click(object sender, EventArgs e)
        {
            CompleteClose();
        }

        public virtual void InitUn()
        {
            ts.InitUn();
        }

        public virtual void CompleteClose()
        {

            InitUn();

            try
            {
                this.Close();
            }
            catch
            {
            }
            try
            {
                this.Dispose();
            }
            catch
            {
            }
        }

        public virtual void UserApply()
        {
            MenuLoad();
            AddExitButton();
        }
        protected virtual void MenuLoad()
        {
            //Clears the main Button Menu (people, parts, orders, etc).
            MenuClear();
            //Set better image for back button.
            cmdBack.Image = GetBackButtonImage();
            //Form Background Color
            tools.BackColor = Color.White;

            ActSetup set = new ActSetup();
            TheContext.TheSys.ActsListStatic(TheContext, set);
            //This is where all byttons get added to the main tab.
            foreach (ActHandle h in set.Handles)
            {
                try
                {
                    AddMainButton(h);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        ToolStripSplitButton AddMainButton(ActHandle h)
        {
            ToolStripSplitButton b = AddMainButton(h.TheAct);
            if( h.SubActs.Count > 0 )
            {
                try
                {
                    AddSubMenu(h, b);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return b;
        }

        public virtual ToolStripSplitButton AddMainButton(Act act)
        {
            ToolStripSplitButton b = new ToolStripSplitButton();
            b.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            b.Image = ToolBarImageGet(act.Name);
            b.Text = act.Name;
            b.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            b.ButtonClick += new EventHandler(ToolBar_ButtonClick);
            b.Tag = act;
            
            tools.Items.Add(b);
            //ToolBarButtons.Add(b);
            return b;
        }

        void ToolBar_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                ToolStripSplitButton sb = (ToolStripSplitButton)sender;
                Act h = (Act)sb.Tag;
                h.Handler(TheContext, new ActArgs());
            }
            catch(Exception ex)
            {
                TheContext.TheLeader.Error("Toolbar Error: " + ex.Message + "\r\n" + ex.StackTrace.ToString());   // 2011_09_28 this was coming up with 'child is not a control of this parent'
            }
        }

        void AddSubMenu(ActHandle h, ToolStripSplitButton b)
        {
            ContextMenuStrip mnu = new System.Windows.Forms.ContextMenuStrip();
            try
            {
                MenusAppend(mnu.Items, h);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            b.DropDown = mnu;
        }

        void MenusAppend(ToolStripItemCollection items, ActHandle h)
        {
            foreach (ActHandle sh in h.SubActs)
            {
                if (sh is ActHandleSeparator)
                {
                    items.Add(new ToolStripSeparator());
                }
                else
                {
                    if (sh.TheAct == null)
                    {
                        try
                        {
                            ToolStripMenuItem i = (ToolStripMenuItem)items.Add(sh.Caption);
                            MenusAppend(i.DropDownItems, sh);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    else if (sh.TheAct.Handler == null)
                    {
                        try
                        {
                            ToolStripMenuItem i = (ToolStripMenuItem)items.Add(sh.TheAct.Name);
                            MenusAppend(i.DropDownItems, sh);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    else
                    {
                        try
                        {
                            MenuAppend(items, sh.TheAct);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
        }

        void MenuAppend(ToolStripItemCollection items, Act act)
        {
            if (act.Name.Contains("&"))
                act.Name = act.Name.Replace("&", "&&");
            ToolStripItem i = items.Add(act.Name);
            i.Click += new EventHandler(SubAct_Click);
            i.Tag = act.Handler;
        }

        protected virtual Image ToolBarImageGet(string s)
        {
            return null;
        }

        void SubAct_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripItem i = (ToolStripItem)sender;
                ActHandler h = (ActHandler)i.Tag;
                h(TheContext, new ActArgs(i.Text));
            }
            catch(Exception ex)
            {
                TheContext.TheLeader.Error(ex);
            }
        }

        public virtual Control TabCheckShow(String strID)
        {
            return ts.TabCheckShow(strID);
        }
        public TabPageCore TabGetByID(String strID)
        {
            return ts.TabGetByID(strID);
        }
        public void TabTopClose()
        {
            ts.TabTopClose();
        }
        public String TabCurrentCaptionGet()
        {
            return ts.TabCurrentCaptionGet();
        }
        public ArrayList TabOpenCaptionsGet()
        {
            return ts.GetOpenTabCaptions();
        }
        public void TabCloseByID(String strID)
        {
            ts.TabCloseByID(strID);
        }
        public TabPageCore TabShow(Control c)
        {
            return ts.TabShow(c, "");
        }

        public virtual TabPageCore TabShow(Control c, String caption)
        {
            return TabShow(c, caption, caption.ToLower().Replace(" ", ""));  //this needs to have an id of the caption to avoid multiple order searches, etc
        }

        public virtual TabPageCore TabShow(Control c, String caption, String uid)
        {
            return ts.TabShow(c, caption, uid);
        }
        public TabPageCore TabShow(Control c, String caption, bool locked)
        {
            return ts.TabShow(c, caption, locked);
        }
        public void TabSelectedSet(TabPageCore p)
        {
            ts.TabSelectedSet(p);
        }

        public virtual void TabsInitialSet()
        {
            ts.TabsClearAll();
        }

        public bool ConfirmClose = false;
        private void mnuExit_Click(object sender, EventArgs e)
        {
            CompleteClose();
        }
        public virtual int GetHeaderHeight()
        {
            return tools.Height;
        }
        public virtual int GetFooterHeight()
        {
            return sb.Height;
        }
        private void cmdBack_Click(object sender, EventArgs e)
        {
            ts.TabTopClose();
        }

        //public ArrayList ToolBarButtons = new ArrayList();
        public ToolStripButton AddToolBarButton(String strText, System.Drawing.Image pic)
        {
            ToolStripButton b = new ToolStripButton();
            b.Text = strText;
            b.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            tools.Items.Add(b);
            if (pic != null)
                b.Image = pic;
            b.ImageTransparentColor = System.Drawing.Color.Magenta;
            b.Size = new System.Drawing.Size(49, 22);
            //ToolBarButtons.Add(b);
            return b;
        }

        protected void MenuClear()
        {
            ArrayList a = new ArrayList(tools.Items);
            foreach(Object b in a)
            {
                try
                {
                    if (b != cmdBack)
                    {
                        if (b is ToolStripSplitButton)
                        {
                            ToolStripSplitButton bs = (ToolStripSplitButton)b;
                            bs.ButtonClick -= new EventHandler(ToolBar_ButtonClick);
                            tools.Items.Remove(bs);
                        }
                        else
                        {
                            ToolStripButton bs = (ToolStripButton)b;
                            bs.Click -= new EventHandler(cmdExit_Click);
                            tools.Items.Remove(bs);
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            ShowAbout();
        }
        public virtual void ShowAbout()
        {
        }
        public void AddImage(Image i, String strKey)
        {
            try
            {
                il24.Images.Add(strKey, i);
            }
            catch
            {
            }
        }
        private void frmMain_Soft_FormClosing(object sender, FormClosingEventArgs e)
        {
            DoFormClosing();
        }
        public virtual void DoFormClosing()
        {
        }
        private void frmMain_Soft_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        public virtual Rectangle AvailableRectangle
        {
            get
            {
                if( sb.Visible )
                    return new Rectangle(0, tools.Bottom, this.ClientRectangle.Width, sb.Top - tools.Bottom);
                else
                    return new Rectangle(0, tools.Bottom, this.ClientRectangle.Width, this.ClientRectangle.Height - tools.Bottom);
            }
        }
        public virtual void DoResize()
        {
            try
            {
                tools.Left = 0;
                //tools.Top = mnu.Bottom;
                tools.Top = ToolsTopGet();
                tools.Width = this.ClientRectangle.Width;
                Rectangle r = AvailableRectangle;
                ts.Left = r.Left;
                ts.Top = r.Top;
                ts.Width = r.Width;
                ts.Height = r.Height;
            }
            catch
            {
            }
        }
        protected virtual int ToolsTopGet()
        {
            return 0;
        }
        private void ts_TabChanged(TabPageCore t)
        {
        }
        private void ts_TabAdded(TabPageCore t)
        {
            CheckTabStatus();
        }
        void CheckTabStatus()
        {
            try
            {
                cmdBack.Enabled = ts.TabCount > 0;
            }
            catch
            {
            }
        }
        private void ts_TabRemoved(TabPageCore t)
        {
            CheckTabStatus();
        }
        private void mnuMainExit_Click(object sender, EventArgs e)
        {
            this.CompleteClose();
        }

        public TabPageCore BrowseWebAddress(String strURL)
        {
            Browser b = new Browser();
            TabPageCore p = TabShow(b, strURL);
            b.Navigate(strURL);
            return p;
        }
        public void ShowTabStack()
        {
            Browser b = new Browser();
            FormExternal xForm = new FormExternal();
            xForm.SetControl(b);
            xForm.Text = "Tab Stack";
            xForm.Icon = this.Icon;
            xForm.WindowState = FormWindowState.Normal;
            xForm.Show();
            xForm.Top = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height / 2;
            xForm.Height = xForm.Top;
            xForm.Left = 0;
            xForm.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width / 2;
            b.ReloadWB();
            b.Add(ts.GetTabStackHTML());
        }

        public List<TabPageCore> TabsList
        {
            get
            {
                return ts.TabsList;
            }
        }

        public virtual void Show(ShowArgs args)
        {

        }

        public virtual IItem ItemShownByTag(Context x, ItemTag t)
        {
            TabPageCore p = ts.TabGetByID(t.Uid);
            if (p == null)
            {
                return ItemFindByTag(x, t);
            }

            if (p.TheView is ViewItem)
            {
                ViewItem pv = (ViewItem)p.TheView;
                return pv.TheItem;
            }

            return null;
        }

        public virtual IItem ItemFindByTag(Context x, ItemTag t)
        {
            foreach (TabPageCore p in ts.TabsList)
            {
                if (p.TheView is ViewItem)
                {
                    ViewItem pv = (ViewItem)p.TheView;
                    IItem ret = pv.ItemFindByTag(t);
                    if (ret != null)
                        return ret;
                }
            }
            return null;
        }

        public BrowserPlain ShowHTML(string strHTML, string strCaption)
        {
            BrowserPlain b = new BrowserPlain();
            b.ShowControls = true;
            TabShow(b, strCaption);
            b.ReloadWB();
            b.Add(strHTML);
            b.OnNavigate += new OnNavigateHandler(b_OnNavigate);
            return b;
        }

        protected void b_OnNavigate(GenericEvent e)
        {
            NavigateHandle(e);
        }

        protected virtual void NavigateHandle(GenericEvent e)
        {
        }

        public virtual void TabsCloseUnlocked()
        {
            ts.CloseAll();
        }
    }
}