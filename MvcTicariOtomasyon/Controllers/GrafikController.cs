using MvcTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategoriler ve Ürün Sayıları").AddLegend("Stok").
            AddSeries("Değerler",xValue: new[] { "Mobilya", "TV", "Bilgisayar"},
            yValues: new[] { 50, 300, 100 }).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }

        Context c = new Context();
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = c.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stok));
            var grafik = new Chart(width: 500, height: 500).AddTitle("Stoklar")
                .AddSeries(chartType: "Line", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet); 
        }

        //manuel olarak eklendi buralarda
        public List<Grafikler> UrunListesi()
        {
            List<Grafikler> grf = new List<Grafikler>();

            grf.Add(new Grafikler()
            {
                urunad="Bilgisayar",
                stok =120
            });
            grf.Add(new Grafikler()
            {
                urunad = "TV",
                stok = 100
            });
            grf.Add(new Grafikler()
            {
                urunad = "Masa",
                stok = 70
            });
            grf.Add(new Grafikler()
            {
                urunad = "Koltuk",
                stok = 180
            });
            grf.Add(new Grafikler()
            {
                urunad = "Tablet",
                stok = 110
            });

            return grf;

        }
        

        //ındex 5 ve ondan sonra sql den veri çekildi
        public ActionResult Index5()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }
        public List<Grafik2> UrunListesi2()
        {
           List<Grafik2> grf = new List<Grafik2>();
            using (var c = new Context())
            {
                grf = c.Uruns.Select(g => new Grafik2
                {
                    urn = g.UrunAd,
                    stk = g.Stok

                }).ToList();
            }
            return grf; 

        }

        public ActionResult Index6()
        {
            return View();
        }

        public ActionResult Index7()
        {
            return View();
        }
    }
}