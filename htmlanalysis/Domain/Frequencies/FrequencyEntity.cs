using System.ComponentModel.DataAnnotations;
using HTMLAnalysis.Domain.Fetches;

namespace HTMLAnalysis.Domain.Frequencies
{
    public class FrequencyEntity
    {
        public virtual FetchEntity Fetch { get; set; }

        [Key]
        public string SaltedHash { get; set; }

        [Required]
        public string EncryptedWord { get; set; }

        public int Count { get; set; }
    }
}