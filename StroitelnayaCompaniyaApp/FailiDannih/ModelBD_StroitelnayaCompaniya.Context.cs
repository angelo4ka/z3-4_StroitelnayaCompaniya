﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StroitelnayaCompaniyaApp.FailiDannih
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class z3_4_BalashovaEntities : DbContext
    {
        public z3_4_BalashovaEntities()
            : base("name=z3_4_BalashovaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EdinicaIzmereniya> EdinicaIzmereniya { get; set; }
        public virtual DbSet<Sklad> Sklad { get; set; }
        public virtual DbSet<Stroimaterial> Stroimaterial { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<VidStroimaterialov> VidStroimaterialov { get; set; }
    }
}
