using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("ordhed_rma")]
    public partial class ordhed_rma_auto : Rz5.ordhed_new
    {
        static ordhed_rma_auto()
        {
            Item.AttributesCache(typeof(ordhed_rma_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "receive_date_actual":
                    receive_date_actualAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute receive_date_actualAttribute;

        [CoreVarVal("receive_date_actual", "DateTime", Caption="Receive Date Actual", Importance = 0)]
        public VarDateTime receive_date_actualVar;

        public ordhed_rma_auto()
        {
            StaticInit();
            receive_date_actualVar = new VarDateTime(this, receive_date_actualAttribute);
        }

        public override string ClassId
        { get { return "ordhed_rma"; } }

        public DateTime receive_date_actual
        {
            get  { return (DateTime)receive_date_actualVar.Value; }
            set  { receive_date_actualVar.Value = value; }
        }

    }
    public partial class ordhed_rma
    {
        public static ordhed_rma New(Context x)
        {  return (ordhed_rma)x.Item("ordhed_rma"); }

        public static ordhed_rma GetById(Context x, String uid)
        { return (ordhed_rma)x.GetById("ordhed_rma", uid); }

        public static ordhed_rma QtO(Context x, String sql)
        { return (ordhed_rma)x.QtO("ordhed_rma", sql); }
    }
}
