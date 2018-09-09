using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTMLAnalysis.Domain.Frequencies
{
    public interface IFrequencyRepository
    {
        Task<IEnumerable<IFrequency>> GetAll();
    }
}
