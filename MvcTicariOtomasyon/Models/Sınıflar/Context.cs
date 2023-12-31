﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcTicariOtomasyon.Models.Sınıflar
{
    public class Context : DbContext
    {
        //tabloları oluşturduk
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Brans> Departmans { get; set; }
        public DbSet<Cari> Caris { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Faturalar> Faturalars { get; set; }
        public DbSet<Gider> Giders { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<SatısHareket> SatisHarakets { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Detay> Detays { get; set; }
        public DbSet<Yapilacak> Yapilacaks { get; set; }
        public DbSet<KargoDetay> KargoDetays { get; set; }
        public DbSet<KargoTakip> KargoTakips { get; set; }
        public DbSet<Mesajlar> Mesajlars { get; set; }



    }
}