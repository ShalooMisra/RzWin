using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;

using Core;
using System.Web;

namespace CoreWeb
{
    public class Spot
    {
        public int TopAbs = 0;
        public int LeftAbs = 0;
        public int WidthAbs = 0;
        public int HeightAbs = 0;

        public Screen TheScreen;
        public Spot ParentSpot;
        public List<Spot> Spots = new List<Spot>();

        public DateTime ChangeDate = DateTime.Now;
        public DateTime ContainsChangesDate = DateTime.Now;
        public bool HideOverflow = true;
        public bool SkipParentRender = false;

        public Object ChangeLock = new Object();

        int m_DivIndex = 0;
        public int DivIndex
        {
            get
            {
                return m_DivIndex;
            }
            set
            {
                m_DivIndex = value;
                //Change();
            }
        }

        public String Uid = Tools.Strings.GetNewID();
        public bool RelativeY = false;

        Dictionary<GenAlign, int> Margins = new Dictionary<GenAlign, int>();
        Dictionary<GenAlign, int> Padding = new Dictionary<GenAlign, int>();

        protected List<Control> Controls = new List<Control>();

        public Control ControlAdd(Control c)
        {
            Controls.Add(c);
            return c;
        }
        public Dictionary<string, string> ParseValueString(string param)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            string[] all = Tools.Strings.Split(param, "|");
            foreach (string s in all)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                string name = Tools.Strings.ParseDelimit(s, ":", 1).Trim();
                string val = Tools.Html.ConvertFromPostString(Tools.Strings.ParseDelimit(s, ":", 2));
                try
                {
                    if (Tools.Strings.StrExt(name))
                        d.Add(name, val);
                }
                catch { }
            }
            return d;
        }

        public void ControlValuesSet(System.Web.HttpRequest request)
        {
            foreach (Control c in Controls)
            {
                c.ValueSetFromRequest(request);
            }
        }

        public void ChangedSpots(List<Spot> changed, DateTime cutoff)
        {
            if (ChangeDate > cutoff)
            {
                changed.Add(this);
            }
            else
            {
                foreach (Spot c in Spots)
                {
                    c.ChangedSpots(changed, cutoff);
                }
            }
        }

        public Point Location
        {
            get
            {
                return new Point(Convert.ToInt32(LeftAbs), Convert.ToInt32(TopAbs));
            }

            set
            {
                LeftAbs = value.X;
                TopAbs = value.Y;
                Change();
            }
        }

        public Size Size
        {
            get
            {
                return new Size(Convert.ToInt32(WidthAbs), Convert.ToInt32(HeightAbs));
            }

            set
            {
                WidthAbs = value.Width;
                HeightAbs = value.Height;
                Change();
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(Location, Size);
            }
        }

        Color m_BackColor = Color.White;
        public Color BackColor
        {
            get
            {
                return m_BackColor;
            }

            set
            {
                m_BackColor = value;
                Change();
            }
        }

        public virtual void Change()
        {
            ChangeDate = DateTime.Now;
            if (ParentSpot != null)
                ParentSpot.ContainsChanges();
        }

        public void ContainsChanges()
        {
            ContainsChangesDate = DateTime.Now;
            if (ParentSpot != null)
                ParentSpot.ContainsChanges();
        }

        public virtual Spot SpotAdd(Screen screen, Spot s)
        {
            Spots.Add(s);
            s.ParentSpot = this;
            s.TheScreen = screen;

            ContainsChanges();

            return s;
        }

        public virtual void SpotRemove(Spot s)
        {
            Spots.Remove(s);
            foreach (ViewHandle vh in TheScreen.ViewsList())
            {
                vh.ControlsToRemove.Add(s.DivId);
            }
            ContainsChanges();
        }

        public Spot SpotById(String id)
        {
            if (id == Uid)
                return this;
            foreach (Spot h in Spots)
            {
                if (h.Uid == id)
                    return h;
                Spot sp = h.SpotById(id);
                if (sp != null)
                    return sp;
            }
            return null;
        }

        public virtual void Act(Context x, SpotActArgs args)
        {

        }

        public virtual void ActsList(Context x, List<String> ids, List<ActHandle> acts, HttpRequest request)
        {
        }

        public static String DivIdConvert(String id)
        {
            return "l_" + id;
        }

        public virtual void ResizeRenderAll(StringBuilder sb, System.Web.UI.Page page)
        {
            int targetLevel = 0;
            while (ResizeRender(sb, targetLevel, 0, page))
            {
                targetLevel++;
            }
        }

        public bool ResizeRender(StringBuilder sb, int targetLevel, int currentLevel, System.Web.UI.Page page)
        {
            if (targetLevel == currentLevel)
            {
                ResizeRender(sb, page);
                return true;
            }
            else if (targetLevel > currentLevel)
            {
                currentLevel++;
                bool ret = false;
                foreach (Spot h in Spots)
                {
                    if (h.ResizeRender(sb, targetLevel, currentLevel, page))
                        ret = true;
                }
                return ret;
            }
            else
                return false;
        }

        protected virtual void ResizeRender(StringBuilder sb, System.Web.UI.Page page)
        {
        }

        public virtual String BorderRender()
        {
            return "";
        }

        public virtual void RunToRight(StringBuilder sb)
        {
            sb.AppendLine("                    RunToRight('" + Spot.DivIdConvert(Uid) + "', '" + Spot.DivIdConvert(this.ParentSpot.Uid) + "');");
        }

        public virtual void RunDivToRight(StringBuilder sb, String divId)
        {
            sb.AppendLine("                    RunToRight('" + divId + "', '" + this.DivId + "');");
        }

        public virtual void RunToBottom(StringBuilder sb)
        {
            sb.AppendLine("                    RunToBottom('" + Spot.DivIdConvert(Uid) + "', '" + Spot.DivIdConvert(this.ParentSpot.Uid) + "');");
        }

        public virtual void RunDivToBottom(StringBuilder sb, String divId)
        {
            sb.AppendLine("                    RunToBottom('" + divId + "', '" + this.DivId + "');");
        }

        public virtual void RunIdToBottom(String elementId, StringBuilder sb)
        {
            sb.AppendLine("                    RunToBottom('" + elementId + "', '" + this.DivId + "');");
        }

        public virtual void RunToBottomExcept(StringBuilder sb, String exceptDivId)
        {
            sb.AppendLine("                    RunToBottomExcept('" + Spot.DivIdConvert(Uid) + "', '" + Spot.DivIdConvert(this.ParentSpot.Uid) + "', '" + exceptDivId + "');");
        }

        public virtual void PlaceAtBottom(StringBuilder sb)
        {
            sb.AppendLine("                    PlaceAtBottom('" + Spot.DivIdConvert(Uid) + "', '" + Spot.DivIdConvert(this.ParentSpot.Uid) + "');");
        }

        public virtual void PlaceDivAtBottom(StringBuilder sb, String divId)
        {
            sb.AppendLine("                    PlaceAtBottom('" + divId + "', '" + this.DivId + "');");
        }

        public virtual void PlaceDivRightEdge(StringBuilder sb, String divId)
        {
            sb.AppendLine("                    PlaceRightEdge('" + divId + "', '" + this.DivId + "');");
        }

        public void PlaceLeftEdge(StringBuilder sb)
        {
            sb.AppendLine("                    PlaceLeftEdge('" + Spot.DivIdConvert(Uid) + "');");
        }

        public void PlaceTopEdge(StringBuilder sb)
        {
            sb.AppendLine("                    PlaceTopEdge('" + Spot.DivIdConvert(Uid) + "');");
        }

        public void PlaceDivCenterX(StringBuilder sb, String divId)
        {
            sb.AppendLine("                    PlaceDivCenterX('" + divId + "', '" + Spot.DivIdConvert(Uid) + "');");
        }

        public String DivId
        {
            get
            {
                return Spot.DivIdConvert(Uid);
            }
        }

        public String DivIdParent
        {
            get
            {
                Spot p = ParentSpot;
                if (p == null)
                    return "";
                else
                    return "l_" + p.Uid;
            }
        }

        public virtual void Render(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            RenderDefinition(x, sb, page);
            //switch (Spot.view_typeVar.ValueEnum)
            //{
            //    case SpotViewType.Point:
            //        RenderContentsPoint(x, sb, page);
            //        break;
            //    default:
            RenderContents(x, sb, screenHandle, viewHandle, session, page);
            //        break;
            //}

            sb.Append("</div>");
        }

        public virtual String PositionRender()
        {
            String position = "";
            if (RelativeY)
                position = "position: relative";
            else
                position = "position: absolute; top: " + Location.Y.ToString() + "px";

            position += "; left: " + Location.X.ToString() + "px";   //; width: " + Spot.Size.Width.ToString() + "px; height: " + Spot.Size.Height.ToString() + "px" 

            //if (WidthPct != 0)
            //    position += "; width: " + WidthPct.ToString() + "%";

            //if (!RelativeY && HeightPct != 0)
            //    position += "; height: " + HeightPct.ToString() + "%";

            return position;
        }

        public virtual void AddMargin(GenAlign a, int px)
        {
            if (Margins == null)
                Margins = new Dictionary<GenAlign, int>();
            try { Margins.Remove(a); }
            catch { }
            Margins.Add(a, px);
        }
        public virtual void AddPadding(GenAlign a, int px)
        {
            if (Padding == null)
                Padding = new Dictionary<GenAlign, int>();
            try { Padding.Remove(a); }
            catch { }
            Padding.Add(a, px);
        }

        public virtual void RenderDefinition(Context x, StringBuilder sb, System.Web.UI.Page page)
        {
            String position = PositionRender();
            String border = BorderRender();
            if (Tools.Strings.StrExt(border))
                position += "; " + border;
            String color = "";
            if (BackColor != Color.White)
                color = "; background-color: " + Tools.Html.GetHTMLColor(BackColor);
            String overflow = "";
            //if (Spot.HideOverflow)
            //    overflow = "; overflow: hidden";
            String cssClass = "";
            List<String> classes = new List<string>();
            ClassesList(x, classes);
            bool first = true;
            foreach (String cl in classes)
            {
                if (!first)
                    cssClass += " ";
                cssClass += cl;
                first = false;
            }
            String padding = "";
            if (RelativeY)
                padding = "; padding-top: 2px; padding-bottom: 2px";
            else
                padding = GetDivPaddingMargin();
            string index = "";
            if (DivIndex != 0)
                index = "; z-index: " + DivIndex.ToString();
            sb.Append("<div typename=\"" + GetType().Name + "\" class=\"" + cssClass + "\" id=\"" + DivId + "\" style=\"" + position + color + overflow + ExtraStyle + padding + index + "\">");
        }

        private string GetDivPaddingMargin()
        {
            if (Margins == null)
                Margins = new Dictionary<GenAlign, int>();
            if (Padding == null)
                Padding = new Dictionary<GenAlign, int>();
            if (Margins.Count <= 0 && Padding.Count <= 0)
                return "";
            string s = "";
            //Margins
            foreach (KeyValuePair<GenAlign, int> kvp in Margins)
            {
                if (kvp.Value <= 0)
                    continue;
                s += "; margin";
                if (kvp.Key != GenAlign.All)
                    s += "-" + kvp.Key.ToString().ToLower();
                s += ": " + kvp.Value.ToString() + "px";
            }
            //Padding
            foreach (KeyValuePair<GenAlign, int> kvp in Padding)
            {
                if (kvp.Value <= 0)
                    continue;
                s += "; padding";
                if (kvp.Key != GenAlign.All)
                    s += "-" + kvp.Key.ToString().ToLower();
                s += ": " + kvp.Value.ToString() + "px";
            }
            return s;
        }

        private String m_ExtraStyle = "";
        public virtual String ExtraStyle
        {
            get
            {
                return m_ExtraStyle;
            }
            set
            {
                m_ExtraStyle = value;
            }
        }

        protected virtual void ClassesList(Context context, List<String> classes)
        {
            classes.Add("spot-control-div");
            //if (Spot.CenterHoriz)
            //    classes.Add("center-horiz");
        }

        public virtual void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            if (Spots.Count > 0)
            {
                foreach (Spot s in Spots)
                {
                    if (!s.SkipParentRender)
                        s.Render(x, sb, screenHandle, viewHandle, session, page);
                }
            }
            //else
            //    sb.Append("<b>" + Spot.TestValue + "</b>");
        }

        public virtual void RenderContentsPoint(Context x, StringBuilder sb, System.Web.UI.Page page)
        {
            //sb.Append("<b>" + Spot.StateObject.ToString() + "</b>");
        }

        public String RenderDefinitionString(Context x, System.Web.UI.Page page)
        {
            StringBuilder sb = new StringBuilder();
            RenderDefinition(x, sb, page);
            return sb.ToString();
        }


        public String RenderContentsString(Context x, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            StringBuilder sb = new StringBuilder();
            RenderContents(x, sb, screenHandle, viewHandle, session, page);
            return sb.ToString();
        }
       
        public String ActionScript(String actionId, String actionParams = "''")
        {
            return "Action('" + TheScreen.Uid + "', '" + Uid + "', " + actionId + ", " + actionParams + ");";
        }

        public String ActionScriptPlusControls(String actionId, String actionParams = "''")
        {
            return "ActionPlusControls('" + TheScreen.Uid + "', '" + Uid + "', " + actionId + ", " + actionParams + ");";
        }

        public String Select
        {
            get
            {
                return "$('#" + DivIdConvert(Uid) + "')";
            }
        }

        public String SelectAndGet
        {
            get
            {
                return Select + ".get(0)";
            }
        }

        public String PlaceBelow(Spot spot, bool tryblock = false, int add_extra = 0, int sub_extra = 0)
        {
            return PlaceBelow(spot.DivId, spot.InnerDivId, tryblock, add_extra, sub_extra);
        }

        public virtual String PlaceBelow(String positionDiv, String sizeDiv, bool tryblock = false, int add_extra = 0, int sub_extra = 0)
        {
            //if (tryblock)
            //    return "try{" + Select + ".css('top', $('#" + divSize + "').height() + $('#" + divPosition + "').position().top + " + Screen.LayoutTheta.ToString() + " + " + add_extra + " - " + sub_extra + ");}catch(evnt){}";
            //else
            return Select + ".css('top', $('#" + sizeDiv + "').outerHeight(true) + $('#" + positionDiv + "').position().top);";  //+ Screen.LayoutTheta.ToString()
        }

        public static void PlaceDivBelow(StringBuilder sb, String divToMove, String referenceDiv)
        {
            sb.AppendLine("$('#" + divToMove + "').css('top', $('#" + referenceDiv + "').outerHeight(true) + $('#" + referenceDiv + "').position().top);");
        }

        public virtual String PlaceRight(String positionDiv, String sizeDiv, bool tryblock = false, int add_extra = 0, int sub_extra = 0)
        {
            //if (tryblock)
            //    return "try{" + Select + ".css('left', $('#" + sizeDiv + "').width() + $('#" + positionDiv + "').position().left + " + Screen.LayoutTheta.ToString() + " + " + add_extra + " - " + sub_extra + ");}catch(evnt){}";
            //else
            return Select + ".css('left', $('#" + sizeDiv + "').outerWidth(true) + $('#" + positionDiv + "').position().left);";  //  + Screen.LayoutTheta.ToString()
        }

        public static void PlaceDivRight(StringBuilder sb, String divToMove, String referenceDiv, int add_extra = 0, int sub_extra = 0)
        {
            sb.AppendLine("$('#" + divToMove + "').css('left', $('#" + referenceDiv + "').outerWidth(true) + $('#" + referenceDiv + "').position().left + " + add_extra + " - " + sub_extra + ");");
        }

        public String PlaceRight(Spot spot, bool tryblock = false, int add_extra = 0, int sub_extra = 0)
        {
            return PlaceRight(spot.DivId, spot.InnerDivId, tryblock, add_extra, sub_extra);
        }

        public virtual String WidthGetScript
        {
            get
            {
                return "$('#" + InnerDivId + "').width()";
            }
        }

        public virtual String HeightGetScript
        {
            get
            {
                return "$('#" + InnerDivId + "').height()";
            }
        }

        public virtual String HeightSetScript(String set)
        {
            return "$('#" + InnerDivId + "').css('height', " + set + ");";
        }

        public virtual String InnerDivId
        {
            get
            {
                return DivId;
            }
        }

        public virtual String SpotType
        {
            get
            {
                return "Spot";
            }
        }

        protected void AttributeAdd(XmlNode n, String name, String value)
        {
            XmlAttribute a = n.OwnerDocument.CreateAttribute(name);
            a.Value = value;
            n.Attributes.Append(a);
        }

        public virtual void XmlAbsorb(Context x, XmlNode n)
        {
        }

        public virtual void XmlRender(Context x, XmlNode n)
        {
        }

        public Spot SpotFind(String id)
        {
            foreach (Spot s in Spots)
            {
                if (s.Uid == id)
                    return s;
            }
            return null;
        }

        public Spot SpotFindRecurse(String id)
        {
            foreach (Spot s in Spots)
            {
                if (s.Uid == id)
                    return s;

                Spot ss = s.SpotFindRecurse(id);
                if (ss != null)
                    return ss;
            }
            return null;
        }

        public virtual void RequestHandle(Context x, System.Web.HttpRequest request, System.Web.HttpResponse response)
        {
        }

        public static void Buttonize(ViewHandle viewHandle, String id, String image)
        {
            if( Tools.Strings.StrExt(image) )
                viewHandle.ScriptsToRun.Add("$('#" + id + "').css('background-image', \"url('Graphics/" + image + "')\").css('background-repeat', 'no-repeat').css('background-position', 'center 2px').css('padding', '35px 6px 0px 6px').button();");  //top, right, bottom, left
            else
                viewHandle.ScriptsToRun.Add("$('#" + id + "').button();");
        }

        public static void ButtonizeNoText(ViewHandle viewHandle, String id, String image)
        {
            viewHandle.ScriptsToRun.Add("$('#" + id + "').css('background-image', \"url('Graphics/" + image + "')\").css('background-repeat', 'no-repeat').css('background-position', 'center 14px').css('padding', '35px 15px 0px 15px').button();");  //top, right, bottom, left
        }

        public static void Buttonize(ViewHandle viewHandle, String id, String image, int top = 35, int right = 6, int bottom = 0, int left = 6, int center = 2)
        {
            viewHandle.ScriptsToRun.Add("$('#" + id + "').css('background-image', \"url('Graphics/" + image + "')\").css('background-repeat', 'no-repeat').css('background-position', 'center " + center.ToString() + "px').css('padding', '" + top.ToString() + "px " + right.ToString() + "px " + bottom.ToString() + "px " + left.ToString() + "px').button();");  //top, right, bottom, left
        }

        public static String Button(ViewHandle viewHandle, String id, String caption, String image, String onClick, String extraStyle = "", int top = 35, int right = 6, int bottom = 0, int left = 6, int center = 2)
        {
            if (extraStyle != "")
                extraStyle = "; " + extraStyle;

            String ret = "<input id=\"" + id + "\" type=\"button\" style=\"margin: 4px" + extraStyle + "\" value=\"" + caption + "\" onclick=\"" + onClick + "\">";
            Spot.Buttonize(viewHandle, id, image, top, right, bottom, left, center);

            return ret;
        }

        public static String RenderWidthGap(String id)
        {
            return "($('#" + id + "').outerWidth(true) - $('#" + id + "').width())";
        }

        public static String RenderHeightGap(String id)
        {
            return "($('#" + id + "').outerHeight(true) - $('#" + id + "').height())";
        }
    }

    public class SpotActArgs
    {
        public String ActionId;
        public String ActionParams;
        public Dictionary<String, String> Vars = new Dictionary<string, string>();
        public ViewHandle SourceView;
        public System.Web.UI.Page SourcePage;
        public System.Web.HttpRequest Request;

        public SpotActArgs(System.Web.HttpRequest request, System.Web.UI.Page page, ViewHandle sourceView)
        {
            ActionId = Tools.Data.NullFilterString(request["action_id"]);
            ActionParams = Tools.Data.NullFilterString(request["action_params"]);
            SourceView = sourceView;
            SourcePage = page;

            foreach (String k in request.Form.AllKeys)
            {
                if (k.Contains("_dot_") || k.StartsWith("pos_") || k.StartsWith("ctl_"))
                {
                    Vars.Add(k.ToLower().Trim(), request[k]);
                }
            }
            Request = request;
        }

        public String Var(String name)
        {
            String key = ("ctl_" + name).ToLower().Trim();
            if (Vars.ContainsKey(key))
                return Vars[key];
            else
                return null;
        }
    }
}
