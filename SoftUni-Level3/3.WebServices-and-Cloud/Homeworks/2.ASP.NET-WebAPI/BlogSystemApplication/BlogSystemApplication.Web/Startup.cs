using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BlogSystemApplication.Web.Startup))]

namespace BlogSystemApplication.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}