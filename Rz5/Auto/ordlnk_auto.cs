using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("ordlnk")]
    public partial class ordlnk_auto : NewMethod.nObject
    {
        static ordlnk_auto()
        {
            Item.AttributesCache(typeof(ordlnk_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "orderid1":
                    orderid1Attribute = (CoreVarValAttribute)attr;
                    break;
                case "orderid2":
                    orderid2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "ordernumber1":
                    ordernumber1Attribute = (CoreVarValAttribute)attr;
                    break;
                case "ordernumber2":
                    ordernumber2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "ordertype1":
                    ordertype1Attribute = (CoreVarValAttribute)attr;
                    break;
                case "ordertype2":
                    ordertype2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "datecreated":
                    datecreatedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datemodified":
                    datemodifiedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "modifiedby":
                    modifiedbyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "detailid":
                    detailidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "detailid2":
                    detailid2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "companyname1":
                    companyname1Attribute = (CoreVarValAttribute)attr;
                    break;
                case "companyname2":
                    companyname2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "isvoid":
                    isvoidAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute orderid1Attribute;
        static CoreVarValAttribute orderid2Attribute;
        static CoreVarValAttribute ordernumber1Attribute;
        static CoreVarValAttribute ordernumber2Attribute;
        static CoreVarValAttribute ordertype1Attribute;
        static CoreVarValAttribute ordertype2Attribute;
        static CoreVarValAttribute datecreatedAttribute;
        static CoreVarValAttribute datemodifiedAttribute;
        static CoreVarValAttribute modifiedbyAttribute;
        static CoreVarValAttribute detailidAttribute;
        static CoreVarValAttribute detailid2Attribute;
        static CoreVarValAttribute companyname1Attribute;
        static CoreVarValAttribute companyname2Attribute;
        static CoreVarValAttribute isvoidAttribute;

        [CoreVarVal("orderid1", "String", TheFieldLength = 50, Caption="Order 1 Id", Importance = 1)]
        public VarString orderid1Var;

        [CoreVarVal("orderid2", "String", TheFieldLength = 50, Caption="Order 2 Id", Importance = 2)]
        public VarString orderid2Var;

        [CoreVarVal("ordernumber1", "String", TheFieldLength = 50, Caption="Order Number 1", Importance = 3)]
        public VarString ordernumber1Var;

        [CoreVarVal("ordernumber2", "String", TheFieldLength = 50, Caption="Order Number 2", Importance = 4)]
        public VarString ordernumber2Var;

        [CoreVarVal("ordertype1", "String", TheFieldLength = 50, Caption="Order Type 1", Importance = 5)]
        public VarString ordertype1Var;

        [CoreVarVal("ordertype2", "String", TheFieldLength = 50, Caption="Order Type 2", Importance = 6)]
        public VarString ordertype2Var;

        [CoreVarVal("datecreated", "DateTime", Caption="Date Created", Importance = 7)]
        public VarDateTime datecreatedVar;

        [CoreVarVal("datemodified", "DateTime", Caption="Date Modified", Importance = 8)]
        public VarDateTime datemodifiedVar;

        [CoreVarVal("modifiedby", "String", TheFieldLength = 50, Caption="Modified By", Importance = 9)]
        public VarString modifiedbyVar;

        [CoreVarVal("detailid", "String", TheFieldLength = 50, Caption="Detail Id", Importance = 10)]
        public VarString detailidVar;

        [CoreVarVal("detailid2", "String", TheFieldLength = 50, Caption="Detail Id 2", Importance = 11)]
        public VarString detailid2Var;

        [CoreVarVal("companyname1", "String", TheFieldLength = 50, Caption="Company Name 1", Importance = 12)]
        public VarString companyname1Var;

        [CoreVarVal("companyname2", "String", TheFieldLength = 50, Caption="Company Name 2", Importance = 13)]
        public VarString companyname2Var;

        [CoreVarVal("isvoid", "Boolean", Caption="Isvoid", Importance = 14)]
        public VarBoolean isvoidVar;

        public ordlnk_auto()
        {
            StaticInit();
            orderid1Var = new VarString(this, orderid1Attribute);
            orderid2Var = new VarString(this, orderid2Attribute);
            ordernumber1Var = new VarString(this, ordernumber1Attribute);
            ordernumber2Var = new VarString(this, ordernumber2Attribute);
            ordertype1Var = new VarString(this, ordertype1Attribute);
            ordertype2Var = new VarString(this, ordertype2Attribute);
            datecreatedVar = new VarDateTime(this, datecreatedAttribute);
            datemodifiedVar = new VarDateTime(this, datemodifiedAttribute);
            modifiedbyVar = new VarString(this, modifiedbyAttribute);
            detailidVar = new VarString(this, detailidAttribute);
            detailid2Var = new VarString(this, detailid2Attribute);
            companyname1Var = new VarString(this, companyname1Attribute);
            companyname2Var = new VarString(this, companyname2Attribute);
            isvoidVar = new VarBoolean(this, isvoidAttribute);
        }

        public override string ClassId
        { get { return "ordlnk"; } }

        public String orderid1
        {
            get  { return (String)orderid1Var.Value; }
            set  { orderid1Var.Value = value; }
        }

        public String orderid2
        {
            get  { return (String)orderid2Var.Value; }
            set  { orderid2Var.Value = value; }
        }

        public String ordernumber1
        {
            get  { return (String)ordernumber1Var.Value; }
            set  { ordernumber1Var.Value = value; }
        }

        public String ordernumber2
        {
            get  { return (String)ordernumber2Var.Value; }
            set  { ordernumber2Var.Value = value; }
        }

        public String ordertype1
        {
            get  { return (String)ordertype1Var.Value; }
            set  { ordertype1Var.Value = value; }
        }

        public String ordertype2
        {
            get  { return (String)ordertype2Var.Value; }
            set  { ordertype2Var.Value = value; }
        }

        public DateTime datecreated
        {
            get  { return (DateTime)datecreatedVar.Value; }
            set  { datecreatedVar.Value = value; }
        }

        public DateTime datemodified
        {
            get  { return (DateTime)datemodifiedVar.Value; }
            set  { datemodifiedVar.Value = value; }
        }

        public String modifiedby
        {
            get  { return (String)modifiedbyVar.Value; }
            set  { modifiedbyVar.Value = value; }
        }

        public String detailid
        {
            get  { return (String)detailidVar.Value; }
            set  { detailidVar.Value = value; }
        }

        public String detailid2
        {
            get  { return (String)detailid2Var.Value; }
            set  { detailid2Var.Value = value; }
        }

        public String companyname1
        {
            get  { return (String)companyname1Var.Value; }
            set  { companyname1Var.Value = value; }
        }

        public String companyname2
        {
            get  { return (String)companyname2Var.Value; }
            set  { companyname2Var.Value = value; }
        }

        public Boolean isvoid
        {
            get  { return (Boolean)isvoidVar.Value; }
            set  { isvoidVar.Value = value; }
        }

    }
    public partial class ordlnk
    {
        public static ordlnk New(Context x)
        {  return (ordlnk)x.Item("ordlnk"); }

        public static ordlnk GetById(Context x, String uid)
        { return (ordlnk)x.GetById("ordlnk", uid); }

        public static ordlnk QtO(Context x, String sql)
        { return (ordlnk)x.QtO("ordlnk", sql); }
    }
}
