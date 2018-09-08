using System.Collections.Generic;

namespace HTMLAnalysis.Domain.NLP
{
    public class AzureNlpResponse
    {
        public string AnalyzerId { get; set; }

        public IEnumerable<string> Result { get; set; }
    }
}
