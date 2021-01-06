using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LSYS.Models.Entity;
namespace LSYS.Controllers
{
    public class TumOdemelerController : Controller
    {
        // GET: TumOdemeler
        LSYSEntities db = new LSYSEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_ODEME.ToList();
            return View(degerler);
        }
        public ActionResult IndexP()
        {
            var degerler = db.TBL_ODEME.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OdemeEkleP()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OdemeEkleP(TBL_ODEME p)
        {
            db.TBL_ODEME.Add(p);
            db.SaveChanges();

            return View();
        }
    }
}