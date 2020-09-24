using HtmlAnalysis.Core.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HtmlAnalysis.Core.DataAccess
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WebFrequenciesDbContext>
    {
        public WebFrequenciesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WebFrequenciesDbContext>();

            var config = LoadConfiguration.Configure().Build();
            var connectionStrings = config[$"{nameof(ConnectionStrings)}:{nameof(ConnectionStrings.HtmlAnalysisDb)}"];

            optionsBuilder.UseSqlServer(connectionStrings);

            return new WebFrequenciesDbContext(optionsBuilder.Options);
        }
    }
}