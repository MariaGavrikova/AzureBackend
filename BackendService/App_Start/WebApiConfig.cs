using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Web.Http;

using Swashbuckle.Application;

namespace BackendService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config
                .EnableSwagger(c => {
                    var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                    var commentsFile = Path.Combine(baseDirectory, "bin\\", commentsFileName);

                    c.SingleApiVersion("v1", "Module 2 Task 3 Backend Service");
                    c.IncludeXmlComments(commentsFile);
                })
                .EnableSwaggerUi();
        }
    }
}
