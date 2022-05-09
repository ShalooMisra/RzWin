using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("n_team")]
    public partial class n_team_auto : NewMethod.nObject
    {
        static n_team_auto()
        {
            Item.AttributesCache(typeof(n_team_auto), AttributeCache);
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
                case "name":
                    nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_main":
                    is_mainAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_n_team_uidAttribute;
        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute is_mainAttribute;

        [CoreVarVal("the_n_team_uid", "String", Caption="The N Team Uid")]
        public VarString the_n_team_uidVar;

        [CoreVarVal("name", "String", TheFieldLength = 255, Caption="Name", Importance = 1)]
        public VarString nameVar;

        [CoreVarVal("is_main", "Boolean", Caption="Is Main", Importance = 2)]
        public VarBoolean is_mainVar;

        public n_team_auto()
        {
            StaticInit();
            the_n_team_uidVar = new VarString(this, the_n_team_uidAttribute);
            nameVar = new VarString(this, nameAttribute);
            is_mainVar = new VarBoolean(this, is_mainAttribute);
        }

        public override string ClassId
        { get { return "n_team"; } }

        public String the_n_team_uid
        {
            get  { return (String)the_n_team_uidVar.Value; }
            set  { the_n_team_uidVar.Value = value; }
        }

        public String name
        {
            get  { return (String)nameVar.Value; }
            set  { nameVar.Value = value; }
        }

        public Boolean is_main
        {
            get  { return (Boolean)is_mainVar.Value; }
            set  { is_mainVar.Value = value; }
        }

    }
    public partial class n_team
    {
        public static n_team New(Context x)
        {  return (n_team)x.Item("n_team"); }

        public static n_team GetById(Context x, String uid)
        { return (n_team)x.GetById("n_team", uid); }

        public static n_team QtO(Context x, String sql)
        { return (n_team)x.QtO("n_team", sql); }
        public static n_team GetByName(Context x, String name, String extraSql = "")
        { return (n_team)x.GetByName("n_team", name, extraSql); }
    }
}
