using System.Collections.Generic;

namespace HTMLAnalysis.Domain
{
    /// <summary>
    /// The result of a fetch execution, in which a <see cref="IDocument"/>
    /// is downloaded from a source and has its word frequencies analysed.
    /// </summary>
    public interface IFetch
    {
        /// <summary>
        /// The source of the document, e.g.: a Url
        /// </summary>
        /// <value>The source.</value>
        string Source { get; }

        /// <summary>
        /// The word frequency observed in the document
        /// </summary>
        /// <value>The frequencies.</value>
        IEnumerable<IFrequency> Frequencies { get; }

        /// <summary>
        /// Returns the frequency of a particular word in the corpus of
        /// the analysed <see cref="IDocument"/>, if available.
        /// </summary>
        /// <returns>The frequency of the word, if available.</returns>
        /// <param name="word">Word.</param>
        int? FrequencyOf(string word);
    }
}