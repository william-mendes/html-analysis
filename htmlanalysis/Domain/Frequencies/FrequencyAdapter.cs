namespace HTMLAnalysis.Domain.Frequencies
{
    public class FrequencyAdapter : IFrequencyAdapter
    {
        private readonly IEncryptionService _encryptionService;

        public FrequencyAdapter(IEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }

        public FrequencyEntity ToFrequencyEntity(IFrequency frequency)
        {
            var salt = _encryptionService.NewSalt;
            var saltedHash = _encryptionService.SaltedHash(frequency.Word, salt);
            var frequencyEntity = new FrequencyEntity();
            frequencyEntity.SaltedHash = saltedHash;
            frequencyEntity.EncryptedWord = _encryptionService.EncryptWord(frequency.Word);
            frequencyEntity.Count = frequency.Count;
            return frequencyEntity;
        }

        public IFrequency ToIFrequency(FrequencyEntity frequencyEntity)
        {
            var word = _encryptionService.DecryptWord(frequencyEntity.EncryptedWord);
            return new Frequency(word, frequencyEntity.Count);
        }
    }
}