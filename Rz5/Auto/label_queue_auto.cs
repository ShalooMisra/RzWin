using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("label_queue")]
    public partial class label_queue_auto : NewMethod.nObject
    {
        static label_queue_auto()
        {
            Item.AttributesCache(typeof(label_queue_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "object_class":
                    object_classAttribute = (CoreVarValAttribute)attr;
                    break;
                case "object_id":
                    object_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "label_template":
                    label_templateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "extra_data":
                    extra_dataAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fixed_address":
                    fixed_addressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "split_address":
                    split_addressAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute object_classAttribute;
        static CoreVarValAttribute object_idAttribute;
        static CoreVarValAttribute label_templateAttribute;
        static CoreVarValAttribute extra_dataAttribute;
        static CoreVarValAttribute fixed_addressAttribute;
        static CoreVarValAttribute split_addressAttribute;

        [CoreVarVal("object_class", "String", TheFieldLength = 255, Caption="Object Class", Importance = 1)]
        public VarString object_classVar;

        [CoreVarVal("object_id", "String", TheFieldLength = 255, Caption="Object Id", Importance = 2)]
        public VarString object_idVar;

        [CoreVarVal("label_template", "String", TheFieldLength = 255, Caption="Label Template", Importance = 3)]
        public VarString label_templateVar;

        [CoreVarVal("extra_data", "String", TheFieldLength = 255, Caption="Extra Data", Importance = 4)]
        public VarString extra_dataVar;

        [CoreVarVal("fixed_address", "Text", Caption="Fixed Address", Importance = 5)]
        public VarText fixed_addressVar;

        [CoreVarVal("split_address", "Text", Caption="Split Address", Importance = 6)]
        public VarText split_addressVar;

        public label_queue_auto()
        {
            StaticInit();
            object_classVar = new VarString(this, object_classAttribute);
            object_idVar = new VarString(this, object_idAttribute);
            label_templateVar = new VarString(this, label_templateAttribute);
            extra_dataVar = new VarString(this, extra_dataAttribute);
            fixed_addressVar = new VarText(this, fixed_addressAttribute);
            split_addressVar = new VarText(this, split_addressAttribute);
        }

        public override string ClassId
        { get { return "label_queue"; } }

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

        public String label_template
        {
            get  { return (String)label_templateVar.Value; }
            set  { label_templateVar.Value = value; }
        }

        public String extra_data
        {
            get  { return (String)extra_dataVar.Value; }
            set  { extra_dataVar.Value = value; }
        }

        public String fixed_address
        {
            get  { return (String)fixed_addressVar.Value; }
            set  { fixed_addressVar.Value = value; }
        }

        public String split_address
        {
            get  { return (String)split_addressVar.Value; }
            set  { split_addressVar.Value = value; }
        }

    }
    public partial class label_queue
    {
        public static label_queue New(Context x)
        {  return (label_queue)x.Item("label_queue"); }

        public static label_queue GetById(Context x, String uid)
        { return (label_queue)x.GetById("label_queue", uid); }

        public static label_queue QtO(Context x, String sql)
        { return (label_queue)x.QtO("label_queue", sql); }
    }
}
