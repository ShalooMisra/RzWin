using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("n_log", Importance = -1)]
    public partial class n_log_auto : NewMethod.nObject
    {
        static n_log_auto()
        {
            Item.AttributesCache(typeof(n_log_auto), AttributeCache);
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
                case "user_name":
                    user_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "log_text":
                    log_textAttribute = (CoreVarValAttribute)attr;
                    break;
                case "machine_name":
                    machine_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "object_class":
                    object_classAttribute = (CoreVarValAttribute)attr;
                    break;
                case "object_id":
                    object_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "manually_entered":
                    manually_enteredAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_n_user_uidAttribute;
        static CoreVarValAttribute user_nameAttribute;
        static CoreVarValAttribute log_textAttribute;
        static CoreVarValAttribute machine_nameAttribute;
        static CoreVarValAttribute object_classAttribute;
        static CoreVarValAttribute object_idAttribute;
        static CoreVarValAttribute manually_enteredAttribute;

        [CoreVarVal("the_n_user_uid", "String", Caption="The N User Uid", Importance = -1)]
        public VarString the_n_user_uidVar;

        [CoreVarVal("user_name", "String", TheFieldLength = 255, Caption="User Name", Importance = 2)]
        public VarString user_nameVar;

        [CoreVarVal("log_text", "Text", Caption="Log Text", Importance = 3)]
        public VarText log_textVar;

        [CoreVarVal("machine_name", "String", TheFieldLength = 255, Caption="Machine Name", Importance = 4)]
        public VarString machine_nameVar;

        [CoreVarVal("object_class", "String", TheFieldLength = 255, Caption="Object Class", Importance = 5)]
        public VarString object_classVar;

        [CoreVarVal("object_id", "String", TheFieldLength = 255, Caption="Object Id", Importance = 6)]
        public VarString object_idVar;

        [CoreVarVal("manually_entered", "Boolean", Caption="Manually Entered", Importance = 7)]
        public VarBoolean manually_enteredVar;

        public n_log_auto()
        {
            StaticInit();
            the_n_user_uidVar = new VarString(this, the_n_user_uidAttribute);
            user_nameVar = new VarString(this, user_nameAttribute);
            log_textVar = new VarText(this, log_textAttribute);
            machine_nameVar = new VarString(this, machine_nameAttribute);
            object_classVar = new VarString(this, object_classAttribute);
            object_idVar = new VarString(this, object_idAttribute);
            manually_enteredVar = new VarBoolean(this, manually_enteredAttribute);
        }

        public override string ClassId
        { get { return "n_log"; } }

        public String the_n_user_uid
        {
            get  { return (String)the_n_user_uidVar.Value; }
            set  { the_n_user_uidVar.Value = value; }
        }

        public String user_name
        {
            get  { return (String)user_nameVar.Value; }
            set  { user_nameVar.Value = value; }
        }

        public String log_text
        {
            get  { return (String)log_textVar.Value; }
            set  { log_textVar.Value = value; }
        }

        public String machine_name
        {
            get  { return (String)machine_nameVar.Value; }
            set  { machine_nameVar.Value = value; }
        }

        public String object_class
        {
            get  { return (String)object_classVar.Value; }
            set  { object_classVar.Value = value; }
        }

        public String object_id
        {
            get  { return (String)object_idVar.Value; }
            set  { object_idVar.Value = value; }
        }

        public Boolean manually_entered
        {
            get  { return (Boolean)manually_enteredVar.Value; }
            set  { manually_enteredVar.Value = value; }
        }

    }
    public partial class n_log
    {
        public static n_log New(Context x)
        {  return (n_log)x.Item("n_log"); }

        public static n_log GetById(Context x, String uid)
        { return (n_log)x.GetById("n_log", uid); }

        public static n_log QtO(Context x, String sql)
        { return (n_log)x.QtO("n_log", sql); }
    }
}
