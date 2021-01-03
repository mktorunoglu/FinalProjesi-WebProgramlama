using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LSYS.Models.Entity;
namespace LSYS.Controllers
{
    public class TumOdemelerController : Controller
    {
        // GET: TumOdemeler
        LSYSEntities db = new LSYSEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_ODEME.ToList();
            return View(degerler);
        }
    }
}