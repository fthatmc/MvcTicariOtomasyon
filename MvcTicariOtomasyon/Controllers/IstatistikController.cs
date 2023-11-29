using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            //carilerin toplamını ver
            var deger1 = c.Caris.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;

            //Toplam stok sayısını ver
            var deger5 = c.Uruns.Sum(x=>x.Stok).ToString();
            ViewBag.d5 = deger5;

            //Urun tablosundan Markayı seç Tekrarsız olarak(Distinct) say topla string olarak değeri ver
            var deger6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;

            //stoğu 20 den az olan stokları say
            var deger7 = c.Uruns.Count(x=>x.Stok<=20).ToString();
            ViewBag.d7 = deger7;

            //Uruns tablosunu (orderby) sırala, satış fiyatına göre, nasıl (descending) büyükten küçüğe
            // sonra en üstteki ürün adını seç (FirstOrDefault) , string formatta yazdır.
            var deger8 = (from x in c.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault().ToString();
            ViewBag.d8 = deger8;

            //yukardan farkı ascending
            var deger9 = (from x in c.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault().ToString();
            ViewBag.d9 = deger9;

            var deger10 = c.Uruns.Count(x=>x.UrunAd=="Buz Dolabı").ToString();
            ViewBag.d10 = deger10;

            var deger11 = c.Uruns.Count(x => x.UrunAd == "Telefon").ToString();
            ViewBag.d11 = deger11;

            //urun tablosunu markaya göre (GroupBy) gruplandır
            //OrderByDescending çoktan aza doğru sırala aynı zamanda z'den a'ya da sıralama yapılır bununla
            //Key gruplandırdığımız değerin ismi 
            //FirstOrDefault bununla da en üstteki değeri getir
            //kısaca burası en çok satan ürünün markasını yazacak.
            var deger12 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;

            //en çok satış yapılan ürünün id'sine göre bulup adını çektik
            // id = ( c.SatisHarakets.GroupBy(z=>z.Urunid).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())
            //c.Uruns.Where(x=>x.UrunID == id)
            //Select(c => c.UrunAd).FirstOrDefault(); gelen id ye göre ürün adını seç.
            var deger13 = c.Uruns.Where(u=>u.UrunID == ( c.SatisHarakets.GroupBy(x=>x.Urunid).
            OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).
            Select(c => c.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;

            //toplam satış
            var deger14 = c.SatisHarakets.Sum(x=>x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;

            //bugun kaç tane satış yapıldı
            DateTime bugun = DateTime.Today;
            var deger15 = c.SatisHarakets.Count(x=>x.Tarih==bugun).ToString();
            ViewBag.d15 = deger15;

            //kasa toplamı
            if (Convert.ToInt32(deger15) != 0)

            {
                //bugun satılanların (sum) toplamı
                var deger16 = c.SatisHarakets.Where(x => x.Tarih == bugun).Sum(y => y.ToplamTutar).ToString();
                ViewBag.d16 = deger16;

            }
            else { ViewBag.d16 = deger15;}



            return View();
        }

        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Caris // cariler tablosunu
                        group x by x.CariSehir into g // Carisehir e göre gruplandırıp g ye ekle
                        select new SinifGrup //Annonymus type
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };


            return View(sorgu.ToList());
        }
        public PartialViewResult partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departmans.BransAd into g
                         select new SinifGrup2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult partial2()
        {
            var sorgu = c.Caris.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult partial3()
        {
            var sorgu1 = c.Uruns.ToList();
            return PartialView(sorgu1);
        }
        public PartialViewResult partial4()
        {
            var sorgu3 = from x in c.Uruns
                         group x by x.Marka into g
                         select new MarkaSayi
                         {
                             Marka = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu3.ToList());
        }
    }
}