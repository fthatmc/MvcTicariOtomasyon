using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var urun = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                //eğer p boş değilse p içeren ürün adını ındex e getir
                urun = urun.Where(y => y.UrunAd.Contains(p));
            }
            return View(urun.ToList());
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            //dropdown list
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.Deger1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {
            u.Durum = true;
            c.Uruns.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var urun = c.Uruns.Find(id);
            urun.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunBul(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.Deger1 = deger1;
            var urundeger = c.Uruns.Find(id);
            return View("UrunBul", urundeger);
        }

        public ActionResult UrunGuncelle(Urun u)
        {
            var urn = c.Uruns.Find(u.UrunID);
            urn.AlisFiyat = u.AlisFiyat;
            urn.SatisFiyat = u.SatisFiyat;
            urn.Kategoriid = u.Kategoriid;
            urn.Durum = true;
            urn.Marka = u.Marka;
            urn.Stok = u.Stok;
            urn.UrunAd = u.UrunAd;
            urn.UrunGorsel = u.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UrunListesi()
        {
            var urun = c.Uruns.ToList();
            return View(urun);
        }

        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> personel = (from x in c.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                 Value = x.PersonelID.ToString()
                                             }).ToList();
            ViewBag.personel = personel;

            var deger = c.Uruns.Find(id);
            ViewBag.deger1 = deger.UrunID;
            ViewBag.deger2 = deger.SatisFiyat;
            
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatısHareket p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarakets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");
        }
    }
}