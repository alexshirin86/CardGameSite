using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CardGameSite.DAL.EF;
using CardGameSite.DAL.Interfaces;
using CardGameSite.DAL.Repositories;

namespace CardGameSite.DAL.Extensions
{
    public static class CollectionDependencyInjections
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration config)
        {
            string connection = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<PDbContext>(options =>
                options.UseSqlServer(connection));

            services.AddSingleton<IUnitOfWork, EFUnitOfWork>();

            return services;
        }
    }
}
