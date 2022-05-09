using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("partpicture")]
    public partial class partpicture_auto : NewMethod.nObject
    {
        static partpicture_auto()
        {
            Item.AttributesCache(typeof(partpicture_auto), AttributeCache);
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
                case "the_companycontact_uid":
                    the_companycontact_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_orddet_uid":
                    the_orddet_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_company_uid":
                    the_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_qualitycontrol_uid":
                    the_qualitycontrol_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_partrecord_uid":
                    the_partrecord_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fullpartnumber":
                    fullpartnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "prefix":
                    prefixAttribute = (CoreVarValAttribute)attr;
                    break;
                case "basenumber":
                    basenumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "basenumberstripped":
                    basenumberstrippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contactname":
                    contactnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "filename":
                    filenameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "linktype":
                    linktypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "filetype":
                    filetypeAttribute = (CoreVarValAttribute)attr;
                    break;
                //case "is_cofc":
                //    is_cofcAttribute = (CoreVarValAttribute)attr;
                //    break;
                case "image_height":
                    image_heightAttribute = (CoreVarValAttribute)attr;
                    break;
                case "image_width":
                    image_widthAttribute = (CoreVarValAttribute)attr;
                    break;
                case "order_caption":
                    order_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "file_path":
                    file_pathAttribute = (CoreVarValAttribute)attr;
                    break;


            }
        }

        static CoreVarValAttribute the_ordhed_uidAttribute;
        static CoreVarValAttribute the_companycontact_uidAttribute;
        static CoreVarValAttribute the_orddet_uidAttribute;
        static CoreVarValAttribute the_company_uidAttribute;
        static CoreVarValAttribute the_qualitycontrol_uidAttribute;
        static CoreVarValAttribute the_partrecord_uidAttribute;
        static CoreVarValAttribute fullpartnumberAttribute;
        static CoreVarValAttribute prefixAttribute;
        static CoreVarValAttribute basenumberAttribute;
        static CoreVarValAttribute basenumberstrippedAttribute;
        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute contactnameAttribute;
        static CoreVarValAttribute filenameAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute linktypeAttribute;
        static CoreVarValAttribute filetypeAttribute;
        //static CoreVarValAttribute is_cofcAttribute;
        static CoreVarValAttribute image_heightAttribute;
        static CoreVarValAttribute image_widthAttribute;
        static CoreVarValAttribute order_captionAttribute;
        static CoreVarValAttribute file_pathAttribute;

        


        [CoreVarVal("the_ordhed_uid", "String", TheFieldLength = 255, Caption="The Ordhed Uid", Importance = 1)]
        public VarString the_ordhed_uidVar;

        [CoreVarVal("the_companycontact_uid", "String", TheFieldLength = 255, Caption="The Companycontact Uid", Importance = 2)]
        public VarString the_companycontact_uidVar;

        [CoreVarVal("the_orddet_uid", "String", TheFieldLength = 255, Caption="The Orddet Uid", Importance = 3)]
        public VarString the_orddet_uidVar;

        [CoreVarVal("the_company_uid", "String", TheFieldLength = 255, Caption="The Company Uid", Importance = 4)]
        public VarString the_company_uidVar;

        [CoreVarVal("the_qualitycontrol_uid", "String", TheFieldLength = 255, Caption="The Qualitycontrol Uid", Importance = 5)]
        public VarString the_qualitycontrol_uidVar;

        [CoreVarVal("the_partrecord_uid", "String", TheFieldLength = 255, Caption="The Partrecord Uid", Importance = 6)]
        public VarString the_partrecord_uidVar;

        [CoreVarVal("fullpartnumber", "String", TheFieldLength = 255, Caption="Full Partnumber", Importance = 7)]
        public VarString fullpartnumberVar;

        [CoreVarVal("prefix", "String", TheFieldLength = 255, Caption="Prefix", Importance = 8)]
        public VarString prefixVar;

        [CoreVarVal("basenumber", "String", TheFieldLength = 255, Caption="Base Number", Importance = 9)]
        public VarString basenumberVar;

        [CoreVarVal("basenumberstripped", "String", TheFieldLength = 255, Caption="Base Number Stripped", Importance = 10)]
        public VarString basenumberstrippedVar;

        [CoreVarVal("companyname", "String", TheFieldLength = 255, Caption="Company Name", Importance = 11)]
        public VarString companynameVar;

        [CoreVarVal("contactname", "String", TheFieldLength = 255, Caption="Contact Name", Importance = 12)]
        public VarString contactnameVar;

        [CoreVarVal("filename", "String", TheFieldLength = 255, Caption="File Name", Importance = 13)]
        public VarString filenameVar;

        [CoreVarVal("description", "String", TheFieldLength = 8000, Caption="Description", Importance = 14)]
        public VarString descriptionVar;

        [CoreVarVal("linktype", "String", TheFieldLength = 255, Caption="Link Type", Importance = 15)]
        public VarString linktypeVar;

        [CoreVarVal("filetype", "String", TheFieldLength = 255, Caption="File Type", Importance = 16)]
        public VarString filetypeVar;

        //[CoreVarVal("is_cofc", "sbyte", Caption="Is C Of C", Importance = 17)]
        //public VarByte is_cofcVar;

        [CoreVarVal("image_height", "Int32", Caption="Image Height", Importance = 19)]
        public VarInt32 image_heightVar;

        [CoreVarVal("image_width", "Int32", Caption="Image Width", Importance = 20)]
        public VarInt32 image_widthVar;

        [CoreVarVal("order_caption", "String", TheFieldLength = 255, Caption="Order Caption", Importance = 22)]
        public VarString order_captionVar;

        [CoreVarVal("file_path", "String", TheFieldLength = 255, Caption = "File Path", Importance = 23)]
        public VarString file_pathVar;
        



        public partpicture_auto()
        {
            StaticInit();
            the_ordhed_uidVar = new VarString(this, the_ordhed_uidAttribute);
            the_companycontact_uidVar = new VarString(this, the_companycontact_uidAttribute);
            the_orddet_uidVar = new VarString(this, the_orddet_uidAttribute);
            the_company_uidVar = new VarString(this, the_company_uidAttribute);
            the_qualitycontrol_uidVar = new VarString(this, the_qualitycontrol_uidAttribute);
            the_partrecord_uidVar = new VarString(this, the_partrecord_uidAttribute);
            fullpartnumberVar = new VarString(this, fullpartnumberAttribute);
            prefixVar = new VarString(this, prefixAttribute);
            basenumberVar = new VarString(this, basenumberAttribute);
            basenumberstrippedVar = new VarString(this, basenumberstrippedAttribute);
            companynameVar = new VarString(this, companynameAttribute);
            contactnameVar = new VarString(this, contactnameAttribute);
            filenameVar = new VarString(this, filenameAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            linktypeVar = new VarString(this, linktypeAttribute);
            filetypeVar = new VarString(this, filetypeAttribute);
            //is_cofcVar = new VarByte(this, is_cofcAttribute);
            image_heightVar = new VarInt32(this, image_heightAttribute);
            image_widthVar = new VarInt32(this, image_widthAttribute);
            order_captionVar = new VarString(this, order_captionAttribute);
            file_pathVar = new VarString(this, file_pathAttribute);

            



        }

        public override string ClassId
        { get { return "partpicture"; } }

        public String the_ordhed_uid
        {
            get  { return (String)the_ordhed_uidVar.Value; }
            set  { the_ordhed_uidVar.Value = value; }
        }

        public String the_companycontact_uid
        {
            get  { return (String)the_companycontact_uidVar.Value; }
            set  { the_companycontact_uidVar.Value = value; }
        }

        public String the_orddet_uid
        {
            get  { return (String)the_orddet_uidVar.Value; }
            set  { the_orddet_uidVar.Value = value; }
        }

        public String the_company_uid
        {
            get  { return (String)the_company_uidVar.Value; }
            set  { the_company_uidVar.Value = value; }
        }

        public String the_qualitycontrol_uid
        {
            get  { return (String)the_qualitycontrol_uidVar.Value; }
            set  { the_qualitycontrol_uidVar.Value = value; }
        }

        public String the_partrecord_uid
        {
            get  { return (String)the_partrecord_uidVar.Value; }
            set  { the_partrecord_uidVar.Value = value; }
        }

        public String fullpartnumber
        {
            get  { return (String)fullpartnumberVar.Value; }
            set  { fullpartnumberVar.Value = value; }
        }

        public String prefix
        {
            get  { return (String)prefixVar.Value; }
            set  { prefixVar.Value = value; }
        }

        public String basenumber
        {
            get  { return (String)basenumberVar.Value; }
            set  { basenumberVar.Value = value; }
        }

        public String basenumberstripped
        {
            get  { return (String)basenumberstrippedVar.Value; }
            set  { basenumberstrippedVar.Value = value; }
        }

        public String companyname
        {
            get  { return (String)companynameVar.Value; }
            set  { companynameVar.Value = value; }
        }

        public String contactname
        {
            get  { return (String)contactnameVar.Value; }
            set  { contactnameVar.Value = value; }
        }

        public String filename
        {
            get  { return (String)filenameVar.Value; }
            set  { filenameVar.Value = value; }
        }

        public String description
        {
            get  { return (String)descriptionVar.Value; }
            set  { descriptionVar.Value = value; }
        }

        public String linktype
        {
            get  { return (String)linktypeVar.Value; }
            set  { linktypeVar.Value = value; }
        }

        public String filetype
        {
            get  { return (String)filetypeVar.Value; }
            set  { filetypeVar.Value = value; }
        }

        //public sbyte is_cofc
        //{
        //    get  { return (sbyte)is_cofcVar.Value; }
        //    set  { is_cofcVar.Value = value; }
        //}

        public Int32 image_height
        {
            get  { return (Int32)image_heightVar.Value; }
            set  { image_heightVar.Value = value; }
        }

        public Int32 image_width
        {
            get  { return (Int32)image_widthVar.Value; }
            set  { image_widthVar.Value = value; }
        }

        public String order_caption
        {
            get  { return (String)order_captionVar.Value; }
            set  { order_captionVar.Value = value; }
        }

        public String file_path
        {
            get { return (String)file_pathVar.Value; }
            set { file_pathVar.Value = value; }
        }


        

    }
    public partial class partpicture
    {
        public static partpicture New(Context x)
        {  return (partpicture)x.Item("partpicture"); }

        public static partpicture GetById(Context x, String uid)
        { return (partpicture)x.GetById("partpicture", uid); }

        public static partpicture QtO(Context x, String sql)
        { return (partpicture)x.QtO("partpicture", sql); }

        
    }
}
