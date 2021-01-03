using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LSYS.Models.Entity;
namespace LSYS.Controllers
{
    public class TumSatıslarController : Controller
    {
        // GET: TumSatıslar
        LSYSEntities db = new LSYSEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_SATIS.ToList();
            return View(degerler);
        }

        public ActionResult SatisGetir(int id)
        {
            var sts = db.TBL_SATIS.Find(id);
            return View("SatisGetir", sts);
        }
        public ActionResult SatisGuncelle(TBL_SATIS p)
        {
            var sts = db.TBL_SATIS.Find(p.SATIS_ID);
            sts.MUSTERI_ID = p.MUSTERI_ID;
            sts.URUN_ID = p.URUN_ID;
            sts.ADET = p.ADET;
            sts.SATIS_TARIH = p.SATIS_TARIH;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}