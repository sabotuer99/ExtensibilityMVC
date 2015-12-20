using ExtensibilityMVC.CustomActionResults;
using ExtensibilityMVC.LoggerInfo;
using ExtensibilityMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace ExtensibilityMVC.Controllers
{
    public class XmlController : Controller
    {
        IRequestLogger logger;
        /// <summary>
        /// The Constructor with the Logger parameter. 
        /// </summary>
        /// <param name="log"></param>
        public XmlController(IRequestLogger log)
        {
            logger = log;
        }

        public XmlController()
        {
            logger = new RequestLogger();
        }


        [HttpGet]
        public XmlActionResult GetXmlData()
        {
            LogInfo();

            System.Xml.XmlTextReader reader =
              new System.Xml.XmlTextReader(Server.MapPath("~/Book.xml"));
            var xml = XElement.Load(reader);
            return new XmlActionResult(xml.ToString(), "book.xml");
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