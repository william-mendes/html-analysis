using HtmlAnalysis.Core.Domain.Data;
using System.Collections.Generic;

namespace HtmlAnalysis.DataAccess.Database.Contracts
{
    public interface IFrequencyRepository
    {
        IEnumerable<Frequency> GetConsolidated();
    }
}