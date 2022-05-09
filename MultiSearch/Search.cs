using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using NewMethod;
using Rz5;
using Tools.Database; 

namespace MultiSearch
{
    public delegate void EnableLogin(Boolean bEnable);
    public partial class Search : UserControl
    {
        SHDocVw.WebBrowser AxWebBrowser;
        public static bool ShouldStopAutoSearching = false;
        private StatusIcon z_StatusKey = StatusIcon.Null;
        private StatusIcon z_ResultKey = StatusIcon.Null;
        public String LastPartSearched = "";
        public bool IsBusy = false;
        public bool IsSearching = false;
        public bool IsAbleToSearch = false;
        public bool HasSearched = false;
        public StringBuilder Activity;
        public DateTime LastBusy;
        public DateTime LastDone;
        public TabPage MyTab;
        public bool DoCheckStockDate = false;
        public DateTime LastStockCheck = System.DateTime.Now;
        public bool TriedForceSearch = false;
        public bool IsInitialized = false;
        public bool SavePageData = false;
        public bool Cancelled = false;

        public Int32 ColorIndex = 0;
        public Int32 BWIndex = 0;

        public String WebsiteName = "";
        public String UserName_Name = "";
        public String Password_Name = "";
        public String SecondPassword_Name = "";

        public String LoginTag = "";
        public String LoginType = "";
        public String LoginValue = "";
        public String LoginText = "";
        public String LoginHref = "";
        public String LoginSrc = "";
        public String LoginName = "";
        public String LoginAlt = "";
        protected multisearch_login xLogin = null;
        public IMSDataProvider msData;


        private bool bShowLogin = false;
        public bool ShowLogin
        {
            get
            {
                return bShowLogin;
            }
            set
            {
                bShowLogin = value;
                if (InvokeRequired)
                {
                    EnableLogin d = new EnableLogin(DoVisibleLogin);
                    Invoke(d, new Object[] { value });
                }
                else
                    DoVisibleLogin(value);
            }
        }
        private bool bShowPostButtons = false;
        public bool ShowPostButtons
        {
            get
            {
                return bShowPostButtons;
            }
            set
            {
                bShowPostButtons = value;
                if (InvokeRequired)
                {
                    EnableLogin d = new EnableLogin(DoVisiblePost);
                    Invoke(d, new Object[] { value });
                }
                else
                    DoVisiblePost(value);
            }
        }


        public Search(IMSDataProvider d)
        {
            msData = d;
            InitializeComponent();
            Activity = new StringBuilder();
            AxWebBrowser = (SHDocVw.WebBrowser)wb.ActiveXInstance;
            AxWebBrowser.NewWindow2 += new SHDocVw.DWebBrowserEvents2_NewWindow2EventHandler(AxWebBrowser_NewWindow2);
            AxWebBrowser.NewWindow3 += new SHDocVw.DWebBrowserEvents2_NewWindow3EventHandler(AxWebBrowser_NewWindow3);
            //wb.Silent = true;
            //wb.RegisterAsBrowser = true;
            wb.ScriptErrorsSuppressed = true;
        }

        ~Search()
        {
            try
            {
                AxWebBrowser.NewWindow3 -= new SHDocVw.DWebBrowserEvents2_NewWindow3EventHandler(AxWebBrowser_NewWindow3);
            }
            catch { }
        }

        private void DoVisibleLogin(bool bVisible)
        {
            cmdLogin.Visible = bVisible;
        }

        private void DoVisiblePost(bool bVisible)
        {
            //if (msData.IsAAT)
            //{
            //    cmdPOstOffers.Visible = bVisible;
            //    cmdPostRFQs.Visible = bVisible;
            //}
        }

        public void SetIndex(Int32 index)
        {
            ColorIndex = (index * 2) + 1;
            BWIndex = (index * 2) + 2;
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            try
            {
                wb.GoBack();
            }
            catch (Exception)
            {
            }
        }

        public void DoEvents()
        {
            System.Windows.Forms.Application.DoEvents();
        }

        public bool AutoSearch = false;
        public void AutoSearchCheck()
        {
            if (msData.HasAutoSearch(WebsiteName, true))
                AutoSearch = true;
            else if (msData.HasAutoSearch(WebsiteName, false))
                AutoSearch = true;
            else
                AutoSearch = false;
        }

        public virtual void InitWebsite()
        {
            IsInitialized = true;
            CheckEnableLogin();
            HasSearched = false;
            if (!Tools.Misc.IsDevelopmentMachine())
            {
                cmdHTML.Visible = false;
                cmdText.Visible = false;
            }
            if (Tools.Strings.StrExt(this.UserName_Name))
            {
                WaitForDone();
                WaitForDone();
                EnterAutoLoginInfo();
            }
        }

        protected virtual void EnterAutoLoginInfo()
        {
            bool y = false;

            String user = Tools.OperatingSystem.GetCrumb(this.ToString() + "_user");
            if (!Tools.Strings.StrExt(user))
                return;

            String pass = Tools.OperatingSystem.GetCrumb(this.ToString() + "_pass");
            if (!Tools.Strings.StrExt(pass))
                return;

            String pass2 = Tools.OperatingSystem.GetCrumb(this.ToString() + "_pass2");

            if (Tools.Strings.StrExt(this.UserName_Name))
            {
                if (SetTextBox(this.UserName_Name, user))
                    y = true;
            }

            if (Tools.Strings.StrExt(this.Password_Name))
            {
                if (!SetTextBox(this.Password_Name, pass))
                    y = false;
            }

            if (Tools.Strings.StrExt(this.SecondPassword_Name))
            {
                if (!SetTextBox(this.SecondPassword_Name, pass2))
                    y = false;
            }

            if (y)
            {
                if (Tools.Strings.StrExt(this.LoginTag))
                {
                    this.ClickElement(this.LoginTag, this.LoginText, this.LoginValue, this.LoginName, "", true, this.LoginSrc);
                }
            }
        }

