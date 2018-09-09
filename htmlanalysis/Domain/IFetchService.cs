using HTMLAnalysis.Domain.Documents;

namespace HTMLAnalysis.Domain
{
    /// <summary>
    /// Provides domain logic that is related to <see cref="IFetch"/>
    /// but external to it.
    /// </summary>
    public interface IFetchService
    {
        /// <summary>
        /// Responsible for analysing frequencies of a given <see cref="IDocument"/>,
        /// storing the relevant statistics and returning <see cref="IFetch"/>
        /// with the statistical result of the analysis.
        /// </summary>
        /// <returns>An instance of <see cref="IFetch"/> with statistical information about the <see cref="IDocument"/></returns>
        /// <param name="document">Document to be analysed.</param>
        IFetch Analyse(IDocument document);
    }
}