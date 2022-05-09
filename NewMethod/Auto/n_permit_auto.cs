using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("n_permit")]
    public partial class n_permit_auto : NewMethod.nObject
    {
        static n_permit_auto()
        {
            Item.AttributesCache(typeof(n_permit_auto), AttributeCache);
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
                case "name":
                    nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_positive":
                    is_positiveAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hold_temp_string":
                    hold_temp_stringAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_n_user_uidAttribute;
        static CoreVarValAttribute the_n_team_uidAttribute;
        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute is_positiveAttribute;
        static CoreVarValAttribute hold_temp_stringAttribute;

        [CoreVarVal("the_n_user_uid", "String", TheFieldLength = 255, Caption="The N User Uid", Importance = -2)]
        public VarString the_n_user_uidVar;

        [CoreVarVal("the_n_team_uid", "String", Caption="The N Team Uid")]
        public VarString the_n_team_uidVar;

        [CoreVarVal("name", "String", TheFieldLength = 255, Caption="Name", Importance = 1)]
        public VarString nameVar;

        [CoreVarVal("is_positive", "Boolean", Caption="Is Positive", Importance = 2)]
        public VarBoolean is_positiveVar;

        [CoreVarVal("hold_temp_string", "String", TheFieldLength = 255, Caption="Hold Temp String", Importance = 3)]
        public VarString hold_temp_stringVar;

        public n_permit_auto()
        {
            StaticInit();
            the_n_user_uidVar = new VarString(this, the_n_user_uidAttribute);
            the_n_team_uidVar = new VarString(this, the_n_team_uidAttribute);
            nameVar = new VarString(this, nameAttribute);
            is_positiveVar = new VarBoolean(this, is_positiveAttribute);
            hold_temp_stringVar = new VarString(this, hold_temp_stringAttribute);
        }

        public override string ClassId
        { get { return "n_permit"; } }

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

        public String name
        {
            get  { return (String)nameVar.Value; }
            set  { nameVar.Value = value; }
        }

        public Boolean is_positive
        {
            get  { return (Boolean)is_positiveVar.Value; }
            set  { is_positiveVar.Value = value; }
        }

        public String hold_temp_string
        {
            get  { return (String)hold_temp_stringVar.Value; }
            set  { hold_temp_stringVar.Value = value; }
        }

    }
    public partial class n_permit
    {
        public static n_permit New(Context x)
        {  return (n_permit)x.Item("n_permit"); }

        public static n_permit GetById(Context x, String uid)
        { return (n_permit)x.GetById("n_permit", uid); }

        public static n_permit QtO(Context x, String sql)
        { return (n_permit)x.QtO("n_permit", sql); }

        public static n_permit GetByName(Context x, String name, String extraSql = "")
        { return (n_permit)x.GetByName("n_permit", name, extraSql); }
    }
}
