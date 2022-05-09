using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Core;
using CoreWeb;
using Rz5;
using System.Text;
using System.Web.UI;
using RzWeb.Screens;
using RzWeb.Controls;
using Rz5.Web;
using NewMethod;
using System.Collections;
using CoreWeb.Controls;
using System.Drawing;
using System.Data;

namespace RzWeb
{
    public class PostOrders : RzScreen
    {
        //Private Variables
        PostOrdersArgs Args;
        BoolControl chkInvoices;
        BoolControl chkPurchases;
        BoolControl chkRMAs;
        BoolControl chkVRMAs;
        BoolControl chkServices;
        AnchorControl cmdSearch;
        AnchorControl cmdPost;
        AnchorControl cmdCheckAll;
        AnchorControl cmdUnCheckAll;
        ArrayList OrderCheckboxes = new ArrayList();

        //Constructors
        public PostOrders(Rz5.ContextRz context)
            : base(context)
        {
            Args = new PostOrdersArgs();
            chkInvoices = (BoolControl)SpotAdd(ControlAdd(new BoolControl("chkInvoices", "Invoices", true)));
            chkPurchases = (BoolControl)SpotAdd(ControlAdd(new BoolControl("chkPurchases", "Purchase Orders", true)));
            chkRMAs = (BoolControl)SpotAdd(ControlAdd(new BoolControl("chkRMAs", "RMAs", true)));
            chkVRMAs = (BoolControl)SpotAdd(ControlAdd(new BoolControl("chkVRMAs", "Vendor RMAs", true)));
            chkServices = (BoolControl)SpotAdd(ControlAdd(new BoolControl("chkServices", "Service Orders", true)));
            cmdSearch = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("cmdSearch", "Search", ActionScriptPlusControls("'search'"), "null")));
            cmdPost = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("cmdPost", "Post", "Post();", "null")));
            cmdCheckAll = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("cmdCheckAll", "Check All", "CheckUnCheck(true);", "null")));
            cmdUnCheckAll = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("cmdUnCheckAll", "UnCheck All", "CheckUnCheck(false);", "null")));
            AdjustControls();
        }
        //Public Override Functions
        public override String Title(Context x)
        {
            return "Post Orders";
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"left_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; width: 150px; padding: 6px;\">");
            sb.AppendLine("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Post Options<br><hr><br>");
            chkInvoices.Render(x, sb, screenHandle, viewHandle, session, page);
            chkPurchases.Render(x, sb, screenHandle, viewHandle, session, page);
            chkRMAs.Render(x, sb, screenHandle, viewHandle, session, page);
            chkVRMAs.Render(x, sb, screenHandle, viewHandle, session, page);
            chkServices.Render(x, sb, screenHandle, viewHandle, session, page);
            cmdSearch.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"top_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; height: 25px; padding: 6px;\">");
            cmdPost.Render(x, sb, screenHandle, viewHandle, session, page);
            cmdCheckAll.Render(x, sb, screenHandle, viewHandle, session, page);
            cmdUnCheckAll.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"results_" + Uid + "\" style=\"position: absolute; overflow: scroll; height: 50px; width: 50px; padding: 6px;\">");
            sb.AppendLine(RenderResults((ContextRz)x));
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        public override void ClientScriptsInclude(System.Web.UI.Page page)
        {
            base.ClientScriptsInclude(page);
            page.ClientScript.RegisterClientScriptInclude("Rz", page.ResolveClientUrl("~/Scripts") + "/Rz.js");
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            ContextRz xrz = (ContextRz)x;
            switch (args.ActionId)
            {
                case "search":
                    DoSearch(xrz, args.Vars);
                    break;
                case "post":
                    DoPost(xrz, args.Vars);
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
        }
        //Protected Override Functions
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, "left_" + Uid);
            sb.AppendLine("$('#left_" + Uid + "').css('left', 5);");
            RunDivToBottom(sb, "left_" + Uid);
            PlaceDivBelowMenu(sb, "top_" + Uid);
            sb.AppendLine("$('#top_" + Uid + "').css('left', $('#left_" + Uid + "').position().left + $('#left_" + Uid + "').width() + 15);");
            RunDivToRight(sb, "top_" + Uid);
            sb.AppendLine(chkInvoices.Select + ".css('top', 50);");
            sb.AppendLine(chkPurchases.PlaceBelow(chkInvoices));
            sb.AppendLine(chkRMAs.PlaceBelow(chkPurchases));
            sb.AppendLine(chkVRMAs.PlaceBelow(chkRMAs));
            sb.AppendLine(chkServices.PlaceBelow(chkVRMAs));
            sb.AppendLine(cmdSearch.PlaceBelow(chkServices));
            sb.AppendLine(cmdSearch.Select + ".css('left', 30);");
            sb.AppendLine(cmdPost.Select + ".css('top', 5);");
            sb.AppendLine(cmdPost.Select + ".css('left', 10);");
            sb.AppendLine(cmdCheckAll.Select + ".css('top', 5);");
            sb.AppendLine(cmdCheckAll.PlaceRight(cmdPost));
            sb.AppendLine(cmdUnCheckAll.Select + ".css('top', 5);");
            sb.AppendLine(cmdUnCheckAll.PlaceRight(cmdCheckAll));
            PlaceDivBelowDiv(sb, "results_" + Uid, "top_" + Uid);
            sb.AppendLine("$('#results_" + Uid + "').css('left', $('#top_" + Uid + "').position().left + 5);");
            RunDivToRight(sb, "results_" + Uid);
            RunDivToBottom(sb, "results_" + Uid);
        }
        //Private Functions
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function Post()");
            sb.AppendLine("{");
            sb.AppendLine("var data = \"\";");
            foreach (string s in OrderCheckboxes)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                sb.AppendLine("data += '|" + s + ":' + $('#" + s + "').is(':checked');");
            }
            sb.AppendLine(ActionScript("'post'", "data"));
            sb.AppendLine("}");
            sb.AppendLine("function CheckUnCheck(c)");
            sb.AppendLine("{");
            foreach (string s in OrderCheckboxes)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                sb.AppendLine("$('#" + s + "').prop('checked', c);");
            }
            sb.AppendLine("}");
            viewHandle.Definitions.Add(sb.ToString());
        }
        private void AdjustControls()
        {
            chkInvoices.UseNameInID = true;
            chkPurchases.UseNameInID = true;
            chkRMAs.UseNameInID = true;
            chkServices.UseNameInID = true;
            chkVRMAs.UseNameInID = true;
            cmdSearch.ButtonTopPadding = 0;
            cmdPost.ButtonTopPadding = 0;
            cmdCheckAll.ButtonTopPadding = 0;
            cmdUnCheckAll.ButtonTopPadding = 0;
        }
        private void DoSearch(ContextRz x, Dictionary<string,string> d)
        {
            PostSearchArgs a = new PostSearchArgs();
            string s = "";
            d.TryGetValue("ctl_chkinvoices", out s);
            a.Invoice = Tools.Strings.StrCmp("true", s);
            chkInvoices.ValueSet(a.Invoice);
            s = "";
            d.TryGetValue("ctl_chkpurchases", out s);
            a.Purchase = Tools.Strings.StrCmp("true", s);
            chkPurchases.ValueSet(a.Purchase);
            s = "";
            d.TryGetValue("ctl_chkrmas", out s);
            a.RMA = Tools.Strings.StrCmp("true", s);
            chkRMAs.ValueSet(a.RMA);
            s = "";
            d.TryGetValue("ctl_chkvrmas", out s);
            a.VRMA = Tools.Strings.StrCmp("true", s);
            chkVRMAs.ValueSet(a.VRMA);
            s = "";
            d.TryGetValue("ctl_chkservices", out s);
            a.Service = Tools.Strings.StrCmp("true", s);
            chkServices.ValueSet(a.Service);
            Args.DoSearch(x, a);
            Change();
        }
        private void DoPost(ContextRz x, Dictionary<string, string> d)
        {

        }        
        private string RenderResults(ContextRz x)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=\"1\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"1%\" bgcolor=\"#C0C0C0\">&nbsp;</td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#C0C0C0\"><b>Type</b></td>");
            sb.AppendLine("    <td width=\"17%\" bgcolor=\"#C0C0C0\"><b>Number</b></td>");
            sb.AppendLine("    <td width=\"33%\" bgcolor=\"#C0C0C0\"><b>Company</b></td>");
            sb.AppendLine("    <td width=\"16%\" bgcolor=\"#C0C0C0\"><b>Total</b></td>");
            sb.AppendLine("    <td width=\"16%\" bgcolor=\"#C0C0C0\"><b>Status</b></td>");
            sb.AppendLine("  </tr>");
            foreach (ordhed_invoice o in Args.Invoices)
            {
                sb.AppendLine(AddLVLine(x, o));
            }
            foreach (ordhed_purchase o in Args.Purchases)
            {
                sb.AppendLine(AddLVLine(x, o));
            }
            foreach (ordhed_rma o in Args.RMAs)
            {
                sb.AppendLine(AddLVLine(x, o));
            }
            foreach (ordhed_vendrma o in Args.VRMAs)
            {
                sb.AppendLine(AddLVLine(x, o));
            }
            foreach (ordhed_service o in Args.Services)
            {
                sb.AppendLine(AddLVLine(x, o));
            }
            sb.AppendLine("</table>");
            return sb.ToString();
        }
        private string AddLVLine(ContextRz x, ordhed_new o)
        {
            if (o == null)
                return "";
            string s = o.PostStatus(x);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("  <tr>");
            string id = "order_" + o.ordertype + "_" + o.unique_id;
            OrderCheckboxes.Add(id);
            sb.AppendLine("    <td width=\"1%\"><input id=\"" + id + "\" type=\"checkbox\" name=\"" + id + "\" onclick=\"Save('mark');\"/></td>");
            sb.AppendLine("    <td width=\"17%\">" + o.ordertype + "</td>");
            sb.AppendLine("    <td width=\"17%\">" + o.ordernumber + "</td>");
            sb.AppendLine("    <td width=\"33%\">" + o.companyname + "</td>");
            sb.AppendLine("    <td width=\"16%\">" + Tools.Number.MoneyFormat(o.ordertotal) + "</td>");
            //sub.ForeColor = Color.Green;
            //if (!Tools.Strings.StrCmp("complete", s))
            //    sub.ForeColor = Color.Red;
            sb.AppendLine("    <td width=\"16%\">" + s + "</td>");
            sb.AppendLine("  </tr>");
            return sb.ToString();
        }
    }
}
