using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomViewEngine.ViewEngine
{
    public class DebugInfoRazorViewEngine : RazorViewEngine
    {
        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            bool debugOn = controllerContext.Controller.ViewData["debugModeOn"] != null;
            if (debugOn)
            {
                RazorView view = (RazorView)base.CreatePartialView(controllerContext, partialPath);
                return new DebugInfoRazorView(controllerContext, view.ViewPath, view.LayoutPath, view.RunViewStartPages, view.ViewStartFileExtensions);
            }
            else
            {
                return base.CreatePartialView(controllerContext, partialPath);
            }

            
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            bool debugOn = controllerContext.Controller.ControllerContext.HttpContext.Request.QueryString["debugModeOn"] != null;
            if (debugOn)
            {
                RazorView view = (RazorView)base.CreateView(controllerContext, viewPath, masterPath); 
                return new DebugInfoRazorView(controllerContext, view.ViewPath, view.LayoutPath, view.RunViewStartPages, view.ViewStartFileExtensions);
            }
            else
            {
                return base.CreateView(controllerContext, viewPath, masterPath);
            }
        }
    }
}