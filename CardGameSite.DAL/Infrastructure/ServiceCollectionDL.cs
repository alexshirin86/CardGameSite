using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CardGameSite.DAL.EF;
using CardGameSite.DAL.Repositories.Interfaces;
using CardGameSite.DAL.Repositories.Implementations;
using CardGameSite.DAL.Entities;
using CardGameSite.DAL.Repositories;
using Microsoft.AspNetCore.Identity;


namespace CardGameSite.DAL.Infrastructure
{
    public static class ServiceCollectionDL
    {
        public static IServiceCollection AddServiceCollectionDL(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUnitOfWork<Product>, UnitOfWork<Product>>();
            services.AddScoped<IUnitOfWork<CategoryProduct>, UnitOfWork<CategoryProduct>>();
            services.AddScoped<IUnitOfWork<User>, UnitOfWork<User>>();

            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IRepository<CategoryProduct>, Repository<CategoryProduct>>();
            services.AddScoped<IRepository<User>, Repository<User>>();

            services.AddDbContext<SiteDbContext>(options =>
                options.UseSqlServer(
                   config.GetConnectionString("DefaultConnection")));


            return services;
        }

        public static IdentityBuilder AddIdentityDL(this IdentityBuilder builder)
        {
            builder.AddEntityFrameworkStores<SiteDbContext>();

            return builder;
        }
    }
}
