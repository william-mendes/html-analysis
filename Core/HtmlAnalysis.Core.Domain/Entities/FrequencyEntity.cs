using System.ComponentModel.DataAnnotations;

namespace HtmlAnalysis.Core.Domain.Entities
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