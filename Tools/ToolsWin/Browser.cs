
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Tools;

namespace ToolsWin
{
    public partial class Browser : UserControl
    {
        public event OnNavigateHandler OnNavigate;
        public event OnNavigate2Handler OnNavigate2;
        public event OnNavigateHandler NavigateComplete;
        public event OnNavigateHandler zz_StatusChange;
        public event OnNavigateHandler zz_ProgressChange;
        public event OnNavigateHandler zz_LocationChange;
        public bool m_Silent;
        public String UserAgent = "";
        StringBuilder added = null;
        public bool ReloadedHasBeen = false;
        public bool Silent
        {
            get
            {
                return m_Silent;
            }
            set
            {
                m_Silent = value;
            }
        }

        public bool m_ShowControls = false;
        public bool ShowControls
        {
            get
            {
                return m_ShowControls;
            }
            set
            {
                m_ShowControls = value;
                DoResize();
            }
        }
        public bool ShowBackButton
        {
            get
            {
                return cmdBack.Visible;
            }
            set
            {
                cmdBack.Visible = value;
            }
        }

        public Browser()
        {
            try
            {
                InitializeComponent();
            }
            catch { }
            //wb.RegisterAsBrowser = true;
        }
        public void Navigate(String strURL)
        {
            try
            {
                //Object empty = null;
                //wb.Silent = Silent;
                //wb.Navigate(strURL, ref empty, ref empty, ref empty, ref empty);

                Navigate(strURL, "");
            }
            catch(Exception)
            {
            }
        }
        public void Navigate(String strURL, String PostData)
        {
            try
            {
                wb.Silent = Silent;
                Byte[] b = null;
                if( Tools.Strings.StrExt(PostData) )
                    b = ASCIIEncoding.ASCII.GetBytes(PostData);
                Object ob = (Object)b;
                String strHeader = "Content-Type: application/x-www-form-urlencoded\r\n";

                if (Tools.Strings.StrExt(UserAgent))
                {
                    strHeader += "User-Agent: " + UserAgent + "\r\n";
                }

                Object oHeader = (Object)strHeader;
                Object empty = null;
                Object strURLx = strURL;
                wb.Navigate2(ref strURLx, ref empty, ref empty, ref ob, ref oHeader);
            }
            catch(Exception)
            {
            }
        }
        public void Clear()
        {
            Navigate("about:blank");
            //wb.Navigate("http://www.recognin.com/blank.htm");
            //mshtml.IHTMLDocument2 doc = GetDocument();
            //doc.clear();
        }

        public AxSHDocVw.AxWebBrowser GetWB()
        {

            return wb;
        }

