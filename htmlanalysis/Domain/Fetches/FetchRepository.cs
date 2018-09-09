using HTMLAnalysis.Infra;

namespace HTMLAnalysis.Domain.Fetches
{
    public class FetchRepository : IFetchRepository
    {
        readonly WebFrequenciesDbContext _context;

        public FetchRepository(WebFrequenciesDbContext context)
        {
            _context = context;
        }

        public void Persist(IFetch fetch)
        {
            throw new System.NotImplementedException();
        }
    }
}
