using CustomViewEngine.ViewEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CustomViewEngine
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Register your View Engine Here.
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new DebugInfoRazorViewEngine());
            //ViewEngines.Engines.Add(new MyWebFormViewEngine());
            //ViewEngines.Engines.Add(new MyViewEngine());
        }
    }
}
