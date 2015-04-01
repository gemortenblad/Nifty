using Microsoft.Owin;
using Nifty;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
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
