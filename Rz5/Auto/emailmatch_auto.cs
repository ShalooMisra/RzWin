using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("emailmatch")]
    public partial class emailmatch_auto : NewMethod.nObject
    {
        static emailmatch_auto()
        {
            Item.AttributesCache(typeof(emailmatch_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "base_message_uid":
                    base_message_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fullpartnumber":
                    fullpartnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantity":
                    quantityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datecode":
                    datecodeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "manufacturer":
                    manufacturerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "prefix":
                    prefixAttribute = (CoreVarValAttribute)attr;
                    break;
                case "basenumber":
                    basenumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "basenumberstripped":
                    basenumberstrippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "basenumbertrunced":
                    basenumbertruncedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "condition":
                    conditionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "partsetup":
                    partsetupAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cost":
                    costAttribute = (CoreVarValAttribute)attr;
                    break;
                case "costcurr":
                    costcurrAttribute = (CoreVarValAttribute)attr;
                    break;
                case "price":
                    priceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pricecurr":
                    pricecurrAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sourceaddress":
                    sourceaddressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "requirementid":
                    requirementidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyid":
                    companyidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ishandled":
                    ishandledAttribute = (CoreVarValAttribute)attr;
                    break;
                case "requiredpart":
                    requiredpartAttribute = (CoreVarValAttribute)attr;
                    break;
                case "requiredquantity":
                    requiredquantityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "partid":
                    partidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datecreated":
                    datecreatedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datemodified":
                    datemodifiedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "modifiedby":
                    modifiedbyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "firstlines":
                    firstlinesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isclosed":
                    isclosedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quotequantity":
                    quotequantityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quoteprice":
                    quotepriceAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute base_message_uidAttribute;
        static CoreVarValAttribute fullpartnumberAttribute;
        static CoreVarValAttribute quantityAttribute;
        static CoreVarValAttribute datecodeAttribute;
        static CoreVarValAttribute manufacturerAttribute;
        static CoreVarValAttribute prefixAttribute;
        static CoreVarValAttribute basenumberAttribute;
        static CoreVarValAttribute basenumberstrippedAttribute;
        static CoreVarValAttribute basenumbertruncedAttribute;
        static CoreVarValAttribute conditionAttribute;
        static CoreVarValAttribute partsetupAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute costAttribute;
        static CoreVarValAttribute costcurrAttribute;
        static CoreVarValAttribute priceAttribute;
        static CoreVarValAttribute pricecurrAttribute;
        static CoreVarValAttribute sourceaddressAttribute;
        static CoreVarValAttribute requirementidAttribute;
        static CoreVarValAttribute companyidAttribute;
        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute ishandledAttribute;
        static CoreVarValAttribute requiredpartAttribute;
        static CoreVarValAttribute requiredquantityAttribute;
        static CoreVarValAttribute partidAttribute;
        static CoreVarValAttribute datecreatedAttribute;
        static CoreVarValAttribute datemodifiedAttribute;
        static CoreVarValAttribute modifiedbyAttribute;
        static CoreVarValAttribute firstlinesAttribute;
        static CoreVarValAttribute isclosedAttribute;
        static CoreVarValAttribute quotequantityAttribute;
        static CoreVarValAttribute quotepriceAttribute;

        [CoreVarVal("base_message_uid", "String", TheFieldLength = 50, Caption="Base Message Id", Importance = 1)]
        public VarString base_message_uidVar;

        [CoreVarVal("fullpartnumber", "String", TheFieldLength = 255, Caption="Part Number", Importance = 2)]
        public VarString fullpartnumberVar;

        [CoreVarVal("quantity", "Int64", Caption="Quantity", Importance = 3)]
        public VarInt64 quantityVar;

        [CoreVarVal("datecode", "String", TheFieldLength = 15, Caption="Date Code", Importance = 4)]
        public VarString datecodeVar;

        [CoreVarVal("manufacturer", "String", TheFieldLength = 25, Caption="Manufacturer", Importance = 5)]
        public VarString manufacturerVar;

        [CoreVarVal("prefix", "String", TheFieldLength = 20, Caption="Prefix", Importance = 6)]
        public VarString prefixVar;

        [CoreVarVal("basenumber", "String", TheFieldLength = 50, Caption="Base Number", Importance = 7)]
        public VarString basenumberVar;

        [CoreVarVal("basenumberstripped", "String", TheFieldLength = 50, Caption="Truncated Base Number", Importance = 8)]
        public VarString basenumberstrippedVar;

        [CoreVarVal("basenumbertrunced", "String", TheFieldLength = 50, Caption="Truncated Base Number", Importance = 9)]
        public VarString basenumbertruncedVar;

        [CoreVarVal("condition", "String", TheFieldLength = 50, Caption="Condition", Importance = 10)]
        public VarString conditionVar;

        [CoreVarVal("partsetup", "String", TheFieldLength = 50, Caption="Part Setup", Importance = 11)]
        public VarString partsetupVar;

        [CoreVarVal("description", "String", TheFieldLength = 50, Caption="Description", Importance = 12)]
        public VarString descriptionVar;

        [CoreVarVal("cost", "Double", Caption="Cost", Importance = 13)]
        public VarDouble costVar;

        [CoreVarVal("costcurr", "String", TheFieldLength = 4, Caption="Cost Currency", Importance = 14)]
        public VarString costcurrVar;

        [CoreVarVal("price", "Double", Caption="Price", Importance = 15)]
        public VarDouble priceVar;

        [CoreVarVal("pricecurr", "String", TheFieldLength = 4, Caption="Price Currency", Importance = 16)]
        public VarString pricecurrVar;

        [CoreVarVal("sourceaddress", "String", TheFieldLength = 50, Caption="Source Address", Importance = 17)]
        public VarString sourceaddressVar;

        [CoreVarVal("requirementid", "String", TheFieldLength = 50, Caption="Req Id", Importance = 18)]
        public VarString requirementidVar;

        [CoreVarVal("companyid", "String", TheFieldLength = 50, Caption="Company Id", Importance = 19)]
        public VarString companyidVar;

        [CoreVarVal("companyname", "String", TheFieldLength = 50, Caption="Company Name", Importance = 20)]
        public VarString companynameVar;

        [CoreVarVal("ishandled", "Boolean", Caption="Handled", Importance = 21)]
        public VarBoolean ishandledVar;

        [CoreVarVal("requiredpart", "String", TheFieldLength = 50, Caption="Required Part", Importance = 22)]
        public VarString requiredpartVar;

        [CoreVarVal("requiredquantity", "Int64", Caption="Required Quantity", Importance = 23)]
        public VarInt64 requiredquantityVar;

        [CoreVarVal("partid", "String", TheFieldLength = 50, Caption="Part Id", Importance = 24)]
        public VarString partidVar;

        [CoreVarVal("datecreated", "DateTime", Caption="Date Created", Importance = 25)]
        public VarDateTime datecreatedVar;

        [CoreVarVal("datemodified", "DateTime", Caption="Date Modified", Importance = 26)]
        public VarDateTime datemodifiedVar;

        [CoreVarVal("modifiedby", "String", TheFieldLength = 50, Caption="Modified By", Importance = 27)]
        public VarString modifiedbyVar;

        [CoreVarVal("firstlines", "String", TheFieldLength = 8000, Caption="First Lines", Importance = 28)]
        public VarString firstlinesVar;

        [CoreVarVal("isclosed", "Boolean", Caption="Is Closed", Importance = 29)]
        public VarBoolean isclosedVar;

        [CoreVarVal("quotequantity", "Int64", Caption="Quote Quantity", Importance = 30)]
        public VarInt64 quotequantityVar;

        [CoreVarVal("quoteprice", "Double", Caption="Quote Price", Importance = 31)]
        public VarDouble quotepriceVar;

        public emailmatch_auto()
        {
            StaticInit();
            base_message_uidVar = new VarString(this, base_message_uidAttribute);
            fullpartnumberVar = new VarString(this, fullpartnumberAttribute);
            quantityVar = new VarInt64(this, quantityAttribute);
            datecodeVar = new VarString(this, datecodeAttribute);
            manufacturerVar = new VarString(this, manufacturerAttribute);
            prefixVar = new VarString(this, prefixAttribute);
            basenumberVar = new VarString(this, basenumberAttribute);
            basenumberstrippedVar = new VarString(this, basenumberstrippedAttribute);
            basenumbertruncedVar = new VarString(this, basenumbertruncedAttribute);
            conditionVar = new VarString(this, conditionAttribute);
            partsetupVar = new VarString(this, partsetupAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            costVar = new VarDouble(this, costAttribute);
            costcurrVar = new VarString(this, costcurrAttribute);
            priceVar = new VarDouble(this, priceAttribute);
            pricecurrVar = new VarString(this, pricecurrAttribute);
            sourceaddressVar = new VarString(this, sourceaddressAttribute);
            requirementidVar = new VarString(this, requirementidAttribute);
            companyidVar = new VarString(this, companyidAttribute);
            companynameVar = new VarString(this, companynameAttribute);
            ishandledVar = new VarBoolean(this, ishandledAttribute);
            requiredpartVar = new VarString(this, requiredpartAttribute);
            requiredquantityVar = new VarInt64(this, requiredquantityAttribute);
            partidVar = new VarString(this, partidAttribute);
            datecreatedVar = new VarDateTime(this, datecreatedAttribute);
            datemodifiedVar = new VarDateTime(this, datemodifiedAttribute);
            modifiedbyVar = new VarString(this, modifiedbyAttribute);
            firstlinesVar = new VarString(this, firstlinesAttribute);
            isclosedVar = new VarBoolean(this, isclosedAttribute);
            quotequantityVar = new VarInt64(this, quotequantityAttribute);
            quotepriceVar = new VarDouble(this, quotepriceAttribute);
        }

        public override string ClassId
        { get { return "emailmatch"; } }

        public String base_message_uid
        {
            get  { return (String)base_message_uidVar.Value; }
            set  { base_message_uidVar.Value = value; }
        }

        public String fullpartnumber
        {
            get  { return (String)fullpartnumberVar.Value; }
            set  { fullpartnumberVar.Value = value; }
        }

        public Int64 quantity
        {
            get  { return (Int64)quantityVar.Value; }
            set  { quantityVar.Value = value; }
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

        public String basenumberstripped
        {
            get  { return (String)basenumberstrippedVar.Value; }
            set  { basenumberstrippedVar.Value = value; }
        }

        public String basenumbertrunced
        {
            get  { return (String)basenumbertruncedVar.Value; }
            set  { basenumbertruncedVar.Value = value; }
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

        public String description
        {
            get  { return (String)descriptionVar.Value; }
            set  { descriptionVar.Value = value; }
        }

        public Double cost
        {
            get  { return (Double)costVar.Value; }
            set  { costVar.Value = value; }
        }

        public String costcurr
        {
            get  { return (String)costcurrVar.Value; }
            set  { costcurrVar.Value = value; }
        }

        public Double price
        {
            get  { return (Double)priceVar.Value; }
            set  { priceVar.Value = value; }
        }

        public String pricecurr
        {
            get  { return (String)pricecurrVar.Value; }
            set  { pricecurrVar.Value = value; }
        }

        public String sourceaddress
        {
            get  { return (String)sourceaddressVar.Value; }
            set  { sourceaddressVar.Value = value; }
        }

        public String requirementid
        {
            get  { return (String)requirementidVar.Value; }
            set  { requirementidVar.Value = value; }
        }

        public String companyid
        {
            get  { return (String)companyidVar.Value; }
            set  { companyidVar.Value = value; }
        }

        public String companyname
        {
            get  { return (String)companynameVar.Value; }
            set  { companynameVar.Value = value; }
        }

        public Boolean ishandled
        {
            get  { return (Boolean)ishandledVar.Value; }
            set  { ishandledVar.Value = value; }
        }

        public String requiredpart
        {
            get  { return (String)requiredpartVar.Value; }
            set  { requiredpartVar.Value = value; }
        }

        public Int64 requiredquantity
        {
            get  { return (Int64)requiredquantityVar.Value; }
            set  { requiredquantityVar.Value = value; }
        }

        public String partid
        {
            get  { return (String)partidVar.Value; }
            set  { partidVar.Value = value; }
        }

        public DateTime datecreated
        {
            get  { return (DateTime)datecreatedVar.Value; }
            set  { datecreatedVar.Value = value; }
        }

        public DateTime datemodified
        {
            get  { return (DateTime)datemodifiedVar.Value; }
            set  { datemodifiedVar.Value = value; }
        }

        public String modifiedby
        {
            get  { return (String)modifiedbyVar.Value; }
            set  { modifiedbyVar.Value = value; }
        }

        public String firstlines
        {
            get  { return (String)firstlinesVar.Value; }
            set  { firstlinesVar.Value = value; }
        }

        public Boolean isclosed
        {
            get  { return (Boolean)isclosedVar.Value; }
            set  { isclosedVar.Value = value; }
        }

        public Int64 quotequantity
        {
            get  { return (Int64)quotequantityVar.Value; }
            set  { quotequantityVar.Value = value; }
        }

        public Double quoteprice
        {
            get  { return (Double)quotepriceVar.Value; }
            set  { quotepriceVar.Value = value; }
        }

    }
    public partial class emailmatch
    {
        public static emailmatch New(Context x)
        {  return (emailmatch)x.Item("emailmatch"); }

        public static emailmatch GetById(Context x, String uid)
        { return (emailmatch)x.GetById("emailmatch", uid); }

        public static emailmatch QtO(Context x, String sql)
        { return (emailmatch)x.QtO("emailmatch", sql); }
    }
}
