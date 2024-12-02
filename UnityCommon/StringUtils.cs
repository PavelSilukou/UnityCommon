using System.Text;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace UnityCommon
{
    public static class StringUtils
    {
        public static string Join(string separator, object[,] objects)
        {
            var resultStr = new StringBuilder();
            for (var i = 0; i < objects.GetLength(0); i++)
            {
                resultStr.Append(string.Join(separator, objects.GetRow(i))); 
            }

            return resultStr.ToString();
        }
    }
}
