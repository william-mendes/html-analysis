using System;
using System.Security.Cryptography;
using System.Text;

namespace HTMLAnalysis.Domain.Encryption
{
    public class EncryptionService : IEncryptionService, IDisposable
    {
        const int SaltLength = 32;

        readonly SHA256Managed _hashProvider;
        readonly RNGCryptoServiceProvider _saltProvider;
        readonly RSACryptoServiceProvider _cryptoProvider;
        readonly Encoding _encoding;

        public EncryptionService()
        {
            _hashProvider = new SHA256Managed();
            _saltProvider = new RNGCryptoServiceProvider();
            _cryptoProvider = new RSACryptoServiceProvider();
            _encoding = Encoding.UTF8;
        }

        public void Dispose()
        {
            _saltProvider.Dispose();
            _cryptoProvider.Dispose();
        }

        public string NewSalt
        {
            get
            {
                var random = new RNGCryptoServiceProvider();
                var salt = new byte[SaltLength];
                random.GetNonZeroBytes(salt);
                return Convert.ToBase64String(salt);
            }
        }

        public string SaltedHash(string word, string salt)
        {
            var input = string.Concat(word, salt);
            var data = _hashProvider.ComputeHash(_encoding.GetBytes(input));
            var builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                builder.Append(data[i].ToString("x2"));
            return builder.ToString();
        }

        public string EncryptedWord(string word)
        {
            var encryptedWord = _cryptoProvider.EncryptValue(_encoding.GetBytes(word));
            return Convert.ToBase64String(encryptedWord);
        }

        public string DecryptWord(string encryptedWord)
        {
            var decryptedBuffer = _cryptoProvider.EncryptValue(_encoding.GetBytes(encryptedWord));
            return _encoding.GetString(decryptedBuffer);
        }

    }
}