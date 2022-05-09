using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Text;
using Core;
using CoreWeb;
using NewMethod;
using Rz5;
using System.Web.UI;

namespace RzWeb
{
    public class PackControl : CoreWeb.Control
    {
        public event EventHandler PackRefreshed;
        ContextRz TheContext;
        Rz5.Web.RzScreen TheControlScreen
        {
            get
            {
                return (Rz5.Web.RzScreen)TheScreen;
            }
        }
        ViewHandle TheView;
        System.Web.SessionState.HttpSessionState TheSession;
        System.Web.UI.Page ThePage;
        protected pack ThePack;
        protected orddet_line TheLine;
        protected VarRefPacks TheVar;
        protected bool RequireStock = false;
        protected bool IsPick = false;
        Rz5.Enums.OrderType TheType = Rz5.Enums.OrderType.Any;
        ListViewSpotlvPacks lvPacks;
        Int32Control txtQuantity;
        TextControl txtMFG;
        TextControl txtDC;
        RzWeb.ChoicesControl cboCond;
        RzWeb.ChoicesControl cboPkg;
        TextControl txtLoc;
        TextControl txtBox;
        TextControl txtLot;
        TextControl txtSerial;

        public PackControl(String name, String caption, Context x, Screen screenHandle, VarRefPacks var, orddet_line line, bool require_stock, bool is_pick, Rz5.Enums.OrderType type, bool skip_parent_render = true)
            : base(name, caption, skip_parent_render)
        {
            TheScreen = screenHandle;
            TheContext = (ContextRz)x;
            TheLine = line;
            TheVar = var;
            RequireStock = require_stock;
            IsPick = is_pick;
            TheType = type;
            lvPacks = (ListViewSpotlvPacks)SpotAdd(TheControlScreen, new ListViewSpotlvPacks());
            lvPacks.SkipParentRender = true;
            InitLV();
            txtQuantity = (Int32Control)SpotAdd(TheControlScreen, ControlAdd(new Int32Control("quantity", "Quantity", 0)));
            txtMFG = (TextControl)SpotAdd(TheControlScreen, ControlAdd(new TextControl("manufacturer", "Manufacturer", "")));
            txtDC = (TextControl)SpotAdd(TheControlScreen, ControlAdd(new TextControl("datecode", ((ContextRz)x).DateCodeCaption, "")));
            cboCond = (RzWeb.ChoicesControl)SpotAdd(TheControlScreen, ControlAdd(new RzWeb.ChoicesControl("condition", "Condition", "", GetChoiceList(TheContext, "condition"), "", "condition")));
            cboPkg = (RzWeb.ChoicesControl)SpotAdd(TheControlScreen, ControlAdd(new RzWeb.ChoicesControl("packaging", "Packaging", "", GetChoiceList(TheContext, "packaging"), "", "packaging")));
            txtLoc = (TextControl)SpotAdd(TheControlScreen, ControlAdd(new TextControl("location", "Location", "")));
            txtBox = (TextControl)SpotAdd(TheControlScreen, ControlAdd(new TextControl("boxnum", "Box Number", "")));
            txtLot = (TextControl)SpotAdd(TheControlScreen, ControlAdd(new TextControl("lot_code", "Lot Number", "")));
            txtSerial = (TextControl)SpotAdd(TheControlScreen, ControlAdd(new TextControl("serial", "Serial Number", "")));

            if (IsPick)
            {
                txtMFG.Visible = false;
                txtDC.Visible = false;
                cboCond.Visible = false;
                cboPkg.Visible = false;
                txtLoc.Visible = false;
                txtBox.Visible = false;
                txtLot.Visible = false;
                txtSerial.Visible = false;
            }
            AdjustControls();
        }
        private void InitLV()
        {
            ListArgs args = null;
            if (IsPick)
            {
                if (TheType == Rz5.Enums.OrderType.Invoice)
                    args = TheLine.PacksOutArgs(TheContext);
                else if (TheType == Rz5.Enums.OrderType.VendRMA)
                    args = TheLine.PacksVendRMAArgs(TheContext);
            }
            else
            {
                if (TheType == Rz5.Enums.OrderType.Purchase)
                    args = TheLine.PacksInArgs(TheContext);
                else if (TheType == Rz5.Enums.OrderType.RMA)
                    args = TheLine.PacksRMAArgs(TheContext);
            }
            args.OptionsAllow = true;
            args.AddAllow = false;
            args.TheCaption = "Items";  //this enables the tools view
            lvPacks.TheArgs = args;
            lvPacks.CurrentTemplate = n_template.GetByName(TheContext, lvPacks.TheArgs.TheTemplate);
            if (lvPacks.CurrentTemplate == null)
                lvPacks.CurrentTemplate = n_template.Create(TheContext, lvPacks.TheArgs.TheClass, lvPacks.TheArgs.TheTemplate);
            lvPacks.CurrentTemplate.GatherColumns(TheContext);
            lvPacks.ColSource = new ColumnSourceTemplate(lvPacks.CurrentTemplate);
            lvPacks.RowSource = new RowSourceItem(lvPacks.TheArgs.LiveItems.AllGet(TheContext));
            lvPacks.ItemDoubleClicked += new ItemDoubleClickHandler(lvPacks_ItemDoubleClicked);
        }
        public String ControlId
        {
            get
            {
                return "packs_" + Uid;
            }
        }
        public override void RenderCaption(Core.Context x, StringBuilder sb)
        {
            //do nothing, handled in render control
        }
        public override void RenderControl(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            TheView = viewHandle;
            TheSession = session;
            ThePage = page;
            sb.AppendLine("<div id=\"packs_" + Uid + "\" style=\"position: absolute; top: 0px; left: 0px; font-size: small;\">");
            lvPacks.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"cmdnew_" + Uid + "\" style=\"position: absolute; top: 0px; left: 0px; font-size: small;\">");
            sb.AppendLine("<input id=\"cmdNew\" type=\"button\" value=\"New\" onclick=\"" + ActionScript("'new'") + "\">");
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"packentry_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; top: 0px; left: 0px; font-size: small;\">");
            txtQuantity.Render(x, sb, screenHandle, viewHandle, session, page);
            txtMFG.Render(x, sb, screenHandle, viewHandle, session, page);
            txtDC.Render(x, sb, screenHandle, viewHandle, session, page);
            cboCond.Render(x, sb, screenHandle, viewHandle, session, page);
            cboPkg.Render(x, sb, screenHandle, viewHandle, session, page);
            txtLoc.Render(x, sb, screenHandle, viewHandle, session, page);
            txtBox.Render(x, sb, screenHandle, viewHandle, session, page);
            txtLot.Render(x, sb, screenHandle, viewHandle, session, page);
            txtSerial.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"cmdok_" + Uid + "\" style=\"position: absolute; top: 0px; left: 0px; font-size: small;\">");
            sb.AppendLine("<input id=\"cmdOK\" type=\"button\" value=\"OK\" onclick=\"OKClicked();\">");
            Buttonize(viewHandle, "cmdOK", "check.png");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        public override object StringToObject(String val)
        {
            return val;
        }
        public override string ValueAddScript(string varName)
        {
            return "";
        }
        public override bool ValueEquals(Object val)
        {
            //Need to figure this out further
            return false;
        }
        public override void ValueSet(Object val)
        {
            try
            {
                //Need to figure this out further                
            }
            catch { }
        }
        //public override String ValueSetScript
        //{
        //    get
        //    {
        //        return "";
        //    }
        //}
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            sb.AppendLine("$('#packs_" + Uid + "').css('width', " + this.Select + ".width());");
            sb.AppendLine("$('#packs_" + Uid + "').css('height', " + this.Select + ".height());");
            sb.AppendLine(lvPacks.Select + ".css('top', 5);");
            sb.AppendLine(lvPacks.Select + ".css('width', $('#packs_" + Uid + "').width());");
            sb.AppendLine("$('#packentry_" + Uid + "').css('width', $('#packs_" + Uid + "').width());");
            sb.AppendLine("$('#packentry_" + Uid + "').css('height', 115);");
            sb.AppendLine("$('#packentry_" + Uid + "').css('left', -6);");
            sb.AppendLine("$('#packentry_" + Uid + "').css('top', $('#packs_" + Uid + "').height() - 115);");
            sb.AppendLine("$('#cmdnew_" + Uid + "').css('left', 0);");
            sb.AppendLine("$('#cmdnew_" + Uid + "').css('width', $('#packentry_" + Uid + "').width());");
            sb.AppendLine("$('#cmdnew_" + Uid + "').css('height', 25);");
            sb.AppendLine("$('#cmdnew_" + Uid + "').css('top', ($('#packs_" + Uid + "').height() - $('#packentry_" + Uid + "').height()) - $('#cmdnew_" + Uid + "').height() + 6);");
            sb.AppendLine("$('#cmdNew').css('width', $('#packentry_" + Uid + "').width());");
            sb.AppendLine(txtQuantity.Select + ".css('top', 5);");
            sb.AppendLine(txtQuantity.Select + ".css('left', 5);");
            sb.AppendLine(txtMFG.Select + ".css('top', 5);");
            sb.AppendLine(txtMFG.PlaceRight(txtQuantity));
            sb.AppendLine(txtDC.Select + ".css('top', 5);");
            sb.AppendLine(txtDC.PlaceRight(txtMFG));
            sb.AppendLine(cboCond.Select + ".css('top', 5);");
            sb.AppendLine(cboCond.PlaceRight(txtDC));
            sb.AppendLine(cboPkg.PlaceBelow(txtQuantity));
            sb.AppendLine(cboPkg.Select + ".css('left', 5);");
            sb.AppendLine(txtLoc.PlaceBelow(txtQuantity));
            sb.AppendLine(txtLoc.PlaceRight(cboPkg));
            sb.AppendLine(txtBox.PlaceBelow(txtQuantity));
            sb.AppendLine(txtBox.PlaceRight(txtLoc));
            sb.AppendLine(txtLot.PlaceBelow(txtQuantity));
            sb.AppendLine(txtLot.PlaceRight(txtBox));

            sb.AppendLine(txtSerial.PlaceBelow(txtBox));
            sb.AppendLine(txtSerial.Select + ".css('left', 5);");

            sb.AppendLine("$('#cmdok_" + Uid + "').css('top', 10);");
            sb.AppendLine("$('#cmdok_" + Uid + "').css('left', $('#packentry_" + Uid + "').width() - $('#cmdok_" + Uid + "').width() - 5);");
            sb.AppendLine(lvPacks.Select + ".css('height', $('#cmdnew_" + Uid + "').position().top - " + lvPacks.Select + ".position().top - 5);");
            base.ResizeRender(sb, page);
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function OKClicked() {");
            sb.AppendLine("var data = \"\";");
            foreach (CoreWeb.Control c in Controls)
            {
                sb.AppendLine(c.ValueAddScript("data"));
            }
            sb.AppendLine(ActionScript("'ok_clicked'", "data"));
            sb.AppendLine("}");
            viewHandle.Definitions.Add(sb.ToString());
            viewHandle.ScriptsToRun.Add("$('#cmdNew').css('padding', '0px 6px 0px 6px').button();");  //top, right, bottom, left
        }
        private void AdjustControls()
        {
            lvPacks.ExtraStyle = "; font-size: small";
            txtQuantity.CaptionFontSize = FontSize.XXSmall;
            txtQuantity.TextFontSize = FontSize.XXSmall;
            txtQuantity.FixedWidth = 113;
            txtMFG.CaptionFontSize = FontSize.XXSmall;
            txtMFG.TextFontSize = FontSize.XXSmall;
            txtMFG.FixedWidth = 113;
            txtDC.CaptionFontSize = FontSize.XXSmall;
            txtDC.TextFontSize = FontSize.XXSmall;
            txtDC.FixedWidth = 113;
            cboCond.CaptionFontSize = FontSize.XXSmall;
            cboCond.TextFontSize = FontSize.XXSmall;
            cboCond.FixedWidth = 120;
            cboPkg.CaptionFontSize = FontSize.XXSmall;
            cboPkg.TextFontSize = FontSize.XXSmall;
            cboPkg.FixedWidth = 120;
            txtLoc.CaptionFontSize = FontSize.XXSmall;
            txtLoc.TextFontSize = FontSize.XXSmall;
            txtLoc.FixedWidth = 113;
            txtBox.CaptionFontSize = FontSize.XXSmall;
            txtBox.TextFontSize = FontSize.XXSmall;
            txtBox.FixedWidth = 113;
            txtLot.CaptionFontSize = FontSize.XXSmall;
            txtLot.TextFontSize = FontSize.XXSmall;
            txtLot.FixedWidth = 113;
            txtSerial.CaptionFontSize = FontSize.XXSmall;
            txtSerial.TextFontSize = FontSize.XXSmall;
            txtSerial.FixedWidth = 250;
        }
        private ArrayList GetChoiceList(ContextRz x, string listname)
        {
            ArrayList a = new ArrayList();
            n_choices ch = n_choices.GetByName(x, listname);
            if (ch == null)
                return a;
            ch.CacheChoiceList(x);
            foreach (n_choice c in ch.AllChoices)
            {
                a.Add(c.name);
            }
            return a;
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            string s = Tools.Html.ConvertToPostString(args.ActionParams.ToLower().Trim());
            s = Tools.Html.ConvertFromPostString(s);
            switch (args.ActionId)
            {
                case "ok_clicked":
                    DoOK((ContextRz)x, args.ActionParams);
                    break;
                case "new":
                    DoNew((ContextRz)x);
                    break;
                default:
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
        }
        private void DoOK(ContextRz x, String s)
        {
            Dictionary<string, string> d = ParseValueString(s);
            if (d == null)
                return;
            if (ThePack == null)
            {
                DoNew(x, true);
                //x.TheLeader.Tell("You need to first select or create a new pack/receive item before saving.");
                //return; 
            }
            foreach (CoreWeb.Control c in Controls)
            {
                string[] names = Tools.Strings.Split(c.Name, "|");
                foreach (string name in names)
                {
                    if (d.ContainsKey(name))
                    {
                        try { ThePack.ValSet(name, c.StringToObject(d[name].ToString())); }
                        catch { }
                    }
                }
            }
            bool failed = false;
            try { x.TheDelta.Update(x, ThePack); }
            catch (Exception ex)
            { x.TheLeader.Tell("Failed to save: " + ex.Message); failed = true; }
            if (!IsPick)
            {
                TheLine.datecode = ThePack.datecode;
                TheLine.manufacturer = ThePack.manufacturer;
                TheLine.packaging = ThePack.packaging;
                TheLine.condition = ThePack.condition;
                TheLine.receive_location = ThePack.location;
                TheLine.lotnumber = ThePack.lot_code;
                TheLine.Update(x);
            }
            if (!failed)
            {
                ThePack = null;
                SetControls(ThePack);
            }
            lvPacks.RowSource = new RowSourceItem(lvPacks.TheArgs.LiveItems.AllGet(TheContext));
            lvPacks.Change();
            if (PackRefreshed != null)
                PackRefreshed(this, new EventArgs());
        }
        private void DoNew(ContextRz x, bool skip_set = false)
        {
            if (!x.TheLeader.AreYouSure("you want to create a new entry"))
                return;
            partrecord stock = null;
            if (RequireStock)
            {
                stock = (partrecord)TheLine.LinkedInventory(x);
                if (stock == null)
                    stock = ((Rz5.Web.LeaderWebUserRz)x.TheLeader).AskForInventoryItem((Rz5.ContextRz)x, "Please choose a stock item:", TheLine.fullpartnumber, TheScreen, TheView, TheSession, ThePage);
                if (stock == null)
                    return;
                if (stock.quantity == 0)
                {
                    x.TheLeader.Error(stock.ToString() + " has zero quantity");
                    return;
                }
            }
            ThePack = (pack)TheVar.RefAddNewItem(x);
            if (stock != null)
            {
                ThePack.ThePartSet(x, stock);
                if (stock.quantity < ThePack.quantity)
                    ThePack.quantity = Convert.ToInt32(stock.quantity);
                ThePack.Update(x);
            }
            if (!skip_set)
                SetControls(ThePack);
        }
        private void SetControls(pack p)
        {
            if (p == null)
                p = new pack();

            txtQuantity.ValueSet(p.quantity);
            txtMFG.ValueSet(p.manufacturer);
            txtDC.ValueSet(p.datecode);
            cboCond.ValueSet(p.condition);
            cboPkg.ValueSet(p.packaging);
            txtLoc.ValueSet(p.location);
            txtBox.ValueSet(p.boxnum);
            txtLot.ValueSet(p.lot_code);
            txtSerial.ValueSet(p.serial);

            txtQuantity.Change();
            txtMFG.Change();
            txtDC.Change();
            cboCond.Change();
            cboPkg.Change();
            txtLoc.Change();
            txtBox.Change();
            txtLot.Change();
            txtSerial.Change();
        }
        private void lvPacks_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            if (item == null)
                return;
            //ThePack = (pack)item;
            ThePack = (pack)TheVar.Find(x, item.Uid);
            SetControls(ThePack);
        }
    }
    public class ListViewSpotlvPacks : Rz5.Web.ListViewSpotRz
    {
        public ListViewSpotlvPacks()
            : base("pack")
        {
        }
    }
}
