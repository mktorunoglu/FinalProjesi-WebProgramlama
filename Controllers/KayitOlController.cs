using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LSYS.Models.Entity;
namespace LSYS.Controllers
{
    public class KayitOlController : Controller
    {
        // GET: KayitOl
        LSYSEntities db = new LSYSEntities();
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kayit(TBL_MUSTERI p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TBL_MUSTERI.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}