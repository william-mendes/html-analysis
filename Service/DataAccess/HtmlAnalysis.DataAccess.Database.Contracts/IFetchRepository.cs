using HtmlAnalysis.Domain.Data;
using System.Threading.Tasks;

namespace HtmlAnalysis.DataAccess.Database.Contracts
{
    public interface IFetchRepository
    {
        Task PersistAsync(Fetch fetch, int n);
    }
}