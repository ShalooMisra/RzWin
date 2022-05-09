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
    public partial class Search_ChinaICMart : MultiSearch.Search
    {
        public Search_ChinaICMart(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "chinaicmart";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "ChinaICMart"; 
        }
        public override void InitWebsite()
        {
            //if (msData.IsAAT)
            //    cmdCheckBoxes.Visible = true;
            Navigate("http://www.chinaicmart.com/", false);
            UserName_Name = "username";
            Password_Name = "password";
            base.InitWebsite();
        }
        public override void EnterLoginInfo()
        {
            base.EnterLoginInfo();
            ClickElement("input", "", "", "imageField2", "", true, "images/btn_login.gif", "", "");
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("keyword", strPartNumber))
            {
                if (ClickButton("", "Search", "Submit", "", true))
                    IsAbleToSearch = true;
            }
        }
        public override void CheckAllBoxes()
        {
            try
            {
                HtmlDocument xDoc = wb.Document;
                HtmlElement body = xDoc.Body;
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
                        if (Tools.Strings.StrCmp(inp.type, "checkbox"))
                        {
                            if (Tools.Strings.HasString(inp.name.ToLower(), "id"))
                            {
                                c = (mshtml.IHTMLOptionButtonElement)(ele);
                                c.@checked = true;
                            }
                        }
                    }
                }
            }
            catch
            { }
        }
    }
}

