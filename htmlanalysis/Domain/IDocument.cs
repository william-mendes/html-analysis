using System.Collections.Generic;

namespace HTMLAnalysis.Domain
{
    /// <summary>
    /// A representation of a document with a corpus (body) that can have
    /// its fragments analysed, such as per phrase and per words.
    /// </summary>
    public interface IDocument
    {
        /// <summary>
        /// The source of the document, e.g.: a Url
        /// </summary>
        /// <value>The source.</value>
        string Source { get; }

        /// <summary>
        /// The body or corpus of the document, on top of which analysis may
        /// be performed.
        /// </summary>
        /// <value>The body.</value>
        string Body { get; }

        /// <summary>
        /// Phrases segmentation broken by tokens provided by <see cref="Tokenization.Tokens"/>
        /// </summary>
        /// <value>The phrases.</value>
        IEnumerable<string> Phrases { get; }

        /// <summary>
        /// Word segmentation using broken by tokens provided by <see cref="Tokenization.Tokens"/>.
        /// </summary>
        /// <value>The words.</value>
        IEnumerable<string> Words { get; }
    }
}
