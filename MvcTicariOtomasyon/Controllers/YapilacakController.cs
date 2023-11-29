using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Caris.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.Kategoris.Count().ToString();
            ViewBag.d3 = deger3;

            //(cari tablosunda carisehir i seç) (distinct-tekrarsız ).(count-say).(sayısal değeri getir-ToString)
            var deger4 = (from x in c.Caris select x.CariSehir).Distinct().Count().ToString();
            ViewBag.d4 = deger4;

            var yapilacak = c.Yapilacaks.ToList();
            return View(yapilacak);
        }
    }
}