using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Camedia.Startup))]
namespace Camedia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
