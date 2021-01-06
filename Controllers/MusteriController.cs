using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LSYS.Models.Entity;
namespace LSYS.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        LSYSEntities db = new LSYSEntities();
        public ActionResult Index(string p)
        {
            var musteriler = from u in db.TBL_MUSTERI select u;
            if (!string.IsNullOrEmpty(p))
            {
                musteriler = musteriler.Where(m => m.AD.Contains(p));
            }
           
            return View(musteriler.ToList());
        }
        public ActionResult IndexP(string p)
        {
            var musteriler = from u in db.TBL_MUSTERI select u;
            if (!string.IsNullOrEmpty(p))
            {
                musteriler = musteriler.Where(m => m.AD.Contains(p));
            }

            return View(musteriler.ToList());
        }
        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }

        // sayfa üzerinde bir butona tıklandığında bu işlemi yap
        [HttpPost]
        public ActionResult MusteriEkle(TBL_MUSTERI p)
        {
            db.TBL_MUSTERI.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult MusteriSil(int id)
        {
            var mst = db.TBL_MUSTERI.Find(id);
            db.TBL_MUSTERI.Remove(mst);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mst = db.TBL_MUSTERI.Find(id);
            return View("MusteriGetir", mst);
        }

        public ActionResult MusteriGuncelle(TBL_MUSTERI p)
        {
            var mst = db.TBL_MUSTERI.Find(p.MUSTERI_ID);
            mst.AD = p.AD;
            mst.SOYAD = p.SOYAD;
            mst.TELEFON = p.TELEFON;
            mst.ADRES = p.ADRES;
            mst.BAYI_ID = p.BAYI_ID;
            mst.MAIL = p.MAIL;
            mst.KULLANICI_ADI = p.KULLANICI_ADI;
            mst.SIFRE = p.SIFRE;
            mst.DOGUM_TARIHI = p.DOGUM_TARIHI;


            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }




}