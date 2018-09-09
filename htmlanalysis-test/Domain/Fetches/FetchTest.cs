using System.Collections.Generic;
using System.Linq;
using HTMLAnalysis.Domain.Documents;
using Moq;
using Xunit;

namespace HTMLAnalysis.Domain.Fetches
{
    public class FetchTest
    {
        static readonly IEnumerable<string> Words = new[] { "word1", "word2", "word1", "word3", "word1", "word4", "word31" };

        readonly Mock<IDocument> _documentMock;
        readonly Fetch _analysis;

        public FetchTest()
        {
            _documentMock = new Mock<IDocument>();
            _documentMock.SetupGet(x => x.Words).Returns(Words);

            _analysis = new Fetch(_documentMock.Object);
        }

        [Fact]
        public void ExtractFrequenciesFrom_PresentAllWordsFrom_DocumentBody() {
            Assert.All(
                Words.Distinct(),
                wordOfBody => Assert.Contains(_analysis.Frequencies, f => f.Word.Equals(wordOfBody)));
        }

        [Fact]
        public void ExtractFrequenciesFrom_Counts_3_For_Word1() {
            Assert.Equal(3, _analysis.FrequencyOf("word1"));
        }

        [Fact]
        public void ExtractFrequenciesFrom_Counts_1_For_Word2()
        {
            Assert.Equal(1, _analysis.FrequencyOf("word2"));
        }

        [Fact]
        public void ExtractFrequenciesFrom_Counts_1_For_Word3()
        {
            Assert.Equal(1, _analysis.FrequencyOf("word3"));
        }

        [Fact]
        public void ExtractFrequenciesFrom_Counts_1_For_Word31()
        {
            Assert.Equal(1, _analysis.FrequencyOf("word31"));
        }
    }
}
