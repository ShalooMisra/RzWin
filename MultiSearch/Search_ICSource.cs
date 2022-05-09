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
    public partial class Search_ICSource : MultiSearch.Search
    {
        //Constructors
        public Search_ICSource(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            ShowPostButtons = true;
            WebsiteName = "icsource";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() { return "ICSource"; }
        public override void InitWebsite()
        {
            //if (msData.IsAAT)
            //    cmdCheckBoxes.Visible = true;
            Navigate("http://www.icsource.com/login.aspx", false);
            UserName_Name = "ctl00$ContentHeader$ICSourceHead$txtUserName";
            Password_Name = "ctl00$ContentHeader$ICSourceHead$txtpassword";
            base.InitWebsite();
            IsInitialized = true;
        }
        public override void EnterLoginInfo()
        {
            base.EnterLoginInfo();
            ClickElement("input", "", "", "ctl00$ContentHeader$ICSourceHead$btnLogin", "ctl00_ContentHeader_ICSourceHead_btnLogin", true, "");
        }
        public override void NavToPost(String type)
        {
            switch (type.ToLower())
            {
                case "offers":
                    wb.Navigate("http://www.icsource.com/Members/PostParts.aspx?vw=enterparts");
                    break;
                case "rfqs":
                    wb.Navigate("http://www.icsource.com/Members/PostRequirements.aspx?vw=enterreqs");
                    break;
            }
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            bool y = false;
            //if (msData.IsAAT)
            //{
            //    if (SetTextBox("HeaderInclude1$txtPart", strPartNumber))
            //        y = true;
            //    if (y)
            //        ClickElement("img", "", "", "", "", false, "/Images/go.gif");
            //    else
            //        SetStatusIconTimer(StatusIcon.Error);
            //    return;
            //}
            base.RunSearch(strPartNumber, wait);
            if( SetTextBox("ctlByParts$ctlByPartsSearch$txtPNZX", strPartNumber) )
				y = true;
			else if( SetTextBox("ctlByParts$ctlByPartsSR$ctlInv$SearchInvGrid1$_ctl1$txtPartNumberFilter", strPartNumber) )
				y = true;
            else if (SetPartSearchTextbox(strPartNumber))
                y = true;
			if( y )
			{
                if (ClickButton("", "", "", "ctlByParts_ctlByPartsSearch_btn_search", wait))
                    IsAbleToSearch = true;
                else if (ClickButton("", "", "ctlByParts:ctlByPartsSR:ctlInv:SearchInvGrid1:_ctl1:btnSearch", "", wait))
                    IsAbleToSearch = true;
                else if (ClickElement("input", "", "", "HeaderInclude1$btnHdnPartSearch", "HeaderInclude1_btnHdnPartSearch", true, ""))
                    IsAbleToSearch =true;
			}
			else
                SetStatusIconTimer(StatusIcon.Error);
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
                            if (Tools.Strings.HasString(inp.name.ToLower(), "chk_delete"))
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
            if (GetPageHTML(wb).ToLower().Contains("no results found"))
                key = StatusIcon.NoResults;
            else if (GetPageHTML(wb).ToLower().Contains("cmdsendrfq"))
                key = StatusIcon.Results;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
        //Protected Override Functions
        protected override void EnterAutoLoginInfo()
        {
            base.EnterAutoLoginInfo();
            ClickElement("input", "", "Login", "ctl00$ContentPlaceHolder1$LoginMain1$btnLogin", "ctl00_ContentPlaceHolder1_LoginMain1_btnLogin", true, "");
        }
        //Private Functions
        private bool SetPartSearchTextbox(string part)
        {
            HtmlElementCollection col = wb.Document.Body.All;
            mshtml.IHTMLInputElement inp;
            foreach (HtmlElement ele in col)
            {
                if (Tools.Strings.StrCmp(ele.TagName, "input"))
                {
                    inp = (mshtml.IHTMLInputElement)ele.DomElement;
                    if (Tools.Strings.StrCmp(inp.name, "headerinclude1$txtpart"))
                    {
                        inp.value = part;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

