using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using Swashbuckle.Application;
using System.Web.Http;

[assembly: OwinStartup(typeof(Core.Reporting.WebAPI.Startup))]
namespace Core.Reporting.WebAPI
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "WPR.WebAPI");
                c.UseFullTypeNameInSchemaIds();
            })
                .EnableSwaggerUi();

            app.UseCors(CorsOptions.AllowAll);
            //app.UseWebApi(config);
            app.UseNinjectMiddleware(() => NinjectBinding.CreateKernel.Value);
            app.UseNinjectWebApi(config);

        }
    }
}