using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LSYS.Models.Entity;
namespace LSYS.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        LSYSEntities db = new LSYSEntities();
        public ActionResult Index(Nullable<int> id)
        {
            var urndty = from k in db.TBL_K_HAMMADELER
                       where k.URUN_ID == id
                       select k;

            return View(urndty.ToList());
        }
    }
}