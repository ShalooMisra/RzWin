using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("currency", Caption="Currency", Importance = 79)]
    public partial class currency_auto : NewMethod.nObject
    {
        static currency_auto()
        {
            Item.AttributesCache(typeof(currency_auto), AttributeCache);
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
                case "exchange_rate":
                    exchange_rateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "symbol":
                    symbolAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute exchange_rateAttribute;
        static CoreVarValAttribute symbolAttribute;

        [CoreVarVal("name", "String", Caption="Name", Importance = 0)]
        public VarString nameVar;

        [CoreVarVal("exchange_rate", "Double", Caption="Exchange Rate", Importance = 1)]
        public VarDouble exchange_rateVar;

        [CoreVarVal("symbol", "String", Caption="Symbol", Importance = 2)]
        public VarString symbolVar;

        public currency_auto()
        {
            StaticInit();
            nameVar = new VarString(this, nameAttribute);
            exchange_rateVar = new VarDouble(this, exchange_rateAttribute);
            symbolVar = new VarString(this, symbolAttribute);
        }

        public override string ClassId
        { get { return "currency"; } }

        public String name
        {
            get  { return (String)nameVar.Value; }
            set  { nameVar.Value = value; }
        }

        public Double exchange_rate
        {
            get  { return (Double)exchange_rateVar.Value; }
            set  { exchange_rateVar.Value = value; }
        }

        public String symbol
        {
            get  { return (String)symbolVar.Value; }
            set  { symbolVar.Value = value; }
        }

    }
    public partial class currency
    {
        public static currency New(Context x)
        {  return (currency)x.Item("currency"); }

        public static currency GetById(Context x, String uid)
        { return (currency)x.GetById("currency", uid); }

        public static currency QtO(Context x, String sql)
        { return (currency)x.QtO("currency", sql); }

        public static currency GetByName(Context x, String name, String extraSql = "")
        { return (currency)x.GetByName("currency", name, extraSql); }
    }
}
