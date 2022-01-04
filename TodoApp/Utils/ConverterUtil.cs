using System.Text;

namespace TodoApp.Utils
{
    public static class ConverterUtil
    {
        public static string ToReadableString(this byte[] bytes)
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
