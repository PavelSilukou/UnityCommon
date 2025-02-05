// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using System.Text;

namespace UnityCommon
{
    public static class ByteArrayExtensions
    {
        public static string GetString(this byte[] array)
        {
            return Encoding.UTF8.GetString(array);
        }
    }
}