using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("importtemplate")]
    public partial class importtemplate_auto : NewMethod.nObject
    {
        static importtemplate_auto()
        {
            Item.AttributesCache(typeof(importtemplate_auto), AttributeCache);
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
                case "template_name":
                    template_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "templatespecs":
                    templatespecsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "file_name":
                    file_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "info_type":
                    info_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "do_save":
                    do_saveAttribute = (CoreVarValAttribute)attr;
                    break;
                case "do_report":
                    do_reportAttribute = (CoreVarValAttribute)attr;
                    break;
                case "do_batch":
                    do_batchAttribute = (CoreVarValAttribute)attr;
                    break;
                case "include_parts":
                    include_partsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "parts_type":
                    parts_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "include_reqs":
                    include_reqsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "reqs_type":
                    reqs_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "include_sales":
                    include_salesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sales_type":
                    sales_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "include_purchase":
                    include_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "purchase_type":
                    purchase_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "include_alternate":
                    include_alternateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternate_type":
                    alternate_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "report_type":
                    report_typeAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute base_company_uidAttribute;
        static CoreVarValAttribute base_mc_user_uidAttribute;
        static CoreVarValAttribute template_nameAttribute;
        static CoreVarValAttribute templatespecsAttribute;
        static CoreVarValAttribute file_nameAttribute;
        static CoreVarValAttribute info_typeAttribute;
        static CoreVarValAttribute do_saveAttribute;
        static CoreVarValAttribute do_reportAttribute;
        static CoreVarValAttribute do_batchAttribute;
        static CoreVarValAttribute include_partsAttribute;
        static CoreVarValAttribute parts_typeAttribute;
        static CoreVarValAttribute include_reqsAttribute;
        static CoreVarValAttribute reqs_typeAttribute;
        static CoreVarValAttribute include_salesAttribute;
        static CoreVarValAttribute sales_typeAttribute;
        static CoreVarValAttribute include_purchaseAttribute;
        static CoreVarValAttribute purchase_typeAttribute;
        static CoreVarValAttribute include_alternateAttribute;
        static CoreVarValAttribute alternate_typeAttribute;
        static CoreVarValAttribute report_typeAttribute;

        [CoreVarVal("base_company_uid", "String", TheFieldLength = 50, Caption="Base Company Id", Importance = 1)]
        public VarString base_company_uidVar;

        [CoreVarVal("base_mc_user_uid", "String", TheFieldLength = 50, Caption="Base Mc User Id", Importance = 2)]
        public VarString base_mc_user_uidVar;

        [CoreVarVal("template_name", "String", TheFieldLength = 50, Caption="Template Name", Importance = 3)]
        public VarString template_nameVar;

        [CoreVarVal("templatespecs", "String", TheFieldLength = 8000, Caption="Template Specs", Importance = 4)]
        public VarString templatespecsVar;

        [CoreVarVal("file_name", "String", TheFieldLength = 255, Caption="File Name", Importance = 5)]
        public VarString file_nameVar;

        [CoreVarVal("info_type", "String", TheFieldLength = 255, Caption="Information Type", Importance = 6)]
        public VarString info_typeVar;

        [CoreVarVal("do_save", "Boolean", Caption="Do Save", Importance = 7)]
        public VarBoolean do_saveVar;

        [CoreVarVal("do_report", "Boolean", Caption="Do Report", Importance = 8)]
        public VarBoolean do_reportVar;

        [CoreVarVal("do_batch", "Boolean", Caption="Do Batch", Importance = 9)]
        public VarBoolean do_batchVar;

        [CoreVarVal("include_parts", "Boolean", Caption="Include Parts", Importance = 10)]
        public VarBoolean include_partsVar;

        [CoreVarVal("parts_type", "String", TheFieldLength = 50, Caption="Parts Type", Importance = 11)]
        public VarString parts_typeVar;

        [CoreVarVal("include_reqs", "Boolean", Caption="Include Reqs", Importance = 12)]
        public VarBoolean include_reqsVar;

        [CoreVarVal("reqs_type", "String", TheFieldLength = 255, Caption="Reqs Type", Importance = 13)]
        public VarString reqs_typeVar;

        [CoreVarVal("include_sales", "Boolean", Caption="Include Sales", Importance = 14)]
        public VarBoolean include_salesVar;

        [CoreVarVal("sales_type", "String", TheFieldLength = 255, Caption="Sales Type", Importance = 15)]
        public VarString sales_typeVar;

        [CoreVarVal("include_purchase", "Boolean", Caption="Include Purchase", Importance = 16)]
        public VarBoolean include_purchaseVar;

        [CoreVarVal("purchase_type", "String", TheFieldLength = 255, Caption="Purchase Type", Importance = 17)]
        public VarString purchase_typeVar;

        [CoreVarVal("include_alternate", "Boolean", Caption="Include Alternate", Importance = 18)]
        public VarBoolean include_alternateVar;

        [CoreVarVal("alternate_type", "String", TheFieldLength = 255, Caption="Alternate Type", Importance = 19)]
        public VarString alternate_typeVar;

        [CoreVarVal("report_type", "String", TheFieldLength = 255, Caption="Report Type", Importance = 20)]
        public VarString report_typeVar;

        public importtemplate_auto()
        {
            StaticInit();
            base_company_uidVar = new VarString(this, base_company_uidAttribute);
            base_mc_user_uidVar = new VarString(this, base_mc_user_uidAttribute);
            template_nameVar = new VarString(this, template_nameAttribute);
            templatespecsVar = new VarString(this, templatespecsAttribute);
            file_nameVar = new VarString(this, file_nameAttribute);
            info_typeVar = new VarString(this, info_typeAttribute);
            do_saveVar = new VarBoolean(this, do_saveAttribute);
            do_reportVar = new VarBoolean(this, do_reportAttribute);
            do_batchVar = new VarBoolean(this, do_batchAttribute);
            include_partsVar = new VarBoolean(this, include_partsAttribute);
            parts_typeVar = new VarString(this, parts_typeAttribute);
            include_reqsVar = new VarBoolean(this, include_reqsAttribute);
            reqs_typeVar = new VarString(this, reqs_typeAttribute);
            include_salesVar = new VarBoolean(this, include_salesAttribute);
            sales_typeVar = new VarString(this, sales_typeAttribute);
            include_purchaseVar = new VarBoolean(this, include_purchaseAttribute);
            purchase_typeVar = new VarString(this, purchase_typeAttribute);
            include_alternateVar = new VarBoolean(this, include_alternateAttribute);
            alternate_typeVar = new VarString(this, alternate_typeAttribute);
            report_typeVar = new VarString(this, report_typeAttribute);
        }

        public override string ClassId
        { get { return "importtemplate"; } }

        public String base_company_uid
        {
            get  { return (String)base_company_uidVar.Value; }
            set  { base_company_uidVar.Value = value; }
        }

        public String base_mc_user_uid
        {
            get  { return (String)base_mc_user_uidVar.Value; }
            set  { base_mc_user_uidVar.Value = value; }
        }

        public String template_name
        {
            get  { return (String)template_nameVar.Value; }
            set  { template_nameVar.Value = value; }
        }

        public String templatespecs
        {
            get  { return (String)templatespecsVar.Value; }
            set  { templatespecsVar.Value = value; }
        }

        public String file_name
        {
            get  { return (String)file_nameVar.Value; }
            set  { file_nameVar.Value = value; }
        }

        public String info_type
        {
            get  { return (String)info_typeVar.Value; }
            set  { info_typeVar.Value = value; }
        }

        public Boolean do_save
        {
            get  { return (Boolean)do_saveVar.Value; }
            set  { do_saveVar.Value = value; }
        }

        public Boolean do_report
        {
            get  { return (Boolean)do_reportVar.Value; }
            set  { do_reportVar.Value = value; }
        }

        public Boolean do_batch
        {
            get  { return (Boolean)do_batchVar.Value; }
            set  { do_batchVar.Value = value; }
        }

        public Boolean include_parts
        {
            get  { return (Boolean)include_partsVar.Value; }
            set  { include_partsVar.Value = value; }
        }

        public String parts_type
        {
            get  { return (String)parts_typeVar.Value; }
            set  { parts_typeVar.Value = value; }
        }

        public Boolean include_reqs
        {
            get  { return (Boolean)include_reqsVar.Value; }
            set  { include_reqsVar.Value = value; }
        }

        public String reqs_type
        {
            get  { return (String)reqs_typeVar.Value; }
            set  { reqs_typeVar.Value = value; }
        }

        public Boolean include_sales
        {
            get  { return (Boolean)include_salesVar.Value; }
            set  { include_salesVar.Value = value; }
        }

        public String sales_type
        {
            get  { return (String)sales_typeVar.Value; }
            set  { sales_typeVar.Value = value; }
        }

        public Boolean include_purchase
        {
            get  { return (Boolean)include_purchaseVar.Value; }
            set  { include_purchaseVar.Value = value; }
        }

        public String purchase_type
        {
            get  { return (String)purchase_typeVar.Value; }
            set  { purchase_typeVar.Value = value; }
        }

        public Boolean include_alternate
        {
            get  { return (Boolean)include_alternateVar.Value; }
            set  { include_alternateVar.Value = value; }
        }

        public String alternate_type
        {
            get  { return (String)alternate_typeVar.Value; }
            set  { alternate_typeVar.Value = value; }
        }

        public String report_type
        {
            get  { return (String)report_typeVar.Value; }
            set  { report_typeVar.Value = value; }
        }

    }
    public partial class importtemplate
    {
        public static importtemplate New(Context x)
        {  return (importtemplate)x.Item("importtemplate"); }

        public static importtemplate GetById(Context x, String uid)
        { return (importtemplate)x.GetById("importtemplate", uid); }

        public static importtemplate QtO(Context x, String sql)
        { return (importtemplate)x.QtO("importtemplate", sql); }
    }
}
