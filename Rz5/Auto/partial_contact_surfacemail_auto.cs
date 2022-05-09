using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("partial_contact_surfacemail")]
    public partial class partial_contact_surfacemail_auto : NewMethod.nObject
    {
        static partial_contact_surfacemail_auto()
        {
            Item.AttributesCache(typeof(partial_contact_surfacemail_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "primaryphone":
                    primaryphoneAttribute = (CoreVarValAttribute)attr;
                    break;
                case "primaryfax":
                    primaryfaxAttribute = (CoreVarValAttribute)attr;
                    break;
                case "primaryemailaddress":
                    primaryemailaddressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "line1":
                    line1Attribute = (CoreVarValAttribute)attr;
                    break;
                case "line2":
                    line2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "line3":
                    line3Attribute = (CoreVarValAttribute)attr;
                    break;
                case "adrcity":
                    adrcityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "adrstate":
                    adrstateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "adrzip":
                    adrzipAttribute = (CoreVarValAttribute)attr;
                    break;
                case "adrcountry":
                    adrcountryAttribute = (CoreVarValAttribute)attr;
                    break;
                case "source":
                    sourceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ip_address":
                    ip_addressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "notes":
                    notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "primaryurl":
                    primaryurlAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute primaryphoneAttribute;
        static CoreVarValAttribute primaryfaxAttribute;
        static CoreVarValAttribute primaryemailaddressAttribute;
        static CoreVarValAttribute line1Attribute;
        static CoreVarValAttribute line2Attribute;
        static CoreVarValAttribute line3Attribute;
        static CoreVarValAttribute adrcityAttribute;
        static CoreVarValAttribute adrstateAttribute;
        static CoreVarValAttribute adrzipAttribute;
        static CoreVarValAttribute adrcountryAttribute;
        static CoreVarValAttribute sourceAttribute;
        static CoreVarValAttribute ip_addressAttribute;
        static CoreVarValAttribute notesAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute primaryurlAttribute;

        [CoreVarVal("companyname", "String", TheFieldLength = 255, Caption="Companyname", Importance = 1)]
        public VarString companynameVar;

        [CoreVarVal("primaryphone", "String", TheFieldLength = 50, Caption="Primary Phone", Importance = 2)]
        public VarString primaryphoneVar;

        [CoreVarVal("primaryfax", "String", TheFieldLength = 50, Caption="Primary Fax", Importance = 3)]
        public VarString primaryfaxVar;

        [CoreVarVal("primaryemailaddress", "String", TheFieldLength = 50, Caption="Primary Email", Importance = 4)]
        public VarString primaryemailaddressVar;

        [CoreVarVal("line1", "String", TheFieldLength = 255, Caption="Line 1", Importance = 5)]
        public VarString line1Var;

        [CoreVarVal("line2", "String", TheFieldLength = 255, Caption="Line 2", Importance = 6)]
        public VarString line2Var;

        [CoreVarVal("line3", "String", TheFieldLength = 255, Caption="Line3", Importance = 7)]
        public VarString line3Var;

        [CoreVarVal("adrcity", "String", TheFieldLength = 255, Caption="City", Importance = 8)]
        public VarString adrcityVar;

        [CoreVarVal("adrstate", "String", TheFieldLength = 255, Caption="State", Importance = 9)]
        public VarString adrstateVar;

        [CoreVarVal("adrzip", "String", TheFieldLength = 255, Caption="Zip", Importance = 10)]
        public VarString adrzipVar;

        [CoreVarVal("adrcountry", "String", TheFieldLength = 255, Caption="Country", Importance = 11)]
        public VarString adrcountryVar;

        [CoreVarVal("source", "String", TheFieldLength = 255, Caption="Source", Importance = 12)]
        public VarString sourceVar;

        [CoreVarVal("ip_address", "String", TheFieldLength = 255, Caption="Ip Address", Importance = 13)]
        public VarString ip_addressVar;

        [CoreVarVal("notes", "String", TheFieldLength = 255, Caption="Notes", Importance = 14)]
        public VarString notesVar;

        [CoreVarVal("description", "String", TheFieldLength = 255, Caption="Description", Importance = 15)]
        public VarString descriptionVar;

        [CoreVarVal("primaryurl", "String", TheFieldLength = 255, Caption="Primaryurl", Importance = 16)]
        public VarString primaryurlVar;

        public partial_contact_surfacemail_auto()
        {
            StaticInit();
            companynameVar = new VarString(this, companynameAttribute);
            primaryphoneVar = new VarString(this, primaryphoneAttribute);
            primaryfaxVar = new VarString(this, primaryfaxAttribute);
            primaryemailaddressVar = new VarString(this, primaryemailaddressAttribute);
            line1Var = new VarString(this, line1Attribute);
            line2Var = new VarString(this, line2Attribute);
            line3Var = new VarString(this, line3Attribute);
            adrcityVar = new VarString(this, adrcityAttribute);
            adrstateVar = new VarString(this, adrstateAttribute);
            adrzipVar = new VarString(this, adrzipAttribute);
            adrcountryVar = new VarString(this, adrcountryAttribute);
            sourceVar = new VarString(this, sourceAttribute);
            ip_addressVar = new VarString(this, ip_addressAttribute);
            notesVar = new VarString(this, notesAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            primaryurlVar = new VarString(this, primaryurlAttribute);
        }

        public override string ClassId
        { get { return "partial_contact_surfacemail"; } }

        public String companyname
        {
            get  { return (String)companynameVar.Value; }
            set  { companynameVar.Value = value; }
        }

        public String primaryphone
        {
            get  { return (String)primaryphoneVar.Value; }
            set  { primaryphoneVar.Value = value; }
        }

        public String primaryfax
        {
            get  { return (String)primaryfaxVar.Value; }
            set  { primaryfaxVar.Value = value; }
        }

        public String primaryemailaddress
        {
            get  { return (String)primaryemailaddressVar.Value; }
            set  { primaryemailaddressVar.Value = value; }
        }

        public String line1
        {
            get  { return (String)line1Var.Value; }
            set  { line1Var.Value = value; }
        }

        public String line2
        {
            get  { return (String)line2Var.Value; }
            set  { line2Var.Value = value; }
        }

        public String line3
        {
            get  { return (String)line3Var.Value; }
            set  { line3Var.Value = value; }
        }

        public String adrcity
        {
            get  { return (String)adrcityVar.Value; }
            set  { adrcityVar.Value = value; }
        }

        public String adrstate
        {
            get  { return (String)adrstateVar.Value; }
            set  { adrstateVar.Value = value; }
        }

        public String adrzip
        {
            get  { return (String)adrzipVar.Value; }
            set  { adrzipVar.Value = value; }
        }

        public String adrcountry
        {
            get  { return (String)adrcountryVar.Value; }
            set  { adrcountryVar.Value = value; }
        }

        public String source
        {
            get  { return (String)sourceVar.Value; }
            set  { sourceVar.Value = value; }
        }

        public String ip_address
        {
            get  { return (String)ip_addressVar.Value; }
            set  { ip_addressVar.Value = value; }
        }

        public String notes
        {
            get  { return (String)notesVar.Value; }
            set  { notesVar.Value = value; }
        }

        public String description
        {
            get  { return (String)descriptionVar.Value; }
            set  { descriptionVar.Value = value; }
        }

        public String primaryurl
        {
            get  { return (String)primaryurlVar.Value; }
            set  { primaryurlVar.Value = value; }
        }

    }
    public partial class partial_contact_surfacemail
    {
        public static partial_contact_surfacemail New(Context x)
        {  return (partial_contact_surfacemail)x.Item("partial_contact_surfacemail"); }

        public static partial_contact_surfacemail GetById(Context x, String uid)
        { return (partial_contact_surfacemail)x.GetById("partial_contact_surfacemail", uid); }

        public static partial_contact_surfacemail QtO(Context x, String sql)
        { return (partial_contact_surfacemail)x.QtO("partial_contact_surfacemail", sql); }
    }
}
