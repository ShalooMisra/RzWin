using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("filelink")]
    public partial class filelink_auto : NewMethod.nObject
    {
        static filelink_auto()
        {
            Item.AttributesCache(typeof(filelink_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "linkname":
                    linknameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "filepath":
                    filepathAttribute = (CoreVarValAttribute)attr;
                    break;
                case "objectclass":
                    objectclassAttribute = (CoreVarValAttribute)attr;
                    break;
                case "objectid":
                    objectidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "objectid2":
                    objectid2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "objectclass2":
                    objectclass2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "parttable2":
                    parttable2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "linktype":
                    linktypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "objecttag2":
                    objecttag2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "filetype":
                    filetypeAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute linknameAttribute;
        static CoreVarValAttribute filepathAttribute;
        static CoreVarValAttribute objectclassAttribute;
        static CoreVarValAttribute objectidAttribute;
        static CoreVarValAttribute objectid2Attribute;
        static CoreVarValAttribute objectclass2Attribute;
        static CoreVarValAttribute parttable2Attribute;
        static CoreVarValAttribute linktypeAttribute;
        static CoreVarValAttribute objecttag2Attribute;
        static CoreVarValAttribute filetypeAttribute;

        [CoreVarVal("linkname", "String", TheFieldLength = 255, Caption="Link Name", Importance = 1)]
        public VarString linknameVar;

        [CoreVarVal("filepath", "String", TheFieldLength = 255, Caption="File Path", Importance = 2)]
        public VarString filepathVar;

        [CoreVarVal("objectclass", "String", TheFieldLength = 255, Caption="Class", Importance = 3)]
        public VarString objectclassVar;

        [CoreVarVal("objectid", "String", TheFieldLength = 255, Caption="Id", Importance = 4)]
        public VarString objectidVar;

        [CoreVarVal("objectid2", "String", TheFieldLength = 50, Caption="Object Id 2", Importance = 5)]
        public VarString objectid2Var;

        [CoreVarVal("objectclass2", "String", TheFieldLength = 50, Caption="Object Class 2", Importance = 6)]
        public VarString objectclass2Var;

        [CoreVarVal("parttable2", "String", TheFieldLength = 50, Caption="Part Table 2", Importance = 7)]
        public VarString parttable2Var;

        [CoreVarVal("linktype", "String", TheFieldLength = 50, Caption="Type", Importance = 8)]
        public VarString linktypeVar;

        [CoreVarVal("objecttag2", "String", TheFieldLength = 50, Caption="Object Tag", Importance = 9)]
        public VarString objecttag2Var;

        [CoreVarVal("filetype", "String", TheFieldLength = 50, Caption="File Type", Importance = 10)]
        public VarString filetypeVar;

        public filelink_auto()
        {
            StaticInit();
            linknameVar = new VarString(this, linknameAttribute);
            filepathVar = new VarString(this, filepathAttribute);
            objectclassVar = new VarString(this, objectclassAttribute);
            objectidVar = new VarString(this, objectidAttribute);
            objectid2Var = new VarString(this, objectid2Attribute);
            objectclass2Var = new VarString(this, objectclass2Attribute);
            parttable2Var = new VarString(this, parttable2Attribute);
            linktypeVar = new VarString(this, linktypeAttribute);
            objecttag2Var = new VarString(this, objecttag2Attribute);
            filetypeVar = new VarString(this, filetypeAttribute);
        }

        public override string ClassId
        { get { return "filelink"; } }

        public String linkname
        {
            get  { return (String)linknameVar.Value; }
            set  { linknameVar.Value = value; }
        }

        public String filepath
        {
            get  { return (String)filepathVar.Value; }
            set  { filepathVar.Value = value; }
        }

        public String objectclass
        {
            get  { return (String)objectclassVar.Value; }
            set  { objectclassVar.Value = value; }
        }

        public String objectid
        {
            get  { return (String)objectidVar.Value; }
            set  { objectidVar.Value = value; }
        }

        public String objectid2
        {
            get  { return (String)objectid2Var.Value; }
            set  { objectid2Var.Value = value; }
        }

        public String objectclass2
        {
            get  { return (String)objectclass2Var.Value; }
            set  { objectclass2Var.Value = value; }
        }

        public String parttable2
        {
            get  { return (String)parttable2Var.Value; }
            set  { parttable2Var.Value = value; }
        }

        public String linktype
        {
            get  { return (String)linktypeVar.Value; }
            set  { linktypeVar.Value = value; }
        }

        public String objecttag2
        {
            get  { return (String)objecttag2Var.Value; }
            set  { objecttag2Var.Value = value; }
        }

        public String filetype
        {
            get  { return (String)filetypeVar.Value; }
            set  { filetypeVar.Value = value; }
        }

    }
    public partial class filelink
    {
        public static filelink New(Context x)
        {  return (filelink)x.Item("filelink"); }

        public static filelink GetById(Context x, String uid)
        { return (filelink)x.GetById("filelink", uid); }

        public static filelink QtO(Context x, String sql)
        { return (filelink)x.QtO("filelink", sql); }
    }
}
