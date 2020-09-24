using HtmlAnalysis.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HtmlAnalysis.Core.DataAccess
{
    public class WebFrequenciesDbContext : DbContext
    {
        public WebFrequenciesDbContext(DbContextOptions<WebFrequenciesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FetchEntity> Fetches { get; set; }

        public virtual DbSet<FrequencyEntity> Frequencies { get; set; }
    }
}