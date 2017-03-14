using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WXUserPage.Startup))]
namespace WXUserPage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
