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
            services.AddTransient<IService<ProductDTO>, Service<Product, ProductDTO>>();
            services.AddTransient<IService<CategoryProductDTO>, Service<CategoryProduct, CategoryProductDTO>>();
            services.AddTransient<IService<UserDTO>, Service<User, UserDTO>>();

            //services.AddScoped<DataManagerServices>();

            return DAL.Infrastructure.CollectionDependencyInjections.AddDependencyInjectionServiceCollection(services, config);
        }

        public static IdentityBuilder AddDependencyInjectionIdentityBuilder(this IdentityBuilder builder)
        {
            return DAL.Infrastructure.CollectionDependencyInjections.AddDependencyInjectionIdentityBuilder(builder);
        }
    }
}
