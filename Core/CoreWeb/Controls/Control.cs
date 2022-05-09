using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreWeb
{
    public abstract class Control : Spot
    {
        public String Name = "";
        public String Caption = "";
        public Boolean IgnoreOnSave = false;
        public Boolean UseNameInID = false;
        bool m_Visible = true;
        public bool Visible
        {
            get
            {
                return m_Visible;
            }
            set
            {
                m_Visible = value;
                //Change();
            }
        }
        Color m_BackColorControl = Color.White;
        public Color BackColorControl
        {
            get
            {
                return m_BackColorControl;
            }
            set
            {
                m_BackColorControl = value;
                //Change();
            }
        }
        protected bool FailedSet = false;
        Dictionary<GenAlign, int> MarginsControl = new Dictionary<GenAlign, int>();
        Dictionary<GenAlign, int> PaddingControl = new Dictionary<GenAlign, int>();

        public Control(String name, String caption, bool skip_parent_render)
        {
            Name = name;
            Caption = caption;
            SkipParentRender = skip_parent_render;

        }
        public abstract String ValueAddScript(String varName);
        public abstract object StringToObject(String val);
        public abstract void RenderControl(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page);
        public virtual bool ValueEquals(Object val)
        {
            return false;
        }
        public virtual void ValueSet(Object val)
        {

        }
        public void ValueSetFromRequest(System.Web.HttpRequest request)
        {
            String s = request[ControlId];
            if (s == null)
                throw new Exception("No info for " + Name);
            ValueSet(StringToObject(s));
        }
        public String ControlId
        {
            get
            {
                if (!UseNameInID)
                    return "ctl_" + Uid;
                else
                    return "ctl_" + Name;
            }
        }
        public virtual void RenderCaption(Core.Context x, StringBuilder sb)
        {
            if (Tools.Strings.StrExt(Caption))
                sb.AppendLine(Tools.Html.ConvertTextToHTML(Caption) + "<br />");
        }
        public override string InnerDivId
        {
            get
            {
                return "content_" + Uid;
            }
        }
        public override void RenderContents(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"" + InnerDivId + "\" " + GetStyle() + " >");
            RenderCaption(x, sb);
            RenderControl(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");
        }
        public override String PlaceBelow(String divPosition, String divSize, bool tryblock = false, int add_extra = 0, int sub_extra = 0)
        {
            if (tryblock)
                return "try{" + Select + ".css('top', $('#" + divPosition + "').height() + $('#" + divPosition + "').position().top + " + Screen.LayoutTheta.ToString() + " + " + add_extra + " - " + sub_extra + ");}catch(evnt){}";
            else
                return Select + ".css('top', $('#" + divPosition + "').height() + $('#" + divPosition + "').position().top + " + Screen.LayoutTheta.ToString() + " + " + add_extra + " - " + sub_extra + ");";
        }
        public override String PlaceRight(String positionDiv, String sizeDiv, bool tryblock = false, int add_extra = 0, int sub_extra = 0)
        {
            if (tryblock)
                return "try{" + Select + ".css('left', $('#" + positionDiv + "').width() + $('#" + positionDiv + "').position().left + " + Screen.LayoutTheta.ToString() + " + " + add_extra + " - " + sub_extra + ");}catch(evnt){}";
            else
                return Select + ".css('left', $('#" + positionDiv + "').width() + $('#" + positionDiv + "').position().left + " + Screen.LayoutTheta.ToString() + " + " + add_extra + " - " + sub_extra + ");";
        }
        public virtual string GetStyle()
        {
            if (MarginsControl == null)
                MarginsControl = new Dictionary<GenAlign, int>();
            if (PaddingControl == null)
                PaddingControl = new Dictionary<GenAlign, int>();
            bool b = false;
            string s = " style=\"";
            //Margins
            foreach (KeyValuePair<GenAlign, int> kvp in MarginsControl)
            {
                if (kvp.Value <= 0)
                    continue;
                b = true;
                s += "margin";
                if (kvp.Key != GenAlign.All)
                    s += "-" + kvp.Key.ToString().ToLower();
                s += ": " + kvp.Value.ToString() + "px; ";
            }
            //Padding
            foreach (KeyValuePair<GenAlign, int> kvp in PaddingControl)
            {
                if (kvp.Value <= 0)
                    continue;
                b = true;
                s += "padding";
                if (kvp.Key != GenAlign.All)
                    s += "-" + kvp.Key.ToString().ToLower();
                s += ": " + kvp.Value.ToString() + "px; ";
            }
            //BackColor
            if (BackColorControl != Color.White)
            {
                b = true;
                s += " background-color: " + Tools.Html.GetHTMLColor(BackColorControl) + "; ";
            }
            else
            {
                b = true;
                s += " background-color: Automatic; ";
            }
            //Visibility
            if (!Visible)
            {
                b = true;
                s += " visibility: hidden; ";
            }
            s += "\" ";
            if (!b)
                return "";
            return s;
        }
        public void AddMarginControl(GenAlign a, int px)
        {
            if (MarginsControl == null)
                MarginsControl = new Dictionary<GenAlign, int>();
            try { MarginsControl.Remove(a); }
            catch { }
            MarginsControl.Add(a, px);
        }
        public void AddPaddingControl(GenAlign a, int px)
        {
            if (PaddingControl == null)
                PaddingControl = new Dictionary<GenAlign, int>();
            try { PaddingControl.Remove(a); }
            catch { }
            PaddingControl.Add(a, px);
        }
    }
    public class TextControl : Control
    {
        public String Value = "";
        public TextAlign TxtAlign = TextAlign.Left;
        public int FixedWidth = 200;
        Color m_TextForeColor = Color.Black;
        public String OnEnterClick = "";
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
        Color m_TextBackColor = Color.White;
        public Color TextBackColor
        {
            get
            {
                return m_TextBackColor;
            }
            set
            {
                m_TextBackColor = value;
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
                Change();
            }
        }
        bool m_RemoveBorder = false;
        public bool RemoveBorder
        {
            get
            {
                return m_RemoveBorder;
            }
            set
            {
                m_RemoveBorder = value;
                Change();
            }
        }
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
        bool m_DisableEdit = false;
        public bool DisableEdit
        {
            get
            {
                return m_DisableEdit;
            }
            set
            {
                m_DisableEdit = value;
            }
        }
        Color m_CaptionForeColor = Color.Black;
        public Color CaptionForeColor
        {
            get
            {
                return m_CaptionForeColor;
            }
            set
            {
                m_CaptionForeColor = value;
                //Change();
            }
        }
        bool m_CaptionBold = false;
        public bool CaptionBold
        {
            get
            {
                return m_CaptionBold;
            }
            set
            {
                m_CaptionBold = value;
                //Change();
            }
        }
        FontSize m_CaptionFontSize = FontSize.Inherit;
        public FontSize CaptionFontSize
        {
            get
            {
                return m_CaptionFontSize;
            }
            set
            {
                m_CaptionFontSize = value;
            }
        }
        Dictionary<GenAlign, int> PaddingCaption = new Dictionary<GenAlign, int>();
        public bool ReadOnly = false;
        public bool IsPassword = false;
        public bool CaptionInLine = false;

        public TextControl(String name, String caption, String value = "", bool skip_parent_render = true, bool readOnly = false)
            : base(name, caption, skip_parent_render)
        {
            Value = value;
            ReadOnly = readOnly;
        }
        public override void RenderControl(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            string edit = "";
            string type = "type=\"text\"";
            if (DisableEdit)
                edit = " disabled=\"disabled\" ";
            if (ReadOnly)
                edit += " readonly=\"readonly\" ";
            if (IsPassword)
                type = "type=\"password\"";

            String onkey = "";
            if (Tools.Strings.StrExt(OnEnterClick))
                onkey = " onKeyDown=\"if(event.keyCode == 13) $('#" + OnEnterClick + "').click();\"";
            //size=\"" + Columns.ToString() + "\"           
            sb.AppendLine("<input id=\"" + ControlId + "\" name=\"" + ControlId + "\" " + type + " value=\"" + Tools.Html.ConvertTextToHTML(Value) + "\" " + GetTextBoxStyle() + " " + edit + onkey + " />");
        }
        public override void RenderCaption(Core.Context x, StringBuilder sb)
        {
            if (Tools.Strings.StrExt(Caption))
            {
                if (!CaptionInLine)
                    sb.AppendLine("<label id=\"" + Caption + "_" + Uid + "\" " + GetCaptionStyle() + " >" + Tools.Html.ConvertTextToHTML(Caption) + "</label><br />");
                else
                    sb.AppendLine("<label id=\"" + Caption + "_" + Uid + "\" " + GetCaptionStyle() + " >" + Tools.Html.ConvertTextToHTML(Caption) + "</label>&nbsp;");
            }
        }
        protected virtual string GetTextBoxStyle()
        {
            string s = " style=\"text-align: " + TxtAlign.ToString().ToLower() + "; ";
            s += " color: " + Tools.Html.GetHTMLColor(TextForeColor) + "; ";
            if (TextBackColor != Color.White)
                s += " background-color: " + Tools.Html.GetHTMLColor(TextBackColor) + "; ";
            else
                s += " background-color: Automatic; ";
            if (TextBold)
                s += " font-weight: bold; ";
            if (RemoveBorder)
                s += " border: none; ";
            if (TextFontSize != FontSize.Inherit)
            {
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
            s += " width: " + FixedWidth.ToString() + "px; ";
            return s += "\"";
        }
        protected string GetCaptionStyle()
        {
            string s = " style=\"text-align: " + TxtAlign.ToString().ToLower() + "; ";
            if (CaptionForeColor != Color.White)
                s += " color: " + Tools.Html.GetHTMLColor(CaptionForeColor) + "; ";
            else
                s += " color: Automatic; ";
            if (CaptionBold)
                s += " font-weight: bold; ";
            if (CaptionFontSize != FontSize.Inherit)
            {
                switch (CaptionFontSize)
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
                        s += " font-size: " + CaptionFontSize.ToString().ToLower() + "; ";
                        break;
                }
            }
            foreach (KeyValuePair<GenAlign, int> kvp in PaddingCaption)
            {
                if (kvp.Value <= 0)
                    continue;
                s += " padding";
                if (kvp.Key != GenAlign.All)
                    s += "-" + kvp.Key.ToString().ToLower();
                s += ": " + kvp.Value.ToString() + "px; ";
            }
            return s += "\"";
        }
        public override string ValueAddScript(string varName)
        {
            return varName + " += '|" + Name + ":' + ConvertToPostString($('#" + ControlId + "').val());";
        }
        public override bool ValueEquals(Object val)
        {
            try
            {
                return Value == val.ToString();
            }
            catch { }
            return base.ValueEquals(val);
        }
        public override void ValueSet(Object val)
        {
            try
            {
                Value = val.ToString();
            }
            catch { }
        }
        public override object StringToObject(String val)
        {
            return val;
        }
        public void AddPaddingCaption(GenAlign a, int px)
        {
            if (PaddingCaption == null)
                PaddingCaption = new Dictionary<GenAlign, int>();
            try { PaddingCaption.Remove(a); }
            catch { }
            PaddingCaption.Add(a, px);
        }
        public static void Render(StringBuilder sb, String controlId = "", String controlName = "", String onEnterClick = "", int width = 200, String caption = "")
        {
            String keyDown = "";
            if (Tools.Strings.StrExt(onEnterClick))
                keyDown = "onKeyDown=\"if(event.keyCode == 13) $('#" + onEnterClick + "').click();";

            sb.AppendLine("<div style=\"margin: 2px; font-size: smaller\">" + caption + "<br /><input id=\"" + controlId + "\" type=\"text\" name=\"ctl_" + controlName + "\" style=\"width: " + width.ToString() + "px\" " + keyDown + " \" /></div>");
        }
    }
    public class TextAreaControl : TextControl
    {
        public int Rows = 0;
        public bool ReadOnly = false;
        public int FixedHeight = 0;

        public TextAreaControl(String name, String caption, String value = "", int rows = 2, int cols = 15, bool skip_parent_render = true, bool readOnly = false)
            : base(name, caption, value, skip_parent_render)
        {
            Rows = rows;
            FixedWidth = cols;
            ReadOnly = readOnly;
        }
        public override void RenderControl(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            string rows = "";
            string cols = "";
            if (Rows > 0)
                rows = " rows=\"" + Rows.ToString() + "\" ";
            //if (Columns > 0)
            //    cols = " cols=\"" + Columns.ToString() + "\" ";
            string edit = "";
            if (DisableEdit)
                edit = " disabled=\"disabled\" ";
            if (ReadOnly)
                edit += " readonly=\"readonly\" ";
            sb.AppendLine("<textarea id=\"" + ControlId + "\" name=\"" + ControlId + "\" " + rows + cols + " " + edit + " " + GetTextBoxStyle() + " >" + Value + "</textarea>");//Tools.Html.ConvertTextToHTML(
        }
        protected override string GetTextBoxStyle()
        {
            string s = " style=\"text-align: " + TxtAlign.ToString().ToLower() + "; ";
            s += " color: " + Tools.Html.GetHTMLColor(TextForeColor) + "; ";
            if (TextBackColor != Color.White)
                s += " background-color: " + Tools.Html.GetHTMLColor(TextBackColor) + "; ";
            else
                s += " background-color: Automatic; ";
            if (TextBold)
                s += " font-weight: bold; ";
            if (RemoveBorder)
                s += " border: none; ";
            if (TextFontSize != FontSize.Inherit)
            {
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
            s += " width: " + FixedWidth.ToString() + "px; ";
            if (FixedHeight > 0)
                s += " height: " + FixedHeight.ToString() + "px; ";
            return s += "\"";
        }
    }
    public class Int32Control : TextControl
    {
        public Int32 IntValue = 0;

        public Int32Control(String name, String caption, Int32 value, bool skip_parent_render = true)
            : base(name, caption, value.ToString(), skip_parent_render)
        {
            IntValue = value;
            TxtAlign = TextAlign.Right;
        }
        public override void RenderControl(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            string edit = "";
            if (DisableEdit)
                edit = " disabled=\"disabled\" ";
            if (ReadOnly)
                edit += " readonly=\"readonly\" ";
            //size=\"" + Columns.ToString() + "\"
            sb.AppendLine("<input id=\"" + ControlId + "\" name=\"" + ControlId + "\" type=\"text\" value=\"" + Tools.Html.ConvertTextToHTML(IntValue.ToString()) + "\" " + GetTextBoxStyle() + " " + edit + " onFocus=\"this.select()\" />");
        }
        public override bool ValueEquals(Object val)
        {
            try
            {
                if (FailedSet)
                {
                    FailedSet = false;
                    return false;
                }
                return IntValue == (Int32)val;
            }
            catch { }
            return base.ValueEquals(val);
        }
        public override void ValueSet(Object val)
        {
            try
            {
                Value = val.ToString();
                IntValue = Convert.ToInt32(val);
            }
            catch { }
        }
        public override object StringToObject(String val)
        {
            try
            {
                return Convert.ToInt32(val);
            }
            catch { FailedSet = true; }
            return IntValue;
        }
    }
    public class Int64Control : TextControl
    {
        public Int64 IntValue = 0;

        public Int64Control(String name, String caption, Int64 value, bool skip_parent_render = true)
            : base(name, caption, value.ToString(), skip_parent_render)
        {
            IntValue = value;
            TxtAlign = TextAlign.Right;
        }
        public override void RenderControl(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            string edit = "";
            if (DisableEdit)
                edit = " disabled=\"disabled\" ";
            if (ReadOnly)
                edit += " readonly=\"readonly\" ";
            //size=\"" + Columns.ToString() + "\"
            sb.AppendLine("<input id=\"" + ControlId + "\" name=\"" + ControlId + "\" type=\"text\" value=\"" + Tools.Html.ConvertTextToHTML(IntValue.ToString()) + "\" " + GetTextBoxStyle() + " " + edit + " onFocus=\"this.select()\" />");
        }
        public override bool ValueEquals(Object val)
        {
            try
            {
                if (FailedSet)
                {
                    FailedSet = false;
                    return false;
                }
                return IntValue == (Int64)val;
            }
            catch { }
            return base.ValueEquals(val);
        }
        public override void ValueSet(Object val)
        {
            try
            {
                Value = val.ToString();
                IntValue = Convert.ToInt64(val);
            }
            catch { }
        }
        public override object StringToObject(String val)
        {
            try
            {
                return Convert.ToInt64(val);
            }
            catch { FailedSet = true; }
            return IntValue;
        }
    }
    public class DoubleControl : TextControl
    {
        public Double DblValue = 0;

        public DoubleControl(String name, String caption, Double value, bool skip_parent_render = true)
            : base(name, caption, value.ToString(), skip_parent_render)
        {
            DblValue = value;
            TxtAlign = TextAlign.Right;
        }
        public override void RenderControl(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            string edit = "";
            if (DisableEdit)
                edit = " disabled=\"disabled\" ";
            if (ReadOnly)
                edit += " readonly=\"readonly\" ";
            //size=\"" + Columns.ToString() + "\"
            sb.AppendLine("<input id=\"" + ControlId + "\" name=\"" + ControlId + "\" type=\"text\" value=\"" + Tools.Html.ConvertTextToHTML(DblValue.ToString()) + "\" " + GetTextBoxStyle() + " " + edit + " onFocus=\"this.select()\" />");
        }
        public override bool ValueEquals(Object val)
        {
            try
            {
                if (FailedSet)
                {
                    FailedSet = false;
                    return false;
                }
                return DblValue == (Double)val;
            }
            catch { }
            return base.ValueEquals(val);
        }
        public override void ValueSet(Object val)
        {
            try
            {
                Value = val.ToString();
                DblValue = Convert.ToDouble(val);
            }
            catch { }
        }
        public override object StringToObject(String val)
        {
            try
            {
                return Convert.ToDouble(val);
            }
            catch { FailedSet = true; }
            return DblValue;
        }
    }
    public class MoneyControl : DoubleControl
    {
        public string CurrencySymbol = "";

        public MoneyControl(String name, String caption, Double value, string currency_symbol = "$", bool skip_parent_render = true)
            : base(name, caption, value, skip_parent_render)
        {
            CurrencySymbol = currency_symbol;
            TxtAlign = TextAlign.Right;
        }
        public override void RenderControl(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            string edit = "";
            if (DisableEdit)
                edit = " disabled=\"disabled\" ";
            sb.AppendLine("<input id=\"" + ControlId + "\" type=\"text\" value=\"" + Tools.Html.ConvertTextToHTML(CurrencySymbol + Tools.Number.MoneyFormat_2_6(DblValue)) + "\" " + GetTextBoxStyle() + " " + edit + " onFocus=\"this.select()\" />");
        }
        public override bool ValueEquals(Object val)
        {
            try
            {
                if (FailedSet)
                {
                    FailedSet = false;
                    return false;
                }
                return DblValue == (Double)val;
            }
            catch { }
            return base.ValueEquals(val);
        }
        public override object StringToObject(String val)
        {
            try
            {
                val = val.Replace(CurrencySymbol, "");
                return Convert.ToDouble(val);
            }
            catch { FailedSet = true; }
            return DblValue;
        }
    }
    public class DateControl : TextControl
    {
        public DateTime DtValue = Tools.Dates.GetBlankDate();

        public DateControl(String name, String caption, DateTime value, bool skip_parent_render = true)
            : base(name, caption, value.ToShortDateString(), skip_parent_render)
        {
            DtValue = value;
            TxtAlign = TextAlign.Center;
        }
        public override bool ValueEquals(Object val)
        {
            try
            {
                if (FailedSet)
                {
                    FailedSet = false;
                    return false;
                }
                return DtValue == (DateTime)val;
            }
            catch { }
            return base.ValueEquals(val);
        }
        public override void ValueSet(Object val)
        {
            try
            {
                DateTime d = Convert.ToDateTime(val);
                Value = d.ToShortDateString();
                DtValue = d;
            }
            catch { }
        }
        public override void RenderContents(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            viewHandle.ScriptsToRun.Add("$('#" + ControlId + "').datepicker();");//{ beforeShow: function() {$('#ui-datepicker-div').maxZIndex();} }
        }
        public override void RenderControl(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            string edit = "";
            if (DisableEdit)
                edit = " disabled=\"disabled\" ";
            if (ReadOnly)
                edit += " readonly=\"readonly\" ";
            string date = DtValue.ToShortDateString();
            if (DtValue == Tools.Dates.GetBlankDate())
                date = "";
            if (!Tools.Dates.DateExists(DtValue))
                date = "";
            //size=\"" + Columns.ToString() + "\"
            sb.AppendLine("<input id=\"" + ControlId + "\" name=\"" + ControlId + "\" type=\"text\" value=\"" + Tools.Html.ConvertTextToHTML(date) + "\" " + GetTextBoxStyle() + " " + edit + " />");
        }
        public override object StringToObject(String val)
        {
            try
            {
                return Convert.ToDateTime(val);
            }
            catch { FailedSet = true; }
            return DtValue;
        }
    }
    public class BoolControl : Control
    {
        public Boolean BoolValue = false;
        public string OnClick = "";
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
        public bool Disabled = false;

        public BoolControl(String name, String caption, Boolean value, string onclick = "", bool skip_parent_render = true)
            : base(name, caption, skip_parent_render)
        {
            BoolValue = value;
            OnClick = onclick;
        }
        public override void RenderCaption(Core.Context x, StringBuilder sb)
        {
            //do nothing, handled in render control
        }
        public override void RenderControl(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            string label = "";
            if (Tools.Strings.StrExt(Caption))
                label = "<label for=\"" + ControlId + "\" " + GetLabelStyle() + " >" + Tools.Html.ConvertTextToHTML(Caption) + "</label>";
            string check = "";
            if (BoolValue)
                check = " checked=\"checked\" ";
            string click = "";
            if (Tools.Strings.StrExt(OnClick))
                click = " onclick=\"" + OnClick + "\" ";
            string edit = "";
            if (Disabled)
                edit += " disabled=\"disabled\" ";
            sb.AppendLine("<input id=\"" + ControlId + "\" type=\"checkbox\" name=\"" + ControlId + "\" " + edit + " " + check + " value=\"" + Tools.Html.ConvertTextToHTML(Caption) + "\" " + click + " />" + label);
        }
        public override string ValueAddScript(string varName)
        {
            return varName + " += '|" + Name + ":' + ConvertToPostString($('#" + ControlId + ":checked').val());";
        }
        public override bool ValueEquals(Object val)
        {
            try
            {
                if (FailedSet)
                {
                    FailedSet = false;
                    return false;
                }
                return BoolValue == (bool)val;
            }
            catch { }
            return base.ValueEquals(val);
        }
        public override void ValueSet(Object val)
        {
            try
            {
                BoolValue = Convert.ToBoolean(val);
            }
            catch { }
        }
        public override object StringToObject(String val)
        {
            try
            {
                switch (val.ToLower())
                {
                    case "false":
                    case "undefined":
                        return false;
                    case "true":
                        return true;
                    default:
                        if (Tools.Strings.StrCmp(val, Caption))
                            return true;
                        else
                            return false;
                }
            }
            catch { FailedSet = true; }
            return BoolValue;
        }
        private string GetLabelStyle()
        {
            string s = " style=\"";
            bool b = false;
            if (TextForeColor != Color.Black)
            {
                b = true;
                s += " color: " + Tools.Html.GetHTMLColor(TextForeColor) + "; ";
            }
            if (TextBold)
            {
                b = true;
                s += " font-weight: bold; ";
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
            s += "\" ";
            if (!b)
                return "";
            return s;
        }
    }
    public class ComboBoxControl : TextControl
    {
        public ArrayList Choices = new ArrayList();
        public String OnChange = "";
        public bool IncludeBlankOption = true;

        public ComboBoxControl(String name, String caption, String value, ArrayList choices, String on_change = "", bool skip_parent_render = true)
            : base(name, caption, value, skip_parent_render)
        {
            Choices = choices;
            TxtAlign = TextAlign.Left;
            OnChange = on_change;
        }
        public override void RenderControl(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            string edit = "";
            string dis = "";
            if (DisableEdit)
                dis = " disabled ";
            if (ReadOnly)
                edit += " readonly=\"readonly\" ";
            if (Tools.Strings.StrExt(OnChange))
                edit += " onchange=\"" + OnChange + "\" ";
            sb.AppendLine("<select " + dis + " id=\"" + ControlId + "\" name=\"" + ControlId + "\" " + GetComboStyle() + " " + edit + " >");
            if (IncludeBlankOption)
                sb.AppendLine("<option></option>");
            bool found = false;
            if (Choices == null)
                Choices = new ArrayList();
            foreach (string s in Choices)
            {
                string sel = "";
                if (Tools.Strings.StrCmp(s, Value))
                {
                    sel = "selected";
                    found = true;
                }
                sb.AppendLine("<option " + sel + ">" + Tools.Html.ConvertTextToHTML(s) + "</option>");
            }
            if (!found && Tools.Strings.StrExt(Value))
                sb.AppendLine("<option selected>" + Tools.Html.ConvertTextToHTML(Value) + "</option>");
            sb.AppendLine("</select>");
        }
        private string GetComboStyle()
        {
            bool b = false;
            string s = "style=\"";
            if (FixedWidth > 0)
            {
                b = true;
                s += " width: " + FixedWidth.ToString() + "px; ";
            }
            if (TextForeColor != Color.Black)
            {
                b = true;
                s += " color: " + Tools.Html.GetHTMLColor(TextForeColor) + "; ";
            }

            b = true;
            s += " height: 18px;";

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
    }
    public class LabelControl : TextControl
    {
        public string LabelAlign = "";

        public LabelControl(String name, String caption, String value, bool skip_parent_render = true)
            : base(name, caption, value, skip_parent_render)
        {

        }
        public override void RenderControl(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            sb.AppendLine("<label id=\"" + ControlId + "\" " + GetLabelStyle() + " >" + Tools.Html.ConvertTextToHTML(Value) + "</label>");
        }
        public override string ValueAddScript(string varName)
        {
            return "";
            //return varName + " += '|" + Name + ":' + ConvertToPostString($('#" + TextBoxId + "').val());";
        }
        public string GetLabelStyle()
        {
            string s = " style=\"";
            bool b = false;
            if (TextForeColor != Color.Black)
            {
                b = true;
                s += " color: " + Tools.Html.GetHTMLColor(TextForeColor) + "; ";
            }
            if (TextBackColor != Color.White)
            {
                b = true;
                s += " background-color: " + Tools.Html.GetHTMLColor(TextBackColor) + "; ";
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
            s += "\" ";
            if (!b)
                return "";
            return s;
        }
    }
    public class RadioButtonControl : Control
    {
        RadioControlConfig Options;
        RadioAlign Align;
        public string Value = "";
        public bool ReadOnly = false;
        public int CountHorizontal = 0;
        public int CountVertical = 0;
        public int CellPadding = -1;

        public RadioButtonControl(String name, String caption, string value, string[] options, RadioAlign align = RadioAlign.Horizontal, bool skip_parent_render = true)
            : base(name, caption, skip_parent_render)
        {
            Options = ConvertToConfig(options);
            Align = align;
            Value = value;
        }
        public RadioButtonControl(String name, String caption, string value, RadioControlConfig options, RadioAlign align = RadioAlign.Horizontal, bool skip_parent_render = true)
            : base(name, caption, skip_parent_render)
        {
            Options = options;
            Align = align;
            Value = value;
        }
        public override void RenderContents(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            AddScripts(viewHandle);
        }
        public override void RenderCaption(Core.Context x, StringBuilder sb)
        {
            //do nothing, handled in render control
        }
        public override void RenderControl(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            if (CountHorizontal > 0 && CountVertical > 0)
            {
                RenderControlWithCount(x, sb, screenHandle, viewHandle, session, page);
                return;
            }
            sb.AppendLine("<table cellpadding=\"0\" border=\"0\" cellspacing=\"0\">");
            if (Align == RadioAlign.Horizontal)
                sb.AppendLine("  <tr>");
            foreach (RadioControlConfig s in Options.AllOptions)
            {
                if (s == null)
                    continue;
                switch (Align)
                {
                    case RadioAlign.Horizontal:
                        sb.AppendLine("    <td style=\"padding-right: 10px\">");
                        sb.AppendLine(GetOptionDefinition(s));
                        sb.AppendLine("    </td>");
                        break;
                    case RadioAlign.Vertical:
                        sb.AppendLine("  <tr>");
                        sb.AppendLine("    <td>");
                        sb.AppendLine(GetOptionDefinition(s));
                        sb.AppendLine("    </td>");
                        sb.AppendLine("  </tr>");
                        break;
                }
            }
            if (Align == RadioAlign.Horizontal)
                sb.AppendLine("  </tr>");
            sb.AppendLine("</table>");
        }
        private void RenderControlWithCount(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            ArrayList options = new ArrayList();
            ArrayList a = new ArrayList();
            int count = 0;
            foreach (RadioControlConfig s in Options.AllOptions)
            {
                if (s == null)
                    continue;
                count++;
                a.Add(s);
                if (count >= CountHorizontal)
                {
                    options.Add(a);
                    a = new ArrayList();
                    count = 0;
                }
            }
            string cell_pad = "";
            if (CellPadding > -1)
                cell_pad = "cellpadding=\"" + cell_pad.ToString() + "\"";
            sb.AppendLine("<table border=\"0\" " + cell_pad + ">");
            foreach (ArrayList aa in options)
            {
                if (aa == null)
                    continue;
                sb.AppendLine("  <tr>");
                foreach (RadioControlConfig s in aa)
                {
                    sb.AppendLine("  <td>");
                    sb.AppendLine(GetOptionDefinition(s));
                    sb.AppendLine("  </td>");
                }
                sb.AppendLine("  </tr>");
            }
            sb.AppendLine("</table>");
        }
        public override string ValueAddScript(string varName)
        {
            return varName + " += '|" + Name + ":' + ConvertToPostString(GetRadioButtonValue" + ControlId + "());";
        }
        public override bool ValueEquals(Object val)
        {
            try
            {
                return Value == val.ToString();
            }
            catch { }
            return base.ValueEquals(val);
        }
        public override void ValueSet(Object val)
        {
            try
            {
                Value = val.ToString();
            }
            catch { }
        }
        public override object StringToObject(String val)
        {
            return val;
        }
        private string GetOptionDefinition(RadioControlConfig opt)
        {
            if (opt == null)
                return "";
            string label = "";
            if (Tools.Strings.StrExt(opt.Caption))
                label = "<label for=\"" + ControlId + "_" + opt.Value + "\" " + GetLabelStyle(opt) + " >" + Tools.Html.ConvertTextToHTML(opt.Caption) + "</label>";
            string check = "";
            if (Tools.Strings.StrCmp(Value, opt.Value))
                check = " checked=\"checked\" ";
            string onclick = "";
            if (Tools.Strings.StrExt(opt.OnClick))
                onclick = " onclick=\"" + opt.OnClick + "\" ";
            string style = "";
            if (opt.BackColor != Color.White)
                style = " style=\"background-color: " + Tools.Html.GetHTMLColor(opt.BackColor) + " ";
            else
                style += " style=\"background-color: Automatic; ";
            if (Tools.Strings.StrExt(opt.ExtraStyle))
                style += opt.ExtraStyle;
            style += "\"";
            string edit = "";
            if (ReadOnly)
                onclick = " onclick=\"javascript: return false;\" ";
            return "<input id=\"" + ControlId + "_" + opt.Value + "\" type=\"radio\" name=\"" + Name + "\" " + check + " " + edit + " value=\"" + Tools.Html.ConvertTextToHTML(opt.Value) + "\" " + onclick + " " + style + " />" + label;
        }
        private string GetLabelStyle(RadioControlConfig opt)
        {
            string s = "style=\"";
            bool b = false;
            if (opt.FontSize != FontSize.Inherit)
            {
                b = true;
                switch (opt.FontSize)
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
                        s += " font-size: " + opt.FontSize.ToString().ToLower() + "; ";
                        break;
                }
            }
            if (opt.Bold)
            {
                b = true;
                s += " font-weight: bold; ";
            }
            if (opt.ForeColor != Color.Black)
            {
                b = true;
                s += " color: " + Tools.Html.GetHTMLColor(opt.ForeColor) + "; ";
            }
            if (opt.BackColor != Color.White)
            {
                b = true;
                s += " background-color: " + Tools.Html.GetHTMLColor(opt.BackColor) + "; ";
            }
            else
            {
                b = true;
                s += " background-color: Automatic; ";
            }
            s += "\"";
            if (!b)
                return "";
            return s;
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sbb = new StringBuilder();
            sbb.AppendLine("function GetRadioButtonValue" + ControlId + "()");
            sbb.AppendLine("{");
            sbb.AppendLine("    var stringValue = \"\";");
            foreach (RadioControlConfig s in Options.AllOptions)
            {
                if (s == null)
                    continue;
                sbb.AppendLine("    stringValue = $('#" + ControlId + "_" + s.Value + ":checked').val();");
                sbb.AppendLine("    if (!(typeof stringValue === \"undefined\"))");
                sbb.AppendLine("    {");
                sbb.AppendLine("        return stringValue;");
                sbb.AppendLine("    }");
            }
            sbb.AppendLine("}");
            viewHandle.Definitions.Add(sbb.ToString());
        }
        private RadioControlConfig ConvertToConfig(string[] options)
        {
            RadioControlConfig c = new RadioControlConfig();
            RadioControlConfig r;
            foreach (string s in options)
            {
                r = new RadioControlConfig();
                r.Caption = Tools.Strings.ParseDelimit(s, ":", 1);
                r.Value = Tools.Strings.ParseDelimit(s, ":", 2).Trim();
                c.AllOptions.Add(r);
            }
            return c;
        }
    }
    public class AnchorControl : Control
    {
        string ImageURL = "";
        public string OnClick = "";
        public string Href = "#";
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
        Color m_TextBackColor = Color.White;
        public Color TextBackColor
        {
            get
            {
                return m_TextBackColor;
            }
            set
            {
                m_TextBackColor = value;
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
                Change();
            }
        }
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
        public bool DoButtonize = true;
        public int ButtonTopPadding = 35;

        public AnchorControl(String name, String caption, string onclick, string image_url = "", bool skip_parent_render = true, bool includeControls = false)
            : base(name, caption, skip_parent_render)
        {
            OnClick = onclick;
            ImageURL = image_url;
        }
        public override void RenderCaption(Core.Context x, StringBuilder sb)
        {
            //do nothing handled in control
        }
        public override void RenderControl(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            if (Tools.Strings.StrExt(ImageURL))
            {
                sb.AppendLine("<input id=\"" + ControlId + "\" type=\"button\" onclick=\"" + OnClick + "\" value=\"" + Caption + "\" />");  //this used to be Uid but i think it was intended to be controlid for the element id
                if (DoButtonize)
                    Buttonize(viewHandle, ControlId, ImageURL, ButtonTopPadding);
                else
                    viewHandle.ScriptsToRun.Add("$('#" + ControlId + "').css('background-image', \"url('Graphics/" + ImageURL + "')\").css('background-repeat', 'no-repeat');");
            }
            else
            {
                sb.AppendLine("<a href=\"" + Href + "\" onclick=\"" + OnClick + "\" " + GetAnchorStyle() + " >" + Caption + "</a>");
            }
        }
        public override string ValueAddScript(string varName)
        {
            return "";
        }
        public override bool ValueEquals(Object val)
        {
            return true;
        }
        public override void ValueSet(Object val)
        {

        }
        public override object StringToObject(String val)
        {
            return null;
        }
        private string GetAnchorStyle()
        {
            bool b = false;
            string s = " style=\" ";
            if (TextForeColor != Color.Black)
            {
                b = true;
                s += " color: " + Tools.Html.GetHTMLColor(TextForeColor) + "; ";
            }
            if (TextBackColor != Color.White)
            {
                b = true;
                s += " background-color: " + Tools.Html.GetHTMLColor(TextBackColor) + "; ";
            }
            else
            {
                b = true;
                s += " background-color: Automatic; ";
            }
            if (TextBold)
            {
                b = true;
                s += " font-weight: bold; ";
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
            if (!b)
                return "";
            return s += "\"";
        }
    }
    public class ImageControl : Control
    {
        public int ImageBorderSize = 0;
        public string ImageURL = "";

        public ImageControl(String name, String caption, string image_url, bool skip_parent_render = true)
            : base(name, caption, skip_parent_render)
        {
            ImageURL = image_url;
        }
        public override void RenderCaption(Core.Context x, StringBuilder sb)
        {
            //do nothing handled in control
        }
        public override void RenderControl(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            string s = "";
            sb.AppendLine("<img id=\"" + ControlId + "\" alt=\"" + Name + "\" border=\"" + ImageBorderSize.ToString() + "\" src=\"" + page.ResolveClientUrl(ImageURL) + "\" " + s + "/>");
        }
        public override string ValueAddScript(string varName)
        {
            return "";
        }
        public override bool ValueEquals(Object val)
        {
            return true;
        }
        public override void ValueSet(Object val)
        {

        }
        public override object StringToObject(String val)
        {
            return null;
        }
    }
    public class RadioControlConfig
    {
        public ArrayList AllOptions = new ArrayList();
        public string Caption = "";
        public string Value = "";
        public string OnClick = "";
        public bool Bold = false;
        public FontSize FontSize = FontSize.Inherit;
        public Color ForeColor = Color.Black;
        public Color BackColor = Color.White;
        public string ExtraStyle = "";
    }
    public enum TextAlign
    {
        Left = 0,
        Center = 1,
        Right = 2,
    }
    public enum RadioAlign
    {
        Horizontal = 0,
        Vertical = 1,
    }
    public enum GenAlign
    {
        All = 0,
        Top = 1,
        Left = 2,
        Right = 3,
        Bottom = 4,
    }
    public enum FontSize
    {
        Inherit = 0,
        Large = 1,
        Larger = 2,
        Medium = 3,
        Small = 4,
        Smaller = 5,
        XLarge = 6,
        XSmall = 7,
        XXLarge = 8,
        XXSmall = 9,
    }
} 