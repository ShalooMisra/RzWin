using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using NewMethodx;

namespace Tie
{
    public enum EternalItemType
    {
        None = 0,
        File = 1,
        Folder = 2,
        Database = 3,
    }

    public class EternalItemHandle
    {
        public static String EternalTableCheckName = "new_method_software_eternal_check_id_holding_table";

        public EternalItemType TheType;
        public String FileName = "";
        public String FolderPath = "";
        public String ServerName = "";
        public String DatabaseName = "";
        public String UserName = "";
        public String Password = "";
        public String Caption = "";

        public String GetAsXml()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Tools.Xml.BuildXmlProp("item_type", (int)TheType));
            sb.Append(Tools.Xml.BuildXmlProp("file_name", FileName));
            sb.Append(Tools.Xml.BuildXmlProp("folder_path", FolderPath));
            sb.Append(Tools.Xml.BuildXmlProp("server_name", ServerName));
            sb.Append(Tools.Xml.BuildXmlProp("database_name", DatabaseName));
            sb.Append(Tools.Xml.BuildXmlProp("user_name", UserName));
            sb.Append(Tools.Xml.BuildXmlProp("password", Password));
            sb.Append(Tools.Xml.BuildXmlProp("caption", Caption));
            //sb.Append(Tools.Xml.BuildXmlProp("", ));
            //sb.Append(Tools.Xml.BuildXmlProp("", ));
            //sb.Append(Tools.Xml.BuildXmlProp("", ));

            return sb.ToString();
        }

        public void AbsorbXml(XmlNode n)
        {
            TheType = (EternalItemType)Tools.Xml.ReadXmlProp_Integer(n, "item_type");
            FileName = Tools.Xml.ReadXmlProp(n, "file_name");
            FolderPath = Tools.Xml.ReadXmlProp(n, "folder_path");
            ServerName = Tools.Xml.ReadXmlProp(n, "server_name");
            DatabaseName = Tools.Xml.ReadXmlProp(n, "database_name");
            UserName = Tools.Xml.ReadXmlProp(n, "user_name");
            Password = Tools.Xml.ReadXmlProp(n, "password");
            Caption = Tools.Xml.ReadXmlProp(n, "caption");
        }
    }

    //public class PedestalHandle
    //{
    //    public String FTPSite = "";
    //    public String FTPFolder = "";
    //    public String ServerName = "";
    //    public String DatabaseName = "";
    //    public String UserName = "";
    //    public String Password = "";

    //    public String GetAsXml()
    //    {
    //        StringBuilder sb = new StringBuilder();

    //        sb.Append(Tools.Xml.BuildXmlProp("item_type", (int)TheType));
    //        sb.Append(Tools.Xml.BuildXmlProp("file_name", FileName));
    //        sb.Append(Tools.Xml.BuildXmlProp("folder_name", FolderName));
    //        sb.Append(Tools.Xml.BuildXmlProp("server_name", ServerName));
    //        sb.Append(Tools.Xml.BuildXmlProp("database_name", DatabaseName));
    //        sb.Append(Tools.Xml.BuildXmlProp("user_name", UserName));
    //        sb.Append(Tools.Xml.BuildXmlProp("password", Password));
    //        //sb.Append(Tools.Xml.BuildXmlProp("", ));
    //        //sb.Append(Tools.Xml.BuildXmlProp("", ));
    //        //sb.Append(Tools.Xml.BuildXmlProp("", ));

    //        return sb.ToString();
    //    }

    //    public void AbsorbXml(XmlNode n)
    //    {
    //        TheType = (EternalItemType)Tools.Xml.ReadXmlProp_Integer(n, "item_type");
    //        FileName = Tools.Xml.ReadXmlProp(n, "file_name");
    //        FolderName = Tools.Xml.ReadXmlProp(n, "folder_name");
    //        ServerName = Tools.Xml.ReadXmlProp(n, "server_name");
    //        DatabaseName = Tools.Xml.ReadXmlProp(n, "database_name");
    //        UserName = Tools.Xml.ReadXmlProp(n, "user_name");
    //        Password = Tools.Xml.ReadXmlProp(n, "password");
    //    }


    //}
}
