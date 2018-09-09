using HTMLAnalysis.Domain.Frequencies;

namespace HTMLAnalysis.Domain
{
    public interface IFrequencyAdapter
    {
        IFrequency ToIFrequency(FrequencyEntity entity);

        FrequencyEntity ToFrequencyEntity(IFrequency frequency);
    }
}