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
    public class ProcessPayments : RzScreen
    {
        //Private Variables
        PaymentBatch TheBatch;
        CompanyContactControl Company;
        LabelControl lblBalance;
        TextControl txtMemo;
        DoubleControl dblAmount;        
        RadioButtonControl optMethod;
        LabelControl lblApplied;
        LabelControl lblOpen;
        ComboBoxControl cboAccount;
        ListViewSpotProcessPayments LV;

        //Constructors
        public ProcessPayments(Rz5.ContextRz context, PaymentType type, company company)
            : base(context)
        {
            TheBatch = new PaymentBatch(context, type, company);
            string comp_id = "";
            string comp_name = "";
            if (TheBatch.Company != null)
            {
                comp_id = TheBatch.Company.unique_id;
                comp_name = TheBatch.Company.companyname;
            }
            Company = (CompanyContactControl)SpotAdd(ControlAdd(new CompanyContactControl("Company", TheBatch.BatchType.ToString(), comp_id, comp_name, "", "", "", "", "", "")));
            lblBalance = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblBalance", "", TheBatch.BalanceCaption)));
            txtMemo = (TextControl)SpotAdd(ControlAdd(new TextControl("txtMemo", "Memo", "")));
            dblAmount = (DoubleControl)SpotAdd(ControlAdd(new DoubleControl("dblAmount", "Payment Amount", 0)));
            optMethod = (RadioButtonControl)SpotAdd(ControlAdd(new RadioButtonControl("optMethod", "", "manual", GetMethodOptions(), RadioAlign.Vertical)));
            lblApplied = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblApplied", "", TheBatch.AppliedCaption)));
            lblOpen = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblOpen", "", TheBatch.OpenCaption)));
            cboAccount = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("cboAccount", "Account", "", GetAccounts(context), "Save('account_changed');")));
            LV = (ListViewSpotProcessPayments)SpotAdd(new ListViewSpotProcessPayments());
            LV.AllowExport = false;
            LV.ItemDoubleClicked += new ItemDoubleClickHandler(LV_ItemDoubleClicked);
            AdjustControls();
            Init(context);
        }
        //Public Override Functions
        public override String Title(Context x)
        {
            if (TheBatch.BatchType == PaymentType.Customer)
                return "Receive Payments";
            else
                return "Pay Bills";
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"top_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 175px;\">");
            Company.Render(x, sb, screenHandle, viewHandle, session, page);
            lblBalance.Render(x, sb, screenHandle, viewHandle, session, page);
            txtMemo.Render(x, sb, screenHandle, viewHandle, session, page);
            dblAmount.Render(x, sb, screenHandle, viewHandle, session, page);
            optMethod.Render(x, sb, screenHandle, viewHandle, session, page);
            lblApplied.Render(x, sb, screenHandle, viewHandle, session, page);
            lblOpen.Render(x, sb, screenHandle, viewHandle, session, page);
            cboAccount.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.Append("<input type=\"button\" id=\"refreshButton\" value=\"Refresh\" style=\"font-size: x-small; width: 80px;\" onclick=\"" + ActionScript("'refresh'") + "\">");
            Buttonize(viewHandle, "refreshButton", "RefreshBlue3.png");            
            sb.Append("<input type=\"button\" id=\"billButton\" value=\"New Bill\" style=\"font-size: x-small; width: 80px;\" onclick=\"" + ActionScript("'new_bill'") + "\">");
            Buttonize(viewHandle, "billButton", "add_32.png");
            sb.Append("<input type=\"button\" id=\"saveButton\" value=\"Save\" style=\"font-size: x-small; width: 80px;\" onclick=\"Save('save');\">");
            Buttonize(viewHandle, "saveButton", "GreenCheck.png");
            sb.AppendLine("<label id=\"warning\" style=\"position: absolute; top: 30px; color: Red; font-size: meduim;\"></label>");
            sb.AppendLine("</div>");
            CheckBatch((ContextRz)x, viewHandle);
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
                case "amount_changed":
                    AmountChanged(xrz, d, args.SourceView);
                    break;
                case "account_changed":
                    AccountChanged(xrz, d, args.SourceView);
                    break;
                case "refresh":
                    if (TheBatch.Company != null)
                        TheBatch.SetCompany(xrz, TheBatch.Company);
                    Display(xrz);
                    break;
                case "new_bill":
                    NewBill(xrz);
                    break;
                case "save":
                    Save(xrz, d, args.SourceView);
                    break;
            }
        }
        //Protected Override Functions
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, "top_" + Uid);
            RunDivToRight(sb, "top_" + Uid);
            sb.AppendLine(Company.Select + ".css('top', 5);");
            sb.AppendLine(Company.Select + ".css('left', 5);");
            sb.AppendLine(Company.Select + ".css('width', $('#" + Company.ControlId + "').width());");
            sb.AppendLine(Company.Select + ".css('height', 55);");
            sb.AppendLine(lblBalance.Select + ".css('top', 5);");            
            sb.AppendLine(lblBalance.PlaceRight(Company));            
            sb.AppendLine(lblApplied.PlaceRight(Company));
            sb.AppendLine(lblApplied.PlaceBelow(lblBalance));
            sb.AppendLine(lblOpen.PlaceRight(Company));
            sb.AppendLine(lblOpen.PlaceBelow(lblApplied));
            sb.AppendLine(txtMemo.Select + ".css('left', 5);");
            sb.AppendLine(txtMemo.Select + ".css('top', 75);");
            sb.AppendLine(dblAmount.Select + ".css('left', 5);");
            sb.AppendLine(dblAmount.PlaceBelow(txtMemo));
            //sb.AppendLine(cboMethod.PlaceBelow(txtMemo));
            //sb.AppendLine(cboMethod.PlaceRight(dblAmount));
            sb.AppendLine(optMethod.PlaceBelow(txtMemo));
            sb.AppendLine(optMethod.PlaceRight(dblAmount));            
            sb.AppendLine(cboAccount.Select + ".css('top', 75);");
            sb.AppendLine(cboAccount.PlaceRight(txtMemo));
            sb.AppendLine("$('#refreshButton').css('top', 0);");
            sb.AppendLine("$('#refreshButton').css('left', 550);");
            sb.AppendLine("$('#billButton').css('top', 0);");
            sb.AppendLine("$('#billButton').css('left', 560);");
            sb.AppendLine("$('#saveButton').css('top', 78);");
            sb.AppendLine("$('#saveButton').css('left', 270);");
            sb.AppendLine("$('#warning').css('top', $('#saveButton').outerHeight(true) + $('#saveButton').position().top);");
            sb.AppendLine("$('#warning').css('left', $('#saveButton').position().left);");
            sb.AppendLine(LV.Select + ".css('left', 5);");
            PlaceDivBelowDiv(sb, LV.DivId, "top_" + Uid);
            LV.RunToRight(sb);
            LV.RunToBottom(sb);
        }
        //Private Functions
        private void Init(ContextRz x)
        {
            LoadLV(x);
            ClearControls();
        }
        private void Display(ContextRz x)
        {
            LoadLV(x);
            lblBalance.ValueSet(TheBatch.BalanceCaption);
            lblApplied.ValueSet(TheBatch.AppliedCaption);
            lblOpen.ValueSet(TheBatch.OpenCaption);
            if (TheBatch.Account != null)
            {
                cboAccount.ValueSet(account.GetAccountFullNameWithBullet(TheBatch.Account));
                cboAccount.Change();
            }
            lblBalance.Change();
            lblApplied.Change();
            lblOpen.Change();
        }
        private void CheckBatch(ContextRz x, ViewHandle viewHandle)
        {
            String inst = "";
            if (TheBatch.Valid(ref inst))
            {
                Warning("", viewHandle);
                viewHandle.ScriptsToRun.Add("ShowDiv('saveButton');");
            }
            else
            {
                Warning(inst, viewHandle);
                viewHandle.ScriptsToRun.Add("HideDiv('saveButton');");
            }
        }
        private void Warning(string text, ViewHandle viewHandle)
        {
            viewHandle.ScriptsToRun.Add("$('#warning').text('" + text + "');");
        }
        private void AmountChanged(ContextRz x, Dictionary<string, string> d, ViewHandle viewHandle)
        {
            double amnt = 0;
            string s = "";
            d.TryGetValue("dblAmount", out s);
            try { amnt = Convert.ToDouble(s); }
            catch { }
            TheBatch.Amount = amnt;
            dblAmount.ValueSet(amnt);
            CheckBatch((ContextRz)x, viewHandle);
            Display((ContextRz)x);
        }
        private void AccountChanged(ContextRz x, Dictionary<string, string> d, ViewHandle viewHandle)
        {
            string s = "";
            d.TryGetValue("cboAccount", out s);
            if (Tools.Strings.StrExt(s))
                TheBatch.Account = account.GetByFullName(x, account.GetAccountFullNameStripBullet(s));
            CheckBatch((ContextRz)x, viewHandle);
            Display((ContextRz)x);
        }        
        private void NewBill(ContextRz x)
        {
            x.Sys.TheOrderLogic.ShowNewBill(x, TheBatch.Company);
        }
        private void Save(ContextRz x, Dictionary<string, string> d, ViewHandle viewHandle)
        {
            try
            {
                string s = "";
                d.TryGetValue("txtMemo", out s);
                TheBatch.Memo = s;
                s = "";
                d.TryGetValue("optMethod", out s);
                switch(s.ToLower().Trim ())
                {
                    case "print":
                        TheBatch.Method = "Print Check";
                        break;
                    case "debit":
                        TheBatch.Method = "Debit Card";
                        break;
                    default:
                        TheBatch.Method = "Manual Check";
                        break;
                }
                s = "";
                d.TryGetValue("cboAccount", out s);
                if (Tools.Strings.StrExt(s))
                    TheBatch.Account = account.GetByFullName(x, account.GetAccountFullNameStripBullet(s));
                TheBatch.Post(x);
                TheBatch = new PaymentBatch(x, TheBatch.BatchType, null);
                ClearControls();
                LoadLV(x);
                CheckBatch(x, viewHandle);
            }
            catch (Exception ex)
            {
                x.Leader.Tell("Posting failed: " + ex.Message);
            }
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
            TheArgs.TheClass = "ordhed";
            TheArgs.TheTable = "ordhed";
            TheArgs.TheTemplate = "process_payments";
            n_template t = n_template.GetByName(x, TheArgs.TheTemplate);
            if (t == null)
                CreateTemplate(x, TheArgs);
            return TheArgs;
        }
        private List<IItem> GetRowSourceItems(ContextRz x)
        {
            List<IItem> l = new List<IItem>();
            foreach (PaymentBatchDetail d in TheBatch.Details)
            {
                if (d.Order == null)
                {
                    ordhed o = new ordhed();
                    o.unique_id = "credit";
                    o.orderdate = DateTime.Now;
                    o.ordernumber = "Credit";
                    if (d.Amount > 0)
                        o.total_weight = d.Amount;
                    else
                        o.total_weight = 0;
                    l.Add(o);
                }
                else
                {
                    if (d.Amount > 0)
                        d.Order.total_weight = d.Amount;
                    else
                        d.Order.total_weight = 0;
                    l.Add(d.Order);
                }
            }
            return l;
        }
        private void CreateTemplate(ContextRz x, ListArgs TheArgs)
        {
            n_template t = (n_template)x.Item("n_template");
            t.template_name = TheArgs.TheTemplate;
            t.class_name = TheArgs.TheClass;
            t.use_gridlines = true;
            x.Insert(t);
            //orderdate
            n_column c = new n_column();
            t.InitNewColumn(c);
            CoreVarValAttribute p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "orderdate");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "Date";
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //ordernumber
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "ordernumber");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "Order";
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //orderreference
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "orderreference");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "Reference";
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //terms
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "terms");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "Terms";
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //ordertotal
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "ordertotal");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "Total";
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //outstandingamount
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "outstandingamount");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "Outstanding";
            x.Insert(c);
            t.AbsorbColumn(x, c);
            //total_weight
            c = new n_column();
            t.InitNewColumn(c);
            p = x.TheSysRz.GetPropByName(x, TheArgs.TheClass, "total_weight");
            if (p != null)
                c.AbsorbProp(p);
            c.column_caption = "Payment";
            x.Insert(c);
            t.AbsorbColumn(x, c);
        }
        private void ClearControls()
        {
            Company.CompanyID = "";
            Company.CompanyName = "";
            lblBalance.ValueSet("");
            txtMemo.ValueSet("");
            optMethod.ValueSet("manual");
            dblAmount.ValueSet(0);
            lblApplied.ValueSet(TheBatch.AppliedCaption);
            lblOpen.ValueSet(TheBatch.OpenCaption);
            cboAccount.ValueSet("");
            cboAccount.Change();
            Company.Change();
            lblBalance.Change();
            txtMemo.Change();
            optMethod.Change();
            dblAmount.Change();
            lblApplied.Change();
            lblOpen.Change();
        }
        private void ClearCompany(ContextRz x)
        {
            TheBatch.SetCompany(x, null);
            lblBalance.ValueSet(TheBatch.BalanceCaption);
            lblApplied.ValueSet(TheBatch.AppliedCaption);
            lblOpen.ValueSet(TheBatch.OpenCaption);
            dblAmount.ValueSet(0);
            optMethod.ValueSet("manual");
            Change();
        }
        private ArrayList GetAccounts(ContextRz x)
        {
            ArrayList a = new ArrayList();
            List<account> l = x.TheSysRz.TheAccountLogic.GetAccounts(x, new AccountCriteria(AccountType.Bank));
            foreach (account aa in l)
            {
                a.Add(account.GetAccountFullNameWithBullet(aa));
            }
            return a;
        }
        private RadioControlConfig GetMethodOptions()
        {
            RadioControlConfig cfg = new RadioControlConfig();
            RadioControlConfig c = new RadioControlConfig();
            c.Caption = "Manual Check";
            c.Value = "manual";
            cfg.AllOptions.Add(c);

            c = new RadioControlConfig();
            c.Caption = "Print Check";
            c.Value = "print";
            cfg.AllOptions.Add(c);

            c = new RadioControlConfig();
            c.Caption = "Debit Card";
            c.Value = "debit";
            cfg.AllOptions.Add(c);

            return cfg;
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
            sb.AppendLine(dblAmount.Select + ".focusout(function()");
            sb.AppendLine("{");
            sb.AppendLine("     var v = $('#" + dblAmount.ControlId + "').val().replace(\"$\", \"\").replace(\",\", \"\");");
            sb.AppendLine("     if(!IsNumeric(v))");
            sb.AppendLine("     {");
            sb.AppendLine("         $('#" + dblAmount.ControlId + "').val(0);");
            sb.AppendLine("         return;");
            sb.AppendLine("     }");
            sb.AppendLine("     Save('amount_changed');"); 
            sb.AppendLine("});");
            viewHandle.Definitions.Add(sb.ToString());
            if (TheBatch.BatchType == PaymentType.Customer)
            {
                viewHandle.ScriptsToRun.Add("HideDiv('billButton');");
                viewHandle.ScriptsToRun.Add("HideDiv('" + cboAccount.DivId + "');");
                viewHandle.ScriptsToRun.Add("HideDiv('" + optMethod.DivId + "');");
            }
        }
        private void AdjustControls()
        {
            Company.CompanyOnly = true;
            Company.CompanyChanged += new CompanyChangedHandler(Company_CompanyChanged);
            Company.CompanyCleared += new CompanyContactClearHandler(Company_CompanyCleared);
            txtMemo.FixedWidth = 200;            
        }
        //Control Events
        private void Company_CompanyChanged(ContextNM x, company c, ViewHandle v)
        {
            TheBatch.SetCompany((ContextRz)x, c);
            lblBalance.ValueSet(TheBatch.BalanceCaption);
            lblApplied.ValueSet(TheBatch.AppliedCaption);
            lblOpen.ValueSet(TheBatch.OpenCaption);
            CheckBatch((ContextRz)x, v);
            Display((ContextRz)x);
        }
        private void Company_CompanyCleared(ContextNM x, ViewHandle v)
        {
            ClearCompany((ContextRz)x);
        }
        private void LV_ItemDoubleClicked(Context x, IItem item, Page page, ViewHandle viewHandle)
        {
            try
            {
                ordhed o = (ordhed)item;
                foreach (PaymentBatchDetail d in TheBatch.Details)
                {
                    if (d.Order == null && Tools.Strings.StrCmp(o.ordernumber, "credit"))
                    {
                        d.ChangeAmount((ContextRz)x);
                        break;
                    }
                    if (d.Order == null)
                        continue;
                    if (Tools.Strings.StrCmp(o.unique_id, d.Order.unique_id))
                    {
                        d.ChangeAmount((ContextRz)x);
                        break;
                    }
                }
                Display((ContextRz)x);
                CheckBatch((ContextRz)x, viewHandle);                
            }
            catch { }
        }
    }
    public class ListViewSpotProcessPayments : ListViewSpotRz
    {
        public ListViewSpotProcessPayments()
            : base("ordhed")
        {
        }
        protected override List<ActHandle> FilterActsForWeb(Context x, List<ActHandle> a, IItem item)
        {
            ordhed o = (ordhed)item;
            List<ActHandle> aa = new List<ActHandle>();
            if (o == null)
                return aa;
            //Open Order
            Act act = new Core.Act("openorder", new ActHandler(OpenOrder));
            ActHandle ah = new ActHandle("openorder", "Open Order " + o.ToString());
            ah.TheAct = act;
            aa.Add(ah);
            return aa;
        }
        private void OpenOrder(Context x, ActArgs a)
        {
            ordhed o = (ordhed)a.TheItems.FirstGet(x);
            if (o == null)
                return;
            x.Show(new ShowArgsOrder(x, o, o.OrderType));
        }
    }
}