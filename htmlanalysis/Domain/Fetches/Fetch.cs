using System.Collections.Generic;
using System.Linq;
using HTMLAnalysis.Domain.Frequencies;

namespace HTMLAnalysis.Domain.Fetches
{
    public class Fetch : IFetch
    {
        public Fetch(IDocument document)
        {
            Source = document.Source;
            Frequencies = FrequencyListFrom(ExtractFrequenciesFrom(document));
        }

        public string Source { get; private set; }

        public IEnumerable<IFrequency> Frequencies { get; private set; }

        public int? FrequencyOf(string word) => 
            Frequencies
                .FirstOrDefault(f => f.Word.Equals(word))
                ?.Count;

        static IEnumerable<IFrequency> FrequencyListFrom(IDictionary<string, int> dictionary) =>
            dictionary
                .ToList()
                .OrderByDescending(d => d.Value)
                .ToArray()
                .Select(pair => new Frequency(pair.Key, pair.Value))
                .Take(100)
                .ToArray();

        static IDictionary<string, int> ExtractFrequenciesFrom(IDocument document) => 
            document
                .Words
                .Distinct()
                .ToDictionary(
                    distinctWord => distinctWord,
                    distinctWord => document.Words.Count(wordInList => string.Compare(wordInList, distinctWord, true) == 0));
    }
}