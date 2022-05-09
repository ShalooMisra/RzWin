//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Drawing;

//using Tools;
//using ToolsWin;

//using Core;

//namespace CoreWin
//{
//    public class LeaderBrowser : Leader
//    {
//        Browser TheBrowser = null;
//        public LeaderBrowser(Browser wb)
//        {
//            TheBrowser = wb;
//            if (!TheBrowser.ReloadedHasBeen)
//                TheBrowser.ReloadWB();
//        }

//        public override void Clear()
//        {
//            base.Clear();
//            TheBrowser.ReloadWB();
//        }

//        public override void Comment(string comment, Color color)
//        {
//            base.Comment(comment, color);
//            TheBrowser.Add("<br><font color=\"" + Tools.Html.GetHTMLColor(color.ToArgb()) + "\">" + Tools.Html.ConvertTextToHTML(comment) + "</font>");
//        }

//        public override void Error(String s, bool hide_message)
//        {
//            TheBrowser.Add("<br><b><font color=\"red\">" + Tools.Html.ConvertTextToHTML(s) + "</font></b>");
//        }
//    }
//}
