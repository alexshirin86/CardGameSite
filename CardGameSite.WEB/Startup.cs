using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CardGameSite.BLL.Infrastructure;
using CardGameSite.WEB.AutoMapper;
using CardGameSite.BLL.AutoMapper;
using AutoMapper;


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
            
            services.AddDependencyInjectionBLL(Configuration);
            
            services.AddControllersWithViews();
            services.AddRazorPages();
            // Настройка хранилища данных в памяти.
            services.AddDistributedMemoryCache();
            // Регистрирация службы, используемой для доступа к данным се­анса.
            services.AddSession();
            // Конфигурация AutoMapper
            MapperConfiguration mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new WebMapping());  //mapping between Web and Business layer objects
                cfg.AddProfile(new BllMapping());  // mapping between Business and DB layer objects
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
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

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
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
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "store", 
                    pattern: "{controller=Store}/{action=Store}");

                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();

            });
        }
    }
}
