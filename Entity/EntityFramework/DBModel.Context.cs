﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WEBGIAYEntities : DbContext
    {
        public WEBGIAYEntities()
            : base("name=WEBGIAYEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ANHCHITIET> ANHCHITIETs { get; set; }
        public virtual DbSet<CTDH> CTDHs { get; set; }
        public virtual DbSet<CUNGSANPHAM> CUNGSANPHAMs { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMERS { get; set; }
        public virtual DbSet<DOITUONG> DOITUONGs { get; set; }
        public virtual DbSet<DONHANG> DONHANGs { get; set; }
        public virtual DbSet<GOITIN> GOITINs { get; set; }
        public virtual DbSet<KICHCO> KICHCOes { get; set; }
        public virtual DbSet<LICHSUDANGTIN> LICHSUDANGTINs { get; set; }
        public virtual DbSet<LICHSUMUATIN> LICHSUMUATINs { get; set; }
        public virtual DbSet<MERCHANT> MERCHANTS { get; set; }
        public virtual DbSet<PHANLOAI> PHANLOAIs { get; set; }
        public virtual DbSet<RATING> RATINGs { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<THUONGHIEU> THUONGHIEUx { get; set; }
        public virtual DbSet<WEBMASTER> WEBMASTERs { get; set; }
    }
}
