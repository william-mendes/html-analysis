using System.Threading.Tasks;

namespace HTMLAnalysis.Domain.Fetches
{
    public class FetchService : IFetchService
    {
        readonly IFetchRepository _repository;

        public FetchService(IFetchRepository repository)
        {
            _repository = repository;
        }

        public async Task<IFetch> ProcessAsync(IDocument document)
        {
            var fetch = new Fetch(document);
            await _repository.PersistAsync(fetch, 100);
            return fetch;
        }
    }
}
