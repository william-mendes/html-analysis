using System.Collections.Generic;

namespace HTMLAnalysis.Domain
{
    /// <summary>
    /// Provides domain logic that is related to <see cref="INlp"/>
    /// but that is external to it.
    /// </summary>
    public interface INlpService
    {
        /// <summary>
        /// Returns an instance of <see cref="INlp"/> containing the parse
        /// tree result of the phrase.
        /// </summary>
        /// <returns>The parse tree.</returns>
        /// <param name="phrase">Phrase.</param>
        INlp Parse(string phrase);

    }
}
