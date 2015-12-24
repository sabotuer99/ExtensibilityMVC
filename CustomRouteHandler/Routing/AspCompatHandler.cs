using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomRouteHandler.Routing
{
    public class AspCompatHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new AspCompatHandlerImpl(requestContext);
        }

        public class AspCompatHandlerImpl : System.Web.UI.Page, IHttpAsyncHandler
        {
            public AspCompatHandlerImpl(RequestContext requestContext)
            {
                this.RequestContext = requestContext;
            }

            public RequestContext RequestContext { get; set; }

            protected override void OnInit(EventArgs e)
            {
                string requiredString = this.RequestContext.RouteData.GetRequiredString("controller");
                var controllerFactory = ControllerBuilder.Current.GetControllerFactory();
                var controller = controllerFactory.CreateController(this.RequestContext, requiredString);
                if (controller == null)
                    throw new InvalidOperationException("Could not find controller: " + requiredString);
                try
                {
                    controller.Execute(this.RequestContext);
                }
                finally
                {
                    controllerFactory.ReleaseController(controller);
                }
                this.Context.ApplicationInstance.CompleteRequest();
            }

            public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
            {
                return this.AspCompatBeginProcessRequest(context, cb, extraData);
            }

            public void EndProcessRequest(IAsyncResult result)
            {
                this.AspCompatEndProcessRequest(result);
            }
        }
    }
}