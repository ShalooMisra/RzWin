using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("manufacturer")]
    public partial class manufacturer_auto : NewMethod.nObject
    {
        static manufacturer_auto()
        {
            Item.AttributesCache(typeof(manufacturer_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "manufacturer_name":
                    manufacturer_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alias_data":
                    alias_dataAttribute = (CoreVarValAttribute)attr;
                    break;
                case "address":
                    addressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "manufacturer_url":
                    manufacturer_urlAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute manufacturer_nameAttribute;
        static CoreVarValAttribute alias_dataAttribute;
        static CoreVarValAttribute addressAttribute;
        static CoreVarValAttribute manufacturer_urlAttribute;

        [CoreVarVal("manufacturer_name", "String", TheFieldLength = 255, Caption="Manufacturer Name", Importance = 1)]
        public VarString manufacturer_nameVar;

        [CoreVarVal("alias_data", "Text", Caption="Alias Data", Importance = 2)]
        public VarText alias_dataVar;

        [CoreVarVal("address", "String", TheFieldLength = 255, Caption="Address", Importance = 3)]
        public VarString addressVar;

        [CoreVarVal("manufacturer_url", "String", TheFieldLength = 8000, Caption="Manufacturer Url", Importance = 4)]
        public VarString manufacturer_urlVar;

        public manufacturer_auto()
        {
            StaticInit();
            manufacturer_nameVar = new VarString(this, manufacturer_nameAttribute);
            alias_dataVar = new VarText(this, alias_dataAttribute);
            addressVar = new VarString(this, addressAttribute);
            manufacturer_urlVar = new VarString(this, manufacturer_urlAttribute);
        }

        public override string ClassId
        { get { return "manufacturer"; } }

        public String manufacturer_name
        {
            get  { return (String)manufacturer_nameVar.Value; }
            set  { manufacturer_nameVar.Value = value; }
        }

        public String alias_data
        {
            get  { return (String)alias_dataVar.Value; }
            set  { alias_dataVar.Value = value; }
        }

        public String address
        {
            get  { return (String)addressVar.Value; }
            set  { addressVar.Value = value; }
        }

        public String manufacturer_url
        {
            get  { return (String)manufacturer_urlVar.Value; }
            set  { manufacturer_urlVar.Value = value; }
        }

    }
    public partial class manufacturer
    {
        public static manufacturer New(Context x)
        {  return (manufacturer)x.Item("manufacturer"); }

        public static manufacturer GetById(Context x, String uid)
        { return (manufacturer)x.GetById("manufacturer", uid); }

        public static manufacturer QtO(Context x, String sql)
        { return (manufacturer)x.QtO("manufacturer", sql); }
    }
}
