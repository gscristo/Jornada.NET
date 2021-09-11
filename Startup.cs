using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WebApiRest.Persistence;
using WebApiRest.Persistence.Repositories;
using WebApiRest.Profiles;

namespace WebApiRest
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
        {   var connectionString = "Server=localhost\\SQLEXPRESS;Database=ApiJornada;user=sa;password=Isis@3004;MultipleActiveResultSets=true;";
            services.AddAutoMapper(typeof(ProductProfile));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddDbContext<DataContext>(o => o.UseSqlServer(connectionString));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", 
                new OpenApiInfo { 
                    Title = "WebApiRest",
                     Version = "v1",
                     Contact = new OpenApiContact{
                         Name = "GustavoCristo",
                         Email = "gustavo.cristo@itlean.com",
                         Url = new Uri("https://www.linkedin.com/in/gustavo-cristo-a9a584133/")
                     } 
                     });

                     var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiRest v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
