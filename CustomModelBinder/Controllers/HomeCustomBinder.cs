using CustomModelBinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomModelBinder.Controllers
{
    public class HomeCustomBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
                                ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            string title = request.Form.Get("Title");
            string day = request.Form.Get("Day");
            string month = request.Form.Get("Month");
            string year = request.Form.Get("Year");

            string parsedDate = "Invalid Date Parameters";
            try
            {
                parsedDate = DateTime.Parse(month + "/" + day + "/" + year).ToLongDateString();
            }
            catch (Exception ex) {}


            return new HomePageModels
            {
                Title = title,
                Date = parsedDate
            };
        }
    } 
}