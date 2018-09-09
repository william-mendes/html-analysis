using Xunit;

namespace HTMLAnalysis.Domain.Encryption
{
    public class EncryptionServiceTest
    {
        IEncryptionService _service;

        public EncryptionServiceTest()
        {
            _service = new EncryptionService();
        }

        [Fact]
        public void SaltedHash_OfWordAndSalt_Produces_ExpectedHash() {
            var expected = "43ddd11b582e9ff2a3ed93baf4cbda815873c640f5292c748eb88213b74db514";
            var actual = _service.SaltedHash("word", "salt");
            Assert.Equal(expected, actual);
        }
    }
}