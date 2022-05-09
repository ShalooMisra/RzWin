using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("n_sys_target", Importance = -1)]
    public partial class n_sys_target_auto : NewMethod.nObject
    {
        static n_sys_target_auto()
        {
            Item.AttributesCache(typeof(n_sys_target_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_n_sys_uid":
                    the_n_sys_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "system_name":
                    system_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "xml_file":
                    xml_fileAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_n_sys_uidAttribute;
        static CoreVarValAttribute system_nameAttribute;
        static CoreVarValAttribute xml_fileAttribute;

        [CoreVarVal("the_n_sys_uid", "String", Caption="The N Sys Uid", Importance = -1)]
        public VarString the_n_sys_uidVar;

        [CoreVarVal("system_name", "String", TheFieldLength = 255, Caption="System Name", Importance = 1)]
        public VarString system_nameVar;

        [CoreVarVal("xml_file", "String", TheFieldLength = 255, Caption="Xml File", Importance = 2)]
        public VarString xml_fileVar;

        public n_sys_target_auto()
        {
            StaticInit();
            the_n_sys_uidVar = new VarString(this, the_n_sys_uidAttribute);
            system_nameVar = new VarString(this, system_nameAttribute);
            xml_fileVar = new VarString(this, xml_fileAttribute);
        }

        public override string ClassId
        { get { return "n_sys_target"; } }

        public String the_n_sys_uid
        {
            get  { return (String)the_n_sys_uidVar.Value; }
            set  { the_n_sys_uidVar.Value = value; }
        }

        public String system_name
        {
            get  { return (String)system_nameVar.Value; }
            set  { system_nameVar.Value = value; }
        }

        public String xml_file
        {
            get  { return (String)xml_fileVar.Value; }
            set  { xml_fileVar.Value = value; }
        }

    }
    public partial class n_sys_target
    {
        public static n_sys_target New(Context x)
        {  return (n_sys_target)x.Item("n_sys_target"); }

        public static n_sys_target GetById(Context x, String uid)
        { return (n_sys_target)x.GetById("n_sys_target", uid); }

        public static n_sys_target QtO(Context x, String sql)
        { return (n_sys_target)x.QtO("n_sys_target", sql); }
    }
}
