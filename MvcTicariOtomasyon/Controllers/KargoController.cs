using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();
        public ActionResult Index(string p)
        {
            //var kargo = c.KargoDetays.ToList();
            //return View(kargo);

            var kargo = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                //eğer p boş değilse p içeren ürün adını ındex e getir
                kargo = kargo.Where(y => y.TakipKodu.Contains(p));
            }
            return View(kargo.ToList());
        }

        [HttpGet]
        public ActionResult YeniKargo() 
        { 
            Random rnd = new Random();
            string[] karakter = { "j", "K", "f", "S", };
            int k1, k2, k3;
            k1=rnd.Next(0, karakter.Length);
            k2=rnd.Next(0, karakter.Length);
            k3=rnd.Next(0, karakter.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);//3 karakter gelsin diye
            s2 = rnd.Next(10, 99);//2 karakter gelsin diye
            s3 = rnd.Next(10, 99);//2 karakter gelsin diye
            string barkod = s1.ToString() + karakter[k1] + s2 + karakter[k2] + s3 + karakter[k3];
            ViewBag.barkod = barkod;
            return View(); 
        }
        [HttpPost]
        public ActionResult KargoEkle(KargoDetay p)
        {
            
            c.KargoDetays.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KargoTakip(string id)
        {
            //parametreye TakipKodu dunu çekemediğimiz için Global.asax'dan 
            //Route Config ayarı yapıldı 180. derse bak!! not eklendi derse 6 küsürüncü dk.
            //neden string id diye tanımlamak zorunda kaldık nedeni burda sonuçta id de p,s,d,f,g vs gibi bir değişken

            var kargo = c.KargoTakips.Where(x=>x.TakipKodu==id).ToList();      
            return View(kargo);
        }
    }
}