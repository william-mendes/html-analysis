using System.Collections.Generic;

namespace HTMLAnalysis.Domain.NLP
{
    public interface INlpService
    {
        IEnumerable<string> Parse(string phrase);

    }
}
