using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIS.MGT.Core;
using MGT.AIS.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSwag.AspNetCore;

namespace MGT.AIS
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
            services.AddMvc(options =>
            {
                options.Filters.Add<HttpGlobalExceptionFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.ConfigureMediatR();
            services.ConfigureRepository();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(err =>
            {
                var message = err.ApplicationServices;
            });
                app.UseHsts();
            }

            app.UseCors(builder => builder
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials());

            app.UseSwagger(Configuration);
            // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
