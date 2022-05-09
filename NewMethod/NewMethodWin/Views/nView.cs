using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Core;
using CoreWin;
using CoreWin.Views;
using System.Collections.Generic;

namespace NewMethod
{
    public partial class nView : ViewItem
    {
        public nView()
        {
            InitializeComponent();
        }

        protected virtual void DisposeView()
        {
            NMWin.Sys.Changed -= new DeltaHandler(Sys_Changed);
        }

        void Sys_Changed(Context x, ChangeArgs args)
        {
            if (this.InvokeRequired)
            {
                HandleChangeNotification d = new HandleChangeNotification(SysChanged);
                this.Invoke(d, new object[] { x, args });
            }
            else
            {
                SysChanged(x, args);
            }
        }

        public bool suppressRefresh = false;
        protected virtual void SysChanged(Context x, ChangeArgs args)
        {
            if (TheItem != null)
            {
                if (args.IdDeleted(TheItem.Uid))
                    SendCloseRequest();
                else if (args.IdUpdated(TheItem.Uid) && !IsLoading && !IsSaving && !suppressRefresh)
                    CompleteLoad();
            }
        }

        public bool m_IsLoading = false;
        public bool IsLoading
        {
            get
            {
                return m_IsLoading;
            }
            set
            {
                m_IsLoading = value;
            }
        }

        public bool IsSaving = false;

        bool wasSysChangedLinked = false;
        public virtual void CompleteLoad()
        {
            if (!wasSysChangedLinked)
            {
                if (NMWin.ContextDefault != null)
                {
                    NMWin.Sys.Changed += new DeltaHandler(Sys_Changed);
                    wasSysChangedLinked = true;
                }
            }

            NMWin.LoadFormValues(this, (nObject)TheItem);
        }

        public virtual void CompleteSaveAndUpdate()
        {
            IsSaving = true;
            CompleteSave();
            NMWin.ContextDefault.Update(TheItem);
            IsSaving = false;
        }

        public virtual void CompleteSave()
        {
            nObject o = GetCurrentObject();
            if (o != null)
                NMWin.GrabFormValues(this, o, ControlsToIgnore);
            ClearInfo();
        }

        protected virtual List<Control> ControlsToIgnore
        {
            get
            {
                return null;
            }
        }

        public void SendCloseRequest()
        {
            NMWin.Leader.Comment("Sending close request...");
            CloseRequestSend();
        }

        protected override void InitUn()
        {
            base.InitUn();
            this.Resize -= new System.EventHandler(this.nView_Resize);
        }

        public virtual void HandleAction(object sender, ActArgs args)
        {
            switch (args.ActionName.ToLower())
            {
                case "saveandexit":
                case "save_and_close":
                    args.Handled = true;
                    try
                    {
                        CompleteSaveAndUpdate();
                        SendCloseRequest();
                    }
                    catch (Exception ex)
                    {
                        NMWin.ContextDefault.Leader.Tell(ex.Message);
                    }

                    break;
                case "save":

                    try
                    {
                        CompleteSaveAndUpdate();
                        CompleteLoad();
                    }
                    catch (Exception ex)
                    {
                        NMWin.ContextDefault.Leader.Tell(ex.Message);
                    }
                    //added this 2013_07_06.  doesn't it make sense to reload the screen if just 'save' is clicked?
                    //Commented out by KT on 8-19-2014 - This confilicts with the make mandatory source, is clearing all unsaved values if you forget source.


                    args.Handled = true;
                    break;
                case "exit":
                    SendCloseRequest();
                    args.Handled = true;
                    break;
                case "delete":
                    if (NMWin.Leader.AreYouSure("delete " + GetCurrentObject().ToString()))
                    {
                        args.TheContext.Delete(GetCurrentObject());
                        SendCloseRequest();
                        args.Handled = true;
                    }
                    break;
                case "clip":
                    nObject x = GetCurrentObject();
                    if (x != null)
                    {
                        if (NMWin.User != null)
                            NMWin.User.AddClipObject((ContextNM)args.TheContext, x, true);
                    }
                    break;
                case "note":
                    nObject xn = GetCurrentObject();
                    if (xn != null)
                        xn.SendNote(NMWin.ContextDefault);
                    args.Handled = true;
                    break;
            }
        }

        public nObject GetCurrentObject()
        {
            return (nObject)TheItem;
        }

        public void SetCurrentObject(nObject xObject)
        {
            Init(xObject);
        }

        public virtual int GetImageIndex()
        {
            return 0;
        }

        public virtual String GetCaption()
        {
            return "";
        }

        public virtual void SetCustomState(String strState)
        {

        }

        public event EventHandler DeleteRequest;
        public bool SendDeleteRequest()
        {
            if (DeleteRequest != null)
            {
                DeleteRequest(null, null);
                return true;
            }
            else
                return false;
        }

        private void nView_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        protected virtual void DoResize()
        {

        }

        public virtual Rectangle AreaAvailable
        {
            get
            {
                return new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);
            }
        }

        public void EnableControls()
        {
            SetEnabled(true);
        }

        public virtual void DisableControls()
        {
            DisableControls(null);
        }

        public void DisableControls(List<Object> exceptions)
        {
            SetEnabled(false, exceptions);
        }

        public void SetEnabled(bool enabled)
        {
            SetEnabled(enabled, null);
        }

        public virtual void SetEnabled(bool enabled, List<Object> exceptions)
        {
            SetEnabled(this, enabled, exceptions);
        }

        public static void SetEnabled(Control ctl, bool enabled, List<Object> exceptions)
        {
            foreach (Control c in ctl.Controls)
            {
                bool b = true;
                if (exceptions != null)
                {
                    foreach (Object x in exceptions)
                    {
                        if (Object.ReferenceEquals(x, c))
                        {
                            b = false;
                            break;
                        }
                    }
                }

                if (b)
                {
                    if (c is IEnableable)
                    {
                        IEnableable en = (IEnableable)c;
                        en.Enable(enabled);
                    }
                    else
                    {
                        if (c.Controls.Count == 0)
                            c.Enabled = enabled;
                        else
                            SetEnabled(c, enabled, exceptions);
                    }
                }
            }
        }

        public virtual void ClearInfo()
        {
            ClearInfo(Controls);
        }

        public virtual void ClearInfo(ControlCollection cs)
        {
            if (cs == null)
                return;

            nEdit ctl;
            foreach (Control c in cs)
            {
                if (c.Name.ToLower().StartsWith("ctl_"))
                {
                    try
                    {
                        ctl = (nEdit)c;
                        ctl.ClearInfo();
                    }
                    catch (Exception)
                    { }
                }
                else
                {
                    ClearInfo(c.Controls);
                }
            }
        }
    }

    public interface IEnableable
    {
        void Enable(bool enabled);
    }

    public class FlashClickArgs
    {
        public String strButton = "";

        public FlashClickArgs(String button)
        {
            strButton = button;
        }
    }

    public interface ICompleteLoad
    {
        void CompleteLoad();
    }
}
