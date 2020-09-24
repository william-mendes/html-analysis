using HtmlAnalysis.Core.Domain.Data;
using Moq;

namespace HtmlAnalysis.TestFixtures
{
    public static class FrequencyFixtures
    {
        public static Mock<Frequency> Frequency(string word, int count) {
            var mock = new Mock<Frequency>();
            mock.SetupGet(x => x.Word).Returns(word);
            mock.SetupGet(x => x.Count).Returns(count);
            return mock;
        }
    }
}
