using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("n_sys_link", Importance = -1)]
    public partial class n_sys_link_auto : NewMethod.nObject
    {
        static n_sys_link_auto()
        {
            Item.AttributesCache(typeof(n_sys_link_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "right_n_sys_uid":
                    right_n_sys_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "left_n_sys_uid":
                    left_n_sys_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "left_n_sys_order":
                    left_n_sys_orderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "right_n_sys_order":
                    right_n_sys_orderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "left_system_name":
                    left_system_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "right_system_name":
                    right_system_nameAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute right_n_sys_uidAttribute;
        static CoreVarValAttribute left_n_sys_uidAttribute;
        static CoreVarValAttribute left_n_sys_orderAttribute;
        static CoreVarValAttribute right_n_sys_orderAttribute;
        static CoreVarValAttribute left_system_nameAttribute;
        static CoreVarValAttribute right_system_nameAttribute;

        [CoreVarVal("right_n_sys_uid", "String", TheFieldLength = 255, Caption="Right N Sys Uid", Importance = -2)]
        public VarString right_n_sys_uidVar;

        [CoreVarVal("left_n_sys_uid", "String", Caption="Left N Sys Uid", Importance = -1)]
        public VarString left_n_sys_uidVar;

        [CoreVarVal("left_n_sys_order", "Int64", Caption="Left N Sys Order", Importance = 1)]
        public VarInt64 left_n_sys_orderVar;

        [CoreVarVal("right_n_sys_order", "Int64", Caption="Right N Sys Order", Importance = 2)]
        public VarInt64 right_n_sys_orderVar;

        [CoreVarVal("left_system_name", "String", TheFieldLength = 255, Caption="Left System Name", Importance = 3)]
        public VarString left_system_nameVar;

        [CoreVarVal("right_system_name", "String", TheFieldLength = 255, Caption="Right System Name", Importance = 4)]
        public VarString right_system_nameVar;

        public n_sys_link_auto()
        {
            StaticInit();
            right_n_sys_uidVar = new VarString(this, right_n_sys_uidAttribute);
            left_n_sys_uidVar = new VarString(this, left_n_sys_uidAttribute);
            left_n_sys_orderVar = new VarInt64(this, left_n_sys_orderAttribute);
            right_n_sys_orderVar = new VarInt64(this, right_n_sys_orderAttribute);
            left_system_nameVar = new VarString(this, left_system_nameAttribute);
            right_system_nameVar = new VarString(this, right_system_nameAttribute);
        }

        public override string ClassId
        { get { return "n_sys_link"; } }

        public String right_n_sys_uid
        {
            get  { return (String)right_n_sys_uidVar.Value; }
            set  { right_n_sys_uidVar.Value = value; }
        }

        public String left_n_sys_uid
        {
            get  { return (String)left_n_sys_uidVar.Value; }
            set  { left_n_sys_uidVar.Value = value; }
        }

        public Int64 left_n_sys_order
        {
            get  { return (Int64)left_n_sys_orderVar.Value; }
            set  { left_n_sys_orderVar.Value = value; }
        }

        public Int64 right_n_sys_order
        {
            get  { return (Int64)right_n_sys_orderVar.Value; }
            set  { right_n_sys_orderVar.Value = value; }
        }

        public String left_system_name
        {
            get  { return (String)left_system_nameVar.Value; }
            set  { left_system_nameVar.Value = value; }
        }

        public String right_system_name
        {
            get  { return (String)right_system_nameVar.Value; }
            set  { right_system_nameVar.Value = value; }
        }

    }
    public partial class n_sys_link
    {
        public static n_sys_link New(Context x)
        {  return (n_sys_link)x.Item("n_sys_link"); }

        public static n_sys_link GetById(Context x, String uid)
        { return (n_sys_link)x.GetById("n_sys_link", uid); }

        public static n_sys_link QtO(Context x, String sql)
        { return (n_sys_link)x.QtO("n_sys_link", sql); }
    }
}
