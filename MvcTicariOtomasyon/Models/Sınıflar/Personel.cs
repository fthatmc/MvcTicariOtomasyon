using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Sınıflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }

        [Display(Name = "Personel Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }

        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }

        [Display(Name = "Personel Görseli")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string PersonelGorsel { get; set; }
        public ICollection<SatısHareket> SatisHaraket { get; set; }

        public int Bransid { get; set; }
        public virtual Brans Departmans { get; set; }
    }
}