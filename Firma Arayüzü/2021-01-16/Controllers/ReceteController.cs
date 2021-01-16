using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LSYSweb.Models.Entity;

namespace LSYSweb.Controllers
{
    public class ReceteController : Controller
    {
        // GET: kHammaddeler
        LSYSEntities db = new LSYSEntities();

        public ActionResult Index()
        {
            var degerler = db.TBL_K_HAMMADELER.ToList();
            return View(degerler);
        }
    }
}