using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_Arrow : MultiSearch.Search
    {
        //Constructors
        public Search_Arrow(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "arrow";
            InitializeComponent();
        }
        //Public Override Functions
	    public override String ToString(){return "Arrow";}
	    public override void InitWebsite()
	    {
		    Navigate("http://www.arrownac.com/", false);
            IsInitialized = true;
	    }
        public override void RunSearch(String strPartNumber, bool wait)
	    {
		    base.RunSearch(strPartNumber, wait);

		    if( SetTextBox("search_token", strPartNumber) )
		    {
                if (!ClickElement("a", "", "", "", "submit_search", false, ""))
                {
                    if (!ClickElement("img", "", "", "", "", wait, "/images/arrownac_searchbutton.gif"))
                    {
                        if (ClickElement("input", "", "", "", "", wait, "images/aws_but_search_trans.gif"))
                            IsAbleToSearch = true;
                    }
                    else
                    {
                        IsAbleToSearch = true;
                    }
                }
                else
                    IsAbleToSearch = true;
		    }
		    else
                SetStatusIconTimer(StatusIcon.Error);
	    }
        public override void SetStatusIconTimer()
        {
            if (!HasSearched)
            {
                base.SetStatusIconTimer();
                return;
            }
            StatusIcon key = StatusIcon.Null;
            if (GetPageHTML(wb).ToLower().Contains("results per page:"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Contains("<h2>no search results found</h2>"))
                key = StatusIcon.NoResults;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}

