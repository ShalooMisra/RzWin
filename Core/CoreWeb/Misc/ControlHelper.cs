using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace CoreWeb
{
    public static class ControlHelper
    {
        public static string WriteCssLink(Type controlType, string assembly, ClientScriptManager scriptManager)
        {
            string url = scriptManager.GetWebResourceUrl(controlType, assembly);
            StringBuilder link = new StringBuilder();
            link.Append("<link href=\"" + url + "\" rel=\"stylesheet\" type=\"text/css\" />\n");
            return link.ToString();
        }

        public static string WriteCssLink(string localPath)
        {
            StringBuilder link = new StringBuilder();
            link.Append("<link href=\"" + localPath + "\" rel=\"stylesheet\" type=\"text/css\" />\n");
            return link.ToString();
        }

        /// <summary>
        /// Writes a script tage for a file contained in an external assembly.
        /// </summary>
        /// <param name="controlType"></param>
        /// <param name="assembly"></param>
        /// <param name="scriptManager"></param>
        /// <returns></returns>
        public static string WriteScriptTag(Type controlType, string assembly, ClientScriptManager scriptManager)
        {
            StringBuilder scriptBuilder = new StringBuilder();
            scriptBuilder.Append("<script type=\"text/javascript\" src=\"").Append(scriptManager.GetWebResourceUrl(controlType, assembly).ToString()).Append("\"></script>");
            scriptManager.RegisterStartupScript(controlType, assembly, scriptBuilder.ToString());
            return scriptBuilder.ToString();
        }

        /// <summary>
        /// Writes a script tag for a file contained in the caller's assmebly.
        /// </summary>
        /// <param name="controlType"></param>
        /// <param name="assembly"></param>
        /// <param name="scriptManager"></param>
        /// <returns></returns>
        public static string WriteLocalScriptTag(Type controlType, string localPath, ClientScriptManager scriptManager)
        {
            StringBuilder scriptBuilder = new StringBuilder();
            scriptBuilder.Append("<script type=\"text/javascript\" src=\"").Append(localPath).Append("\"></script>");
            scriptManager.RegisterStartupScript(controlType, localPath, scriptBuilder.ToString());
            return scriptBuilder.ToString();
        }

        public static HtmlTextWriter CreateHtmlWriter()
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringWriter stringWriter = new StringWriter(stringBuilder);
            return new HtmlTextWriter(stringWriter);
        }
    }
}

