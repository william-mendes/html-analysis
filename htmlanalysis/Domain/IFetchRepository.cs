namespace HTMLAnalysis.Domain
{
    /// <summary>
    /// Allows managing persitence of <see cref="IFetch"/>.
    /// </summary>
    public interface IFetchRepository
    {
        /// <summary>
        /// Persists <see cref="IFetch"/>
        /// </summary>
        /// <param name="fetch">Fetch.</param>
        void Persist(IFetch fetch);
    }
}
