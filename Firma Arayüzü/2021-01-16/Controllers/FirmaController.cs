using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web.Mvc;
using LSYSweb.Models.Entity;

namespace LSYSweb.Controllers
{
    public class FirmaController : Controller
    {
        // GET: Firma
        LSYSEntities db = new LSYSEntities();

        public ViewResult Urunler()
        {
            var degerler = db.TBL_URUN.ToList();
            return View(degerler);
        }

        public ViewResult Siparisler()
        {
            var degerler = db.TBL_SIPARIS.ToList();
            return View(degerler);
        }

        public ViewResult Stok()
        {
            var degerler = db.TBL_HAMMADDE.ToList();
            return View(degerler);
        }
    }
}

