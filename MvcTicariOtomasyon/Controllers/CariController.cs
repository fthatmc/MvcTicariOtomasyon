using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var cari = c.Caris.Where(x => x.Durum == true).ToList();
            return View(cari);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cari p)
        {
            p.Durum = true;
            c.Caris.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cari = c.Caris.Find(id);
            cari.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CariGetir(int id)
        {
            var cari = c.Caris.Find(id);
            return View("CariGetir", cari);
        }
        [HttpPost]
        public ActionResult CariGuncelle(Cari p)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }

            var cari = c.Caris.Find(p.CariID);
            cari.CariAd = p.CariAd;
            cari.CariSoyad = p.CariSoyad;
            cari.CariSehir = p.CariSehir;
            cari.CariMail = p.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult CariSatisHareket(int id)
        {
            var carisatis = c.SatisHarakets.Where(x => x.Cariid == id).ToList();
            var cariadsoyad = c.Caris.Where(x => x.CariID == id).Select(c => c.CariAd + " " + c.CariSoyad).FirstOrDefault();
            ViewBag.cari = cariadsoyad;
            return View(carisatis);
        }
    }
}