using System;
using System.Collections.Generic;
using System.Text;

namespace ToolsWin
{
    public class WebWin
    {
        //Public Static Functions
        public static void BrowseWebAddress(String strURL)
        {
            Tools.FileSystem.Shell("iexplore", strURL);
        }
    }
}
