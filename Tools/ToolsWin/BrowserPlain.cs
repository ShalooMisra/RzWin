using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Tools;

namespace ToolsWin
{
    public partial class BrowserPlain : UserControl
    {
        public event OnNavigateHandler OnNavigate;
        public event OnNavigate2HandlerPlain OnNavigate2;
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

        public BrowserPlain()
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
                //wb.Silent = Silent;
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
                //wb.Navigate(strURL, ref empty, ref empty, ref ob, ref oHeader);
                wb.Navigate(strURL);
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

        public WebBrowser GetWB()
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
            //try
            //{
                if (wb.Document == null)
                    wb.Navigate("about:blank");
                else
                    wb.Document.OpenNew(false);

                ReloadedHasBeen = true;
            //}
            //catch(Exception ex) {
            //    MessageBox.Show(ex.Message);

            //}

            ////remove it
            //try
            //{
            //    this.Controls.Remove(this.wb);
            //    wb.Navigating -= new WebBrowserNavigatingEventHandler(wb_Navigating);
            //    wb.Navigated -= new WebBrowserNavigatedEventHandler(wb_Navigated);
            //    this.wb.Dispose();
            //    this.wb = null;
            //}
            //catch(Exception)
            //{
            //}
            //added = new StringBuilder();
            //this.wb = new WebBrowser();
            ////this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.wb.Enabled = true;
            //this.wb.Location = new System.Drawing.Point(0, 0);
            ////this.wb.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject("wb.OcxState") ) );
            //this.wb.Size = new System.Drawing.Size(552, 474);
            //this.wb.TabIndex = 0;
            ////this.wb.BeforeNavigate2 += new AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2EventHandler(this.wb_BeforeNavigate2);
            //wb.Navigating += new WebBrowserNavigatingEventHandler(wb_Navigating);
            //wb.Navigated += new WebBrowserNavigatedEventHandler(wb_Navigated);
            
            ////this.wb.NavigateComplete2 += new AxSHDocVw.DWebBrowserEvents2_NavigateComplete2EventHandler(wb_NavigateComplete2);
            //this.Controls.Add(this.wb);
            ////wb.Silent = Silent;
            //Clear();
            //DoResize();
            //ReloadedHasBeen = true;
        }


