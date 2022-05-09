using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("n_instance_target", Importance = -1)]
    public partial class n_instance_target_auto : NewMethod.nObject
    {
        static n_instance_target_auto()
        {
            Item.AttributesCache(typeof(n_instance_target_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_n_data_target_uid":
                    the_n_data_target_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_n_sys_uid":
                    the_n_sys_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "name":
                    nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hold_temp_string":
                    hold_temp_stringAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_n_data_target_uidAttribute;
        static CoreVarValAttribute the_n_sys_uidAttribute;
        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute hold_temp_stringAttribute;

        [CoreVarVal("the_n_data_target_uid", "String", TheFieldLength = 255, Caption="The N Data Target Uid", Importance = -2)]
        public VarString the_n_data_target_uidVar;

        [CoreVarVal("the_n_sys_uid", "String", Caption="The N Sys Uid", Importance = -1)]
        public VarString the_n_sys_uidVar;

        [CoreVarVal("name", "String", TheFieldLength = 255, Caption="Name", Importance = 1)]
        public VarString nameVar;

        [CoreVarVal("hold_temp_string", "String", TheFieldLength = 255, Caption="Hold Temp String", Importance = 2)]
        public VarString hold_temp_stringVar;

        public n_instance_target_auto()
        {
            StaticInit();
            the_n_data_target_uidVar = new VarString(this, the_n_data_target_uidAttribute);
            the_n_sys_uidVar = new VarString(this, the_n_sys_uidAttribute);
            nameVar = new VarString(this, nameAttribute);
            hold_temp_stringVar = new VarString(this, hold_temp_stringAttribute);
        }

        public override string ClassId
        { get { return "n_instance_target"; } }

        public String the_n_data_target_uid
        {
            get  { return (String)the_n_data_target_uidVar.Value; }
            set  { the_n_data_target_uidVar.Value = value; }
        }

        public String the_n_sys_uid
        {
            get  { return (String)the_n_sys_uidVar.Value; }
            set  { the_n_sys_uidVar.Value = value; }
        }

        public String name
        {
            get  { return (String)nameVar.Value; }
            set  { nameVar.Value = value; }
        }

        public String hold_temp_string
        {
            get  { return (String)hold_temp_stringVar.Value; }
            set  { hold_temp_stringVar.Value = value; }
        }

    }
    public partial class n_instance_target
    {
        public static n_instance_target New(Context x)
        {  return (n_instance_target)x.Item("n_instance_target"); }

        public static n_instance_target GetById(Context x, String uid)
        { return (n_instance_target)x.GetById("n_instance_target", uid); }

        public static n_instance_target QtO(Context x, String sql)
        { return (n_instance_target)x.QtO("n_instance_target", sql); }

        public static n_instance_target GetByName(Context x, String name, String extraSql = "")
        { return (n_instance_target)x.GetByName("n_instance_target", name, extraSql); }
    }
}
