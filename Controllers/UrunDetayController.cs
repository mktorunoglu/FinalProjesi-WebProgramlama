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
            var urn = from k in db.TBL_URUN
                      where k.URUN_ID == id
                      select k;

            return View(urn.ToList());
        }
        public ActionResult IndexP(Nullable<int> id)
        {
            var urn = from k in db.TBL_URUN
                      where k.URUN_ID == id
                      select k;

            return View(urn.ToList());
        }
    }
}