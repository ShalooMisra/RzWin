using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Tools
{
    public static class Html
    {
        public static String GetSmallStyle()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<STYLE TYPE=text/css>");
            sb.AppendLine("<!--");
            sb.AppendLine("    BODY, p, th, td {font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 10px;}");
            sb.AppendLine("-->");
            sb.AppendLine("</STYLE>");
            return sb.ToString();
        }

        public static String GetHTMLColor(int color)
        {
            Color c = Color.FromArgb(color);
            return "#" + Colors.RGBtoHEX(c.R) + Colors.RGBtoHEX(c.G) + Colors.RGBtoHEX(c.B);
        }
        public static String GetHTMLColor(Color c)
        {
            return "#" + Colors.RGBtoHEX(c.R) + Colors.RGBtoHEX(c.G) + Colors.RGBtoHEX(c.B);
        }
        public static String RemoveHTMLScripts(String s)
        {
            return Tools.Strings.Replace(s, "<script ", "<not_a_script ").Replace("</script>", "</not_a_script>");
        }
        public static String RemoveHTMLComments(String s)
        {
            String ret = s;
            while (Tools.Strings.HasString(ret, "<!--"))
            {
                int x = ret.IndexOf("-->");
                if (x > -1)
                {
                    ret = Tools.Strings.ParseDelimit(ret, "<!--", 1) + ret.Substring(x + 3);
                }
            }

            return ret;
        }
        public static String RemoveHtmlLinks(String s)
        {
            String ret = s;
            while (Tools.Strings.HasString(ret, "<a h"))
            {
                int x = ret.IndexOf("</a>");
                if (x > -1)
                {
                    ret = Tools.Strings.ParseDelimit(ret, "<a h", 1) + ret.Substring(x + 4);
                }
            }

            return ret;
        }
        public static String WebTrim(String s)
        {
            String c = new string((Char)160, 1);
            return s.Replace("\t", "").Replace(c, "").Trim();
        }

        public static String EscapeHtml(String text)
        {
            return ConvertTextToHTML(text);
        }

        public static String ConvertTextToHTML(String strText)
        {
            //has to handle < without then converting the & in &lt; into &amp
            return strText.Replace("<", "!less than!").Replace(">", "!greater than!").Replace("\r\n", "<br>").Replace("&", "&amp;").Replace("\n", "<br>").Replace("!less than!", "&lt;").Replace("!greater than!", "&gt;").Replace(" ", "&nbsp;");
        }
        public static String ConvertTextToHTML_AllowBreaks(String strText)
        {
            //has to handle < without then converting the & in &lt; into &amp
            return strText.Replace("<", "!less than!").Replace(">", "!greater than!").Replace("\r\n", "<br>").Replace("&", "&amp;").Replace("\n", "<br>").Replace("!less than!", "&lt;").Replace("!greater than!", "&gt;");
        }
        public static String ConvertHTMLToText_Quick(String strHTML)
        {
            return Tools.Strings.Replace(Tools.Strings.Replace(strHTML, "&amp;", "&"), "&nbsp;", " ");
        }
        public static String AlertFilter(String s)
        {
            return s.Replace("'", "").Replace("\"", "");
        }
        public static string ConvertToPostString(string stringValue)
        {
            var v = RemoveConvertedKeyChars(stringValue);
            v = ConvertKeyChars(v);
            v = FilterChars(v);
            v = ChangeKeyChars(v);
            return v;
        }
        private static string RemoveConvertedKeyChars(string stringValue)
        {
            string v = "";
            foreach (char c in stringValue)
            {
                switch (c)
                {
                    case '\0':
                    case '\b':
                        break;
                    default:
                        v += c.ToString();
                        break;
                }
            }
            return v;
        }
        private static string ConvertKeyChars(string stringValue)
        {
            string v = "";
            foreach (char c in stringValue)
            {
                switch (c)
                {
                    case '[':
                        v += "\0";
                        break;
                    case ']':
                        v += "\b";
                        break;
                    default:
                        v += c.ToString();
                        break;
                }
            }
            return v;
        }
        public static string FilterChars(string stringValue)
        {
            string v = "";
            foreach (char c in stringValue)
            {
                switch (c)
                {
                    case ':':
                        v += "[colon]";
                        break;
                    case '\\':
                        v += "[backslash]";
                        break;
                    case ' ':
                    case (char)160:
                    //case '\xA0':  equivalent to 160
                        v += "[space]";
                        break;
                    case '.':
                        v += "[period]";
                        break;
                    case '&':
                        v += "[and]";
                        break;
                    case '-':
                        v += "[dash]";
                        break;
                    case '\'':
                        v += "[singlequote]";
                        break;
                    case '|':
                        v += "[pipe]";
                        break;
                    case '\"':
                        v += "[doublequote]";
                        break;
                    case '\f':
                        v += "[formfeed]";
                        break;
                    case '\n':
                        v += "[newline]";
                        break;
                    case '\r':
                        v += "[return]";
                        break;
                    case '\t':
                        v += "[htab]";
                        break;
                    case '\v':
                        v += "[vtab]";
                        break;
                    case '!':
                        v += "[exclamation]";
                        break;
                    case '@':
                        v += "[atsymb]";
                        break;
                    case '#':
                        v += "[pound]";
                        break;
                    case '$':
                        v += "[dollar]";
                        break;
                    case '%':
                        v += "[perc]";
                        break;
                    case '^':
                        v += "[carrot]";
                        break;
                    case '*':
                        v += "[star]";
                        break;
                    case '(':
                        v += "[openpar]";
                        break;
                    case ')':
                        v += "[closepar]";
                        break;
                    case '_':
                        v += "[uscore]";
                        break;
                    case '+':
                        v += "[plus]";
                        break;
                    case '=':
                        v += "[equal]";
                        break;
                    case '~':
                        v += "[tilde]";
                        break;
                    case '`':
                        v += "[apost]";
                        break;
                    case '{':
                        v += "[openbrace]";
                        break;
                    case '}':
                        v += "[closebrace]";
                        break;
                    case '[':
                        v += "[openbrack]";
                        break;
                    case ']':
                        v += "[closebrack]";
                        break;
                    case ';':
                        v += "[semic]";
                        break;
                    case ',':
                        v += "[comma]";
                        break;
                    case '<':
                        v += "[lessthn]";
                        break;
                    case '>':
                        v += "[greaterthn]";
                        break;
                    case '/':
                        v += "[fslash]";
                        break;
                    case '?':
                        v += "[question]";
                        break;
                    default:
                        v += c.ToString();
                        break;
                }
            }
            return v;
        }
        private static string ChangeKeyChars(string stringValue)
        {
            string v = "";
            foreach (char c in stringValue)
            {
                switch (c)
                {
                    case '\0':
                        v += "[openbrack]";
                        break;
                    case '\b':
                        v += "[closebrack]";
                        break;
                    default:
                        v += c.ToString();
                        break;
                }
            }
            return v;
        }
        public static string ConvertFromPostString(string stringValue)
        {
            stringValue = stringValue.Replace("[openbrack]", "\0");
            stringValue = stringValue.Replace("[closebrack]", "\b");
            //
            stringValue = stringValue.Replace("[colon]", ":");
            stringValue = stringValue.Replace("[backslash]", "\\");
            stringValue = stringValue.Replace("[space]", " ");
            stringValue = stringValue.Replace("[period]", ".");
            stringValue = stringValue.Replace("[and]", "&");
            stringValue = stringValue.Replace("[dash]", "-");
            stringValue = stringValue.Replace("[singlequote]", "\'");
            stringValue = stringValue.Replace("[pipe]", "|");
            stringValue = stringValue.Replace("[doublequote]", "\"");
            stringValue = stringValue.Replace("[backspace]", "\b");
            stringValue = stringValue.Replace("[formfeed]", "\f");
            stringValue = stringValue.Replace("[newline]", "\n");
            stringValue = stringValue.Replace("[return]", "\r");
            stringValue = stringValue.Replace("[htab]", "\t");
            stringValue = stringValue.Replace("[vtab]", "\v");
            stringValue = stringValue.Replace("[null]", "\0");
            stringValue = stringValue.Replace("[exclamation]", "!");
            stringValue = stringValue.Replace("[atsymb]", "@");
            stringValue = stringValue.Replace("[pound]", "#");
            stringValue = stringValue.Replace("[dollar]", "$");
            stringValue = stringValue.Replace("[perc]", "%");
            stringValue = stringValue.Replace("[carrot]", "^");
            stringValue = stringValue.Replace("[star]", "*");
            stringValue = stringValue.Replace("[openpar]", "(");
            stringValue = stringValue.Replace("[closepar]", ")");
            stringValue = stringValue.Replace("[uscore]", "_");
            stringValue = stringValue.Replace("[plus]", "+");
            stringValue = stringValue.Replace("[equal]", "=");
            stringValue = stringValue.Replace("[tilde]", "~");
            stringValue = stringValue.Replace("[apost]", "`");
            stringValue = stringValue.Replace("[openbrace]", "{");
            stringValue = stringValue.Replace("[closebrace]", "}");
            stringValue = stringValue.Replace("[openbrack]", "[");
            stringValue = stringValue.Replace("[closebrack]", "]");
            stringValue = stringValue.Replace("[semic]", ";");
            stringValue = stringValue.Replace("[comma]", ",");
            stringValue = stringValue.Replace("[lessthn]", "<");
            stringValue = stringValue.Replace("[greaterthn]", ">");
            stringValue = stringValue.Replace("[fslash]", "/");
            stringValue = stringValue.Replace("[question]", "?");
            //
            stringValue = stringValue.Replace("\0", "[");
            stringValue = stringValue.Replace("\b", "]");
            return stringValue;
        }

        public static String GetDomainLink(String strDomain, String strCaption)
        {
            return "<a href=\"http://www." + strDomain + "\" target=\"_new\">" + strCaption + "</a>";
        }

        public static string FilterInput(string p)
        {
            return p.Replace((char)160, ' ');
        }
    }
}
