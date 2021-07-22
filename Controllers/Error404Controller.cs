using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Charming.Controllers
{
    public class Error404Controller : Controller
    {
        // GET: Error404
        public ActionResult WarningFatalError()
        {
            return View();
        }
    }
}