using CardGameSite.BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CardGameSite.DAL.Infrastructure;
using CardGameSite.DAL.Entities;
using CardGameSite.BLL.DTO;
using CardGameSite.BLL.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using System;


namespace CardGameSite.BLL.Infrastructure
{
    public static class CollectionDependencyInjections
    {
        public static IServiceCollection AddServiceCollection(this IServiceCollection services, IConfiguration config)
        {            
            services.AddTransient<IService<ProductDTO>, Service<Product, ProductDTO>>();
            services.AddTransient<IService<CategoryProductDTO>, Service<CategoryProduct, CategoryProductDTO>>();
            services.AddTransient<IService<UserDTO>, Service<User, UserDTO>>();
            
            return DAL.Infrastructure.CollectionDependencyInjections.AddDependencyInjectionServiceCollection(services, config);
        }

        public static IdentityBuilder AddIdentityBuilder(this IServiceCollection services, Action<IdentityOptions> setupAction)
        {
            return services.AddIdentity<User, Role>(setupAction)
                .AddIdentityBuilder()
                .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider)
                .AddDefaultUI();
        }
    }
}
