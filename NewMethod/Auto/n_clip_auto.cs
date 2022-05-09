using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("n_clip")]
    public partial class n_clip_auto : NewMethod.nObject
    {
        static n_clip_auto()
        {
            Item.AttributesCache(typeof(n_clip_auto), AttributeCache);
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
                case "the_n_clip_uid":
                    the_n_clip_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "name":
                    nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "notes":
                    notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "clip_type":
                    clip_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "link_class":
                    link_classAttribute = (CoreVarValAttribute)attr;
                    break;
                case "link_id":
                    link_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_n_clip_order":
                    the_n_clip_orderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "activity_index":
                    activity_indexAttribute = (CoreVarValAttribute)attr;
                    break;
                case "summary":
                    summaryAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_expanded":
                    is_expandedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_update":
                    last_updateAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_n_user_uidAttribute;
        static CoreVarValAttribute the_n_clip_uidAttribute;
        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute notesAttribute;
        static CoreVarValAttribute clip_typeAttribute;
        static CoreVarValAttribute link_classAttribute;
        static CoreVarValAttribute link_idAttribute;
        static CoreVarValAttribute the_n_clip_orderAttribute;
        static CoreVarValAttribute activity_indexAttribute;
        static CoreVarValAttribute summaryAttribute;
        static CoreVarValAttribute is_expandedAttribute;
        static CoreVarValAttribute last_updateAttribute;

        [CoreVarVal("the_n_user_uid", "String", TheFieldLength = 255, Caption="The N User Uid", Importance = -2)]
        public VarString the_n_user_uidVar;

        [CoreVarVal("the_n_clip_uid", "String", Caption="The N Clip Uid")]
        public VarString the_n_clip_uidVar;

        [CoreVarVal("name", "String", TheFieldLength = 255, Caption="Name", Importance = 1)]
        public VarString nameVar;

        [CoreVarVal("notes", "Text", Caption="Notes", Importance = 2)]
        public VarText notesVar;

        [CoreVarVal("clip_type", "String", TheFieldLength = 255, Caption="Clip Type", Importance = 3)]
        public VarString clip_typeVar;

        [CoreVarVal("link_class", "String", TheFieldLength = 255, Caption="Link Class", Importance = 4)]
        public VarString link_classVar;

        [CoreVarVal("link_id", "String", TheFieldLength = 255, Caption="Link ID", Importance = 5)]
        public VarString link_idVar;

        [CoreVarVal("the_n_clip_order", "Int64", Caption="The N Clip Order", Importance = 6)]
        public VarInt64 the_n_clip_orderVar;

        [CoreVarVal("activity_index", "Int64", Caption="Activity Index", Importance = 7)]
        public VarInt64 activity_indexVar;

        [CoreVarVal("summary", "Text", Caption="Summary", Importance = 8)]
        public VarText summaryVar;

        [CoreVarVal("is_expanded", "Boolean", Caption="Is Expanded", Importance = 9)]
        public VarBoolean is_expandedVar;

        [CoreVarVal("last_update", "DateTime", Caption="Last Update", Importance = 10)]
        public VarDateTime last_updateVar;

        public n_clip_auto()
        {
            StaticInit();
            the_n_user_uidVar = new VarString(this, the_n_user_uidAttribute);
            the_n_clip_uidVar = new VarString(this, the_n_clip_uidAttribute);
            nameVar = new VarString(this, nameAttribute);
            notesVar = new VarText(this, notesAttribute);
            clip_typeVar = new VarString(this, clip_typeAttribute);
            link_classVar = new VarString(this, link_classAttribute);
            link_idVar = new VarString(this, link_idAttribute);
            the_n_clip_orderVar = new VarInt64(this, the_n_clip_orderAttribute);
            activity_indexVar = new VarInt64(this, activity_indexAttribute);
            summaryVar = new VarText(this, summaryAttribute);
            is_expandedVar = new VarBoolean(this, is_expandedAttribute);
            last_updateVar = new VarDateTime(this, last_updateAttribute);
        }

        public override string ClassId
        { get { return "n_clip"; } }

        public String the_n_user_uid
        {
            get  { return (String)the_n_user_uidVar.Value; }
            set  { the_n_user_uidVar.Value = value; }
        }

        public String the_n_clip_uid
        {
            get  { return (String)the_n_clip_uidVar.Value; }
            set  { the_n_clip_uidVar.Value = value; }
        }

        public String name
        {
            get  { return (String)nameVar.Value; }
            set  { nameVar.Value = value; }
        }

        public String notes
        {
            get  { return (String)notesVar.Value; }
            set  { notesVar.Value = value; }
        }

        public String clip_type
        {
            get  { return (String)clip_typeVar.Value; }
            set  { clip_typeVar.Value = value; }
        }

        public String link_class
        {
            get  { return (String)link_classVar.Value; }
            set  { link_classVar.Value = value; }
        }

        public String link_id
        {
            get  { return (String)link_idVar.Value; }
            set  { link_idVar.Value = value; }
        }

        public Int64 the_n_clip_order
        {
            get  { return (Int64)the_n_clip_orderVar.Value; }
            set  { the_n_clip_orderVar.Value = value; }
        }

        public Int64 activity_index
        {
            get  { return (Int64)activity_indexVar.Value; }
            set  { activity_indexVar.Value = value; }
        }

        public String summary
        {
            get  { return (String)summaryVar.Value; }
            set  { summaryVar.Value = value; }
        }

        public Boolean is_expanded
        {
            get  { return (Boolean)is_expandedVar.Value; }
            set  { is_expandedVar.Value = value; }
        }

        public DateTime last_update
        {
            get  { return (DateTime)last_updateVar.Value; }
            set  { last_updateVar.Value = value; }
        }

    }
    public partial class n_clip
    {
        public static n_clip New(Context x)
        {  return (n_clip)x.Item("n_clip"); }

        public static n_clip GetById(Context x, String uid)
        { return (n_clip)x.GetById("n_clip", uid); }

        public static n_clip QtO(Context x, String sql)
        { return (n_clip)x.QtO("n_clip", sql); }

        public static n_clip GetByName(Context x, String name, String extraSql = "")
        { return (n_clip)x.GetByName("n_clip", name, extraSql); }
    }
}
