using HtmlAnalysis.Core.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HtmlAnalysis.Settings
{
    public static class OptionRegister
    {
        public static IServiceCollection ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStrings>(configuration.GetSection<ConnectionStrings>());

            return services;
        }

        private static IConfigurationSection GetSection<T>(this IConfiguration configuration)
        {
            var sectionName = typeof(T).Name;

            return configuration.GetSection(sectionName);
        }
    }
}
