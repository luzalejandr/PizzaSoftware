using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace PizzaSoft.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
              .ReadFrom.Configuration(config)
              .CreateLogger();

            try
            {
                Log.Information("Iniciando sistema");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "sistema falló al iniciarse");
            }
            finally
            {
                Log.Information("Finalizando sistema");
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel((options) =>
                    {
                        options.AddServerHeader = false;
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
