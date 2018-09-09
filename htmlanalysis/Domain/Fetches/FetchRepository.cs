using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HTMLAnalysis.Domain.Frequencies;
using HTMLAnalysis.Infra;

namespace HTMLAnalysis.Domain.Fetches
{
    public class FetchRepository : IFetchRepository
    {
        readonly IEncryptionService _encryptionService;
        readonly WebFrequenciesDbContext _context;

        public FetchRepository(
            IEncryptionService encryptionService,
            WebFrequenciesDbContext context)
        {
            _encryptionService = encryptionService;
            _context = context;
        }

        public async Task PersistAsync(IFetch fetch, int n)
        {
            var entity = await PersistFetchAsync(fetch);
            await PurgeFrequenciesIfExistingOf(entity);
            await PersistFrequenciesAsync(fetch, entity, n);
        }

        async Task<FetchEntity> PersistFetchAsync(IFetch fetch)
        {
            var entity = _context.Fetches.SingleOrDefault(f => f.Source == fetch.Source);
            if (entity == null)
            {
                entity = new FetchEntity();
                entity.Source = fetch.Source;
                _context.Fetches.Add(entity);
                await _context.SaveChangesAsync();
            }

            return entity;
        }

        async Task PurgeFrequenciesIfExistingOf(FetchEntity fetchEntity)
        {
            if (fetchEntity.Frequencies != null && fetchEntity.Frequencies.Any())
            {
                _context.Frequencies.RemoveRange(fetchEntity.Frequencies);
                await _context.SaveChangesAsync();
            }
        }

        async Task PersistFrequenciesAsync(IFetch fetch, FetchEntity fetchEntity, int n)
        {
            if (fetch.Frequencies != null && fetch.Frequencies.Any())
            {
                foreach (var frequency in fetch.Frequencies.Take(n))
                {
                    var frequencyEntity = _context.Frequencies.FirstOrDefault(f => f.Fetch.Source == fetchEntity.Source);
                    if (frequencyEntity == null)
                    {
                        var salt = _encryptionService.NewSalt;
                        var saltedHash = _encryptionService.SaltedHash(frequency.Word, salt);
                        frequencyEntity = new FrequencyEntity();
                        frequencyEntity.Fetch = fetchEntity;
                        frequencyEntity.SaltedHash = saltedHash;
                        frequencyEntity.EncryptedWord = _encryptionService.EncryptedWord(frequency.Word, saltedHash);
                        frequencyEntity.Count = frequency.Count;
                        _context.Frequencies.Add(frequencyEntity);
                    }
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
