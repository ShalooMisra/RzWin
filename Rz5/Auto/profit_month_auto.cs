using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("profit_month")]
    public partial class profit_month_auto : NewMethod.nObject
    {
        static profit_month_auto()
        {
            Item.AttributesCache(typeof(profit_month_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "year_number":
                    year_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "month_number":
                    month_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "profit_date":
                    profit_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "user_name":
                    user_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "profit_amount":
                    profit_amountAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute year_numberAttribute;
        static CoreVarValAttribute month_numberAttribute;
        static CoreVarValAttribute profit_dateAttribute;
        static CoreVarValAttribute user_nameAttribute;
        static CoreVarValAttribute profit_amountAttribute;

        [CoreVarVal("year_number", "Int32", Caption="Year Number", Importance = 1)]
        public VarInt32 year_numberVar;

        [CoreVarVal("month_number", "Int32", Caption="Month Number", Importance = 2)]
        public VarInt32 month_numberVar;

        [CoreVarVal("profit_date", "DateTime", Caption="Profit Date", Importance = 3)]
        public VarDateTime profit_dateVar;

        [CoreVarVal("user_name", "String", TheFieldLength = 255, Caption="User Name", Importance = 4)]
        public VarString user_nameVar;

        [CoreVarVal("profit_amount", "Double", Caption="Profit Amount", Importance = 5)]
        public VarDouble profit_amountVar;

        public profit_month_auto()
        {
            StaticInit();
            year_numberVar = new VarInt32(this, year_numberAttribute);
            month_numberVar = new VarInt32(this, month_numberAttribute);
            profit_dateVar = new VarDateTime(this, profit_dateAttribute);
            user_nameVar = new VarString(this, user_nameAttribute);
            profit_amountVar = new VarDouble(this, profit_amountAttribute);
        }

        public override string ClassId
        { get { return "profit_month"; } }

        public Int32 year_number
        {
            get  { return (Int32)year_numberVar.Value; }
            set  { year_numberVar.Value = value; }
        }

        public Int32 month_number
        {
            get  { return (Int32)month_numberVar.Value; }
            set  { month_numberVar.Value = value; }
        }

        public DateTime profit_date
        {
            get  { return (DateTime)profit_dateVar.Value; }
            set  { profit_dateVar.Value = value; }
        }

        public String user_name
        {
            get  { return (String)user_nameVar.Value; }
            set  { user_nameVar.Value = value; }
        }

        public Double profit_amount
        {
            get  { return (Double)profit_amountVar.Value; }
            set  { profit_amountVar.Value = value; }
        }

    }
    public partial class profit_month
    {
        public static profit_month New(Context x)
        {  return (profit_month)x.Item("profit_month"); }

        public static profit_month GetById(Context x, String uid)
        { return (profit_month)x.GetById("profit_month", uid); }

        public static profit_month QtO(Context x, String sql)
        { return (profit_month)x.QtO("profit_month", sql); }
    }
}
