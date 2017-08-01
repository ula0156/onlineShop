using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(onlineShopWeb.Startup))]
namespace onlineShopWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
