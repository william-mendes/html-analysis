using HtmlAnalysis.Core.Domain.Data;
using HtmlAnalysis.Core.Domain.Entities;
using HtmlAnalysis.Service.Contracts.Adapters;
using HtmlAnalysis.Service.Contracts.Services;

namespace HtmlAnalysis.Service.Implementation.Adapters
{
    public class FrequencyAdapter : IFrequencyAdapter
    {
        private readonly IEncryptionService _encryptionService;

        public FrequencyAdapter(IEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }

        public FrequencyEntity ToFrequencyEntity(Frequency frequency)
        {
            var salt = _encryptionService.NewSalt;
            var saltedHash = _encryptionService.SaltedHash(frequency.Word, salt);
            var frequencyEntity = new FrequencyEntity();
            frequencyEntity.SaltedHash = saltedHash;
            frequencyEntity.EncryptedWord = _encryptionService.EncryptWord(frequency.Word);
            frequencyEntity.Count = frequency.Count;
            return frequencyEntity;
        }

        public Frequency ToIFrequency(FrequencyEntity frequencyEntity)
        {
            var word = _encryptionService.DecryptWord(frequencyEntity.EncryptedWord);
            return new Frequency(word, frequencyEntity.Count);
        }
    }
}