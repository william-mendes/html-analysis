using HTMLAnalysis.Domain.Documents;

namespace HTMLAnalysis.Domain.Fetches
{
    public class FetchService : IFetchService
    {
        public IFetch Analyse(IDocument document)
        {
            return new Fetch(document);
        }
    }
}
