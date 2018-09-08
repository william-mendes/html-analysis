using System.Threading.Tasks;

namespace HTMLAnalysis.Domain.Documents
{
    public interface IDocumentService
    {
        Task<Document> DownloadIntoDocumentAsync(string url);
    }
}