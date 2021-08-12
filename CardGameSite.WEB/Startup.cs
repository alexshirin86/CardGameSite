using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;
using CardGameSite.BLL.Infrastructure;
using CardGameSite.WEB.AutoMapper;
using CardGameSite.BLL.AutoMapper;
using CardGameSite.WEB.Models;
using CardGameSite.BLL.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;


namespace CardGameSite.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            // Настройка хранилища данных в памяти.
            services.AddDistributedMemoryCache();
            // Регистрирация службы, используемой для доступа к данным се­анса.
            services.AddSession();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                   

            // Конфигурация AutoMapper
            MapperConfiguration mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new WebMapping()); 
                cfg.AddProfile(new BllMapping());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            // зависимости       
            services.AddServiceCollectionBL(Configuration);

            services.AddIdentityBL(
                options =>
                {
                    options.Password.RequireNonAlphanumeric = false;
                    options.SignIn.RequireConfirmedEmail = false;
                });

            services.AddScoped<AppUserManager>();
            services.AddScoped<AppSignInManager>();
            services.AddScoped<AppRoleManager>();
            services.AddScoped<DataManagerServices>();
                       
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            // Автоматическое ассоцииро­вание запросов которые поступают от клиента с сеансами.
            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();

                endpoints.MapControllerRoute("catpage",
                    "{category}/Page{productPage:int}",
                    new { Controller = "Store", action = "Store" });
                endpoints.MapControllerRoute("page", "Page{productPage:int}",
                    new { Controller = "Store", action = "Store", productPage = 1 });
                endpoints.MapControllerRoute("category", "{category}",
                    new { Controller = "Store", action = "Store", productPage = 1 });
                endpoints.MapControllerRoute("pagination",
                    "Products/Page{productPage}",
                    new { Controller = "Store", action = "Store", productPage = 1 });
                
                

                endpoints.MapControllerRoute(
                    name: "store", 
                    pattern: "{controller=Store}/{action=Store}");

                endpoints.MapControllerRoute(
                    name: "users",
                    pattern: "{controller=UserManager}/{action=Index}");

            });
        }
    }
}
