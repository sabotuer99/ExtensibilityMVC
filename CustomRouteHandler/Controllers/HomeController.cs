using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CustomRouteHandler.Controllers
{
    public class HomeController : Controller
    {
        public string ThreadState()
        {
            var thread = System.Threading.Thread.CurrentThread;
            ApartmentState state = thread.GetApartmentState();
            return state.ToString();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}