using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LSYS.Models.Entity;
namespace LSYS.Controllers
{
    public class YoneticiController : Controller
    {
        // GET: Yonetici
        LSYSEntities db = new LSYSEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_YONETICI.ToList();
            return View(degerler);
        }
        // sayfayı yükleyince bir işlem yapma
        [HttpGet]
        public ActionResult YoneticiEkle()
        {
            return View();
        }

        // sayfa üzerinde bir butona tıklandığında bu işlemi yap
        [HttpPost]
        public ActionResult YoneticiEkle(TBL_YONETICI p)
        {
            db.TBL_YONETICI.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult YoneticiSil(int id)
        {
            var yonetici = db.TBL_YONETICI.Find(id);
            db.TBL_YONETICI.Remove(yonetici);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YoneticiGetir(int id)
        {
            var ynt = db.TBL_YONETICI.Find(id);
            return View("YoneticiGetir", ynt);
        }

        public ActionResult YoneticiGuncelle(TBL_YONETICI p)
        {
            var hmd = db.TBL_YONETICI.Find(p.YONETICI_ID);
            hmd.YONETICI_AD = p.YONETICI_AD;
            hmd.YONETICI_SOYAD = p.YONETICI_SOYAD;
            hmd.KULLANICI_ADI = p.KULLANICI_ADI;
            hmd.SIFRE = p.SIFRE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}