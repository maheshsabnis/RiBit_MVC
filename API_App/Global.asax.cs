using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace API_App
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            // Register DI Container
            UnityConfig.RegisterComponents();
            // ROute Table for API
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // REgister All Action Filters for API
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            // The Routes thse are matched from the GlobalConfiguration
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // Bundling
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
