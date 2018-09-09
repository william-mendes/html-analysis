using HTMLAnalysis.Domain.Fetches;
using HTMLAnalysis.Domain.Frequencies;
using Microsoft.EntityFrameworkCore;

namespace HTMLAnalysis.Infra
{
    public class WebFrequenciesDbContext : DbContext
    {
        public WebFrequenciesDbContext(DbContextOptions<WebFrequenciesDbContext> options) : base(options) { }

        public DbSet<FetchEntity> Fetches { get; set; }

        public DbSet<FrequencyEntity> Frequencies { get; set; }
    }
}