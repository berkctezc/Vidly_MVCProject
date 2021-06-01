using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartup(typeof(Vidly_MVCProject.Startup))]

namespace Vidly_MVCProject
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
