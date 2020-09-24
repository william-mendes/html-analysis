using HtmlAnalysis.Core.Domain.Data;
using System.Collections.Generic;
using System.Linq;

namespace HtmlAnalysis.Domain.Data
{
    public class Fetch
    {
        public Fetch(Document document)
        {
            Source = document.Source;
            Frequencies = FrequencyListFrom(ExtractFrequenciesFrom(document));
        }

        public string Source { get; private set; }

        public IEnumerable<Frequency> Frequencies { get; private set; }

        public int? FrequencyOf(string word) =>
            Frequencies
                .FirstOrDefault(f => f.Word.Equals(word))
                ?.Count;

        static IEnumerable<Frequency> FrequencyListFrom(IDictionary<string, int> dictionary) =>
            dictionary
                .ToList()
                .OrderByDescending(d => d.Value)
                .ToArray()
                .Select(pair => new Frequency(pair.Key, pair.Value))
                .ToArray();

        static IDictionary<string, int> ExtractFrequenciesFrom(Document document) =>
            document
                .Words
                .Distinct()
                .ToDictionary(
                    distinctWord => distinctWord,
                    distinctWord => document.Words.Count(wordInList => string.Compare(wordInList, distinctWord, true) == 0));
    }
}