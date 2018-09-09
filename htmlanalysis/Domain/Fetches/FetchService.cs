namespace HTMLAnalysis.Domain.Fetches
{
    public class FetchService : IFetchService
    {
        readonly IFetchRepository _repository;

        public FetchService(IFetchRepository repository)
        {
            _repository = repository;
        }

        public IFetch Analyse(IDocument document)
        {
            var fetch = new Fetch(document);
            _repository.Persist(fetch);
            return fetch;
        }
    }
}
