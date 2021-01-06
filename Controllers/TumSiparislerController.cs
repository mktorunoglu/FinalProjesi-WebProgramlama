using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LSYS.Models.Entity;
namespace LSYS.Controllers
{
    public class TumSiparislerController : Controller
    {
        // GET: TumSiparisler
        LSYSEntities db = new LSYSEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_SIPARIS.ToList();
            return View(degerler);
        }

        public ActionResult IndexP()
        {
            var degerler = db.TBL_SIPARIS.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult SiparisEkle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SiparisEkle(TBL_SIPARIS p)
        {
            db.TBL_SIPARIS.Add(p);
            db.SaveChanges();

            return View();
        }

        public ActionResult SiparisGetir(int id)
        {
            var sts = db.TBL_SIPARIS.Find(id);
            return View("SiparisGetir", sts);
        }
        public ActionResult SiparisGuncelle(TBL_SIPARIS p)
        {
            var sts = db.TBL_SIPARIS.Find(p.SIPARIS_ID);
            sts.URUN_ID = p.URUN_ID;
            sts.URUN_ADET = p.URUN_ADET;
            sts.ALIS_FIYAT = p.ALIS_FIYAT;
            sts.TUTAR = p.TEMIN_SURESI;
            sts.BAYI_ID = p.BAYI_ID;
            sts.TARIH = p.TARIH;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SiparisSil(int id)
        {
            var spr = db.TBL_SIPARIS.Find(id);
            db.TBL_SIPARIS.Remove(spr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SiparisEkleP()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SiparisEkleP(TBL_SIPARIS p)
        {
            db.TBL_SIPARIS.Add(p);
            db.SaveChanges();

            return View();
        }

        public ActionResult SiparisGetirP(int id)
        {
            var sts = db.TBL_SIPARIS.Find(id);
            return View("SiparisGetirP", sts);
        }
        public ActionResult SiparisGuncelleP(TBL_SIPARIS p)
        {
            var sts = db.TBL_SIPARIS.Find(p.SIPARIS_ID);
            sts.URUN_ID = p.URUN_ID;
            sts.URUN_ADET = p.URUN_ADET;
            sts.ALIS_FIYAT = p.ALIS_FIYAT;
            sts.TUTAR = p.TEMIN_SURESI;
            sts.BAYI_ID = p.BAYI_ID;
            sts.TARIH = p.TARIH;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}