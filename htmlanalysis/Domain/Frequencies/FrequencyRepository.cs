using System.Collections.Generic;
using System.Linq;
using HTMLAnalysis.Infra;

namespace HTMLAnalysis.Domain.Frequencies
{
    public class FrequencyRepository : IFrequencyRepository
    {
        private readonly IFrequencyAdapter _adapter;
        private readonly WebFrequenciesDbContext _context;

        public FrequencyRepository(
            IFrequencyAdapter adapter,
            WebFrequenciesDbContext context)
        {
            _adapter = adapter;
            _context = context;
        }

        public IEnumerable<IFrequency> GetConsolidated()
        {
            var map = MapFrequencies();
            return ReduceFrequenciesOf(map);
        }

        IEnumerable<IFrequency> MapFrequencies()
        {
            return _context
                .Frequencies
                .OrderByDescending(d => d.Count)
                .Select(frequencyEntity => _adapter.ToIFrequency(frequencyEntity))
                .ToArray();
        }

        IEnumerable<IFrequency> ReduceFrequenciesOf(IEnumerable<IFrequency> map)
        {
            var dictionary = new Dictionary<string, int>();
            foreach (var frequency in map)
            {
                var currentCount = dictionary.GetValueOrDefault(frequency.Word, 0);
                dictionary[frequency.Word] = currentCount + frequency.Count;
            }

            return dictionary
                .ToList()
                .OrderByDescending(kv => kv.Value)
                .Select(kv => new Frequency(kv.Key, kv.Value))
                .ToArray();
        }
    }
}