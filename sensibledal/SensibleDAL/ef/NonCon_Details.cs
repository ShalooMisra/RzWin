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
    
    public partial class NonCon_Details
    {
        public int DetailsID { get; set; }
        public int NonConID { get; set; }
        public Nullable<bool> isNonconforming { get; set; }
        public Nullable<bool> isActionRequired { get; set; }
        public string IsVendorFeedbackUpdated { get; set; }
        public string CANum { get; set; }
        public string SCNum { get; set; }
        public string PANum { get; set; }
        public string submittedBy { get; set; }
        public System.DateTime dateSubmitted { get; set; }
        public Nullable<bool> detailsComplete { get; set; }
        public string completedBy { get; set; }
        public Nullable<bool> isLeadsBodyIssue { get; set; }
        public string leadsMemo { get; set; }
        public Nullable<bool> Retin { get; set; }
        public Nullable<bool> Oxidation { get; set; }
        public Nullable<bool> GenDamage { get; set; }
        public Nullable<bool> Pull { get; set; }
        public Nullable<bool> Refurb { get; set; }
    
        public virtual NonCon_Head NonCon_Head { get; set; }
    }
}
