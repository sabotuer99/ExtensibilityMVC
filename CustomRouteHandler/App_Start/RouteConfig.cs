using CustomRouteHandler.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomRouteHandler
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.Add(new Route(
                url: "AspCompat/{controller}/{action}",
                defaults: new RouteValueDictionary(
                    new { controller = "Home", action = "ThreadState" }),
                routeHandler: new AspCompatHandler()));

            //routes.MapRoute(
            //    name: "AspCompatRoute",
            //    url: "AspCompat/{controller}/{action}",
            //    defaults: new { controller = "Home", action = "ThreadState" }
            //).RouteHandler = new AspCompatHandler();

            routes.MapRoute(
                name: "noram",
                url: "{controller}/Index/{id}",
                defaults: new { controller = "Home", action = "noram"},
                constraints: new { id = "(us|ca)" }
            );

            routes.MapRoute(
                name: "europe",
                url: "{controller}/Index/{id}",
                defaults: new { controller = "Home", action = "europe"},
                constraints: new EuropeConstraint()
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", 
                    action = "Index", id = UrlParameter.Optional}
            );
        }
    }

    public class EuropeConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName,
        RouteValueDictionary values, RouteDirection routeDirection)
        {
            List<string> vals = new List<string>(){"uk","de","es","it","fr","be","nl"};
            string id = (string)values["id"];

            return vals.Contains(id);
        }
    }
}
