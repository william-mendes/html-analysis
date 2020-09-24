namespace HtmlAnalysis.Service.Contracts.Services
{
    public interface IEncryptionService
    {
        string NewSalt { get; }

        string SaltedHash(string word, string salt);

        string EncryptWord(string word);

        string DecryptWord(string word);
    }
}