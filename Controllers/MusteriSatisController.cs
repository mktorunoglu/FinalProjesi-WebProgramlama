using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LSYS.Models.Entity;
namespace LSYS.Controllers
{
    public class MusteriSatisController : Controller
    {
        // GET: MusteriSatis
        LSYSEntities db = new LSYSEntities();
        public ActionResult Index(Nullable<int> id)
        {
            var byi = from k in db.TBL_SATIS
                      where k.MUSTERI_ID == id
                      select k;

            return View(byi.ToList());
        }
        public ActionResult IndexP(Nullable<int> id)
        {
            var byi = from k in db.TBL_SATIS
                      where k.MUSTERI_ID == id
                      select k;

            return View(byi.ToList());
        }
    }
}