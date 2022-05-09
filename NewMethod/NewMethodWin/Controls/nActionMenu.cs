using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Core;

namespace NewMethod
{
    public partial class nActionMenu : UserControl
    {
        public SysNewMethod xSys
        {
            get
            {
                return NMWin.ContextDefault.xSys;
            }
        }
        public nObject xObject;
        ActSetup actSetup;

        public virtual int FixedWidth
        {
            get
            {
                return 143;
            }
        }

        public nActionMenu()
        {
            InitializeComponent();
        }

        protected void CompleteDispose()
        {
            try
            {
                PanelInitUn(pLinks);
                this.cmdNotes.Click -= new System.EventHandler(this.cmdNotes_Click);
                this.cmdSaveExit.Click -= new System.EventHandler(this.cmdSaveExit_Click);
                this.cmdSave.Click -= new System.EventHandler(this.cmdSave_Click);
                this.cmdDelete.Click -= new System.EventHandler(this.cmdDelete_Click);
                this.Resize -= new System.EventHandler(this.nActionMenu_Resize);
            }
            catch { }
        }

        //Public Events
        public event FlashClickHandler ActionClick;
        //Public Functions

        public virtual void CompleteLoad(nObject o)
        {
            CompleteLoad(o, null);
        }

        public virtual void CompleteLoad(nObject o, ActSetup setup)
        {
            this.Width = FixedWidth;
            xObject = o;
            actSetup = setup;
            LoadActionMenu();
            cmdDelete.Enabled = xObject.DeletePossible(NMWin.ContextDefault);
            DoResize();
            LoadMenus();
        }
        private void LoadActionMenu()
        {
            if (actSetup == null)
                actSetup = new ActSetup(xObject);
            else
                actSetup.Clear();

            if (actSetup.TheItems == null)
            {
                actSetup.TheItems = new ItemsInstance();
                actSetup.TheItems.Add(NMWin.ContextDefault, xObject);
            }

            actSetup.IsRightClick = false;
            NMWin.ContextDefault.TheSys.ActsListInstance(NMWin.ContextDefault, actSetup);
        }
        public void DoResize()
        {
            try
            {
                pButtons.Top = 0;
                pDelete.Top = this.ClientRectangle.Height - pDelete.Height;
                pLinks.Top = pButtons.Bottom + 3;
                pLinks.Height = pDelete.Top - pLinks.Top;
                pLinks.Left = 3;
                pLinks.Width = this.ClientRectangle.Width - pLinks.Left;
                pDelete.Left = 0;
                pDelete.Width = this.ClientRectangle.Width;
                cmdDelete.Left = 2;
                cmdDelete.Width = this.ClientRectangle.Width - (cmdDelete.Left * 2);
                pDelete.Visible = true;
                if (actSetup != null)
                {
                    if (!m_EnableDelete)
                    {
                        pDelete.Visible = false;
                        pLinks.Height = pDelete.Bottom - pLinks.Top;
                        pLinks.BringToFront();
                    }
                }
                ToolsWin.Screens.ShowOverTo(this, pButtons);
            }
            catch (Exception)
            { }
        }
        public bool IsDisabled()
        {
            try
            {
                return !pLinks.Enabled;
            }
            catch { return false; }
        }
        public void LoadMenus()
        {
            PanelInit(pLinks);
            //PanelLoad(mnuBanner, pLinks);
            PanelLoad(actSetup.Handles, pLinks);
        }

        private void SendActionClick(String action)
        {
            if (ActionClick != null)
                ActionClick(this, new FlashClickArgs(action));
        }

        private void PanelInit(FlowLayoutPanel panel)
        {
            PanelInitUn(panel);
        }

        private void PanelInitUn(FlowLayoutPanel panel)
        {
            foreach (Control c in panel.Controls)
            {
                try
                {
                    ((nActionLink)c).LinkClicked -= new ActionLinkClickHandler(link_LinkClicked);
                }
                catch { }
            }

            panel.Controls.Clear();
        }
        
