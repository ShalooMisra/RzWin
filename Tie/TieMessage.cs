using System;
using System.Collections;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using System.Windows.Forms;

using NewMethodx;
using OthersCodex;
using System.Collections.Generic;

namespace Tie
{
    public class TieMessage
    {
        public String XMLData = "";
        public String FunctionName = "";
        public String ContentString = "";
        public String FromSession = "";
        public String ToSession = "";
        public String JobID = "";
        public XmlNode ContentNode;
        public String EntireMessage = "";
        public bool FullyParsed = false;
        public bool UseEntireMessage = false;
        Dictionary<String, String> ExtraValues = null;

        public static System.Xml.XmlNode Parse(String strXML, ref String strFunction, ref String strTo, ref String strJob)
        {
            System.Xml.XmlDocument d = new System.Xml.XmlDocument();

            try
            {
                d.LoadXml(strXML);
                XmlNode xNode = d.SelectSingleNode("commands/command[1]");
                strFunction = Tools.Xml.ReadXmlProp(xNode, "functionname");
                strTo = Tools.Xml.ReadXmlProp(xNode, "to_session");
                strJob = Tools.Xml.ReadXmlProp(xNode, "job_id");
                return xNode;
            }
            catch (Exception e)
            {
                strFunction = "";
                strTo = "";
                strJob = "";
                return null;
            }
        }
        public TieMessage(String all)
        {
            QuickParse(all);
        }

        public TieMessage(String fromsession, String functionName, String tosession)
        {
            FromSession = fromsession;
            ToSession = tosession;
            FunctionName = functionName;
        }

        public bool IsHello
        {
            get { return Tools.Strings.StrCmp(FunctionName, "hello"); }
        }

        public bool IsEchoRequest
        {
            get { return Tools.Strings.StrCmp(FunctionName, "echo_request"); }
        }

        public virtual void InitialParse(XmlNode n)
        {
            try
            {
                try
                {
                    ContentNode = n.SelectSingleNode("content");
                    ContentString = ContentNode.InnerXml;
                    FromSession = Tools.Xml.ReadXmlProp(n, "from_session");
                    ToSession = Tools.Xml.ReadXmlProp(n, "to_session");
                    JobID = Tools.Xml.ReadXmlProp(n, "job_id");

                    foreach (XmlNode nc in n.ChildNodes)
                    {
                        if (nc.Name.StartsWith("ext_"))
                        {
                            if (ExtraValues == null)
                                ExtraValues = new Dictionary<string, string>();
                            ExtraValues.Add(nc.Name.Substring(4), nc.InnerText);
                        }
                    }
                }
                catch
                {
                    ContentString = "";
                    FromSession = "";
                    ToSession = "";
                    JobID = "";
                    ContentNode = null;
                }
                FullyParsed = true;
            }
            catch { }
        }

        public String GetWrappedXml()
        {
            if (UseEntireMessage)
                return "<begin_message>" + EntireMessage + "<end_message>";

            return "<begin_message>:" + ToSession + ";" + GetXML() + "<end_message>";
        }

        public String GetWrappedXml(String password)
        {
            if (UseEntireMessage)
                return "<begin_message>" + EntireMessage + "<end_message>";

            return "<begin_message>:" + ToSession + ";_encrypted_" + EncDec.Encrypt(GetXML(), password) + "<end_message>";
        }

        public String GetXML()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<?xml version=\"1.0\"?>\n");
            sb.Append("<commands>\n");
            sb.Append("<command>\n");

            sb.Append(Tools.Xml.BuildXmlProp("functionname", FunctionName));
            sb.Append(Tools.Xml.BuildXmlProp("from_session", FromSession));
            sb.Append(Tools.Xml.BuildXmlProp("to_session", ToSession));
            sb.Append(Tools.Xml.BuildXmlProp("job_id", JobID));

            if (ExtraValues != null)
            {
                foreach (KeyValuePair<String, String> k in ExtraValues)
                {
                    sb.Append(Tools.Xml.BuildXmlProp("ext_" + k.Key, k.Value));
                }
            }

            sb.Append(Tools.Xml.BuildXmlProp("content", ContentString, false));

            sb.Append("</command>\n");
            sb.Append("</commands>");

            return sb.ToString();
        }

        public void QuickParse(String all)
        {
            EntireMessage = all;
            if (all.StartsWith(":"))    //strip the 'to' away
            {
                int mark = all.IndexOf(';');
                if (mark > 1)
                    ToSession = all.Substring(1, mark - 1);
                else
                    ToSession = "";
            }
            else
            {
                ToSession = "";
            }
        }

        public void FullyParse(String password)
        {
            try
            {
                String content = EntireMessage;
                if (content.StartsWith(":"))    //strip the 'to' away
                {
                    int mark = content.IndexOf(';');
                    content = content.Substring(mark + 1);
                }

                if (content.StartsWith("_encrypted_"))
                    content = EncDec.Decrypt(content.Substring(11), password);

                String f = "";
                String t = "";
                String j = "";
                XmlNode n = TieMessage.Parse(content, ref f, ref t, ref j);

                FunctionName = f;
                ToSession = t;
                JobID = j;
                XMLData = content;
                InitialParse(n);
            }
            catch
            {
                ;
            }
        }

        public void AddExtraValue(String key, String value)
        {
            if (ExtraValues == null)
                ExtraValues = new Dictionary<string, string>();

            ExtraValues.Add(key, value);
        }

        public String GetExtraValue(String key)
        {
            try
            {
                return ExtraValues[key];
            }
            catch { return ""; }
        }
    }
}