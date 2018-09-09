using Xunit;

namespace HTMLAnalysis.Domain.Encryption
{
    public class EncryptionServiceTest
    {
        readonly IEncryptionService _service;

        public EncryptionServiceTest()
        {
            _service = new EncryptionService();
        }

        [Fact]
        public void SaltedHash_OfWordAndSalt_Produces_ExpectedHash()
        {
            var expected = "43ddd11b582e9ff2a3ed93baf4cbda815873c640f5292c748eb88213b74db514";
            var actual = _service.SaltedHash("word", "salt");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EncryptWord_Produces_ExpectedEncryption()
        {
            var expected = "ZnMACzTjk5RVrWGs5eebOSndQYdwGkLvuNJusN6+r0G8gXzihtlyQ7KAkyeor608nIIqmdaLGbofCGG/qG7NAJaqpHtjrYyfyooLRnFWCam15t6/pzMlS9InS/daYgA4dMy+wMR2hUGtyFCthew/e12m2swZgvChdFOF6EZVUPQ=";
            var actual = _service.EncryptWord("word");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DecryptWord_Produces_ExpectedDecryption()
        {
            var expected = "word";
            var actual = _service.DecryptWord("ZnMACzTjk5RVrWGs5eebOSndQYdwGkLvuNJusN6+r0G8gXzihtlyQ7KAkyeor608nIIqmdaLGbofCGG/qG7NAJaqpHtjrYyfyooLRnFWCam15t6/pzMlS9InS/daYgA4dMy+wMR2hUGtyFCthew/e12m2swZgvChdFOF6EZVUPQ=");
            Assert.Equal(expected, actual);
        }
    }
}