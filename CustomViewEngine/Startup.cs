using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomViewEngine.Startup))]
namespace CustomViewEngine
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
