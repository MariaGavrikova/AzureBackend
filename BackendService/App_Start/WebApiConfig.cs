using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Description;

using Swashbuckle.Application;
using Swashbuckle.Swagger;

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

                    c.SingleApiVersion("v1", "Backend Service with Logging");
                    c.IncludeXmlComments(commentsFile);
                    c.OperationFilter<FileUploadOperation>();
                })
                .EnableSwaggerUi();
        }
    }    
}
