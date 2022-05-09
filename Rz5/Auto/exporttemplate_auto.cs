using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("exporttemplate")]
    public partial class exporttemplate_auto : NewMethod.nObject
    {
        static exporttemplate_auto()
        {
            Item.AttributesCache(typeof(exporttemplate_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "exportname":
                    exportnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exportstring":
                    exportstringAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exportclass":
                    exportclassAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exportfile":
                    exportfileAttribute = (CoreVarValAttribute)attr;
                    break;
                case "manualsql":
                    manualsqlAttribute = (CoreVarValAttribute)attr;
                    break;
                case "criterialist":
                    criterialistAttribute = (CoreVarValAttribute)attr;
                    break;
                case "emailsubject":
                    emailsubjectAttribute = (CoreVarValAttribute)attr;
                    break;
                case "emailaddresses":
                    emailaddressesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exportconsigned":
                    exportconsignedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exportexcess":
                    exportexcessAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exportstock":
                    exportstockAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fieldstring":
                    fieldstringAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exporttotext":
                    exporttotextAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companystring":
                    companystringAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantitymultiplier":
                    quantitymultiplierAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exportoffers":
                    exportoffersAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantitycap":
                    quantitycapAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantitysurrogate":
                    quantitysurrogateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fixeddata":
                    fixeddataAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exportdate":
                    exportdateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "reincludestripped":
                    reincludestrippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "includeheader":
                    includeheaderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qtyabovezero":
                    qtyabovezeroAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pnlength":
                    pnlengthAttribute = (CoreVarValAttribute)attr;
                    break;
                case "templatename":
                    templatenameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "donotexport":
                    donotexportAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exportwhere":
                    exportwhereAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exportcaptions":
                    exportcaptionsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "withcost":
                    withcostAttribute = (CoreVarValAttribute)attr;
                    break;
                case "only_selected":
                    only_selectedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exportonly":
                    exportonlyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "filter_dupes":
                    filter_dupesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "only_selected_consign":
                    only_selected_consignAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exportonly_consign":
                    exportonly_consignAttribute = (CoreVarValAttribute)attr;
                    break;
                case "donotexport_consign":
                    donotexport_consignAttribute = (CoreVarValAttribute)attr;
                    break;
                case "only_selected_offers":
                    only_selected_offersAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exportonly_offers":
                    exportonly_offersAttribute = (CoreVarValAttribute)attr;
                    break;
                case "donotexport_offers":
                    donotexport_offersAttribute = (CoreVarValAttribute)attr;
                    break;
                case "adqty":
                    adqtyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "adpercent":
                    adpercentAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute exportnameAttribute;
        static CoreVarValAttribute exportstringAttribute;
        static CoreVarValAttribute exportclassAttribute;
        static CoreVarValAttribute exportfileAttribute;
        static CoreVarValAttribute manualsqlAttribute;
        static CoreVarValAttribute criterialistAttribute;
        static CoreVarValAttribute emailsubjectAttribute;
        static CoreVarValAttribute emailaddressesAttribute;
        static CoreVarValAttribute exportconsignedAttribute;
        static CoreVarValAttribute exportexcessAttribute;
        static CoreVarValAttribute exportstockAttribute;
        static CoreVarValAttribute fieldstringAttribute;
        static CoreVarValAttribute exporttotextAttribute;
        static CoreVarValAttribute companystringAttribute;
        static CoreVarValAttribute quantitymultiplierAttribute;
        static CoreVarValAttribute exportoffersAttribute;
        static CoreVarValAttribute quantitycapAttribute;
        static CoreVarValAttribute quantitysurrogateAttribute;
        static CoreVarValAttribute fixeddataAttribute;
        static CoreVarValAttribute exportdateAttribute;
        static CoreVarValAttribute reincludestrippedAttribute;
        static CoreVarValAttribute includeheaderAttribute;
        static CoreVarValAttribute qtyabovezeroAttribute;
        static CoreVarValAttribute pnlengthAttribute;
        static CoreVarValAttribute templatenameAttribute;
        static CoreVarValAttribute donotexportAttribute;
        static CoreVarValAttribute exportwhereAttribute;
        static CoreVarValAttribute exportcaptionsAttribute;
        static CoreVarValAttribute withcostAttribute;
        static CoreVarValAttribute only_selectedAttribute;
        static CoreVarValAttribute exportonlyAttribute;
        static CoreVarValAttribute filter_dupesAttribute;
        static CoreVarValAttribute only_selected_consignAttribute;
        static CoreVarValAttribute exportonly_consignAttribute;
        static CoreVarValAttribute donotexport_consignAttribute;
        static CoreVarValAttribute only_selected_offersAttribute;
        static CoreVarValAttribute exportonly_offersAttribute;
        static CoreVarValAttribute donotexport_offersAttribute;
        static CoreVarValAttribute adqtyAttribute;
        static CoreVarValAttribute adpercentAttribute;

        [CoreVarVal("exportname", "String", TheFieldLength = 50, Caption="Name", Importance = 1)]
        public VarString exportnameVar;

        [CoreVarVal("exportstring", "String", TheFieldLength = 8000, Caption="String", Importance = 2)]
        public VarString exportstringVar;

        [CoreVarVal("exportclass", "String", TheFieldLength = 50, Caption="Class", Importance = 3)]
        public VarString exportclassVar;

        [CoreVarVal("exportfile", "String", TheFieldLength = 4096, Caption="Export File", Importance = 4)]
        public VarString exportfileVar;

        [CoreVarVal("manualsql", "Boolean", Caption="Manual Sql", Importance = 5)]
        public VarBoolean manualsqlVar;

        [CoreVarVal("criterialist", "String", TheFieldLength = 8000, Caption="Criteria List", Importance = 6)]
        public VarString criterialistVar;

        [CoreVarVal("emailsubject", "String", TheFieldLength = 50, Caption="Email Subject", Importance = 7)]
        public VarString emailsubjectVar;

        [CoreVarVal("emailaddresses", "String", TheFieldLength = 50, Caption="Email Addresses", Importance = 8)]
        public VarString emailaddressesVar;

        [CoreVarVal("exportconsigned", "Boolean", Caption="Export Consigned", Importance = 9)]
        public VarBoolean exportconsignedVar;

        [CoreVarVal("exportexcess", "Boolean", Caption="Export Excess", Importance = 10)]
        public VarBoolean exportexcessVar;

        [CoreVarVal("exportstock", "Boolean", Caption="Export Stock", Importance = 11)]
        public VarBoolean exportstockVar;

        [CoreVarVal("fieldstring", "String", TheFieldLength = 8000, Caption="Fields", Importance = 12)]
        public VarString fieldstringVar;

        [CoreVarVal("exporttotext", "Boolean", Caption="Export To Text", Importance = 13)]
        public VarBoolean exporttotextVar;

        [CoreVarVal("companystring", "String", TheFieldLength = 8000, Caption="Company String", Importance = 14)]
        public VarString companystringVar;

        [CoreVarVal("quantitymultiplier", "Double", Caption="Quantity Multiplier", Importance = 15)]
        public VarDouble quantitymultiplierVar;

        [CoreVarVal("exportoffers", "Boolean", Caption="Export Offers", Importance = 16)]
        public VarBoolean exportoffersVar;

        [CoreVarVal("quantitycap", "Int64", Caption="Quantity Cap", Importance = 17)]
        public VarInt64 quantitycapVar;

        [CoreVarVal("quantitysurrogate", "Int64", Caption="Quantity Surrogate", Importance = 18)]
        public VarInt64 quantitysurrogateVar;

        [CoreVarVal("fixeddata", "String", TheFieldLength = 255, Caption="Fixed Data", Importance = 19)]
        public VarString fixeddataVar;

        [CoreVarVal("exportdate", "DateTime", Caption="Export Date", Importance = 20)]
        public VarDateTime exportdateVar;

        [CoreVarVal("reincludestripped", "Boolean", Caption="Re-include Stripped", Importance = 21)]
        public VarBoolean reincludestrippedVar;

        [CoreVarVal("includeheader", "Boolean", Caption="Include Header", Importance = 22)]
        public VarBoolean includeheaderVar;

        [CoreVarVal("qtyabovezero", "Boolean", Caption="Quantity Above Zero", Importance = 23)]
        public VarBoolean qtyabovezeroVar;

        [CoreVarVal("pnlength", "Boolean", Caption="Part Number Length > 2", Importance = 24)]
        public VarBoolean pnlengthVar;

        [CoreVarVal("templatename", "String", TheFieldLength = 255, Caption="Template Name", Importance = 25)]
        public VarString templatenameVar;

        [CoreVarVal("donotexport", "Text", Caption="Do Not Export", Importance = 26)]
        public VarText donotexportVar;

        [CoreVarVal("exportwhere", "String", TheFieldLength = 8000, Caption="Export Where", Importance = 27)]
        public VarString exportwhereVar;

        [CoreVarVal("exportcaptions", "String", TheFieldLength = 255, Caption="Export Captions", Importance = 28)]
        public VarString exportcaptionsVar;

        [CoreVarVal("withcost", "Boolean", Caption="With Cost", Importance = 29)]
        public VarBoolean withcostVar;

        [CoreVarVal("only_selected", "Boolean", Caption="Only Selected", Importance = 30)]
        public VarBoolean only_selectedVar;

        [CoreVarVal("exportonly", "String", TheFieldLength = 8000, Caption="Export Only", Importance = 31)]
        public VarString exportonlyVar;

        [CoreVarVal("filter_dupes", "Boolean", Caption="Filter Dupes", Importance = 32)]
        public VarBoolean filter_dupesVar;

        [CoreVarVal("only_selected_consign", "Boolean", Caption="Only Selected Consign", Importance = 33)]
        public VarBoolean only_selected_consignVar;

        [CoreVarVal("exportonly_consign", "String", TheFieldLength = 8000, Caption="Export Only Consign", Importance = 34)]
        public VarString exportonly_consignVar;

        [CoreVarVal("donotexport_consign", "Text", Caption="Do Not Export Consign", Importance = 35)]
        public VarText donotexport_consignVar;

        [CoreVarVal("only_selected_offers", "Boolean", Caption="Only Selected Offers", Importance = 36)]
        public VarBoolean only_selected_offersVar;

        [CoreVarVal("exportonly_offers", "Text", Caption="Exportonly Offers", Importance = 37)]
        public VarText exportonly_offersVar;

        [CoreVarVal("donotexport_offers", "Text", Caption="Do Not Export Offers", Importance = 38)]
        public VarText donotexport_offersVar;

        [CoreVarVal("adqty", "Boolean", Caption="Advertised Quantity", Importance = 39)]
        public VarBoolean adqtyVar;

        [CoreVarVal("adpercent", "Int32", Caption="Advertised Percent", Importance = 40)]
        public VarInt32 adpercentVar;

        public exporttemplate_auto()
        {
            StaticInit();
            exportnameVar = new VarString(this, exportnameAttribute);
            exportstringVar = new VarString(this, exportstringAttribute);
            exportclassVar = new VarString(this, exportclassAttribute);
            exportfileVar = new VarString(this, exportfileAttribute);
            manualsqlVar = new VarBoolean(this, manualsqlAttribute);
            criterialistVar = new VarString(this, criterialistAttribute);
            emailsubjectVar = new VarString(this, emailsubjectAttribute);
            emailaddressesVar = new VarString(this, emailaddressesAttribute);
            exportconsignedVar = new VarBoolean(this, exportconsignedAttribute);
            exportexcessVar = new VarBoolean(this, exportexcessAttribute);
            exportstockVar = new VarBoolean(this, exportstockAttribute);
            fieldstringVar = new VarString(this, fieldstringAttribute);
            exporttotextVar = new VarBoolean(this, exporttotextAttribute);
            companystringVar = new VarString(this, companystringAttribute);
            quantitymultiplierVar = new VarDouble(this, quantitymultiplierAttribute);
            exportoffersVar = new VarBoolean(this, exportoffersAttribute);
            quantitycapVar = new VarInt64(this, quantitycapAttribute);
            quantitysurrogateVar = new VarInt64(this, quantitysurrogateAttribute);
            fixeddataVar = new VarString(this, fixeddataAttribute);
            exportdateVar = new VarDateTime(this, exportdateAttribute);
            reincludestrippedVar = new VarBoolean(this, reincludestrippedAttribute);
            includeheaderVar = new VarBoolean(this, includeheaderAttribute);
            qtyabovezeroVar = new VarBoolean(this, qtyabovezeroAttribute);
            pnlengthVar = new VarBoolean(this, pnlengthAttribute);
            templatenameVar = new VarString(this, templatenameAttribute);
            donotexportVar = new VarText(this, donotexportAttribute);
            exportwhereVar = new VarString(this, exportwhereAttribute);
            exportcaptionsVar = new VarString(this, exportcaptionsAttribute);
            withcostVar = new VarBoolean(this, withcostAttribute);
            only_selectedVar = new VarBoolean(this, only_selectedAttribute);
            exportonlyVar = new VarString(this, exportonlyAttribute);
            filter_dupesVar = new VarBoolean(this, filter_dupesAttribute);
            only_selected_consignVar = new VarBoolean(this, only_selected_consignAttribute);
            exportonly_consignVar = new VarString(this, exportonly_consignAttribute);
            donotexport_consignVar = new VarText(this, donotexport_consignAttribute);
            only_selected_offersVar = new VarBoolean(this, only_selected_offersAttribute);
            exportonly_offersVar = new VarText(this, exportonly_offersAttribute);
            donotexport_offersVar = new VarText(this, donotexport_offersAttribute);
            adqtyVar = new VarBoolean(this, adqtyAttribute);
            adpercentVar = new VarInt32(this, adpercentAttribute);
        }

        public override string ClassId
        { get { return "exporttemplate"; } }

        public String exportname
        {
            get  { return (String)exportnameVar.Value; }
            set  { exportnameVar.Value = value; }
        }

        public String exportstring
        {
            get  { return (String)exportstringVar.Value; }
            set  { exportstringVar.Value = value; }
        }

        public String exportclass
        {
            get  { return (String)exportclassVar.Value; }
            set  { exportclassVar.Value = value; }
        }

        public String exportfile
        {
            get  { return (String)exportfileVar.Value; }
            set  { exportfileVar.Value = value; }
        }

        public Boolean manualsql
        {
            get  { return (Boolean)manualsqlVar.Value; }
            set  { manualsqlVar.Value = value; }
        }

        public String criterialist
        {
            get  { return (String)criterialistVar.Value; }
            set  { criterialistVar.Value = value; }
        }

        public String emailsubject
        {
            get  { return (String)emailsubjectVar.Value; }
            set  { emailsubjectVar.Value = value; }
        }

        public String emailaddresses
        {
            get  { return (String)emailaddressesVar.Value; }
            set  { emailaddressesVar.Value = value; }
        }

        public Boolean exportconsigned
        {
            get  { return (Boolean)exportconsignedVar.Value; }
            set  { exportconsignedVar.Value = value; }
        }

        public Boolean exportexcess
        {
            get  { return (Boolean)exportexcessVar.Value; }
            set  { exportexcessVar.Value = value; }
        }

        public Boolean exportstock
        {
            get  { return (Boolean)exportstockVar.Value; }
            set  { exportstockVar.Value = value; }
        }

        public String fieldstring
        {
            get  { return (String)fieldstringVar.Value; }
            set  { fieldstringVar.Value = value; }
        }

        public Boolean exporttotext
        {
            get  { return (Boolean)exporttotextVar.Value; }
            set  { exporttotextVar.Value = value; }
        }

        public String companystring
        {
            get  { return (String)companystringVar.Value; }
            set  { companystringVar.Value = value; }
        }

        public Double quantitymultiplier
        {
            get  { return (Double)quantitymultiplierVar.Value; }
            set  { quantitymultiplierVar.Value = value; }
        }

        public Boolean exportoffers
        {
            get  { return (Boolean)exportoffersVar.Value; }
            set  { exportoffersVar.Value = value; }
        }

        public Int64 quantitycap
        {
            get  { return (Int64)quantitycapVar.Value; }
            set  { quantitycapVar.Value = value; }
        }

        public Int64 quantitysurrogate
        {
            get  { return (Int64)quantitysurrogateVar.Value; }
            set  { quantitysurrogateVar.Value = value; }
        }

        public String fixeddata
        {
            get  { return (String)fixeddataVar.Value; }
            set  { fixeddataVar.Value = value; }
        }

        public DateTime exportdate
        {
            get  { return (DateTime)exportdateVar.Value; }
            set  { exportdateVar.Value = value; }
        }

        public Boolean reincludestripped
        {
            get  { return (Boolean)reincludestrippedVar.Value; }
            set  { reincludestrippedVar.Value = value; }
        }

        public Boolean includeheader
        {
            get  { return (Boolean)includeheaderVar.Value; }
            set  { includeheaderVar.Value = value; }
        }

        public Boolean qtyabovezero
        {
            get  { return (Boolean)qtyabovezeroVar.Value; }
            set  { qtyabovezeroVar.Value = value; }
        }

        public Boolean pnlength
        {
            get  { return (Boolean)pnlengthVar.Value; }
            set  { pnlengthVar.Value = value; }
        }

        public String templatename
        {
            get  { return (String)templatenameVar.Value; }
            set  { templatenameVar.Value = value; }
        }

        public String donotexport
        {
            get  { return (String)donotexportVar.Value; }
            set  { donotexportVar.Value = value; }
        }

        public String exportwhere
        {
            get  { return (String)exportwhereVar.Value; }
            set  { exportwhereVar.Value = value; }
        }

        public String exportcaptions
        {
            get  { return (String)exportcaptionsVar.Value; }
            set  { exportcaptionsVar.Value = value; }
        }

        public Boolean withcost
        {
            get  { return (Boolean)withcostVar.Value; }
            set  { withcostVar.Value = value; }
        }

        public Boolean only_selected
        {
            get  { return (Boolean)only_selectedVar.Value; }
            set  { only_selectedVar.Value = value; }
        }

        public String exportonly
        {
            get  { return (String)exportonlyVar.Value; }
            set  { exportonlyVar.Value = value; }
        }

        public Boolean filter_dupes
        {
            get  { return (Boolean)filter_dupesVar.Value; }
            set  { filter_dupesVar.Value = value; }
        }

        public Boolean only_selected_consign
        {
            get  { return (Boolean)only_selected_consignVar.Value; }
            set  { only_selected_consignVar.Value = value; }
        }

        public String exportonly_consign
        {
            get  { return (String)exportonly_consignVar.Value; }
            set  { exportonly_consignVar.Value = value; }
        }

        public String donotexport_consign
        {
            get  { return (String)donotexport_consignVar.Value; }
            set  { donotexport_consignVar.Value = value; }
        }

        public Boolean only_selected_offers
        {
            get  { return (Boolean)only_selected_offersVar.Value; }
            set  { only_selected_offersVar.Value = value; }
        }

        public String exportonly_offers
        {
            get  { return (String)exportonly_offersVar.Value; }
            set  { exportonly_offersVar.Value = value; }
        }

        public String donotexport_offers
        {
            get  { return (String)donotexport_offersVar.Value; }
            set  { donotexport_offersVar.Value = value; }
        }

        public Boolean adqty
        {
            get  { return (Boolean)adqtyVar.Value; }
            set  { adqtyVar.Value = value; }
        }

        public Int32 adpercent
        {
            get  { return (Int32)adpercentVar.Value; }
            set  { adpercentVar.Value = value; }
        }

    }
    public partial class exporttemplate
    {
        public static exporttemplate New(Context x)
        {  return (exporttemplate)x.Item("exporttemplate"); }

        public static exporttemplate GetById(Context x, String uid)
        { return (exporttemplate)x.GetById("exporttemplate", uid); }

        public static exporttemplate QtO(Context x, String sql)
        { return (exporttemplate)x.QtO("exporttemplate", sql); }
    }
}
