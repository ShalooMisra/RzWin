using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("ordhed_rfq")]
    public partial class ordhed_rfq_auto : Rz5.ordhed_old
    {
        static ordhed_rfq_auto()
        {
            Item.AttributesCache(typeof(ordhed_rfq_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
            }
        }


        public ordhed_rfq_auto()
        {
            StaticInit();
        }

        public override string ClassId
        { get { return "ordhed_rfq"; } }

    }
    public partial class ordhed_rfq
    {
        public static ordhed_rfq New(Context x)
        {  return (ordhed_rfq)x.Item("ordhed_rfq"); }

        public static ordhed_rfq GetById(Context x, String uid)
        { return (ordhed_rfq)x.GetById("ordhed_rfq", uid); }

        public static ordhed_rfq QtO(Context x, String sql)
        { return (ordhed_rfq)x.QtO("ordhed_rfq", sql); }
    }
}
