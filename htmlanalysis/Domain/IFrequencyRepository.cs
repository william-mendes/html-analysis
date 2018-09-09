using System.Collections.Generic;

namespace HTMLAnalysis.Domain.Frequencies
{
    public interface IFrequencyRepository
    {
        IEnumerable<IFrequency> GetAll();
    }
}
