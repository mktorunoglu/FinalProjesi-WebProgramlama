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

        public ActionResult Index(Nullable<int> id)
        {
            var khmd = from k in db.TBL_K_HAMMADELER
                       where k.URUN_ID == id
                       select k;

            return View(khmd.ToList());
        }
    }
}