using System.Collections.Generic;

namespace HTMLAnalysis.Domain.NLP
{
    public class AzureNlpRequest
    {
        public AzureNlpRequest(
            IEnumerable<string> analyzerIds,
            string language,
            string text) {

            AnalyzerIds = analyzerIds;
            Language = language;
            Text = text;
        }


        public IEnumerable<string> AnalyzerIds { get; private set; }

        public string Language { get; private set; }

        public string Text { get; private set; }
    }
}
