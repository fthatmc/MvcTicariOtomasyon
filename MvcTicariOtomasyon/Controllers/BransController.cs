using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class BransController : Controller
    {
        //!!! Tabloyu oluştururken yanlışlıkla  public DbSet<Brans> Departmans { get; set; } böyle yaptın!!!
        // GET: Brans
        Context c = new Context();
        public ActionResult Index()
        {
            var brans = c.Departmans.Where(x => x.Durum == true).ToList();
            return View(brans);
           
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Brans d)
        {
            d.Durum = true;
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DepartmanGetır(int id)
        {
            var brans = c.Departmans.Find(id);
            return View("DepartmanGetır", brans);
        }
        [HttpPost]
        public ActionResult DepartmanGuncelle(Brans d)
        {
            var brans = c.Departmans.Find(d.BransID);
            brans.Durum= true;
            brans.BransAd = d.BransAd;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DepartmanSil(int id)
        {
            var brans = c.Departmans.Find(id);
            brans.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            //aşağıda gelen id ye göre personelenin bransid si aynı olanı listele
            var personel = c.Personels.Where(x => x.Bransid == id).ToList();
            //aşağıda gelen id ye göre departmanın adını çektik
            var dpt = c.Departmans.Where(x => x.BransID == id).Select(c => c.BransAd).FirstOrDefault();
            ViewBag.DptAd = dpt;
            return View(personel);

        }
        public ActionResult DepartmanPersonelSatıs(int id)
        {
            var satıs = c.SatisHarakets.Where(x => x.Personelid == id).ToList();
            //aşağıda gelen id ye göre satışı yapanın adını ve soyadını çektik çektik
            var peradsoyad = c.Personels.Where(x => x.PersonelID == id).Select(c => c.PersonelAd + " " + c.PersonelSoyad).FirstOrDefault();
            ViewBag.PerAdSoyad = peradsoyad;
            return View(satıs);
        }
    }
}