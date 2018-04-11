using BLL.Services.Implementations;
using BLL.Services.Realizations;
using DAL.Repositories.Implementations;
using DAL.Repositories.Realizations;
using DAL.Unit_of_work;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace WebStore
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager(), new InjectionConstructor());
        
            container.RegisterType<IStoreService, StoreService>();
            container.RegisterType<IProductService, ProductService>();

            container.RegisterType<IStoreRepository, StoreRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}