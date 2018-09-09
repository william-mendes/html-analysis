using System.ComponentModel.DataAnnotations;
using HTMLAnalysis.Domain.Fetches;

namespace HTMLAnalysis.Domain.Frequencies
{
    public class FrequencyEntity
    {
        public virtual FetchEntity Analysis { get; set; }

        [Key]
        public string SaltedHash { get; set; }

        public string EncryptedWord { get; set; }

        public int Count { get; set; }
    }
}