        public void CheckEnableLogin()
        {
            try
            {
                String name = WebsiteName;
                multisearch_login login = msData.GetLoginByName(false, name);
                if (login == null)
                {
                    login = msData.GetLoginByName(true, name);
                    if (login == null)
                    {
                        if (InvokeRequired)
                        {
                            EnableLogin d = new EnableLogin(DoEnableLogin);
                            Invoke(d, new Object[] { false });
                        }
                        else
                            DoEnableLogin(false);
                        return;
                    }
                }
                xLogin = login;
                if (InvokeRequired)
                {
                    EnableLogin d = new EnableLogin(DoEnableLogin);
                    Invoke(d, new Object[] { true });
                }
                else
                    DoEnableLogin(true);
            }
            catch { }
        }

        public void DoEnableLogin(Boolean bEnable)
        {
            cmdLogin.Enabled = bEnable;
        }

        public virtual void EnterLoginInfo()
        {
            bool y = false;
            if (xLogin == null)
                return;
            String user = xLogin.username;
            if (!Tools.Strings.StrExt(user))
                return;
            String pass = xLogin.password;
            if (!Tools.Strings.StrExt(pass))
                return;
            String pass2 = xLogin.extradata;
            if (Tools.Strings.StrExt(this.UserName_Name))
            {
                if (SetTextBox(this.UserName_Name, user))
                    y = true;
            }
            if (Tools.Strings.StrExt(this.Password_Name))
            {
                if (!SetTextBox(this.Password_Name, pass))
                    y = false;
            }
            if (Tools.Strings.StrExt(this.SecondPassword_Name))
            {
                if (!SetTextBox(this.SecondPassword_Name, pass2))
                    y = false;
            }
            if (y)
            {
                if (Tools.Strings.StrExt(this.LoginTag))
                {
                    this.ClickElement(this.LoginTag, this.LoginText, this.LoginValue, this.LoginName, "", true, this.LoginSrc, this.LoginAlt, this.LoginHref);
                }
            }
        }

        public virtual string ToString() { return "<none>"; }

        public virtual void BeforeSearch(String part_number)
        {

        }

        public virtual void RunSearch(String strPartNumber, bool wait)
        {
            HasSearched = true;
            LastPartSearched = strPartNumber;
            RzWin.Leader.Comment("Searching " + this.ToString() + " for " + strPartNumber);
            IsSearching = true;
            if (this.IsAbleToSearch)
                pic.BackColor = Color.Green;
        }


        public void FinishedSearch()
        {
            PassiveWaitForDone();
        }

        public bool Navigate(String strURL, bool wait)
        {

            LastBusy = System.DateTime.Now;
            LastDone = System.DateTime.Now;
            IsBusy = true;

            try
            {
                Object o = null;
                wb.Navigate(strURL);
            }
            catch (Exception)
            {
            }

            if (wait)
            {
                return WaitForDone();
            }
            else
            {
                PassiveWaitForDone();
                return true;
            }
        }

        public void PassiveWaitForDone()
        {
            Thread t = new Thread(new ThreadStart(PassiveWaitForDoneThread));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            return;
        }

        private void PassiveWaitForDoneThread()
        {
            if (WaitForDone())
                return;

            if (WaitForDone())
                return;

            if (WaitForDone())
                return;
        }

