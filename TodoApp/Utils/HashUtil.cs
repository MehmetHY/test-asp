using System.Security.Cryptography;
using System.Text;

namespace TodoApp.Utils
{
    public static class HashUtil
    {
        public static string ToHashSha256(this string? str)
        {
            if (str == null) return string.Empty;
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
            str = bytes.ToReadableFormat();
            return str;
        }

        public static string ToTrimmedHashSha256(this string? str)
        {
            if (str == null) return string.Empty;
            str = str.Trim();
            return str.ToHashSha256();
        }

        public static string ToReadableFormat(this byte[] bytes)
        {
            StringBuilder sb = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
