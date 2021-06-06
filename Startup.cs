using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Vidly_MVCProject.Startup))]

namespace Vidly_MVCProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}