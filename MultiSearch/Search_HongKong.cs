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
    public partial class Search_HongKong : MultiSearch.Search
    {
        //Contructors
        public Search_HongKong(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowPostButtons = true;
            ShowLogin = true;
            WebsiteName = "hongkong";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() { return "HongKong"; }
        public override void InitWebsite()
        {
            //if (msData.IsAAT)
            //    cmdCheckBoxes.Visible = true;
            Navigate("http://www.hkinventory.com/public/Home.asp", false);
            UserName_Name = "username";
            Password_Name = "passwd";
            LoginType = "submit";
            LoginValue = "Sign In";
            LoginText = "Sign In";
            LoginName = "btnLogin";
            IsInitialized = true;
            base.InitWebsite();
        }
        public override void EnterLoginInfo()
        {
            base.EnterLoginInfo();
            ClickButton("Sign In", "Sign In", "btnLogin", "", true);
        }
        public override void NavToPost(String type)
        {
            switch (type.ToLower())
            {
                case "offers":
                    wb.Navigate("http://www.hkinventory.com/member/CheckMembership.asp");
                    break;
                case "rfqs":
                    wb.Navigate("http://www.hkinventory.com/member/RequireBatchAdd.asp");
                    break;
            }
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            SetTextBox("pnums", strPartNumber);
            ClickButton("", "", "btnSubmit", "", true);
            IsAbleToSearch = true;
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
                            if (Tools.Strings.HasString(inp.name.ToLower(), "ck"))
                            {
                                c = (mshtml.IHTMLOptionButtonElement)(ele);
                                c.@checked = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            { }
        }
        public override void SetStatusIconTimer()
        {
            if (!HasSearched)
            {
                base.SetStatusIconTimer();
                return;
            }
            StatusIcon key = StatusIcon.Null;
            if (GetPageHTML(wb).ToLower().Contains("contact seller"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Contains("no record found!"))
                key = StatusIcon.NoResults;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}

