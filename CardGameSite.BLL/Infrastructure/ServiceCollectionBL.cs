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
    public static class ServiceCollectionBL
    {
        public static IServiceCollection AddServiceCollectionBL(this IServiceCollection services, IConfiguration config)
        {            
            services.AddTransient<IService<ProductDTO>, Service<Product, ProductDTO>>();
            services.AddTransient<IService<CategoryProductDTO>, Service<CategoryProduct, CategoryProductDTO>>();
            services.AddTransient<IService<UserDTO>, Service<User, UserDTO>>();
            
            return services.AddServiceCollectionDL(config);
        }

        public static IdentityBuilder AddIdentityBL(this IServiceCollection services, Action<IdentityOptions> setupAction)
        {            
            return services.AddIdentity<User, Role>(setupAction)
                .AddIdentityDL()
                .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider)
                .AddDefaultUI();
        }
    }
}
