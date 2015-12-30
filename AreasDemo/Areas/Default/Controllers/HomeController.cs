using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreasDemo.Areas.Default.Controllers
{
    public class HomeController : Controller
    {
        // GET: Default/Home
        public string Index()
        {
            return "Area Demo, Default, Home, Index";
        }
    }
}