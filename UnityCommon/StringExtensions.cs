using System;
using System.Text;

namespace UnityCommon
{
    public static class StringExtensions
    {
        public static string CapitalizeFirstLetter(this string str)
        {
            return char.ToUpper(str[0]) + str[1..];
        }

        public static byte[] ToByteArray(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public static string ToBase64String(this string str)
        {
            return Convert.ToBase64String(str.ToByteArray());
        }

        public static string ToStringFromBase64(this string str)
        {
            var data = Convert.FromBase64String(str);
            return data.GetString();
        }
    }
}
