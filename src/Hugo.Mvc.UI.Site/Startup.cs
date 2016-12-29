using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hugo.Mvc.UI.Site.Startup))]
namespace Hugo.Mvc.UI.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
