using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("n_user_screens")]
    public partial class n_user_screens_auto : NewMethod.nObject
    {
        static n_user_screens_auto()
        {
            Item.AttributesCache(typeof(n_user_screens_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_n_user_uid":
                    the_n_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "load_order":
                    load_orderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "screen_id":
                    screen_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_locked":
                    is_lockedAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_n_user_uidAttribute;
        static CoreVarValAttribute load_orderAttribute;
        static CoreVarValAttribute screen_idAttribute;
        static CoreVarValAttribute is_lockedAttribute;

        [CoreVarVal("the_n_user_uid", "String", TheFieldLength = 255, Caption="The N User Uid", Importance = 1)]
        public VarString the_n_user_uidVar;

        [CoreVarVal("load_order", "Int64", Caption="Load Order", Importance = 2)]
        public VarInt64 load_orderVar;

        [CoreVarVal("screen_id", "String", TheFieldLength = 255, Caption="Screen Id", Importance = 3)]
        public VarString screen_idVar;

        [CoreVarVal("is_locked", "Boolean", Caption="Is Locked", Importance = 4)]
        public VarBoolean is_lockedVar;

        public n_user_screens_auto()
        {
            StaticInit();
            the_n_user_uidVar = new VarString(this, the_n_user_uidAttribute);
            load_orderVar = new VarInt64(this, load_orderAttribute);
            screen_idVar = new VarString(this, screen_idAttribute);
            is_lockedVar = new VarBoolean(this, is_lockedAttribute);
        }

        public override string ClassId
        { get { return "n_user_screens"; } }

        public String the_n_user_uid
        {
            get  { return (String)the_n_user_uidVar.Value; }
            set  { the_n_user_uidVar.Value = value; }
        }

        public Int64 load_order
        {
            get  { return (Int64)load_orderVar.Value; }
            set  { load_orderVar.Value = value; }
        }

        public String screen_id
        {
            get  { return (String)screen_idVar.Value; }
            set  { screen_idVar.Value = value; }
        }

        public Boolean is_locked
        {
            get  { return (Boolean)is_lockedVar.Value; }
            set  { is_lockedVar.Value = value; }
        }

    }
    public partial class n_user_screens
    {
        public static n_user_screens New(Context x)
        {  return (n_user_screens)x.Item("n_user_screens"); }

        public static n_user_screens GetById(Context x, String uid)
        { return (n_user_screens)x.GetById("n_user_screens", uid); }

        public static n_user_screens QtO(Context x, String sql)
        { return (n_user_screens)x.QtO("n_user_screens", sql); }
    }
}
