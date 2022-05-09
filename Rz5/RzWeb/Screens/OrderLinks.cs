using System;
using System.Text;
using System.Collections;
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
using System.Web.UI;

namespace RzWeb
{
    public class OrderLinks : RzScreen
    {
        ordhed TheOrder;
        String LinksDiv
        {
            get
            {
                return "links_" + Uid;
            }
        }
        OrderMapObject MapObj;
        ListViewSpotOrderSearch lvSearch;
        ArrayList aOrders = new ArrayList();

        public OrderLinks(ContextRz x, ordhed o)
            : base(x)
        {
            TheOrder = o;
            MapObj = new OrderMapObject();
            MapObj.CompleteLoad(x, TheOrder, 100, false);
            lvSearch = (ListViewSpotOrderSearch)SpotAdd(new ListViewSpotOrderSearch());
            lvSearch.SkipParentRender = true;
            lvSearch.TheArgs = new ListArgs(x);
            lvSearch.TheArgs.AddAllow = false;
            lvSearch.TheArgs.TheClass = "ordhed";
            lvSearch.TheArgs.TheLimit = 200;
            lvSearch.TheArgs.TheTable = "ordhed";
            lvSearch.TheArgs.TheTemplate = "order_search_results";
            lvSearch.CurrentTemplate = n_template.GetByName(x, lvSearch.TheArgs.TheTemplate);
            if (lvSearch.CurrentTemplate == null)
                lvSearch.CurrentTemplate = n_template.Create(x, lvSearch.TheArgs.TheClass, lvSearch.TheArgs.TheTemplate);
            lvSearch.CurrentTemplate.GatherColumns(x);
            lvSearch.ColSource = new ColumnSourceTemplate(lvSearch.CurrentTemplate);
            lvSearch.ItemDoubleClicked += new ItemDoubleClickHandler(lvSearch_ItemDoubleClicked);            
            AdjustControls();
        }
        //Override Functions
        public override String Title(Context x)
        {
            return "Order Links";
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            string s = Tools.Html.ConvertToPostString(args.ActionParams.ToLower().Trim());
            s = Tools.Html.ConvertFromPostString(s);
            switch (args.ActionId.ToLower())
            {
                case "tabShow":
                    break;
                case "show_orders":
                    ShowOrders((ContextRz)x, args.ActionParams);
                    break;
                case "show_order":
                    ShowOrder((ContextRz)x, args.ActionParams);
                    break;
                default:
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"links_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; width: 175px;\">");
            sb.AppendLine("   <div id=\"label_" + Uid + "\" style=\"position: absolute; width: 175px; left: 0px;\">");
            sb.AppendLine("   <center><b>All Linked Orders</b></center>");
            sb.AppendLine("   </div><br>");
            sb.AppendLine("   <div id=\"all_orders_" + Uid + "\" style=\"position: absolute; overflow: scroll; padding: 6px; width: 175px; left: 0px;\">");
            sb.AppendLine(GetOrderList((ContextRz)x, viewHandle, session, page));
            sb.AppendLine("   </div>");
            lvSearch.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, LinksDiv);
            RunDivToBottom(sb, LinksDiv);
            RunDivToRight(sb, LinksDiv);
            sb.AppendLine("$('#all_orders_" + Uid + "').css('height', $('#" + LinksDiv + "').height() - $('#all_orders_" + Uid + "').position().top - 3);");
            sb.AppendLine(lvSearch.Select + ".css('top', 2);");
            sb.AppendLine(lvSearch.Select + ".css('left', $('#all_orders_" + Uid + "').width() + 25);");
            sb.AppendLine(lvSearch.Select + ".css('width', $('#links_" + Uid + "').width() - " + lvSearch.Select + ".position().left);");
            sb.AppendLine(lvSearch.Select + ".css('height', $('#all_orders_" + Uid + "').height() - " + lvSearch.Select + ".position().top + 17);");
            AnchorControl prev = null;
            foreach (AnchorControl b in aOrders)
            {
                sb.AppendLine(b.Select + ".css('left', 5);");
                if (prev == null)
                {
                    prev = b;
                    continue;
                }
                sb.AppendLine(b.PlaceBelow(prev));
                prev = b;
            }
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            viewHandle.ScriptsToRun.Add("$('#linked_orders_" + Uid + "').tabs({ select: function(event, ui) { " + ActionScript("'tabShow'") + " } });");
        }
        private void AdjustControls()
        {
            lvSearch.ExtraStyle = "; font-size: small";
        }
        private void ShowOrders(ContextRz x, string ID)
        {
            ordhed o = ordhed.GetById(x, ID);
            ArrayList a = new ArrayList();
            foreach (DictionaryEntry d in MapObj.Links)
            {
                if (d.Key.ToString().StartsWith(ID))
                    a.Add(Tools.Strings.ParseDelimit(d.Key.ToString(), "*", 2).Trim());
            }
            string inn = Tools.Data.GetIn(a);
            if (!Tools.Strings.StrExt(inn))
                return;
            lvSearch.TheArgs.AddAllow = false;
            if (o != null)
                lvSearch.TheArgs.TheCaption = "Orders Linked To " + o.ToString();
            else
                lvSearch.TheArgs.TheCaption = "Linked Orders";
            lvSearch.TheArgs.TheWhere = "unique_id in (" + inn + ")";
            lvSearch.RowSource = new RowSourceTable(x.Select(lvSearch.TheArgs.RenderSql(x, lvSearch.CurrentTemplate)));
            lvSearch.Change();
        }
        private void ShowOrder(ContextRz x, string ID)
        {
            ordhed o = CastOrder(x, ordhed.GetById(x, ID));
            x.Show(new ShowArgsOrder(x, o, o.OrderType));
        }
        private string GetOrderList(ContextRz x, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            StringBuilder sb = new StringBuilder();
            foreach (OrderHandle h in MapObj.lvHandles)
            {
                string id = Tools.Strings.GetNewID();
                AnchorControl a = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("anch_" + Tools.Strings.GetNewID(), "<input id=\"cmdShow_" + id + "\" type=\"button\" value=\"\" onclick=\"" + ActionScript("'show_order'", "'" + h.strID + "'") + "\"><script type=\"text/javascript\">buttonize('cmdShow_" + id + "', 'mg.png'); $('#cmdShow_" + id + "').css('padding', '0px 0px 0px 0px').button(); $('#cmdShow_" + id + "').css('width', 14); $('#cmdShow_" + id + "').css('height', 12); $('#cmdShow_" + id + "').css('background-position', 'center 0px'); $('#cmdShow_" + id + "').css('top', 10);</script>&nbsp;&nbsp;" + h.strNumber + "-" + h.type.ToString(), ActionScript("'show_orders'", "'" + h.strID + "'"))));
                a.Render(x, sb, TheScreen, viewHandle, session, page);
                aOrders.Add(a);
            }
            return sb.ToString();
        }
        private ordhed CastOrder(ContextRz x, ordhed o)
        {
            switch (o.OrderType)
            {
                case Rz5.Enums.OrderType.Invoice:
                    return ordhed_invoice.GetById(x, o.unique_id);
                case Rz5.Enums.OrderType.Purchase:
                    return ordhed_purchase.GetById(x, o.unique_id);
                case Rz5.Enums.OrderType.Quote:
                    return ordhed_quote.GetById(x, o.unique_id);
                case Rz5.Enums.OrderType.RFQ:
                    return ordhed_rfq.GetById(x, o.unique_id);
                case Rz5.Enums.OrderType.RMA:
                    return ordhed_rma.GetById(x, o.unique_id);
                case Rz5.Enums.OrderType.Sales:
                    return ordhed_sales.GetById(x, o.unique_id);
                case Rz5.Enums.OrderType.Service:
                    return ordhed_service.GetById(x, o.unique_id);
                case Rz5.Enums.OrderType.VendRMA:
                    return ordhed_vendrma.GetById(x, o.unique_id);
                default:
                    return o;
            }
        }
        private void lvSearch_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            ordhed o = CastOrder((ContextRz)x, (ordhed)item);
            x.Show(new ShowArgsOrder(x, o, o.OrderType));
        }
    }
}



