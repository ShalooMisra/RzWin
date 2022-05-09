using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Reflection;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

using OfficeInterop;
using Core;
//using CoreWin;
using NewMethod;
//using Tie;
using System.Data;
using Tools.Database;
using HubspotApis;

namespace Rz5
{
    [CoreSys("Rz5")]
    public partial class SysRz5 : SysNewMethod
    {
        public static String RzNamespace = "Rz5";  //use this for CreateInstance();
        public const int RzIndex = 4;

        public override string InstallFolderPrefix
        {
            get
            {
                return "Rz4";  //leave for now; its what Peak looks for
            }
        }

        protected override Core.Logic LogicCreate()
        {
            return new RzLogic();
        }


        public override void ActsListInstance(Context x, ActSetup mnu, string classId)
        {
            ContextRz xrz = (ContextRz)x;

            base.ActsListInstance(x, mnu, classId);
            switch (classId.ToLower())
            {
                case "profit_deduction":
                    TheProfitLogic.ActsListInstanceDeductions(x, mnu);
                    break;
                case "calllog":
                    TheCompanyLogic.ActsListInstanceCallLog(x, mnu);
                    break;
                case "contactnote":
                    TheCompanyLogic.ActsListInstanceContactNote(x, mnu);
                    break;
                case "partrecord":
                    ThePartLogic.ActsListInstance(x, mnu);
                    break;
                case "company":
                    TheCompanyLogic.ActsListInstance(x, mnu);
                    break;
                case "companyaddress":
                    TheCompanyLogic.ActsListInstanceCompanyAddress(x, mnu);
                    break;
                case "shippingaccount":
                    TheCompanyLogic.ActsListInstanceShippingAccount(x, mnu);
                    break;
                case "consignment_code":
                    mnu.Add("Activate");
                    mnu.Add("De-Activate");
                    break;
                case "ordhed":
                case "ordhed_rfq":
                case "ordhed_service":
                case "ordhed_quote":
                case "ordhed_sales":
                case "ordhed_purchase":
                case "ordhed_invoice":
                case "ordhed_rma":
                case "ordhed_vendrma":
                    TheOrderLogic.ActsListInstance(x, mnu);
                    break;
                case "orddet_old":
                case "orddet_rfq":
                case "orddet_quote":
                    TheLineLogic.ActsListOrdDetOld(xrz, mnu);
                    break;
                case "orddet_line":
                case "orddet_service":
                case "orddet_sales":
                case "orddet_purchase":
                case "orddet_invoice":
                case "orddet_rma":
                case "orddet_vendrma":
                    TheLineLogic.ActsListInstance(x, mnu);
                    break;
                //case "qualitycontrol":
                //    mnu.Add("Print");
                //    mnu.Add("Email");
                //    break;
                //Refactored from RzSensible 12-5-2018
                case "qualitycontrol":
                    base.ActsListInstance(x, mnu, classId);
                    mnu.Add("Customer Report");
                    break;
                case "pack":
                    mnu.Add("View Inspection");
                    break;
                case "offer":
                    mnu.Add("New RFQ");
                    mnu.Add("Hot Part");
                    mnu.Add("Give Quote");
                    mnu.Add("Receive Bid");
                    break;
                case "companycontact":
                    TheCompanyLogic.ActsListInstanceContact(x, mnu);
                    break;
                case "printheader":
                    mnu.Add("Duplicate");
                    break;
                case "partpicture":
                    mnu.Add("View");
                    mnu.Add("Delete");
                    break;
                case "reqbatch":
                    mnu.Add("Add Req");
                    mnu.Add("Import List");
                    mnu.Add("View Summary");
                    if (!xrz.Logic.UseAlternateReqScreens)
                    {
                        mnu.Add("Close");
                        mnu.Add("ReOpen");
                    }
                    else
                    {
                        mnu.Add("Flag As Open");
                        mnu.Add("Flag As Released");
                        mnu.Add("Flag As Sourced");
                        mnu.Add("Flag As Closed");
                    }
                    mnu.Add("Formal Quote");
                    mnu.Add("Sales Order");
                    mnu.Add("Set Req Company");
                    mnu.Add("Set Req Agent");
                    mnu.Add("Order By Price");
                    break;
                case "checkpayment":
                    mnu.Add("Send To QB");
                    mnu.Add("Apply Full Payment");
                    break;
                case "marketing_batch":
                    mnu.Add("Active");
                    mnu.Add("Non-Active");
                    mnu.Add("Duplicate");
                    break;
                case "partial_contact_email":
                    TheCompanyLogic.ActsListInstanceDomainExtra(xrz, mnu);
                    break;
                case "lot_buy":
                    mnu.Add("Calculate And Report");
                    mnu.Add("Report In A Date Range");
                    break;
                case "label_queue":
                    if (mnu.Multiple(x))
                        mnu.Add("Export Address List");
                    break;
                case "dealheader":
                    mnu.Add("Report");
                    break;
                case "emailtemplate":
                    mnu.Add("Duplicate");
                    break;
                case "phonecall":
                    mnu.Add("Apply Extra Stuff");
                    TheCompanyLogic.ActsListInstanceFindRecordings(xrz, mnu);
                    break;
                case "filelink":
                    mnu.Add("Export File");
                    mnu.Add("Import File");
                    break;
                case "test_pictures":
                    mnu.Add("Print");
                    break;
                case "usernote":
                    mnu.Add("Apply A Company");
                    break;
                case "currency":
                    mnu.Add("View Rate History");
                    break;


            }
            if (Recall)
            {
                n_user u = ((ContextRz)x).xUserRz;
                if (u.CheckPermit((ContextNM)x, Permissions.ThePermits.CanViewChangeHistory, true, true))
                {
                    mnu.AddSeparator();
                    mnu.Add("View Change History");
                }
            }
        }


       
        public override bool ViewChangeHistory(ContextNM x, nObject o)
        {
            if (x == null)
                return false;
            if (o == null)
                return false;
            ((ILeaderRz)x.TheLeader).ViewChangeHistory((ContextRz)x, o);
            return true;
        }
       
