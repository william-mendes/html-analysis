using Autofac.Extensions.DependencyInjection;
using HtmlAnalysis.Core;
using HtmlAnalysis.Core.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HtmlAnalysis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = LoadConfiguration.Configure().Build();

            var host = BuildWebHostBuilder(args, config);

            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<WebFrequenciesDbContext>();

                context.Database.Migrate();
            }

            host.Run();
        }

        public static IHost BuildWebHostBuilder(string[] args, IConfiguration config)
        {
            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureAppConfiguration(configBuilder =>
                {
                    configBuilder = LoadConfiguration.Configure();
                })
                .ConfigureWebHostDefaults(webHostBuilder =>
                {
                    webHostBuilder
                    .UseConfiguration(config)
                    .UseStartup<Startup>();
                })
                .Build();
        }
    }
}