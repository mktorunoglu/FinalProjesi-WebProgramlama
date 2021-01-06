using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LSYS.Models.Entity;
namespace LSYS.Controllers
{
    public class OdemeController : Controller
    {
        // GET: Odeme
        LSYSEntities db = new LSYSEntities();
        public ActionResult Index(Nullable<int> id)
        {
            var byi = from k in db.TBL_ODEME
                      where k.BAYI_ID == id
                      select k;

            return View(byi.ToList());
        }
        [HttpGet]
        public ActionResult OdemeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OdemeEkle(TBL_ODEME p)
        {
            db.TBL_ODEME.Add(p);
            db.SaveChanges();

            return View();
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