using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("ordhed_old", Abstract = true)]
    public partial class ordhed_old_auto : Rz5.ordhed
    {
        static ordhed_old_auto()
        {
            Item.AttributesCache(typeof(ordhed_old_auto), AttributeCache);
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


        public ordhed_old_auto()
        {
            StaticInit();
        }

        public override string ClassId
        { get { return "ordhed_old"; } }

    }
    public partial class ordhed_old
    {
        public static ordhed_old New(Context x)
        {  return (ordhed_old)x.Item("ordhed_old"); }

        public static ordhed_old GetById(Context x, String uid)
        { return (ordhed_old)x.GetById("ordhed_old", uid); }

        public static ordhed_old QtO(Context x, String sql)
        { return (ordhed_old)x.QtO("ordhed_old", sql); }
    }
}
