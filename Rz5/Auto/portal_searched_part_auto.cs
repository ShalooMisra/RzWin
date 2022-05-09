using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("portal_searched_part")]
    public partial class portal_searched_part_auto : NewMethod.nObject
    {
        static portal_searched_part_auto()
        {
            Item.AttributesCache(typeof(portal_searched_part_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }
        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {

                case "userID":
                    userIDAttribute = (CoreVarValAttribute)attr;
                    break;
                case "userName":
                    userNameAttribute = (CoreVarValAttribute)attr;
                    break;

                case "fullpartnumber":
                    fullpartnumberAttribute = (CoreVarValAttribute)attr;
                    break;

                case "manufacturer":
                    manufacturerAttribute = (CoreVarValAttribute)attr;
                    break;

                case "company_uid":
                    company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;

                case "contactname":
                    contactnameAttribute = (CoreVarValAttribute)attr;
                    break;

                case "contact_uid":
                    contact_uidAttribute = (CoreVarValAttribute)attr;
                    break;

                case "quantity":
                    quantityAttribute = (CoreVarValAttribute)attr;
                    break;

                case "notes":
                    notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quote_requested":
                    quote_requestedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_internal":
                    is_internalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "searchcount":
                    searchcountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_search_date":
                    last_search_dateAttribute = (CoreVarValAttribute)attr;
                    break;

                    





            }
        }

        static CoreVarValAttribute userIDAttribute;
        static CoreVarValAttribute userNameAttribute;
        static CoreVarValAttribute fullpartnumberAttribute;
        static CoreVarValAttribute manufacturerAttribute;
        static CoreVarValAttribute company_uidAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute contactnameAttribute;
        static CoreVarValAttribute contact_uidAttribute;
        static CoreVarValAttribute quantityAttribute;
        static CoreVarValAttribute notesAttribute;
        static CoreVarValAttribute quote_requestedAttribute;
        static CoreVarValAttribute is_internalAttribute;
        static CoreVarValAttribute searchcountAttribute;
        static CoreVarValAttribute last_search_dateAttribute;

       





        [CoreVarVal("userID", "String", TheFieldLength = 50, Caption = "userID", Importance = 1)]
        public VarString userIDVar;

        [CoreVarVal("userName", "String", TheFieldLength = 50, Caption = "userName", Importance = 2)]
        public VarString userNameVar;

        [CoreVarVal("fullpartnumber", "String", TheFieldLength = 100, Caption = "fullpartnumber", Importance = 3)]
        public VarString fullpartnumberVar;

        [CoreVarVal("manufacturer", "String", TheFieldLength = 50, Caption = "manufacturer", Importance = 4)]
        public VarString manufacturerVar;

        [CoreVarVal("company_uid", "String", TheFieldLength = 50, Caption = "company_uid", Importance = 5)]
        public VarString company_uidVar;

        [CoreVarVal("description", "String", TheFieldLength = 4096, Caption = "Description", Importance = 6)]
        public VarString descriptionVar;

        [CoreVarVal("companyname", "String", TheFieldLength = 50, Caption = "companyname", Importance = 7)]
        public VarString companynameVar;

        [CoreVarVal("contactname", "String", TheFieldLength = 50, Caption = "contactname", Importance = 8)]
        public VarString contactnameVar;

        [CoreVarVal("contact_uid", "String", TheFieldLength = 50, Caption = "contact_uid", Importance = 8)]
        public VarString contact_uidVar;

        [CoreVarVal("quantity", "Int32", TheFieldLength = 255, Caption = "quantity", Importance = 9)]
        public VarInt32 quantityVar;

        [CoreVarVal("notes", "String", TheFieldLength = 4096, Caption = "notes", Importance = 10)]
        public VarString notesVar;

        [CoreVarVal("quote_requested", "Boolean", Caption = "quote_requested", Importance = 11)]
        public VarBoolean quote_requestedVar;

        [CoreVarVal("is_internal", "Boolean", Caption = "is_internal", Importance = 12)]
        public VarBoolean is_internalVar;

        [CoreVarVal("searchcount", "Int32", TheFieldLength = 255, Caption = "searchcount", Importance = 13)]
        public VarInt32 searchcountVar;

        [CoreVarVal("last_search_date", "DateTime", Caption = "Last Search Date", Importance = 14)]
        public VarDateTime last_search_dateVar;

        
        public portal_searched_part_auto()
        {
            StaticInit();
            userIDVar = new VarString(this, userIDAttribute);
            userNameVar = new VarString(this, userNameAttribute);
            fullpartnumberVar = new VarString(this, fullpartnumberAttribute);
            manufacturerVar = new VarString(this, manufacturerAttribute);
            company_uidVar = new VarString(this, company_uidAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            companynameVar = new VarString(this, companynameAttribute);
            contactnameVar = new VarString(this, contactnameAttribute);
            contact_uidVar = new VarString(this, contact_uidAttribute);
            quantityVar = new VarInt32(this, quantityAttribute);
            notesVar = new VarString(this, notesAttribute);
            quote_requestedVar = new VarBoolean(this, quote_requestedAttribute);
            is_internalVar = new VarBoolean(this, is_internalAttribute);
            searchcountVar = new VarInt32(this, searchcountAttribute);
            last_search_dateVar = new VarDateTime(this, last_search_dateAttribute);

            
        }


        public override string ClassId
        { get { return "portal_searched_part"; } }

        public string userID
        {
            get { return (string)userIDVar.Value; }
            set { userIDVar.Value = value; }
        }

        public string userName
        {
            get { return (string)userNameVar.Value; }
            set { userNameVar.Value = value; }
        }

        public string base_ordhed_uid
        {
            get { return (string)fullpartnumberVar.Value; }
            set { fullpartnumberVar.Value = value; }
        }

        public string manufacturer
        {
            get { return (string)manufacturerVar.Value; }
            set { manufacturerVar.Value = value; }
        }

        public string company_uid
        {
            get { return (string)company_uidVar.Value; }
            set { company_uidVar.Value = value; }
        }

        public string description
        {
            get { return (string)descriptionVar.Value; }
            set { descriptionVar.Value = value; }
        }

        public string companyname
        {
            get { return (string)companynameVar.Value; }
            set { companynameVar.Value = value; }
        }

        public string contactname
        {
            get { return (string)contactnameVar.Value; }
            set { contactnameVar.Value = value; }
        }

        public string contact_uid
        {
            get { return (string)contact_uidVar.Value; }
            set { contact_uidVar.Value = value; }
        }
        
        public Int32 quantity
        {
            get { return (Int32)quantityVar.Value; }
            set { quantityVar.Value = value; }
        }

        public string notes
        {
            get { return (string)notesVar.Value; }
            set { notesVar.Value = value; }
        }

        public Boolean quote_requested
        {
            get { return (Boolean)quote_requestedVar.Value; }
            set { quote_requestedVar.Value = value; }
        }
     
        public Boolean is_internal
        {
            get { return (Boolean)is_internalVar.Value; }
            set { is_internalVar.Value = value; }
        }

        public Int32 searchcount
        {
            get { return (Int32)searchcountVar.Value; }
            set { searchcountVar.Value = value; }
        }

        public DateTime last_search_date
        {
            get { return (DateTime)last_search_dateVar.Value; }
            set { last_search_dateVar.Value = value; }
        }



        


    }
    public partial class portal_searched_part
    {
        public static portal_searched_part New(Context x)
        { return (portal_searched_part)x.Item("portal_searched_part"); }

        public static portal_searched_part GetById(Context x, String uid)
        { return (portal_searched_part)x.GetById("portal_searched_part", uid); }

        public static portal_searched_part QtO(Context x, String sql)
        { return (portal_searched_part)x.QtO("portal_searched_part", sql); }


    }
}
