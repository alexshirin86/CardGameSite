using CardGameSite.BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CardGameSite.BLL.Services;


namespace CardGameSite.BLL.Infrastructure
{
    public static class CollectionDependencyInjections
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration config)
        {
            services.AddDependencyInjection(config);
            services.AddSingleton<IOrderService, OrderService>();            
            return services;
        }
    }
}
