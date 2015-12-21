using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HtmlAgilityPack;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace CustomViewEngine.ViewEngine
{
    public class DebugInfoRazorView : RazorView
    {
        //call the base constructors
        public DebugInfoRazorView(ControllerContext controllerContext, 
            string viewPath, 
            string layoutPath, 
            bool runViewStartPages, 
            IEnumerable<string> viewStartFileExtensions,
            IViewPageActivator viewPageActivator) :
            base(controllerContext, viewPath, layoutPath, runViewStartPages, viewStartFileExtensions, viewPageActivator) {}

        public DebugInfoRazorView(ControllerContext controllerContext,
            string viewPath,
            string layoutPath,
            bool runViewStartPages,
            IEnumerable<string> viewStartFileExtensions) :
            base(controllerContext, viewPath, layoutPath, runViewStartPages, viewStartFileExtensions) { }

        //override base Render to add custom content
        public override void Render(ViewContext viewContext, TextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            base.Render(viewContext, sw);

            string contents = sb.ToString();

            contents = Regex.Replace(contents, "</body>", "<p>DEBUG INFO:</p><p>" + Environment.StackTrace + "</p></body>");

            writer.Write(contents);
            writer.Flush();
        }
    }
}