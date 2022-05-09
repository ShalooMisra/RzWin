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
    public class BudgetEditor : RzScreen
    {
        //Private Variables
        budget Budget;        
        ComboBoxControl cboBudget;
        AnchorControl cmdCreateNew;
        ListViewSpotBudgetEditor LV;
        AnchorControl cmdCopyAcross;
        AnchorControl cmdAdjustAmount;
        AnchorControl cmdClear;

        //Constructors
        public BudgetEditor(Rz5.ContextRz context, budget b)
            : base(context)
        {
            Budget = b;
            cboBudget = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("cboBudget", "Budget", Budget.budget_name, GetBudgets(context), ActionScriptPlusControls("'account_changed'"))));
            cmdCreateNew = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("cmdCreateNew", "Create New Budget", ActionScriptPlusControls("'new_budget'"), "null")));
            LV = (ListViewSpotBudgetEditor)SpotAdd(new ListViewSpotBudgetEditor());
            LV.AllowExport = false;
            LV.ItemDoubleClicked += new ItemDoubleClickHandler(LV_ItemDoubleClicked);
            cmdCopyAcross = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("cmdCopyAcross", "Copy Across Rows", "GetSelectedId('copy_rows');", "null")));
            cmdAdjustAmount = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("cmdAdjustAmount", "Adjust Row Amounts", "GetSelectedId('adjust_rows');", "null")));
            cmdClear = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("cmdClear", "Clear", ActionScriptPlusControls("'clear'"), "null")));
            LoadLV(context);
            AdjustControls();
        }
        //Public Override Functions
        public override String Title(Context x)
        {
            return "Budget Editor";
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"top_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; height: 50px; padding: 6px;\">");
            cboBudget.Render(x, sb, screenHandle, viewHandle, session, page);
            cmdCreateNew.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"bottom_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; height: 23px; padding: 6px;\">");
            cmdCopyAcross.Render(x, sb, screenHandle, viewHandle, session, page);
            cmdAdjustAmount.Render(x, sb, screenHandle, viewHandle, session, page);
            cmdClear.Render(x, sb, screenHandle, viewHandle, session, page);
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
                case "account_changed":
                    AccountChanged(xrz, args.Vars);
                    break;
                case "clear":
                    ClearBudget(xrz);
                    break;
                case "copy_rows":
                    CopyRows(xrz, GetBudgetAccountList(xrz, args.ActionParams));
                    break;
                case "adjust_rows":
                    AdjustRows(xrz, GetBudgetAccountList(xrz, args.ActionParams));
                    break;
                case "new_budget":
                    CreateNewBudget(xrz);
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
        }
        //Protected Override Functions
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, "top_" + Uid);
            RunDivToRight(sb, "top_" + Uid);
            sb.AppendLine(cboBudget.Select + ".css('top', 3);");
            sb.AppendLine(cboBudget.Select + ".css('left', 10);");
            sb.AppendLine(cmdCreateNew.Select + ".css('top', 18);");
            sb.AppendLine(cmdCreateNew.Select + ".css('left', $('#top_" + Uid + "').width() - " + cmdCreateNew.Select + ".width());");
            PlaceDivBelowDiv(sb, LV.DivId, "top_" + Uid);
            LV.RunToRight(sb);
            sb.AppendLine(LV.Select + ".css('height', $('#bottom_" + Uid + "').position().top - " + LV.Select + ".position().top);");   
            PlaceDivAtBottom(sb, "bottom_" + Uid);
            RunDivToRight(sb, "bottom_" + Uid);
            sb.AppendLine(cmdCopyAcross.Select + ".css('top', 5);");
            sb.AppendLine(cmdAdjustAmount.Select + ".css('top', 5);");
            sb.AppendLine(cmdClear.Select + ".css('top', 5);");
            sb.AppendLine(cmdCopyAcross.Select + ".css('left', 5);");
            sb.AppendLine(cmdAdjustAmount.PlaceRight(cmdCopyAcross));
            sb.AppendLine(cmdClear.PlaceRight(cmdAdjustAmount));
        }
        //Private Functions
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function GetSelectedId(action)");
            sb.AppendLine("{");
            sb.AppendLine("  var data = SelectedRowIds('" + LV.TableId() + "');");
            sb.AppendLine(ActionScript("action", "data"));
            sb.AppendLine("}");
            viewHandle.Definitions.Add(sb.ToString());
        }
        private void AdjustControls()
        {
            cmdCreateNew.ButtonTopPadding = 0;
            cmdCopyAcross.ButtonTopPadding = 0;
            cmdAdjustAmount.ButtonTopPadding = 0;
            cmdClear.ButtonTopPadding = 0;
            cboBudget.FixedWidth = 300;
            cboBudget.CaptionBold = true;
            cboBudget.CaptionFontSize = FontSize.Large;
            cboBudget.UseNameInID = true;
            cboBudget.IncludeBlankOption = false;
        }
        private List<budget_account> GetBudgetAccountList(ContextRz x, string ids)
        {
            List<budget_account> l = new List<budget_account>();
            if (!Tools.Strings.StrExt(ids))
                return l;
            string[] str = Tools.Strings.Split(ids, "|");
            string inn = "";
            foreach (string s in str)
            {
                string id = Tools.Strings.ParseDelimit(s, "_dot_", 2).Trim();
                if (Tools.Strings.StrExt(inn))
                    inn += ",";
                inn += "'" + id + "'";
            }
            if (!Tools.Strings.StrExt(inn))
                return l;
            ArrayList a = x.QtC("budget_account", "select * from budget_account where unique_id in (" + inn + ")");
            foreach (budget_account b in a)
            {
                l.Add(b);
            }
            return l;
        }
        private void CopyRows(ContextRz x, List<budget_account> l)
        {
            bool c = false;
            double d = x.TheLeader.AskForDouble("Enter the amount to apply to all months for all selected lines.", 0, "Enter Amount", ref c);
            if (c)
                return;
            foreach (budget_account b in l)
            {
                if (b != null)
                    b.ApplyValue(x, d);
            }
            LoadLV(x);
        }
        private void AdjustRows(ContextRz x, List<budget_account> l)
        {
            bool c = false;
            double d = x.TheLeader.AskForDouble("Enter the amount to apply to the percentage for all months for all selected lines.", 0, "Enter Amount", ref c);
            if (c)
                return;
            LeaderWebUser lwu = (LeaderWebUser)x.Leader;
            DialogResultBudgetPercentArgs result = (DialogResultBudgetPercentArgs)lwu.ShowModalDialog(new BudgetPercentArgsGet(x));
            if (!result.Success)
                return;
            foreach (budget_account b in l)
            {
                if (b != null)
                    b.ApplyPercent(x, d, result.Percent, result.Decrease);
            }
            LoadLV(x);
        }
        private void AccountChanged(ContextRz x, Dictionary<string, string> d)
        {
            string s = "";
            d.TryGetValue("ctl_cbobudget", out s);
            if (!Tools.Strings.StrExt(s))
                return;
            Budget = budget.GetByName(x, s);
            LoadLV(x);
        }
        private void ClearBudget(ContextRz x)
        {
            if (Budget == null)
                return;
            if (!x.TheLeader.AreYouSure("you want to clear this budget"))
                return;
            Budget.ClearBudget(x);
            LoadLV(x);
        }
        private void CreateNewBudget(ContextRz x)
        {
            LeaderWebUser lwu = (LeaderWebUser)x.Leader;
            DialogResultBudgetArgs result = (DialogResultBudgetArgs)lwu.ShowModalDialog(new BudgetArgsGet(x));
            if (!result.Success)
                return;
            if (result.Budget == null)
                return;
            Budget = result.Budget;
            cboBudget.ValueSet(Budget.budget_name);
            cboBudget.Change();
            LoadLV(x);
        }
        private ArrayList GetBudgets(ContextRz x)
        {
            return x.SelectScalarArray("select distinct(budget_name) from budget where len(isnull(budget_name,'')) > 0 order by budget_name");
        }
        private void LoadLV(ContextRz context)
        {
            LV.TheArgs = GetListArgs(context);
            LV.CurrentTemplate = n_template.GetByName(context, LV.TheArgs.TheTemplate);
            if (LV.CurrentTemplate == null)
                LV.CurrentTemplate = n_template.Create(context, LV.TheArgs.TheClass, LV.TheArgs.TheTemplate);
            LV.CurrentTemplate.GatherColumns(context);
            LV.ColSource = new ColumnSourceTemplate(LV.CurrentTemplate);
            LV.RowSource = new RowSourceItem(GetRowSourceItems(context));
            LV.Change();
        }
        private ListArgs GetListArgs(ContextRz x)
        {
            ListArgs TheArgs = new ListArgs(x);
            TheArgs.ExportAllow = false;
            TheArgs.AddAllow = false;
            TheArgs.TheClass = "budget_account";
            TheArgs.TheTable = "budget_account";
            TheArgs.TheTemplate = "budget_account_lv";
            n_template t = n_template.GetByName(x, TheArgs.TheTemplate);
            if (t == null)
                CreateTemplate(x, TheArgs);
            return TheArgs;
        }
        private void CreateTemplate(ContextRz x, ListArgs TheArgs)
        {
            n_template t = (n_template)x.Item("n_template");
            t.template_name = TheArgs.TheTemplate;
            t.class_name = TheArgs.TheClass;
            t.use_gridlines = true;
            x.Insert(t);
            //account_fullname
            n_column c = new n_column();
            t.InitNewColumn(c);
            CoreVarValAttribute p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "account_fullname");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "Account";
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //annual_total
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "annual_total");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "Annual Total";
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //jan
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "jan");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "JAN";
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //feb
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "feb");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "FEB";
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //march
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "march");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "MAR";
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //april
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "april");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "APR";
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //may
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "may");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "MAY";
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //june
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "june");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "JUN";
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //july
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "july");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "JUL";
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //august
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "august");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "AUG";
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //sept
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "sept");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "SEP";
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //oct
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "oct");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "OCT";
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //nov
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "nov");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "NOV";
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //december
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "december");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "DEC";
            x.Insert(c);
            t.AbsorbColumn(x, c);
        }
        private List<IItem> GetRowSourceItems(ContextRz x)
        {
            List<IItem> l = new List<IItem>();
            if (Budget == null)
                return l;
            Budget.GatherAccounts(x);
            foreach (budget_account a in Budget.AccountList(x))
            {
                l.Add(a);
            }
            return l;
        }
        //Control Events
        private void LV_ItemDoubleClicked(Context x, IItem item, Page page, ViewHandle viewHandle)
        {
            try
            {

            }
            catch { }
        }
    }
    public class ListViewSpotBudgetEditor : ListViewSpotRz
    {
        public ListViewSpotBudgetEditor()
            : base("budget_account")
        {
        }
    }
}
