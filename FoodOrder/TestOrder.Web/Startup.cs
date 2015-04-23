using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestOrder.Web.Startup))]
namespace TestOrder.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
