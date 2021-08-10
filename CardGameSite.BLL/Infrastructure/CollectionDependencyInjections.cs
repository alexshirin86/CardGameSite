using CardGameSite.BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CardGameSite.DAL.Infrastructure;
using CardGameSite.DAL.Entities;
using CardGameSite.BLL.DTO;
using CardGameSite.BLL.Services.Implementations;
using Microsoft.AspNetCore.Identity;


namespace CardGameSite.BLL.Infrastructure
{
    public static class CollectionDependencyInjections
    {
        public static IServiceCollection AddDependencyInjectionServiceCollection(this IServiceCollection services, IConfiguration config)
        {            
            services.AddScoped<IService<ProductDTO>, Service<Product, ProductDTO>>();
            services.AddScoped<IService<CategoryProductDTO>, Service<CategoryProduct, CategoryProductDTO>>();
            services.AddScoped<IService<UserDTO>, Service<User, UserDTO>>();

            return DAL.Infrastructure.CollectionDependencyInjections.AddDependencyInjectionServiceCollection(services, config);
        }

        public static IdentityBuilder AddDependencyInjectionIdentityBuilder(this IdentityBuilder builder)
        {
            return DAL.Infrastructure.CollectionDependencyInjections.AddDependencyInjectionIdentityBuilder(builder);
        }
    }
}
