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

namespace RzWeb
{
    public class ChartOfAccounts : RzScreen
    {
        ListViewSpotAccounts lvAccounts;

        //Constructors
        public ChartOfAccounts(Rz5.ContextRz context)
            : base(context)
        {
            lvAccounts = (ListViewSpotAccounts)SpotAdd(new ListViewSpotAccounts(this));           
            lvAccounts.AllowExport = false;
            lvAccounts.ItemDoubleClicked += new ItemDoubleClickHandler(lvAccounts_ItemDoubleClicked);
            LoadLV(context);
        }
        //Public Override Functions
        public override String Title(Context x)
        {
            return "Chart Of Accounts";
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"top_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 50px;\">");
            sb.Append("<input type=\"button\" id=\"reportButton\" value=\"Refresh\" style=\"font-size: x-small; width: 80px;\" onclick=\"" + ActionScriptPlusControls("'refresh'") + "\">&nbsp;&nbsp;&nbsp;");
            Buttonize(viewHandle, "reportButton", "RefreshBlue3.png");
            sb.Append("<input type=\"button\" id=\"addButton\" value=\"Add\" style=\"font-size: x-small; width: 80px;\" onclick=\"" + ActionScriptPlusControls("'add'") + "\">");
            Buttonize(viewHandle, "addButton", "add_32.png");
            sb.AppendLine("</div>");
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
                case "refresh":
                    LoadLV(xrz);
                    break;
                case "add":
                    AddAccount(xrz);
                    LoadLV(xrz);
                    break;
            }
        }
        //Protected Override Functions
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, "top_" + Uid);
            sb.AppendLine("$('#top_" + Uid + "').css('width', $(window).width() - $('#top_" + Uid + "').position().left - 25);");
            PlaceDivBelow(sb, lvAccounts.DivId, "top_" + Uid);
            lvAccounts.RunToBottom(sb);
            lvAccounts.RunToRight(sb);
        }
        //Public Functions
        public void ShowAccountReport(Context x, ActArgs a)
        {
            account acnt = (account)a.TheItems.FirstGet(x);
            if (acnt == null)
                return;
            acnt.ShowAccountReport((ContextRz)x);
        }
        public void ShowAccountEdit(Context x, ActArgs a)
        {
            account acnt = (account)a.TheItems.FirstGet(x);
            if (acnt == null)
                return;
            x.Show(acnt);
        }
        public void ShowAccountSub(Context x, ActArgs a)
        {
            account acnt = (account)a.TheItems.FirstGet(x);
            if (acnt == null)
                return;
            account sub = account.CreateNewAccount((ContextRz)x, acnt.unique_id);
            if (sub != null)
                x.Show(sub);
            LoadLV((ContextRz)x);
        }
        public void ShowAccountDelete(Context x, ActArgs a)
        {
            account acnt = (account)a.TheItems.FirstGet(x);
            if (acnt == null)
                return;
            String reason = "";
            if (!acnt.DeletePossible((ContextRz)x, ref reason))
                x.Leader.Tell("Cannot delete: " + reason);
            else
            {
                if (!x.Leader.AreYouSure("delete " + acnt.full_name))
                    return;
                acnt.Delete(x);
            }
            LoadLV((ContextRz)x);
        }
        //Private Functions
        private void LoadLV(ContextRz context)
        {
            lvAccounts.TheArgs = GetListArgs(context);
            lvAccounts.CurrentTemplate = n_template.GetByName(context, lvAccounts.TheArgs.TheTemplate);
            if (lvAccounts.CurrentTemplate == null)
                lvAccounts.CurrentTemplate = n_template.Create(context, lvAccounts.TheArgs.TheClass, lvAccounts.TheArgs.TheTemplate);
            lvAccounts.CurrentTemplate.GatherColumns(context);
            lvAccounts.ColSource = new ColumnSourceTemplate(lvAccounts.CurrentTemplate);
            lvAccounts.RowSource = GetRowSource(context);
            lvAccounts.Change();
        }
        private void AddAccount(ContextRz context)
        {
            account a = account.CreateNewAccount(context);
            if (a == null)
                return;
            context.Show(a);
        }
        private ListArgs GetListArgs(ContextRz x)
        {
            ListArgs TheArgs = new ListArgs(x);
            TheArgs.AddAllow = false;
            TheArgs.UnlimitedAllow = true;
            TheArgs.TheLimit = -1;
            TheArgs.ExportAllow = false;            
            TheArgs.TheCaption = "Accounts";
            TheArgs.TheClass = "account";
            TheArgs.TheOrder = "number,name";
            TheArgs.TheTable = "account";
            TheArgs.TheTemplate = "chart_of_accounts";
            n_template t = n_template.GetByName(x, TheArgs.TheTemplate);
            if (t == null)
                CreateTemplate(x, TheArgs);
            return TheArgs;
        }
        private RowSourceItem GetRowSource(ContextRz x)
        {
            ArrayList a = x.QtC("account", "select * from account where isnull(is_hidden,0) = 0 and len(isnull(parent_id,'')) = 0 order by number,name");
            List<IItem> accnts = new List<IItem>();
            foreach (account aa in a)
            {
                accnts.Add(aa);
                if (aa.SubAccountsList(x).Count > 0)
                    GetSubAccounts(x, aa, accnts, 1);
            }
            return new RowSourceItem(accnts);
        }
        private void GetSubAccounts(ContextRz x, account a, List<IItem> accnts, int indent)
        {
            foreach (account aa in a.SubAccountsList(x))
            {
                aa.name = GetIndent(indent) + aa.name;
                accnts.Add(aa);
                if (aa.SubAccountsList(x).Count > 0)
                    GetSubAccounts(x, aa, accnts, indent++);
            }
        }
        private string GetIndent(int indent)
        {
            string build = " ";
            for (int i = 0; i < indent; i++)
            {
                build += "-";
            }
            return build + " ";
        }
        private void CreateTemplate(ContextRz x, ListArgs TheArgs)
        {
            n_template t = (n_template)x.Item("n_template");
            t.template_name = TheArgs.TheTemplate;
            t.class_name = TheArgs.TheClass;
            t.use_gridlines = true;
            x.Insert(t);
            //name
            n_column c = new n_column();
            t.InitNewColumn(c);
            CoreVarValAttribute p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "name");
            if (p != null)
                c.AbsorbProp(p);
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //number
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "number");
            if (p != null)
                c.AbsorbProp(p);
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //type
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "type");
            if (p != null)
                c.AbsorbProp(p);
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //balance
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "balance");
            if (p != null)
                c.AbsorbProp(p);
            x.Insert(c);
            t.AbsorbColumn(x, c);
        }
        private void lvAccounts_ItemDoubleClicked(Context x, IItem item, Page page, ViewHandle viewHandle)
        {
            account acnt = account.GetById(x, item.Uid);
            if (acnt == null)
                return;
            if (acnt.Type == AccountType.Bank)
                acnt.ShowCheckRegister((ContextRz)x);
            else
                acnt.ShowAccountReport((ContextRz)x);
        }
    }
    public class ListViewSpotAccounts : ListViewSpotRz
    {
        public ChartOfAccounts Chart;

        public ListViewSpotAccounts(ChartOfAccounts c)
            : base("account")
        {
            Chart = c;
        }
        protected override List<ActHandle> FilterActsForWeb(Context x, List<ActHandle> a, IItem item)
        {
            try
            {
                account acnt = (account)item;
                List<ActHandle> aa = new List<ActHandle>();
                //Report
                Act act = new Core.Act("reporton", new ActHandler(Chart.ShowAccountReport));
                ActHandle ah = new ActHandle("reporton", "Report on " + acnt.name);
                ah.TheAct = act;
                aa.Add(ah);
                //Edit
                act = new Core.Act("editaccount", new ActHandler(Chart.ShowAccountEdit));
                ah = new ActHandle("editaccount", "Edit " + acnt.name);
                ah.TheAct = act;
                aa.Add(ah);
                //Add Sub
                act = new Core.Act("addsubaccount", new ActHandler(Chart.ShowAccountSub));
                ah = new ActHandle("addsubaccount", "Add a Sub-Account " + acnt.name);
                ah.TheAct = act;
                aa.Add(ah);                
                aa.Add(new ActHandleSeparator());
                //Delete
                act = new Core.Act("deleteaccount", new ActHandler(Chart.ShowAccountDelete));
                ah = new ActHandle("deleteaccount", "Delete " + acnt.name);
                ah.TheAct = act;
                aa.Add(ah);
                return aa;
            }
            catch { return a; }
        }
    }
}
