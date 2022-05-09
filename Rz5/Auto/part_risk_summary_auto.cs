using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("part_risk_summary", Caption = "Part Risk Summary", Importance = 80)]
    public partial class part_risk_summary_auto : NewMethod.nObject
    {
        static part_risk_summary_auto()
        {
            Item.AttributesCache(typeof(account_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {

                case "batch_id":
                    batch_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyName":
                    companyNameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyId":
                    companyIdAttribute = (CoreVarValAttribute)attr;
                    break;
                case "comID":
                    comIDAttribute = (CoreVarValAttribute)attr;
                    break;
                case "dtoID":
                    dtoIDAttribute = (CoreVarValAttribute)attr;
                    break;
                case "partNumber":
                    partNumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "manufacturer":
                    manufacturerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "eCCN":
                    eCCNAttribute = (CoreVarValAttribute)attr;
                    break;
                case "partDescription":
                    partDescriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "LastCheckDate":
                    LastCheckDateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "estimatedYearsToEOL":
                    estimatedYearsToEOLAttribute = (CoreVarValAttribute)attr;
                    break;
                case "estimatedEOLDate":
                    estimatedEOLDateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "partLifecycleStage":
                    partLifecycleStageAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lifeCycleRiskGrade":
                    lifeCycleRiskGradeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "overallRisk":
                    overallRiskAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hasObsolescenceNotice":
                    hasObsolescenceNoticeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hasNRNDNotice":
                    hasNRNDNoticeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "seGrade":
                    seGradeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ProductImageSmall":
                    ProductImageSmallAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ProductImageLarge":
                    ProductImageLargeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "MinimumPrice":
                    MinimumPriceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "AveragePrice":
                    AveragePriceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "MinLeadtime":
                    MinLeadtimeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "Maxleadtime":
                    MaxleadtimeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "LastUpdatedate":
                    LastUpdatedateAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }


        static CoreVarValAttribute batch_idAttribute;
        static CoreVarValAttribute companyNameAttribute;
        static CoreVarValAttribute companyIdAttribute;
        static CoreVarValAttribute comIDAttribute;
        static CoreVarValAttribute dtoIDAttribute;
        static CoreVarValAttribute partNumberAttribute;
        static CoreVarValAttribute manufacturerAttribute;
        static CoreVarValAttribute eCCNAttribute;
        static CoreVarValAttribute partDescriptionAttribute;
        static CoreVarValAttribute LastCheckDateAttribute;
        static CoreVarValAttribute estimatedYearsToEOLAttribute;
        static CoreVarValAttribute estimatedEOLDateAttribute;
        static CoreVarValAttribute partLifecycleStageAttribute;
        static CoreVarValAttribute lifeCycleRiskGradeAttribute;
        static CoreVarValAttribute overallRiskAttribute;
        static CoreVarValAttribute hasObsolescenceNoticeAttribute;
        static CoreVarValAttribute hasNRNDNoticeAttribute;
        static CoreVarValAttribute seGradeAttribute;
        static CoreVarValAttribute ProductImageSmallAttribute;
        static CoreVarValAttribute ProductImageLargeAttribute;
        static CoreVarValAttribute AveragePriceAttribute;
        static CoreVarValAttribute MinimumPriceAttribute;
        static CoreVarValAttribute MinLeadtimeAttribute;
        static CoreVarValAttribute MaxleadtimeAttribute;
        static CoreVarValAttribute LastUpdatedateAttribute;


        [CoreVarVal("batch_id", "Int32", Caption = "batch_id", Importance = 1)]
        public VarInt32 batch_idVar;

        [CoreVarVal("companyName", "String", Caption = "companyName", Importance = 0, SearchCriteria = true)]
        public VarString companyNameVar;

        [CoreVarVal("companyId", "String", Caption = "companyId", Importance = 0, SearchCriteria = true)]
        public VarString companyIdVar;

        [CoreVarVal("comID", "String", Caption = "comID", Importance = 0, SearchCriteria = true)]
        public VarString comIDVar;

        [CoreVarVal("dtoID", "String", Caption = "dtoID", Importance = 0, SearchCriteria = true)]
        public VarString dtoIDVar;

        [CoreVarVal("partNumber", "String", Caption = "partNumber", Importance = 0, SearchCriteria = true)]
        public VarString partNumberVar;

        [CoreVarVal("manufacturer", "String", Caption = "manufacturer", Importance = 0, SearchCriteria = true)]
        public VarString manufacturerVar;

        [CoreVarVal("eCCN", "String", Caption = "eCCN", Importance = 0, SearchCriteria = true)]
        public VarString eCCNVar;

        [CoreVarVal("partDescription", "Text", Caption = "partDescription", Importance = 0, SearchCriteria = true)]
        public VarText partDescriptionVar;

        [CoreVarVal("LastCheckDate", "String", Caption = "LastCheckDate", Importance = 0, SearchCriteria = true)]
        public VarString LastCheckDateVar;

        [CoreVarVal("estimatedYearsToEOL", "String", Caption = "estimatedYearsToEOL", Importance = 0, SearchCriteria = true)]
        public VarString estimatedYearsToEOLVar;

        [CoreVarVal("estimatedEOLDate", "String", Caption = "estimatedEOLDate", Importance = 0, SearchCriteria = true)]
        public VarString estimatedEOLDateVar;

        [CoreVarVal("partLifecycleStage", "String", Caption = "partLifecycleStage", Importance = 0, SearchCriteria = true)]
        public VarString partLifecycleStageVar;

        [CoreVarVal("lifeCycleRiskGrade", "String", Caption = "lifeCycleRiskGrade", Importance = 0, SearchCriteria = true)]
        public VarString lifeCycleRiskGradeVar;

        [CoreVarVal("overallRisk", "String", Caption = "overallRisk", Importance = 0, SearchCriteria = true)]
        public VarString overallRiskVar;

        [CoreVarVal("hasObsolescenceNotice", "String", Caption = "hasObsolescenceNotice", Importance = 0, SearchCriteria = true)]
        public VarString hasObsolescenceNoticeVar;

        [CoreVarVal("hasNRNDNotice", "String", Caption = "hasNRNDNotice", Importance = 0, SearchCriteria = true)]
        public VarString hasNRNDNoticeVar;

        [CoreVarVal("seGrade", "String", Caption = "seGrade", Importance = 0, SearchCriteria = true)]
        public VarString seGradeVar;

        [CoreVarVal("ProductImageSmall", "String", Caption = "ProductImageSmall", Importance = 0, SearchCriteria = true)]
        public VarString ProductImageSmallVar;

        [CoreVarVal("ProductImageLarge", "String", Caption = "ProductImageLarge", Importance = 0, SearchCriteria = true)]
        public VarString ProductImageLargeVar;

        [CoreVarVal("MinimumPrice", "String", Caption = "MinimumPrice", Importance = 0, SearchCriteria = true)]
        public VarString MinimumPriceVar;

        [CoreVarVal("AveragePrice", "String", Caption = "AveragePrice", Importance = 0, SearchCriteria = true)]
        public VarString AveragePriceVar;

        [CoreVarVal("MinLeadtime", "String", Caption = "MinLeadtime", Importance = 0, SearchCriteria = true)]
        public VarString MinLeadtimeVar;

        [CoreVarVal("Maxleadtime", "String", Caption = "Maxleadtime", Importance = 0, SearchCriteria = true)]
        public VarString MaxleadtimeVar;

        [CoreVarVal("LastUpdatedate", "String", Caption = "LastUpdatedate", Importance = 0, SearchCriteria = true)]
        public VarString LastUpdatedateVar;





        public part_risk_summary_auto()
        {
            StaticInit();
            batch_idVar = new VarInt32(this, batch_idAttribute);
            companyNameVar = new VarString(this, companyNameAttribute);
            companyIdVar = new VarString(this, companyIdAttribute);
            comIDVar = new VarString(this, comIDAttribute);
            dtoIDVar = new VarString(this, dtoIDAttribute);
            partNumberVar = new VarString(this, partNumberAttribute);
            manufacturerVar = new VarString(this, manufacturerAttribute);
            eCCNVar = new VarString(this, eCCNAttribute);
            partDescriptionVar = new VarText(this, partDescriptionAttribute);
            LastCheckDateVar = new VarString(this, LastCheckDateAttribute);
            estimatedYearsToEOLVar = new VarString(this, estimatedYearsToEOLAttribute);
            estimatedEOLDateVar = new VarString(this, estimatedEOLDateAttribute);
            partLifecycleStageVar = new VarString(this, partLifecycleStageAttribute);
            lifeCycleRiskGradeVar = new VarString(this, lifeCycleRiskGradeAttribute);
            overallRiskVar = new VarString(this, overallRiskAttribute);
            hasObsolescenceNoticeVar = new VarString(this, hasObsolescenceNoticeAttribute);
            hasNRNDNoticeVar = new VarString(this, hasNRNDNoticeAttribute);
            seGradeVar = new VarString(this, seGradeAttribute);
            ProductImageSmallVar = new VarString(this, ProductImageSmallAttribute);
            ProductImageLargeVar = new VarString(this, ProductImageLargeAttribute);
            MinimumPriceVar = new VarString(this, MinimumPriceAttribute);
            AveragePriceVar = new VarString(this, AveragePriceAttribute);
            MinLeadtimeVar = new VarString(this, MinLeadtimeAttribute);
            MaxleadtimeVar = new VarString(this, MaxleadtimeAttribute);
            LastUpdatedateVar = new VarString(this, LastUpdatedateAttribute);
        }

        public override string ClassId
        { get { return "part_risk_summary"; } }



        public Int32 batch_id
        {
            get { return (Int32)batch_idVar.Value; }
            set { batch_idVar.Value = value; }
        }

        public String companyName
        {
            get { return (String)companyNameVar.Value; }
            set { companyNameVar.Value = value; }
        }

        public String companyId
        {
            get { return (String)companyIdVar.Value; }
            set { companyIdVar.Value = value; }
        }

        public Int64 comID
        {
            get { return (Int64)comIDVar.Value; }
            set { comIDVar.Value = value; }
        }

        public Int64 dtoID
        {
            get { return (Int64)dtoIDVar.Value; }
            set { dtoIDVar.Value = value; }
        }

        public String partNumber
        {
            get { return (String)partNumberVar.Value; }
            set { partNumberVar.Value = value; }
        }

        public String manufacturer
        {
            get { return (String)manufacturerVar.Value; }
            set { manufacturerVar.Value = value; }
        }

        public String eCCN
        {
            get { return (String)eCCNVar.Value; }
            set { eCCNVar.Value = value; }
        }

        public String partDescription
        {
            get { return (String)partDescriptionVar.Value; }
            set { partDescriptionVar.Value = value; }
        }

        public String LastCheckDate
        {
            get { return (String)LastCheckDateVar.Value; }
            set { LastCheckDateVar.Value = value; }
        }


        public String estimatedYearsToEOL
        {
            get { return (String)estimatedYearsToEOLVar.Value; }
            set { estimatedYearsToEOLVar.Value = value; }
        }

        public String estimatedEOLDate
        {
            get { return (String)estimatedEOLDateVar.Value; }
            set { estimatedEOLDateVar.Value = value; }
        }

        public String partLifecycleStage
        {
            get { return (String)partLifecycleStageVar.Value; }
            set { partLifecycleStageVar.Value = value; }
        }

        public String lifeCycleRiskGrade
        {
            get { return (String)lifeCycleRiskGradeVar.Value; }
            set { lifeCycleRiskGradeVar.Value = value; }
        }

        public String overallRisk
        {
            get { return (String)overallRiskVar.Value; }
            set { overallRiskVar.Value = value; }
        }

        public String hasObsolescenceNotice
        {
            get { return (String)hasObsolescenceNoticeVar.Value; }
            set { hasObsolescenceNoticeVar.Value = value; }
        }

        public String hasNRNDNotice
        {
            get { return (String)hasNRNDNoticeVar.Value; }
            set { hasNRNDNoticeVar.Value = value; }
        }

        public String seGrade
        {
            get { return (String)seGradeVar.Value; }
            set { seGradeVar.Value = value; }
        }

        public String ProductImageSmall
        {
            get { return (String)ProductImageSmallVar.Value; }
            set { ProductImageSmallVar.Value = value; }
        }

        public String ProductImageLarge
        {
            get { return (String)ProductImageLargeVar.Value; }
            set { ProductImageLargeVar.Value = value; }
        }

        public String MinimumPrice
        {
            get { return (String)MinimumPriceVar.Value; }
            set { MinimumPriceVar.Value = value; }
        }

        public String AveragePrice
        {
            get { return (String)AveragePriceVar.Value; }
            set { AveragePriceVar.Value = value; }
        }

        public String MinLeadtime
        {
            get { return (String)MinLeadtimeVar.Value; }
            set { MinLeadtimeVar.Value = value; }
        }

        public String Maxleadtime
        {
            get { return (String)MaxleadtimeVar.Value; }
            set { MaxleadtimeVar.Value = value; }
        }

        public String LastUpdatedate
        {
            get { return (String)LastUpdatedateVar.Value; }
            set { LastUpdatedateVar.Value = value; }
        }






    }
    public partial class part_risk_summary
    {
        public static part_risk_summary New(Context x)
        { return (part_risk_summary)x.Item("part_risk_summary"); }

        public static part_risk_summary GetById(Context x, String uid)
        { return (part_risk_summary)x.GetById("part_risk_summary", uid); }

        public static part_risk_summary QtO(Context x, String sql)
        { return (part_risk_summary)x.QtO("part_risk_summary", sql); }

        public static part_risk_summary GetByName(Context x, String name, String extraSql = "")
        { return (part_risk_summary)x.GetByName("part_risk_summary", name, extraSql); }
    }
}
