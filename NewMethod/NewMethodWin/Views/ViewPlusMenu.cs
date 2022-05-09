using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Core;

namespace NewMethod
{
    public partial class ViewPlusMenu : NewMethod.nView
    {
        //mc_menu CurrentMenu;
        //private MenuSetup menu;
        //private MenuSetup banner;
        public bool TrackExtraInfo = false;

        public ViewPlusMenu()
        {
            InitializeComponent();
        }

        public override void Init(Item item)
        {
            base.Init(item);
            InitActions();
        }

        public virtual void InitActions()
        {
            if (TheItem != null)
                xActions.CompleteLoad((nObject)TheItem);
        }

        public override void CompleteLoad()
        {      
            //Load All Controls (i.e. ctl_XXXX, etc_)
            base.CompleteLoad();

            //Check for Allow Delete Button
            try
            {
                nObject x = GetCurrentObject();
                if (x != null)
                    xActions.EnableDelete = x.CanBeDeletedBy(NMWin.ContextDefault);
            }
            catch { }
        }

        void CompleteDispose()
        {
            try
            {
                this.xActions.ActionClick -= new NewMethod.FlashClickHandler(this.xActions_ActionClick);
            }
            catch { }
        }

        //public override void LoadForm()
        //{
        //    nObject o = GetCurrentObject();
        //    if (o != null)
        //    {
        //        o.LoadFormValues(this, ControlsToIgnore);
        //    }
        //    base.LoadForm();

        //}
        public override String GetCaption()
        {
            if (GetCurrentObject() == null)
            {
                return "";
            }
            else
            {
                return GetCurrentObject().ToString();
            }
        }

        public override void SetEnabled(bool enabled, List<Object> exceptions)
        {
            base.SetEnabled(enabled, exceptions);
        }

        protected override void DoResize()
        {
            base.DoResize();
            try
            {
                xActions.Top = 0;
                xActions.Left = this.ClientRectangle.Width - xActions.Width;
                xActions.Height = this.ClientRectangle.Height - xActions.Top;
                xActions.BringToFront();
            }
            catch (Exception)
            { }
        }
        public virtual void HandleCommand(string strCommand)
        {
            try
            {
                NMWin.Leader.Comment("Handling command " + strCommand + "...");
                if (strCommand.ToLower().StartsWith("change_view_") || strCommand.ToLower().StartsWith("view_"))
                {
                    HandleView(strCommand.ToLower().Replace("change_view_", "").Replace("view_", "").Trim());
                    return;
                }
                if (Tools.Strings.StrCmp(strCommand, "saveandexit"))
                    strCommand = "save_and_close";
                //make sure that derived classes can tell the args to just
                //return the info rather than showing it                
                ActArgs args = new ActArgs();
                args.TheContext = NMWin.ContextDefault;
                args.TheItems = new ItemsInstance();
                nObject x = GetCurrentObject();
                args.TheItems.Add(NMWin.ContextDefault, (IItem)x);
                args.Name = strCommand;
                NMWin.Leader.Comment("Checking args...");
                CheckActionArgs(args);

                base.HandleAction(this, args);
                if (args.Handled)
                {
                    NMWin.Leader.Comment("Handled - Finishing...");
                    FinishedAction(args);
                    return;
                }
                else
                    NMWin.Leader.Comment("Not handled.");


                CompleteSaveAndUpdate();


                Context xx = NMWin.ContextDefault.Clone();
                String cid = xx.TheDelta.StartChangeCache();
                args.TheContext = xx;
                NMWin.ContextDefault.TheSys.ActInstanceBeforeAfter(xx, args);
                xx.TheDelta.EndChangeCache(NMWin.ContextDefault, cid);
                CompleteLoad();
                DoResize();
                FinishedAction(args);
            }
            catch (Exception ex)
            {
                NMWin.Leader.Error("There was an error in ViewPlusMenu.HandleCommand(" + strCommand + ") : " + ex.Message + "\r\n\r\n\r\n" + ex.StackTrace + "\r\n\r\n\r\n" + ex.InnerException);
            }
        }
        public virtual void CheckActionArgs(ActArgs args)
        {

        }
        public virtual void FinishedAction(ActArgs args)
        {

        }
        public virtual void HandleView(String strView)
        {

        }
        //Control Events
        private void xActions_ActionClick(object sender, FlashClickArgs args)
        {
            //nThrobber throb = new nThrobber();
            //throb.ShowThrobber();
            HandleCommand(args.strButton);
            //throb.HideThrobber();
        }

        public override Rectangle AreaAvailable
        {
            get
            {
                return new Rectangle(0, 0, this.ClientRectangle.Width - xActions.Width, this.ClientRectangle.Height);
            }
        }
    }
}

