using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LSYS.Models.Entity;

namespace LSYS.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        LSYSEntities db = new LSYSEntities();
        public ActionResult Index(string p)
        {
            var urunler = from u in db.TBL_URUN select u;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(m => m.URUN_ADI.Contains(p));
            }
            // var urunler = db.TBLKITAP.ToList();
            return View(urunler.ToList());
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            
            return View();

        }
        [HttpPost]
        public ActionResult UrunEkle(TBL_URUN p)
        {
            db.TBL_URUN.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult UrunSil(int id)
        {
            var urun = db.TBL_URUN.Find(id);
            db.TBL_URUN.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBL_URUN.Find(id);
            return View("UrunGetir", urun);
        }

        public ActionResult UrunGuncelle(TBL_URUN p)
        {
            var urun = db.TBL_URUN.Find(p.URUN_ID);
            urun.URUN_ID = p.URUN_ID;
            urun.URUN_ADI = p.URUN_ADI;
            urun.URUN_MODEL = p.URUN_MODEL;
            urun.P_BAKIM_SURESI= p.P_BAKIM_SURESI;
            urun.ALIS_FIYAT = p.ALIS_FIYAT;
            urun.SATIS_FIYAT = p.SATIS_FIYAT;
            urun.STOK_ADEDI = p.STOK_ADEDI;
            urun.TEMIN_SURESI = p.TEMIN_SURESI; 
            urun.STOK_ESIK_DEGERI = p.STOK_ESIK_DEGERI;
            urun.KAR = p.KAR;
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}