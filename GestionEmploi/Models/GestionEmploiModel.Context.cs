﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionEmploi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBIG3A8Entities : DbContext
    {
        public DBIG3A8Entities()
            : base("name=DBIG3A8Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Emploi> Emploi { get; set; }
        public virtual DbSet<Personne> Personne { get; set; }
        public virtual DbSet<Travailleur> Travailleur { get; set; }
    }
}