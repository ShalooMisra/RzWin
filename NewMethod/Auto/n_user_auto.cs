using System;
using Core;

namespace NewMethod
{
    [CoreClass("n_user")]
    public partial class n_user_auto : NewMethod.nObject
    {
        static n_user_auto()
        {
            Item.AttributesCache(typeof(n_user_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_order_activity_uid":
                    the_order_activity_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_site_info_uid":
                    the_site_info_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "main_n_team_uid":
                    main_n_team_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "name":
                    nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "login_name":
                    login_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "login_password":
                    login_passwordAttribute = (CoreVarValAttribute)attr;
                    break;
                case "phone":
                    phoneAttribute = (CoreVarValAttribute)attr;
                    break;
                case "phone_ext":
                    phone_extAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_address":
                    email_addressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "user_code":
                    user_codeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "social_security":
                    social_securityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "user_initials":
                    user_initialsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "super_user":
                    super_userAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_signature":
                    email_signatureAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pop_server":
                    pop_serverAttribute = (CoreVarValAttribute)attr;
                    break;
                case "smtp_server":
                    smtp_serverAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_user":
                    email_userAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_password":
                    email_passwordAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fax_number":
                    fax_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternate_name":
                    alternate_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternate_phone":
                    alternate_phoneAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternate_email":
                    alternate_emailAttribute = (CoreVarValAttribute)attr;
                    break;
                case "current_location":
                    current_locationAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_inactive":
                    is_inactiveAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_segregated":
                    is_segregatedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "version_offset":
                    version_offsetAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternate_initials":
                    alternate_initialsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "permit_type":
                    permit_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "template_editor":
                    template_editorAttribute = (CoreVarValAttribute)attr;
                    break;
                case "job_desc":
                    job_descAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_server_login":
                    is_server_loginAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_agentname":
                    qb_agentnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_away":
                    is_awayAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_activity":
                    last_activityAttribute = (CoreVarValAttribute)attr;
                    break;
                //case "basice_tengrandprofit":
                //    basice_tengrandprofitAttribute = (CoreVarValAttribute)attr;
                //    break;
                case "showonprofit_report":
                    showonprofit_reportAttribute = (CoreVarValAttribute)attr;
                    break;
                case "latest_version":
                    latest_versionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "internal_phonenumber":
                    internal_phonenumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "internal_phonenumber_stripped":
                    internal_phonenumber_strippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_order_activity_order":
                    the_order_activity_orderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_signature_alt":
                    email_signature_altAttribute = (CoreVarValAttribute)attr;
                    break;
                case "machine_primary":
                    machine_primaryAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cell_number":
                    cell_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cell_carrier":
                    cell_carrierAttribute = (CoreVarValAttribute)attr;
                    break;
                case "allow_list_export":
                    allow_list_exportAttribute = (CoreVarValAttribute)attr;
                    break;
                case "assistant_to_uid":
                    assistant_to_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "assistant_to_name":
                    assistant_to_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "monthly_np_goal":
                    monthly_np_goalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "monthly_quote_goal":
                    monthly_quote_goalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "monthly_booking_goal":
                    monthly_booking_goalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "monthly_invoiced_goal":
                    monthly_invoiced_goalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_client":
                    email_clientAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_hubspot_enabled":
                    is_hubspot_enabledAttribute = (CoreVarValAttribute)attr;
                    break;
                case "show_on_sales_screen":
                    show_on_sales_screenAttribute = (CoreVarValAttribute)attr;
                    break;
                case "leaderboard_image_url":
                    leaderboard_image_urlAttribute = (CoreVarValAttribute)attr;
                    break;
                case "leaderboard_text":
                    leaderboard_textAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_salesrep_listID":
                    qb_salesrep_listIDAttribute = (CoreVarValAttribute)attr;
                    break;

                case "password_hash":
                    password_hashAttribute = (CoreVarValAttribute)attr;
                    break;

                case "password_salt":
                    password_saltAttribute = (CoreVarValAttribute)attr;
                    break;

                case "is_house_account":
                    is_house_accountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_activity_hidden":
                    is_activity_hiddenAttribute = (CoreVarValAttribute)attr;
                    break;
                //case "is_warehouse":
                //    is_warehouseAttribute = (CoreVarValAttribute)attr;
                //    break;
                //case "is_sales":
                //    is_salesAttribute = (CoreVarValAttribute)attr;
                //    break;
                case "is_accounting":
                    is_accountingAttribute = (CoreVarValAttribute)attr;
                    break;
                //case "main_location":
                //    main_locationAttribute = (CoreVarValAttribute)attr;
                //    break;
                case "is_quoter":
                    is_quoterAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sales_assistant":
                    sales_assistantAttribute = (CoreVarValAttribute)attr;
                    break;
                case "commission_percent":
                    commission_percentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "commission_bogey":
                    commission_bogeyAttribute = (CoreVarValAttribute)attr;
                    break;

            }
        }

        static CoreVarValAttribute the_order_activity_uidAttribute;
        static CoreVarValAttribute the_site_info_uidAttribute;
        static CoreVarValAttribute main_n_team_uidAttribute;
        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute login_nameAttribute;
        static CoreVarValAttribute login_passwordAttribute;
        static CoreVarValAttribute phoneAttribute;
        static CoreVarValAttribute phone_extAttribute;
        static CoreVarValAttribute email_addressAttribute;
        static CoreVarValAttribute user_codeAttribute;
        static CoreVarValAttribute social_securityAttribute;
        static CoreVarValAttribute user_initialsAttribute;
        static CoreVarValAttribute super_userAttribute;
        static CoreVarValAttribute email_signatureAttribute;
        static CoreVarValAttribute pop_serverAttribute;
        static CoreVarValAttribute smtp_serverAttribute;
        static CoreVarValAttribute email_userAttribute;
        static CoreVarValAttribute email_passwordAttribute;
        static CoreVarValAttribute fax_numberAttribute;
        static CoreVarValAttribute alternate_nameAttribute;
        static CoreVarValAttribute alternate_phoneAttribute;
        static CoreVarValAttribute alternate_emailAttribute;
        static CoreVarValAttribute current_locationAttribute;
        static CoreVarValAttribute is_inactiveAttribute;
        static CoreVarValAttribute is_segregatedAttribute;
        static CoreVarValAttribute version_offsetAttribute;
        static CoreVarValAttribute alternate_initialsAttribute;
        static CoreVarValAttribute permit_typeAttribute;
        static CoreVarValAttribute template_editorAttribute;
        static CoreVarValAttribute job_descAttribute;
        static CoreVarValAttribute is_server_loginAttribute;
        static CoreVarValAttribute qb_agentnameAttribute;
        static CoreVarValAttribute is_awayAttribute;
        static CoreVarValAttribute last_activityAttribute;
        //static CoreVarValAttribute basice_tengrandprofitAttribute;
        static CoreVarValAttribute showonprofit_reportAttribute;
        static CoreVarValAttribute latest_versionAttribute;
        static CoreVarValAttribute internal_phonenumberAttribute;
        static CoreVarValAttribute internal_phonenumber_strippedAttribute;
        static CoreVarValAttribute the_order_activity_orderAttribute;
        static CoreVarValAttribute email_signature_altAttribute;
        static CoreVarValAttribute machine_primaryAttribute;
        static CoreVarValAttribute cell_numberAttribute;
        static CoreVarValAttribute cell_carrierAttribute;
        static CoreVarValAttribute allow_list_exportAttribute;
        static CoreVarValAttribute assistant_to_uidAttribute;
        static CoreVarValAttribute assistant_to_nameAttribute;
        static CoreVarValAttribute monthly_np_goalAttribute;
        static CoreVarValAttribute monthly_quote_goalAttribute;
        static CoreVarValAttribute monthly_booking_goalAttribute;
        static CoreVarValAttribute monthly_invoiced_goalAttribute;
        static CoreVarValAttribute email_clientAttribute;
        static CoreVarValAttribute is_hubspot_enabledAttribute;
        static CoreVarValAttribute show_on_sales_screenAttribute;
        static CoreVarValAttribute leaderboard_image_urlAttribute;
        static CoreVarValAttribute leaderboard_textAttribute;
        static CoreVarValAttribute qb_salesrep_listIDAttribute;
        static CoreVarValAttribute password_hashAttribute;
        static CoreVarValAttribute password_saltAttribute;
        static CoreVarValAttribute is_house_accountAttribute;
        static CoreVarValAttribute is_activity_hiddenAttribute;
        //static CoreVarValAttribute is_warehouseAttribute;
        //static CoreVarValAttribute is_salesAttribute;
        static CoreVarValAttribute is_accountingAttribute;
        //static CoreVarValAttribute main_locationAttribute;
        static CoreVarValAttribute is_quoterAttribute;
        static CoreVarValAttribute sales_assistantAttribute;
        static CoreVarValAttribute commission_percentAttribute;
        static CoreVarValAttribute commission_bogeyAttribute;


        [CoreVarVal("the_order_activity_uid", "String", TheFieldLength = 255, Caption = "The Order Activity Uid", Importance = -3)]
        public VarString the_order_activity_uidVar;

        [CoreVarVal("the_site_info_uid", "String", TheFieldLength = 255, Caption = "The Site Info Uid", Importance = -2)]
        public VarString the_site_info_uidVar;

        [CoreVarVal("main_n_team_uid", "String", Caption = "Main N Team Uid")]
        public VarString main_n_team_uidVar;

        [CoreVarVal("name", "String", TheFieldLength = 255, Caption = "Name", Importance = 1)]
        public VarString nameVar;

        [CoreVarVal("login_name", "String", TheFieldLength = 255, Caption = "Login Name", Importance = 2)]
        public VarString login_nameVar;

        [CoreVarVal("login_password", "String", TheFieldLength = 255, Caption = "Login Password", Importance = 3)]
        public VarString login_passwordVar;

        [CoreVarVal("phone", "String", TheFieldLength = 255, Caption = "Phone", Importance = 4)]
        public VarString phoneVar;

        [CoreVarVal("phone_ext", "String", TheFieldLength = 255, Caption = "Phone Ext", Importance = 5)]
        public VarString phone_extVar;

        [CoreVarVal("email_address", "String", TheFieldLength = 255, Caption = "Email Address", Importance = 6)]
        public VarString email_addressVar;

        [CoreVarVal("user_code", "String", TheFieldLength = 255, Caption = "User Code", Importance = 7)]
        public VarString user_codeVar;

        [CoreVarVal("social_security", "String", TheFieldLength = 255, Caption = "Social Security", Importance = 8)]
        public VarString social_securityVar;

        [CoreVarVal("user_initials", "String", TheFieldLength = 255, Caption = "User Initials", Importance = 9)]
        public VarString user_initialsVar;

        [CoreVarVal("super_user", "Boolean", Caption = "Super User", Importance = 10)]
        public VarBoolean super_userVar;

        [CoreVarVal("email_signature", "Text", Caption = "Email Signature", Importance = 11)]
        public VarText email_signatureVar;

        [CoreVarVal("pop_server", "String", TheFieldLength = 255, Caption = "Pop Server", Importance = 12)]
        public VarString pop_serverVar;

        [CoreVarVal("smtp_server", "String", TheFieldLength = 255, Caption = "Smtp Server", Importance = 13)]
        public VarString smtp_serverVar;

        [CoreVarVal("email_user", "String", TheFieldLength = 255, Caption = "Email User", Importance = 14)]
        public VarString email_userVar;

        [CoreVarVal("email_password", "String", TheFieldLength = 255, Caption = "Email Password", Importance = 15)]
        public VarString email_passwordVar;

        [CoreVarVal("fax_number", "String", TheFieldLength = 255, Caption = "Fax Number", Importance = 16)]
        public VarString fax_numberVar;

        [CoreVarVal("alternate_name", "String", TheFieldLength = 255, Caption = "Alternate Name", Importance = 17)]
        public VarString alternate_nameVar;

        [CoreVarVal("alternate_phone", "String", TheFieldLength = 255, Caption = "Alternate Phone", Importance = 18)]
        public VarString alternate_phoneVar;

        [CoreVarVal("alternate_email", "String", TheFieldLength = 255, Caption = "Alternate Email", Importance = 19)]
        public VarString alternate_emailVar;

        [CoreVarVal("current_location", "String", TheFieldLength = 255, Caption = "Current Location", Importance = 20)]
        public VarString current_locationVar;

        [CoreVarVal("is_inactive", "Boolean", Caption = "Is Inactive", Importance = 21)]
        public VarBoolean is_inactiveVar;

        [CoreVarVal("is_segregated", "Boolean", Caption = "Is Segregated", Importance = 22)]
        public VarBoolean is_segregatedVar;

        [CoreVarVal("version_offset", "Int32", Caption = "Version Offset", Importance = 23)]
        public VarInt32 version_offsetVar;

        [CoreVarVal("alternate_initials", "String", TheFieldLength = 255, Caption = "Alternate Initials", Importance = 24)]
        public VarString alternate_initialsVar;

        [CoreVarVal("permit_type", "String", TheFieldLength = 255, Caption = "Permit Type", Importance = 25)]
        public VarString permit_typeVar;

        [CoreVarVal("template_editor", "Boolean", Caption = "Template Editor", Importance = 26)]
        public VarBoolean template_editorVar;

        [CoreVarVal("job_desc", "Text", Caption = "Job Desc", Importance = 27)]
        public VarText job_descVar;

        [CoreVarVal("is_server_login", "Boolean", Caption = "Is Server Login", Importance = 28)]
        public VarBoolean is_server_loginVar;

        [CoreVarVal("qb_agentname", "String", TheFieldLength = 255, Caption = "Qb Agentname", Importance = 29)]
        public VarString qb_agentnameVar;

        [CoreVarVal("is_away", "Boolean", Caption = "Is Away", Importance = 30)]
        public VarBoolean is_awayVar;

        [CoreVarVal("last_activity", "DateTime", Caption = "Last Activity", Importance = 31)]
        public VarDateTime last_activityVar;

        //[CoreVarVal("basice_tengrandprofit", "Boolean", Caption = "Basice Tengrandprofit", Importance = 32)]
        //public VarBoolean basice_tengrandprofitVar;

        [CoreVarVal("showonprofit_report", "Boolean", Caption = "Showonprofit Report", Importance = 33)]
        public VarBoolean showonprofit_reportVar;

        [CoreVarVal("latest_version", "String", TheFieldLength = 255, Caption = "Latest Version", Importance = 34)]
        public VarString latest_versionVar;

        [CoreVarVal("internal_phonenumber", "String", TheFieldLength = 255, Caption = "Internal Phone Number", Importance = 36)]
        public VarString internal_phonenumberVar;

        [CoreVarVal("internal_phonenumber_stripped", "String", TheFieldLength = 255, Caption = "Internal Phonenumber Stripped", Importance = 37)]
        public VarString internal_phonenumber_strippedVar;

        [CoreVarVal("the_order_activity_order", "Int64", Caption = "The Order Activity Order", Importance = 38)]
        public VarInt64 the_order_activity_orderVar;

        [CoreVarVal("email_signature_alt", "Text", Caption = "Email Signature Alt", Importance = 39)]
        public VarText email_signature_altVar;

        [CoreVarVal("machine_primary", "String", TheFieldLength = 255, Caption = "Machine Primary", Importance = 40)]
        public VarString machine_primaryVar;

        [CoreVarVal("cell_number", "String", TheFieldLength = 255, Caption = "Cell Number", Importance = 41)]
        public VarString cell_numberVar;

        [CoreVarVal("cell_carrier", "String", TheFieldLength = 255, Caption = "Cell Carrier", Importance = 42)]
        public VarString cell_carrierVar;

        [CoreVarVal("allow_list_export", "Boolean", Caption = "Allow List Export", Importance = 43)]
        public VarBoolean allow_list_exportVar;

        [CoreVarVal("assistant_to_uid", "String", TheFieldLength = 255, Caption = "Assistant to UID", Importance = 44)]
        public VarString assistant_to_uidVar;

        [CoreVarVal("assistant_to_name", "String", TheFieldLength = 255, Caption = "Assistant to Name", Importance = 45)]
        public VarString assistant_to_nameVar;

        [CoreVarVal("monthly_np_goal", "Double", Caption = "Monthly NP Goal", Importance = 46)]
        public VarDouble monthly_np_goalVar;

        [CoreVarVal("monthly_quote_goal", "Double", Caption = "monthly_quote_goal", Importance = 47)]
        public VarDouble monthly_quote_goalVar;

        [CoreVarVal("monthly_booking_goal", "Double", Caption = "monthly_booking_goal", Importance = 48)]
        public VarDouble monthly_booking_goalVar;

        [CoreVarVal("monthly_invoiced_goal", "Double", Caption = "monthly_invoiced_goal", Importance = 49)]
        public VarDouble monthly_invoiced_goalVar;

        [CoreVarVal("email_client", "String", TheFieldLength = 255, Caption = "Preferred Email Client", Importance = 50)]
        public VarString email_clientVar;

        [CoreVarVal("is_hubspot_enabled", "Boolean", Caption = "Is this user using Hubspot?", Importance = 51)]
        public VarBoolean is_hubspot_enabledVar;

        [CoreVarVal("show_on_sales_screen", "Boolean", Caption = "Show the user on the sales whiteboard", Importance = 52)]
        public VarBoolean show_on_sales_screenVar;

        [CoreVarVal("leaderboard_image_url", "String", TheFieldLength = 255, Caption = "Leaderboard Image URL", Importance = 50)]
        public VarString leaderboard_image_urlVar;

        [CoreVarVal("leaderboard_text", "String", TheFieldLength = 255, Caption = "Leaderboard Text", Importance = 51)]
        public VarString leaderboard_textVar;

        [CoreVarVal("qb_salesrep_listID", "String", TheFieldLength = 255, Caption = "Quickbooks Sales Rep ListID (Foreign Key)", Importance = 52)]
        public VarString qb_salesrep_listIDVar;

        [CoreVarVal("password_hash", "String", TheFieldLength = 255, Caption = "Password Hash", Importance = 53)]
        public VarString password_hashVar;

        [CoreVarVal("password_salt", "String", TheFieldLength = 255, Caption = "Password Salt", Importance = 54)]
        public VarString password_saltVar;

        [CoreVarVal("is_house_account", "Boolean", Caption = "Is House Account", Importance = 1)]
        public VarBoolean is_house_accountVar;

        [CoreVarVal("is_activity_hidden", "Boolean", Caption = "Is Activity Hidden", Importance = 2)]
        public VarBoolean is_activity_hiddenVar;

        //[CoreVarVal("is_warehouse", "Boolean", Caption = "Is Warehouse", Importance = 3)]
        //public VarBoolean is_warehouseVar;

        //[CoreVarVal("is_sales", "Boolean", Caption = "Is Sales", Importance = 4)]
        //public VarBoolean is_salesVar;

        [CoreVarVal("is_accounting", "Boolean", Caption = "Is Accounting", Importance = 5)]
        public VarBoolean is_accountingVar;

        //[CoreVarVal("main_location", "String", TheFieldLength = 255, Caption = "Main Location", Importance = 6)]
        //public VarString main_locationVar;

        [CoreVarVal("is_quoter", "Boolean", Caption = "Is Quoter", Importance = 7)]
        public VarBoolean is_quoterVar;

        [CoreVarVal("sales_assistant", "Boolean", Caption = "Sales Assistant", Importance = 8)]
        public VarBoolean sales_assistantVar;

        [CoreVarVal("commission_percent", "Double", Caption = "Commission Percent", Importance = 9)]
        public VarDouble commission_percentVar;

        [CoreVarVal("commission_bogey", "Double", Caption = "Commission Bogey", Importance = 10)]
        public VarDouble commission_bogeyVar;




        public n_user_auto()
        {
            StaticInit();
            the_order_activity_uidVar = new VarString(this, the_order_activity_uidAttribute);
            the_site_info_uidVar = new VarString(this, the_site_info_uidAttribute);
            main_n_team_uidVar = new VarString(this, main_n_team_uidAttribute);
            nameVar = new VarString(this, nameAttribute);
            login_nameVar = new VarString(this, login_nameAttribute);
            login_passwordVar = new VarString(this, login_passwordAttribute);
            phoneVar = new VarString(this, phoneAttribute);
            phone_extVar = new VarString(this, phone_extAttribute);
            email_addressVar = new VarString(this, email_addressAttribute);
            user_codeVar = new VarString(this, user_codeAttribute);
            social_securityVar = new VarString(this, social_securityAttribute);
            user_initialsVar = new VarString(this, user_initialsAttribute);
            super_userVar = new VarBoolean(this, super_userAttribute);
            email_signatureVar = new VarText(this, email_signatureAttribute);
            pop_serverVar = new VarString(this, pop_serverAttribute);
            smtp_serverVar = new VarString(this, smtp_serverAttribute);
            email_userVar = new VarString(this, email_userAttribute);
            email_passwordVar = new VarString(this, email_passwordAttribute);
            fax_numberVar = new VarString(this, fax_numberAttribute);
            alternate_nameVar = new VarString(this, alternate_nameAttribute);
            alternate_phoneVar = new VarString(this, alternate_phoneAttribute);
            alternate_emailVar = new VarString(this, alternate_emailAttribute);
            current_locationVar = new VarString(this, current_locationAttribute);
            is_inactiveVar = new VarBoolean(this, is_inactiveAttribute);
            is_segregatedVar = new VarBoolean(this, is_segregatedAttribute);
            version_offsetVar = new VarInt32(this, version_offsetAttribute);
            alternate_initialsVar = new VarString(this, alternate_initialsAttribute);
            permit_typeVar = new VarString(this, permit_typeAttribute);
            template_editorVar = new VarBoolean(this, template_editorAttribute);
            job_descVar = new VarText(this, job_descAttribute);
            is_server_loginVar = new VarBoolean(this, is_server_loginAttribute);
            qb_agentnameVar = new VarString(this, qb_agentnameAttribute);
            is_awayVar = new VarBoolean(this, is_awayAttribute);
            last_activityVar = new VarDateTime(this, last_activityAttribute);
            //basice_tengrandprofitVar = new VarBoolean(this, basice_tengrandprofitAttribute);
            showonprofit_reportVar = new VarBoolean(this, showonprofit_reportAttribute);
            latest_versionVar = new VarString(this, latest_versionAttribute);
            internal_phonenumberVar = new VarString(this, internal_phonenumberAttribute);
            internal_phonenumber_strippedVar = new VarString(this, internal_phonenumber_strippedAttribute);
            the_order_activity_orderVar = new VarInt64(this, the_order_activity_orderAttribute);
            email_signature_altVar = new VarText(this, email_signature_altAttribute);
            machine_primaryVar = new VarString(this, machine_primaryAttribute);
            cell_numberVar = new VarString(this, cell_numberAttribute);
            cell_carrierVar = new VarString(this, cell_carrierAttribute);
            allow_list_exportVar = new VarBoolean(this, allow_list_exportAttribute);
            assistant_to_uidVar = new VarString(this, assistant_to_uidAttribute);
            assistant_to_nameVar = new VarString(this, assistant_to_nameAttribute);
            monthly_np_goalVar = new VarDouble(this, monthly_np_goalAttribute);
            monthly_quote_goalVar = new VarDouble(this, monthly_quote_goalAttribute);
            monthly_booking_goalVar = new VarDouble(this, monthly_booking_goalAttribute);
            monthly_invoiced_goalVar = new VarDouble(this, monthly_invoiced_goalAttribute);
            email_clientVar = new VarString(this, email_clientAttribute);
            is_hubspot_enabledVar = new VarBoolean(this, is_hubspot_enabledAttribute);
            show_on_sales_screenVar = new VarBoolean(this, show_on_sales_screenAttribute);
            leaderboard_image_urlVar = new VarString(this, leaderboard_image_urlAttribute);
            leaderboard_textVar = new VarString(this, leaderboard_textAttribute);
            qb_salesrep_listIDVar = new VarString(this, qb_salesrep_listIDAttribute);
            password_hashVar = new VarString(this, password_hashAttribute);
            password_saltVar = new VarString(this, password_saltAttribute);

            is_house_accountVar = new VarBoolean(this, is_house_accountAttribute);
            is_activity_hiddenVar = new VarBoolean(this, is_activity_hiddenAttribute);
            //is_warehouseVar = new VarBoolean(this, ctl_main_locationAttribute);
            //is_salesVar = new VarBoolean(this, is_salesAttribute);
            is_accountingVar = new VarBoolean(this, is_accountingAttribute);
            //main_locationVar = new VarString(this, main_locationAttribute);
            is_quoterVar = new VarBoolean(this, is_quoterAttribute);
            sales_assistantVar = new VarBoolean(this, sales_assistantAttribute);
            commission_percentVar = new VarDouble(this, commission_percentAttribute);
            commission_bogeyVar = new VarDouble(this, commission_bogeyAttribute);


        }

        public override string ClassId
        { get { return "n_user"; } }

        public String the_order_activity_uid
        {
            get { return (String)the_order_activity_uidVar.Value; }
            set { the_order_activity_uidVar.Value = value; }
        }

        public String the_site_info_uid
        {
            get { return (String)the_site_info_uidVar.Value; }
            set { the_site_info_uidVar.Value = value; }
        }

        public String main_n_team_uid
        {
            get { return (String)main_n_team_uidVar.Value; }
            set { main_n_team_uidVar.Value = value; }
        }

        public String name
        {
            get { return (String)nameVar.Value; }
            set { nameVar.Value = value; }
        }

        public String login_name
        {
            get { return (String)login_nameVar.Value; }
            set { login_nameVar.Value = value; }
        }

        public String login_password
        {
            get { return (String)login_passwordVar.Value; }
            set { login_passwordVar.Value = value; }
        }

        public String phone
        {
            get { return (String)phoneVar.Value; }
            set { phoneVar.Value = value; }
        }

        public String phone_ext
        {
            get { return (String)phone_extVar.Value; }
            set { phone_extVar.Value = value; }
        }

        public String email_address
        {
            get { return (String)email_addressVar.Value; }
            set { email_addressVar.Value = value; }
        }

        public String user_code
        {
            get { return (String)user_codeVar.Value; }
            set { user_codeVar.Value = value; }
        }

        public String social_security
        {
            get { return (String)social_securityVar.Value; }
            set { social_securityVar.Value = value; }
        }

        public String user_initials
        {
            get { return (String)user_initialsVar.Value; }
            set { user_initialsVar.Value = value; }
        }

        public Boolean super_user
        {
            get { return (Boolean)super_userVar.Value; }
            set { super_userVar.Value = value; }
        }

        public String email_signature
        {
            get { return (String)email_signatureVar.Value; }
            set { email_signatureVar.Value = value; }
        }

        public String pop_server
        {
            get { return (String)pop_serverVar.Value; }
            set { pop_serverVar.Value = value; }
        }

        public String smtp_server
        {
            get { return (String)smtp_serverVar.Value; }
            set { smtp_serverVar.Value = value; }
        }

        public String email_user
        {
            get { return (String)email_userVar.Value; }
            set { email_userVar.Value = value; }
        }

        public String email_password
        {
            get { return (String)email_passwordVar.Value; }
            set { email_passwordVar.Value = value; }
        }

        public String fax_number
        {
            get { return (String)fax_numberVar.Value; }
            set { fax_numberVar.Value = value; }
        }

        public String alternate_name
        {
            get { return (String)alternate_nameVar.Value; }
            set { alternate_nameVar.Value = value; }
        }

        public String alternate_phone
        {
            get { return (String)alternate_phoneVar.Value; }
            set { alternate_phoneVar.Value = value; }
        }

        public String alternate_email
        {
            get { return (String)alternate_emailVar.Value; }
            set { alternate_emailVar.Value = value; }
        }

        public String current_location
        {
            get { return (String)current_locationVar.Value; }
            set { current_locationVar.Value = value; }
        }

        public Boolean is_inactive
        {
            get { return (Boolean)is_inactiveVar.Value; }
            set { is_inactiveVar.Value = value; }
        }

        public Boolean is_segregated
        {
            get { return (Boolean)is_segregatedVar.Value; }
            set { is_segregatedVar.Value = value; }
        }

        public Int32 version_offset
        {
            get { return (Int32)version_offsetVar.Value; }
            set { version_offsetVar.Value = value; }
        }

        public String alternate_initials
        {
            get { return (String)alternate_initialsVar.Value; }
            set { alternate_initialsVar.Value = value; }
        }

        public String permit_type
        {
            get { return (String)permit_typeVar.Value; }
            set { permit_typeVar.Value = value; }
        }

        public Boolean template_editor
        {
            get { return (Boolean)template_editorVar.Value; }
            set { template_editorVar.Value = value; }
        }

        public String job_desc
        {
            get { return (String)job_descVar.Value; }
            set { job_descVar.Value = value; }
        }

        public Boolean is_server_login
        {
            get { return (Boolean)is_server_loginVar.Value; }
            set { is_server_loginVar.Value = value; }
        }

        public String qb_agentname
        {
            get { return (String)qb_agentnameVar.Value; }
            set { qb_agentnameVar.Value = value; }
        }

        public Boolean is_away
        {
            get { return (Boolean)is_awayVar.Value; }
            set { is_awayVar.Value = value; }
        }

        public DateTime last_activity
        {
            get { return (DateTime)last_activityVar.Value; }
            set { last_activityVar.Value = value; }
        }

        //public Boolean basice_tengrandprofit
        //{
        //    get { return (Boolean)basice_tengrandprofitVar.Value; }
        //    set { basice_tengrandprofitVar.Value = value; }
        //}

        public Boolean showonprofit_report
        {
            get { return (Boolean)showonprofit_reportVar.Value; }
            set { showonprofit_reportVar.Value = value; }
        }

        public String latest_version
        {
            get { return (String)latest_versionVar.Value; }
            set { latest_versionVar.Value = value; }
        }

        public String internal_phonenumber
        {
            get { return (String)internal_phonenumberVar.Value; }
            set { internal_phonenumberVar.Value = value; }
        }

        public String internal_phonenumber_stripped
        {
            get { return (String)internal_phonenumber_strippedVar.Value; }
            set { internal_phonenumber_strippedVar.Value = value; }
        }

        public Int64 the_order_activity_order
        {
            get { return (Int64)the_order_activity_orderVar.Value; }
            set { the_order_activity_orderVar.Value = value; }
        }

        public String email_signature_alt
        {
            get { return (String)email_signature_altVar.Value; }
            set { email_signature_altVar.Value = value; }
        }

        public String machine_primary
        {
            get { return (String)machine_primaryVar.Value; }
            set { machine_primaryVar.Value = value; }
        }

        public String cell_number
        {
            get { return (String)cell_numberVar.Value; }
            set { cell_numberVar.Value = value; }
        }

        public String cell_carrier
        {
            get { return (String)cell_carrierVar.Value; }
            set { cell_carrierVar.Value = value; }
        }

        public Boolean allow_list_export
        {
            get { return (Boolean)allow_list_exportVar.Value; }
            set { allow_list_exportVar.Value = value; }
        }

        public String assistant_to_uid
        {
            get { return (String)assistant_to_uidVar.Value; }
            set { assistant_to_uidVar.Value = value; }
        }

        public String assistant_to_name
        {
            get { return (String)assistant_to_nameVar.Value; }
            set { assistant_to_nameVar.Value = value; }
        }
        public Double monthly_np_goal
        {
            get { return (Double)monthly_np_goalVar.Value; }
            set { monthly_np_goalVar.Value = value; }
        }

        public Double monthly_quote_goal
        {
            get { return (Double)monthly_quote_goalVar.Value; }
            set { monthly_quote_goalVar.Value = value; }
        }

        public Double monthly_booking_goal
        {
            get { return (Double)monthly_booking_goalVar.Value; }
            set { monthly_booking_goalVar.Value = value; }
        }

        public Double monthly_invoiced_goal
        {
            get { return (Double)monthly_invoiced_goalVar.Value; }
            set { monthly_invoiced_goalVar.Value = value; }
        }
        public String email_client
        {
            get { return (String)email_clientVar.Value; }
            set { email_clientVar.Value = value; }
        }
        public Boolean is_hubspot_enabled
        {
            get { return (Boolean)is_hubspot_enabledVar.Value; }
            set { is_hubspot_enabledVar.Value = value; }
        }
        public Boolean show_on_sales_screen
        {
            get { return (Boolean)show_on_sales_screenVar.Value; }
            set { show_on_sales_screenVar.Value = value; }
        }
        public String leaderboard_image_url
        {
            get { return (String)leaderboard_image_urlVar.Value; }
            set { leaderboard_image_urlVar.Value = value; }
        }

        public String leaderboard_text
        {
            get { return (String)leaderboard_textVar.Value; }
            set { leaderboard_textVar.Value = value; }
        }

        public String qb_salesrep_listID
        {
            get { return (String)qb_salesrep_listIDVar.Value; }
            set { qb_salesrep_listIDVar.Value = value; }
        }

        public String password_hash
        {
            get { return (String)password_hashVar.Value; }
            set { password_hashVar.Value = value; }
        }

        public String password_salt
        {
            get { return (String)password_saltVar.Value; }
            set { password_saltVar.Value = value; }
        }

        public Boolean is_house_account
        {
            get { return (Boolean)is_house_accountVar.Value; }
            set { is_house_accountVar.Value = value; }
        }

        public Boolean is_activity_hidden
        {
            get { return (Boolean)is_activity_hiddenVar.Value; }
            set { is_activity_hiddenVar.Value = value; }
        }

        //public Boolean is_warehouse
        //{
        //    get { return (Boolean)is_warehouseVar.Value; }
        //    set { is_warehouseVar.Value = value; }
        //}

        //public Boolean is_sales
        //{
        //    get { return (Boolean)is_salesVar.Value; }
        //    set { is_salesVar.Value = value; }
        //}

        public Boolean is_accounting
        {
            get { return (Boolean)is_accountingVar.Value; }
            set { is_accountingVar.Value = value; }
        }

        //public String main_location
        //{
        //    get { return (String)main_locationVar.Value; }
        //    set { main_locationVar.Value = value; }
        //}

        public Boolean is_quoter
        {
            get { return (Boolean)is_quoterVar.Value; }
            set { is_quoterVar.Value = value; }
        }

        public Boolean sales_assistant
        {
            get { return (Boolean)sales_assistantVar.Value; }
            set { sales_assistantVar.Value = value; }
        }

        public Double commission_percent
        {
            get { return (Double)commission_percentVar.Value; }
            set { commission_percentVar.Value = value; }
        }

        public Double commission_bogey
        {
            get { return (Double)commission_bogeyVar.Value; }
            set { commission_bogeyVar.Value = value; }
        }



    }
    public partial class n_user
    {
        public static n_user New(Context x)
        { return (n_user)x.Item("n_user"); }

        public static n_user GetById(Context x, String uid)
        { return (n_user)x.GetById("n_user", uid); }

        public static n_user QtO(Context x, String sql)
        { return (n_user)x.QtO("n_user", sql); }

        public static n_user GetByName(Context x, String name, String extraSql = "")
        { return (n_user)x.GetByName("n_user", name, extraSql); }


    }
}
