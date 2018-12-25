using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.KeyVault;

using BackendService.App_Start;

namespace BackendService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private const string KeyUrl = "https://adventure-works-kv.vault.azure.net/secrets/ConnectionString";

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            log4net.Config.XmlConfigurator.Configure();

            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            var secret = keyVaultClient.GetSecretAsync(KeyUrl).GetAwaiter().GetResult();
            SecretValues.ConnectionString = secret.Value;
        }
    }
}
