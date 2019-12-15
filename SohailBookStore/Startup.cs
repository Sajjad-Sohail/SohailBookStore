using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SohailBookStore.Data;
using SohailBookStore.Models;
using SohailBookStore.Services;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Startup
    {
        private IConfiguration configuration;

        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
          //  services.AddMvc();// to let the .NET framework and the web server know how to process incoming requests etc.
            services.AddControllersWithViews();
            services.AddDbContext<SohailBookStoreDbContext>(dbContextOptionBuilder =>
            dbContextOptionBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Sohail;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddScoped<IRepository<Book>, SqlBooksRepository>();
            services.AddScoped<IRepository<Carousel>, SqlCarouselRepository>();
            services.AddScoped<IRepository<Order>, SqlOrderRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();
            logger.LogInformation("Response serving");
             
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                   
        });

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "shop",
                    pattern: "{controller=Product}/{action=Index}/{id?}");

            });
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "user",
                    pattern: "{controller=User}/{action=Index}/{id?}");

            });


        }
    }
}
