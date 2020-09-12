using HtmlAnalysis.Core.Domain.Data;
using HtmlAnalysis.Core.Domain.Entities;

namespace HtmlAnalysis.Service.Contracts.Adapters
{
    public interface IFrequencyAdapter
    {
        Frequency ToIFrequency(FrequencyEntity entity);

        FrequencyEntity ToFrequencyEntity(Frequency frequency);
    }
}