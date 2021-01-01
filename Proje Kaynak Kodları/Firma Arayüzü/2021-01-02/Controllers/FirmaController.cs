using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LSYSweb.Models.Entity;

namespace LSYSweb.Controllers
{
    public class FirmaController : Controller
    {
        // GET: Home

        LSYSEntities db = new LSYSEntities();

        public ViewResult Urunler()
        {
            var degerler = db.TBL_URUN.ToList();
            return View(degerler);
        }

        public ViewResult Siparisler()
        {
            var degerler = db.TBL_URUN.ToList();
            return View(degerler);
        }

        public ViewResult Stok()
        {
            var degerler = db.TBL_URUN.ToList();
            return View(degerler);
        }

        public ViewResult Recete()
        {
            var degerler = db.TBL_URUN.ToList();
            return View(degerler);
        }
    }
}


