using HTMLAnalysis.Domain.Documents;

namespace HTMLAnalysis.Domain.Analysis
{
    public class AnalysisService : IAnalysisService
    {
        public AnalysisResult Analyse(Document document)
        {
            return new AnalysisResult(document);
        }
    }
}
