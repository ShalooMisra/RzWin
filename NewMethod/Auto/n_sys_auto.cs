using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("n_sys", Importance = -1)]
    public partial class n_sys_auto : NewMethod.nObject
    {
        static n_sys_auto()
        {
            Item.AttributesCache(typeof(n_sys_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "system_name":
                    system_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "system_index":
                    system_indexAttribute = (CoreVarValAttribute)attr;
                    break;
                case "structure_changed":
                    structure_changedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "parent_update":
                    parent_updateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_loaded":
                    is_loadedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_expanded":
                    is_expandedAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute system_nameAttribute;
        static CoreVarValAttribute system_indexAttribute;
        static CoreVarValAttribute structure_changedAttribute;
        static CoreVarValAttribute parent_updateAttribute;
        static CoreVarValAttribute is_loadedAttribute;
        static CoreVarValAttribute is_expandedAttribute;

        [CoreVarVal("system_name", "String", TheFieldLength = 255, Caption="Name", Importance = 1)]
        public VarString system_nameVar;

        [CoreVarVal("system_index", "Int32", Caption="Index", Importance = 2)]
        public VarInt32 system_indexVar;

        [CoreVarVal("structure_changed", "DateTime", Caption="Structure Changed", Importance = 3)]
        public VarDateTime structure_changedVar;

        [CoreVarVal("parent_update", "DateTime", Caption="Parent Update", Importance = 4)]
        public VarDateTime parent_updateVar;

        [CoreVarVal("is_loaded", "Boolean", Caption="Is Loaded", Importance = 5)]
        public VarBoolean is_loadedVar;

        [CoreVarVal("is_expanded", "Boolean", Caption="Is Expanded", Importance = 6)]
        public VarBoolean is_expandedVar;

        public n_sys_auto()
        {
            StaticInit();
            system_nameVar = new VarString(this, system_nameAttribute);
            system_indexVar = new VarInt32(this, system_indexAttribute);
            structure_changedVar = new VarDateTime(this, structure_changedAttribute);
            parent_updateVar = new VarDateTime(this, parent_updateAttribute);
            is_loadedVar = new VarBoolean(this, is_loadedAttribute);
            is_expandedVar = new VarBoolean(this, is_expandedAttribute);
        }

        public override string ClassId
        { get { return "n_sys"; } }

        public String system_name
        {
            get  { return (String)system_nameVar.Value; }
            set  { system_nameVar.Value = value; }
        }

        public Int32 system_index
        {
            get  { return (Int32)system_indexVar.Value; }
            set  { system_indexVar.Value = value; }
        }

        public DateTime structure_changed
        {
            get  { return (DateTime)structure_changedVar.Value; }
            set  { structure_changedVar.Value = value; }
        }

        public DateTime parent_update
        {
            get  { return (DateTime)parent_updateVar.Value; }
            set  { parent_updateVar.Value = value; }
        }

        public Boolean is_loaded
        {
            get  { return (Boolean)is_loadedVar.Value; }
            set  { is_loadedVar.Value = value; }
        }

        public Boolean is_expanded
        {
            get  { return (Boolean)is_expandedVar.Value; }
            set  { is_expandedVar.Value = value; }
        }

    }
    public partial class n_sys
    {
        public static n_sys New(Context x)
        {  return (n_sys)x.Item("n_sys"); }

        public static n_sys GetById(Context x, String uid)
        { return (n_sys)x.GetById("n_sys", uid); }

        public static n_sys QtO(Context x, String sql)
        { return (n_sys)x.QtO("n_sys", sql); }
    }
}
