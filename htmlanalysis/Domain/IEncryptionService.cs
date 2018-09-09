namespace HTMLAnalysis.Domain
{
    /// <summary>
    /// Provides Encryption Features to the Domain.
    /// </summary>
    public interface IEncryptionService
    {
        /// <summary>
        /// Generates and returns a new random Salt.
        /// </summary>
        /// <value>The new salt.</value>
        string NewSalt { get; }

        /// <summary>
        /// Returns hash from the salted word, created server side key.
        /// </summary>
        /// <returns>The hash.</returns>
        /// <param name="word">Word to be salted and hashed</param>
        /// <param name="salt">Salt to salt the word and be hashed.</param>
        string SaltedHash(string word, string salt);

        /// <summary>
        /// The encrypted word using the salted hash.
        /// </summary>
        /// <returns>The password.</returns>
        /// <param name="word">Word.</param>
        /// <param name="saltedHash">Salted hash.</param>
        string EncryptWord(string word);

        /// <summary>
        /// Decrypts the word.
        /// </summary>
        /// <returns>The word.</returns>
        /// <param name="word">Word.</param>
        string DecryptWord(string word);
    }
}