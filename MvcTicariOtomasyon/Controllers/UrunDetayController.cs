using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        IEnumerable cs = new IEnumerable();
        public ActionResult Index()
        {
            cs.Deger1 = c.Uruns.Where(x=>x.UrunID==1).ToList();
            cs.Deger2 = c.Detays.Where(x => x.DetayID == 1).ToList();
            return View(cs);
        }
    }
}