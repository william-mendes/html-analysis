using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HtmlAnalysis.Core.Domain.Entities
{
    public class FetchEntity
    {
        [Key]
        public string Source { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<FrequencyEntity> Frequencies { get; set; }
    }
}