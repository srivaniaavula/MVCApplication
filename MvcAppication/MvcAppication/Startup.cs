using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcAppication.Startup))]
namespace MvcAppication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
