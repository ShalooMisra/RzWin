using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_Microdis : MultiSearch.Search
    {
        //Constructors
        public Search_Microdis(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "microdis";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "Microdis"; 
        }
        public override void InitWebsite()
        {
            Navigate("http://www.microdis.net/", false);
            IsInitialized = true;
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("search", strPartNumber))
            {
                if (ClickSearchButton())
                {
                    IsAbleToSearch = true;
                    return;
                }
            }
        }
        public override void SetStatusIconTimer()
        {
            if (!HasSearched)
            {
                base.SetStatusIconTimer();
                return;
            }
            StatusIcon key = StatusIcon.Ready;
            //if (GetPageHTML(wb).ToLower().Contains("X"))
            //    key = StatusIcon.Results;
            //else if (GetPageHTML(wb).ToLower().Contains("X"))
            //    key = StatusIcon.NoResults;
            //else
            //    key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
        //Private Functions
        private bool ClickSearchButton()
        {
            HtmlElementCollection col = wb.Document.Body.All;
            mshtml.IHTMLElement anc;
            foreach (HtmlElement ele in col)
            {
                if (Tools.Strings.StrCmp(ele.TagName, "input"))
                {
                    anc = (mshtml.IHTMLElement)(ele.DomElement);
                    if (Tools.Strings.StrCmp(anc.className, "search_submit"))
                    {
                        anc.click();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

