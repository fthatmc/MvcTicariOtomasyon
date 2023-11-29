using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Sınıflar
{
    public class KargoDetay
    {
        [Key]
        public int KargoDetayid { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(300)]
        public string Aciklama { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Personel { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Alici { get; set; }
        public DateTime Tarih { get; set; }
    }
}