using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace RestItemService
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
            services.AddControllers();
            services.AddSwaggerGen(c => //added
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Items API",
                    Version = "v3.2",
                    Description = "Example of OpenAPI for api/localItems",
                    TermsOfService = new Uri("https://www.dr.dk/"),
                    Contact = new OpenApiContact()
                    {
                        Name = "Mikkel",
                        Email = "mikk265a@edu.easj.dk",
                        Url = new Uri("https://worldofwarcraft.com/en-gb/")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "No licence required",
                        Url = new Uri("https://www.zealand.dk/")
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(); //added
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Items API v1.0");
                    c.RoutePrefix = "api/help";
                }
            );

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}