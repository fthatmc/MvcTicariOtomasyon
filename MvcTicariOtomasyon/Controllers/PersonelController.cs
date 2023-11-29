using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var personel = c.Personels.ToList();
            return View(personel);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.BransAd,
                                               Value = x.BransID.ToString()
                                           }).ToList();
            ViewBag.Deger1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            //File UpLoad ile resim ekleme kod satırı 159.ders
            if (Request.Files.Count > 0)

            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Resim/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Resim/" + dosyaAdi + uzanti;
            }

            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var personel = c.Personels.Find(id);
            c.Personels.Remove(personel);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult PersonelGetir(int id)
        {
            var per = c.Personels.Find(id);
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.BransAd,
                                               Value = x.BransID.ToString()
                                           }).ToList();
            ViewBag.Deger1 = deger1;
            return View("PersonelGetir", per);
        }
        [HttpPost]
        public ActionResult PersonelGuncelle(Personel p)
        {

            var per = c.Personels.Find(p.PersonelID);
            per.PersonelAd = p.PersonelAd;
            per.PersonelSoyad = p.PersonelSoyad;
            if (Request.Files.Count > 0)

            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Resim/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Resim/" + dosyaAdi + uzanti;
            }

            per.PersonelGorsel = p.PersonelGorsel;
            per.Bransid = p.Bransid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult PersonelList()
        {
            var personel1 = c.Personels.ToList();
            return View(personel1);
        }
    }
}