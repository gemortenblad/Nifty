using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nifty.Startup))]
namespace Nifty
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
