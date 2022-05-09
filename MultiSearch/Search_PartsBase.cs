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
    public partial class Search_PartsBase : MultiSearch.Search
    {
        //Constructors
        public Search_PartsBase(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            DoCheckStockDate = true;
            ShowLogin = true;
            WebsiteName = "partsbase";
            InitializeComponent();
            SuppressNewWindows = true;
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "PartsBase"; 
        }
        public override void InitWebsite()
        {
            Navigate("http://www.partsbase.com/parts/asp/ReadTextFile.asp?fn=NotRegistered&from=", false);
            UserName_Name = "username";
            Password_Name = "password";
            SecondPassword_Name = "";
            LoginTag = "IMG";
            LoginType = "IMG";
            LoginHref = "/images/Login_NoFocus.jpg";
            base.InitWebsite();
        }
        public override void EnterLoginInfo()
        {
            base.EnterLoginInfo();
            ClickLink("", "", "", "PBButton", true, "javascript:validate();"); 
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);

            ClickLink("Search", "", "", "", false, "");
            WaitForDone();
            //WaitForDone();


            //if( ClickElement("input", "", "   Skip   ", "", "", true,""))
            //    WaitForDone();

			if( SetTextBox("ItemDesc", strPartNumber) )
			{
				if( ClickElement("input", "", "Search", "", "", wait, "") )
					IsAbleToSearch = true;
			}
			else
                SetStatusIconTimer(StatusIcon.Error);
        }
        public override void ScrapeBids()
        {
            try
            {
                //HtmlDocument xDoc = wb.Document;
                //foreach (HtmlElement e in xDoc.All)
                //{
                //    if (Tools.Strings.StrCmp(e.TagName, "table"))
                //    {
                //        mshtml.HTMLTable t = (mshtml.HTMLTable)e.;
                //        if (t.innerText != null)
                //        {
                //            Tools.FileSystem.PopText(t.innerText);
                //            foreach (mshtml.HTMLTableRow r in t.rows)
                //            {
                //                if (r.innerText != null)
                //                {
                //                    if (Tools.Strings.StrCmp(r.innerText, "# Type Call Date Call Time From Number From Name To Number Call Duration ST Calls To Billing Code Call Type Call Category"))
                //                        continue;
                //                    //ProcessOneCall(r);
                //                }
                //            }
                //        }
                //    }
                //}
            }
            catch
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
            if (GetPageHTML(wb).ToLower().Contains("name=reqrfq_"))
                key = StatusIcon.Results;
            else if (GetPageText(wb).ToLower().Contains("we could not find the following parts in our database"))
                key = StatusIcon.NoResults;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
        //Control Events
        private void wb_NewWindow2(object sender, AxSHDocVw.DWebBrowserEvents2_NewWindow2Event e)
        {

        }
    }
}
