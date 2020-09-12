using System.Linq;
using HtmlAnalysis.TestFixtures;
using HtmlAnalysis.TestUtils;
using Moq;
using Xunit;

namespace HtmlAnalysis.Domain.Fetches
{
    public class FetchRepositorySliceTest
    {
        readonly WebFrequenciesDbContext _context;
        readonly Mock<IEncryptionService> _encryptionServiceMock;
        readonly Mock<IFetch> _fetchMock;

        public FetchRepositorySliceTest()
        {
            _context = TestDbContextUtils.NewTestContext;
            _encryptionServiceMock = new Mock<IEncryptionService>();
            _fetchMock = FetchFixtures.StanfordCoreNLPWithRandomUrl;
        }

        [Fact]
        public void Persist_Saves_FetchEntity()
        {
            var fetch = _fetchMock.Object;
            Assert.DoesNotContain(_context.Fetches, f => f.Source == fetch.Source);
            Repository.PersistAsync(fetch, 0);
            Assert.Contains(_context.Fetches, f => f.Source == fetch.Source);
        }

        [Fact]
        public void Persist_DifferentUrls_Save2Fetches()
        {
            var count = _context.Fetches.Count();
            Repository.PersistAsync(FetchFixtures.StanfordCoreNLPWithRandomUrl.Object, 1);
            Repository.PersistAsync(FetchFixtures.StanfordCoreNLPWithRandomUrl.Object, 1);
            Assert.Equal(count + 2, _context.Fetches.Count());
        }

        [Fact]
        public void Persist_Saves_AtLeast1_Frequency()
        {
            var fetch = _fetchMock.Object;
            var count = _context.Frequencies.Count();
            Repository.PersistAsync(fetch, 1);
            Assert.True(count < _context.Frequencies.Count());
        }

        [Fact]
        public void Persist_Saves_FrequencyWith_SaltedHashOfWord()
        {
            var expected = "salted-hash";

            _encryptionServiceMock
                .Setup(x => x.SaltedHash(It.IsAny<string>(), It.IsAny<string>()))
                .Returns<string, string>((word, salt) => expected);

            var fetch = _fetchMock.Object;
            Repository.PersistAsync(fetch, 1);
            Assert.Equal(
                expected,
                _context.Fetches
                    .Single(f => f.Source == fetch.Source)
                    .Frequencies
                    .FirstOrDefault()
                    .SaltedHash);
        }

        [Fact]
        public void Persist_Saves_FrequencyWith_EncryptedWord()
        {
            var expected = "encrypted-word";

            _encryptionServiceMock
                .Setup(x => x.EncryptWord(It.IsAny<string>()))
                .Returns<string>((word) => expected);

            var fetch = _fetchMock.Object;
            Repository.PersistAsync(fetch, 1);
            Assert.Equal(
                expected,
                _context.Fetches
                    .Single(f => f.Source == fetch.Source)
                    .Frequencies
                    .FirstOrDefault()
                    .EncryptedWord);
        }

        [Fact]
        public void Persist_Saves_FrequencyWith_Count()
        {
            var fetch = _fetchMock.Object;
            Repository.PersistAsync(fetch, 1);
            Assert.Equal(
                fetch.Frequencies.ToList()[0].Count,
                _context.Fetches
                    .Single(f => f.Source == fetch.Source)
                    .Frequencies
                    .FirstOrDefault()
                    .Count);
        }

        [Fact]
        public void Persist_Saves_Only_TopNWordsNotMore()
        {
            var expected = 10;
            var fetch = _fetchMock.Object;
            Repository.PersistAsync(fetch, expected);
            Assert.True(fetch.Frequencies.Count() > expected);
            Assert.Equal(
                expected,
                _context.Fetches
                    .Single(f => f.Source == fetch.Source)
                    .Frequencies
                    .Count());
        }

        [Fact]
        public void Persist_Updates_WordIfPreexisting()
        {
            var fetch = _fetchMock.Object;
            var frequencies = fetch.Frequencies.ToList();
            Repository.PersistAsync(fetch, 1);

            var fetch2 = new Mock<Fetch>();
            var frequencyCount2 = frequencies[0].Count + 1;
            var frequencies2 = FrequencyFixtures.Frequency(frequencies[0].Word, frequencyCount2);
            fetch2.Setup(x => x.Source).Returns(fetch.Source);
            fetch2.Setup(x => x.Frequencies).Returns(new[] { frequencies2.Object });
            Repository.PersistAsync(fetch2.Object, 1);

            Assert.Equal(
                frequencyCount2,
                _context.Fetches
                    .Single(f => f.Source == fetch.Source)
                    .Frequencies
                    .FirstOrDefault()
                    .Count);
        }

        IFetchRepository Repository => new FetchRepository(
            new FrequencyAdapter(_encryptionServiceMock.Object),
            _context);
    }
}
