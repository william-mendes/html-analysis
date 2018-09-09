using System.Threading.Tasks;

namespace HTMLAnalysis.Domain
{
    /// <summary>
    /// Provides domain logic related to <see cref="IDocument"/>
    /// but that is external to it.
    /// </summary>
    public interface IDocumentService
    {
        /// <summary>
        /// Downloads a HTML page from the internet and create a <see cref="IDocument"/>
        /// representing such HTML page.
        /// </summary>
        /// <returns>The into document async.</returns>
        /// <param name="url">URL.</param>
        Task<IDocument> DownloadIntoDocumentAsync(string url);
    }
}