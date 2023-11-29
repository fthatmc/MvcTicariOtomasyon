using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Sınıflar
{
    public class Cari
    {
        [Key]
        public int CariID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 Karakter Girebilirsiniz")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 Karakter Girebilirsiniz")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CariSehir { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string CariMail { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(20)]
        public string CariSifre { get; set; }
        public bool Durum { get; set; }
        public ICollection<SatısHareket> SatisHaraket { get; set; }
    }
}