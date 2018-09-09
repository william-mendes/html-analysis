using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace HTMLAnalysis.Domain.Encryption
{
    public class EncryptionServiceTest
    {
        readonly IConfiguration _configuration;
        readonly IEncryptionService _service;

        public EncryptionServiceTest()
        {
            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string> {
                    { "EncryptionKey" , "BwIAAACkAABSU0EyAAQAAAEAAQA3LyN+L7nzQ+YpvPM2H406wD81kaeOUZw86tSk0+7c5rrXYKD9BDE9KHAKhzzyMfi0Nl/MTCeWV4iyRwp7pyS4VJl6c1JOLSQ+yMVHxv7r05TVk86oBNzmTG7wsxF5qbf1rVbWuW70PpzNLM/chFxGZKIonCMrjR7sRFM4Oqg+ztPHQvRnfExmooNbpibeL2tMLHwSGR0H57KWY1q55NiZ60xoJz+vcZ9arqmrV85XablDvHNowN9yEvxDsUkxP/GNYGQ0uCpJfQ4ZTv3g/KY8s/xjvuBcECOS339QpNeIQCCufFlQyGV+fyvPrBH0+twkgYmTYNd3sr+C3118ftvaneibldnRKvEF06l9zBcxuuM1fOrjlKZaREkJYA0BZEoehA0RNOGgiyRZ5AlzatxBQEcPCL+K4/F9BOUbEFEsYUF3is5+jEXEe3rEc9XdVjcKZUw0dBUixR2G1m30oXJwmrVeSMs94pTyoop19H7eD3N5GX5OHiC1MxUs/cmmTRtQxXaz5fkpveY/kfylegqBqupJJIQIH1GSuMxfyto5sGdUbn61FRZneLJVuPlF9zfwhH6gS0hSH2I0p2puiNJrUWTQGgOuNantwaRw5kf74dTtNPh+VfVMUIP1MRvRx+Fm01B4yDqmgJkIApVKptkCgtLdWDf3usHI2HZqQMD91LyBDDHaIedXEWVXqhaWJ9qWH6bq9NPLzp4hsNz/IaP1CoVm5Jo2/eyyoydgfR3Jxdss0+GAkEnioYNSF7H5qpk=" }
                })
                .Build();


            _service = new EncryptionService(_configuration);
        }

        [Fact]
        public void SaltedHash_OfWordAndSalt_Produces_ExpectedHash()
        {
            var expected = "43ddd11b582e9ff2a3ed93baf4cbda815873c640f5292c748eb88213b74db514";
            var actual = _service.SaltedHash("word", "salt");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EncryptWord_Produces_Decryptable_String()
        {
            var original = "word";
            var encrypted = _service.EncryptWord(original);
            var decrypted = _service.DecryptWord(encrypted);
            Assert.Equal(original, decrypted);
            Assert.NotEqual(encrypted, decrypted);
        }
    }
}