        public override void SendNote(ContextNM context, nObject xObject)
        {
            usernote n = usernote.New(context);
            n.shouldpopup = true;
            n.is_pending = true;
            context.Insert(n);
            if (xObject is company)
            {
                company cp = (company)xObject;
                n.CreateObjectLink((ContextRz)context, xObject, cp.ToString() + " Ph: " + cp.primaryphone + "  Em: " + cp.primaryemailaddress);

            }
            else if (xObject is companycontact)
            {
                companycontact ct = (companycontact)xObject;
                n.CreateObjectLink((ContextRz)context, xObject, ct.ToString() + " Ph: " + ct.primaryphone + "  Em: " + ct.primaryemailaddress);
            }
            else
                n.CreateObjectLink((ContextRz)context, xObject, xObject.ToString());

            context.Show(n);
        }
        public override String[] GetActiveClasses()
        {
            return Tools.Strings.Split("ordhed,orddet,company,companycontact,quote,req", ",");
        }
       
        public override ArrayList GetMainProperties(String strClass)
        {
            switch (strClass.ToLower())
            {
                case "ordhed":
                case "ordhed_rfq":
                case "ordhed_service":
                case "ordhed_quote":
                case "ordhed_sales":
                case "ordhed_purchase":
                case "ordhed_invoice":
                case "ordhed_rma":
                case "ordhed_vendrma":
                    return nTools.SplitArray("ordernumber|orderdate|agentname|companyname|firstpartnumber", "|");
                case "orddet":
                case "orddet_rfq":
                case "orddet_service":
                case "orddet_quote":
                case "orddet_sales":
                case "orddet_purchase":
                case "orddet_invoice":
                case "orddet_rma":
                case "orddet_vendrma":
                    return nTools.SplitArray("isselected|fullpartnumber|quantityordered|manufacturer|datecode|description|unitprice", "|");
                case "partrecord":
                    return nTools.SplitArray("fullpartnumber|quantity|manufacturer|datecode|description|location|stocktype|companyname", "|");
                case "quote":
                    return nTools.SplitArray("quotetype|companyname|quotedate|fullpartnumber|quotequantity|quoteprice|manufacturer|datecode", "|");
                case "req":
                    return nTools.SplitArray("companyname|datecreated|fullpartnumber|targetquantity|targetprice|manufacturer|datecode", "|");
                case "company":
                    return nTools.SplitArray("companyname|agentname|primarycontact|primaryphone|primaryfax|primaryemailaddress|termsascustomer", "|");
                case "companycontact":
                    return nTools.SplitArray("companyname|contactname|agentname|primaryphone|primaryfax|primaryemailaddress", "|");
                default:
                    return base.GetMainProperties(strClass);
            }
        }
        public override ArrayList GetMainSearchProperties(String strClass)
        {
            switch (strClass.ToLower())
            {
                case "ordhed":
                    return nTools.SplitArray("ordernumber|orderdate|agentname|companyname|firstpartnumber", "|");
                case "orddet":
                    return nTools.SplitArray("isselected|fullpartnumber|quantityordered|manufacturer|datecode|description|unitprice", "|");
                case "partrecord":
                    return nTools.SplitArray("fullpartnumber|quantity|manufacturer|datecode|description|location|boxnum|boxcode|stocktype|companyname|condition|category|lotnumber", "|");
                case "quote":
                    return nTools.SplitArray("quotetype|companyname|quotedate|fullpartnumber|quotequantity|quoteprice|manufacturer|datecode", "|");
                case "req":
                    return nTools.SplitArray("companyname|datecreated|fullpartnumber|targetquantity|targetprice|manufacturer|datecode", "|");
                case "company":
                    return nTools.SplitArray("companyname|agentname|primarycontact|primaryphone|primaryfax|primaryemailaddress|termsascustomer", "|");
                case "companycontact":
                    return nTools.SplitArray("companyname|contactname|agentname|primaryphone|primaryfax|primaryemailaddress", "|");
                default:
                    return base.GetMainProperties(strClass);
            }
        }

        
        public CoreVarValAttribute GetPropByName(ContextRz x, string class_name, string prop_name)
        {
            CoreClassHandle cl = null;
            try
            {
                cl = x.TheSys.CoreClassGet(class_name);
            }
            catch { return null; }
            return cl.VarValGet(prop_name);
        }
        protected override void ActInstance(Context context, ActArgs args)
        {
            String classId = args.ClassIdSingleOrBlank(context);

            switch (classId.Trim().ToLower())
            {
                case "ordhed_quote":
                    TheQuoteLogic.ActInstance((ContextRz)context, args);
                    return;
                case "orddet_quote":
                    TheQuoteLogic.ActDetail((ContextRz)context, args);
                    return;
                case "orddet_line":
                    TheLineLogic.ActInstance((ContextRz)context, args);
                    return;
                //KT 4-6-2016 - Handle Proper deleting of service lines - removing cost form orddet_line, etc.
                case "service_line":
                    TheServiceLogic.ActInstance((ContextRz)context, args);
                    break;
                case "calllog":
                    TheCompanyLogic.ActInstanceCallLog((ContextRz)context, args);
                    break;
                case "contactnote":
                    TheCompanyLogic.ActInstanceContactNote((ContextRz)context, args);
                    break;
                case "companyaddress":
                    TheCompanyLogic.ActInstanceCompanyAddress((ContextRz)context, args);
                    break;
                case "shippingaccount":
                    TheCompanyLogic.ActInstanceShippingAccount((ContextRz)context, args);
                    break;
                case "company":
                    TheCompanyLogic.ActInstance((ContextRz)context, args);
                    return;
                case "partrecord":
                    ThePartLogic.ActInstance((ContextRz)context, args);
                    break;
                //case "n_set":
                //    TheSettingLogic.ActionHandle(context, args);
                //    break;
                case "companycontact":
                    TheCompanyLogic.ActContact((ContextRz)context, args);
                    break;
                case "label_queue":
                    TheLabelLogic.ActInstance((ContextRz)context, args);
                    break;
                case "ordhed":
                    TheOrderLogic.ActInstance((ContextRz)context, args);
                    break;
                case "orddet":
                    TheLineLogic.ActDetail((ContextRz)context, args);
                    break;
                case "phonecall":
                    ThePhoneLogic.ActInstance((ContextRz)context, args);
                    break;
                case "usernote":
                    TheUserLogicRz.ActInstance((ContextRz)context, args);
                    break;
            }

            if (args.Handled)
                return;

            if (classId.ToLower().Trim().StartsWith("ordhed_"))
            {
                TheOrderLogic.ActInstance((ContextRz)context, args);
                if (args.Handled)
                    return;
            }
            if (classId.ToLower().Trim().StartsWith("orddet_"))
            {
                TheLineLogic.ActDetail((ContextRz)context, args);
                if (args.Handled)
                    return;
            }
            //KT
            if (classId.ToLower().Trim() == "profit_deduction")
            {
                TheProfitLogic.ActInstance((ContextRz)context, args);
                return;
            }
            base.ActInstance(context, args);
        }
        public virtual void UpdateFields(ContextRz context)
        {
            try
            {
                context.Execute("alter table partrecord modify location varchar(255)");
            }
            catch { }
        }
        public virtual void UpdateChoices(ContextRz context)
        {
            try
            {
                n_choices c = n_choices.GetByName(context, "all_states");
                if (c == null)
                    CreateAllStatesChoices(context);
                c = n_choices.GetByName(context, "all_countries");
                if (c == null)
                    CreateAllCountriesChoices(context);
            }
            catch { }
        }
        private void CreateAllStatesChoices(ContextRz context)
        {
            n_choices ch = n_choices.New(context);
            ch.name = "all_states";
            context.Insert(ch);
            long count = 0;
            string[] states = Tools.Strings.Split("AL|AK|AS|AZ|AR|CA|CO|CT|DC|DE|FL|FM|GA|GU|HI|IA|ID|IL|IN|KS|KY|LA|MD|MA|ME|MH|MI|MN|MP|MS|MO|MT|NC|ND|NE|NH|NJ|NM|NV|NY|OH|OK|OR|PA|PR|RI|SC|SD|TN|TX|UT|VA|VI|VT|WA|WI|WV|WY", "|");
            foreach (string s in states)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                n_choice c = n_choice.New(context);
                c.name = s;
                c.the_n_choices_order = count;
                count++;
                c.the_n_choices_uid = ch.unique_id;
                context.Insert(c);
            }
        }
        private void CreateAllCountriesChoices(ContextRz context)
        {
            n_choices ch = n_choices.New(context);
            ch.name = "all_countries";
            context.Insert(ch);
            long count = 0;
            string[] countries = Tools.Strings.Split("United States|Canada|Afghanistan|Albania|Algeria|Andorra|Angola|Antigua|Argentina|Armenia|Australia|Austria|Azerbaijan|Bahamas|Bahrain|Bangladesh|Barbados|Belarus|Belgium|Belize|Benin|Bhutan|Bolivia|Bosnia|Botswana|Brazil|Brunei|Bulgaria|Burkina Faso|Burundi|Cambodia|Cameroon|Canada|Cape Verde|Chad|Chile|China|Colombia|Comoros|Congo|Costa Rica|Côte dIvoire|Croatia|Cuba|Cyprus|Czech Republic|Denmark|Djibouti|Dominica|Dominican Republic|East Timor|Ecuador|Egypt|El Salvador|Equatorial Guinea|Eritrea|Estonia|Ethiopia|Fiji|Finland|France|Gabon|Gambia, The|Georgia|Germany|Ghana|Greece|Grenada|Guatemala|Guinea|GuineaBissau|Guyana|Haiti|Honduras|Hungary|Iceland|India|Indonesia|Iran|Iraq|Ireland|Israel|Italy|Jamaica|Japan|Jordan|Kazakhstan|Kenya|Kiribati|Korea, North|Korea, South|Kuwait|Kyrgyzstan|Laos|Latvia|Lebanon|Lesotho|Liberia|Libya|Liechtenstein|Lithuania|Luxembourg|Macedonia|Madagascar|Malawi|Malaysia|Maldives|Mali|Malta|Marshall Islands|Mauritania|Mauritius|Mexico|Micronesia|Moldova|Monaco|Mongolia|Montenegro|Morocco|Mozambique|Myanmar Burma|Namibia|Nauru|Nepal|Netherlands|New Zealand|Nicaragua|Niger|Nigeria|Norway|Oman|Pakistan|Palau|Panama|Papua New Guinea|Paraguay|Peru|Philippines|Poland|Portugal|Qatar|Romania|Russia|Rwanda|Saint Kitts|Saint Lucia|Saint Vincent|Samoa|San Marino|Sao Tome|Saudi Arabia|Senegal|Serbia|Seychelles|Sierra Leone|Singapore|Slovakia|Slovenia|Solomon Islands|Somalia|South Africa|Spain|Sri Lanka|Sudan|Suriname|Swaziland|Sweden|Switzerland|Syria|Taiwan|Tajikistan|Tanzania|Thailand|Togo|Tonga|Trinidad and Tobago|Tunisia|Turkey|Turkmenistan|Tuvalu|Uganda|Ukraine|United Arab Emirates|United Kingdom|United States|Uruguay|Uzbekistan|Vanuatu|Vatican City|Venezuela|Vietnam|Western Sahara|Yemen|Zambia|Zimbabwe", "|");
            foreach (string s in countries)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                n_choice c = n_choice.New(context);
                c.name = s;
                c.the_n_choices_order = count;
                count++;
                c.the_n_choices_uid = ch.unique_id;
                context.Insert(c);
            }
        }
        //Start Logics
        EmailLogic m_EmailLogic;
        public EmailLogic TheEmailLogic
        {
            get
            {
                if (m_EmailLogic == null)
                    m_EmailLogic = EmailLogicCreate();
                return m_EmailLogic;
            }
        }
        protected virtual EmailLogic EmailLogicCreate()
        {
            return new EmailLogic();
        }
        CompanyLogic m_CompanyLogic;
        public CompanyLogic TheCompanyLogic
        {
            get
            {
                if (m_CompanyLogic == null)
                    m_CompanyLogic = CompanyLogicCreate();
                return m_CompanyLogic;
            }
        }
        protected virtual CompanyLogic CompanyLogicCreate()
        {
            return new CompanyLogic();
        }
        PhoneLogic m_PhoneLogic;
        public PhoneLogic ThePhoneLogic
        {
            get
            {
                if (m_PhoneLogic == null)
                    m_PhoneLogic = PhoneLogicCreate();
                return m_PhoneLogic;
            }
        }
        protected virtual PhoneLogic PhoneLogicCreate()
        {
            return new PhoneLogic();
        }
        HomeLogic m_HomeLogic;
        public HomeLogic TheHomeLogic
        {
            get
            {
                if (m_HomeLogic == null)
                    m_HomeLogic = HomeLogicCreate();
                return m_HomeLogic;
            }
        }
        protected virtual HomeLogic HomeLogicCreate()
        {
            return new HomeLogic();
        }
        OrderLogic m_OrderLogic;
        public OrderLogic TheOrderLogic
        {
            get
            {
                if (m_OrderLogic == null)
                    m_OrderLogic = OrderLogicCreate();
                return m_OrderLogic;
            }
        }
        protected virtual OrderLogic OrderLogicCreate()
        {
            return new OrderLogic();
        }
        protected override Core.ItemLogic ItemLogicCreate()
        {
            //return base.ItemLogicCreate();
            return new Rz5.ItemLogic();
        }
        LineLogic m_LineLogic;
        public LineLogic TheLineLogic
        {
            get
            {
                if (m_LineLogic == null)
                    m_LineLogic = LineLogicCreate();
                return m_LineLogic;
            }
        }
        protected virtual LineLogic LineLogicCreate()
        {
            return new LineLogic();
        }
        protected override NewMethod.PermitLogic PermitLogicCreate()
        {
            return new Rz5.PermitLogic();
        }
        //protected override NewMethod.ListViewLogic ListViewLogicCreate()
        //{
        //    return new Rz4.ListViewLogic();
        //}
        PanelLogic m_PanelLogic;
        public PanelLogic ThePanelLogic
        {
            get
            {
                if (m_PanelLogic == null)
                    m_PanelLogic = PanelLogicCreate();
                return m_PanelLogic;
            }
        }

        ReportLogic m_ReportLogic;
        public ReportLogic TheReportLogic
        {
            get
            {
                if (m_ReportLogic == null)
                    m_ReportLogic = ReportLogicCreate();
                return m_ReportLogic;
            }
        }

        protected virtual ReportLogic ReportLogicCreate()
        {
            return new ReportLogic();
        }

        protected virtual PanelLogic PanelLogicCreate()
        {
            return new PanelLogic();
        }
        PrintLogic m_PrintLogic;
        public PrintLogic ThePrintLogic
        {
            get
            {
                if (m_PrintLogic == null)
                    m_PrintLogic = PrintLogicCreate();
                return m_PrintLogic;
            }
        }
        protected virtual PrintLogic PrintLogicCreate()
        {
            return new PrintLogic();
        }
        DutyLogic m_TheDutyLogic = null;
        public DutyLogic TheDutyLogic
        {
            get
            {
                if (m_TheDutyLogic == null)
                    m_TheDutyLogic = DutyLogicCreate();
                return m_TheDutyLogic;
            }
        }
        protected virtual DutyLogic DutyLogicCreate()
        {
            return new DutyLogic();
        }



        //public override ProofLogic ProofCreate()
        //{
        //    return new ProofLogicRz();
        //}

        ToolsLogic m_TheToolsLogic = null;
        public ToolsLogic TheToolsLogic
        {
            get
            {
                if (m_TheToolsLogic == null)
                    m_TheToolsLogic = ToolsLogicCreate();

                return m_TheToolsLogic;
            }

            set
            {
                m_TheToolsLogic = value;
            }
        }
        public virtual ToolsLogic ToolsLogicCreate()
        {
            return new ToolsLogic();
        }
        ReqLogic m_ReqLogic = null;
        public ReqLogic TheReqLogic
        {
            get
            {
                if (m_ReqLogic == null)
                    m_ReqLogic = ReqLogicCreate();

                return m_ReqLogic;
            }

            set
            {
                m_ReqLogic = value;
            }
        }
        public virtual ReqLogic ReqLogicCreate()
        {
            return new ReqLogic();
        }
        PartLogic m_PartLogic = null;
        public PartLogic ThePartLogic
        {
            get
            {
                if (m_PartLogic == null)
                    m_PartLogic = PartLogicCreate();

                return m_PartLogic;
            }

            set
            {
                m_PartLogic = value;
            }
        }
        public virtual PartLogic PartLogicCreate()
        {
            return new PartLogic();
        }
        ProfitLogic m_ProfitLogic = null;
        public ProfitLogic TheProfitLogic
        {
            get
            {
                if (m_ProfitLogic == null)
                    m_ProfitLogic = ProfitLogicCreate();

                return m_ProfitLogic;
            }

            set
            {
                m_ProfitLogic = value;
            }
        }
        public virtual ProfitLogic ProfitLogicCreate()
        {
            return new ProfitLogic();
        }
        QuoteLogic m_QuoteLogic = null;
        public QuoteLogic TheQuoteLogic
        {
            get
            {
                if (m_QuoteLogic == null)
                    m_QuoteLogic = QuoteLogicCreate();

                return m_QuoteLogic;
            }

            set
            {
                m_QuoteLogic = value;
            }
        }
        public virtual QuoteLogic QuoteLogicCreate()
        {
            return new QuoteLogic();
        }
        PaymentLogic m_PaymentLogic = null;
        public PaymentLogic ThePaymentLogic
        {
            get
            {
                if (m_PaymentLogic == null)
                    m_PaymentLogic = PaymentLogicCreate();

                return m_PaymentLogic;
            }

            set
            {
                m_PaymentLogic = value;
            }
        }
        public virtual PaymentLogic PaymentLogicCreate()
        {
            return new PaymentLogic();
        }
        InvoiceLogic m_InvoiceLogic = null;
        public InvoiceLogic TheInvoiceLogic
        {
            get
            {
                if (m_InvoiceLogic == null)
                    m_InvoiceLogic = InvoiceLogicCreate();

                return m_InvoiceLogic;
            }

            set
            {
                m_InvoiceLogic = value;
            }
        }
        public virtual InvoiceLogic InvoiceLogicCreate()
        {
            return new InvoiceLogic();
        }
        SalesLogic m_SalesLogic = null;
        public SalesLogic TheSalesLogic
        {
            get
            {
                if (m_SalesLogic == null)
                    m_SalesLogic = SalesLogicCreate();

                return m_SalesLogic;
            }

            set
            {
                m_SalesLogic = value;
            }
        }
        public virtual SalesLogic SalesLogicCreate()
        {
            return new SalesLogic();
        }
        public override NewMethod.UserLogic UserLogicCreate()
        {
            return new UserLogic();
        }
        UrlLogic m_UrlLogic = null;
        public UrlLogic TheUrlLogic
        {
            get
            {
                if (m_UrlLogic == null)
                    m_UrlLogic = UrlLogicCreate();

                return m_UrlLogic;
            }

            set
            {
                m_UrlLogic = value;
            }
        }
        public virtual UrlLogic UrlLogicCreate()
        {
            return new UrlLogic();
        }
        ServiceLogic m_ServiceLogic = null;
        public ServiceLogic TheServiceLogic
        {
            get
            {
                if (m_ServiceLogic == null)
                    m_ServiceLogic = ServiceLogicCreate();

                return m_ServiceLogic;
            }

            set
            {
                m_ServiceLogic = value;
            }
        }
        public virtual ServiceLogic ServiceLogicCreate()
        {
            return new ServiceLogic();
        }
        ImportLogic m_ImportLogic = null;
        public ImportLogic TheImportLogic
        {
            get
            {
                if (m_ImportLogic == null)
                    m_ImportLogic = ImportLogicCreate();

                return m_ImportLogic;
            }

            set
            {
                m_ImportLogic = value;
            }
        }

        protected virtual ImportLogic ImportLogicCreate()
        {
            return new ImportLogic();
        }

        AccountLogic m_AccountLogic = null;
        public AccountLogic TheAccountLogic
        {
            get
            {
                if (m_AccountLogic == null)
                    m_AccountLogic = AccountLogicCreate();

                return m_AccountLogic;
            }

            set
            {
                m_AccountLogic = value;
            }
        }


        //Refactored from SysSensible 12-5-2018
        protected virtual AccountLogic AccountLogicCreate()
        {
            //Temp workaround to disable accounting for the old system
            //and keep enabled for the test system.

            //KT - Commented Out to Allow Payments in Test System. 10-7-2014
            AccountLogic a = new AccountLogic();
            //if (!NMWin.ContextDefault.Data.DatabaseName.ToLower().EndsWith("_test"))
            a.Enabled = false;
            return a;
        }

        QuickBooksLogic m_QuickBooksLogic;
        public QuickBooksLogic TheQuickBooksLogic
        {
            get
            {
                if (m_QuickBooksLogic == null)
                    m_QuickBooksLogic = QuickBooksLogicCreate();
                return m_QuickBooksLogic;
            }
        }
        protected virtual QuickBooksLogic QuickBooksLogicCreate()
        {
            return new QuickBooksLogic();
        }
        public Rz5.PermitLogic ThePermitLogicRz
        {
            get
            {
                return (Rz5.PermitLogic)ThePermitLogic;
            }
        }
        LinkLogic m_TheLinkLogic;
        public LinkLogic TheLinkLogic
        {
            get
            {
                if (m_TheLinkLogic == null)
                    m_TheLinkLogic = LinkLogicCreate();
                return m_TheLinkLogic;
            }
        }
        LinkLogic LinkLogicCreate()
        {
            return new LinkLogic();
        }
        LabelLogic m_LabelLogic;
        public LabelLogic TheLabelLogic
        {
            get
            {
                if (m_LabelLogic == null)
                    m_LabelLogic = LabelLogicCreate();
                return m_LabelLogic;
            }
        }
        protected virtual LabelLogic LabelLogicCreate()
        {
            return new LabelLogic();
        }
        public Rz5.UserLogic TheUserLogicRz
        {
            get
            {
                return (Rz5.UserLogic)TheUserLogic;
            }
        }
  

        public override Assembly AssemblyGetHere()
        {
            return Assembly.GetExecutingAssembly();
        }
        protected override void AssemblyList(List<Assembly> ret)
        {
            ret.Add(Assembly.GetExecutingAssembly());
            base.AssemblyList(ret);
        }
        public override void ActsListStatic(Context x, ActSetup set)
        {
            ActsListRz(x, set);
            base.ActsListStatic(x, set);
        }
        protected virtual void ActsListRz(Context x, ActSetup acts)
        {
            ContextRz xrz = (ContextRz)x;

            ThePartLogic.ActsListStatic(x, acts);
            TheCompanyLogic.ActsListStatic(x, acts);
            TheHomeLogic.ActsListStatic(x, acts);
            TheOrderLogic.ActsListStatic(x, acts);
            TheOrderLogic.ActsListShipping(xrz, acts);
            TheEmailLogic.ActsListStatic(x, acts);
            ThePaymentLogic.ActsListStatic(x, acts);
            TheImportLogic.ActsListStatic(x, acts);
            TheAccountLogic.ActsListStatic(x, acts);
            TheReportLogic.ActsListStatic(x, acts);
            ThePanelLogic.ActsListStatic(x, acts);
            TheToolsLogic.ActsListStatic(x, acts);
        }
        public override String CaptionGet(Context x)
        {
            ContextRz xrz = (ContextRz)x;
            int version = RzIndex;
            if (xrz.Accounts.Enabled)
                version = 5;
            return "Rz" + version.ToString() + " <" + Tools.Misc.GetVersionString(Tools.ToolsNM.AssemblyNM) + "> " + xrz.xUser.login_name.ToUpper() + " - " + xrz.TheData.TheConnection.TheKey.ServerName + xrz.xUser.CurrentPermitModeCaption;   //" + RzLicense.LicenseType.ToString() + "
        }

        new public RzLogic Logic
        {
            get
            {
                return (RzLogic)TheLogic;
            }

            set
            {
                this.TheLogic = value;
            }
        }

        new public ProofLogicRz ProofLogic
        {
            get
            {
                return (ProofLogicRz)base.ProofLogic;
            }
        }

        protected override ProofLogic ProofLogicCreate()
        {
            return new ProofLogicRz();
        }

    }
}
