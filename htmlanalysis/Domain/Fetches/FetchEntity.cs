using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HTMLAnalysis.Domain.Frequencies;

namespace HTMLAnalysis.Domain.Fetches
{
    public class FetchEntity
    {
        [Key]
        public string Source { get; set; }

        [Timestamp]
        public DateTime Timestamp { get; set; }

        public virtual ICollection<FrequencyEntity> Frequencies { get; set; }
    }
}