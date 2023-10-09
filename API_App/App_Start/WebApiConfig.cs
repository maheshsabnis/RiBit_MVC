using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Http;

namespace API_App
{
    public static class WebApiConfig
    {
        /// <summary>
        /// HttpConfiguration: Read each Incomming Request
        /// and will generate a Route Template
        /// as api/'controller'/id
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // ENabling CORS

            config.EnableCors();

            // Web API routes
            // Help the Custom Routes aka ATtribute based ROuting
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
