using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Sınıflar
{
    public class Mesajlar
    {
        [Key]
        public int MesajID { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Gonderici { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Alici { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Konu { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(2030)]
        public string icerik { get; set; }


        [Column(TypeName = "Smalldatetime")]
        public DateTime Tarih  { get; set; }
    }
}