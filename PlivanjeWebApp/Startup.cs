using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlivanjeWebApp.Startup))]
namespace PlivanjeWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
