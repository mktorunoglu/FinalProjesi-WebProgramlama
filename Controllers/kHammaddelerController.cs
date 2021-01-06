using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LSYS.Models.Entity;
namespace LSYS.Controllers
{
    public class kHammaddelerController : Controller
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
        public ActionResult IndexP(Nullable<int> id)
        {

            var khmd = from k in db.TBL_K_HAMMADELER
                       where k.URUN_ID == id
                       select k;

            return View(khmd.ToList());
        }



    }
}