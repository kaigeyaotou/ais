using AIS.MGT.Api;
using MGT.AIS.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using NSwag;
using NSwag.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGT.AIS
{
    public static class SwaggerConfigExtensions
    {
        public static void UseSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            // INFO: 在这里配置更多的 Controller 程序集。
            var controllerAssemblies = new[]
            {
                typeof(AISController).Assembly,
                typeof(PreminumFinanceController).Assembly
            };

            List<SwaggerSchema> schemes = new List<SwaggerSchema>();
            //schemes.Add(SwaggerSchema.Undefined);
            schemes.Add(SwaggerSchema.Http);
            schemes.Add(SwaggerSchema.Https);


            // Enable the Swagger UI middleware and the Swagger generator
            app.UseSwaggerUi3(controllerAssemblies, settings =>
            {
                settings.SwaggerUiRoute = "/docs";
                //settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
                settings.PostProcess = document =>
                {
                    document.Info.Title = "AIS Api";
                    //document.Info.Version = Program.Version;
                    document.Schemes = schemes;
                };

            });



        }
    }
}
