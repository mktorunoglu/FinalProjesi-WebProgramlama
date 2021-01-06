using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LSYS.Models.Entity;

namespace LSYS.Controllers
{
    public class BayiController : Controller
    {
        // GET: Bayi
        LSYSEntities db = new LSYSEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_BAYI.ToList();
            return View(degerler);
        }
        public ActionResult IndexP()
        {
            var degerler = db.TBL_BAYI.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult BayiEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BayiEkle(TBL_BAYI p)
        {
            db.TBL_BAYI.Add(p);
            db.SaveChanges();

            return View();
        }

        public ActionResult BayiSil(int id)
        {
            var bayi = db.TBL_BAYI.Find(id);
            db.TBL_BAYI.Remove(bayi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BayiGetir(int id)
        {
            var byi = db.TBL_BAYI.Find(id);
            return View("BayiGetir", byi);
        }

        public ActionResult BayiGuncelle(TBL_BAYI p)
        {
            var byi = db.TBL_BAYI.Find(p.BAYI_ID);
            byi.BAYI_ID = p.BAYI_ID;
            byi.BAYI_ADI = p.BAYI_ADI;
            byi.KULLANICI_ADI = p.KULLANICI_ADI;
            byi.SIFRE = p.SIFRE;
            byi.TELEFON = p.TELEFON;
            byi.ADRES = p.ADRES;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

         [HttpGet]
        public ActionResult BayiEkleP()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BayiEkleP(TBL_BAYI p)
        {
            db.TBL_BAYI.Add(p);
            db.SaveChanges();

            return View();
        }
        public ActionResult BayiGetirP(int id)
        {
            var byi = db.TBL_BAYI.Find(id);
            return View("BayiGetirP", byi);
        }

        public ActionResult BayiGuncelleP(TBL_BAYI p)
        {
            var byi = db.TBL_BAYI.Find(p.BAYI_ID);
            byi.BAYI_ID = p.BAYI_ID;
            byi.BAYI_ADI = p.BAYI_ADI;
            byi.KULLANICI_ADI = p.KULLANICI_ADI;
            byi.SIFRE = p.SIFRE;
            byi.TELEFON = p.TELEFON;
            byi.ADRES = p.ADRES;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}