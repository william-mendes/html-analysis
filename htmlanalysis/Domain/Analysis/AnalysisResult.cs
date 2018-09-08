using System.Collections.Generic;
using System.Linq;
using HTMLAnalysis.Domain.Documents;
using HTMLAnalysis.Domain.Frequencies;

namespace HTMLAnalysis.Domain.Analysis
{
    public class AnalysisResult
    {
        public AnalysisResult(Document document)
        {
            Frequencies = FrequencyListFrom(document);
        }

        public IEnumerable<Frequency> Frequencies { get; private set; }

        public int? FrequencyOf(string word) => 
            Frequencies
                .FirstOrDefault(f => f.Word.Equals(word))
                ?.Count;

        static IEnumerable<Frequency> FrequencyListFrom(Document document) => 
            ExtractFrequenciesFrom(document)
                .ToList()
                .OrderByDescending(d => d.Value)
                .ToArray()
                .Select(pair => new Frequency(pair.Key, pair.Value))
                .Take(100)
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