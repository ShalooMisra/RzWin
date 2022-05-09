using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreWeb;
using NewMethod;
using Core;
using Rz5;

namespace RzWeb
{
    public class ChoicesControl : CoreWeb.ComboBoxControl
    {
        public bool AllowChoiceEdit = true;
        public String ChoiceList = "";

        public ChoicesControl(String name, String caption, String value, ArrayList choices, String on_change = "", String choice_list = "", bool skip_parent_render = true)
            : base(name, caption, value, choices, on_change, skip_parent_render)
        {
            ChoiceList = choice_list;
        }
        public override void RenderCaption(Core.Context x, StringBuilder sb)
        {
            string s = "";
            if (!CaptionInLine)
                s = "<br />";
            if (Tools.Strings.StrExt(Caption))
            {
                if (AllowChoiceEdit && Tools.Strings.StrExt(ChoiceList))
                {
                    //sb.AppendLine("<label id=\"" + Caption + "_" + Uid + "\" " + GetCaptionStyle() + " >" + Tools.Html.ConvertTextToHTML(Caption) + "</label>" + s);
                    //sb.AppendLine("<div id=\"div_add_" + Uid + "\" style=\"position: absolute; top: 0px;\"><input id=\"cmdAdd_" + Uid + "\" type=\"button\" value=\"\" style=\"float: right;\" onclick=\"" + ActionScript("'edit_choice'") + "\"></div>");
                    //sb.AppendLine("<script type=\"text/javascript\">buttonize('cmdAdd_" + Uid + "', 'add_choice.png'); $('#cmdAdd_" + Uid + "').css('padding', '0px 0px 0px 0px').button(); $('#cmdAdd_" + Uid + "').css('width', 14); $('#cmdAdd_" + Uid + "').css('height', 12); $('#cmdAdd_" + Uid + "').css('background-position', 'center 0px');</script>");// $('#cmdAdd_" + id + "').css('top', -1);

                    sb.AppendLine("<label id=\"" + Caption + "_" + Uid + "\" " + GetCaptionStyle() + " >" + Tools.Html.ConvertTextToHTML(Caption) + "</label>" + s);
                    sb.AppendLine("<div id=\"div_add_" + Uid + "\" style=\"position: absolute; top: 0px;\"><img border=\"0\" src=\"Graphics/add_choice.png\" id=\"cmdAdd_" + Uid + "\" type=\"button\" value=\"\" style=\"float: right; cursor: pointer;\" onclick=\"" + ActionScript("'edit_choice'") + "\" /></div>");
                    //sb.AppendLine("<script type=\"text/javascript\">buttonize('cmdAdd_" + Uid + "', ''); $('#cmdAdd_" + Uid + "').css('padding', '0px 0px 0px 0px').button(); $('#cmdAdd_" + Uid + "').css('width', 14); $('#cmdAdd_" + Uid + "').css('height', 12); $('#cmdAdd_" + Uid + "').css('background-position', 'center 0px');</script>");// $('#cmdAdd_" + id + "').css('top', -1);
                }
                else
                    sb.AppendLine("<label id=\"" + Caption + "_" + Uid + "\" " + GetCaptionStyle() + " >" + Tools.Html.ConvertTextToHTML(Caption) + "</label>" + s);
            }
        }
        public override void Act(Core.Context x, SpotActArgs args)
        {
            base.Act(x, args);
            switch (args.ActionId)
            {
                case "edit_choice":
                    AddNewChoice((ContextRz)x);
                    break;
                default:
                    break;
            }
        }
        public override string GetStyle()
        {
            string s = base.GetStyle().Trim().TrimEnd(new char[] { '\"' });
            s += " width: " + FixedWidth.ToString() + "px;\"";
            return s;
        }
        private void AddNewChoice(ContextRz x)
        {
            string s = x.Leader.AskForString("Please enter a new choice below:");
            if (!Tools.Strings.StrExt(s))
                return;
            n_choices ch = n_choices.GetByName(x, ChoiceList);
            if (ch == null)
            {
                ValueSet(s);
                Change();
                return;
            }
            if (!x.TheLeader.AskYesNo("Would you like to add this entry to the choice list?"))
            {
                ValueSet(s);
                Change();
                return;
            }
            n_choice c = ch.AddChoice(x, s);
            if (c == null)
                return;
            ch.CacheChoiceList(x);
            Choices = new ArrayList();
            foreach (n_choice n in ch.ChoicesList(x))
            {
                Choices.Add(n.name);
            }
            ValueSet(s);
            Change();
        }
        protected override void ResizeRender(StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            sb.AppendLine("$('#div_add_" + Uid + "').css('left', $('#" + ControlId + "').width() - 14);");
        }
    }
}
