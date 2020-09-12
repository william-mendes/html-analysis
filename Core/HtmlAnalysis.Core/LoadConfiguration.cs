using Microsoft.Extensions.Configuration;
using System;

namespace HtmlAnalysis.Core
{
    public class LoadConfiguration
    {
        public static IConfigurationBuilder Configure()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

#if DEBUG
            configBuilder.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json", optional: false, reloadOnChange: true);
#endif
            return configBuilder;
        }
    }
}