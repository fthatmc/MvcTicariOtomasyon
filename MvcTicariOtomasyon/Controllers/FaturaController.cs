using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;
namespace MvcTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var fatura = c.Faturalars.ToList();
            return View(fatura);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaKalemDetay(int id)
        {
            var faturakalem = c.FaturaKalems.Where(x=>x.Faturaid == id).ToList();
            return View(faturakalem);
        }
        [HttpGet]
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir",fatura);
        }
        [HttpPost]
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fatura = c.Faturalars.Find(f.FaturaID);
            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturaSıraNo = f.FaturaSıraNo;
            fatura.VergiDairesi = f.VergiDairesi;
            fatura.TeslimAlan = f.TeslimAlan;
            fatura.TeslimEden = f.TeslimEden;
            fatura.Toplam = f.Toplam;
            fatura.Saat = f.Saat;
            fatura.Tarih = f.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult FaturaKalemEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Faturalars.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.FaturaID.ToString(),
                                               Value = x.FaturaID.ToString()
                                           }).ToList();
            ViewBag.Deger1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult FaturaKalemEkle(FaturaKalem a)
        {
            c.FaturaKalems.Add(a);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}