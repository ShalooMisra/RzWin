using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ToolsWin
{
    public class HtmlWin
    {        
        /// <summary>
        /// Injects an auto login script into the DOM and returns the invocable script name
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="additionalScripting">Can be empty</param>
        /// <param name="browser"></param>
        /// <returns></returns>
        public static string ScriptLogin(LoginInfo loginInfo, string additionalScripting, WebBrowser browser)
        {
            string script = "function login(){" + loginInfo.UsernameInputControl + ".value = '" + loginInfo.Username +
                "';\n" + loginInfo.PasswordInputControl + ".value = '" + loginInfo.Password + "';\n" + additionalScripting + 
                "document.getElementById('" + loginInfo.LoginCommitControl + "').click();}";
            HtmlElement head = browser.Document.GetElementsByTagName("head")[0];
            HtmlElement scriptElement = browser.Document.CreateElement("script");
            mshtml.IHTMLScriptElement element = (mshtml.IHTMLScriptElement)scriptElement.DomElement;
            scriptElement.SetAttribute("type", @"text/javascript");
            scriptElement.SetAttribute("language", @"javascript");
            element.text = script;
            head.AppendChild(scriptElement);
            return "login";
        }
        public static String ConvertHTMLToText(String strHTML)
        {
            HTMLConversionHolder h = new HTMLConversionHolder();
            h.strHTML = strHTML;
            Thread t = new Thread(new ParameterizedThreadStart(ConvertHTMLToTextOnThread));
            t.SetApartmentState(ApartmentState.STA);
            t.Start(h);
            t.Join();
            return h.strText;
        }
        public static void ConvertHTMLToTextOnThread(Object x)
        {
            try
            {
                HTMLConversionHolder h = (HTMLConversionHolder)x;
                BrowserPlain b = new BrowserPlain();
                b.ReloadWB();
                b.Add(h.strHTML);
                String s = GetPageText(b);
                b.Dispose();
                b = null;
                h.strText = s;
            }
            catch (Exception)
            {
            }
        }

        private static String GetPageText(BrowserPlain browser)
        {
            try
            {
                mshtml.IHTMLDocument2 xDoc = (mshtml.IHTMLDocument2)browser.GetDocument().DomDocument;
                return GrabDocumentHTML(xDoc, 0, true, false);
            }
            catch
            {
                return "";
            }
        }

        private static String GrabDocumentHTML(mshtml.IHTMLDocument2 xDoc, int intBase, bool textonly, bool outer)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                mshtml.IHTMLElement body;
                body = xDoc.body;
                if (outer)
                {
                    mshtml.IHTMLDocument3 d3 = (mshtml.IHTMLDocument3)xDoc;
                    sb.Append(d3.documentElement.outerHTML);
                }
                else if (textonly)
                    sb.Append(body.innerText);
                else
                    sb.Append(body.innerHTML);
                mshtml.IHTMLFramesCollection2 frames = xDoc.frames;
                for (int j = 0; j < frames.length; j++)
                {
                    try
                    {
                        Int32 n = Convert.ToInt32(j);
                        Object oFrameIndex = (Object)(n);
                        mshtml.IHTMLWindow2 frame = (mshtml.IHTMLWindow2)(frames.item(ref oFrameIndex));
                        Object d = frame.document;
                        mshtml.IHTMLDocument2 frameDoc = (mshtml.IHTMLDocument2)(d);
                        sb.Append("\r\n");
                        sb.Append(String.Concat("<recognin frame break: ", Convert.ToString(intBase), ">"));
                        sb.Append("\r\n");
                        intBase++;
                        sb.Append(GrabDocumentHTML(frameDoc, intBase, textonly, outer));
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
            return sb.ToString();
        }

        public static String ConvertListViewToHTML(ListView lv)
        {
            int cols = lv.Columns.Count;
            StringBuilder s = new StringBuilder();
            s.AppendLine("<table border=\"1\" cellpadding=\"1\" cellspacing=\"1\">");
            s.AppendLine("<tr>");
            foreach (ColumnHeader c in lv.Columns)
            {
                s.AppendLine("<td><b>" + c.Text + "</b></td>");
            }
            s.AppendLine("</tr>");
            foreach (ListViewItem i in lv.Items)
            {
                s.AppendLine("<tr>");
                for (int j = 0; j < cols; j++)
                {
                    try
                    {
                        s.AppendLine("<td>" + i.SubItems[j].Text + "</td>");
                    }
                    catch (Exception)
                    {
                    }
                }
                s.AppendLine("</tr>");
            }
            s.AppendLine("</table>");
            return s.ToString();
        }

        public struct LoginInfo
        {
            public string Username;
            public string Password;
            public string UsernameInputControl;
            public string PasswordInputControl;
            public string LoginCommitControl;
        }
        //Private Classes
        private class HTMLConversionHolder
        {
            public String strHTML;
            public String strText;
        }
    }
}
