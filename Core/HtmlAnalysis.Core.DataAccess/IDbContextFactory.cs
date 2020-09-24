using Microsoft.EntityFrameworkCore;

namespace HtmlAnalysis.Core.DataAccess
{
    public interface IDbContextFactory
    {
        DbContext GetContext();
    }
}
