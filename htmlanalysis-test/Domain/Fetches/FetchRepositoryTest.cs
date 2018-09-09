using HTMLAnalysis.Infra;
using HTMLAnalysis.TestUtils;
using Xunit;

namespace HTMLAnalysis.Domain.Fetches
{
    public class FetchRepositoryTest
    {
        readonly WebFrequenciesDbContext _context;
        readonly FetchRepository _repository;

        public FetchRepositoryTest()
        {
            _context = TestDbContextUtils.NewTestContext;
            _repository = new FetchRepository(_context);
        }

        [Fact(Skip = "Not yet implemented")]
        public void Persist_Saves_FetchEntity()
        {

        }

        [Fact(Skip = "Not yet implemented")]
        public void Persist_Saves_FrequencyWith_SaltedHashOfWord()
        {

        }

        [Fact(Skip = "Not yet implemented")]
        public void Persist_Saves_FrequencyWith_EncryptedWord()
        {

        }

        [Fact(Skip = "Not yet implemented")]
        public void Persist_Saves_FrequencyWith_Count()
        {

        }

        [Fact(Skip = "Not yet implemented")]
        public void Persist_Saves_Only_Top100Words()
        {

        }

        [Fact(Skip = "Not yet implemented")]
        public void Persist_Updates_WordIfPreexisting()
        {

        }
    }
}
