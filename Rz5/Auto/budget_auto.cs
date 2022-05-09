using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("budget", Caption="Budget", Importance = 85)]
    public partial class budget_auto : NewMethod.nObject
    {
        static budget_auto()
        {
            Item.AttributesCache(typeof(budget_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "budget_name":
                    budget_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "budget_year":
                    budget_yearAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute budget_nameAttribute;
        static CoreVarValAttribute budget_yearAttribute;

        [CoreVarVal("budget_name", "String", Caption="Budget Name", Importance = 0)]
        public VarString budget_nameVar;

        [CoreVarVal("budget_year", "Int32", Caption="Budget Year", Importance = 1)]
        public VarInt32 budget_yearVar;

        public budget_auto()
        {
            StaticInit();
            budget_nameVar = new VarString(this, budget_nameAttribute);
            budget_yearVar = new VarInt32(this, budget_yearAttribute);
        }

        public override string ClassId
        { get { return "budget"; } }

        public String budget_name
        {
            get  { return (String)budget_nameVar.Value; }
            set  { budget_nameVar.Value = value; }
        }

        public Int32 budget_year
        {
            get  { return (Int32)budget_yearVar.Value; }
            set  { budget_yearVar.Value = value; }
        }

    }
    public partial class budget
    {
        public static budget New(Context x)
        {  return (budget)x.Item("budget"); }

        public static budget GetById(Context x, String uid)
        { return (budget)x.GetById("budget", uid); }

        public static budget QtO(Context x, String sql)
        { return (budget)x.QtO("budget", sql); }
    }
}
