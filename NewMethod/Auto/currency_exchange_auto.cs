using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("currency_exchange", Importance = -1)]
    public partial class currency_exchange_auto : NewMethod.nObject
    {
        static currency_exchange_auto()
        {
            Item.AttributesCache(typeof(currency_exchange_auto), AttributeCache);
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
            }
        }

        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute exchange_rateAttribute;

        [CoreVarVal("name", "String", TheFieldLength = 255, Caption="Name", Importance = 1)]
        public VarString nameVar;

        [CoreVarVal("exchange_rate", "Double", Caption="Exchange Rate", Importance = 2)]
        public VarDouble exchange_rateVar;

        public currency_exchange_auto()
        {
            StaticInit();
            nameVar = new VarString(this, nameAttribute);
            exchange_rateVar = new VarDouble(this, exchange_rateAttribute);
        }

        public override string ClassId
        { get { return "currency_exchange"; } }

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

    }
    public partial class currency_exchange
    {
        public static currency_exchange New(Context x)
        {  return (currency_exchange)x.Item("currency_exchange"); }

        public static currency_exchange GetById(Context x, String uid)
        { return (currency_exchange)x.GetById("currency_exchange", uid); }

        public static currency_exchange QtO(Context x, String sql)
        { return (currency_exchange)x.QtO("currency_exchange", sql); }

        public static currency_exchange GetByName(Context x, String name, String extraSql = "")
        { return (currency_exchange)x.GetByName("currency_exchange", name, extraSql); }
    }
}
