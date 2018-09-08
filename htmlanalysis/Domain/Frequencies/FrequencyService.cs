using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTMLAnalysis.Domain.Frequencies
{
    public class FrequencyService : IFrequencyService
    {
        public async Task<List<Frequency>> GetAll()
        {
            var result = new List<Frequency>()
            {
                new Frequency("word", 2),
                new Frequency("bla", 5),
            };

            return result;
        }
    }
}