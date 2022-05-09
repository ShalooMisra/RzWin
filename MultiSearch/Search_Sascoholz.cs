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
    public partial class Search_Sascoholz : MultiSearch.Search
    {
        //Constructors
        public Search_Sascoholz(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "sascoholz";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "Sascoholz"; 
        }
        public override void InitWebsite()
        {
            Navigate("http://www.sascoholz.com/", false);
            base.InitWebsite();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("search_token", strPartNumber))
			{
                if (ClickElement("input", "", "", "", "", wait, "/images_en/buttons/bf_suche_starten.gif"))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
			}
            FinishedSearch();
        }
    }
}
