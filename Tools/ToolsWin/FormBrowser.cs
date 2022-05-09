using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ToolsWin
{
    public partial class FormBrowser : Form
    {
        public FormBrowser()
        {
            InitializeComponent();
            wb.ReloadWB();
        }
        public AxSHDocVw.AxWebBrowser GetWB()
        {
            return wb.GetWB();
        }

        delegate ArrayList GetLinkArrayHandler(String strIncluding);
        public ArrayList GetLinkArray(String strIncluding)
        {
            if( InvokeRequired )
                return (ArrayList)Invoke(new GetLinkArrayHandler(ActuallyGetLinkArray), new object[] { strIncluding });
            else
                return GetLinkArray(strIncluding);
        }

        public ArrayList ActuallyGetLinkArray(String strIncluding)
        {
            return wb.GetLinkArray(strIncluding);
        }

        delegate void NavigateHandler(String strURL);
        public void Navigate(String strURL)
        {
            if (InvokeRequired)
                Invoke(new NavigateHandler(ActuallyNavigate), new object[] { strURL });
            else
                ActuallyNavigate(strURL);
        }

        void ActuallyNavigate(String strURL)
        {
            wb.ReloadWB();
            wb.Navigate(strURL);
        }

        delegate String GetStringHandler();

        public String GetHTML()
        {
            if (InvokeRequired)
                return (String)Invoke(new GetStringHandler(ActuallyGetHTML));
            else
                return ActuallyGetHTML();
        }

        String ActuallyGetHTML()
        {
            return wb.GetPageHTML();
        }

        public String GetText()
        {
            if (InvokeRequired)
                return (String)Invoke(new GetStringHandler(ActuallyGetText));
            else
                return ActuallyGetText();
        }

        String ActuallyGetText()
        {
            return wb.GetPageText();
        }

        public String GetURL()
        {
            if (InvokeRequired)
                return (String)Invoke(new GetStringHandler(ActuallyGetURL));
            else
                return ActuallyGetURL();
        }

        String ActuallyGetURL()
        {
            return wb.GetURL();
        }

        delegate bool ClickLinkHandler(String strLink);

        public bool ClickLink(String strLink)
        {
            if (InvokeRequired)
                return (bool)Invoke(new ClickLinkHandler(ActuallyClickLink), new object[] { strLink });
            else
                return ActuallyClickLink(strLink);
        }

        bool ActuallyClickLink(String strLink)
        {
            return wb.ClickElement("a", strLink, "", "", "", false);
        }

        delegate bool ReadyHandler();
        public bool IsReady()
        {
            if (InvokeRequired)
                return (bool)Invoke(new ReadyHandler(ActuallyIsReady));
            else
                return ActuallyIsReady();
        }

        bool ActuallyIsReady()
        {
            try
            {
                return wb.GetWB().ReadyState == SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE;
            }
            catch { return false; }
        }
    }
}