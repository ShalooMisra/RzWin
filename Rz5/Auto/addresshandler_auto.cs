using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("addresshandler")]
    public partial class addresshandler_auto : NewMethod.nObject
    {
        static addresshandler_auto()
        {
            Item.AttributesCache(typeof(addresshandler_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "emailaddress":
                    emailaddressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "handlertags":
                    handlertagsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sourcedest":
                    sourcedestAttribute = (CoreVarValAttribute)attr;
                    break;
                case "scancompany":
                    scancompanyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "savecompany":
                    savecompanyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companymap":
                    companymapAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contactmap":
                    contactmapAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companystop":
                    companystopAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contactstop":
                    contactstopAttribute = (CoreVarValAttribute)attr;
                    break;
                case "phonemap":
                    phonemapAttribute = (CoreVarValAttribute)attr;
                    break;
                case "phonestop":
                    phonestopAttribute = (CoreVarValAttribute)attr;
                    break;
                case "faxmap":
                    faxmapAttribute = (CoreVarValAttribute)attr;
                    break;
                case "faxstop":
                    faxstopAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute emailaddressAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute handlertagsAttribute;
        static CoreVarValAttribute sourcedestAttribute;
        static CoreVarValAttribute scancompanyAttribute;
        static CoreVarValAttribute savecompanyAttribute;
        static CoreVarValAttribute companymapAttribute;
        static CoreVarValAttribute contactmapAttribute;
        static CoreVarValAttribute companystopAttribute;
        static CoreVarValAttribute contactstopAttribute;
        static CoreVarValAttribute phonemapAttribute;
        static CoreVarValAttribute phonestopAttribute;
        static CoreVarValAttribute faxmapAttribute;
        static CoreVarValAttribute faxstopAttribute;

        [CoreVarVal("emailaddress", "String", TheFieldLength = 255, Caption="Email Address", Importance = 1)]
        public VarString emailaddressVar;

        [CoreVarVal("description", "String", TheFieldLength = 50, Caption="Description", Importance = 2)]
        public VarString descriptionVar;

        [CoreVarVal("handlertags", "String", TheFieldLength = 50, Caption="Tags", Importance = 3)]
        public VarString handlertagsVar;

        [CoreVarVal("sourcedest", "String", TheFieldLength = 50, Caption="Source / Dest", Importance = 4)]
        public VarString sourcedestVar;

        [CoreVarVal("scancompany", "Boolean", Caption="Scan Company", Importance = 5)]
        public VarBoolean scancompanyVar;

        [CoreVarVal("savecompany", "Boolean", Caption="Save Company", Importance = 6)]
        public VarBoolean savecompanyVar;

        [CoreVarVal("companymap", "String", TheFieldLength = 4096, Caption="Company Map", Importance = 7)]
        public VarString companymapVar;

        [CoreVarVal("contactmap", "String", TheFieldLength = 4096, Caption="Contact Map", Importance = 8)]
        public VarString contactmapVar;

        [CoreVarVal("companystop", "String", TheFieldLength = 255, Caption="Company Stop", Importance = 9)]
        public VarString companystopVar;

        [CoreVarVal("contactstop", "String", TheFieldLength = 255, Caption="Contact Stop", Importance = 10)]
        public VarString contactstopVar;

        [CoreVarVal("phonemap", "String", TheFieldLength = 4096, Caption="Phone Map", Importance = 11)]
        public VarString phonemapVar;

        [CoreVarVal("phonestop", "String", TheFieldLength = 255, Caption="Phone Stop", Importance = 12)]
        public VarString phonestopVar;

        [CoreVarVal("faxmap", "String", TheFieldLength = 4096, Caption="Fax Map", Importance = 13)]
        public VarString faxmapVar;

        [CoreVarVal("faxstop", "String", TheFieldLength = 255, Caption="Fax Stop", Importance = 14)]
        public VarString faxstopVar;

        public addresshandler_auto()
        {
            StaticInit();
            emailaddressVar = new VarString(this, emailaddressAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            handlertagsVar = new VarString(this, handlertagsAttribute);
            sourcedestVar = new VarString(this, sourcedestAttribute);
            scancompanyVar = new VarBoolean(this, scancompanyAttribute);
            savecompanyVar = new VarBoolean(this, savecompanyAttribute);
            companymapVar = new VarString(this, companymapAttribute);
            contactmapVar = new VarString(this, contactmapAttribute);
            companystopVar = new VarString(this, companystopAttribute);
            contactstopVar = new VarString(this, contactstopAttribute);
            phonemapVar = new VarString(this, phonemapAttribute);
            phonestopVar = new VarString(this, phonestopAttribute);
            faxmapVar = new VarString(this, faxmapAttribute);
            faxstopVar = new VarString(this, faxstopAttribute);
        }

        public override string ClassId
        { get { return "addresshandler"; } }

        public String emailaddress
        {
            get  { return (String)emailaddressVar.Value; }
            set  { emailaddressVar.Value = value; }
        }

        public String description
        {
            get  { return (String)descriptionVar.Value; }
            set  { descriptionVar.Value = value; }
        }

        public String handlertags
        {
            get  { return (String)handlertagsVar.Value; }
            set  { handlertagsVar.Value = value; }
        }

        public String sourcedest
        {
            get  { return (String)sourcedestVar.Value; }
            set  { sourcedestVar.Value = value; }
        }

        public Boolean scancompany
        {
            get  { return (Boolean)scancompanyVar.Value; }
            set  { scancompanyVar.Value = value; }
        }

        public Boolean savecompany
        {
            get  { return (Boolean)savecompanyVar.Value; }
            set  { savecompanyVar.Value = value; }
        }

        public String companymap
        {
            get  { return (String)companymapVar.Value; }
            set  { companymapVar.Value = value; }
        }

        public String contactmap
        {
            get  { return (String)contactmapVar.Value; }
            set  { contactmapVar.Value = value; }
        }

        public String companystop
        {
            get  { return (String)companystopVar.Value; }
            set  { companystopVar.Value = value; }
        }

        public String contactstop
        {
            get  { return (String)contactstopVar.Value; }
            set  { contactstopVar.Value = value; }
        }

        public String phonemap
        {
            get  { return (String)phonemapVar.Value; }
            set  { phonemapVar.Value = value; }
        }

        public String phonestop
        {
            get  { return (String)phonestopVar.Value; }
            set  { phonestopVar.Value = value; }
        }

        public String faxmap
        {
            get  { return (String)faxmapVar.Value; }
            set  { faxmapVar.Value = value; }
        }

        public String faxstop
        {
            get  { return (String)faxstopVar.Value; }
            set  { faxstopVar.Value = value; }
        }

    }
    public partial class addresshandler
    {
        public static addresshandler New(Context x)
        {  return (addresshandler)x.Item("addresshandler"); }

        public static addresshandler GetById(Context x, String uid)
        { return (addresshandler)x.GetById("addresshandler", uid); }

        public static addresshandler QtO(Context x, String sql)
        { return (addresshandler)x.QtO("addresshandler", sql); }
    }
}
