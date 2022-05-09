using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("usernote")]
    public partial class usernote_auto : NewMethod.nObject
    {
        static usernote_auto()
        {
            Item.AttributesCache(typeof(usernote_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_ordhed_uid":
                    the_ordhed_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_company_uid":
                    base_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "for_mc_user_uid":
                    for_mc_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "by_mc_user_uid":
                    by_mc_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "notetext":
                    notetextAttribute = (CoreVarValAttribute)attr;
                    break;
                case "batchnumber":
                    batchnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "displaydate":
                    displaydateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "createdbyname":
                    createdbynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "createdforname":
                    createdfornameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isclosed":
                    isclosedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shouldpopup":
                    shouldpopupAttribute = (CoreVarValAttribute)attr;
                    break;
                case "dorecur":
                    dorecurAttribute = (CoreVarValAttribute)attr;
                    break;
                case "recurdata":
                    recurdataAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fullpartnumber":
                    fullpartnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "notetype":
                    notetypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_signoff":
                    is_signoffAttribute = (CoreVarValAttribute)attr;
                    break;
                case "subjectstring":
                    subjectstringAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_pending":
                    is_pendingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "extra_info":
                    extra_infoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "importance":
                    importanceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "company_uid":
                    company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "status_log":
                    status_logAttribute = (CoreVarValAttribute)attr;
                    break;
                case "current_status":
                    current_statusAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_companycontact_uid":
                    the_companycontact_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contactname":
                    contactnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "represent_class":
                    represent_classAttribute = (CoreVarValAttribute)attr;
                    break;
                case "represent_uid":
                    represent_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "child_info":
                    child_infoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_task":
                    is_taskAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_folder":
                    is_folderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "task_size":
                    task_sizeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "task_type":
                    task_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "attachment_count":
                    attachment_countAttribute = (CoreVarValAttribute)attr;
                    break;
                case "tags":
                    tagsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "tag_summary":
                    tag_summaryAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_status":
                    last_statusAttribute = (CoreVarValAttribute)attr;
                    break;
                case "request_priority":
                    request_priorityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "respond_priority":
                    respond_priorityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "request_reason":
                    request_reasonAttribute = (CoreVarValAttribute)attr;
                    break;
                case "respond_description":
                    respond_descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_ordhed_uidAttribute;
        static CoreVarValAttribute base_company_uidAttribute;
        static CoreVarValAttribute for_mc_user_uidAttribute;
        static CoreVarValAttribute by_mc_user_uidAttribute;
        static CoreVarValAttribute notetextAttribute;
        static CoreVarValAttribute batchnumberAttribute;
        static CoreVarValAttribute displaydateAttribute;
        static CoreVarValAttribute createdbynameAttribute;
        static CoreVarValAttribute createdfornameAttribute;
        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute isclosedAttribute;
        static CoreVarValAttribute shouldpopupAttribute;
        static CoreVarValAttribute dorecurAttribute;
        static CoreVarValAttribute recurdataAttribute;
        static CoreVarValAttribute fullpartnumberAttribute;
        static CoreVarValAttribute notetypeAttribute;
        static CoreVarValAttribute is_signoffAttribute;
        static CoreVarValAttribute subjectstringAttribute;
        static CoreVarValAttribute is_pendingAttribute;
        static CoreVarValAttribute extra_infoAttribute;
        static CoreVarValAttribute importanceAttribute;
        static CoreVarValAttribute company_uidAttribute;
        static CoreVarValAttribute status_logAttribute;
        static CoreVarValAttribute current_statusAttribute;
        static CoreVarValAttribute the_companycontact_uidAttribute;
        static CoreVarValAttribute contactnameAttribute;
        static CoreVarValAttribute represent_classAttribute;
        static CoreVarValAttribute represent_uidAttribute;
        static CoreVarValAttribute child_infoAttribute;
        static CoreVarValAttribute is_taskAttribute;
        static CoreVarValAttribute is_folderAttribute;
        static CoreVarValAttribute task_sizeAttribute;
        static CoreVarValAttribute task_typeAttribute;
        static CoreVarValAttribute attachment_countAttribute;
        static CoreVarValAttribute tagsAttribute;
        static CoreVarValAttribute tag_summaryAttribute;
        static CoreVarValAttribute last_statusAttribute;
        static CoreVarValAttribute request_priorityAttribute;
        static CoreVarValAttribute respond_priorityAttribute;
        static CoreVarValAttribute request_reasonAttribute;
        static CoreVarValAttribute respond_descriptionAttribute;

        [CoreVarVal("the_ordhed_uid", "String", TheFieldLength = 255, Caption="The Ordhed Uid", Importance = 1)]
        public VarString the_ordhed_uidVar;

        [CoreVarVal("base_company_uid", "String", TheFieldLength = 50, Caption="Base Company Id", Importance = 2)]
        public VarString base_company_uidVar;

        [CoreVarVal("for_mc_user_uid", "String", TheFieldLength = 50, Caption="User Id", Importance = 3)]
        public VarString for_mc_user_uidVar;

        [CoreVarVal("by_mc_user_uid", "String", TheFieldLength = 50, Caption="User Id", Importance = 4)]
        public VarString by_mc_user_uidVar;

        [CoreVarVal("notetext", "String", TheFieldLength = 4096, Caption="Note", Importance = 5)]
        public VarString notetextVar;

        [CoreVarVal("batchnumber", "String", TheFieldLength = 20, Caption="Batch Number", Importance = 6)]
        public VarString batchnumberVar;

        [CoreVarVal("displaydate", "DateTime", Caption="Display Date", Importance = 7)]
        public VarDateTime displaydateVar;

        [CoreVarVal("createdbyname", "String", TheFieldLength = 50, Caption="Created By", Importance = 8)]
        public VarString createdbynameVar;

        [CoreVarVal("createdforname", "String", TheFieldLength = 50, Caption="Created For", Importance = 9)]
        public VarString createdfornameVar;

        [CoreVarVal("companyname", "String", TheFieldLength = 50, Caption="Company Name", Importance = 10)]
        public VarString companynameVar;

        [CoreVarVal("isclosed", "Boolean", Caption="Is Closed", Importance = 11)]
        public VarBoolean isclosedVar;

        [CoreVarVal("shouldpopup", "Boolean", Caption="Pop Up", Importance = 12)]
        public VarBoolean shouldpopupVar;

        [CoreVarVal("dorecur", "Boolean", Caption="Recurring", Importance = 13)]
        public VarBoolean dorecurVar;

        [CoreVarVal("recurdata", "String", TheFieldLength = 50, Caption="Recur Data", Importance = 14)]
        public VarString recurdataVar;

        [CoreVarVal("fullpartnumber", "String", TheFieldLength = 255, Caption="Part Number", Importance = 15)]
        public VarString fullpartnumberVar;

        [CoreVarVal("notetype", "String", TheFieldLength = 50, Caption="Note Type", Importance = 16)]
        public VarString notetypeVar;

        [CoreVarVal("is_signoff", "Boolean", Caption="Is Signoff", Importance = 17)]
        public VarBoolean is_signoffVar;

        [CoreVarVal("subjectstring", "String", TheFieldLength = 255, Caption="Subject String", Importance = 18)]
        public VarString subjectstringVar;

        [CoreVarVal("is_pending", "Boolean", Caption="Pending", Importance = 19)]
        public VarBoolean is_pendingVar;

        [CoreVarVal("extra_info", "Text", Caption="Extra Info", Importance = 20)]
        public VarText extra_infoVar;

        [CoreVarVal("importance", "Int32", Caption="Importance", Importance = 21)]
        public VarInt32 importanceVar;

        [CoreVarVal("company_uid", "String", TheFieldLength = 255, Caption="Company Uid", Importance = 22)]
        public VarString company_uidVar;

        [CoreVarVal("status_log", "Text", Caption="Status Log", Importance = 23)]
        public VarText status_logVar;

        [CoreVarVal("current_status", "String", TheFieldLength = 255, Caption="Current Status", Importance = 24)]
        public VarString current_statusVar;

        [CoreVarVal("the_companycontact_uid", "String", TheFieldLength = 255, Caption="The Companycontact Uid", Importance = 25)]
        public VarString the_companycontact_uidVar;

        [CoreVarVal("contactname", "String", TheFieldLength = 255, Caption="Contactname", Importance = 26)]
        public VarString contactnameVar;

        [CoreVarVal("represent_class", "String", TheFieldLength = 255, Caption="Represent Class", Importance = 27)]
        public VarString represent_classVar;

        [CoreVarVal("represent_uid", "String", TheFieldLength = 255, Caption="Represent Uid", Importance = 28)]
        public VarString represent_uidVar;

        [CoreVarVal("child_info", "Text", Caption="Child Info", Importance = 29)]
        public VarText child_infoVar;

        [CoreVarVal("is_task", "Boolean", Caption="Is Task", Importance = 30)]
        public VarBoolean is_taskVar;

        [CoreVarVal("is_folder", "Boolean", Caption="Is Folder", Importance = 31)]
        public VarBoolean is_folderVar;

        [CoreVarVal("task_size", "String", TheFieldLength = 255, Caption="Task Size", Importance = 32)]
        public VarString task_sizeVar;

        [CoreVarVal("task_type", "String", TheFieldLength = 255, Caption="Task Type", Importance = 33)]
        public VarString task_typeVar;

        [CoreVarVal("attachment_count", "Int32", Caption="Attachment Count", Importance = 34)]
        public VarInt32 attachment_countVar;

        [CoreVarVal("tags", "String", TheFieldLength = 8000, Caption="Tags", Importance = 35)]
        public VarString tagsVar;

        [CoreVarVal("tag_summary", "String", TheFieldLength = 8000, Caption="Tag Summary", Importance = 36)]
        public VarString tag_summaryVar;

        [CoreVarVal("last_status", "String", TheFieldLength = 255, Caption="Last Status", Importance = 37)]
        public VarString last_statusVar;

        [CoreVarVal("request_priority", "String", TheFieldLength = 255, Caption="Request Priority", Importance = 38)]
        public VarString request_priorityVar;

        [CoreVarVal("respond_priority", "String", TheFieldLength = 255, Caption="Respond Priority", Importance = 39)]
        public VarString respond_priorityVar;

        [CoreVarVal("request_reason", "Text", Caption="Request Reason", Importance = 40)]
        public VarText request_reasonVar;

        [CoreVarVal("respond_description", "Text", Caption="Respond Description", Importance = 41)]
        public VarText respond_descriptionVar;

        public usernote_auto()
        {
            StaticInit();
            the_ordhed_uidVar = new VarString(this, the_ordhed_uidAttribute);
            base_company_uidVar = new VarString(this, base_company_uidAttribute);
            for_mc_user_uidVar = new VarString(this, for_mc_user_uidAttribute);
            by_mc_user_uidVar = new VarString(this, by_mc_user_uidAttribute);
            notetextVar = new VarString(this, notetextAttribute);
            batchnumberVar = new VarString(this, batchnumberAttribute);
            displaydateVar = new VarDateTime(this, displaydateAttribute);
            createdbynameVar = new VarString(this, createdbynameAttribute);
            createdfornameVar = new VarString(this, createdfornameAttribute);
            companynameVar = new VarString(this, companynameAttribute);
            isclosedVar = new VarBoolean(this, isclosedAttribute);
            shouldpopupVar = new VarBoolean(this, shouldpopupAttribute);
            dorecurVar = new VarBoolean(this, dorecurAttribute);
            recurdataVar = new VarString(this, recurdataAttribute);
            fullpartnumberVar = new VarString(this, fullpartnumberAttribute);
            notetypeVar = new VarString(this, notetypeAttribute);
            is_signoffVar = new VarBoolean(this, is_signoffAttribute);
            subjectstringVar = new VarString(this, subjectstringAttribute);
            is_pendingVar = new VarBoolean(this, is_pendingAttribute);
            extra_infoVar = new VarText(this, extra_infoAttribute);
            importanceVar = new VarInt32(this, importanceAttribute);
            company_uidVar = new VarString(this, company_uidAttribute);
            status_logVar = new VarText(this, status_logAttribute);
            current_statusVar = new VarString(this, current_statusAttribute);
            the_companycontact_uidVar = new VarString(this, the_companycontact_uidAttribute);
            contactnameVar = new VarString(this, contactnameAttribute);
            represent_classVar = new VarString(this, represent_classAttribute);
            represent_uidVar = new VarString(this, represent_uidAttribute);
            child_infoVar = new VarText(this, child_infoAttribute);
            is_taskVar = new VarBoolean(this, is_taskAttribute);
            is_folderVar = new VarBoolean(this, is_folderAttribute);
            task_sizeVar = new VarString(this, task_sizeAttribute);
            task_typeVar = new VarString(this, task_typeAttribute);
            attachment_countVar = new VarInt32(this, attachment_countAttribute);
            tagsVar = new VarString(this, tagsAttribute);
            tag_summaryVar = new VarString(this, tag_summaryAttribute);
            last_statusVar = new VarString(this, last_statusAttribute);
            request_priorityVar = new VarString(this, request_priorityAttribute);
            respond_priorityVar = new VarString(this, respond_priorityAttribute);
            request_reasonVar = new VarText(this, request_reasonAttribute);
            respond_descriptionVar = new VarText(this, respond_descriptionAttribute);
        }

        public override string ClassId
        { get { return "usernote"; } }

        public String the_ordhed_uid
        {
            get  { return (String)the_ordhed_uidVar.Value; }
            set  { the_ordhed_uidVar.Value = value; }
        }

        public String base_company_uid
        {
            get  { return (String)base_company_uidVar.Value; }
            set  { base_company_uidVar.Value = value; }
        }

        public String for_mc_user_uid
        {
            get  { return (String)for_mc_user_uidVar.Value; }
            set  { for_mc_user_uidVar.Value = value; }
        }

        public String by_mc_user_uid
        {
            get  { return (String)by_mc_user_uidVar.Value; }
            set  { by_mc_user_uidVar.Value = value; }
        }

        public String notetext
        {
            get  { return (String)notetextVar.Value; }
            set  { notetextVar.Value = value; }
        }

        public String batchnumber
        {
            get  { return (String)batchnumberVar.Value; }
            set  { batchnumberVar.Value = value; }
        }

        public DateTime displaydate
        {
            get  { return (DateTime)displaydateVar.Value; }
            set  { displaydateVar.Value = value; }
        }

        public String createdbyname
        {
            get  { return (String)createdbynameVar.Value; }
            set  { createdbynameVar.Value = value; }
        }

        public String createdforname
        {
            get  { return (String)createdfornameVar.Value; }
            set  { createdfornameVar.Value = value; }
        }

        public String companyname
        {
            get  { return (String)companynameVar.Value; }
            set  { companynameVar.Value = value; }
        }

        public Boolean isclosed
        {
            get  { return (Boolean)isclosedVar.Value; }
            set  { isclosedVar.Value = value; }
        }

        public Boolean shouldpopup
        {
            get  { return (Boolean)shouldpopupVar.Value; }
            set  { shouldpopupVar.Value = value; }
        }

        public Boolean dorecur
        {
            get  { return (Boolean)dorecurVar.Value; }
            set  { dorecurVar.Value = value; }
        }

        public String recurdata
        {
            get  { return (String)recurdataVar.Value; }
            set  { recurdataVar.Value = value; }
        }

        public String fullpartnumber
        {
            get  { return (String)fullpartnumberVar.Value; }
            set  { fullpartnumberVar.Value = value; }
        }

        public String notetype
        {
            get  { return (String)notetypeVar.Value; }
            set  { notetypeVar.Value = value; }
        }

        public Boolean is_signoff
        {
            get  { return (Boolean)is_signoffVar.Value; }
            set  { is_signoffVar.Value = value; }
        }

        public String subjectstring
        {
            get  { return (String)subjectstringVar.Value; }
            set  { subjectstringVar.Value = value; }
        }

        public Boolean is_pending
        {
            get  { return (Boolean)is_pendingVar.Value; }
            set  { is_pendingVar.Value = value; }
        }

        public String extra_info
        {
            get  { return (String)extra_infoVar.Value; }
            set  { extra_infoVar.Value = value; }
        }

        public Int32 importance
        {
            get  { return (Int32)importanceVar.Value; }
            set  { importanceVar.Value = value; }
        }

        public String company_uid
        {
            get  { return (String)company_uidVar.Value; }
            set  { company_uidVar.Value = value; }
        }

        public String status_log
        {
            get  { return (String)status_logVar.Value; }
            set  { status_logVar.Value = value; }
        }

        public String current_status
        {
            get  { return (String)current_statusVar.Value; }
            set  { current_statusVar.Value = value; }
        }

        public String the_companycontact_uid
        {
            get  { return (String)the_companycontact_uidVar.Value; }
            set  { the_companycontact_uidVar.Value = value; }
        }

        public String contactname
        {
            get  { return (String)contactnameVar.Value; }
            set  { contactnameVar.Value = value; }
        }

        public String represent_class
        {
            get  { return (String)represent_classVar.Value; }
            set  { represent_classVar.Value = value; }
        }

        public String represent_uid
        {
            get  { return (String)represent_uidVar.Value; }
            set  { represent_uidVar.Value = value; }
        }

        public String child_info
        {
            get  { return (String)child_infoVar.Value; }
            set  { child_infoVar.Value = value; }
        }

        public Boolean is_task
        {
            get  { return (Boolean)is_taskVar.Value; }
            set  { is_taskVar.Value = value; }
        }

        public Boolean is_folder
        {
            get  { return (Boolean)is_folderVar.Value; }
            set  { is_folderVar.Value = value; }
        }

        public String task_size
        {
            get  { return (String)task_sizeVar.Value; }
            set  { task_sizeVar.Value = value; }
        }

        public String task_type
        {
            get  { return (String)task_typeVar.Value; }
            set  { task_typeVar.Value = value; }
        }

        public Int32 attachment_count
        {
            get  { return (Int32)attachment_countVar.Value; }
            set  { attachment_countVar.Value = value; }
        }

        public String tags
        {
            get  { return (String)tagsVar.Value; }
            set  { tagsVar.Value = value; }
        }

        public String tag_summary
        {
            get  { return (String)tag_summaryVar.Value; }
            set  { tag_summaryVar.Value = value; }
        }

        public String last_status
        {
            get  { return (String)last_statusVar.Value; }
            set  { last_statusVar.Value = value; }
        }

        public String request_priority
        {
            get  { return (String)request_priorityVar.Value; }
            set  { request_priorityVar.Value = value; }
        }

        public String respond_priority
        {
            get  { return (String)respond_priorityVar.Value; }
            set  { respond_priorityVar.Value = value; }
        }

        public String request_reason
        {
            get  { return (String)request_reasonVar.Value; }
            set  { request_reasonVar.Value = value; }
        }

        public String respond_description
        {
            get  { return (String)respond_descriptionVar.Value; }
            set  { respond_descriptionVar.Value = value; }
        }

    }
    public partial class usernote
    {
        public static usernote New(Context x)
        {  return (usernote)x.Item("usernote"); }

        public static usernote GetById(Context x, String uid)
        { return (usernote)x.GetById("usernote", uid); }

        public static usernote QtO(Context x, String sql)
        { return (usernote)x.QtO("usernote", sql); }
    }
}
