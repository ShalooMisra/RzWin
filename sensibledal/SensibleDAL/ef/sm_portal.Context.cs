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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class sm_portalEntities : DbContext
    {
        public sm_portalEntities()
            : base("name=sm_portalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<insp_detail> insp_detail { get; set; }
        public virtual DbSet<insp_head> insp_head { get; set; }
        public virtual DbSet<insp_whse> insp_whse { get; set; }
    }
}
