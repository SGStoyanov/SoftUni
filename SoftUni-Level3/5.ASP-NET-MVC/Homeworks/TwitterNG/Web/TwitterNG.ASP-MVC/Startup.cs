using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TwitterNG.ASP_MVC.Startup))]
namespace TwitterNG.ASP_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
