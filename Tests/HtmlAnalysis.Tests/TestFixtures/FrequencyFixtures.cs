using Moq;

namespace HtmlAnalysis.TestFixtures
{
    public static class FrequencyFixtures
    {
        public static Mock<IFrequency> Frequency(string word, int count) {
            var mock = new Mock<IFrequency>();
            mock.SetupGet(x => x.Word).Returns(word);
            mock.SetupGet(x => x.Count).Returns(count);
            return mock;
        }
    }
}
