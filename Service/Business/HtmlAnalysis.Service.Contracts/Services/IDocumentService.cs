using HtmlAnalysis.Domain.Data;
using System.Threading.Tasks;

namespace HtmlAnalysis.Service.Contracts.Services
{
    public interface IDocumentService
    {
        Task<Document> DownloadIntoDocumentAsync(string url);
    }
}