using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("emailaddress")]
    public partial class emailaddress_auto : NewMethod.nObject
    {
        static emailaddress_auto()
        {
            Item.AttributesCache(typeof(emailaddress_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "addressstring":
                    addressstringAttribute = (CoreVarValAttribute)attr;
                    break;
                case "basestring":
                    basestringAttribute = (CoreVarValAttribute)attr;
                    break;
                case "domainstring":
                    domainstringAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute addressstringAttribute;
        static CoreVarValAttribute basestringAttribute;
        static CoreVarValAttribute domainstringAttribute;

        [CoreVarVal("addressstring", "String", TheFieldLength = 255, Caption="String", Importance = 1)]
        public VarString addressstringVar;

        [CoreVarVal("basestring", "String", TheFieldLength = 255, Caption="Base", Importance = 2)]
        public VarString basestringVar;

        [CoreVarVal("domainstring", "String", TheFieldLength = 255, Caption="Domain String", Importance = 3)]
        public VarString domainstringVar;

        public emailaddress_auto()
        {
            StaticInit();
            addressstringVar = new VarString(this, addressstringAttribute);
            basestringVar = new VarString(this, basestringAttribute);
            domainstringVar = new VarString(this, domainstringAttribute);
        }

        public override string ClassId
        { get { return "emailaddress"; } }

        public String addressstring
        {
            get  { return (String)addressstringVar.Value; }
            set  { addressstringVar.Value = value; }
        }

        public String basestring
        {
            get  { return (String)basestringVar.Value; }
            set  { basestringVar.Value = value; }
        }

        public String domainstring
        {
            get  { return (String)domainstringVar.Value; }
            set  { domainstringVar.Value = value; }
        }

    }
    public partial class emailaddress
    {
        public static emailaddress New(Context x)
        {  return (emailaddress)x.Item("emailaddress"); }

        public static emailaddress GetById(Context x, String uid)
        { return (emailaddress)x.GetById("emailaddress", uid); }

        public static emailaddress QtO(Context x, String sql)
        { return (emailaddress)x.QtO("emailaddress", sql); }
    }
}
