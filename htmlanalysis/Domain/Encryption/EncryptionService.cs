using System;
using System.Security.Cryptography;

namespace HTMLAnalysis.Domain.Encryption
{
    public class EncryptionService : IEncryptionService
    {
        const int SaltLength = 32;

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

        public string EncryptedWord(string password, string saltedHash)
        {
            throw new System.NotImplementedException();
        }

        public string SaltedHash(string word, string salt)
        {
            throw new System.NotImplementedException();
        }

        public string UnhashSaltedHash(string saltedHash)
        {
            throw new NotImplementedException();
        }

        public string UnsaltSaltedWord(object saltedWord)
        {
            throw new NotImplementedException();
        }
    }
}
