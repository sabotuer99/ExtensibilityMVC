﻿using ExtensibilityMVC.LoggerInfo;
using ExtensibilityMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExtensibilityMVC.Controllers
{
    public class HomeController : Controller
    {
                
        IRequestLogger logger;
        /// <summary>
        /// The Constructor with the Logger parameter. 
        /// </summary>
        /// <param name="log"></param>
        public HomeController(IRequestLogger log)
        {
            logger = log;
        }

        public HomeController()
        {
            logger = new RequestLogger();
        }

        public ActionResult Index()
        {
            LogInfo();
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

        private void LogInfo()
        {
            LoggerInformation logInfo = new LoggerInformation();
            logInfo.UserName = this.Request.LogonUserIdentity.Name;
            logInfo.RequestUrl = this.Request.Url.AbsoluteUri;
            logInfo.Browser = this.Request.Browser.Browser;
            logInfo.RequestType = this.Request.RequestType;
            logInfo.UserHostAddress = this.Request.UserHostAddress;
            logger.RecordLog(logInfo);
        }
    }
}