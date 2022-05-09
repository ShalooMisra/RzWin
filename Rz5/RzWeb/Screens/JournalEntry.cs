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

namespace RzWeb
{
    public class JournalEntry : RzScreen
    {
        //Private Variables
        private DateControl dtEntry;
        private TextControl txtMemo;
        private ListViewSpotJournalEntry LV;
        private ComboBoxControl cboAccount;
        private DoubleControl dblDebit;
        private DoubleControl dblCredit;
        private List<IItem> Entries;
        private journal SelectedJournal;

        //Constructors
        public JournalEntry(Rz5.ContextRz context)
            : base(context)
        {
            dtEntry = (DateControl)SpotAdd(ControlAdd(new DateControl("dtEntry", "Entry Date", DateTime.Now)));
            txtMemo = (TextControl)SpotAdd(ControlAdd(new TextControl("txtMemo", "Memo", "")));
            LV = (ListViewSpotJournalEntry)SpotAdd(new ListViewSpotJournalEntry());
            LV.AllowExport = false;
            LV.AllowAdd = false;
            LV.ItemDoubleClicked += new ItemDoubleClickHandler(LV_ItemDoubleClicked);
            cboAccount = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("cboAccount", "Account", "", GetAccounts(context))));
            dblDebit = (DoubleControl)SpotAdd(ControlAdd(new DoubleControl("dblDebit", "Debit", 0)));
            dblCredit = (DoubleControl)SpotAdd(ControlAdd(new DoubleControl("dblCredit", "Credit", 0)));
            AdjustControls();
            Init(context);
        }
        //Public Override Functions
        public override String Title(Context x)
        {
            return "Journal Entry";
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"top_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 50px;\">");
            sb.Append("<input type=\"button\" id=\"resetButton\" value=\"Reset\" style=\"font-size: x-small; width: 80px;\" onclick=\"" + ActionScript("'reset'") + "\">&nbsp;&nbsp;&nbsp;");
            Buttonize(viewHandle, "resetButton", "RefreshBlue3.png");
            sb.Append("<input type=\"button\" id=\"saveButton\" value=\"Save\" style=\"font-size: x-small; width: 80px;\" onclick=\"Save('save');\">");
            Buttonize(viewHandle, "saveButton", "GreenCheck.png"); 
            dtEntry.Render(x, sb, screenHandle, viewHandle, session, page);
            txtMemo.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<label id=\"warning\" style=\"position: absolute; top: 30px; color: Red; font-size: meduim;\"></label>");
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"bottom_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 35px; width: 710px;\">");
            cboAccount.Render(x, sb, screenHandle, viewHandle, session, page);
            dblDebit.Render(x, sb, screenHandle, viewHandle, session, page);
            dblCredit.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("     <div id=\"ok_" + Uid + "\" style=\"position: absolute; top: 3px;\">");
            sb.AppendLine("         <input type=\"button\" id=\"okButton\" value=\"OK\" style=\"font-size: small; width: 80px; height: 40px;\" onclick=\"Save('ok');\">");
            sb.AppendLine("     </div>"); 
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
            Dictionary<string, string> d = ParseValueString(args.ActionParams);
            switch (args.ActionId)
            {
                case "ok":
                    OKEntry(xrz, d, args.SourceView);
                    break;
                case "save":
                    SaveEntry(xrz, d, args.SourceView);
                    break;
                case "check_post":
                    CheckPost(xrz, d, args.SourceView);
                    break;
                case "reset":
                    Reset(xrz, d, args.SourceView);
                    break;
            }
        }
        //Protected Override Functions
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, "top_" + Uid);
            RunDivToRight(sb, "top_" + Uid);
            sb.AppendLine(dtEntry.Select + ".css('top', 8);");
            sb.AppendLine(dtEntry.Select + ".css('left', $('#saveButton').position().left + $('#saveButton').outerWidth(true) + 5);");
            sb.AppendLine(txtMemo.Select + ".css('top', 8);");
            sb.AppendLine(txtMemo.PlaceRight(dtEntry));
            sb.AppendLine("$('#warning').css('left', " + txtMemo.Select + ".position().left + " + txtMemo.Select + ".width() + 10);");
            PlaceDivBelowDiv(sb, LV.DivId, "top_" + Uid);
            sb.AppendLine(LV.Select + ".css('left', 5);");
            LV.RunToRight(sb);            
            PlaceDivAtBottom(sb, "bottom_" + Uid);
            sb.AppendLine(cboAccount.Select + ".css('left', 10);");
            sb.AppendLine(dblDebit.PlaceRight(cboAccount));
            sb.AppendLine(dblCredit.PlaceRight(dblDebit));
            sb.AppendLine("$('#ok_" + Uid + "').css('left', " + dblCredit.Select + ".position().left + " + dblCredit.Select + ".width() + 5);");
            sb.AppendLine(LV.Select + ".css('height', $('#bottom_" + Uid + "').position().top - " + LV.Select + ".position().top - 10);");
            sb.AppendLine("$('#bottom_" + Uid + "').css('left', ($(window).width() - $('#bottom_" + Uid + "').width()) / 2);");
        }
        //Private Functions
        private void Init(ContextRz x)
        {
            SetStartingEntries();
            LoadLV(x);
        }
        private void ClearControls()
        {
            cboAccount.ValueSet("");
            dblDebit.ValueSet(0);
            dblCredit.ValueSet(0);
            cboAccount.Change();
            dblDebit.Change();
            dblCredit.Change();
        }
        private void SaveEntry(ContextRz x, Dictionary<string, string> d, ViewHandle viewHandle)
        {
            if (!x.Leader.AreYouSure("post this transaction"))
                return;
            DateTime dt = DateTime.Now;
            string s = "";
            d.TryGetValue("dtEntry", out s);
            try { dt = Convert.ToDateTime(s); }
            catch { }
            s = "";
            d.TryGetValue("txtMemo", out s);
            try
            {
                BuildJournalEntry(x, s).Post(x, dt);
                x.Leader.Tell("Post complete.");
                Init(x);
                ClearControls();
                dtEntry.ValueSet(DateTime.Now);
                dtEntry.Change();
                txtMemo.ValueSet("");
                txtMemo.Change();
                CheckPost(x, d, viewHandle);
            }
            catch (Exception ex)
            {
                x.Leader.Error(ex);
            }
        }
        private void OKEntry(ContextRz x, Dictionary<string, string> d, ViewHandle viewHandle)
        {
            string s = "";
            d.TryGetValue("cboAccount", out s);
            if (!Tools.Strings.StrExt(s))
            {
                x.TheLeader.Tell("You need to select an account for this entry.");
                return;
            }
            string name = account.GetAccountFullNameStripBullet(s);
            account a = account.GetByFullName(x, name);
            if (a == null)
            {
                x.TheLeader.Tell("The account " + name + " could not be located.");
                return;
            }
            SelectedJournal.Account = a;
            DateTime dt = DateTime.Now;
            s = "";
            d.TryGetValue("dtEntry", out s);
            try { dt = Convert.ToDateTime(s); }
            catch { }
            SelectedJournal.date_created = dt;
            s = "";
            d.TryGetValue("txtMemo", out s);
            SelectedJournal.description = s;
            s = "";
            d.TryGetValue("dblDebit", out s);
            double debit = 0;
            try { debit = Convert.ToDouble(s); }
            catch { }
            SelectedJournal.debit_amount = debit;
            s = "";
            d.TryGetValue("dblCredit", out s);
            double credit = 0;
            try { credit = Convert.ToDouble(s); }
            catch { }
            SelectedJournal.credit_amount = credit;
            SelectedJournal.unique_id = "notanid_" + SelectedJournal.unique_id;
            SelectedJournal = null;
            LoadLV(x);
            ClearControls();
            CheckPost(x, d, viewHandle);
            viewHandle.ScriptsToRun.Add("HideDiv('" + "bottom_" + Uid + "');");
        }
        private void CheckPost(ContextRz x, Dictionary<string, string> d, ViewHandle viewHandle)
        {
            viewHandle.ScriptsToRun.Add("HideDiv('saveButton');");
            string s = "";
            d.TryGetValue("dtEntry", out s);
            DateTime dt = Tools.Dates.GetBlankDate();
            try { dt = Convert.ToDateTime(s); }
            catch { }
            if (!Tools.Dates.DateExists(dt))
            {
                Warning("Please enter a date for this transaction.", viewHandle);
                return;
            }
            s = "";
            d.TryGetValue("txtMemo", out s);
            if (!Tools.Strings.StrExt(s))
            {
                Warning("Please enter a memo for this transaction.", viewHandle);
                return;
            }
            Rz5.JournalEntry je = BuildJournalEntry(x, s);
            if (je.Total == 0)
            {
                Warning("Please enter at least two entries.", viewHandle);
                return;
            }
            if (!je.Balances)
            {
                Warning("This entry does not balance yet.", viewHandle);
                return;
            }
            Warning("", viewHandle);
            viewHandle.ScriptsToRun.Add("ShowDiv('saveButton');");
        }
        private void Reset(ContextRz x, Dictionary<string, string> d, ViewHandle viewHandle)
        {
            SelectedJournal = null;
            Init(x);
            dtEntry.ValueSet(DateTime.Now);
            dtEntry.Change();
            txtMemo.ValueSet("");
            txtMemo.Change();
            CheckPost(x, d, viewHandle);
            viewHandle.ScriptsToRun.Add("HideDiv('" + "bottom_" + Uid + "');");
        }
        private Rz5.JournalEntry BuildJournalEntry(ContextRz x, string memo)
        {
            Rz5.JournalEntry ret = new Rz5.JournalEntry(memo);
            foreach (IItem i in Entries)
            {
                journal j = (journal)i;
                if (!j.unique_id.ToLower().StartsWith("notanid_"))
                    continue;
                j.description = memo;
                ret.Add(x, j.Account, j.debit_amount, j.credit_amount);
            }
            return ret;
        }
        private void Warning(string text, ViewHandle viewHandle)
        {
            viewHandle.ScriptsToRun.Add("$('#warning').text('" + text + "');");
        }
        private void LoadLV(ContextRz context)
        {
            LV.TheArgs = GetListArgs(context);
            LV.CurrentTemplate = n_template.GetByName(context, LV.TheArgs.TheTemplate);
            if (LV.CurrentTemplate == null)
                LV.CurrentTemplate = n_template.Create(context, LV.TheArgs.TheClass, LV.TheArgs.TheTemplate);
            LV.CurrentTemplate.GatherColumns(context);
            LV.ColSource = new ColumnSourceTemplate(LV.CurrentTemplate);
            LV.RowSource = new RowSourceItem(Entries);
            LV.Change();
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function Save(action)");
            sb.AppendLine("{");
            sb.AppendLine("var data = \"\";");
            foreach (CoreWeb.Control c in Controls)
            {
                if (!c.IgnoreOnSave)
                    sb.AppendLine(c.ValueAddScript("data"));
            }
            sb.AppendLine(ActionScript("action", "data"));
            sb.AppendLine("}");
            sb.AppendLine(txtMemo.Select + ".focusout(function()");
            sb.AppendLine("{");
            sb.AppendLine("     Save('check_post');");
            sb.AppendLine("});");
            sb.AppendLine(dblDebit.Select + ".focusout(function()");
            sb.AppendLine("{");
            sb.AppendLine("     var v = $('#" + dblDebit.ControlId + "').val().replace(\"$\", \"\").replace(\",\", \"\");");
            sb.AppendLine("     if(!IsNumeric(v))");
            sb.AppendLine("     {");
            sb.AppendLine("         $('#" + dblDebit.ControlId + "').val(0);");
            sb.AppendLine("         return;");
            sb.AppendLine("     }");
            sb.AppendLine("     var n = Number(v);");
            sb.AppendLine("     if(n == 0)");
            sb.AppendLine("         return;");
            sb.AppendLine("     if(n < 0)");
            sb.AppendLine("     {");
            sb.AppendLine("         $('#" + dblDebit.ControlId + "').val(0);");
            sb.AppendLine("         $('#" + dblCredit.ControlId + "').val(n * -1);");
            sb.AppendLine("     }");
            sb.AppendLine("     else");
            sb.AppendLine("         $('#" + dblCredit.ControlId + "').val(0);");
            sb.AppendLine("});");
            sb.AppendLine(dblCredit.Select + ".focusout(function()");
            sb.AppendLine("{");
            sb.AppendLine("     var v = $('#" + dblCredit.ControlId + "').val().replace(\"$\", \"\").replace(\",\", \"\");");
            sb.AppendLine("     if(!IsNumeric(v))");
            sb.AppendLine("     {");
            sb.AppendLine("         $('#" + dblCredit.ControlId + "').val(0);");
            sb.AppendLine("         return;");
            sb.AppendLine("     }");
            sb.AppendLine("     var n = Number(v);");
            sb.AppendLine("     if(n == 0)");
            sb.AppendLine("         return;");
            sb.AppendLine("     if(n < 0)");
            sb.AppendLine("     {");
            sb.AppendLine("         $('#" + dblCredit.ControlId + "').val(0);");
            sb.AppendLine("         $('#" + dblDebit.ControlId + "').val(n * -1);");
            sb.AppendLine("     }");
            sb.AppendLine("     else");
            sb.AppendLine("         $('#" + dblDebit.ControlId + "').val(0);");
            sb.AppendLine("});");
            viewHandle.Definitions.Add(sb.ToString());
            viewHandle.ScriptsToRun.Add("HideDiv('" + "bottom_" + Uid + "');");
            viewHandle.ScriptsToRun.Add("Save('check_post');");
        }
        private void AdjustControls()
        {
            dtEntry.FixedWidth = 100;
            txtMemo.FixedWidth = 400;
            cboAccount.ReadOnly = true;
        }
        private ArrayList GetAccounts(ContextRz x)
        {
            List<account> l = x.TheSysRz.TheAccountLogic.GetAccounts(x, new AccountCriteria());
            ArrayList a = new ArrayList();
            foreach (account aa in l)
            {
                a.Add(account.GetAccountFullNameWithBullet(aa));
            }
            return a;
        }
        private ListArgs GetListArgs(ContextRz x)
        {
            ListArgs TheArgs = new ListArgs(x);
            TheArgs.ExportAllow = false;
            TheArgs.AddAllow = false;
            TheArgs.TheCaption = "Journal Entries";
            TheArgs.TheClass = "journal";
            TheArgs.TheTable = "journal";
            TheArgs.TheTemplate = "journal_entries";
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
            //account_name
            n_column c = new n_column();
            t.InitNewColumn(c);
            CoreVarValAttribute p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "account_name");
            if (p != null)
                c.AbsorbProp(p);
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //debit_amount
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "debit_amount");
            if (p != null)
                c.AbsorbProp(p);
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //credit_amount
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "credit_amount");
            if (p != null)
                c.AbsorbProp(p);
            x.Insert(c);
            t.AbsorbColumn(x, c);
        }
        private void SetStartingEntries()
        {
            Entries = new List<IItem>();
            for (int i = 0; i < 17; i++)
            {
                journal j = new journal();
                j.unique_id = i.ToString();
                Entries.Add(j);
            }
        }
        private void ShowJournalEntry(ContextRz x, ViewHandle viewHandle)
        {
            if (SelectedJournal == null)
                return;
            viewHandle.ScriptsToRun.Add("ShowDiv('" + "bottom_" + Uid + "');");
            account a = account.GetById(x, SelectedJournal.account_id);
            string name = "";
            if (a != null)
                name = account.GetAccountFullNameWithBullet(a);
            cboAccount.ValueSet(name);
            dblDebit.ValueSet(SelectedJournal.debit_amount);
            dblCredit.ValueSet(SelectedJournal.credit_amount);
            cboAccount.Change();
            dblDebit.Change();
            dblCredit.Change();
        }
        private void LV_ItemDoubleClicked(Context x, IItem item, Page page, ViewHandle viewHandle)
        {
            SelectedJournal = (journal)item;
            ShowJournalEntry((ContextRz)x, viewHandle);
        }
    }
    public class ListViewSpotJournalEntry : ListViewSpotRz
    {
        public ListViewSpotJournalEntry()
            : base("journal")
        {
        }
    }
}
