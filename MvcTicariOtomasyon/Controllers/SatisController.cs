using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var satis = c.SatisHarakets.ToList();
            return View(satis);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> urun = (from x in c.Uruns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.UrunID.ToString()
                                         }).ToList();

            List<SelectListItem> cari = (from x in c.Caris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CariAd + " " + x.CariSoyad,
                                             Value = x.CariID.ToString()
                                         }).ToList();
            List<SelectListItem> personel = (from x in c.Personels.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.PersonelAd + " " + x.PersonelSoyad,
                                             Value = x.PersonelID.ToString()
                                         }).ToList();
            ViewBag.urun = urun;
            ViewBag.cari = cari;
            ViewBag.personel = personel;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatısHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarakets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SatisBul(int id)
        {
            List<SelectListItem> urun = (from x in c.Uruns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.UrunID.ToString()
                                         }).ToList();

            List<SelectListItem> cari = (from x in c.Caris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CariAd + " " + x.CariSoyad,
                                             Value = x.CariID.ToString()
                                         }).ToList();
            List<SelectListItem> personel = (from x in c.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                 Value = x.PersonelID.ToString()
                                             }).ToList();
            ViewBag.urun = urun;
            ViewBag.cari = cari;
            ViewBag.personel = personel;
            var satıs =c.SatisHarakets.Find(id);
            return View("SatisBul", satıs);
        }
        [HttpPost]
        public ActionResult SatisGuncelle(SatısHareket sat)
        {
            var satıs = c.SatisHarakets.Find(sat.SatisID);
            satıs.Cariid = sat.Cariid;
            satıs.Urunid = sat.Urunid;
            satıs.Personelid = sat.Personelid;
            satıs.Adet = sat.Adet;
            satıs.Fiyat = sat.Fiyat;
            satıs.ToplamTutar = sat.ToplamTutar;
            satıs.Tarih = sat.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SatisDetay(int id)
        {
            var satis = c.SatisHarakets.Where(x=>x.SatisID==id).ToList();
            return View(satis);
           
        }
    }
}