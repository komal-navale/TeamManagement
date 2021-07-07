using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FrontEndTeamManagement.Startup))]
namespace FrontEndTeamManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
