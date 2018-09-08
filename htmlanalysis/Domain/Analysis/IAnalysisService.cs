using HTMLAnalysis.Domain.Documents;

namespace HTMLAnalysis.Domain.Analysis
{
    public interface IAnalysisService
    {
        AnalysisResult Analyse(Document document);
    }
}