using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LSYS.Models.Entity;
namespace LSYS.Controllers
{
    public class HammaddeController : Controller
    {
        // GET: Hammadde
        LSYSEntities db = new LSYSEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_HAMMADDE.ToList();
            return View(degerler);
        }
        // sayfayı yükleyince bir işlem yapma
        [HttpGet]
        public ActionResult HammaddeEkle()
        {
            return View();
        }

        // sayfa üzerinde bir butona tıklandığında bu işlemi yap
        [HttpPost]
        public ActionResult HammaddeEkle(TBL_HAMMADDE p)
        {


            db.TBL_HAMMADDE.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult HammaddeSil(int id)
        {
            var hammadde = db.TBL_HAMMADDE.Find(id);
            db.TBL_HAMMADDE.Remove(hammadde);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult HammaddeGetir(int id)
        {
            var hmd = db.TBL_HAMMADDE.Find(id);
            return View("HammaddeGetir", hmd);
        }

        public ActionResult HammaddeGuncelle(TBL_HAMMADDE p)
        {
            var hmd = db.TBL_HAMMADDE.Find(p.HAMMADDE_ID);
            hmd.HAMMADDE_ADI = p.HAMMADDE_ADI;
            hmd.STOK_ADEDI = p.STOK_ADEDI;
            hmd.STOK_ESIK_DEGERI = p.STOK_ESIK_DEGERI;
            hmd.TEMIN_SURESI = p.TEMIN_SURESI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}