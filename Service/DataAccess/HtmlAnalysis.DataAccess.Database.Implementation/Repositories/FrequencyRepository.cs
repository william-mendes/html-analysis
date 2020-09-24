using HtmlAnalysis.Core.DataAccess;
using HtmlAnalysis.Core.Domain.Data;
using HtmlAnalysis.DataAccess.Database.Contracts;
using HtmlAnalysis.Service.Contracts.Adapters;
using System.Collections.Generic;
using System.Linq;

namespace HtmlAnalysis.DataAccess.Database.Implementation
{
    public class FrequencyRepository : IFrequencyRepository
    {
        private readonly IFrequencyAdapter _adapter;
        private readonly WebFrequenciesDbContext _context;

        public FrequencyRepository(
            IFrequencyAdapter adapter,
            IDbContextFactory dbContextFactory)
        {
            _adapter = adapter;
            _context = (WebFrequenciesDbContext)dbContextFactory.GetContext();
        }

        public IEnumerable<Frequency> GetConsolidated()
        {
            var map = MapFrequencies();
            return ReduceFrequenciesOf(map);
        }

        IEnumerable<Frequency> MapFrequencies()
        {
            return _context
                .Frequencies
                .OrderByDescending(d => d.Count)
                .Select(frequencyEntity => _adapter.ToIFrequency(frequencyEntity))
                .ToArray();
        }

        IEnumerable<Frequency> ReduceFrequenciesOf(IEnumerable<Frequency> map)
        {
            var dictionary = new Dictionary<string, int>();
            foreach (var frequency in map)
            {
                var currentCount = dictionary.GetValueOrDefault(frequency.Word, 0);
                dictionary[frequency.Word] = currentCount + frequency.Count;
            }

            return dictionary
                .ToList()
                .Select(kv => new Frequency(kv.Key, kv.Value))
                .OrderByDescending(kv => kv.Count)
                .Take(100)
                .ToArray();
        }
    }
}