        private void PanelLoad(List<ActHandle> acts, FlowLayoutPanel panel)
        {
            if (panel == null)
                return;
 
            foreach (ActHandle h in acts)
            {
                if (Tools.Strings.StrCmp(h.Name, "delete"))
                    continue;
                nActionLink link = new nActionLink();
                link.CompleteLoad(h);
                link.LinkClicked += new ActionLinkClickHandler(link_LinkClicked);
                panel.Controls.Add(link);
            }
        }
        
        public void Disable(String strDisable)
        {
            foreach (nActionLink l in pLinks.Controls)
            {
                if (Tools.Strings.StrCmp(l.GetText(), strDisable))
                    l.Enabled = false;
            }
        }

        public void Enable(String strEnable)
        {
            foreach (nActionLink l in pLinks.Controls)
            {
                if (Tools.Strings.StrCmp(l.GetText(), strEnable))
                {
                    l.Enabled = true;
                    l.SetEnabled(true);
                }
            }
        }

        public void DisableNotes()
        {
            cmdNotes.Enabled = false;
        }

        public void DisableDelete()
        {
            cmdDelete.Enabled = false;
        }

        public void DisableExcept(String strExcept)
        {
            //pActions.Enabled = true;
            pLinks.Enabled = true;
            //pBanner.Enabled = true;
            
            //allow clip and note
            pButtons.Enabled = true;
            cmdSave.Enabled = Tools.Strings.HasString(strExcept, "|save|");
            cmdSaveExit.Enabled = cmdSave.Enabled;
            cmdNotes.Enabled = true;
            //cmdClip.Enabled = true;

            foreach (nActionLink l in pLinks.Controls)
            {
                bool en  = Tools.Strings.HasString(strExcept, "|" + l.GetText() + "|");
                l.Enabled = en;
                l.SetEnabled(en);
            }

            //foreach (nActionLink l in pBanner.Controls)
            //{
            //    l.Enabled = Tools.Strings.HasString(strExcept, "|" + l.GetText() + "|");
            //}
        }

        //private MenuSetup AlterBannerMenu(MenuSetup banner)
        //{
        //    if (banner == null)
        //        return banner;
        //    MenuSetup mnu = new MenuSetup();
        //    mnu.IsRightClick = false;
        //    foreach (MenuItem i in banner.MenuItems)
        //    {
        //        i.strKey = "change_view_" + i.strKey;
        //        mnu.MenuItems.Add(i); 
        //    }
        //    return mnu;
        //}

        public void EnableJustSaveAndExit()
        {
            this.Enabled = true;
            cmdSaveExit.Enabled = true;
            cmdNotes.Enabled = true;
        }

        public void EnableJustNotes()
        {
            this.Enabled = true;
            cmdNotes.Enabled = true;
        }

        //Buttons
        private void cmdSave_Click(object sender, EventArgs e)
        {
            SendActionClick("Save");
        }
        private void cmdSaveExit_Click(object sender, EventArgs e)
        {
            SendActionClick("SaveAndExit");
        }
        private void cmdNotes_Click(object sender, EventArgs e)
        {
            SendActionClick("Note");
        }
        //private void cmdClip_Click(object sender, EventArgs e)
        //{
        //    SendActionClick("Clip");
        //}
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            SendActionClick("Delete");
        }
        //Control Events
        private void nActionMenu_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        void link_LinkClicked(object sender, string ActionKey)
        {
            SendActionClick(ActionKey);
        }

        bool m_EnableDelete = false;
        public bool EnableDelete
        {
            get
            {
                return m_EnableDelete;
            }

            set
            {
                m_EnableDelete = value;

                if( value && xObject != null )
                    cmdDelete.Enabled = xObject.DeletePossible(NMWin.ContextDefault);
                else
                    cmdDelete.Enabled = m_EnableDelete;

                DoResize();
            }
        }
    }
    public delegate void FlashClickHandler(Object sender, FlashClickArgs args);
}
