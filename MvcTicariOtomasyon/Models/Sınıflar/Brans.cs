using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Sınıflar
{
    public class Brans
    {
        [Key]
        public int BransID { get; set; }

        [Display(Name = "Personel Branşı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string BransAd { get; set; }
        public bool Durum { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}