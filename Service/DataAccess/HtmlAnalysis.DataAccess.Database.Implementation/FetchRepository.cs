using HtmlAnalysis.Core.DataAccess;
using HtmlAnalysis.Core.Domain.Entities;
using HtmlAnalysis.DataAccess.Database.Contracts;
using HtmlAnalysis.Domain.Data;
using HtmlAnalysis.Service.Contracts.Adapters;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlAnalysis.DataAccess.Database.Implementation
{
    public class FetchRepository : IFetchRepository
    {
        private readonly IFrequencyAdapter _frequencyAdapter;
        private readonly WebFrequenciesDbContext _context;

        public FetchRepository(
            IFrequencyAdapter frequencyAdapter,
            WebFrequenciesDbContext context)
        {
            _frequencyAdapter = frequencyAdapter;
            _context = context;
        }

        public async Task PersistAsync(Fetch fetch, int n)
        {
            var entity = await PersistFetchAsync(fetch);
            await PurgeFrequenciesIfExistingOf(entity);
            await PersistFrequenciesAsync(fetch, entity, n);
        }

        async Task<FetchEntity> PersistFetchAsync(Fetch fetch)
        {
            var entity = _context.Fetches.SingleOrDefault(f => f.Source == fetch.Source);
            if (entity == null)
            {
                entity = new FetchEntity();
                entity.Source = fetch.Source;
                _context.Fetches.Add(entity);
                await _context.SaveChangesAsync();
            }

            return entity;
        }

        async Task PurgeFrequenciesIfExistingOf(FetchEntity fetchEntity)
        {
            if (fetchEntity.Frequencies != null && fetchEntity.Frequencies.Any())
            {
                _context.Frequencies.RemoveRange(fetchEntity.Frequencies);
                await _context.SaveChangesAsync();
            }
        }

        async Task PersistFrequenciesAsync(Fetch fetch, FetchEntity fetchEntity, int n)
        {
            if (fetch.Frequencies != null && fetch.Frequencies.Any())
            {
                foreach (var frequency in fetch.Frequencies.Take(n))
                {
                    var frequencyEntity = _frequencyAdapter.ToFrequencyEntity(frequency);
                    frequencyEntity.Fetch = fetchEntity;
                    _context.Frequencies.Add(frequencyEntity);
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}