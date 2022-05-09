using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("linecardlink")]
    public partial class linecardlink_auto : NewMethod.nObject
    {
        static linecardlink_auto()
        {
            Item.AttributesCache(typeof(linecardlink_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "base_manufacturer_uid":
                    base_manufacturer_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_company_uid":
                    base_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "linkdata":
                    linkdataAttribute = (CoreVarValAttribute)attr;
                    break;
                case "linktype":
                    linktypeAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute base_manufacturer_uidAttribute;
        static CoreVarValAttribute base_company_uidAttribute;
        static CoreVarValAttribute linkdataAttribute;
        static CoreVarValAttribute linktypeAttribute;

        [CoreVarVal("base_manufacturer_uid", "String", TheFieldLength = 50, Caption="Base Manufacturer Id", Importance = 1)]
        public VarString base_manufacturer_uidVar;

        [CoreVarVal("base_company_uid", "String", TheFieldLength = 50, Caption="Base Company Id", Importance = 2)]
        public VarString base_company_uidVar;

        [CoreVarVal("linkdata", "String", TheFieldLength = 255, Caption="Link Data", Importance = 3)]
        public VarString linkdataVar;

        [CoreVarVal("linktype", "String", TheFieldLength = 255, Caption="Link Type", Importance = 4)]
        public VarString linktypeVar;

        public linecardlink_auto()
        {
            StaticInit();
            base_manufacturer_uidVar = new VarString(this, base_manufacturer_uidAttribute);
            base_company_uidVar = new VarString(this, base_company_uidAttribute);
            linkdataVar = new VarString(this, linkdataAttribute);
            linktypeVar = new VarString(this, linktypeAttribute);
        }

        public override string ClassId
        { get { return "linecardlink"; } }

        public String base_manufacturer_uid
        {
            get  { return (String)base_manufacturer_uidVar.Value; }
            set  { base_manufacturer_uidVar.Value = value; }
        }

        public String base_company_uid
        {
            get  { return (String)base_company_uidVar.Value; }
            set  { base_company_uidVar.Value = value; }
        }

        public String linkdata
        {
            get  { return (String)linkdataVar.Value; }
            set  { linkdataVar.Value = value; }
        }

        public String linktype
        {
            get  { return (String)linktypeVar.Value; }
            set  { linktypeVar.Value = value; }
        }

    }
    public partial class linecardlink
    {
        public static linecardlink New(Context x)
        {  return (linecardlink)x.Item("linecardlink"); }

        public static linecardlink GetById(Context x, String uid)
        { return (linecardlink)x.GetById("linecardlink", uid); }

        public static linecardlink QtO(Context x, String sql)
        { return (linecardlink)x.QtO("linecardlink", sql); }
    }
}
