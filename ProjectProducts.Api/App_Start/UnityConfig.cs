using AutoMapper;
using ProjectProducts.Data.Repository;
using ProjectProducts.Data.Repository.Implements;
using ProjectProducts.Domain.Implements;
using ProjectProducts.Domain.Interface;
using ProjectProducts.Domain.Mapper;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace ProjectProducts.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IProductRepository, ProductRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IProductService, ProductService>(new HierarchicalLifetimeManager());

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductProfile());
            });

            container.RegisterInstance<IMapper>(config.CreateMapper());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}