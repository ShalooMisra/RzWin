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
    public partial class Search_ChipSource : MultiSearch.Search
    {
        //Constructors
        public Search_ChipSource(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            DoCheckStockDate = true;
            ShowLogin = true;
            ShowPostButtons = true;
            WebsiteName = "chipsource";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "ChipSource"; 
        }
        public override void InitWebsite()
        {
            //if (msData.IsAAT)
            //    cmdCheckBoxes.Visible = true;
            Navigate("http://www.chipsource.com/search.asp", false);
            UserName_Name = "AcctNum";
            Password_Name = "Password";
            SecondPassword_Name = "";
            LoginTag = "input";
            LoginName = "Submit";
            LoginValue = "ENTER";
            LoginType = "submit";
            base.InitWebsite();
        }
        public override void NavToPost(String type)
        {
            switch (type.ToLower())
            {
                case "offers":
                    wb.Navigate("http://www.chipsource.com/c_CutNPostIOR.asp?Type=O");
                    break;
                case "rfqs":
                    wb.Navigate("http://www.chipsource.com/c_CutNPostIOR.asp?Type=R");
                    break;
            }
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            bool y = false;
			if( ClickLink("New Search", "", "", "", true, "") )
				WaitForSetText("PARTS", strPartNumber);
			if( SetTextBox("PARTS", strPartNumber) )
			{
				if( ClickButton("", "Full Part Search", "", "", wait) )
					IsAbleToSearch = true;
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
                            if (Tools.Strings.HasString(inp.name.ToLower(), "r"))
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
            if (GetPageHTML(wb).ToLower().Contains("X"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Contains("X"))
                key = StatusIcon.NoResults;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}

