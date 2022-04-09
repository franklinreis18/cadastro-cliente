using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(webApplication.Startup))]
namespace webApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
