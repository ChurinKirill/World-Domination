using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorldDomination.Startup))]
namespace WorldDomination
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
