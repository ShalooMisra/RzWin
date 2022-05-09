using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("system_management")]
    public partial class system_management_auto : NewMethod.nObject
    {
        static system_management_auto()
        {
            Item.AttributesCache(typeof(system_management_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "system_id":
                    system_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "system_name":
                    system_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_enabled":
                    is_enabledAttribute = (CoreVarValAttribute)attr;
                    break;
                

            }
        }


        static CoreVarValAttribute system_idAttribute;
        static CoreVarValAttribute system_nameAttribute;
        static CoreVarValAttribute is_enabledAttribute;
        

       


        [CoreVarVal("system_id", "String", TheFieldLength = 50, Caption = "system_id", Importance = 1)]
        public VarString system_idVar;
        [CoreVarVal("system_name", "String", TheFieldLength = 50, Caption = "system_name", Importance = 2)]
        public VarString system_nameVar;
        [CoreVarVal("is_enabled", "Boolean", TheFieldLength = 50, Caption = "is_enabled", Importance = 3)]
        public VarBoolean is_enabledVar;

        public system_management_auto()
        {
            StaticInit();
            system_idVar = new VarString(this, system_idAttribute);
            system_nameVar = new VarString(this, system_nameAttribute);
            is_enabledVar = new VarBoolean(this, is_enabledAttribute);

        }    


        public override string ClassId
        { get { return "system_management"; } }

        public String system_id
        {
            get { return (String)system_idVar.Value; }
            set { system_idVar.Value = value; }
        }
        public String system_name
        {
            get { return (String)system_nameVar.Value; }
            set { system_nameVar.Value = value; }
        }

        public bool is_enabled
        {
            get { return (bool)is_enabledVar.Value; }
            set { is_enabledVar.Value = value; }
        }

      
        

    }
    public partial class system_management
    {
        public static system_management New(Context x)
        { return (system_management)x.Item(""); }

        public static system_management GetById(Context x, String uid)
        { return (system_management)x.GetById("system_management", uid); }

        public static system_management QtO(Context x, String sql)
        { return (system_management)x.QtO("system_management", sql); }
    }
}
