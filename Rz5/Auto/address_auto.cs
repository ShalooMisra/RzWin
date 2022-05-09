using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("address")]
    public partial class address_auto : NewMethod.nObject
    {
        static address_auto()
        {
            Item.AttributesCache(typeof(address_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "companyid":
                    companyidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contactid":
                    contactidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "addresstype":
                    addresstypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isdefault":
                    isdefaultAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isinternational":
                    isinternationalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "internationaltext":
                    internationaltextAttribute = (CoreVarValAttribute)attr;
                    break;
                case "line1":
                    line1Attribute = (CoreVarValAttribute)attr;
                    break;
                case "line2":
                    line2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "line3":
                    line3Attribute = (CoreVarValAttribute)attr;
                    break;
                case "city":
                    cityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "state":
                    stateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "zipcode":
                    zipcodeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "country":
                    countryAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute companyidAttribute;
        static CoreVarValAttribute contactidAttribute;
        static CoreVarValAttribute addresstypeAttribute;
        static CoreVarValAttribute isdefaultAttribute;
        static CoreVarValAttribute isinternationalAttribute;
        static CoreVarValAttribute internationaltextAttribute;
        static CoreVarValAttribute line1Attribute;
        static CoreVarValAttribute line2Attribute;
        static CoreVarValAttribute line3Attribute;
        static CoreVarValAttribute cityAttribute;
        static CoreVarValAttribute stateAttribute;
        static CoreVarValAttribute zipcodeAttribute;
        static CoreVarValAttribute countryAttribute;

        [CoreVarVal("companyid", "String", TheFieldLength = 50, Caption="Company Id", Importance = 1)]
        public VarString companyidVar;

        [CoreVarVal("contactid", "String", TheFieldLength = 50, Caption="Contact Id", Importance = 2)]
        public VarString contactidVar;

        [CoreVarVal("addresstype", "String", TheFieldLength = 50, Caption="Address Type", Importance = 3)]
        public VarString addresstypeVar;

        [CoreVarVal("isdefault", "Boolean", Caption="Is Default", Importance = 4)]
        public VarBoolean isdefaultVar;

        [CoreVarVal("isinternational", "String", TheFieldLength = 50, Caption="Is International", Importance = 5)]
        public VarString isinternationalVar;

        [CoreVarVal("internationaltext", "String", TheFieldLength = 50, Caption="International Text", Importance = 6)]
        public VarString internationaltextVar;

        [CoreVarVal("line1", "String", TheFieldLength = 50, Caption="Line 1", Importance = 7)]
        public VarString line1Var;

        [CoreVarVal("line2", "String", TheFieldLength = 50, Caption="Line 2", Importance = 8)]
        public VarString line2Var;

        [CoreVarVal("line3", "String", TheFieldLength = 50, Caption="Line 3", Importance = 9)]
        public VarString line3Var;

        [CoreVarVal("city", "String", TheFieldLength = 50, Caption="City", Importance = 10)]
        public VarString cityVar;

        [CoreVarVal("state", "String", TheFieldLength = 50, Caption="State", Importance = 11)]
        public VarString stateVar;

        [CoreVarVal("zipcode", "String", TheFieldLength = 50, Caption="Zip Code", Importance = 12)]
        public VarString zipcodeVar;

        [CoreVarVal("country", "String", TheFieldLength = 50, Caption="Country", Importance = 13)]
        public VarString countryVar;

        public address_auto()
        {
            StaticInit();
            companyidVar = new VarString(this, companyidAttribute);
            contactidVar = new VarString(this, contactidAttribute);
            addresstypeVar = new VarString(this, addresstypeAttribute);
            isdefaultVar = new VarBoolean(this, isdefaultAttribute);
            isinternationalVar = new VarString(this, isinternationalAttribute);
            internationaltextVar = new VarString(this, internationaltextAttribute);
            line1Var = new VarString(this, line1Attribute);
            line2Var = new VarString(this, line2Attribute);
            line3Var = new VarString(this, line3Attribute);
            cityVar = new VarString(this, cityAttribute);
            stateVar = new VarString(this, stateAttribute);
            zipcodeVar = new VarString(this, zipcodeAttribute);
            countryVar = new VarString(this, countryAttribute);
        }

        public override string ClassId
        { get { return "address"; } }

        public String companyid
        {
            get  { return (String)companyidVar.Value; }
            set  { companyidVar.Value = value; }
        }

        public String contactid
        {
            get  { return (String)contactidVar.Value; }
            set  { contactidVar.Value = value; }
        }

        public String addresstype
        {
            get  { return (String)addresstypeVar.Value; }
            set  { addresstypeVar.Value = value; }
        }

        public Boolean isdefault
        {
            get  { return (Boolean)isdefaultVar.Value; }
            set  { isdefaultVar.Value = value; }
        }

        public String isinternational
        {
            get  { return (String)isinternationalVar.Value; }
            set  { isinternationalVar.Value = value; }
        }

        public String internationaltext
        {
            get  { return (String)internationaltextVar.Value; }
            set  { internationaltextVar.Value = value; }
        }

        public String line1
        {
            get  { return (String)line1Var.Value; }
            set  { line1Var.Value = value; }
        }

        public String line2
        {
            get  { return (String)line2Var.Value; }
            set  { line2Var.Value = value; }
        }

        public String line3
        {
            get  { return (String)line3Var.Value; }
            set  { line3Var.Value = value; }
        }

        public String city
        {
            get  { return (String)cityVar.Value; }
            set  { cityVar.Value = value; }
        }

        public String state
        {
            get  { return (String)stateVar.Value; }
            set  { stateVar.Value = value; }
        }

        public String zipcode
        {
            get  { return (String)zipcodeVar.Value; }
            set  { zipcodeVar.Value = value; }
        }

        public String country
        {
            get  { return (String)countryVar.Value; }
            set  { countryVar.Value = value; }
        }

    }
    public partial class address
    {
        public static address New(Context x)
        {  return (address)x.Item("address"); }

        public static address GetById(Context x, String uid)
        { return (address)x.GetById("address", uid); }

        public static address QtO(Context x, String sql)
        { return (address)x.QtO("address", sql); }
    }
}
