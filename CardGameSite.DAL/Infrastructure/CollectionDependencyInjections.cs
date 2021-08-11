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
    public static class CollectionDependencyInjections
    {
        public static IServiceCollection AddDependencyInjectionServiceCollection(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IUnitOfWork<Product>, UnitOfWork<Product>>();
            services.AddTransient<IUnitOfWork<CategoryProduct>, UnitOfWork<CategoryProduct>>();
            services.AddTransient<IUnitOfWork<User>, UnitOfWork<User>>();

            services.AddTransient<IRepository<Product>, ProductRepository>();
            services.AddTransient<IRepository<CategoryProduct>, Repository<CategoryProduct>>();
            services.AddTransient<IRepository<User>, Repository<User>>();

            services.AddDbContext<SiteDbContext>(options =>
                options.UseSqlServer(
                   config.GetConnectionString("DefaultConnection")));


            return services;
        }

        public static IdentityBuilder AddIdentityBuilder(this IdentityBuilder builder)
        {
            builder.AddEntityFrameworkStores<SiteDbContext>();

            return builder;
        }
    }
}
