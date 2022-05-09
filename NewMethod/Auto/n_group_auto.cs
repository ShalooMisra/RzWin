using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("n_group")]
    public partial class n_group_auto : NewMethod.nObject
    {
        static n_group_auto()
        {
            Item.AttributesCache(typeof(n_group_auto), AttributeCache);
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
                case "the_n_class_uid":
                    the_n_class_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "name":
                    nameAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_n_team_uidAttribute;
        static CoreVarValAttribute the_n_user_uidAttribute;
        static CoreVarValAttribute the_n_class_uidAttribute;
        static CoreVarValAttribute nameAttribute;

        [CoreVarVal("the_n_team_uid", "String", TheFieldLength = 255, Caption="The N Team Uid", Importance = -3)]
        public VarString the_n_team_uidVar;

        [CoreVarVal("the_n_user_uid", "String", TheFieldLength = 255, Caption="The N User Uid", Importance = -2)]
        public VarString the_n_user_uidVar;

        [CoreVarVal("the_n_class_uid", "String", Caption="The N Class Uid")]
        public VarString the_n_class_uidVar;

        [CoreVarVal("name", "String", TheFieldLength = 255, Caption="Name", Importance = 1)]
        public VarString nameVar;

        public n_group_auto()
        {
            StaticInit();
            the_n_team_uidVar = new VarString(this, the_n_team_uidAttribute);
            the_n_user_uidVar = new VarString(this, the_n_user_uidAttribute);
            the_n_class_uidVar = new VarString(this, the_n_class_uidAttribute);
            nameVar = new VarString(this, nameAttribute);
        }

        public override string ClassId
        { get { return "n_group"; } }

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

        public String the_n_class_uid
        {
            get  { return (String)the_n_class_uidVar.Value; }
            set  { the_n_class_uidVar.Value = value; }
        }

        public String name
        {
            get  { return (String)nameVar.Value; }
            set  { nameVar.Value = value; }
        }

    }
    public partial class n_group
    {
        public static n_group New(Context x)
        {  return (n_group)x.Item("n_group"); }

        public static n_group GetById(Context x, String uid)
        { return (n_group)x.GetById("n_group", uid); }

        public static n_group QtO(Context x, String sql)
        { return (n_group)x.QtO("n_group", sql); }

        public static n_group GetByName(Context x, String name, String extraSql = "")
        { return (n_group)x.GetByName("n_group", name, extraSql); }
    }
}
