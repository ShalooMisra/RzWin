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
    public partial class Search_Generic : MultiSearch.Search
    {
        public String Caption = "";
        public String SiteAddress = "";
        public String SearchBoxName = "";
        public String SearchButtonValue = "";
        public String[] ButtonImages = new String[] { "" };
        public bool AlwaysNavigateFirst = false;

        public Search_Generic(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            InitializeComponent();
        }

        public void CompleteLoad(String strCaption, String strSite, String strTextBox, String strSearchButton, String strButtonImage, bool bNavFirst)
        {
            Caption = strCaption;
            SiteAddress = strSite;
            WebsiteName = strSite;
            SearchBoxName = strTextBox;
            SearchButtonValue = strSearchButton;
            ButtonImages = Tools.Strings.Split(strButtonImage, "|");
            AlwaysNavigateFirst = bNavFirst;
        }

        public override String ToString() { return Caption; }

        public override void InitWebsite()
        {
            Navigate(SiteAddress, false);
            IsInitialized = true;
        }

        public override void RunSearch(String strPartNumber, bool wait)
        {
            if( AlwaysNavigateFirst )
                Navigate(SiteAddress, true);

            base.RunSearch(strPartNumber, wait);

            if (SetTextBox(SearchBoxName, strPartNumber))
            {
                switch (ButtonImages.Length)
                {
                    case 0:
                        if (ClickElement("input", "", SearchButtonValue, "", "", wait, ""))
                            IsAbleToSearch = true;

                        break;
                    case 1:
                        if (ClickElement("input", "", SearchButtonValue, "", "", wait, ButtonImages[0]))
                            IsAbleToSearch = true;
                        break;
                    default:
                        foreach (String b in ButtonImages)
                        {
                            if (ClickElement("input", "", SearchButtonValue, "", "", wait, b))
                            {
                                IsAbleToSearch = true;
                                break;
                            }
                        }
                        break;
                }
            }
            else
                SetStatusIconTimer(StatusIcon.Error);
        }
    }
}

