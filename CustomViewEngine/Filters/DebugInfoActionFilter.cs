using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomViewEngine.Filters
{
    public class DebugInfo : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewData["debugModeOn"] = filterContext.HttpContext.Request.QueryString["debugModeOn"];

            base.OnActionExecuting(filterContext);
        }
    }
}