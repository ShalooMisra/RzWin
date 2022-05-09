using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("ordhed_vendrma")]
    public partial class ordhed_vendrma_auto : Rz5.ordhed_new
    {
        static ordhed_vendrma_auto()
        {
            Item.AttributesCache(typeof(ordhed_vendrma_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "is_consign":
                    is_consignAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lot_number":
                    lot_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ship_date_actual":
                    ship_date_actualAttribute = (CoreVarValAttribute)attr;
                    break;
                
            }
        }

        static CoreVarValAttribute is_consignAttribute;
        static CoreVarValAttribute lot_numberAttribute;
        static CoreVarValAttribute ship_date_actualAttribute;
       
        

        [CoreVarVal("is_consign", "Boolean", Caption="Is Consign", Importance = 6)]
        public VarBoolean is_consignVar;

        [CoreVarVal("lot_number", "String", TheFieldLength = 255, Caption="Lot Number", Importance = 7)]
        public VarString lot_numberVar;

        [CoreVarVal("ship_date_actual", "DateTime", Caption="Ship Date Actual", Importance = 2)]
        public VarDateTime ship_date_actualVar;

       


        

        public ordhed_vendrma_auto()
        {
            StaticInit();
            is_consignVar = new VarBoolean(this, is_consignAttribute);
            lot_numberVar = new VarString(this, lot_numberAttribute);
            ship_date_actualVar = new VarDateTime(this, ship_date_actualAttribute);
          
        }

        public override string ClassId
        { get { return "ordhed_vendrma"; } }

        public Boolean is_consign
        {
            get  { return (Boolean)is_consignVar.Value; }
            set  { is_consignVar.Value = value; }
        }

        public String lot_number
        {
            get  { return (String)lot_numberVar.Value; }
            set  { lot_numberVar.Value = value; }
        }

        public DateTime ship_date_actual
        {
            get  { return (DateTime)ship_date_actualVar.Value; }
            set  { ship_date_actualVar.Value = value; }
        }
       

    }
    public partial class ordhed_vendrma
    {
        public static ordhed_vendrma New(Context x)
        {  return (ordhed_vendrma)x.Item("ordhed_vendrma"); }

        public static ordhed_vendrma GetById(Context x, String uid)
        { return (ordhed_vendrma)x.GetById("ordhed_vendrma", uid); }

        public static ordhed_vendrma QtO(Context x, String sql)
        { return (ordhed_vendrma)x.QtO("ordhed_vendrma", sql); }
    }
}
