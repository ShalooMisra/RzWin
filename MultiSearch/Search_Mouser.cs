using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace MultiSearch
{
    public partial class Search_Mouser : MultiSearch.Search
    {
        //Constructors
        public Search_Mouser(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "mouser";
            //if (msData.IsAAT)
            //    ShowLogin = true;
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "Mouser"; 
        }
        public override void InitWebsite()
        {
            //if (!msData.IsAAT)
            //{
            //    Navigate("http://www.mouser.com", false);
            //    return;
            //}
            Navigate("https://www.mouser.com/MyMouser/MouserLogin.aspx?qs=0gZ0gv0KDwsa90U4U1kx8SQLbtECTgRE", false);
            UserName_Name = "ctl00$ContentMain$login$login$UserName";
            Password_Name = "ctl00$ContentMain$login$login$Password";
            //Navigate("https://www.mouser.com/secure/index.cfm?handler=mymouser._login", false);
            //UserName_Name = "username";
            //Password_Name = "password";
            base.InitWebsite();
        }
        public override void EnterLoginInfo()
        {
            base.EnterLoginInfo();
            //ClickElement("input", "", "", "login", "", true, "images/btn_log_in_white.gif");
            ClickButton("", "Log In", "ctl00$ContentMain$login$login$LoginButton", "ctl00_ContentMain_login_login_LoginButton", true);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetPartNumber("$txtSearch", strPartNumber))
            {
                if (ClickSearch("input", "$btnSearch"))
                    IsAbleToSearch = true;
            }
            else if (SetTextBox("keyword", strPartNumber))
            {
                if (ClickElement("input", "", "", "Image1", "", false,""))
                    IsAbleToSearch = true;
            }
            else if (SetTextBox("DefaultHeader$HeaderKeyWord", strPartNumber))
            {
                if (ClickElement("input", "", "", "DefaultHeader$ImageButton1", "", false,""))
                    IsAbleToSearch = true;
            }
            else if (SetTextBox("ctl00$Header1$txtSearch", strPartNumber))
            {
                if (ClickElement("input", "", "Search", "ctl00$Header1$btnSearch", "ctl00_Header1_btnSearch", false, ""))
                    IsAbleToSearch = true;
            }
        }
        public override void SetStatusIconTimer()
        {
            if (!HasSearched)
            {
                base.SetStatusIconTimer();
                return;
            }
            StatusIcon key = StatusIcon.Null;
            if (GetPageHTML(wb).ToLower().Contains("ctl00$contentmain$orderqty"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Contains("ctl00$contentmain$btnbuytop"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Contains("no results found for"))
                key = StatusIcon.NoResults;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
        //Private Functions
        private Boolean SetPartNumber(String strName, String strText)
        {
            try
            {
                HtmlDocument xDoc = wb.Document;
                HtmlElement body;
                body = xDoc.Body;
                HtmlElementCollection col = body.All;
                IEnumerator en = col.GetEnumerator();
                mshtml.IHTMLElement ele;
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
                        if (Tools.Strings.StrExt(strName) && inp.name.ToLower().Contains(strName.ToLower()) && (!Tools.Strings.StrCmp(inp.type, "hidden")))
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
                //Object fr = xDoc.frames;
                //mshtml.IHTMLFramesCollection2 frames = (mshtml.IHTMLFramesCollection2)xDoc.frames;
                //mshtml.IHTMLFrameElement f;
                //for (int j = 0; j < frames.length; j++)
                //{
                //    Int32 n = Convert.ToInt32(j);
                //    Object oFrameIndex = (Object)(n);
                //    mshtml.IHTMLWindow2 frame = (mshtml.IHTMLWindow2)(frames.item(ref oFrameIndex));
                //    Object d = frame.document;
                //    try
                //    {
                //        mshtml.IHTMLDocument2 frameDoc = (mshtml.IHTMLDocument2)(d);

                //        if (SetTextBoxDocument(frameDoc, strName, strText))
                //            return true;
                //    }
                //    catch (Exception e)
                //    {
                //        int k = 0;
                //    }
                //}
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private Boolean ClickSearch(String strTag, String strName)
        {
            try
            {
                HtmlDocument xDoc = wb.Document;
                HtmlElement body;
                body = xDoc.Body;
                HtmlElementCollection col = body.All;
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
                        if (Tools.Strings.StrCmp(strTag, "input"))
                        {
                            inp = (mshtml.IHTMLInputElement)(anc);
                            String st = inp.name;
                            if (Tools.Strings.StrExt(strName) && inp.name.ToLower().Contains(strName.ToLower()))
                                yes = true;
                        }
                        if (yes)
                        {
                            anc.click();
                            return WaitForDone();
                        }
                    }
                }
                //mshtml.IHTMLFramesCollection2 frames = xDoc.frames;
                //mshtml.IHTMLFrameElement f;
                //for (int j = 0; j < frames.length; j++)
                //{
                //    Int32 n = Convert.ToInt32(j);
                //    Object oFrameIndex = (Object)n;
                //    mshtml.IHTMLWindow2 frame = (mshtml.IHTMLWindow2)(frames.item(ref oFrameIndex));
                //    Object d = frame.document;
                //    try
                //    {
                //        HtmlDocument frameDoc = (HtmlDocument)d;
                //        if (ClickElementDocument(frameDoc, strTag, "", "", strName, "", true, "", "", ""))
                //            return true;
                //    }
                //    catch (Exception e)
                //    {
                //        int k = 0;
                //    }
                //}
                return false;
            }
            catch { }
            return false;
        }
    }
}

