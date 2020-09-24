using System.Linq;
using HtmlAnalysis.Core.DataAccess;
using HtmlAnalysis.Core.Domain.Entities;
using HtmlAnalysis.DataAccess.Database.Contracts;
using HtmlAnalysis.DataAccess.Database.Implementation;
using HtmlAnalysis.Service.Contracts.Services;
using HtmlAnalysis.Service.Implementation.Adapters;
using HtmlAnalysis.TestUtils;
using Moq;
using Xunit;

namespace HtmlAnalysis.Domain.Frequencies
{
    /// <summary>
    /// Frequency repository slice test.
    /// Covers integration of the slice <see cref="IFrequencyRepository"/>,
    /// <see cref="IFrequencyAdapter"/>, <see cref="WebFrequenciesDbContext"/>.
    /// Mocks <see cref="IEncryptionService"/>.
    /// </summary>
    public class FrequencyRepositorySliceTest
    {
        private static readonly WebFrequenciesDbContext _context;
        private static Mock<IDbContextFactory> _contextFactoryMock;
        private readonly Mock<IEncryptionService> _encryptionServiceMock;

        static FrequencyRepositorySliceTest()
        {
            _context = TestDbContextUtils.NewTestContext;
            _context.Frequencies.Add(new FrequencyEntity { @EncryptedWord = "encrypted1", Count = 15 });
            _context.Frequencies.Add(new FrequencyEntity { @EncryptedWord = "encrypted2", Count = 20 });
            _context.SaveChanges();

            _contextFactoryMock.Setup(x => x.GetContext()).Returns(_context);
        }

        public FrequencyRepositorySliceTest()
        {
            _encryptionServiceMock = new Mock<IEncryptionService>();
            _encryptionServiceMock.Setup(x => x.DecryptWord("encrypted1")).Returns("word1");
            _encryptionServiceMock.Setup(x => x.DecryptWord("encrypted2")).Returns("word1");

        }

        [Fact]
        public void GetConsolidated_Returns_SingleConsolidateItem()
        {
            Assert.Single(Repository.GetConsolidated());
        }

        [Fact]
        public void GetConsolidated_Returns_ConsolidatedItem_FindsTheRightWord()
        {
            Assert.Contains(Repository.GetConsolidated(), x => x.Word.Equals("word1"));
        }

        [Fact]
        public void GetConsolidated_Returns_ConsolidatedItem_ConsolidatedCount()
        {
            Assert.Equal(35, Repository.GetConsolidated().ToList()[0].Count);
        }

        IFrequencyRepository Repository => new FrequencyRepository(
            new FrequencyAdapter(_encryptionServiceMock.Object), _contextFactoryMock.Object);
    }
}