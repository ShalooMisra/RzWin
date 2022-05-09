using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Core;
using CoreWeb;
using NewMethod;
using Rz5;
using System.Web.UI;

namespace Rz5.Web
{
    public class _Item : RzScreen
    {
        public ContextRz Context;
        protected IItem Item;
        protected ActionSpot xActions;

        public _Item(Context x, IItem item)
            : base(x)
        {
            Context = (ContextRz)x;
            Item = item;

            if (Item == null)
                throw new Exception("No item to display");

            xActions = (ActionSpot)SpotAdd(new ActionSpot(Context, (nObject)Item));
        }
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            sb.AppendLine(PlaceBelowMenu(xActions));
            sb.AppendLine(xActions.Select + ".css('left', $(window).width() - (" + xActions.WidthGetScript + " + 5));");
            sb.AppendLine(xActions.HeightSetScript("$(window).height() - (" + xActions.Select + ".position().top + 5)"));
        }
        public void SaveScreen(ViewHandle viewHandle, bool close_screen = false)
        {
            string tf = "false";
            if (close_screen)
                tf = "true";
            viewHandle.ScriptsToRun.Add("ItemSave(" + tf + ");");
        }
        public void Save(Context x, SpotActArgs args)
        {
            SaveData(x, args);            
            try
            {
                CheckData(x, args);
                Context.TheDelta.Update(Context, Item);
            }
            catch (Exception ex)
            {                
                x.TheLeader.Tell("Failed to save: " + ex.Message);
            }
            Change();
            ShowChanges(x, args);
        }
        protected void SaveData(Context x, SpotActArgs args)
        {
            Dictionary<string, string> values = ParseValueString(args.ActionParams); //parse the args into a named value list  
            foreach (CoreWeb.Control c in Controls)
            {
                string[] names = Tools.Strings.Split(c.Name, "|");
                foreach (string name in names)
                {
                    if (values.ContainsKey(name))
                    {
                        try { Item.ValSet(name, c.StringToObject(values[name].ToString())); }
                        catch { }
                    }
                }
            }
            SaveData(x, args, values);
        }
        protected virtual void SaveData(Context x, SpotActArgs args, Dictionary<string, string> values)
        {
            //if (ThePart == null)
            //{
            //    x.TheLeader.Tell("This part does not exist.");
            //    return;
            //}
            //string[] str = Tools.Strings.Split(args.ActionParams, "|");
            //if (!Tools.Strings.StrCmp(str[0], "undefined"))
            //{
            //    ThePart.StockType = Rz5.Enums.StockType.Stock;
            //    ThePart.lotnumber = Rz5.consignment_code.ParseCode(str[3]);
            //}
            //if (!Tools.Strings.StrCmp(str[1], "undefined"))
            //{
            //    ThePart.StockType = Rz5.Enums.StockType.Consign;
            //    ThePart.lotnumber = Rz5.consignment_code.ParseCode(str[4]);
            //}
            //if (!Tools.Strings.StrCmp(str[2], "undefined"))
            //    ThePart.StockType = Rz5.Enums.StockType.Excess;
            //ThePart.fullpartnumber = str[5];
            //ThePart.release = str[6];
            //ThePart.serial = str[7];
            //if (Tools.Number.IsNumeric(str[8]))
            //    ThePart.quantity = Convert.ToInt64(str[8]);
            //ThePart.location = str[9];
            //ThePart.boxnum = str[10];
            //ThePart.condition = str[11];
            //ThePart.boxcode = str[12];
            //if (!Tools.Strings.StrCmp(str[13], "undefined"))
            //    ThePart.clean = true;
            //else
            //    ThePart.clean = false;
            //if (!Tools.Strings.StrCmp(str[14], "undefined"))
            //    ThePart.reserved = true;
            //else
            //    ThePart.reserved = false;
            //ThePart.notes = str[15];
            //ThePart.alternatepart = str[16];
            //if (Tools.Number.IsNumeric(str[17]))
            //    ThePart.cost = Convert.ToDouble(str[17]);
        }
        protected virtual void CheckData(Context x, SpotActArgs args)
        {
            //override and throw exception if object does not have what is needed to save
        }
        void ShowChanges(Context x, SpotActArgs args)
        {
            foreach (CoreWeb.Control c in Controls)
            {
                //get the value from Item
                //compare it to the current control value
                //if it isn't equal, add the line to update the value

                Object val = null;
                try { val = Item.ValGet(c.Name); }
                catch { continue; }
                if (!c.ValueEquals(val))
                {
                    c.ValueSet(val);
                    //args.SourceView.ScriptsToRun.Add(c.ValueSetScript);
                }
            }
        }
        public override string ScriptToolsRender(System.Web.UI.Page page, ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ScriptToolsRender(page, viewHandle));            
            sb.AppendLine("function ItemSave(close) {");
            sb.AppendLine("var data = \"\";");
            //add each of the control values
            foreach (CoreWeb.Control c in Controls)
            {
                if (!c.IgnoreOnSave)
                    sb.AppendLine(c.ValueAddScript("data"));
            }
            sb.AppendLine("if( close ) " + ActionScript("'saveexit'", "data") + " else " + ActionScript("'save'", "data"));
            sb.AppendLine("}");
            return sb.ToString();
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            switch (args.ActionId.ToLower())
            {
                case "save":
                    Save(x, args);
                    break;
                case "saveexit":
                    Save(x, args);
                    args.SourceView.ScriptsToRun.Add("window.close();");
                    break;
                case "note":
                    break;
            }
        }
    }
}
