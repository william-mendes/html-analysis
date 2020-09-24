using HtmlAnalysis.Core.Configs;
using HtmlAnalysis.Core.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HtmlAnalysis.Settings
{
    public static class DbContextRegister
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var dbConnection = serviceProvider.GetRequiredService<IOptions<ConnectionStrings>>();

            services.AddDbContext<WebFrequenciesDbContext>(opt => opt
                .UseLazyLoadingProxies()
                .UseSqlServer(dbConnection.Value.HtmlAnalysisDb));

            return services;
        }
    }
}