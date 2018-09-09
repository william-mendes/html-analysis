using System.Threading.Tasks;

namespace HTMLAnalysis.Domain
{
    /// <summary>
    /// Allows managing persitence of <see cref="IFetch"/>.
    /// </summary>
    public interface IFetchRepository
    {
        /// <summary>
        /// Persists <see cref="IFetch"/> saving a given N
        /// number of <see cref="IFrequency"/> that will also be persisted.
        /// </summary>
        /// <param name="fetch">Fetch.</param>
        /// <param name="n">How many frequency entries are to be saved.</param>
        Task PersistAsync(IFetch fetch, int n);
    }
}