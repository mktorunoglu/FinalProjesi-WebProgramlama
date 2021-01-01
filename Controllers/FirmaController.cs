using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LSYS.Models.Entity;

namespace LSYS.Controllers
{
    public class FirmaController : Controller
    {
        // GET: Firma
        LSYSEntities db = new LSYSEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_FIRMA.ToList();
            return View(degerler);
        }
    }
}