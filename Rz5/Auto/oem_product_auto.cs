using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("oem_product", Caption= "Oem Product", Importance = 85)]
    public partial class oem_product_auto : NewMethod.nObject
    {
        static oem_product_auto()
        {
            Item.AttributesCache(typeof(oem_product_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }
        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "oem_product_name":
                    oem_product_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "oem_product_uid":
                    oem_product_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "oem_product_description":
                    oem_product_descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_price":
                    base_priceAttribute = (CoreVarValAttribute)attr;
                    break;

            }
        }



        static CoreVarValAttribute oem_product_nameAttribute;
        static CoreVarValAttribute oem_product_uidAttribute;
        static CoreVarValAttribute oem_product_descriptionAttribute;
        static CoreVarValAttribute base_priceAttribute;
        

        [CoreVarVal("oem_product_name", "String", TheFieldLength = 50, Caption = "OEM Product Name", Importance = 1)]
        public VarString oem_product_nameVar;

        [CoreVarVal("oem_product_uid", "String", TheFieldLength = 50, Caption = "OEM Product UID", Importance = 2)]
        public VarString oem_product_uidVar;

        [CoreVarVal("oem_product_description", "String", TheFieldLength = 4096, Caption = "OEM Product Description", Importance = 3)]
        public VarString oem_product_descriptionVar;

        [CoreVarVal("base_price", "Double", Caption = "Base / SUggested Price", Importance = 4)]
        public VarDouble base_priceVar;


        public oem_product_auto()
        {
            StaticInit();
            oem_product_nameVar = new VarString(this, oem_product_nameAttribute);
            oem_product_uidVar = new VarString(this, oem_product_uidAttribute);
            oem_product_descriptionVar = new VarString(this, oem_product_descriptionAttribute);
            base_priceVar = new VarDouble(this, base_priceAttribute);
        }

        public override string ClassId
        { get { return "oem_product"; } }

        public string oem_product_name
        {
            get { return (string)oem_product_nameVar.Value; }
            set { oem_product_nameVar.Value = value; }
        }

        public string oem_product_uid
        {
            get { return (string)oem_product_uidVar.Value; }
            set { oem_product_uidVar.Value = value; }
        }

        public string oem_product_description
        {
            get { return (string)oem_product_descriptionVar.Value; }
            set { oem_product_descriptionVar.Value = value; }
        }

        public double base_price
        {
            get { return (double)base_priceVar.Value; }
            set { base_priceVar.Value = value; }
        }

        
    }
    public partial class oem_product
    {
        public static oem_product New(Context x)
        {  return (oem_product)x.Item("oem_product"); }

        public static oem_product GetById(Context x, String uid)
        { return (oem_product)x.GetById("oem_product", uid); }

        public static oem_product QtO(Context x, String sql)
        { return (oem_product)x.QtO("oem_product", sql); }
    }
}
