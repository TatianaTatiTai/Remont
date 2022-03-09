using System.Web.Http;
using System.Web.Http.Cors;
using Ninject.Web.WebApi;
using Owin;

namespace LAMS.WebApi.Extensions
{
    /// <summary>
    /// Extension methods for IAppBuilder
    /// </summary>
    public static class WebApiExtensions
    {
        /// <summary>
        /// Enables and configures WebApi for owin app
        /// </summary>
        /// <param name="app">Owin app builder</param>
        /// <param name="configuration">http configuration</param>
        public static void ConfigureWebApi(this IAppBuilder app, HttpConfiguration configuration)
        {
            var dependencyResolver = new NinjectDependencyResolver(NinjectWebCommon.Bootstrapper.Kernel);

            GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;

            configuration.DependencyResolver = dependencyResolver;
            configuration.SuppressDefaultHostAuthentication();            

            //configuration.EnableCors(new EnableCorsAttribute("http://localhost:4200", headers: "*", methods: "*"));   

            RegisterWebApiRoutes(configuration);

            app.UseWebApi(configuration);
        }

        private static void RegisterWebApiRoutes(HttpConfiguration configuration)
        {
            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
            );
        }
    }
}