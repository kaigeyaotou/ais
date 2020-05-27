using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MGT.AIS.Config;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace MGT.AIS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            Directory.SetCurrentDirectory(Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath);

            var configuration = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
                               .AddJsonFile(path: $"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                               .Build();
            var address = configuration.ConfigureHttpBase();

            return WebHost.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IConfiguration>(configuration);
                    services.AddSingleton(address);
                    services.AddTransient<IDbConnection>(sp =>
                    {
                        var dbconnection = configuration.GetSection("DBConnection").Value;
                        return new SqlConnection(dbconnection);
                    });
                })
                    .UseIISIntegration()
                    .UseKestrel()
                    .UseUrls("http://*:80", "http://*:53713")
                    //.UseUrls("http://*:53713")
                    .UseStartup<Startup>();

        }
    }
}
