using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SheaduleASP.Startup))]
namespace SheaduleASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
