using HtmlAnalysis.Service.Contracts.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Cryptography;
using System.Text;

namespace HtmlAnalysis.Service.Implementation.Services
{
    public class EncryptionService : IEncryptionService, IDisposable
    {
        const int SaltLength = 32;

        readonly Encoding _encoding;
        readonly RSACryptoServiceProvider _cryptoProvider;
        readonly RNGCryptoServiceProvider _saltProvider;
        readonly SHA256Managed _hashProvider;

        public EncryptionService(IConfiguration configuration)
        {
            _cryptoProvider = new RSACryptoServiceProvider();
            var encryptionKey = configuration.GetSection("EncryptionKey").Value;
            _cryptoProvider.ImportCspBlob(Convert.FromBase64String(encryptionKey));

            _saltProvider = new RNGCryptoServiceProvider();
            _hashProvider = new SHA256Managed();
            _encoding = Encoding.UTF8;
        }

        public void Dispose()
        {
            _hashProvider.Dispose();
            _saltProvider.Dispose();
            _cryptoProvider.Dispose();
        }

        public string NewSalt
        {
            get
            {
                var salt = new byte[SaltLength];
                _saltProvider.GetNonZeroBytes(salt);
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

        public string EncryptWord(string word)
        {
            var encryptedWord = _cryptoProvider.Encrypt(_encoding.GetBytes(word), false);
            return Convert.ToBase64String(encryptedWord);
        }

        public string DecryptWord(string encryptedWord)
        {
            var decryptedBuffer = _cryptoProvider.Decrypt(Convert.FromBase64String(encryptedWord), false);
            return _encoding.GetString(decryptedBuffer);
        }

    }
}