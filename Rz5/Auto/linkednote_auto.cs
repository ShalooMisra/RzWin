using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("linkednote")]
    public partial class linkednote_auto : NewMethod.nObject
    {
        static linkednote_auto()
        {
            Item.AttributesCache(typeof(linkednote_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "objectname":
                    objectnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "object_uid":
                    object_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "linked_note":
                    linked_noteAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute objectnameAttribute;
        static CoreVarValAttribute object_uidAttribute;
        static CoreVarValAttribute linked_noteAttribute;

        [CoreVarVal("objectname", "String", TheFieldLength = 255, Caption="Object Name", Importance = 1)]
        public VarString objectnameVar;

        [CoreVarVal("object_uid", "String", TheFieldLength = 255, Caption="Object Uniqueid", Importance = 2)]
        public VarString object_uidVar;

        [CoreVarVal("linked_note", "Text", Caption="Linked Note", Importance = 3)]
        public VarText linked_noteVar;

        public linkednote_auto()
        {
            StaticInit();
            objectnameVar = new VarString(this, objectnameAttribute);
            object_uidVar = new VarString(this, object_uidAttribute);
            linked_noteVar = new VarText(this, linked_noteAttribute);
        }

        public override string ClassId
        { get { return "linkednote"; } }

        public String objectname
        {
            get  { return (String)objectnameVar.Value; }
            set  { objectnameVar.Value = value; }
        }

        public String object_uid
        {
            get  { return (String)object_uidVar.Value; }
            set  { object_uidVar.Value = value; }
        }

        public String linked_note
        {
            get  { return (String)linked_noteVar.Value; }
            set  { linked_noteVar.Value = value; }
        }

    }
    public partial class linkednote
    {
        public static linkednote New(Context x)
        {  return (linkednote)x.Item("linkednote"); }

        public static linkednote GetById(Context x, String uid)
        { return (linkednote)x.GetById("linkednote", uid); }

        public static linkednote QtO(Context x, String sql)
        { return (linkednote)x.QtO("linkednote", sql); }
    }
}
