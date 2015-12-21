using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomViewEngine.Controllers
{
    public class myViewController : Controller
    {
        //
        // GET: /myView/
        public ActionResult Index()
        {
            ViewData["Message"] = "Hello World!";
            return View();
        }
    }
}