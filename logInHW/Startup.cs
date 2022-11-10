using BL;
using DL;
using logInHW.Models3;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyLibrary;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using ILogger = NLog.ILogger;

namespace logInHW
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
            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<IUserDL, UserDL>();

            services.AddScoped<IOrdersBl, OrdersBl>();
            services.AddScoped<IOrdersDl, OrdersDl>();

            services.AddScoped<IProductBl, ProductBl>();
            services.AddScoped<IProductDl, ProductDl>();

            services.AddScoped<ICategoriesBl, CategoriesBl>();
            services.AddScoped<ICategoriesDl, CategoriesDl>();
            services.AddDbContext<DL.api212796Context>(options => options.UseSqlServer(
                Configuration.GetConnectionString("Home")
            ), ServiceLifetime.Scoped);

            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "logInHW", Version = "v1" });
            });

            services.AddResponseCaching();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> Logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "logInHW v1"));
            }
            Logger.LogInformation("server is up!");
            // catch all errors by middleware Logger.LogError("ops!!!!!!!!!");
           // app.UseErrorHandlingMiddleware();

            //use rating middleware
            app.UseRatingMiddleware();
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            //use caching middleware/
            app.UseResponseCaching();

            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(20)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };

                await next();
            });


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
