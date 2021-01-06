using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LSYS.Controllers
{
    public class BPanelController : Controller
    {
        // GET: BPanel

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}