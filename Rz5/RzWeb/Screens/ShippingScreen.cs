using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;

using Core;
using CoreWeb;
using NewMethod;
using Rz5;
using Rz5.Web;

namespace RzWeb
{
    public class ShippingScreen : RzScreen
    {
        public ShippingScreenTop top;
        public ShippingScreen(ContextRz x)
            : base(x)
        {
            top = new ShippingScreenTop();
            top.LeftAbs = 0;
            //top.WidthPct = 100;
            top.TopAbs = 200;
            top.HeightAbs = 500;
            top.TheScreen = this;
            top.ParentSpot = this;
            Spots.Add(top);
        }
        public override String Title(Context x)
        {
            return "Shipping Screen";
        }
    }
    public class ShippingScreenTop : Spot
    {
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"shipping_screen\" style=\"position:absolute; left: 0px; top: 0px; padding: 8px; text-align: left; background-color: white;\">Shipping Screen<br><font color=\"gray\">Contents</font><br>");
            sb.AppendLine("</div>");
        }
    }
}