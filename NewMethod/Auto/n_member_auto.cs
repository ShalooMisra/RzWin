using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("n_member")]
    public partial class n_member_auto : NewMethod.nObject
    {
        static n_member_auto()
        {
            Item.AttributesCache(typeof(n_member_auto), AttributeCache);
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
                case "the_n_team_uid":
                    the_n_team_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_captain":
                    is_captainAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_n_user_uidAttribute;
        static CoreVarValAttribute the_n_team_uidAttribute;
        static CoreVarValAttribute is_captainAttribute;

        [CoreVarVal("the_n_user_uid", "String", TheFieldLength = 255, Caption="The N User Uid", Importance = -2)]
        public VarString the_n_user_uidVar;

        [CoreVarVal("the_n_team_uid", "String", Caption="The N Team Uid")]
        public VarString the_n_team_uidVar;

        [CoreVarVal("is_captain", "Boolean", Caption="Is Captain", Importance = 1)]
        public VarBoolean is_captainVar;

        public n_member_auto()
        {
            StaticInit();
            the_n_user_uidVar = new VarString(this, the_n_user_uidAttribute);
            the_n_team_uidVar = new VarString(this, the_n_team_uidAttribute);
            is_captainVar = new VarBoolean(this, is_captainAttribute);
        }

        public override string ClassId
        { get { return "n_member"; } }

        public String the_n_user_uid
        {
            get  { return (String)the_n_user_uidVar.Value; }
            set  { the_n_user_uidVar.Value = value; }
        }

        public String the_n_team_uid
        {
            get  { return (String)the_n_team_uidVar.Value; }
            set  { the_n_team_uidVar.Value = value; }
        }

        public Boolean is_captain
        {
            get  { return (Boolean)is_captainVar.Value; }
            set  { is_captainVar.Value = value; }
        }

    }
    public partial class n_member
    {
        public static n_member New(Context x)
        {  return (n_member)x.Item("n_member"); }

        public static n_member GetById(Context x, String uid)
        { return (n_member)x.GetById("n_member", uid); }

        public static n_member QtO(Context x, String sql)
        { return (n_member)x.QtO("n_member", sql); }
    }
}
