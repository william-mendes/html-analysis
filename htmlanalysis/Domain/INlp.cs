namespace HTMLAnalysis.Domain
{
    /// <summary>
    /// Represents the result of an NLP analysis run on a phrase.
    /// </summary>
    public interface INlp
    {
        /// <summary>
        /// Gets the phrase.
        /// </summary>
        /// <value>The phrase.</value>
        string Phrase { get; }

        /// <summary>
        /// Gets the parse tree.
        /// </summary>
        /// <value>The parse tree.</value>
        INlpParseTree ParseTree { get; }
    }
}