        public bool WaitForDone()
        {
            if (WaitForDone(wb))
            {
                IsBusy = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool WaitForDone(WebBrowser xwb)
        {
            try
            {
                if (xwb == null)
                    xwb = wb;

                int j = 0;
                for (int i = 0; i < 20; i++)
                {
                    if (Cancelled)
                        return false;

                    DoEvents();
                    System.Threading.Thread.Sleep(100);

                    if (Cancelled)
                        return false;

                    if (xwb.ReadyState != WebBrowserReadyState.Complete)
                        i = 0;

                    j++;
                    if (j > 60)
                        return false;
                }
                DocumentReallyComplete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual void DocumentReallyComplete()
        {
            if (Program.SkipData)
                return;

            if (IsAbleToSearch && SavePageData)
            {
                GrabThePage();
            }
        }

        public void GrabThePage()
        {
            Thread t = new Thread(new ThreadStart(GrabThePageThread));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        public void GrabThePageThread()
        {
            if (Program.xData == null)
                return;

            try
            {
                String strSQL = "insert into multisearch(unique_id, datecreated, sitename, alldata, userid, url) values ( cast(newid() as varchar(50)), getdate(), '" + this.ToString() + "', '" + this.GetPageHTML(wb).Replace("'", "''") + "', '" + Program.userid + "', '" + wb.Url.ToString().Replace("'", "''") + "')";
                Program.xData.Execute(strSQL, true);
                Program.SetStatus("Saved page from " + this.ToString());
            }
            catch (Exception)
            {
                Program.SetStatus("Error saving page from " + this.ToString());
            }
        }

        public bool ClickElementDocument(HtmlDocument xDoc, String strTag, String strText, String strValue, String strName, String strID, bool wait, String strSource, String strAlt, String strHref)
        {
            HtmlElement body;
            body = xDoc.Body;

            HtmlElementCollection col = body.All;

            mshtml.IHTMLElement anc;
            String strhref;
            String strURL;
            mshtml.IHTMLInputElement inp;
            mshtml.IHTMLButtonElement b;
            mshtml.IHTMLImgElement i;
            mshtml.IHTMLAnchorElement a;

            bool yes;

            foreach (HtmlElement ele in col)
            {

                if (Tools.Strings.StrCmp(ele.TagName, strTag))
                {
                    anc = (mshtml.IHTMLElement)(ele.DomElement);

                    yes = false;

                    if (Tools.Strings.StrExt(strText) && Tools.Strings.StrCmp(strText, anc.innerText))
                        yes = true;

                    if (Tools.Strings.StrExt(strID) && Tools.Strings.StrCmp(strID, anc.id))
                    {
                        yes = true;
                    }
                    else if (Tools.Strings.StrCmp(strTag, "a"))
                    {
                        a = (mshtml.IHTMLAnchorElement)(anc);

                        if (Tools.Strings.StrExt(strHref) && Tools.Strings.StrCmp(strHref, a.href))
                            yes = true;
                    }
                    else if (Tools.Strings.StrCmp(strTag, "input"))
                    {
                        inp = (mshtml.IHTMLInputElement)(anc);

                        String st = inp.name;

                        if (Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, inp.name))
                            yes = true;

                        if (Tools.Strings.StrExt(strValue) && Tools.Strings.StrCmp(strValue, inp.value))
                            yes = true;

                        if (Tools.Strings.StrExt(strSource) && Tools.Strings.HasString(inp.src, strSource))
                            yes = true;

                        if (Tools.Strings.StrExt(strAlt) && Tools.Strings.HasString(inp.alt, strAlt))
                            yes = true;
                    }
                    else if (Tools.Strings.StrCmp(strTag, "button"))
                    {
                        b = (mshtml.IHTMLButtonElement)anc;

                        if (Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, b.name))
                            yes = true;

                        if (Tools.Strings.StrExt(strValue) && Tools.Strings.StrCmp(strValue, b.value))
                            yes = true;
                    }

                    else if (Tools.Strings.StrCmp(strTag, "img"))
                    {
                        i = (mshtml.IHTMLImgElement)anc;

                        if (Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, i.name))
                            yes = true;

                        if (Tools.Strings.StrExt(strSource) && Tools.Strings.HasString(i.src, strSource))
                            yes = true;
                    }

                    if (yes)
                    {
                        //AddActivity(String.Concat(S"Clicking ", strText, strValue, strName, strID, S"..."));
                        anc.click();
                        if (wait)
                            return WaitForDone();
                        else
                            return true;
                    }
                }
            }

            //can this be done with the standard browser?
            //foreach(HtmlElement frame in xDoc.All)
            //{
            //    HtmlFrame

            //    Object d = frame.document;

            //    try
            //    {
            //        mshtml.IHTMLDocument2 frameDoc = (mshtml.IHTMLDocument2)(d);

            //        if( ClickElementDocument(frameDoc, strTag, strText, strValue, strName, strID, wait, strSource,strAlt,  strHref) )
            //            return true;
            //    }
            //    catch(Exception e)
            //    {
            //        int k=0;
            //    }
            //}

            return false;
        }

        public bool SetCheckBox(String strName)
        {

            HtmlDocument xDoc = wb.Document;
            HtmlElement body;
            body = xDoc.Body;

            HtmlElementCollection col = body.All;

            IEnumerator en = col.GetEnumerator();
            mshtml.IHTMLInputElement inp;
            mshtml.IHTMLElement ele;
            mshtml.IHTMLOptionButtonElement c;

            while (en.MoveNext())
            {
                ele = (mshtml.IHTMLElement)(en.Current);

                if (String.Compare(ele.tagName.ToLower(), "input") == 0)
                {
                    inp = (mshtml.IHTMLInputElement)(ele);

                    if (String.Compare(inp.name.ToLower(), strName.ToLower()) == 0)
                    {
                        c = (mshtml.IHTMLOptionButtonElement)(ele);
                        c.@checked = true;
                        return true;
                    }
                }
            }

            return false;
        }

        public bool ClickElement(String strTag, String strText, String strValue, String strName, String strID, bool wait, String strSource, String strAlt, String strHref)
        {
            try
            {
                HtmlDocument xDoc = wb.Document;
                if (ClickElementDocument(xDoc, strTag, strText, strValue, strName, strID, wait, strSource, strAlt, strHref))
                    return true;

                //frames
                Object odoc = wb.Document.DomDocument;
                mshtml.IHTMLDocument2 ddoc = (mshtml.IHTMLDocument2)odoc;
                mshtml.IHTMLFramesCollection2 frames = (ddoc).frames;
                mshtml.IHTMLFrameElement f;

                for (int j = 0; j < frames.length; j++)
                {
                    try
                    {
                        Int32 n = Convert.ToInt32(j);
                        Object oFrameIndex = (Object)(n);
                        mshtml.IHTMLWindow2 frame = (mshtml.IHTMLWindow2)(frames.item(ref oFrameIndex));

                        Object d = frame.document;

                        mshtml.IHTMLDocument2 frameDoc = (mshtml.IHTMLDocument2)(d);
                        if (ClickElementDocument((mshtml.IHTMLDocument2)frameDoc, strTag, strText, strValue, strName, strID, wait, strSource, strAlt, strHref))
                            return true;
                    }
                    catch (Exception e)
                    { }
                }

                return false;
            }
            catch (Exception e)
            {
                //AddActivity("Error in ClickElement");
            }
            return false;
        }

        public bool ClickElementDocument(mshtml.IHTMLDocument2 xDoc, String strTag, String strText, String strValue, String strName, String strID, bool wait, String strSource, String strAlt, String strHref)
        {
            mshtml.IHTMLElement body;
            body = xDoc.body;

            mshtml.IHTMLElementCollection col = (mshtml.IHTMLElementCollection)(body.all);

            IEnumerator en = col.GetEnumerator();

            mshtml.IHTMLElement ele;
            mshtml.IHTMLElement anc;
            String strhref;
            String strURL;
            mshtml.IHTMLInputElement inp;
            mshtml.IHTMLButtonElement b;
            mshtml.IHTMLImgElement i;
            mshtml.IHTMLAnchorElement a;

            bool yes;

            while (en.MoveNext())
            {
                ele = (mshtml.IHTMLElement)(en.Current);

                if (String.Compare(ele.tagName.ToLower(), strTag.ToLower()) == 0)
                {
                    anc = (mshtml.IHTMLElement)(ele);

                    yes = false;

                    if (Tools.Strings.StrExt(strText) && Tools.Strings.StrCmp(strText, anc.innerText))
                        yes = true;

                    if (Tools.Strings.StrExt(strID) && Tools.Strings.StrCmp(strID, anc.id))
                    {
                        yes = true;
                    }
                    else if (Tools.Strings.StrCmp(strTag, "a"))
                    {
                        a = (mshtml.IHTMLAnchorElement)(anc);

                        if (Tools.Strings.StrExt(strHref) && Tools.Strings.StrCmp(strHref, a.href))
                            yes = true;
                    }
                    else if (Tools.Strings.StrCmp(strTag, "input"))
                    {
                        inp = (mshtml.IHTMLInputElement)(anc);

                        String st = inp.name;

                        if (Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, inp.name))
                            yes = true;

                        if (Tools.Strings.StrExt(strValue) && Tools.Strings.StrCmp(strValue, inp.value))
                            yes = true;

                        if (Tools.Strings.StrExt(strSource) && Tools.Strings.HasString(inp.src, strSource))
                            yes = true;

                        if (Tools.Strings.StrExt(strAlt) && Tools.Strings.HasString(inp.alt, strAlt))
                            yes = true;
                    }
                    else if (Tools.Strings.StrCmp(strTag, "button"))
                    {
                        b = (mshtml.IHTMLButtonElement)anc;
                        if (Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, b.name))
                            yes = true;

                        if (Tools.Strings.StrExt(strValue) && Tools.Strings.StrCmp(strValue, b.value))
                            yes = true;
                    }

                    else if (Tools.Strings.StrCmp(strTag, "img"))
                    {
                        i = (mshtml.IHTMLImgElement)anc;

                        if (Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, i.name))
                            yes = true;

                        if (Tools.Strings.StrExt(strSource) && Tools.Strings.HasString(i.src, strSource))
                            yes = true;
                    }

                    if (yes)
                    {
                        //AddActivity(String.Concat(S"Clicking ", strText, strValue, strName, strID, S"..."));
                        anc.click();
                        if (wait)
                            return WaitForDone();
                        else
                            return true;
                    }
                }
            }

