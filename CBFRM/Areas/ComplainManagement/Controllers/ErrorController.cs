using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CBFRM.Areas.ComplainManagement.Controllers
{
    public class ErrorController : Controller
    {
        // GET: ComplainManagement/Error
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ModuleError()
        {

            return View("ModuleError");
        }
    }
}