using System;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoreWeb;
using NewMethod;

namespace NewMethodWeb
{
    public class AgentControl : Control
    {
        List<string> Agents;
        public String AgentID = "";
        public String AgentName = "";
        public String AgentIDField = "";
        public String AgentNameField = "";
        FontSize m_TextFontSize = FontSize.Inherit;
        public FontSize TextFontSize
        {
            get
            {
                return m_TextFontSize;
            }
            set
            {
                m_TextFontSize = value;
            }
        }
        Color m_TextForeColor = Color.Black;
        public Color TextForeColor
        {
            get
            {
                return m_TextForeColor;
            }
            set
            {
                m_TextForeColor = value;
                //Change();
            }
        }
        bool m_TextBold = false;
        public bool TextBold
        {
            get
            {
                return m_TextBold;
            }
            set
            {
                m_TextBold = value;
            }
        }
        FontSize m_LabelFontSize = FontSize.Inherit;
        public FontSize LabelFontSize
        {
            get
            {
                return m_LabelFontSize;
            }
            set
            {
                m_LabelFontSize = value;
            }
        }
        Color m_LabelForeColor = Color.Black;
        public Color LabelForeColor
        {
            get
            {
                return m_LabelForeColor;
            }
            set
            {
                m_LabelForeColor = value;
            }
        }
        bool m_LabelBold = false;
        public bool LabelBold
        {
            get
            {
                return m_LabelBold;
            }
            set
            {
                m_LabelBold = value;
            }
        }
        public bool Disabled = false;

        public AgentControl(String name, String caption, String agent_id, String agent_name, String agent_id_field, String agent_name_field, ArrayList agents, bool skip_parent_render = true)
            : base(name, caption, skip_parent_render)
        {
            AgentID = agent_id;
            AgentName = agent_name;
            AgentIDField = agent_id_field;
            AgentNameField = agent_name_field;
            List<string> a = new List<string>();
            foreach (string s in agents)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                a.Add(s);
            }
            Agents = a;
        }
        public override void RenderCaption(Core.Context x, StringBuilder sb)
        {
            //do nothing, handled in render control
        }
        public override void RenderControl(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            string label = "";
            if (Tools.Strings.StrExt(Caption))
                label = "<label for=\"" + ControlId + "\" " + GetLabelStyle() + " >" + Tools.Html.ConvertTextToHTML(Caption) + "</label><br />";
            string onclick = ActionScript("'choose_agent'", "'na'");
            if (Disabled)
                onclick = "#";
            string agent = AgentName;
            if (!Tools.Strings.StrExt(agent))
                agent = "&lt;click to choose&gt;";
            sb.AppendLine(label + "<a href=\"#\" onclick=\"" + onclick + "\" " + GetTextStyle() + " >" + agent + "</a>");
            sb.AppendLine("<input id=\"username_" + ControlId + "\" type=\"text\" size=\"25\" value=\"" + AgentName + "\" style=\"display: none;\" >");
            sb.AppendLine("<input id=\"userid_" + ControlId + "\" type=\"text\" size=\"25\" value=\"" + AgentID + "\" style=\"display: none;\" >");
        }
        public override string ValueAddScript(string varName)
        {
            return varName + " += '|" + AgentIDField + ":' + ConvertToPostString($('#userid_" + ControlId + "').val()) + '|" + AgentNameField + ":' + ConvertToPostString($('#username_" + ControlId + "').val());";
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
                AgentID = val.ToString();
            }
            catch { }
        }
        public override object StringToObject(String val)
        {
            return val;
        }
        private string GetLabelStyle()
        {
            string s = " style=\"";
            bool b = false;
            if (LabelForeColor != Color.Black)
            {
                b = true;
                s += " color: " + Tools.Html.GetHTMLColor(LabelForeColor) + "; ";
            }
            if (LabelBold)
            {
                b = true;
                s += " font-weight: bold; ";
            }
            if (LabelFontSize != FontSize.Inherit)
            {
                b = true;
                switch (LabelFontSize)
                {
                    case FontSize.XLarge:
                        s += " font-size: x-large; ";
                        break;
                    case FontSize.XXLarge:
                        s += " font-size: xx-large; ";
                        break;
                    case FontSize.XSmall:
                        s += " font-size: x-small; ";
                        break;
                    case FontSize.XXSmall:
                        s += " font-size: xx-small; ";
                        break;
                    default:
                        s += " font-size: " + LabelFontSize.ToString().ToLower() + "; ";
                        break;
                }
            }
            s += "\" ";
            if (!b)
                return "";
            return s;
        }
        private string GetTextStyle()
        {
            bool b = false;
            string s = "style=\"";
            if (TextForeColor != Color.Black)
            {
                b = true;
                s += " color: " + Tools.Html.GetHTMLColor(TextForeColor) + "; ";
            }
            if (TextFontSize != FontSize.Inherit)
            {
                b = true;
                switch (TextFontSize)
                {
                    case FontSize.XLarge:
                        s += " font-size: x-large; ";
                        break;
                    case FontSize.XXLarge:
                        s += " font-size: xx-large; ";
                        break;
                    case FontSize.XSmall:
                        s += " font-size: x-small; ";
                        break;
                    case FontSize.XXSmall:
                        s += " font-size: xx-small; ";
                        break;
                    default:
                        s += " font-size: " + TextFontSize.ToString().ToLower() + "; ";
                        break;
                }
            }
            if (TextBold)
            {
                b = true;
                s += " font-weight: bold; ";
            }
            if (!b)
                return "";
            s += "\"";
            return s;
        }
        public override void Act(Core.Context x, SpotActArgs args)
        {
            base.Act(x, args);
            switch (args.ActionId.ToLower())
            {
                case "choose_agent":
                    ChooseAgent(x);
                    args.SourceView.ScriptsToRun.Add("DoResize();");
                    break;
                default:
                    break;
            }
        }
        private void ChooseAgent(Core.Context x)
        {
            List<String> agentsList = new List<string>();
            foreach (String s in Agents)
            {
                agentsList.Add(s);
            }
            string agent = x.TheLeader.AskForStringFromArray("Please choose an agent below:", AgentName, agentsList);
            if (agent == null)
            {
                //User Cancelled
                return;
            }
            if (!Tools.Strings.StrExt(agent))
            {
                AgentID = "";
                AgentName = "";
                Change();
                return;
            }
            agent = Tools.Html.ConvertToPostString(agent);
            agent = Tools.Html.ConvertFromPostString(agent);
            n_user u = n_user.GetByName((ContextNM)x, agent);
            if (u == null)
                return;
            AgentID = u.unique_id;
            AgentName = u.name;
            Change();
        }
    }
}