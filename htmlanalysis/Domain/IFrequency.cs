namespace HTMLAnalysis.Domain
{
    /// <summary>
    /// The representation of frequencies (count) of a single word in a corpus.
    /// </summary>
    public interface IFrequency
    {
        /// <summary>
        /// Gets the word.
        /// </summary>
        /// <value>The word.</value>
        string Word { get; }

        /// <summary>
        /// Gets the frequency (count) of that word in the corpus.
        /// </summary>
        /// <value>The count.</value>
        int Count { get; }
    }
}