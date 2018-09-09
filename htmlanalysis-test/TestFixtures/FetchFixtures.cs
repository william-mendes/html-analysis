using HTMLAnalysis.Domain;
using Moq;
using System;
using System.Linq;

namespace HTMLAnalysis.TestFixtures
{
    public static class FetchFixtures
    {
        public static Mock<IFetch> StanfordCoreNLPWithRandomUrl
        {
            get
            {
                var random = Math.Abs(new Random().Next());

                var url = $"https://stanfordnlp.github.io/CoreNLP/?random={random}";

                var frequencies = new IFrequency[] {
                    FrequencyFixtures.Frequency("the", 46).Object,
                    FrequencyFixtures.Frequency("corenlp", 35).Object,
                    FrequencyFixtures.Frequency("to", 24).Object,
                    FrequencyFixtures.Frequency("stanford", 23).Object,
                    FrequencyFixtures.Frequency("of", 23).Object,
                    FrequencyFixtures.Frequency("and", 21).Object,
                    FrequencyFixtures.Frequency("for", 19).Object,
                    FrequencyFixtures.Frequency("a", 18).Object,
                    FrequencyFixtures.Frequency("in", 15).Object,
                    FrequencyFixtures.Frequency("download", 15).Object,
                    FrequencyFixtures.Frequency("is", 13).Object,
                    FrequencyFixtures.Frequency("or", 13).Object,
                    FrequencyFixtures.Frequency("languages", 13).Object,
                    FrequencyFixtures.Frequency("with", 12).Object,
                    FrequencyFixtures.Frequency("java", 12).Object
                };

                var fetchMock = new Mock<IFetch>();

                fetchMock
                    .SetupGet(x => x.Source)
                    .Returns(url);

                fetchMock
                    .SetupGet(x => x.Frequencies)
                    .Returns(frequencies);

                fetchMock
                    .Setup(x => x.FrequencyOf(It.IsAny<string>()))
                    .Returns<string>(word => frequencies
                                     .FirstOrDefault(f => f.Word == word)
                                     ?.Count);

                return fetchMock;
            }
        }
    }
}
