using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("n_data_target")]
    public partial class n_data_target_auto : NewMethod.nObject
    {
        static n_data_target_auto()
        {
            Item.AttributesCache(typeof(n_data_target_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "target_type":
                    target_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "name":
                    nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "server_name":
                    server_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "user_name":
                    user_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "user_password":
                    user_passwordAttribute = (CoreVarValAttribute)attr;
                    break;
                case "database_name":
                    database_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "command_string":
                    command_stringAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute target_typeAttribute;
        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute server_nameAttribute;
        static CoreVarValAttribute user_nameAttribute;
        static CoreVarValAttribute user_passwordAttribute;
        static CoreVarValAttribute database_nameAttribute;
        static CoreVarValAttribute command_stringAttribute;

        [CoreVarVal("target_type", "Int32", Caption="Target Type", Importance = 1)]
        public VarInt32 target_typeVar;

        [CoreVarVal("name", "String", TheFieldLength = 255, Caption="Name", Importance = 2)]
        public VarString nameVar;

        [CoreVarVal("server_name", "String", TheFieldLength = 255, Caption="Server Name", Importance = 3)]
        public VarString server_nameVar;

        [CoreVarVal("user_name", "String", TheFieldLength = 255, Caption="User Name", Importance = 4)]
        public VarString user_nameVar;

        [CoreVarVal("user_password", "String", TheFieldLength = 255, Caption="User Password", Importance = 5)]
        public VarString user_passwordVar;

        [CoreVarVal("database_name", "String", TheFieldLength = 255, Caption="Database Name", Importance = 6)]
        public VarString database_nameVar;

        [CoreVarVal("command_string", "Text", Caption="Command String", Importance = 7)]
        public VarText command_stringVar;

        public n_data_target_auto()
        {
            StaticInit();
            target_typeVar = new VarInt32(this, target_typeAttribute);
            nameVar = new VarString(this, nameAttribute);
            server_nameVar = new VarString(this, server_nameAttribute);
            user_nameVar = new VarString(this, user_nameAttribute);
            user_passwordVar = new VarString(this, user_passwordAttribute);
            database_nameVar = new VarString(this, database_nameAttribute);
            command_stringVar = new VarText(this, command_stringAttribute);
        }

        public override string ClassId
        { get { return "n_data_target"; } }

        public Int32 target_type
        {
            get  { return (Int32)target_typeVar.Value; }
            set  { target_typeVar.Value = value; }
        }

        public String name
        {
            get  { return (String)nameVar.Value; }
            set  { nameVar.Value = value; }
        }

        public String server_name
        {
            get  { return (String)server_nameVar.Value; }
            set  { server_nameVar.Value = value; }
        }

        public String user_name
        {
            get  { return (String)user_nameVar.Value; }
            set  { user_nameVar.Value = value; }
        }

        public String user_password
        {
            get  { return (String)user_passwordVar.Value; }
            set  { user_passwordVar.Value = value; }
        }

        public String database_name
        {
            get  { return (String)database_nameVar.Value; }
            set  { database_nameVar.Value = value; }
        }

        public String command_string
        {
            get  { return (String)command_stringVar.Value; }
            set  { command_stringVar.Value = value; }
        }

    }
    public partial class n_data_target
    {
        public static n_data_target New(Context x)
        {  return (n_data_target)x.Item("n_data_target"); }

        public static n_data_target GetById(Context x, String uid)
        { return (n_data_target)x.GetById("n_data_target", uid); }

        public static n_data_target QtO(Context x, String sql)
        { return (n_data_target)x.QtO("n_data_target", sql); }

        public static n_data_target GetByName(Context x, String name, String extraSql = "")
        { return (n_data_target)x.GetByName("n_data_target", name, extraSql); }
    }
}
