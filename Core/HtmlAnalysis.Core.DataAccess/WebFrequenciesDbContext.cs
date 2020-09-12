using HtmlAnalysis.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HtmlAnalysis.Core.DataAccess
{
    public class WebFrequenciesDbContext : DbContext
    {
        public WebFrequenciesDbContext(DbContextOptions<WebFrequenciesDbContext> options) : base(options) { }

        public DbSet<FetchEntity> Fetches { get; set; }

        public DbSet<FrequencyEntity> Frequencies { get; set; }
    }
}