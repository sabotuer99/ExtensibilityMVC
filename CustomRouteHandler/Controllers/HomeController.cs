using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CustomRouteHandler.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {

        [Route("~/Echo/{echo:int}")]
        public string IntEcho(int echo)
        {
            return "Number is: " + echo;
        }
        
        [Route("~/Echo/{echo}")]
        public string StringEcho(string echo="default")
        {
            return "You said: " + echo;
        }


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

        public string noram(string id)
        {
            return "Welcome to North America. Id = " + id;
        }

        public string europe(string id)
        {
            return "Welcome to Europe. Id = " + id;
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