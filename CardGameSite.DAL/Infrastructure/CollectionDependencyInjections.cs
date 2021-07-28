using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CardGameSite.DAL.EF;
using CardGameSite.DAL.Interfaces;
using CardGameSite.DAL.Entities;
using CardGameSite.DAL.Repositories;


namespace CardGameSite.DAL.Infrastructure
{
    public static class CollectionDependencyInjections
    {
        public static IServiceCollection AddDependencyInjectionDAL(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUnitOfWork<Product>, EFUnitOfWork<Product>>();
            services.AddScoped<IRepository<Product>, FakeProductRepository>();
            

            string connection = config.GetConnectionString("DefaultConnection");
            
            services.AddDbContext<PDbContext>(options =>
                options.UseSqlServer(connection));
               
            return services;
        }
    }
}
