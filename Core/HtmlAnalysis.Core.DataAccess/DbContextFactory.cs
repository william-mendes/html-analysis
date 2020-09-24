using Microsoft.EntityFrameworkCore;

namespace HtmlAnalysis.Core.DataAccess
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly WebFrequenciesDbContext _context;

        public DbContextFactory(WebFrequenciesDbContext context)
        {
            _context = context;
        }

        public DbContext GetContext()
        {
            return _context;
        }
    }
}