        public void Close()
        {
            //mshtml.IHTMLDocument2 doc = GetDocument();
            //doc.close();
        }
        public void ReloadWB()
        {
            //remove it
            try
            {
                this.Controls.Remove(this.wb);
                this.wb.BeforeNavigate2 -= new AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2EventHandler(this.wb_BeforeNavigate2);
                this.wb.NavigateComplete2 -= new AxSHDocVw.DWebBrowserEvents2_NavigateComplete2EventHandler(wb_NavigateComplete2);
                this.wb.NewWindow3 -= new AxSHDocVw.DWebBrowserEvents2_NewWindow3EventHandler(this.wb_NewWindow3);
                this.wb.Dispose();
                this.wb = null;
            }
            catch(Exception)
            {
            }
            added = new StringBuilder();
            this.wb = new AxSHDocVw.AxWebBrowser();
            ( (System.ComponentModel.ISupportInitialize)( this.wb ) ).BeginInit();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Browser));
            //this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Enabled = true;
            this.wb.Location = new System.Drawing.Point(0, 0);
            this.wb.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject("wb.OcxState") ) );
            this.wb.Size = new System.Drawing.Size(552, 474);
            this.wb.TabIndex = 0;
            this.wb.BeforeNavigate2 += new AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2EventHandler(this.wb_BeforeNavigate2);
            this.wb.NavigateComplete2 += new AxSHDocVw.DWebBrowserEvents2_NavigateComplete2EventHandler(wb_NavigateComplete2);
            this.wb.NewWindow3 += new AxSHDocVw.DWebBrowserEvents2_NewWindow3EventHandler(this.wb_NewWindow3);
            this.Controls.Add(this.wb);
            ( (System.ComponentModel.ISupportInitialize)( this.wb ) ).EndInit();
            wb.Silent = Silent;
            Clear();
            DoResize();
            ReloadedHasBeen = true;
        }

        public void SetHTML(String strHTML)
        {
            Clear();
            mshtml.IHTMLDocument2 doc = (mshtml.IHTMLDocument2)wb.Document;
            doc.writeln(strHTML);
        }
        public void Add(String strHTML)
        {
            try
            {
                mshtml.IHTMLDocument2 doc = (mshtml.IHTMLDocument2)wb.Document;
                doc.writeln(strHTML);
                if( added != null )
                    added.Append(strHTML);
            }
            catch(Exception)
            {
            }
        }
        public String GetURL()
        {
            try
            {
                return wb.LocationURL;
            }
            catch
            {
                return "";
            }
        }
        public bool WaitForDone()
        {
            try
            {
                int j = 0;
                for(int i = 0 ; i < 20 ; i++)
                {
                    try
                    {
                        System.Windows.Forms.Application.DoEvents();
                        System.Threading.Thread.Sleep(100);
                        if( wb.ReadyState != SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE )
                            i = 0;
                    }
                    catch
                    {
                    }
                    j++;
                    if( j > 100 )
                        return false;
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool WaitForDoneFast()
        {
            try
            {
                int j = 0;
                for (int i = 0; i < 20; i++)
                {
                    try
                    {
                        System.Windows.Forms.Application.DoEvents();
                        System.Threading.Thread.Sleep(10);
                        if (wb.ReadyState != SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE)
                            i = 0;
                    }
                    catch
                    {
                    }
                    j++;
                    if (j > 100)
                        return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool GoBack()
        {
            try
            {
                wb.GoBack();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public bool GoForward()
        {
            try
            {
                wb.GoForward();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        private String GrabDocumentHTML(mshtml.IHTMLDocument2 xDoc, int intBase, bool textonly, bool outer)
        {
            StringBuilder sb = new StringBuilder();

            
         

            try
            {
                mshtml.IHTMLElement body;
                body = xDoc.body;
                if (outer)
                {
                    mshtml.IHTMLDocument3 d3 = (mshtml.IHTMLDocument3)xDoc;
                    sb.Append(d3.documentElement.outerHTML);

                    //foreach(Object x in xDoc.all)
                    //{
                    //    //sb.Append(((mshtml.IHTMLElement)xDoc.all. item("", 0).outerHTML);
                    //    sb.Append(((mshtml.IHTMLElement)x).outerHTML);
                    //}
                }
                else if (textonly)
                    sb.Append(body.innerText);
                else
                    sb.Append(body.innerHTML);
                mshtml.IHTMLFramesCollection2 frames = xDoc.frames;
                //mshtml.IHTMLFrameElement f;
                for (int j = 0; j < frames.length; j++)
                {
                    try
                    {
                        Int32 n = Convert.ToInt32(j);
                        Object oFrameIndex = (Object)(n);
                        mshtml.IHTMLWindow2 frame = (mshtml.IHTMLWindow2)(frames.item(ref oFrameIndex));
                        Object d = frame.document;
                        mshtml.IHTMLDocument2 frameDoc = (mshtml.IHTMLDocument2)(d);
                        sb.Append("\r\n");
                        sb.Append(String.Concat("<recognin frame break: ", Convert.ToString(intBase), ">"));
                        sb.Append("\r\n");
                        intBase++;
                        sb.Append(GrabDocumentHTML(frameDoc, intBase, textonly, outer));
                    }
                    catch
                    {
                    }
                }
            }
            catch { }
            return sb.ToString();
        }

        public String GetPageHTML()
        {
            return GetPageHTML(false);
        }
        public String GetPageHTML(bool outer)
        {
            try
            {
                mshtml.IHTMLDocument2 xDoc = (mshtml.IHTMLDocument2)( wb.Document );
                return GrabDocumentHTML(xDoc, 0, false, outer);
            }
            catch
            {
                return "";
            }
        }
        public String GetPageText()
        {
            try
            {
                mshtml.IHTMLDocument2 xDoc = (mshtml.IHTMLDocument2)( wb.Document );
                return GrabDocumentHTML(xDoc, 0, true, false);
            }
            catch
            {
                return "";
            }
        }
        public void Print()
        {
            try
            {
                wb.ExecWB(SHDocVw.OLECMDID.OLECMDID_PRINT, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT);
            }
            catch(Exception)
            {
            }
        }
        public mshtml.IHTMLDocument2 GetDocument()
        {
            try
            {
                return (mshtml.IHTMLDocument2)wb.Document;
            }
            catch(Exception)
            {
                return null;
            }
        }
        public bool ClickElementDocument(mshtml.IHTMLDocument2 xDoc, String strTag, String strText, String strValue, String strName, String strID, bool wait, String strSource, String strHref)
        {
            mshtml.IHTMLElement body = xDoc.body;
            mshtml.IHTMLElementCollection col = (mshtml.IHTMLElementCollection)( body.all );
            IEnumerator en = col.GetEnumerator();
            mshtml.IHTMLElement ele;
            mshtml.IHTMLElement anc;
            //String strhref;
            //String strURL;
            mshtml.IHTMLInputElement inp;
            mshtml.IHTMLButtonElement b;
            mshtml.IHTMLImgElement i;
            mshtml.IHTMLAnchorElement a;
            
            bool yes;
            while(en.MoveNext())
            {
                ele = (mshtml.IHTMLElement)( en.Current );
                if(String.Compare(ele.tagName.ToLower(), strTag.ToLower()) == 0)
                {
                    anc = (mshtml.IHTMLElement)( ele );
                    yes = false;
                    if(anc.innerHTML != null)
                    {
                        if(Tools.Strings.HasString(anc.innerText, "next"))
                        {;
                        }
                        if(Tools.Strings.HasString(anc.innerText, "more"))
                        {;
                        }
                    }
                    if (Tools.Strings.StrExt(strText) && Tools.Strings.StrCmp(strText, anc.innerText))
                    {
                        if (Tools.Strings.StrCmp(strTag, "A"))
                        {
                            a = (mshtml.IHTMLAnchorElement)( anc );
                            if (!Tools.Strings.StrExt(a.href))  //some sites have like <a>Next</a> that isn't really clickable
                                continue;
                        }
                        yes = true;
                    }
                    if(Tools.Strings.StrExt(strID) && Tools.Strings.StrCmp(strID, anc.id))
                    {
                        yes = true;
                    }
                    else if(Tools.Strings.StrCmp(strTag, "a"))
                    {
                        a = (mshtml.IHTMLAnchorElement)( anc );
                        if( Tools.Strings.StrExt(strHref) && Tools.Strings.HasString(a.href, strHref) )
                            yes = true;
                    }
                    else if(Tools.Strings.StrCmp(strTag, "input"))
                    {
                        inp = (mshtml.IHTMLInputElement)( anc );
                        if( Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, inp.name) )
                            yes = true;
                        if( Tools.Strings.StrExt(strValue) && Tools.Strings.StrCmp(strValue, inp.value) )
                            yes = true;
                        if( Tools.Strings.StrExt(strSource) && Tools.Strings.HasString(inp.src, strSource) )
                            yes = true;
                    }
                    else if(Tools.Strings.StrCmp(strTag, "button"))
                    {
                        b = (mshtml.IHTMLButtonElement)anc;
                        if( Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, b.name) )
                            yes = true;
                        if( Tools.Strings.StrExt(strValue) && Tools.Strings.StrCmp(strValue, b.value) )
                            yes = true;
                    }
                    else if(Tools.Strings.StrCmp(strTag, "img"))
                    {
                        i = (mshtml.IHTMLImgElement)anc;
                        if( Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, i.name) )
                            yes = true;
                        if( Tools.Strings.StrExt(strSource) && Tools.Strings.HasString(i.src, strSource) )
                            yes = true;
                        if( Tools.Strings.StrExt(strText) && Tools.Strings.HasString(i.src, strText) )
                            yes = true;
                    }
                    if(yes)
                    {
                        //AddActivity(String.Concat(S"Clicking ", strText, strValue, strName, strID, S"..."));
                        anc.click();
                        if(wait)
                        {
                            for(int j = 0 ; j < 20 ; j++)
                            {
                                if( WaitForDone() )
                                    return true;
                            }
                            return WaitForDone();
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            mshtml.IHTMLFramesCollection2 frames = xDoc.frames;
            //mshtml.IHTMLFrameElement f;
            for(int j = 0 ; j < frames.length ; j++)
            {
                Int32 n = Convert.ToInt32(j);
                Object oFrameIndex = (Object)n;
                mshtml.IHTMLWindow2 frame = (mshtml.IHTMLWindow2)( frames.item(ref oFrameIndex) );
                Object d = frame.document;
                try
                {
                    mshtml.IHTMLDocument2 frameDoc = (mshtml.IHTMLDocument2)( d );
                    if( ClickElementDocument(frameDoc, strTag, strText, strValue, strName, strID, wait, strSource, strHref) )
                        return true;
                }
                catch
                {
                    //int k = 0;
                }
            }
            return false;
        }
        public bool SetCheckBox(String strName)
        {
            return SetCheckBox(strName, "");
        }
        public bool SetCheckBox(String strName, String strValue)
        {
            mshtml.IHTMLDocument2 xDoc = (mshtml.IHTMLDocument2)( wb.Document );
            mshtml.IHTMLElement body;
            body = xDoc.body;
            mshtml.IHTMLElementCollection col = (mshtml.IHTMLElementCollection)( body.all );
            IEnumerator en = col.GetEnumerator();
            mshtml.IHTMLInputElement inp;
            mshtml.IHTMLElement ele;
            //mshtml.IHTMLElement anc;
            //String strhref;
            //String strURL;
            mshtml.IHTMLOptionButtonElement c;
            //bool yes;
            while(en.MoveNext())
            {
                ele = (mshtml.IHTMLElement)( en.Current );
                if(String.Compare(ele.tagName.ToLower(), "input") == 0)
                {
                    inp = (mshtml.IHTMLInputElement)( ele );
                    if (inp.name == null)
                        continue;
                    if(String.Compare(inp.name.ToLower(), strName.ToLower()) == 0)
                    {
                        String val = inp.value;
                        if (val == null)
                            val = "";
                        if(!Tools.Strings.StrExt(strValue) || Tools.Strings.StrCmp(strValue, val.ToLower()))
                        {
                            c = (mshtml.IHTMLOptionButtonElement)( ele );
                            c.@checked = true;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool ClickElement(String strTag, String strText, String strValue, String strName, String strID, bool wait, String strSource, String strHref)
        {
            try
            {
                mshtml.IHTMLDocument2 xDoc = (mshtml.IHTMLDocument2)( wb.Document );
                return ClickElementDocument(xDoc, strTag, strText, strValue, strName, strID, wait, strSource, strHref);
            }
            catch
            {
                //AddActivity("Error in ClickElement");
            }
            return false;
        }
        public bool ClickElement(String strTag, String strText, String strValue, String strName, String strID, bool wait)
        {
            return ClickElement(strTag, strText, strValue, strName, strID, wait, "", "");
        }
        public bool ClickElement(String strTag, String strText, String strValue, String strName, String strID, bool wait, String strSource)
        {
            return ClickElement(strTag, strText, strValue, strName, strID, wait, strSource, "");
        }
        public bool SetTextBoxDocument(mshtml.IHTMLDocument2 xDoc, String strName, String strText)
        {
            try
            {
                mshtml.IHTMLElement body;
                body = xDoc.body;
                mshtml.IHTMLElementCollection col = (mshtml.IHTMLElementCollection)( body.all );
                IEnumerator en = col.GetEnumerator();
                mshtml.IHTMLElement ele;
                //mshtml.IHTMLElement anc;
                //String strhref;
                //String strURL;
                mshtml.IHTMLInputElement inp;
                mshtml.IHTMLTextAreaElement tx;
                mshtml.IHTMLSelectElement se;
                bool yes;
                while(en.MoveNext())
                {
                    ele = (mshtml.IHTMLElement)( en.Current );
                    String s = ele.tagName;
                    if(String.Compare(ele.tagName.ToLower(), "input") == 0)
                    {
                        inp = (mshtml.IHTMLInputElement)( ele );
                        yes = false;
                        if( Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, inp.name) && ( !Tools.Strings.StrCmp(inp.type, "hidden") ) )
                            yes = true;
                        //if (Tools.Strings.StrCmp(inp.type, "file"))
                        //{
                        //    //mshtml.IHtmlEle
                        //}
                        //else
                        //{
                        if(yes)
                        {
                            inp.value = strText;
                            return true;
                        }
                        //}
                    }
                    else if(String.Compare(ele.tagName.ToLower(), "textarea") == 0)
                    {
                        tx = (mshtml.IHTMLTextAreaElement)( ele );
                        yes = false;
                        if( Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, tx.name) )
                            yes = true;
                        if(yes)
                        {
                            tx.value = strText;
                            return true;
                        }
                    }
                    else if(String.Compare(ele.tagName.ToLower(), "select") == 0)
                    {
                        se = (mshtml.IHTMLSelectElement)( ele );
                        yes = false;
                        if( Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, se.name) )
                            yes = true;
                        if(yes)
                        {
                            se.value = strText;
                            //if (se.onchange != DBNull.Value)
                            //{
                            //    mshtml.IHTMLElement e = se as mshtml.IHTMLElement;
                            //    mshtml.IHTMLDocument4 doc = e.document as mshtml.IHTMLDocument4;
                            //    object dummy = null;
                            //    object eventObj = doc.CreateEventObject(ref dummy);
                            //    mshtml.HTMLSelectElementClass see = se as mshtml.HTMLSelectElementClass;
                            //    see.FireEvent("onchange", ref eventObj);
                            //}
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
                //mshtml.IHTMLFrameElement f;
                for(int j = 0 ; j < frames.length ; j++)
                {
                    Int32 n = Convert.ToInt32(j);
                    Object oFrameIndex = (Object)( n );
                    mshtml.IHTMLWindow2 frame = (mshtml.IHTMLWindow2)( frames.item(ref oFrameIndex) );
                    Object d = frame.document;
                    try
                    {
                        mshtml.IHTMLDocument2 frameDoc = (mshtml.IHTMLDocument2)( d );
                        if( SetTextBoxDocument(frameDoc, strName, strText) )
                            return true;
                    }
                    catch
                    {
                        //int k = 0;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public String GetTextBoxDocument(mshtml.IHTMLDocument2 xDoc, String strName)
        {
            return GetTextBoxDocument(xDoc, strName, false);
        }
        public String GetTextBoxDocument(mshtml.IHTMLDocument2 xDoc, String strName, bool allow_hidden)
        {
            try
            {
                mshtml.IHTMLElement body;
                body = xDoc.body;
                mshtml.IHTMLElementCollection col = (mshtml.IHTMLElementCollection)( body.all );
                IEnumerator en = col.GetEnumerator();
                mshtml.IHTMLElement ele;
                //mshtml.IHTMLElement anc;
                //String strhref;
                //String strURL;
                mshtml.IHTMLInputElement inp;
                mshtml.IHTMLTextAreaElement tx;
                bool yes;
                while(en.MoveNext())
                {
                    ele = (mshtml.IHTMLElement)( en.Current );
                    String s = ele.tagName;
                    if(String.Compare(ele.tagName.ToLower(), "input") == 0)
                    {
                        inp = (mshtml.IHTMLInputElement)( ele );
                        yes = false;
                        if(allow_hidden)
                        {
                            if( Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, inp.name) )
                                yes = true;
                        }
                        else
                        {
                            if( Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, inp.name) && ( !Tools.Strings.StrCmp(inp.type, "hidden") ) )
                                yes = true;
                        }
                        if(yes)
                        {
                            //inp.value = strText;
                            return inp.value;
                        }
                    }
                    else if(String.Compare(ele.tagName.ToLower(), "textarea") == 0)
                    {
                        tx = (mshtml.IHTMLTextAreaElement)( ele );
                        yes = false;
                        if( Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, tx.name) )
                            yes = true;
                        if(yes)
                        {
                            //tx.value = strText;
                            return tx.value;
                        }
                    }
                }
                //mshtml.IHTMLFramesCollection2 frames = xDoc.frames;
                Object fr = xDoc.frames;
                mshtml.IHTMLFramesCollection2 frames = (mshtml.IHTMLFramesCollection2)xDoc.frames;
                //mshtml.FramesCollection frames = xDoc.frames;
                //mshtml.IHTMLFrameElement f;
                for(int j = 0 ; j < frames.length ; j++)
                {
                    Int32 n = Convert.ToInt32(j);
                    Object oFrameIndex = (Object)( n );
                    mshtml.IHTMLWindow2 frame = (mshtml.IHTMLWindow2)( frames.item(ref oFrameIndex) );
                    Object d = frame.document;
                    String st;
                    try
                    {
                        mshtml.IHTMLDocument2 frameDoc = (mshtml.IHTMLDocument2)( d );
                        st = GetTextBoxDocument(frameDoc, strName);
                        if( Tools.Strings.StrExt(st) )
                            return st;
                        //if (SetTextBoxDocument(frameDoc, strName, strText))
                        //    return true;
                    }
                    catch
                    {
                        //int k = 0;
                    }
                }
                return "";
            }
            catch
            {
                return "";
            }
        }
        public bool SetTextBox(String strName, String strText)
        {
            mshtml.IHTMLDocument2 xDoc = (mshtml.IHTMLDocument2)( wb.Document );
            return SetTextBoxDocument(xDoc, strName, strText);
        }
        public bool ClickButton(String strText, String strValue, String strName, String strID, bool wait)
        {
            if (ClickElement("input", strText, strValue, strName, strID, wait, ""))
                return true;
            else
                return ClickElement("button", strText, strValue, strName, strID, wait, "");
        }
        public String GetTextBox(String strName)
        {
            return GetTextBox(strName, false);
        }
        public String GetTextBox(String strName, bool allow_hidden)
        {
            mshtml.IHTMLDocument2 xDoc = (mshtml.IHTMLDocument2)( wb.Document );
            return GetTextBoxDocument(xDoc, strName, allow_hidden);
        }
        private void wb_BeforeNavigate2(object sender, AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2Event e)
        {
            GenericEvent ge = new GenericEvent();
            ge.Message = e.uRL.ToString();
            if(OnNavigate != null)
            {
                OnNavigate(ge);
                if( ge.Handled )
                    e.cancel = true;
            }

            if (OnNavigate2 != null)
                OnNavigate2(e);

        }
        private void wb_NavigateComplete2(object sender, AxSHDocVw.DWebBrowserEvents2_NavigateComplete2Event e)
        {
            if( NavigateComplete != null )
                NavigateComplete(new GenericEvent());
            mshtml.IHTMLDocument2 doc = (mshtml.IHTMLDocument2)wb.Document;
            mshtml.IHTMLWindow2 window = doc.parentWindow;
            mshtml.HTMLWindowEvents_Event ievent = (mshtml.HTMLWindowEvents_Event)window;
            ievent.onerror += new mshtml.HTMLWindowEvents_onerrorEventHandler(this.WindowError);
        }
        private void WindowError(string t, string i, int s)
        {
            mshtml.IHTMLDocument2 doc = (mshtml.IHTMLDocument2)wb.Document;
            mshtml.IHTMLWindow2 window = doc.parentWindow;
            ((mshtml.IHTMLEventObj)window.@event).returnValue = true;
        }
 
        public mshtml.IHTMLElement GetLinkByHRef(String strHRef)
        {
            ArrayList ary = new ArrayList();
            mshtml.IHTMLDocument2 xDoc = GetDocument();
            if( xDoc == null )
                return null;
            mshtml.IHTMLElement body = xDoc.body;
            mshtml.IHTMLElementCollection col = (mshtml.IHTMLElementCollection)( body.all );
            IEnumerator en = col.GetEnumerator();
            mshtml.IHTMLElement ele;
            //mshtml.IHTMLElement anc;
            //String strURL;
            //mshtml.IHTMLInputElement inp;
            //mshtml.IHTMLImgElement i;
            mshtml.IHTMLAnchorElement a;
            //bool yes;
            while(en.MoveNext())
            {
                ele = (mshtml.IHTMLElement)( en.Current );
                if(Tools.Strings.StrCmp(ele.tagName, "a"))
                {
                    a = (mshtml.IHTMLAnchorElement)ele;
                    if( Tools.Strings.StrCmp(a.href, strHRef) )
                        return (mshtml.IHTMLElement)a;
                }
            }
            return null;
        }

        public ArrayList GetLinkArray()
        {
            ArrayList ret = new ArrayList();
            try
            {
                GetLinkArrayDocument(GetDocument(), ret);
            }
            catch { }
            return ret;
        }

        public void GetLinkArrayDocument(mshtml.IHTMLDocument2 xDoc, ArrayList ary)
        {
            try
            {
                if (xDoc == null)
                    return;
                mshtml.IHTMLElement body = xDoc.body;
                mshtml.IHTMLElementCollection col = (mshtml.IHTMLElementCollection)(body.all);
                IEnumerator en = col.GetEnumerator();
                mshtml.IHTMLElement ele;
                //mshtml.IHTMLElement anc;
                //String strhref;
                //String strURL;
                //mshtml.IHTMLInputElement inp;
                //mshtml.IHTMLButtonElement b;
                //mshtml.IHTMLImgElement i;
                mshtml.IHTMLAnchorElement a;
                //bool yes;
                while (en.MoveNext())
                {
                    ele = (mshtml.IHTMLElement)(en.Current);
                    if (Tools.Strings.StrCmp(ele.tagName, "a"))
                    {
                        a = (mshtml.IHTMLAnchorElement)ele;
                        if (!Tools.Strings.IsInArray(a.href, ary))
                        {
                            if( a.href != null )
                                ary.Add(a.href);
                        }
                    }
                    //else if (Tools.Strings.StrCmp(ele.tagName, "frame"))
                    //{
                    //    try
                    //    {
                    //        mshtml.IHTMLFrameElement2 f = (mshtml.IHTMLFrameElement)ele;
                    //        mshtml.IHTMLDocument2 fd = f.Get
                    //    }
                    //    catch { }
                    //}
                }
            }
            catch { }

            try
            {
                mshtml.FramesCollection frames = xDoc.frames;
                if (frames != null)
                {
                    for (int i = 0; i < frames.length; i++)
                    {
                        object refIdx = i;
                        mshtml.IHTMLWindow2 frame = (mshtml.IHTMLWindow2)frames.item(ref refIdx);
                        GetLinkArrayDocument(frame.document, ary);
                    }
                }
            }
            catch { }
        }

        public ArrayList GetLinkObjectArray()
        {
            ArrayList ary = new ArrayList();
            mshtml.IHTMLDocument2 xDoc = GetDocument();
            if (xDoc == null)
                return ary;
            mshtml.IHTMLElement body = xDoc.body;
            mshtml.IHTMLElementCollection col = (mshtml.IHTMLElementCollection)(body.all);
            IEnumerator en = col.GetEnumerator();
            mshtml.IHTMLElement ele;
            //mshtml.IHTMLElement anc;
            //String strhref;
            //String strURL;
            //mshtml.IHTMLInputElement inp;
            //mshtml.IHTMLButtonElement b;
            //mshtml.IHTMLImgElement i;
            mshtml.IHTMLAnchorElement a;
            //bool yes;
            ArrayList inc = new ArrayList();
            while (en.MoveNext())
            {
                ele = (mshtml.IHTMLElement)(en.Current);
                if (Tools.Strings.StrCmp(ele.tagName, "a"))
                {
                    a = (mshtml.IHTMLAnchorElement)ele;
                    if (!Tools.Strings.IsInArray(a.href, inc))
                    {
                        ary.Add(a);
                        inc.Add(a.href);
                    }
                }
            }
            return ary;
        }

        public ArrayList GetLinkArray(String strIncluding)
        {
            ArrayList a = GetLinkArray();
            ArrayList b = new ArrayList();
            foreach(String l in a)
            {
                if( Tools.Strings.HasString(l, strIncluding) )
                    b.Add(l);
            }
            return b;
        }
        public ArrayList GetLinkObjectArray(String strIncluding)
        {
            try
            {
                ArrayList a = GetLinkObjectArray();
                ArrayList b = new ArrayList();
                foreach (mshtml.IHTMLAnchorElement x in a)
                {
                    if (Tools.Strings.HasString(x.href, strIncluding))
                        b.Add(x);
                }
                return b;
            }
            catch
            {
                return new ArrayList();
            }
        }

        public static String GetCellText(mshtml.HTMLTable t, int cell)
        {
            try
            {
                int j = 0;
                mshtml.IHTMLElement r = null;
                foreach(mshtml.IHTMLElement elt in t.cells)
                {
                    if(j == cell)
                    {
                        r = elt;
                        break;
                    }
                    j++;
                }
                if( r == null )
                    return "";
                String it = "";
                if( r.innerText != null )
                    it = r.innerText;
                return it;
            }
            catch(Exception)
            {
                return "";
            }
        }

        public static String GetCellText(mshtml.HTMLTableRow t, int cell)
        {
            try
            {
                int j = 0;
                mshtml.IHTMLElement r = null;
                foreach (mshtml.IHTMLElement elt in t.cells)
                {
                    if (j == cell)
                    {
                        r = elt;
                        break;
                    }
                    j++;
                }
                if (r == null)
                    return "";
                String it = "";
                if (r.innerText != null)
                    it = r.innerText;
                return it;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public void ScrollToBottom()
        {
            try
            {
                mshtml.IHTMLDocument2 xDoc = GetDocument();
                if (xDoc == null)
                    Add("Scroll: no document<br>");
                else
                {
                    xDoc.parentWindow.scrollTo(0, 100000000);

                    ////mshtml.HTMLDocument mydoc;
                    //mshtml.IHTMLElement myelem1 = xDoc.body;
                    //mshtml.IHTMLElement2 myelem2 = (mshtml.IHTMLElement2) myelem1;
                    //myelem2.scrollTop = 10000; // put_scrollTop(100);
                }
            }
            catch(Exception ex)
            {
                Add("Scroll: " + ex.Message + "<br>");
            }
        }
        private void wb_NewWindow2(object sender, AxSHDocVw.DWebBrowserEvents2_NewWindow2Event e)
        {
            try
            {
                FormBrowser xForm = new FormBrowser();
                xForm.GetWB().RegisterAsBrowser = true;
                e.ppDisp = xForm.GetWB().Application;
                xForm.Visible = true;
            }
            catch
            {
            }
        }

        public event OnNewWindowHandler OnNewWindow;
        private void wb_NewWindow3(object sender, AxSHDocVw.DWebBrowserEvents2_NewWindow3Event e)
        {
            if (OnNewWindow != null)
            {
                if (OnNewWindow(e))
                    return;
            }

            try
            {
                FormBrowser xForm = new FormBrowser();
                xForm.GetWB().RegisterAsBrowser = true;
                e.ppDisp = xForm.GetWB().Application;
                xForm.Visible = true;
            }
            catch
            {
            }
        }

        private void wb_StatusTextChange(object sender, AxSHDocVw.DWebBrowserEvents2_StatusTextChangeEvent e)
        {
            GenericEvent ge = new GenericEvent(e.text);
            if( zz_StatusChange != null )
                zz_StatusChange(ge);
        }
        private void wb_ProgressChange(object sender, AxSHDocVw.DWebBrowserEvents2_ProgressChangeEvent e)
        {
            if (e.progressMax == 0)
                return;

            GenericEvent ge = new GenericEvent(Convert.ToString(Math.Round(( Convert.ToDecimal(e.progress) / Convert.ToDecimal(e.progressMax) ) * 100, 0)) + "%");
            if( zz_ProgressChange != null )
                zz_ProgressChange(ge);
        }
        private void wb_DocumentComplete(object sender, AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent e)
        {
            GenericEvent ge = new GenericEvent(e.uRL.ToString());
            if (zz_LocationChange != null)
                zz_LocationChange(ge);                        
        }

        private void Browser_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            try
            {
                if (m_ShowControls)
                {
                    pControls.Visible = true;
                    pControls.Left = 0;
                    pControls.Top = 0;
                    pControls.Width = this.ClientRectangle.Width;

                    wb.Left = 0;
                    wb.Top = pControls.Height;
                    wb.Width = this.ClientRectangle.Width;
                    wb.Height = this.ClientRectangle.Height - pControls.Height;
                }
                else
                {
                    pControls.Visible = false;
                    wb.Left = 0;
                    wb.Top = 0;
                    wb.Width = this.ClientRectangle.Width;
                    wb.Height = this.ClientRectangle.Height;
                }
            }
            catch { }
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            try
            {
                wb.GoBack();
            }
            catch { }
        }

        private void cmdForward_Click(object sender, EventArgs e)
        {
            try
            {
                wb.GoForward();
            }
            catch { }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                wb.ExecWB(SHDocVw.OLECMDID.OLECMDID_PRINT, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER);
            }
            catch { }
        }

        public bool IsSaveAsAvailable()
        {
            int response = (int)wb.QueryStatusWB(SHDocVw.OLECMDID.OLECMDID_SAVEAS);
            return (response & (int)SHDocVw.OLECMDF.OLECMDF_ENABLED) != 0 ? true : false;
        }

        public bool SaveAs(String strFile)
        {
            System.Object nullObject = 0;
            string str = "";
            System.Object nullObjStr = str;
            object o = "";

            System.Object sf = strFile;

            if (IsSaveAsAvailable())
            {
                wb.ExecWB(SHDocVw.OLECMDID.OLECMDID_SAVEAS, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER, ref sf, ref nullObjStr);
                return true;
            }
            else
                return false;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if( added == null )
                return;

            String strFile = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "temp_html.htm";
            Tools.Files.SaveFileAsString(strFile, added.ToString());
            Tools.FileSystem.Shell(strFile);
        }


    }
    public delegate void OnNavigateHandler(GenericEvent e);
    public delegate void OnNavigate2Handler(AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2Event e);
    public delegate bool OnNewWindowHandler(AxSHDocVw.DWebBrowserEvents2_NewWindow3Event e);
}