using System.Security.Cryptography;
using System.Text;

namespace SimpleCMS.Core.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static byte[] CalculateSHA1Hash(this string value)
        {
            var encoding = new UnicodeEncoding();
            var valueBytes = encoding.GetBytes(value ?? string.Empty);

            var sha = new SHA1Managed();
            return sha.ComputeHash(valueBytes);
        }
    }
}
