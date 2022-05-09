using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("focus_item")]
    public partial class focus_item_auto : NewMethod.nObject
    {
        static focus_item_auto()
        {
            Item.AttributesCache(typeof(focus_item_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_n_team_uid":
                    the_n_team_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_n_user_uid":
                    the_n_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "name":
                    nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "user_name":
                    user_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "team_name":
                    team_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "item_type":
                    item_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "extra_info":
                    extra_infoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_done":
                    is_doneAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_viewed":
                    is_viewedAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_n_team_uidAttribute;
        static CoreVarValAttribute the_n_user_uidAttribute;
        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute user_nameAttribute;
        static CoreVarValAttribute team_nameAttribute;
        static CoreVarValAttribute item_typeAttribute;
        static CoreVarValAttribute extra_infoAttribute;
        static CoreVarValAttribute is_doneAttribute;
        static CoreVarValAttribute is_viewedAttribute;

        [CoreVarVal("the_n_team_uid", "String", TheFieldLength = 255, Caption="The N Team Uid", Importance = 1)]
        public VarString the_n_team_uidVar;

        [CoreVarVal("the_n_user_uid", "String", TheFieldLength = 255, Caption="The N User Uid", Importance = 2)]
        public VarString the_n_user_uidVar;

        [CoreVarVal("name", "String", TheFieldLength = 255, Caption="Name", Importance = 3)]
        public VarString nameVar;

        [CoreVarVal("description", "String", TheFieldLength = 255, Caption="Description", Importance = 4)]
        public VarString descriptionVar;

        [CoreVarVal("user_name", "String", TheFieldLength = 255, Caption="User Name", Importance = 5)]
        public VarString user_nameVar;

        [CoreVarVal("team_name", "String", TheFieldLength = 255, Caption="Team Name", Importance = 6)]
        public VarString team_nameVar;

        [CoreVarVal("item_type", "String", TheFieldLength = 255, Caption="Item Type", Importance = 7)]
        public VarString item_typeVar;

        [CoreVarVal("extra_info", "Text", Caption="Extra Info", Importance = 8)]
        public VarText extra_infoVar;

        [CoreVarVal("is_done", "Boolean", Caption="Is Done", Importance = 9)]
        public VarBoolean is_doneVar;

        [CoreVarVal("is_viewed", "Boolean", Caption="Is Viewed", Importance = 10)]
        public VarBoolean is_viewedVar;

        public focus_item_auto()
        {
            StaticInit();
            the_n_team_uidVar = new VarString(this, the_n_team_uidAttribute);
            the_n_user_uidVar = new VarString(this, the_n_user_uidAttribute);
            nameVar = new VarString(this, nameAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            user_nameVar = new VarString(this, user_nameAttribute);
            team_nameVar = new VarString(this, team_nameAttribute);
            item_typeVar = new VarString(this, item_typeAttribute);
            extra_infoVar = new VarText(this, extra_infoAttribute);
            is_doneVar = new VarBoolean(this, is_doneAttribute);
            is_viewedVar = new VarBoolean(this, is_viewedAttribute);
        }

        public override string ClassId
        { get { return "focus_item"; } }

        public String the_n_team_uid
        {
            get  { return (String)the_n_team_uidVar.Value; }
            set  { the_n_team_uidVar.Value = value; }
        }

        public String the_n_user_uid
        {
            get  { return (String)the_n_user_uidVar.Value; }
            set  { the_n_user_uidVar.Value = value; }
        }

        public String name
        {
            get  { return (String)nameVar.Value; }
            set  { nameVar.Value = value; }
        }

        public String description
        {
            get  { return (String)descriptionVar.Value; }
            set  { descriptionVar.Value = value; }
        }

        public String user_name
        {
            get  { return (String)user_nameVar.Value; }
            set  { user_nameVar.Value = value; }
        }

        public String team_name
        {
            get  { return (String)team_nameVar.Value; }
            set  { team_nameVar.Value = value; }
        }

        public String item_type
        {
            get  { return (String)item_typeVar.Value; }
            set  { item_typeVar.Value = value; }
        }

        public String extra_info
        {
            get  { return (String)extra_infoVar.Value; }
            set  { extra_infoVar.Value = value; }
        }

        public Boolean is_done
        {
            get  { return (Boolean)is_doneVar.Value; }
            set  { is_doneVar.Value = value; }
        }

        public Boolean is_viewed
        {
            get  { return (Boolean)is_viewedVar.Value; }
            set  { is_viewedVar.Value = value; }
        }

    }
    public partial class focus_item
    {
        public static focus_item New(Context x)
        {  return (focus_item)x.Item("focus_item"); }

        public static focus_item GetById(Context x, String uid)
        { return (focus_item)x.GetById("focus_item", uid); }

        public static focus_item QtO(Context x, String sql)
        { return (focus_item)x.QtO("focus_item", sql); }

        public static focus_item GetByName(Context x, String name, String extraSql = "")
        { return (focus_item)x.GetByName("focus_item", name, extraSql); }
    }
}