            mshtml.IHTMLFramesCollection2 frames = xDoc.frames;
            mshtml.IHTMLFrameElement f;

            for (int j = 0; j < frames.length; j++)
            {

                Int32 n = Convert.ToInt32(j);
                Object oFrameIndex = (Object)n;
                mshtml.IHTMLWindow2 frame = (mshtml.IHTMLWindow2)(frames.item(ref oFrameIndex));

                Object d = frame.document;

                try
                {
                    mshtml.IHTMLDocument2 frameDoc = (mshtml.IHTMLDocument2)(d);

                    if (ClickElementDocument(frameDoc, strTag, strText, strValue, strName, strID, wait, strSource, strAlt, strHref))
                        return true;
                }
                catch (Exception e)
                {
                    int k = 0;
                }
            }
            return false;
        }

        public bool ClickElement(String strTag, String strText, String strValue, String strName, String strID, String strAlt, bool wait)
        {
            return ClickElement(strTag, strText, strValue, strName, strID, wait, "", strAlt, "");
        }

        public bool ClickElement(String strTag, String strText, String strValue, String strName, String strID, bool wait, String strSource)
        {
            return ClickElement(strTag, strText, strValue, strName, strID, wait, strSource, "", "");
        }


        public bool ClickLink(String strText, String strValue, String strName, String strID, bool wait, String strHref)
        {
            try
            {
                return ClickElement("a", strText, strValue, strName, strID, wait, "", "", strHref);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ClickButton(String strText, String strValue, String strName, String strID, bool wait)
        {
            if (ClickElement("input", strText, strValue, strName, strID, wait, ""))
                return true;
            else
                return ClickElement("button", strText, strValue, strName, strID, wait, "");
        }

        public bool SetTextBoxDocument(HtmlDocument xDoc, String strName, String strText)
        {
            try
            {
                HtmlElement body;

                body = xDoc.Body;

                HtmlElementCollection col = body.All;

                mshtml.IHTMLInputElement inp;
                mshtml.IHTMLTextAreaElement tx;
                mshtml.IHTMLSelectElement se;


                bool yes;

                foreach (HtmlElement ele in col)
                {
                    if (Tools.Strings.StrCmp(ele.TagName, "input"))
                    {
                        yes = false;
                        String st = ele.Name;

                        inp = (mshtml.IHTMLInputElement)ele.DomElement;
                        if (Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, st) && !Tools.Strings.StrCmp(inp.type, "hidden"))  // 
                            yes = true;

                        if (yes)
                        {
                            inp.value = strText;
                            return true;
                        }
                    }
                    else if (String.Compare(ele.TagName.ToLower(), "textarea") == 0)
                    {

                        tx = (mshtml.IHTMLTextAreaElement)(ele.DomElement);
                        yes = false;

                        if (Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, tx.name))
                            yes = true;

                        if (yes)
                        {
                            tx.value = strText;
                            return true;
                        }
                    }
                    else if (String.Compare(ele.TagName.ToLower(), "select") == 0)
                    {

                        se = (mshtml.IHTMLSelectElement)ele.DomElement;
                        yes = false;

                        if (Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, se.name))
                            yes = true;

                        if (yes)
                        {

                            se.value = strText;
                            return true;
                            //mshtml.IHTMLOptionsHolder hold = (mshtml.IHTMLOptionsHolder)se.options
                            //for (int g = 0; g < hold.length - 1; g++)
                            //{
                            //    if (Tools.Strings.StrCmp(se.options[g], strText))
                            //    {
                            //        se.selectedIndex = g;
                            //        return true;
                            //    }
                            //}
                        }
                    }
                }

                //mshtml.IHTMLFramesCollection2 frames = xDoc.frames;

                //Object fr = xDoc.frames;

                //mshtml.IHTMLFramesCollection2 frames = (mshtml.IHTMLFramesCollection2)xDoc.frames;
                ////mshtml.FramesCollection frames = xDoc.frames;
                //mshtml.IHTMLFrameElement f;

                //for( int j=0; j<frames.length ; j++ )
                //{

                //    Int32 n = Convert.ToInt32(j);
                //    Object oFrameIndex = (Object)(n); 
                //    mshtml.IHTMLWindow2 frame = (mshtml.IHTMLWindow2)(frames.item(ref oFrameIndex)); 

                //    Object d = frame.document;

                //    try
                //    {
                //        HtmlDocument frameDoc = (HtmlDocument)d;

                //        if( SetTextBoxDocument(frameDoc, strName, strText) )
                //            return true;
                //    }
                //    catch(Exception e)
                //    {
                //        int k=0;
                //    }
                //}

                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool SetTextBoxDocument(mshtml.IHTMLDocument2 xDoc, String strName, String strText)
        {
            try
            {
                mshtml.IHTMLElement body;

                body = xDoc.body;

                mshtml.IHTMLElementCollection col = (mshtml.IHTMLElementCollection)(body.all);

                IEnumerator en = col.GetEnumerator();

                mshtml.IHTMLElement ele;
                mshtml.IHTMLElement anc;
                String strhref;
                String strURL;
                mshtml.IHTMLInputElement inp;
                mshtml.IHTMLTextAreaElement tx;
                mshtml.IHTMLSelectElement se;

                bool yes;

                while (en.MoveNext())
                {
                    ele = (mshtml.IHTMLElement)(en.Current);

                    String s = ele.tagName;

                    if (String.Compare(ele.tagName.ToLower(), "input") == 0)
                    {
                        inp = (mshtml.IHTMLInputElement)(ele);
                        yes = false;

                        String st = inp.name;

                        if (Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, inp.name) && (!Tools.Strings.StrCmp(inp.type, "hidden")))
                            yes = true;

                        //if (Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, inp.id))
                        //    yes = true;

                        if (yes)
                        {
                            inp.value = strText;
                            return true;
                        }
                    }
                    else if (String.Compare(ele.tagName.ToLower(), "textarea") == 0)
                    {

                        tx = (mshtml.IHTMLTextAreaElement)(ele);
                        yes = false;

                        if (Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, tx.name))
                            yes = true;

                        if (yes)
                        {
                            tx.value = strText;
                            return true;
                        }
                    }
                    else if (String.Compare(ele.tagName.ToLower(), "select") == 0)
                    {

                        se = (mshtml.IHTMLSelectElement)(ele);
                        yes = false;

                        if (Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, se.name))
                            yes = true;

                        if (yes)
                        {

                            se.value = strText;
                            return true;
                            //mshtml.IHTMLOptionsHolder hold = (mshtml.IHTMLOptionsHolder)se.options
                            //for (int g = 0; g < hold.length - 1; g++)
                            //{
                            //    if (Tools.Strings.StrCmp(se.options[g], strText))
                            //    {
                            //        se.selectedIndex = g;
                            //        return true;
                            //    }
                            //}
                        }
                    }
                }

