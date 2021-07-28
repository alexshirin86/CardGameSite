using CardGameSite.BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CardGameSite.BLL.Services;
using CardGameSite.DAL.Infrastructure;


namespace CardGameSite.BLL.Infrastructure
{
    public static class CollectionDependencyInjections
    {
        public static IServiceCollection AddDependencyInjectionBLL(this IServiceCollection services, IConfiguration config)
        {            
            services.AddScoped<IProductService, ProductService>();
            services.AddDependencyInjectionDAL(config);
            return services;
        }
    }
}
