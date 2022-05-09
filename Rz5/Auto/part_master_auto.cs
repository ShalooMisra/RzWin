using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("part_master")]
    public partial class part_master_auto : NewMethod.nObject
    {
        static part_master_auto()
        {
            Item.AttributesCache(typeof(part_master_auto), AttributeCache);
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
                case "part_number_stripped":
                    part_number_strippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "manufacturer":
                    manufacturerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "category":
                    categoryAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatepart":
                    alternatepartAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute part_numberAttribute;
        static CoreVarValAttribute part_number_strippedAttribute;
        static CoreVarValAttribute manufacturerAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute categoryAttribute;
        static CoreVarValAttribute alternatepartAttribute;

        [CoreVarVal("part_number", "String", TheFieldLength = 255, Caption = "Part Number", Importance = 1)]
        public VarString part_numberVar;

        [CoreVarVal("part_number_stripped", "String", TheFieldLength = 255, Caption = "Stripped Number", Importance = 2)]
        public VarString part_number_strippedVar;

        [CoreVarVal("manufacturer", "String", TheFieldLength = 255, Caption = "Manufacturer", Importance = 5)]
        public VarString manufacturerVar;

        [CoreVarVal("description", "String", TheFieldLength = 8000, Caption = "Description", Importance = 6)]
        public VarString descriptionVar;

        [CoreVarVal("category", "String", TheFieldLength = 8000, Caption = "Category", Importance = 7)]
        public VarString categoryVar;

        [CoreVarVal("alternatepart", "String", TheFieldLength = 8000, Caption = "Alternate Part", Importance = 8)]
        public VarString alternatepartVar;

        public part_master_auto()
        {
            StaticInit();
            part_numberVar = new VarString(this, part_numberAttribute);
            part_number_strippedVar = new VarString(this, part_number_strippedAttribute);
            manufacturerVar = new VarString(this, manufacturerAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            categoryVar = new VarString(this, categoryAttribute);
            alternatepartVar = new VarString(this, alternatepartAttribute);
        }

        public override string ClassId
        { get { return "part_master"; } }

        public String part_number
        {
            get { return (String)part_numberVar.Value; }
            set { part_numberVar.Value = value; }
        }

        public String part_number_stripped
        {
            get { return (String)part_number_strippedVar.Value; }
            set { part_number_strippedVar.Value = value; }
        }

        public String manufacturer
        {
            get { return (String)manufacturerVar.Value; }
            set { manufacturerVar.Value = value; }
        }

        public String description
        {
            get { return (String)descriptionVar.Value; }
            set { descriptionVar.Value = value; }
        }

        public String category
        {
            get { return (String)categoryVar.Value; }
            set { categoryVar.Value = value; }
        }

        public String alternatepart
        {
            get { return (String)alternatepartVar.Value; }
            set { alternatepartVar.Value = value; }
        }
    }
    public partial class part_master
    {
        public static part_master New(Context x)
        { return (part_master)x.Item("part_master"); }

        public static part_master GetById(Context x, String uid)
        { return (part_master)x.GetById("part_master", uid); }

        public static part_master QtO(Context x, String sql)
        { return (part_master)x.QtO("part_master", sql); }
    }
}
