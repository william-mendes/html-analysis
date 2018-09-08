using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTMLAnalysis.Domain.Frequencies
{
    public interface IFrequencyService
    {
        Task<List<Frequency>> GetAll();
    }
}
