﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PharmacyManagementEntities : DbContext
    {
        public PharmacyManagementEntities()
            : base("name=PharmacyManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Count> Counts { get; set; }
        public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<StockDetail> StockDetails { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
