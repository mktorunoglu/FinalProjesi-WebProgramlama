using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LSYS.Models.Entity;
namespace LSYS.Controllers
{
    public class BayiMusterilerController : Controller
    {
        // GET: BayiMusteriler
        LSYSEntities db = new LSYSEntities();
        public ActionResult Index(Nullable<int> id)
        {
            var byi = from k in db.TBL_MUSTERI
                      where k.BAYI_ID == id
                      select k;

            return View(byi.ToList());
        }
    }
}