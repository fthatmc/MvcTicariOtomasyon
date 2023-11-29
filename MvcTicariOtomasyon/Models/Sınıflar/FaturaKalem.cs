using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Sınıflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Acıklama { get; set; }
        public int Miktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }
        public int Faturaid { get; set; }
        public virtual Faturalar Faturalar { get; set; }
    }
}