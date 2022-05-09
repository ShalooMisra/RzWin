using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_HiTechParts : MultiSearch.Search
    {
        public Search_HiTechParts(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            InitializeComponent();
        }

        public override String ToString() 
        { 
            return "HiTech"; 
        }

        public override void InitWebsite()
        {
            Navigate("http://www.hitechparts.com", false);
            IsInitialized = true;
        }

        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if( SetTextBox("partnumbers", strPartNumber) )
			{
				if( ClickButton("Submit Search", "", "", "", wait) )
                    IsAbleToSearch = true;
			}
			else
                SetStatusIconTimer(StatusIcon.Error);
        }
    }
}

