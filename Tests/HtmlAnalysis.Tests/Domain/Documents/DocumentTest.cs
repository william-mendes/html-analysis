using HtmlAnalysis.Domain.Data;
using System.Linq;
using Xunit;

namespace HtmlAnalysis.Domain.Documents
{
    public class DocumentTest
    {
        const string Url = "http://www.a-walk-in-the-park.com";
        const string Body = "Today,\nI went to the beach.It was great; there were nice birds flying over the ocean.";

        readonly Document _document;

        public DocumentTest() {

            _document = new Document(Url, Body);
        }

        [Fact]
        public void ExtractPhrasesFromBody_Produces_2_Phrases() {
            Assert.Equal(2, _document.Phrases.Count());
        }

        [Fact]
        public void ExtractPhrasesFromBody_Phrase1_IsExtractedSuccessfully()
        {
            Assert.Equal("Today,\nI went to the beach", _document.Phrases.ToList()[0]);
        }

        [Fact]
        public void ExtractPhrasesFromBody_Phrase2_IsExtractedSuccessfully()
        {
            Assert.Equal("It was great; there were nice birds flying over the ocean", _document.Phrases.ToList()[1]);
        }

        [Fact]
        public void ExtractWordsFrom_Contains_AllWordsOfPhrase_Without_SpecialMarkers() {
            var expected = new[] {
                "Today", "I", "went", "to", "the", "beach",
                "It", "was", "great", "there", "were", "nice", "birds",
                "flying", "over", "the", "ocean"};
            Assert.Equal(expected, _document.Words);
        }

        [Fact]
        public void Words_DoesNot_Distinct() {
            var actual = new Document(Url, Body);
            Assert.Equal(2, actual.Words.Count(word => word.Equals("the")));
        }
    }
}
