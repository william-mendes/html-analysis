using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTMLAnalysis.Domain.Frequencies
{
    public class FrequencyRepository : IFrequencyRepository
    {
        public Task<IEnumerable<IFrequency>> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
