﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MagazaUrunTakipSistemi.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RG_MAGAZASTOKYONETIMEntities : DbContext
    {
        public RG_MAGAZASTOKYONETIMEntities()
            : base("name=RG_MAGAZASTOKYONETIMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_KATEGORI> TBL_KATEGORI { get; set; }
        public virtual DbSet<TBL_MUSTERI> TBL_MUSTERI { get; set; }
        public virtual DbSet<TBL_PERSONAL> TBL_PERSONAL { get; set; }
        public virtual DbSet<TBL_SATISLAR> TBL_SATISLAR { get; set; }
        public virtual DbSet<TBL_URUN> TBL_URUN { get; set; }
        public virtual DbSet<TBL_ADMIN> TBL_ADMIN { get; set; }
    }
}
