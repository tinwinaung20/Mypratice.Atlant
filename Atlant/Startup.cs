using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Atlant.Startup))]
namespace Atlant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
