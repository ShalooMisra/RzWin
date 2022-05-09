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
    public partial class Search_PEIGenesis : MultiSearch.Search
    {
        public Search_PEIGenesis(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "peigenesis";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "PEIGenesis"; 
        }
        public override void InitWebsite()
        {
            base.InitWebsite();
            Navigate("http://www.peigenesis.com/pnsearch/pnsearch.asp", true);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetSecondSearch("pn", strPartNumber))
            {
                if (ClickElement("input", "", "Submit", "Submit", "", wait, ""))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
            }
            FinishedSearch();
        }
        //Private Functions
        private bool SetSecondSearch(string strName, string strText)
        {
            try
            {
                HtmlDocument xDoc = wb.Document;
                HtmlElement body = xDoc.Body;
                HtmlElementCollection col = body.All;
                IEnumerator en = col.GetEnumerator();
                mshtml.IHTMLElement ele;
                mshtml.IHTMLElement anc;
                String strhref;
                String strURL;
                mshtml.IHTMLInputElement inp;
                mshtml.IHTMLTextAreaElement tx;
                mshtml.IHTMLSelectElement se;
                bool foundonce = false;
                bool yes = false;
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
                            if (!foundonce)
                            {
                                foundonce = true;
                                continue;
                            }
                            inp.value = strText;
                            return true;
                        }
                    }
                }
                return false;
            }
            catch 
            { return false; }
        }







    }
}