using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcTicariOtomasyon.Models.Sınıflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();

        [Authorize]
        public ActionResult Index()
        {
            
            var mail = (string)Session["CariMail"];
            var degerler = c.Mesajlars.Where(x=>x.Alici == mail).ToList();
            ViewBag.Mail = mail;
            var cariid = c.Caris.Where(x=>x.CariMail==mail).Select(y=>y.CariID).FirstOrDefault();
            //yukarda gelen mail e göre carinin id sini bulduk
            ViewBag.mailid = cariid;
            var toplamsatis = c.SatisHarakets.Where(x=>x.Cariid==cariid).Count();
            ViewBag.toplamsatis = toplamsatis;
            var toplamtutar = c.SatisHarakets.Where(x => x.Cariid == cariid).Sum(y => y.ToplamTutar);
            ViewBag.toplamtutar =toplamtutar;
            var toplamurunsayisi = c.SatisHarakets.Where(x => x.Cariid == cariid).Sum(y => y.Adet);
            ViewBag.toplamurunsayisi =toplamurunsayisi;
            var adsoyad = c.Caris.Where(x => x.CariMail == mail).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;
            return View(degerler);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            //yukarda x mail ile giriş yaptı
            //mail değişkeninden gelen değere göre caris tablosundaki mail bulduk onun vasıtası ile
            // Select(y=>y.CariID) yaparak id'yi bulduk ve id değişkenine atadık.
            var id = c.Caris.Where(x=>x.CariMail==mail.ToString()).Select(y=>y.CariID).FirstOrDefault();
            var degerler = c.SatisHarakets.Where(x=>x.Cariid==id).ToList();
            return View(degerler);
        }

        public ActionResult GelenMesaj()
        {
            var mail = (string)Session["CariMail"]; //oturum açan mail adresini mail değişkenine ata
            var mesaj = c.Mesajlars.Where(x=>x.Alici==mail).OrderByDescending(z => z.MesajID).ToList();
            //alıcısı sisteme giren mail olanın mesajını id sırasına göre listele id si küçük olan en eski mesaj


            var gelenmesajsayisi = c.Mesajlars.Count(c=>c.Alici==mail).ToString();
            ViewBag.gelenmesajsayisi =gelenmesajsayisi;
            var gidenmesajsayisi = c.Mesajlars.Count(c => c.Gonderici == mail).ToString();
            ViewBag.gidenmesajsayisi = gidenmesajsayisi;

            return View(mesaj);                                        
        }

        public ActionResult GidenMesaj()
        {
            var mail = (string)Session["CariMail"]; 
            var mesaj = c.Mesajlars.Where(x => x.Gonderici == mail).OrderByDescending(z => z.MesajID).ToList();

            var gelenmesajsayisi = c.Mesajlars.Count(c => c.Alici == mail).ToString();
            ViewBag.gelenmesajsayisi = gelenmesajsayisi;
            var gidenmesajsayisi = c.Mesajlars.Count(c => c.Gonderici == mail).ToString();
            ViewBag.gidenmesajsayisi = gidenmesajsayisi;

            return View(mesaj);
        }

        public ActionResult MesajDetay(int id)
        {
            var mesajı = c.Mesajlars.Where(x=>x.MesajID == id).ToList();

            var mail = (string)Session["CariMail"];
            var mesaj = c.Mesajlars.Where(x => x.Gonderici == mail).ToList();
            var gelenmesajsayisi = c.Mesajlars.Count(c => c.Alici == mail).ToString();
            ViewBag.gelenmesajsayisi = gelenmesajsayisi;
            var gidenmesajsayisi = c.Mesajlars.Count(c => c.Gonderici == mail).ToString();
            ViewBag.gidenmesajsayisi = gidenmesajsayisi;

            return View(mesajı);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var mesaj = c.Mesajlars.Where(x => x.Gonderici == mail).ToList();
            var gelenmesajsayisi = c.Mesajlars.Count(c => c.Alici == mail).ToString();
            ViewBag.gelenmesajsayisi = gelenmesajsayisi;
            var gidenmesajsayisi = c.Mesajlars.Count(c => c.Gonderici == mail).ToString();
            ViewBag.gidenmesajsayisi = gidenmesajsayisi;

            return View();
        }
        [HttpPost]

        public ActionResult YeniMesaj(Mesajlar m)
        {
            //girenin maili kendi sayfası dolayısyla kendi maili olduğu için gmderici kısmına bu şekilde çektik
            var mail = (string)Session["CariMail"];
            m.Gonderici = mail;

            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

            c.Mesajlars.Add(m);
            c.SaveChanges();

            return View();
        }

        public ActionResult KargoTakip(string p)
        {
            var kargo = from x in c.KargoDetays select x;
            kargo = kargo.Where(y => y.TakipKodu.Contains(p));
            return View(kargo.ToList());
            
        }
        public ActionResult CariKargoTakip(string id)
        {
            var kargo = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(kargo);
        }

        public ActionResult LogOut() 
        { 
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        } 

        public PartialViewResult Partial1()
        {
            var mail = (string)Session["CariMail"];
            var cariid = c.Caris.Where(x=>x.CariMail==mail).Select(x=>x.CariID).FirstOrDefault();
            var cari = c.Caris.Find(cariid);
            return PartialView("Partial1", cari);
        }

        public PartialViewResult Partial2()
        {
            var deger = c.Mesajlars.Where(x => x.Gonderici == "admin").ToList();
            return PartialView(deger);
        }

        public ActionResult CariBilgiGuncelle(Cari cr)
        {
            var cari = c.Caris.Find(cr.CariID);
            cari.CariAd = cr.CariAd;
            cari.CariSoyad = cr.CariSoyad;
            cari.CariSifre = cr.CariSifre;
            cari.CariSehir = cr.CariSehir;
            cari.CariMail = cr.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}