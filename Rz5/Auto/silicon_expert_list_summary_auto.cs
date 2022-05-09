using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("silicon_expert_list_summary")]
    public partial class silicon_expert_list_summary_auto : NewMethod.nObject
    {
        static silicon_expert_list_summary_auto()
        {
            Item.AttributesCache(typeof(silicon_expert_list_summary_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }
        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {

                case "ComID":
                    ComIDAttribute = (CoreVarValAttribute)attr;
                    break;
                case "PartNumber":
                    PartNumberAttribute = (CoreVarValAttribute)attr;
                    break;

                case "Manufacturer":
                    ManufacturerAttribute = (CoreVarValAttribute)attr;
                    break;

                case "PlName":
                    PlNameAttribute = (CoreVarValAttribute)attr;
                    break;

                case "Description":
                    DescriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "Datasheet":
                    DatasheetAttribute = (CoreVarValAttribute)attr;
                    break;
                case "Lifecycle":
                    LifecycleAttribute = (CoreVarValAttribute)attr;
                    break;

                case "RoHS":
                    RoHSAttribute = (CoreVarValAttribute)attr;
                    break;
                case "RoHSVersion":
                    RoHSVersionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "MatchRating":
                    MatchRatingtAttribute = (CoreVarValAttribute)attr;
                    break;
                case "TaxonomyPath":
                    TaxonomyPathAttribute = (CoreVarValAttribute)attr;
                    break;
              
            }
        }

        static CoreVarValAttribute ComIDAttribute;
        static CoreVarValAttribute PartNumberAttribute;
        static CoreVarValAttribute ManufacturerAttribute;
        static CoreVarValAttribute PlNameAttribute;
        static CoreVarValAttribute DescriptionAttribute;
        static CoreVarValAttribute DatasheetAttribute;
        static CoreVarValAttribute LifecycleAttribute;
        static CoreVarValAttribute RoHSAttribute;
        static CoreVarValAttribute RoHSVersionAttribute;
        static CoreVarValAttribute MatchRatingtAttribute;
        static CoreVarValAttribute TaxonomyPathAttribute;



        [CoreVarVal("ComID", "Int64", TheFieldLength = 255, Caption = "ComID", Importance = 1)]
        public VarInt64 ComIDVar;

        [CoreVarVal("PartNumber", "String", TheFieldLength = 255, Caption = "PartNumber", Importance = 2)]
        public VarString PartNumberVar;

        [CoreVarVal("Manufacturer", "String", TheFieldLength = 255, Caption = "Manufacturer", Importance = 3)]
        public VarString ManufacturerVar;

        [CoreVarVal("PlName", "String", TheFieldLength = 255, Caption = "PlName", Importance = 4)]
        public VarString PlNameVar;

        [CoreVarVal("Description", "Text", Caption = "Description", Importance = 5)]
        public VarText DescriptionVar;

        [CoreVarVal("Datasheet", "String", TheFieldLength = 255, Caption = "Datasheet", Importance = 6)]
        public VarString DatasheetVar;

        [CoreVarVal("Lifecycle", "String", TheFieldLength = 255, Caption = "Lifecycle", Importance = 7)]
        public VarString LifecycleVar;

        [CoreVarVal("RoHS", "String", TheFieldLength = 255, Caption = "RoHS", Importance = 8)]
        public VarString RoHSVar;

        [CoreVarVal("RoHSVersion", "String", TheFieldLength = 255, Caption = "RoHSVersion", Importance = 9)]
        public VarString RoHSVersionVar;

        [CoreVarVal("MatchRating", "String", TheFieldLength = 4096, Caption = "MatchRating", Importance = 10)]
        public VarString MatchRatingVar;

        [CoreVarVal("TaxonomyPath", "Text", TheFieldLength = 255, Caption = "TaxonomyPath", Importance = 11)]
        public VarText TaxonomyPathVar;

        


        public silicon_expert_list_summary_auto()
        {
            StaticInit();           

            ComIDVar = new VarInt64(this, ComIDAttribute);
            PartNumberVar = new VarString(this, PartNumberAttribute);
            ManufacturerVar = new VarString(this, ManufacturerAttribute);
            PlNameVar = new VarString(this, PlNameAttribute);
            DescriptionVar = new VarText(this, DescriptionAttribute);
            DatasheetVar = new VarString(this, DatasheetAttribute);
            LifecycleVar = new VarString(this, LifecycleAttribute);
            RoHSVar = new VarString(this, RoHSAttribute);
            RoHSVersionVar = new VarString(this, RoHSVersionAttribute);
            MatchRatingVar = new VarString(this, MatchRatingtAttribute);
            TaxonomyPathVar = new VarText(this, TaxonomyPathAttribute);


        }


        public override string ClassId
        { get { return "silicon_expert_list_summary"; } }

        public Int64 ComID
        {
            get { return (Int64)ComIDVar.Value; }
            set { ComIDVar.Value = value; }
        }

        public String PartNumber
        {
            get { return (String)PartNumberVar.Value; }
            set { PartNumberVar.Value = value; }
        }

        public String Manufacturer
        {
            get { return (String)ManufacturerVar.Value; }
            set { ManufacturerVar.Value = value; }
        }

        public String PlName
        {
            get { return (String)PlNameVar.Value; }
            set { PlNameVar.Value = value; }
        }

        public Double Description
        {
            get { return (Double)DescriptionVar.Value; }
            set { DescriptionVar.Value = value; }
        }

        public String Datasheet
        {
            get { return (String)DatasheetVar.Value; }
            set { DatasheetVar.Value = value; }
        }

        public String Lifecycle
        {
            get { return (String)LifecycleVar.Value; }
            set { LifecycleVar.Value = value; }
        }

        public String RoHS
        {
            get { return (String)RoHSVar.Value; }
            set { RoHSVar.Value = value; }
        }

        public String RoHSVersion
        {
            get { return (String)RoHSVersionVar.Value; }
            set { RoHSVersionVar.Value = value; }
        }

        public String MatchRating
        {
            get { return (String)MatchRatingVar.Value; }
            set { MatchRatingVar.Value = value; }
        }

        public String TaxonomyPath
        {
            get { return (String)TaxonomyPathVar.Value; }
            set { TaxonomyPathVar.Value = value; }
        }
      


    }
    public partial class silicon_expert_list_summary
    {
        public static silicon_expert_list_summary New(Context x)
        { return (silicon_expert_list_summary)x.Item("silicon_expert_list_summary"); }


        public static silicon_expert_list_summary GetById(Context x, String uid)
        { return (silicon_expert_list_summary)x.GetById("silicon_expert_list_summary", uid); }

        public static silicon_expert_list_summary QtO(Context x, String sql)
        { return (silicon_expert_list_summary)x.QtO("silicon_expert_list_summary", sql); }


    }
}
