namespace HTMLAnalysis.Domain
{
    /// <summary>
    /// Represents the recursive tree that has structural
    /// information about a particular section of the phrase.
    /// </summary>
    public interface INlpParseTree
    {
        /// <summary>
        /// Gets the identifier of the tree section
        /// </summary>
        /// <value>The key.</value>
        string Key { get; }

        /// <summary>
        /// Gets the classification of the tree section.
        /// </summary>
        /// <value>The classification.</value>
        string Classification { get; }

        /// <summary>
        /// Gets the children of the tree section, if any is available.
        /// </summary>
        /// <value>The children.</value>
        INlpParseTree Children { get; }
    }
}