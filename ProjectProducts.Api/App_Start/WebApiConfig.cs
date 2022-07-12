using ProjectProducts.Data;
using ProjectProducts.Data.Repository;
using ProjectProducts.Data.Repository.Implements;
using ProjectProducts.Domain.Implements;
using ProjectProducts.Domain.Interface;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace ProjectProducts.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
