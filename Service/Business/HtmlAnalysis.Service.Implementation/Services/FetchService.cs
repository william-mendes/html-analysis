using HtmlAnalysis.DataAccess.Database.Contracts;
using HtmlAnalysis.Domain.Data;
using HtmlAnalysis.Service.Contracts.Services;
using System.Threading.Tasks;

namespace HtmlAnalysis.Service.Implementation.Services
{
    public class FetchService : IFetchService
    {
        private readonly IFetchRepository _repository;

        public FetchService(IFetchRepository repository)
        {
            _repository = repository;
        }

        public async Task<Fetch> ProcessAsync(Document document)
        {
            var fetch = new Fetch(document);
            await _repository.PersistAsync(fetch, 100);
            return fetch;
        }
    }
}