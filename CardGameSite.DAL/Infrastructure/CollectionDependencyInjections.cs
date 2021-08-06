using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CardGameSite.DAL.EF;
using CardGameSite.DAL.Repositories.Interfaces;
using CardGameSite.DAL.Repositories.Implementations;
using CardGameSite.DAL.Entities;
using CardGameSite.DAL.Repositories;


namespace CardGameSite.DAL.Infrastructure
{
    public static class CollectionDependencyInjections
    {
        public static IServiceCollection AddDependencyInjectionDAL(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUnitOfWork<Product>, UnitOfWork<Product>>();
            services.AddScoped<IUnitOfWork<CategoryProduct>, UnitOfWork<CategoryProduct>>();
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IRepository<CategoryProduct>, Repository<CategoryProduct>>();

            services.AddDbContext<SiteDbContext>(options =>
                options.UseSqlServer(
                   config.GetConnectionString("DefaultConnection")));
            
            return services;
        }
    }
}
