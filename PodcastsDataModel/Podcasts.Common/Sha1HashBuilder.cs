using System;
using System.Security.Cryptography;
using System.Text;

namespace Podcasts.Common
{
    public class Sha1HashBuilder : IHashBuilder
    {
        public string Build(string text)
        {
            using (var hashProvider = new SHA1CryptoServiceProvider())
            {
                const string salt = "ThisIsASalt";

                byte[] saltedText = Encoding.UTF8.GetBytes(string.Concat(text, salt));
                byte[] hashedText = hashProvider.ComputeHash(saltedText);
                hashProvider.Clear();
                return Convert.ToBase64String(hashedText); 
            }

        }
    }
}