                //mshtml.IHTMLFramesCollection2 frames = xDoc.frames;

                Object fr = xDoc.frames;

                mshtml.IHTMLFramesCollection2 frames = (mshtml.IHTMLFramesCollection2)xDoc.frames;
                //mshtml.FramesCollection frames = xDoc.frames;
                mshtml.IHTMLFrameElement f;

                for (int j = 0; j < frames.length; j++)
                {

                    Int32 n = Convert.ToInt32(j);
                    Object oFrameIndex = (Object)(n);
                    mshtml.IHTMLWindow2 frame = (mshtml.IHTMLWindow2)(frames.item(ref oFrameIndex));

                    Object d = frame.document;

                    try
                    {
                        mshtml.IHTMLDocument2 frameDoc = (mshtml.IHTMLDocument2)(d);

                        if (SetTextBoxDocument(frameDoc, strName, strText))
                            return true;
                    }
                    catch (Exception e)
                    {
                        int k = 0;
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public String GetTextBoxDocument(HtmlDocument xDoc, String strName)
        {

            try
            {
                HtmlElement body;

                body = xDoc.Body;

                HtmlElementCollection col = body.All;

                IEnumerator en = col.GetEnumerator();

                mshtml.IHTMLElement ele;
                mshtml.IHTMLInputElement inp;
                mshtml.IHTMLTextAreaElement tx;

                bool yes;

                while (en.MoveNext())
                {
                    ele = (mshtml.IHTMLElement)(en.Current);

                    String s = ele.tagName;

                    if (String.Compare(ele.tagName.ToLower(), "input") == 0)
                    {
                        inp = (mshtml.IHTMLInputElement)(ele);
                        yes = false;

                        if (Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, inp.name) && (!Tools.Strings.StrCmp(inp.type, "hidden")))
                            yes = true;

                        if (yes)
                        {
                            //inp.value = strText;
                            return inp.value;
                        }
                    }
                    else if (String.Compare(ele.tagName.ToLower(), "textarea") == 0)
                    {

                        tx = (mshtml.IHTMLTextAreaElement)(ele);
                        yes = false;

                        if (Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, tx.name))
                            yes = true;

                        if (yes)
                        {
                            //tx.value = strText;
                            return tx.value;
                        }
                    }
                }

                //mshtml.IHTMLFramesCollection2 frames = xDoc.frames;

                //Object fr = xDoc.frames;

                //mshtml.IHTMLFramesCollection2 frames = (mshtml.IHTMLFramesCollection2)xDoc.frames;
                ////mshtml.FramesCollection frames = xDoc.frames;
                //mshtml.IHTMLFrameElement f;

                //for (int j = 0; j < frames.length; j++)
                //{

                //    Int32 n = Convert.ToInt32(j);
                //    Object oFrameIndex = (Object)(n);
                //    mshtml.IHTMLWindow2 frame = (mshtml.IHTMLWindow2)(frames.item(ref oFrameIndex));

                //    Object d = frame.document;

                //    String st;
                //    try
                //    {
                //        HtmlDocument frameDoc = (HtmlDocument)d;

                //        st = GetTextBoxDocument(frameDoc, strName);
                //        if (Tools.Strings.StrExt(st))
                //            return st;
                //        //if (SetTextBoxDocument(frameDoc, strName, strText))
                //        //    return true;
                //    }
                //    catch (Exception e)
                //    {
                //        int k = 0;
                //    }
                //}

                return "";
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public bool SetTextBox(String strName, String strText)
        {
            try
            {
                if (SetTextBoxDocument(wb.Document, strName, strText))
                    return true;
            }
            catch (Exception)
            {
                return false;
            }

            //frames
            Object odoc = wb.Document.DomDocument;
            mshtml.IHTMLDocument2 ddoc = (mshtml.IHTMLDocument2)odoc;
            mshtml.IHTMLFramesCollection2 frames = (ddoc).frames;
            mshtml.IHTMLFrameElement f;

            for (int j = 0; j < frames.length; j++)
            {
                try
                {
                    Int32 n = Convert.ToInt32(j);
                    Object oFrameIndex = (Object)(n);
                    mshtml.IHTMLWindow2 frame = (mshtml.IHTMLWindow2)(frames.item(ref oFrameIndex));

                    Object d = frame.document;

                    mshtml.IHTMLDocument2 frameDoc = (mshtml.IHTMLDocument2)(d);
                    if (SetTextBoxDocument((mshtml.IHTMLDocument2)frameDoc, strName, strText))
                        return true;
                }
                catch (Exception e)
                { }
            }

            return false;
        }

        public String GetTextBox(String strName)
        {
            HtmlDocument xDoc = wb.Document;
            return GetTextBoxDocument(xDoc, strName);
        }

        private void wb_DocumentComplete(object sender, AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent e)
        {

            LastBusy = System.DateTime.Now;
            //lblLocation.Text = e.uRL.ToString();

            try
            {
                HtmlDocument doc = wb.Document;
                //doc.body.insertAdjacentHTML("afterBegin", "&#xa0;<SCRIPT For='window' Event='onerror'>var noOp = null;</SCRIPT>");
            }
            catch
            {

            }

            //try
            //{

            //    SHDocVw.IWebBrowser2 doc = (SHDocVw.IWebBrowser2)(e.pDisp);
            //    AxSHDocVw.AxWebBrowser send;
            //    send = (AxSHDocVw.AxWebBrowser)(sender);

            //    if ((AxSHDocVw.AxWebBrowser)(doc) == send)
            //    {
            //        IsBusy = false;

            //    }
            //}
            //catch (Exception)
            //{ 
            //}

            //AddActivity(e.uRL.ToString());
        }

        //private void wb_ProgressChange(object sender, AxSHDocVw.DWebBrowserEvents2_ProgressChangeEvent e)
        //{
        //    lblProgress.Text = Convert.ToString(Math.Round((Convert.ToDecimal(e.progress) / Convert.ToDecimal(e.progressMax)) * 100, 0)) + "%";
        //}

        //private void wb_StatusTextChange(object sender, AxSHDocVw.DWebBrowserEvents2_StatusTextChangeEvent e)
        //{
        //    lblStatus.Text = e.text;
        //}

        private void Search_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public virtual void DoResize()
        {
            try
            {
                wb.Left = 0;
                wb.Width = this.ClientRectangle.Width;
                wb.Height = this.ClientRectangle.Height - (wb.Top + sb.Height);
            }
            catch (Exception)
            {

            }
        }

        public bool WaitForSetText(String strName, String strVal)
        {
            DoEvents();
            System.Threading.Thread.Sleep(100);
            DateTime start = System.DateTime.Now;
            System.TimeSpan t;

            for (int i = 0; i < 1000; i++)
            {
                DoEvents();
                System.Threading.Thread.Sleep(200);
                Application.DoEvents();

                if (!this.SetTextBox(strName, strVal))
                    i = 0;
                else
                    return true;

                t = System.DateTime.Now - start;
                if (t.TotalSeconds > 20)
                    return false;
            }
            return true;
        }

        public bool SuppressNewWindows = false;

        protected virtual void cmdMainPage_Click(object sender, EventArgs e)
        {
            InitWebsite();
        }

        private String GrabDocumentHTML(HtmlDocument xDoc, int intBase, bool textonly)
        {
            StringBuilder sb = new StringBuilder();

            HtmlElement body;
            body = xDoc.Body;

            if (textonly)
                sb.Append(body.InnerText);
            else
                sb.Append(body.InnerHtml);

            //mshtml.IHTMLFramesCollection2 frames = xDoc.frames;
            //mshtml.IHTMLFrameElement f;

            //for( int j=0; j<frames.length ; j++ )
            //{
            //    try
            //    {
            //        Int32 n = Convert.ToInt32(j);
            //        Object oFrameIndex = (Object)(n); 
            //        mshtml.IHTMLWindow2 frame = (mshtml.IHTMLWindow2)(frames.item(ref oFrameIndex)); 

            //        Object d = frame.document;

            //        mshtml.IHTMLDocument2 frameDoc = (mshtml.IHTMLDocument2)(d);
            //        sb.Append("\r\n");
            //        sb.Append(String.Concat("<recognin frame break: ", Convert.ToString(intBase), ">"));
            //        sb.Append("\r\n");
            //        intBase++;
            //        sb.Append( GrabDocumentHTML( frameDoc, intBase, textonly ) );

            //    }
            //    catch(Exception e)
            //    {}
            //}
            return sb.ToString();
        }

        public String GetPageHTML(WebBrowser xwb)
        {
            if (xwb == null)
                xwb = wb;

            try
            {
                HtmlDocument xDoc = xwb.Document;
                return GrabDocumentHTML(xDoc, 0, false);
            }
            catch
            {
                return "";
            }
        }

        public String GetPageText(WebBrowser xwb)
        {
            if (xwb == null)
                xwb = wb;

            try
            {
                HtmlDocument xDoc = xwb.Document;
                return GrabDocumentHTML(xDoc, 0, true);
            }
            catch (Exception e)
            {
                return "";
            }
        }

        private void cmdText_Click(object sender, EventArgs e)
        {
            Tools.FileSystem.PopText(this.GetPageText(wb));
        }

        private void cmdHTML_Click(object sender, EventArgs e)
        {
            Tools.FileSystem.PopText(this.GetPageHTML(wb));
        }

        public void CheckStockDate()
        {
            String s = GetPageText(wb);
            if (!Tools.Strings.StrExt(s))
                return;

            if (!Tools.Strings.HasString(s, "2460199"))
                return;

            s = s.ToLower().Replace("@", " at ");
            s = s.Replace("2460199", "@");

            String[] a = s.Split("@".ToCharArray());

            String year = "";
            String month = "";
            String day = "";
            String hour = "";

            DateTime d;
            ArrayList dates = new ArrayList();

            foreach (String p in a)
            {
                try
                {
                    if (p.StartsWith(Tools.Strings.Right(DateTime.Now.Year.ToString(), 2)))
                    {
                        year = Tools.Strings.Left(p, 2);
                        month = p.Substring(2, 2);
                        day = p.Substring(4, 2);
                        hour = p.Substring(6, 2);

                        try
                        {
                            d = DateTime.Parse(month + "/" + day + "/" + year + " " + hour + ":00");
                            dates.Add((Object)d);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                catch (Exception)
                {
                }
            }

            if (dates.Count <= 0)
            {
                Program.SetStatus("No stock dates from " + this.ToString());
                return;
            }

            DateTime winner = DateTime.Now.Subtract(new TimeSpan(10, 0, 0, 0));

            foreach (DateTime x in dates)
            {
                if (x > winner)
                    winner = x;
            }

            Program.SetStatus("The latest stock date from " + this.ToString() + " is " + winner.ToString());

            Program.xData.Execute("delete from webstockcheck where site_name = '" + Program.xData.SyntaxFilter(this.ToString()) + "'", true);
            Program.xData.Execute("insert into webstockcheck( site_name, last_date) values ('" + Program.xData.SyntaxFilter(this.ToString()) + "', '" + winner.ToString() + "')");
        }

        public virtual void NavToPost(String type)
        {

        }

        private void cmdForward_Click(object sender, EventArgs e)
        {
            try
            {
                wb.GoForward();
            }
            catch (Exception)
            { }
        }

        private void Search_Click(object sender, EventArgs e)
        {

        }

        private void Search_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.XButton1)
            {
                try
                {
                    wb.GoBack();
                }
                catch (Exception) { }
            }

            if (e.Button == MouseButtons.XButton2)
            {
                try
                {
                    wb.GoForward();
                }
                catch (Exception) { }
            }
        }

        private void wb_BeforeNavigate2(object sender, AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2Event e)
        {
            if (HandleNavigate(e.uRL.ToString()))
                e.cancel = true;
        }

        public virtual bool HandleNavigate(String url)
        {
            try
            {
                String s;
                if (this.IsInitialized && !this.IsAbleToSearch)
                {
                    if (Tools.Strings.StrExt(this.UserName_Name))
                    {
                        s = GetTextBox(this.UserName_Name);
                        if (Tools.Strings.StrExt(s))
                            Tools.OperatingSystem.DropCrumb(this.ToString() + "_user", s);
                    }

                    if (Tools.Strings.StrExt(this.Password_Name))
                    {
                        s = GetTextBox(this.Password_Name);
                        if (Tools.Strings.StrExt(s))
                            Tools.OperatingSystem.DropCrumb(this.ToString() + "_pass", s);
                    }

                    if (Tools.Strings.StrExt(this.SecondPassword_Name))
                    {
                        s = GetTextBox(this.SecondPassword_Name);
                        if (Tools.Strings.StrExt(s))
                            Tools.OperatingSystem.DropCrumb(this.ToString() + "_pass2", s);
                    }
                }
            }
            catch (Exception)
            { }

            return false;
        }

        private void wb_NavigateError(object sender, AxSHDocVw.DWebBrowserEvents2_NavigateErrorEvent e)
        {

        }

        protected virtual void cmdLogin_Click(object sender, EventArgs e)
        {
            EnterLoginInfo();
        }

        private void cmdPostRFQs_Click(object sender, EventArgs e)
        {
            NavToPost("rfqs");
        }

        protected virtual void cmdPOstOffers_Click(object sender, EventArgs e)
        {
            NavToPost("offers");
        }

        private void cmdCheckBoxes_Click(object sender, EventArgs e)
        {
            CheckAllBoxes();
        }

        public virtual void CheckAllBoxes()
        {

        }
        public virtual void ScrapeBids()
        {

        }
        private void cmdScrapeBid_Click(object sender, EventArgs e)
        {
            ScrapeBids();
        }
        public String ParseCellText(mshtml.HTMLTableRow r, int i)
        {
            try
            {
                return GetCellText(r, i);
            }
            catch (Exception)
            {
                return "";
            }
        }
        public long ParseCellLong(mshtml.HTMLTableRow r, int i)
        {
            try
            {
                String s = GetCellText(r, i);
                if (Tools.Number.IsNumeric(s))
                    return Convert.ToInt64(s);
                else
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public Double ParseCellDouble(mshtml.HTMLTableRow r, int i)
        {
            try
            {
                String s = GetCellText(r, i).Replace("$", "").Trim();
                s = nTools.StripNonNumeric(s, true);
                if (Tools.Number.IsNumeric(s))
                    return Convert.ToDouble(s);
                else
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public DateTime ParseCellDate(mshtml.HTMLTableRow r, int i)
        {
            try
            {
                String s = GetCellText(r, i);
                if (Tools.Dates.IsDate(s))
                    return Convert.ToDateTime(s);
                else
                    return Tools.Dates.GetNullDate();
            }
            catch (Exception)
            {
                return Tools.Dates.GetNullDate();
            }
        }
        public String GetCellText(mshtml.HTMLTableRow r, int i)
        {
            int j = 0;
            foreach (mshtml.IHTMLElement cell in r.cells)
            {
                if (j == i)
                {
                    if (cell.innerText != null)
                        return cell.innerText.Trim();
                    else
                        return "";
                }
                j++;
            }
            return "";
        }
        public mshtml.IHTMLElement GetCell(mshtml.HTMLTableRow r, int i)
        {
            int j = 0;
            foreach (mshtml.IHTMLElement cell in r.cells)
            {
                if (j == i)
                {
                    return cell;
                }
                j++;
            }
            return null;
        }
        private void wb_NewWindow(object sender, CancelEventArgs e)
        {
            if (SuppressNewWindows)
                e.Cancel = true;
        }

        void AxWebBrowser_NewWindow2(ref object ppDisp, ref bool Cancel)
        {
            if (SuppressNewWindows)
            {
                Cancel = true;
            }
            else
            {
                FormBrowser xForm = new FormBrowser();
                xForm.Show();
                xForm.GetWB().RegisterAsBrowser = true;
                ppDisp = xForm.GetWB().Application;
            }
        }

        void AxWebBrowser_NewWindow3(ref object ppDisp, ref bool Cancel, uint dwFlags, string bstrUrlContext, string bstrUrl)
        {
            if (SuppressNewWindows)
            {
                Cancel = true;
            }
            else
            {
                FormBrowser xForm = new FormBrowser();
                xForm.Show();
                xForm.GetWB().RegisterAsBrowser = true;
                ppDisp = xForm.GetWB().Application;
            }
        }
        private void wb_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            long p = Tools.Number.CalcPercent(e.MaximumProgress, e.CurrentProgress);
            if (p > 100)
                p = 100;

            if (p == 100 || p == 0)
                lblProgress.Text = "Done";
            else
                lblProgress.Text = "Progress: " + p.ToString() + "%";
        }
        private void wb_LocationChanged(object sender, EventArgs e)
        {
            //lblLocation.Text = wb.Url.AbsoluteUri;
        }

        //Set Status Icon
        private void SetStatusIcon(StatusIcon key)
        {
            if (Tools.Strings.StrCmp(MyTab.ImageKey.ToString().ToLower().Trim(), key.ToString().ToLower().Trim()))
                return;
            switch (key)
            {
                case StatusIcon.Null:
                case StatusIcon.Ready:
                    ShowReady();
                    break;
                case StatusIcon.Auto:
                    ShowReady(true);
                    break;
                case StatusIcon.Busy:
                    ShowBusy();
                    break;
                case StatusIcon.Results:
                    ShowResult(StatusIcon.Results);
                    break;
                case StatusIcon.NoResults:
                    ShowResult(StatusIcon.NoResults);
                    break;
                case StatusIcon.Error:
                    ShowError();
                    break;
            }
        }
        private bool tmrStatusIconRunning = false;
        private void wb_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            ShowBusy();
        }
        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            IsBusy = false;
            SetStatusIconTimer();
        }
        public virtual void AfterSearch()
        {
            SetStatusIconTimer(StatusIcon.Null);
        }
        public virtual void SetStatusIconTimer()
        {
            SetStatusIcon(StatusIcon.Null);
        }
        public virtual void SetStatusIconTimer(StatusIcon key)
        {
            switch (key)
            {
                case StatusIcon.Null:
                case StatusIcon.Auto:
                case StatusIcon.Ready:
                case StatusIcon.Busy:
                    z_StatusKey = key;
                    tmrStatusIcon.Stop();
                    tmrStatusIcon.Interval = 1000;
                    tmrStatusIcon.Start();
                    tmrStatusIconRunning = true;
                    break;
                case StatusIcon.Results:
                case StatusIcon.NoResults:
                case StatusIcon.Error:
                    z_ResultKey = key;
                    tmrIcon.Stop();
                    tmrIcon.Interval = 3000;
                    tmrIcon.Start();
                    break;
            }
        }
        public virtual void ShowError()
        {
            RzWin.Leader.Comment("Error in " + this.ToString());
            MyTab.ImageKey = StatusIcon.Error.ToString().ToLower().Trim();
        }
        public virtual void ShowBusy()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            pic.BackColor = Color.Red;
            MyTab.ImageKey = "busy";
            MyTab.Text = this.ToString();
        }
        public virtual void ShowReady()
        {
            ShowReady(false);
        }
        public virtual void ShowReady(bool auto)
        {
            IsBusy = false;
            pic.BackColor = Color.Blue;
            if (auto)
                MyTab.ImageKey = "auto";
            else
                MyTab.ImageKey = "ready";
            MyTab.Text = this.ToString();
            if (this.IsAbleToSearch)
                pic.BackColor = Color.Green;
        }
        public virtual void ShowResult(StatusIcon result)
        {
            MyTab.ImageKey = result.ToString().ToLower().Trim();
            HasSearched = false;
        }
        private void tmrIcon_Tick(object sender, EventArgs e)
        {
            tmrIcon.Stop();
            if (tmrStatusIconRunning)
            {
                tmrIcon.Interval = 1000;
                tmrIcon.Start();
                return;
            }
            if (Tools.Strings.StrCmp(MyTab.ImageKey.ToString().ToLower().Trim(), z_ResultKey.ToString().ToLower().Trim()))
                return;
            SetStatusIcon(z_ResultKey);
        }
        private void tmrStatusIcon_Tick(object sender, EventArgs e)
        {
            tmrStatusIcon.Stop();
            tmrStatusIconRunning = false;
            if (Tools.Strings.StrCmp(MyTab.ImageKey.ToString().ToLower().Trim(), z_StatusKey.ToString().ToLower().Trim()))
                return;
            SetStatusIcon(z_StatusKey);
        }


    }
    public enum xtagREADYSTATE
    {
        READYSTATE_UNINITIALIZED = 0,
        READYSTATE_LOADING = 1,
        READYSTATE_LOADED = 2,
        READYSTATE_INTERACTIVE = 3,
        READYSTATE_COMPLETE = 4,
    }
    public enum StatusIcon
    {
        Null = -1, //Null
        Ready = 0, //Start Status of Tab
        Auto = 1, //Auto Searching of Tab
        Busy = 2, //Running/Searching
        Error = 3, //Error on Tab
        Results = 4, //Results Found
        NoResults = 5, //No Results Found
    }
    public static class Program
    {

        public static MultiSearchScreen MainForm;
        public static StatusScreen xStatus;
        public static DataConnectionSqlServer xData;
        public static String userid = "";
        public static bool IgnoreActivity = false;
        public static bool SkipData = false;

        public static void SetStatus(String NewStatus)
        {
            xStatus.SetStatus(NewStatus);
        }
    }
}
