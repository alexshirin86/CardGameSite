using CardGameSite.BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CardGameSite.DAL.Infrastructure;
using CardGameSite.DAL.Entities;
using CardGameSite.BLL.DTO;
using CardGameSite.BLL.Services.Implementations;


namespace CardGameSite.BLL.Infrastructure
{
    public static class CollectionDependencyInjections
    {
        public static IServiceCollection AddDependencyInjectionBLL(this IServiceCollection services, IConfiguration config)
        {            
            services.AddScoped<IService<ProductDTO>, Service<Product, ProductDTO>>();
            services.AddScoped<IService<CategoryProductDTO>, Service<CategoryProduct, CategoryProductDTO>>();
            services.AddDependencyInjectionDAL(config);
            return services;
        }
    }
}
