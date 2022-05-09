using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("part_warning")]
    public partial class part_warning_auto : NewMethod.nObject
    {
        static part_warning_auto()
        {
            Item.AttributesCache(typeof(part_warning_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "part_number":
                    part_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "country":
                    countryAttribute = (CoreVarValAttribute)attr;
                    break;
                case "notes":
                    notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "warning_type":
                    warning_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "date_reported":
                    date_reportedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "other_info":
                    other_infoAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute part_numberAttribute;
        static CoreVarValAttribute countryAttribute;
        static CoreVarValAttribute notesAttribute;
        static CoreVarValAttribute warning_typeAttribute;
        static CoreVarValAttribute date_reportedAttribute;
        static CoreVarValAttribute other_infoAttribute;

        [CoreVarVal("part_number", "String", TheFieldLength = 255, Caption="Part Number", Importance = 1)]
        public VarString part_numberVar;

        [CoreVarVal("country", "String", TheFieldLength = 255, Caption="Country", Importance = 2)]
        public VarString countryVar;

        [CoreVarVal("notes", "Text", Caption="Notes", Importance = 3)]
        public VarText notesVar;

        [CoreVarVal("warning_type", "String", TheFieldLength = 255, Caption="Warning Type", Importance = 4)]
        public VarString warning_typeVar;

        [CoreVarVal("date_reported", "DateTime", Caption="Date Reported", Importance = 5)]
        public VarDateTime date_reportedVar;

        [CoreVarVal("other_info", "String", TheFieldLength = 255, Caption="Other Info", Importance = 6)]
        public VarString other_infoVar;

        public part_warning_auto()
        {
            StaticInit();
            part_numberVar = new VarString(this, part_numberAttribute);
            countryVar = new VarString(this, countryAttribute);
            notesVar = new VarText(this, notesAttribute);
            warning_typeVar = new VarString(this, warning_typeAttribute);
            date_reportedVar = new VarDateTime(this, date_reportedAttribute);
            other_infoVar = new VarString(this, other_infoAttribute);
        }

        public override string ClassId
        { get { return "part_warning"; } }

        public String part_number
        {
            get  { return (String)part_numberVar.Value; }
            set  { part_numberVar.Value = value; }
        }

        public String country
        {
            get  { return (String)countryVar.Value; }
            set  { countryVar.Value = value; }
        }

        public String notes
        {
            get  { return (String)notesVar.Value; }
            set  { notesVar.Value = value; }
        }

        public String warning_type
        {
            get  { return (String)warning_typeVar.Value; }
            set  { warning_typeVar.Value = value; }
        }

        public DateTime date_reported
        {
            get  { return (DateTime)date_reportedVar.Value; }
            set  { date_reportedVar.Value = value; }
        }

        public String other_info
        {
            get  { return (String)other_infoVar.Value; }
            set  { other_infoVar.Value = value; }
        }

    }
    public partial class part_warning
    {
        public static part_warning New(Context x)
        {  return (part_warning)x.Item("part_warning"); }

        public static part_warning GetById(Context x, String uid)
        { return (part_warning)x.GetById("part_warning", uid); }

        public static part_warning QtO(Context x, String sql)
        { return (part_warning)x.QtO("part_warning", sql); }
    }
}
