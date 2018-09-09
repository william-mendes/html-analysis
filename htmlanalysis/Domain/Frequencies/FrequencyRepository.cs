using System.Collections.Generic;
using System.Linq;
using HTMLAnalysis.Infra;

namespace HTMLAnalysis.Domain.Frequencies
{
    public class FrequencyRepository : IFrequencyRepository
    {
        readonly IEncryptionService _encryptionService;
        readonly WebFrequenciesDbContext _context;

        public FrequencyRepository(
            IEncryptionService encryptionService,
            WebFrequenciesDbContext context)
        {
            _encryptionService = encryptionService;
            _context = context;
        }

        public IEnumerable<IFrequency> GetAll()
        {
            return _context.Frequencies
                           .Select(frequencyEntity => ToIFrequency(frequencyEntity))
                           .AsEnumerable();
        }

        IFrequency ToIFrequency(FrequencyEntity frequencyEntity)
        {
            var saltedHash = frequencyEntity.SaltedHash;
            var saltedWord = _encryptionService.UnhashSaltedHash(saltedHash);
            var unsaltedWord = _encryptionService.UnsaltSaltedWord(saltedWord);
            return new Frequency(unsaltedWord, frequencyEntity.Count);
        }
    }
}
