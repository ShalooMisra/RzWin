using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("checkpayment")]
    public partial class checkpayment_auto : NewMethod.nObject
    {
        static checkpayment_auto()
        {
            Item.AttributesCache(typeof(checkpayment_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "base_company_uid":
                    base_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_mc_user_uid":
                    base_mc_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_ordhed_uid":
                    base_ordhed_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "transtype":
                    transtypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "referencedata":
                    referencedataAttribute = (CoreVarValAttribute)attr;
                    break;
                case "legacycompanyid":
                    legacycompanyidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "legacyordernumber":
                    legacyordernumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "legacyordertype":
                    legacyordertypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "transdate":
                    transdateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "transamountcurr":
                    transamountcurrAttribute = (CoreVarValAttribute)attr;
                    break;
                case "transamount":
                    transamountAttribute = (CoreVarValAttribute)attr;
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
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "senttoqb":
                    senttoqbAttribute = (CoreVarValAttribute)attr;
                    break;
                case "istt":
                    isttAttribute = (CoreVarValAttribute)attr;
                    break;
                case "subtotal":
                    subtotalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "feeamount":
                    feeamountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "payment_type":
                    payment_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_underpaid":
                    is_underpaidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "handlingamount":
                    handlingamountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "taxamount":
                    taxamountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_account":
                    qb_accountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "payment_in_uid":
                    payment_in_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "payment_out_uid":
                    payment_out_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "payment_method":
                    payment_methodAttribute = (CoreVarValAttribute)attr;
                    break;
                case "line_uid":
                    line_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordernumber":
                    ordernumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "withhold_from_profit":
                    withhold_from_profitAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sendTransactionAlertEmail":
                    sendTransactionAlertEmailAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sendAffiliateAlertEmail":
                    sendAffiliateAlertEmailAttribute = (CoreVarValAttribute)attr;
                    break;




            }
        }

        static CoreVarValAttribute base_company_uidAttribute;
        static CoreVarValAttribute base_mc_user_uidAttribute;
        static CoreVarValAttribute base_ordhed_uidAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute transtypeAttribute;
        static CoreVarValAttribute referencedataAttribute;
        static CoreVarValAttribute legacycompanyidAttribute;
        static CoreVarValAttribute legacyordernumberAttribute;
        static CoreVarValAttribute legacyordertypeAttribute;
        static CoreVarValAttribute transdateAttribute;
        static CoreVarValAttribute transamountcurrAttribute;
        static CoreVarValAttribute transamountAttribute;
        static CoreVarValAttribute datecreatedAttribute;
        static CoreVarValAttribute datemodifiedAttribute;
        static CoreVarValAttribute modifiedbyAttribute;
        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute senttoqbAttribute;
        static CoreVarValAttribute isttAttribute;
        static CoreVarValAttribute subtotalAttribute;
        static CoreVarValAttribute feeamountAttribute;
        static CoreVarValAttribute payment_typeAttribute;
        static CoreVarValAttribute is_underpaidAttribute;
        static CoreVarValAttribute handlingamountAttribute;
        static CoreVarValAttribute taxamountAttribute;
        static CoreVarValAttribute qb_accountAttribute;
        static CoreVarValAttribute payment_in_uidAttribute;
        static CoreVarValAttribute payment_out_uidAttribute;
        static CoreVarValAttribute payment_methodAttribute;
        static CoreVarValAttribute line_uidAttribute;
        static CoreVarValAttribute ordernumberAttribute;
        static CoreVarValAttribute withhold_from_profitAttribute;
        static CoreVarValAttribute sendTransactionAlertEmailAttribute;
        static CoreVarValAttribute sendAffiliateAlertEmailAttribute;

        


        [CoreVarVal("base_company_uid", "String", TheFieldLength = 50, Caption = "Base Company Id", Importance = 1)]
        public VarString base_company_uidVar;

        [CoreVarVal("base_mc_user_uid", "String", TheFieldLength = 50, Caption = "User Id", Importance = 2)]
        public VarString base_mc_user_uidVar;

        [CoreVarVal("base_ordhed_uid", "String", TheFieldLength = 50, Caption = "Base Ordhed Id", Importance = 3)]
        public VarString base_ordhed_uidVar;

        [CoreVarVal("description", "String", TheFieldLength = 255, Caption = "Description", Importance = 4)]
        public VarString descriptionVar;

        [CoreVarVal("transtype", "String", TheFieldLength = 255, Caption = "Transaction Type", Importance = 5)]
        public VarString transtypeVar;

        [CoreVarVal("referencedata", "String", TheFieldLength = 255, Caption = "Reference Data", Importance = 6)]
        public VarString referencedataVar;

        [CoreVarVal("legacycompanyid", "String", TheFieldLength = 255, Caption = "Legacy Company Id", Importance = 7)]
        public VarString legacycompanyidVar;

        [CoreVarVal("legacyordernumber", "String", TheFieldLength = 255, Caption = "Legacy Order Number", Importance = 8)]
        public VarString legacyordernumberVar;

        [CoreVarVal("legacyordertype", "String", TheFieldLength = 255, Caption = "Legacy Order Type", Importance = 9)]
        public VarString legacyordertypeVar;

        [CoreVarVal("transdate", "DateTime", Caption = "Transaction Date", Importance = 10)]
        public VarDateTime transdateVar;

        [CoreVarVal("transamountcurr", "String", TheFieldLength = 4, Caption = "Transaction Amount Currency", Importance = 11)]
        public VarString transamountcurrVar;

        [CoreVarVal("transamount", "Double", Caption = "Transaction Amount", Importance = 12)]
        public VarDouble transamountVar;

        [CoreVarVal("datecreated", "DateTime", Caption = "Date Created", Importance = 13)]
        public VarDateTime datecreatedVar;

        [CoreVarVal("datemodified", "DateTime", Caption = "Date Modified", Importance = 14)]
        public VarDateTime datemodifiedVar;

        [CoreVarVal("modifiedby", "String", TheFieldLength = 50, Caption = "Modified By", Importance = 15)]
        public VarString modifiedbyVar;

        [CoreVarVal("companyname", "String", TheFieldLength = 255, Caption = "Company Name", Importance = 16)]
        public VarString companynameVar;

        [CoreVarVal("senttoqb", "Boolean", Caption = "Sent To Qb", Importance = 17)]
        public VarBoolean senttoqbVar;

        [CoreVarVal("istt", "Boolean", Caption = "Is Tt", Importance = 18)]
        public VarBoolean isttVar;


        [CoreVarVal("subtotal", "Double", Caption = "Sub Total", Importance = 19)]
        public VarDouble subtotalVar;

        [CoreVarVal("feeamount", "Double", Caption = "Fee Amount", Importance = 20)]
        public VarDouble feeamountVar;

        [CoreVarVal("payment_type", "String", TheFieldLength = 255, Caption = "Payment Type", Importance = 21)]
        public VarString payment_typeVar;

        [CoreVarVal("is_underpaid", "Boolean", Caption = "Is Under Paid", Importance = 22)]
        public VarBoolean is_underpaidVar;

        [CoreVarVal("handlingamount", "Double", Caption = "Handlingamount", Importance = 23)]
        public VarDouble handlingamountVar;

        [CoreVarVal("taxamount", "Double", Caption = "Taxamount", Importance = 24)]
        public VarDouble taxamountVar;

        [CoreVarVal("qb_account", "String", TheFieldLength = 255, Caption = "Qb Account", Importance = 25)]
        public VarString qb_accountVar;

        [CoreVarVal("payment_in_uid", "String", Caption = "Payment In Uid", Importance = 25)]
        public VarString payment_in_uidVar;

        [CoreVarVal("payment_out_uid", "String", Caption = "Payment Out Uid", Importance = 26)]
        public VarString payment_out_uidVar;

        [CoreVarVal("payment_method", "String", Caption = "Payment Method", Importance = 27)]
        public VarString payment_methodVar;

        [CoreVarVal("line_uid", "String", TheFieldLength = 50, Caption = "Line Item UID", Importance = 28)]
        public VarString line_uidVar;

        [CoreVarVal("ordernumber", "String", TheFieldLength = 50, Caption = "Order Number", Importance = 29)]
        public VarString ordernumberVar;

        [CoreVarVal("withhold_from_profit", "Boolean", Caption = "Withold from profit calculation", Importance = 30)]
        public VarBoolean withhold_from_profitVar;

        [CoreVarVal("sendTransactionAlertEmail", "Boolean", Caption = "Send Transaction Email Alert", Importance = 31)]
        public VarBoolean sendTransactionAlertEmailVar;

        [CoreVarVal("sendAffiliateAlertEmail", "Boolean", Caption = "Send Affiliate Payment Email Alert", Importance = 31)]
        public VarBoolean sendAffiliateAlertEmailVar;

        


        public checkpayment_auto()
        {
            StaticInit();
            base_company_uidVar = new VarString(this, base_company_uidAttribute);
            base_mc_user_uidVar = new VarString(this, base_mc_user_uidAttribute);
            base_ordhed_uidVar = new VarString(this, base_ordhed_uidAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            transtypeVar = new VarString(this, transtypeAttribute);
            referencedataVar = new VarString(this, referencedataAttribute);
            legacycompanyidVar = new VarString(this, legacycompanyidAttribute);
            legacyordernumberVar = new VarString(this, legacyordernumberAttribute);
            legacyordertypeVar = new VarString(this, legacyordertypeAttribute);
            transdateVar = new VarDateTime(this, transdateAttribute);
            transamountcurrVar = new VarString(this, transamountcurrAttribute);
            transamountVar = new VarDouble(this, transamountAttribute);
            datecreatedVar = new VarDateTime(this, datecreatedAttribute);
            datemodifiedVar = new VarDateTime(this, datemodifiedAttribute);
            modifiedbyVar = new VarString(this, modifiedbyAttribute);
            companynameVar = new VarString(this, companynameAttribute);
            senttoqbVar = new VarBoolean(this, senttoqbAttribute);
            isttVar = new VarBoolean(this, isttAttribute);
            subtotalVar = new VarDouble(this, subtotalAttribute);
            feeamountVar = new VarDouble(this, feeamountAttribute);
            payment_typeVar = new VarString(this, payment_typeAttribute);
            is_underpaidVar = new VarBoolean(this, is_underpaidAttribute);
            handlingamountVar = new VarDouble(this, handlingamountAttribute);
            taxamountVar = new VarDouble(this, taxamountAttribute);
            qb_accountVar = new VarString(this, qb_accountAttribute);
            payment_in_uidVar = new VarString(this, payment_in_uidAttribute);
            payment_out_uidVar = new VarString(this, payment_out_uidAttribute);
            payment_methodVar = new VarString(this, payment_methodAttribute);
            line_uidVar = new VarString(this, line_uidAttribute);
            ordernumberVar = new VarString(this, ordernumberAttribute);
            withhold_from_profitVar = new VarBoolean(this, withhold_from_profitAttribute);
            sendTransactionAlertEmailVar = new VarBoolean(this, sendTransactionAlertEmailAttribute);
            sendAffiliateAlertEmailVar = new VarBoolean(this, sendAffiliateAlertEmailAttribute);
            





        }

        public override string ClassId
        { get { return "checkpayment"; } }

        public String base_company_uid
        {
            get { return (String)base_company_uidVar.Value; }
            set { base_company_uidVar.Value = value; }
        }

        public String base_mc_user_uid
        {
            get { return (String)base_mc_user_uidVar.Value; }
            set { base_mc_user_uidVar.Value = value; }
        }

        public String base_ordhed_uid
        {
            get { return (String)base_ordhed_uidVar.Value; }
            set { base_ordhed_uidVar.Value = value; }
        }

        public String description
        {
            get { return (String)descriptionVar.Value; }
            set { descriptionVar.Value = value; }
        }

        public String transtype
        {
            get { return (String)transtypeVar.Value; }
            set { transtypeVar.Value = value; }
        }

        public String referencedata
        {
            get { return (String)referencedataVar.Value; }
            set { referencedataVar.Value = value; }
        }

        public String legacycompanyid
        {
            get { return (String)legacycompanyidVar.Value; }
            set { legacycompanyidVar.Value = value; }
        }

        public String legacyordernumber
        {
            get { return (String)legacyordernumberVar.Value; }
            set { legacyordernumberVar.Value = value; }
        }

        public String legacyordertype
        {
            get { return (String)legacyordertypeVar.Value; }
            set { legacyordertypeVar.Value = value; }
        }

        public DateTime transdate
        {
            get { return (DateTime)transdateVar.Value; }
            set { transdateVar.Value = value; }
        }

        public String transamountcurr
        {
            get { return (String)transamountcurrVar.Value; }
            set { transamountcurrVar.Value = value; }
        }

        public Double transamount
        {
            get { return (Double)transamountVar.Value; }
            set { transamountVar.Value = value; }
        }

        public DateTime datecreated
        {
            get { return (DateTime)datecreatedVar.Value; }
            set { datecreatedVar.Value = value; }
        }

        public DateTime datemodified
        {
            get { return (DateTime)datemodifiedVar.Value; }
            set { datemodifiedVar.Value = value; }
        }

        public String modifiedby
        {
            get { return (String)modifiedbyVar.Value; }
            set { modifiedbyVar.Value = value; }
        }

        public String companyname
        {
            get { return (String)companynameVar.Value; }
            set { companynameVar.Value = value; }
        }

        public Boolean senttoqb
        {
            get { return (Boolean)senttoqbVar.Value; }
            set { senttoqbVar.Value = value; }
        }

        public Boolean istt
        {
            get { return (Boolean)isttVar.Value; }
            set { isttVar.Value = value; }
        }

        public Double subtotal
        {
            get { return (Double)subtotalVar.Value; }
            set { subtotalVar.Value = value; }
        }

        public Double feeamount
        {
            get { return (Double)feeamountVar.Value; }
            set { feeamountVar.Value = value; }
        }

        public String payment_type
        {
            get { return (String)payment_typeVar.Value; }
            set { payment_typeVar.Value = value; }
        }

        public Boolean is_underpaid
        {
            get { return (Boolean)is_underpaidVar.Value; }
            set { is_underpaidVar.Value = value; }
        }

        public Double handlingamount
        {
            get { return (Double)handlingamountVar.Value; }
            set { handlingamountVar.Value = value; }
        }

        public Double taxamount
        {
            get { return (Double)taxamountVar.Value; }
            set { taxamountVar.Value = value; }
        }

        public String qb_account
        {
            get { return (String)qb_accountVar.Value; }
            set { qb_accountVar.Value = value; }
        }

        public String payment_in_uid
        {
            get { return (String)payment_in_uidVar.Value; }
            set { payment_in_uidVar.Value = value; }
        }

        public String payment_out_uid
        {
            get { return (String)payment_out_uidVar.Value; }
            set { payment_out_uidVar.Value = value; }
        }

        public String payment_method
        {
            get { return (String)payment_methodVar.Value; }
            set { payment_methodVar.Value = value; }
        }

        public String line_uid
        {
            get { return (String)line_uidVar.Value; }
            set { line_uidVar.Value = value; }
        }

        public String ordernumber
        {
            get { return (String)ordernumberVar.Value; }
            set { ordernumberVar.Value = value; }
        }
        public Boolean withhold_from_profit
        {
            get { return (Boolean)withhold_from_profitVar.Value; }
            set { withhold_from_profitVar.Value = value; }
        }

        public Boolean sendTransactionAlertEmail
        {
            get { return (Boolean)sendTransactionAlertEmailVar.Value; }
            set { sendTransactionAlertEmailVar.Value = value; }
        }

        public Boolean sendAffiliateAlertEmail
        {
            get { return (Boolean)sendAffiliateAlertEmailVar.Value; }
            set { sendAffiliateAlertEmailVar.Value = value; }
        }

        

    }
    public partial class checkpayment
    {
        public static checkpayment New(Context x)
        { return (checkpayment)x.Item("checkpayment"); }

        public static checkpayment GetById(Context x, String uid)
        { return (checkpayment)x.GetById("checkpayment", uid); }

        public static checkpayment QtO(Context x, String sql)
        { return (checkpayment)x.QtO("checkpayment", sql); }
    }
}
