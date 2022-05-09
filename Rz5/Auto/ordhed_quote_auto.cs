using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("ordhed_quote")]
    public partial class ordhed_quote_auto : Rz5.ordhed_old
    {
        static ordhed_quote_auto()
        {
            Item.AttributesCache(typeof(ordhed_quote_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {               
                case "is_oem_product":
                    is_oem_productAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_all_data_gathered":
                    is_all_data_gatheredAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ready_to_validate":
                    ready_to_validateAttribute = (CoreVarValAttribute)attr;
                    break;


            }
        }

        static CoreVarValAttribute is_oem_productAttribute;
        static CoreVarValAttribute is_all_data_gatheredAttribute;
        static CoreVarValAttribute ready_to_validateAttribute;
        


        [CoreVarVal("is_oem_product", "Boolean", Caption = "Is OEM Product", Importance = 3)]
        public VarBoolean is_oem_productVar;

        [CoreVarVal("is_all_data_gathered", "Boolean", Caption = "Has the Salesperson gathered all critical data", Importance = 4)]
        public VarBoolean is_all_data_gatheredVar;

        [CoreVarVal("ready_to_validate", "Boolean", Caption = "Order data gathered by sales rep, ready for validation.", Importance = 4)]
        public VarBoolean ready_to_validateVar;

        


        public ordhed_quote_auto()
        {
            StaticInit();

            is_oem_productVar = new VarBoolean(this, is_oem_productAttribute);
            is_all_data_gatheredVar = new VarBoolean(this, is_all_data_gatheredAttribute);
            ready_to_validateVar = new VarBoolean(this, ready_to_validateAttribute);
            
        }

        public override string ClassId
        { get { return "ordhed_quote"; } }


        public bool is_oem_product
        {
            get { return (bool)is_oem_productVar.Value; }
            set { is_oem_productVar.Value = value; }
        }

        public bool is_all_data_gathered
        {
            get { return (bool)is_all_data_gatheredVar.Value; }
            set { is_all_data_gatheredVar.Value = value; }
        }

        public bool ready_to_validate
        {
            get { return (bool)ready_to_validateVar.Value; }
            set { ready_to_validateVar.Value = value; }
        }

        


    }
    public partial class ordhed_quote
    {
        public static ordhed_quote New(Context x)
        {  return (ordhed_quote)x.Item("ordhed_quote"); }

        public static ordhed_quote GetById(Context x, String uid)
        { return (ordhed_quote)x.GetById("ordhed_quote", uid); }

        public static ordhed_quote QtO(Context x, String sql)
        { return (ordhed_quote)x.QtO("ordhed_quote", sql); }
    }
}
