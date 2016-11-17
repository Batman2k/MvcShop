using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RapidMountain.Startup))]
namespace RapidMountain
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
