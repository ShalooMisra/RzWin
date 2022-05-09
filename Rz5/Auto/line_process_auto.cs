using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Rz5
{
    [CoreClass("line_process")]   
    public partial class line_process_auto : NewMethod.nObject
    {
        static line_process_auto()
        {
            Item.AttributesCache(typeof(line_process_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "orddet_line_uid":
                    orddet_line_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "line_priority":
                    line_priorityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_payment_approved":
                    vendor_payment_approvedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_payment_approved_by":
                    vendor_payment_approved_byAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_payment_approved_date":
                    vendor_payment_approved_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "type":
                    typeAttribute = (CoreVarValAttribute)attr;
                    break;

            }
        }


        static CoreVarValAttribute orddet_line_uidAttribute;
        static CoreVarValAttribute line_priorityAttribute;
        static CoreVarValAttribute vendor_payment_approvedAttribute;
        static CoreVarValAttribute vendor_payment_approved_byAttribute;
        static CoreVarValAttribute vendor_payment_approved_dateAttribute;
        static CoreVarValAttribute typeAttribute;
        

        [CoreVarVal("orddet_line_uid", "String", Caption = "orddet_line_uid", Importance = 0, SearchCriteria = true)]
        public VarString orddet_line_uidVar;

        [CoreVarVal("line_priority", "Int32", Caption = "line_priority", Importance = 1, SearchCriteria = true)]
        public VarInt32 line_priorityVar;
        
        [CoreVarVal("vendor_payment_approved", "Boolean", Caption = "vendor_payment_approved", Importance = 3, SearchCriteria = true)]
        public VarBoolean vendor_payment_approvedVar;

        [CoreVarVal("vendor_payment_approved_by", "String", Caption = "vendor_payment_approved_by", Importance = 4, SearchCriteria = true)]
        public VarString vendor_payment_approved_by_byVar;

        [CoreVarVal("vendor_payment_approved_date", "DateTime", Caption = "vendor_payment_approved_date", Importance = 5, SearchCriteria = true)]
        public VarDateTime vendor_payment_approved_dateVar;


        [CoreVarVal("type", "String", Caption = "type", Importance = 6, SearchCriteria = true)]
        public VarString typeVar;
        


        public line_process_auto()
        {
            StaticInit();
            orddet_line_uidVar = new VarString(this, orddet_line_uidAttribute);
            line_priorityVar = new VarInt32(this, line_priorityAttribute);
            vendor_payment_approvedVar = new VarBoolean(this, vendor_payment_approvedAttribute);
            vendor_payment_approved_by_byVar = new VarString(this, vendor_payment_approved_byAttribute);
            vendor_payment_approved_dateVar = new VarDateTime(this, vendor_payment_approved_dateAttribute);
            typeVar = new VarString(this, typeAttribute);
            
        }
        

        public override string ClassId
        { get { return "line_process"; } }


        public String orddet_line_uid
        {
            get { return (String)orddet_line_uidVar.Value; }
            set { orddet_line_uidVar.Value = value; }
        }

        public Int32 line_priority
        {
            get { return (Int32)line_priorityVar.Value; }
            set { line_priorityVar.Value = value; }
        }

        public bool vendor_payment_approved
        {
            get { return (bool)vendor_payment_approvedVar.Value; }
            set { vendor_payment_approvedVar.Value = value; }
        }

        public String vendor_payment_approved_by
        {
            get { return (String)vendor_payment_approved_by_byVar.Value; }
            set { vendor_payment_approved_by_byVar.Value = value; }
        }

        public DateTime vendor_payment_approved_date
        {
            get { return (DateTime)vendor_payment_approved_dateVar.Value; }
            set { vendor_payment_approved_dateVar.Value = value; }
        }

        public DateTime type
        {
            get { return (DateTime)typeVar.Value; }
            set { typeVar.Value = value; }
        }

        
    }



    public partial class line_process
    {
        public static line_process New(Context x)
        { return (line_process)x.Item("line_process"); }

        public static line_process GetById(Context x, String uid)
        { return (line_process)x.GetById("line_process", uid); }

        public static line_process QtO(Context x, String sql)
        { return (line_process)x.QtO("line_process", sql); }

        public static line_process GetByName(Context x, String name, String extraSql = "")
        { return (line_process)x.GetByName("line_process", name, extraSql); }
    }
}
