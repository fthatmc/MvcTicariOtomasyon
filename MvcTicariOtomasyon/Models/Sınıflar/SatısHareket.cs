using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Sınıflar
{
    public class SatısHareket
    {
        [Key]
        public int SatisID { get; set; }
        //ürün
        //cari
        //personel
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }

        [Display(Name = "Ürün ID")]
        public int Urunid { get; set; }
        [Display(Name = "Cari ID")]
        public int Cariid { get; set; }
        [Display(Name = "Personel Adı Soyadı")]
        public int Personelid { get; set; }

        //alttaki üçü primary key olarak yansıyacak
        //satıshareket tablosu foregin key

        public virtual Urun uruns { get; set; }
        public virtual Cari Caris { get; set; }
        public virtual Personel Personels { get; set; }
    }
}