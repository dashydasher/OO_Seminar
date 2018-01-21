using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlivanjeWeb.Startup))]
namespace PlivanjeWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
