using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomRouteHandler.Startup))]
namespace CustomRouteHandler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
