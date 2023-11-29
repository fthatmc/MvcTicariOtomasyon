using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;
using PagedList;
using PagedList.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index(int sayfa=1) // sayfa=1 1. sayfadan başla 2 olsa 2. sayfa
        {
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa, 4);//kaçtan başlayacak, kaç satıra ayıracak
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            Kategori k = c.Kategoris.ToList().Find(x => x.KategoriID == id);
            c.Kategoris.Remove(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult KategoriGuncelle(int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGuncelle", kategori);
        }
        [HttpPost]
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var kategori = c.Kategoris.Find(k.KategoriID);
            kategori.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}