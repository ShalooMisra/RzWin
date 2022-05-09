using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("part")]
    public partial class part_auto : NewMethod.nObject
    {
        static part_auto()
        {
            Item.AttributesCache(typeof(part_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "fullpartnumber":
                    fullpartnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "prefix":
                    prefixAttribute = (CoreVarValAttribute)attr;
                    break;
                case "basenumber":
                    basenumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datecode":
                    datecodeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "manufacturer":
                    manufacturerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "condition":
                    conditionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "partsetup":
                    partsetupAttribute = (CoreVarValAttribute)attr;
                    break;
                case "packaging":
                    packagingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "category":
                    categoryAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lotnumber":
                    lotnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatepart":
                    alternatepartAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatepart_stripped":
                    alternatepart_strippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatepart_01":
                    alternatepart_01Attribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatepart_01_stripped":
                    alternatepart_01_strippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatepart_02":
                    alternatepart_02Attribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatepart_02_stripped":
                    alternatepart_02_strippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatepart_03":
                    alternatepart_03Attribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatepart_03_stripped":
                    alternatepart_03_strippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatepart_04":
                    alternatepart_04Attribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatepart_04_stripped":
                    alternatepart_04_strippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "internalpartnumber":
                    internalpartnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "internalpartnumber_stripped":
                    internalpartnumber_strippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "stocktype":
                    stocktypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "internalcomment":
                    internalcommentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "rohs_info":
                    rohs_infoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unit_of_measure":
                    unit_of_measureAttribute = (CoreVarValAttribute)attr;
                    break;
                case "consignment_code":
                    consignment_codeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "consignment_percent":
                    consignment_percentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantity":
                    quantityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "basenumberstripped":
                    basenumberstrippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "internalstripped":
                    internalstrippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatepartstripped":
                    alternatepartstrippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "partsperpack":
                    partsperpackAttribute = (CoreVarValAttribute)attr;
                    break;
                case "category_stripped":
                    category_strippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description_stripped":
                    description_strippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "manufacturer_stripped":
                    manufacturer_strippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ProductType":
                    ProductTypeAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute fullpartnumberAttribute;
        static CoreVarValAttribute prefixAttribute;
        static CoreVarValAttribute basenumberAttribute;
        static CoreVarValAttribute datecodeAttribute;
        static CoreVarValAttribute manufacturerAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute conditionAttribute;
        static CoreVarValAttribute partsetupAttribute;
        static CoreVarValAttribute packagingAttribute;
        static CoreVarValAttribute categoryAttribute;
        static CoreVarValAttribute lotnumberAttribute;
        static CoreVarValAttribute alternatepartAttribute;
        static CoreVarValAttribute alternatepart_strippedAttribute;
        static CoreVarValAttribute alternatepart_01Attribute;
        static CoreVarValAttribute alternatepart_01_strippedAttribute;
        static CoreVarValAttribute alternatepart_02Attribute;
        static CoreVarValAttribute alternatepart_02_strippedAttribute;
        static CoreVarValAttribute alternatepart_03Attribute;
        static CoreVarValAttribute alternatepart_03_strippedAttribute;
        static CoreVarValAttribute alternatepart_04Attribute;
        static CoreVarValAttribute alternatepart_04_strippedAttribute;
        static CoreVarValAttribute internalpartnumberAttribute;
        static CoreVarValAttribute internalpartnumber_strippedAttribute;
        static CoreVarValAttribute stocktypeAttribute;
        static CoreVarValAttribute internalcommentAttribute;
        static CoreVarValAttribute rohs_infoAttribute;
        static CoreVarValAttribute unit_of_measureAttribute;
        static CoreVarValAttribute consignment_codeAttribute;
        static CoreVarValAttribute consignment_percentAttribute;
        static CoreVarValAttribute quantityAttribute;
        static CoreVarValAttribute basenumberstrippedAttribute;
        static CoreVarValAttribute internalstrippedAttribute;
        static CoreVarValAttribute alternatepartstrippedAttribute;
        static CoreVarValAttribute partsperpackAttribute;
        static CoreVarValAttribute category_strippedAttribute;
        static CoreVarValAttribute description_strippedAttribute;
        static CoreVarValAttribute manufacturer_strippedAttribute;
        static CoreVarValAttribute ProductTypeAttribute;

        [CoreVarVal("fullpartnumber", "String", TheFieldLength = 255, Caption="Fullpartnumber", Importance = 1)]
        public VarString fullpartnumberVar;

        [CoreVarVal("prefix", "String", TheFieldLength = 255, Caption="Prefix", Importance = 2)]
        public VarString prefixVar;

        [CoreVarVal("basenumber", "String", TheFieldLength = 255, Caption="Basenumber", Importance = 3)]
        public VarString basenumberVar;

        [CoreVarVal("datecode", "String", TheFieldLength = 255, Caption="Datecode", Importance = 4)]
        public VarString datecodeVar;

        [CoreVarVal("manufacturer", "String", TheFieldLength = 255, Caption="Manufacturer", Importance = 5)]
        public VarString manufacturerVar;

        [CoreVarVal("description", "String", TheFieldLength = 8000, Caption="Description", Importance = 6)]
        public VarString descriptionVar;

        [CoreVarVal("condition", "String", TheFieldLength = 255, Caption="Condition", Importance = 7)]
        public VarString conditionVar;

        [CoreVarVal("partsetup", "String", TheFieldLength = 255, Caption="Partsetup", Importance = 8)]
        public VarString partsetupVar;

        [CoreVarVal("packaging", "String", TheFieldLength = 255, Caption="Packaging", Importance = 10)]
        public VarString packagingVar;

        [CoreVarVal("category", "String", TheFieldLength = 255, Caption="Category", Importance = 11)]
        public VarString categoryVar;

        [CoreVarVal("lotnumber", "String", TheFieldLength = 255, Caption="Lotnumber", Importance = 12)]
        public VarString lotnumberVar;

        [CoreVarVal("alternatepart", "String", TheFieldLength = 255, Caption="Alternatepart", Importance = 13)]
        public VarString alternatepartVar;

        [CoreVarVal("alternatepart_stripped", "String", TheFieldLength = 255, Caption="Alternatepart Stripped", Importance = 14)]
        public VarString alternatepart_strippedVar;

        [CoreVarVal("alternatepart_01", "String", TheFieldLength = 255, Caption="Alternatepart 01", Importance = 15)]
        public VarString alternatepart_01Var;

        [CoreVarVal("alternatepart_01_stripped", "String", TheFieldLength = 255, Caption="Alternatepart 01 Stripped", Importance = 16)]
        public VarString alternatepart_01_strippedVar;

        [CoreVarVal("alternatepart_02", "String", TheFieldLength = 255, Caption="Alternatepart 02", Importance = 17)]
        public VarString alternatepart_02Var;

        [CoreVarVal("alternatepart_02_stripped", "String", TheFieldLength = 255, Caption="Alternatepart 02 Stripped", Importance = 18)]
        public VarString alternatepart_02_strippedVar;

        [CoreVarVal("alternatepart_03", "String", TheFieldLength = 255, Caption="Alternatepart 03", Importance = 19)]
        public VarString alternatepart_03Var;

        [CoreVarVal("alternatepart_03_stripped", "String", TheFieldLength = 255, Caption="Alternatepart 03 Stripped", Importance = 20)]
        public VarString alternatepart_03_strippedVar;

        [CoreVarVal("alternatepart_04", "String", TheFieldLength = 255, Caption="Alternatepart 04", Importance = 21)]
        public VarString alternatepart_04Var;

        [CoreVarVal("alternatepart_04_stripped", "String", TheFieldLength = 255, Caption="Alternatepart 04 Stripped", Importance = 22)]
        public VarString alternatepart_04_strippedVar;

        [CoreVarVal("internalpartnumber", "String", TheFieldLength = 255, Caption="Internalpartnumber", Importance = 23)]
        public VarString internalpartnumberVar;

        [CoreVarVal("internalpartnumber_stripped", "String", TheFieldLength = 255, Caption="Internalpartnumber Stripped", Importance = 24)]
        public VarString internalpartnumber_strippedVar;

        [CoreVarVal("stocktype", "String", TheFieldLength = 255, Caption="Stocktype", Importance = 25)]
        public VarString stocktypeVar;

        [CoreVarVal("internalcomment", "String", TheFieldLength = 8000, Caption="Internalcomment", Importance = 26)]
        public VarString internalcommentVar;

        [CoreVarVal("rohs_info", "String", TheFieldLength = 255, Caption="Rohs Info", Importance = 27)]
        public VarString rohs_infoVar;

        [CoreVarVal("unit_of_measure", "String", TheFieldLength = 255, Caption="Unit Of Measure", Importance = 28)]
        public VarString unit_of_measureVar;

        [CoreVarVal("consignment_code", "String", TheFieldLength = 255, Caption="Consignment Code", Importance = 29)]
        public VarString consignment_codeVar;

        [CoreVarVal("consignment_percent", "Int32", Caption="Consignment Percent", Importance = 30)]
        public VarInt32 consignment_percentVar;

        [CoreVarVal("quantity", "Int32", Caption="Quantity", Importance = 31)]
        public VarInt32 quantityVar;

        [CoreVarVal("basenumberstripped", "String", TheFieldLength = 255, Caption="Basenumberstripped", Importance = 32)]
        public VarString basenumberstrippedVar;

        [CoreVarVal("internalstripped", "String", TheFieldLength = 255, Caption="Internalstripped", Importance = 33)]
        public VarString internalstrippedVar;

        [CoreVarVal("alternatepartstripped", "String", TheFieldLength = 255, Caption="Alternatepartstripped", Importance = 34)]
        public VarString alternatepartstrippedVar;

        [CoreVarVal("partsperpack", "Int64", Caption="Partsperpack", Importance = 35)]
        public VarInt64 partsperpackVar;

        [CoreVarVal("category_stripped", "String", TheFieldLength = 255, Caption="Category Stripped", Importance = 36)]
        public VarString category_strippedVar;

        [CoreVarVal("description_stripped", "String", TheFieldLength = 8000, Caption="Description Stripped", Importance = 37)]
        public VarString description_strippedVar;

        [CoreVarVal("manufacturer_stripped", "String", TheFieldLength = 255, Caption="Manufacturer Stripped", Importance = 38)]
        public VarString manufacturer_strippedVar;

        [CoreVarVal("ProductType", "String", TheFieldLength = 255, Caption = "ProductType", Importance = 39)]
        public VarString ProductTypeVar;

        public part_auto()
        {
            StaticInit();
            fullpartnumberVar = new VarString(this, fullpartnumberAttribute);
            prefixVar = new VarString(this, prefixAttribute);
            basenumberVar = new VarString(this, basenumberAttribute);
            datecodeVar = new VarString(this, datecodeAttribute);
            manufacturerVar = new VarString(this, manufacturerAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            conditionVar = new VarString(this, conditionAttribute);
            partsetupVar = new VarString(this, partsetupAttribute);
            packagingVar = new VarString(this, packagingAttribute);
            categoryVar = new VarString(this, categoryAttribute);
            lotnumberVar = new VarString(this, lotnumberAttribute);
            alternatepartVar = new VarString(this, alternatepartAttribute);
            alternatepart_strippedVar = new VarString(this, alternatepart_strippedAttribute);
            alternatepart_01Var = new VarString(this, alternatepart_01Attribute);
            alternatepart_01_strippedVar = new VarString(this, alternatepart_01_strippedAttribute);
            alternatepart_02Var = new VarString(this, alternatepart_02Attribute);
            alternatepart_02_strippedVar = new VarString(this, alternatepart_02_strippedAttribute);
            alternatepart_03Var = new VarString(this, alternatepart_03Attribute);
            alternatepart_03_strippedVar = new VarString(this, alternatepart_03_strippedAttribute);
            alternatepart_04Var = new VarString(this, alternatepart_04Attribute);
            alternatepart_04_strippedVar = new VarString(this, alternatepart_04_strippedAttribute);
            internalpartnumberVar = new VarString(this, internalpartnumberAttribute);
            internalpartnumber_strippedVar = new VarString(this, internalpartnumber_strippedAttribute);
            stocktypeVar = new VarString(this, stocktypeAttribute);
            internalcommentVar = new VarString(this, internalcommentAttribute);
            rohs_infoVar = new VarString(this, rohs_infoAttribute);
            unit_of_measureVar = new VarString(this, unit_of_measureAttribute);
            consignment_codeVar = new VarString(this, consignment_codeAttribute);
            consignment_percentVar = new VarInt32(this, consignment_percentAttribute);
            quantityVar = new VarInt32(this, quantityAttribute);
            basenumberstrippedVar = new VarString(this, basenumberstrippedAttribute);
            internalstrippedVar = new VarString(this, internalstrippedAttribute);
            alternatepartstrippedVar = new VarString(this, alternatepartstrippedAttribute);
            partsperpackVar = new VarInt64(this, partsperpackAttribute);
            category_strippedVar = new VarString(this, category_strippedAttribute);
            description_strippedVar = new VarString(this, description_strippedAttribute);
            manufacturer_strippedVar = new VarString(this, manufacturer_strippedAttribute);
            ProductTypeVar = new VarString(this, ProductTypeAttribute);
        }

        public override string ClassId
        { get { return "part"; } }

        public String fullpartnumber
        {
            get  { return (String)fullpartnumberVar.Value; }
            set  { fullpartnumberVar.Value = value; }
        }

        public String prefix
        {
            get  { return (String)prefixVar.Value; }
            set  { prefixVar.Value = value; }
        }

        public String basenumber
        {
            get  { return (String)basenumberVar.Value; }
            set  { basenumberVar.Value = value; }
        }

        public String datecode
        {
            get  { return (String)datecodeVar.Value; }
            set  { datecodeVar.Value = value; }
        }

        public String manufacturer
        {
            get  { return (String)manufacturerVar.Value; }
            set  { manufacturerVar.Value = value; }
        }

        public String description
        {
            get  { return (String)descriptionVar.Value; }
            set  { descriptionVar.Value = value; }
        }

        public String condition
        {
            get  { return (String)conditionVar.Value; }
            set  { conditionVar.Value = value; }
        }

        public String partsetup
        {
            get  { return (String)partsetupVar.Value; }
            set  { partsetupVar.Value = value; }
        }

        public String packaging
        {
            get  { return (String)packagingVar.Value; }
            set  { packagingVar.Value = value; }
        }

        public String category
        {
            get  { return (String)categoryVar.Value; }
            set  { categoryVar.Value = value; }
        }

        public String lotnumber
        {
            get  { return (String)lotnumberVar.Value; }
            set  { lotnumberVar.Value = value; }
        }

        public String alternatepart
        {
            get  { return (String)alternatepartVar.Value; }
            set  { alternatepartVar.Value = value; }
        }

        public String alternatepart_stripped
        {
            get  { return (String)alternatepart_strippedVar.Value; }
            set  { alternatepart_strippedVar.Value = value; }
        }

        public String alternatepart_01
        {
            get  { return (String)alternatepart_01Var.Value; }
            set  { alternatepart_01Var.Value = value; }
        }

        public String alternatepart_01_stripped
        {
            get  { return (String)alternatepart_01_strippedVar.Value; }
            set  { alternatepart_01_strippedVar.Value = value; }
        }

        public String alternatepart_02
        {
            get  { return (String)alternatepart_02Var.Value; }
            set  { alternatepart_02Var.Value = value; }
        }

        public String alternatepart_02_stripped
        {
            get  { return (String)alternatepart_02_strippedVar.Value; }
            set  { alternatepart_02_strippedVar.Value = value; }
        }

        public String alternatepart_03
        {
            get  { return (String)alternatepart_03Var.Value; }
            set  { alternatepart_03Var.Value = value; }
        }

        public String alternatepart_03_stripped
        {
            get  { return (String)alternatepart_03_strippedVar.Value; }
            set  { alternatepart_03_strippedVar.Value = value; }
        }

        public String alternatepart_04
        {
            get  { return (String)alternatepart_04Var.Value; }
            set  { alternatepart_04Var.Value = value; }
        }

        public String alternatepart_04_stripped
        {
            get  { return (String)alternatepart_04_strippedVar.Value; }
            set  { alternatepart_04_strippedVar.Value = value; }
        }

        public String internalpartnumber
        {
            get  { return (String)internalpartnumberVar.Value; }
            set  { internalpartnumberVar.Value = value; }
        }

        public String internalpartnumber_stripped
        {
            get  { return (String)internalpartnumber_strippedVar.Value; }
            set  { internalpartnumber_strippedVar.Value = value; }
        }

        public String stocktype
        {
            get  { return (String)stocktypeVar.Value; }
            set  { stocktypeVar.Value = value; }
        }

        public String internalcomment
        {
            get  { return (String)internalcommentVar.Value; }
            set  { internalcommentVar.Value = value; }
        }

        public String rohs_info
        {
            get  { return (String)rohs_infoVar.Value; }
            set  { rohs_infoVar.Value = value; }
        }

        public String unit_of_measure
        {
            get  { return (String)unit_of_measureVar.Value; }
            set  { unit_of_measureVar.Value = value; }
        }

        public String consignment_code
        {
            get  { return (String)consignment_codeVar.Value; }
            set  { consignment_codeVar.Value = value; }
        }

        public Int32 consignment_percent
        {
            get  { return (Int32)consignment_percentVar.Value; }
            set  { consignment_percentVar.Value = value; }
        }

        public Int32 quantity
        {
            get  { return (Int32)quantityVar.Value; }
            set  { quantityVar.Value = value; }
        }

        public String basenumberstripped
        {
            get  { return (String)basenumberstrippedVar.Value; }
            set  { basenumberstrippedVar.Value = value; }
        }

        public String internalstripped
        {
            get  { return (String)internalstrippedVar.Value; }
            set  { internalstrippedVar.Value = value; }
        }

        public String alternatepartstripped
        {
            get  { return (String)alternatepartstrippedVar.Value; }
            set  { alternatepartstrippedVar.Value = value; }
        }

        public Int64 partsperpack
        {
            get  { return (Int64)partsperpackVar.Value; }
            set  { partsperpackVar.Value = value; }
        }

        public String category_stripped
        {
            get  { return (String)category_strippedVar.Value; }
            set  { category_strippedVar.Value = value; }
        }

        public String description_stripped
        {
            get  { return (String)description_strippedVar.Value; }
            set  { description_strippedVar.Value = value; }
        }

        public String manufacturer_stripped
        {
            get  { return (String)manufacturer_strippedVar.Value; }
            set  { manufacturer_strippedVar.Value = value; }
        }
        public String ProductType
        {
            get { return (String)ProductTypeVar.Value; }
            set { ProductTypeVar.Value = value; }
        }

    }
    public partial class part
    {
        public static part New(Context x)
        {  return (part)x.Item("part"); }

        public static part GetById(Context x, String uid)
        { return (part)x.GetById("part", uid); }

        public static part QtO(Context x, String sql)
        { return (part)x.QtO("part", sql); }
    }
}
