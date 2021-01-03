using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LSYS.Models.Entity;
namespace LSYS.Controllers
{
    public class BakimController : Controller
    {
        // GET: Bakim
        LSYSEntities db = new LSYSEntities();
        public ActionResult Index(Nullable<int> id)
        {
            var bakim = from k in db.TBL_BAKIM
                       where k.BAYI_ID == id
                       select k;

            return View(bakim.ToList());
        }

        [HttpGet]
        public ActionResult BakimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BakimEkle(TBL_BAKIM p)
        {
            db.TBL_BAKIM.Add(p);
            db.SaveChanges();

            return View();
        }


    }
}