using AuthService.Service.Contracts;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Service.Services
{
    public class CypherService
    {
        public static string Encrypt(string input)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));

            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public static bool Compare(string input, string hash)
        {
            string inputHash = Encrypt(input);
            return string.Equals(inputHash, hash, StringComparison.OrdinalIgnoreCase);
        }

        public static bool EncryptAndCompare(string input, string input2)
        {
            string inputHash = Encrypt(input);
            string input2Hash = Encrypt(input2);
            return string.Equals(inputHash, input2Hash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
