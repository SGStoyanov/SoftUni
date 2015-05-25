using Microsoft.Owin;

[assembly: OwinStartup(typeof(TwitterNG.Web.Startup))]
namespace TwitterNG.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
