﻿using System.Security.Cryptography;
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
            str = bytes.ToReadableString();
            return str;
        }
    }
}
