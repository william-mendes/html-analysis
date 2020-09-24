using HtmlAnalysis.Domain.Data;
using System.Threading.Tasks;

namespace HtmlAnalysis.Service.Contracts.Services
{
    public interface IFetchService
    {
        Task<Fetch> ProcessAsync(Document document);
    }
}