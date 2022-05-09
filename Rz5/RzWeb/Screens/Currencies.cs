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
    public class Currencies : RzScreen
    {
        //Private Variables
        private currency TheCurrency;
        private LabelControl lblName;
        private LabelControl lblSymbol;
        private ListViewSpotCurrency LV;        
        private TextControl txtName;
        private DoubleControl dblRate;
        private TextControl txtSymbol;

        //Constructors
        public Currencies(Rz5.ContextRz context)
            : base(context)
        {
            lblName = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblName", "Base Currency Name:", "USD")));
            lblName.CaptionInLine = true;
            lblSymbol = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblSymbol", "Base Currency Symbol:", "$")));
            lblSymbol.CaptionInLine = true;
            txtName = (TextControl)SpotAdd(ControlAdd(new TextControl("ctl_name", "Name", "")));
            dblRate = (DoubleControl)SpotAdd(ControlAdd(new DoubleControl("ctl_exchange_rate", "Rate", 0)));
            txtSymbol = (TextControl)SpotAdd(ControlAdd(new TextControl("ctl_symbol", "Symbol", "")));
            LV = (ListViewSpotCurrency)SpotAdd(new ListViewSpotCurrency());
            LV.AllowExport = false;
            LV.TheArgs = new ListArgs(context);
            LV.TheArgs.TheCaption = "Currencies";
            LV.TheArgs.AddAllow = true;
            LV.TheArgs.AddCaption = "Add New Currency";
            LV.TheArgs.TheClass = "currency";
            LV.TheArgs.TheOrder = "name";
            LV.TheArgs.TheTable = "currency";
            LV.TheArgs.TheTemplate = "all_currencies_2";
            LV.CurrentTemplate = n_template.GetByName(context, LV.TheArgs.TheTemplate);
            if (LV.CurrentTemplate == null)
                LV.CurrentTemplate = n_template.Create(context, LV.TheArgs.TheClass, LV.TheArgs.TheTemplate);
            LV.CurrentTemplate.GatherColumns(context);
            LV.ColSource = new ColumnSourceTemplate(LV.CurrentTemplate);
            LV.ItemDoubleClicked += new ItemDoubleClickHandler(LV_ItemDoubleClicked);
            LV.AddNewItem += new ItemAddHandler(LV_AddNewItem);
            LoadLV(context);
            AdjustControls();
        }
        //Public Override Functions
        public override String Title(Context x)
        {
            return "Currency Manager";
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"top_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 40px;\">");
            lblName.Render(x, sb, screenHandle, viewHandle, session, page);
            lblSymbol.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"bottom_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 40px;\">");
            txtName.Render(x, sb, screenHandle, viewHandle, session, page);
            dblRate.Render(x, sb, screenHandle, viewHandle, session, page);
            txtSymbol.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("     <div id=\"save_" + Uid + "\" style=\"position: absolute; top: 1px;\">");
            sb.AppendLine("         <input type=\"button\" id=\"saveButton\" value=\"Save\" style=\"font-size: small; width: 80px; height: 50px;\" onclick=\"Save();\">");
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
                case "save":
                    SaveCurrency(xrz, d);
                    break;
            }
        }
        //Protected Override Functions
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, "top_" + Uid);
            RunDivToRight(sb, "top_" + Uid);
            sb.AppendLine(lblName.Select + ".css('left', 10);");
            sb.AppendLine(lblSymbol.PlaceRight(lblName));
            PlaceDivBelowDiv(sb, LV.DivId, "top_" + Uid);
            sb.AppendLine(LV.Select + ".css('left', 5);");
            LV.RunToRight(sb);
            PlaceDivAtBottom(sb, "bottom_" + Uid);
            RunDivToRight(sb, "bottom_" + Uid);
            sb.AppendLine(LV.Select + ".css('height', $('#bottom_" + Uid + "').position().top - " + LV.Select + ".position().top - 10);");
            sb.AppendLine(txtName.Select + ".css('left', 10);");
            sb.AppendLine(dblRate.PlaceRight(txtName));
            sb.AppendLine(txtSymbol.PlaceRight(dblRate));
            sb.AppendLine("$('#save_" + Uid + "').css('left', " + txtSymbol.Select + ".position().left + " + txtSymbol.Select + ".width() + 5);");
        }
        //Private Functions
        private void SaveCurrency(ContextRz x, Dictionary<string, string> d)
        {
            if (TheCurrency == null)
            {
                TheCurrency = new currency();
                TheCurrency.Insert(x);
            }
            string s = "";
            d.TryGetValue("ctl_name", out s);
            TheCurrency.name = s;
            s = "";
            d.TryGetValue("ctl_exchange_rate", out s);            
            double rate = 0;
            try { rate = Convert.ToDouble(s); }
            catch { }
            TheCurrency.exchange_rate = rate;
            s = "";
            d.TryGetValue("ctl_symbol", out s);
            TheCurrency.symbol = s;
            TheCurrency.Update(x);
            LoadLV(x);
            LoadCurrency(new currency());
            TheCurrency = null;
        }
        private void LoadCurrency(currency c)
        {
            if (c == null)
                return;
            txtName.ValueSet(c.name);
            dblRate.ValueSet(c.exchange_rate);
            txtSymbol.ValueSet(c.symbol);
            txtName.Change();
            dblRate.Change();
            txtSymbol.Change();
        }
        private void LoadLV(ContextRz x)
        {
            LV.RowSource = new RowSourceTable(x.Select(LV.TheArgs.RenderSql(x, LV.CurrentTemplate)));
            LV.Change();                                              
        }        
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function Save()");
            sb.AppendLine("{");
            sb.AppendLine("var data = \"\";");
            foreach (CoreWeb.Control c in Controls)
            {
                if (!c.IgnoreOnSave)
                    sb.AppendLine(c.ValueAddScript("data"));
            }
            sb.AppendLine(ActionScript("'save'", "data"));
            sb.AppendLine("}");
            viewHandle.Definitions.Add(sb.ToString());
        }
        private void AdjustControls()
        {
            lblName.CaptionFontSize = FontSize.XXLarge;
            lblName.TextFontSize = FontSize.XXLarge;
            lblName.TextForeColor = Color.Blue;
            lblSymbol.CaptionFontSize = FontSize.XXLarge;
            lblSymbol.TextFontSize = FontSize.XXLarge;
            lblSymbol.TextForeColor = Color.Blue;
            lblSymbol.AddPaddingCaption(GenAlign.Left, 50);
        }
        private void LV_ItemDoubleClicked(Context x, IItem item, Page page, ViewHandle viewHandle)
        {
            TheCurrency = (currency)item;
            LoadCurrency(TheCurrency);
        }
        private void LV_AddNewItem(Context x, Page page, ViewHandle viewHandle)
        {
            TheCurrency = currency.New(x);
            TheCurrency.Insert(x);
            LoadCurrency(TheCurrency);
        }
    }
    public class ListViewSpotCurrency : ListViewSpotRz
    {
        public ListViewSpotCurrency()
            : base("currency")
        {
 
        }
    }
}
