using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomModelBinder.Startup))]
namespace CustomModelBinder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
