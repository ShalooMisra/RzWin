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
using NewMethodWeb;
using Rz5;
using Rz5.Web;

namespace RzWeb
{
    public class Choices : _Item
    {
        public n_choices TheChoices
        {
            get
            {
                return (n_choices)Item;
            }
        }
        TextControl txtName;
        ListViewSpotChoices lvChoices;
        String ChoicesDiv
        {
            get
            {
                return "choices_" + Uid;
            }
        }

        public Choices(ContextRz x, n_choices c)
            : base(x, c)
        {
            txtName = (TextControl)SpotAdd(ControlAdd(new TextControl("name", "Choices Name", TheChoices.name)));
            lvChoices = (ListViewSpotChoices)SpotAdd(new ListViewSpotChoices());
            lvChoices.SkipParentRender = true;
            lvChoices.TheArgs = new ListArgs(x);
            lvChoices.TheArgs.AddAllow = true;
            lvChoices.TheArgs.AddCaption = "Add New Choice";
            lvChoices.TheArgs.TheCaption = "Choices";
            lvChoices.TheArgs.TheClass = "n_choice";
            lvChoices.TheArgs.TheLimit = -1;
            lvChoices.TheArgs.TheOrder = "the_n_choices_order desc";
            lvChoices.TheArgs.TheTable = "n_choice";
            lvChoices.TheArgs.TheTemplate = "choices_choice";
            lvChoices.TheArgs.TheWhere = "the_n_choices_uid = '" + TheChoices.unique_id + "'";
            lvChoices.CurrentTemplate = n_template.GetByName(x, lvChoices.TheArgs.TheTemplate);
            if (lvChoices.CurrentTemplate == null)
                lvChoices.CurrentTemplate = n_template.Create(x, lvChoices.TheArgs.TheClass, lvChoices.TheArgs.TheTemplate);
            lvChoices.CurrentTemplate.GatherColumns(x);
            lvChoices.ColSource = new ColumnSourceTemplate(lvChoices.CurrentTemplate);
            lvChoices.RowSource = new RowSourceTable(x.Select(lvChoices.TheArgs.RenderSql(x, lvChoices.CurrentTemplate)));
            lvChoices.ItemDoubleClicked += new ItemDoubleClickHandler(lvChoices_ItemDoubleClicked);
            lvChoices.AddNewItem += new ItemAddHandler(lvChoices_AddNewItem);
            AdjustControls();
        }
        public override String Title(Context x)
        {
            return "All Choices";
        }
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"choices_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 250px; width: 590px;\">");
            txtName.Render(x, sb, screenHandle, viewHandle, session, page);
            lvChoices.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        private void AddScripts(ViewHandle viewHandle)
        {
        }
        protected override void ResizeRender(System.Text.StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, ChoicesDiv);
            RunDivToBottom(sb, ChoicesDiv);
            sb.AppendLine(txtName.Select + ".css('top', 10);");
            sb.AppendLine(txtName.Select + ".css('left', 5);");
            sb.AppendLine(lvChoices.PlaceBelow(txtName));
            sb.AppendLine(lvChoices.Select + ".css('left', 5);");
            sb.AppendLine(lvChoices.Select + ".css('width', $('#" + ChoicesDiv + "').width() - 4);");
            sb.AppendLine(lvChoices.Select + ".css('height', $('#" + ChoicesDiv + "').height() - " + lvChoices.Select + ".position().top);");
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            string s = Tools.Html.ConvertToPostString(args.ActionParams.ToLower().Trim());
            s = Tools.Html.ConvertFromPostString(s);
            switch (args.ActionId)
            {
                default:
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
        }
        private void AdjustControls()
        {
            lvChoices.ExtraStyle = "; font-size: small";
            txtName.FixedWidth = 665;
        }
        private void lvChoices_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            x.Show(new ShowArgs(x, item));
        }
        private void lvChoices_AddNewItem(Context x, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            n_choice c = TheChoices.AddNew_the_n_choice((ContextRz)x);
            c.Insert(x);
            x.Show(new ShowArgs(x, c));
            lvChoices.RowSource = new RowSourceTable(x.Select(lvChoices.TheArgs.RenderSql(x, lvChoices.CurrentTemplate)));
            lvChoices.Change();
        }
    }
    public class ListViewSpotChoices : ListViewSpotRz
    {
        public ListViewSpotChoices()
            : base("n_choice")
        {
        }
    }
}