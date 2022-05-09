using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Tools
{
    public partial class Xml
    {
        //Public Static Functions
        public static String BuildXmlProp(String strName, long val)
        {
            return BuildXmlProp(strName, val.ToString(), true);
        }
        public static String BuildXmlProp(String strName, int val)
        {
            return BuildXmlProp(strName, val.ToString(), true);
        }
        public static String BuildXmlProp(String strName, bool val)
        {
            return BuildXmlProp(strName, val.ToString(), true);
        }
        public static String BuildXmlProp(String strName, String strValue)
        {
            return BuildXmlProp(strName, strValue, true);
        }
        public static String BuildXmlProp(String strName, String strValue, bool encode)
        {
            if (encode)
                return "<" + strName + ">" + Xml.EncodeForXml(strValue) + "</" + strName + ">\n";
            else
                return "<" + strName + ">" + strValue + "</" + strName + ">\n";
        }
        public static String ReadXmlProp(XmlNode n, String strName)
        {
            try
            {
                XmlNode fNode = n.SelectSingleNode(strName);
                return fNode.InnerText;
            }
            catch
            {
                return "";
            }
        }
        public static long ReadXmlProp_Long(XmlNode n, String strName)
        {
            try
            {
                XmlNode fNode = n.SelectSingleNode(strName);
                return Int64.Parse(fNode.InnerText);
            }
            catch
            {
                return 0;
            }
        }
        public static int ReadXmlProp_Integer(XmlNode n, String strName)
        {
            try
            {
                XmlNode fNode = n.SelectSingleNode(strName);
                return Int32.Parse(fNode.InnerText);
            }
            catch
            {
                return 0;
            }
        }
        public static bool ReadXmlProp_Boolean(XmlNode n, String strName)
        {
            try
            {
                XmlNode fNode = n.SelectSingleNode(strName);
                return Boolean.Parse(fNode.InnerText);
            }
            catch
            {
                return false;
            }
        }

        public static bool ReadXmlProp_Boolean(XmlNode n, String strName, bool def)
        {
            try
            {
                XmlNode fNode = n.SelectSingleNode(strName);
                if (fNode == null)
                    return def;

                return Boolean.Parse(fNode.InnerText);
            }
            catch { return def; }
        }

        public static String EncodeForXml(String s)
        {
            return s.Replace("&", "&amp;").Replace("<", "&lt;").Replace("\r", "&#xD;").Replace("\n", "&#xA;");
        }
    }
}
