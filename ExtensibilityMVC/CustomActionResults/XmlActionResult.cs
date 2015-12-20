using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace ExtensibilityMVC.CustomActionResults
{
    public enum EncodingType
    {
        UTF8,
        UTF16,
        UTF32
    }

    public class XmlActionResult : ActionResult
    {
        public XmlActionResult(string xml, string fileName,
            EncodingType encoding = EncodingType.UTF8,
            LoadOptions loadOptions = System.Xml.Linq.LoadOptions.None)
        {
            XmlContent = xml;
            FileName = fileName;
            Encoding = encoding;
            LoadOptions = loadOptions;
        }

        public string FileName { get; set; }

        public string XmlContent { get; set; }

        public EncodingType Encoding { get; set; }

        public LoadOptions LoadOptions { get; set; }

        public XmlDocument ToXmlDocument(XDocument xdoc)
        {
            var xmldoc = new XmlDocument();
            xmldoc.Load(xdoc.CreateReader());
            return xmldoc;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            XDocument doc = XDocument.Parse(XmlContent, this.LoadOptions);
            context.HttpContext.Response.ContentType = "text/xml";
            context.HttpContext.Response.AddHeader("content-disposition",
              string.Format("attachment; filename={0}", FileName));

            XmlDocument xmldoc = ToXmlDocument(doc);
            // Create an XML declaration. 
            XmlDeclaration xmldecl;
            xmldecl = xmldoc.CreateXmlDeclaration("1.0", null, null);

            //XmlElement root = new XmlElement();
            switch (Encoding)
            {
                case EncodingType.UTF8:
                    WriteResponse(context, doc, xmldoc, xmldecl, "utf-8");
                    break;
                case EncodingType.UTF16:
                    WriteResponse(context, doc, xmldoc, xmldecl, "utf-16");
                    break;
                case EncodingType.UTF32:
                    WriteResponse(context, doc, xmldoc, xmldecl, "utf-32");
                    break;
            }
            
            context.HttpContext.Response.End();
        }

        private void WriteResponse(ControllerContext context, XDocument doc, XmlDocument xmldoc, XmlDeclaration xmldecl, String encoding)
        {
            doc.Declaration = new XDeclaration("1.0", encoding, null);
            context.HttpContext.Response.Charset = encoding;
            xmldecl.Encoding = encoding.ToUpper();
            XmlElement root = xmldoc.DocumentElement;
            xmldoc.InsertBefore(xmldecl, root);
            context.HttpContext.Response.BinaryWrite(
              System.Text.UTF8Encoding.Default.GetBytes(xmldoc.OuterXml));
            //return root;
        }
    }
}