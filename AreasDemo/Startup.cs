using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AreasDemo.Startup))]
namespace AreasDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
