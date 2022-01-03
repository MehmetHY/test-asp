using System.Security.Cryptography;
using System.Text;

namespace TodoApp.Utils
{
    public static class HashUtil
    {
        public static void ToHashSha256(this string? str)
        {
            if (str == null) return;
            using var sha256 = SHA256.Create();
            var chars = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
            str = chars.ToString();
        }
    }
}
