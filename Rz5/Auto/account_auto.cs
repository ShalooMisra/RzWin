using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("account", Caption="Account", Importance = 80)]
    public partial class account_auto : NewMethod.nObject
    {
        static account_auto()
        {
            Item.AttributesCache(typeof(account_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "name":
                    nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "number":
                    numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "type":
                    typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "balance":
                    balanceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "parent_id":
                    parent_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "category":
                    categoryAttribute = (CoreVarValAttribute)attr;
                    break;
                case "full_name":
                    full_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "parent_name":
                    parent_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "built_in":
                    built_inAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "extra_info":
                    extra_infoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_hidden":
                    is_hiddenAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute numberAttribute;
        static CoreVarValAttribute typeAttribute;
        static CoreVarValAttribute balanceAttribute;
        static CoreVarValAttribute parent_idAttribute;
        static CoreVarValAttribute categoryAttribute;
        static CoreVarValAttribute full_nameAttribute;
        static CoreVarValAttribute parent_nameAttribute;
        static CoreVarValAttribute built_inAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute extra_infoAttribute;
        static CoreVarValAttribute is_hiddenAttribute;

        [CoreVarVal("name", "String", Caption="Name", Importance = 0, SearchCriteria = true)]
        public VarString nameVar;

        [CoreVarVal("number", "Int32", Caption="Number", Importance = 1)]
        public VarInt32 numberVar;

        [CoreVarVal("type", "String", Caption="Type", Importance = 2)]
        public VarString typeVar;

        [CoreVarVal("balance", "Double", ValueUse = ValueUse.UnitMoney, Caption="Balance", Importance = 4)]
        public VarDouble balanceVar;

        [CoreVarVal("parent_id", "String", Caption="Parent Id", Importance = 4)]
        public VarString parent_idVar;

        [CoreVarVal("category", "String", Caption="Category", Importance = 5)]
        public VarString categoryVar;

        [CoreVarVal("full_name", "String", Caption="Full Name", Importance = 6)]
        public VarString full_nameVar;

        [CoreVarVal("parent_name", "String", Caption="Parent Name", Importance = 7)]
        public VarString parent_nameVar;

        [CoreVarVal("built_in", "Boolean", Caption="Built In", Importance = 8)]
        public VarBoolean built_inVar;

        [CoreVarVal("description", "String", Caption="Description", Importance = 9)]
        public VarString descriptionVar;

        [CoreVarVal("extra_info", "Text", Caption="Extra Info", Importance = 10)]
        public VarText extra_infoVar;

        [CoreVarVal("is_hidden", "Boolean", Caption="Is Hidden", Importance = 11)]
        public VarBoolean is_hiddenVar;

        public account_auto()
        {
            StaticInit();
            nameVar = new VarString(this, nameAttribute);
            numberVar = new VarInt32(this, numberAttribute);
            typeVar = new VarString(this, typeAttribute);
            balanceVar = new VarDouble(this, balanceAttribute);
            parent_idVar = new VarString(this, parent_idAttribute);
            categoryVar = new VarString(this, categoryAttribute);
            full_nameVar = new VarString(this, full_nameAttribute);
            parent_nameVar = new VarString(this, parent_nameAttribute);
            built_inVar = new VarBoolean(this, built_inAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            extra_infoVar = new VarText(this, extra_infoAttribute);
            is_hiddenVar = new VarBoolean(this, is_hiddenAttribute);
        }

        public override string ClassId
        { get { return "account"; } }

        public String name
        {
            get  { return (String)nameVar.Value; }
            set  { nameVar.Value = value; }
        }

        public Int32 number
        {
            get  { return (Int32)numberVar.Value; }
            set  { numberVar.Value = value; }
        }

        public String type
        {
            get  { return (String)typeVar.Value; }
            set  { typeVar.Value = value; }
        }

        public Double balance
        {
            get  { return (Double)balanceVar.Value; }
            set  { balanceVar.Value = value; }
        }

        public String parent_id
        {
            get  { return (String)parent_idVar.Value; }
            set  { parent_idVar.Value = value; }
        }

        public String category
        {
            get  { return (String)categoryVar.Value; }
            set  { categoryVar.Value = value; }
        }

        public String full_name
        {
            get  { return (String)full_nameVar.Value; }
            set  { full_nameVar.Value = value; }
        }

        public String parent_name
        {
            get  { return (String)parent_nameVar.Value; }
            set  { parent_nameVar.Value = value; }
        }

        public Boolean built_in
        {
            get  { return (Boolean)built_inVar.Value; }
            set  { built_inVar.Value = value; }
        }

        public String description
        {
            get  { return (String)descriptionVar.Value; }
            set  { descriptionVar.Value = value; }
        }

        public String extra_info
        {
            get  { return (String)extra_infoVar.Value; }
            set  { extra_infoVar.Value = value; }
        }

        public Boolean is_hidden
        {
            get  { return (Boolean)is_hiddenVar.Value; }
            set  { is_hiddenVar.Value = value; }
        }

    }
    public partial class account
    {
        public static account New(Context x)
        {  return (account)x.Item("account"); }

        public static account GetById(Context x, String uid)
        { return (account)x.GetById("account", uid); }

        public static account QtO(Context x, String sql)
        { return (account)x.QtO("account", sql); }

        public static account GetByName(Context x, String name, String extraSql = "")
        { return (account)x.GetByName("account", name, extraSql); }
    }
}
