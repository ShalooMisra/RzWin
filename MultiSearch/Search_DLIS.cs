using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace MultiSearch
{
    public partial class Search_DLIS : MultiSearch.Search
    {
        //Constructors
        public Search_DLIS(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "dlis";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString()
        {
            return "DLIS";
        }
        public override void InitWebsite()
		{
            Navigate("http://www.dlis.dla.mil/webflis/pub/pub_search.aspx", false);
            base.InitWebsite(); 
		}
        public override void RunSearch(String strPartNumber, bool wait)
		{
			base.RunSearch(strPartNumber, wait);
            if (SetTextBox("txtNiin", strPartNumber))			
            {
                if (ClickButton("", "Go", "btnNIIN", "", true))
                    IsAbleToSearch = true;
            }
			else
                SetStatusIconTimer(StatusIcon.Error);
		}
    }
}
