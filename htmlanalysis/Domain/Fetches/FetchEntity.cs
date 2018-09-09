using System;
using System.ComponentModel.DataAnnotations;

namespace HTMLAnalysis.Domain.Fetches
{
    public class FetchEntity
    {
        [Key]
        public string Url { get; set; }

        [Timestamp]
        public DateTime Timestamp { get; set; }
    }
}