        public void SetHTML(String strHTML)
        {
            Clear();
            HtmlDocument doc = wb.Document;
            doc.Write(strHTML);
        }
        public void Add(String strHTML)
        {
            try
            {
                HtmlDocument doc = wb.Document;
                doc.Write(strHTML);
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
                return wb.Url.AbsoluteUri.ToString();  //?
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
                        if( wb.ReadyState != WebBrowserReadyState.Complete )
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
                        if (wb.ReadyState != WebBrowserReadyState.Complete)
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
        private String GrabDocumentHTML(HtmlDocument xDoc, int intBase, bool textonly, bool outer)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                HtmlElement body = xDoc.Body;
                //if (outer)
                //{
                //    //mshtml.IHTMLDocument3 d3 = (mshtml.IHTMLDocument3)xDoc;
                //    sb.Append(((HtmlElement)xDoc).OuterHtml);

                //    //foreach(Object x in xDoc.all)
                //    //{
                //    //    //sb.Append(((mshtml.IHTMLElement)xDoc.all. item("", 0).outerHTML);
                //    //    sb.Append(((mshtml.IHTMLElement)x).outerHTML);
                //    //}
                //}
                //else 
                    
                if (textonly)
                    sb.Append(body.InnerText);
                else
                    sb.Append(body.InnerHtml);

                //HtmlElementCollection frames = xDoc.

                //mshtml.IHTMLFramesCollection2 frames = xDoc.frames;
                ////mshtml.IHTMLFrameElement f;
                //for (int j = 0; j < frames.length; j++)
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
                //        sb.Append(GrabDocumentHTML(frameDoc, intBase, textonly, outer));
                //    }
                //    catch
                //    {
                //    }
                //}
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
                HtmlDocument xDoc = wb.Document;
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
                HtmlDocument xDoc = (HtmlDocument)(wb.Document);
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
                wb.Print();
                //wb.ExecWB(SHDocVw.OLECMDID.OLECMDID_PRINT, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT);
            }
            catch(Exception)
            {
            }
        }
        public void PrintWithDialog()
        {
            try { wb.ShowPrintDialog(); }
            catch { }
        }
        public HtmlDocument GetDocument()
        {
            try
            {
                return (HtmlDocument)wb.Document;
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
                    if( Tools.Strings.StrExt(strText) && Tools.Strings.StrCmp(strText, anc.innerText) )
                        yes = true;
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
            //mshtml.IHTMLDocument2 xDoc = (mshtml.IHTMLDocument2)( wb.Document );
            //mshtml.IHTMLElement body;
            //body = xDoc.body;
            //mshtml.IHTMLElementCollection col = (mshtml.IHTMLElementCollection)( body.all );
            //IEnumerator en = col.GetEnumerator();
            //mshtml.IHTMLInputElement inp;
            //mshtml.IHTMLElement ele;
            ////mshtml.IHTMLElement anc;
            ////String strhref;
            ////String strURL;
            //mshtml.IHTMLOptionButtonElement c;
            ////bool yes;
            //while(en.MoveNext())
            //{
            //    ele = (mshtml.IHTMLElement)( en.Current );
            //    if(String.Compare(ele.tagName.ToLower(), "input") == 0)
            //    {
            //        inp = (mshtml.IHTMLInputElement)( ele );
            //        if(String.Compare(inp.name.ToLower(), strName.ToLower()) == 0)
            //        {
            //            String val = inp.value;
            //            if (val == null)
            //                val = "";
            //            if(!Tools.Strings.StrExt(strValue) || Tools.Strings.StrCmp(strValue, val.ToLower()))
            //            {
            //                c = (mshtml.IHTMLOptionButtonElement)( ele );
            //                c.@checked = true;
            //                return true;
            //            }
            //        }
            //    }
            //}
            return false;
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
                        }
                    }
                }
                return false;
            }
            catch { return false; }
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
                        }
                    }
                }
                Object fr = xDoc.frames;
                mshtml.IHTMLFramesCollection2 frames = (mshtml.IHTMLFramesCollection2)xDoc.frames;
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
                catch { }
            }
            return false;
        }
        public bool ClickElement(String strTag, String strText, String strValue, String strName, String strID, bool wait, String strSource, String strHref)
        {
            try
            {
                mshtml.IHTMLDocument2 xDoc = (mshtml.IHTMLDocument2)(wb.Document.DomDocument);
                return ClickElementDocument(xDoc, strTag, strText, strValue, strName, strID, wait, strSource, strHref);
            }
            catch
            {
                //AddActivity("Error in ClickElement");
            }
            return false;
        }
        //public bool ClickElement(String strTag, String strText, String strValue, String strName, String strID, bool wait)
        //{
        //    return ClickElement(strTag, strText, strValue, strName, strID, wait, "", "");
        //}
        //public bool ClickElement(String strTag, String strText, String strValue, String strName, String strID, bool wait, String strSource)
        //{
        //    return ClickElement(strTag, strText, strValue, strName, strID, wait, strSource, "");
        //}
        //public bool SetTextBoxDocument(mshtml.IHTMLDocument2 xDoc, String strName, String strText)
        //{
        //    try
        //    {
        //        mshtml.IHTMLElement body;
        //        body = xDoc.body;
        //        mshtml.IHTMLElementCollection col = (mshtml.IHTMLElementCollection)( body.all );
        //        IEnumerator en = col.GetEnumerator();
        //        mshtml.IHTMLElement ele;
        //        //mshtml.IHTMLElement anc;
        //        //String strhref;
        //        //String strURL;
        //        mshtml.IHTMLInputElement inp;
        //        mshtml.IHTMLTextAreaElement tx;
        //        mshtml.IHTMLSelectElement se;
        //        bool yes;
        //        while(en.MoveNext())
        //        {
        //            ele = (mshtml.IHTMLElement)( en.Current );
        //            String s = ele.tagName;
        //            if(String.Compare(ele.tagName.ToLower(), "input") == 0)
        //            {
        //                inp = (mshtml.IHTMLInputElement)( ele );
        //                yes = false;
        //                if( Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, inp.name) && ( !Tools.Strings.StrCmp(inp.type, "hidden") ) )
        //                    yes = true;
        //                //if (Tools.Strings.StrCmp(inp.type, "file"))
        //                //{
        //                //    //mshtml.IHtmlEle
        //                //}
        //                //else
        //                //{
        //                if(yes)
        //                {
        //                    inp.value = strText;
        //                    return true;
        //                }
        //                //}
        //            }
        //            else if(String.Compare(ele.tagName.ToLower(), "textarea") == 0)
        //            {
        //                tx = (mshtml.IHTMLTextAreaElement)( ele );
        //                yes = false;
        //                if( Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, tx.name) )
        //                    yes = true;
        //                if(yes)
        //                {
        //                    tx.value = strText;
        //                    return true;
        //                }
        //            }
        //            else if(String.Compare(ele.tagName.ToLower(), "select") == 0)
        //            {
        //                se = (mshtml.IHTMLSelectElement)( ele );
        //                yes = false;
        //                if( Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, se.name) )
        //                    yes = true;
        //                if(yes)
        //                {
        //                    se.value = strText;
        //                    return true;
        //                    //mshtml.IHTMLOptionsHolder hold = (mshtml.IHTMLOptionsHolder)se.options
        //                    //for (int g = 0; g < hold.length - 1; g++)
        //                    //{
        //                    //    if (Tools.Strings.StrCmp(se.options[g], strText))
        //                    //    {
        //                    //        se.selectedIndex = g;
        //                    //        return true;
        //                    //    }
        //                    //}
        //                }
        //            }
        //        }
        //        //mshtml.IHTMLFramesCollection2 frames = xDoc.frames;
        //        Object fr = xDoc.frames;
        //        mshtml.IHTMLFramesCollection2 frames = (mshtml.IHTMLFramesCollection2)xDoc.frames;
        //        //mshtml.FramesCollection frames = xDoc.frames;
        //        //mshtml.IHTMLFrameElement f;
        //        for(int j = 0 ; j < frames.length ; j++)
        //        {
        //            Int32 n = Convert.ToInt32(j);
        //            Object oFrameIndex = (Object)( n );
        //            mshtml.IHTMLWindow2 frame = (mshtml.IHTMLWindow2)( frames.item(ref oFrameIndex) );
        //            Object d = frame.document;
        //            try
        //            {
        //                mshtml.IHTMLDocument2 frameDoc = (mshtml.IHTMLDocument2)( d );
        //                if( SetTextBoxDocument(frameDoc, strName, strText) )
        //                    return true;
        //            }
        //            catch
        //            {
        //                //int k = 0;
        //            }
        //        }
        //        return false;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public String GetTextBoxDocument(mshtml.IHTMLDocument2 xDoc, String strName)
        //{
        //    return GetTextBoxDocument(xDoc, strName, false);
        //}
        //public String GetTextBoxDocument(mshtml.IHTMLDocument2 xDoc, String strName, bool allow_hidden)
        //{
        //    try
        //    {
        //        mshtml.IHTMLElement body;
        //        body = xDoc.body;
        //        mshtml.IHTMLElementCollection col = (mshtml.IHTMLElementCollection)( body.all );
        //        IEnumerator en = col.GetEnumerator();
        //        mshtml.IHTMLElement ele;
        //        //mshtml.IHTMLElement anc;
        //        //String strhref;
        //        //String strURL;
        //        mshtml.IHTMLInputElement inp;
        //        mshtml.IHTMLTextAreaElement tx;
        //        bool yes;
        //        while(en.MoveNext())
        //        {
        //            ele = (mshtml.IHTMLElement)( en.Current );
        //            String s = ele.tagName;
        //            if(String.Compare(ele.tagName.ToLower(), "input") == 0)
        //            {
        //                inp = (mshtml.IHTMLInputElement)( ele );
        //                yes = false;
        //                if(allow_hidden)
        //                {
        //                    if( Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, inp.name) )
        //                        yes = true;
        //                }
        //                else
        //                {
        //                    if( Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, inp.name) && ( !Tools.Strings.StrCmp(inp.type, "hidden") ) )
        //                        yes = true;
        //                }
        //                if(yes)
        //                {
        //                    //inp.value = strText;
        //                    return inp.value;
        //                }
        //            }
        //            else if(String.Compare(ele.tagName.ToLower(), "textarea") == 0)
        //            {
        //                tx = (mshtml.IHTMLTextAreaElement)( ele );
        //                yes = false;
        //                if( Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, tx.name) )
        //                    yes = true;
        //                if(yes)
        //                {
        //                    //tx.value = strText;
        //                    return tx.value;
        //                }
        //            }
        //        }
        //        //mshtml.IHTMLFramesCollection2 frames = xDoc.frames;
        //        Object fr = xDoc.frames;
        //        mshtml.IHTMLFramesCollection2 frames = (mshtml.IHTMLFramesCollection2)xDoc.frames;
        //        //mshtml.FramesCollection frames = xDoc.frames;
        //        //mshtml.IHTMLFrameElement f;
        //        for(int j = 0 ; j < frames.length ; j++)
        //        {
        //            Int32 n = Convert.ToInt32(j);
        //            Object oFrameIndex = (Object)( n );
        //            mshtml.IHTMLWindow2 frame = (mshtml.IHTMLWindow2)( frames.item(ref oFrameIndex) );
        //            Object d = frame.document;
        //            String st;
        //            try
        //            {
        //                mshtml.IHTMLDocument2 frameDoc = (mshtml.IHTMLDocument2)( d );
        //                st = GetTextBoxDocument(frameDoc, strName);
        //                if( Tools.Strings.StrExt(st) )
        //                    return st;
        //                //if (SetTextBoxDocument(frameDoc, strName, strText))
        //                //    return true;
        //            }
        //            catch
        //            {
        //                //int k = 0;
        //            }
        //        }
        //        return "";
        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //}
        //public bool SetTextBox(String strName, String strText)
        //{
        //    mshtml.IHTMLDocument2 xDoc = (mshtml.IHTMLDocument2)( wb.Document );
        //    return SetTextBoxDocument(xDoc, strName, strText);
        //}
        //public bool ClickButton(String strText, String strValue, String strName, String strID, bool wait)
        //{
        //    if (ClickElement("input", strText, strValue, strName, strID, wait, ""))
        //        return true;
        //    else
        //        return ClickElement("button", strText, strValue, strName, strID, wait, "");
        //}
        //public String GetTextBox(String strName)
        //{
        //    return GetTextBox(strName, false);
        //}
        //public String GetTextBox(String strName, bool allow_hidden)
        //{
        //    //mshtml.IHTMLDocument2 xDoc = (mshtml.IHTMLDocument2)( wb.Document );
        //    //return GetTextBoxDocument(xDoc, strName, allow_hidden);
        //    return "";
        //}

        void wb_Navigating(object sender, WebBrowserNavigatingEventArgs e)        
        {
            GenericEvent ge = new GenericEvent();
            ge.Message = e.Url.ToString();
            if(OnNavigate != null)
            {
                OnNavigate(ge);
                if( ge.Handled )
                    e.Cancel = true;
            }

            if (OnNavigate2 != null)
                OnNavigate2(e);

        }


        void wb_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if( NavigateComplete != null )
                NavigateComplete(new GenericEvent());
        }
        //public mshtml.IHTMLElement GetLinkByHRef(String strHRef)
        //{
        //    ArrayList ary = new ArrayList();
        //    mshtml.IHTMLDocument2 xDoc = GetDocument();
        //    if( xDoc == null )
        //        return null;
        //    mshtml.IHTMLElement body = xDoc.body;
        //    mshtml.IHTMLElementCollection col = (mshtml.IHTMLElementCollection)( body.all );
        //    IEnumerator en = col.GetEnumerator();
        //    mshtml.IHTMLElement ele;
        //    //mshtml.IHTMLElement anc;
        //    //String strURL;
        //    //mshtml.IHTMLInputElement inp;
        //    //mshtml.IHTMLImgElement i;
        //    mshtml.IHTMLAnchorElement a;
        //    //bool yes;
        //    while(en.MoveNext())
        //    {
        //        ele = (mshtml.IHTMLElement)( en.Current );
        //        if(Tools.Strings.StrCmp(ele.tagName, "a"))
        //        {
        //            a = (mshtml.IHTMLAnchorElement)ele;
        //            if( Tools.Strings.StrCmp(a.href, strHRef) )
        //                return (mshtml.IHTMLElement)a;
        //        }
        //    }
        //    return null;
        //}

        //public ArrayList GetLinkArray()
        //{
        //    ArrayList ret = new ArrayList();
        //    try
        //    {
        //        GetLinkArrayDocument(GetDocument(), ret);
        //    }
        //    catch { }
        //    return ret;
        //}

        //public void GetLinkArrayDocument(mshtml.IHTMLDocument2 xDoc, ArrayList ary)
        //{
        //    try
        //    {
        //        if (xDoc == null)
        //            return;
        //        mshtml.IHTMLElement body = xDoc.body;
        //        mshtml.IHTMLElementCollection col = (mshtml.IHTMLElementCollection)(body.all);
        //        IEnumerator en = col.GetEnumerator();
        //        mshtml.IHTMLElement ele;
        //        //mshtml.IHTMLElement anc;
        //        //String strhref;
        //        //String strURL;
        //        //mshtml.IHTMLInputElement inp;
        //        //mshtml.IHTMLButtonElement b;
        //        //mshtml.IHTMLImgElement i;
        //        mshtml.IHTMLAnchorElement a;
        //        //bool yes;
        //        while (en.MoveNext())
        //        {
        //            ele = (mshtml.IHTMLElement)(en.Current);
        //            if (Tools.Strings.StrCmp(ele.tagName, "a"))
        //            {
        //                a = (mshtml.IHTMLAnchorElement)ele;
        //                if (!Tools.Strings.IsInArray(a.href, ary))
        //                {
        //                    if( a.href != null )
        //                        ary.Add(a.href);
        //                }
        //            }
        //            //else if (Tools.Strings.StrCmp(ele.tagName, "frame"))
        //            //{
        //            //    try
        //            //    {
        //            //        mshtml.IHTMLFrameElement2 f = (mshtml.IHTMLFrameElement)ele;
        //            //        mshtml.IHTMLDocument2 fd = f.Get
        //            //    }
        //            //    catch { }
        //            //}
        //        }
        //    }
        //    catch { }

        //    try
        //    {
        //        mshtml.FramesCollection frames = xDoc.frames;
        //        if (frames != null)
        //        {
        //            for (int i = 0; i < frames.length; i++)
        //            {
        //                object refIdx = i;
        //                mshtml.IHTMLWindow2 frame = (mshtml.IHTMLWindow2)frames.item(ref refIdx);
        //                GetLinkArrayDocument(frame.document, ary);
        //            }
        //        }
        //    }
        //    catch { }
        //}

        //public ArrayList GetLinkObjectArray()
        //{
        //    ArrayList ary = new ArrayList();
        //    mshtml.IHTMLDocument2 xDoc = GetDocument();
        //    if (xDoc == null)
        //        return ary;
        //    mshtml.IHTMLElement body = xDoc.body;
        //    mshtml.IHTMLElementCollection col = (mshtml.IHTMLElementCollection)(body.all);
        //    IEnumerator en = col.GetEnumerator();
        //    mshtml.IHTMLElement ele;
        //    //mshtml.IHTMLElement anc;
        //    //String strhref;
        //    //String strURL;
        //    //mshtml.IHTMLInputElement inp;
        //    //mshtml.IHTMLButtonElement b;
        //    //mshtml.IHTMLImgElement i;
        //    mshtml.IHTMLAnchorElement a;
        //    //bool yes;
        //    ArrayList inc = new ArrayList();
        //    while (en.MoveNext())
        //    {
        //        ele = (mshtml.IHTMLElement)(en.Current);
        //        if (Tools.Strings.StrCmp(ele.tagName, "a"))
        //        {
        //            a = (mshtml.IHTMLAnchorElement)ele;
        //            if (!Tools.Strings.IsInArray(a.href, inc))
        //            {
        //                ary.Add(a);
        //                inc.Add(a.href);
        //            }
        //        }
        //    }
        //    return ary;
        //}

        //public ArrayList GetLinkArray(String strIncluding)
        //{
        //    ArrayList a = GetLinkArray();
        //    ArrayList b = new ArrayList();
        //    foreach(String l in a)
        //    {
        //        if( Tools.Strings.HasString(l, strIncluding) )
        //            b.Add(l);
        //    }
        //    return b;
        //}
        //public ArrayList GetLinkObjectArray(String strIncluding)
        //{
        //    try
        //    {
        //        ArrayList a = GetLinkObjectArray();
        //        ArrayList b = new ArrayList();
        //        foreach (mshtml.IHTMLAnchorElement x in a)
        //        {
        //            if (Tools.Strings.HasString(x.href, strIncluding))
        //                b.Add(x);
        //        }
        //        return b;
        //    }
        //    catch
        //    {
        //        return new ArrayList();
        //    }
        //}

        //public static String GetCellText(mshtml.HTMLTable t, int cell)
        //{
        //    try
        //    {
        //        int j = 0;
        //        mshtml.IHTMLElement r = null;
        //        foreach(mshtml.IHTMLElement elt in t.cells)
        //        {
        //            if(j == cell)
        //            {
        //                r = elt;
        //                break;
        //            }
        //            j++;
        //        }
        //        if( r == null )
        //            return "";
        //        String it = "";
        //        if( r.innerText != null )
        //            it = r.innerText;
        //        return it;
        //    }
        //    catch(Exception)
        //    {
        //        return "";
        //    }
        //}

        //public static String GetCellText(mshtml.HTMLTableRow t, int cell)
        //{
        //    try
        //    {
        //        int j = 0;
        //        mshtml.IHTMLElement r = null;
        //        foreach (mshtml.IHTMLElement elt in t.cells)
        //        {
        //            if (j == cell)
        //            {
        //                r = elt;
        //                break;
        //            }
        //            j++;
        //        }
        //        if (r == null)
        //            return "";
        //        String it = "";
        //        if (r.innerText != null)
        //            it = r.innerText;
        //        return it;
        //    }
        //    catch (Exception)
        //    {
        //        return "";
        //    }
        //}

        public void ScrollToBottom()
        {
            try
            {
                HtmlDocument xDoc = GetDocument();
                if (xDoc == null)
                    Add("Scroll: no document<br>");
                else
                    xDoc.Window.ScrollTo(0, Int32.MaxValue);
            }
            catch(Exception ex)
            {
                Add("Scroll: " + ex.Message + "<br>");
            }
        }
        //private void wb_NewWindow2(object sender, AxSHDocVw.DWebBrowserEvents2_NewWindow2Event e)
        //{
        //    try
        //    {
        //        FormBrowser xForm = new FormBrowser();
        //        xForm.GetWB().RegisterAsBrowser = true;
        //        e.ppDisp = xForm.GetWB().Application;
        //        xForm.Visible = true;
        //    }
        //    catch
        //    {
        //    }
        //}
        //private void wb_StatusTextChange(object sender, AxSHDocVw.DWebBrowserEvents2_StatusTextChangeEvent e)
        //{
        //    GenericEvent ge = new GenericEvent(e.text);
        //    if( zz_StatusChange != null )
        //        zz_StatusChange(ge);
        //}
        //private void wb_ProgressChange(object sender, AxSHDocVw.DWebBrowserEvents2_ProgressChangeEvent e)
        //{
        //    GenericEvent ge = new GenericEvent(Convert.ToString(Math.Round(( Convert.ToDecimal(e.progress) / Convert.ToDecimal(e.progressMax) ) * 100, 0)) + "%");
        //    if( zz_ProgressChange != null )
        //        zz_ProgressChange(ge);
        //}
        //private void wb_DocumentComplete(object sender, AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent e)
        //{
        //    GenericEvent ge = new GenericEvent(e.uRL.ToString());
        //    if( zz_LocationChange != null )
        //        zz_LocationChange(ge);
        //}

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
                wb.Print();
               // wb.ExecWB(SHDocVw.OLECMDID.OLECMDID_PRINT, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER);
            }
            catch { }
        }
        public bool IsSaveAsAvailable()
        {
            //int response = (int)wb.QueryStatusWB(SHDocVw.OLECMDID.OLECMDID_SAVEAS);
            //return (response & (int)SHDocVw.OLECMDF.OLECMDF_ENABLED) != 0 ? true : false;
            return false;
        }
        public bool SaveAs(String strFile)
        {
            //System.Object nullObject = 0;
            //string str = "";
            //System.Object nullObjStr = str;
            //object o = "";

            //System.Object sf = strFile;

            //if (IsSaveAsAvailable())
            //{
            //    wb.ExecWB(SHDocVw.OLECMDID.OLECMDID_SAVEAS, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER, ref sf, ref nullObjStr);
            //    return true;
            //}
            //else
            //    return false;

            return false;
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            if( added == null )
                return;

            String strFile = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "temp_html.htm";
            Tools.FileSystem.SaveFileAsString(strFile, added.ToString());
            Tools.FileSystem.Shell(strFile);
        }
        public List<TableHandle> TablesGet()
        {
            List<TableHandle> ret = new List<TableHandle>();
            foreach (mshtml.IHTMLElement e in ((mshtml.IHTMLDocument2)wb.Document.DomDocument).all)
            {
                if (Tools.Strings.StrCmp(e.tagName, "table"))
                {
                    mshtml.HTMLTable t = (mshtml.HTMLTable)e;

                    if (t.rows.length > 1)
                    {
                        int cols = 0;
                        int trying = 0;
                        foreach (mshtml.HTMLTableRow r in t.rows)
                        {
                            if (r.cells.length > cols)
                                cols = r.cells.length;

                            trying++;
                            if(trying >10 )
                                break;
                        }

                        TableHandle h = new TableHandle();
                        h.TextSample = Tools.Strings.Left(t.innerText, 200);
                        h.Rows = t.rows.length;
                        h.Columns = cols;
                        h.TheTable = t;
                        ret.Add(h);
                    }
                }
            }

            return ret;
        }

        public String GetTextBoxDocument(HtmlDocument xDoc, String strName)
        {
            return GetTextBoxDocument(xDoc, strName, false);
        }
        public String GetTextBoxDocument(HtmlDocument xDoc, String strName, bool allow_hidden)
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
                            return inp.value;
                    }
                    else if (String.Compare(ele.TagName.ToLower(), "textarea") == 0)
                    {
                        tx = (mshtml.IHTMLTextAreaElement)(ele.DomElement);
                        yes = false;
                        if (Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, tx.name))
                            yes = true;
                        if (yes)
                            return tx.value;
                    }
                    else if (String.Compare(ele.TagName.ToLower(), "select") == 0)
                    {
                        se = (mshtml.IHTMLSelectElement)ele.DomElement;
                        yes = false;
                        if (Tools.Strings.StrExt(strName) && Tools.Strings.StrCmp(strName, se.name))
                            yes = true;
                        if (yes)
                            return se.value;
                    }
                }
                return "";
            }
            catch { return ""; }
        }
        public String GetTextBox(String strName)
        {
            return GetTextBox(strName, false);
        }
        public String GetTextBox(String strName, bool allow_hidden)
        {
            HtmlDocument xDoc = (HtmlDocument)(wb.Document);
            return GetTextBoxDocument(xDoc, strName, allow_hidden);
        }

    }
    //public delegate void OnNavigateHandler(GenericEvent e);
    public delegate void OnNavigate2HandlerPlain(WebBrowserNavigatingEventArgs args);

    public class TableHandle
    {
        public String TextSample = "";
        public int Columns = 0;
        public int Rows = 0;
        public mshtml.HTMLTable TheTable = null;

        public String ConvertToCsv()
        {
            if (TheTable == null)
                return "";

            StringBuilder sb = new StringBuilder();

            int row = 0;
            foreach (mshtml.HTMLTableRow r in TheTable.rows)
            {
                if (row > 0)
                    sb.Append("\r\n");

                int cellindex = 0;
                foreach (mshtml.IHTMLElement cell in r.cells)
                {
                    if( cellindex > 0 )
                        sb.Append(",");
                    if (cell.outerText != null)
                    {
                        sb.Append("\"" + cell.outerText.Replace("\"", "'") + "\"");
                    }
                    cellindex++;
                }
                row++;
            }

            return sb.ToString();
        }
    }
}