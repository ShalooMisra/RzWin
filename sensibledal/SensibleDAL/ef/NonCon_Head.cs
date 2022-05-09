//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SensibleDAL.ef
{
    using System;
    using System.Collections.Generic;
    
    public partial class NonCon_Head
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NonCon_Head()
        {
            this.NonCon_Customer = new HashSet<NonCon_Customer>();
            this.NonCon_Details = new HashSet<NonCon_Details>();
            this.NonCon_Disposition = new HashSet<NonCon_Disposition>();
            this.NonCon_Payment = new HashSet<NonCon_Payment>();
            this.NonCon_RMA = new HashSet<NonCon_RMA>();
        }
    
        public int NonConID { get; set; }
        public Nullable<System.DateTime> NonConDate { get; set; }
        public string VendorUID { get; set; }
        public string Description { get; set; }
        public string vendorName { get; set; }
        public string vendorPO { get; set; }
        public string vendorPOID { get; set; }
        public string partNumber { get; set; }
        public string partNumberID { get; set; }
        public string MFG { get; set; }
        public Nullable<int> QTY { get; set; }
        public string stocktype { get; set; }
        public Nullable<bool> isSale { get; set; }
        public Nullable<System.DateTime> dateSubmitted { get; set; }
        public string submittedBy { get; set; }
        public string isComplete { get; set; }
        public string completedBy { get; set; }
        public Nullable<System.DateTime> completedDate { get; set; }
        public string buyerName { get; set; }
        public string buyerEmail { get; set; }
        public string status { get; set; }
        public Nullable<bool> deleted { get; set; }
        public string ClosureRemarks { get; set; }
        public Nullable<bool> isShortShip { get; set; }
        public string linecode_sales { get; set; }
        public Nullable<int> lineCount { get; set; }
        public Nullable<bool> initial_email_sent { get; set; }
        public Nullable<bool> is_approved { get; set; }
        public string approval_user { get; set; }
        public Nullable<System.DateTime> approval_date { get; set; }
        public Nullable<bool> approval_email_sent { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NonCon_Customer> NonCon_Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NonCon_Details> NonCon_Details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NonCon_Disposition> NonCon_Disposition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NonCon_Payment> NonCon_Payment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NonCon_RMA> NonCon_RMA { get; set; }
    }
}